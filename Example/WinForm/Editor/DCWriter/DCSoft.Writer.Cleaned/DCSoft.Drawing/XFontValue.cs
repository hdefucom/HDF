#define DEBUG
using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       字体信息类型，本对象可以参与XML和二进制的序列化及反序列化。
	///       </summary>
	[Serializable]
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-23456789008D")]
	[DCPublishAPI]
	[Editor(typeof(GClass439), typeof(UITypeEditor))]
	[DefaultProperty("Value")]
	[ComDefaultInterface(typeof(IXFontValue))]
	[ClassInterface(ClassInterfaceType.None)]
	[TypeConverter(typeof(GClass440))]
	[ToolboxItem(false)]
	[ComVisible(true)]
	public class XFontValue : ICloneable, IComponent, IXFontValue
	{
		public static string string_0;

		[NonSerialized]
		[DCInternal]
		public static Font font_0;

		/// <summary>
		///       默认字体名称
		///       </summary>
		[NonSerialized]
		[DCInternal]
		public static string DefaultFontName;

		/// <summary>
		///       默认字体大小
		///       </summary>
		[NonSerialized]
		[DCInternal]
		public static float DefaultFontSize;

		private string string_1 = DefaultFontName;

		private float float_0 = DefaultFontSize;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Point;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private bool bool_3 = false;

		[NonSerialized]
		private static List<Font> list_0;

		[NonSerialized]
		private static List<string> list_1;

		private static int int_0;

		private static EventHandler eventHandler_0;

		[NonSerialized]
		private int int_1 = -1;

		[NonSerialized]
		private Font font_1 = null;

		private EventHandler eventHandler_1 = null;

		[NonSerialized]
		private ISite isite_0 = null;

		/// <summary>
		///       判断当前字体是否是默认字体
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public bool IsDefault
		{
			get
			{
				if (string_1 == DefaultFontName && float_0 == DefaultFontSize && !bool_1 && !bool_2 && !bool_0 && !bool_3)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       判断当前字体名称是否是默认字体
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool IsDefaultName => string_1 == DefaultFontName;

		/// <summary>
		///       字体名称
		///       </summary>
		[DefaultFontNameValue]
		[Editor("DCSoft.WinForms.Design.FontNameUITypeEditor", typeof(UITypeEditor))]
		public string Name
		{
			get
			{
				return string_1;
			}
			set
			{
				if (string_1 != value)
				{
					string_1 = value;
					if (string_1 == null || string_1.Length == 0)
					{
						string_1 = DefaultFontName;
					}
					font_1 = null;
				}
			}
		}

		/// <summary>
		///       判断当前字体是否是默认大小
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool IsDefaultSize => float_0 == DefaultFontSize;

		/// <summary>
		///       字体大小
		///       </summary>
		[Editor("DCSoft.Editor.FontSizeEditor", typeof(UITypeEditor))]
		[DefaultValue(9f)]
		public float Size
		{
			get
			{
				return float_0;
			}
			set
			{
				if (float_0 != value)
				{
					float_0 = value;
					if (float_0 <= 0f)
					{
						float_0 = DefaultFontSize;
					}
					font_1 = null;
				}
			}
		}

		/// <summary>
		///       字体大小的度量单位
		///       </summary>
		[DefaultValue(GraphicsUnit.Point)]
		public GraphicsUnit Unit
		{
			get
			{
				return graphicsUnit_0;
			}
			set
			{
				graphicsUnit_0 = value;
			}
		}

		/// <summary>
		///       是否粗体
		///       </summary>
		[DefaultValue(false)]
		public bool Bold
		{
			get
			{
				return bool_0;
			}
			set
			{
				if (bool_0 != value)
				{
					bool_0 = value;
					font_1 = null;
				}
			}
		}

		/// <summary>
		///       是否斜体
		///       </summary>
		[DefaultValue(false)]
		public bool Italic
		{
			get
			{
				return bool_1;
			}
			set
			{
				if (bool_1 != value)
				{
					bool_1 = value;
					font_1 = null;
				}
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
				return bool_2;
			}
			set
			{
				if (bool_2 != value)
				{
					bool_2 = value;
					font_1 = null;
				}
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
				return bool_3;
			}
			set
			{
				if (bool_3 != value)
				{
					bool_3 = value;
					font_1 = null;
				}
			}
		}

		/// <summary>
		///       字体样式
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DefaultValue(FontStyle.Regular)]
		public FontStyle Style
		{
			get
			{
				FontStyle fontStyle = FontStyle.Regular;
				if (bool_0)
				{
					fontStyle = FontStyle.Bold;
				}
				if (bool_1)
				{
					fontStyle |= FontStyle.Italic;
				}
				if (bool_2)
				{
					fontStyle |= FontStyle.Underline;
				}
				if (bool_3)
				{
					fontStyle |= FontStyle.Strikeout;
				}
				return fontStyle;
			}
			set
			{
				if (Style != value)
				{
					bool_0 = method_1(value, FontStyle.Bold);
					bool_1 = method_1(value, FontStyle.Italic);
					bool_2 = method_1(value, FontStyle.Underline);
					bool_3 = method_1(value, FontStyle.Strikeout);
					font_1 = null;
				}
			}
		}

		/// <summary>
		///       获得字体 CellAscent值
		///       </summary>
		[Browsable(false)]
		public int CellAscent => Value.FontFamily.GetCellAscent(Style);

		/// <summary>
		///       获得字体CellDescent值
		///       </summary>
		[Browsable(false)]
		public int CellDescent => Value.FontFamily.GetCellDescent(Style);

		/// <summary>
		///       获得字体LineSpacing值
		///       </summary>
		[Browsable(false)]
		public int LineSpacing => Value.FontFamily.GetLineSpacing(Style);

		/// <summary>
		///       获得字体EmHeight值
		///       </summary>
		[Browsable(false)]
		public int EmHeight => Value.FontFamily.GetEmHeight(Style);

		/// <summary>
		///       内部缓存字体对象的列表
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public static List<Font> Buffer => list_0;

		/// <summary>
		///       清空缓存区累计次数
		///       </summary>
		[DCInternal]
		public static int BufferClearCount => int_0;

		/// <summary>
		///       字体的内置编号,相同设置的XFontValue对象，其RawFontIndex属性相同
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public int RawFontIndex
		{
			get
			{
				if (int_1 < 0 || font_1 == null)
				{
					Font value = Value;
					int_1 = list_0.IndexOf(value);
				}
				return int_1;
			}
		}

		/// <summary>
		///       字体对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public Font Value
		{
			get
			{
				if (font_1 == null)
				{
					string text = string_1;
					if (string.IsNullOrEmpty(text))
					{
						text = Control.DefaultFont.Name;
					}
					float size = float_0;
					if (size <= 0f)
					{
						size = Control.DefaultFont.Size;
					}
					FontStyle style = Style;
					if (list_1.Count > 0)
					{
						foreach (string item in list_1)
						{
							if (string.Compare(item, text, ignoreCase: true) == 0)
							{
								text = DefaultFontName;
								break;
							}
						}
					}
					if (text == DefaultFontName && size == DefaultFontSize && style == FontStyle.Regular)
					{
						font_1 = font_0;
						if (!list_0.Contains(font_0))
						{
							list_0.Add(font_0);
						}
					}
					else
					{
						foreach (Font item2 in list_0)
						{
							if (text == item2.Name && size == item2.Size && style == item2.Style && graphicsUnit_0 == item2.Unit)
							{
								font_1 = item2;
								break;
							}
						}
					}
					if (font_1 == null)
					{
						if (list_0.Count > 500)
						{
							return font_0;
						}
						FontFamily fontFamily = null;
						try
						{
							fontFamily = new FontFamily(text);
							if (fontFamily.Name != text)
							{
								fontFamily = new FontFamily(DefaultFontName);
								bool flag = false;
								foreach (string item3 in list_1)
								{
									if (string.Compare(item3, string_1, ignoreCase: true) == 0)
									{
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									list_1.Add(string_1);
								}
							}
						}
						catch (Exception)
						{
							fontFamily = new FontFamily(DefaultFontName);
							bool flag = false;
							foreach (string item4 in list_1)
							{
								if (string.Compare(item4, string_1, ignoreCase: true) == 0)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								list_1.Add(string_1);
							}
						}
						try
						{
							if (!fontFamily.IsStyleAvailable(Style))
							{
								FontStyle[] array = new FontStyle[6]
								{
									FontStyle.Regular,
									FontStyle.Bold,
									FontStyle.Italic,
									FontStyle.Underline,
									FontStyle.Strikeout,
									FontStyle.Bold | FontStyle.Italic
								};
								foreach (FontStyle style2 in array)
								{
									if (fontFamily.IsStyleAvailable(style2))
									{
										Style = style2;
										break;
									}
								}
							}
							font_1 = new Font(fontFamily, float_0, Style, Unit);
							list_0.Add(font_1);
						}
						catch (Exception ex2)
						{
							Debug.WriteLine(ex2.Message);
							font_1 = font_0;
						}
					}
				}
				return font_1;
			}
			set
			{
				if (value == null)
				{
					value = font_0;
				}
				if (!method_4(value))
				{
					string_1 = value.Name;
					float_0 = value.Size;
					bool_0 = value.Bold;
					bool_1 = value.Italic;
					bool_2 = value.Underline;
					bool_3 = value.Strikeout;
					graphicsUnit_0 = value.Unit;
					font_1 = value;
				}
			}
		}

		/// <summary>
		///       组件站点对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		///       字体缓存对象清空时间
		///       </summary>
		[DCInternal]
		public static event EventHandler BufferCleared
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
		///       对象销毁事件
		///       </summary>
		[DCInternal]
		public event EventHandler Disposed
		{
			add
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		static XFontValue()
		{
			string_0 = "Font";
			font_0 = null;
			DefaultFontName = null;
			DefaultFontSize = 9f;
			list_0 = new List<Font>();
			list_1 = new List<string>();
			int_0 = 0;
			eventHandler_0 = null;
			font_0 = Control.DefaultFont;
			DefaultFontName = font_0.Name;
			DefaultFontSize = font_0.Size;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XFontValue()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">字体名称</param>
		/// <param name="size">字体大小</param>
		public XFontValue(string string_2, float float_1)
		{
			string_1 = string_2;
			float_0 = float_1;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">字体名称</param>
		/// <param name="size">字体大小</param>
		/// <param name="style">字体样式</param>
		public XFontValue(string string_2, float float_1, FontStyle fontStyle_0)
		{
			string_1 = string_2;
			float_0 = float_1;
			Style = fontStyle_0;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">字体名称</param>
		/// <param name="size">字体大小</param>
		/// <param name="style">字体样式</param>
		/// <param name="unit">度量单位</param>
		public XFontValue(string string_2, float float_1, FontStyle fontStyle_0, GraphicsUnit graphicsUnit_1)
		{
			string_1 = string_2;
			float_0 = float_1;
			Style = fontStyle_0;
			Unit = graphicsUnit_1;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="f">字体对象</param>
		public XFontValue(Font font_2)
		{
			if (font_2 != null)
			{
				Name = font_2.Name;
				Size = font_2.Size;
				Style = font_2.Style;
				Unit = font_2.Unit;
			}
		}

		[DCInternal]
		public XFontValue method_0(float float_1)
		{
			XFontValue xFontValue = Clone();
			xFontValue.Size = (float)GraphicsUnitConvert.ToPixel(xFontValue.Size, GraphicsUnit.Point, float_1);
			xFontValue.Unit = GraphicsUnit.Pixel;
			return xFontValue;
		}

		private bool method_1(FontStyle fontStyle_0, FontStyle fontStyle_1)
		{
			return (fontStyle_0 & fontStyle_1) == fontStyle_1;
		}

		[DCInternal]
		public bool method_2()
		{
			string a = smethod_1(string_1);
			if (a != string_1)
			{
				string_1 = a;
				return true;
			}
			return false;
		}

		[DCInternal]
		public static void smethod_0()
		{
			list_0.Clear();
			list_1.Clear();
			GC.Collect();
			int_0++;
			if (eventHandler_0 != null)
			{
				eventHandler_0(null, null);
			}
		}

		[DCInternal]
		public static string smethod_1(string string_2)
		{
			int num = 0;
			if (string_2 == null || string_2.Trim().Length == 0)
			{
				return DefaultFontName;
			}
			while (true)
			{
				string_2 = string_2.Trim();
				if (list_1.Count > 0)
				{
					foreach (string item in list_1)
					{
						if (string.Compare(string_2, item, ignoreCase: true) == 0)
						{
							return DefaultFontName;
						}
					}
				}
				try
				{
					FontFamily fontFamily = new FontFamily(string_2);
					return fontFamily.Name;
				}
				catch (Exception)
				{
					int num2 = string_2.IndexOf("(");
					if (num2 <= 0)
					{
						goto IL_007d;
					}
					string text = string_2.Substring(0, num2).Trim();
					if (text.Length <= 0)
					{
						goto IL_007d;
					}
					string_2 = text;
					goto end_IL_0040;
					IL_007d:
					list_1.Add(string_2);
					break;
					end_IL_0040:;
				}
			}
			return DefaultFontName;
		}

		/// <summary>
		///       获得字体的以像素为单位的高度
		///       </summary>
		/// <returns>字体高度</returns>
		public float GetHeight()
		{
			return Value?.GetHeight() ?? 0f;
		}

		/// <summary>
		///       获得字体的高度
		///       </summary>
		/// <param name="g">绘图对象</param>
		/// <returns>字体高度</returns>
		public float GetHeight(DCGraphics dcgraphics_0)
		{
			Font value = Value;
			if (value == null)
			{
				return 0f;
			}
			if (dcgraphics_0.NativeGraphics != null)
			{
				return value.GetHeight(dcgraphics_0.NativeGraphics);
			}
			if (dcgraphics_0.GraphisForMeasure != null)
			{
				return value.GetHeight(dcgraphics_0.GraphisForMeasure);
			}
			return value.GetHeight(dcgraphics_0.DpiY);
		}

		/// <summary>
		///       获得字体的高度
		///       </summary>
		/// <param name="g">绘图对象</param>
		/// <returns>字体高度</returns>
		public float GetHeight(Graphics graphics_0)
		{
			return Value?.GetHeight(graphics_0) ?? 0f;
		}

		/// <summary>
		///       获得指定分辨率的字体的高度
		///       </summary>
		/// <param name="dpi">分辨率</param>
		/// <returns>字体高度</returns>
		public float GetHeight(float float_1)
		{
			return Value?.GetHeight(float_1) ?? 0f;
		}

		/// <summary>
		///       获得指定度量单位下的字体高度
		///       </summary>
		/// <param name="unit">指定的度量单位</param>
		/// <returns>字体高度</returns>
		public float GetHeight(GraphicsUnit unit)
		{
			return GraphicsUnitConvert.Convert(Value.SizeInPoints, GraphicsUnit.Point, unit);
		}

		[DCInternal]
		public void method_3(XFontValue xfontValue_0)
		{
			string_1 = xfontValue_0.string_1;
			float_0 = xfontValue_0.float_0;
			bool_0 = xfontValue_0.bool_0;
			bool_1 = xfontValue_0.bool_1;
			bool_2 = xfontValue_0.bool_2;
			bool_3 = xfontValue_0.bool_3;
			graphicsUnit_0 = xfontValue_0.graphicsUnit_0;
		}

		[DCInternal]
		public bool method_4(Font font_2)
		{
			if (font_2 == null)
			{
				return false;
			}
			if (string_1 != font_2.Name)
			{
				return false;
			}
			if (float_0 != font_2.Size)
			{
				return false;
			}
			if (bool_0 != font_2.Bold)
			{
				return false;
			}
			if (bool_1 != font_2.Italic)
			{
				return false;
			}
			if (bool_2 != font_2.Underline)
			{
				return false;
			}
			if (bool_3 != font_2.Strikeout)
			{
				return false;
			}
			if (graphicsUnit_0 != font_2.Unit)
			{
				return false;
			}
			return true;
		}

		[DCInternal]
		public bool method_5(XFontValue xfontValue_0)
		{
			if (xfontValue_0 == null)
			{
				return false;
			}
			if (this == xfontValue_0)
			{
				return true;
			}
			if (string_1 != xfontValue_0.string_1)
			{
				return false;
			}
			if (float_0 != xfontValue_0.float_0)
			{
				return false;
			}
			if (bool_0 != xfontValue_0.bool_0)
			{
				return false;
			}
			if (bool_1 != xfontValue_0.bool_1)
			{
				return false;
			}
			if (bool_2 != xfontValue_0.bool_2)
			{
				return false;
			}
			if (bool_3 != xfontValue_0.bool_3)
			{
				return false;
			}
			if (graphicsUnit_0 != xfontValue_0.graphicsUnit_0)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public XFontValue Clone()
		{
			XFontValue xFontValue = new XFontValue();
			xFontValue.method_3(this);
			return xFontValue;
		}

		object ICloneable.Clone()
		{
			XFontValue xFontValue = new XFontValue();
			xFontValue.method_3(this);
			return xFontValue;
		}

		/// <summary>
		///       比较两个对象内容是否相同
		///       </summary>
		/// <param name="obj">对象</param>
		/// <returns>内容是否相同</returns>
		[DCInternal]
		public override bool Equals(object other)
		{
			if (other == this)
			{
				return true;
			}
			if (!(other is XFontValue))
			{
				return false;
			}
			XFontValue xFontValue = (XFontValue)other;
			return xFontValue.bool_0 == bool_0 && xFontValue.bool_1 == bool_1 && xFontValue.bool_3 == bool_3 && xFontValue.bool_2 == bool_2 && xFontValue.float_0 == float_0 && xFontValue.string_1 == string_1 && xFontValue.graphicsUnit_0 == graphicsUnit_0;
		}

		/// <summary>
		///       获得对象的哈希代码
		///       </summary>
		/// <returns>哈希代码</returns>
		[DCInternal]
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		/// <summary>
		///       获得表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		[DCInternal]
		public override string ToString()
		{
			int num = 1;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(Name);
			arrayList.Add(Size.ToString());
			if (Style != 0)
			{
				arrayList.Add("style=" + Style.ToString("G"));
			}
			if (graphicsUnit_0 != GraphicsUnit.Point)
			{
				arrayList.Add(graphicsUnit_0.ToString("G"));
			}
			return string.Join(", ", (string[])arrayList.ToArray(typeof(string)));
		}

		[DCInternal]
		public void method_6(string string_2)
		{
			int num = 11;
			if (string.IsNullOrEmpty(string_2))
			{
				return;
			}
			string[] array = string_2.Split(',');
			if (array.Length < 1)
			{
				throw new ArgumentException("必须符合 name,size,style=Bold,Italic,Underline,Strikeout 样式");
			}
			string name = array[0];
			float result = 9f;
			if (array.Length >= 2 && !float.TryParse(array[1].Trim(), out result))
			{
				result = 9f;
			}
			if (result <= 0f)
			{
				result = 1f;
			}
			FontStyle fontStyle = FontStyle.Regular;
			bool flag = false;
			for (int i = 2; i < array.Length; i++)
			{
				string text = array[i].Trim().ToLower();
				if (!flag && text.StartsWith("style"))
				{
					int num2 = text.IndexOf("=");
					if (num2 > 0)
					{
						flag = true;
						text = text.Substring(num2 + 1);
					}
				}
				if (flag)
				{
					if (Enum.IsDefined(typeof(FontStyle), text.Trim()))
					{
						FontStyle fontStyle2 = (FontStyle)Enum.Parse(typeof(FontStyle), text.Trim(), ignoreCase: true);
						fontStyle |= fontStyle2;
					}
					else if (Enum.IsDefined(typeof(GraphicsUnit), text.Trim()))
					{
						graphicsUnit_0 = (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), text.Trim(), ignoreCase: true);
					}
				}
			}
			Name = name;
			Size = result;
			Style = fontStyle;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		[DCInternal]
		public void Dispose()
		{
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, new EventArgs());
			}
		}
	}
}
