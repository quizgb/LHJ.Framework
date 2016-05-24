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
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.newTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSeqMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synonymToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.newPackageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProcedureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFunctionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTriggerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.databaseLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commitF9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rollbackF10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSessionView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsSub = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslOracleVersion = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem4,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.printToolStripMenuItem,
            this.toolStripMenuItem6,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fileMenuItem.Text = "파일(&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLWindowToolStripMenuItem,
            this.commandWindowToolStripMenuItem,
            this.toolStripMenuItem7,
            this.newTableMenuItem,
            this.newViewMenuItem,
            this.newSeqMenuItem,
            this.synonymToolStripMenuItem,
            this.directoryToolStripMenuItem,
            this.jobToolStripMenuItem,
            this.toolStripMenuItem1,
            this.newPackageMenuItem,
            this.newProcedureMenuItem,
            this.newFunctionMenuItem,
            this.newTriggerMenuItem,
            this.toolStripMenuItem2,
            this.userToolStripMenuItem,
            this.roleToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.toolStripMenuItem3,
            this.databaseLinkToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // sQLWindowToolStripMenuItem
            // 
            this.sQLWindowToolStripMenuItem.Name = "sQLWindowToolStripMenuItem";
            this.sQLWindowToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sQLWindowToolStripMenuItem.Text = "SQL Window ...";
            // 
            // commandWindowToolStripMenuItem
            // 
            this.commandWindowToolStripMenuItem.Name = "commandWindowToolStripMenuItem";
            this.commandWindowToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.commandWindowToolStripMenuItem.Text = "Command Window";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(176, 6);
            // 
            // newTableMenuItem
            // 
            this.newTableMenuItem.Name = "newTableMenuItem";
            this.newTableMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newTableMenuItem.Text = "Table";
            // 
            // newViewMenuItem
            // 
            this.newViewMenuItem.Name = "newViewMenuItem";
            this.newViewMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newViewMenuItem.Text = "View";
            // 
            // newSeqMenuItem
            // 
            this.newSeqMenuItem.Name = "newSeqMenuItem";
            this.newSeqMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newSeqMenuItem.Text = "Sequence";
            // 
            // synonymToolStripMenuItem
            // 
            this.synonymToolStripMenuItem.Name = "synonymToolStripMenuItem";
            this.synonymToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.synonymToolStripMenuItem.Text = "Synonym";
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.directoryToolStripMenuItem.Text = "Directory";
            // 
            // jobToolStripMenuItem
            // 
            this.jobToolStripMenuItem.Name = "jobToolStripMenuItem";
            this.jobToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jobToolStripMenuItem.Text = "Job";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // newPackageMenuItem
            // 
            this.newPackageMenuItem.Name = "newPackageMenuItem";
            this.newPackageMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newPackageMenuItem.Text = "Package";
            // 
            // newProcedureMenuItem
            // 
            this.newProcedureMenuItem.Name = "newProcedureMenuItem";
            this.newProcedureMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newProcedureMenuItem.Text = "Procedure";
            // 
            // newFunctionMenuItem
            // 
            this.newFunctionMenuItem.Name = "newFunctionMenuItem";
            this.newFunctionMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newFunctionMenuItem.Text = "Function";
            // 
            // newTriggerMenuItem
            // 
            this.newTriggerMenuItem.Name = "newTriggerMenuItem";
            this.newTriggerMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newTriggerMenuItem.Text = "Trigger";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 6);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.userToolStripMenuItem.Text = "User";
            // 
            // roleToolStripMenuItem
            // 
            this.roleToolStripMenuItem.Name = "roleToolStripMenuItem";
            this.roleToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.roleToolStripMenuItem.Text = "Role";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 6);
            // 
            // databaseLinkToolStripMenuItem
            // 
            this.databaseLinkToolStripMenuItem.Name = "databaseLinkToolStripMenuItem";
            this.databaseLinkToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.databaseLinkToolStripMenuItem.Text = "Database Link";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(144, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveAsToolStripMenuItem.Text = "Save as ..";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(144, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(144, 6);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.connectToolStripMenuItem.Text = "Connect ...";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect ...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(144, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOnToolStripMenuItem,
            this.logOffToolStripMenuItem,
            this.toolStripMenuItem8,
            this.executeToolStripMenuItem,
            this.commitF9ToolStripMenuItem,
            this.rollbackF10ToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.sessionToolStripMenuItem.Text = "보기(&V)";
            // 
            // logOnToolStripMenuItem
            // 
            this.logOnToolStripMenuItem.Name = "logOnToolStripMenuItem";
            this.logOnToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.logOnToolStripMenuItem.Text = "Log on";
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.logOffToolStripMenuItem.Text = "Log off";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 6);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.executeToolStripMenuItem.Text = "Execute     F8";
            // 
            // commitF9ToolStripMenuItem
            // 
            this.commitF9ToolStripMenuItem.Name = "commitF9ToolStripMenuItem";
            this.commitF9ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.commitF9ToolStripMenuItem.Text = "Commit      F9";
            // 
            // rollbackF10ToolStripMenuItem
            // 
            this.rollbackF10ToolStripMenuItem.Name = "rollbackF10ToolStripMenuItem";
            this.rollbackF10ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.rollbackF10ToolStripMenuItem.Text = "Rollback    F11";
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
            this.saveToolStripButton,
            this.tsbtnSessionView,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
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
            this.tsbtnSqlWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSqlWindow.Image")));
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
            this.tsbtnSchemaBrowser.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSchemaBrowser.Image")));
            this.tsbtnSchemaBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSchemaBrowser.Name = "tsbtnSchemaBrowser";
            this.tsbtnSchemaBrowser.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSchemaBrowser.Text = "Schema Browser";
            this.tsbtnSchemaBrowser.Click += new System.EventHandler(this.tsbtnSqlWindow_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // tsbtnSessionView
            // 
            this.tsbtnSessionView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSessionView.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSessionView.Image")));
            this.tsbtnSessionView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSessionView.Name = "tsbtnSessionView";
            this.tsbtnSessionView.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSessionView.Text = "Session View";
            this.tsbtnSessionView.ToolTipText = "Session View";
            this.tsbtnSessionView.Click += new System.EventHandler(this.tsbtnSqlWindow_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
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
            this.toolStripStatusLabel1,
            this.tsslOracleVersion});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 858);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1264, 26);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 21);
            this.toolStripStatusLabel1.Text = "                    ";
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
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem newTableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSeqMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synonymToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newPackageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProcedureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFunctionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTriggerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem databaseLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commitF9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rollbackF10ToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton tsbtnSessionView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStrip tsSub;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslOracleVersion;

    }
}