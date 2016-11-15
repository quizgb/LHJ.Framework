namespace LHJ.TextCompare.UsrControl
{
    partial class ucCompareSelect
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
            this.btnFile = new System.Windows.Forms.Button();
            this.btnClipBoard = new System.Windows.Forms.Button();
            this.rbtnFile = new System.Windows.Forms.RadioButton();
            this.rbtnClipBoard = new System.Windows.Forms.RadioButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtClipBoard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFile.Location = new System.Drawing.Point(523, 1);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(35, 23);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnClipBoard_Click);
            // 
            // btnClipBoard
            // 
            this.btnClipBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClipBoard.Location = new System.Drawing.Point(523, 32);
            this.btnClipBoard.Name = "btnClipBoard";
            this.btnClipBoard.Size = new System.Drawing.Size(35, 50);
            this.btnClipBoard.TabIndex = 1;
            this.btnClipBoard.Text = "Get";
            this.btnClipBoard.UseVisualStyleBackColor = true;
            this.btnClipBoard.Click += new System.EventHandler(this.btnClipBoard_Click);
            // 
            // rbtnFile
            // 
            this.rbtnFile.AutoSize = true;
            this.rbtnFile.Location = new System.Drawing.Point(14, 4);
            this.rbtnFile.Name = "rbtnFile";
            this.rbtnFile.Size = new System.Drawing.Size(43, 16);
            this.rbtnFile.TabIndex = 2;
            this.rbtnFile.TabStop = true;
            this.rbtnFile.Text = "File";
            this.rbtnFile.UseVisualStyleBackColor = true;
            // 
            // rbtnClipBoard
            // 
            this.rbtnClipBoard.AutoSize = true;
            this.rbtnClipBoard.Location = new System.Drawing.Point(14, 35);
            this.rbtnClipBoard.Name = "rbtnClipBoard";
            this.rbtnClipBoard.Size = new System.Drawing.Size(78, 16);
            this.rbtnClipBoard.TabIndex = 3;
            this.rbtnClipBoard.TabStop = true;
            this.rbtnClipBoard.Text = "ClipBoard";
            this.rbtnClipBoard.UseVisualStyleBackColor = true;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(95, 2);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(422, 21);
            this.txtFile.TabIndex = 4;
            // 
            // txtClipBoard
            // 
            this.txtClipBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClipBoard.Location = new System.Drawing.Point(95, 33);
            this.txtClipBoard.Multiline = true;
            this.txtClipBoard.Name = "txtClipBoard";
            this.txtClipBoard.ReadOnly = true;
            this.txtClipBoard.Size = new System.Drawing.Size(422, 49);
            this.txtClipBoard.TabIndex = 5;
            // 
            // ucCompareSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtClipBoard);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.rbtnClipBoard);
            this.Controls.Add(this.rbtnFile);
            this.Controls.Add(this.btnClipBoard);
            this.Controls.Add(this.btnFile);
            this.Name = "ucCompareSelect";
            this.Size = new System.Drawing.Size(569, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnClipBoard;
        private System.Windows.Forms.RadioButton rbtnFile;
        private System.Windows.Forms.RadioButton rbtnClipBoard;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtClipBoard;
    }
}
