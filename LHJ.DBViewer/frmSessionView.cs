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
    public partial class frmSessionView : Form
    {
        public frmSessionView()
        {
            InitializeComponent();

            this.SearchSessionInfo();
        }

        private void SearchSessionInfo()
        {
            DataTable dt = DALDataAccess.GetSessionInfo();
            this.dgvSession.DataSource = dt;  
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnRefresh))
                {
                    this.SearchSessionInfo();
                }
            }
        }

        private void dgvSession_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
