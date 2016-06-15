using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LHJ.DrawingBoard.DrawObjects
{
    //줄(라인) 을 그려주는 클래스, DrawObject 를 상속 받는다.

    //클래스를 직렬화 한다.
    [Serializable]
    class LineObject : DrawObject
    {
        #region 1.Variable
        /// <summary>
        /// 라인 시작 위치
        /// </summary>
        private Point mStartPoint;

        /// <summary>
        /// 라인 끝 위치
        /// </summary>
        private Point mEndPoint;

        /// <summary>
        /// 연결된 라인 관련 변수
        /// </summary>
        [NonSerialized]
        private GraphicsPath mAreaPath = null;
        [NonSerialized]
        private Pen mAreaPen = null;
        [NonSerialized]
        private Region mAreaRegion = null;
        #endregion 1.Variable


        #region 2.Property
        /// <summary>
        /// 이 객체가 가지는 핸들의 개수를 반환한다.
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        ///  GraphicsPath 
        /// </summary>    
        protected GraphicsPath AreaPath
        {
            get
            {
                return this.mAreaPath;
            }
            set
            {
                this.mAreaPath = value;
            }
        }

        /// <summary>
        /// Pen 
        /// </summary>
        protected Pen AreaPen
        {
            get
            {
                return this.mAreaPen;
            }
            set
            {
                this.mAreaPen = value;
            }
        }

        /// <summary>
        /// Region
        /// </summary>
        protected Region AreaRegion
        {
            get
            {
                return this.mAreaRegion;
            }
            set
            {
                this.mAreaRegion = value;
            }
        }

        public Point StartPoint
        {
            get { return this.mStartPoint; }
            set { this.mStartPoint = value; }
        }

        public Point EndPoint
        {
            get { return this.mEndPoint; }
            set { this.mEndPoint = value; }
        }
        #endregion 2.Property


        #region 3.Constructor
        public LineObject()
            : this(0, 0, 1, 0)
        {
        }

        public LineObject(int x1, int y1, int x2, int y2)
            : base()
        {
            this.mStartPoint.X = x1;
            this.mStartPoint.Y = y1;
            this.mEndPoint.X = x2;
            this.mEndPoint.Y = y2;

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
            LineObject lineObject = new LineObject();
            lineObject.StartPoint = this.mStartPoint;
            lineObject.EndPoint = this.mEndPoint;

            FillDrawObjectFields(lineObject);
            return lineObject;
        }

        /// <summary>
        /// 이 객체를 그려준다.
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color, PenWidth))
            {
                g.DrawLine(pen, this.mStartPoint.X, this.mStartPoint.Y, this.mEndPoint.X, this.mEndPoint.Y);
            }
        }

        /// <summary>
        /// 이 객체의 포인터를 반환한다.
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            if (handleNumber == 1)
                return this.mStartPoint;
            else
                return this.mEndPoint;
        }

        /// <summary>
        ///  마우스가 클릭된 위치가 DrawObject를 포함하는지 알려준다
        ///  -1 - no hit
        ///   0 - hit anywhere
        /// > 1 - handle number
        /// </summary>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                        return i;
                }
            }

            if (PointInObject(point))
                return 0;

            return -1;
        }

        /// <summary>
        /// 마우스의 위치가 DrawObject 내에 있는지 알려준다.
        /// </summary>
        protected override bool PointInObject(Point point)
        {
            CreateObjects();

            return AreaRegion.IsVisible(point);
        }

        /// <summary>
        /// DrawObject가 rectangle 에 포함되는지 알려준다.
        /// </summary>
        public override bool IntersectsWith(Rectangle rectangle)
        {
            CreateObjects();

            return AreaRegion.IsVisible(rectangle);
        }

        /// <summary>
        /// Pointer 의 HandleNumber 에 따라서 마우스 커서를 반환한다.
        /// </summary>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        /// <summary>
        /// DrawObject 의 사이즈를 변경한다.
        /// </summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            if (handleNumber == 1)
                this.mStartPoint = point;
            else
                this.mEndPoint = point;

            Invalidate();
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public override void Move(int deltaX, int deltaY)
        {
            this.mStartPoint.X += deltaX;
            this.mStartPoint.Y += deltaY;
            
            this.mEndPoint.X += deltaX;
            this.mEndPoint.Y += deltaY;

            Invalidate();
        }

        /// <summary>
        /// 객체를 갱신한다.
        /// </summary>
        protected void Invalidate()
        {
            if (AreaPath != null)
            {
                AreaPath.Dispose();
                AreaPath = null;
            }

            if (AreaPen != null)
            {
                AreaPen.Dispose();
                AreaPen = null;
            }

            if (AreaRegion != null)
            {
                AreaRegion.Dispose();
                AreaRegion = null;
            }
        }

        /// <summary>
        /// HitTest 에 사용 될 객체를 생성한다.
        /// </summary>
        protected virtual void CreateObjects()
        {
            if (AreaPath != null)
                return;

            AreaPath = new GraphicsPath();
            AreaPen = new Pen(Color.Black, 7);
            AreaPath.AddLine(this.mStartPoint.X, this.mStartPoint.Y, this.mEndPoint.X, this.mEndPoint.Y);
            AreaPath.Widen(AreaPen);

            AreaRegion = new Region(AreaPath);
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
