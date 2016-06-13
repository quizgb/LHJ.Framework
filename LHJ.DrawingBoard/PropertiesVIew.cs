using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.DrawingBoard
{
    public partial class PropertiesVIew : Form
    {
        #region 전역변수

        /// <summary>
        /// Pen의 두께의 최대치를 설정하는 상수
        /// </summary>
        private const int maxWidth = 10;

        #endregion

        #region 속성

        /// <summary>
        /// Pen 의 두께
        /// </summary>
        public int PenWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 테두리 색
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// 배경색
        /// </summary>
        public Color BackGroundColor
        {
            get;
            set;
        }

        #endregion

        #region 생성자

        public PropertiesVIew()
        {
        }

        //선택된 DrawObject 의 값을 넣어준다.
        public PropertiesVIew(Color color, Color backgroundColor, int penWidth = 1)
        {
            InitializeComponent();

            InitControls();

            label_Color.BackColor = color;
            label_BackgroundColor.BackColor = backgroundColor;
            combobox_PenWidth.Text = penWidth.ToString();

            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            this.button_SelectColor.Click += new System.EventHandler(this.button_SelectColor_Click);
            this.button_SelectBackgroudColor.Click += new System.EventHandler(this.button_Cancel_Click);
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 저장하기
        /// </summary>
        private void button_Save_Click(object sender, EventArgs e)
        {
            //프로그램의 속성에 속성들을 저장한다.
            Controller.MainController.Instance.LastUsedColor = Color = label_Color.BackColor;
            Controller.MainController.Instance.LastUesdBackgoroundColor = BackGroundColor = label_BackgroundColor.BackColor;
            Controller.MainController.Instance.LastUsedPenWidth = PenWidth = int.Parse(combobox_PenWidth.Text);

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 테두리 색 지정하기
        /// </summary>
        private void button_SelectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = label_Color.BackColor;

            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                label_Color.BackColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// 취소하기
        /// </summary>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = label_BackgroundColor.BackColor;

            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                label_BackgroundColor.BackColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// 콤보박스 초기화
        /// </summary>
        private void InitControls()
        {
            for (int i = 1; i <= maxWidth; i++)
            {
                combobox_PenWidth.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
        }

        #endregion
    }
}
