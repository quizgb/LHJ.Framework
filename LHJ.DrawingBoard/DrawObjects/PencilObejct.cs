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
        #region 전역 변수

        /// <summary>
        /// 위치를 저장하는 컬렉션
        /// </summary>
        private List<Point> pointList;

        #endregion

        #region 생성자

        public PencilObejct()
            : base()
        {
            pointList = new List<Point>();

            Initialize();
        }

        public PencilObejct(int x1, int y1, int x2, int y2)
            : base()
        {
            pointList = new List<Point>();
            pointList.Add(new Point(x1, y1));
            pointList.Add(new Point(x2, y2));

            Initialize();
        }

        #endregion

        #region 내부함수

        /// <summary>
        /// 이 객체를 복사한다.
        /// </summary>
        public override DrawObject Clone()
        {
            PencilObejct pencilObejct = new PencilObejct();

            foreach (Point p in this.pointList)
            {
                pencilObejct.pointList.Add(p);
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
                IEnumerator<Point> enumerator = pointList.GetEnumerator();

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
        public void AddPoint(Point point)
        {
            pointList.Add(point);
        }

        /// <summary>
        /// 핸들 넘버의 위치를 반환한다.
        /// </summary> 
        public override Point GetHandle(int handleNumber)
        {
            if (handleNumber < 1)
                handleNumber = 1;

            if (handleNumber > pointList.Count)
                handleNumber = pointList.Count;

            return ((Point)pointList[handleNumber - 1]);
        }

        /// <summary>
        /// DrawObject 의 사이즈를 변경한다.
        /// </summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            if (handleNumber < 1)
                handleNumber = 1;

            if (handleNumber > pointList.Count)
                handleNumber = pointList.Count;

            pointList[handleNumber - 1] = point;

            Invalidate();
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public override void Move(int deltaX, int deltaY)
        {
            int n = pointList.Count;
            Point point;

            for (int i = 0; i < n; i++)
            {
                point = new Point(((Point)pointList[i]).X + deltaX, ((Point)pointList[i]).Y + deltaY);

                pointList[i] = point;
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

            IEnumerator<Point> enumerator = pointList.GetEnumerator();

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

        #endregion

        #region 속성

        /// <summary>
        /// 핸들의 수를 반환한다.
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return pointList.Count;
            }
        }

        #endregion
    }
}
