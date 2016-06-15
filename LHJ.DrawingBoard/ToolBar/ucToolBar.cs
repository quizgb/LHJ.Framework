using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LHJ.DrawingBoard.Observer;
using LHJ.DrawingBoard.Controller;

namespace LHJ.DrawingBoard.ToolBar
{
    /// <summary>
    /// 상단의 툴바 버튼
    /// 유저 컨트롤로 만들어졌으며, IObserver 를 상속 받아서 구현한다.
    /// </summary>
    public partial class ucToolBar : UserControl, IObserver
    {
        #region 1.Variable
        /// <summary>
        /// 툴바의 버튼 중 그리기 도구 관련된 버튼들을 관리하는 리스트
        /// </summary>
        private List<ToolStripButton> mDrawButtonList = new List<ToolStripButton>();

        /// <summary>
        /// ToolBar 에서 사용할 ObserverClass
        /// </summary>
        private ObserverClass mObserver = new ObserverClass("ToolBar");
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public ucToolBar()
        {
            InitializeComponent();

            this.SetInitialize();
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
            #region 메뉴 클릭 이벤트 등록

            this.toolStripButtonNew.Click += new System.EventHandler(this.ToolStripButtonNew_Click);
            this.toolStripButtonOpen.Click += new System.EventHandler(this.ToolStripButtonFileLoad_Click);
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonFileSave_Click);
            this.toolStripButtonSelect.Click += new System.EventHandler(this.ToolStripButton_Click);
            this.toolStripButtonRectangle.Click += new System.EventHandler(this.ToolStripButton_Click);
            this.toolStripButtonEllipse.Click += new System.EventHandler(this.ToolStripButton_Click);
            this.toolStripButtonLine.Click += new System.EventHandler(this.ToolStripButton_Click);
            this.toolStripButtonPencil.Click += new System.EventHandler(this.ToolStripButton_Click);
            this.toolStripButtonUndo.Click += new System.EventHandler(this.ToolStripButtonUndo_Click);
            this.toolStripButtonRedo.Click += new System.EventHandler(this.ToolStripButtonRedo_Click);

            #endregion

            #region 툴바의 버튼 중 그리기 도구 관련된 버튼들을 drawButtonList에 추가한다.

            this.mDrawButtonList.Add(this.toolStripButtonEllipse);
            this.mDrawButtonList.Add(this.toolStripButtonLine);
            this.mDrawButtonList.Add(this.toolStripButtonSelect);
            this.mDrawButtonList.Add(this.toolStripButtonPencil);
            this.mDrawButtonList.Add(this.toolStripButtonRectangle);

            #endregion

            //선택하기 버튼으로 설정
            this.SetToolBarButtonState("Select");

            //옵저버에 ToolBar 등록
            MainController.Instance.Subscribe(this);
        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// 수신된 ObserverAction 에 따라서 처리 한다.
        /// </summary>
        public void OnNext(ObserverAction action)
        {
            switch (action)
            {
                case ObserverAction.Command: this.SetUndoRedoButton(); return;
                case ObserverAction.Invalidate: this.SetToolBarButtonState("Select"); return;
                case ObserverAction.Ellipse: this.SetToolBarButtonState("Ellipse"); return;
                case ObserverAction.Line: this.SetToolBarButtonState("Line"); return;
                case ObserverAction.Pencil: this.SetToolBarButtonState("Pencil"); return;
                case ObserverAction.Rectangle: this.SetToolBarButtonState("Rectangle"); return;
                case ObserverAction.Select: this.SetToolBarButtonState("Select"); return;
                case ObserverAction.FileLoad: this.SetToolBarButtonState("Select"); this.SetUndoRedoButton(); return;
                case ObserverAction.New: this.SetToolBarButtonState("Select"); this.SetUndoRedoButton(); return;
            }
        }

        /// <summary>
        /// 수신된 ObserverClass 와 Action 에 따라서 처리한다.
        /// </summary>
        public void OnNext(ObserverClass observer)
        {

        }

        /// <summary>
        /// 실행취소와 다시실행 버튼을 설정한다.
        /// </summary>
        public void SetUndoRedoButton()
        {
            if (MainController.Instance.Command.CanUndo)
            {
                this.toolStripButtonUndo.Enabled = true;
            }
            else
            {
                this.toolStripButtonUndo.Enabled = false;
            }

            if (MainController.Instance.Command.CanRedo)
            {
                this.toolStripButtonRedo.Enabled = true;
            }
            else
            {
                this.toolStripButtonRedo.Enabled = false;
            }
        }


