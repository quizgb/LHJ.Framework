namespace LHJ.DBViewer
{
    partial class frmSessionView
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tbxSecond = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1264, 986);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.cbxAutoRefresh);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.tbxSecond);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1264, 35);
            this.pnlTop.TabIndex = 1;
            // 
            // tbxSecond
            // 
            this.tbxSecond.Location = new System.Drawing.Point(12, 8);
            this.tbxSecond.MaxLength = 3;
            this.tbxSecond.Name = "tbxSecond";
            this.tbxSecond.Size = new System.Drawing.Size(51, 21);
            this.tbxSecond.TabIndex = 9;
            this.tbxSecond.Tag = "";
            this.tbxSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "초";
            // 
            // cbxAutoRefresh
            // 
            this.cbxAutoRefresh.AutoSize = true;
            this.cbxAutoRefresh.Location = new System.Drawing.Point(100, 10);
            this.cbxAutoRefresh.Name = "cbxAutoRefresh";
            this.cbxAutoRefresh.Size = new System.Drawing.Size(72, 16);
            this.cbxAutoRefresh.TabIndex = 11;
            this.cbxAutoRefresh.Text = "자동갱신";
            this.cbxAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // frmSessionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 986);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmSessionView";
            this.Text = "Session 조회";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.CheckBox cbxAutoRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSecond;
    }
}