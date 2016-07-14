namespace LHJ.DBViewer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnSqlWindow = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSchemaBrowser = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSessionView = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTableSpaceViewer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsSub = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslLastBulidDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslOracleVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.창ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCascadeWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileVerticalWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileHorizontalWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAllWindowClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArrangeIconsWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.mnsMain.Size = new System.Drawing.Size(1264, 24);
            this.mnsMain.TabIndex = 11;
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
            this.fileMenuItem.DropDownOpening += new System.EventHandler(this.fileMenuItem_DropDownOpening);
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(152, 22);
            this.tsmiConnect.Text = "Connect ...";
            this.tsmiConnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Name = "tsmiDisconnect";
            this.tsmiDisconnect.Size = new System.Drawing.Size(152, 22);
            this.tsmiDisconnect.Text = "Disconnect ...";
            this.tsmiDisconnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiConnect_Click);
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
            this.tsmiSQLWindow.Image = global::LHJ.DBViewer.Properties.Resources._1464171549_browser_window;
            this.tsmiSQLWindow.Name = "tsmiSQLWindow";
            this.tsmiSQLWindow.Size = new System.Drawing.Size(174, 22);
            this.tsmiSQLWindow.Text = "SQL Window";
            this.tsmiSQLWindow.Click += new System.EventHandler(this.tsmiSQLWindow_Click);
            // 
            // tsmiSchemaBrowser
            // 
            this.tsmiSchemaBrowser.Image = global::LHJ.DBViewer.Properties.Resources._1464171551_server;
            this.tsmiSchemaBrowser.Name = "tsmiSchemaBrowser";
            this.tsmiSchemaBrowser.Size = new System.Drawing.Size(174, 22);
            this.tsmiSchemaBrowser.Text = "Schema Browser";
            this.tsmiSchemaBrowser.Click += new System.EventHandler(this.tsmiSQLWindow_Click);
            // 
            // tsmiSessionView
            // 
            this.tsmiSessionView.Image = global::LHJ.DBViewer.Properties.Resources._1464171443_computer;
            this.tsmiSessionView.Name = "tsmiSessionView";
            this.tsmiSessionView.Size = new System.Drawing.Size(174, 22);
            this.tsmiSessionView.Text = "Session View";
            this.tsmiSessionView.Click += new System.EventHandler(this.tsmiSQLWindow_Click);
            // 
            // tsmiTableSpaceViewer
            // 
            this.tsmiTableSpaceViewer.Image = global::LHJ.DBViewer.Properties.Resources._1464171733_computer_settings;
            this.tsmiTableSpaceViewer.Name = "tsmiTableSpaceViewer";
            this.tsmiTableSpaceViewer.Size = new System.Drawing.Size(174, 22);
            this.tsmiTableSpaceViewer.Text = "TableSpace Viewer";
            this.tsmiTableSpaceViewer.Click += new System.EventHandler(this.tsmiSQLWindow_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(57, 20);
            this.toolsMenuItem.Text = "도구(&T)";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSqlWindow,
            this.tsbtnSchemaBrowser,
            this.tsbtnSessionView,
            this.tsbtnTableSpaceViewer,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1264, 25);
            this.tsMain.TabIndex = 14;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnSqlWindow
            // 
            this.tsbtnSqlWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSqlWindow.Image = global::LHJ.DBViewer.Properties.Resources._1464171549_browser_window;
            this.tsbtnSqlWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSqlWindow.Name = "tsbtnSqlWindow";
            this.tsbtnSqlWindow.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSqlWindow.Text = "SQL Window";
            this.tsbtnSqlWindow.ToolTipText = "SQL Window";
            this.tsbtnSqlWindow.Click += new System.EventHandler(this.tsbtnSqlWindow_Click);
            // 
            // tsbtnSchemaBrowser
            // 
            this.tsbtnSchemaBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSchemaBrowser.Image = global::LHJ.DBViewer.Properties.Resources._1464171551_server;
            this.tsbtnSchemaBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSchemaBrowser.Name = "tsbtnSchemaBrowser";
            this.tsbtnSchemaBrowser.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSchemaBrowser.Text = "Schema Browser";
            this.tsbtnSchemaBrowser.Click += new System.EventHandler(this.tsbtnSqlWindow_Click);
            // 
            // tsbtnSessionView
            // 
            this.tsbtnSessionView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSessionView.Image = global::LHJ.DBViewer.Properties.Resources._1464171443_computer;
            this.tsbtnSessionView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSessionView.Name = "tsbtnSessionView";
            this.tsbtnSessionView.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSessionView.Text = "Session View";
            this.tsbtnSessionView.ToolTipText = "Session View";
            this.tsbtnSessionView.Click += new System.EventHandler(this.tsbtnSqlWindow_Click);
            // 
            // tsbtnTableSpaceViewer
            // 
            this.tsbtnTableSpaceViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTableSpaceViewer.Image = global::LHJ.DBViewer.Properties.Resources._1464171733_computer_settings;
            this.tsbtnTableSpaceViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTableSpaceViewer.Name = "tsbtnTableSpaceViewer";
            this.tsbtnTableSpaceViewer.Size = new System.Drawing.Size(23, 22);
            this.tsbtnTableSpaceViewer.Text = "TableSpace Viewer";
            this.tsbtnTableSpaceViewer.Click += new System.EventHandler(this.tsbtnSqlWindow_Click);
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
            // tsSub
            // 
            this.tsSub.Location = new System.Drawing.Point(0, 49);
            this.tsSub.Name = "tsSub";
            this.tsSub.Size = new System.Drawing.Size(1264, 25);
            this.tsSub.TabIndex = 16;
            this.tsSub.Text = "toolStrip2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLastBulidDate,
            this.tsslOracleVersion});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 850);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1264, 26);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslLastBulidDate
            // 
            this.tsslLastBulidDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslLastBulidDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslLastBulidDate.Name = "tsslLastBulidDate";
            this.tsslLastBulidDate.Size = new System.Drawing.Size(92, 21);
            this.tsslLastBulidDate.Text = "(LastBulidDate)";
            // 
            // tsslOracleVersion
            // 
            this.tsslOracleVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslOracleVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslOracleVersion.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsslOracleVersion.Name = "tsslOracleVersion";
            this.tsslOracleVersion.Size = new System.Drawing.Size(103, 21);
            this.tsslOracleVersion.Text = "(OracleVersion)";
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
            this.tsmiCascadeWindow.Click += new System.EventHandler(this.tsmiCascadeWindow_Click);
            // 
            // tsmiTileVerticalWindow
            // 
            this.tsmiTileVerticalWindow.Name = "tsmiTileVerticalWindow";
            this.tsmiTileVerticalWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiTileVerticalWindow.Text = "세로 바둑판식 배열";
            this.tsmiTileVerticalWindow.Click += new System.EventHandler(this.tsmiCascadeWindow_Click);
            // 
            // tsmiTileHorizontalWindow
            // 
            this.tsmiTileHorizontalWindow.Name = "tsmiTileHorizontalWindow";
            this.tsmiTileHorizontalWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiTileHorizontalWindow.Text = "가로 바둑판식 배열";
            this.tsmiTileHorizontalWindow.Click += new System.EventHandler(this.tsmiCascadeWindow_Click);
            // 
            // tsmiAllWindowClose
            // 
            this.tsmiAllWindowClose.Name = "tsmiAllWindowClose";
            this.tsmiAllWindowClose.Size = new System.Drawing.Size(178, 22);
            this.tsmiAllWindowClose.Text = "모두 닫기";
            this.tsmiAllWindowClose.Click += new System.EventHandler(this.tsmiCascadeWindow_Click);
            // 
            // tsmiArrangeIconsWindow
            // 
            this.tsmiArrangeIconsWindow.Name = "tsmiArrangeIconsWindow";
            this.tsmiArrangeIconsWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiArrangeIconsWindow.Text = "아이콘 정렬";
            this.tsmiArrangeIconsWindow.Click += new System.EventHandler(this.tsmiCascadeWindow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 876);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsSub);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnsMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LHJ_DBViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmMain_Shown);
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
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnSqlWindow;
        private System.Windows.Forms.ToolStripButton tsbtnSchemaBrowser;
        private System.Windows.Forms.ToolStripButton tsbtnSessionView;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStrip tsSub;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslLastBulidDate;
        private System.Windows.Forms.ToolStripStatusLabel tsslOracleVersion;
        private System.Windows.Forms.ToolStripButton tsbtnTableSpaceViewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableSpaceViewer;
        private System.Windows.Forms.ToolStripMenuItem 창ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCascadeWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileVerticalWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileHorizontalWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllWindowClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiArrangeIconsWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

    }
}