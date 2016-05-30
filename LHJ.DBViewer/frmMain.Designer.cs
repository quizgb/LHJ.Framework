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
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.findObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comileInvalidObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
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
            this.tsmiTableSpaceViewer = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolsMenuItem});
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
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionsToolStripMenuItem,
            this.toolStripMenuItem9,
            this.findObjectsToolStripMenuItem,
            this.comileInvalidObjectsToolStripMenuItem,
            this.computeStatisticsToolStripMenuItem,
            this.toolStripMenuItem10});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(57, 20);
            this.toolsMenuItem.Text = "도구(&T)";
            // 
            // sessionsToolStripMenuItem
            // 
            this.sessionsToolStripMenuItem.Name = "sessionsToolStripMenuItem";
            this.sessionsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.sessionsToolStripMenuItem.Text = "Sessions...";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(199, 6);
            // 
            // findObjectsToolStripMenuItem
            // 
            this.findObjectsToolStripMenuItem.Name = "findObjectsToolStripMenuItem";
            this.findObjectsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.findObjectsToolStripMenuItem.Text = "Find Objects";
            // 
            // comileInvalidObjectsToolStripMenuItem
            // 
            this.comileInvalidObjectsToolStripMenuItem.Name = "comileInvalidObjectsToolStripMenuItem";
            this.comileInvalidObjectsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.comileInvalidObjectsToolStripMenuItem.Text = "Compile Invalid Objects";
            // 
            // computeStatisticsToolStripMenuItem
            // 
            this.computeStatisticsToolStripMenuItem.Name = "computeStatisticsToolStripMenuItem";
            this.computeStatisticsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.computeStatisticsToolStripMenuItem.Text = "Compute Statistics";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(199, 6);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 858);
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
            // tsmiTableSpaceViewer
            // 
            this.tsmiTableSpaceViewer.Image = global::LHJ.DBViewer.Properties.Resources._1464171733_computer_settings;
            this.tsmiTableSpaceViewer.Name = "tsmiTableSpaceViewer";
            this.tsmiTableSpaceViewer.Size = new System.Drawing.Size(174, 22);
            this.tsmiTableSpaceViewer.Text = "TableSpace Viewer";
            this.tsmiTableSpaceViewer.Click += new System.EventHandler(this.tsmiSQLWindow_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 884);
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
        private System.Windows.Forms.ToolStripMenuItem sessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem findObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comileInvalidObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computeStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
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

    }
}