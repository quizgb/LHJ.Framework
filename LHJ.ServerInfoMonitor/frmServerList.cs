using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.ServerInfoMonitor
{
    public partial class frmServerList : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmServerList()
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
            this.InitServerList();
        }

        #endregion 5.Set Initialize

        #region 6.Method
        private void InitServerList()
        {
            ServerListParam param = new ServerInfoMonitor.ServerListParam();
            this.propertyGrid1.SelectedObject = param;
        }
        #endregion 6.Method

        #region 7.Event

        #endregion 7.Event

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.InitServerList();
        }
    }
}
