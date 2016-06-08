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
        public event Common.Definition.EventHandler.SelectedObjListChangedEventHandler SelectedObjListChanged;
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
            this.cboObjectList.Items.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TABLE);
            this.cboObjectList.Items.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.VIEW);
            this.cboObjectList.SelectedIndex = 0;
        }

        public DataTable GetObjectList(string aUser)
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dt = new DataTable();

            if (this.cboObjectList.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TABLE))
            {
                dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TABLE);
            }
            else if (this.cboObjectList.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.VIEW))
            {
                dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.VIEW);
            }

            this.Cursor = Cursors.Default;

            return dt;
        }

        public DataTable GetObjectListByObjectName(string aUser, string aObjectName)
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dt = new DataTable();

            if (this.cboObjectList.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TABLE))
            {
                dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TABLE, aObjectName);
            }
            else if (this.cboObjectList.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.VIEW))
            {
                dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.VIEW, aObjectName);
            }

            this.Cursor = Cursors.Default;

            return dt;
        }

        private void SetSelectedObjChanged(string aObject)
        {
            if (SelectedObjListChanged != null)
            {
                Common.Definition.EventHandler.SelectedObjListChangedEventArgs e = new Common.Definition.EventHandler.SelectedObjListChangedEventArgs(aObject);
                SelectedObjListChanged(this, e);
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
