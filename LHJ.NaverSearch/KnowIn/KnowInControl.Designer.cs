namespace LHJ.NaverSearch
{
    partial class KnowInControl
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
            this.lblKnowInInfo1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBookDesc = new System.Windows.Forms.TextBox();
            this.lnklblKnowInTitle = new LHJ.NaverSearch.RichLabel();
            this.SuspendLayout();
            // 
            // lblKnowInInfo1
            // 
            this.lblKnowInInfo1.AutoSize = true;
            this.lblKnowInInfo1.Location = new System.Drawing.Point(7, 21);
            this.lblKnowInInfo1.Name = "lblKnowInInfo1";
            this.lblKnowInInfo1.Size = new System.Drawing.Size(29, 12);
            this.lblKnowInInfo1.TabIndex = 3;
            this.lblKnowInInfo1.Text = "정보";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 79);
            this.panel1.TabIndex = 8;
            // 
            // txtBookDesc
            // 
            this.txtBookDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookDesc.BackColor = System.Drawing.Color.White;
            this.txtBookDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookDesc.Enabled = false;
            this.txtBookDesc.Location = new System.Drawing.Point(9, 21);
            this.txtBookDesc.Multiline = true;
            this.txtBookDesc.Name = "txtBookDesc";
            this.txtBookDesc.ReadOnly = true;
            this.txtBookDesc.Size = new System.Drawing.Size(502, 52);
            this.txtBookDesc.TabIndex = 10;
            // 
            // lnklblKnowInTitle
            // 
            this.lnklblKnowInTitle.AutoSize = true;
            this.lnklblKnowInTitle.CustomAutoSize = false;
            this.lnklblKnowInTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnklblKnowInTitle.ForeColorAlt = System.Drawing.SystemColors.HighlightText;
            this.lnklblKnowInTitle.Location = new System.Drawing.Point(7, 4);
            this.lnklblKnowInTitle.Name = "lnklblKnowInTitle";
            this.lnklblKnowInTitle.Size = new System.Drawing.Size(29, 12);
            this.lnklblKnowInTitle.Splitters = new string[] {
        "{{",
        "}}"};
            this.lnklblKnowInTitle.TabIndex = 7;
            this.lnklblKnowInTitle.Text = "제목";
            this.lnklblKnowInTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnklblBookTitle_MouseClick);
            // 
            // KnowInControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtBookDesc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lnklblKnowInTitle);
            this.Controls.Add(this.lblKnowInInfo1);
            this.Name = "KnowInControl";
            this.Size = new System.Drawing.Size(527, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblKnowInInfo1;
        private RichLabel lnklblKnowInTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBookDesc;
    }
}
