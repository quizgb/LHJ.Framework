using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Common.Definition;

namespace LHJ.DBViewer
{
    public partial class frmSessionView : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmSessionView()
        {
            InitializeComponent();
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
            this.SearchSessionInfo();
            this.SearchLockList();

            this.txtSecond.Text = "30";
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SearchLockList()
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dt = DALDataAccess.GetLockList();
            this.dgvLock.DataSource = dt;

            this.Cursor = Cursors.Default;
        }

        private void SearchSessionInfo()
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dt = DALDataAccess.GetSessionInfo();
            this.dgvSession.DataSource = dt;

            this.Cursor = Cursors.Default;
        }
        #endregion 6.Method


        #region 7.Event
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnRefresh))
                {
                    this.SearchSessionInfo();
                    this.SearchLockList();
                }
                else if (btn.Equals(this.btnLock))
                {
                    this.SearchLockList();
                }
                else if (btn.Equals(this.btnCopy))
                {
                    Clipboard.SetDataObject(this.txtSessionQuery.Text);
                }
            }
        }

        private void dgvSession_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = DALDataAccess.GetSessionHashValue(this.dgvSession.GetRowCellStrValue(e.RowIndex, "SID"));

            if (dt.Rows.Count > 0)
            {
                DataTable dtSql = DALDataAccess.GetSessionSql(dt.Rows[0]["HASH"].ToString());

                if (dtSql.Rows.Count > 0)
                {
                    string sql = string.Empty;

                    foreach (DataRow dr in dtSql.Rows)
                    {
                        sql += dr["SQL_TEXT"].ToString().Replace("\n", "\r\n");
                    }

                    this.txtSessionQuery.Text = sql;
                }
                else
                {
                    this.txtSessionQuery.Text = string.Empty;
                }
            }
            else
            {
                this.txtSessionQuery.Text = string.Empty;
            }

            this.txtSessionQuery.SelectAll();
        }

        private void tbxSessionQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.A))
            {
                this.txtSessionQuery.Focus();
                this.txtSessionQuery.SelectAll();
            }
        }

        private void cbxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxAutoRefresh.Checked)
            {
                if (string.IsNullOrEmpty(this.txtSecond.Text))
                {
                    this.txtSecond.Focus();
                    MessageBox.Show(this, "자동갱신 전 초를 입력하셔야 합니다.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbxAutoRefresh.Checked = false;
                    return;
                }

                this.timer1.Interval = Convert.ToInt32(this.txtSecond.Text) * 1000;
                this.timer1.Start();
            }
            else
            {
                this.timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.btnRefresh.PerformClick();
            this.btnLock.PerformClick();
        }

        private void tsmiDeleteLock_Click(object sender, EventArgs e)
        {
            string msg = string.Format("{0},{1} Lock을 삭제하시겠습니까?", this.dgvLock.GetRowCellStrValue(this.dgvLock.CurrentRow.Index, "SID"), this.dgvLock.GetRowCellStrValue(this.dgvLock.CurrentRow.Index, "serial#"));

            if (DialogResult.Yes.Equals(MessageBox.Show(this, msg, ConstValue.MSGBOX_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                DALDataAccess.DeleteLock(this.dgvLock.GetRowCellStrValue(this.dgvLock.CurrentRow.Index, "SID") + "," + this.dgvLock.GetRowCellStrValue(this.dgvLock.CurrentRow.Index, "serial#"));
            }

            this.SearchLockList();
        }

        private void frmSessionView_Load(object sender, EventArgs e)
        {
            this.SetInitialize();
        }

        private void dgvSession_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvSession.AutoResizeColumn();
        }

        private void dgvLock_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvLock.AutoResizeColumn();
        }
        #endregion 7.Event
    }
}