        /// <summary>
        /// 그리기 도구를 선택 했을 때, 선택 된 버튼과 관련된 설정을 한다.
        /// </summary>
        /// <param name="type">버튼의 이름을 인수로 받는다.</param>
        public void SetToolBarButtonState(string aButtonName)
        {
            //생성자에서 등록한 그리기 도구 버튼 리스트
            foreach (ToolStripButton item in this.mDrawButtonList)
            {
                //선택된 버튼은 배경 색깔을 DarkGray 로 변경해준다.
                if (item.Text == aButtonName)
                {
                    item.Enabled = false;
                    item.BackColor = Color.DarkGray;

                    //현재 선택된 그리기 도구를 MainController 에 넣어준다.
                    MainController.Instance.DrawObjectType = this.GetDrawObjectType(aButtonName);
                }
                else
                {
                    //선택되지 않은 버턴들의 배경 색깔은 원래대로 되돌린다.
                    item.Enabled = true;
                    item.BackColor = Color.FromArgb(92, 92, 92);
                }

            }
        }

        /// <summary>
        /// 버튼의 이름에 따라서 DrawObjectType 을 반환한다.
        /// </summary>
        /// <param name="buttonName">버튼의 이름</param>
        /// <returns>DrawObjectType</returns>
        private DrawObjectType GetDrawObjectType(string aButtonName)
        {
            switch (aButtonName)
            {
                case "Select": return DrawObjectType.Select;
                case "Rectangle": return DrawObjectType.Rectangle;
                case "Line": return DrawObjectType.Line;
                case "Ellipse": return DrawObjectType.Ellipse;
                case "Pencil": return DrawObjectType.Pencil;
            }

            //buttonName 중에 일치하는 이름이 없다면 DrawObjectType.Select 를 기본으로 반환한다.
            return DrawObjectType.Select;
        }
        #endregion 6.Method


        #region 7.Event
        /// <summary>
        /// 그리기 도구(선택, 원, 사각형, 줄, 연필) 관련 항목 클릭
        /// </summary>
        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            this.SetToolBarButtonState(((ToolStripButton)sender).Text);
        }

        /// <summary>
        /// 실행 취소
        /// </summary>
        private void ToolStripButtonUndo_Click(object sender, EventArgs e)
        {
            //실행 취소 할 항목이 있다면 실행
            if (MainController.Instance.Command.CanUndo)
            {
                //정상적으로 실행이 취소되었다면 옵저버에게 알린다.
                if (MainController.Instance.Command.Undo())
                {
                    MainController.Instance.Notify(ObserverAction.Invalidate);

                    //실행 취소와 다시 실행 버튼의 상태를 설정한다.
                    this.SetUndoRedoButton();
                }
            }

        }

        /// <summary>
        /// 다시 실행
        /// </summary>
        private void ToolStripButtonRedo_Click(object sender, EventArgs e)
        {
            //다시 실행 할 항목이 있다면 실행
            if (MainController.Instance.Command.CanRedo)
            {
                //정상적으로 다시 실행 되었다면 옵저버에게 알린다.
                if (MainController.Instance.Command.Redo())
                {
                    MainController.Instance.Notify(ObserverAction.Invalidate);

                    //실행취소와 다시실행 버튼의 상태를 설정한다.
                    this.SetUndoRedoButton();
                }
            }
        }

        /// <summary>
        /// 새로 만들기
        /// </summary>
        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            //ObserverClass 의 Action 에 ObserverAction 을 입력 한 후, 옵저버에게 알린다.
            this.mObserver.Action = ObserverAction.New;
            MainController.Instance.Notify(this.mObserver);
        }

        /// <summary>
        /// 불러오기
        /// </summary>
        private void ToolStripButtonFileLoad_Click(object sender, EventArgs e)
        {
            //ObserverClass 의 Action 에 ObserverAction 을 입력 한 후, 옵저버에게 알린다.
            this.mObserver.Action = ObserverAction.FileLoad;
            MainController.Instance.Notify(this.mObserver);
        }

        /// <summary>
        /// 저장하기
        /// </summary>
        private void toolStripButtonFileSave_Click(object sender, EventArgs e)
        {
            //ObserverClass 의 Action 에 ObserverAction 을 입력 한 후, 옵저버에게 알린다.
            this.mObserver.Action = ObserverAction.FileSave;
            MainController.Instance.Notify(this.mObserver);
        }
        #endregion 7.Event   
    }
}
