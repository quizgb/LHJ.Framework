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
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LHJ.Common.Control.FrmSplash aa = new Common.Control.FrmSplash();
            aa.Show();
        }

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
        }
    }
}
