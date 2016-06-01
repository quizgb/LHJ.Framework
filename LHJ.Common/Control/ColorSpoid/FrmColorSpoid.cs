using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Runtime.InteropServices;

namespace LHJ.Common.Control.ColorSpoid
{
    public partial class FrmColorSpoid : Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        Thread th;
        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(Color color);

        public FrmColorSpoid()
        {
            InitializeComponent();
            design();
        }
        private void design()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(111, 9);
            this.panel1.Size = new System.Drawing.Size(47, 45);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Text = "Spoid";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            System.Drawing.Size sz = new Size(170, 125);
            this.MaximumSize = sz;
            this.MinimumSize = sz;
            this.PerformLayout();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(test_label));
            th.Start();
        }
        private Color ScreenColor(int x, int y)
        {
            Size sz = new Size(1, 1);
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(x, y, 0, 0, sz);
            return bmp.GetPixel(0, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.Abort();
        }
        public void test_label()
        {
            String buf = "";
            Color colorbuf;
            while (true)
            {
                buf = "X 좌표 : " + System.Windows.Forms.Control.MousePosition.X.ToString() + "\r\n";
                buf += "Y 좌표 : " + System.Windows.Forms.Control.MousePosition.Y.ToString() + "\r\n";

                colorbuf = ScreenColor(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);

                buf += "R : " + colorbuf.R.ToString() + "\r\n";
                buf += "G : " + colorbuf.G.ToString() + "\r\n";
                buf += "B : " + colorbuf.B.ToString() + "\r\n";
                buf += "Code : " + ToHexString(colorbuf.R).Substring(0, 2) + ToHexString(colorbuf.G).Substring(0, 2) + ToHexString(colorbuf.B).Substring(0, 2);

                SetText(buf);
                SetColor(colorbuf);
            }

        }
        public string ToHexString(int nor)
        {
            byte[] bytes = BitConverter.GetBytes(nor);
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }
        private void SetColor(Color color)
        {
            if (this.panel1.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(SetColor);
                try
                {
                    this.Invoke(d, new object[] { color });
                }
                catch { }
            }
            else
            {
                this.panel1.BackColor = color;
            }
        }
        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                try
                {
                    this.Invoke(d, new object[] { text });
                }
                catch { }
            }
            else
            {
                this.label1.Text = text;
            }
        }

    }
}
