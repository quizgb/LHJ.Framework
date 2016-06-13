using System;
using System.Collections.Generic;
using System.Text;
using LHJ.DrawingBoard.DrawObjects;

namespace LHJ.DrawingBoard.Model
{
    /// <summary>
    /// DrawBox 에 그려지는 모든 Object 를 List 형으로 저장 관리하고 있다.
    /// 저정하기와 불러오기를 하기 위해서 [Serializable] 속성을 가진다.
    /// </summary>
    [Serializable]
    public class Graphic
    {
        #region 전역변수

        /// <summary>
        /// DrawObject 형 List
        /// </summary>
        private List<DrawObject> grapList = new List<DrawObject>();

        #endregion

        #region 속성

        public List<DrawObject> GrapList
        {
            get
            {
                return grapList;
            }

            set
            {
                grapList = value;
            }
        }

        /// <summary>
        /// 선택된 Object 의 숫자를 반환한다.
        /// </summary>
        public int SelectedCount
        {
            get
            {
                int i = 0;

                foreach (DrawObject obj in grapList)
                {
                    if (obj.Selected)
                    {
                        i++;
                    }
                }

                return i;
            }
        }

        #endregion
    }
}
