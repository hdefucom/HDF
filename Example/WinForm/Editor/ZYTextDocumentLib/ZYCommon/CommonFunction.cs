using System.Drawing;
using System.IO;
using System.Net;

namespace ZYCommon
{
	public class CommonFunction
	{
		public static byte[] HttpPostData(string strURL, byte[] bytSend, ProgressHandler SendProgress, ProgressHandler AcceptProgress)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
			httpWebRequest.Method = "POST";
			Stream requestStream = httpWebRequest.GetRequestStream();
			int num = 0;
			SendProgress?.Invoke(0, bytSend.Length);
			while (num < bytSend.Length)
			{
				if (num + 1024 > bytSend.Length)
				{
					requestStream.Write(bytSend, num, bytSend.Length - num);
					num = bytSend.Length;
				}
				else
				{
					requestStream.Write(bytSend, num, 1024);
					num += 1024;
				}
				SendProgress?.Invoke(num, bytSend.Length);
			}
			SendProgress?.Invoke(bytSend.Length, bytSend.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = null;
			httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
			requestStream = httpWebResponse.GetResponseStream();
			MemoryStream memoryStream = new MemoryStream(1024);
			byte[] buffer = new byte[1024];
			int num2 = (int)httpWebResponse.ContentLength;
			int num3 = 0;
			AcceptProgress?.Invoke(0, num2);
			while (true)
			{
				bool flag = true;
				int num4 = requestStream.Read(buffer, 0, 1024);
				if (num4 == 0)
				{
					break;
				}
				memoryStream.Write(buffer, 0, num4);
				num3 += num4;
				if (num3 > num2)
				{
					num2 = num3;
				}
				AcceptProgress?.Invoke(num3, num2);
			}
			AcceptProgress?.Invoke(num3, num2);
			requestStream.Close();
			httpWebResponse.Close();
			httpWebRequest.Abort();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			return result;
		}

		public static int SetIntAttribute(int intAttributes, int intValue, bool bolSet)
		{
			return bolSet ? (intAttributes | intValue) : (intAttributes & ~intValue);
		}

		public static bool GetIntAttribute(int intAttributes, int intValue)
		{
			return (intAttributes & intValue) == intValue;
		}

		public static Color ConvertToColor(int intColor)
		{
			return Color.FromArgb((intColor & 0xFF0000) >> 16, (intColor & 0xFF00) >> 8, intColor & 0xFF);
		}
	}
}
