using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.DBViewer
{
    public partial class frmSQLWindow : Form
    {
        #region 1.Variable
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmSQLWindow()
        {
            InitializeComponent();

            this.SetInitialize();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {
            this.tsbtnAddTab.PerformClick();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetCtrlEnabledByTabPageCnt()
        {
            if (this.tabControl1.TabPages.Count > 0)
            {
                this.tsbtnExecuteQuery.Enabled = true;
                this.tsbtnExportExcel.Enabled = true;
                this.tsbtnCommit.Enabled = true;
                this.tsbtnRollback.Enabled = true;
            }
            else
            {
                this.tsbtnExecuteQuery.Enabled = false;
                this.tsbtnExportExcel.Enabled = false;
                this.tsbtnCommit.Enabled = false;
                this.tsbtnRollback.Enabled = false;
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.tabControl1.Refresh();
        }

        private void userControl11_ItemDoubleClicked(object sender, Common.Definition.EventHandler.ItemDoubleClickEventArgs e)
        {
            ucQuery query = this.tabControl1.SelectedTab.Tag as ucQuery;
            query.AddObjectName(e.ItemName);
        }

        private void tsbtnExecuteQuery_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = sender as ToolStripButton;

            if (tsbtn != null)
            {
                if (tsbtn.Equals(this.tsbtnExecuteQuery))
                {
                    ucQuery query = this.tabControl1.SelectedTab.Tag as ucQuery;
                    query.ExecuteQuery(false, 0, false);
                }
                else if (tsbtn.Equals(this.tsbtnAddTab))
                {
                    this.tabControl1.TabPages.Add("SQL");
                    this.tabControl1.SelectedIndex = this.tabControl1.TabCount - 1;

                    ucQuery query = new ucQuery();
                    query.Dock = DockStyle.Fill;
                    this.tabControl1.SelectedTab.Controls.Add(query);
                    this.tabControl1.SelectedTab.Tag = query;
                    query.SetFocusDDLBox();

                    this.SetCtrlEnabledByTabPageCnt();
                }
                else if (tsbtn.Equals(this.tsbtnRemoveTab))
                {
                    if (this.tabControl1.TabPages.Count > 0)
                    {
                        this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
                        this.tabControl1.SelectedIndex = this.tabControl1.TabCount - 1;
                    }

                    this.SetCtrlEnabledByTabPageCnt();
                }
                else if (tsbtn.Equals(this.tsbtnCommit))
                {
                    Common.Comm.DBWorker.CommitTrans();

                    ucQuery query = this.tabControl1.SelectedTab.Tag as ucQuery;
                    query.SetCtrlProp_Committed();
                }
                else if (tsbtn.Equals(this.tsbtnRollback))
                {
                    Common.Comm.DBWorker.RollbackTrans();

                    ucQuery query = this.tabControl1.SelectedTab.Tag as ucQuery;
                    query.SetCtrlProp_Rollbacked();
                }
                else if (tsbtn.Equals(this.tsbtnExportExcel))
                {
                    ucQuery query = this.tabControl1.SelectedTab.Tag as ucQuery;
                    query.ExportExcelQueryResult();
                }
            }
        }

        private void frmSQLWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Common.Comm.DBWorker.IsOnTrans())
            {
                DialogResult result = MessageBox.Show(this, "Transaction이 진행중입니다.\r\n저장하시겠습니까?\r\nYes : Commit  No : Rollback",
                                                      Common.Definition.ConstValue.MSGBOX_TITLE, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (result.Equals(DialogResult.Yes))
                {
                    Common.Comm.DBWorker.CommitTrans();
                }
                else if (result.Equals(DialogResult.No))
                {
                    Common.Comm.DBWorker.RollbackTrans();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion 7.Event


    }
}
