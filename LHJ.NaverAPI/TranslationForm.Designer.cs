namespace LHJ.NaverTTSTranslation
{
    partial class TranslationForm
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnTranslation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTTSSource = new System.Windows.Forms.ComboBox();
            this.btnTTSSource = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboTTSTarget = new System.Windows.Forms.ComboBox();
            this.btnTTSTarget = new System.Windows.Forms.Button();
            this.cboFromLanguage = new System.Windows.Forms.ComboBox();
            this.cboToLanguage = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trbTTSSource = new System.Windows.Forms.TrackBar();
            this.trbTTSTarget = new System.Windows.Forms.TrackBar();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTTSSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTTSTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(539, 175);
            this.txtSource.TabIndex = 0;
            this.txtSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSource_KeyDown);
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(12, 195);
            this.txtTarget.Multiline = true;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTarget.Size = new System.Drawing.Size(539, 140);
            this.txtTarget.TabIndex = 1;
            this.txtTarget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSource_KeyDown);
            // 
            // btnTranslation
            // 
            this.btnTranslation.Location = new System.Drawing.Point(6, 36);
            this.btnTranslation.Name = "btnTranslation";
            this.btnTranslation.Size = new System.Drawing.Size(178, 26);
            this.btnTranslation.TabIndex = 2;
            this.btnTranslation.Text = "번역";
            this.btnTranslation.UseVisualStyleBackColor = true;
            this.btnTranslation.Click += new System.EventHandler(this.btnTranslation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTTSSource);
            this.groupBox2.Controls.Add(this.trbTTSSource);
            this.groupBox2.Controls.Add(this.btnTTSSource);
            this.groupBox2.Location = new System.Drawing.Point(557, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // cboTTSSource
            // 
            this.cboTTSSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTTSSource.FormattingEnabled = true;
            this.cboTTSSource.Location = new System.Drawing.Point(6, 51);
            this.cboTTSSource.Name = "cboTTSSource";
            this.cboTTSSource.Size = new System.Drawing.Size(178, 20);
            this.cboTTSSource.TabIndex = 1;
            // 
            // btnTTSSource
            // 
            this.btnTTSSource.Location = new System.Drawing.Point(6, 76);
            this.btnTTSSource.Name = "btnTTSSource";
            this.btnTTSSource.Size = new System.Drawing.Size(178, 23);
            this.btnTTSSource.TabIndex = 0;
            this.btnTTSSource.Text = "읽기";
            this.btnTTSSource.UseVisualStyleBackColor = true;
            this.btnTTSSource.Click += new System.EventHandler(this.btnTTSSource_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboTTSTarget);
            this.groupBox3.Controls.Add(this.trbTTSTarget);
            this.groupBox3.Controls.Add(this.btnTTSTarget);
            this.groupBox3.Location = new System.Drawing.Point(557, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 109);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // cboTTSTarget
            // 
            this.cboTTSTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTTSTarget.FormattingEnabled = true;
            this.cboTTSTarget.Location = new System.Drawing.Point(6, 50);
            this.cboTTSTarget.Name = "cboTTSTarget";
            this.cboTTSTarget.Size = new System.Drawing.Size(178, 20);
            this.cboTTSTarget.TabIndex = 2;
            // 
            // btnTTSTarget
            // 
            this.btnTTSTarget.Location = new System.Drawing.Point(6, 76);
            this.btnTTSTarget.Name = "btnTTSTarget";
            this.btnTTSTarget.Size = new System.Drawing.Size(178, 23);
            this.btnTTSTarget.TabIndex = 1;
            this.btnTTSTarget.Text = "읽기";
            this.btnTTSTarget.UseVisualStyleBackColor = true;
            this.btnTTSTarget.Click += new System.EventHandler(this.btnTTSSource_Click);
            // 
            // cboFromLanguage
            // 
            this.cboFromLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromLanguage.FormattingEnabled = true;
            this.cboFromLanguage.Location = new System.Drawing.Point(6, 10);
            this.cboFromLanguage.Name = "cboFromLanguage";
            this.cboFromLanguage.Size = new System.Drawing.Size(86, 20);
            this.cboFromLanguage.TabIndex = 0;
            // 
            // cboToLanguage
            // 
            this.cboToLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToLanguage.FormattingEnabled = true;
            this.cboToLanguage.Location = new System.Drawing.Point(98, 10);
            this.cboToLanguage.Name = "cboToLanguage";
            this.cboToLanguage.Size = new System.Drawing.Size(86, 20);
            this.cboToLanguage.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboToLanguage);
            this.groupBox1.Controls.Add(this.cboFromLanguage);
            this.groupBox1.Controls.Add(this.btnTranslation);
            this.groupBox1.Location = new System.Drawing.Point(557, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // trbTTSSource
            // 
            this.trbTTSSource.LargeChange = 1;
            this.trbTTSSource.Location = new System.Drawing.Point(6, 12);
            this.trbTTSSource.Maximum = 5;
            this.trbTTSSource.Minimum = -5;
            this.trbTTSSource.Name = "trbTTSSource";
            this.trbTTSSource.Size = new System.Drawing.Size(178, 45);
            this.trbTTSSource.TabIndex = 6;
            // 
            // trbTTSTarget
            // 
            this.trbTTSTarget.LargeChange = 1;
            this.trbTTSTarget.Location = new System.Drawing.Point(6, 12);
            this.trbTTSTarget.Maximum = 5;
            this.trbTTSTarget.Minimum = -5;
            this.trbTTSTarget.Name = "trbTTSTarget";
            this.trbTTSTarget.Size = new System.Drawing.Size(178, 45);
            this.trbTTSTarget.TabIndex = 7;
            // 
            // TranslationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(762, 341);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Name = "TranslationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "네이버 기계번역+음성합성";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trbTTSSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTTSTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnTranslation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboFromLanguage;
        private System.Windows.Forms.ComboBox cboToLanguage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTTSSource;
        private System.Windows.Forms.Button btnTTSTarget;
        private System.Windows.Forms.ComboBox cboTTSSource;
        private System.Windows.Forms.ComboBox cboTTSTarget;
        private System.Windows.Forms.TrackBar trbTTSSource;
        private System.Windows.Forms.TrackBar trbTTSTarget;
    }
}

