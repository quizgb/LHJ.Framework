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
        #region 1.Variable
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("오브젝트가 변경될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.SelectedObjChangedEventHandler SelectedObjChanged;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ucObjectList()
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
        #endregion 6.Method


        #region 7.Event
        private void cboObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetSelectedObjChanged(this.cboObjectList.Text);
        }
        #endregion 7.Event
    }
}
