using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Common;

namespace LHJ.Practice
{
    public partial class FrmGetSlnCodeLine : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmGetSlnCodeLine()
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


        #region 6.Method

        #endregion 6.Method


        #region 7.Event
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string dir = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            this.label1.Text = System.IO.Path.GetFileName(dir);
            this.textBox1.AppendText("--" + dir + "--\r\n");
            string[] csprojs = ClsGetSlnCodeLine.GetCsproj(dir);
            int Lines = 0;
            foreach (string csproj in csprojs)
            {
                string[] codes = ClsGetSlnCodeLine.GetCodelist(csproj, false);
                foreach (string c in codes)
                {
                    int line = System.IO.File.ReadAllLines(c).Length;
                    Lines += line;
                    this.textBox1.AppendText(string.Format("{0:50} : {1:000} 줄\r\n", c.PadRight(50), line));
                }
            }
            this.textBox1.AppendText("-----------------------------------------------------------\r\n");
            this.textBox1.AppendText(string.Format("총:                                                : {0:000} 줄\r\n\r\n", Lines));
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.A))
            {
                this.textBox1.Focus();
                this.textBox1.SelectAll();
            }
        }
        #endregion 7.Event
    }
}
