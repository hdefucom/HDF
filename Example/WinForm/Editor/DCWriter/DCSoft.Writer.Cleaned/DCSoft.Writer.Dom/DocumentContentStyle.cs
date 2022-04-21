using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
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
	///       文档样式信息对象
	///       </summary>
	[Serializable]
	
	[ComClass("00012345-6789-ABCD-EF01-234567890044", "3FAB6739-C339-45D9-930F-153F8BFF7CEA")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890044")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDocumentContentStyle))]
	
	public class DocumentContentStyle : ContentStyle, IDocumentContentStyle
	{
		internal const string string_73 = "00012345-6789-ABCD-EF01-234567890044";

		internal const string string_74 = "3FAB6739-C339-45D9-930F-153F8BFF7CEA";

		[NonSerialized]
		private RuntimeDocumentContentStyle runtimeDocumentContentStyle_0 = null;

		[NonSerialized]
		private Hashtable hashtable_0 = null;

		[NonSerialized]
		internal float float_1 = -1f;

		[NonSerialized]
		internal float float_2 = -1f;

		private static GClass371 gclass371_72 = GClass371.smethod_1("PrintColor", typeof(Color), typeof(DocumentContentStyle), Color.Transparent);

		private static GClass371 gclass371_73 = GClass371.smethod_1("PrintBackColor", typeof(Color), typeof(DocumentContentStyle), Color.Empty);

		private static GClass371 gclass371_74 = GClass371.smethod_1("LayoutDirection", typeof(ContentLayoutDirectionStyle), typeof(DocumentContentStyle), ContentLayoutDirectionStyle.Default);

		private static GClass371 gclass371_75 = GClass371.smethod_1("CommentIndex", typeof(int), typeof(DocumentContentStyle), -1);

		private static GClass371 gclass371_76 = GClass371.smethod_1("ProtectType", typeof(ContentProtectType), typeof(DocumentContentStyle), ContentProtectType.None);

		private static GClass371 gclass371_77 = GClass371.smethod_1("TitleLevel", typeof(int), typeof(DocumentContentStyle), -1);

		private static GClass371 gclass371_78 = GClass371.smethod_1("GridLineType", typeof(ContentGridLineType), typeof(DocumentContentStyle), ContentGridLineType.None);

		private static GClass371 gclass371_79 = GClass371.smethod_1("SpecifyGridLineStep", typeof(float), typeof(DocumentContentStyle), 0f);

		private static GClass371 gclass371_80 = GClass371.smethod_1("GridLineOffsetY", typeof(float), typeof(DocumentContentStyle), 0f);

		private static GClass371 gclass371_81 = GClass371.smethod_1("GridLineStyle", typeof(DashStyle), typeof(DocumentContentStyle), DashStyle.Solid);

		private static GClass371 gclass371_82 = GClass371.smethod_1("GridLineColor", typeof(Color), typeof(DocumentContentStyle), Color.Black);

		private static GClass371 gclass371_83 = GClass371.smethod_1("CreatorIndex", typeof(int), typeof(DocumentContentStyle), -1);

		private static GClass371 gclass371_84 = GClass371.smethod_1("DeleterIndex", typeof(int), typeof(DocumentContentStyle), -1);

		private static GClass371 gclass371_85 = GClass371.smethod_1("Name", typeof(string), typeof(DocumentContentStyle), null);

		private static GClass371 gclass371_86 = GClass371.smethod_1("Link", typeof(string), typeof(DocumentContentStyle), null);

		[NonSerialized]
		private int int_2 = 0;

		[NonSerialized]
		private float float_3 = 100f;

		[NonSerialized]
		private float float_4 = 0f;

		private float float_5 = 0f;

		/// <summary>
		///       运行时样式
		///       </summary>
		[Browsable(false)]
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public RuntimeDocumentContentStyle MyRuntimeStyle
		{
			get
			{
				if (runtimeDocumentContentStyle_0 == null)
				{
					runtimeDocumentContentStyle_0 = new RuntimeDocumentContentStyle(this);
				}
				return runtimeDocumentContentStyle_0;
			}
		}

		/// <summary>
		///       附加的数据,本数据不存储
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public Hashtable Tags
		{
			get
			{
				return hashtable_0;
			}
			set
			{
				hashtable_0 = value;
			}
		}

		/// <summary>
		///       打印用文本颜色
		///       </summary>
		
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color PrintColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_72);
			}
			set
			{
				vmethod_1(gclass371_72, value);
			}
		}

		/// <summary>
		///       字符串格式的对象颜色
		///       </summary>
		
		[Browsable(false)]
		[XmlElement("PrintColor")]
		[DefaultValue(null)]
		public string PrintColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(PrintColor, Color.Transparent);
			}
			set
			{
				PrintColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       打印用背景颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Empty")]
		
		[XmlIgnore]
		public Color PrintBackColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_73);
			}
			set
			{
				vmethod_1(gclass371_73, value);
			}
		}

		/// <summary>
		///       字符串格式的对象颜色
		///       </summary>
		[XmlElement("PrintBackColor")]
		[Browsable(false)]
		[DefaultValue(null)]
		
		public string PrintBackColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(PrintBackColor, Color.Empty);
			}
			set
			{
				PrintBackColor = XMLSerializeHelper.StringToColor(value, Color.Empty);
			}
		}

		/// <summary>
		///       运行时使用的打印用的文本颜色
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public Color RuntimePrintColor
		{
			get
			{
				Color printColor = PrintColor;
				if (printColor.A == 0)
				{
					return base.Color;
				}
				return printColor;
			}
		}

		/// <summary>
		///       内容排版方向，默认为Default
		///       </summary>
		
		[DefaultValue(ContentLayoutDirectionStyle.Default)]
		public ContentLayoutDirectionStyle LayoutDirection
		{
			get
			{
				return (ContentLayoutDirectionStyle)vmethod_0(gclass371_74);
			}
			set
			{
				vmethod_1(gclass371_74, value);
			}
		}

		/// <summary>
		///       批注编号，默认为-1.
		///       </summary>
		
		[DefaultValue(-1)]
		public int CommentIndex
		{
			get
			{
				return (int)vmethod_0(gclass371_75);
			}
			set
			{
				vmethod_1(gclass371_75, value);
			}
		}

		/// <summary>
		///       内容保护模式,默认值为None。
		///       </summary>
		[DefaultValue(ContentProtectType.None)]
		
		public ContentProtectType ProtectType
		{
			get
			{
				return (ContentProtectType)vmethod_0(gclass371_76);
			}
			set
			{
				vmethod_1(gclass371_76, value);
			}
		}

		/// <summary>
		///       标题层次,默认值为-1
		///       </summary>
		
		[DefaultValue(-1)]
		public int TitleLevel
		{
			get
			{
				return (int)vmethod_0(gclass371_77);
			}
			set
			{
				vmethod_1(gclass371_77, value);
			}
		}

		/// <summary>
		///       是否存在有效的标题层次
		///       </summary>
		
		[Browsable(false)]
		
		public bool HasTitleLevel
		{
			get
			{
				if (gclass374_0.ContainsKey(gclass371_77))
				{
					int num = (int)vmethod_0(gclass371_77);
					return num >= 0;
				}
				return false;
			}
		}

		/// <summary>
		///       本属性已经淘汰了，请使用XTextContentElement.GridLine属性。网格线类型
		///       </summary>
		[XmlElement]
		
		[DefaultValue(ContentGridLineType.None)]
		public ContentGridLineType GridLineType
		{
			get
			{
				return (ContentGridLineType)vmethod_0(gclass371_78);
			}
			set
			{
				vmethod_1(gclass371_78, value);
			}
		}

		/// <summary>
		///       请改用XTextContentElement.SpecifyFixedLineHeight属性
		///       </summary>
		
		[DefaultValue(0f)]
		[XmlElement]
		[Obsolete("本属性已经淘汰了，请使用XTextContentElement.GridLine属性。")]
		public float SpecifyGridLineStep
		{
			get
			{
				return (float)vmethod_0(gclass371_79);
			}
			set
			{
				vmethod_1(gclass371_79, value);
			}
		}

		/// <summary>
		///       本属性已经淘汰了，请使用XTextContentElement.GridLine属性。网格线纵向偏移量
		///       </summary>
		[XmlElement]
		
		[DefaultValue(0f)]
		public float GridLineOffsetY
		{
			get
			{
				return (float)vmethod_0(gclass371_80);
			}
			set
			{
				vmethod_1(gclass371_80, value);
			}
		}

		/// <summary>
		///       本属性已经淘汰了，请使用XTextContentElement.GridLine属性。网格线线型
		///       </summary>
		[XmlElement]
		
		[DefaultValue(DashStyle.Solid)]
		public DashStyle GridLineStyle
		{
			get
			{
				return (DashStyle)vmethod_0(gclass371_81);
			}
			set
			{
				vmethod_1(gclass371_81, value);
			}
		}

		/// <summary>
		///       本属性已经淘汰了，请使用XTextContentElement.GridLine属性。 网格线颜色
		///        </summary>
		[XmlIgnore]
		
		[DefaultValue(typeof(Color), "Black")]
		[Obsolete("本属性已经淘汰了，请使用XTextContentElement.GridLine属性。")]
		public Color GridLineColor
		{
			get
			{
				return (Color)vmethod_0(gclass371_82);
			}
			set
			{
				vmethod_1(gclass371_82, value);
			}
		}

		/// <summary>
		///       本属性已经淘汰了，请使用XTextContentElement.GridLine属性。字符串格式的对象颜色
		///       </summary>
		[DefaultValue(null)]
		
		[XmlElement("GridLineColor")]
		[Browsable(false)]
		public string GridLineColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(GridLineColor, Color.Black);
			}
			set
			{
				GridLineColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       创建元素的用户信息编号
		///       </summary>
		[DefaultValue(-1)]
		
		public int CreatorIndex
		{
			get
			{
				return (int)vmethod_0(gclass371_83);
			}
			set
			{
				vmethod_1(gclass371_83, value);
			}
		}

		/// <summary>
		///       删除元素的用户信息编号
		///       </summary>
		
		[DefaultValue(-1)]
		public int DeleterIndex
		{
			get
			{
				return (int)vmethod_0(gclass371_84);
			}
			set
			{
				vmethod_1(gclass371_84, value);
			}
		}

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		
		public string Name
		{
			get
			{
				return (string)vmethod_0(gclass371_85);
			}
			set
			{
				vmethod_1(gclass371_85, value);
			}
		}

		/// <summary>
		///       超链接地址
		///       </summary>
		[DefaultValue(null)]
		
		public string Link
		{
			get
			{
				return (string)vmethod_0(gclass371_86);
			}
			set
			{
				vmethod_1(gclass371_86, value);
			}
		}

		/// <summary>
		///       被引用的次数
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		
		
		[Browsable(false)]
		public int ReferenceCount
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		/// <summary>
		///       制表宽度
		///       </summary>
		
		[Browsable(false)]
		public float TabWidth => float_3;

		/// <summary>
		///       默认行高
		///       </summary>
		[Browsable(false)]
		public float DefaultLineHeight => float_4;

		/// <summary>
		///       字体高度
		///       </summary>
		[Browsable(false)]
		public float FontHeight => float_5;

		Color IDocumentContentStyle.BackgroundColor2
		{
			get
			{
				return base.BackgroundColor2;
			}
			set
			{
				base.BackgroundColor2 = value;
			}
		}

		bool IDocumentContentStyle.BackgroundRepeat
		{
			get
			{
				return base.BackgroundRepeat;
			}
			set
			{
				base.BackgroundRepeat = value;
			}
		}

		string IDocumentContentStyle.BulletedString => base.BulletedString;

		bool IDocumentContentStyle.DisableDefaultValue
		{
			get
			{
				return base.DisableDefaultValue;
			}
			set
			{
				base.DisableDefaultValue = value;
			}
		}

		bool IDocumentContentStyle.EmphasisMark
		{
			get
			{
				return base.EmphasisMark;
			}
			set
			{
				base.EmphasisMark = value;
			}
		}

		bool IDocumentContentStyle.FixedSpacing
		{
			get
			{
				return base.FixedSpacing;
			}
			set
			{
				base.FixedSpacing = value;
			}
		}

		float IDocumentContentStyle.LayoutGridHeight
		{
			get
			{
				return base.LayoutGridHeight;
			}
			set
			{
				base.LayoutGridHeight = value;
			}
		}

		bool IDocumentContentStyle.ParagraphMultiLevel
		{
			get
			{
				return base.ParagraphMultiLevel;
			}
			set
			{
				base.ParagraphMultiLevel = value;
			}
		}

		int IDocumentContentStyle.ParagraphOutlineLevel
		{
			get
			{
				return base.ParagraphOutlineLevel;
			}
			set
			{
				base.ParagraphOutlineLevel = value;
			}
		}

		float IDocumentContentStyle.Top
		{
			get
			{
				return base.Top;
			}
			set
			{
				base.Top = value;
			}
		}

		string IDocumentContentStyle.UnderlineColor
		{
			get
			{
				return base.UnderlineColor;
			}
			set
			{
				base.UnderlineColor = value;
			}
		}

		TextUnderlineStyle IDocumentContentStyle.UnderlineStyle
		{
			get
			{
				return base.UnderlineStyle;
			}
			set
			{
				base.UnderlineStyle = value;
			}
		}

		bool IDocumentContentStyle.ValueLocked
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

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentContentStyle()
		{
		}

		
		public override ContentStyle Clone()
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)base.Clone();
			documentContentStyle.runtimeDocumentContentStyle_0 = null;
			return documentContentStyle;
		}

		protected override void vmethod_2(GClass371 gclass371_87)
		{
			runtimeDocumentContentStyle_0 = null;
		}

		
		public bool method_29(string string_75)
		{
			foreach (GClass371 key in base.InnerValues.Keys)
			{
				if (string.Compare(key.Name, string_75, ignoreCase: true) == 0)
				{
					base.InnerValues.Remove(key);
					bool_2 = true;
					return true;
				}
			}
			GClass371[] array = GClass371.smethod_3(GetType(), bool_4: false);
			GClass371[] array2 = array;
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					GClass371 current = array2[num];
					if (string.Compare(current.Name, string_75, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				throw new ArgumentOutOfRangeException(string_75);
			}
			return false;
		}

		
		public string method_30(string string_75)
		{
			int num = 10;
			List<string> list = null;
			if (!string.IsNullOrEmpty(string_75))
			{
				list = new List<string>();
				list.AddRange(string_75.Split(','));
			}
			foreach (GClass371 key in base.InnerValues.Keys)
			{
				if (key != gclass371_84 && key != gclass371_83 && key.method_5(base.InnerValues[key]))
				{
					if (list == null)
					{
						list = new List<string>();
					}
					list.Add(key.Name);
				}
			}
			if (list != null)
			{
				list.Sort();
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string item in list)
				{
					if (!string.IsNullOrEmpty(item))
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(item);
					}
				}
				return stringBuilder.ToString();
			}
			return null;
		}

		
		public string method_31(string string_75)
		{
			int num = 1;
			List<string> list = null;
			if (!string.IsNullOrEmpty(string_75))
			{
				list = new List<string>();
				list.AddRange(string_75.Split(','));
			}
			foreach (GClass371 key in base.InnerValues.Keys)
			{
				if (key != gclass371_84 && key != gclass371_83)
				{
					if (key.method_5(base.InnerValues[key]))
					{
						if (!base.DisableDefaultValue)
						{
							if (list == null)
							{
								list = new List<string>();
							}
							list.Add(key.Name);
						}
					}
					else if (list != null)
					{
						for (int num2 = list.Count - 1; num2 >= 0; num2--)
						{
							if (list[num2] == key.Name)
							{
								list.RemoveAt(num2);
							}
						}
					}
				}
			}
			if (list != null)
			{
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					string b = list[num2];
					for (int i = num2 + 1; i < list.Count; i++)
					{
						if (list[i] == b)
						{
							list.RemoveAt(i);
							i--;
						}
					}
				}
				list.Sort();
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string item in list)
				{
					if (!string.IsNullOrEmpty(item))
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(item);
					}
				}
				return stringBuilder.ToString();
			}
			return null;
		}

		
		public void method_32(DCGraphics dcgraphics_0)
		{
			int num = 9;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			SizeF sizeF = dcgraphics_0.MeasureString("____", base.Font, 10000, DrawStringFormatExt.GenericTypographic);
			float_5 = dcgraphics_0.GetFontHeight(base.Font);
			float_3 = (int)Math.Ceiling(sizeF.Width);
			_ = base.Font;
			float_4 = float_5 + 4f;
			float num2 = float_5 + 4f;
			if (float_4 != num2)
			{
			}
		}

		
		public int method_33(DocumentContentStyle documentContentStyle_0)
		{
			int num = 3;
			if (documentContentStyle_0 == null)
			{
				throw new ArgumentNullException("defaultStyle");
			}
			foreach (GClass371 key in documentContentStyle_0.InnerValues.Keys)
			{
				if (base.InnerValues.ContainsKey(key))
				{
					object obj = documentContentStyle_0.InnerValues[key];
					object obj2 = base.InnerValues[key];
					if (obj == obj2)
					{
						base.InnerValues.Remove(key);
						bool_2 = true;
					}
				}
			}
			return base.InnerValues.Count;
		}

		internal DocumentContentStyle method_34()
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)Clone();
			documentContentStyle.BorderLeft = false;
			documentContentStyle.BorderTop = false;
			documentContentStyle.BorderRight = false;
			documentContentStyle.BorderBottom = false;
			return documentContentStyle;
		}
	}
}
