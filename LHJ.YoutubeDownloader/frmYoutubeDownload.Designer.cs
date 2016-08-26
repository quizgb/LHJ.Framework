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
            this.btnFavoriteLocalDownPath = new System.Windows.Forms.Button();
            this.cboDownloadType = new System.Windows.Forms.ComboBox();
            this.tbxYoutubeUrl = new System.Windows.Forms.TextBox();
            this.lblYoutubeUrl = new System.Windows.Forms.Label();
            this.btnSetDownloadPath = new System.Windows.Forms.Button();
            this.tbxDownloadPath = new System.Windows.Forms.TextBox();
            this.lblDownloadPath = new System.Windows.Forms.Label();
            this.pnlDownloadList = new System.Windows.Forms.Panel();
            this.pnlDownloadListMenu = new System.Windows.Forms.Panel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelDownloadList = new System.Windows.Forms.Button();
            this.cbxCheckAllDownloadList = new System.Windows.Forms.CheckBox();
            this.btnCreateShortCut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlDownloadList.SuspendLayout();
            this.pnlDownloadListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpDownloadList
            // 
            this.flpDownloadList.AutoScroll = true;
            this.flpDownloadList.BackColor = System.Drawing.Color.White;
            this.flpDownloadList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDownloadList.Location = new System.Drawing.Point(0, 30);
            this.flpDownloadList.Name = "flpDownloadList";
            this.flpDownloadList.Size = new System.Drawing.Size(761, 450);
            this.flpDownloadList.TabIndex = 0;
            this.flpDownloadList.MouseEnter += new System.EventHandler(this.flpDownloadList_MouseEnter);
            // 
            // btnAddDownloadList
            // 
            this.btnAddDownloadList.Location = new System.Drawing.Point(718, 32);
            this.btnAddDownloadList.Name = "btnAddDownloadList";
            this.btnAddDownloadList.Size = new System.Drawing.Size(57, 23);
            this.btnAddDownloadList.TabIndex = 1;
            this.btnAddDownloadList.Text = "추가";
            this.btnAddDownloadList.UseVisualStyleBackColor = true;
            this.btnAddDownloadList.Click += new System.EventHandler(this.btnAddDownloadList_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFavoriteLocalDownPath);
            this.panel1.Controls.Add(this.cboDownloadType);
            this.panel1.Controls.Add(this.tbxYoutubeUrl);
            this.panel1.Controls.Add(this.lblYoutubeUrl);
            this.panel1.Controls.Add(this.btnAddDownloadList);
            this.panel1.Controls.Add(this.btnSetDownloadPath);
            this.panel1.Controls.Add(this.tbxDownloadPath);
            this.panel1.Controls.Add(this.lblDownloadPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 62);
            this.panel1.TabIndex = 2;
            // 
            // btnFavoriteLocalDownPath
            // 
            this.btnFavoriteLocalDownPath.Image = global::LHJ.YoutubeDownloader.Properties.Resources._1472131444_star;
            this.btnFavoriteLocalDownPath.Location = new System.Drawing.Point(648, 3);
            this.btnFavoriteLocalDownPath.Name = "btnFavoriteLocalDownPath";
            this.btnFavoriteLocalDownPath.Size = new System.Drawing.Size(31, 23);
            this.btnFavoriteLocalDownPath.TabIndex = 8;
            this.btnFavoriteLocalDownPath.UseVisualStyleBackColor = true;
            this.btnFavoriteLocalDownPath.Click += new System.EventHandler(this.btnAddDownloadList_Click);
            // 
            // cboDownloadType
            // 
            this.cboDownloadType.DisplayMember = "CODE_NAME";
            this.cboDownloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDownloadType.Enabled = false;
            this.cboDownloadType.Location = new System.Drawing.Point(652, 33);
            this.cboDownloadType.Name = "cboDownloadType";
            this.cboDownloadType.Size = new System.Drawing.Size(60, 20);
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
            // btnSetDownloadPath
            // 
            this.btnSetDownloadPath.Image = global::LHJ.YoutubeDownloader.Properties.Resources._1472131309_system_search;
            this.btnSetDownloadPath.Location = new System.Drawing.Point(680, 3);
            this.btnSetDownloadPath.Name = "btnSetDownloadPath";
            this.btnSetDownloadPath.Size = new System.Drawing.Size(31, 23);
            this.btnSetDownloadPath.TabIndex = 4;
            this.btnSetDownloadPath.UseVisualStyleBackColor = true;
            this.btnSetDownloadPath.Click += new System.EventHandler(this.btnAddDownloadList_Click);
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
            // pnlDownloadList
            // 
            this.pnlDownloadList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDownloadList.Controls.Add(this.flpDownloadList);
            this.pnlDownloadList.Controls.Add(this.pnlDownloadListMenu);
            this.pnlDownloadList.Location = new System.Drawing.Point(12, 68);
            this.pnlDownloadList.Name = "pnlDownloadList";
            this.pnlDownloadList.Size = new System.Drawing.Size(763, 482);
            this.pnlDownloadList.TabIndex = 4;
            // 
            // pnlDownloadListMenu
            // 
            this.pnlDownloadListMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDownloadListMenu.Controls.Add(this.btnCreateShortCut);
            this.pnlDownloadListMenu.Controls.Add(this.btnDownload);
            this.pnlDownloadListMenu.Controls.Add(this.btnDelDownloadList);
            this.pnlDownloadListMenu.Controls.Add(this.cbxCheckAllDownloadList);
            this.pnlDownloadListMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDownloadListMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlDownloadListMenu.Name = "pnlDownloadListMenu";
            this.pnlDownloadListMenu.Size = new System.Drawing.Size(761, 30);
            this.pnlDownloadListMenu.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Image = global::LHJ.YoutubeDownloader.Properties.Resources._1472133673_download;
            this.btnDownload.Location = new System.Drawing.Point(121, 2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(31, 23);
            this.btnDownload.TabIndex = 10;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnAddDownloadList_Click);
            // 
            // btnDelDownloadList
            // 
            this.btnDelDownloadList.Image = global::LHJ.YoutubeDownloader.Properties.Resources._1464172710_Less;
            this.btnDelDownloadList.Location = new System.Drawing.Point(84, 2);
            this.btnDelDownloadList.Name = "btnDelDownloadList";
            this.btnDelDownloadList.Size = new System.Drawing.Size(31, 23);
            this.btnDelDownloadList.TabIndex = 9;
            this.btnDelDownloadList.UseVisualStyleBackColor = true;
            this.btnDelDownloadList.Click += new System.EventHandler(this.btnAddDownloadList_Click);
            // 
            // cbxCheckAllDownloadList
            // 
            this.cbxCheckAllDownloadList.AutoSize = true;
            this.cbxCheckAllDownloadList.Location = new System.Drawing.Point(6, 7);
            this.cbxCheckAllDownloadList.Name = "cbxCheckAllDownloadList";
            this.cbxCheckAllDownloadList.Size = new System.Drawing.Size(72, 16);
            this.cbxCheckAllDownloadList.TabIndex = 0;
            this.cbxCheckAllDownloadList.Text = "전체선택";
            this.cbxCheckAllDownloadList.UseVisualStyleBackColor = true;
            this.cbxCheckAllDownloadList.CheckedChanged += new System.EventHandler(this.cbxCheckAllDownloadList_CheckedChanged);
            // 
            // btnCreateShortCut
            // 
            this.btnCreateShortCut.Location = new System.Drawing.Point(666, 3);
            this.btnCreateShortCut.Name = "btnCreateShortCut";
            this.btnCreateShortCut.Size = new System.Drawing.Size(90, 23);
            this.btnCreateShortCut.TabIndex = 11;
            this.btnCreateShortCut.Text = "바로가기 생성";
            this.btnCreateShortCut.UseVisualStyleBackColor = true;
            this.btnCreateShortCut.Click += new System.EventHandler(this.btnAddDownloadList_Click);
            // 
            // frmYoutubeDownload
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(788, 562);
            this.Controls.Add(this.pnlDownloadList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYoutubeDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Downloader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDownloadList.ResumeLayout(false);
            this.pnlDownloadListMenu.ResumeLayout(false);
            this.pnlDownloadListMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDownloadList;
        private System.Windows.Forms.Button btnAddDownloadList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetDownloadPath;
        private System.Windows.Forms.TextBox tbxDownloadPath;
        private System.Windows.Forms.Label lblDownloadPath;
        private System.Windows.Forms.TextBox tbxYoutubeUrl;
        private System.Windows.Forms.Label lblYoutubeUrl;
        private System.Windows.Forms.Panel pnlDownloadList;
        private System.Windows.Forms.Panel pnlDownloadListMenu;
        private System.Windows.Forms.Button btnFavoriteLocalDownPath;
        private System.Windows.Forms.ComboBox cboDownloadType;
        private System.Windows.Forms.CheckBox cbxCheckAllDownloadList;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDelDownloadList;
        private System.Windows.Forms.Button btnCreateShortCut;
    }
}

