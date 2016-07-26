using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Common.Definition;
using System.Collections;

namespace LHJ.DBViewer
{
    public partial class ucObject2 : UserControl
    {
        #region 1.Variable
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.SelectedObjChangedEventHandler SelectedObjChanged;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ucObject2()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
            {
                return;
            }

            this.SetInitialize();
        }
        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TABLE);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.VIEW);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.FUNCTION);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.PROCEDURE);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TRIGGER);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.INDEX);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.SEQUENCE);
            this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.PACKAGE);

            ListBox lbx;

            foreach (TabPage tp in this.tabControl1.TabPages)
            {
                lbx = new ListBox();
                lbx.Dock = DockStyle.Fill;
                lbx.SelectedIndexChanged += this.lbx_SelectedIndexChanged;

                tp.Controls.Add(lbx);
            }

            this.tabControl1_SelectedIndexChanged(this.tabControl1, null);
        }
        #endregion 5.Set Initialize


        #region 6.Metho
        private void SetSelectedObjChanged(Hashtable aHt)
        {
            if (SelectedObjChanged != null)
            {
                Common.Definition.EventHandler.SelectedObjChangedEventArgs e = new Common.Definition.EventHandler.SelectedObjChangedEventArgs(aHt);
                SelectedObjChanged(this, e);
            }
        }

        private void lbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lbx = sender as ListBox;

            if (lbx != null)
            { 
                Hashtable ht = new Hashtable();

                ht["USER"] = this.ucUserList1.User;
                ht["OBJECT_NAME"] = lbx.Text;

                this.SetSelectedObjChanged(ht);
            }
        }

        private void GetObjectList(string aUser = "")
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dt = new DataTable();
            ListBox lbx = this.tabControl1.SelectedTab.Controls[0] as ListBox;
            lbx.Items.Clear();

            if (string.IsNullOrEmpty(aUser))
            {
                aUser = this.ucUserList1.User;
            }

            if (string.IsNullOrEmpty(this.txtSearch.Text))
            {
                if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TABLE))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TABLE);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.VIEW))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.VIEW);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.FUNCTION))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.FUNCTION);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.PROCEDURE))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.PROCEDURE);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TRIGGER))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TRIGGER);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.INDEX))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.INDEX);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.SEQUENCE))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.SEQUENCE);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.PACKAGE))
                {
                    dt = DALDataAccess.GetObjectList(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.PACKAGE);
                }
            }
            else
            {
                if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TABLE))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TABLE, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.VIEW))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.VIEW, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.FUNCTION))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.FUNCTION, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.PROCEDURE))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.PROCEDURE, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.TRIGGER))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TRIGGER, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.INDEX))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.INDEX, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.SEQUENCE))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.SEQUENCE, this.txtSearch.Text);
                }
                else if (this.tabControl1.SelectedTab.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_DISPLAY.PACKAGE))
                {
                    dt = DALDataAccess.GetObjectListByObjectName(aUser, Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.PACKAGE, this.txtSearch.Text);
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                lbx.Items.Add(dr["OBJECT_NAME"].ToString());
            }

            this.Cursor = Cursors.Default;
        }
        #endregion 6.Method


        #region 7.Event
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetObjectList(string.Empty);

            ListBox lbx = this.tabControl1.SelectedTab.Controls[0] as ListBox;

            if (lbx.Items.Count > 0)
            {
                lbx.SelectedIndex = 0;
            }
            else
            {
                this.lbx_SelectedIndexChanged(lbx, null);
            }
        }

        private void ucUserList1_SelectedUserChanged(object sender, Common.Definition.EventHandler.SelectedUserChangedEventArgs e)
        {
            this.GetObjectList(e.User);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GetObjectList(string.Empty);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                this.GetObjectList(string.Empty);
            }
        }
        #endregion 7.Event
    }
}
