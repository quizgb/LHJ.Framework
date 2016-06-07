namespace LHJ.DBViewer
{
    partial class frmSessionView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvSession = new LHJ.Controls.ucDataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvLock = new LHJ.Controls.ucDataGridView();
            this.cmsDeleteLock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteLock = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLock = new System.Windows.Forms.Button();
            this.txtSessionQuery = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLock)).BeginInit();
            this.cmsDeleteLock.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1264, 884);
            this.pnlMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSession);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 849);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvSession
            // 
            this.dgvSession.AllowUserToAddRows = false;
            this.dgvSession.AllowUserToDeleteRows = false;
            this.dgvSession.AllowUserToResizeRows = false;
            this.dgvSession.BackgroundColor = System.Drawing.Color.White;
            this.dgvSession.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSession.Location = new System.Drawing.Point(0, 0);
            this.dgvSession.MultiSelect = false;
            this.dgvSession.Name = "dgvSession";
            this.dgvSession.ReadOnly = true;
            this.dgvSession.RowHeadersVisible = false;
            this.dgvSession.RowTemplate.Height = 23;
            this.dgvSession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSession.ShowRowHeaderValue = false;
            this.dgvSession.Size = new System.Drawing.Size(1264, 374);
            this.dgvSession.TabIndex = 2;
            this.dgvSession.DataSourceChanged += new System.EventHandler(this.dgvSession_DataSourceChanged);
            this.dgvSession.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSession_CellDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvLock);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtSessionQuery);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(1264, 471);
            this.splitContainer2.SplitterDistance = 667;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvLock
            // 
            this.dgvLock.AllowUserToAddRows = false;
            this.dgvLock.AllowUserToDeleteRows = false;
            this.dgvLock.AllowUserToResizeRows = false;
            this.dgvLock.BackgroundColor = System.Drawing.Color.White;
            this.dgvLock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLock.ContextMenuStrip = this.cmsDeleteLock;
            this.dgvLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLock.Location = new System.Drawing.Point(0, 35);
            this.dgvLock.MultiSelect = false;
            this.dgvLock.Name = "dgvLock";
            this.dgvLock.ReadOnly = true;
            this.dgvLock.RowHeadersVisible = false;
            this.dgvLock.RowTemplate.Height = 23;
            this.dgvLock.ShowRowHeaderValue = false;
            this.dgvLock.Size = new System.Drawing.Size(667, 436);
            this.dgvLock.TabIndex = 3;
            this.dgvLock.DataSourceChanged += new System.EventHandler(this.dgvLock_DataSourceChanged);
            // 
            // cmsDeleteLock
            // 
            this.cmsDeleteLock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteLock});
            this.cmsDeleteLock.Name = "contextMenuStrip1";
            this.cmsDeleteLock.Size = new System.Drawing.Size(138, 26);
            // 
            // tsmiDeleteLock
            // 
            this.tsmiDeleteLock.Name = "tsmiDeleteLock";
            this.tsmiDeleteLock.Size = new System.Drawing.Size(137, 22);
            this.tsmiDeleteLock.Text = "Delete Lock";
            this.tsmiDeleteLock.Click += new System.EventHandler(this.tsmiDeleteLock_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 35);
            this.panel1.TabIndex = 2;
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(12, 6);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 23);
            this.btnLock.TabIndex = 12;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSessionQuery
            // 
            this.txtSessionQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSessionQuery.Location = new System.Drawing.Point(0, 35);
            this.txtSessionQuery.Multiline = true;
            this.txtSessionQuery.Name = "txtSessionQuery";
            this.txtSessionQuery.ReadOnly = true;
            this.txtSessionQuery.Size = new System.Drawing.Size(593, 436);
            this.txtSessionQuery.TabIndex = 4;
            this.txtSessionQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSessionQuery_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnCopy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 35);
            this.panel2.TabIndex = 3;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.cbxAutoRefresh);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtSecond);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1264, 35);
            this.pnlTop.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(178, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbxAutoRefresh
            // 
            this.cbxAutoRefresh.AutoSize = true;
            this.cbxAutoRefresh.Location = new System.Drawing.Point(100, 10);
            this.cbxAutoRefresh.Name = "cbxAutoRefresh";
            this.cbxAutoRefresh.Size = new System.Drawing.Size(72, 16);
            this.cbxAutoRefresh.TabIndex = 11;
            this.cbxAutoRefresh.Text = "자동갱신";
            this.cbxAutoRefresh.UseVisualStyleBackColor = true;
            this.cbxAutoRefresh.CheckedChanged += new System.EventHandler(this.cbxAutoRefresh_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "초";
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(12, 8);
            this.txtSecond.MaxLength = 3;
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(51, 21);
            this.txtSecond.TabIndex = 9;
            this.txtSecond.Tag = "";
            this.txtSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSessionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 884);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmSessionView";
            this.Text = "Session 조회";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSessionView_Load);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSession)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLock)).EndInit();
            this.cmsDeleteLock.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.CheckBox cbxAutoRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ucDataGridView dgvSession;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLock;
        private Controls.ucDataGridView dgvLock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtSessionQuery;
        private System.Windows.Forms.ContextMenuStrip cmsDeleteLock;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteLock;
    }
}