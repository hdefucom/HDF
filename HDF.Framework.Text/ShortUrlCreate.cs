using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Framework.Text
{
    internal class ShortUrlCreate
    {

        public static string[] ShortUrl(string url)
        {
            //可以自定义生成MD5加密字符传前的混合KEY
            string key = "Freemud";
            //要使用生成URL的字符
            string[] chars = new string[]
            {
                 "a", "b", "c", "d", "e", "f", "g", "h",
                 "i", "j", "k", "l", "m", "n", "o", "p",
                 "q", "r", "s", "t", "u", "v", "w", "x",
                 "y", "z", "0", "1", "2", "3", "4", "5",
                "6", "7", "8", "9", "A", "B", "C", "D",
              "E", "F", "G", "H", "I", "J", "K", "L",
               "M", "N", "O", "P", "Q", "R", "S", "T",
                "U", "V", "W", "X", "Y", "Z"
           };
            //对传入网址进行MD5加密
            string hex = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key + url, "md5");
            string[] resUrl = new string[4];
            for (int i = 0; i < 4; i++)
            {
                //把加密字符按照8位一组16进制与0x3FFFFFFF进行位与运算
                int hexint = 0x3FFFFFFF & Convert.ToInt32("0x" + hex.Substring(i * 8, 8), 16);
                string outChars = string.Empty;
                for (int j = 0; j < 6; j++)
                {
                    //把得到的值与0x0000003D进行位与运算，取得字符数组chars索引
                    int index = 0x0000003D & hexint;
                    //把取得的字符相加
                    outChars += chars[index];
                    //每次循环按位右移5位
                    hexint = hexint >> 5;
                }
                //把字符串存入对应索引的输出数组
                resUrl[i] = outChars;
            }
            return resUrl;
        }





        public static string GetShortUrl(string url)
        {
            //可以自定义生成MD5加密字符传前的混合KEY
            string key = DateTime.Now.ToString();
            //要使用生成URL的字符
            string[] chars = new string[]{
             "a","b","c","d","e","f","g","h",
             "i","j","k","l","m","n","o","p",
             "q","r","s","t","u","v","w","x",
             "y","z","0","1","2","3","4","5",
             "6","7","8","9","A","B","C","D",
             "E","F","G","H","I","J","K","L",
             "M","N","O","P","Q","R","S","T",
             "U","V","W","X","Y","Z"
              };

            //对传入网址进行MD5加密

            using MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.Default.GetBytes(key + url);
            byte[] encryptdata = md5.ComputeHash(bytes);
            var res = BitConverter.ToString(encryptdata);
            res = res.Replace("-", "");

            string hex = res;
            //string hex = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key + url, "md5");

            string[] resUrl = new string[4];
            for (int i = 0; i < 4; i++)
            {
                //把加密字符按照8位一组16进制与0x3FFFFFFF进行位与运算
                int hexint = 0x3FFFFFFF & Convert.ToInt32("0x" + hex.Substring(i * 8, 8), 16);
                string outChars = string.Empty;
                for (int j = 0; j < 6; j++)
                {
                    //把得到的值与0x0000003D进行位与运算，取得字符数组chars索引
                    int index = 0x0000003D & hexint;
                    //把取得的字符相加
                    outChars += chars[index];
                    //每次循环按位右移5位
                    hexint = hexint >> 5;
                }
                //把字符串存入对应索引的输出数组
                resUrl[i] = outChars;
            }
            return resUrl[new Random().Next(0, 3)];
        }



    }
}
