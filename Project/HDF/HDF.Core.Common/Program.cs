using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace HDF.Core.Common
{
    class Program
    {
        static void Main(string[] args)
        {



            SizeF sf = new Size();


            PointF pf = new Point();


            RectangleF rf = new Rectangle();




            var a = ToMD5("1");
            Console.WriteLine("Hello World!");
        }






        public static string ToMD5(string str)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] bytes = Encoding.Default.GetBytes(str);//将要加密的字符串转换为字节数组
                byte[] encryptdata = md5.ComputeHash(bytes);//将字符串加密后也转换为字符数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为加密字符串
            }
        }



    }









}
