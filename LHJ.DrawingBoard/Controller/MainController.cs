using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using LHJ.DrawingBoard.Observer;

namespace LHJ.DrawingBoard.Controller
{
    /// <summary>
    /// 메인 컨트롤 역활을 할 싱글톤 클래스
    /// 쓰레드에 안전한 싱글톤
    /// </summary>
    public sealed class MainController : IObservable
    {
        #region 1.Variable
        /// <summary>
        /// 싱글톤 패턴을 위한 인스턴스
        /// </summary>
        private static MainController mInstance = null;

        /// <summary>
        /// 현재 DrawBox 에서 그려지는 DrawObject를 저장하는 컬렉션
        /// </summary>
        private Model.Graphic mGraphicModel = new Model.Graphic();
        private static readonly object mPadlock = new object();

        /// <summary>
        /// IObserver 를 상속 받은 객체를 관리하기 위한 컬렉션
        /// </summary>
        private List<IObserver> mListener = new List<IObserver>();

        /// <summary>
        /// 실행취소(Undo) 와 다시실행(Redo)를 관리하는 Command 클래스
        /// </summary>
        private Command.Command mCommand = new Command.Command();

        /// <summary>
        /// 최근에 사용한 Pen 의 두께
        /// </summary>
        private int mLastUsedPenWith = 1;

        /// <summary>
        /// 최근에 사용한 테두리의 색
        /// </summary>
        private Color mLastUsedColor = Color.Black;

        /// <summary>
        /// 최근에 사용한 배경색
        /// </summary>
        private Color mLastUsedBackColor = Color.White;
        #endregion 1.Variable


        #region 2.Property
                /// <summary>
        /// 최근에 사용한 Pen 의 두께
        /// </summary>
        public int LastUsedPenWidth
        {
            get
            {
                return this.mLastUsedPenWith;
            }

            set
            {
                this.mLastUsedPenWith = value;
            }
        }

        /// <summary>
        /// 최근에 사용한 배경색
        /// </summary>
        public Color LastUesdBackgoroundColor
        {
            get
            {
                return this.mLastUsedBackColor;
            }

            set
            {
                this.mLastUsedBackColor = value;
            }
        }

        /// <summary>
        /// 최근에 사용한 테두리의 색
        /// </summary>
        public Color LastUsedColor
        {
            get
            {
                return this.mLastUsedColor;
            }

            set
            {
                this.mLastUsedColor = value;
            }
        }


        /// <summary>
        /// 실행취소(Undo) 와 다시실행(Redo)
        /// </summary>
        public Command.Command Command
        {
            get
            {
                return this.mCommand;
            }

            set
            {
                this.mCommand = value;
            }
        }

        /// <summary>
        /// 현재 DrawBox 에 그려진 그래픽 객체 컬렉션
        /// </summary>
        public Model.Graphic GraphicModel
        {
            get
            {
                return this.mGraphicModel;
            }

            set
            {
                this.mGraphicModel = value;
            }
        }

        /// <summary>
        /// 현재 선택된 DrawObject 의 Type
        /// </summary>
        public DrawObjectType DrawObjectType
        {
            get;
            set;
        }

        /// <summary>
        /// DrawBox 에서 현재 선택된 상태
        /// </summary>
        public SelectMode SelectMode
        {
            get;
            set;
        }
        #endregion 2.Property


        #region 3.Constructor
        MainController()
        {

        }

        /// <summary>
        /// 인스턴스 반환
        /// </summary>
        public static MainController Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mPadlock)
                    {
                        if (mInstance == null)
                        {
                            mInstance = new MainController();
                        }
                    }
                }

                return mInstance;
            }
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
        /// 옵저버에 등록된 구독자들에게 ObserverAction 을 전달
        /// 전달은 받은 구독자들은 ObserverAction 에 따라서 적절한 행동을 한다.
        /// </summary>
        public void Notify(ObserverAction aAction)
        {
            foreach (IObserver item in this.mListener)
            {
                item.OnNext(aAction);
            }
        }

        /// <summary>
        /// 옵저버에 등록된 구독자들에게 ObserverClass 를 전달
        /// 전달은 받은 구독자들은 ObserverClass 의 ObserverName 과 ObserverAction 에 따라서 적절한 행동을 한다.
        /// </summary>
        public void Notify(ObserverClass aObserver)
        {
            foreach (IObserver item in this.mListener)
            {
                item.OnNext(aObserver);
            }
        }

        /// <summary>
        /// Listner에 IObserver를 상속받은 구독자들을 등록한다.
        /// </summary>
        public IDisposable Subscribe(IObserver aObserver)
        {
            this.mListener.Add(aObserver);

            return this.mListener as IDisposable;
        }

        /// <summary>
        /// Listner에 등록된 IObserver를 상속받은 구독자를 해제한다.
        /// </summary>
        /// <param name="observer"></param>
        public void Unsubscribe(IObserver aObserver)
        {
            this.mListener.Remove(aObserver);
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
