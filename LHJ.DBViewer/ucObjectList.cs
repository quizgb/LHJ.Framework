using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.DBViewer
{
    public partial class ucObjectList : UserControl
    {
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("오브젝트가 변경될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.SelectedObjChangedEventHandler SelectedObjChanged;

        public ucObjectList()
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
            this.cboObjectList.Items.Add("Tables");
            this.cboObjectList.Items.Add("Views");
            this.cboObjectList.SelectedIndex = 0;
        }

        public DataTable GetObjectList(string aUser)
        {
            DataTable dt = new DataTable();

            if (this.cboObjectList.Text.Equals("Tables"))
            {
                dt = DALDataAccess.GetObjectList(aUser, "TABLE");
            }
            else if (this.cboObjectList.Text.Equals("Views"))
            {
                dt = DALDataAccess.GetObjectList(aUser, "VIEW");
            }

            return dt;
        }

        private void SetSelectedObjChanged(string aObject)
        {
            if (SelectedObjChanged != null)
            {
                Common.Definition.EventHandler.SelectedObjChangedEventArgs e = new Common.Definition.EventHandler.SelectedObjChangedEventArgs(aObject);
                SelectedObjChanged(this, e);
            }
        }

        private void cboObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetSelectedObjChanged(this.cboObjectList.Text);
        }
    }
}
