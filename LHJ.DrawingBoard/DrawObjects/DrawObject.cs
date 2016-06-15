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
        #region 1.Variable
        //DrawObject 의 선택 여부를 저장
        private bool mSelected;

        //DrawObject 의 테두리 색깔을 지정한다.
        private Color mColor;

        //DrawObject 의 배경 색깔을 지정한다.
        private Color mBackColor;

        //DrawObject 의 Pen 두께를 지정한다.
        private int mPenWidth;
        #endregion 1.Variable


        #region 2.Property
        /// <summary>
        /// DrawObject 의 선택여부
        /// </summary>
        public bool Selected
        {
            get
            {
                return this.mSelected;
            }
            set
            {
                this.mSelected = value;
            }
        }

        /// <summary>
        /// DrawObject 의 테두리 색깔
        /// </summary>
        public Color Color
        {
            get
            {
                return this.mColor;
            }
            set
            {
                this.mColor = value;
            }
        }

        /// <summary>
        /// DrawObject 의 배경 색깔
        /// </summary>
        public Color BackColor
        {
            get
            {
                return this.mBackColor;
            }

            set
            {
                this.mBackColor = value;
            }
        }

        /// <summary>
        /// DrawObject 의 Pen 두께
        /// </summary>
        public int PenWidth
        {
            get
            {
                return this.mPenWidth;
            }
            set
            {
                this.mPenWidth = value;
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
        #endregion 2.Property


        #region 3.Constructor
        public DrawObject()
        {
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
        public virtual Point GetHandle(int aHandleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// 핸들의 Rectangle 을 반환한다.
        /// </summary>
        public virtual Rectangle GetHandleRectangle(int aHandleNumber)
        {
            Point point = this.GetHandle(aHandleNumber);

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
        public virtual int HitTest(Point aPoint)
        {
            return -1;
        }


        /// <summary>
        /// 마우스의 위치가 DrawObject 내에 있는지 알려준다.
        /// </summary>
        protected virtual bool PointInObject(Point aPoint)
        {
            return false;
        }


        /// <summary>
        /// Pointer 의 HandleNumber 에 따라서 마우스 커서를 반환한다.
        /// </summary>
        public virtual Cursor GetHandleCursor(int aHandleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// DrawObject가 rectangle 에 포함되는지 알려준다.
        /// </summary>
        public virtual bool IntersectsWith(Rectangle aRectangle)
        {
            return false;
        }

        /// <summary>
        /// DrawObject 의 위치를 이동한다.
        /// </summary>
        public virtual void Move(int aDeltaX, int aDeltaY)
        {
        }

        /// <summary>
        /// DrawObject 의 사이즈를 변경한다.
        /// </summary>
        public virtual void MoveHandleTo(Point aPoint, int aHandleNumber)
        {
        }

        /// <summary>
        /// DrawObject 를 새로 그리거나, 사이즈를 변경이 끝났을 때 호출된다.
        /// </summary>
        public virtual void Normalize()
        {
        }

        /// <summary>
        /// DrawObject 초기화
        /// </summary>
        protected void Initialize()
        {
            //DrawObject 를 선택으로 설정
            this.mSelected = true;

            //마지막으로 사용된 테두리 색을 입력한다.
            this.mColor = Controller.MainController.Instance.LastUsedColor;

            //마지막으로 사용된 배경색을 입력한다.
            this.mBackColor = Controller.MainController.Instance.LastUesdBackgoroundColor;

            //마지막으로 사용된 Pen 두께를 입력한다.
            this.mPenWidth = Controller.MainController.Instance.LastUsedPenWidth;
        }

        /// <summary>
        /// DrawObject 를 복사 할 때, 속성들을 복사해준다.
        /// </summary>
        protected void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject.Selected = this.mSelected;
            drawObject.Color = this.mColor;
            drawObject.BackColor = this.mBackColor;
            drawObject.PenWidth = this.mPenWidth;
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
