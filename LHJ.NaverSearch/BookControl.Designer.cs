namespace LHJ.NaverSearch
{
    partial class BookControl
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
            this.pbxBookImage = new System.Windows.Forms.PictureBox();
            this.pnlBookImage = new System.Windows.Forms.Panel();
            this.lblBookInfo1 = new System.Windows.Forms.Label();
            this.lblBookPrice = new System.Windows.Forms.Label();
            this.lblBookDesc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBookDesc = new System.Windows.Forms.TextBox();
            this.lnklblBookTitle = new LHJ.NaverSearch.RichLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookImage)).BeginInit();
            this.pnlBookImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxBookImage
            // 
            this.pbxBookImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxBookImage.Location = new System.Drawing.Point(0, 0);
            this.pbxBookImage.Name = "pbxBookImage";
            this.pbxBookImage.Size = new System.Drawing.Size(84, 102);
            this.pbxBookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBookImage.TabIndex = 0;
            this.pbxBookImage.TabStop = false;
            // 
            // pnlBookImage
            // 
            this.pnlBookImage.Controls.Add(this.pbxBookImage);
            this.pnlBookImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBookImage.Location = new System.Drawing.Point(0, 0);
            this.pnlBookImage.Name = "pnlBookImage";
            this.pnlBookImage.Size = new System.Drawing.Size(84, 102);
            this.pnlBookImage.TabIndex = 1;
            // 
            // lblBookInfo1
            // 
            this.lblBookInfo1.AutoSize = true;
            this.lblBookInfo1.Location = new System.Drawing.Point(92, 21);
            this.lblBookInfo1.Name = "lblBookInfo1";
            this.lblBookInfo1.Size = new System.Drawing.Size(165, 12);
            this.lblBookInfo1.TabIndex = 3;
            this.lblBookInfo1.Text = "author | publisher | pubdate";
            // 
            // lblBookPrice
            // 
            this.lblBookPrice.AutoSize = true;
            this.lblBookPrice.Location = new System.Drawing.Point(92, 37);
            this.lblBookPrice.Name = "lblBookPrice";
            this.lblBookPrice.Size = new System.Drawing.Size(29, 12);
            this.lblBookPrice.TabIndex = 4;
            this.lblBookPrice.Text = "금액";
            // 
            // lblBookDesc
            // 
            this.lblBookDesc.AutoSize = true;
            this.lblBookDesc.Location = new System.Drawing.Point(92, 58);
            this.lblBookDesc.Name = "lblBookDesc";
            this.lblBookDesc.Size = new System.Drawing.Size(29, 12);
            this.lblBookDesc.TabIndex = 5;
            this.lblBookDesc.Text = "소개";
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
            // txtBookDesc
            // 
            this.txtBookDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookDesc.BackColor = System.Drawing.Color.White;
            this.txtBookDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookDesc.Enabled = false;
            this.txtBookDesc.Location = new System.Drawing.Point(94, 55);
            this.txtBookDesc.Multiline = true;
            this.txtBookDesc.Name = "txtBookDesc";
            this.txtBookDesc.ReadOnly = true;
            this.txtBookDesc.Size = new System.Drawing.Size(419, 44);
            this.txtBookDesc.TabIndex = 9;
            // 
            // lnklblBookTitle
            // 
            this.lnklblBookTitle.AutoSize = true;
            this.lnklblBookTitle.CustomAutoSize = false;
            this.lnklblBookTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnklblBookTitle.ForeColorAlt = System.Drawing.SystemColors.HighlightText;
            this.lnklblBookTitle.Location = new System.Drawing.Point(92, 4);
            this.lnklblBookTitle.Name = "lnklblBookTitle";
            this.lnklblBookTitle.Size = new System.Drawing.Size(45, 12);
            this.lnklblBookTitle.Splitters = new string[] {
        "{{",
        "}}"};
            this.lnklblBookTitle.TabIndex = 7;
            this.lnklblBookTitle.Text = "책 제목";
            this.lnklblBookTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnklblBookTitle_MouseClick);
            // 
            // BookControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtBookDesc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lnklblBookTitle);
            this.Controls.Add(this.lblBookDesc);
            this.Controls.Add(this.lblBookPrice);
            this.Controls.Add(this.lblBookInfo1);
            this.Controls.Add(this.pnlBookImage);
            this.Name = "BookControl";
            this.Size = new System.Drawing.Size(527, 102);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookImage)).EndInit();
            this.pnlBookImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBookImage;
        private System.Windows.Forms.Panel pnlBookImage;
        private System.Windows.Forms.Label lblBookInfo1;
        private System.Windows.Forms.Label lblBookPrice;
        private System.Windows.Forms.Label lblBookDesc;
        private RichLabel lnklblBookTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBookDesc;
    }
}
