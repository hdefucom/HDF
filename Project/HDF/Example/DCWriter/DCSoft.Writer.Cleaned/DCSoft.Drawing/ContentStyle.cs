using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       样式对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890086")]
	[ComDefaultInterface(typeof(IContentStyle))]
	public class ContentStyle : XDependencyObject, IDisposable, ICloneable, IContentStyle//, GInterface0
	{
		public const string string_0 = "BackgroundColor";

		public const string string_1 = "BackgroundColor2";

		public const string string_2 = "BackgroundStyle";

		public const string string_3 = "BackgroundImage";

		public const string string_4 = "Visibility";

		public const string string_5 = "BackgroundPosition";

		public const string string_6 = "BackgroundPositionX";

		public const string string_7 = "BackgroundPositionY";

		public const string string_8 = "BackgroundRepeat";

		public const string string_9 = "Color";

		public const string string_10 = "FontName";

		public const string string_11 = "FontSize";

		public const string string_12 = "EmphasisMark";

		public const string string_13 = "Bold";

		public const string string_14 = "Italic";

		public const string string_15 = "Underline";

		public const string string_16 = "UnderlineStyle";

		public const string string_17 = "UnderlineColor";

		public const string string_18 = "Strikeout";

		public const string string_19 = "Superscript";

		public const string string_20 = "Subscript";

		public const string string_21 = "FixedSpacing";

		public const string string_22 = "Spacing";

		public const string string_23 = "SpacingAfterParagraph";

		public const string string_24 = "SpacingBeforeParagraph";

		public const string string_25 = "LayoutGridHeight";

		public const string string_26 = "LineSpacingStyle";

		public const string string_27 = "LetterSpacing";

		public const string string_28 = "LineSpacing";

		public const int int_0 = 240;

		public const string string_29 = "Align";

		public const string string_30 = "VerticalAlign";

		public const string string_31 = "FirstLineIndent";

		public const string string_32 = "LeftIndent";

		public const string string_33 = "VertialText";

		public const string string_34 = "RightToLeft";

		public const string string_35 = "Multiline";

		public const string string_36 = "LayoutAlign";

		public const string string_37 = "RoundRadio";

		public const string string_38 = "Rotate";

		public const string string_39 = "CharacterCircle";

		public const string string_40 = "BorderLeftColor";

		public const string string_41 = "BorderTopColor";

		public const string string_42 = "BorderRightColor";

		public const string string_43 = "BorderBottomColor";

		public const string string_44 = "BorderStyle";

		public const string string_45 = "BorderWidth";

		public const string string_46 = "BorderLeft";

		public const string string_47 = "BorderBottom";

		public const string string_48 = "BorderTop";

		public const string string_49 = "BorderRight";

		public const string string_50 = "BorderSpacing";

		public const string string_51 = "MarginLeft";

		public const string string_52 = "MarginTop";

		public const string string_53 = "MarginRight";

		public const string string_54 = "MarginBottom";

		public const string string_55 = "PaddingLeft";

		public const string string_56 = "PaddingTop";

		public const string string_57 = "PaddingRight";

		public const string string_58 = "PaddingBottom";

		public const string string_59 = "Zoom";

		public const string string_60 = "Left";

		public const string string_61 = "Top";

		public const string string_62 = "Width";

		public const string string_63 = "Height";

		public const string string_64 = "Visible";

		public const string string_65 = "PageBreakAfter";

		public const string string_66 = "PageBreakBefore";

		public const string string_67 = "ParagraphMultiLevel";

		public const string string_68 = "ParagraphOutlineLevel";

		public const string string_69 = "VisibleInDirectory";

		public const string string_70 = "ParagraphListStyle";

		[NonSerialized]
		private ContentStyle contentStyle_0 = null;

		private int int_1 = -1;

		private static GClass371 gclass371_0 = GClass371.smethod_1("BackgroundColor", typeof(Color), typeof(ContentStyle), Color.Transparent);

		private static GClass371 gclass371_1 = GClass371.smethod_1("BackgroundColor2", typeof(Color), typeof(ContentStyle), Color.Black);

		private static GClass371 gclass371_2 = GClass371.smethod_1("BackgroundStyle", typeof(XBrushStyleConst), typeof(ContentStyle), XBrushStyleConst.Solid);

		private static GClass371 gclass371_3 = GClass371.smethod_0("BackgroundImage", typeof(XImageValue), typeof(ContentStyle));

		private static GClass371 gclass371_4 = GClass371.smethod_1("Visibility", typeof(RenderVisibility), typeof(ContentStyle), RenderVisibility.All);

		private static GClass371 gclass371_5 = GClass371.smethod_1("BackgroundPosition", typeof(ContentAlignment), typeof(ContentStyle), ContentAlignment.TopLeft);

		private static GClass371 gclass371_6 = GClass371.smethod_1("BackgroundPositionX", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_7 = GClass371.smethod_1("BackgroundPositionY", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_8 = GClass371.smethod_1("BackgroundRepeat", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_9 = GClass371.smethod_1("Color", typeof(Color), typeof(ContentStyle), Color.Black);

		public static string string_71 = Control.DefaultFont.Name;

		public static float float_0 = Control.DefaultFont.Size;

		private static GClass371 gclass371_10 = GClass371.smethod_1("FontName", typeof(string), typeof(ContentStyle), null);

		private static GClass371 gclass371_11 = GClass371.smethod_1("FontSize", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_12 = GClass371.smethod_1("EmphasisMark", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_13 = GClass371.smethod_1("Bold", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_14 = GClass371.smethod_1("Italic", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_15 = GClass371.smethod_1("Underline", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_16 = GClass371.smethod_1("UnderlineStyle", typeof(TextUnderlineStyle), typeof(ContentStyle), TextUnderlineStyle.Single);

		private static GClass371 gclass371_17 = GClass371.smethod_1("UnderlineColor", typeof(string), typeof(ContentStyle), null);

		private static GClass371 gclass371_18 = GClass371.smethod_1("Strikeout", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_19 = GClass371.smethod_1("Superscript", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_20 = GClass371.smethod_1("Subscript", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_21 = GClass371.smethod_1("FixedSpacing", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_22 = GClass371.smethod_1("Spacing", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_23 = GClass371.smethod_1("SpacingAfterParagraph", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_24 = GClass371.smethod_1("SpacingBeforeParagraph", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_25 = GClass371.smethod_1("LayoutGridHeight", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_26 = GClass371.smethod_1("LineSpacingStyle", typeof(LineSpacingStyle), typeof(ContentStyle), LineSpacingStyle.SpaceSingle);

		private static GClass371 gclass371_27 = GClass371.smethod_1("LetterSpacing", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_28 = GClass371.smethod_1("LineSpacing", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_29 = GClass371.smethod_1("RTFLineSpacing", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_30 = GClass371.smethod_1("Align", typeof(DocumentContentAlignment), typeof(ContentStyle), DocumentContentAlignment.Left);

		private static GClass371 gclass371_31 = GClass371.smethod_1("VerticalAlign", typeof(VerticalAlignStyle), typeof(ContentStyle), VerticalAlignStyle.Top);

		private static GClass371 gclass371_32 = GClass371.smethod_1("FirstLineIndent", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_33 = GClass371.smethod_1("LeftIndent", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_34 = GClass371.smethod_1("VertialText", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_35 = GClass371.smethod_1("RightToLeft", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_36 = GClass371.smethod_1("Multiline", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_37 = GClass371.smethod_1("LayoutAlign", typeof(ContentLayoutAlign), typeof(ContentStyle), ContentLayoutAlign.EmbedInText);

		private static GClass371 gclass371_38 = GClass371.smethod_1("RoundRadio", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_39 = GClass371.smethod_1("Rotate", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_40 = GClass371.smethod_1("CharacterCircle", typeof(CharacterCircleStyles), typeof(ContentStyle), CharacterCircleStyles.None);

		private static GClass371 gclass371_41 = GClass371.smethod_1("BorderLeftColor", typeof(Color), typeof(ContentStyle), Color.Black);

		private static GClass371 gclass371_42 = GClass371.smethod_1("BorderTopColor", typeof(Color), typeof(ContentStyle), Color.Black);

		private static GClass371 gclass371_43 = GClass371.smethod_1("BorderRightColor", typeof(Color), typeof(ContentStyle), Color.Black);

		private static GClass371 gclass371_44 = GClass371.smethod_1("BorderBottomColor", typeof(Color), typeof(ContentStyle), Color.Black);

		private static GClass371 gclass371_45 = GClass371.smethod_1("BorderStyle", typeof(DashStyle), typeof(ContentStyle), DashStyle.Solid);

		private static GClass371 gclass371_46 = GClass371.smethod_1("BorderWidth", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_47 = GClass371.smethod_1("BorderLeft", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_48 = GClass371.smethod_1("BorderBottom", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_49 = GClass371.smethod_1("BorderTop", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_50 = GClass371.smethod_1("BorderRight", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_51 = GClass371.smethod_1("BorderSpacing", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_52 = GClass371.smethod_1("MarginLeft", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_53 = GClass371.smethod_1("MarginTop", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_54 = GClass371.smethod_1("MarginRight", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_55 = GClass371.smethod_1("MarginBottom", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_56 = GClass371.smethod_1("PaddingLeft", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_57 = GClass371.smethod_1("PaddingTop", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_58 = GClass371.smethod_1("PaddingRight", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_59 = GClass371.smethod_1("PaddingBottom", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_60 = GClass371.smethod_1("Zoom", typeof(float), typeof(ContentStyle), 1f);

		private static GClass371 gclass371_61 = GClass371.smethod_1("Left", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_62 = GClass371.smethod_1("Top", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_63 = GClass371.smethod_1("Width", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_64 = GClass371.smethod_1("Height", typeof(float), typeof(ContentStyle), 0f);

		private static GClass371 gclass371_65 = GClass371.smethod_1("Visible", typeof(bool), typeof(ContentStyle), true);

		private static GClass371 gclass371_66 = GClass371.smethod_1("PageBreakAfter", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_67 = GClass371.smethod_1("PageBreakBefore", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_68 = GClass371.smethod_1("ParagraphMultiLevel", typeof(bool), typeof(ContentStyle), false);

		private static GClass371 gclass371_69 = GClass371.smethod_1("ParagraphOutlineLevel", typeof(int), typeof(ContentStyle), -1);

		private static GClass371 gclass371_70 = GClass371.smethod_1("VisibleInDirectory", typeof(bool), typeof(ContentStyle), true);

		private static GClass371 gclass371_71 = GClass371.smethod_1("ParagraphListStyle", typeof(ParagraphListStyle), typeof(ContentStyle), ParagraphListStyle.None);

		[NonSerialized]
		private GInterface22 ginterface22_0 = null;

		private string string_72 = null;

		/// <summary>
		///       对象数据是否为空
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public virtual bool IsEmpty => base.InnerValues == null || base.InnerValues.Count == 0;

		/// <summary>
		///       运行时使用的样式列表
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ContentStyle RuntimeStyle
		{
			get
			{
				return contentStyle_0;
			}
			set
			{
				contentStyle_0 = value;
			}
		}

		/// <summary>
		///       内部编号，本属性供内部使用，没有意义，也不做任何参考
		///       </summary>
		[XmlAttribute]
		[DefaultValue(-1)]
		[Browsable(false)]
		public int Index
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		public Color BackgroundColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_0);
			}
			set
			{
				vmethod_1(gclass371_0, value);
			}
		}

		/// <summary>
		///       字符串格式的背景色
		///       </summary>
		[DefaultValue(null)]
		[XmlElement("BackgroundColor")]
		[Browsable(false)]
		public string BackgroundColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackgroundColor, Color.Transparent);
			}
			set
			{
				BackgroundColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		public Color BackgroundColor2
		{
			get
			{
				return (Color)vmethod_0(gclass371_1);
			}
			set
			{
				vmethod_1(gclass371_1, value);
			}
		}

		/// <summary>
		///       字符串格式的背景色
		///       </summary>
		[XmlElement("BackgroundColor2")]
		[DCInternal]
		[DefaultValue(null)]
		[Browsable(false)]
		public string BackgroundColor2String
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackgroundColor2, Color.Black);
			}
			set
			{
				BackgroundColor2 = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       背景样式
		///       </summary>
		[DefaultValue(XBrushStyleConst.Solid)]
		public XBrushStyleConst BackgroundStyle
		{
			get
			{
				return (XBrushStyleConst)vmethod_0(gclass371_2);
			}
			set
			{
				vmethod_1(gclass371_2, value);
			}
		}

		/// <summary>
		///       背景图片
		///       </summary>
		[DefaultValue(null)]
		public XImageValue BackgroundImage
		{
			get
			{
				return (XImageValue)vmethod_0(gclass371_3);
			}
			set
			{
				vmethod_1(gclass371_3, value);
			}
		}

		/// <summary>
		///       可见性设置
		///       </summary>
		[DefaultValue(RenderVisibility.All)]
		public RenderVisibility Visibility
		{
			get
			{
				return (RenderVisibility)vmethod_0(gclass371_4);
			}
			set
			{
				vmethod_1(gclass371_4, value);
			}
		}

		/// <summary>
		///       背景对齐样式
		///       </summary>
		[DefaultValue(ContentAlignment.TopLeft)]
		public ContentAlignment BackgroundPosition
		{
			get
			{
				return (ContentAlignment)vmethod_0(gclass371_5);
			}
			set
			{
				vmethod_1(gclass371_5, value);
			}
		}

		/// <summary>
		///       背景X轴方向偏移量
		///       </summary>
		[DefaultValue(0f)]
		public float BackgroundPositionX
		{
			get
			{
				return (float)vmethod_0(gclass371_6);
			}
			set
			{
				vmethod_1(gclass371_6, value);
			}
		}

		/// <summary>
		///       背景Y轴方向偏移量
		///       </summary>
		[DefaultValue(0f)]
		public float BackgroundPositionY
		{
			get
			{
				return (float)vmethod_0(gclass371_7);
			}
			set
			{
				vmethod_1(gclass371_7, value);
			}
		}

		/// <summary>
		///       是否重复绘制背景
		///       </summary>
		[DefaultValue(false)]
		public bool BackgroundRepeat
		{
			get
			{
				return (bool)vmethod_0(gclass371_8);
			}
			set
			{
				vmethod_1(gclass371_8, value);
			}
		}

		/// <summary>
		///       颜色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		public Color Color
		{
			get
			{
				return (Color)vmethod_0(gclass371_9);
			}
			set
			{
				vmethod_1(gclass371_9, value);
			}
		}

		/// <summary>
		///       字符串格式的对象颜色
		///       </summary>
		[Browsable(false)]
		[XmlElement("Color")]
		[DCInternal]
		[DefaultValue(null)]
		public string ColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(Color, Color.Black);
			}
			set
			{
				Color = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       是否存在可见的背景
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool HasVisibleBackground
		{
			get
			{
				if (BackgroundStyle == XBrushStyleConst.Disabled)
				{
					return false;
				}
				if (BackgroundImage != null && BackgroundImage.Value != null)
				{
					return true;
				}
				if (BackgroundColor.A == 0)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       字体对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[XmlIgnore]
		public XFontValue Font
		{
			get
			{
				XFontValue xFontValue = new XFontValue();
				string fontName = FontName;
				if (!string.IsNullOrEmpty(fontName))
				{
					xFontValue.Name = fontName;
				}
				float fontSize = FontSize;
				if (fontSize > 0f)
				{
					xFontValue.Size = fontSize;
				}
				xFontValue.Bold = Bold;
				xFontValue.Italic = Italic;
				xFontValue.Underline = Underline;
				xFontValue.Strikeout = Strikeout;
				return xFontValue;
			}
			set
			{
				if (value != null)
				{
					FontName = value.Name;
					FontSize = value.Size;
					Bold = value.Bold;
					Italic = value.Italic;
					Underline = value.Underline;
					Strikeout = value.Strikeout;
				}
			}
		}

		/// <summary>
		///       字体名称
		///       </summary>
		[DefaultValue(null)]
		public string FontName
		{
			get
			{
				return (string)vmethod_0(gclass371_10);
			}
			set
			{
				vmethod_1(gclass371_10, value);
			}
		}

		/// <summary>
		///       字体大小
		///       </summary>
		[DefaultValue(0f)]
		public float FontSize
		{
			get
			{
				return (float)vmethod_0(gclass371_11);
			}
			set
			{
				vmethod_1(gclass371_11, value);
			}
		}

		/// <summary>
		///       着重号
		///       </summary>
		[DefaultValue(false)]
		public bool EmphasisMark
		{
			get
			{
				return (bool)vmethod_0(gclass371_12);
			}
			set
			{
				vmethod_1(gclass371_12, value);
			}
		}

		/// <summary>
		///       粗体
		///       </summary>
		[DefaultValue(false)]
		public bool Bold
		{
			get
			{
				return (bool)vmethod_0(gclass371_13);
			}
			set
			{
				vmethod_1(gclass371_13, value);
			}
		}

		/// <summary>
		///       斜体
		///       </summary>
		[DefaultValue(false)]
		public bool Italic
		{
			get
			{
				return (bool)vmethod_0(gclass371_14);
			}
			set
			{
				vmethod_1(gclass371_14, value);
			}
		}

		/// <summary>
		///       字体样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public FontStyle FontStyle
		{
			get
			{
				FontStyle fontStyle = FontStyle.Regular;
				if (Bold)
				{
					fontStyle |= FontStyle.Bold;
				}
				if (Italic)
				{
					fontStyle |= FontStyle.Italic;
				}
				if (Underline)
				{
					fontStyle |= FontStyle.Underline;
				}
				if (Strikeout)
				{
					fontStyle |= FontStyle.Strikeout;
				}
				return fontStyle;
			}
			set
			{
				Bold = ((value & FontStyle.Bold) == FontStyle.Bold);
				Italic = ((value & FontStyle.Italic) == FontStyle.Italic);
				Underline = ((value & FontStyle.Underline) == FontStyle.Underline);
				Strikeout = ((value & FontStyle.Strikeout) == FontStyle.Strikeout);
			}
		}

		/// <summary>
		///       下划线
		///       </summary>
		[DefaultValue(false)]
		public bool Underline
		{
			get
			{
				return (bool)vmethod_0(gclass371_15);
			}
			set
			{
				vmethod_1(gclass371_15, value);
			}
		}

		/// <summary>
		///       下划线样式
		///       </summary>
		[DefaultValue(TextUnderlineStyle.Single)]
		public TextUnderlineStyle UnderlineStyle
		{
			get
			{
				return (TextUnderlineStyle)vmethod_0(gclass371_16);
			}
			set
			{
				vmethod_1(gclass371_16, value);
			}
		}

		/// <summary>
		///       下划线样式
		///       </summary>
		[DefaultValue(null)]
		public string UnderlineColor
		{
			get
			{
				return (string)vmethod_0(gclass371_17);
			}
			set
			{
				vmethod_1(gclass371_17, value);
			}
		}

		/// <summary>
		///       删除线
		///       </summary>
		[DefaultValue(false)]
		public bool Strikeout
		{
			get
			{
				return (bool)vmethod_0(gclass371_18);
			}
			set
			{
				vmethod_1(gclass371_18, value);
			}
		}

		/// <summary>
		///       上标样式
		///       </summary>
		[DefaultValue(false)]
		public bool Superscript
		{
			get
			{
				return (bool)vmethod_0(gclass371_19);
			}
			set
			{
				vmethod_1(gclass371_19, value);
			}
		}

		/// <summary>
		///       下标样式
		///       </summary>
		[DefaultValue(false)]
		public bool Subscript
		{
			get
			{
				return (bool)vmethod_0(gclass371_20);
			}
			set
			{
				vmethod_1(gclass371_20, value);
			}
		}

		/// <summary>
		///       固定字符间距
		///       </summary>
		[DefaultValue(false)]
		public bool FixedSpacing
		{
			get
			{
				return (bool)vmethod_0(gclass371_21);
			}
			set
			{
				vmethod_1(gclass371_21, value);
			}
		}

		/// <summary>
		///       字符间距
		///       </summary>
		[DefaultValue(0f)]
		public float Spacing
		{
			get
			{
				return (float)vmethod_0(gclass371_22);
			}
			set
			{
				vmethod_1(gclass371_22, value);
			}
		}

		/// <summary>
		///       段落后间距
		///       </summary>
		[DefaultValue(0f)]
		public float SpacingAfterParagraph
		{
			get
			{
				return (float)vmethod_0(gclass371_23);
			}
			set
			{
				vmethod_1(gclass371_23, Math.Max(0f, value));
			}
		}

		/// <summary>
		///       段落前间距
		///       </summary>
		[DefaultValue(0f)]
		public float SpacingBeforeParagraph
		{
			get
			{
				return (float)vmethod_0(gclass371_24);
			}
			set
			{
				vmethod_1(gclass371_24, Math.Max(0f, value));
			}
		}

		/// <summary>
		///       内容排版布局网格高度
		///       </summary>
		/// <remarks>
		///       若该属性值大于0，则区域内容进行排版时所有的文档行固定为该属性值，而忽略掉
		///       行间距和段落间距的设置。
		///       </remarks>
		[DefaultValue(0f)]
		public float LayoutGridHeight
		{
			get
			{
				return (float)vmethod_0(gclass371_25);
			}
			set
			{
				vmethod_1(gclass371_25, value);
			}
		}

		/// <summary>
		///       行间距样式
		///       </summary>
		[DefaultValue(LineSpacingStyle.SpaceSingle)]
		public LineSpacingStyle LineSpacingStyle
		{
			get
			{
				return (LineSpacingStyle)vmethod_0(gclass371_26);
			}
			set
			{
				vmethod_1(gclass371_26, value);
			}
		}

		/// <summary>
		///       字符间距
		///       </summary>
		[DefaultValue(0f)]
		public float LetterSpacing
		{
			get
			{
				return (float)vmethod_0(gclass371_27);
			}
			set
			{
				vmethod_1(gclass371_27, Math.Max(0f, value));
			}
		}

		/// <summary>
		///       行间距
		///       </summary>
		[DefaultValue(0f)]
		public float LineSpacing
		{
			get
			{
				return (float)vmethod_0(gclass371_28);
			}
			set
			{
				vmethod_1(gclass371_28, Math.Max(0f, value));
			}
		}

		/// <summary>
		///       从RTF文档中导入的绝对行间距值
		///       </summary>
		[DefaultValue(0f)]
		[DCInternal]
		public float RTFLineSpacing
		{
			get
			{
				return (float)vmethod_0(gclass371_29);
			}
			set
			{
				vmethod_1(gclass371_29, value);
			}
		}

		/// <summary>
		///       文本水平对齐方式
		///       </summary>
		[DefaultValue(DocumentContentAlignment.Left)]
		public DocumentContentAlignment Align
		{
			get
			{
				return (DocumentContentAlignment)vmethod_0(gclass371_30);
			}
			set
			{
				vmethod_1(gclass371_30, value);
			}
		}

		/// <summary>
		///       文本垂直对齐方式
		///       </summary>
		[DefaultValue(VerticalAlignStyle.Top)]
		public VerticalAlignStyle VerticalAlign
		{
			get
			{
				return (VerticalAlignStyle)vmethod_0(gclass371_31);
			}
			set
			{
				vmethod_1(gclass371_31, value);
			}
		}

		/// <summary>
		///       首行缩进量
		///       </summary>
		[DefaultValue(0f)]
		public float FirstLineIndent
		{
			get
			{
				float num = (float)vmethod_0(gclass371_32);
				if (!(num > 0f))
				{
				}
				return num;
			}
			set
			{
				vmethod_1(gclass371_32, value);
			}
		}

		/// <summary>
		///       段落左缩进量
		///       </summary>
		[DefaultValue(0f)]
		public float LeftIndent
		{
			get
			{
				return (float)vmethod_0(gclass371_33);
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				vmethod_1(gclass371_33, value);
			}
		}

		/// <summary>
		///       是否垂直显示文本
		///       </summary>
		[DefaultValue(false)]
		public bool VertialText
		{
			get
			{
				return (bool)vmethod_0(gclass371_34);
			}
			set
			{
				vmethod_1(gclass371_34, value);
			}
		}

		/// <summary>
		///       是否从右到左显示文本
		///       </summary>
		[DefaultValue(false)]
		public bool RightToLeft
		{
			get
			{
				return (bool)vmethod_0(gclass371_35);
			}
			set
			{
				vmethod_1(gclass371_35, value);
			}
		}

		/// <summary>
		///       允许显示多行文本
		///       </summary>
		[DefaultValue(false)]
		public bool Multiline
		{
			get
			{
				return (bool)vmethod_0(gclass371_36);
			}
			set
			{
				vmethod_1(gclass371_36, value);
			}
		}

		/// <summary>
		///       内容布局对齐方式
		///       </summary>
		[DefaultValue(ContentLayoutAlign.EmbedInText)]
		public ContentLayoutAlign LayoutAlign
		{
			get
			{
				return (ContentLayoutAlign)vmethod_0(gclass371_37);
			}
			set
			{
				vmethod_1(gclass371_37, value);
			}
		}

		/// <summary>
		///       圆角半径
		///       </summary>
		[DefaultValue(0f)]
		public float RoundRadio
		{
			get
			{
				return (float)vmethod_0(gclass371_38);
			}
			set
			{
				vmethod_1(gclass371_38, value);
			}
		}

		/// <summary>
		///       图形逆时针旋转角度，以度为单位
		///       </summary>
		[DefaultValue(0f)]
		public float Rotate
		{
			get
			{
				return (float)vmethod_0(gclass371_39);
			}
			set
			{
				vmethod_1(gclass371_39, value);
			}
		}

		/// <summary>
		///       字符圈样式
		///       </summary>
		[DefaultValue(CharacterCircleStyles.None)]
		public CharacterCircleStyles CharacterCircle
		{
			get
			{
				return (CharacterCircleStyles)vmethod_0(gclass371_40);
			}
			set
			{
				vmethod_1(gclass371_40, value);
			}
		}

		/// <summary>
		///       左边框颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		public Color BorderLeftColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_41);
			}
			set
			{
				vmethod_1(gclass371_41, value);
			}
		}

		/// <summary>
		///       字符串格式的左边框颜色
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement("BorderLeftColor")]
		[DCInternal]
		public string BorderLeftColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BorderLeftColor, Color.Black);
			}
			set
			{
				BorderLeftColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		public Color BorderColor
		{
			get
			{
				return BorderLeftColor;
			}
			set
			{
				BorderLeftColor = value;
				BorderTopColor = value;
				BorderRightColor = value;
				BorderBottomColor = value;
			}
		}

		/// <summary>
		///       上边框颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		public Color BorderTopColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_42);
			}
			set
			{
				vmethod_1(gclass371_42, value);
			}
		}

		/// <summary>
		///       字符串格式的上边框颜色
		///       </summary>
		[DefaultValue(null)]
		[XmlElement("BorderTopColor")]
		[Browsable(false)]
		[DCInternal]
		public string BorderTopColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BorderTopColor, Color.Black);
			}
			set
			{
				BorderTopColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       右边框颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		public Color BorderRightColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_43);
			}
			set
			{
				vmethod_1(gclass371_43, value);
			}
		}

		/// <summary>
		///       字符串格式的右边框颜色
		///       </summary>
		[XmlElement("BorderRightColor")]
		[DefaultValue(null)]
		[Browsable(false)]
		[DCInternal]
		public string BorderRightColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BorderRightColor, Color.Black);
			}
			set
			{
				BorderRightColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       下边框颜色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		public Color BorderBottomColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_44);
			}
			set
			{
				vmethod_1(gclass371_44, value);
			}
		}

		/// <summary>
		///       字符串格式的下边框颜色
		///       </summary>
		[XmlElement("BorderBottomColor")]
		[DefaultValue(null)]
		[Browsable(false)]
		[DCInternal]
		public string BorderBottomColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BorderBottomColor, Color.Black);
			}
			set
			{
				BorderBottomColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       边框线型
		///       </summary>
		[DefaultValue(DashStyle.Solid)]
		public DashStyle BorderStyle
		{
			get
			{
				return (DashStyle)vmethod_0(gclass371_45);
			}
			set
			{
				vmethod_1(gclass371_45, value);
			}
		}

		/// <summary>
		///       边框线型值,仅为COM公开使用。
		///       </summary>
		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(0)]
		[Browsable(false)]
		[DCInternal]
		[Obsolete("请使用BorderStyle属性值，本属性仅为COM公开使用。")]
		public int BorderStyleValue
		{
			get
			{
				return (int)BorderStyle;
			}
			set
			{
				BorderStyle = (DashStyle)value;
			}
		}

		/// <summary>
		///       边框线粗细
		///       </summary>
		[DefaultValue(0f)]
		public float BorderWidth
		{
			get
			{
				return (float)vmethod_0(gclass371_46);
			}
			set
			{
				vmethod_1(gclass371_46, value);
			}
		}

		/// <summary>
		///       是否显示左边框线
		///       </summary>
		[DefaultValue(false)]
		public bool BorderLeft
		{
			get
			{
				return (bool)vmethod_0(gclass371_47);
			}
			set
			{
				vmethod_1(gclass371_47, value);
			}
		}

		/// <summary>
		///       是否显示下边框线
		///       </summary>
		[DefaultValue(false)]
		public bool BorderBottom
		{
			get
			{
				return (bool)vmethod_0(gclass371_48);
			}
			set
			{
				vmethod_1(gclass371_48, value);
			}
		}

		/// <summary>
		///       是否显示上边框线
		///       </summary>
		[DefaultValue(false)]
		public bool BorderTop
		{
			get
			{
				return (bool)vmethod_0(gclass371_49);
			}
			set
			{
				vmethod_1(gclass371_49, value);
			}
		}

		/// <summary>
		///       是否显示右边框线
		///       </summary>
		[DefaultValue(false)]
		public bool BorderRight
		{
			get
			{
				return (bool)vmethod_0(gclass371_50);
			}
			set
			{
				vmethod_1(gclass371_50, value);
			}
		}

		/// <summary>
		///       是否存在完整的边框线
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool HasFullBorder => BorderLeft && BorderTop && BorderRight && BorderBottom;

		/// <summary>
		///       边框线间距
		///       </summary>
		[DefaultValue(0f)]
		public float BorderSpacing
		{
			get
			{
				return (float)vmethod_0(gclass371_51);
			}
			set
			{
				vmethod_1(gclass371_51, value);
			}
		}

		/// <summary>
		///       判断样式是否存在可见的边框效果
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool HasVisibleBorder
		{
			get
			{
				if (!BorderLeft && !BorderTop && !BorderRight && !BorderBottom)
				{
					return false;
				}
				if (BorderTopColor.A == 0 && BorderLeftColor.A == 0 && BorderRightColor.A == 0 && BorderBottomColor.A == 0)
				{
					return false;
				}
				if (BorderWidth == 0f)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       左外边距
		///       </summary>
		[DCInternal]
		[DefaultValue(0f)]
		public float MarginLeft
		{
			get
			{
				return (float)vmethod_0(gclass371_52);
			}
			set
			{
				vmethod_1(gclass371_52, value);
			}
		}

		/// <summary>
		///       上外边距
		///       </summary>
		[DefaultValue(0f)]
		[DCInternal]
		public float MarginTop
		{
			get
			{
				return (float)vmethod_0(gclass371_53);
			}
			set
			{
				vmethod_1(gclass371_53, value);
			}
		}

		/// <summary>
		///       右外边距
		///       </summary>
		[DefaultValue(0f)]
		[DCInternal]
		public float MarginRight
		{
			get
			{
				return (float)vmethod_0(gclass371_54);
			}
			set
			{
				vmethod_1(gclass371_54, value);
			}
		}

		/// <summary>
		///       下外边距
		///       </summary>
		[DefaultValue(0f)]
		[DCInternal]
		public float MarginBottom
		{
			get
			{
				return (float)vmethod_0(gclass371_55);
			}
			set
			{
				vmethod_1(gclass371_55, value);
			}
		}

		/// <summary>
		///       左内边距
		///       </summary>
		[DefaultValue(0f)]
		public float PaddingLeft
		{
			get
			{
				return (float)vmethod_0(gclass371_56);
			}
			set
			{
				vmethod_1(gclass371_56, value);
			}
		}

		/// <summary>
		///       上内边距
		///       </summary>
		[DefaultValue(0f)]
		public float PaddingTop
		{
			get
			{
				return (float)vmethod_0(gclass371_57);
			}
			set
			{
				vmethod_1(gclass371_57, value);
			}
		}

		/// <summary>
		///       右内边距
		///       </summary>
		[DefaultValue(0f)]
		public float PaddingRight
		{
			get
			{
				return (float)vmethod_0(gclass371_58);
			}
			set
			{
				vmethod_1(gclass371_58, value);
			}
		}

		/// <summary>
		///       下内边距
		///       </summary>
		[DefaultValue(0f)]
		public float PaddingBottom
		{
			get
			{
				return (float)vmethod_0(gclass371_59);
			}
			set
			{
				vmethod_1(gclass371_59, value);
			}
		}

		/// <summary>
		///       缩放比例
		///       </summary>
		[DCInternal]
		[DefaultValue(1f)]
		public float Zoom
		{
			get
			{
				return (float)vmethod_0(gclass371_60);
			}
			set
			{
				vmethod_1(gclass371_60, value);
			}
		}

		/// <summary>
		///       左端位置
		///       </summary>
		[DCInternal]
		[DefaultValue(0f)]
		public float Left
		{
			get
			{
				return (float)vmethod_0(gclass371_61);
			}
			set
			{
				vmethod_1(gclass371_61, value);
			}
		}

		/// <summary>
		///       顶端位置
		///       </summary>
		[DCInternal]
		[DefaultValue(0f)]
		public float Top
		{
			get
			{
				return (float)vmethod_0(gclass371_62);
			}
			set
			{
				vmethod_1(gclass371_62, value);
			}
		}

		/// <summary>
		///       宽度
		///       </summary>
		[DefaultValue(0f)]
		[DCInternal]
		public float Width
		{
			get
			{
				return (float)vmethod_0(gclass371_63);
			}
			set
			{
				vmethod_1(gclass371_63, value);
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[DefaultValue(0f)]
		[DCInternal]
		public float Height
		{
			get
			{
				return (float)vmethod_0(gclass371_64);
			}
			set
			{
				vmethod_1(gclass371_64, value);
			}
		}

		/// <summary>
		///       是否可见
		///       </summary>
		[DCInternal]
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return (bool)vmethod_0(gclass371_65);
			}
			set
			{
				vmethod_1(gclass371_65, value);
			}
		}

		/// <summary>
		///       在后面分页
		///       </summary>
		[DefaultValue(false)]
		public bool PageBreakAfter
		{
			get
			{
				return (bool)vmethod_0(gclass371_66);
			}
			set
			{
				vmethod_1(gclass371_66, value);
			}
		}

		/// <summary>
		///       之前分页
		///       </summary>
		[DefaultValue(false)]
		public bool PageBreakBefore
		{
			get
			{
				return (bool)vmethod_0(gclass371_67);
			}
			set
			{
				vmethod_1(gclass371_67, value);
			}
		}

		/// <summary>
		///       多层次段落列表
		///       </summary>
		[DefaultValue(false)]
		public bool ParagraphMultiLevel
		{
			get
			{
				return (bool)vmethod_0(gclass371_68);
			}
			set
			{
				vmethod_1(gclass371_68, value);
			}
		}

		/// <summary>
		///       段落大纲层次
		///       </summary>
		[DefaultValue(-1)]
		public int ParagraphOutlineLevel
		{
			get
			{
				return (int)vmethod_0(gclass371_69);
			}
			set
			{
				vmethod_1(gclass371_69, value);
			}
		}

		/// <summary>
		///       段落是否允许显示在目录中
		///       </summary>
		[DefaultValue(true)]
		public bool VisibleInDirectory
		{
			get
			{
				return (bool)vmethod_0(gclass371_70);
			}
			set
			{
				vmethod_1(gclass371_70, value);
			}
		}

		/// <summary>
		///       paragraph list style
		///       </summary>
		[DefaultValue(ParagraphListStyle.None)]
		public ParagraphListStyle ParagraphListStyle
		{
			get
			{
				return (ParagraphListStyle)vmethod_0(gclass371_71);
			}
			set
			{
				vmethod_1(gclass371_71, value);
			}
		}

		/// <summary>
		///       判断是否是圆点列表方式
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool IsBulletedList => GClass470.smethod_6(ParagraphListStyle);

		/// <summary>
		///       判断是否是数字列表方式
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool IsListNumberStyle => GClass470.smethod_7(ParagraphListStyle);

		[Browsable(false)]
		[DCInternal]
		public string BulletedString => GClass470.smethod_2(ParagraphListStyle);

		[DCInternal]
		GInterface22 PropertyLogger
		{
			get
			{
				return ginterface22_0;
			}
			set
			{
				ginterface22_0 = value;
			}
		}

		/// <summary>
		///       采用默认值的属性名称,该属性已经过期，仅向下保持兼容性
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[DCInternal]
		public string DefaultValuePropertyNames
		{
			get
			{
				return string_72;
			}
			set
			{
				string_72 = value;
			}
		}

		bool IContentStyle.ValueLocked
		{
			get
			{
				return base.ValueLocked;
			}
			set
			{
				base.ValueLocked = value;
			}
		}

		[DCInternal]
		public int method_3(string string_73)
		{
			return GClass340.smethod_0(this, string_73);
		}

		[DCInternal]
		public bool method_4(ContentStyle contentStyle_1)
		{
			return XDependencyObject.smethod_9(this, contentStyle_1);
		}

		[DCInternal]
		public int method_5(ContentStyle contentStyle_1)
		{
			int num = 5;
			if (contentStyle_1 == null)
			{
				throw new ArgumentNullException("defaultStyle");
			}
			bool flag = false;
			foreach (GClass371 key in contentStyle_1.InnerValues.Keys)
			{
				if (base.InnerValues.ContainsKey(key))
				{
					object obj = contentStyle_1.InnerValues[key];
					object obj2 = base.InnerValues[key];
					if (obj == obj2)
					{
						base.InnerValues.Remove(key);
						flag = true;
					}
				}
			}
			if (flag)
			{
				vmethod_2(null);
			}
			return base.InnerValues.Count;
		}

		[DCInternal]
		public Brush method_6()
		{
			return method_7(GraphicsUnit.Pixel);
		}

		[DCInternal]
		public Brush method_7(GraphicsUnit graphicsUnit_0)
		{
			return method_8(new RectangleF(0f, 0f, 100f, 100f), graphicsUnit_0);
		}

		[DCInternal]
		public Brush method_8(RectangleF rectangleF_0, GraphicsUnit graphicsUnit_0)
		{
			XBrushStyle xBrushStyle = new XBrushStyle();
			xBrushStyle.Style = BackgroundStyle;
			xBrushStyle.Color = BackgroundColor;
			xBrushStyle.Color2 = BackgroundColor2;
			xBrushStyle.Style = BackgroundStyle;
			xBrushStyle.Image = BackgroundImage;
			xBrushStyle.Repeat = BackgroundRepeat;
			xBrushStyle.OffsetX = BackgroundPositionX;
			xBrushStyle.OffsetY = BackgroundPositionY;
			return xBrushStyle.method_4(rectangleF_0, graphicsUnit_0);
		}

		[DCInternal]
		public void method_9(Brush brush_0)
		{
			if (brush_0 != null)
			{
				if (brush_0 is SolidBrush)
				{
					BackgroundColor = ((SolidBrush)brush_0).Color;
				}
				else if (brush_0 is TextureBrush)
				{
					TextureBrush textureBrush = (TextureBrush)brush_0;
					BackgroundImage = new XImageValue(textureBrush.Image);
					BackgroundRepeat = (textureBrush.WrapMode == WrapMode.Tile);
					BackgroundPositionX = textureBrush.Transform.OffsetX;
					BackgroundPositionY = textureBrush.Transform.OffsetY;
				}
				else if (brush_0 is LinearGradientBrush)
				{
					LinearGradientBrush linearGradientBrush = (LinearGradientBrush)brush_0;
					BackgroundColor = linearGradientBrush.LinearColors[0];
				}
				else if (brush_0 is HatchBrush)
				{
					HatchBrush hatchBrush = (HatchBrush)brush_0;
					BackgroundColor = hatchBrush.BackgroundColor;
				}
			}
		}

		[DCInternal]
		public float method_10(float float_1, float float_2, GraphicsUnit graphicsUnit_0)
		{
			LineSpacingStyle lineSpacingStyle = LineSpacingStyle;
			if (lineSpacingStyle == LineSpacingStyle.SpaceSpecify)
			{
				return LineSpacing;
			}
			if (lineSpacingStyle == LineSpacingStyle.SpaceSpecify)
			{
				return float_1 + float_2 * 0.1f;
			}
			float result = 0f;
			switch (lineSpacingStyle)
			{
			case LineSpacingStyle.SpaceSingle:
				result = float_1 + float_2 * 0.1f;
				break;
			case LineSpacingStyle.Space1pt5:
				result = float_1 + float_2 * 0.6f;
				break;
			case LineSpacingStyle.SpaceDouble:
				result = float_1 + float_2 * 1.1f;
				break;
			case LineSpacingStyle.SpaceExactly:
				result = Math.Max(float_1, float_2);
				break;
			case LineSpacingStyle.SpaceMultiple:
				result = float_1 + float_2 * (LineSpacing - 1f + 0.1f);
				break;
			}
			return result;
		}

		[DCInternal]
		public void method_11(StringFormat stringFormat_0)
		{
			if (stringFormat_0.LineAlignment == StringAlignment.Center)
			{
				Align = DocumentContentAlignment.Center;
			}
			else if (stringFormat_0.LineAlignment == StringAlignment.Far)
			{
				Align = DocumentContentAlignment.Right;
			}
			else if (stringFormat_0.LineAlignment == StringAlignment.Near)
			{
				Align = DocumentContentAlignment.Left;
			}
			if (stringFormat_0.Alignment == StringAlignment.Center)
			{
				VerticalAlign = VerticalAlignStyle.Middle;
			}
			else if (stringFormat_0.Alignment == StringAlignment.Near)
			{
				VerticalAlign = VerticalAlignStyle.Top;
			}
			else if (stringFormat_0.Alignment == StringAlignment.Far)
			{
				VerticalAlign = VerticalAlignStyle.Bottom;
			}
			if ((stringFormat_0.FormatFlags & StringFormatFlags.DirectionVertical) == StringFormatFlags.DirectionVertical)
			{
				VertialText = true;
			}
			else
			{
				VertialText = false;
			}
			if ((stringFormat_0.FormatFlags & StringFormatFlags.DirectionRightToLeft) == StringFormatFlags.DirectionRightToLeft)
			{
				RightToLeft = true;
			}
			else
			{
				RightToLeft = false;
			}
		}

		[DCInternal]
		public DrawStringFormatExt method_12()
		{
			DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
			switch (Align)
			{
			case DocumentContentAlignment.Left:
				drawStringFormatExt.Alignment = StringAlignment.Near;
				break;
			case DocumentContentAlignment.Center:
				drawStringFormatExt.Alignment = StringAlignment.Center;
				break;
			case DocumentContentAlignment.Right:
				drawStringFormatExt.Alignment = StringAlignment.Far;
				break;
			case DocumentContentAlignment.Justify:
				drawStringFormatExt.Alignment = StringAlignment.Center;
				break;
			}
			switch (VerticalAlign)
			{
			case VerticalAlignStyle.Top:
				drawStringFormatExt.LineAlignment = StringAlignment.Near;
				break;
			case VerticalAlignStyle.Middle:
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				break;
			case VerticalAlignStyle.Bottom:
				drawStringFormatExt.LineAlignment = StringAlignment.Far;
				break;
			}
			StringFormatFlags stringFormatFlags = drawStringFormatExt.FormatFlags;
			if (!Multiline)
			{
				stringFormatFlags |= StringFormatFlags.NoWrap;
			}
			if (VertialText)
			{
				stringFormatFlags |= StringFormatFlags.DirectionVertical;
			}
			if (RightToLeft)
			{
				stringFormatFlags |= StringFormatFlags.DirectionRightToLeft;
			}
			drawStringFormatExt.FormatFlags = stringFormatFlags;
			return drawStringFormatExt;
		}

		[DCInternal]
		public StringFormat method_13()
		{
			StringFormat stringFormat = new StringFormat();
			switch (Align)
			{
			case DocumentContentAlignment.Left:
				stringFormat.Alignment = StringAlignment.Near;
				break;
			case DocumentContentAlignment.Center:
				stringFormat.Alignment = StringAlignment.Center;
				break;
			case DocumentContentAlignment.Right:
				stringFormat.Alignment = StringAlignment.Far;
				break;
			case DocumentContentAlignment.Justify:
				stringFormat.Alignment = StringAlignment.Center;
				break;
			}
			switch (VerticalAlign)
			{
			case VerticalAlignStyle.Top:
				stringFormat.LineAlignment = StringAlignment.Near;
				break;
			case VerticalAlignStyle.Middle:
				stringFormat.LineAlignment = StringAlignment.Center;
				break;
			case VerticalAlignStyle.Bottom:
				stringFormat.LineAlignment = StringAlignment.Far;
				break;
			}
			StringFormatFlags stringFormatFlags = stringFormat.FormatFlags;
			if (!Multiline)
			{
				stringFormatFlags |= StringFormatFlags.NoWrap;
			}
			if (VertialText)
			{
				stringFormatFlags |= StringFormatFlags.DirectionVertical;
			}
			if (RightToLeft)
			{
				stringFormatFlags |= StringFormatFlags.DirectionRightToLeft;
			}
			stringFormat.FormatFlags = stringFormatFlags;
			return stringFormat;
		}

		[DCInternal]
		public Matrix method_14(Graphics graphics_0, Rectangle rectangle_0)
		{
			if (Rotate == 0f)
			{
				return null;
			}
			Matrix transform = graphics_0.Transform;
			Matrix matrix = transform.Clone();
			Point point = new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			matrix.RotateAt(Rotate, new PointF(point.X, point.Y));
			graphics_0.Transform = matrix;
			return transform;
		}

		[DCInternal]
		public Pen method_15()
		{
			Pen pen = new Pen(BorderTopColor, BorderWidth);
			pen.DashStyle = BorderStyle;
			return pen;
		}

		[DCInternal]
		public XPenStyle method_16()
		{
			XPenStyle xPenStyle = new XPenStyle(BorderTopColor, BorderWidth);
			xPenStyle.DashStyle = BorderStyle;
			return xPenStyle;
		}

		[DCInternal]
		public void method_17(Pen pen_0)
		{
			if (pen_0 != null)
			{
				BorderTopColor = pen_0.Color;
				BorderLeftColor = BorderTopColor;
				BorderRightColor = BorderTopColor;
				BorderBottomColor = BorderTopColor;
				BorderWidth = pen_0.Width;
				BorderStyle = pen_0.DashStyle;
			}
		}

		[DCInternal]
		public void method_18(DCGraphics dcgraphics_0, Pen pen_0, RectangleF rectangleF_0)
		{
			smethod_12(dcgraphics_0, pen_0, rectangleF_0, BorderLeft, BorderTop, BorderRight, BorderBottom);
		}

		[DCInternal]
		public void method_19(Graphics graphics_0, RectangleF rectangleF_0)
		{
			method_20(new DCGraphics(graphics_0), rectangleF_0);
		}

		[DCInternal]
		public void method_20(DCGraphics dcgraphics_0, RectangleF rectangleF_0)
		{
			float borderWidth = BorderWidth;
			DashStyle borderStyle = BorderStyle;
			smethod_13(dcgraphics_0, rectangleF_0, BorderLeft, BorderLeftColor, borderWidth, borderStyle, BorderTop, BorderTopColor, borderWidth, borderStyle, BorderRight, BorderRightColor, borderWidth, borderStyle, BorderBottom, BorderBottomColor, borderWidth, borderStyle);
		}

		[DCInternal]
		public static void smethod_12(DCGraphics dcgraphics_0, Pen pen_0, RectangleF rectangleF_0, bool bool_3, bool bool_4, bool bool_5, bool bool_6)
		{
			if (bool_3 && bool_4 && bool_5 && bool_6)
			{
				dcgraphics_0.DrawRectangle(pen_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
				return;
			}
			if (bool_3)
			{
				dcgraphics_0.DrawLine(pen_0, rectangleF_0.Left, rectangleF_0.Bottom, rectangleF_0.Left, rectangleF_0.Top);
			}
			if (bool_4)
			{
				dcgraphics_0.DrawLine(pen_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Top);
			}
			if (bool_5)
			{
				dcgraphics_0.DrawLine(pen_0, rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom);
			}
			if (bool_6)
			{
				dcgraphics_0.DrawLine(pen_0, rectangleF_0.Left, rectangleF_0.Bottom, rectangleF_0.Right, rectangleF_0.Bottom);
			}
		}

		[DCInternal]
		public static void smethod_13(DCGraphics dcgraphics_0, RectangleF rectangleF_0, bool bool_3, Color color_0, float float_1, DashStyle dashStyle_0, bool bool_4, Color color_1, float float_2, DashStyle dashStyle_1, bool bool_5, Color color_2, float float_3, DashStyle dashStyle_2, bool bool_6, Color color_3, float float_4, DashStyle dashStyle_3)
		{
			if (color_0 == color_1 && color_1 == color_2 && color_2 == color_3 && float_1 == float_2 && float_2 == float_3 && float_3 == float_4 && dashStyle_0 == dashStyle_1 && dashStyle_1 == dashStyle_2 && dashStyle_2 == dashStyle_3 && bool_3 && bool_4 && bool_5 && bool_6)
			{
				if (color_0.A != 0 && float_1 > 0f)
				{
					dcgraphics_0.DrawRectangle(color_0, float_1, dashStyle_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
				}
				return;
			}
			if (bool_3 && color_0.A != 0 && float_1 > 0f)
			{
				dcgraphics_0.DrawLine(color_0, float_1, dashStyle_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom);
			}
			if (bool_4 && color_1.A != 0 && float_2 > 0f)
			{
				dcgraphics_0.DrawLine(color_1, float_2, dashStyle_1, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Top);
			}
			if (bool_5 && color_2.A != 0 && float_3 > 0f)
			{
				dcgraphics_0.DrawLine(color_2, float_3, dashStyle_2, rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom);
			}
			if (bool_6 && color_3.A != 0 && float_4 > 0f)
			{
				dcgraphics_0.DrawLine(color_3, float_4, dashStyle_3, rectangleF_0.Left, rectangleF_0.Bottom, rectangleF_0.Right, rectangleF_0.Bottom);
			}
		}

		[DCInternal]
		public bool method_21(ContentStyle contentStyle_1)
		{
			if (contentStyle_1 == null)
			{
				return false;
			}
			if (contentStyle_1 == this)
			{
				return true;
			}
			if (contentStyle_1.BorderLeft == BorderLeft && contentStyle_1.BorderTop == BorderTop && contentStyle_1.BorderRight == BorderRight && contentStyle_1.BorderBottom == BorderBottom && contentStyle_1.BorderLeftColor == BorderLeftColor && contentStyle_1.BorderTopColor == BorderTopColor && contentStyle_1.BorderRightColor == BorderRightColor && contentStyle_1.BorderBottomColor == BorderBottomColor && contentStyle_1.BorderWidth == BorderWidth && contentStyle_1.BorderStyle == BorderStyle)
			{
				return true;
			}
			return false;
		}

		[DCInternal]
		public Rectangle method_22(int int_2, int int_3, int int_4, int int_5)
		{
			return new Rectangle(int_2 + (int)PaddingLeft, int_3 + (int)PaddingTop, (int)((float)int_4 - PaddingLeft - PaddingRight), (int)((float)int_5 - PaddingTop - PaddingBottom));
		}

		[DCInternal]
		public Rectangle method_23(Rectangle rectangle_0)
		{
			return new Rectangle(rectangle_0.Left + (int)PaddingLeft, rectangle_0.Top + (int)PaddingTop, (int)((float)rectangle_0.Width - PaddingLeft - PaddingRight), (int)((float)rectangle_0.Height - PaddingTop - PaddingBottom));
		}

		[DCInternal]
		public RectangleF method_24(float float_1, float float_2, float float_3, float float_4)
		{
			return new RectangleF(float_1 + PaddingLeft, float_2 + PaddingTop, float_3 - PaddingLeft - PaddingRight, float_4 - PaddingTop - PaddingBottom);
		}

		[DCInternal]
		public RectangleF method_25(RectangleF rectangleF_0)
		{
			return new RectangleF(rectangleF_0.Left + PaddingLeft, rectangleF_0.Top + PaddingTop, rectangleF_0.Width - PaddingLeft - PaddingRight, rectangleF_0.Height - PaddingTop - PaddingBottom);
		}

		[DCInternal]
		[Browsable(false)]
		public string method_26(int int_2)
		{
			return GClass470.smethod_5(int_2, ParagraphListStyle);
		}

		object ICloneable.Clone()
		{
			ContentStyle contentStyle = (ContentStyle)MemberwiseClone();
			contentStyle.gclass374_0 = new GClass374();
			contentStyle.ValueLocked = false;
			XDependencyObject.CopyValueFast(this, contentStyle);
			return contentStyle;
		}

		[DCInternal]
		public ContentStyle CloneEnableDefaultValue()
		{
			ContentStyle contentStyle = Clone();
			contentStyle.DisableDefaultValue = false;
			return contentStyle;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public virtual ContentStyle Clone()
		{
			return (ContentStyle)((ICloneable)this).Clone();
		}

		[DCInternal]
		public void method_27(ContentStyle contentStyle_1)
		{
			XDependencyObject.smethod_7(contentStyle_1, this, bool_3: false);
		}

		[DCInternal]
		public void method_28(ContentStyle contentStyle_1, bool bool_3)
		{
			XDependencyObject.smethod_7(contentStyle_1, this, bool_3: true);
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		[DCInternal]
		public override string ToString()
		{
			return XDependencyObject.smethod_3(this);
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		[DCInternal]
		public virtual void Dispose()
		{
			method_0();
			if (contentStyle_0 != null)
			{
				contentStyle_0.Dispose();
				contentStyle_0 = null;
			}
		}

		[DCInternal]
		public virtual void vmethod_3()
		{
		}
	}
}
