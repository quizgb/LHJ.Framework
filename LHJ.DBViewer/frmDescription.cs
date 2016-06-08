using System;
using System.Collections;
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
    public partial class frmDescription : Form
    {
        #region 1.Variable
        private Hashtable mHt = new Hashtable();
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmDescription()
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

        }
        #endregion 5.Set Initialize


        #region 6.Method
        public void Search(Hashtable aHt)
        {
            this.tabControl1.TabPages.Clear();

            this.mHt = aHt;
            DataTable dt = DALDataAccess.GetObjectListByObjectName(this.mHt["USER"].ToString(), this.mHt["OBJECT_NAME"].ToString());

            this.lblInfo.Text = string.Format("[{0}] Created:{1}   Last DDL:{2}", this.mHt["OBJECT_NAME"].ToString(), dt.Rows[0]["CREATED"].ToString(), dt.Rows[0]["LAST_DDL_TIME"].ToString());
            this.tabControl1.Tag = dt.Rows[0]["OBJECT_TYPE"].ToString();

            if (dt.Rows[0]["OBJECT_TYPE"].ToString().Equals(Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TABLE))
            {
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.COLUMN);
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.DATA);
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.INDEX);
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT);
            }
            else if (dt.Rows[0]["OBJECT_TYPE"].ToString().Equals(Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.VIEW))
            {
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.COLUMN);
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.DATA);
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT);
            }
            else if (dt.Rows[0]["OBJECT_TYPE"].ToString().Equals(Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.FUNCTION))
            {
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT);
            }
            else if (dt.Rows[0]["OBJECT_TYPE"].ToString().Equals(Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.PROCEDURE))
            {
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT);
            }
            else if (dt.Rows[0]["OBJECT_TYPE"].ToString().Equals(Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TRIGGER))
            {
                this.tabControl1.TabPages.Add(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT);
            }

            foreach (TabPage tp in this.tabControl1.TabPages)
            {
                if (tp.Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT))
                {
                    TextBox tbx = new TextBox();
                    tbx.ReadOnly = true;
                    tbx.Multiline = true;
                    tbx.Dock = DockStyle.Fill;

                    tp.Controls.Add(tbx);
                }
            }

            this.tabControl1_SelectedIndexChanged(this.tabControl1, null);
        }
        #endregion 6.Method

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Count > 0)
            {
                if (this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Text.Equals(Common.Definition.ConstValue.DBViewer_ObjectInfo_DISPLAY.SCRIPT))
                {
                    DataTable dtScript = DALDataAccess.GetObjectScript(this.mHt["USER"].ToString(), this.mHt["OBJECT_NAME"].ToString());
                    TextBox tbx = this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Controls[0] as TextBox;

                    tbx.Text = string.Format("{0};", dtScript.Rows[0]["SCRIPT"].ToString().Trim()).Replace("\n", "\r\n");

                    if (this.tabControl1.Tag.Equals(Common.Definition.ConstValue.DBViewer_ObjectList_VALUE.TABLE))
                    {
                        DataTable dtIndex = DALDataAccess.GetIndexByTableName(this.mHt["USER"].ToString(), this.mHt["OBJECT_NAME"].ToString());

                        if (dtIndex.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtIndex.Rows)
                            {
                                dtScript = DALDataAccess.GetObjectScript(this.mHt["USER"].ToString(), dr["INDEX_NAME"].ToString());

                                tbx.Text += "\r\n\r\n\r\n";
                                tbx.Text += string.Format("{0};", dtScript.Rows[0]["SCRIPT"].ToString().Trim()).Replace("\n", "\r\n");
                            }
                        }
                    }
                }
            }
        }


        #region 7.Event

        #endregion 7.Event
    }
}
