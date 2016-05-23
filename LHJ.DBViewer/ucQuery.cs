using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.DBService;
using Oracle.DataAccess.Client;
using System.Diagnostics;

namespace LHJ.DBViewer
{
    public partial class ucQuery : UserControl
    {
        const int LINE_HEIGHT = 20;
        const int BASE_LINES = 5;
        const int BASE_HEIGHT = LINE_HEIGHT * BASE_LINES;
        const int SCROLL_HEIGHT = 34;
        const int SCROLL_WIDTH = 70;
        const int QUERY_ROW_CNT = 150;

        private string m_Query = string.Empty;
        private DataTable m_DTDataSource = null; 

        public ucQuery()
        {
            InitializeComponent();
        }

        public void SetFocusDDLBox()
        {
            this.txtSqlArea.Focus();
        }

        public void AddObjectName(string aObjectName)
        {
            this.txtSqlArea.Text += aObjectName;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    //Form1 frmMain = (Form1)this.MdiParent;
                    //frmMain.SaveFileDialog();
                    break;

                case Keys.Control | Keys.Down:
                    ExecuteQuery(false, 0, true);
                    break;

                case Keys.F7:
                    ExecuteQuery(false, 0, false);
                    break;

                case Keys.F9:
                    //ExecuteCommit();
                    break;

                case Keys.F11:
                    //ExecuteRollback();
                    break;

                case Keys.Control | Keys.P:
                    ExecuteExplainPlan();
                    break;

                default:
                    /// nothing to do here ... move along
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ExecuteExplainPlan()
        {
            // local variables
            String ExplainCmd = "";

            if (!Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                MessageBox.Show("You are not connected", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.m_Query = string.Empty;
            this.dgvQueryResult.DataSource = null;
            this.m_DTDataSource = new DataTable();

            if (string.IsNullOrEmpty(txtSqlArea.SelectedText))
            {
                //strQuery = txtSqlArea.Text.TrimEnd(';');

                //2015.08.27 이호준 수정
                string[] query = txtSqlArea.Text.Split(';');
                int totLength = 0;

                for (int cnt = 0; cnt < query.Length; cnt++)
                {
                    totLength += query[cnt].Length + 1;

                    if (txtSqlArea.SelectionStart > totLength)
                    {
                        continue;
                    }
                    else
                    {
                        this.m_Query = query[cnt];
                        break;
                    }
                }
                //2015.08.27 이호준 수정
            }
            else
            {
                this.m_Query = txtSqlArea.SelectedText.TrimEnd(';');
            }

            if (this.m_Query != "")
            {
                this.Cursor = Cursors.WaitCursor;

                Stopwatch sw1 = new Stopwatch();
                sw1.Start();

                // Executing the explain plan for current SQL
                ExplainCmd = "explain plan for " + this.m_Query;

                try
                {
                    Common.Comm.DBWorker.ExecuteNonQuery("delete from plan_table");
                    Common.Comm.DBWorker.ExecuteNonQuery(ExplainCmd);

                    ExplainCmd = "SELECT ID, PARENT_ID," +
                                    "substr (lpad(' ', (level-1) * 3) || operation || ' (' || options || ')',1,30 ) \"Operation\", " +
                                    "object_name   \"Object\", " +
                                    "cost, cardinality, bytes, access_predicates " +
                                 "from plan_table " +
                                 "start with id = 0 " +
                                 "connect by prior id=parent_id";

                    this.m_DTDataSource = Common.Comm.DBWorker.ExecuteDataTable(ExplainCmd);
                    this.dgvQueryResult.DataSource = this.m_DTDataSource;

                    sw1.Stop();
                    this.tsslQueryResultDelay.Text = string.Format("{0} Secs", Math.Round(sw1.Elapsed.TotalSeconds, 3).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        public void ExecuteQuery(bool aScrolled, int aLastScrollIndex, bool aAllQuery)
        {
            bool isSelect;
            String trimmedSQL;

            if (txtSqlArea.ReadOnly) // do nothing if in "Read only" mode
            {
                return;
            }

            if (!Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                MessageBox.Show("You are not connected", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            if (!aScrolled)
            {
                this.m_Query = string.Empty;
                this.dgvQueryResult.DataSource = null;
                this.m_DTDataSource = new DataTable();

                // Check if user selected text to run
                if (string.IsNullOrEmpty(txtSqlArea.SelectedText))
                {
                    //strQuery = txtSqlArea.Text.TrimEnd(';');

                    //2015.08.27 이호준 수정
                    string[] query = txtSqlArea.Text.Split(';');
                    int totLength = 0;

                    for (int cnt = 0; cnt < query.Length; cnt++)
                    {
                        totLength += query[cnt].Length + 1;

                        if (txtSqlArea.SelectionStart > totLength)
                        {
                            continue;
                        }
                        else
                        {
                            this.m_Query = query[cnt];
                            break;
                        }
                    }
                    //2015.08.27 이호준 수정
                }
                else
                {
                    this.m_Query = txtSqlArea.SelectedText.TrimEnd(';');
                }
            }

            if (!string.IsNullOrEmpty(this.m_Query))
            {
                Common.Comm.Logger.Info(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("Execute Query!\r\nSQL : {0}", this.m_Query));

                trimmedSQL = this.m_Query.Trim().ToUpper();
                isSelect = trimmedSQL.StartsWith("SELECT");

                try
                {
                    // Executing the Select command and showing the data grid 
                    if (isSelect)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (aAllQuery)
                        {
                            this.m_DTDataSource = Common.Comm.DBWorker.ExecuteDataTable(this.m_Query);
                            dgvQueryResult.DataSource = this.m_DTDataSource;
                            this.tsslRowCount.Text = string.Format("{0} of {1}", "1", dgvQueryResult.Rows.Count.ToString());
                        }
                        else
                        {
                            if (!aScrolled)
                            {
                                this.m_DTDataSource = Common.Comm.DBWorker.ExecuteDataTable(this.m_Query, this.m_DTDataSource.Rows.Count, QUERY_ROW_CNT, "Table1", null);
                                dgvQueryResult.DataSource = this.m_DTDataSource;
                                this.tsslRowCount.Text = string.Format("{0} of {1}", "1", dgvQueryResult.Rows.Count.ToString());
                            }
                            else
                            {
                                DataTable dt = Common.Comm.DBWorker.ExecuteDataTable(this.m_Query, this.m_DTDataSource.Rows.Count, QUERY_ROW_CNT, "Table1", null);
                                this.m_DTDataSource.Merge(dt);
                            }
                        }

                        sw1.Stop();
                        this.tsslQueryResultDelay.Text = string.Format("{0} Secs", Math.Round(sw1.Elapsed.TotalSeconds, 3).ToString());

                        if (aScrolled)
                        {
                            dgvQueryResult.FirstDisplayedScrollingRowIndex = aLastScrollIndex;
                            dgvQueryResult.Refresh();
                            dgvQueryResult.CurrentCell = dgvQueryResult.Rows[aLastScrollIndex].Cells[0];
                            dgvQueryResult.Rows[aLastScrollIndex].Selected = true;
                        }
                    }
                    else // if not SELECT statement, execute the DML/DDL Command
                    {
                        // executing the command
                        this.Cursor = Cursors.WaitCursor;
                        int n = Common.Comm.DBWorker.ExecuteNonQuery(this.m_Query);
                        this.Cursor = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

            } // if SQL Area text is null
        }

        private void dgvQueryResult_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (((e.NewValue + this.dgvQueryResult.DisplayedRowCount(false)) >= this.m_DTDataSource.Rows.Count) && (this.m_DTDataSource.Rows.Count >= QUERY_ROW_CNT))
                {
                    ExecuteQuery(true, e.NewValue, false);
                }
            }
        }

        private void dgvQueryResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsslRowCount.Text = string.Format("{0} of {1}", (e.RowIndex + 1).ToString(), dgvQueryResult.Rows.Count.ToString());
        }
    }
}
