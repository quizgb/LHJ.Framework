using System;
using System.Drawing;
using System.Windows.Forms;
using LHJ.Common.Definition;

namespace LHJ.Controls
{
    /// <summary>
    /// 1.프로그레스 바 가운데 % 표시
    /// </summary>
    public class ucProgressBar : ProgressBar
    {
        #region 1.Variable
        private string mProgressBarText = "";
        private ConstValue.ProgressBarTextType mTextType = ConstValue.ProgressBarTextType.None;
        #endregion 1.Variable


        #region 2.Property
        public ConstValue.ProgressBarTextType TextType
        {
            get { return this.mTextType; }
            set { this.mTextType = value; }
        }

        /// <summary>
        /// ProgressTextType 이 Text일때 사용되는 속성
        /// </summary>
        public string ProgressBarText
        {
            get { return this.mProgressBarText; }
            set { this.mProgressBarText = value; }
        }
        #endregion 2.Property


        #region 3.Constructor

        #endregion 3.Constructor
        

        #region 4.Override Method
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case ConstValue.WM_PAINT:
                    using (var graphics = Graphics.FromHwnd(Handle))
                    {
                        string text = currentText();
                        var textSize = graphics.MeasureString(text, SystemFonts.DefaultFont);

                        using (var textBrush = new SolidBrush(Color.Black))
                        {
                            graphics.DrawString(text, SystemFonts.DefaultFont, textBrush, (Width / 2) - (textSize.Width / 2), (Height / 2) - (textSize.Height / 2));
                        }

                    }
                    break;
            }
        }
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
        private string currentText()
        {
            if (mTextType == ConstValue.ProgressBarTextType.None)
            {
                return string.Empty;
            }
            else if (mTextType == ConstValue.ProgressBarTextType.Word)
            {
                return this.mProgressBarText;
            }
            else if (mTextType == ConstValue.ProgressBarTextType.Percentage)
            {
                int percent = (int)(((double)(Value - Minimum) / (double)(Maximum - Minimum)) * 100);
                return percent.ToString() + "%";
            }
            else
            {
                return string.Empty;
            }

        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
