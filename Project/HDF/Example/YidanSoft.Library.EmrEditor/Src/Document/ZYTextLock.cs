using System;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// ZYTextLock ��ʾǩ������,��xml�б���ΪlockԪ��.
    /// <example>����:<lock user="zhuren" time="2009-05-13 14:59:44" level="2" /></example>
    /// ��Ҫ������������(ǩ����),����ʱ��(ǩ��ʱ��),�����ȼ�(ǩ���ȼ�)
    /// ǩ���˿��Խ���ǰ̨������,ǩ��ʱ��Ϊ��ǰǩ����ʱ��,�ȼ����Ա���Ϊ���������е������ȼ� mfb
	/// </summary>
	public class ZYTextLock : ZYTextElement
	{
		private static System.Drawing.Bitmap Icon = null;
		static ZYTextLock()
		{
			System.IO.Stream stream = typeof( ZYTextLock ).Assembly.GetManifestResourceStream("ZYTextDocumentLib.icon.lock.bmp");
			if( stream != null )
			{
				Icon = ( System.Drawing.Bitmap ) System.Drawing.Image.FromStream( stream );
				Icon.MakeTransparent( System.Drawing.Color.White );
				stream.Close();
			}
		}
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public ZYTextLock()
		{
		}
//		public override int Width
//		{
//			get
//			{
//				return myOwnerDocument.PixelToDocumentUnit( Icon.Width );
//			}
//			set
//			{
//			}
//		}
//		public override int Height
//		{
//			get
//			{
//				return myOwnerDocument.PixelToDocumentUnit( Icon.Height );
//			}
//			set
//			{
//			}
//		}
		protected string strUserName = "";
		/// <summary>
		/// ������
		/// </summary>
		public string UserName
		{
			get{ return strUserName ;}
			set{ strUserName = value;}
		}
		protected DateTime dtmDateTime = ZYTime.GetServerTime();//System.DateTime.Now ;
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime DateTime
		{
			get{ return dtmDateTime ;}
			set{ dtmDateTime = value;}
		}
		private int intLevel = 0 ;
		/// <summary>
		/// �ȼ�
		/// </summary>
		public int Level
		{
			get{ return intLevel ;}
			set{ intLevel = value;}
		}
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public string LockInfo
		{
			get
			{
				return  "ҽ��:" + strUserName +" "+ dtmDateTime.ToString("yyyy-MM-dd HH:mm") +" "+"��ǩ";
			}
		}
		//�����Ԫ�ش�С 2007-9-16 ������
		public override bool RefreshSize()
		{
			//����ͼƬ��С
			int w = myOwnerDocument.PixelToDocumentUnit( Icon.Width );
			int h = myOwnerDocument.PixelToDocumentUnit( Icon.Height );
			this.intWidth = w ;
			this.intHeight = h ;
			//����������Ϣ��С
			System.Drawing.SizeF size = myOwnerDocument.View.MeasureString( this.LockInfo , null );
			this.intWidth =  ( int ) ( w + size.Width + 20 );
			this.intHeight = ( int ) (  Math.Max( h , size.Height ) );
			return true;
		}
		//ˢ����ʾ 2007-9-16 ������
		public override bool RefreshView()
		{
			System.Drawing.Rectangle bounds = new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width , this.Height );
			//���Ǵ�ӡ״̬ ��ֻ����������Ϣ
			if( this.myOwnerDocument.Info.Printing )
			{			
				myOwnerDocument.View.DrawString( this.LockInfo , null , System.Drawing.Color.Black , bounds.Left , bounds.Top );
			}
			//�Ǵ�ӡ״̬ ����������Ϣ��ͼƬ
			else
			{
				int w = myOwnerDocument.PixelToDocumentUnit( Icon.Width );
				int h = myOwnerDocument.PixelToDocumentUnit( Icon.Height );
				myOwnerDocument.View.DrawString( this.LockInfo , null , System.Drawing.Color.Black , bounds.Left , bounds.Top );
				myOwnerDocument.View.DrawImage( Icon , bounds.Left+(int)myOwnerDocument.View.MeasureString( this.LockInfo , null ).Width+30 , bounds.Top-5  , w, h );
			}
			return true;
		}
		public override bool FromXML(System.Xml.XmlElement myElement)
		{
			base.FromXML (myElement);
			strUserName = myElement.GetAttribute("user");
			//dtmDateTime = ZYCommon.StringCommon.ConvertToDateTime( myElement.GetAttribute("time"),null,System.DateTime.Now);
			dtmDateTime = StringCommon.ConvertToDateTime( myElement.GetAttribute("time"),null,ZYTime.GetServerTime());
			intLevel = StringCommon.ToInt32Value( myElement.GetAttribute("level" ) , intLevel );
			return true;
		}
		public override bool ToXML(System.Xml.XmlElement myElement)
		{
			base.ToXML (myElement);
			myElement.SetAttribute("user" , strUserName );
			myElement.SetAttribute("time" , dtmDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
			myElement.SetAttribute("level" , intLevel.ToString());
			return true;
		}


		public override string GetXMLName()
		{
			return ZYTextConst.c_Lock ;
		}
	}
}