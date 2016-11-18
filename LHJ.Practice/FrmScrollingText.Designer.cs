namespace LHJ.Practice
{
    partial class FrmScrollingText
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
            this.dougScrollingTextCtrl1 = new clsScrollingText.DougScrollingTextCtrl();
            this.ucMarqueeTextBox1 = new LHJ.Controls.ucMarqueeTextBox();
            this.SuspendLayout();
            // 
            // dougScrollingTextCtrl1
            // 
            this.dougScrollingTextCtrl1.Delay = 250;
            this.dougScrollingTextCtrl1.DougScrollingTextColor1 = System.Drawing.Color.Black;
            this.dougScrollingTextCtrl1.DougScrollingTextColor2 = System.Drawing.Color.Gold;
            this.dougScrollingTextCtrl1.Location = new System.Drawing.Point(59, 85);
            this.dougScrollingTextCtrl1.Name = "dougScrollingTextCtrl1";
            this.dougScrollingTextCtrl1.Size = new System.Drawing.Size(1157, 151);
            this.dougScrollingTextCtrl1.TabIndex = 0;
            this.dougScrollingTextCtrl1.Text = "TEST12345678";
            // 
            // ucMarqueeTextBox1
            // 
            this.ucMarqueeTextBox1.Delay = 1;
            this.ucMarqueeTextBox1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucMarqueeTextBox1.Location = new System.Drawing.Point(84, 258);
            this.ucMarqueeTextBox1.Name = "ucMarqueeTextBox1";
            this.ucMarqueeTextBox1.Size = new System.Drawing.Size(993, 63);
            this.ucMarqueeTextBox1.TabIndex = 1;
            this.ucMarqueeTextBox1.Text = "ucMarqueeTextBox1";
            // 
            // FrmScrollingText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 333);
            this.Controls.Add(this.ucMarqueeTextBox1);
            this.Controls.Add(this.dougScrollingTextCtrl1);
            this.Name = "FrmScrollingText";
            this.Text = "FrmScrollingText";
            this.ResumeLayout(false);

        }

        #endregion

        private clsScrollingText.DougScrollingTextCtrl dougScrollingTextCtrl1;
        private Controls.ucMarqueeTextBox ucMarqueeTextBox1;
    }
}