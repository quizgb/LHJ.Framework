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
        #region 1.Variable
        private System.Windows.Forms.Button mButton;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Panel mPanel;
        private Thread mThread;
        delegate void SetTextCallback(string text);
        delegate void SetColorCallback(Color color);
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmColorSpoid()
        {
            InitializeComponent();
            
            this.Design();
        }
        #endregion 3.Constructor


        #region 4.Override Method
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F4:
                    this.mButton.PerformClick();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
        private void Design()
        {
            this.mButton = new Button();
            this.mLabel = new System.Windows.Forms.Label();
            this.mPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            // button1
            //
            this.mButton.Size = new Size(120, 20);
            this.mButton.TabIndex = 2;
            this.mButton.Location = new Point(12, 100);
            this.mButton.Text = "[F4]Copy RGB";
            this.mButton.Click += new EventHandler(this.Button_Click);
            // 
            // label1
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(12, 9);
            this.mLabel.Size = new System.Drawing.Size(38, 12);
            this.mLabel.TabIndex = 0;
            // 
            // panel1
            // 
            this.mPanel.Location = new System.Drawing.Point(111, 9);
            this.mPanel.Size = new System.Drawing.Size(47, 45);
            this.mPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mPanel);
            this.Controls.Add(this.mLabel);
            this.Controls.Add(this.mButton);
            this.Text = "Spoid";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            System.Drawing.Size sz = new Size(170, 160);
            this.MaximumSize = sz;
            this.MinimumSize = sz;
            this.PerformLayout();
        }

        private Color ScreenColor(int aX, int aY)
        {
            Size sz = new Size(1, 1);
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(aX, aY, 0, 0, sz);

            return bmp.GetPixel(0, 0);
        }

        public void DisplayColorInfo()
        {
            String buff = "";
            Color colorBuff;

            while (true)
            {
                buff = "X 좌표 : " + System.Windows.Forms.Control.MousePosition.X.ToString() + "\r\n";
                buff += "Y 좌표 : " + System.Windows.Forms.Control.MousePosition.Y.ToString() + "\r\n";

                colorBuff = ScreenColor(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);

                buff += "R : " + colorBuff.R.ToString() + "\r\n";
                buff += "G : " + colorBuff.G.ToString() + "\r\n";
                buff += "B : " + colorBuff.B.ToString() + "\r\n";
                buff += "Code : " + ToHexString(colorBuff.R).Substring(0, 2) + ToHexString(colorBuff.G).Substring(0, 2) + ToHexString(colorBuff.B).Substring(0, 2);

                this.SetText(buff);
                this.SetColor(colorBuff);
            }
        }

        public string ToHexString(int aNor)
        {
            byte[] bytes = BitConverter.GetBytes(aNor);
            string hexString = "";

            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }

            return hexString;
        }

        private void SetColor(Color aColor)
        {
            if (this.mPanel.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(this.SetColor);

                try
                {
                    this.Invoke(d, new object[] { aColor });
                }
                catch { }
            }
            else
            {
                this.mPanel.BackColor = aColor;
            }
        }

        private void SetText(string aText)
        {
            if (this.mLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(this.SetText);

                try
                {
                    this.Invoke(d, new object[] { aText });
                }
                catch { }
            }
            else
            {
                this.mLabel.Text = aText;
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void Form1_Load(object sender, EventArgs e)
        {
            this.mThread = new Thread(new ThreadStart(this.DisplayColorInfo));
            this.mThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mThread.Abort();
        }
        #endregion 7.Event

        private void Button_Click(object sender, EventArgs e)
        {
            Color colorBuff = ScreenColor(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
            Clipboard.SetDataObject(string.Format("{0}, {1}, {2}", colorBuff.R.ToString(), colorBuff.G.ToString(), colorBuff.B.ToString()));
        }
    }
}
