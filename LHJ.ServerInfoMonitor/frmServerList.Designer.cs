namespace LHJ.ServerInfoMonitor
{
    partial class frmServerList
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
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.propertyGridEx1 = new PropertyGridEx.PropertyGridEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxPing = new System.Windows.Forms.TextBox();
            this.btnPing = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.lvwServer = new System.Windows.Forms.ListView();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.propertyGridEx1);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.lvwServer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(300, 519);
            this.pnlMain.TabIndex = 0;
            // 
            // propertyGridEx1
            // 
            this.propertyGridEx1.AutoSizeProperties = true;
            // 
            // 
            // 
            this.propertyGridEx1.DocCommentDescription.AutoEllipsis = true;
            this.propertyGridEx1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridEx1.DocCommentDescription.Location = new System.Drawing.Point(3, 19);
            this.propertyGridEx1.DocCommentDescription.Name = "";
            this.propertyGridEx1.DocCommentDescription.Size = new System.Drawing.Size(294, 36);
            this.propertyGridEx1.DocCommentDescription.TabIndex = 1;
            this.propertyGridEx1.DocCommentImage = null;
            // 
            // 
            // 
            this.propertyGridEx1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridEx1.DocCommentTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.propertyGridEx1.DocCommentTitle.Location = new System.Drawing.Point(3, 3);
            this.propertyGridEx1.DocCommentTitle.Name = "";
            this.propertyGridEx1.DocCommentTitle.Size = new System.Drawing.Size(294, 16);
            this.propertyGridEx1.DocCommentTitle.TabIndex = 0;
            this.propertyGridEx1.DocCommentTitle.UseMnemonic = false;
            this.propertyGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridEx1.Location = new System.Drawing.Point(0, 197);
            this.propertyGridEx1.Name = "propertyGridEx1";
            this.propertyGridEx1.Size = new System.Drawing.Size(300, 322);
            this.propertyGridEx1.TabIndex = 6;
            // 
            // 
            // 
            this.propertyGridEx1.ToolStrip.AccessibleName = "도구 모음";
            this.propertyGridEx1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.propertyGridEx1.ToolStrip.AllowMerge = false;
            this.propertyGridEx1.ToolStrip.AutoSize = false;
            this.propertyGridEx1.ToolStrip.CanOverflow = false;
            this.propertyGridEx1.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.propertyGridEx1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.propertyGridEx1.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this.propertyGridEx1.ToolStrip.Name = "";
            this.propertyGridEx1.ToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.propertyGridEx1.ToolStrip.Size = new System.Drawing.Size(300, 25);
            this.propertyGridEx1.ToolStrip.TabIndex = 1;
            this.propertyGridEx1.ToolStrip.TabStop = true;
            this.propertyGridEx1.ToolStrip.Text = "PropertyGridToolBar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxPing);
            this.panel1.Controls.Add(this.btnPing);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnInit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 64);
            this.panel1.TabIndex = 5;
            // 
            // tbxPing
            // 
            this.tbxPing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPing.Location = new System.Drawing.Point(49, 34);
            this.tbxPing.Name = "tbxPing";
            this.tbxPing.Size = new System.Drawing.Size(248, 21);
            this.tbxPing.TabIndex = 8;
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(3, 33);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(40, 23);
            this.btnPing.TabIndex = 7;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(207, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(90, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(99, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "추가＆수정";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(3, 5);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(90, 23);
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "초기화";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lvwServer
            // 
            this.lvwServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwServer.Location = new System.Drawing.Point(0, 0);
            this.lvwServer.MultiSelect = false;
            this.lvwServer.Name = "lvwServer";
            this.lvwServer.Size = new System.Drawing.Size(300, 133);
            this.lvwServer.TabIndex = 0;
            this.lvwServer.UseCompatibleStateImageBehavior = false;
            this.lvwServer.View = System.Windows.Forms.View.List;
            this.lvwServer.SelectedIndexChanged += new System.EventHandler(this.lvwServer_SelectedIndexChanged);
            this.lvwServer.DoubleClick += new System.EventHandler(this.lvwServer_DoubleClick);
            // 
            // frmServerList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 519);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServerList";
            this.Text = "frmServerList";
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.ListView lvwServer;
        private System.Windows.Forms.TextBox tbxPing;
        private System.Windows.Forms.Button btnPing;
        private PropertyGridEx.PropertyGridEx propertyGridEx1;
    }
}