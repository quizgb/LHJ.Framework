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

            Common.Definition.EventHandler.SelectedUserChangedEventArgs e = new Common.Definition.EventHandler.SelectedUserChangedEventArgs(this.ucUserList1.User);
            this.ucUserList1_SelectedUserChanged(this.ucUserList1, e);
        }

        private void ucUserList1_SelectedUserChanged(object sender, Common.Definition.EventHandler.SelectedUserChangedEventArgs e)
        {
            this.lbxObject.Items.Clear();
            DataTable dt = this.ucObjectList1.GetObjectList(e.User);

            foreach (DataRow dr in dt.Rows)
            {
                this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
            }

            this.SetColumnInfo();
        }

        private void ucObjectList1_SelectedObjChanged(object sender, Common.Definition.EventHandler.SelectedObjChangedEventArgs e)
        {
            this.lbxObject.Items.Clear();
            DataTable dt = this.ucObjectList1.GetObjectList(this.ucUserList1.User);

            foreach (DataRow dr in dt.Rows)
            {
                this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
            }

            this.SetColumnInfo();
        }

        private void lbxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetColumnInfo();
        }

        private void SetColumnInfo()
        {
            DataTable dt = DALDataAccess.GetTableColumns(Common.Comm.DBWorker.GetUserID().ToUpper(), this.lbxObject.Text);
            this.dgvColumnInfo.DataSource = dt;
        }
    }
}
