using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LHJ.Common.Control
{
    public partial class FrmSplash : Form
    {
        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmSplash()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method
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

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
