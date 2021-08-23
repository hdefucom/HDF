using System;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// ZYTime 的摘要说明。
	/// </summary>
	public class ZYTime
	{
		public ZYTime()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static System.DateTime GetServerTime()
		{
			//string strData =DoHttpRequest("http://192.168.8.1/emr/reServerTime.aspx");
			string strData=System.DateTime.Now.ToString("yyyyMMddHHmmss");
			strData= strData.PadRight(14,'0');
			return new System.DateTime
				(Convert.ToInt32(strData.Substring(0,4)),
				Convert.ToInt32(strData.Substring(4,2)),
				Convert.ToInt32(strData.Substring(6,2)) ,
				Convert.ToInt32(strData.Substring(8,2)) ,
				Convert.ToInt32(strData.Substring(10,2)) ,
				Convert.ToInt32(strData.Substring(12,2)) );

			//return StringCommon.ToDBDateTime(time,System.DateTime.Now);
		}
		public static string DoHttpRequest(string strWWWAddress)
		{
			string strResult = "";
			HttpWebRequest oRequest = null;
			Stream oInStream = null;
			HttpWebResponse oRespons = null;
			StreamReader readStream = null;
			Encoding oEncoding = Encoding.UTF8;
			try
			{
				oRequest = (HttpWebRequest)WebRequest.Create(strWWWAddress);
				oRequest.Method = "GET";
				oRespons = (HttpWebResponse)oRequest.GetResponse();
				readStream = new StreamReader(oRespons.GetResponseStream(), oEncoding );
				strResult = readStream.ReadToEnd();
				readStream.Close(); 
				readStream = null;
				//iStatusCode = oRespons.StatusCode;
				oRespons.Close(); 
				oRespons = null;

			}

			catch (Exception ex)
			{

				throw ex;

			}

			finally
			{

				if (oInStream != null) oInStream.Close();

				if (readStream != null) readStream.Close();

				if (oRespons != null) oRespons.Close();

			}

			return strResult;

		}


	}
}
