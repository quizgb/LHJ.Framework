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
        public class DesktopSizeItmCvt : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(mDesktopSizeItm);
            }
        }

        public class ColorDepthItmCvt : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(mColorDepthItm);
            }
        }

        #region 1.Variable
        public static List<string> mDesktopSizeItm;
        public static List<string> mColorDepthItm;

        private string mServerName = string.Empty;
        private string mIPAddr = string.Empty;
        private string mUserName = string.Empty;
        private string mPassWord = string.Empty;
        private bool mFullScreen = false;
        private bool mRedirectDrives = true;
        private bool mRedirectClipboard = true;
        private bool mRedirectPrinters = true;
        private bool mSmartSizing = true;
        private string mDesktopSize = string.Empty;
        private string mColorDepth = string.Empty;
        #endregion 1.Variable


        #region 2.Property
        [CategoryAttribute("서버정보"),
        DescriptionAttribute("서버의 명칭입니다.")]
        public string A_서버명칭
        {
            get { return this.mServerName; }
            set { this.mServerName = value; }
        }

        [CategoryAttribute("서버정보"),
        DescriptionAttribute("서버 IP 주소입니다.")]
        public string B_IP주소
        {
            get { return this.mIPAddr; }
            set { this.mIPAddr = value; }
        }

        [CategoryAttribute("서버정보"),
        DescriptionAttribute("사용자 이름입니다.")]
        public string C_사용자이름
        {
            get { return this.mUserName; }
            set { this.mUserName = value; }
        }

        [CategoryAttribute("서버정보"),
        DescriptionAttribute("비밀번호입니다.")]
        public string D_비밀번호
        {
            get { return this.mPassWord; }
            set { this.mPassWord = value; }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격화면의 전체화면 여부를 지정합니다.")]
        public bool A_FullScreen
        {
            get { return this.mFullScreen; }
            set { this.mFullScreen = value; }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격 연결하는 컴퓨터의 디스크(저장 장치) 접근 여부를 지정합니다.")]
        public bool B_RedirectDrives
        {
            get { return this.mRedirectDrives; }
            set { this.mRedirectDrives = value; }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격 연결하는 컴퓨터와의 클립보드 공유 여부를 지정합니다.")]
        public bool C_RedirectClipboard
        {
            get { return this.mRedirectClipboard; }
            set { this.mRedirectClipboard = value; }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격 연결하는 컴퓨터의 프린터 접근 여부를 지정합니다.")]
        public bool D_RedirectPrinters
        {
            get { return this.mRedirectPrinters; }
            set { this.mRedirectPrinters = value; }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격 화면 크기를 화면에 맞게 강제 지정합니다.")]
        public bool E_SmartSizing
        {
            get { return this.mSmartSizing; }
            set { this.mSmartSizing = value; }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격 화면 크기를 화면에 맞게 강제 지정합니다.")]
        [TypeConverter(typeof(DesktopSizeItmCvt))]
        public string F_DesktopSize
        {
            get
            {
                string S = string.Empty;

                if (this.mDesktopSize != null)
                {
                    S = this.mDesktopSize;
                }
                else
                {
                    S = mDesktopSizeItm[0];
                }

                return S;
            }
            set
            {
                this.mDesktopSize = value;
            }
        }

        [CategoryAttribute("화면정보"),
        DescriptionAttribute("원격 화면의 색을 지정합니다.")]
        [TypeConverter(typeof(ColorDepthItmCvt))]
        public string G_ColorDepth
        {
            get
            {
                string S = string.Empty;

                if (this.mColorDepth != null)
                {
                    S = this.mColorDepth;
                }
                else
                {
                    S = mColorDepthItm[0];
                }

                return S;
            }
            set
            {
                this.mColorDepth = value;
            }
        }
        #endregion 2.Property


        #region 3.Constructor
        public ServerListParam()
        {
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
            mDesktopSizeItm = new List<string>();

            mDesktopSizeItm.Add("800X600");
            mDesktopSizeItm.Add("1024X768");
            mDesktopSizeItm.Add("1280X1024");
            mDesktopSizeItm.Add("1366X768");
            mDesktopSizeItm.Add("1440X900");
            mDesktopSizeItm.Add("1600X1200");
            mDesktopSizeItm.Add("1920X1080");
            mDesktopSizeItm.Add("FullScreen");
            mDesktopSizeItm.Add("CurrentViewSize");

            mColorDepthItm = new List<string>();

            mColorDepthItm.Add("256 Color(8 Bit)");
            mColorDepthItm.Add("High Color(16 Bit)");
            mColorDepthItm.Add("True Color(24 Bit)");
            mColorDepthItm.Add("Maximum Color(32 Bit)");
        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event  
    }
}
