using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Controls;

namespace LHJ.Practice
{
    public partial class FrmImageViewer : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmImageViewer()
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
            this.KeyPreview = false;
            ucImageViewer viewer = new ucImageViewer();
            viewer.Parent = this;
            viewer.Dock = DockStyle.Fill;
            viewer.ZoomRate = 1f;
            viewer.EnableZoom = true;
            viewer.Image = Properties.Resources._00001161_608555_001;
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion 7.Event
    }
}
