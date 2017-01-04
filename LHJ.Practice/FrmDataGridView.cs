using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.Controls;

namespace LHJ.Practice
{
    public partial class FrmDataGridView : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public FrmDataGridView()
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
            DataSet ds = this.ucDataGridView1.OpenExcel(@"C:\Example.xls", true);
            //this.ucDataGridView1.DataSource = ds.Tables[0];

            ucDataGridView.DataGridViewProgressColumn column = new ucDataGridView.DataGridViewProgressColumn();

            this.ucDataGridView1.ColumnCount = 2;
            this.ucDataGridView1.Columns[0].Name = "TESTHeader1";
            this.ucDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ucDataGridView1.Columns[1].Name = "TESTHeader22";
            this.ucDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ucDataGridView1.Columns.Add(column);
            this.ucDataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.HeaderText = "Progress";


            object[] row1 = new object[] { "test1", "test2", 50 };
            object[] row2 = new object[] { "test1", "test2", 55 };
            object[] row3 = new object[] { "test1", "test2", 22 };
            object[] rows = new object[] { row1, row2, row3 };

            foreach (object[] row in rows)
            {
                this.ucDataGridView1.Rows.Add(row);
            }

            this.ucDataGridView1.AddHighHeader(0,1,"12");
        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
