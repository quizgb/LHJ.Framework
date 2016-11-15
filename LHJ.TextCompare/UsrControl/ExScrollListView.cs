using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.TextCompare.UsrControl
{
    internal class ExScrollListView : ListView
    {
        private const int WM_HSCROLL = 276;
        private const int WM_VSCROLL = 277;
        private const int WM_MOUSEWHEEL = 522;

        public event ScrollEventHandler HScroll = null;
        public event ScrollEventHandler VScroll = null;

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);

            if (msg.Msg == WM_HSCROLL && this.HScroll != null)
                this.HScroll((object)this, new ScrollEventArgs(ScrollEventType.ThumbTrack, msg.WParam.ToInt32()));
            if (msg.Msg == WM_VSCROLL && this.VScroll != null)
                this.VScroll((object)this, new ScrollEventArgs(ScrollEventType.ThumbTrack, msg.WParam.ToInt32()));

            if (msg.Msg != WM_MOUSEWHEEL || this.VScroll == null)
                return;

            this.VScroll((object)this, new ScrollEventArgs(ScrollEventType.ThumbTrack, msg.WParam.ToInt32()));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control && e.KeyCode == Keys.C)
            {
                string text = string.Empty;

                foreach (ListViewItem selectedItem in this.SelectedItems)
                {
                    text = text + selectedItem.SubItems[1].Text + Environment.NewLine;
                }

                Clipboard.SetText(text);
            }

            //if (!e.Control || e.KeyCode != Keys.A)
            //{
            //    return;
            //}

            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem listViewItem in this.Items)
                {
                    listViewItem.Selected = true;
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Columns[1].Width = -2;
        }

        public int GetVisibleRowCount()
        {
            ListViewItem topItem = this.TopItem;

            for (int index = this.TopItem.Index + 1; index < this.Items.Count; ++index)
            {
                Rectangle rectangle = this.ClientRectangle;
                int top1 = rectangle.Top;
                rectangle = this.ClientRectangle;
                int height1 = rectangle.Height;
                int num1 = top1 + height1;
                rectangle = this.Items[index].Bounds;
                int top2 = rectangle.Top;
                rectangle = this.Items[index].Bounds;
                int height2 = rectangle.Height;
                int num2 = top2 + height2;
                if (num1 < num2)
                    return this.Items[index - 1].Index - this.TopItem.Index;
            }

            return this.Items[this.Items.Count - 1].Index - this.TopItem.Index;
        }
    }
}
