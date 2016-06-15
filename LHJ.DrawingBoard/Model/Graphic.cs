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
        #region 1.Variable
        /// <summary>
        /// DrawObject 형 List
        /// </summary>
        private List<DrawObject> mGrapList = new List<DrawObject>();
        #endregion 1.Variable


        #region 2.Property
        public List<DrawObject> GrapList
        {
            get
            {
                return this.mGrapList;
            }

            set
            {
                this.mGrapList = value;
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

                foreach (DrawObject obj in this.mGrapList)
                {
                    if (obj.Selected)
                    {
                        i++;
                    }
                }

                return i;
            }
        }
        #endregion 2.Property


        #region 3.Constructor

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

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
