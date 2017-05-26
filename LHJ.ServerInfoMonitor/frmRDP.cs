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
            rdp.AdvancedSettings7.ConnectionBarShowMinimizeButton = false;
            rdp.AdvancedSettings7.ContainerHandledFullScreen = 0;

            rdp.ConnectingText = string.Format("연결중...{0}[{1}]", aParam.A_서버명칭, aParam.B_IP주소);
            rdp.DisconnectedText = string.Format("연결해제...{0}[{1}]", aParam.A_서버명칭, aParam.B_IP주소);


            if (aParam.A_FullScreen)
            {
                rdp.DesktopWidth = Screen.FromControl((Control)this).Bounds.Width;
                rdp.DesktopHeight = Screen.FromControl((Control)this).Bounds.Height;
                rdp.SecuredSettings.FullScreen = 1;
            }
            else
            {
                rdp.SecuredSettings.FullScreen = 0;
            }

            rdp.AdvancedSettings7.RedirectDrives = aParam.B_RedirectDrives;
            rdp.AdvancedSettings7.RedirectClipboard = aParam.C_RedirectClipboard;
            rdp.AdvancedSettings7.RedirectPrinters = aParam.D_RedirectPrinters;
            rdp.AdvancedSettings7.SmartSizing = aParam.E_SmartSizing;

            Point pt = this.GetDesktopSize(aParam.F_DesktopSize, aParam.A_FullScreen);

            rdp.DesktopWidth = pt.X;
            rdp.DesktopHeight = pt.Y;

            if (aParam.G_ColorDepth.Contains("8"))
            {
                rdp.ColorDepth = 8;   
            }
            else if (aParam.G_ColorDepth.Contains("16"))
            {
                rdp.ColorDepth = 16;
            }
            else if (aParam.G_ColorDepth.Contains("24"))
            {
                rdp.ColorDepth = 24;
            }
            else if (aParam.G_ColorDepth.Contains("32"))
            {
                rdp.ColorDepth = 32;
            }

            IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
            secured.ClearTextPassword = aParam.D_비밀번호;

            rdp.Connect();
        }

        #endregion 5.Set Initialize

        #region 6.Method
        private Point GetDesktopSize(string _DesktopSize, bool _IsFullScreen)
        {
            int width;
            int height;

            if (_DesktopSize.Equals(""))
            {
                if (_IsFullScreen)
                {
                    width = Screen.FromControl((Control)this).Bounds.Width;
                    height = Screen.FromControl((Control)this).Bounds.Height;
                }
                else
                {
                    width = rdp.Width;
                    height = rdp.Height;
                }
            }
            else if (_DesktopSize.Contains("X"))
            {
                string[] strArray = _DesktopSize.Split("X".ToCharArray());
                width = int.Parse(strArray[0]);
                height = int.Parse(strArray[1]);
            }
            else
            {
                string str = _DesktopSize;

                if (!(str == Common.Definition.ConstValue.ServerInfoMonitor_DesktopSize.SizeFullScreen))
                {
                    if (str == Common.Definition.ConstValue.ServerInfoMonitor_DesktopSize.SizeCurView)
                    {
                        width = rdp.Width;
                        height = rdp.Height;
                    }
                    else
                    {
                        width = rdp.Width;
                        height = rdp.Height;
                    }
                }
                else
                {
                    Rectangle bounds = Screen.FromControl((Control)this).Bounds;
                    width = bounds.Width;
                    bounds = Screen.FromControl((Control)this).Bounds;
                    height = bounds.Height;
                }
            }

            return new Point(width, height);
        }
        #endregion 6.Method

        #region 7.Event
        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            MessageBox.Show(this, rdp.GetErrorDescription((uint)e.discReason, (uint)rdp.ExtendedDisconnectReason), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion 7.Event  
    }
}
