using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LHJ.Common.Definition;
using LHJ.DBService;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace LHJ.Controls
{
    /// <summary>
    /// 상위 헤더 클래스
    /// </summary>
    internal class BandHeader
    {
        int startCol;
        /// <summary>
        /// 시작 컬럼 위치
        /// </summary>
        internal int StartCol
        {
            get { return startCol; }
            set { this.startCol = value; }
        }
        int endCol;
        /// <summary>
        /// 종료 컬럼 위치
        /// </summary>
        internal int EndCol
        {
            get { return this.endCol; }
            set { this.endCol = value; }
        }
        internal string Text { get; set; }

        internal bool Contains(int col)
        {
            return this.startCol <= col && this.endCol >= col;
        }
    }

    /// <summary>
    /// 1.Cell Row Number 표시
    /// 2.엑셀 출력
    /// 3.엑셀 입력받아 DataSet 반환
    /// 4.ProgressBar Column 클래스 추가
    /// </summary>
    public class ucDataGridView : DataGridView
    {
        #region 1.Variable
        private bool mShowRowHeaderValue = true;
        private bool mPaging = false;
        private int mPagingRowCount = 150;
        private Pen blackPen = new Pen(Color.Gray);
        private List<BandHeader> mBandHeaderList = new List<BandHeader>();
        #endregion 1.Variable


        #region 2.Property

        /// <summary>
        /// DataGridView 의 RowHeader Columns에 Row Number 표시여부를 설정한다.
        /// </summary>
        public bool ShowRowHeaderValue
        {
            get { return this.mShowRowHeaderValue; }
            set { this.mShowRowHeaderValue = value; }
        }

        public bool Paging
        {
            get { return this.mPaging; }
            set { this.mPaging = value; }
        }

        public int PagingRowCount
        {
            get 
            {
                if (this.mPaging)
                {
                    return this.mPagingRowCount;
                }
                else
                {
                    return 0;
                }
            }
            set { this.mPagingRowCount = value; }
        }

        #endregion 2.Property


        #region 3.Constructor
        public ucDataGridView()
        {
            //this.SetInitialize();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        /// <summary>
        /// RowHeader 에 Row Number 표시
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            if (this.mShowRowHeaderValue)
            {
                string rowIdx = (e.RowIndex + 1).ToString();
                Font font = new Font(Font.Name, (float)8.0);

                Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, RowHeadersWidth, e.RowBounds.Height);
                StringFormat centerFormat = new StringFormat();
                centerFormat.Alignment = StringAlignment.Center;
                centerFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(rowIdx, font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            foreach (var highHeader in this.mBandHeaderList)
            {
                int startCol = highHeader.StartCol;
                int endCol = highHeader.EndCol;

                Rectangle rect = this.GetHeaderRectangle(startCol);

                int width = 0;

                for (int i = startCol; i <= endCol; i++)
                {
                    width += this.Columns[i].Width;
                }

                rect.Height = (rect.Height / 2);
                rect.Width = width;

                e.Graphics.FillRectangle(new SolidBrush(this.ColumnHeadersDefaultCellStyle.BackColor), rect);
                e.Graphics.DrawRectangle(blackPen, rect);
                e.Graphics.DrawString(highHeader.Text,
                    this.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor),
                    rect,
                    format);
            }
        }
        #endregion 4.Override Method


        #region 5.Set Initialize

        /// <summary>
        /// Set Initialize
        /// </summary>
        public void InitializeBandHeader()
        {
            this.ColumnWidthChanged += MultiHeaderGrid_ColumnWidthChanged;
            this.HorizontalScrollBar.Scroll += HorizontalScrollBar_Scroll;
            this.CellPainting += MultiHeaderGrid_CellPainting;

            foreach (DataGridViewColumn col in this.Columns)
            {
                col.HeaderCell.Style.ForeColor = Color.Gray;
                col.HeaderCell.Style.BackColor = Color.Red;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AllowUserToResizeColumns = true;
            this.ColumnHeadersHeight = 46;

            base.DoubleBuffered = true;
        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// Header의 영역을 가져옵니다.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private Rectangle GetHeaderRectangle(int col)
        {
            int x = this.RowHeadersWidth - this.HorizontalScrollBar.Value;
            //int x = this.Left + this.RowHeadersWidth - this.HorizontalScrollBar.Value;

            for (int i = 0; i < col; i++)
            {
                x += this.Columns[i].Width;
            }

            return new Rectangle(new Point(x, 1), this.Columns[col].HeaderCell.Size);
        }

        public void AddHighHeader(int startCol, int endCol, string text)
        {
            this.InitializeBandHeader();

            mBandHeaderList.Add(new BandHeader() { StartCol = startCol, EndCol = endCol, Text = text });

            for (int i = startCol; i <= endCol; i++)
            {
                this.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
        }

        /// <summary>
        /// 가로 스크롤을 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;
            rtHeader.Height = this.ColumnHeadersHeight;
            this.Invalidate(rtHeader);
        }

        /// <summary>
        /// Cell을 그릴때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MultiHeaderGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                bool isContains = false;

                foreach (var highHeader in this.mBandHeaderList)
                {
                    isContains = highHeader.Contains(e.ColumnIndex);
                    if (isContains == true)
                        break;
                }

                //보더 그리기
                Rectangle r = e.CellBounds;

                r.X -= 1;
                r.Y -= 1;
                r.Height -= 1;

                e.PaintBackground(r, true);
                e.PaintContent(r);
                e.Graphics.DrawRectangle(blackPen, r);

                e.Handled = true;
            }
        }

        /// <summary>
        /// 컬럼의 가로가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MultiHeaderGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;
            rtHeader.Height = this.ColumnHeadersHeight / 2;
            this.Invalidate(rtHeader);
        }

        public void SetDataSource(string aQuery)
        {
            this.DataSource = Common.Comm.DBWorker.ExecuteDataTable(aQuery);
        }

        public void SetDataSource(string aQuery, int aStartIndex, int aMaxIndex, string aSrcTable)
        {
            this.DataSource = Common.Comm.DBWorker.ExecuteDataTable(aQuery, aStartIndex, aMaxIndex, aSrcTable, null);
        }
        /// <summary>
        ///    Excel 파일의 형태를 반환한다.
        ///    -2 : Error  
        ///    -1 : 엑셀파일아님
        ///     0 : 97-2003 엑셀 파일 (xls)
        ///     1 : 2007 이상 파일 (xlsx)
        /// </summary>
        /// <param name="aXlsFile">
        ///    Excel File 명 전체 경로입니다.
        /// </param>
        public static int ExcelFileType(string aXlsFile)
        {
            byte[,] ExcelHeader = {
                { 0xD0, 0xCF, 0x11, 0xE0, 0xA1 }, // XLS  File Header
                { 0x50, 0x4B, 0x03, 0x04, 0x14 }  // XLSX File Header
            };

            // result -2=error, -1=not excel , 0=xls , 1=xlsx
            int result = -1;

            FileInfo FI = new FileInfo(aXlsFile);
            FileStream FS = FI.Open(FileMode.Open);

            try
            {
                byte[] FH = new byte[5];

                FS.Read(FH, 0, 5);

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (FH[j] != ExcelHeader[i, j]) break;
                        else if (j == 4) result = i;
                    }
                    if (result >= 0) break;
                }
            }
            catch
            {
                result = (-2);
                //throw e;
            }
            finally
            {
                FS.Close();
            }
            return result;
        }

        /// <summary>
        ///    Excel 파일을 DataSet 으로 변환하여 반환한다.
        /// </summary>
        /// <param name="FileName">
        ///    Excel File 명 PullPath
        /// </param>
        /// <param name="UseHeader">
        ///    첫번째 줄을 Field 명으로 사용할 것이지 여부
        /// </param>
        public DataSet OpenExcel(string FileName, bool UseHeader)
        {
            DataSet DS = null;

            string[] HDROpt = { "NO", "YES" };
            string HDR = "";
            string ConnStr = "";

            if (UseHeader)
                HDR = HDROpt[1];
            else
                HDR = HDROpt[0];

            int ExcelType = ExcelFileType(FileName);

            switch (ExcelType)
            {
                case (-2): throw new Exception(FileName + "의 형식검사중 오류가 발생하였습니다.");
                case (-1): throw new Exception(FileName + "은 엑셀 파일형식이 아닙니다.");
                case (0):
                    ConnStr = string.Format(ConstValue.ConnectStrExcel97_2003, FileName, HDR, "1");
                    break;
                case (1):
                    ConnStr = string.Format(ConstValue.ConnectStrExcel, FileName, HDR, "1");
                    break;
            }

            OleDbConnection OleDBConn = null;
            OleDbDataAdapter OleDBAdap = null;
            DataTable Schema;

            try
            {
                OleDBConn = new OleDbConnection(ConnStr);
                OleDBConn.Open();

                Schema = OleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                DS = new DataSet();

                foreach (DataRow DR in Schema.Rows)
                {
                    OleDBAdap = new OleDbDataAdapter(DR["TABLE_NAME"].ToString(), OleDBConn);

                    OleDBAdap.SelectCommand.CommandType = CommandType.TableDirect;
                    OleDBAdap.AcceptChangesDuringFill = false;

                    string TableName = DR["TABLE_NAME"].ToString().Replace("$", String.Empty).Replace("'", String.Empty);

                    if (DR["TABLE_NAME"].ToString().Contains("$")) OleDBAdap.Fill(DS, TableName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (OleDBConn != null) OleDBConn.Close();
            }

            return DS;
        }

        //엑셀 컬럼명 A~Z 보다 많을경우..AA AB AC..BA BB BC..붙여주기
        public static String translateColumnIndexToName(int index)
        {
            int quotient = (index) / 26;

            if (quotient > 0)
            {
                return translateColumnIndexToName(quotient - 1) + (char)((index % 26) + 65);
            }
            else
            {
                return "" + (char)((index % 26) + 65);
            }
        }

        /// <summary>
        /// 조회한 내용 엑셀파일 출력
        /// </summary>
        public void ExportToExcel(string aTitle)
        {
            try
            {
                if (this.Rows.Count < 1)
                {
                    MessageBox.Show("엑셀로 저장할 내용이 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                RegistryKey rkHKCR = Registry.ClassesRoot;
                RegistryKey rkExcelKey = rkHKCR.OpenSubKey(ConstValue.REGISTRY_EXCEL_KEY);
                bool bExcelInstalled = (rkExcelKey == null ? false : true);

                if (!bExcelInstalled)
                {
                    MessageBox.Show("엑셀이 설치된 PC에서만 저장이 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();

                sfd.FileName = aTitle + "_" + DateTime.Today.ToString("yyyy-MM-dd");
                sfd.DefaultExt = "xls";
                sfd.Filter = "Excel files (*.xls)|*.xls";
                sfd.InitialDirectory = "C:\\";

                DialogResult result = sfd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    int num = 0;
                    object missingType = Type.Missing;

                    Excel.Application objApp;
                    Excel._Workbook objBook;
                    Excel.Workbooks objBooks;
                    Excel.Sheets objSheets;
                    Excel._Worksheet objSheet;
                    Excel.Range range;

                    string[] headers = new string[this.ColumnCount];
                    string[] columns = new string[this.ColumnCount];

                    for (int c = 0; c < this.ColumnCount; c++)
                    {
                        headers[c] = this.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();

                        int quotient = (c) / 26;

                        if (quotient > 0)
                        {
                            columns[c] = Convert.ToString(translateColumnIndexToName(quotient - 1) + (char)((c % 26) + 65));
                        }
                        else
                        {
                            columns[c] = Convert.ToString((char)((c % 26) + 65));
                        }
                    }

                    objApp = new Excel.Application();
                    objBooks = objApp.Workbooks;
                    objBook = objBooks.Add(Missing.Value);
                    objSheets = objBook.Worksheets;
                    objSheet = (Excel._Worksheet)objSheets.get_Item(1);

                    for (int c = 0; c < this.ColumnCount; c++)
                    {
                        range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                        range.set_Value(Missing.Value, headers[c]);
                    }

                    for (int i = 0; i < this.RowCount - 1; i++)
                    {
                        for (int j = 0; j < this.ColumnCount; j++)
                        {
                            range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2),
                                                                   Missing.Value);
                            range.set_Value(Missing.Value, this.Rows[i].Cells[j].Value.ToString());
                        }
                    }

                    objApp.Visible = false;
                    objApp.UserControl = false;

                    objBook.SaveAs(sfd.FileName,
                              Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                              missingType, missingType, missingType, missingType,
                              Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                              missingType, missingType, missingType, missingType, missingType);

                    objBook.Close(false, missingType, missingType);

                    MessageBox.Show("엑셀 저장 완료!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AutoResizeColumn()
        {
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (i != 0 || i != 1)
                {
                    this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int intWidth = this.Columns[i].Width;
                    this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    this.Columns[i].Width = intWidth;
                }
            }
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event

        public class DataGridViewProgressColumn : DataGridViewImageColumn
        {
            public DataGridViewProgressColumn()
            {
                CellTemplate = new DataGridViewProgressCell();
            }
        }

        private class DataGridViewProgressCell : DataGridViewImageCell
        {
            // Used to make custom cell consistent with a DataGridViewImageCell
            static System.Drawing.Image emptyImage;
            static DataGridViewProgressCell()
            {
                emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
            public DataGridViewProgressCell()
            {
                this.ValueType = typeof(int);
            }
            // Method required to make the Progress Cell consistent with the default Image Cell.
            // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
            protected override object GetFormattedValue(object value,
                                int rowIndex, ref DataGridViewCellStyle cellStyle,
                                System.ComponentModel.TypeConverter valueTypeConverter,
                                System.ComponentModel.TypeConverter formattedValueTypeConverter,
                                DataGridViewDataErrorContexts context)
            {
                return emptyImage;
            }

            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                int progressVal = 0;

                if (value != null)
                {
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        progressVal = 0;
                    }
                    else
                    {
                        progressVal = Convert.ToInt32(value.ToString());
                    }
                }

                float percentage = ((float)progressVal / 100.0f); // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.
                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                // Draws the cell grid
                base.Paint(g, clipBounds, cellBounds,
                 rowIndex, cellState, value, formattedValue, errorText,
                 cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                if (percentage > 0.0)
                {
                    // Draw the progress bar and the text
                    g.FillRectangle(new SolidBrush(Color.FromArgb(163, 189, 242)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                    g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + cellBounds.Size.Width / 2 - 12, cellBounds.Y + 5);
                }
                else
                {
                    // draw the text
                    if (this.DataGridView.CurrentRow != null)
                    {
                        if (this.DataGridView.CurrentRow.Index == rowIndex)
                            g.DrawString(progressVal.ToString() + "%", cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + cellBounds.Size.Width / 2 - 12, cellBounds.Y + 5);
                        else
                            g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + cellBounds.Size.Width / 2 - 12, cellBounds.Y + 5);
                    }
                }   //"cellBounds.X + cellBounds.Size.Width / 2 - 12"로 수정 원래 "cellBounds.X + 6"임
            }
        }
    }
}