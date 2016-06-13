using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LHJ.DrawingBoard.Controller;

namespace LHJ.DrawingBoard.Observer
{
    /// <summary>
    /// 옵저버를 구성하고 관리하는 인터페이스
    /// </summary>
    interface IObservable
    {
        /// <summary>
        /// 구독자들로부터 알려야 할 내용이 있을 때 호출되는 함수
        /// </summary>
        void Notify(ObserverAction action);

        /// <summary>    
        /// 구독자들로부터 알려야 할 내용이 있을 때 호출되는 함수  
        /// </summary>
        void Notify(ObserverClass observer);

        /// <summary>
        /// 구독자들을 등록하는 함수
        /// </summary>
        IDisposable Subscribe(IObserver observer);

        /// <summary>
        /// 구독자들을 해제하는 함수
        /// </summary>
        void Unsubscribe(IObserver observer);
    }
}
