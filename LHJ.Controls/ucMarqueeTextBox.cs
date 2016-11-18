using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace LHJ.Controls
{
    public enum Direction
    {
        Left,
        Right,
    }

    public class MarqueeEventArgs : EventArgs
    {
        private int numberOfScrolls;

        public int NumberOfScrolls
        {
            get
            {
                return this.numberOfScrolls;
            }
        }

        internal MarqueeEventArgs(int numberOfScrolls)
        {
            this.numberOfScrolls = numberOfScrolls;
        }
    }

    internal class RepetitionsValueControl : UserControl
    {
        private CheckBox checkBox;
        private Container components;
        private Label label;
        private NumericUpDown numericUpDown;

        [Description("The number of repetitions.")]
        [Browsable(true)]
        public int Repetitions
        {
            get
            {
                if (this.checkBox.Checked)
                    return -1;
                return (int)this.numericUpDown.Value;
            }
            set
            {
                if (value < 0)
                {
                    this.checkBox.Checked = true;
                }
                else
                {
                    this.checkBox.Checked = false;
                    this.numericUpDown.Value = (Decimal)value;
                }
            }
        }

        public RepetitionsValueControl()
        {
            this.components = (Container)null;
            this.InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.numericUpDown.Enabled = !this.numericUpDown.Enabled;
            this.label.Enabled = !this.label.Enabled;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkBox = new CheckBox();
            this.label = new Label();
            this.numericUpDown = new NumericUpDown();
            this.numericUpDown.BeginInit();
            this.SuspendLayout();
            this.checkBox.Checked = true;
            this.checkBox.CheckState = CheckState.Checked;
            this.checkBox.Location = new Point(8, 8);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new Size(104, 16);
            this.checkBox.TabIndex = 0;
            this.checkBox.Text = "Continuously";
            this.checkBox.CheckedChanged += new EventHandler(this.checkBox_CheckedChanged);
            this.label.Enabled = false;
            this.label.Location = new Point(80, 32);
            this.label.Name = "label";
            this.label.Size = new Size(32, 16);
            this.label.TabIndex = 2;
            this.label.Text = "times";
            this.numericUpDown.Enabled = false;
            this.numericUpDown.Location = new Point(8, 32);
            int[] bits = new int[4];
            bits[0] = 1000000;
            this.numericUpDown.Maximum = new Decimal(bits);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new Size(64, 20);
            this.numericUpDown.TabIndex = 1;
            this.Controls.AddRange(new Control[3]
      {
        (Control) this.numericUpDown,
        (Control) this.label,
        (Control) this.checkBox
      });
            this.Name = "RepetitionsValueControl";
            this.Size = new Size(120, 56);
            this.numericUpDown.EndInit();
            this.ResumeLayout(false);
        }
    }

    internal class RepetitionsValueEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            RepetitionsValueControl repetitionsValueControl = new RepetitionsValueControl();
            repetitionsValueControl.Repetitions = (int)value;
            service.DropDownControl((Control)repetitionsValueControl);
            return (object)repetitionsValueControl.Repetitions;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }

    [Serializable]
    public class MarqueeException : ApplicationException
    {
        internal MarqueeException(string message)
            : base(message)
        {
        }

        internal MarqueeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public delegate void MarqueeEventHandler(object sender, MarqueeEventArgs e);

    public partial class ucMarqueeTextBox : UserControl
    {
        private const int DefaultAmount = 1;
        private const int DefaultDelay = 10;
        private const Direction DefaultDirection = Direction.Left;
        private const int DefaultRepetitions = -1;
        private const string evaluationMessage = "";
        private const int RepeatContinuously = -1;
        private int amount;
        private IContainer components;
        private int count;
        private int delay;
        private Direction direction;
        private int repetitions;
        private bool stopOnMouseOver;
        private StringFormat stringFormat;
        private Timer timer;
        private bool wraparound;
        private float xText;
        private float xWrap;

        [DefaultValue(1)]
        [Category("Speed")]
        [Description("The amount to move the text.")]
        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value > 0)
                    this.amount = value;
                else
                    this.amount = 1;
            }
        }

        [Category("Speed")]
        [Description("The delay in milliseconds before moving the text.")]
        [DefaultValue(20)]
        public int Delay
        {
            get
            {
                return this.delay;
            }
            set
            {
                this.delay = value;
                if (this.delay <= 0)
                {
                    this.timer.Enabled = false;
                }
                else
                {
                    this.timer.Interval = this.delay;
                    this.timer.Enabled = true;
                }
            }
        }

        [Description("The direction the text is scrolled.")]
        [DefaultValue(0)]
        [Browsable(true)]
        public Direction Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        [Browsable(true)]
        [Editor(typeof(RepetitionsValueEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        [Description("The number of repetitions. A negative value means repeat continuously.")]
        public int Repeat
        {
            get
            {
                return this.repetitions;
            }
            set
            {
                this.repetitions = value;
                this.count = 0;
                if (this.delay <= 0)
                    return;
                this.timer.Enabled = true;
            }
        }

        [Description("The flag indicating whether the text movement will stop whilst the mouse is over it.")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool StopOnMouseOver
        {
            get
            {
                return this.stopOnMouseOver;
            }
            set
            {
                this.stopOnMouseOver = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Description("The flag indicating whether the text will wraparound.")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool Wraparound
        {
            get
            {
                return this.wraparound;
            }
            set
            {
                this.wraparound = value;
            }
        }

        [Description("The text has completed a scroll cycle.")]
        public event MarqueeEventHandler TextScrolled;

        public ucMarqueeTextBox()
        {
            this.amount = 1;
            this.direction = Direction.Left;
            this.repetitions = -1;
            this.wraparound = true;
            this.stopOnMouseOver = false;
            this.stringFormat = new StringFormat();
            this.InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Delay = 20;
            this.stringFormat.Alignment = StringAlignment.Near;
            this.stringFormat.LineAlignment = StringAlignment.Center;
            this.Text = "안녕하세요 *^^*";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void GetDrawRectangles(Graphics graphics, out Rectangle mainRectangle, out Rectangle wraparoundRectangle)
        {
            SizeF sizeF = graphics.MeasureString(this.Text, this.Font, 0, this.stringFormat);
            switch (this.direction)
            {
                case Direction.Left:
                    this.xText -= (float)this.amount;
                    if ((double)this.xText <= -(double)sizeF.Width)
                    {
                        this.xText = this.wraparound ? this.xWrap : (float)this.ClientRectangle.Right;
                        ++this.count;
                        this.OnTextScrolled();
                        break;
                    }
                    break;
                case Direction.Right:
                    this.xText += (float)this.amount;
                    if ((double)this.xText >= (double)this.Size.Width)
                    {
                        this.xText = this.wraparound ? this.xWrap : -sizeF.Width;
                        ++this.count;
                        this.OnTextScrolled();
                        break;
                    }
                    break;
            }
            mainRectangle = new Rectangle((int)this.xText, 0, (int)sizeF.Width + 1, this.ClientRectangle.Height);
            wraparoundRectangle = Rectangle.Empty;
            if (!this.wraparound)
                return;
            switch (this.direction)
            {
                case Direction.Left:
                    if (mainRectangle.Left >= 0 || mainRectangle.Right >= this.ClientRectangle.Right)
                        break;
                    this.xWrap = (float)Math.Max(this.ClientRectangle.Right + mainRectangle.Left, mainRectangle.Right + 1);
                    wraparoundRectangle = new Rectangle((int)this.xWrap, 0, (int)sizeF.Width + 1, this.ClientRectangle.Height);
                    break;
                case Direction.Right:
                    if (mainRectangle.Right <= this.ClientRectangle.Right || mainRectangle.Left <= 0)
                        break;
                    this.xWrap = Math.Min((float)(mainRectangle.Left - this.ClientRectangle.Right), (float)((double)mainRectangle.Left - (double)sizeF.Width + 1.0));
                    wraparoundRectangle = new Rectangle((int)this.xWrap, 0, (int)sizeF.Width + 1, this.ClientRectangle.Height);
                    break;
            }
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            this.timer = new Timer(this.components);
            this.timer.Enabled = true;
            this.timer.Tick += new EventHandler(this.timer_Tick);
            this.Name = "Marquee";
            this.Size = new Size(150, 25);
            this.Resize += new EventHandler(this.Marquee_Resize);
            this.Paint += new PaintEventHandler(this.Marquee_Paint);
            this.MouseEnter += new EventHandler(this.Marquee_MouseEnter);
            this.MouseLeave += new EventHandler(this.Marquee_MouseLeave);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
        }

        private void Marquee_MouseEnter(object sender, EventArgs e)
        {
            if (this.stopOnMouseOver)
                this.timer.Enabled = false;
            this.Cursor = Cursors.Hand;
        }

        private void Marquee_MouseLeave(object sender, EventArgs e)
        {
            this.timer.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void Marquee_Paint(object sender, PaintEventArgs e)
        {
            Rectangle mainRectangle;
            Rectangle wraparoundRectangle;
            this.GetDrawRectangles(e.Graphics, out mainRectangle, out wraparoundRectangle);
            e.Graphics.DrawString(this.Text, this.Font, (Brush)new SolidBrush(this.ForeColor), (RectangleF)mainRectangle, this.stringFormat);
            if (!this.wraparound || wraparoundRectangle.IsEmpty)
                return;
            e.Graphics.DrawString(this.Text, this.Font, (Brush)new SolidBrush(this.ForeColor), (RectangleF)wraparoundRectangle, this.stringFormat);
        }

        private void Marquee_Resize(object sender, EventArgs e)
        {
            if ((double)this.xText <= (double)this.Size.Width)
                return;
            this.xText = (float)this.Size.Width;
        }

        private void OnTextScrolled()
        {
            if (this.TextScrolled == null)
                return;
            this.TextScrolled((object)this, new MarqueeEventArgs(this.count));
        }

        private static void ShowNagDialog()
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.repetitions < 0 || this.count < this.repetitions)
                this.Invalidate();
            if (this.repetitions <= 0 || this.count < this.repetitions)
                return;
            this.timer.Enabled = false;
        }
    }
}
