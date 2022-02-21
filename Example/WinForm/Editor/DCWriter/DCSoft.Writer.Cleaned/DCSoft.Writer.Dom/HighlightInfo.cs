using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       高亮度显示区域
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	[DocumentComment]
	
	public class HighlightInfo
	{
		private Dictionary<XTextLine, RectangleF> dictionary_0;

		internal XTextElement xtextElement_0;

		private XTextRange xtextRange_0;

		private Color color_0;

		private Color color_1;

		private HighlightActiveStyle highlightActiveStyle_0;

		/// <summary>
		///       该高亮度显示区域相关的文档元素对象
		///       </summary>
		public XTextElement OwnerElement
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
		///       高亮度区域
		///       </summary>
		public XTextRange Range
		{
			get
			{
				return xtextRange_0;
			}
			set
			{
				xtextRange_0 = value;
				dictionary_0 = null;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		public Color BackColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       文本颜色
		///       </summary>
		public Color Color
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
			}
		}

		/// <summary>
		///       激活模式
		///       </summary>
		public HighlightActiveStyle ActiveStyle
		{
			get
			{
				return highlightActiveStyle_0;
			}
			set
			{
				highlightActiveStyle_0 = value;
			}
		}

		public static bool smethod_0(HighlightInfo highlightInfo_0, HighlightInfo highlightInfo_1)
		{
			if (highlightInfo_0 == highlightInfo_1)
			{
				return true;
			}
			if (highlightInfo_0 == null || highlightInfo_1 == null)
			{
				return false;
			}
			if (!XTextRange.smethod_0(highlightInfo_0.Range, highlightInfo_1.Range) || highlightInfo_0.highlightActiveStyle_0 != highlightInfo_1.highlightActiveStyle_0 || highlightInfo_0.color_0 != highlightInfo_1.color_0 || highlightInfo_0.color_1 != highlightInfo_1.color_1)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public HighlightInfo()
		{
			dictionary_0 = null;
			xtextElement_0 = null;
			xtextRange_0 = null;
			color_0 = SystemColors.Highlight;
			color_1 = SystemColors.HighlightText;
			highlightActiveStyle_0 = HighlightActiveStyle.Hover;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="range">区域</param>
		public HighlightInfo(XTextRange xtextRange_1)
		{
			int num = 11;
			dictionary_0 = null;
			xtextElement_0 = null;
			xtextRange_0 = null;
			color_0 = SystemColors.Highlight;
			color_1 = SystemColors.HighlightText;
			highlightActiveStyle_0 = HighlightActiveStyle.Hover;
			
			if (xtextRange_1 == null)
			{
				throw new ArgumentNullException("range");
			}
			xtextRange_0 = xtextRange_1;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="range">区域</param>
		/// <param name="backColor">背景色</param>
		/// <param name="color">前景色</param>
		public HighlightInfo(XTextRange xtextRange_1, Color color_2, Color color_3)
		{
			int num = 12;
			dictionary_0 = null;
			xtextElement_0 = null;
			xtextRange_0 = null;
			color_0 = SystemColors.Highlight;
			color_1 = SystemColors.HighlightText;
			highlightActiveStyle_0 = HighlightActiveStyle.Hover;
			
			if (xtextRange_1 == null)
			{
				throw new ArgumentNullException("range");
			}
			xtextRange_0 = xtextRange_1;
			color_0 = color_2;
			color_1 = color_3;
		}

		public void method_0()
		{
			if (dictionary_0 != null)
			{
				dictionary_0.Clear();
			}
			xtextElement_0 = null;
			if (xtextRange_0 != null)
			{
				xtextRange_0.method_2();
				xtextRange_0 = null;
			}
		}

		/// <summary>
		///       获得指定文档行的在高亮度区域中的边界
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>获得的边界对象</returns>
		public RectangleF GetLineBounds(XTextElement element)
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<XTextLine, RectangleF>();
				XTextLine xTextLine = null;
				RectangleF rectangleF = RectangleF.Empty;
				foreach (XTextElement item in Range)
				{
					if (item != null && item.OwnerLine != null)
					{
					}
					if (item.OwnerLine != xTextLine)
					{
						if (xTextLine != null)
						{
							dictionary_0[xTextLine] = rectangleF;
							rectangleF = RectangleF.Empty;
						}
						xTextLine = item.OwnerLine;
					}
					rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, item.AbsBounds) : item.AbsBounds);
				}
				if (xTextLine != null)
				{
					dictionary_0[xTextLine] = rectangleF;
				}
			}
			if (dictionary_0.ContainsKey(element.OwnerLine))
			{
				return dictionary_0[element.OwnerLine];
			}
			return RectangleF.Empty;
		}

		/// <summary>
		///       判断指定的元素是否处于高亮度显示区域中
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		public bool Contains(XTextElement element)
		{
			return xtextRange_0.Contains(element);
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Range.ToString() + " BC:" + BackColor.ToString();
		}
	}
}
