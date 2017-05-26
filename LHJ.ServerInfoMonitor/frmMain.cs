using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.ServerInfoMonitor
{
    public partial class frmMain : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
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
            this.SetLastBuildDate();
            this.Icon = Properties.Resources._1495533426_lcd_monitor1;
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetLastBuildDate()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

            this.tsslLastBulidDate.Text = " [Last Build : " + buildDate.ToString("yyyy-MM-dd") + "]";
        }

        private void ShowFormORClose(Form aActiveForm)
        {
            if (aActiveForm != null)
            {
                if (this.vaildMdiChild(aActiveForm))
                {
                    aActiveForm.FormClosing += this.MdiChildFormClosing;
                    aActiveForm.MdiParent = this;
                    aActiveForm.Show();
                }
                else
                {
                    aActiveForm.Close();
                }
            }
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
                    this.MdiChildren[cnt].Focus();
                    break;
                }
            }

            return mdiChild;
        }
        #endregion 6.Method


        #region 7.Event
        private void MdiChildFormClosing(object sender, FormClosingEventArgs e)
        {
            Form senderFrm = sender as Form;

            //if (senderFrm != null)
            //{
            //    Common.Definition.ConstValue.DBViewerFormType frmType = (Common.Definition.ConstValue.DBViewerFormType)senderFrm.Tag;

            //    if (frmType.Equals(Common.Definition.ConstValue.DBViewerFormType.SqlWindow))
            //    {
            //    }
            //}
        }


        private void tsbtnRDP_Click(object sender, EventArgs e)
        {
            ToolStripButton tsBtn = sender as ToolStripButton;

            if (tsBtn != null)
            {
                if (tsBtn.Equals(this.tsbtnRDP))
                {
                    frmRDPMain window = new frmRDPMain();
                    //window.Tag = Common.Definition.ConstValue.DBViewerFormType.SqlWindow;

                    this.ShowFormORClose(window);
                }
            }
        }
        #endregion 7.Event
    }
}
