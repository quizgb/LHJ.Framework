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
        public FrmDataGridView()
        {
            InitializeComponent();

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
        }
    }
}
