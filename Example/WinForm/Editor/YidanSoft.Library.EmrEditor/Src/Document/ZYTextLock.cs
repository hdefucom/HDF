using System;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// ZYTextLock 表示签名对象,在xml中表述为lock元素.
    /// <example>例如:<lock user="zhuren" time="2009-05-13 14:59:44" level="2" /></example>
    /// 主要内容有锁定人(签名人),锁定时间(签名时间),锁定等级(签名等级)
    /// 签名人可以接受前台的输入,签名时间为当前签名的时间,等级可以表述为三级检诊中的三个等级 mfb
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
		/// 初始化对象
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
		/// 锁定人
		/// </summary>
		public string UserName
		{
			get{ return strUserName ;}
			set{ strUserName = value;}
		}
		protected DateTime dtmDateTime = ZYTime.GetServerTime();//System.DateTime.Now ;
		/// <summary>
		/// 锁定时间
		/// </summary>
		public DateTime DateTime
		{
			get{ return dtmDateTime ;}
			set{ dtmDateTime = value;}
		}
		private int intLevel = 0 ;
		/// <summary>
		/// 等级
		/// </summary>
		public int Level
		{
			get{ return intLevel ;}
			set{ intLevel = value;}
		}
		/// <summary>
		/// 文字信息
		/// </summary>
		public string LockInfo
		{
			get
			{
				return  "医生:" + strUserName +" "+ dtmDateTime.ToString("yyyy-MM-dd HH:mm") +" "+"手签";
			}
		}
		//计算该元素大小 2007-9-16 耿国栋
		public override bool RefreshSize()
		{
			//计算图片大小
			int w = myOwnerDocument.PixelToDocumentUnit( Icon.Width );
			int h = myOwnerDocument.PixelToDocumentUnit( Icon.Height );
			this.intWidth = w ;
			this.intHeight = h ;
			//加入文字信息大小
			System.Drawing.SizeF size = myOwnerDocument.View.MeasureString( this.LockInfo , null );
			this.intWidth =  ( int ) ( w + size.Width + 20 );
			this.intHeight = ( int ) (  Math.Max( h , size.Height ) );
			return true;
		}
		//刷新显示 2007-9-16 耿国栋
		public override bool RefreshView()
		{
			System.Drawing.Rectangle bounds = new System.Drawing.Rectangle( this.RealLeft , this.RealTop , this.Width , this.Height );
			//若是打印状态 则只绘制文字信息
			if( this.myOwnerDocument.Info.Printing )
			{			
				myOwnerDocument.View.DrawString( this.LockInfo , null , System.Drawing.Color.Black , bounds.Left , bounds.Top );
			}
			//非打印状态 绘制文字信息和图片
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