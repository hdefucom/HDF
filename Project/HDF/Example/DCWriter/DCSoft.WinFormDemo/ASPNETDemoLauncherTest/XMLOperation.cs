using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.ASPNETDemoLauncherTest
{
    class XMLOperation
    {

        public void WriteXmlNodes(string filename, string exepath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filename);
                XmlNode root = xmlDoc.SelectSingleNode("Exepath");//查找﹤bookstore﹥

                XmlElement xesub1 = xmlDoc.CreateElement("title");
                xesub1.InnerText = exepath;//设置节点的文本值

                root.AppendChild(xesub1);//添加到﹤bookshop﹥节点中
                
                xmlDoc.Save(filename); //保存其更改

            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
            }
        }
        public static string ReadXmlNodes(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string filepath = "";

            try
            {
                xmlDoc.Load(filename);
                XmlElement rootElem = xmlDoc.DocumentElement;
                XmlNodeList xnList = xmlDoc.GetElementsByTagName("title");

                foreach (XmlNode xn in xnList)
                {
                    //无法使用xn["ActivityId"].InnerText
                    if (filepath != "")
                    {
                        filepath = filepath + "," + xn.InnerText;
                    }
                    else
                    {
                        filepath = xn.InnerText;
                    }
                }
                return filepath;
            }
            catch (Exception e)
            {
                //显示错误信息  
                //Console.WriteLine(e.Message);
                return filepath;
            }

        }
    }
}
