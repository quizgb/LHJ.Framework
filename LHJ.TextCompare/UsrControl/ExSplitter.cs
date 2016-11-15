using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.TextCompare.UsrControl
{
    internal class ExSplitter : Splitter
    {
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = Color.LightBlue;
            }
        }

        public new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = new Size(2, value.Height);
            }
        }

        public ExSplitter()
        {
            base.BackColor = Color.LightBlue;
            this.Width = 2;
        }
    }
}
