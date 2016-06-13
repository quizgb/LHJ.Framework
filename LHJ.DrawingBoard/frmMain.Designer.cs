namespace LHJ.DrawingBoard
{
    partial class frmMain
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Draw = new System.Windows.Forms.Panel();
            this.userControl_ToolBar1 = new LHJ.DrawingBoard.ToolBar.ucToolBar();
            this.userControl_DrawBox1 = new LHJ.DrawingBoard.DrawBox.ucDrawBox();
            this.menuStrip1.SuspendLayout();
            this.panel_Draw.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "DTF 파일 (*.DTF)|*.DTF";
            this.openFileDialog1.Title = "DTF 파일 불러오기";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "DTF 파일 (*.DTF)|*.DTF";
            this.saveFileDialog1.Title = "DTF 파일 저장하기";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(192, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "파일";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.newToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.새로_만들기;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "새로 만들기";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.openToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.불러오기;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "불러오기";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.saveToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.저장하기;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "저장하기";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "종료";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAllToolStripMenuItem,
            this.UnselectAllToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.DeleteAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.toolStripSeparator3,
            this.PropertiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.editToolStripMenuItem.Text = "편집";
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.SelectAllToolStripMenuItem.Text = "전체 선택";
            // 
            // UnselectAllToolStripMenuItem
            // 
            this.UnselectAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.UnselectAllToolStripMenuItem.Name = "UnselectAllToolStripMenuItem";
            this.UnselectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.UnselectAllToolStripMenuItem.Text = "전체 해제";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.DeleteToolStripMenuItem.Text = "삭제하기";
            // 
            // DeleteAllToolStripMenuItem
            // 
            this.DeleteAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem";
            this.DeleteAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.DeleteAllToolStripMenuItem.Text = "전체 삭제";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.UndoToolStripMenuItem.Enabled = false;
            this.UndoToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.실행취소;
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.UndoToolStripMenuItem.Text = "실행 취소";
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.RedoToolStripMenuItem.Enabled = false;
            this.RedoToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.다시실행;
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.RedoToolStripMenuItem.Text = "다시 실행";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // PropertiesToolStripMenuItem
            // 
            this.PropertiesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem";
            this.PropertiesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.PropertiesToolStripMenuItem.Text = "속성 설정하기";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.pencilToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.drawToolStripMenuItem.Text = "도구";
            // 
            // pointerToolStripMenuItem
            // 
            this.pointerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.pointerToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.선택;
            this.pointerToolStripMenuItem.Name = "pointerToolStripMenuItem";
            this.pointerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pointerToolStripMenuItem.Text = "선택하기";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.rectangleToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.사각형;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rectangleToolStripMenuItem.Text = "사각형";
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ellipseToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.원;
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ellipseToolStripMenuItem.Text = "원";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lineToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.선_그리기;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lineToolStripMenuItem.Text = "선";
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.pencilToolStripMenuItem.Image = global::LHJ.DrawingBoard.Properties.Resources.연필;
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pencilToolStripMenuItem.Text = "연필";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.helpToolStripMenuItem.Text = "도움말";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "확인";
            // 
            // panel_Draw
            // 
            this.panel_Draw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Draw.AutoScroll = true;
            this.panel_Draw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.panel_Draw.Controls.Add(this.userControl_DrawBox1);
            this.panel_Draw.Location = new System.Drawing.Point(0, 51);
            this.panel_Draw.Name = "panel_Draw";
            this.panel_Draw.Size = new System.Drawing.Size(642, 358);
            this.panel_Draw.TabIndex = 1;
            // 
            // userControl_ToolBar1
            // 
            this.userControl_ToolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userControl_ToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.userControl_ToolBar1.Location = new System.Drawing.Point(0, 24);
            this.userControl_ToolBar1.Margin = new System.Windows.Forms.Padding(0);
            this.userControl_ToolBar1.Name = "userControl_ToolBar1";
            this.userControl_ToolBar1.Size = new System.Drawing.Size(647, 29);
            this.userControl_ToolBar1.TabIndex = 0;
            // 
            // userControl_DrawBox1
            // 
            this.userControl_DrawBox1.BackColor = System.Drawing.Color.White;
            this.userControl_DrawBox1.Location = new System.Drawing.Point(0, 0);
            this.userControl_DrawBox1.Name = "userControl_DrawBox1";
            this.userControl_DrawBox1.Size = new System.Drawing.Size(619, 334);
            this.userControl_DrawBox1.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(642, 409);
            this.Controls.Add(this.userControl_ToolBar1);
            this.Controls.Add(this.panel_Draw);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DrawTool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_Draw.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Draw;
        private LHJ.DrawingBoard.DrawBox.ucDrawBox userControl_DrawBox1;
        private LHJ.DrawingBoard.ToolBar.ucToolBar userControl_ToolBar1;
    }
}

