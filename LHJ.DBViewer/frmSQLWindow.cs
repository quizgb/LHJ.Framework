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
        public frmSQLWindow()
        {
            InitializeComponent();

            ucQuery query = new ucQuery();
            query.Dock = DockStyle.Fill;
            this.tabPage1.Controls.Add(query);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.tabControl1.Refresh();
        }
    }
}
