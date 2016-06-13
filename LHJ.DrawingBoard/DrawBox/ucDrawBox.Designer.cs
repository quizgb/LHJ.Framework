namespace LHJ.DrawingBoard.DrawBox
{
    partial class ucDrawBox
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_ReSize = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ReSize)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_ReSize
            // 
            this.pictureBox_ReSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ReSize.Image = global::LHJ.DrawingBoard.Properties.Resources.Size;
            this.pictureBox_ReSize.Location = new System.Drawing.Point(201, 103);
            this.pictureBox_ReSize.Name = "pictureBox_ReSize";
            this.pictureBox_ReSize.Size = new System.Drawing.Size(17, 17);
            this.pictureBox_ReSize.TabIndex = 0;
            this.pictureBox_ReSize.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAllToolStripMenuItem,
            this.UnselectAllToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.DeleteAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.toolStripSeparator2,
            this.PropertiesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 170);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.SelectAllToolStripMenuItem.Text = "전체선택";
            // 
            // UnselectAllToolStripMenuItem
            // 
            this.UnselectAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem";
            this.UnselectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.UnselectAllToolStripMenuItem.Text = "전체해제";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.DeleteToolStripMenuItem.Text = "삭제하기";
            // 
            // DeleteAllToolStripMenuItem
            // 
            this.DeleteAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem";
            this.DeleteAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.DeleteAllToolStripMenuItem.Text = "전체 삭제하기";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Enabled = false;
            this.UndoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.UndoToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.실행취소;
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.UndoToolStripMenuItem.Text = "실행취소";
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Enabled = false;
            this.RedoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.RedoToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.다시실행;
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.RedoToolStripMenuItem.Text = "다시실행";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // PropertiesToolStripMenuItem
            // 
            this.PropertiesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem";
            this.PropertiesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.PropertiesToolStripMenuItem.Text = "속성 설정하기";
            // 
            // DrawBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox_ReSize);
            this.Name = "DrawBox";
            this.Size = new System.Drawing.Size(218, 120);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ReSize)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ReSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem;
    }
}
