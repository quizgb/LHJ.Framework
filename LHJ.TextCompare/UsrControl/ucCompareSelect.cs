using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LHJ.TextCompare.UsrControl
{
    public partial class ucCompareSelect : UserControl
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ucCompareSelect()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method
        public void SetFile(string pFilePath)
        {
            this.txtFile.Text = pFilePath;
            this.rbtnFile.Checked = true;
        }

        public string GetTitle()
        {
            if (this.rbtnClipBoard.Checked)
            {
                return "ClipBoard";
            }

            if (this.rbtnFile.Checked)
            {
                return Path.GetFileName(this.txtFile.Text);
            }

            return string.Empty;
        }

        public string GetString()
        {
            string text = string.Empty;

            if (this.rbtnClipBoard.Checked)
            {
                if (!string.IsNullOrEmpty(this.txtClipBoard.Text))
                {
                    text = this.txtClipBoard.Text;
                }
                else
                {
                    MessageBox.Show("설정된 텍스트 문자열이 없습니다.(ClipBoard)");
                    this.btnClipBoard.Focus();
                }
            }
            else if (this.rbtnFile.Checked)
            {
                if (string.IsNullOrEmpty(this.txtFile.Text) || !File.Exists(this.txtFile.Text))
                {
                    MessageBox.Show("설정된 파일이 없습니다.");
                    this.btnFile.Focus();
                }

                using (StreamReader streamReader = new StreamReader(this.txtFile.Text, Encoding.Default))
                {
                    text = streamReader.ReadToEnd();
                }
            }

            return text;
        }
        #endregion 6.Method


        #region 7.Event
        private void btnClipBoard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnFile))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = false;
                    openFileDialog.InitialDirectory = Application.StartupPath;

                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    this.txtFile.Text = openFileDialog.FileName;
                    this.rbtnFile.Checked = true;
                }
                else if (btn.Equals(this.btnClipBoard))
                {
                    string text = Clipboard.GetText();

                    if (string.IsNullOrEmpty(text))
                    {
                        MessageBox.Show("클립보드에 복사된 텍스트가 없습니다.");
                    }
                    else
                    {
                        this.txtClipBoard.Text = text;
                        this.rbtnClipBoard.Checked = true;
                    }
                }
            }
        }
        #endregion 7.Event
    }
}
