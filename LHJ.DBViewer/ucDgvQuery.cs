using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Controls;

namespace LHJ.DBViewer
{
    public class ucDgvQuery : ucDataGridView
    {
        #region 1.Variable
        private DataTable mDTSource;
        private string mQuery;
        const int QUERY_ROW_CNT = 150;
        #endregion 1.Variable


        #region 2.Property
        public string Query { get; set; }
        #endregion 2.Property


        #region 3.Constructor
        public ucDgvQuery()
        {
            this.Scroll += this.ucDgvQuery_Scroll;
            this.DataSourceChanged += this.ucDgvQuery_DataSourceChanged;
        }
        #endregion 3.Constructor


        #region 4.Override Method
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    this.ExportExcelQueryResult();
                    break;

                case Keys.Control | Keys.Down:
                    this.ExecuteQuery(false, 0, true);
                    break;

                default:
                    /// nothing to do here ... move along
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method
        public void ExportExcelQueryResult()
        {
            this.Cursor = Cursors.WaitCursor;
            this.ExportToExcel("쿼리결과");
            this.Cursor = Cursors.Default;
        }

        public void ExecuteQuery(bool aScrolled, int aLastScrollIndex, bool aAllQuery)
        {
            bool isSelect;
            String trimmedSQL;

            if (!Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                MessageBox.Show("You are not connected", "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(Query))
            {
                Common.Comm.Logger.Info(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("Execute Query!\r\nSQL : {0}", Query));

                trimmedSQL = Query.Trim().ToUpper();
                isSelect = trimmedSQL.StartsWith("SELECT");

                try
                {
                    if (isSelect)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        Common.Control.LoadingControl.SplashWnd.SplashShow();

                        if (aAllQuery)
                        {
                            this.mDTSource = Common.Comm.DBWorker.ExecuteDataTable(Query);
                            this.DataSource = this.mDTSource;
                        }
                        else
                        {
                            if (!aScrolled)
                            {
                                this.mDTSource = Common.Comm.DBWorker.ExecuteDataTable(Query, 0, QUERY_ROW_CNT, "Table1", null);
                                this.DataSource = this.mDTSource;
                            }
                            else
                            {
                                DataTable dt = Common.Comm.DBWorker.ExecuteDataTable(Query, this.mDTSource.Rows.Count, QUERY_ROW_CNT, "Table1", null);
                                this.mDTSource.Merge(dt);
                            }
                        }

                        Common.Control.LoadingControl.SplashWnd.SplashClose();

                        if (aScrolled)
                        {
                            this.FirstDisplayedScrollingRowIndex = aLastScrollIndex;
                            this.Refresh();
                            this.CurrentCell = this.Rows[aLastScrollIndex].Cells[0];
                            this.Rows[aLastScrollIndex].Selected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.Control.LoadingControl.SplashWnd.SplashClose();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            } 
        }
        #endregion 6.Method


        #region 7.Event
        private void ucDgvQuery_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (((e.NewValue + this.DisplayedRowCount(false)) >= this.mDTSource.Rows.Count) && (this.mDTSource.Rows.Count >= QUERY_ROW_CNT))
                {
                    this.ExecuteQuery(true, e.NewValue, false);
                }
            }
        }

        private void ucDgvQuery_DataSourceChanged(object sender, EventArgs e)
        {
            ucDgvQuery dgv = sender as ucDgvQuery;

            if (dgv != null)
            {
                dgv.AutoResizeColumn();
            }
        }
        #endregion 7.Event
    }
}
