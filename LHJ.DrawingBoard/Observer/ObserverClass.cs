using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LHJ.DrawingBoard.Controller;

namespace LHJ.DrawingBoard.Observer
{
    /// <summary>
    /// 옵저버에게 통보를 할 때 매개변수로 사용되는 클래스.
    /// 본 클래스의 목적은 ObserverName 에  따라서 처리 할지 말지를 구분하기 위해서 사용된다.
    /// 예를 들어 MainView 에서 Next 가 실행 될 때, ObserverName 이 ToolBar 일 때만 ObserverAction 을 실행한다.
    /// </summary>
    public class ObserverClass
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property
        public ObserverName Name { get; set; }
        public ObserverAction Action { get; set; }
        #endregion 2.Property


        #region 3.Constructor
        public ObserverClass(string aName)
        {
            Name = GetName(aName);
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
        //ObserverName 을 반환한다.
        private ObserverName GetName(string aName)
        {
            switch (aName)
            {
                case "MainView": return ObserverName.MainView;
                case "ToolBar": return ObserverName.ToolBar;
                case "DrawBox": return ObserverName.DrawBox;
            }

            //일치하는 name 이 없다면 ObserverName.MainView 을 반환한다.
            return ObserverName.MainView;
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
