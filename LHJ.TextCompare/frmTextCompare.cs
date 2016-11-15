using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LHJ.TextCompare.TextDiff;
using LHJ.TextCompare.UsrControl;

namespace LHJ.TextCompare
{
    public partial class frmTextCompare : Form
    {
        #region 1.Variable
        private DiffListText _sorurceText = (DiffListText)null;
        private DiffListText _destText = (DiffListText)null;
        private bool _inputData = false;
        private bool _ignoreEvent = false;
        private Bitmap _bmpNavigator = (Bitmap)null;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmTextCompare()
        {
            InitializeComponent();
        }
        #endregion 3.Constructor


        #region 4.Override Method
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetInitialize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.pnlSource.Width = (this.Width + this.pbxNavigator.Width) / 2;
        }
        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {
            this.tsLblSource.Text = this.tsLblDest.Text = string.Empty;

            if (!this._inputData)
            {
                return;
            }

            this.btnVisible.PerformClick();
            this.btnCompare.PerformClick();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void ShowDiff(DiffListText source, DiffListText destination, ArrayList DiffLines)
        {
            this.lvSource.SuspendLayout();
            this.lvDestination.SuspendLayout();
            this.pbxNavigator.Image = (Image)null;
            Color color1 = Color.FromArgb((int)byte.MaxValue, 175, 238, 238);
            Color color2 = Color.FromArgb((int)byte.MaxValue, 152, 251, 152);
            Color color3 = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 192, 203);
            int num = 1;
            foreach (DiffResultSpan diffLine in DiffLines)
            {
                switch (diffLine.Status)
                {
                    case DiffResultSpanStatus.NoChange:
                        for (int index = 0; index < diffLine.Length; ++index)
                        {
                            this.lvSource.Items.Add(new ListViewItem(num.ToString())
                            {
                                SubItems = {
                  ((TextLine) source.GetByIndex(diffLine.SourceIndex + index)).Line
                }
                            });
                            this.lvDestination.Items.Add(new ListViewItem(num.ToString())
                            {
                                SubItems = {
                  ((TextLine) destination.GetByIndex(diffLine.DestIndex + index)).Line
                }
                            });
                            ++num;
                        }
                        break;
                    case DiffResultSpanStatus.Replace:
                        this.lbxChangedLine.Items.Add(num.ToString());

                        for (int index = 0; index < diffLine.Length; ++index)
                        {
                            ListViewItem listViewItem1 = new ListViewItem(num.ToString());
                            listViewItem1.SubItems.Add(((TextLine)source.GetByIndex(diffLine.SourceIndex + index)).Line);
                            this.lvSource.Items.Add(listViewItem1);
                            ListViewItem listViewItem2 = new ListViewItem(num.ToString());
                            listViewItem2.SubItems.Add(((TextLine)destination.GetByIndex(diffLine.DestIndex + index)).Line);
                            this.lvDestination.Items.Add(listViewItem2);
                            listViewItem1.BackColor = listViewItem2.BackColor = color2;
                            ++num;
                        }
                        break;
                    case DiffResultSpanStatus.DeleteSource:
                        this.lbxChangedLine.Items.Add(num.ToString());

                        for (int index = 0; index < diffLine.Length; ++index)
                        {
                            ListViewItem listViewItem1 = new ListViewItem(num.ToString());
                            listViewItem1.SubItems.Add(((TextLine)source.GetByIndex(diffLine.SourceIndex + index)).Line);
                            this.lvSource.Items.Add(listViewItem1);
                            ListViewItem listViewItem2 = new ListViewItem(num.ToString());
                            listViewItem2.SubItems.Add("");
                            this.lvDestination.Items.Add(listViewItem2);
                            listViewItem1.BackColor = listViewItem2.BackColor = color3;
                            ++num;
                        }
                        break;
                    case DiffResultSpanStatus.AddDestination:
                        this.lbxChangedLine.Items.Add(num.ToString());

                        for (int index = 0; index < diffLine.Length; ++index)
                        {
                            ListViewItem listViewItem1 = new ListViewItem(num.ToString());
                            listViewItem1.SubItems.Add("");
                            this.lvSource.Items.Add(listViewItem1);
                            ListViewItem listViewItem2 = new ListViewItem(num.ToString());
                            listViewItem2.SubItems.Add(((TextLine)destination.GetByIndex(diffLine.DestIndex + index)).Line);
                            this.lvDestination.Items.Add(listViewItem2);
                            listViewItem1.BackColor = listViewItem2.BackColor = color1;
                            ++num;
                        }
                        break;
                }
            }
            this.lvSource.ResumeLayout();
            this.lvDestination.ResumeLayout();
            this.lvSource.Scrollable = true;
            this.lvDestination.Scrollable = true;
            ++this.lvSource.Columns[0].Width;
            --this.lvSource.Columns[0].Width;
            ++this.lvDestination.Columns[0].Width;
            --this.lvDestination.Columns[0].Width;
            this.CreateNavigatorBitmap();
        }

