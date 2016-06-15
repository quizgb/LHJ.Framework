using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LHJ.DrawingBoard.DrawObjects
{
    //Pencil 로 그려주는 클래스 LineObject 를 상속받는다.

    //클래스를 직렬화 한다.
    [Serializable]
    class PencilObejct : LineObject
    {
        #region 1.Variable
        /// <summary>
        /// 위치를 저장하는 컬렉션
        /// </summary>
        private List<Point> mPointList;
        #endregion 1.Variable


        #region 2.Property
        /// <summary>
        /// 핸들의 수를 반환한다.
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return this.mPointList.Count;
            }
        }

        public List<Point> PointList
        {
            get { return this.mPointList; }
            set { this.mPointList = value; }
        }
        #endregion 2.Property


        #region 3.Constructor
        public PencilObejct()
            : base()
        {
            this.mPointList = new List<Point>();

            Initialize();
        }

        public PencilObejct(int x1, int y1, int x2, int y2)
            : base()
        {
           this.mPointList = new List<Point>();
           this.mPointList.Add(new Point(x1, y1));
           this.mPointList.Add(new Point(x2, y2));

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
            PencilObejct pencilObejct = new PencilObejct();

            foreach (Point p in this.mPointList)
            {
                pencilObejct.PointList.Add(p);
            }

            FillDrawObjectFields(pencilObejct);
            return pencilObejct;
        }

        /// <summary>
        /// 이 객체를 그려준다.
        /// </summary>
        public override void Draw(Graphics g)
        {
            int x1 = 0, y1 = 0;     // 이전의 위치
            int x2, y2;             // 현재의 위치

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color, PenWidth))
            {
                IEnumerator<Point> enumerator = this.mPointList.GetEnumerator();

                if (enumerator.MoveNext())
                {
                    x1 = ((Point)enumerator.Current).X;
                    y1 = ((Point)enumerator.Current).Y;
                }

                //pointList 에 담겨 있는 point 만큼 그려준다.
                while (enumerator.MoveNext())
                {
                    x2 = ((Point)enumerator.Current).X;
                    y2 = ((Point)enumerator.Current).Y;

                    g.DrawLine(pen, x1, y1, x2, y2);

                    x1 = x2;
                    y1 = y2;
                }
            }
        }

        /// <summary>
        /// 위치를 pointList 에 추가한다.
        /// </summary>
        public void AddPoint(Point aPoint)
        {
            this.mPointList.Add(aPoint);
        }

        /// <summary>
        /// 핸들 넘버의 위치를 반환한다.
        /// </summary> 
        public override Point GetHandle(int aHandleNumber)
        {
            if (aHandleNumber < 1)
                aHandleNumber = 1;

            if (aHandleNumber > this.mPointList.Count)
                aHandleNumber = this.mPointList.Count;

            return ((Point)this.mPointList[aHandleNumber - 1]);
        }

        /// <summary>
        /// DrawObject 의 사이즈를 변경한다.
        /// </summary>
        public override void MoveHandleTo(Point aPoint, int aHandleNumber)
        {
            if (aHandleNumber < 1)
                aHandleNumber = 1;

            if (aHandleNumber > this.mPointList.Count)
                aHandleNumber = this.mPointList.Count;

            mPointList[aHandleNumber - 1] = aPoint;

            Invalidate();
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public override void Move(int aDeltaX, int aDeltaY)
        {
            int n = this.mPointList.Count;
            Point point;

            for (int i = 0; i < n; i++)
            {
                point = new Point(((Point)this.mPointList[i]).X + aDeltaX, ((Point)this.mPointList[i]).Y + aDeltaY);
                this.mPointList[i] = point;
            }

            Invalidate();
        }

        /// <summary>
        /// HistTest 를 위한 그래픽 객체를 만들어준다.
        /// </summary>
        protected override void CreateObjects()
        {
            if (AreaPath != null)
                return;

            AreaPath = new GraphicsPath();

            int x1 = 0, y1 = 0;     // 이전 위치
            int x2, y2;             // 현재 위치

            IEnumerator<Point> enumerator = this.mPointList.GetEnumerator();

            if (enumerator.MoveNext())
            {
                x1 = ((Point)enumerator.Current).X;
                y1 = ((Point)enumerator.Current).Y;
            }

            while (enumerator.MoveNext())
            {
                x2 = ((Point)enumerator.Current).X;
                y2 = ((Point)enumerator.Current).Y;

                AreaPath.AddLine(x1, y1, x2, y2);

                x1 = x2;
                y1 = y2;
            }

            AreaPath.CloseFigure();

            AreaRegion = new Region(AreaPath);
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
