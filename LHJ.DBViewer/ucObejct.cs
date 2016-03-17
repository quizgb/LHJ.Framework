using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.DBService;

namespace LHJ.DBViewer
{
    public partial class ucObejct : UserControl
    {
        public ucObejct()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
            {
                return;
            }

            this.InitCombo();
        }

        private void InitCombo()
        {
            DataTable dtUserList = DALDataAccess.GetUserList();

            if (dtUserList.Rows.Count > 0)
            {
                this.cboUserList.DataSource = dtUserList;
            }

            this.cboObjectList.Items.Add("Tables");
            this.cboObjectList.Items.Add("Views");

            this.cboUserList.SelectedValue = DBHelper.UserID.ToUpper();
            this.cboObjectList.SelectedIndex = 0;
        }

        private void cboUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboObjectList_SelectedIndexChanged(this.cboObjectList, e);
        }

        private void cboObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbxObject.Items.Clear();

            if (this.cboObjectList.Text.Equals("Tables"))
            {
                DataTable dt = DALDataAccess.GetObjectList(this.cboUserList.Text, "TABLE");

                foreach (DataRow dr in dt.Rows)
                {
                    this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
                }
            }
            else if (this.cboObjectList.Text.Equals("Views"))
            {
                DataTable dt = DALDataAccess.GetObjectList(this.cboUserList.Text, "VIEW");

                foreach (DataRow dr in dt.Rows)
                {
                    this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
                }
            }
        }
    }
}
