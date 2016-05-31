using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using LHJ.Common.Properties;

namespace LHJ.Common.Control.LoadingControl
{
    /// <summary>
    /// 스플래쉬 윈도우
    /// </summary>
    public partial class SplashWnd : Form
    {
        #region 1.Variable
        private Bitmap bit;

        /// <summary>
        /// 스플래쉬 닫을 때 true로 세팅하는 값
        /// </summary>
        private static bool isCloseCall = false;

        /// <summary>
        /// 값이 true 이면 창이 닫히지 않음.
        /// </summary>
        private bool cannotClose = true;

        /// <summary>
        /// 윈도우를 맨 앞으로 가져오기 위한 Win32 API 메서드
        /// </summary>
        /// <param name="hWnd">윈도우 핸들
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        /// <summary>
        /// 생성자
        /// </summary>
        public SplashWnd()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method
        protected override void OnLoad(EventArgs e)
        {
            bit = new Bitmap(@"..\Compile\ajax-loader.gif");
            ImageAnimator.Animate(bit, new EventHandler(this.OnFrameChanged));
            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            Graphics g = pbxLogo.CreateGraphics();
            g.DrawImage(this.bit, new Point(5, 5));
            base.OnPaint(e);
        }

        /// <summary>
        /// 사용자가 ALT+F4 등의 키로 닫는 걸 방지
        /// </summary>
        /// <param name="e">
        protected override void OnClosing(CancelEventArgs e)
        {
            if (cannotClose)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (this.Handle != IntPtr.Zero)
            {
                IntPtr hWndDeskTop = GetDesktopWindow();
                SetParent(this.Handle, hWndDeskTop);
            }

            base.OnHandleCreated(e);
        }
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
        /// <summary>
        /// 이 메서드를 호출해야만 창이 닫힌다.
        /// </summary>
        public void CloseForce()
        {
            //OnClose 에서 닫힐 수 있도록 세팅
            cannotClose = false;
            this.Close();
        }

        /// <summary>
        /// 스플래쉬 띄우기
        /// </summary>
        public static void SplashShow()
        {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
            System.Windows.Forms.Control mainWindow = System.Windows.Forms.Control.FromHandle(process.MainWindowHandle);

            isCloseCall = false;
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadShowWait));
            thread.Start(new object[] { mainWindow });
        }

        /// <summary>
        /// 스플래쉬 닫기
        /// </summary>
        /// <param name="formFront">스플래쉬를 닫은 후 맨 앞으로 가져올 폼
        public static void SplashClose()
        {
            //Thread의 loop 를 멈춘다.
            isCloseCall = true;
        }

        /// <summary>
        /// 스플래쉬를 띄우기 위한 Parameterized Thread Method
        /// </summary>
        /// <param name="obj">메인 윈도(위치를 잡기 위해)
        private static void ThreadShowWait(object obj)
        {
            object[] objParam = obj as object[];
            SplashWnd splashWnd = new SplashWnd();
            System.Windows.Forms.Control mainWindow = objParam[0] as System.Windows.Forms.Control;

            splashWnd.StartPosition = FormStartPosition.CenterScreen;

            splashWnd.Show();
            splashWnd.BringToFront();

            //닫기 명령이 올 때 가지 0.01 초 단위로 루프
            while (!isCloseCall)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }

            //닫는다.
            if (splashWnd != null)
            {
                splashWnd.CloseForce();
                splashWnd = null;
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void OnFrameChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion 7.Event
    }
}