using MSTSCLib;
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
    public partial class frmRDP : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmRDP(ServerListParam aParam)
        {
            InitializeComponent();

            this.Start(aParam);
        }
        #endregion 3.Constructor


        #region 4.Override Method
       
        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void Start(ServerListParam aParam)
        {
            rdp.Dock = DockStyle.Fill;

            rdp.Server = aParam.B_IP주소;
            rdp.UserName = aParam.C_사용자이름;
            rdp.AdvancedSettings7.EnableCredSspSupport = true;
            rdp.AdvancedSettings7.ConnectToAdministerServer = true;

            IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
            secured.ClearTextPassword = aParam.D_비밀번호;

            rdp.Connect();
        }

        #endregion 5.Set Initialize

        #region 6.Method

        #endregion 6.Method

        #region 7.Event
        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            MessageBox.Show(this, rdp.GetErrorDescription((uint)e.discReason, (uint)rdp.ExtendedDisconnectReason), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion 7.Event  
    }
}
