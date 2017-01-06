namespace LHJ.NaverSearch.Movie
{
    partial class MovieSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxMovieTitle = new System.Windows.Forms.TextBox();
            this.pnlSearchRslt = new System.Windows.Forms.Panel();
            this.lblSearchRslt = new System.Windows.Forms.Label();
            this.lblSearchRsltIdx = new System.Windows.Forms.Label();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.flpSearchRslt = new System.Windows.Forms.FlowLayoutPanel();
            this.ucPaging = new LHJ.NaverSearch.ucPaging();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchRslt.SuspendLayout();
            this.pnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.tbxMovieTitle);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(784, 32);
            this.pnlSearch.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "영화 제목";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(700, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxMovieTitle
            // 
            this.tbxMovieTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMovieTitle.Location = new System.Drawing.Point(66, 5);
            this.tbxMovieTitle.Name = "tbxMovieTitle";
            this.tbxMovieTitle.Size = new System.Drawing.Size(628, 21);
            this.tbxMovieTitle.TabIndex = 1;
            this.tbxMovieTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMovieTitle_KeyDown);
            // 
            // pnlSearchRslt
            // 
            this.pnlSearchRslt.Controls.Add(this.lblSearchRslt);
            this.pnlSearchRslt.Controls.Add(this.lblSearchRsltIdx);
            this.pnlSearchRslt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchRslt.Location = new System.Drawing.Point(0, 32);
            this.pnlSearchRslt.Name = "pnlSearchRslt";
            this.pnlSearchRslt.Size = new System.Drawing.Size(784, 31);
            this.pnlSearchRslt.TabIndex = 8;
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
            // pnlPage
            // 
            this.pnlPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPage.Controls.Add(this.ucPaging);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPage.Location = new System.Drawing.Point(0, 537);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(784, 25);
            this.pnlPage.TabIndex = 9;
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
            this.flpSearchRslt.TabIndex = 10;
            this.flpSearchRslt.MouseEnter += new System.EventHandler(this.flpSearchRslt_MouseEnter);
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
            // MovieSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.flpSearchRslt);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.pnlSearchRslt);
            this.Controls.Add(this.pnlSearch);
            this.Name = "MovieSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "네이버 영화 검색";
            this.Shown += new System.EventHandler(this.MovieSearch_Shown);
            this.Resize += new System.EventHandler(this.MovieSearch_Resize);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlSearchRslt.ResumeLayout(false);
            this.pnlSearchRslt.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxMovieTitle;
        private System.Windows.Forms.Panel pnlSearchRslt;
        private System.Windows.Forms.Label lblSearchRslt;
        private System.Windows.Forms.Label lblSearchRsltIdx;
        private System.Windows.Forms.Panel pnlPage;
        private ucPaging ucPaging;
        private System.Windows.Forms.FlowLayoutPanel flpSearchRslt;
    }
}