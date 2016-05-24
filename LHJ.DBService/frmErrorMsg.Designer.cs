namespace LHJ.DBService
{
    partial class frmErrorMsg
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
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSQL.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSQL.Location = new System.Drawing.Point(12, 72);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ReadOnly = true;
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSQL.Size = new System.Drawing.Size(409, 332);
            this.txtSQL.TabIndex = 0;
            this.txtSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQL_KeyDown);
            // 
            // txtParam
            // 
            this.txtParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParam.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtParam.Location = new System.Drawing.Point(427, 72);
            this.txtParam.Multiline = true;
            this.txtParam.Name = "txtParam";
            this.txtParam.ReadOnly = true;
            this.txtParam.Size = new System.Drawing.Size(109, 331);
            this.txtParam.TabIndex = 1;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblError.Location = new System.Drawing.Point(18, 9);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(96, 17);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Error Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(18, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "SQL :";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(453, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmErrorMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 416);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.txtSQL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmErrorMsg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "오류";
            this.Load += new System.EventHandler(this.frmErrorMsg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}