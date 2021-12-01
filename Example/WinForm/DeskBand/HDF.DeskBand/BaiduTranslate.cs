using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using HDF.DeskBand;
using System.Windows.Forms;

namespace Baidu
{
    public class BaiduTranslate
    {

        /// <summary>
        /// 通用翻译api实体
        /// </summary>
        public class BaiduTranslateApiResult
        {
            public string from { get; set; }
            public string to { get; set; }
            public TranslateResult[] trans_result { get; set; }
            public string error_code { get; set; }


            public class TranslateResult
            {
                public string src { get; set; }
                public string dst { get; set; }
            }
        }

        /// <summary>
        /// 语种识别api实体
        /// </summary>
        public class BaiduLanguageApiResult
        {
            public string error_code { get; set; }
            public string error_msg { get; set; }
            public LanguageResult data { get; set; }


            public class LanguageResult
            {
                public string src { get; set; }
            }

        }



        public static string AppID;
        public static string SecretKey;


        public static BaiduTranslateApiResult Translate(string str, string from = "auto", string to = "auto")
        {
            if (string.IsNullOrEmpty(AppID) || string.IsNullOrEmpty(SecretKey))
                return null;
            // 原文
            string q = str;
            // 源语言
            //string from = "en";
            // 目标语言
            //string to = "zh";
            // 改成您的APP ID
            string appId = AppID;
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // 改成您的密钥
            string secretKey = SecretKey;
            string sign = EncryptString(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            url += "q=" + HttpUtility.UrlEncode(q);
            url += "&from=" + from;
            url += "&to=" + to;
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream myResponseStream = response.GetResponseStream())
            {
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<BaiduTranslateApiResult>(retString);
                return obj;
            }
        }


        public static BaiduLanguageApiResult Language(string str)
        {
            if (string.IsNullOrEmpty(AppID) || string.IsNullOrEmpty(SecretKey))
                return null;
            // 原文
            string q = str;
            // 源语言
            //string from = "en";
            // 目标语言
            //string to = "zh";
            // 改成您的APP ID
            string appId = AppID;
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // 改成您的密钥
            string secretKey = SecretKey;
            string sign = EncryptString(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/language?";
            url += "q=" + HttpUtility.UrlEncode(q);
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream myResponseStream = response.GetResponseStream())
            {
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<BaiduLanguageApiResult>(retString);
                return obj;
            }

        }




        // 计算MD5值
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }




    }
}
