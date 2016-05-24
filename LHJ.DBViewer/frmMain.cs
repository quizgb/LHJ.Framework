using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.DBService;

namespace LHJ.DBViewer
{
    public partial class frmMain : Form
    {
        #region 1.Variable
        private static string mBtn;
        private ToolStripButton mTsBtnSqlWindow = new ToolStripButton();
        private ToolStripButton mTsBtnSchemaBrowser = new ToolStripButton();
        private ToolStripButton mTsBtnSessionView = new ToolStripButton();
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
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
            this.SetTitleBuildDate();
            this.Icon = Properties.Resources._1464082634_033;
            this.tsSub.Renderer = new MyRenderer();

            this.mTsBtnSqlWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnSqlWindow.Text = "SQL Window";

            this.mTsBtnSchemaBrowser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnSchemaBrowser.Text = "Schema Browser";

            this.mTsBtnSessionView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnSessionView.Text = "Session 조회";
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetTitleBuildDate()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

            this.Text += " [Last Build : " + buildDate.ToString("yyyy-MM-dd") + "]";
        }

        private void SetOracleVersionLabel()
        {
            DataTable dt = DALDataAccess.GetOracleVersion();

            if (dt.Rows.Count > 0)
            {
                this.tsslOracleVersion.Text = dt.Rows[0][0].ToString();
            }
        }

        private void ShowLoginForm()
        {
            frmLogin loginFrm = new frmLogin();
            loginFrm.ShowDialog();

            if (Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                this.SetOracleVersionLabel();
                this.tsbtnSqlWindow.PerformClick();
            }
        }

        private void ShowFormORClose(Form aActiveForm)
        {
            if (aActiveForm != null)
            {
                if (this.vaildMdiChild(aActiveForm))
                {
                    aActiveForm.MdiParent = this;
                    aActiveForm.Show();
                }
                else
                {
                    aActiveForm.Close();
                }
            }
        }

        /// <summary>
        /// 메뉴에서 선택된 폼의 존재여부를 확인
        /// </summary>
        /// <param name="activeForm"></param>
        /// <returns></returns>
        private bool vaildMdiChild(Form activeForm)
        {
            bool mdiChild = true;

            for (int cnt = 0; cnt < this.MdiChildren.Length; cnt++)
            {
                string fromName = this.MdiChildren[cnt].Name;

                if (fromName.Equals(activeForm.Name))
                {
                    mdiChild = false;
                    this.MdiChildren[cnt].Focus();
                    break;
                }
            }

            return mdiChild;
        }
        #endregion 6.Method


        #region 7.Event
        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void tsBtn_Click(object sender, MouseEventArgs e)
        {
            ToolStripButton tsBtn = sender as ToolStripButton;
            tsBtn.Checked = true;

            foreach (ToolStripButton abtn in tsBtn.GetCurrentParent().Items)
            {
                if (!abtn.Equals(tsBtn))
                {
                    abtn.Checked = false;
                }
            }

            if (tsBtn.Equals(this.mTsBtnSqlWindow))
            {
                frmSQLWindow window = new frmSQLWindow();
                this.ShowFormORClose(window);
            }
            else if (tsBtn.Equals(this.mTsBtnSchemaBrowser))
            {
                frmSchemaBrowser browser = new frmSchemaBrowser();
                this.ShowFormORClose(browser);
            }
            else if (tsBtn.Equals(this.mTsBtnSessionView))
            {
                frmSessionView sessionView = new frmSessionView();
                this.ShowFormORClose(sessionView);
            }
        }
        #endregion 7.Event

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                ToolStripButton tsBtn = e.Item as ToolStripButton;

                if (tsBtn != null && tsBtn.Checked)
                {
                    foreach (ToolStripButton btn in tsBtn.GetCurrentParent().Items)
                    {
                        if (!btn.Equals(tsBtn))
                        {
                            btn.Invalidate();
                        }
                    }

                    e.Graphics.DrawRectangle(Pens.Black, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                }
                else
                {
                    base.OnRenderButtonBackground(e);
                }
            }
        }

        private void tsbtnSqlWindow_Click(object sender, EventArgs e)
        {
            ToolStripButton tsBtn = sender as ToolStripButton;

            if (tsBtn.Equals(this.tsbtnSqlWindow))
            {
                if (!this.tsSub.Items.Contains(this.mTsBtnSqlWindow))
                {
                    this.tsSub.Items.Add(this.mTsBtnSqlWindow);
                }

                this.tsBtn_Click(this.mTsBtnSqlWindow, null);
            }
            else if (tsBtn.Equals(this.tsbtnSchemaBrowser))
            {
                if (!this.tsSub.Items.Contains(this.mTsBtnSchemaBrowser))
                {
                    this.tsSub.Items.Add(this.mTsBtnSchemaBrowser);
                }

                this.tsBtn_Click(this.mTsBtnSchemaBrowser, null);
            }
            else if (tsBtn.Equals(this.tsbtnSessionView))
            {
                if (!this.tsSub.Items.Contains(this.mTsBtnSessionView))
                {
                    this.tsSub.Items.Add(this.mTsBtnSessionView);
                }

                this.tsBtn_Click(this.mTsBtnSessionView, null);
            }
        }
    }
}
