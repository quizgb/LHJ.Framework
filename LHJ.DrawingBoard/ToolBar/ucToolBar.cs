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
        #region 전역변수

        /// <summary>
        /// 툴바의 버튼 중 그리기 도구 관련된 버튼들을 관리하는 리스트
        /// </summary>
        private List<ToolStripButton> drawButtonList = new List<ToolStripButton>();

        /// <summary>
        /// ToolBar 에서 사용할 ObserverClass
        /// </summary>
        private ObserverClass observer = new ObserverClass("ToolBar");

        #endregion

        #region 생성자

        public ucToolBar()
        {
            InitializeComponent();


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

            drawButtonList.Add(toolStripButtonEllipse);
            drawButtonList.Add(toolStripButtonLine);
            drawButtonList.Add(toolStripButtonSelect);
            drawButtonList.Add(toolStripButtonPencil);
            drawButtonList.Add(toolStripButtonRectangle);

            #endregion

            //선택하기 버튼으로 설정
            SetToolBarButtonState("Select");

            //옵저버에 ToolBar 등록
            MainController.Instance.Subscribe(this);
        }

        #endregion

        #region 옵저버 패턴

        /// <summary>
        /// 수신된 ObserverAction 에 따라서 처리 한다.
        /// </summary>
        public void OnNext(ObserverAction action)
        {
            switch (action)
            {
                case ObserverAction.Command: SetUndoRedoButton(); return;
                case ObserverAction.Invalidate: SetToolBarButtonState("Select"); return;
                case ObserverAction.Ellipse: SetToolBarButtonState("Ellipse"); return;
                case ObserverAction.Line: SetToolBarButtonState("Line"); return;
                case ObserverAction.Pencil: SetToolBarButtonState("Pencil"); return;
                case ObserverAction.Rectangle: SetToolBarButtonState("Rectangle"); return;
                case ObserverAction.Select: SetToolBarButtonState("Select"); return;
                case ObserverAction.FileLoad: SetToolBarButtonState("Select"); SetUndoRedoButton(); return;
                case ObserverAction.New: SetToolBarButtonState("Select"); SetUndoRedoButton(); return;
            }
        }

        /// <summary>
        /// 수신된 ObserverClass 와 Action 에 따라서 처리한다.
        /// </summary>
        public void OnNext(ObserverClass observer)
        {

        }

        #endregion

        #region 내부 함수

        /// <summary>
        /// 실행취소와 다시실행 버튼을 설정한다.
        /// </summary>
        public void SetUndoRedoButton()
        {
            if (MainController.Instance.Command.CanUndo)
            {
                toolStripButtonUndo.Enabled = true;
            }
            else
            {
                toolStripButtonUndo.Enabled = false;
            }

            if (MainController.Instance.Command.CanRedo)
            {
                toolStripButtonRedo.Enabled = true;
            }
            else
            {
                toolStripButtonRedo.Enabled = false;
            }
        }


        /// <summary>
        /// 그리기 도구를 선택 했을 때, 선택 된 버튼과 관련된 설정을 한다.
        /// </summary>
        /// <param name="type">버튼의 이름을 인수로 받는다.</param>
        public void SetToolBarButtonState(string buttonName)
        {
            //생성자에서 등록한 그리기 도구 버튼 리스트
            foreach (ToolStripButton item in drawButtonList)
            {
                //선택된 버튼은 배경 색깔을 DarkGray 로 변경해준다.
                if (item.Text == buttonName)
                {
                    item.Enabled = false;
                    item.BackColor = Color.DarkGray;

                    //현재 선택된 그리기 도구를 MainController 에 넣어준다.
                    MainController.Instance.DrawObjectType = GetDrawObjectType(buttonName);
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
        private DrawObjectType GetDrawObjectType(string buttonName)
        {
            switch (buttonName)
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

        #endregion

        #region ToolBar Strip 메뉴

        /// <summary>
        /// 그리기 도구(선택, 원, 사각형, 줄, 연필) 관련 항목 클릭
        /// </summary>
        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            SetToolBarButtonState(((ToolStripButton)sender).Text);
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
                    SetUndoRedoButton();
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
                    SetUndoRedoButton();
                }
            }
        }

        /// <summary>
        /// 새로 만들기
        /// </summary>
        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            //ObserverClass 의 Action 에 ObserverAction 을 입력 한 후, 옵저버에게 알린다.
            observer.Action = ObserverAction.New;
            MainController.Instance.Notify(observer);
        }

        /// <summary>
        /// 불러오기
        /// </summary>
        private void ToolStripButtonFileLoad_Click(object sender, EventArgs e)
        {
            //ObserverClass 의 Action 에 ObserverAction 을 입력 한 후, 옵저버에게 알린다.
            observer.Action = ObserverAction.FileLoad;
            MainController.Instance.Notify(observer);
        }

        /// <summary>
        /// 저장하기
        /// </summary>
        private void toolStripButtonFileSave_Click(object sender, EventArgs e)
        {
            //ObserverClass 의 Action 에 ObserverAction 을 입력 한 후, 옵저버에게 알린다.
            observer.Action = ObserverAction.FileSave;
            MainController.Instance.Notify(observer);
        }

        #endregion
    }
}
