using LHJ.Common.Definition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LHJ.Common.Common.Com
{
    public class Cryptography
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public Cryptography()
        {
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
        /// 암호화 Function (AES256 암호화 알고리즘 적용)
        /// </summary>
        /// <param name="pOriStr">원문</param>
        /// <returns>암호화 문자열</returns>
        public static String FN_ENCRPT(String pOriStr)
        {
            String tmpOriStr = tmpOriStr = pOriStr.ToString();

            // Rihndael class를 선언하고, 초기화
            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            // 입력받은 문자열을 바이트 배열로 변환
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(tmpOriStr);

            // 딕셔너리 공격을 대비해서 키를 더 풀기 어렵게 만들기 위해서 
            // Salt를 사용한다.
            byte[] Salt = Encoding.ASCII.GetBytes(ConstValue.ServerInfoMonitor_General.ENCRPT_KEY.Length.ToString());

            // PasswordDeriveBytes 클래스를 사용해서 SecretKey를 얻는다.
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ConstValue.ServerInfoMonitor_General.ENCRPT_KEY, Salt);

            // Create a encryptor from the existing SecretKey bytes.
            // encryptor 객체를 SecretKey로부터 만든다.
            // Secret Key에는 32바이트
            // (Rijndael의 디폴트인 256bit가 바로 32바이트입니다)를 사용하고, 
            // Initialization Vector로 16바이트
            // (역시 디폴트인 128비트가 바로 16바이트입니다)를 사용한다.
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

            // 메모리스트림 객체를 선언,초기화 
            MemoryStream memoryStream = new MemoryStream();

            // CryptoStream객체를 암호화된 데이터를 쓰기 위한 용도로 선언
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);

            // 암호화 프로세스가 진행된다.
            cryptoStream.Write(PlainText, 0, PlainText.Length);

            // 암호화 종료
            cryptoStream.FlushFinalBlock();

            // 암호화된 데이터를 바이트 배열로 담는다.
            byte[] CipherBytes = memoryStream.ToArray();

            // 스트림 해제
            memoryStream.Close();
            cryptoStream.Close();

            // 암호화된 데이터를 Base64 인코딩된 문자열로 변환한다.
            string EncryptedData = Convert.ToBase64String(CipherBytes);

            // 최종 결과를 리턴
            return EncryptedData;
        }

        /// <summary>
        /// 복호화 Function (AES256 암호화 알고리즘 적용)
        /// </summary>
        /// <param name="pEncrptStr">암호화 문자열</param>
        /// <returns>원문</returns>
        public static String FN_DECRPT(String pEncrptStr)
        {
            String tmpEncrptStr = pEncrptStr.ToString();

            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            byte[] EncryptedData = Convert.FromBase64String(tmpEncrptStr);
            byte[] Salt = Encoding.ASCII.GetBytes(ConstValue.ServerInfoMonitor_General.ENCRPT_KEY.Length.ToString());

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ConstValue.ServerInfoMonitor_General.ENCRPT_KEY, Salt);

            // Decryptor 객체를 만든다.
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

            MemoryStream memoryStream = new MemoryStream(EncryptedData);

            // 데이터 읽기(복호화이므로) 용도로 cryptoStream객체를 선언, 초기화
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

            // 복호화된 데이터를 담을 바이트 배열을 선언한다.
            // 길이는 알 수 없지만, 일단 복호화되기 전의 데이터의 길이보다는
            // 길지 않을 것이기 때문에 그 길이로 선언한다.
            byte[] PlainText = new byte[EncryptedData.Length];

            // 복호화 시작
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);

            memoryStream.Close();
            cryptoStream.Close();

            // 복호화된 데이터를 문자열로 바꾼다.
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);

            // 최종 결과 리턴
            return DecryptedData;

        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event  
    }
}
