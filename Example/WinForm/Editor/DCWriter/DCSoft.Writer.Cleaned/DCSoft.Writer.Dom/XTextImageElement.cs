#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom.Undo;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       图片对象
	///       </summary>
	/// <remarks>编制袁永福</remarks>
	[Serializable]
	[Guid("00012345-6789-ABCD-EF01-234567890058")]
	[ClassInterface(ClassInterfaceType.None)]
	
	
	[ComDefaultInterface(typeof(IXTextImageElement))]
	[ComClass("00012345-6789-ABCD-EF01-234567890058", "F52F4335-C691-4DCD-BDBD-3D8E6DCC530A")]
	[XmlType("XImage")]
	[ComVisible(true)]
	public sealed class XTextImageElement : XTextObjectElement, IDisposable, IXTextImageElement
	{
		internal const string string_9 = "00012345-6789-ABCD-EF01-234567890058";

		internal const string string_10 = "F52F4335-C691-4DCD-BDBD-3D8E6DCC530A";

		private Color color_0 = Color.Transparent;

		private bool bool_9 = true;

		private bool bool_10 = false;

		private int int_8 = -1;

		private VerticalAlignStyle verticalAlignStyle_0 = VerticalAlignStyle.Bottom;

		private string string_11 = null;

		private string string_12 = null;

		private bool bool_11 = true;

		private string string_13 = null;

		[NonSerialized]
		private XImageValue ximageValue_0 = null;

		private int int_9 = 0;

		private bool bool_12 = true;

		private ShapeDocument shapeDocument_0 = null;

		private bool bool_13 = false;

		private bool bool_14 = true;

		private XImageValue ximageValue_1 = null;

		private XImageValue ximageValue_2 = null;

		[NonSerialized]
		private Image image_0 = null;

		private int int_10 = 0;

		[NonSerialized]
		private string string_14 = null;

		[NonSerialized]
		private bool bool_15 = false;

		private PageImageInfoList pageImageInfoList_0 = null;

		private bool bool_16 = true;

		private string string_15 = null;

		public override string DomDisplayName => "Image:" + base.ID;

		/// <summary>
		///       图片的透明色
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		[HtmlAttribute]
		[ComVisible(true)]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color TransparentColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
				method_17();
				method_21();
			}
		}

		[DefaultValue(null)]
		[XmlElement]
		[ComVisible(true)]
		[Browsable(false)]
		public string TransparentColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TransparentColor, Color.Transparent);
			}
			set
			{
				TransparentColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       允许用户编辑图片上的附加图形
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool EnableEditImageAdditionShape
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       是否启用合并图片数据
		///       </summary>
		[DefaultValue(false)]
		[ComVisible(true)]
		public bool EnableRepeatedImage
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       重复引用的图片数据的数据编号,DCWriter内部使用。
		///       </summary>
		[DefaultValue(-1)]
		[XmlElement]
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(true)]
		public int ValueIndexOfRepeatedImage
		{
			get
			{
				return int_8;
			}
			set
			{
				if (int_8 != value)
				{
					int_8 = value;
					method_17();
					method_21();
				}
			}
		}

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[DefaultValue(VerticalAlignStyle.Bottom)]
		[ComVisible(true)]
		[HtmlAttribute]
		public VerticalAlignStyle VAlign
		{
			get
			{
				return verticalAlignStyle_0;
			}
			set
			{
				verticalAlignStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的垂直对齐方式
		///       </summary>
		
		public override VerticalAlignStyle RuntimeVAlign => VAlign;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "image";

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute(AttributeName = "title")]
		public string Title
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		/// <summary>
		///       缺少图片数据时显示的文本
		///       </summary>
		
		[DefaultValue(null)]
		[HtmlAttribute(AttributeName = "alt")]
		public string Alt
		{
			get
			{
				return string_12;
			}
			set
			{
				string_12 = value;
			}
		}

		/// <summary>
		///       保持宽度、高度比例。若本属性值为true，
		///       则用户鼠标拖拽改变图片大小时会保持图片的宽度高度比例，
		///       否则用户可以随意改变图片的宽度和高度。
		///       </summary>
		[DefaultValue(true)]
		public bool KeepWidthHeightRate
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
				method_18();
			}
		}

		
		public bool RuntimeKeepWidthHeightRate
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_71))
				{
					return KeepWidthHeightRate;
				}
				return false;
			}
		}

		/// <summary>
		///       图片来源
		///       </summary>
		[DefaultValue(null)]
		public string Source
		{
			get
			{
				return string_13;
			}
			set
			{
				string_13 = value;
				if (ximageValue_0 != null)
				{
					ximageValue_0.Dispose();
					ximageValue_0 = null;
				}
				int_9 = 0;
				method_17();
				method_21();
			}
		}

		/// <summary>
		///       运行时使用的图片来源
		///       </summary>
		private string RuntimeSource
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_70))
				{
					return Source;
				}
				return null;
			}
		}

		/// <summary>
		///       根据Source属性加载的图片数据
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(null)]
		
		public XImageValue ImageFromSource
		{
			get
			{
				int num = 18;
				if (SaveContentInFile)
				{
					return null;
				}
				if (ximageValue_0 == null)
				{
					if (int_9 > 3)
					{
						return null;
					}
					string runtimeSource = RuntimeSource;
					if (!string.IsNullOrEmpty(runtimeSource))
					{
						try
						{
							if (OwnerDocument.BinaryBuffer != null && OwnerDocument.BinaryBuffer.Contains(runtimeSource))
							{
								byte[] content = OwnerDocument.BinaryBuffer.GetContent(runtimeSource);
								if (content != null)
								{
									content = smethod_0(content);
									ximageValue_0 = new XImageValue(content, bool_2: true);
								}
								return ximageValue_0;
							}
							WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(WriterControl, OwnerDocument, this, runtimeSource, null);
							WriterControl.ReadFileContent(WriterControl, writerReadFileContentEventArgs);
							byte[] array = writerReadFileContentEventArgs.GetResultBinary();
							if (array != null)
							{
								array = smethod_0(array);
								ximageValue_0 = new XImageValue(array, bool_2: true);
							}
							if (OwnerDocument.BinaryBuffer != null)
							{
								OwnerDocument.BinaryBuffer.SetContent(runtimeSource, array);
							}
						}
						catch (FileNotFoundException)
						{
							int_9++;
							Debug.WriteLine("FileNotFoundException:" + runtimeSource);
						}
						catch (Exception ex2)
						{
							int_9++;
							Debug.WriteLine(ex2.Message);
						}
					}
				}
				return ximageValue_0;
			}
		}

		/// <summary>
		///       保存图片数据到文件中
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(true)]
		public bool SaveContentInFile
		{
			get
			{
				return bool_12;
			}
			set
			{
				bool_12 = value;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[XmlElement]
		
		[Browsable(true)]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       扩展图形的根页面对象
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public ShapeDocumentPage AdditionShapePage => AdditionShape?.FirstPage;

		/// <summary>
		///       附加图形对象
		///       </summary>
		[ComVisible(true)]
		
		[DefaultValue(null)]
		public ShapeDocument AdditionShape
		{
			get
			{
				if (shapeDocument_0 != null)
				{
					shapeDocument_0.vmethod_20();
					shapeDocument_0.method_4(bool_8: true);
				}
				if (shapeDocument_0 != null && shapeDocument_0.Pages.Count > 0 && shapeDocument_0.Pages[0] is ShapeDocumentImagePage)
				{
					ShapeDocumentImagePage shapeDocumentImagePage = (ShapeDocumentImagePage)shapeDocument_0.Pages[0];
					shapeDocumentImagePage.Image = null;
				}
				return shapeDocument_0;
			}
			set
			{
				shapeDocument_0 = value;
				method_21();
			}
		}

		/// <summary>
		///       DCWriter内部使用
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[XmlIgnore]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		[ComVisible(false)]
		[Browsable(false)]
		[DefaultValue(false)]
		
		[HtmlAttribute]
		public string InnerAdditionShape
		{
			get
			{
				if (shapeDocument_0 == null || shapeDocument_0.Pages.Count == 0 || shapeDocument_0.Pages[0].Elements.Count == 0)
				{
					return null;
				}
				string s = XMLHelper.SaveObjectToXMLString(shapeDocument_0);
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				return Convert.ToBase64String(bytes);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					shapeDocument_0 = null;
					return;
				}
				byte[] bytes = Convert.FromBase64String(value);
				string @string = Encoding.UTF8.GetString(bytes);
				try
				{
					shapeDocument_0 = (ShapeDocument)XMLHelper.LoadObjectFromXMLString(typeof(ShapeDocument), @string);
				}
				catch (Exception)
				{
					shapeDocument_0 = null;
				}
			}
		}

		/// <summary>
		///       额外的图形数据
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		[Obsolete("仅供兼容性支持，已永久返回空引用了。推荐使用AdditionShape属性")]
		public string AdditionShapeContent
		{
			get
			{
				return null;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					shapeDocument_0 = null;
				}
				else
				{
					StringReader textReader_ = new StringReader(value);
					shapeDocument_0 = new ShapeDocument();
					shapeDocument_0.vmethod_27(textReader_);
					shapeDocument_0.EditMode = false;
				}
				method_21();
			}
		}

		/// <summary>
		///       额外的图形数据采用固定大小
		///       </summary>
		[HtmlAttribute]
		
		[DefaultValue(false)]
		public bool AdditionShapeFixSize
		{
			get
			{
				return bool_13;
			}
			set
			{
				bool_13 = value;
			}
		}

		/// <summary>
		///       设置/获得对象在设计器中的大小
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override SizeF EditorSize
		{
			get
			{
				return base.EditorSize;
			}
			set
			{
				base.EditorSize = value;
				method_19();
				method_21();
			}
		}

		/// <summary>
		///       压缩保存模式,以实际大小来设置保存的数据，这会导致大图片数据的损失。
		///       </summary>
		
		[DefaultValue(true)]
		public bool CompressSaveMode
		{
			get
			{
				return bool_14;
			}
			set
			{
				bool_14 = value;
			}
		}

		/// <summary>
		///       运行时使用的图片对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		
		public XImageValue RuntimeImage
		{
			get
			{
				if (EnableRepeatedImage)
				{
					XImageValue xImageValue = OwnerDocument.RepeatedImages.method_3(ValueIndexOfRepeatedImage);
					if (xImageValue != null)
					{
						if (TransparentColor.A != 0 && xImageValue.Value is Bitmap)
						{
							if (ximageValue_1 == null)
							{
								Bitmap bitmap = (Bitmap)xImageValue.Value.Clone();
								bitmap.MakeTransparent(TransparentColor);
								ximageValue_1 = new XImageValue(bitmap);
							}
							return ximageValue_1;
						}
						return xImageValue;
					}
				}
				if (ximageValue_1 == null)
				{
					XImageValue xImageValue2 = ImageFromSource;
					if (xImageValue2 == null)
					{
						xImageValue2 = Image;
					}
					if (TransparentColor.A != 0)
					{
						if (ximageValue_1 == null && xImageValue2.Value is Bitmap)
						{
							Bitmap bitmap = (Bitmap)xImageValue2.Value.Clone();
							bitmap.MakeTransparent(TransparentColor);
							ximageValue_1 = new XImageValue(bitmap);
						}
						else
						{
							ximageValue_1 = xImageValue2;
						}
						return ximageValue_1;
					}
					return xImageValue2;
				}
				return ximageValue_1;
			}
			set
			{
				ximageValue_1 = value;
			}
		}

		/// <summary>
		///       内部的图像数据对象
		///       </summary>
		
		public XImageValue Image
		{
			get
			{
				if (ximageValue_2 == null)
				{
					ximageValue_2 = new XImageValue();
					ximageValue_2.SafeLoadMode = false;
				}
				if (OwnerDocument != null)
				{
					ximageValue_2.FormatBase64String = OwnerDocument.Options.BehaviorOptions.OutputFormatedXMLSource;
				}
				return ximageValue_2;
			}
			set
			{
				ximageValue_2 = value;
				if (ximageValue_1 != null)
				{
					XImageValue xImageValue = ximageValue_1;
					ximageValue_1 = null;
					xImageValue.Dispose();
				}
			}
		}

		/// <summary>
		///       图像对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[Browsable(false)]
		public Image ImageValue
		{
			get
			{
				if (ximageValue_2 == null)
				{
					return null;
				}
				return ximageValue_2.Value;
			}
			set
			{
				if (ximageValue_2 == null)
				{
					ximageValue_2 = new XImageValue();
					ximageValue_2.SafeLoadMode = false;
				}
				ximageValue_2.Value = value;
			}
		}

		/// <summary>
		///       图像数据
		///       </summary>
		
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public byte[] ImageData
		{
			get
			{
				if (ximageValue_2 == null)
				{
					return null;
				}
				return ximageValue_2.ImageData;
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					if (ximageValue_2 != null)
					{
						ximageValue_2.Dispose();
						ximageValue_2 = null;
					}
					return;
				}
				if (ximageValue_2 == null)
				{
					ximageValue_2 = new XImageValue();
					ximageValue_2.SafeLoadMode = false;
				}
				ximageValue_2.ImageData = value;
			}
		}

		/// <summary>
		///       预览使用的图片对象
		///       </summary>
		[Browsable(false)]
		public override Image PreviewImage
		{
			get
			{
				if (int_10 != Image.ContentVersion)
				{
					method_21();
					int_10 = Image.ContentVersion;
				}
				if (image_0 == null)
				{
					bool flag = false;
					if (HasAdditionalShape)
					{
						flag = true;
					}
					else if (RuntimeImage != null && RuntimeImage.HasContent)
					{
						SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(RuntimeImage.Width, RuntimeImage.Height), GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
						if (sizeF.Width > Width * 2f || sizeF.Height > Height * 2f)
						{
							flag = true;
						}
					}
					if (flag)
					{
						image_0 = CreateContentImage();
						if (TransparentColor.A != 0 && image_0 is Bitmap)
						{
							((Bitmap)image_0).MakeTransparent(TransparentColor);
						}
					}
				}
				return image_0;
			}
		}

		/// <summary>
		///       DCWriter内部使用.原始图片数据来源
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		[ComVisible(false)]
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[HtmlAttribute]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		public string InnerNativeImageSource
		{
			get
			{
				return string_14;
			}
			set
			{
				string_14 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用.原始图片数据来源
		///       </summary>
		
		[XmlIgnore]
		[Browsable(false)]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		[ComVisible(false)]
		[HtmlAttribute]
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool InnerHasNoImage
		{
			get
			{
				return bool_15;
			}
			set
			{
				bool_15 = value;
			}
		}

		/// <summary>
		///       是否有附加图形
		///       </summary>
		
		[Browsable(false)]
		public bool HasAdditionalShape
		{
			get
			{
				if (AdditionShape != null && AdditionShape.Pages.Count > 0 && AdditionShape.Pages[0].Elements.Count > 0)
				{
					return true;
				}
				return false;
			}
		}

		[DefaultValue(null)]
		[XmlArrayItem("Image", typeof(PageImageInfo))]
		public PageImageInfoList PageImages
		{
			get
			{
				if (pageImageInfoList_0 == null)
				{
					pageImageInfoList_0 = new PageImageInfoList();
				}
				return pageImageInfoList_0;
			}
			set
			{
				pageImageInfoList_0 = value;
			}
		}

		
		public string PageImagesPreview
		{
			get
			{
				int num = 12;
				StringBuilder stringBuilder = new StringBuilder();
				if (pageImageInfoList_0 != null)
				{
					foreach (PageImageInfo item in pageImageInfoList_0)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.AppendLine();
						}
						stringBuilder.Append(item.PageIndex + "=" + item.Image);
					}
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       平滑缩放图像
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool SmoothZoom
		{
			get
			{
				return bool_16;
			}
			set
			{
				bool_16 = value;
			}
		}

		private bool RuntimeSmoothZoom
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_72))
				{
					return SmoothZoom;
				}
				return false;
			}
		}

		/// <summary>
		///       自定义的额外图形数据
		///       </summary>
		
		[DefaultValue(null)]
		[ComVisible(true)]
		[HtmlAttribute]
		public string CustomAdditionShapeContent
		{
			get
			{
				return string_15;
			}
			set
			{
				string_15 = value;
			}
		}

		/// <summary>
		///       表示对象内容的纯文本数据
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlIgnore]
		public override string Text
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextImageElement()
		{
			base.WidthHeightRate = 0.0;
		}

		public void method_16(bool bool_17)
		{
			if (EnableRepeatedImage == bool_17)
			{
				return;
			}
			if (EnableRepeatedImage)
			{
				if (OwnerDocument != null)
				{
					RepeatedImageValue repeatedImageValue = OwnerDocument.RepeatedImages.method_3(ValueIndexOfRepeatedImage);
					if (repeatedImageValue != null)
					{
						ximageValue_2 = new XImageValue();
						ximageValue_2.SafeLoadMode = false;
						repeatedImageValue = (RepeatedImageValue)repeatedImageValue.Clone();
						repeatedImageValue.method_3(ximageValue_2);
					}
				}
				ValueIndexOfRepeatedImage = -1;
			}
			EnableRepeatedImage = bool_17;
		}

		private void method_17()
		{
			if (ximageValue_1 != null)
			{
				ximageValue_1.Dispose();
				ximageValue_1 = null;
			}
		}

		public override void FixDomState()
		{
			int_9 = 0;
			base.FixDomState();
		}

		public override void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 8;
			base.OnViewMouseDblClick(elementMouseEventArgs_0);
			if (!elementMouseEventArgs_0.Handled && elementMouseEventArgs_0.Button == MouseButtons.Left && !RuntimeContentReadonly)
			{
				object obj = OwnerDocument.EditorControl.ExecuteCommand("EditImageAdditionShape", showUI: true, this);
				if (obj is bool && (bool)obj)
				{
					elementMouseEventArgs_0.Handled = true;
				}
			}
		}

		private bool method_18()
		{
			double num = 0.0;
			num = ((!RuntimeKeepWidthHeightRate || ximageValue_2 == null || ximageValue_2.Value == null || ximageValue_2.Height <= 0) ? 0.0 : ((double)ximageValue_2.Width / (double)ximageValue_2.Height));
			if (WidthHeightRate != num)
			{
				WidthHeightRate = num;
				return true;
			}
			return false;
		}

		private void method_19()
		{
			float clientWidth = ClientWidth;
			float clientHeight = ClientHeight;
			if (shapeDocument_0 == null || shapeDocument_0.Pages.Count <= 0)
			{
				return;
			}
			ShapeDocumentPage shapeDocumentPage = (ShapeDocumentPage)shapeDocument_0.Pages[0];
			if (shapeDocumentPage.Width != clientWidth || shapeDocumentPage.Height != clientHeight)
			{
				if (shapeDocumentPage.Width > 0f && shapeDocumentPage.Height > 0f)
				{
					float float_ = clientWidth / shapeDocumentPage.Width;
					float float_2 = clientHeight / shapeDocumentPage.Height;
					shapeDocumentPage.vmethod_0(float_, float_2);
				}
				shapeDocumentPage.Width = clientWidth;
				shapeDocumentPage.Height = clientHeight;
			}
		}

		/// <summary>
		///       设置元素大小
		///       </summary>
		/// <param name="width">新的元素宽度</param>
		/// <param name="height">新的元素高度</param>
		/// <param name="updateView">操作是否更新视图</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		
		public override bool EditorSetSize(float width, float height, bool updateView, bool logUndo)
		{
			bool result;
			if (result = base.EditorSetSize(width, height, updateView, logUndo))
			{
				method_19();
				method_21();
			}
			return result;
		}

		
		public bool method_20(Image image_1, bool bool_17, bool bool_18)
		{
			int num = 9;
			XTextDocument ownerDocument = OwnerDocument;
			if (bool_18)
			{
				if (ownerDocument.BeginLogUndo())
				{
					ownerDocument.UndoList.AddProperty("ImageValue", image_1, ImageValue, this);
					ownerDocument.UndoList.AddMethod(UndoMethodTypes.Invalidate);
				}
				ImageValue = image_1;
			}
			if (bool_17)
			{
				InvalidateView();
			}
			return true;
		}

		public override void vmethod_21(string string_16)
		{
			if (ximageValue_2 == null)
			{
				ximageValue_2 = ximageValue_1;
			}
			if (shapeDocument_0 != null)
			{
				shapeDocument_0.method_5();
			}
			if (CompressSaveMode)
			{
				if (ximageValue_1 == null)
				{
					RuntimeImage = ximageValue_2;
				}
				if (ximageValue_1 != null)
				{
					Size size = OwnerDocument.ToPixel(new Size((int)Width, (int)Height));
					if ((double)ximageValue_1.Width > (double)size.Width * 1.5 && (double)ximageValue_1.Height > (double)size.Height * 1.5)
					{
						try
						{
							ximageValue_2 = ximageValue_1.GetThumbnailImage(size.Width, size.Height);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
							ximageValue_2 = ximageValue_1;
						}
					}
				}
			}
			base.vmethod_21(string_16);
		}

		/// <summary>
		///       加载图片数据
		///       </summary>
		/// <param name="base64">Base64字符串</param>
		/// <param name="setSize">是否设置大小</param>
		/// <returns>操作是否成功</returns>
		
		[ComVisible(false)]
		public bool LoadImageFromBase64String(string base64, bool setSize)
		{
			if (!string.IsNullOrEmpty(base64))
			{
				if (ximageValue_2 == null)
				{
					ximageValue_2 = new XImageValue();
				}
				ximageValue_2.SafeLoadMode = false;
				ximageValue_2.LoadBase64String(base64);
				if (setSize)
				{
					UpdateSize(keepSizePossible: false);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       加载图片数据
		///       </summary>
		/// <param name="img">图片对象</param>
		/// <param name="setSize">是否设置大小</param>
		/// <returns>操作是否成功</returns>
		
		[ComVisible(false)]
		public bool LoadImage(Image image_1, bool setSize)
		{
			if (image_1 != null)
			{
				if (ximageValue_2 == null)
				{
					ximageValue_2 = new XImageValue(image_1);
				}
				else
				{
					ximageValue_2.Value = image_1;
				}
				if (setSize)
				{
					UpdateSize(keepSizePossible: false);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       从指定的资源地址加载图片数据
		///       </summary>
		/// <param name="strUrl">图片资源地址</param>
		/// <param name="setSize">是否设置对象大小</param>
		/// <returns>操作是否成功</returns>
		
		public bool LoadImage(string strUrl, bool setSize)
		{
			if (ximageValue_2 == null)
			{
				ximageValue_2 = new XImageValue();
			}
			ximageValue_2.SafeLoadMode = false;
			if (ximageValue_2.Load(strUrl) > 0)
			{
				if (setSize)
				{
					UpdateSize(keepSizePossible: false);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得提示文本信息
		///       </summary>
		/// <returns>
		/// </returns>
		public override GClass96 GetToolTipInfo()
		{
			GClass96 gClass = base.GetToolTipInfo();
			if (gClass == null && !string.IsNullOrEmpty(Title))
			{
				gClass = new GClass96(this, Title);
				gClass.method_12(ToolTipContentType.ElementToolTip);
			}
			return gClass;
		}

		/// <summary>
		///       文档加载后事件
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			if (Image == null || !Image.HasContent)
			{
				UpdateImageContent();
			}
		}

		private static byte[] smethod_0(byte[] byte_0)
		{
			return byte_0;
		}

		/// <summary>
		///       更新内容
		///       </summary>
		
		public void UpdateImageContent()
		{
			if (!string.IsNullOrEmpty(RuntimeSource))
			{
				WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(OwnerDocument.EditorControl, OwnerDocument, this, RuntimeSource, null);
				byte[] array = WriterControl.ReadFileContent(OwnerDocument.EditorControl, writerReadFileContentEventArgs);
				writerReadFileContentEventArgs.InnerDispose();
				if (array != null)
				{
					array = smethod_0(array);
					XImageValue xImageValue2 = Image = new XImageValue(array, bool_2: false);
				}
			}
		}

		public override void vmethod_23()
		{
			method_18();
			base.vmethod_23();
		}

		/// <summary>
		///       根据图片内容更新元素的大小
		///       </summary>
		/// <param name="keepSizePossible">是否尽量保持大小不变或少变化</param>
		
		public void UpdateSize(bool keepSizePossible)
		{
			if (Image.HasContent)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(ximageValue_2.Width, ximageValue_2.Height), GraphicsUnit.Pixel, (OwnerDocument == null) ? GraphicsUnit.Document : OwnerDocument.DocumentGraphicsUnit);
				bool flag = method_18();
				if (keepSizePossible && flag)
				{
					return;
				}
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				if (keepSizePossible)
				{
					if (RuntimeKeepWidthHeightRate)
					{
						float num = 0f;
						num = ((runtimeStyle != null) ? ((float)((double)ClientWidth / WidthHeightRate) + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom) : ((float)((double)Width / WidthHeightRate)));
						if (num != Height)
						{
							EditorSize = new SizeF(Width, num);
						}
					}
				}
				else if (runtimeStyle == null)
				{
					EditorSize = new SizeF(sizeF.Width, sizeF.Height);
				}
				else
				{
					EditorSize = new SizeF(sizeF.Width + runtimeStyle.PaddingLeft + runtimeStyle.PaddingRight, sizeF.Height + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom);
				}
			}
			else
			{
				EditorSize = new SizeF(100f, 100f);
			}
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public override void Dispose()
		{
			if (ximageValue_2 != null)
			{
				ximageValue_2.Dispose();
				ximageValue_2 = null;
			}
			method_17();
			method_21();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextImageElement xTextImageElement = (XTextImageElement)base.Clone(Deeply);
			if (shapeDocument_0 != null)
			{
				xTextImageElement.shapeDocument_0 = (ShapeDocument)shapeDocument_0.vmethod_17(bool_8: true);
			}
			if (image_0 != null)
			{
				xTextImageElement.image_0 = (Image)image_0.Clone();
			}
			if (ximageValue_1 != null)
			{
				xTextImageElement.ximageValue_1 = ximageValue_1.Clone();
			}
			if (pageImageInfoList_0 != null)
			{
				xTextImageElement.pageImageInfoList_0 = pageImageInfoList_0.Clone();
			}
			if (ximageValue_2 != null)
			{
				xTextImageElement.ximageValue_2 = ximageValue_2.Clone();
			}
			return xTextImageElement;
		}

		private void method_21()
		{
			if (image_0 != null)
			{
				image_0.Dispose();
				image_0 = null;
			}
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 14;
			bool_15 = false;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			DocumentContentStyle documentContentStyle = readHTMLEventArgs_0.CreateContentStyle(readHTMLEventArgs_0.CurrentStyle, this, readHTMLEventArgs_0.HtmlElement);
			if (readHTMLEventArgs_0.HtmlElement.method_13("border"))
			{
				documentContentStyle.BorderWidth = readHTMLEventArgs_0.ToInt32(readHTMLEventArgs_0.HtmlElement.method_9("border"));
				documentContentStyle.BorderLeft = true;
				documentContentStyle.BorderTop = true;
				documentContentStyle.BorderRight = true;
				documentContentStyle.BorderBottom = true;
			}
			Style = documentContentStyle;
			SizeF sizeF = readHTMLEventArgs_0.ReadImageSize(readHTMLEventArgs_0.HtmlElement);
			if (sizeF.Width > 0f)
			{
				Width = sizeF.Width;
			}
			if (sizeF.Height > 0f)
			{
				Height = sizeF.Height;
			}
			Alt = readHTMLEventArgs_0.HtmlElement.method_9("alt");
			Title = readHTMLEventArgs_0.HtmlElement.method_9("title");
			if (!bool_15)
			{
				if (!string.IsNullOrEmpty(string_14))
				{
					string absoluteURL = readHTMLEventArgs_0.HtmlDocument.GetAbsoluteURL(string_14);
					string_14 = null;
					XImageValue xImageValue = method_22(absoluteURL);
					if (xImageValue != null)
					{
						Image = xImageValue;
					}
				}
				if ((Image == null || !Image.HasContent) && readHTMLEventArgs_0.HtmlElement.method_13("src"))
				{
					string absoluteURL = readHTMLEventArgs_0.HtmlElement.method_9("src");
					if (absoluteURL != null && absoluteURL.StartsWith("data:image/png;base64,", StringComparison.CurrentCultureIgnoreCase))
					{
						string s = absoluteURL.Substring("data:image/png;base64,".Length);
						byte[] byte_ = Convert.FromBase64String(s);
						XImageValue xImageValue = Image = new XImageValue(byte_, bool_2: false);
					}
					else
					{
						absoluteURL = readHTMLEventArgs_0.HtmlDocument.GetAbsoluteURL(absoluteURL);
						XImageValue xImageValue = Image = method_22(absoluteURL);
					}
				}
			}
			if (Width == 0f || Height == 0f)
			{
				UpdateSize(keepSizePossible: false);
			}
		}

		private XImageValue method_22(string string_16)
		{
			int num = 14;
			try
			{
				XImageValue xImageValue = new XImageValue();
				xImageValue.SafeLoadMode = false;
				string text = string.Format(WriterStringsCore.Downloading_URL, string_16);
				if (WriterControl != null)
				{
					WriterControl.SetStatusText(text);
				}
				if (OwnerDocument.Options.BehaviorOptions.DebugMode)
				{
					Debug.Write(text);
				}
				int num2 = 0;
				if (OwnerDocument.writerReadFileContentEventHandler_0 != null)
				{
					WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(WriterControl, OwnerDocument, this, string_16, null);
					OwnerDocument.writerReadFileContentEventHandler_0(this, writerReadFileContentEventArgs);
					if (writerReadFileContentEventArgs.Cancel)
					{
						return null;
					}
					byte[] resultBinary = writerReadFileContentEventArgs.GetResultBinary();
					if (resultBinary != null && resultBinary.Length > 0)
					{
						num2 = resultBinary.Length;
						xImageValue.ImageData = resultBinary;
					}
				}
				if (num2 == 0)
				{
					num2 = xImageValue.Load(string_16);
				}
				if (OwnerDocument.Options.BehaviorOptions.DebugMode)
				{
					Debug.WriteLine(WriterUtils.smethod_44(num2));
				}
				if (WriterControl != null)
				{
					WriterControl.SetStatusText(null);
				}
				return xImageValue;
			}
			catch (Exception ex)
			{
				Alt = string_16 + ":" + ex.Message;
				if (OwnerDocument.Options.BehaviorOptions.DebugMode)
				{
					Debug.WriteLine(WriterStringsCore.Fail);
				}
			}
			if (WriterControl != null)
			{
				WriterControl.SetStatusText(null);
			}
			return null;
		}

		/// <summary>
		///       设置页码图片值
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <param name="img">图片对象</param>
		
		[ComVisible(true)]
		public void SetPageImage(int pageIndex, Image image_1)
		{
			PageImages.SetImage(pageIndex, new XImageValue(image_1));
		}

		/// <summary>
		///       设置页码图片值
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <param name="img">图片对象</param>
		[ComVisible(true)]
		
		public void SetPageImageByImageValue(int pageIndex, XImageValue ximageValue_3)
		{
			PageImages.SetImage(pageIndex, ximageValue_3);
		}

		/// <summary>
		///       设置页码图片值
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <param name="base64">BASE64文本值</param>
		[ComVisible(true)]
		
		public void SetPageImageByBase64String(int pageIndex, string base64)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.SafeLoadMode = false;
			xImageValue.LoadBase64String(base64);
			PageImages.SetImage(pageIndex, xImageValue);
		}

		/// <summary>
		///       设置页码图片值
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		public void SetPageImageByFileName(int pageIndex, string fileName)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.SafeLoadMode = false;
			xImageValue.Load(fileName);
			PageImages.SetImage(pageIndex, xImageValue);
		}

		private void method_23(DocumentPaintEventArgs documentPaintEventArgs_0, Image image_1)
		{
			RectangleF clientViewBounds = documentPaintEventArgs_0.ClientViewBounds;
			RectangleF descRect = RectangleF.Intersect(clientViewBounds, documentPaintEventArgs_0.ClipRectangle);
			if (RuntimeZOrderStyle == ElementZOrderStyle.Normal && RuntimeStyle.LayoutAlign == ContentLayoutAlign.EmbedInText)
			{
				descRect.Intersect(base.OwnerLine.AbsBounds);
			}
			PointF location = descRect.Location;
			descRect.X -= clientViewBounds.X;
			descRect.Y -= clientViewBounds.Y;
			RectangleF rectangleF = new RectangleF(0f, 0f, image_1.Width, image_1.Height);
			RectangleF sourceRect = new RectangleF((float)Math.Round(rectangleF.Width * descRect.X / clientViewBounds.Width, 3), (float)Math.Round(rectangleF.Height * descRect.Y / clientViewBounds.Height, 3), (float)Math.Round(rectangleF.Width * descRect.Width / clientViewBounds.Width, 3), (float)Math.Round(rectangleF.Height * descRect.Height / clientViewBounds.Height, 3));
			descRect.Location = location;
			InterpolationMode imageInterpolationMode = OwnerDocument.Options.ViewOptions.ImageInterpolationMode;
			if (imageInterpolationMode != InterpolationMode.Invalid)
			{
				documentPaintEventArgs_0.Graphics.InterpolationMode = imageInterpolationMode;
			}
			documentPaintEventArgs_0.Graphics.DrawImage(image_1, descRect, sourceRect, GraphicsUnit.Pixel);
		}

		/// <summary>
		///       绘制图片文档内容
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			Image image = null;
			if (pageImageInfoList_0 != null && pageImageInfoList_0.Count > 0)
			{
				XImageValue xImageValue = PageImages.GetImage(args.PageIndex);
				if (xImageValue == null)
				{
					xImageValue = RuntimeImage;
				}
				if (xImageValue != null)
				{
					image = xImageValue.Value;
				}
			}
			if (args.RenderMode == DocumentRenderMode.PDF)
			{
				Image image2 = image;
				if (image2 == null)
				{
					image2 = base.CreateContentImage();
					if (image2 is Bitmap && TransparentColor.A != 0)
					{
						((Bitmap)image2).MakeTransparent(TransparentColor);
					}
				}
				if (image2.RawFormat.Guid != ImageFormat.Jpeg.Guid)
				{
					MemoryStream memoryStream = new MemoryStream();
					if (TransparentColor.A != 0)
					{
						image2.Save(memoryStream, ImageFormat.Png);
					}
					else
					{
						image2.Save(memoryStream, ImageFormat.Jpeg);
					}
					image2.Dispose();
					image2 = null;
					memoryStream.Position = 0L;
					image2 = System.Drawing.Image.FromStream(memoryStream);
				}
				args.Graphics.DrawImage(image2, args.ClientViewBounds);
				return;
			}
			RectangleF clientViewBounds = args.ClientViewBounds;
			RectangleF rectangleF = clientViewBounds;
			rectangleF.Intersect(args.ClipRectangle);
			if (OwnerDocument.LastDrawAbsoluteBounds != null)
			{
				PointF[] value = DrawerUtil.TransformRectangle(args.Graphics.Transform, clientViewBounds);
				OwnerDocument.LastDrawAbsoluteBounds[this] = value;
			}
			if (image != null)
			{
				method_23(args, image);
				if (HasAdditionalShape)
				{
					method_24(args);
				}
				return;
			}
			if (args.RenderMode == DocumentRenderMode.Paint && PreviewImage != null)
			{
				if (RuntimeSmoothZoom)
				{
					method_23(args, PreviewImage);
					return;
				}
				Image image2 = PreviewImage;
				InterpolationMode interpolationMode = args.Graphics.InterpolationMode;
				PixelOffsetMode pixelOffsetMode = args.Graphics.PixelOffsetMode;
				args.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				args.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
				method_23(args, image2);
				args.Graphics.InterpolationMode = interpolationMode;
				args.Graphics.PixelOffsetMode = pixelOffsetMode;
				return;
			}
			XImageValue runtimeImage = RuntimeImage;
			if (runtimeImage.HasContent)
			{
				Image image2 = runtimeImage.Value;
				if (args.RenderMode == DocumentRenderMode.PDF)
				{
					args.Graphics.DrawImage(image2, clientViewBounds);
				}
				else if (RuntimeSmoothZoom)
				{
					method_23(args, image2);
				}
				else
				{
					InterpolationMode interpolationMode = args.Graphics.InterpolationMode;
					PixelOffsetMode pixelOffsetMode = args.Graphics.PixelOffsetMode;
					args.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					args.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
					method_23(args, image2);
					args.Graphics.InterpolationMode = interpolationMode;
					args.Graphics.PixelOffsetMode = pixelOffsetMode;
				}
			}
			else
			{
				bool flag = true;
				if ((args.RenderMode == DocumentRenderMode.Print || args.RenderMode == DocumentRenderMode.ReadPaint) && !OwnerDocument.Options.ViewOptions.PrintImageAltText)
				{
					flag = false;
				}
				if (flag)
				{
					DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Color = Color.Red;
					drawStringFormatExt.SetBounds(clientViewBounds);
					drawStringFormatExt.Font = new XFontValue();
					string string_ = WriterStringsCore.NoImage;
					if (!string.IsNullOrEmpty(Alt))
					{
						string_ = Alt;
					}
					args.Graphics.method_2(string_, drawStringFormatExt);
				}
			}
			if (HasAdditionalShape)
			{
				method_24(args);
			}
		}

		private void method_24(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (XTextDocument.smethod_13(GEnum6.const_74))
			{
				ShapeDocument additionShape = AdditionShape;
				ShapeDocumentPage shapeDocumentPage = (ShapeDocumentPage)additionShape.Pages[0];
				additionShape.vmethod_3(documentPaintEventArgs_0.Graphics);
				ShapeRenderEventArgs shapeRenderEventArgs = new ShapeRenderEventArgs();
				shapeRenderEventArgs.ClipRectangle = documentPaintEventArgs_0.ClipRectangle;
				shapeRenderEventArgs.DesignMode = false;
				shapeRenderEventArgs.Document = additionShape;
				shapeRenderEventArgs.Element = shapeDocumentPage;
				shapeRenderEventArgs.Graphics = documentPaintEventArgs_0.Graphics;
				shapeRenderEventArgs.Render = new GClass331();
				shapeRenderEventArgs.Style = ShapeRenderStyle.Paint;
				shapeRenderEventArgs.ViewOptions = additionShape.Options.ViewOptions;
				shapeRenderEventArgs.ZoomRate = 1f;
				GraphicsState graphicsState_ = shapeRenderEventArgs.Graphics.Save();
				shapeRenderEventArgs.Graphics.TranslateTransform(AbsLeft, AbsTop, MatrixOrder.Append);
				try
				{
					if (shapeDocumentPage is ShapeDocumentImagePage)
					{
						ShapeDocumentImagePage shapeDocumentImagePage = (ShapeDocumentImagePage)shapeDocumentPage;
						shapeDocumentImagePage.Image = Image;
					}
					if (shapeDocumentPage.Elements != null && shapeDocumentPage.Elements.Count > 0)
					{
						if (!XTextDocument.smethod_13(GEnum6.const_74))
						{
							return;
						}
						if (!AdditionShapeFixSize)
						{
							shapeRenderEventArgs.Graphics.ScaleTransform(Width / shapeDocumentPage.Width, Height / shapeDocumentPage.Height);
							shapeDocumentPage.vmethod_7(shapeRenderEventArgs);
						}
						else
						{
							shapeDocumentPage.vmethod_7(shapeRenderEventArgs);
						}
						shapeDocumentPage.vmethod_7(shapeRenderEventArgs);
					}
				}
				finally
				{
					if (shapeDocumentPage is ShapeDocumentImagePage)
					{
						ShapeDocumentImagePage shapeDocumentImagePage = (ShapeDocumentImagePage)shapeDocumentPage;
						shapeDocumentImagePage.Image = null;
					}
					shapeDocumentPage.Left = 0f;
					shapeDocumentPage.Top = 0f;
				}
				shapeRenderEventArgs.Graphics.Restore(graphicsState_);
				additionShape.Dispose();
			}
		}

		/// <summary>
		///       创建预览用的图片
		///       </summary>
		/// <returns>创建的图片对象</returns>
		
		public override Image CreateContentImage()
		{
			if (RuntimeImage.HasContent && !HasAdditionalShape)
			{
				SizeF size = new SizeF(Width, Height);
				size = GraphicsUnitConvert.Convert(size, OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
				Color white = Color.White;
				if (OwnerDocument == null || OwnerDocument.PageSettings.RuntimePageBorderBackground == null)
				{
				}
				return RuntimeImage.GetThumbnailImage((int)size.Width, (int)size.Height, white).Value;
			}
			return base.CreateContentImage();
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			SizeF size = new SizeF(Width, Height);
			size = GraphicsUnitConvert.Convert(size, OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			if (AdditionShape != null)
			{
				using (Image image = CreateContentImage())
				{
					gclass103_0.method_45(image, (int)size.Width, (int)size.Height, null, RuntimeStyle);
				}
				return;
			}
			XImageValue runtimeImage = RuntimeImage;
			if (runtimeImage != null && runtimeImage.HasContent)
			{
				gclass103_0.method_45(runtimeImage.Value, (int)size.Width, (int)size.Height, Image.ImageData, RuntimeStyle);
			}
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 3;
			if (Image == null)
			{
				return "[IMG Null]";
			}
			return "[IMG" + Image.ToString() + "]";
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToPlaintString()
		{
			return "";
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
		}
	}
}
