using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LHJ.TextCompare.UsrControl;

namespace LHJ.TextCompare
{
    partial class frmTextCompare
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
            this.gbxDest = new System.Windows.Forms.GroupBox();
            this.rbtnFast = new System.Windows.Forms.RadioButton();
            this.rbtnMedium = new System.Windows.Forms.RadioButton();
            this.rbtnSlow = new System.Windows.Forms.RadioButton();
            this.btnCompare = new System.Windows.Forms.Button();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.pnlNavigator = new System.Windows.Forms.Panel();
            this.pbxNavigator = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbxSource = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLblSource = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDest = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsLblDest = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbxTop = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisible = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCompareInfo = new System.Windows.Forms.Panel();
            this.lbxChangedLine = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvDestination = new LHJ.TextCompare.UsrControl.ExScrollListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucCompareSelectDestination = new LHJ.TextCompare.UsrControl.ucCompareSelect();
            this.exSplitter1 = new LHJ.TextCompare.UsrControl.ExSplitter();
            this.lvSource = new LHJ.TextCompare.UsrControl.ExScrollListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucCompareSelectSource = new LHJ.TextCompare.UsrControl.ucCompareSelect();
            this.gbxDest.SuspendLayout();
            this.pnlSource.SuspendLayout();
            this.pnlNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNavigator)).BeginInit();
            this.gbxSource.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlDest.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.gbxTop.SuspendLayout();
            this.pnlCompareInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDest
            // 
            this.gbxDest.BackColor = System.Drawing.Color.White;
            this.gbxDest.Controls.Add(this.ucCompareSelectDestination);
            this.gbxDest.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDest.Location = new System.Drawing.Point(0, 22);
            this.gbxDest.Name = "gbxDest";
            this.gbxDest.Size = new System.Drawing.Size(602, 108);
            this.gbxDest.TabIndex = 25;
            this.gbxDest.TabStop = false;
            this.gbxDest.Text = " [대상 텍스트] ";
            // 
            // rbtnFast
            // 
            this.rbtnFast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnFast.AutoSize = true;
            this.rbtnFast.Checked = true;
            this.rbtnFast.Location = new System.Drawing.Point(685, 18);
            this.rbtnFast.Name = "rbtnFast";
            this.rbtnFast.Size = new System.Drawing.Size(47, 16);
            this.rbtnFast.TabIndex = 36;
            this.rbtnFast.TabStop = true;
            this.rbtnFast.Text = "Fast";
            this.rbtnFast.UseVisualStyleBackColor = true;
            // 
            // rbtnMedium
            // 
            this.rbtnMedium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnMedium.AutoSize = true;
            this.rbtnMedium.Location = new System.Drawing.Point(732, 18);
            this.rbtnMedium.Name = "rbtnMedium";
            this.rbtnMedium.Size = new System.Drawing.Size(69, 16);
            this.rbtnMedium.TabIndex = 35;
            this.rbtnMedium.Text = "Medium";
            this.rbtnMedium.UseVisualStyleBackColor = true;
            // 
            // rbtnSlow
            // 
            this.rbtnSlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSlow.AutoSize = true;
            this.rbtnSlow.Location = new System.Drawing.Point(801, 18);
            this.rbtnSlow.Name = "rbtnSlow";
            this.rbtnSlow.Size = new System.Drawing.Size(51, 16);
            this.rbtnSlow.TabIndex = 34;
            this.rbtnSlow.Text = "Slow";
            this.rbtnSlow.UseVisualStyleBackColor = true;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompare.Location = new System.Drawing.Point(852, 15);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(84, 23);
            this.btnCompare.TabIndex = 33;
            this.btnCompare.Text = "   비교 시작";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.lvSource);
            this.pnlSource.Controls.Add(this.pnlNavigator);
            this.pnlSource.Controls.Add(this.gbxSource);
            this.pnlSource.Controls.Add(this.statusStrip1);
            this.pnlSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSource.Location = new System.Drawing.Point(0, 41);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(580, 625);
            this.pnlSource.TabIndex = 31;
            // 
            // pnlNavigator
            // 
            this.pnlNavigator.BackColor = System.Drawing.Color.White;
            this.pnlNavigator.Controls.Add(this.pbxNavigator);
            this.pnlNavigator.Controls.Add(this.panel2);
            this.pnlNavigator.Controls.Add(this.panel3);
            this.pnlNavigator.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavigator.Location = new System.Drawing.Point(558, 130);
            this.pnlNavigator.Name = "pnlNavigator";
            this.pnlNavigator.Size = new System.Drawing.Size(22, 495);
            this.pnlNavigator.TabIndex = 37;
            // 
            // pbxNavigator
            // 
            this.pbxNavigator.BackColor = System.Drawing.Color.White;
            this.pbxNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxNavigator.Location = new System.Drawing.Point(0, 6);
            this.pbxNavigator.Name = "pbxNavigator";
            this.pbxNavigator.Size = new System.Drawing.Size(22, 483);
            this.pbxNavigator.TabIndex = 36;
            this.pbxNavigator.TabStop = false;
            this.pbxNavigator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxNavigator_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 6);
            this.panel2.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(22, 6);
            this.panel3.TabIndex = 38;
            // 
            // gbxSource
            // 
            this.gbxSource.BackColor = System.Drawing.Color.White;
            this.gbxSource.Controls.Add(this.ucCompareSelectSource);
            this.gbxSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSource.Location = new System.Drawing.Point(0, 22);
            this.gbxSource.Name = "gbxSource";
            this.gbxSource.Size = new System.Drawing.Size(580, 108);
            this.gbxSource.TabIndex = 29;
            this.gbxSource.TabStop = false;
            this.gbxSource.Text = " [원본 텍스트] ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblSource});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLblSource
            // 
            this.tsLblSource.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsLblSource.Name = "tsLblSource";
            this.tsLblSource.Size = new System.Drawing.Size(132, 17);
            this.tsLblSource.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(137, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Modify";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(222, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Add";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Pink;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(52, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "Delete";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDest
            // 
            this.pnlDest.Controls.Add(this.lvDestination);
            this.pnlDest.Controls.Add(this.gbxDest);
            this.pnlDest.Controls.Add(this.statusStrip2);
            this.pnlDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDest.Location = new System.Drawing.Point(582, 41);
            this.pnlDest.Name = "pnlDest";
            this.pnlDest.Size = new System.Drawing.Size(602, 625);
            this.pnlDest.TabIndex = 32;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblDest});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(602, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 39;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsLblDest
            // 
            this.tsLblDest.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsLblDest.Name = "tsLblDest";
            this.tsLblDest.Size = new System.Drawing.Size(132, 17);
            this.tsLblDest.Text = "toolStripStatusLabel2";
            // 
            // gbxTop
            // 
            this.gbxTop.BackColor = System.Drawing.SystemColors.Control;
            this.gbxTop.Controls.Add(this.btnClose);
            this.gbxTop.Controls.Add(this.btnVisible);
            this.gbxTop.Controls.Add(this.label4);
            this.gbxTop.Controls.Add(this.rbtnFast);
            this.gbxTop.Controls.Add(this.label3);
            this.gbxTop.Controls.Add(this.rbtnMedium);
            this.gbxTop.Controls.Add(this.label2);
            this.gbxTop.Controls.Add(this.rbtnSlow);
            this.gbxTop.Controls.Add(this.label1);
            this.gbxTop.Controls.Add(this.btnCompare);
            this.gbxTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxTop.Location = new System.Drawing.Point(0, 0);
            this.gbxTop.Name = "gbxTop";
            this.gbxTop.Size = new System.Drawing.Size(1184, 41);
            this.gbxTop.TabIndex = 33;
            this.gbxTop.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1102, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "종 료";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnVisible
            // 
            this.btnVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisible.Location = new System.Drawing.Point(936, 15);
            this.btnVisible.Name = "btnVisible";
            this.btnVisible.Size = new System.Drawing.Size(166, 23);
            this.btnVisible.TabIndex = 39;
            this.btnVisible.Text = "비교 대상 설정(보임/숨김)";
            this.btnVisible.UseVisualStyleBackColor = true;
            this.btnVisible.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "※ 범례";
            // 
            // pnlCompareInfo
            // 
            this.pnlCompareInfo.Controls.Add(this.groupBox1);
            this.pnlCompareInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCompareInfo.Location = new System.Drawing.Point(0, 666);
            this.pnlCompareInfo.Name = "pnlCompareInfo";
            this.pnlCompareInfo.Size = new System.Drawing.Size(1184, 96);
            this.pnlCompareInfo.TabIndex = 34;
            this.pnlCompareInfo.Visible = false;
            // 
            // lbxChangedLine
            // 
            this.lbxChangedLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxChangedLine.FormattingEnabled = true;
            this.lbxChangedLine.ItemHeight = 12;
            this.lbxChangedLine.Location = new System.Drawing.Point(3, 17);
            this.lbxChangedLine.Name = "lbxChangedLine";
            this.lbxChangedLine.ScrollAlwaysVisible = true;
            this.lbxChangedLine.Size = new System.Drawing.Size(136, 76);
            this.lbxChangedLine.TabIndex = 0;
            this.lbxChangedLine.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxChangedLine);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Changed Line";
            // 
            // lvDestination
            // 
            this.lvDestination.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDestination.FullRowSelect = true;
            this.lvDestination.HideSelection = false;
            this.lvDestination.Location = new System.Drawing.Point(0, 130);
            this.lvDestination.Name = "lvDestination";
            this.lvDestination.Size = new System.Drawing.Size(602, 495);
            this.lvDestination.TabIndex = 29;
            this.lvDestination.UseCompatibleStateImageBehavior = false;
            this.lvDestination.View = System.Windows.Forms.View.Details;
            this.lvDestination.VScroll += new System.Windows.Forms.ScrollEventHandler(this.lvDestination_VScroll);
            this.lvDestination.SelectedIndexChanged += new System.EventHandler(this.lvDestination_SelectedIndexChanged);
            this.lvDestination.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvDestination_KeyUp);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Line";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Text (Destination)";
            this.columnHeader4.Width = 558;
            // 
            // ucCompareSelectDestination
            // 
            this.ucCompareSelectDestination.BackColor = System.Drawing.Color.White;
            this.ucCompareSelectDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCompareSelectDestination.Location = new System.Drawing.Point(3, 17);
            this.ucCompareSelectDestination.Name = "ucCompareSelectDestination";
            this.ucCompareSelectDestination.Size = new System.Drawing.Size(596, 88);
            this.ucCompareSelectDestination.TabIndex = 1;
            // 
            // exSplitter1
            // 
            this.exSplitter1.BackColor = System.Drawing.Color.LightBlue;
            this.exSplitter1.Location = new System.Drawing.Point(580, 41);
            this.exSplitter1.Name = "exSplitter1";
            this.exSplitter1.Size = new System.Drawing.Size(2, 625);
            this.exSplitter1.TabIndex = 27;
            this.exSplitter1.TabStop = false;
            // 
            // lvSource
            // 
            this.lvSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSource.FullRowSelect = true;
            this.lvSource.HideSelection = false;
            this.lvSource.Location = new System.Drawing.Point(0, 130);
            this.lvSource.Name = "lvSource";
            this.lvSource.Size = new System.Drawing.Size(558, 495);
            this.lvSource.TabIndex = 28;
            this.lvSource.UseCompatibleStateImageBehavior = false;
            this.lvSource.View = System.Windows.Forms.View.Details;
            this.lvSource.VScroll += new System.Windows.Forms.ScrollEventHandler(this.lvSource_VScroll);
            this.lvSource.SelectedIndexChanged += new System.EventHandler(this.lvSource_SelectedIndexChanged);
            this.lvSource.SizeChanged += new System.EventHandler(this.lvSource_SizeChanged);
            this.lvSource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvSource_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Line";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Text (Source)";
            this.columnHeader2.Width = 514;
            // 
            // ucCompareSelectSource
            // 
            this.ucCompareSelectSource.BackColor = System.Drawing.Color.White;
            this.ucCompareSelectSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCompareSelectSource.Location = new System.Drawing.Point(3, 17);
            this.ucCompareSelectSource.Name = "ucCompareSelectSource";
            this.ucCompareSelectSource.Size = new System.Drawing.Size(574, 88);
            this.ucCompareSelectSource.TabIndex = 0;
            // 
            // frmTextCompare
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.pnlDest);
            this.Controls.Add(this.exSplitter1);
            this.Controls.Add(this.pnlSource);
            this.Controls.Add(this.pnlCompareInfo);
            this.Controls.Add(this.gbxTop);
            this.Name = "frmTextCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Compare";
            this.gbxDest.ResumeLayout(false);
            this.pnlSource.ResumeLayout(false);
            this.pnlSource.PerformLayout();
            this.pnlNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxNavigator)).EndInit();
            this.gbxSource.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlDest.ResumeLayout(false);
            this.pnlDest.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.gbxTop.ResumeLayout(false);
            this.gbxTop.PerformLayout();
            this.pnlCompareInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private GroupBox gbxDest;
        private ExSplitter exSplitter1;
        private ExScrollListView lvDestination;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ExScrollListView lvSource;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Panel pnlSource;
        private Panel pnlDest;
        private Button btnCompare;
        private RadioButton rbtnFast;
        private RadioButton rbtnMedium;
        private RadioButton rbtnSlow;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pbxNavigator;
        private Panel pnlNavigator;
        private Panel panel3;
        private Panel panel2;
        private GroupBox gbxTop;
        private Label label4;
        private ucCompareSelect ucCompareSelectSource;
        private ucCompareSelect ucCompareSelectDestination;
        private GroupBox gbxSource;
        private Button btnVisible;
        private Button btnClose;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsLblSource;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel tsLblDest;
        private Panel pnlCompareInfo;
        private ListBox lbxChangedLine;
        private GroupBox groupBox1;
    }
}

