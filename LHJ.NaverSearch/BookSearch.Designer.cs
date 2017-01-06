namespace LHJ.NaverSearch
{
    partial class BookSearch
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxBookTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearchRslt = new System.Windows.Forms.Label();
            this.lblSearchRsltIdx = new System.Windows.Forms.Label();
            this.flpSearchRslt = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchRslt = new System.Windows.Forms.Panel();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.ucPaging = new LHJ.NaverSearch.ucPaging();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchRslt.SuspendLayout();
            this.pnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(697, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxBookTitle
            // 
            this.tbxBookTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxBookTitle.Location = new System.Drawing.Point(63, 5);
            this.tbxBookTitle.Name = "tbxBookTitle";
            this.tbxBookTitle.Size = new System.Drawing.Size(628, 21);
            this.tbxBookTitle.TabIndex = 1;
            this.tbxBookTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxBookTitle_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "책 제목";
            // 
            // lblSearchRslt
            // 
            this.lblSearchRslt.AutoSize = true;
            this.lblSearchRslt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSearchRslt.Location = new System.Drawing.Point(14, 1);
            this.lblSearchRslt.Name = "lblSearchRslt";
            this.lblSearchRslt.Size = new System.Drawing.Size(74, 21);
            this.lblSearchRslt.TabIndex = 3;
            this.lblSearchRslt.Text = "검색결과";
            this.lblSearchRslt.Visible = false;
            // 
            // lblSearchRsltIdx
            // 
            this.lblSearchRsltIdx.AutoSize = true;
            this.lblSearchRsltIdx.Location = new System.Drawing.Point(87, 10);
            this.lblSearchRsltIdx.Name = "lblSearchRsltIdx";
            this.lblSearchRsltIdx.Size = new System.Drawing.Size(87, 12);
            this.lblSearchRsltIdx.TabIndex = 4;
            this.lblSearchRsltIdx.Text = "(1-10 / 419 건)";
            this.lblSearchRsltIdx.Visible = false;
            // 
            // flpSearchRslt
            // 
            this.flpSearchRslt.AutoScroll = true;
            this.flpSearchRslt.BackColor = System.Drawing.Color.White;
            this.flpSearchRslt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSearchRslt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSearchRslt.Location = new System.Drawing.Point(0, 63);
            this.flpSearchRslt.Name = "flpSearchRslt";
            this.flpSearchRslt.Size = new System.Drawing.Size(784, 474);
            this.flpSearchRslt.TabIndex = 5;
            this.flpSearchRslt.MouseEnter += new System.EventHandler(this.flpSearchRslt_MouseEnter);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.tbxBookTitle);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(784, 32);
            this.pnlSearch.TabIndex = 6;
            // 
            // pnlSearchRslt
            // 
            this.pnlSearchRslt.Controls.Add(this.lblSearchRslt);
            this.pnlSearchRslt.Controls.Add(this.lblSearchRsltIdx);
            this.pnlSearchRslt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchRslt.Location = new System.Drawing.Point(0, 32);
            this.pnlSearchRslt.Name = "pnlSearchRslt";
            this.pnlSearchRslt.Size = new System.Drawing.Size(784, 31);
            this.pnlSearchRslt.TabIndex = 7;
            // 
            // pnlPage
            // 
            this.pnlPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPage.Controls.Add(this.ucPaging);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPage.Location = new System.Drawing.Point(0, 537);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(784, 25);
            this.pnlPage.TabIndex = 8;
            // 
            // ucPaging
            // 
            this.ucPaging.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucPaging.Location = new System.Drawing.Point(0, 0);
            this.ucPaging.Name = "ucPaging";
            this.ucPaging.Size = new System.Drawing.Size(117, 23);
            this.ucPaging.TabIndex = 5;
            this.ucPaging.TotalItmCount = 0;
            this.ucPaging.Visible = false;
            this.ucPaging.PageChanged += new LHJ.NaverSearch.ucPaging.PageChangedEventHandler(this.ucPaging_PageChanged);
            // 
            // BookSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.flpSearchRslt);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.pnlSearchRslt);
            this.Controls.Add(this.pnlSearch);
            this.Name = "BookSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "네이버 책 검색";
            this.Shown += new System.EventHandler(this.BookSearch_Shown);
            this.Resize += new System.EventHandler(this.BookSearch_Resize);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlSearchRslt.ResumeLayout(false);
            this.pnlSearchRslt.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxBookTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSearchRslt;
        private System.Windows.Forms.Label lblSearchRsltIdx;
        private System.Windows.Forms.FlowLayoutPanel flpSearchRslt;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchRslt;
        private ucPaging ucPaging;
        private System.Windows.Forms.Panel pnlPage;
    }
}

