using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.DBService;

namespace LHJ.DBViewer
{
    public partial class frmMain : Form
    {
        private static string mBtn;
        private ToolStripButton mTsBtnSqlWindow = new ToolStripButton();
        private ToolStripButton mTsBtnSessionView = new ToolStripButton();

        public frmMain()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            InitializeComponent();

            this.toolStrip2.Renderer = new MyRenderer();

            mTsBtnSqlWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            mTsBtnSqlWindow.Text = "SQL Window";

            mTsBtnSessionView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            mTsBtnSessionView.Text = "Session 조회";

            this.toolStrip2.Items.Add(mTsBtnSqlWindow);
            this.toolStrip2.Items.Add(mTsBtnSessionView);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string sMethodNm = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string meessage = "프로그램에 문제가 있어 비 정상적으로 종료 되었습니다.\n" +
                             "아래 내용을 개발자에게 전달 바랍니다.\nquizgb@naver.com\n\n\n";
            string[] call_stacks;

            Exception exc = (Exception)e.ExceptionObject;

            call_stacks = exc.StackTrace.Split(new string[] { "\r\n" },
                                  StringSplitOptions.RemoveEmptyEntries);

            meessage += "■ Error:\n    " + exc.Message + "\n\n";
            meessage += "■ Location:\n"; ;

            foreach (string line in call_stacks)
            {
                if (line.Contains(".cs"))
                {
                    meessage += line + "\n\n";
                }
            }

            MessageBox.Show(meessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(101); //오류 보고 다이얼로그 표시하지 않고 종료 시키기 for WINDOWS 7
        }

        private void SetOracleVersionLabel()
        {
            DataTable dt = DALDataAccess.GetOracleVersion();

            if (dt.Rows.Count > 0)
            {
                this.tsslOracleVersion.Text = dt.Rows[0][0].ToString();
            }
        }

        private void ShowLoginForm()
        {
            frmLogin loginFrm = new frmLogin();
            loginFrm.ShowDialog();

            if (Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                this.SetOracleVersionLabel();

                frmSQLWindow window = new frmSQLWindow();
                this.ShowFormORClose(window);
                this.mTsBtnSqlWindow.Checked = true;
            }
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                ToolStripButton tsBtn = e.Item as ToolStripButton;

                if (tsBtn != null && tsBtn.Checked)
                {
                    foreach (ToolStripButton btn in tsBtn.GetCurrentParent().Items)
                    {
                        if (!btn.Equals(tsBtn))
                        {
                            btn.Invalidate();
                        }
                    }

                    e.Graphics.DrawRectangle(Pens.Black, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                }
                else
                {
                    base.OnRenderButtonBackground(e);
                }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void ShowFormORClose(Form aActiveForm)
        {
            if (aActiveForm != null)
            {
                if (this.vaildMdiChild(aActiveForm))
                {
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

        private void tsBtn_Click(object sender, MouseEventArgs e)
        {
            ToolStripButton tsBtn = sender as ToolStripButton;
            tsBtn.Checked = true;

            foreach (ToolStripButton abtn in tsBtn.GetCurrentParent().Items)
            {
                if (!abtn.Equals(tsBtn))
                {
                    abtn.Checked = false;
                }
            }

            if (tsBtn.Equals(this.mTsBtnSqlWindow))
            {
                frmSQLWindow window = new frmSQLWindow();
                this.ShowFormORClose(window);
            }
            else if (tsBtn.Text.Equals("Schema Browser"))
            {
                frmSchemaBrowser browser = new frmSchemaBrowser();
                this.ShowFormORClose(browser);
            }
            else if (tsBtn.Equals(this.mTsBtnSessionView))
            {
                frmSessionView sessionView = new frmSessionView();
                this.ShowFormORClose(sessionView);
            }
        }
    }
}
