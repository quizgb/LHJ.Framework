namespace LHJ.DBViewer
{
    partial class frmTableSpaceView
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTableSpaceName = new System.Windows.Forms.Label();
            this.lbxTableSpace = new System.Windows.Forms.ListBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvTableSpace = new LHJ.Controls.ucDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new LHJ.Controls.ucDataGridView.DataGridViewProgressColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTableSpaceName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(845, 46);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTableSpaceName
            // 
            this.lblTableSpaceName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTableSpaceName.AutoSize = true;
            this.lblTableSpaceName.Location = new System.Drawing.Point(166, 9);
            this.lblTableSpaceName.Name = "lblTableSpaceName";
            this.lblTableSpaceName.Size = new System.Drawing.Size(0, 12);
            this.lblTableSpaceName.TabIndex = 0;
            // 
            // lbxTableSpace
            // 
            this.lbxTableSpace.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbxTableSpace.FormattingEnabled = true;
            this.lbxTableSpace.ItemHeight = 12;
            this.lbxTableSpace.Location = new System.Drawing.Point(0, 46);
            this.lbxTableSpace.Name = "lbxTableSpace";
            this.lbxTableSpace.Size = new System.Drawing.Size(162, 537);
            this.lbxTableSpace.TabIndex = 3;
            this.lbxTableSpace.SelectedIndexChanged += new System.EventHandler(this.lbxTableSpace_SelectedIndexChanged);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dgvTableSpace);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(162, 46);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(683, 537);
            this.pnlBody.TabIndex = 4;
            // 
            // dgvTableSpace
            // 
            this.dgvTableSpace.AllowUserToAddRows = false;
            this.dgvTableSpace.AllowUserToDeleteRows = false;
            this.dgvTableSpace.AllowUserToResizeRows = false;
            this.dgvTableSpace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTableSpace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableSpace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvTableSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableSpace.Location = new System.Drawing.Point(0, 0);
            this.dgvTableSpace.Name = "dgvTableSpace";
            this.dgvTableSpace.ReadOnly = true;
            this.dgvTableSpace.RowTemplate.Height = 23;
            this.dgvTableSpace.ShowRowHeaderValue = true;
            this.dgvTableSpace.Size = new System.Drawing.Size(683, 537);
            this.dgvTableSpace.TabIndex = 0;
            this.dgvTableSpace.DataSourceChanged += new System.EventHandler(this.dgvTableSpace_DataSourceChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.DataPropertyName = "FILE_NAME";
            this.Column1.HeaderText = "DataFile Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 104;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column2.DataPropertyName = "FILE_ID";
            this.Column2.HeaderText = "File ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 51;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "USAGE";
            this.Column3.HeaderText = "Usage";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 47;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column4.DataPropertyName = "TOTAL";
            this.Column4.HeaderText = "Total";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 58;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column5.DataPropertyName = "USED";
            this.Column5.HeaderText = "Used";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 59;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.DataPropertyName = "FREE";
            this.Column6.HeaderText = "Free";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 55;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column7.DataPropertyName = "AUTOEXTENSIBLE";
            this.Column7.HeaderText = "AutoExtend";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 94;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column8.DataPropertyName = "STATUS";
            this.Column8.HeaderText = "Status";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 65;
            // 
            // frmTableSpaceView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(845, 583);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.lbxTableSpace);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmTableSpaceView";
            this.Text = "TableSpace Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSpace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.ListBox lbxTableSpace;
        private System.Windows.Forms.Label lblTableSpaceName;
        private System.Windows.Forms.Panel pnlBody;
        private Controls.ucDataGridView dgvTableSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Controls.ucDataGridView.DataGridViewProgressColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}