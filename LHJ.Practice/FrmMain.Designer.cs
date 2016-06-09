namespace LHJ.Practice
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.barBtnShowDataGridView = new System.Windows.Forms.RibbonButton();
            this.barBtnGetSlnCodeLine = new System.Windows.Forms.RibbonButton();
            this.barBtnImageViewer = new System.Windows.Forms.RibbonButton();
            this.barBtnScrollingText = new System.Windows.Forms.RibbonButton();
            this.barBtnTextToSpeech = new System.Windows.Forms.RibbonButton();
            this.barBtnColorSpoid = new System.Windows.Forms.RibbonButton();
            this.barBtnJson = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ribbon1.Size = new System.Drawing.Size(678, 172);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "샘플 프로그램 모음";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.barBtnShowDataGridView);
            this.ribbonPanel1.Items.Add(this.barBtnGetSlnCodeLine);
            this.ribbonPanel1.Items.Add(this.barBtnImageViewer);
            this.ribbonPanel1.Items.Add(this.barBtnScrollingText);
            this.ribbonPanel1.Items.Add(this.barBtnTextToSpeech);
            this.ribbonPanel1.Items.Add(this.barBtnColorSpoid);
            this.ribbonPanel1.Items.Add(this.barBtnJson);
            this.ribbonPanel1.Text = "프로그램 리스트";
            // 
            // barBtnShowDataGridView
            // 
            this.barBtnShowDataGridView.Image = global::LHJ.Practice.Properties.Resources.login_view_32x32;
            this.barBtnShowDataGridView.MaximumSize = new System.Drawing.Size(120, 60);
            this.barBtnShowDataGridView.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.barBtnShowDataGridView.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnShowDataGridView.SmallImage")));
            this.barBtnShowDataGridView.Text = "DataGridView";
            this.barBtnShowDataGridView.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // barBtnGetSlnCodeLine
            // 
            this.barBtnGetSlnCodeLine.Image = global::LHJ.Practice.Properties.Resources.add;
            this.barBtnGetSlnCodeLine.MaximumSize = new System.Drawing.Size(140, 60);
            this.barBtnGetSlnCodeLine.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnGetSlnCodeLine.SmallImage")));
            this.barBtnGetSlnCodeLine.Text = "GetSolutionCodeLine";
            this.barBtnGetSlnCodeLine.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // barBtnImageViewer
            // 
            this.barBtnImageViewer.Image = global::LHJ.Practice.Properties.Resources.delete;
            this.barBtnImageViewer.MaximumSize = new System.Drawing.Size(120, 60);
            this.barBtnImageViewer.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnImageViewer.SmallImage")));
            this.barBtnImageViewer.Text = "ImageViewer";
            this.barBtnImageViewer.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // barBtnScrollingText
            // 
            this.barBtnScrollingText.Image = ((System.Drawing.Image)(resources.GetObject("barBtnScrollingText.Image")));
            this.barBtnScrollingText.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnScrollingText.SmallImage")));
            this.barBtnScrollingText.Text = "ScrollingText";
            this.barBtnScrollingText.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // barBtnTextToSpeech
            // 
            this.barBtnTextToSpeech.Image = ((System.Drawing.Image)(resources.GetObject("barBtnTextToSpeech.Image")));
            this.barBtnTextToSpeech.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnTextToSpeech.SmallImage")));
            this.barBtnTextToSpeech.Text = "TextToSpeech";
            this.barBtnTextToSpeech.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // barBtnColorSpoid
            // 
            this.barBtnColorSpoid.Image = ((System.Drawing.Image)(resources.GetObject("barBtnColorSpoid.Image")));
            this.barBtnColorSpoid.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnColorSpoid.SmallImage")));
            this.barBtnColorSpoid.Text = "ColorSpoid";
            this.barBtnColorSpoid.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // barBtnJson
            // 
            this.barBtnJson.Image = ((System.Drawing.Image)(resources.GetObject("barBtnJson.Image")));
            this.barBtnJson.SmallImage = ((System.Drawing.Image)(resources.GetObject("barBtnJson.SmallImage")));
            this.barBtnJson.Text = "Json";
            this.barBtnJson.Click += new System.EventHandler(this.barBtnShowDataGridView_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 483);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton barBtnShowDataGridView;
        private System.Windows.Forms.RibbonButton barBtnGetSlnCodeLine;
        private System.Windows.Forms.RibbonButton barBtnImageViewer;
        private System.Windows.Forms.RibbonButton barBtnScrollingText;
        private System.Windows.Forms.RibbonButton barBtnTextToSpeech;
        private System.Windows.Forms.RibbonButton barBtnColorSpoid;
        private System.Windows.Forms.RibbonButton barBtnJson;
    }
}