using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace LHJ.DrawingBoard.DrawObjects
{
    /// <summary>
    /// 사각형을 그려주는 클래스, DrawObject를 상속 받는다.
    /// </summary>

    //클래스를 직렬화한다.
    [Serializable]
    class RectangleObject : DrawObject
    {
        #region 1.Variable
        private Rectangle mRectangle;
        #endregion 1.Variable


        #region 2.Property
        /// <summary>
        /// 핸들의 숫자를 반환한다.
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 8;
            }
        }

        protected Rectangle Rectangle
        {
            get
            {
                return this.mRectangle;
            }
            set
            {
                this.mRectangle = value;
            }
        }
        #endregion 2.Property


        #region 3.Constructor
        public RectangleObject()
            : this(0, 0, 1, 1)
        {

        }

        public RectangleObject(int x, int y, int width, int height)
            : base()
        {
            this.mRectangle.X = x;
            this.mRectangle.Y = y;
            this.mRectangle.Width = width;
            this.mRectangle.Height = height;

            Initialize();
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

        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// 이 객체를 복사한다.
        /// </summary>
        public override DrawObject Clone()
        {
            RectangleObject rectangleObject = new RectangleObject();
            rectangleObject.Rectangle = this.mRectangle;

            FillDrawObjectFields(rectangleObject);
            return rectangleObject;
        }


        /// <summary>
        /// 이 객체를 그려준다.
        /// </summary>
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, PenWidth))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawRectangle(pen, RectangleObject.GetNormalizedRectangle(this.mRectangle));

                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    g.FillRectangle(brush, this.mRectangle);
                }
            }
        }

        //Retangle 의 크기와 위치를 설정한다.
        protected void SetRectangle(int x, int y, int width, int height)
        {
            this.mRectangle.X = x;
            this.mRectangle.Y = y;
            this.mRectangle.Width = width;
            this.mRectangle.Height = height;
        }

        /// <summary>
        /// 핸들 넘버의 위치를 반환한다.
        /// </summary>
        public override Point GetHandle(int aHandleNumber)
        {
            int x, y, xCenter, yCenter;

            xCenter = this.mRectangle.X + this.mRectangle.Width / 2;
            yCenter = this.mRectangle.Y + this.mRectangle.Height / 2;
            x = this.mRectangle.X;
            y = this.mRectangle.Y;

            switch (aHandleNumber)
            {
                case 1:
                    x = this.mRectangle.X;
                    y = this.mRectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = this.mRectangle.Y;
                    break;
                case 3:
                    x = this.mRectangle.Right;
                    y = this.mRectangle.Y;
                    break;
                case 4:
                    x = this.mRectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = this.mRectangle.Right;
                    y = this.mRectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = this.mRectangle.Bottom;
                    break;
                case 7:
                    x = this.mRectangle.X;
                    y = this.mRectangle.Bottom;
                    break;
                case 8:
                    x = this.mRectangle.X;
                    y = yCenter;
                    break;
            }

            return new Point(x, y);

        }

        /// <summary>
        ///  마우스가 클릭된 위치가 DrawObject를 포함하는지 알려준다
        ///  -1 - no hit
        ///   0 - hit anywhere
        /// > 1 - handle number
        /// </summary>
        public override int HitTest(Point aPoint)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(aPoint))
                        return i;
                }
            }

            if (PointInObject(aPoint))
                return 0;

            return -1;
        }

        /// <summary>
        /// 마우스의 위치가 DrawObject 내에 있는지 알려준다.
        /// </summary>
        protected override bool PointInObject(Point aPoint)
        {
            return this.mRectangle.Contains(aPoint);
        }

        /// <summary>
        /// Pointer 의 HandleNumber 에 따라서 마우스 커서를 반환한다.
        /// </summary>
        public override Cursor GetHandleCursor(int aHandleNumber)
        {
            switch (aHandleNumber)
            {
                case 1:
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }

        /// <summary>
        /// DrawObject 의 사이즈를 변경한다.
        /// </summary>
        public override void MoveHandleTo(Point aPoint, int aHandleNumber)
        {
            int left = this.mRectangle.Left;
            int top = this.mRectangle.Top;
            int right = this.mRectangle.Right;
            int bottom = this.mRectangle.Bottom;

            switch (aHandleNumber)
            {
                case 1:
                    left = aPoint.X;
                    top = aPoint.Y;
                    break;
                case 2:
                    top = aPoint.Y;
                    break;
                case 3:
                    right = aPoint.X;
                    top = aPoint.Y;
                    break;
                case 4:
                    right = aPoint.X;
                    break;
                case 5:
                    right = aPoint.X;
                    bottom = aPoint.Y;
                    break;
                case 6:
                    bottom = aPoint.Y;
                    break;
                case 7:
                    left = aPoint.X;
                    bottom = aPoint.Y;
                    break;
                case 8:
                    left = aPoint.X;
                    break;
            }

            this.SetRectangle(left, top, right - left, bottom - top);
        }

        /// <summary>
        /// DrawObject가 rectangle 에 포함되는지 알려준다.
        /// </summary>
        public override bool IntersectsWith(Rectangle aRectangle)
        {
            return this.mRectangle.IntersectsWith(aRectangle);
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public override void Move(int aDeltaX, int aDeltaY)
        {
            this.mRectangle.X += aDeltaX;
            this.mRectangle.Y += aDeltaY;
        }

        /// <summary>
        /// DrawObject 를 새로 그리거나, 사이즈를 변경이 끝났을 때 호출된다.
        /// </summary>
        public override void Normalize()
        {
            this.mRectangle = RectangleObject.GetNormalizedRectangle(this.mRectangle);
        }


        /// <summary>
        /// Retagle을 그려준다
        /// </summary>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Retagle을 그려준다
        /// </summary>
        public static Rectangle GetNormalizedRectangle(Point aP1, Point aP2)
        {
            return GetNormalizedRectangle(aP1.X, aP1.Y, aP2.X, aP2.Y);
        }

        /// <summary>
        /// Retagle을 그려준다
        /// </summary>
        public static Rectangle GetNormalizedRectangle(Rectangle aRect)
        {
            return GetNormalizedRectangle(aRect.X, aRect.Y, aRect.X + aRect.Width, aRect.Y + aRect.Height);
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
