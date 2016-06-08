namespace LHJ.DBViewer
{
    partial class frmSchemaBrowser
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucObject21 = new LHJ.DBViewer.ucObject2();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucObject21);
            this.splitContainer1.Size = new System.Drawing.Size(1042, 680);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucObject21
            // 
            this.ucObject21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucObject21.Location = new System.Drawing.Point(0, 0);
            this.ucObject21.Name = "ucObject21";
            this.ucObject21.Size = new System.Drawing.Size(202, 680);
            this.ucObject21.TabIndex = 0;
            this.ucObject21.SelectedObjChanged += new LHJ.Common.Definition.EventHandler.SelectedObjChangedEventHandler(this.ucObject21_SelectedObjChanged);
            // 
            // frmSchemaBrowser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1042, 680);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSchemaBrowser";
            this.Text = "Schema Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucObject2 ucObject21;
    }
}