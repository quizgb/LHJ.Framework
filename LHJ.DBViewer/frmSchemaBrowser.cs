﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.DBViewer
{
    public partial class frmSchemaBrowser : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmSchemaBrowser()
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

        private void frmSchemaBrowser_Activated(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Update();
            this.ResumeLayout();
        }


        #region 6.Method

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
