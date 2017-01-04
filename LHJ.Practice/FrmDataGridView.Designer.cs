namespace LHJ.Practice
{
    partial class FrmDataGridView
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
            this.ucDataGridView1 = new LHJ.Controls.ucDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucDataGridView1.Location = new System.Drawing.Point(30, 45);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Paging = false;
            this.ucDataGridView1.PagingRowCount = 0;
            this.ucDataGridView1.RowTemplate.Height = 23;
            this.ucDataGridView1.ShowRowHeaderValue = true;
            this.ucDataGridView1.Size = new System.Drawing.Size(636, 343);
            this.ucDataGridView1.TabIndex = 0;
            // 
            // FrmDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 495);
            this.Controls.Add(this.ucDataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataGridView";
            this.Text = "DataGridView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ucDataGridView ucDataGridView1;
    }
}