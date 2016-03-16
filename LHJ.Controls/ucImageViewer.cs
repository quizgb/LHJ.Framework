using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LHJ.Controls
{
    /// <summary>
    /// ImageViewer
    /// </summary>
    public partial class ucImageViewer : ScrollableControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ucImageViewer"/> class.
        /// </summary>
        public ucImageViewer()
            : base()
        {
			this.SetStyle(ControlStyles.DoubleBuffer |
					ControlStyles.UserPaint |
					ControlStyles.AllPaintingInWmPaint,
					true);

			this.UpdateStyles();

            this.InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = SystemColors.ControlDarkDark;

            this.ZoomRate = 1f;
			this.ZoomStep = 0.25f;
            //this.ZoomStep = 0.07f;
            this.EnableDrag = true;
            this.EnableZoom = true;
            this.InterpolationMode = InterpolationMode.HighQualityBicubic;

            this.verticalSrollBarWidth = GetSystemMetrics(21);
            this.horizontalScrollBarHeight = GetSystemMetrics(3);

            this.Paint += new PaintEventHandler(this.ImageViewer_Paint);
            this.SizeChanged += new EventHandler(this.ImageViewer_SizeChanged);
            this.Scroll += new ScrollEventHandler(this.ImageViewer_Scroll);
            this.MouseDown += new MouseEventHandler(this.ImageViewer_MouseDown);
            this.MouseMove += new MouseEventHandler(this.ImageViewer_MouseMove);
            this.MouseUp += new MouseEventHandler(this.ImageViewer_MouseUp);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(this.ImageViewer_PreviewKeyDown);
            this.EnabledChanged += new EventHandler(this.ImageViewer_EnabledChanged);
        }

        private Image image;
        private float zoomRate;
        private float zoomStep;
        private bool enableDrag;
        private bool enableZoom;
        private InterpolationMode interpolationMode;

        private bool grabbed;
        private Point grabbedPoint;
        private int verticalSrollBarWidth;
        private int horizontalScrollBarHeight;

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w param.</param>
        /// <param name="lParam">The l param.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Gets the system metrics.
        /// </summary>
        /// <param name="smIndex">Index of the sm.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        protected static extern int GetSystemMetrics(int smIndex);

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
                this.UpdateImage();
            }
        }

        /// <summary>
        /// Gets or sets the zoom rate.
        /// </summary>
        /// <value>The zoom rate.</value>
        public float ZoomRate
        {
            get { return this.zoomRate; }
            set
            {
                if (!this.enableZoom)
                    return;

                if (value <= 0.10f)
                    value = 0.10f;

                this.zoomRate = value;
                this.UpdateImage();
            }
        }

        /// <summary>
        /// Gets or sets the zoom step.
        /// </summary>
        /// <value>The zoom step.</value>
        public float ZoomStep
        {
            get { return this.zoomStep; }
            set
            {
                if (value <= 0.01f)
                    value = 0.01f;

                this.zoomStep = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable drag].
        /// </summary>
        /// <value><c>true</c> if [enable drag]; otherwise, <c>false</c>.</value>
        public bool EnableDrag
        {
            get { return this.enableDrag; }
            set { this.enableDrag = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable zoom].
        /// </summary>
        /// <value><c>true</c> if [enable zoom]; otherwise, <c>false</c>.</value>
        public bool EnableZoom
        {
            get { return this.enableZoom; }
            set
            {
                if (!value)
                    this.ZoomRate = 1f;

                this.enableZoom = value;
            }
        }

        /// <summary>
        /// Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        public InterpolationMode InterpolationMode
        {
            get { return this.interpolationMode; }
            set
            {
                this.interpolationMode = value;
                this.UpdateImage();
            }
        }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        /// <value>The display size.</value>
        public Size DisplaySize
        {
            get
            {
                return new Size(
                    (int)(this.image.Width * this.zoomRate),
                    (int)(this.image.Height * this.zoomRate));
            }
        }

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return this.image.Size; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ucImageViewer"/> is grabbed.
        /// </summary>
        /// <value><c>true</c> if grabbed; otherwise, <c>false</c>.</value>
        public bool Grabbed
        {
            get { return this.grabbed; }
            internal set
            {
                this.grabbed = value;

                if (value)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Enlarges the specified zoom step.
        /// </summary>
        /// <param name="zoomStep">The zoom step.</param>
        public void Enlarge(float zoomStep) { this.ZoomRate += this.zoomStep; }

        /// <summary>
        /// Enlarges this instance.
        /// </summary>
        public void Enlarge() { this.Enlarge(this.zoomStep); }

        /// <summary>
        /// Reduces the specified zoom step.
        /// </summary>
        /// <param name="zoomStep">The zoom step.</param>
        public void Reduce(float zoomStep) { this.ZoomRate -= this.zoomStep; }

        /// <summary>
        /// Reduces this instance.
        /// </summary>
        public void Reduce() { this.Reduce(this.zoomStep); }

        /// <summary>
        /// Performs the page up.
        /// </summary>
        public virtual void PerformPageUp() { SendMessage(this.Handle, 0x115, 2, 0); }

        /// <summary>
        /// Performs the page down.
        /// </summary>
        public virtual void PerformPageDown() { SendMessage(this.Handle, 0x115, 3, 0); }

        /// <summary>
        /// Scrolls the left.
        /// </summary>
        public virtual void ScrollLeft() { SendMessage(this.Handle, 0x114, 0, 0); }

        /// <summary>
        /// Scrolls the right.
        /// </summary>
        public virtual void ScrollRight() { SendMessage(this.Handle, 0x114, 1, 0); }

        /// <summary>
        /// Scrolls up.
        /// </summary>
        public virtual void ScrollUp() { SendMessage(this.Handle, 0x115, 0, 0); }

        /// <summary>
        /// Scrolls down.
        /// </summary>
        public virtual void ScrollDown() { SendMessage(this.Handle, 0x115, 1, 0); }

        /// <summary>
        /// Scrolls to.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void ScrollTo(int x, int y)
        {
            this.ScrollTo(new Point(x, y));
        }

        /// <summary>
        /// Scrolls to.
        /// </summary>
        /// <param name="location">The location.</param>
        public virtual void ScrollTo(Point location)
        {
            Size displaySize = this.DisplaySize;

            if (location.X < 0)
                location.X = 0;
            else if (location.X > displaySize.Width)
                location.X = displaySize.Width;

            if (location.Y < 0)
                location.Y = 0;
            else if (location.Y > displaySize.Height)
                location.Y = displaySize.Height;

            this.AutoScrollPosition = location;
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        public virtual void UpdateImage()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new Action(this.UpdateImage),
                    (object[])null);

                return;
            }

            if (this.image == null)
                return;

            this.AutoScroll = true;
            this.AutoScrollMinSize = this.DisplaySize;

            Size displaySize = this.DisplaySize;
            this.HorizontalScroll.SmallChange = (int)(displaySize.Width / 20);
            this.HorizontalScroll.LargeChange = (int)(displaySize.Width / 10);
            this.VerticalScroll.SmallChange = (int)(displaySize.Width / 20);
            this.VerticalScroll.LargeChange = (int)(displaySize.Width / 10);

            this.Invalidate();
        }

        /// <summary>
        /// Processes a dialog character.
        /// </summary>
        /// <param name="charCode">The character to process.</param>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessDialogChar(char charCode)
        {
            switch (charCode)
            {
                case '-':
                    this.Reduce();
                    break;

                case '+':
                case '=':
                    this.Enlarge();
                    break;
            }

            return base.ProcessDialogChar(charCode);
        }

        /// <summary>
        /// Handles the Paint event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_Paint(object sender, PaintEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new PaintEventHandler(this.ImageViewer_Paint),
                    new object[] { sender, e });

                return;
            }

            using (BufferedGraphics bufferedGraphics =
                BufferedGraphicsManager.Current.Allocate(e.Graphics, this.ClientRectangle))
            {
                bufferedGraphics.Graphics.Clear(this.BackColor);

                if (this.image == null)
                    return;

                Graphics graphic = e.Graphics;
                Point autoScrollPosition = this.AutoScrollPosition;
                Size clientSize = this.ClientSize;
                Size imageSize = this.ImageSize;
                Size displaySize = this.DisplaySize;
                Padding padding = this.Padding;

                int imageX = autoScrollPosition.X;
                int imageY = autoScrollPosition.Y;

                if (clientSize.Width > displaySize.Width)
                    imageX = clientSize.Width / 2 - displaySize.Width / 2;

                if (clientSize.Height > displaySize.Height)
                    imageY = clientSize.Height / 2 - displaySize.Height / 2;

                bufferedGraphics.Graphics.InterpolationMode = this.interpolationMode;
                bufferedGraphics.Graphics.DrawImage(this.image,
                    new Rectangle(imageX, imageY, displaySize.Width, displaySize.Height));

                bufferedGraphics.Render(e.Graphics);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ImageViewer_SizeChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new EventHandler(this.ImageViewer_SizeChanged),
                    new object[] { sender, e });

                return;
            }

            this.Invalidate();
        }

        /// <summary>
        /// Handles the Scroll event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ScrollEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new ScrollEventHandler(this.ImageViewer_Scroll),
                    new object[] { sender, e });

                return;
            }

            this.Invalidate();
        }

        /// <summary>
        /// Handles the MouseDown event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MouseEventHandler(this.ImageViewer_MouseDown),
                    new object[] { sender, e });

                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                if (!this.enableDrag)
                    return;

                this.Grabbed = true;
                Point basePoint = this.AutoScrollPosition;

                this.grabbedPoint = new Point(
                    basePoint.X + e.X,
                    basePoint.Y + e.Y);
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MouseEventHandler(this.ImageViewer_MouseMove),
                    new object[] { sender, e });

                return;
            }

            if (this.Grabbed)
            {
                Point clientPoint = e.Location;
                this.AutoScrollPosition = new Point(
                    clientPoint.X - this.grabbedPoint.X,
                    clientPoint.Y - this.grabbedPoint.Y);
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MouseEventHandler(this.ImageViewer_MouseUp),
                    new object[] { sender, e });

                return;
            }

            if (e.Button == MouseButtons.Left)
                this.Grabbed = false;
        }

        /// <summary>
        /// Handles the PreviewKeyDown event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PreviewKeyDownEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new PreviewKeyDownEventHandler(this.ImageViewer_PreviewKeyDown),
                    new object[] { sender, e });

                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Add:
                    this.Enlarge();
                    break;

                case Keys.Subtract:
                    this.Reduce();
                    break;

                case Keys.Home:
                    this.ScrollTo(Point.Empty);
                    break;

                case Keys.End:
                    this.ScrollTo(new Point(this.DisplaySize.Width, this.DisplaySize.Height));
                    break;

                case Keys.PageUp:
                    this.PerformPageUp();
                    break;

                case Keys.PageDown:
                    this.PerformPageDown();
                    break;

                case Keys.Left:
                    this.ScrollLeft();
                    break;

                case Keys.Right:
                    this.ScrollRight();
                    break;

                case Keys.Up:
                    this.ScrollUp();
                    break;

                case Keys.Down:
                    this.ScrollDown();
                    break;
            }
        }

        /// <summary>
        /// Handles the EnabledChanged event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ImageViewer_EnabledChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new EventHandler(this.ImageViewer_EnabledChanged),
                    new object[] { sender, e });

                return;
            }

            this.Invalidate();
        }
    }
}
