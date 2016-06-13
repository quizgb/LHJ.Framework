namespace LHJ.DrawingBoard
{
    partial class PropertiesVIew
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_SelectBackgroudColor = new System.Windows.Forms.Button();
            this.button_SelectColor = new System.Windows.Forms.Button();
            this.combobox_PenWidth = new System.Windows.Forms.ComboBox();
            this.label_BackgroundColor = new System.Windows.Forms.Label();
            this.label_Color = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(153, 117);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(93, 25);
            this.button_Cancel.TabIndex = 19;
            this.button_Cancel.Text = "취 소";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(38, 117);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(93, 25);
            this.button_Save.TabIndex = 18;
            this.button_Save.Text = "저 장";
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // button_SelectBackgroudColor
            // 
            this.button_SelectBackgroudColor.Location = new System.Drawing.Point(198, 43);
            this.button_SelectBackgroudColor.Name = "button_SelectBackgroudColor";
            this.button_SelectBackgroudColor.Size = new System.Drawing.Size(38, 25);
            this.button_SelectBackgroudColor.TabIndex = 17;
            this.button_SelectBackgroudColor.Text = "...";
            this.button_SelectBackgroudColor.UseVisualStyleBackColor = true;
            // 
            // button_SelectColor
            // 
            this.button_SelectColor.Location = new System.Drawing.Point(198, 10);
            this.button_SelectColor.Name = "button_SelectColor";
            this.button_SelectColor.Size = new System.Drawing.Size(38, 25);
            this.button_SelectColor.TabIndex = 16;
            this.button_SelectColor.Text = "...";
            this.button_SelectColor.UseVisualStyleBackColor = true;
            // 
            // combobox_PenWidth
            // 
            this.combobox_PenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_PenWidth.FormattingEnabled = true;
            this.combobox_PenWidth.Location = new System.Drawing.Point(101, 74);
            this.combobox_PenWidth.Name = "combobox_PenWidth";
            this.combobox_PenWidth.Size = new System.Drawing.Size(82, 20);
            this.combobox_PenWidth.TabIndex = 15;
            // 
            // label_BackgroundColor
            // 
            this.label_BackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_BackgroundColor.Location = new System.Drawing.Point(101, 43);
            this.label_BackgroundColor.Name = "label_BackgroundColor";
            this.label_BackgroundColor.Size = new System.Drawing.Size(82, 22);
            this.label_BackgroundColor.TabIndex = 14;
            // 
            // label_Color
            // 
            this.label_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Color.Location = new System.Drawing.Point(101, 11);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(82, 22);
            this.label_Color.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pen 두께";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "배경색";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "테두리 색";
            // 
            // PropertiesVIew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(278, 152);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_SelectBackgroudColor);
            this.Controls.Add(this.button_SelectColor);
            this.Controls.Add(this.combobox_PenWidth);
            this.Controls.Add(this.label_BackgroundColor);
            this.Controls.Add(this.label_Color);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesVIew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "속성";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_SelectBackgroudColor;
        private System.Windows.Forms.Button button_SelectColor;
        private System.Windows.Forms.ComboBox combobox_PenWidth;
        private System.Windows.Forms.Label label_BackgroundColor;
        private System.Windows.Forms.Label label_Color;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}