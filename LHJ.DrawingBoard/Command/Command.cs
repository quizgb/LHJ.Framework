using System;
using System.Collections.Generic;
using System.Text;
using LHJ.DrawingBoard.Controller;
using LHJ.DrawingBoard.DrawObjects;


namespace LHJ.DrawingBoard.Command
{
    /// <summary>
    /// 실행취소(Undo) 와 다시실행(Redo) 를 관리하는 클래스
    /// 실행 취소(Undo) 와 다시실행(Redo) 항목을 각각 Stack 으로 관리한다.
    /// </summary>
    public class Command
    {
        #region 1.Variable
        /// <summary>
        /// 실행취소(Undo) 스택
        /// List<DrawObject> 를 스택으로 쌓는다.
        /// </summary>
        private Stack<List<DrawObjects.DrawObject>> mUndoStack = new Stack<List<DrawObjects.DrawObject>>();

        /// <summary>
        /// 다시실행(Redo) 스택
        /// List<DrawObject> 를 스택으로 쌓는다.
        /// </summary>
        private Stack<List<DrawObjects.DrawObject>> mRedoStack = new Stack<List<DrawObjects.DrawObject>>();
        #endregion 1.Variable


        #region 2.Property
        /// <summary>
        /// 실행취소(Undo) 가능 여부 
        /// </summary>
        public bool CanUndo
        {
            get { return this.mUndoStack.Count > 0; }
        }

        /// <summary>
        /// 다시실행(Redo) 가능 여부
        /// </summary>
        public bool CanRedo
        {
            get { return this.mRedoStack.Count > 0; }
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
        /// <summary>
        /// Command 추가 => 실행취소(Undo) 스택에 List<DrawObjects.DrawObject>를 추가한다.
        /// </summary>
        public void AddCommand(List<DrawObjects.DrawObject> data)
        {
            //실행취소(Undo) 스택에 추가
            this.mUndoStack.Push(DataClone(data));

            //Command 가 추가 되었음을 옵저버에게 알린다.
            MainController.Instance.Notify(ObserverAction.Command);
        }

        /// <summary>
        /// 실행취소(Undo) 와 다시실행(Redo) 스택을 비운다.
        /// </summary>
        public void Clear()
        {
            this.mUndoStack.Clear();
            this.mRedoStack.Clear();
        }   


        /// <summary>
        /// 실행취소(Undo)
        /// 실행취소 후 실행취소 여부를 bool 값으로 반환한다.
        /// </summary>
        /// <returns>true or false</returns>
        public bool Undo()
        {
            if (CanUndo)
            {
                //다시실행(Redo) 스택에 현재 GrapList 를 넣어준다.
                this.mRedoStack.Push(DataClone(MainController.Instance.GraphicModel.GrapList));

                //실행취소(Undo) 스택에서 가장 최근에 들어온 값을 복사하여 현재 GrapList에 입력한다.
                MainController.Instance.GraphicModel.GrapList = this.DataClone(this.mUndoStack.Pop());

                return true;
            }

            return false;
        }

        /// <summary>
        /// 다시실행(Redo)
        /// 다시실행 후 다시실행 여부를 bool 값으로 반환한다.
        /// </summary>
        /// <returns>true or false</returns>
        public bool Redo()
        {
            if (CanRedo)
            {
                //실행취소(Undo) 스택에 현재 GrapList 를 넣어준다.
                this.mUndoStack.Push(DataClone(MainController.Instance.GraphicModel.GrapList));

                //현재 GrapList 에 다시실행(Redo) 스택에서 가장 최근에 들어온 값을 복사하여 넣어준다.
                MainController.Instance.GraphicModel.GrapList = DataClone(this.mRedoStack.Pop());

                return true;
            }

            return false;
        }

        /// <summary>
        /// List<DrawObjects.DrawObject> 을 복사하여 반환한다.
        /// </summary>
        private List<DrawObjects.DrawObject> DataClone(List<DrawObjects.DrawObject> aDrawObjects)
        {
            List<DrawObject> clone = new List<DrawObject>();

            foreach (DrawObject item in aDrawObjects)
            {
                clone.Add(item.Clone());
            }

            return clone;
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
