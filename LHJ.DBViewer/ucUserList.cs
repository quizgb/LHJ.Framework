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
    public partial class ucUserList : UserControl
    {
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("유저가 변경될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.SelectedUserChangedEventHandler SelectedUserChanged;

        public string User { get; private set; }

        public ucUserList()
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
            this.Cursor = Cursors.WaitCursor;   

            DataTable dtUserList = DALDataAccess.GetUserList();

            if (dtUserList.Rows.Count > 0)
            {
                this.cboUserList.DataSource = dtUserList;
            }

            this.cboUserList.SelectedValue = Common.Comm.DBWorker.GetUserID().ToUpper();
            this.User = this.cboUserList.Text;

            this.Cursor = Cursors.Default;
        }

        private void SetSelectedUserChanged(string aUser)
        {
            if (SelectedUserChanged != null)
            {
                Common.Definition.EventHandler.SelectedUserChangedEventArgs e = new Common.Definition.EventHandler.SelectedUserChangedEventArgs(aUser);
                SelectedUserChanged(this, e);
            }
        }

        private void cboUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.User = this.cboUserList.Text;
            this.SetSelectedUserChanged(this.cboUserList.Text);
        }
    }
}
