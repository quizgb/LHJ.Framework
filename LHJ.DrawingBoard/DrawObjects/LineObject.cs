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
        #region 전역 변수

        /// <summary>
        /// 라인 시작 위치
        /// </summary>
        private Point startPoint;

        /// <summary>
        /// 라인 끝 위치
        /// </summary>
        private Point endPoint;

        /// <summary>
        /// 연결된 라인 관련 변수
        /// </summary>
        [NonSerialized]
        private GraphicsPath areaPath = null;
        [NonSerialized]
        private Pen areaPen = null;
        [NonSerialized]
        private Region areaRegion = null;

        #endregion

        #region 생성자

        public LineObject()
            : this(0, 0, 1, 0)
        {
        }

        public LineObject(int x1, int y1, int x2, int y2)
            : base()
        {
            startPoint.X = x1;
            startPoint.Y = y1;
            endPoint.X = x2;
            endPoint.Y = y2;

            Initialize();
        }

        #endregion

        #region 내부 함수

        /// <summary>
        /// 이 객체를 복사한다.
        /// </summary>
        public override DrawObject Clone()
        {
            LineObject lineObject = new LineObject();
            lineObject.startPoint = this.startPoint;
            lineObject.endPoint = this.endPoint;

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
                g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
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
                return startPoint;
            else
                return endPoint;
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
                startPoint = point;
            else
                endPoint = point;

            Invalidate();
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public override void Move(int deltaX, int deltaY)
        {
            startPoint.X += deltaX;
            startPoint.Y += deltaY;

            endPoint.X += deltaX;
            endPoint.Y += deltaY;

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
            AreaPath.AddLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
            AreaPath.Widen(AreaPen);


            AreaRegion = new Region(AreaPath);
        }

        #endregion

        #region 속성

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
                return areaPath;
            }
            set
            {
                areaPath = value;
            }
        }

        /// <summary>
        /// Pen 
        /// </summary>
        protected Pen AreaPen
        {
            get
            {
                return areaPen;
            }
            set
            {
                areaPen = value;
            }
        }

        /// <summary>
        /// Region
        /// </summary>
        protected Region AreaRegion
        {
            get
            {
                return areaRegion;
            }
            set
            {
                areaRegion = value;
            }
        }

        #endregion
    }
}
