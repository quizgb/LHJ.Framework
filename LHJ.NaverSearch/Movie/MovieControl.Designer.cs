namespace LHJ.NaverSearch
{
    partial class MovieControl
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
            this.pbxMvImage = new System.Windows.Forms.PictureBox();
            this.pnlBookImage = new System.Windows.Forms.Panel();
            this.lblMvInfo1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnklblMvTitle = new LHJ.NaverSearch.RichLabel();
            this.lblRating = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMvImage)).BeginInit();
            this.pnlBookImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxMvImage
            // 
            this.pbxMvImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMvImage.Location = new System.Drawing.Point(0, 0);
            this.pbxMvImage.Name = "pbxMvImage";
            this.pbxMvImage.Size = new System.Drawing.Size(84, 102);
            this.pbxMvImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMvImage.TabIndex = 0;
            this.pbxMvImage.TabStop = false;
            // 
            // pnlBookImage
            // 
            this.pnlBookImage.Controls.Add(this.pbxMvImage);
            this.pnlBookImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBookImage.Location = new System.Drawing.Point(0, 0);
            this.pnlBookImage.Name = "pnlBookImage";
            this.pnlBookImage.Size = new System.Drawing.Size(84, 102);
            this.pnlBookImage.TabIndex = 1;
            // 
            // lblMvInfo1
            // 
            this.lblMvInfo1.AutoSize = true;
            this.lblMvInfo1.Location = new System.Drawing.Point(92, 21);
            this.lblMvInfo1.Name = "lblMvInfo1";
            this.lblMvInfo1.Size = new System.Drawing.Size(165, 12);
            this.lblMvInfo1.TabIndex = 3;
            this.lblMvInfo1.Text = "author | publisher | pubdate";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(84, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 102);
            this.panel1.TabIndex = 8;
            // 
            // lnklblMvTitle
            // 
            this.lnklblMvTitle.AutoSize = true;
            this.lnklblMvTitle.CustomAutoSize = false;
            this.lnklblMvTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnklblMvTitle.ForeColorAlt = System.Drawing.SystemColors.HighlightText;
            this.lnklblMvTitle.Location = new System.Drawing.Point(92, 4);
            this.lnklblMvTitle.Name = "lnklblMvTitle";
            this.lnklblMvTitle.Size = new System.Drawing.Size(57, 12);
            this.lnklblMvTitle.Splitters = new string[] {
        "{{",
        "}}"};
            this.lnklblMvTitle.TabIndex = 7;
            this.lnklblMvTitle.Text = "영화 제목";
            this.lnklblMvTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnklblBookTitle_MouseClick);
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(92, 41);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(29, 12);
            this.lblRating.TabIndex = 9;
            this.lblRating.Text = "평점";
            // 
            // MovieControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lnklblMvTitle);
            this.Controls.Add(this.lblMvInfo1);
            this.Controls.Add(this.pnlBookImage);
            this.Name = "MovieControl";
            this.Size = new System.Drawing.Size(527, 102);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMvImage)).EndInit();
            this.pnlBookImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxMvImage;
        private System.Windows.Forms.Panel pnlBookImage;
        private System.Windows.Forms.Label lblMvInfo1;
        private RichLabel lnklblMvTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRating;
    }
}
