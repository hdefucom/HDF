using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace DCSoft.Writer.WinFormDemo.ASPNETDemoLauncherTest
{
    public class BsnameId
    {
        public BsnameId() { }
        /// <summary>
        /// 依据文件名读取注册表，获取文件路径，若指定文件不存在，则返回空值。   
        /// </summary>
        ///  <param name="exe">端口数值</param>
        /// <returns></returns>
        public  string BsnmIdtoString(string exe)
        {
            string strKeyName = "";     //"(Default)" key, which contains the intalled path
            string objResult = null;
            RegistryKey regSubKey = null;
            
            using (regSubKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + exe + ".exe", false))
            {   //Read the path
                if (regSubKey !=null)
                {
                    objResult = Convert.ToString(regSubKey.GetValue(strKeyName));
                    return objResult;
                }
            }
            
            return null;
        }
        /// <summary>
        /// 依据文件名读取注册表，获取文件路径，若指定文件不存在，则返回空值。  
        /// </summary>
        ///  <param name="exe">端口数值</param>
        /// <returns></returns>
        public  string BsnmIdttoString(string exe)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                if (key != null)//判断对象存在
                {
                    foreach (string keyName in key.GetSubKeyNames())//遍历子项名称的字符串数组
                    {
                        using (RegistryKey key2 = key.OpenSubKey(keyName, false))//遍历子项节点
                        {
                            if (key2 != null)
                            {
                                string softwareName = key2.GetValue("DisplayName", "").ToString();//获取软件名
                                if(softwareName.IndexOf(exe)>-1 )
                                {
                                    string installLocation = key2.GetValue("InstallLocation", "").ToString() ;//获取安装路径
                                    return installLocation;
                                 } 
                             }
                          }
                      }
                  }
              }
            return null;
        }
     }
    
}
