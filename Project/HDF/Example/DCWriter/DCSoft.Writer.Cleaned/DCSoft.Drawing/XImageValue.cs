using DCSoft.Common;
using DCSoft.Drawing.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       设计文档图片数据对象
	///       </summary>
	/// <remarks>
	///       设计文档图片数据对象。它是System.Drawing.Image的一个封装，这个对象保存图片对象，还保存构造图片对象的原始二进制数据。
	///       <br />在设计器的属性列表中，需要从一个文件中加载图片数据，为了保持原始数据的完整性，在保存设计文档时是保存加载图片
	///       的二进制数据的，加载设计文档时，会从这个原始的二进制数据来加载图片，这样保证的设计的完整性。本对象就是图片和二进制
	///       数据的混合封装。方便程序加载和保存图片数据。
	///       <br />本对象内部使用了 System.Drawing.Image 对象,可能使用了非托管资源,因此实现了IDisposable 接口,可以用来显式的释放
	///       非托管资源.
	///       </remarks>
	[Serializable]
	[Editor(typeof(SimpleImageValueEditor), typeof(UITypeEditor))]
	[TypeConverter(typeof(XImageValueTypeConverter))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXImageValue))]
	[Guid("00012345-6789-ABCD-EF01-23456789008C")]
	[ToolboxItem(false)]
	[DCPublishAPI]
	[DocumentComment]
	[DefaultProperty("ImageData")]
	public class XImageValue : ICloneable, IComponent, IXImageValue
	{
		private class Class25
		{
			private class Class26
			{
				public byte[] byte_0 = null;

				public Image image_0 = null;

				public Image method_0()
				{
					if (image_0 == null || smethod_1(image_0))
					{
						MemoryStream stream = new MemoryStream(byte_0);
						image_0 = Image.FromStream(stream);
					}
					return image_0;
				}
			}

			private List<Class26> list_0 = new List<Class26>();

			public void method_0()
			{
				foreach (Class26 item in list_0)
				{
					item.byte_0 = null;
					if (item.image_0 != null)
					{
						item.image_0.Dispose();
						item.image_0 = null;
					}
				}
				list_0.Clear();
			}

			public byte[] method_1(byte[] byte_0)
			{
				int num = method_2(byte_0);
				if (num >= 0)
				{
					return list_0[num].byte_0;
				}
				return null;
			}

			public int method_2(byte[] byte_0)
			{
				if (byte_0 == null || byte_0.Length == 0)
				{
					return -1;
				}
				int num = 0;
				while (true)
				{
					if (num < list_0.Count)
					{
						Class26 @class = list_0[num];
						if (BinaryHelper.Equals(@class.byte_0, byte_0))
						{
							break;
						}
						num++;
						continue;
					}
					Class26 class2 = new Class26();
					class2.byte_0 = byte_0;
					list_0.Insert(0, class2);
					return 0;
				}
				return num;
			}

			public Image method_3(byte[] byte_0)
			{
				int num = method_2(byte_0);
				if (num >= 0)
				{
					return list_0[num].method_0();
				}
				return null;
			}

			public Image method_4(int int_0)
			{
				if (int_0 >= 0 && int_0 < list_0.Count)
				{
					return list_0[int_0].method_0();
				}
				return null;
			}

			public bool method_5(Image image_0)
			{
				foreach (Class26 item in list_0)
				{
					if (item.image_0 != null && item.image_0 == image_0)
					{
						return true;
					}
				}
				return false;
			}
		}

		[DCInternal]
		public static string string_0 = "Image";

		private static int int_0 = 0;

		private int int_1;

		private float float_0;

		private float float_1;

		private int int_2;

		[NonSerialized]
		private Image image_0;

		private byte[] byte_0;

		private static object object_0 = null;

		private static Class25 class25_0 = new Class25();

		private bool bool_0;

		private bool bool_1;

		private EventHandler eventHandler_0;

		[NonSerialized]
		private ISite isite_0;

		[XmlIgnore]
		[DCInternal]
		public int InstanceIndex => int_1;

		/// <summary>
		///       获取图片的水平分辨率（以“像素/英寸”为单位）。 
		///       </summary>
		[DefaultValue(0f)]
		public float HorizontalResolution
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		/// <summary>
		///       获取图片的垂直分辨率（以“像素/英寸”为单位）。 
		///       </summary>
		[DefaultValue(0f)]
		public float VerticalResolution
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		/// <summary>
		///       内容版本号,对象数据发生任何改变都会修改此版本号
		///       </summary>
		[Browsable(false)]
		public int ContentVersion => int_2;

		/// <summary>
		///       对象是否包含数据
		///       </summary>
		[Browsable(false)]
		public bool HasContent
		{
			get
			{
				if (image_0 != null)
				{
					return true;
				}
				if (byte_0 != null && byte_0.Length > 0)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       显示的图片对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual Image Value
		{
			get
			{
				if (image_0 == null)
				{
					method_1();
				}
				return image_0;
			}
			set
			{
				image_0 = value;
				byte_0 = null;
				int_2++;
				if (image_0 != null)
				{
					float_0 = image_0.HorizontalResolution;
					float_1 = image_0.VerticalResolution;
				}
				else
				{
					float_0 = 0f;
					float_1 = 0f;
				}
			}
		}

		/// <summary>
		///       保存图形数据的二进制数据
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public byte[] ImageData
		{
			get
			{
				if (byte_0 == null && image_0 != null)
				{
					bool flag = false;
					try
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							image_0.Save(memoryStream, ImageFormat.Png);
							byte_0 = memoryStream.ToArray();
						}
						flag = true;
					}
					catch (Exception)
					{
					}
					if (!flag)
					{
						try
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								image_0.Save(memoryStream, ImageFormat.Jpeg);
								byte_0 = memoryStream.ToArray();
							}
							flag = true;
						}
						catch (Exception)
						{
						}
					}
					if (!flag)
					{
						try
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								using (Image image = (Image)image_0.Clone())
								{
									image.Save(memoryStream, ImageFormat.Jpeg);
									byte_0 = memoryStream.ToArray();
									flag = true;
								}
							}
						}
						catch (Exception)
						{
						}
					}
				}
				return byte_0;
			}
			set
			{
				if (image_0 != null)
				{
					image_0.Dispose();
					float_1 = 0f;
					float_0 = 0f;
				}
				byte_0 = smethod_2(value);
				image_0 = null;
				int_2++;
			}
		}

		/// <summary>
		///       安全模式
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public bool SafeLoadMode
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       是否格式化输出Base64字符串
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public bool FormatBase64String
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       包含图片数据的Base64字符串
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(false)]
		public string ImageDataBase64String
		{
			get
			{
				byte[] imageData = ImageData;
				if (imageData != null && imageData.Length > 0)
				{
					string text = Convert.ToBase64String(imageData);
					if (FormatBase64String)
					{
						text = StringFormatHelper.GroupFormatString(text, 8, 16);
					}
					return text;
				}
				return null;
			}
			set
			{
				int num = 11;
				if (value != null && value.Length > 0)
				{
					try
					{
						ImageData = Convert.FromBase64String(value);
					}
					catch (FormatException)
					{
						StringBuilder stringBuilder = new StringBuilder();
						foreach (char value2 in value)
						{
							if ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".IndexOf(value2) >= 0)
							{
								stringBuilder.Append(value2);
							}
						}
						switch (stringBuilder.Length % 3)
						{
						case 1:
							stringBuilder.Append("==");
							break;
						case 2:
							stringBuilder.Append("=");
							break;
						}
						try
						{
							string s = stringBuilder.ToString();
							ImageData = Convert.FromBase64String(s);
						}
						catch
						{
							ImageData = null;
						}
					}
					catch
					{
						ImageData = null;
					}
					int_2++;
				}
			}
		}

		/// <summary>
		///       图片格式
		///       </summary>
		public ImageFormat RawFormat
		{
			get
			{
				if (Value != null)
				{
					return Value.RawFormat;
				}
				return null;
			}
		}

		/// <summary>
		///       图片宽度
		///       </summary>
		public int Width
		{
			get
			{
				if (Value == null)
				{
					return 0;
				}
				return Value.Width;
			}
		}

		/// <summary>
		///       图片高度
		///       </summary>
		public int Height
		{
			get
			{
				if (Value == null)
				{
					return 0;
				}
				return Value.Height;
			}
		}

		/// <summary>
		///       图片大小
		///       </summary>
		[Browsable(false)]
		public Size Size
		{
			get
			{
				if (Value == null)
				{
					return Size.Empty;
				}
				return Value.Size;
			}
		}

		/// <summary>
		///       对象站点
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		public ISite Site
		{
			get
			{
				return isite_0;
			}
			set
			{
				isite_0 = value;
			}
		}

		/// <summary>
		///       对象销毁事件
		///       </summary>
		[DCInternal]
		public event EventHandler Disposed
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XImageValue()
		{
			int_1 = int_0++;
			float_0 = 0f;
			float_1 = 0f;
			int_2 = 0;
			image_0 = null;
			byte_0 = null;
			bool_0 = true;
			bool_1 = true;
			eventHandler_0 = null;
			isite_0 = null;
			
			int_2 = GetHashCode();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="img">图片数据</param>
		public XImageValue(Image image_1)
		{
			int_1 = int_0++;
			float_0 = 0f;
			float_1 = 0f;
			int_2 = 0;
			image_0 = null;
			byte_0 = null;
			bool_0 = true;
			bool_1 = true;
			eventHandler_0 = null;
			isite_0 = null;
			
			Value = image_1;
			int_2 = GetHashCode();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="stream">包含图片数据的流对象</param>
		public XImageValue(Stream stream_0)
		{
			int_1 = int_0++;
			float_0 = 0f;
			float_1 = 0f;
			int_2 = 0;
			image_0 = null;
			byte_0 = null;
			bool_0 = true;
			bool_1 = true;
			eventHandler_0 = null;
			isite_0 = null;
			
			byte[] array = new byte[1024];
			MemoryStream memoryStream = new MemoryStream();
			while (true)
			{
				int num = stream_0.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			ImageData = memoryStream.ToArray();
			int_2 = GetHashCode();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="bs">图片数据</param>
		public XImageValue(byte[] byte_1)
		{
			int_1 = int_0++;
			float_0 = 0f;
			float_1 = 0f;
			int_2 = 0;
			image_0 = null;
			byte_0 = null;
			bool_0 = true;
			bool_1 = true;
			eventHandler_0 = null;
			isite_0 = null;
			
			ImageData = byte_1;
			int_2 = GetHashCode();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="bs">图片数据</param>
		/// <param name="safeLoadMode">是否为安全加载模式</param>
		public XImageValue(byte[] byte_1, bool bool_2)
		{
			int_1 = int_0++;
			float_0 = 0f;
			float_1 = 0f;
			int_2 = 0;
			image_0 = null;
			byte_0 = null;
			bool_0 = true;
			bool_1 = true;
			eventHandler_0 = null;
			isite_0 = null;
			
			SafeLoadMode = bool_2;
			ImageData = byte_1;
			int_2 = GetHashCode();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="url">要加载图片数据的URL</param>
		public XImageValue(string string_1)
		{
			int num = 4;
			int_1 = int_0++;
			float_0 = 0f;
			float_1 = 0f;
			int_2 = 0;
			image_0 = null;
			byte_0 = null;
			bool_0 = true;
			bool_1 = true;
			eventHandler_0 = null;
			isite_0 = null;
			
			if (Load(string_1) <= 0)
			{
				throw new Exception("从" + string_1 + "加载图片数据错误");
			}
			int_2 = GetHashCode();
		}

		[DCInternal]
		public bool method_0(XImageValue ximageValue_0)
		{
			if (ximageValue_0 == null)
			{
				return false;
			}
			if (ximageValue_0 == this)
			{
				return true;
			}
			if (ximageValue_0.Value == Value)
			{
				return true;
			}
			if (ximageValue_0.byte_0 == byte_0)
			{
				return true;
			}
			if (ximageValue_0.byte_0 != null && byte_0 != null && ximageValue_0.byte_0.Length == byte_0.Length)
			{
				int num = byte_0.Length - 1;
				while (true)
				{
					if (num >= 0)
					{
						if (byte_0[num] != ximageValue_0.byte_0[num])
						{
							break;
						}
						num--;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		/// <summary>
		///       修改图片格式
		///       </summary>
		/// <param name="format">新的图片格式</param>
		[DCInternal]
		public void ChangeImageFormat(ImageFormat format)
		{
			int num = 3;
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			Image value = Value;
			if (value != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				value.Save(memoryStream, format);
				image_0.Dispose();
				memoryStream.Close();
				image_0 = null;
				byte_0 = memoryStream.ToArray();
			}
		}

		private void method_1()
		{
			if (byte_0 != null && byte_0.Length > 0 && image_0 == null)
			{
				image_0 = class25_0.method_3(byte_0);
			}
		}

		[DCInternal]
		public static void smethod_0()
		{
			class25_0.method_0();
		}

		public static bool smethod_1(Image image_1)
		{
			int num = 5;
			if (image_1 == null)
			{
				throw new ArgumentNullException("img");
			}
			if (object_0 == null)
			{
				object_0 = typeof(Image).GetField("nativeImage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (object_0 == null)
				{
					object_0 = new object();
				}
			}
			if (object_0 is FieldInfo)
			{
				IntPtr value = (IntPtr)((FieldInfo)object_0).GetValue(image_1);
				if (value == IntPtr.Zero)
				{
					return true;
				}
			}
			return false;
		}

		private static byte[] smethod_2(byte[] byte_1)
		{
			if (byte_1 == null || byte_1.Length == 0)
			{
				return byte_1;
			}
			return class25_0.method_1(byte_1);
		}

		/// <summary>
		///       以指定的单位获取图像的界限。
		///       </summary>
		/// <param name="unit">System.Drawing.GraphicsUnit 值之一，指示边框的测量单位。</param>
		/// <returns>System.Drawing.RectangleF，以指定的单位表示图像的界限。</returns>
		[DCInternal]
		public RectangleF GetBounds(ref GraphicsUnit unit)
		{
			if (Value != null)
			{
				return Value.GetBounds(ref unit);
			}
			return RectangleF.Empty;
		}

		/// <summary>
		///       创建指定大小的缩略图片
		///       </summary>
		/// <param name="thumbWidth">缩略图宽度</param>
		/// <param name="thumbHeight">缩略图高度</param>
		/// <returns>生成的缩略图对象</returns>
		[DCInternal]
		public XImageValue GetThumbnailImage(int thumbWidth, int thumbHeight)
		{
			Image value = Value;
			if (value != null)
			{
				Image thumbnailImage = value.GetThumbnailImage(thumbWidth, thumbHeight, method_2, IntPtr.Zero);
				return new XImageValue(thumbnailImage);
			}
			return null;
		}

		/// <summary>
		///       创建指定大小的缩略图片
		///       </summary>
		/// <param name="thumbWidth">缩略图宽度</param>
		/// <param name="thumbHeight">缩略图高度</param>
		/// <param name="backColor">背景色</param>
		/// <returns>生成的缩略图对象</returns>
		[DCInternal]
		public XImageValue GetThumbnailImage(int thumbWidth, int thumbHeight, Color backColor)
		{
			Image value = Value;
			if (value != null)
			{
				Bitmap bitmap = new Bitmap(thumbWidth, thumbHeight);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.Clear(backColor);
					graphics.DrawImage(value, 0, 0, thumbWidth, thumbHeight);
				}
				return new XImageValue(bitmap);
			}
			return null;
		}

		private bool method_2()
		{
			return false;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制后的对象</returns>
		[DCInternal]
		public XImageValue Clone()
		{
			XImageValue xImageValue = (XImageValue)MemberwiseClone();
			xImageValue.image_0 = null;
			xImageValue.byte_0 = null;
			if (image_0 != null)
			{
				xImageValue.image_0 = (Image)image_0.Clone();
			}
			if (byte_0 != null)
			{
				xImageValue.byte_0 = new byte[byte_0.Length];
				Array.Copy(byte_0, 0, xImageValue.byte_0, 0, byte_0.Length);
			}
			xImageValue.int_2 = int_2;
			return xImageValue;
		}

		/// <summary>
		///       引用模式的复制对象
		///       </summary>
		/// <returns>复制品</returns>
		/// <remarks>
		///       通过这种模式复制出来的对象，其引用的原始图片对象和字节数组是相同的。
		///       而Clone()方法复制出来的对象，其原始图片对象和字节数组也是完全复制的。
		///       </remarks>
		[DCInternal]
		public XImageValue CloneImageDataOnly()
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.image_0 = image_0;
			xImageValue.byte_0 = byte_0;
			xImageValue.int_2 = int_2;
			return xImageValue;
		}

		object ICloneable.Clone()
		{
			XImageValue xImageValue = new XImageValue();
			if (image_0 != null)
			{
				xImageValue.image_0 = (Image)image_0.Clone();
			}
			if (byte_0 != null)
			{
				xImageValue.byte_0 = new byte[byte_0.Length];
				Array.Copy(byte_0, 0, xImageValue.byte_0, 0, byte_0.Length);
			}
			xImageValue.int_2 = int_2;
			return xImageValue;
		}

		/// <summary>
		///       从Base64字符串加载图片数据
		///       </summary>
		/// <param name="base64">BASE64字符串</param>
		/// <returns>加载的字节数</returns>
		public int LoadBase64String(string base64)
		{
			if (string.IsNullOrEmpty(base64))
			{
				byte_0 = null;
				image_0 = null;
				return 0;
			}
			byte[] array2 = ImageData = Convert.FromBase64String(base64);
			return array2.Length;
		}

		/// <summary>
		///       从指定URL加载图片数据
		///       </summary>
		/// <param name="strUrl">URL字符串</param>
		/// <returns>加载的字节数</returns>
		public int Load(string strUrl)
		{
			Uri uri = new Uri(strUrl);
			if (uri.Scheme == Uri.UriSchemeFile)
			{
				if (!File.Exists(strUrl))
				{
					return -1;
				}
				byte[] array = null;
				using (FileStream fileStream = new FileStream(strUrl, FileMode.Open, FileAccess.Read))
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					fileStream.Close();
				}
				ImageData = array;
				if (array == null)
				{
					return -1;
				}
				return array.Length;
			}
			if (uri.Scheme == Uri.UriSchemeHttp)
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] array = ImageData = webClient.DownloadData(strUrl);
					if (array != null)
					{
						return array.Length;
					}
				}
			}
			return 0;
		}

		/// <summary>
		///       保存图片数据到指定文件中
		///       </summary>
		/// <param name="FileName">文件名</param>
		/// <returns>操作是否成功</returns>
		public bool Save(string FileName)
		{
			if (image_0 != null || byte_0 != null)
			{
				using (FileStream fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write))
				{
					if (byte_0 != null)
					{
						fileStream.Write(byte_0, 0, byte_0.Length);
					}
					else
					{
						image_0.Save(fileStream, GetFormat(FileName));
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得图片格式
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>图片格式</returns>
		[DCInternal]
		public static ImageFormat GetFormat(string fileName)
		{
			int num = 12;
			if (fileName != null)
			{
				fileName = fileName.Trim().ToLower();
				if (fileName.EndsWith(".bmp"))
				{
					return ImageFormat.Bmp;
				}
				if (fileName.EndsWith(".jpg") || fileName.EndsWith(".jpeg"))
				{
					return ImageFormat.Jpeg;
				}
				if (fileName.EndsWith(".png"))
				{
					return ImageFormat.Png;
				}
				if (fileName.EndsWith(".gif"))
				{
					return ImageFormat.Gif;
				}
				if (fileName.EndsWith(".wmf"))
				{
					return ImageFormat.Wmf;
				}
			}
			return ImageFormat.Png;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			if (image_0 != null)
			{
				if (!class25_0.method_5(image_0))
				{
					image_0.Dispose();
				}
				image_0 = null;
			}
			isite_0 = null;
			if (byte_0 != null)
			{
				byte_0 = null;
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		[DCInternal]
		public override string ToString()
		{
			int num = 18;
			Image value = Value;
			_ = ImageData;
			if (byte_0 == null || image_0 == null)
			{
				return "None";
			}
			if (byte_0.Length < 1024)
			{
				return byte_0.Length + "B " + value.Width + "*" + value.Height;
			}
			return Convert.ToInt32(byte_0.Length / 1024) + "KB " + value.Width + "*" + value.Height;
		}

		[DCInternal]
		public void method_3(XImageValue ximageValue_0)
		{
			if (ximageValue_0 != null && ximageValue_0 != this)
			{
				ximageValue_0.int_2 = int_2;
				ximageValue_0.bool_1 = bool_1;
				ximageValue_0.float_0 = float_0;
				ximageValue_0.float_1 = float_1;
				ximageValue_0.byte_0 = byte_0;
				ximageValue_0.image_0 = image_0;
				ximageValue_0.isite_0 = isite_0;
			}
		}
	}
}
