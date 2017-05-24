using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.ServerInfoMonitor
{
    public class ServerListParam
    {
        public string MyName;
        public Color MyColor;
        public int MyAge;
        public string FriendName;
        public Color FriendColor;
        public int FriendAge;
        [CategoryAttribute("나"),
        DescriptionAttribute("내 이름")]
        public string 내이름
        {
            get { return MyName; }
        }
        [CategoryAttribute("나"),
        DescriptionAttribute("내 색깔")]
        public Color 내색깔
        {
            get { return MyColor; }
        }
        [CategoryAttribute("나"),
        DescriptionAttribute("내 나이")]
        public int 내나이
        {
            get { return MyAge; }
        }
        [CategoryAttribute("친구"),
        DescriptionAttribute("친구 이름")]
        public string 친구이름
        {
            get { return FriendName; }
            set { FriendName = value; }
        }
        [CategoryAttribute("친구"),
        DescriptionAttribute("친구 색깔")]
        public Color 친구색깔
        {
            get { return FriendColor; }
            set { FriendColor = value; }
        }
        [CategoryAttribute("친구"),
        DescriptionAttribute("친구 나이")]
        public int 친구나이
        {
            get { return FriendAge; }
            set { FriendAge = value; }
        }
    }
}