        private void CreateNavigatorBitmap()
        {
            if (this.lvSource.Items.Count == 0 || this.lvSource.TopItem == null)
                return;
            double num = (double)(this.pbxNavigator.Height - 4) / ((double)this.lvSource.Items.Count + 0.0);
            Bitmap bitmap = new Bitmap(this.pbxNavigator.Width, this.pbxNavigator.Height);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            graphics.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
            for (int index = 0; index < this.lvSource.Items.Count; ++index)
            {
                if (!(this.lvSource.Items[index].BackColor == SystemColors.Window))
                    graphics.FillRectangle((Brush)new SolidBrush(this.lvSource.Items[index].BackColor), 0.0f, (float)num * (float)(index + 1), (float)bitmap.Width, (float)num);
            }
            this._bmpNavigator = bitmap;
            this.ShowNavigatorBitmap();
        }

        private void ShowNavigatorBitmap()
        {
            if (this._bmpNavigator == null)
                return;
            double num1 = (double)(this.pbxNavigator.Height - 4) / ((double)this.lvSource.Items.Count + 0.0);
            Bitmap bitmap = new Bitmap((Image)this._bmpNavigator);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            float y = (float)(this.lvSource.TopItem.Index + 1) * (float)num1;
            float num2 = (float)(this.lvSource.GetVisibleRowCount() + 2) * (float)num1;
            graphics.DrawRectangle(Pens.Orange, 1f, y, (float)(bitmap.Width - 3), (double)y + (double)num2 >= (double)bitmap.Height ? (float)((double)bitmap.Height - (double)y - 1.0) : num2);
            this.pbxNavigator.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbxNavigator.Image = (Image)bitmap;
        }

        private void ChangeListViewSource()
        {
            if (this.lvSource.TopItem == null || this.lvDestination.TopItem == null)
                return;
            int num = 0;
            while (this.lvSource.TopItem.Index != this.lvDestination.TopItem.Index && num++ < 10)
                this.lvDestination.TopItem = this.lvDestination.Items[this.lvSource.TopItem.Index];
            this.ShowNavigatorBitmap();
        }

        private void ChangeListViewDestination()
        {
            if (this.lvSource.TopItem == null || this.lvDestination.TopItem == null)
                return;
            int num = 0;
            while (this.lvDestination.TopItem.Index != this.lvSource.TopItem.Index && num++ < 10)
                this.lvSource.TopItem = this.lvSource.Items[this.lvDestination.TopItem.Index];
            this.ShowNavigatorBitmap();
        }
        #endregion 6.Method


