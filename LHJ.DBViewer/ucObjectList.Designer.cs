namespace LHJ.DBViewer
{
    partial class ucObjectList
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboObjectList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboObjectList
            // 
            this.cboObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboObjectList.DisplayMember = "USERNAME";
            this.cboObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectList.FormattingEnabled = true;
            this.cboObjectList.Location = new System.Drawing.Point(3, 3);
            this.cboObjectList.Name = "cboObjectList";
            this.cboObjectList.Size = new System.Drawing.Size(194, 20);
            this.cboObjectList.TabIndex = 2;
            this.cboObjectList.ValueMember = "USERNAME";
            this.cboObjectList.SelectedIndexChanged += new System.EventHandler(this.cboObjectList_SelectedIndexChanged);
            // 
            // ucObjectList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cboObjectList);
            this.Name = "ucObjectList";
            this.Size = new System.Drawing.Size(200, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboObjectList;
    }
}
