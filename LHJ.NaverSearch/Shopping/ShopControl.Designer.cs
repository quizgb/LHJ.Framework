namespace LHJ.NaverSearch
{
    partial class ShopControl
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
            this.pbxShopImage = new System.Windows.Forms.PictureBox();
            this.pnlBookImage = new System.Windows.Forms.Panel();
            this.lblShopInfo1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnklblShopTitle = new LHJ.NaverSearch.RichLabel();
            this.lblShopInfo2 = new System.Windows.Forms.Label();
            this.lblShopInfo3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShopImage)).BeginInit();
            this.pnlBookImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxShopImage
            // 
            this.pbxShopImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxShopImage.Location = new System.Drawing.Point(0, 0);
            this.pbxShopImage.Name = "pbxShopImage";
            this.pbxShopImage.Size = new System.Drawing.Size(84, 102);
            this.pbxShopImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxShopImage.TabIndex = 0;
            this.pbxShopImage.TabStop = false;
            // 
            // pnlBookImage
            // 
            this.pnlBookImage.Controls.Add(this.pbxShopImage);
            this.pnlBookImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBookImage.Location = new System.Drawing.Point(0, 0);
            this.pnlBookImage.Name = "pnlBookImage";
            this.pnlBookImage.Size = new System.Drawing.Size(84, 102);
            this.pnlBookImage.TabIndex = 1;
            // 
            // lblShopInfo1
            // 
            this.lblShopInfo1.AutoSize = true;
            this.lblShopInfo1.Location = new System.Drawing.Point(92, 21);
            this.lblShopInfo1.Name = "lblShopInfo1";
            this.lblShopInfo1.Size = new System.Drawing.Size(29, 12);
            this.lblShopInfo1.TabIndex = 3;
            this.lblShopInfo1.Text = "금액";
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
            // lnklblShopTitle
            // 
            this.lnklblShopTitle.AutoSize = true;
            this.lnklblShopTitle.CustomAutoSize = false;
            this.lnklblShopTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnklblShopTitle.ForeColorAlt = System.Drawing.SystemColors.HighlightText;
            this.lnklblShopTitle.Location = new System.Drawing.Point(92, 4);
            this.lnklblShopTitle.Name = "lnklblShopTitle";
            this.lnklblShopTitle.Size = new System.Drawing.Size(29, 12);
            this.lnklblShopTitle.Splitters = new string[] {
        "{{",
        "}}"};
            this.lnklblShopTitle.TabIndex = 7;
            this.lnklblShopTitle.Text = "제목";
            this.lnklblShopTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnklblBookTitle_MouseClick);
            // 
            // lblShopInfo2
            // 
            this.lblShopInfo2.AutoSize = true;
            this.lblShopInfo2.Location = new System.Drawing.Point(92, 38);
            this.lblShopInfo2.Name = "lblShopInfo2";
            this.lblShopInfo2.Size = new System.Drawing.Size(41, 12);
            this.lblShopInfo2.TabIndex = 9;
            this.lblShopInfo2.Text = "판매처";
            // 
            // lblShopInfo3
            // 
            this.lblShopInfo3.AutoSize = true;
            this.lblShopInfo3.Location = new System.Drawing.Point(92, 57);
            this.lblShopInfo3.Name = "lblShopInfo3";
            this.lblShopInfo3.Size = new System.Drawing.Size(53, 12);
            this.lblShopInfo3.TabIndex = 10;
            this.lblShopInfo3.Text = "상품종류";
            // 
            // ShopControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblShopInfo3);
            this.Controls.Add(this.lblShopInfo2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lnklblShopTitle);
            this.Controls.Add(this.lblShopInfo1);
            this.Controls.Add(this.pnlBookImage);
            this.Name = "ShopControl";
            this.Size = new System.Drawing.Size(527, 102);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShopImage)).EndInit();
            this.pnlBookImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxShopImage;
        private System.Windows.Forms.Panel pnlBookImage;
        private System.Windows.Forms.Label lblShopInfo1;
        private RichLabel lnklblShopTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblShopInfo2;
        private System.Windows.Forms.Label lblShopInfo3;
    }
}
