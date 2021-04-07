using System;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace HDF.Framework.Common
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public static class EncryptionHelper
    {
        /// <summary>
        /// 将传入的字符串以MD5的方式加密后返回
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string ToMD5(this string str)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] bytes = Encoding.Default.GetBytes(str);//将要加密的字符串转换为字节数组
                byte[] encryptdata = md5.ComputeHash(bytes);//将字符串加密后也转换为字符数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为加密字符串
            }
        }






        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }
            return Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
