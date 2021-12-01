using System;

namespace ZYCommon
{
	
	/// <summary>
	/// �������ݵĽ�����Ϣ����ί��
	/// </summary>
	/// <param name="objData" type="object">��������</param>
	/// <param name="CompletedStep" type="int">�Ѿ���ɵĲ�����</param>
	/// <param name="TotalStep" type="int">�ܵĲ�����</param>
	public delegate void ObjectProgressHandler( object objData , int CompletedStep , int TotalStep );
 
	/// <summary>
	/// ������Ϣ����ί��
	/// </summary>
	/// <param name="CompletedStep" type="int">�Ѿ���ɵĲ�����</param>
	/// <param name="TotalStep" type="int">�ܵĲ�����</param>
	public delegate void ProgressHandler( int CompletedStep , int TotalStep );
	
	/// <summary>
	/// ͨ�ú������� 
	/// </summary>
	public class CommonFunction
	{
		/// <summary>
		/// ��ָ��URLʹ��POST�����������ݵ�����,�����������д�����
		/// </summary>
		/// <param name="strURL">URL�ַ���</param>
		/// <param name="bytSend">Ҫ���͵Ķ���������</param>
		/// <param name="SendProgress">��������ʱ�Ľ��ȴ���</param>
		/// <param name="AcceptProgress">��������ʱ�Ľ��ȴ���</param>
		/// <returns>���ܵ��Ķ���������</returns>
		public static byte[] HttpPostData(
			string strURL ,
			byte[] bytSend , 
			ProgressHandler SendProgress ,
			ProgressHandler AcceptProgress )
		{
			// ��������
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
			
			// ��������
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
		/// ���ñ�־λ
		/// </summary>
		/// <param name="intAttributes">ԭʼ�ı�־����</param>
		/// <param name="intValue">Ҫ���õı�־λ������</param>
		/// <param name="bolSet">�Ƿ����û������</param>
		/// <returns>�޸ĺ�ı�־����</returns>
		public static int SetIntAttribute(int intAttributes , int intValue , bool bolSet)
		{
			return bolSet ? intAttributes | intValue : intAttributes & ~ intValue ;
		}

		/// <summary>
		/// �ж��Ƿ����õı�־λ
		/// </summary>
		/// <param name="intAttributes">ԭʼ�ĵı�־����</param>
		/// <param name="intValue">��Ҫ�жϵı�־λ������</param>
		/// <returns>�Ƿ����������</returns>
		public static bool GetIntAttribute( int intAttributes , int intValue)
		{
			return ( intAttributes & intValue ) == intValue;
		}

		/// <summary>
		/// ��һ������ת��Ϊһ����ɫֵ
		/// </summary>
		/// <param name="intColor">����</param>
		/// <returns>��ɫֵ</returns>
		public static System.Drawing.Color ConvertToColor( int intColor)
		{
			return  System.Drawing.Color.FromArgb( (intColor & 0xff0000) >> 16  , ( intColor & 0xff00)>> 8 , ( intColor & 0xff));
		}

	}
}
