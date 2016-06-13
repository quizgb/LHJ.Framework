using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace LHJ.DrawingBoard.DrawObjects
{
    //그리기와 관련된 최상위 추상 클래스

    //클래스를 직렬화 한다.
    [Serializable]
    public abstract class DrawObject
    {
        #region 전역변수

        //DrawObject 의 선택 여부를 저장
        private bool selected;

        //DrawObject 의 테두리 색깔을 지정한다.
        private Color color;

        //DrawObject 의 배경 색깔을 지정한다.
        private Color backColor;

        //DrawObject 의 Pen 두께를 지정한다.
        private int penWidth;

        #endregion

        #region 생성자

        public DrawObject()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// DrawObject 의 선택여부
        /// </summary>
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }

        /// <summary>
        /// DrawObject 의 테두리 색깔
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        /// <summary>
        /// DrawObject 의 배경 색깔
        /// </summary>
        public Color BackColor
        {
            get
            {
                return backColor;
            }

            set
            {
                backColor = value;
            }
        }

        /// <summary>
        /// DrawObject 의 Pen 두께
        /// </summary>
        public int PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                penWidth = value;
            }
        }

        /// <summary>
        /// DrawObject 의 핸들 갯수
        /// </summary>
        public virtual int HandleCount
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region 가상 함수

        /// <summary>
        /// DrawObject 복사 함수
        /// </summary>
        public abstract DrawObject Clone();

        /// <summary>
        /// DrawObject 그리기 함수
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// 핸들 넘버의 위치를 반환한다.
        /// </summary>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// 핸들의 Rectangle 을 반환한다.
        /// </summary>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// DrawObject 가 선택되었을때 표시를 해주는 Pointer 를 그린다
        /// </summary>
        public virtual void DrawPointer(Graphics g)
        {
            if (!Selected)
                return;

            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    g.FillRectangle(brush, GetHandleRectangle(i));
                }
            }
        }

        /// <summary>
        ///  마우스가 클릭된 위치가 DrawObject를 포함하는지 알려준다
        ///  -1 - no hit
        ///   0 - hit anywhere
        /// > 1 - handle number
        /// </summary>
        public virtual int HitTest(Point point)
        {
            return -1;
        }


        /// <summary>
        /// 마우스의 위치가 DrawObject 내에 있는지 알려준다.
        /// </summary>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }


        /// <summary>
        /// Pointer 의 HandleNumber 에 따라서 마우스 커서를 반환한다.
        /// </summary>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// DrawObject가 rectangle 에 포함되는지 알려준다.
        /// </summary>
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// DrawObject 의 사이즈를 변경한다.
        /// </summary>
        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }



        /// <summary>
        /// DrawObject 를 새로 그리거나, 사이즈를 변경이 끝났을 때 호출된다.
        /// </summary>
        public virtual void Normalize()
        {
        }

        #endregion

        #region 내부 함수

        /// <summary>
        /// DrawObject 초기화
        /// </summary>
        protected void Initialize()
        {
            //DrawObject 를 선택으로 설정
            this.selected = true;


            //마지막으로 사용된 테두리 색을 입력한다.
            color = Controller.MainController.Instance.LastUsedColor;

            //마지막으로 사용된 배경색을 입력한다.
            backColor = Controller.MainController.Instance.LastUesdBackgoroundColor;

            //마지막으로 사용된 Pen 두께를 입력한다.
            penWidth = Controller.MainController.Instance.LastUsedPenWidth;
        }

        /// <summary>
        /// DrawObject 를 복사 할 때, 속성들을 복사해준다.
        /// </summary>
        protected void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject.selected = this.selected;
            drawObject.color = this.color;
            drawObject.backColor = this.backColor;
            drawObject.penWidth = this.penWidth;
        }

        #endregion
    }
}
