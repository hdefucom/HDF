using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

namespace DCSoft.Writer.WinFormDemo.ASPNETDemoLauncherTest
{
    public class PortInUse
    {
        /// <summary>
        /// //检查端口是否被占用！占用则返回true。  
        /// </summary>
        ///  <param name="port">端口数值</param>
        /// <returns></returns>
        
        public static bool PortInUseBl(int port)
        {
            bool inUse = false;
            //sjm
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();//获取目前端口列表
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();//

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)//检查端口是否被占用！
                {
                    inUse = true;
                    break;
                }
            }

            return inUse;
        }
    }

}
