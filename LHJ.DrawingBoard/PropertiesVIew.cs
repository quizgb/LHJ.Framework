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
        #region 1.Variable
        /// <summary>
        /// Pen의 두께의 최대치를 설정하는 상수
        /// </summary>
        private const int mMaxWidth = 10;
        #endregion 1.Variable


        #region 2.Property
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
        #endregion 2.Property


        #region 3.Constructor
        public PropertiesVIew()
        {
        }

        //선택된 DrawObject 의 값을 넣어준다.
        public PropertiesVIew(Color color, Color backgroundColor, int penWidth = 1)
        {
            InitializeComponent();

            this.SetInitialize(color, backgroundColor, penWidth);
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize(Color aColor, Color aBackgroundColor, int aPenWidth)
        {
            this.InitControls();

            this.label_Color.BackColor = aColor;
            this.label_BackgroundColor.BackColor = aBackgroundColor;
            this.combobox_PenWidth.Text = aPenWidth.ToString();

            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            this.button_SelectColor.Click += new System.EventHandler(this.button_SelectColor_Click);
            this.button_SelectBackgroudColor.Click += new System.EventHandler(this.button_Cancel_Click);
        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// 콤보박스 초기화
        /// </summary>
        private void InitControls()
        {
            for (int i = 1; i <= mMaxWidth; i++)
            {
                this.combobox_PenWidth.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
        }
        #endregion 6.Method


        #region 7.Event
        /// <summary>
        /// 저장하기
        /// </summary>
        private void button_Save_Click(object sender, EventArgs e)
        {
            //프로그램의 속성에 속성들을 저장한다.
            Controller.MainController.Instance.LastUsedColor = Color = this.label_Color.BackColor;
            Controller.MainController.Instance.LastUesdBackgoroundColor = BackGroundColor = this.label_BackgroundColor.BackColor;
            Controller.MainController.Instance.LastUsedPenWidth = PenWidth = int.Parse(this.combobox_PenWidth.Text);

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 테두리 색 지정하기
        /// </summary>
        private void button_SelectColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.label_Color.BackColor;

            if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.label_Color.BackColor = this.colorDialog1.Color;
            }
        }

        /// <summary>
        /// 취소하기
        /// </summary>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.label_BackgroundColor.BackColor;

            if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.label_BackgroundColor.BackColor = this.colorDialog1.Color;
            }
        }
        #endregion 7.Event
    }
}
