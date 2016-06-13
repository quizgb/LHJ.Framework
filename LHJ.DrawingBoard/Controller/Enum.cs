using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.DrawingBoard.Controller
{
    /// <summary>
    /// 옵저버 패턴에서 사용하는 Action 
    /// </summary>    
    public enum ObserverAction
    {
        Invalidate,   //다시 그리기
        Command,      //실행취소와 다시실행
        Rectangle,    //사각형
        Ellipse,      //원
        Line,         //줄
        Pencil,       //연필
        Select,       //선택
        FileLoad,     //불러오기
        FileSave,     //저장하기
        New           //새로 만들기
    };

    /// <summary>
    /// IObserver 를 상속 받아서 구현하는 구독자의 이름
    /// </summary>   
    public enum ObserverName
    {
        MainView,   //메인화면
        DrawBox,    //그리기 상자
        ToolBar     //상단 툴바
    }

    /// <summary>
    /// 그리기와 관련된 객체의 타입
    /// </summary>
    public enum DrawObjectType
    {
        Rectangle,  //사각형
        Ellipse,    //원
        Line,       //줄
        Pencil,     //연필
        Select      //선택
    };

    /// <summary>
    /// DrawBox 에서 현재 선택된 상태
    /// </summary>
    public enum SelectMode
    {
        None,            //아무것도 선택되지 않음
        NetSelection,   //영역으로 선택
        Move,           //이동
        Size            //사이즈 변경
    };
}
