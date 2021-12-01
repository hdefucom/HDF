using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       段落结束标记对象,XWriterLib内部使用
	///       </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextParagraphFlagElement))]
	[XmlType("XParagraphFlag")]
	[ComClass("00012345-6789-ABCD-EF01-23456789001B", "DD4653F9-509D-4AEE-A021-AD63E1A59A1C")]
	[DocumentComment]
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("00012345-6789-ABCD-EF01-23456789001B")]
	public sealed class XTextParagraphFlagElement : XTextEOFElement, IXTextParagraphFlagElement
	{
		internal const string string_3 = "00012345-6789-ABCD-EF01-23456789001B";

		internal const string string_4 = "DD4653F9-509D-4AEE-A021-AD63E1A59A1C";

		private static Bitmap bitmap_0;

		private int int_6 = -1;

		[NonSerialized]
		private XTextParagraphListItemElement xtextParagraphListItemElement_0 = null;

		[NonSerialized]
		private bool bool_5 = false;

		private ContentLayoutDirectionStyle contentLayoutDirectionStyle_0 = ContentLayoutDirectionStyle.Default;

		internal float float_5 = 0f;

		private XTextElement xtextElement_0 = null;

		[NonSerialized]
		internal int int_7 = -1;

		private int int_8 = 0;

		private int int_9 = 0;

		[NonSerialized]
		private int int_10 = -1;

		[NonSerialized]
		private int int_11 = -1;

		private bool bool_6 = false;

		private bool bool_7 = false;

		[NonSerialized]
		private XTextParagraphFlagElement xtextParagraphFlagElement_0 = null;

		[NonSerialized]
		private List<XTextParagraphFlagElement> list_0 = null;

		[NonSerialized]
		private float float_6 = 1f;

		public override string DomDisplayName => "<P>" + RuntimeStyle.Align;

		/// <summary>
		///       主题编号,DCWriter内部使用。
		///       </summary>
		[DefaultValue(-1)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[XmlElement]
		[HtmlAttribute]
		public int TopicID
		{
			get
			{
				return int_6;
			}
			set
			{
				int_6 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。段落列表元素对象
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[ComVisible(false)]
		[Browsable(false)]
		public XTextParagraphListItemElement ListItemElement
		{
			get
			{
				return xtextParagraphListItemElement_0;
			}
			set
			{
				xtextParagraphListItemElement_0 = value;
			}
		}

		/// <summary>
		///       是否为根元素
		///       </summary>
		internal bool IsRootLevelElement
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       在公共内容中的第一个元素就是自己
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override XTextElement FirstContentElementInPublicContent => this;

		/// <summary>
		///       运行时的内容排版方向
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public ContentLayoutDirectionStyle RuntimeLayoutDirection
		{
			get
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				if (runtimeStyle == null)
				{
					return ContentLayoutDirectionStyle.LeftToRight;
				}
				if (contentLayoutDirectionStyle_0 == ContentLayoutDirectionStyle.Default)
				{
					contentLayoutDirectionStyle_0 = runtimeStyle.LayoutDirection;
				}
				if (contentLayoutDirectionStyle_0 == ContentLayoutDirectionStyle.Default)
				{
					if (!Class126.smethod_5())
					{
						return ContentLayoutDirectionStyle.LeftToRight;
					}
					XTextContentElement contentElement = ContentElement;
					if (contentElement == null || contentElement.PrivateContent == null)
					{
						return ContentLayoutDirectionStyle.LeftToRight;
					}
					XTextElementList privateContent = contentElement.PrivateContent;
					int num = privateContent.method_9(this);
					int num2 = 0;
					int num3 = 0;
					for (int num4 = num - 1; num4 >= 0; num4--)
					{
						XTextElement xTextElement = privateContent[num4];
						if (xTextElement != null)
						{
							if (xTextElement is XTextParagraphFlagElement)
							{
								break;
							}
							if (xTextElement is XTextCharElement)
							{
								char charValue = ((XTextCharElement)xTextElement).CharValue;
								if (Class126.smethod_8(charValue))
								{
									num3++;
								}
								else if (!char.IsWhiteSpace(charValue))
								{
									num2++;
								}
							}
						}
					}
					if (num3 > num2)
					{
						contentLayoutDirectionStyle_0 = ContentLayoutDirectionStyle.RightToLeft;
					}
					else
					{
						contentLayoutDirectionStyle_0 = ContentLayoutDirectionStyle.LeftToRight;
					}
				}
				return contentLayoutDirectionStyle_0;
			}
			set
			{
				contentLayoutDirectionStyle_0 = value;
			}
		}

		/// <summary>
		///       对象所属页码
		///       </summary>
		[Browsable(false)]
		public override int OwnerPageIndex
		{
			get
			{
				XTextLine ownerLine = base.OwnerLine;
				if (ownerLine != null && ownerLine.OwnerPage != null)
				{
					if (OwnerDocument == null)
					{
						return ownerLine.OwnerPage.PageIndex;
					}
					return OwnerDocument.Pages.IndexOf(ownerLine.OwnerPage);
				}
				return -1;
			}
		}

		/// <summary>
		///       判断是否是文档容器中最后一个段落元素 
		///       </summary>
		[Browsable(false)]
		public bool IsLastElementInContentElement
		{
			get
			{
				XTextContentElement contentElement = ContentElement;
				if (contentElement != null && contentElement.PrivateContent.LastElement == this)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       视图宽度
		///       </summary>
		[Browsable(false)]
		public override float ViewWidth => float_5;

		/// <summary>
		///       段落中第一个文档内容元素
		///       </summary>
		internal XTextElement ParagraphFirstContentElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
			}
		}

		/// <summary>
		///       段落列表样式
		///       </summary>
		internal ParagraphListStyle ListStyle => RuntimeStyle?.ParagraphListStyle ?? ParagraphListStyle.None;

		/// <summary>
		///       段落在段落列表中的序号
		///       </summary>
		[Browsable(true)]
		[DefaultValue(0)]
		[XmlIgnore]
		public int ListIndex
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
					bool_7 = false;
				}
			}
		}

		/// <summary>
		///       列表的最大值
		///       </summary>
		[DefaultValue(0)]
		[XmlIgnore]
		[Browsable(true)]
		[DCInternal]
		public int MaxListIndex
		{
			get
			{
				return int_9;
			}
			set
			{
				int_9 = value;
			}
		}

		/// <summary>
		///       段落大纲层次
		///       </summary>
		public int OutlineLevel => RuntimeStyle?.ParagraphOutlineLevel ?? (-1);

		[XmlIgnore]
		[ReadOnly(true)]
		[DefaultValue(-1)]
		[DCInternal]
		[Browsable(true)]
		public int RTFListOverriedID
		{
			get
			{
				return int_10;
			}
			internal set
			{
				int_10 = value;
			}
		}

		[DCInternal]
		[XmlIgnore]
		[DefaultValue(-1)]
		[ReadOnly(true)]
		[Browsable(true)]
		public int RTFOutlineLevel
		{
			get
			{
				return int_11;
			}
			internal set
			{
				int_11 = value;
			}
		}

		/// <summary>
		///       重新设置列表序号标记
		///       </summary>
		[DefaultValue(false)]
		public bool ResetListIndexFlag
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       本对象是否是自动产生的
		///       </summary>
		[DCInternal]
		[DefaultValue(false)]
		public bool AutoCreate
		{
			get
			{
				return bool_7 && StyleIndex < 0 && OutlineLevel >= 0 && !ResetListIndexFlag;
			}
			set
			{
				bool_7 = value;
			}
		}

		/// <summary>
		///       上级段落元素对象
		///       </summary>
		internal XTextParagraphFlagElement ParentParagraph
		{
			get
			{
				return xtextParagraphFlagElement_0;
			}
			set
			{
				xtextParagraphFlagElement_0 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。子段落元素列表
		///       </summary>
		[ComVisible(false)]
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		public List<XTextParagraphFlagElement> ChildParagraphs
		{
			get
			{
				if (list_0 == null)
				{
					list_0 = new List<XTextParagraphFlagElement>();
				}
				return list_0;
			}
		}

		/// <summary>
		///       所在段落的第一个内容元素对象
		///       </summary>
		public override XTextElement FirstContentElement
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return this;
				}
				return xtextElement_0;
			}
		}

		/// <summary>
		///       内部使用：字体缩放比率
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ReadOnly(true)]
		internal float FontSizeZoomRate
		{
			get
			{
				return float_6;
			}
			set
			{
				float_6 = value;
			}
		}

		/// <summary>
		///       段落边界矩形
		///       </summary>
		[Browsable(false)]
		internal RectangleF ParagraphBounds
		{
			get
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				XTextLine ownerLine = base.OwnerLine;
				if (ownerLine == null)
				{
					return RectangleF.Empty;
				}
				RectangleF rectangleF = new RectangleF(ownerLine.AbsLeft, ownerLine.AbsTop, ownerLine.ContentWidth, ownerLine.Height);
				if (ownerLine.LastElement is XTextParagraphFlagElement)
				{
					ownerLine.Width += ownerLine.LastElement.ViewWidth;
				}
				for (int num = documentContentElement.PrivateLines.IndexOf(ownerLine) - 1; num >= 0; num--)
				{
					XTextLine xTextLine = documentContentElement.PrivateLines[num];
					if (xTextLine.LastElement is XTextParagraphFlagElement)
					{
						break;
					}
					rectangleF = RectangleF.Union(rectangleF, xTextLine.Bounds);
				}
				return rectangleF;
			}
		}

		/// <summary>
		///       表示对象内容的纯文本数据
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return Environment.NewLine;
			}
			set
			{
			}
		}

		/// <summary>
		///       整个段落的文字
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		public string ParagraphText
		{
			get
			{
				XTextElementList content = base.DocumentContentElement.Content;
				int num = content.FastIndexOf(this);
				if (num >= 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						XTextElement xTextElement = content[num2];
						if (xTextElement is XTextParagraphFlagElement)
						{
							break;
						}
						if (!xTextElement.IsLogicDeleted)
						{
							stringBuilder.Insert(0, xTextElement.Text);
						}
					}
					if (ListItemElement != null)
					{
						stringBuilder.Insert(0, ListItemElement.Text);
					}
					return stringBuilder.ToString();
				}
				return "";
			}
		}

		static XTextParagraphFlagElement()
		{
			bitmap_0 = null;
			bitmap_0 = (Bitmap)WriterResourcesCore.ParagraphFlagLeftToRight.Clone();
			bitmap_0.MakeTransparent(Color.White);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextParagraphFlagElement()
		{
		}

		/// <summary>
		///       设置对象获得焦点
		///       </summary>
		public override void Focus()
		{
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			documentContentElement.Focus();
			int num = documentContentElement.Content.IndexOf(this);
			if (num >= 0)
			{
				documentContentElement.SetSelection(num, 0);
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
			}
		}

		/// <summary>
		///       段落标记元素不能设置可见性
		///       </summary>
		/// <param name="visible">
		/// </param>
		/// <param name="logUndo">
		/// </param>
		/// <param name="fastMode">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode)
		{
			return false;
		}

		internal void method_13(XTextParagraphFlagElement xtextParagraphFlagElement_1)
		{
			ChildParagraphs.Add(xtextParagraphFlagElement_1);
			xtextParagraphFlagElement_1.ParentParagraph = this;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深入复制子元素</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)base.Clone(Deeply);
			xTextParagraphFlagElement.int_10 = -1;
			xTextParagraphFlagElement.int_11 = -1;
			return xTextParagraphFlagElement;
		}

		/// <summary>
		///       绘制段落符号
		///       </summary>
		/// <param name="args">参数</param>
		public override void Draw(DocumentPaintEventArgs args)
		{
			int num = 16;
			OwnerDocument.method_85(this);
			args.Render.vmethod_3(this, args);
			if (args.RenderMode == DocumentRenderMode.Paint)
			{
				Bitmap bitmap = null;
				ContentLayoutDirectionStyle runtimeLayoutDirection = base.OwnerLine.RuntimeLayoutDirection;
				RectangleF absBounds = AbsBounds;
				switch (runtimeLayoutDirection)
				{
				case ContentLayoutDirectionStyle.LeftToRight:
					bitmap = DCStdImageList.Instance.BmpParagraphFlagLeftToRight;
					break;
				case ContentLayoutDirectionStyle.RightToLeft:
					bitmap = DCStdImageList.Instance.BmpParagraphFlagRightToLeft;
					absBounds.X = absBounds.Right - ViewWidth;
					break;
				default:
					bitmap = DCStdImageList.Instance.BmpParagraphFlagRightToLeft;
					break;
				}
				if (args.RenderMode == DocumentRenderMode.Paint)
				{
					Size size = bitmap.Size;
					size = OwnerDocument.PixelToDocumentUnit(size);
					InterpolationMode interpolationMode = args.Graphics.InterpolationMode;
					args.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					args.Graphics.DrawImage(bitmap, absBounds.Left, absBounds.Bottom - (float)size.Height);
					args.Graphics.InterpolationMode = interpolationMode;
				}
				if (args.Graphics != null)
				{
					args.Graphics.LogContent("\r\n");
				}
			}
		}

		/// <summary>
		///       计算段落符号元素大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			XTextDocument ownerDocument = OwnerDocument;
			Width = ownerDocument.sizeF_0.Width;
			Height = ownerDocument.sizeF_0.Height;
			XFontValue fastFont = RuntimeStyle.GetFastFont(FontSizeZoomRate);
			Height = args.Graphics.GetFontHeight(fastFont);
			float_5 = ownerDocument.float_7;
		}

		/// <summary>
		///       返回对象包含的字符串数据
		///       </summary>
		/// <returns>字符串数据</returns>
		public override string ToString()
		{
			return "[P]";
		}

		/// <summary>
		///       返回纯文本
		///       </summary>
		/// <returns>文本内容</returns>
		public override string ToPlaintString()
		{
			return Environment.NewLine;
		}

		/// <summary>
		///       获得整个段落中的文档元素
		///       </summary>
		/// <returns>
		/// </returns>
		[DCInternal]
		[ComVisible(true)]
		public XTextElementList GetParagraphElements()
		{
			XTextElementList xTextElementList = new XTextElementList();
			XTextElementList privateContent = ContentElement.PrivateContent;
			int num = privateContent.FastIndexOf(this);
			xTextElementList.AddRaw(this);
			if (num >= 0)
			{
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					XTextElement xTextElement = privateContent[num2];
					if (xTextElement is XTextParagraphFlagElement)
					{
						break;
					}
					xTextElementList.method_13(0, xTextElement);
				}
			}
			return xTextElementList;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (list_0 != null)
			{
				list_0.Clear();
				list_0 = null;
			}
			xtextParagraphListItemElement_0 = null;
			xtextElement_0 = null;
			xtextParagraphFlagElement_0 = null;
		}
	}
}
