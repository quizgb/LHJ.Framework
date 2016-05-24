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
    public partial class frmSQLWindow : Form
    {
        #region 1.Variable
        private ucQuery m_Query = new ucQuery();
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmSQLWindow()
        {
            InitializeComponent();

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
            this.m_Query.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(this.m_Query);
        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.tabControl1.Refresh();
        }

        private void frmSQLWindow_Shown(object sender, EventArgs e)
        {
            this.m_Query.SetFocusDDLBox();
        }

        private void userControl11_ItemDoubleClicked(object sender, Common.Definition.EventHandler.ItemDoubleClickEventArgs e)
        {
            this.m_Query.AddObjectName(e.ItemName);
        }
        #endregion 7.Event
    }
}
