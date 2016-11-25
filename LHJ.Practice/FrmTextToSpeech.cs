using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Synthesis;

namespace LHJ.Practice
{
    public partial class FrmTextToSpeech : Form
    {
        #region 1.Variable
        private SpeechSynthesizer m_Ts = new SpeechSynthesizer();
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmTextToSpeech()
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
            this.m_Ts.SetOutputToDefaultAudioDevice();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// 숫자를 한글 발음으로 바꾼다.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string transToHan(long num)
        {
            string[] han = new string[] { "", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
            string[] unit = new string[] { "천", "백", "십", "" };
            string[] unit2 = new string[] { "", "만", "억", "조" };

            string result = num.ToString();

            // 네자리마다 단위수2(만,억,조)가 바뀌고 네자리바다 단위수1(천,백,십)이 바뀌므로 네자리씩 나눈다.
            ArrayList spilt = new ArrayList();
            for (int i = 0; result.Length > 0; i++)
            {
                int spiltLength;
                if (result.Length > 4) { spiltLength = 4; }
                else { spiltLength = result.Length; }

                spilt.Add(result.Substring(result.Length - spiltLength, spiltLength));
                result = result.Substring(0, result.Length - spiltLength);
            }

            for (int i = 0; i < spilt.Count; i++)
            {
                string str = (string)spilt[i];
                // 네자리씩 나눌때 네자리가 되지않으면 원만한 처리를 위해서 '0'을 채워 네자리로 만든다.
                if (str.Length < 4) str = str.PadLeft(4, '0');

                if (Int32.Parse(str) != 0) result = unit2[i] + result;

                // 네자리로 나뉜값을 '천','백','십'단위를 구분하는 루틴
                for (int j = 3; j >= 0; j--)
                {
                    string unitFlag = unit[j];
                    if (str.Substring(j, 1) == "0") unitFlag = "";
                    result = han[Int32.Parse(str.Substring(j, 1))] + unitFlag + result;
                }
            }
            return result;
        }

        private void Play()
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text))
            {
                // System.Speech는 기본 영문만 제공한다.
                /*
                // C# TTS 사용 순서

                    1. Microsoft Speech Platform - Runtime 설치 (http://www.microsoft.com/en-us/download/details.aspx?id=27225)
                    2. Microsoft Speech Platform - Software Development Kit (SDK) (http://www.microsoft.com/en-us/download/details.aspx?id=27226)
                    3. Microsoft Speech Platform - Runtime Languages (http://www.microsoft.com/en-us/download/details.aspx?id=27224)
                       다운로드 후 KR을 검색해서 2개의 언어 파일을 받는다.
                */
                // 2 SDK 설치 후 C:\Program Files\Microsoft SDKs\Speech\v11.0\Assembly\Microsoft.Speech.dll 를 참조
                // System.Speech.dll을 참조하면 한국어를 인식 못함.

                // 보이스를 선택하지 않아도 처리됨
                //ts.SelectVoice("Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)");

                if (this.m_Ts.State == Microsoft.Speech.Synthesis.SynthesizerState.Ready)
                {
                    //m_Ts.SpeakProgress += new EventHandler<Microsoft.Speech.Synthesis.SpeakProgressEventArgs>(speakRBox_SpeakProgress);
                    //m_Ts.SpeakCompleted += new EventHandler<Microsoft.Speech.Synthesis.SpeakCompletedEventArgs>(speakRBox_SpeakCompleted);
                    this.m_Ts.SpeakAsync(this.textBox1.Text);
                    return;
                }
                if (this.m_Ts.State == Microsoft.Speech.Synthesis.SynthesizerState.Paused)
                {
                    this.m_Ts.Resume();
                }
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void button1_Click(object sender, EventArgs e)
        {
            this.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_Ts.State == Microsoft.Speech.Synthesis.SynthesizerState.Speaking)
            {
                this.m_Ts.Pause();
                return;
            }
            else if (m_Ts.State == Microsoft.Speech.Synthesis.SynthesizerState.Paused)
            {
                this.m_Ts.Resume();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.m_Ts.SpeakAsyncCancelAll();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.A))
            {
                this.textBox1.Focus();
                this.textBox1.SelectAll();
            }
        }
        #endregion 7.Event
    }
}
