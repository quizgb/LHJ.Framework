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
        private ToolStripButton mTsBtnSqlWindow = new ToolStripButton();
        private ToolStripButton mTsBtnSchemaBrowser = new ToolStripButton();
        private ToolStripButton mTsBtnSessionView = new ToolStripButton();
        private ToolStripButton mTsBtnTableSpaceView = new ToolStripButton();
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
            this.SetLastBuildDate();
            this.Icon = Properties.Resources._1464082634_033;
            //this.tsSub.Renderer = new MyRenderer();

            this.mTsBtnSqlWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnSqlWindow.Tag = Common.Definition.ConstValue.DBViewerFormType.SqlWindow;
            this.mTsBtnSqlWindow.Text = "SQL Window";

            this.mTsBtnSchemaBrowser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnSchemaBrowser.Tag = Common.Definition.ConstValue.DBViewerFormType.SchemaBrowser;
            this.mTsBtnSchemaBrowser.Text = "Schema Browser";

            this.mTsBtnSessionView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnSessionView.Tag = Common.Definition.ConstValue.DBViewerFormType.SessionViewer;
            this.mTsBtnSessionView.Text = "Session 조회";

            this.mTsBtnTableSpaceView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            this.mTsBtnTableSpaceView.Tag = Common.Definition.ConstValue.DBViewerFormType.TableSpaceViewer;
            this.mTsBtnTableSpaceView.Text = "TableSpace 조회";
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetLastBuildDate()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

            this.tsslLastBulidDate.Text = " [Last Build : " + buildDate.ToString("yyyy-MM-dd") + "]";
        }

        private void SetOracleVersionLabel()
        {
            DataTable dt = DALDataAccess.GetOracleVersion();

            if (dt.Rows.Count > 0)
            {
                this.tsslOracleVersion.Text = string.Format("[{0}]", dt.Rows[0][0].ToString());
            }
        }

        private void ShowLoginForm()
        {
            frmLogin loginFrm = new frmLogin();
            loginFrm.ShowDialog();

            this.SetCtrlEnabledDBConnState();

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
                    aActiveForm.Activated += this.MdiChildFormActivated;
                    aActiveForm.FormClosing += this.MdiChildFormClosing;
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

        private void SetCtrlEnabledDBConnState()
        {
            if (Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                this.tsmiConnect.Enabled = false;
                this.tsmiDisconnect.Enabled = true;
                this.tsMain.Enabled = true;
                this.tsSub.Enabled = true;
            }
            else
            {
                this.tsmiConnect.Enabled = true;
                this.tsmiDisconnect.Enabled = false;
                this.tsMain.Enabled = false;
                this.tsSub.Enabled = false;
            }
        }

        private void CloseAllMdiForm()
        {
            for (int cnt = this.MdiChildren.Length - 1; cnt > -1; cnt--)
            {
                this.MdiChildren[cnt].Close();
            }
        }

        private void AddToolStripMenuItemByFormType(Form aMDIForm)
        {
            bool existFormState = false;

            for (int itemCnt = 0; itemCnt < this.창ToolStripMenuItem.DropDownItems.Count; itemCnt++)
            {
                if (!this.창ToolStripMenuItem.DropDownItems[itemCnt].GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    continue;
                }

                ToolStripMenuItem mi = this.창ToolStripMenuItem.DropDownItems[itemCnt] as ToolStripMenuItem;
                mi.Checked = false;

                if (mi.Tag != null)
                {
                    if (mi.Tag.Equals((Common.Definition.ConstValue.DBViewerFormType)aMDIForm.Tag))
                    {
                        mi.Checked = true;
                        existFormState = true;
                    }
                }
            }

            if (!existFormState)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = aMDIForm.Text;
                tsmi.Tag = (Common.Definition.ConstValue.DBViewerFormType)aMDIForm.Tag;
                tsmi.Checked = true;
                tsmi.Click += new EventHandler(this.AddToolStripMenuItem_Click);

                this.창ToolStripMenuItem.DropDownItems.Add(tsmi);
            }
        }

        private void DelToolStripMenuItemByFormType(Common.Definition.ConstValue.DBViewerFormType aFormType)
        {
            for (int itemCnt = 0; itemCnt < this.창ToolStripMenuItem.DropDownItems.Count; itemCnt++)
            {
                if (!this.창ToolStripMenuItem.DropDownItems[itemCnt].GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    continue;
                }

                ToolStripMenuItem mi = this.창ToolStripMenuItem.DropDownItems[itemCnt] as ToolStripMenuItem;
                mi.Checked = false;

                if (mi.Tag != null)
                {
                    if (mi.Tag.Equals(aFormType))
                    {
                        this.창ToolStripMenuItem.DropDownItems.Remove(mi);
                        return;
                    }
                }
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void MdiChildFormActivated(object sender, EventArgs e)
        {
            Form senderFrm = sender as Form;

            if (senderFrm != null)
            {
                Common.Definition.ConstValue.DBViewerFormType frmType = (Common.Definition.ConstValue.DBViewerFormType)senderFrm.Tag;

                foreach (ToolStripButton tsb in this.tsSub.Items)
                {
                    if (tsb.Tag != null)
                    {
                        if (tsb.Tag.Equals(frmType))
                        {
                            tsb.Checked = true;
                        }
                        else
                        {
                            tsb.Checked = false;
                        }
                    }
                }

                this.AddToolStripMenuItemByFormType(senderFrm);
            }
        }

        private void MdiChildFormClosing(object sender, FormClosingEventArgs e)
        {
            Form senderFrm = sender as Form;

            if (senderFrm != null)
            {
                Common.Definition.ConstValue.DBViewerFormType frmType = (Common.Definition.ConstValue.DBViewerFormType)senderFrm.Tag;

                if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SqlWindow))
                {
                    if (this.tsSub.Items.Contains(this.mTsBtnSqlWindow))
                    {
                        this.tsSub.Items.Remove(this.mTsBtnSqlWindow);
                    }
                }
                else if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SchemaBrowser))
                {
                    if (this.tsSub.Items.Contains(this.mTsBtnSchemaBrowser))
                    {
                        this.tsSub.Items.Remove(this.mTsBtnSchemaBrowser);
                    }
                }
                else if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SessionViewer))
                {
                    if (this.tsSub.Items.Contains(this.mTsBtnSessionView))
                    {
                        this.tsSub.Items.Remove(this.mTsBtnSessionView);
                    }
                }
                else if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.TableSpaceViewer))
                {
                    if (this.tsSub.Items.Contains(this.mTsBtnTableSpaceView))
                    {
                        this.tsSub.Items.Remove(this.mTsBtnTableSpaceView);
                    }
                }

                this.DelToolStripMenuItemByFormType(frmType);
            }
        }

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
                window.Tag = Common.Definition.ConstValue.DBViewerFormType.SqlWindow;

                this.ShowFormORClose(window);
            }
            else if (tsBtn.Equals(this.mTsBtnSchemaBrowser))
            {
                frmSchemaBrowser browser = new frmSchemaBrowser();
                browser.Tag = Common.Definition.ConstValue.DBViewerFormType.SchemaBrowser;

                this.ShowFormORClose(browser);
            }
            else if (tsBtn.Equals(this.mTsBtnSessionView))
            {
                frmSessionView sessionView = new frmSessionView();
                sessionView.Tag = Common.Definition.ConstValue.DBViewerFormType.SessionViewer;

                this.ShowFormORClose(sessionView);
            }
            else if (tsBtn.Equals(this.mTsBtnTableSpaceView))
            {
                frmTableSpaceView tableSpaceView = new frmTableSpaceView();
                tableSpaceView.Tag = Common.Definition.ConstValue.DBViewerFormType.TableSpaceViewer;

                this.ShowFormORClose(tableSpaceView);
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            if (tsmi != null)
            {
                Common.Definition.ConstValue.DBViewerFormType frmType = (Common.Definition.ConstValue.DBViewerFormType)tsmi.Tag;

                if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SqlWindow))
                {
                    this.tsBtn_Click(this.mTsBtnSqlWindow, null);
                }
                else if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SchemaBrowser))
                {
                    this.tsBtn_Click(this.mTsBtnSchemaBrowser, null);
                }
                else if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SessionViewer))
                {
                    this.tsBtn_Click(this.mTsBtnSessionView, null);
                }
                else if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.TableSpaceViewer))
                {
                    this.tsBtn_Click(this.mTsBtnTableSpaceView, null);
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
            else if (tsBtn.Equals(this.tsbtnTableSpaceViewer))
            {
                if (!this.tsSub.Items.Contains(this.mTsBtnTableSpaceView))
                {
                    this.tsSub.Items.Add(this.mTsBtnTableSpaceView);
                }

                this.tsBtn_Click(this.mTsBtnTableSpaceView, null);
            }
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            if (tsmi != null)
            {
                if (tsmi.Equals(this.tsmiConnect))
                {
                    this.ShowLoginForm();
                }
                else if (tsmi.Equals(this.tsmiDisconnect))
                {
                    Common.Comm.DBWorker.Close();
                    this.CloseAllMdiForm();
                }
                else if (tsmi.Equals(this.tsmiExit))
                {
                    this.Close();
                }
            }
        }

        private void fileMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.SetCtrlEnabledDBConnState();
        }

        private void tsmiSQLWindow_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            if (tsmi != null)
            {
                if (tsmi.Equals(this.tsmiSQLWindow))
                {
                    if (!this.tsSub.Items.Contains(this.mTsBtnSqlWindow))
                    {
                        this.tsSub.Items.Add(this.mTsBtnSqlWindow);
                    }

                    this.tsBtn_Click(this.mTsBtnSqlWindow, null);
                }
                else if (tsmi.Equals(this.tsmiSchemaBrowser))
                {
                    if (!this.tsSub.Items.Contains(this.mTsBtnSchemaBrowser))
                    {
                        this.tsSub.Items.Add(this.mTsBtnSchemaBrowser);
                    }

                    this.tsBtn_Click(this.mTsBtnSchemaBrowser, null);
                }
                else if (tsmi.Equals(this.tsmiSessionView))
                {
                    if (!this.tsSub.Items.Contains(this.mTsBtnSessionView))
                    {
                        this.tsSub.Items.Add(this.mTsBtnSessionView);
                    }

                    this.tsBtn_Click(this.mTsBtnSessionView, null);
                }
                else if (tsmi.Equals(this.tsmiTableSpaceViewer))
                {
                    if (!this.tsSub.Items.Contains(this.mTsBtnTableSpaceView))
                    {
                        this.tsSub.Items.Add(this.mTsBtnTableSpaceView);
                    }

                    this.tsBtn_Click(this.mTsBtnTableSpaceView, null);
                }
            }
        }

        private void tsmiCascadeWindow_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            if (tsmi != null)
            {
                if (tsmi.Equals(this.tsmiCascadeWindow))
                {
                    this.LayoutMdi(MdiLayout.Cascade);
                }
                else if (tsmi.Equals(this.tsmiTileHorizontalWindow))
                {
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                }
                else if (tsmi.Equals(this.tsmiTileVerticalWindow))
                {
                    this.LayoutMdi(MdiLayout.TileVertical);
                }
                else if (tsmi.Equals(this.tsmiAllWindowClose))
                {
                    this.CloseAllMdiForm();
                }
                else if (tsmi.Equals(this.tsmiArrangeIconsWindow))
                {
                    this.LayoutMdi(MdiLayout.ArrangeIcons);
                }
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
    }
}
