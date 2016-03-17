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
            this.cboUserList = new System.Windows.Forms.ComboBox();
            this.cboObjectList = new System.Windows.Forms.ComboBox();
            this.lbxObject = new System.Windows.Forms.ListBox();
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
            // cboUserList
            // 
            this.cboUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUserList.DisplayMember = "USERNAME";
            this.cboUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserList.FormattingEnabled = true;
            this.cboUserList.Location = new System.Drawing.Point(3, 3);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(186, 20);
            this.cboUserList.TabIndex = 0;
            this.cboUserList.ValueMember = "USERNAME";
            this.cboUserList.SelectedIndexChanged += new System.EventHandler(this.cboUserList_SelectedIndexChanged);
            // 
            // cboObjectList
            // 
            this.cboObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboObjectList.DisplayMember = "USERNAME";
            this.cboObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectList.FormattingEnabled = true;
            this.cboObjectList.Location = new System.Drawing.Point(3, 29);
            this.cboObjectList.Name = "cboObjectList";
            this.cboObjectList.Size = new System.Drawing.Size(186, 20);
            this.cboObjectList.TabIndex = 1;
            this.cboObjectList.ValueMember = "USERNAME";
            this.cboObjectList.SelectedIndexChanged += new System.EventHandler(this.cboObjectList_SelectedIndexChanged);
            // 
            // lbxObject
            // 
            this.lbxObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxObject.FormattingEnabled = true;
            this.lbxObject.ItemHeight = 12;
            this.lbxObject.Location = new System.Drawing.Point(3, 55);
            this.lbxObject.Name = "lbxObject";
            this.lbxObject.Size = new System.Drawing.Size(186, 208);
            this.lbxObject.TabIndex = 2;
            // 
            // UserControl1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbxObject);
            this.Controls.Add(this.cboObjectList);
            this.Controls.Add(this.cboUserList);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(192, 277);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cboUserList;
        private System.Windows.Forms.ComboBox cboObjectList;
        private System.Windows.Forms.ListBox lbxObject;
    }
}
