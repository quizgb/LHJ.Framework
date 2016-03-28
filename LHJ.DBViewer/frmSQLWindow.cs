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
        private ucQuery m_Query = new ucQuery();

        public frmSQLWindow()
        {
            InitializeComponent();

            m_Query.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(m_Query);
        }

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
    }
}
