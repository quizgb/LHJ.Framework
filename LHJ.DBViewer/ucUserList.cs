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
        #region 1.Variable
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("유저가 변경될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.SelectedUserChangedEventHandler SelectedUserChanged;
        #endregion 1.Variable


        #region 2.Property
        public string User { get; private set; }
        #endregion 2.Property


        #region 3.Constructor
        public ucUserList()
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
            this.InitCombo();
        }
        #endregion 5.Set Initialize


        #region 6.Method
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
        #endregion 6.Method


        #region 7.Event
        private void cboUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.User = this.cboUserList.Text;
            this.SetSelectedUserChanged(this.cboUserList.Text);
        }
        #endregion 7.Event
    }
}
