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

namespace LHJ.DBViewer
{
    public partial class ucQuery : UserControl
    {
        const int LINE_HEIGHT = 20;
        const int BASE_LINES = 5;
        const int BASE_HEIGHT = LINE_HEIGHT * BASE_LINES;
        const int SCROLL_HEIGHT = 34;
        const int SCROLL_WIDTH = 70;

        public ucQuery()
        {
            InitializeComponent();
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
                    ExecuteQuery();
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

        public void ExecuteQuery()
        {
            // local variables
            bool isSelect;
            String trimmedSQL;
            DataSet ds = new DataSet();
            List<String> lSQLStrings = new List<String>();
            int currSQLStringInd = 1;
            String strQuery = null;

            if (txtSqlArea.ReadOnly) // do nothing if in "Read only" mode
            {
                return;
            }
            if (!Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                MessageBox.Show("You are not connected", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // clear the grids data source
            dgvQueryResult.DataSource = null;

            if (ds != null)
            {
                ds.Clear();
            }

            // Check if user selected text to run
            if (txtSqlArea.SelectedText == "")
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
                        strQuery = query[cnt];
                        break;
                    }
                }
                //2015.08.27 이호준 수정
            }
            else
            {
                strQuery = txtSqlArea.SelectedText.TrimEnd(';');
            }

            if (strQuery != "")
            {
                // checking type of SQL command
                trimmedSQL = strQuery.Trim().ToUpper();
                isSelect = trimmedSQL.StartsWith("SELECT");

                // Inserting the new text to the SQL's list (after reomving all occurances of that SQL
                lSQLStrings.RemoveAll(delegate (String s) { return s.Equals(strQuery); });
                lSQLStrings.Add(strQuery);
                currSQLStringInd = lSQLStrings.Count;

                try
                {
                    // Executing the Select command and showing the data grid 
                    if (isSelect)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        ds = Common.Comm.DBWorker.ExecuteDataSet(strQuery, 0, 100, "Table1", null);
                        dgvQueryResult.DataSource = ds.Tables[0];
            
                        this.Cursor = Cursors.Default;

                        // Set the sizes of the text area and grid view
                        txtSqlArea.Height = Math.Max((txtSqlArea.Lines.Length + 1) * LINE_HEIGHT, BASE_HEIGHT);
                        txtSqlArea.Width = this.Width - SCROLL_WIDTH;
                        dgvQueryResult.Width = this.Width - SCROLL_WIDTH;
                        dgvQueryResult.Height = this.Height - txtSqlArea.Height - SCROLL_HEIGHT;
                        dgvQueryResult.Location = new Point(0, txtSqlArea.Height);
                        dgvQueryResult.Visible = true;
                    }
                    else // if not SELECT statement, execute the DML/DDL Command
                    {
                        // executing the command
                        this.Cursor = Cursors.WaitCursor;
                        int n = Common.Comm.DBWorker.ExecuteNonQuery(strQuery);
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
            if ((e.NewValue + this.dgvQueryResult.DisplayedRowCount(false)).Equals(100))
            {
                ExecuteQuery();
            }
        }
    }
}
