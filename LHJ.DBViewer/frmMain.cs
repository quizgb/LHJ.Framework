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

        public frmMain()
        {
            InitializeComponent();

            this.toolStrip2.Renderer = new MyRenderer();

            ToolStripButton tsBtn = new ToolStripButton();
            tsBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            tsBtn.Text = "SQL Window";

            this.toolStrip2.Items.Add(tsBtn);

            tsBtn = new ToolStripButton();
            tsBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsBtn_Click);
            tsBtn.Text = "Schema Browser";

            this.toolStrip2.Items.Add(tsBtn);
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
            loginFrm.Owner = this;

            loginFrm.ShowDialog();

            if (DBHelper.State.Equals(ConnectionState.Open))
            {
                this.SetOracleVersionLabel();
                frmSQLWindow window = new frmSQLWindow();
                this.ShowFormORClose(window);
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
            ToolStripButton aaa = sender as ToolStripButton;
            aaa.Checked = true;

            foreach (ToolStripButton abtn in aaa.GetCurrentParent().Items)
            {
                if (!abtn.Equals(aaa))
                {
                    abtn.Checked = false;
                }
            }

            if (aaa.Text.Equals("SQL Window"))
            {
                frmSQLWindow window = new frmSQLWindow();
                this.ShowFormORClose(window);
            }
            else if (aaa.Text.Equals("Schema Browser"))
            {
                frmSchemaBrowser browser = new frmSchemaBrowser();
                this.ShowFormORClose(browser);
            }
        }
    }
}
