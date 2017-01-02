using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverTTSTranslation
{
    public partial class TranslationForm : Form
    {
        public class Trans
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string type { get; set; }
            public string service { get; set; }
            public string version { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public string translatedText { get; set; }
        }

        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public TranslationForm()
        {
            InitializeComponent();

            this.SetInitialize();
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
            this.Icon = Properties.Resources._1483348680_Translate;

            this.cboFromLanguage.DisplayMember = "CODE_NAME";
            this.cboFromLanguage.ValueMember = "CODE";

            this.cboToLanguage.DisplayMember = "CODE_NAME";
            this.cboToLanguage.ValueMember = "CODE";

            this.cboTTSSource.DisplayMember = "CODE_NAME";
            this.cboTTSSource.ValueMember = "CODE";

            this.cboTTSTarget.DisplayMember = "CODE_NAME";
            this.cboTTSTarget.ValueMember = "CODE";

            this.SetLanguageComboBox();
            this.SetTTSComboBox();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetTTSComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CODE");
            dt.Columns.Add("CODE_NAME");

            DataRow dr = dt.NewRow();

            dr["CODE"] = string.Empty;
            dr["CODE_NAME"] = string.Empty;

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "mijin";
            dr["CODE_NAME"] = "미진(한국어, 여성)";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "jinho";
            dr["CODE_NAME"] = "진호(한국어, 남성)";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "clara";
            dr["CODE_NAME"] = "클라라(영어, 여성)";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "matt";
            dr["CODE_NAME"] = "매튜(영어, 남성)";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "yuri";
            dr["CODE_NAME"] = "유리(일본어, 여성)";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "shinji";
            dr["CODE_NAME"] = "신지(일본어, 남성)";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "meimei";
            dr["CODE_NAME"] = "메이메이(중국어, 여성)";

            dt.Rows.Add(dr);

            this.cboTTSSource.DataSource = dt;
            this.cboTTSTarget.DataSource = dt.Copy();
        }

        private void SetLanguageComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CODE");
            dt.Columns.Add("CODE_NAME");

            DataRow dr = dt.NewRow();

            dr["CODE"] = string.Empty;
            dr["CODE_NAME"] = string.Empty;

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "ko";
            dr["CODE_NAME"] = "한국어";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "en";
            dr["CODE_NAME"] = "영어";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "ja";
            dr["CODE_NAME"] = "일본어";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["CODE"] = "zh-CN";
            dr["CODE_NAME"] = "중국어";

            dt.Rows.Add(dr);

            this.cboFromLanguage.DataSource = dt;
            this.cboToLanguage.DataSource = dt.Copy();
        }

        private string Translation(string aSource, string aTarget, string aText)
        {
            string url = "https://openapi.naver.com/v1/language/translate";
            string text = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", Definition.ConstValue.ConstValue.NaverClintInfo.ID);
            request.Headers.Add("X-Naver-Client-Secret", Definition.ConstValue.ConstValue.NaverClintInfo.PASS);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] byteDataParams = Encoding.UTF8.GetBytes(string.Format("source={0}&target={1}&text={2}", aSource, aTarget, aText));
            request.ContentLength = byteDataParams.Length;

            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        text = reader.ReadToEnd();
                    }
                }
            }

            Trans ts = Newtonsoft.Json.JsonConvert.DeserializeObject<Trans>(text);

            return ts.message.result.translatedText;
        }

        private void TTS(string aSpeacker, int aSpeed, string aText)
        {
            string url = "https://openapi.naver.com/v1/voice/tts.bin";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", Definition.ConstValue.ConstValue.NaverClintInfo.ID);
            request.Headers.Add("X-Naver-Client-Secret", Definition.ConstValue.ConstValue.NaverClintInfo.PASS);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] byteDataParams = Encoding.UTF8.GetBytes(string.Format("speaker={0}&speed={1}&text={2}", aSpeacker, aSpeed, aText));
            request.ContentLength = byteDataParams.Length;

            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        byte[] buffer = new byte[32768];
                        int read;

                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                    }

                    ms.Position = 0;

                    using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
                    {
                        using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                        {
                            waveOut.Init(blockAlignedStream);
                            waveOut.Play();

                            while (waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    }
                }
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void btnTranslation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSource.Text))
            {
                this.txtSource.Focus();
                MessageBox.Show("번역할 문자열을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.cboFromLanguage.SelectedValue.ToString()))
            {
                MessageBox.Show("번역할 문자열의 언어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.cboToLanguage.SelectedValue.ToString()))
            {
                MessageBox.Show("번역될 언어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.txtTarget.Text = this.Translation(this.cboFromLanguage.SelectedValue.ToString(), this.cboToLanguage.SelectedValue.ToString(), this.txtSource.Text);
        }

        private void txtSource_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (tbx != null)
            {
                if (e.Control && e.KeyCode.Equals(Keys.A))
                {
                    tbx.Focus();
                    tbx.SelectAll();
                }
            }
        }

        private void btnTTSSource_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnTTSSource))
                {
                    if (string.IsNullOrEmpty(this.txtSource.Text))
                    {
                        this.txtSource.Focus();
                        MessageBox.Show("읽을 문자열을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    this.TTS(this.cboTTSSource.SelectedValue.ToString(), this.trbTTSSource.Value, this.txtSource.Text);
                }
                else if (btn.Equals(this.btnTTSTarget))
                {
                    if (string.IsNullOrEmpty(this.txtTarget.Text))
                    {
                        this.txtTarget.Focus();
                        MessageBox.Show("읽을 문자열을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    this.TTS(this.cboTTSTarget.SelectedValue.ToString(), this.trbTTSTarget.Value, this.txtTarget.Text);
                }
            }
        }
        #endregion 7.Event
    }
}
