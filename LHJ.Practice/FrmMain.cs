using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.Practice
{
    public partial class FrmMain : RibbonForm
    {
        #region 1.Variable
        private Timer m_Timer;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetInitialize();
        }
        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {
            Common.Comm.Logger.SetConfigLogger("Practice");
            Common.Comm.Logger.Info(System.Reflection.MethodBase.GetCurrentMethod(), "Practice Start!");

            this.m_Timer = new Timer();
            this.m_Timer.Interval = 20000;
            this.m_Timer.Tick += this.timer_Tick;
            this.m_Timer.Start();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// 메뉴에서 선택된 폼의 존재여부를 확인
        /// </summary>
        /// <param name="activeForm"></param>
        /// <returns></returns>
        private bool vaildMdiChild(Form activeForm)
        {
            bool mdiChild = true;

            for (int cnt = 0; cnt < this.MdiChildren.Length; cnt++)
            {
                string fromName = this.MdiChildren[cnt].Name;

                if (fromName.Equals(activeForm.Name))
                {
                    mdiChild = false;
                    this.MdiChildren[cnt].WindowState = FormWindowState.Maximized;
                    this.MdiChildren[cnt].Focus();
                    break;
                }
            }

            return mdiChild;
        }

        private void ShowFormORClose(Form aActiveForm)
        {
            if (aActiveForm != null)
            {
                if (this.vaildMdiChild(aActiveForm))
                {
                    aActiveForm.MdiParent = this;
                    aActiveForm.WindowState = FormWindowState.Maximized;
                    aActiveForm.Show();
                }
                else
                {
                    aActiveForm.Close();
                }
            }
        }

        private void ShowNotify()
        {
            Common.Control.Toast.frmNotify nw;

            nw = new Common.Control.Toast.frmNotify("Toast 알림", "TEST");
            nw.TitleClicked += new System.EventHandler(titleClick);
            nw.TextClicked += new System.EventHandler(textClick);
            nw.SetDimensions(150, 100);
            nw.WaitTime = 5000;

            nw.Notify();
        }
        #endregion 6.Method


        #region 7.Event
        private void titleClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Title text clicked");
        }

        private void textClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Text clicked");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            this.ShowNotify();

            //if (timer.Interval < m_Delay)
            //{
            //    timer.Interval = m_Delay;
            //}
        }

        private void barBtnShowDataGridView_Click(object sender, EventArgs e)
        {
            RibbonButton btn = sender as RibbonButton;

            if (btn.Equals(this.barBtnShowDataGridView))
            {
                FrmDataGridView scnDataGridView = new FrmDataGridView();
                this.ShowFormORClose(scnDataGridView);
            }
            else if (btn.Equals(this.barBtnGetSlnCodeLine))
            {
                FrmGetSlnCodeLine scnGetSlnCodeLine = new FrmGetSlnCodeLine();
                this.ShowFormORClose(scnGetSlnCodeLine);
            }
            else if (btn.Equals(this.barBtnImageViewer))
            {
                FrmImageViewer scnImageViewer = new FrmImageViewer();
                this.ShowFormORClose(scnImageViewer);
            }
            else if (btn.Equals(this.barBtnScrollingText))
            {
                FrmScrollingText scnScrollingText = new FrmScrollingText();
                this.ShowFormORClose(scnScrollingText);
            }
            else if (btn.Equals(this.barBtnTextToSpeech))
            {
                FrmTextToSpeech scnTextToSpeech = new FrmTextToSpeech();
                this.ShowFormORClose(scnTextToSpeech);
            }
            else if (btn.Equals(this.barBtnColorSpoid))
            {
                Common.Control.ColorSpoid.FrmColorSpoid scnFrmColorSpoid = new Common.Control.ColorSpoid.FrmColorSpoid();
                scnFrmColorSpoid.WindowState = FormWindowState.Maximized;
                this.ShowFormORClose(scnFrmColorSpoid);
            }
            else if (btn.Equals(this.barBtnJson))
            {
                FrmJson scnTextToSpeech = new FrmJson();
                this.ShowFormORClose(scnTextToSpeech);
            }
        }
        #endregion 7.Event
    }
}
