using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LHJ.DrawingBoard.DrawObjects
{
    //원을 그리는 클래스, RectangleObject 를 상속받는다.

    //클래스를 직렬화 한다.
    [Serializable]
    class EllipseObject : RectangleObject
    {
        #region 생성자

        public EllipseObject()
            : this(0, 0, 1, 1)
        {
        }

        public EllipseObject(int x, int y, int width, int height)
            : base()
        {
            Rectangle = new Rectangle(x, y, width, height);
            Initialize();
        }

        #endregion

        #region 내부 함수

        /// <summary>
        /// 이 객체를 복사한다.
        /// </summary>
        public override DrawObject Clone()
        {
            EllipseObject ellipseObject = new EllipseObject();
            ellipseObject.Rectangle = this.Rectangle;

            FillDrawObjectFields(ellipseObject);
            return ellipseObject;
        }

        /// <summary>
        /// 이 객체를 그려준다.
        /// </summary>
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, PenWidth))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawEllipse(pen, RectangleObject.GetNormalizedRectangle(Rectangle));

                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    g.FillEllipse(brush, Rectangle);
                }
            }

        }

        #endregion
    }
}
