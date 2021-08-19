using System;
using System.Drawing;
using System.IO;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextLock : ZYTextElement
	{
		private static Bitmap Icon;

		protected string strUserName = "";

		protected Image userImage = null;

		protected DateTime dtmDateTime = ZYTime.GetServerTime();

		private int intLevel = 0;

		public string UserName
		{
			get
			{
				return strUserName;
			}
			set
			{
				strUserName = value;
			}
		}

		public Image UserImage
		{
			get
			{
				return userImage;
			}
			set
			{
				userImage = value;
			}
		}

		public DateTime DateTime
		{
			get
			{
				return dtmDateTime;
			}
			set
			{
				dtmDateTime = value;
			}
		}

		public int Level
		{
			get
			{
				return intLevel;
			}
			set
			{
				intLevel = value;
			}
		}

		public string LockInfo => strUserName;

		static ZYTextLock()
		{
			Icon = null;
			Stream manifestResourceStream = typeof(ZYTextLock).Assembly.GetManifestResourceStream("ZYTextDocumentLib.icon.lock.bmp");
			if (manifestResourceStream != null)
			{
				Icon = (Bitmap)Image.FromStream(manifestResourceStream);
				Icon.MakeTransparent(Color.White);
				manifestResourceStream.Close();
			}
		}

		public override bool RefreshSize()
		{
			int num = myOwnerDocument.PixelToDocumentUnit(Icon.Width);
			int num2 = myOwnerDocument.PixelToDocumentUnit(Icon.Height);
			intWidth = num;
			intHeight = num2;
			SizeF sizeF = myOwnerDocument.View.MeasureString(LockInfo, null);
			intWidth = (int)((float)num + sizeF.Width + 20f);
			intHeight = (int)Math.Max(num2, sizeF.Height);
			return true;
		}

		public override bool RefreshView()
		{
			Rectangle rectangle = new Rectangle(RealLeft, RealTop, Width, Height);
			if (myOwnerDocument.Info.Printing)
			{
				if (OwnerDocument.ZYMarkImage != null && OwnerDocument.ZYMarkImage.ContainsKey(UserName))
				{
					myOwnerDocument.View.DrawImage((Image)OwnerDocument.ZYMarkImage[UserName], rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				}
			}
			else
			{
				int width = myOwnerDocument.PixelToDocumentUnit(Icon.Width);
				int height = myOwnerDocument.PixelToDocumentUnit(Icon.Height);
				myOwnerDocument.View.DrawString(LockInfo, null, Color.Black, rectangle.Left, rectangle.Top);
				myOwnerDocument.View.DrawImage(Icon, rectangle.Left + (int)myOwnerDocument.View.MeasureString(LockInfo, null).Width + 30, rectangle.Top - 5, width, height);
			}
			return true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			base.FromXML(myElement);
			strUserName = myElement.GetAttribute("user");
			dtmDateTime = StringCommon.ConvertToDateTime(myElement.GetAttribute("time"), null, ZYTime.GetServerTime());
			intLevel = StringCommon.ToInt32Value(myElement.GetAttribute("level"), intLevel);
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			base.ToXML(myElement);
			myElement.SetAttribute("user", strUserName);
			myElement.SetAttribute("time", dtmDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
			myElement.SetAttribute("level", intLevel.ToString());
			return true;
		}

		public override string GetXMLName()
		{
			return "lock";
		}
	}
}
