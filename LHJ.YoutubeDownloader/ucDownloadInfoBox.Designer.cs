namespace LHJ.YoutubeDownloader
{
    partial class ucDownloadInfoBox
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
            this.cbxDownload = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.ucpgbDownload = new LHJ.Controls.ucProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxDownload
            // 
            this.cbxDownload.AutoSize = true;
            this.cbxDownload.Location = new System.Drawing.Point(12, 35);
            this.cbxDownload.Name = "cbxDownload";
            this.cbxDownload.Size = new System.Drawing.Size(15, 14);
            this.cbxDownload.TabIndex = 0;
            this.cbxDownload.UseVisualStyleBackColor = true;
            this.cbxDownload.CheckedChanged += new System.EventHandler(this.cbxDownload_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(139, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 12);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Test";
            // 
            // pbxPreview
            // 
            this.pbxPreview.Location = new System.Drawing.Point(33, 3);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(100, 78);
            this.pbxPreview.TabIndex = 1;
            this.pbxPreview.TabStop = false;
            // 
            // ucpgbDownload
            // 
            this.ucpgbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpgbDownload.Location = new System.Drawing.Point(141, 51);
            this.ucpgbDownload.Name = "ucpgbDownload";
            this.ucpgbDownload.ProgressBarText = "";
            this.ucpgbDownload.Size = new System.Drawing.Size(400, 23);
            this.ucpgbDownload.TabIndex = 4;
            this.ucpgbDownload.TextType = LHJ.Common.Definition.ConstValue.ProgressBarTextType.None;
            // 
            // ucDownloadInfoBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ucpgbDownload);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbxPreview);
            this.Controls.Add(this.cbxDownload);
            this.Name = "ucDownloadInfoBox";
            this.Size = new System.Drawing.Size(548, 84);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucDownloadInfo_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxDownload;
        private System.Windows.Forms.PictureBox pbxPreview;
        private System.Windows.Forms.Label lblTitle;
        private Controls.ucProgressBar ucpgbDownload;
    }
}
