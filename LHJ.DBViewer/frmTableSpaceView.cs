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
    public partial class frmTableSpaceView : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmTableSpaceView()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
            {
                return;
            }

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
            this.GetTableSpaceList();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void GetTableSpaceList()
        {
            this.lbxTableSpace.Items.Clear();
            DataTable dt = DALDataAccess.GetTableSpaceList();

            foreach (DataRow dr in dt.Rows)
            {
                this.lbxTableSpace.Items.Add(dr["TABLESPACE_NAME"].ToString());
            }

            if (dt.Rows.Count > 0)
            {
                this.lbxTableSpace.SelectedIndex = 0;
            }
            else
            {
                this.dgvTableSpace.DataSource = null;
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void lbxTableSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.lblTableSpaceName.Text = this.lbxTableSpace.Text;

            DataTable dtTableSpaceInfo = DALDataAccess.GetTableSpaceInfo(this.lbxTableSpace.Text);
            this.dgvTableSpace.DataSource = dtTableSpaceInfo;

            this.Cursor = Cursors.Default;
        }

        private void dgvTableSpace_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvTableSpace.AutoResizeColumn();
        }
        #endregion 7.Event
    }
}
