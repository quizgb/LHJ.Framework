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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    //Form1 frmMain = (Form1)this.MdiParent;
                    //frmMain.SaveFileDialog();
                    break;

                case Keys.F7:
                    ExecuteQuery(false, 0);
                    break;

                case Keys.F9:
                    //ExecuteCommit();
                    break;

                case Keys.F11:
                    //ExecuteRollback();
                    break;

                case Keys.Control | Keys.P:
                    //ExecuteExplainPlan();
                    break;

                default:
                    /// nothing to do here ... move along
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ExecuteQuery(bool aScrolled, int aLastScrollIndex)
        {
            // local variables
            bool isSelect;
            String trimmedSQL;
            List<String> lSQLStrings = new List<String>();
            int currSQLStringInd = 1;

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
                // checking type of SQL command
                trimmedSQL = this.m_Query.Trim().ToUpper();
                isSelect = trimmedSQL.StartsWith("SELECT");

                // Inserting the new text to the SQL's list (after reomving all occurances of that SQL
                lSQLStrings.RemoveAll(delegate (String s) { return s.Equals(this.m_Query); });
                lSQLStrings.Add(this.m_Query);
                currSQLStringInd = lSQLStrings.Count;

                try
                {
                    // Executing the Select command and showing the data grid 
                    if (isSelect)
                    {
                        this.Cursor = Cursors.WaitCursor;

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

                        sw1.Stop();
                        this.tsslQueryResultDelay.Text = sw1.Elapsed.TotalSeconds.ToString();

                        this.Cursor = Cursors.Default;

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
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } // if SQL Area text is null
        }

        private void dgvQueryResult_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if ((e.NewValue + this.dgvQueryResult.DisplayedRowCount(false)) >= this.m_DTDataSource.Rows.Count)
                {
                    ExecuteQuery(true, e.NewValue);
                }
            }
        }

        private void dgvQueryResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.tsslRowCount.Text = string.Format("{0} of {1}", e.RowIndex, dgvQueryResult.Rows.Count);
        }
    }
}
