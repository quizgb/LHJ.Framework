﻿namespace LHJ.DBViewer
{
    partial class ucQuery
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
            this.dgvQueryResult = new LHJ.Controls.ucDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSqlArea = new LHJ.DBViewer.clsRichDDLBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslQueryResultDelay = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQueryResult
            // 
            this.dgvQueryResult.AllowUserToAddRows = false;
            this.dgvQueryResult.AllowUserToDeleteRows = false;
            this.dgvQueryResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueryResult.Location = new System.Drawing.Point(0, 0);
            this.dgvQueryResult.Name = "dgvQueryResult";
            this.dgvQueryResult.ReadOnly = true;
            this.dgvQueryResult.RowTemplate.Height = 23;
            this.dgvQueryResult.ShowRowHeaderValue = true;
            this.dgvQueryResult.Size = new System.Drawing.Size(818, 180);
            this.dgvQueryResult.TabIndex = 1;
            this.dgvQueryResult.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueryResult_RowEnter);
            this.dgvQueryResult.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvQueryResult_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSqlArea);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvQueryResult);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(818, 531);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtSqlArea
            // 
            this.txtSqlArea.AcceptsTab = true;
            this.txtSqlArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlArea.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSqlArea.ForeColor = System.Drawing.Color.Black;
            this.txtSqlArea.Location = new System.Drawing.Point(0, 0);
            this.txtSqlArea.Name = "txtSqlArea";
            this.txtSqlArea.Size = new System.Drawing.Size(818, 319);
            this.txtSqlArea.TabIndex = 0;
            this.txtSqlArea.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslRowCount,
            this.tsslQueryResultDelay});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 180);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(818, 28);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslRowCount
            // 
            this.tsslRowCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslRowCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslRowCount.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.tsslRowCount.Name = "tsslRowCount";
            this.tsslRowCount.Size = new System.Drawing.Size(86, 23);
            this.tsslRowCount.Text = "(RowCount)";
            // 
            // tsslQueryResultDelay
            // 
            this.tsslQueryResultDelay.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslQueryResultDelay.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslQueryResultDelay.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.tsslQueryResultDelay.Name = "tsslQueryResultDelay";
            this.tsslQueryResultDelay.Size = new System.Drawing.Size(134, 23);
            this.tsslQueryResultDelay.Text = "(QueryResultDelay)";
            // 
            // ucQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucQuery";
            this.Size = new System.Drawing.Size(818, 531);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private clsRichDDLBox txtSqlArea;
        private Controls.ucDataGridView dgvQueryResult;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslRowCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslQueryResultDelay;
        private clsRichDDLBox clsRichDDLBox1;
    }
}
