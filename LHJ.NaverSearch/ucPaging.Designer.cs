namespace LHJ.NaverSearch
{
    partial class ucPaging
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
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.flpPage = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHome.Enabled = false;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(29, 19);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "<<";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(29, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 19);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(58, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 19);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(87, 0);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(30, 19);
            this.btnEnd.TabIndex = 4;
            this.btnEnd.Text = ">>";
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // flpPage
            // 
            this.flpPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPage.Location = new System.Drawing.Point(58, 0);
            this.flpPage.Name = "flpPage";
            this.flpPage.Size = new System.Drawing.Size(0, 19);
            this.flpPage.TabIndex = 5;
            // 
            // ucPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpPage);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnHome);
            this.Name = "ucPaging";
            this.Size = new System.Drawing.Size(117, 19);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.FlowLayoutPanel flpPage;
    }
}
