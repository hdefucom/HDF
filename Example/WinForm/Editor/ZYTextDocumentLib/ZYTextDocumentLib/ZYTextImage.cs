using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextImage : ZYTextObject, IDisposable
	{
		private Image myImage = null;

		private static PixelFormat[] indexedPixelFormats = new PixelFormat[6]
		{
			PixelFormat.Undefined,
			PixelFormat.Undefined,
			PixelFormat.Format16bppArgb1555,
			PixelFormat.Format1bppIndexed,
			PixelFormat.Format4bppIndexed,
			PixelFormat.Format8bppIndexed
		};

		public bool ImageSizeRectLock
		{
			get
			{
				if (Math.Abs(dblWidthHeightRate - (double)myImage.Width / (double)myImage.Height) < 0.04)
				{
					return true;
				}
				return false;
			}
			set
			{
				if (value && myImage != null)
				{
					dblWidthHeightRate = (double)myImage.Width / (double)myImage.Height;
				}
				else
				{
					dblWidthHeightRate = 0.0;
				}
			}
		}

		public Image Image
		{
			get
			{
				return myImage;
			}
			set
			{
				myImage = value;
				if (myImage != null)
				{
					Width = myImage.Size.Width;
					Height = myImage.Size.Height;
				}
			}
		}

		public string Src
		{
			get
			{
				return myAttributes.GetString("src");
			}
			set
			{
				myAttributes.SetValue("src", value);
			}
		}

		public bool SaveInFile
		{
			get
			{
				return myAttributes.GetBool("saveinfile");
			}
			set
			{
				myAttributes.SetValue("saveinfile", value);
			}
		}

		public string ImageType
		{
			get
			{
				return myAttributes.GetString("type");
			}
			set
			{
				myAttributes.SetValue("type", value);
			}
		}

		public string ImageIndex
		{
			get
			{
				return myAttributes.GetString("imgindex");
			}
			set
			{
				myAttributes.SetValue("imgindex", value);
			}
		}

		public string ImgFile
		{
			get;
			set;
		}

		public string ImgName
		{
			get;
			set;
		}

		public string ImgSourceSrc
		{
			get
			{
				return myAttributes.GetString("ImgSourceSrc");
			}
			set
			{
				myAttributes.SetValue("ImgSourceSrc", value);
			}
		}

		public override string GetXMLName()
		{
			return "img";
		}

		public override bool FromXML(XmlElement myElement)
		{
			if (base.FromXML(myElement))
			{
				Width = 30;
				Height = 30;
				if (myImage != null)
				{
					myImage.Dispose();
					myImage = null;
				}
				if (SaveInFile)
				{
					myImage = StringCommon.ImageFromBase64String(myElement.InnerText);
				}
				else
				{
					myImage = ZYTextConst.ImageFromURL(Src);
				}
				if (myImage != null)
				{
					Width = myImage.Size.Width;
					Height = myImage.Size.Height;
				}
				if (myElement.HasAttribute("width"))
				{
					Width = StringCommon.ToInt32Value(myElement.GetAttribute("width"), intWidth);
				}
				if (myElement.HasAttribute("height"))
				{
					Height = StringCommon.ToInt32Value(myElement.GetAttribute("height"), intHeight);
				}
				if (myElement.HasAttribute("imgindex"))
				{
					ImageIndex = myElement.GetAttribute("imgindex");
				}
				if (myElement.HasAttribute("ImgFile"))
				{
					ImgFile = myElement.GetAttribute("ImgFile");
				}
				if (myElement.HasAttribute("ImgName"))
				{
					ImgName = myElement.GetAttribute("ImgName");
				}
				if (myElement.HasAttribute("ImgSourceSrc"))
				{
					ImgSourceSrc = myElement.GetAttribute("ImgSourceSrc");
				}
				myAttributes.SetValue("width", intWidth.ToString());
				myAttributes.SetValue("height", intHeight.ToString());
				return true;
			}
			return false;
		}

		public override bool ToXML(XmlElement myElement)
		{
			switch (myOwnerDocument.Info.SaveMode)
			{
			case 0:
				if (myImage != null)
				{
					if (myImage.Size.Width != intWidth)
					{
						myAttributes.SetValue("width", intWidth.ToString());
					}
					else
					{
						myAttributes.RemoveAttribute("width");
					}
					if (myImage.Size.Height != intHeight)
					{
						myAttributes.SetValue("height", intHeight.ToString());
					}
					else
					{
						myAttributes.RemoveAttribute("height");
					}
				}
				myAttributes.ToXML(myElement);
				if (SaveInFile && myImage != null)
				{
					Bitmap bitmap = new Bitmap(myImage);
					myElement.InnerText = StringCommon.ImageToBase64String(bitmap, ImageTypeCheck.CheckImageType(myImage));
					bitmap.Dispose();
				}
				return true;
			default:
				return false;
			}
		}

		public override bool isTextElement()
		{
			return false;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			if (base.HandleMouseMove(x, y, Button))
			{
				return true;
			}
			if (myImage != null && Bounds.Contains(x, y))
			{
				myOwnerDocument.SetToolTip("图片宽度:" + myImage.Size.Width + " 高度:" + myImage.Size.Height + "\r\n格式:" + myImage.PixelFormat.ToString(), -1, new Rectangle(x, y, 5, 5));
				return true;
			}
			return false;
		}

		public override bool RefreshView()
		{
			int realLeft = RealLeft;
			int realTop = RealTop;
			if (myImage != null)
			{
				myOwnerDocument.View.DrawImage(myImage, realLeft, realTop, intWidth, intHeight);
			}
			else
			{
				myOwnerDocument.View.DrawString("未找到图片文件", realLeft, realTop, intWidth, intHeight);
			}
			return base.RefreshView();
		}

		public bool LoadImage()
		{
			string imageType = ImageType;
			if (imageType != null && imageType == "emrtextdoc")
			{
				using (ZYTextDocument zYTextDocument = new ZYTextDocument())
				{
					zYTextDocument.View = new DocumentView();
					zYTextDocument.FromXMLFile(Src);
					myImage = zYTextDocument.GetPreViewImage();
				}
			}
			else
			{
				myImage = ZYTextConst.ImageFromURL(Src);
			}
			if (myImage != null)
			{
				intWidth = myOwnerDocument.PixelToDocumentUnit(myImage.Size.Width);
				intHeight = myOwnerDocument.PixelToDocumentUnit(myImage.Size.Height);
			}
			return true;
		}

		public ZYTextImage()
		{
			myBorder = new ZYTextBorder();
			intWidth = 90;
			intHeight = 90;
		}

		public bool EditImage()
		{
			using (Bitmap contentBMP = new Bitmap(myImage))
			{
				using (frmEditImage frmEditImage = new frmEditImage())
				{
					frmEditImage.ShowInTaskbar = false;
					frmEditImage.ContentBMP = contentBMP;
					frmEditImage.MinimizeBox = false;
					frmEditImage.ShowDialog();
					if (frmEditImage.BMPChanged)
					{
						myImage.Dispose();
						myImage = frmEditImage.EditedBMP;
						myOwnerDocument.Modified = true;
						return true;
					}
				}
			}
			return false;
		}

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			switch (Button)
			{
			case MouseButtons.Left:
				if (ImageIndex != "-1")
				{
					ZYPublic.ImageIndex = ImageIndex;
					ZYPublic.TempZYTextImage = this;
				}
				break;
			}
			return base.HandleMouseDown(x, y, Button);
		}

		private bool IsPointInThisImage(int x, int y)
		{
			if (x > Bounds.Left + Bounds.Width || x < Bounds.Left)
			{
				return false;
			}
			if (y > Bounds.Top + Bounds.Height || y < Top)
			{
				return false;
			}
			return true;
		}

		public override bool HandleDblClick(int x, int y, MouseButtons Button)
		{
			int num = y - Bounds.Top;
			int num2 = x - Bounds.Left;
			if (ZYPublic.TempZYTextImage != null && IsPointInThisImage(x, y) && !string.IsNullOrEmpty(ZYPublic.TempZYTextImage.ImageIndex) && ImageIndex == "-1")
			{
				if (IsPixelFormatIndexed(Image.PixelFormat))
				{
					Bitmap image = new Bitmap(Image, Width, Height);
					Graphics graphics = Graphics.FromImage(image);
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.DrawImage(Image, 0, 0, Width, Height);
					graphics.Save();
					graphics.Dispose();
					Image = image;
				}
				Image image2 = Image;
				Graphics graphics2 = Graphics.FromImage(image2);
				int num3 = (int)((float)num2 * ((float)image2.Width / (float)Bounds.Width));
				int num4 = (int)((float)num * ((float)image2.Height / (float)Bounds.Height));
				float num5 = 30f;
				graphics2.FillEllipse(new SolidBrush(Color.White), num3, num4, num5 * 1.3f, num5 * 1.3f);
				graphics2.DrawString(ZYPublic.TempZYTextImage.ImageIndex.ToString(), new Font("宋体", num5, FontStyle.Bold), new SolidBrush(Color.Blue), new Point(num3, num4));
				graphics2.Save();
				graphics2.Dispose();
				OwnerDocument.RefreshElement(this);
			}
			return base.HandleDblClick(x, y, Button);
		}

		public bool ClearImgMark()
		{
			bool result = true;
			if (ImageIndex != "-1")
			{
				return false;
			}
			byte[] imgByImgSource = GetImgByImgSource(ImgSourceSrc);
			if (imgByImgSource == null)
			{
				result = false;
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream(imgByImgSource);
				Bitmap original = new Bitmap(memoryStream);
				original = (Bitmap)(Image = new Bitmap(original, Width, Height));
				OwnerDocument.RefreshElement(this);
				memoryStream.Close();
				memoryStream.Dispose();
			}
			return result;
		}

		public byte[] GetImgByImgSource(string ImgId)
		{
			IDbConnection connection = myOwnerDocument.DataSource.DBConn.Connection;
			IDbCommand dbCommand = connection.CreateCommand();
			dbCommand.CommandText = "SELECT TOP 1 IMG_DATA FROM ZYRISDB.dbo.DIC_REPORT_DIAGRAM WHERE IMG_ID= " + ImgId;
			bool flag = true;
			byte[] result = null;
			if (connection.State == ConnectionState.Open)
			{
				flag = false;
			}
			try
			{
				if (flag)
				{
					connection.Open();
				}
				IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
				if (dataReader.Read())
				{
					result = (byte[])dataReader[0];
				}
				dataReader.Close();
			}
			catch
			{
				try
				{
					if (flag)
					{
						connection.Close();
					}
				}
				catch
				{
				}
			}
			return result;
		}

		public byte[] GetImgByImgSource()
		{
			return GetImgByImgSource(ImgSourceSrc);
		}

		private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
		{
			PixelFormat[] array = indexedPixelFormats;
			foreach (PixelFormat pixelFormat in array)
			{
				if (pixelFormat.Equals(imgPixelFormat))
				{
					return true;
				}
			}
			return false;
		}

		public void Dispose()
		{
			if (myImage != null)
			{
				myImage.Dispose();
				myImage = null;
			}
		}
	}
}
