using System;

namespace ZYCommon
{
	
	/// <summary>
	/// 附加数据的进度信息处理委托
	/// </summary>
	/// <param name="objData" type="object">附加数据</param>
	/// <param name="CompletedStep" type="int">已经完成的步骤数</param>
	/// <param name="TotalStep" type="int">总的步骤数</param>
	public delegate void ObjectProgressHandler( object objData , int CompletedStep , int TotalStep );
 
	/// <summary>
	/// 进度信息处理委托
	/// </summary>
	/// <param name="CompletedStep" type="int">已经完成的步骤数</param>
	/// <param name="TotalStep" type="int">总的步骤数</param>
	public delegate void ProgressHandler( int CompletedStep , int TotalStep );
	
	/// <summary>
	/// 通用函数集合 
	/// </summary>
	public class CommonFunction
	{
		/// <summary>
		/// 向指定URL使用POST方法发送数据的例程,本函数不进行错误处理
		/// </summary>
		/// <param name="strURL">URL字符串</param>
		/// <param name="bytSend">要发送的二进制数据</param>
		/// <param name="SendProgress">发送数据时的进度处理</param>
		/// <param name="AcceptProgress">接受数据时的进度处理</param>
		/// <returns>接受到的二进制数据</returns>
		public static byte[] HttpPostData(
			string strURL ,
			byte[] bytSend , 
			ProgressHandler SendProgress ,
			ProgressHandler AcceptProgress )
		{
			// 发送数据
			System.Net.HttpWebRequest myReq =(System.Net.HttpWebRequest) System.Net.WebRequest.Create( strURL );
			myReq.Method = "POST" ;
			System.IO.Stream myStream = myReq.GetRequestStream();
			int iCount = 0 ;
			if( SendProgress != null)	
				SendProgress( 0 , bytSend.Length );
			while( iCount < bytSend.Length )
			{
				if( iCount + 1024 > bytSend.Length)
				{
					myStream.Write(bytSend, iCount , bytSend.Length - iCount );
					iCount = bytSend.Length ;
				}
				else
				{
					myStream.Write(bytSend , iCount , 1024);
					iCount += 1024;
				}
				if( SendProgress != null)	
					SendProgress( iCount , bytSend.Length );
			}//while
			if( SendProgress != null)	
				SendProgress( bytSend.Length  , bytSend.Length );
			myStream.Close();
			
			// 接受数据
			System.Net.HttpWebResponse myRes = null;
			myRes = myReq.GetResponse() as System.Net.HttpWebResponse ;
				
			myStream = myRes.GetResponseStream();
			System.IO.MemoryStream myBuf = new System.IO.MemoryStream(1024);
			byte[] bytBuf = new byte[1024];
			int ContentLength = (int)myRes.ContentLength ;
			int AcceptLength = 0 ;
			if( AcceptProgress != null)
				AcceptProgress(0 , ContentLength );
			while(true)
			{
				int iLen = myStream.Read(bytBuf,0,1024);
				if(iLen ==0)
					break;
				myBuf.Write(bytBuf,0,iLen);
				AcceptLength += iLen ;
				if( AcceptLength > ContentLength )
					ContentLength = AcceptLength ;
				if( AcceptProgress != null)
					AcceptProgress( AcceptLength , ContentLength );
			}//while
			if( AcceptProgress != null)
				AcceptProgress( AcceptLength , ContentLength );
			myStream.Close();
			myRes.Close();
			myReq.Abort();
			byte[] bytReturn = myBuf.ToArray();
			myBuf.Close();
			return bytReturn ;
		}// public static byte[] HttpPostData()
	 
		/// <summary>
		/// 设置标志位
		/// </summary>
		/// <param name="intAttributes">原始的标志数据</param>
		/// <param name="intValue">要设置的标志位的数据</param>
		/// <param name="bolSet">是否设置或者清除</param>
		/// <returns>修改后的标志数据</returns>
		public static int SetIntAttribute(int intAttributes , int intValue , bool bolSet)
		{
			return bolSet ? intAttributes | intValue : intAttributes & ~ intValue ;
		}

		/// <summary>
		/// 判断是否设置的标志位
		/// </summary>
		/// <param name="intAttributes">原始的的标志数据</param>
		/// <param name="intValue">需要判断的标志位的数据</param>
		/// <returns>是否进行了设置</returns>
		public static bool GetIntAttribute( int intAttributes , int intValue)
		{
			return ( intAttributes & intValue ) == intValue;
		}

		/// <summary>
		/// 将一个整数转换为一个颜色值
		/// </summary>
		/// <param name="intColor">整数</param>
		/// <returns>颜色值</returns>
		public static System.Drawing.Color ConvertToColor( int intColor)
		{
			return  System.Drawing.Color.FromArgb( (intColor & 0xff0000) >> 16  , ( intColor & 0xff00)>> 8 , ( intColor & 0xff));
		}

	}
}
