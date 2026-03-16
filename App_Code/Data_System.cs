using System;
using System.Configuration;
using System.Web.Security;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
///Data_System 的摘要说明
/// </summary>
namespace WebQywy
{
    public class Data_System
    {
        public static SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
        public const string Key = "qwrasdfq23)(*_&**&^;ldgjhwert";
        public static byte[] DesKey = { 0xEA, 0xC, 0x7, 0x56, 0x5A, 0x41, 0xBF, 0xB1 };
        public static byte[] DesIV = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef };

        /// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        public static byte[] GetLegalKey()
        {
            string sTemp = Key;
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初始向量IV</returns>
        public static byte[] GetLegalIV()
        {
            string sTemp = "80jadeDness63orTizlUcIo1asdfasdfasdfasdfegheyreudf(*&*(^*&^0wqrjljsdlrrolD22976"; // 任意字符串
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public static string Encrypto(string Source)
        {
            try
            {
                byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
                MemoryStream ms = new MemoryStream();
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(bytIn, 0, bytIn.Length);
                cs.FlushFinalBlock();
                ms.Close();
                byte[] bytOut = ms.ToArray();
                return Convert.ToBase64String(bytOut);
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public static string Decrypto(string Source)
        {
            try
            {

                byte[] bytIn = Convert.FromBase64String(Source);
                MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch { }
            return "";

        }

        /// <summary>
        /// Des加密方法
        /// </summary>
        /// <param name="Source">源字符串</param>
        /// <returns>加密完的串</returns>
        public static string EncryptDes(string Source)
        {
            try
            {
                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();

                DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                DES.Mode = CipherMode.ECB;

                ICryptoTransform DESEncrypt = DES.CreateEncryptor();

                byte[] Buffer = Encoding.Default.GetBytes(Source);
                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// Des解密方法
        /// </summary>
        /// <param name="Source">加密码串</param>
        /// <returns>解密串</returns>
        public static string DecryptDes(string Source)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();

            DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
            DES.Mode = CipherMode.ECB;

            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(Source);
                result = Encoding.Default.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception e)
            {
                result = "";
            }

            return result;
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="Passowrd">待加密的字符串</param>
        /// <returns>返回已经加密的字符串</returns>
        public static string Encrypt(string Password)
        {
            string str = "";
            FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(Password, true, 2);
            str = FormsAuthentication.Encrypt(ticket).ToString();
            return str;
        }

        /// <summary>
        /// 解密字符串，与Encrypt()方法对应
        /// </summary>
        /// <param name="Passowrd">待解密的字符串</param>
        /// <returns>返回已经解密的字符串</returns>
        public static string Decrypt(string Passowrd)
        {
            string str = "";
            str = FormsAuthentication.Decrypt(Passowrd).Name.ToString();
            return str;
        }

        /// <summary>
        /// 加密字符串，采用SHA1或MD5加密，不可逆
        /// </summary>
        /// <param name="Password">待加密的字符串</param>
        /// <param name="Format">0 － SHA1,1 － MD5</param>
        /// <returns>返回加密的结果</returns>
        public static string Encrypt(string Password, int Format)
        {
            string str = "";
            switch (Format)
            {
                case 0:
                    str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
                    break;
                case 1:
                    str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                    break;
            }
            return str;
        }

        /// <summary>
        /// 转换字符串，按照指定类型进行转换
        /// </summary>
        /// <param name="strCookie">待转换cookie</param>
        /// <param name="type">数字，根据数字调用不同方法</param>
        /// <returns>返回加密的cookie</returns>
        private static string En(string strCookie, int type)
        {
            string str;
            if (type % 2 == 0)
            {
                str = Transform1(strCookie);
            }
            else
            {
                str = Transform3(strCookie);
            }

            str = Transform2(strCookie);
            return str;
        }

        /// <summary>
        /// 转换字符串，按照指定类型进行转换，与方法En()对应
        /// </summary>
        /// <param name="strCookie">待转换cookie</param>
        /// <param name="type">数字，根据数字调用不同方法</param>
        /// <returns>返回加密的cookie</returns>
        private static string De(string strCookie, int type)
        {
            string str;
            if (type % 2 == 0)
            {
                str = DeTransform1(strCookie);
            }
            else
            {
                str = DeTransform3(strCookie);
            }

            str = Transform2(strCookie);
            return str;
        }

        /// <summary>
        /// 方法一：将指定的字符串编码
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>已编码的字符串</returns>
        public static string Transform1(string str)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();

            foreach (char a in str)
            {
                switch (i % 6)
                {
                    case 0:
                        sb.Append((char)(a + 1));
                        break;
                    case 1:
                        sb.Append((char)(a + 5));
                        break;
                    case 2:
                        sb.Append((char)(a + 7));
                        break;
                    case 3:
                        sb.Append((char)(a + 2));
                        break;
                    case 4:
                        sb.Append((char)(a + 4));
                        break;
                    case 5:
                        sb.Append((char)(a + 9));
                        break;
                }
                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 方法一：将指定的字符串翻译码，与方法Transform1()对应
        /// </summary>
        /// <param name="str">待译码的字符串</param>
        /// <returns>已译码的字符串</returns>
        public static string DeTransform1(string str)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();

            foreach (char a in str)
            {
                switch (i % 6)
                {
                    case 0:
                        sb.Append((char)(a - 1));
                        break;
                    case 1:
                        sb.Append((char)(a - 5));
                        break;
                    case 2:
                        sb.Append((char)(a - 7));
                        break;
                    case 3:
                        sb.Append((char)(a - 2));
                        break;
                    case 4:
                        sb.Append((char)(a - 4));
                        break;
                    case 5:
                        sb.Append((char)(a - 9));
                        break;
                }
                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 方法二：将指定的字符串编码
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>已编码的字符串</returns>
        public static string Transform3(string str)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();

            foreach (char a in str)
            {
                switch (i % 6)
                {
                    case 0:
                        sb.Append((char)(a + 3));
                        break;
                    case 1:
                        sb.Append((char)(a + 6));
                        break;
                    case 2:
                        sb.Append((char)(a + 8));
                        break;
                    case 3:
                        sb.Append((char)(a + 7));
                        break;
                    case 4:
                        sb.Append((char)(a + 5));
                        break;
                    case 5:
                        sb.Append((char)(a + 2));
                        break;
                }
                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 方法一：将指定的字符串翻译码，与方法Transform３()对应
        /// </summary>
        /// <param name="str">待译码的字符串</param>
        /// <returns>已译码的字符串</returns>
        public static string DeTransform3(string str)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();

            foreach (char a in str)
            {
                switch (i % 6)
                {
                    case 0:
                        sb.Append((char)(a - 3));
                        break;
                    case 1:
                        sb.Append((char)(a - 6));
                        break;
                    case 2:
                        sb.Append((char)(a - 8));
                        break;
                    case 3:
                        sb.Append((char)(a - 7));
                        break;
                    case 4:
                        sb.Append((char)(a - 5));
                        break;
                    case 5:
                        sb.Append((char)(a - 2));
                        break;
                }
                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 方法一与方法二需要调用的功用函数
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>已编码的字符串</returns>
        public static string Transform2(string str)
        {
            uint j = 0;
            StringBuilder sb = new StringBuilder();

            str = Reverse(str);
            foreach (char a in str)
            {
                j = a;
                if (j > 255)
                {
                    j = (uint)((a >> 8) + ((a & 0x0ff) << 8));
                }
                else
                {
                    j = (uint)((a >> 4) + ((a & 0x0f) << 4));
                }
                sb.Append((char)j);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 将指定的字符反过来显示
        /// </summary>
        /// <param name="str">待反转的字符</param>
        /// <returns>反转后的字符</returns>
        public static string Reverse(string str)
        {
            int i;
            StringBuilder sb = new StringBuilder();

            for (i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 判断一个字符串是否只包含汉字
        /// </summary>
        /// <param name="testStr"></param>
        /// <returns></returns>
        public static bool IsOnlyContainsChinese(string testStr)
        {
            char[] words = testStr.ToCharArray();
            foreach (char word in words)
            {
                if (IsGBCode(word.ToString()) || IsGBKCode(word.ToString())) // it is a GB2312 or GBK 
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断一个word是否为GB2312编码的汉字
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool IsGBCode(string word)
        {
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(word);
            if (bytes.Length <= 1) // if there is only one byte, it is ASCII code or other code
            {
                return false;
            }
            else
            {
                byte byte1 = bytes[0];
                byte byte2 = bytes[1];
                if (byte1 >= 176 && byte1 <= 247 && byte2 >= 160 && byte2 <= 254) //判断是否是GB2312
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// 判断一个word是否为GBK编码的汉字
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool IsGBKCode(string word)
        {
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(word.ToString());
            if (bytes.Length <= 1) // if there is only one byte, it is ASCII code
            {
                return false;
            }
            else
            {
                byte byte1 = bytes[0];
                byte byte2 = bytes[1];
                if (byte1 >= 129 && byte1 <= 254 && byte2 >= 64 && byte2 <= 254) //判断是否是GBK编码
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 检索所有中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string IsChinese(string str)
        {
            string c="";
            string unipp = @"[\u4e00-\u9fa5]+";                     //写出匹配原则，[\u4e00-\u9fa5]为匹配所有的汉字。也包括繁体中文。
            foreach (Match m in Regex.Matches(str, unipp))   //循环打印所有匹配的汉子。
            {
                c += m.ToString();                 
            }
            return c;
        }
    }
}