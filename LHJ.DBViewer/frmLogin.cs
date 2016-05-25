using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Common.Common.Com;
using LHJ.Common.Definition;
using LHJ.DBService;

namespace LHJ.DBViewer
{
    public partial class frmLogin : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmLogin()
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
            this.Icon = Properties.Resources._1464083802_key;

            Common.Comm.Logger.SetConfigLogger("DBViewer");
            Common.Comm.Logger.Info(System.Reflection.MethodBase.GetCurrentMethod(), "DBViewer Start!");

            this.CenterToParent();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Password))
            {
                this.cbxSavePassword.Checked = true;
                this.txtPassword.Text = Properties.Settings.Default.Password;
            }

            this.txtUsername.Text = Properties.Settings.Default.LastUsername;
            this.txtDatabase.Text = Properties.Settings.Default.LastDatabase;
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private bool CheckDataBeforeLogin()
        {
            if (string.IsNullOrEmpty(this.txtUsername.Text))
            {
                this.txtUsername.Focus();
                MessageBox.Show(this, "Username을 입력하세요.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.txtPassword.Focus();
                MessageBox.Show(this, "Password를 입력하세요.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDatabase.Text))
            {
                this.txtDatabase.Focus();
                MessageBox.Show(this, "Database를 입력하세요.", ConstValue.MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void DatabaseLogin()
        {
            if (!this.CheckDataBeforeLogin())
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.btnLogin.Enabled = false;

            Common.Comm.DBWorker.Open(this.txtDatabase.Text.Trim(), this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim());

            this.btnLogin.Enabled = true;
            this.Cursor = Cursors.Default;

            if (Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open))
            {
                if (this.cbxSavePassword.Checked)
                {
                    Properties.Settings.Default.Password = this.txtPassword.Text;
                }

                Properties.Settings.Default.LastUsername = this.txtUsername.Text;
                Properties.Settings.Default.LastDatabase = this.txtDatabase.Text;

                Properties.Settings.Default.Save();

                this.Close();
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Equals(this.btnLogin))
            {
                this.DatabaseLogin();
            }
            else if (btn.Equals(this.btnClose))
            {
                this.Close();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (tbx.Equals(this.txtUsername))
                {
                    this.txtPassword.Focus();
                }
                else if (tbx.Equals(this.txtPassword))
                {
                    this.txtDatabase.Focus();
                }
                else if (tbx.Equals(this.txtDatabase))
                {
                    this.btnLogin.PerformClick();
                }
            }
        }

        private void cbxSavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbxSavePassword.Checked)
            {
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Common.Comm.DBWorker.GetConnState().Equals(ConnectionState.Open) && !e.CloseReason.Equals(CloseReason.UserClosing))
            {
                e.Cancel = true;
            }
        }
        #endregion 7.Event
    }
}
