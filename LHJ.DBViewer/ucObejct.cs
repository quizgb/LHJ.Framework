using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.DBService;
using LHJ.Common.Definition;

namespace LHJ.DBViewer
{
    public partial class ucObejct : UserControl
    {
        #region 1.Variable
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
         Description("아이템이 더블클릭될 때 발생됩니다.")]
        public event Common.Definition.EventHandler.ItemDoubleClickEventHandler ItemDoubleClicked;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ucObejct()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
            {
                return;
            }

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
            Common.Definition.EventHandler.SelectedUserChangedEventArgs e = new Common.Definition.EventHandler.SelectedUserChangedEventArgs(this.ucUserList1.User);
            this.ucUserList1_SelectedUserChanged(this.ucUserList1, e);
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetColumnInfo()
        {
            DataTable dt = DALDataAccess.GetTableColumns(Common.Comm.DBWorker.GetUserID().ToUpper(), this.lbxObject.Text);
            this.dgvColumnInfo.DataSource = dt;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.txtSearch.Text))
            {
                this.ucObjectList1_SelectedObjListChanged(this.ucObjectList1, new Common.Definition.EventHandler.SelectedObjListChangedEventArgs(string.Empty));
            }
            else
            {
                this.lbxObject.Items.Clear();
                DataTable dt = this.ucObjectList1.GetObjectListByObjectName(this.ucUserList1.User, this.txtSearch.Text);

                foreach (DataRow dr in dt.Rows)
                {
                    this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
                }

                this.SetColumnInfo();
                this.txtSearch.Focus();
            }
        }
        #endregion 6.Method


        #region 7.Event
        private void ucUserList1_SelectedUserChanged(object sender, Common.Definition.EventHandler.SelectedUserChangedEventArgs e)
        {
            this.lbxObject.Items.Clear();
            DataTable dt = this.ucObjectList1.GetObjectList(e.User);

            foreach (DataRow dr in dt.Rows)
            {
                this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
            }

            this.SetColumnInfo();
            this.txtSearch.Focus();
        }

        private void ucObjectList1_SelectedObjListChanged(object sender, Common.Definition.EventHandler.SelectedObjListChangedEventArgs e)
        {
            this.lbxObject.Items.Clear();
            DataTable dt = this.ucObjectList1.GetObjectList(this.ucUserList1.User);

            foreach (DataRow dr in dt.Rows)
            {
                this.lbxObject.Items.Add(dr["OBJECT_NAME"].ToString());
            }

            this.SetColumnInfo();
            this.txtSearch.Focus();
        }

        private void lbxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetColumnInfo();
        }

        private void lbxObject_DoubleClick(object sender, EventArgs e)
        {
            this.SetItemDoubleClicked(this.lbxObject.Text);
        }

        private void SetItemDoubleClicked(string aItemName)
        {
            if (ItemDoubleClicked != null)
            {
                Common.Definition.EventHandler.ItemDoubleClickEventArgs e = new Common.Definition.EventHandler.ItemDoubleClickEventArgs(aItemName);
                ItemDoubleClicked(this, e);
            }
        }

        private void dgvColumnInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SetItemDoubleClicked(this.dgvColumnInfo.GetRowCellStrValue(e.RowIndex, e.ColumnIndex));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                this.Search();
            }
        }

        private void dgvColumnInfo_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvColumnInfo.AutoResizeColumn();
        }
        #endregion 7.Event
    }
}
