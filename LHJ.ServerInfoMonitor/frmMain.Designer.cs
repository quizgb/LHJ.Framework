namespace LHJ.ServerInfoMonitor
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSQLWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSchemaBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSessionView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableSpaceViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.창ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCascadeWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileVerticalWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileHorizontalWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArrangeIconsWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAllWindowClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnRDP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslLastBulidDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.sessionToolStripMenuItem,
            this.toolsMenuItem,
            this.창ToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnsMain.Size = new System.Drawing.Size(1196, 24);
            this.mnsMain.TabIndex = 12;
            this.mnsMain.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect,
            this.tsmiDisconnect,
            this.toolStripSeparator3,
            this.tsmiExit});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fileMenuItem.Text = "파일(&F)";
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(147, 22);
            this.tsmiConnect.Text = "Connect ...";
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Name = "tsmiDisconnect";
            this.tsmiDisconnect.Size = new System.Drawing.Size(147, 22);
            this.tsmiDisconnect.Text = "Disconnect ...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(147, 22);
            this.tsmiExit.Text = "E&xit";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSQLWindow,
            this.tsmiSchemaBrowser,
            this.tsmiSessionView,
            this.tsmiTableSpaceViewer});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.sessionToolStripMenuItem.Text = "보기(&V)";
            // 
            // tsmiSQLWindow
            // 
            this.tsmiSQLWindow.Name = "tsmiSQLWindow";
            this.tsmiSQLWindow.Size = new System.Drawing.Size(174, 22);
            this.tsmiSQLWindow.Text = "SQL Window";
            // 
            // tsmiSchemaBrowser
            // 
            this.tsmiSchemaBrowser.Name = "tsmiSchemaBrowser";
            this.tsmiSchemaBrowser.Size = new System.Drawing.Size(174, 22);
            this.tsmiSchemaBrowser.Text = "Schema Browser";
            // 
            // tsmiSessionView
            // 
            this.tsmiSessionView.Name = "tsmiSessionView";
            this.tsmiSessionView.Size = new System.Drawing.Size(174, 22);
            this.tsmiSessionView.Text = "Session View";
            // 
            // tsmiTableSpaceViewer
            // 
            this.tsmiTableSpaceViewer.Name = "tsmiTableSpaceViewer";
            this.tsmiTableSpaceViewer.Size = new System.Drawing.Size(174, 22);
            this.tsmiTableSpaceViewer.Text = "TableSpace Viewer";
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(57, 20);
            this.toolsMenuItem.Text = "도구(&T)";
            // 
            // 창ToolStripMenuItem
            // 
            this.창ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCascadeWindow,
            this.tsmiTileVerticalWindow,
            this.tsmiTileHorizontalWindow,
            this.tsmiArrangeIconsWindow,
            this.tsmiAllWindowClose,
            this.toolStripSeparator2});
            this.창ToolStripMenuItem.Name = "창ToolStripMenuItem";
            this.창ToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.창ToolStripMenuItem.Text = "창(&W)";
            // 
            // tsmiCascadeWindow
            // 
            this.tsmiCascadeWindow.Name = "tsmiCascadeWindow";
            this.tsmiCascadeWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiCascadeWindow.Text = "계단식 배열";
            // 
            // tsmiTileVerticalWindow
            // 
            this.tsmiTileVerticalWindow.Name = "tsmiTileVerticalWindow";
            this.tsmiTileVerticalWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiTileVerticalWindow.Text = "세로 바둑판식 배열";
            // 
            // tsmiTileHorizontalWindow
            // 
            this.tsmiTileHorizontalWindow.Name = "tsmiTileHorizontalWindow";
            this.tsmiTileHorizontalWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiTileHorizontalWindow.Text = "가로 바둑판식 배열";
            // 
            // tsmiArrangeIconsWindow
            // 
            this.tsmiArrangeIconsWindow.Name = "tsmiArrangeIconsWindow";
            this.tsmiArrangeIconsWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiArrangeIconsWindow.Text = "아이콘 정렬";
            // 
            // tsmiAllWindowClose
            // 
            this.tsmiAllWindowClose.Name = "tsmiAllWindowClose";
            this.tsmiAllWindowClose.Size = new System.Drawing.Size(178, 22);
            this.tsmiAllWindowClose.Text = "모두 닫기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRDP,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1196, 25);
            this.tsMain.TabIndex = 15;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnRDP
            // 
            this.tsbtnRDP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRDP.Image = global::LHJ.ServerInfoMonitor.Properties.Resources._1495533765_Normal_LCD;
            this.tsbtnRDP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRDP.Name = "tsbtnRDP";
            this.tsbtnRDP.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRDP.Text = "원격접속(MSTSC)";
            this.tsbtnRDP.ToolTipText = "원격접속(MSTSC)";
            this.tsbtnRDP.Click += new System.EventHandler(this.tsbtnRDP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLastBulidDate});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1196, 24);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslLastBulidDate
            // 
            this.tsslLastBulidDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslLastBulidDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslLastBulidDate.Name = "tsslLastBulidDate";
            this.tsslLastBulidDate.Size = new System.Drawing.Size(92, 19);
            this.tsslLastBulidDate.Text = "(LastBulidDate)";
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1196, 661);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LHJ_ServerInfoMonitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSQLWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiSchemaBrowser;
        private System.Windows.Forms.ToolStripMenuItem tsmiSessionView;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableSpaceViewer;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 창ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCascadeWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileVerticalWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileHorizontalWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiArrangeIconsWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllWindowClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnRDP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslLastBulidDate;
    }
}

