﻿namespace LHJ.DBViewer
{
    partial class frmSQLWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnExecuteQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnAddTab = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRemoveTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExportExcel = new System.Windows.Forms.ToolStripButton();
            this.userControl11 = new LHJ.DBViewer.ucObejct();
            this.pnlMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1264, 884);
            this.pnlMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.userControl11);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 884);
            this.splitContainer1.SplitterDistance = 1000;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 859);
            this.tabControl1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnExecuteQuery,
            this.toolStripSeparator1,
            this.tsbtnAddTab,
            this.tsbtnRemoveTab,
            this.toolStripSeparator2,
            this.tsbtnExportExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1000, 25);
            this.toolStrip2.TabIndex = 17;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnExecuteQuery
            // 
            this.tsbtnExecuteQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExecuteQuery.Image = global::LHJ.DBViewer.Properties.Resources._1464172718_play_circle_outline;
            this.tsbtnExecuteQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExecuteQuery.Name = "tsbtnExecuteQuery";
            this.tsbtnExecuteQuery.Size = new System.Drawing.Size(23, 22);
            this.tsbtnExecuteQuery.Text = "Execute Query";
            this.tsbtnExecuteQuery.Click += new System.EventHandler(this.tsbtnExecuteQuery_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnAddTab
            // 
            this.tsbtnAddTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddTab.Image = global::LHJ.DBViewer.Properties.Resources._1464172705_More;
            this.tsbtnAddTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddTab.Name = "tsbtnAddTab";
            this.tsbtnAddTab.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAddTab.Text = "Add Tab";
            this.tsbtnAddTab.Click += new System.EventHandler(this.tsbtnExecuteQuery_Click);
            // 
            // tsbtnRemoveTab
            // 
            this.tsbtnRemoveTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRemoveTab.Image = global::LHJ.DBViewer.Properties.Resources._1464172710_Less;
            this.tsbtnRemoveTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRemoveTab.Name = "tsbtnRemoveTab";
            this.tsbtnRemoveTab.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRemoveTab.Text = "Remove Tab";
            this.tsbtnRemoveTab.Click += new System.EventHandler(this.tsbtnExecuteQuery_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnExportExcel
            // 
            this.tsbtnExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExportExcel.Image = global::LHJ.DBViewer.Properties.Resources._1464175446_excel;
            this.tsbtnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExportExcel.Name = "tsbtnExportExcel";
            this.tsbtnExportExcel.Size = new System.Drawing.Size(23, 22);
            this.tsbtnExportExcel.Text = "Export Excel";
            this.tsbtnExportExcel.Click += new System.EventHandler(this.tsbtnExecuteQuery_Click);
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(260, 884);
            this.userControl11.TabIndex = 0;
            this.userControl11.ItemDoubleClicked += new LHJ.Common.Definition.EventHandler.ItemDoubleClickEventHandler(this.userControl11_ItemDoubleClicked);
            // 
            // frmSQLWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 884);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmSQLWindow";
            this.Text = "SQL Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private ucObejct userControl11;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnExecuteQuery;
        private System.Windows.Forms.ToolStripButton tsbtnAddTab;
        private System.Windows.Forms.ToolStripButton tsbtnRemoveTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnExportExcel;

    }
}