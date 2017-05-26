using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.ServerInfoMonitor
{
    public partial class frmRDPMain : Form
    {
        #region 1.Variable
        private Point mImageLocation = new Point(15, 5);
        private Point mImgHitArea = new Point(13, 2);
        const String _ENCRPT_KEY = "egmainkfP@ssw0rd12#$";
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmRDPMain()
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
            // set the Mode of Drawing as Owner Drawn
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.tabControl1.ItemSize = new Size(80, 20);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;

            // Add the Handler to draw the Image on Tab Pages
            this.tabControl1.DrawItem += TabControl1_DrawItem;

            this.splitContainer1.SplitterDistance = 0;
            this.즐겨찾기ToolStripMenuItem.Checked = true;

            frmServerList serverFrm = new frmServerList();
            serverFrm.TopLevel = false;
            serverFrm.Dock = DockStyle.Fill;

            this.splitContainer1.Panel1.Controls.Add(serverFrm);
            serverFrm.Show();
        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                // Close Image to draw
                Image img = new Bitmap(Properties.Resources._1495539349_Close_Icon);
                Rectangle r = e.Bounds;
                r = this.tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = this.tabControl1.TabPages[e.Index].Text;
                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
                e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - mImageLocation.X), mImageLocation.Y));
            }
            catch (Exception)
            {
            }
        }

        private void 즐겨찾기ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            if (tsmi != null)
            {
                if (tsmi.Checked)
                {
                    this.splitContainer1.SplitterDistance = this.Width / 8;
                }
                else
                {
                    this.splitContainer1.SplitterDistance = 0;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabPage newPage = new TabPage();
            frmRDP rdpFrm = new frmRDP();

            newPage.Text = "RDP  ";
            rdpFrm.TopLevel = false;
            rdpFrm.Dock = DockStyle.Fill;

            newPage.Controls.Add(rdpFrm);

            this.tabControl1.TabPages.Add(newPage);
            rdpFrm.Show();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - (mImgHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, mImgHitArea.Y);
            r.Width = 16;
            r.Height = 16;

            if (r.Contains(p))
            {
                TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                tc.TabPages.Remove(TabP);
            }
        }
        #endregion 7.Event  

        private void frmRDPMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.splitContainer1.Panel1.Controls[0] is frmServerList)
            {
                frmServerList serverFrm = this.splitContainer1.Panel1.Controls[0] as frmServerList;
                serverFrm.SaveServerList();
            }
        }
    }
}
