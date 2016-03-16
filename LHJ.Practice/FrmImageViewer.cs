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
        public FrmImageViewer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
    }
}
