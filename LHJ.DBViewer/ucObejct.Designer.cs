﻿namespace LHJ.DBViewer
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
            this.ucUserList1 = new LHJ.DBViewer.ucUserList();
            this.ucObjectList1 = new LHJ.DBViewer.ucObjectList();
            this.dgvColumnInfo = new LHJ.Controls.ucDataGridView();
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
            this.lbxObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxObject.FormattingEnabled = true;
            this.lbxObject.ItemHeight = 12;
            this.lbxObject.Location = new System.Drawing.Point(3, 65);
            this.lbxObject.Name = "lbxObject";
            this.lbxObject.Size = new System.Drawing.Size(186, 424);
            this.lbxObject.TabIndex = 2;
            this.lbxObject.SelectedIndexChanged += new System.EventHandler(this.lbxObject_SelectedIndexChanged);
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
            // ucObjectList1
            // 
            this.ucObjectList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucObjectList1.Location = new System.Drawing.Point(3, 34);
            this.ucObjectList1.Name = "ucObjectList1";
            this.ucObjectList1.Size = new System.Drawing.Size(186, 25);
            this.ucObjectList1.TabIndex = 4;
            this.ucObjectList1.SelectedObjChanged += new LHJ.Common.Definition.EventHandler.SelectedObjChangedEventHandler(this.ucObjectList1_SelectedObjChanged);
            // 
            // dgvColumnInfo
            // 
            this.dgvColumnInfo.AllowUserToAddRows = false;
            this.dgvColumnInfo.AllowUserToDeleteRows = false;
            this.dgvColumnInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvColumnInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnInfo.Location = new System.Drawing.Point(54, 287);
            this.dgvColumnInfo.Name = "dgvColumnInfo";
            this.dgvColumnInfo.ReadOnly = true;
            this.dgvColumnInfo.RowTemplate.Height = 23;
            this.dgvColumnInfo.ShowRowHeaderValue = true;
            this.dgvColumnInfo.Size = new System.Drawing.Size(103, 144);
            this.dgvColumnInfo.TabIndex = 5;
            // 
            // ucObejct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvColumnInfo);
            this.Controls.Add(this.ucObjectList1);
            this.Controls.Add(this.ucUserList1);
            this.Controls.Add(this.lbxObject);
            this.Name = "ucObejct";
            this.Size = new System.Drawing.Size(192, 522);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbxObject;
        private ucUserList ucUserList1;
        private ucObjectList ucObjectList1;
        private Controls.ucDataGridView dgvColumnInfo;
    }
}
