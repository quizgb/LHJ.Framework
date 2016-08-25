namespace LHJ.YoutubeDownloader
{
    partial class frmYoutubeDownload
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
            this.flpDownloadList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDownloadList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboDownloadType = new System.Windows.Forms.ComboBox();
            this.tbxYoutubeUrl = new System.Windows.Forms.TextBox();
            this.lblYoutubeUrl = new System.Windows.Forms.Label();
            this.btnDownloadPath = new System.Windows.Forms.Button();
            this.tbxDownloadPath = new System.Windows.Forms.TextBox();
            this.lblDownloadPath = new System.Windows.Forms.Label();
            this.ucProgressBar1 = new LHJ.Controls.ucProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpDownloadList
            // 
            this.flpDownloadList.AutoScroll = true;
            this.flpDownloadList.BackColor = System.Drawing.Color.White;
            this.flpDownloadList.Location = new System.Drawing.Point(12, 97);
            this.flpDownloadList.Name = "flpDownloadList";
            this.flpDownloadList.Size = new System.Drawing.Size(781, 458);
            this.flpDownloadList.TabIndex = 0;
            this.flpDownloadList.MouseEnter += new System.EventHandler(this.flpDownloadList_MouseEnter);
            // 
            // btnAddDownloadList
            // 
            this.btnAddDownloadList.Location = new System.Drawing.Point(767, 5);
            this.btnAddDownloadList.Name = "btnAddDownloadList";
            this.btnAddDownloadList.Size = new System.Drawing.Size(75, 23);
            this.btnAddDownloadList.TabIndex = 1;
            this.btnAddDownloadList.Text = "추가";
            this.btnAddDownloadList.UseVisualStyleBackColor = true;
            this.btnAddDownloadList.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboDownloadType);
            this.panel1.Controls.Add(this.tbxYoutubeUrl);
            this.panel1.Controls.Add(this.lblYoutubeUrl);
            this.panel1.Controls.Add(this.btnAddDownloadList);
            this.panel1.Controls.Add(this.btnDownloadPath);
            this.panel1.Controls.Add(this.tbxDownloadPath);
            this.panel1.Controls.Add(this.lblDownloadPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 62);
            this.panel1.TabIndex = 2;
            // 
            // cboDownloadType
            // 
            this.cboDownloadType.DisplayMember = "CODE_NAME";
            this.cboDownloadType.Location = new System.Drawing.Point(710, 6);
            this.cboDownloadType.Name = "cboDownloadType";
            this.cboDownloadType.Size = new System.Drawing.Size(51, 20);
            this.cboDownloadType.TabIndex = 7;
            this.cboDownloadType.ValueMember = "CODE";
            // 
            // tbxYoutubeUrl
            // 
            this.tbxYoutubeUrl.Location = new System.Drawing.Point(150, 33);
            this.tbxYoutubeUrl.Name = "tbxYoutubeUrl";
            this.tbxYoutubeUrl.Size = new System.Drawing.Size(496, 21);
            this.tbxYoutubeUrl.TabIndex = 6;
            // 
            // lblYoutubeUrl
            // 
            this.lblYoutubeUrl.AutoSize = true;
            this.lblYoutubeUrl.Location = new System.Drawing.Point(65, 37);
            this.lblYoutubeUrl.Name = "lblYoutubeUrl";
            this.lblYoutubeUrl.Size = new System.Drawing.Size(78, 12);
            this.lblYoutubeUrl.TabIndex = 5;
            this.lblYoutubeUrl.Text = "Youtube URL";
            // 
            // btnDownloadPath
            // 
            this.btnDownloadPath.Location = new System.Drawing.Point(652, 4);
            this.btnDownloadPath.Name = "btnDownloadPath";
            this.btnDownloadPath.Size = new System.Drawing.Size(42, 23);
            this.btnDownloadPath.TabIndex = 4;
            this.btnDownloadPath.UseVisualStyleBackColor = true;
            // 
            // tbxDownloadPath
            // 
            this.tbxDownloadPath.Location = new System.Drawing.Point(150, 4);
            this.tbxDownloadPath.Name = "tbxDownloadPath";
            this.tbxDownloadPath.Size = new System.Drawing.Size(496, 21);
            this.tbxDownloadPath.TabIndex = 3;
            // 
            // lblDownloadPath
            // 
            this.lblDownloadPath.AutoSize = true;
            this.lblDownloadPath.Location = new System.Drawing.Point(10, 8);
            this.lblDownloadPath.Name = "lblDownloadPath";
            this.lblDownloadPath.Size = new System.Drawing.Size(133, 12);
            this.lblDownloadPath.TabIndex = 2;
            this.lblDownloadPath.Text = "다운로드 받을 폴더경로";
            // 
            // ucProgressBar1
            // 
            this.ucProgressBar1.Location = new System.Drawing.Point(12, 68);
            this.ucProgressBar1.Name = "ucProgressBar1";
            this.ucProgressBar1.ProgressBarText = "";
            this.ucProgressBar1.Size = new System.Drawing.Size(781, 23);
            this.ucProgressBar1.TabIndex = 3;
            this.ucProgressBar1.TextType = LHJ.Common.Definition.ConstValue.ProgressBarTextType.None;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 562);
            this.Controls.Add(this.ucProgressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpDownloadList);
            this.Name = "Form1";
            this.Text = "Youtube Downloader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDownloadList;
        private System.Windows.Forms.Button btnAddDownloadList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDownloadPath;
        private System.Windows.Forms.TextBox tbxDownloadPath;
        private System.Windows.Forms.Label lblDownloadPath;
        private System.Windows.Forms.TextBox tbxYoutubeUrl;
        private System.Windows.Forms.Label lblYoutubeUrl;
        private Controls.ucProgressBar ucProgressBar1;
        private System.Windows.Forms.ComboBox cboDownloadType;
    }
}

