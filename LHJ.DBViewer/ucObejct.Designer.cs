namespace LHJ.DBViewer
{
    partial class ucObejct
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lbxObject = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvColumnInfo = new LHJ.Controls.ucDataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ucObjectList1 = new LHJ.DBViewer.ucObjectList();
            this.ucUserList1 = new LHJ.DBViewer.ucUserList();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 347);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(330, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // lbxObject
            // 
            this.lbxObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxObject.FormattingEnabled = true;
            this.lbxObject.ItemHeight = 12;
            this.lbxObject.Location = new System.Drawing.Point(0, 0);
            this.lbxObject.Name = "lbxObject";
            this.lbxObject.Size = new System.Drawing.Size(186, 304);
            this.lbxObject.TabIndex = 2;
            this.lbxObject.SelectedIndexChanged += new System.EventHandler(this.lbxObject_SelectedIndexChanged);
            this.lbxObject.DoubleClick += new System.EventHandler(this.lbxObject_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 90);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbxObject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvColumnInfo);
            this.splitContainer1.Size = new System.Drawing.Size(186, 429);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgvColumnInfo
            // 
            this.dgvColumnInfo.AllowUserToAddRows = false;
            this.dgvColumnInfo.AllowUserToDeleteRows = false;
            this.dgvColumnInfo.AllowUserToResizeRows = false;
            this.dgvColumnInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvColumnInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvColumnInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumnInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvColumnInfo.Name = "dgvColumnInfo";
            this.dgvColumnInfo.ReadOnly = true;
            this.dgvColumnInfo.RowHeadersVisible = false;
            this.dgvColumnInfo.RowTemplate.Height = 23;
            this.dgvColumnInfo.ShowRowHeaderValue = false;
            this.dgvColumnInfo.Size = new System.Drawing.Size(186, 121);
            this.dgvColumnInfo.TabIndex = 5;
            this.dgvColumnInfo.DataSourceChanged += new System.EventHandler(this.dgvColumnInfo_DataSourceChanged);
            this.dgvColumnInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumnInfo_CellDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(46, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 21);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = global::LHJ.DBViewer.Properties.Resources._1464092745_old_view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(6, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 27);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ucObjectList1
            // 
            this.ucObjectList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucObjectList1.Location = new System.Drawing.Point(3, 26);
            this.ucObjectList1.Name = "ucObjectList1";
            this.ucObjectList1.Size = new System.Drawing.Size(186, 25);
            this.ucObjectList1.TabIndex = 4;
            this.ucObjectList1.SelectedObjChanged += new LHJ.Common.Definition.EventHandler.SelectedObjChangedEventHandler(this.ucObjectList1_SelectedObjChanged);
            // 
            // ucUserList1
            // 
            this.ucUserList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucUserList1.Location = new System.Drawing.Point(3, 3);
            this.ucUserList1.Name = "ucUserList1";
            this.ucUserList1.Size = new System.Drawing.Size(186, 25);
            this.ucUserList1.TabIndex = 3;
            this.ucUserList1.SelectedUserChanged += new LHJ.Common.Definition.EventHandler.SelectedUserChangedEventHandler(this.ucUserList1_SelectedUserChanged);
            // 
            // ucObejct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ucObjectList1);
            this.Controls.Add(this.ucUserList1);
            this.Name = "ucObejct";
            this.Size = new System.Drawing.Size(192, 522);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbxObject;
        private ucUserList ucUserList1;
        private ucObjectList ucObjectList1;
        private Controls.ucDataGridView dgvColumnInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