        #region 7.Event
        private void btnCompare_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Equals(this.btnCompare))
                {
                    this.lbxChangedLine.Items.Clear();

                    this.tsLblSource.Text = this.tsLblDest.Text = "";

                    string pText1 = this.ucCompareSelectSource.GetString();
                    string pText2 = this.ucCompareSelectDestination.GetString();

                    if (string.IsNullOrEmpty(pText1))
                    {
                        this.gbxSource.Visible = this.gbxDest.Visible = true;
                        this.pnlCompareInfo.Visible = !this.gbxSource.Visible;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(pText2))
                        {
                            this.gbxSource.Visible = this.gbxDest.Visible = true;
                            this.pnlCompareInfo.Visible = !this.gbxSource.Visible;
                        }
                        else
                        {
                            this.tsLblSource.Text = this.ucCompareSelectSource.GetTitle();
                            this.tsLblDest.Text = this.ucCompareSelectDestination.GetTitle();

                            this._sorurceText = new DiffListText(pText1);
                            this._destText = new DiffListText(pText2);

                            this.lvSource.Items.Clear();
                            this.lvDestination.Items.Clear();

                            DiffEngine diffEngine = new DiffEngine();
                            DiffEngineLevel level = !this.rbtnFast.Checked ? (!this.rbtnMedium.Checked ? DiffEngineLevel.SlowPerfect : DiffEngineLevel.Medium) : DiffEngineLevel.FastImperfect;

                            diffEngine.ProcessDiff((IDiffList)this._sorurceText, (IDiffList)this._destText, level);
                            this.ShowDiff(this._sorurceText, this._destText, diffEngine.DiffReport());
                            this.gbxSource.Visible = this.gbxDest.Visible = false;
                            this.pnlCompareInfo.Visible = !this.gbxSource.Visible;
                        }
                    }
                }
                else if (btn.Equals(this.btnVisible))
                {
                    this.gbxSource.Visible = this.gbxDest.Visible = !this.gbxSource.Visible;
                    this.pnlCompareInfo.Visible = !this.gbxSource.Visible;
                }
                else if (btn.Equals(this.btnClose))
                {
                    this.Close();
                }
            }
        }

        private void pbxNavigator_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.pbxNavigator.Image == null || this.lvSource.Items.Count == 0)
            {
                return;
            }

            ListViewItem topItem = this.lvSource.TopItem;

            for (int index = this.lvSource.TopItem.Index + 1; index < this.lvSource.Items.Count; ++index)
            {
                Rectangle rectangle = this.lvSource.ClientRectangle;
                int top1 = rectangle.Top;
                rectangle = this.lvSource.ClientRectangle;
                int height1 = rectangle.Height;
                int num1 = top1 + height1;
                rectangle = this.lvSource.Items[index].Bounds;
                int top2 = rectangle.Top;
                rectangle = this.lvSource.Items[index].Bounds;
                int height2 = rectangle.Height;
                int num2 = top2 + height2;

                if (num1 < num2)
                {
                    topItem = this.lvSource.Items[index - 1];
                    break;
                }
            }

            int visibleRowCount = this.lvSource.GetVisibleRowCount();
            int num3 = 0;

            if (visibleRowCount != 0)
            {
                num3 = visibleRowCount / 2;
            }

            double num4 = (double)(this.pbxNavigator.Height - 4) / ((double)this.lvSource.Items.Count + 0.0);
            int index1 = (int)((double)e.Y / num4) - num3;

            if (index1 < 0)
            {
                this.lvSource.TopItem = this.lvSource.Items[0];
            }
            else if (index1 > this.lvSource.Items.Count - 1)
            {
                this.lvSource.TopItem = this.lvSource.Items[this.lvSource.Items.Count - 1];
            }
            else
            {
                this.lvSource.TopItem = this.lvSource.Items[index1];
            }

            while (this.lvSource.TopItem.Index != this.lvDestination.TopItem.Index)
            {
                this.lvDestination.TopItem = this.lvDestination.Items[this.lvSource.TopItem.Index];
            }

            this.ShowNavigatorBitmap();
        }

        private void lvSource_SizeChanged(object sender, EventArgs e)
        {
            if (this.Disposing)
                return;

            this.CreateNavigatorBitmap();
        }

        private void lvSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._ignoreEvent || this.lvSource.SelectedItems.Count == 0)
            {
                return;
            }

            this._ignoreEvent = true;

            this.lvDestination.SelectedItems.Clear();
            this.lvDestination.Items[this.lvSource.SelectedItems[0].Index].Selected = true;

            this._ignoreEvent = false;

            this.ChangeListViewSource();
        }

        private void lvDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._ignoreEvent || this.lvDestination.SelectedItems.Count == 0)
            {
                return;
            }
            this._ignoreEvent = true;

            this.lvSource.SelectedItems.Clear();
            this.lvSource.Items[this.lvDestination.SelectedItems[0].Index].Selected = true;

            this._ignoreEvent = false;

            this.ChangeListViewDestination();
        }

        private void lvSource_VScroll(object sender, ScrollEventArgs e)
        {
            this.ChangeListViewSource();
        }

        private void lvDestination_VScroll(object sender, ScrollEventArgs e)
        {
            this.ChangeListViewDestination();
        }

        private void lvSource_KeyUp(object sender, KeyEventArgs e)
        {
            this.ChangeListViewSource();
        }

        private void lvDestination_KeyUp(object sender, KeyEventArgs e)
        {
            this.ChangeListViewDestination();
        }
        #endregion 7.Event

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvSource.TopItem = this.lvSource.Items[Convert.ToInt32(this.lbxChangedLine.SelectedItems[0].ToString()) - 1];
            this.lvDestination.TopItem = this.lvDestination.Items[Convert.ToInt32(this.lbxChangedLine.SelectedItems[0].ToString()) - 1];
            this.CreateNavigatorBitmap();
        }
    }
}
