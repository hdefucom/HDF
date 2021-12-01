using System;
using System.IO;
using System.Net;
using System.Text;

namespace ZYCommon
{
	public class ZYTime
	{
		public static DateTime GetServerTime()
		{
			return DateTime.Now;
		}

		public static string DoHttpRequest(string strWWWAddress)
		{
			string result = "";
			HttpWebRequest httpWebRequest = null;
			Stream stream = null;
			HttpWebResponse httpWebResponse = null;
			StreamReader streamReader = null;
			Encoding uTF = Encoding.UTF8;
			try
			{
				httpWebRequest = (HttpWebRequest)WebRequest.Create(strWWWAddress);
				httpWebRequest.Method = "GET";
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				streamReader = new StreamReader(httpWebResponse.GetResponseStream(), uTF);
				result = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader = null;
				httpWebResponse.Close();
				httpWebResponse = null;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				stream?.Close();
				streamReader?.Close();
				httpWebResponse?.Close();
			}
			return result;
		}
	}
}
