﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Common.Definition;
using LHJ.DBService;

namespace LHJ.DBViewer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Password))
            {
                this.cbxSavePassword.Checked = true;
                this.txtPassword.Text = Properties.Settings.Default.Password;
            }

            this.txtUsername.Text = Properties.Settings.Default.LastUsername;
            this.txtDatabase.Text = Properties.Settings.Default.LastDatabase;
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

            DBHelper.Connect(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim(), this.txtDatabase.Text.Trim());

            this.btnLogin.Enabled = true;
            this.Cursor = Cursors.Default;

            if (DBHelper.State.Equals(ConnectionState.Open))
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
            if (!DBHelper.State.Equals(ConnectionState.Open))
            {
                e.Cancel = true;
            }
        }
    }
}
