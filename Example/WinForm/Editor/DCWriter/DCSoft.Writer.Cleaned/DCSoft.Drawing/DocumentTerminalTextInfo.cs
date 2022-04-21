using DCSoft.Common;
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
	///       文档结束标记信息
	///       </summary>
	[Serializable]
	
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDocumentTerminalTextInfo))]
	[Guid("2680D7D6-EC07-41DD-995B-2B6B6F56D954")]
	public class DocumentTerminalTextInfo : IDocumentTerminalTextInfo
	{
		private string string_0 = null;

		private string string_1 = null;

		/// <summary>
		///       默认字体
		///       </summary>
		public static XFontValue DefaultFont = new XFontValue(Control.DefaultFont.Name, 20f);

		private XFontValue xfontValue_0 = null;

		private Color color_0 = Color.Black;

		private float float_0 = 2f;

		/// <summary>
		///       文本
		///       </summary>
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       中间页中的结束文本
		///       </summary>
		[DefaultValue(null)]
		public string TextInMiddlePage
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       字体
		///       </summary>
		[DefaultValue(null)]
		public XFontValue Font
		{
			get
			{
				return xfontValue_0;
			}
			set
			{
				xfontValue_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的字体对象
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public XFontValue RuntimeFont
		{
			get
			{
				XFontValue xFontValue = xfontValue_0;
				if (xFontValue == null)
				{
					xFontValue = DefaultFont;
				}
				if (xFontValue == null)
				{
					xFontValue = new XFontValue(Control.DefaultFont.Name, 20f);
				}
				return xFontValue;
			}
		}

		/// <summary>
		///       文本颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		public Color Color
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
		///       颜色值
		///       </summary>
		
		[XmlElement]
		[DefaultValue(null)]
		public string ColorValue
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
		///       以厘米为单位的最小高度
		///       </summary>
		[DefaultValue(2f)]
		public float MinHeightInCMUnit
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

		
		public void method_0(DCGraphics dcgraphics_0, RectangleF rectangleF_0, RectangleF rectangleF_1)
		{
			method_6(TextInMiddlePage, dcgraphics_0, rectangleF_0, rectangleF_1);
		}

		
		public void method_1(DCGraphics dcgraphics_0, RectangleF rectangleF_0, RectangleF rectangleF_1)
		{
			method_6(Text, dcgraphics_0, rectangleF_0, rectangleF_1);
		}

		public bool method_2()
		{
			int num = 11;
			return string.Compare(Text, "line:/", ignoreCase: true) == 0 || string.Compare(TextInMiddlePage, "line:/", ignoreCase: true) == 0;
		}

		public bool method_3()
		{
			int num = 5;
			return string.Compare(Text, "line:\\", ignoreCase: true) == 0 || string.Compare(TextInMiddlePage, "line:\\", ignoreCase: true) == 0;
		}

		public bool method_4()
		{
			int num = 18;
			return string.Compare(Text, "line:s", ignoreCase: true) == 0 || string.Compare(TextInMiddlePage, "line:s", ignoreCase: true) == 0;
		}

		public bool method_5()
		{
			if (!string.IsNullOrEmpty(Text) || !string.IsNullOrEmpty(TextInMiddlePage))
			{
				return !method_2() && !method_3() && !method_4();
			}
			return false;
		}

		private void method_6(string string_2, DCGraphics dcgraphics_0, RectangleF rectangleF_0, RectangleF rectangleF_1)
		{
			int num = 7;
			if (string.IsNullOrEmpty(string_2))
			{
				return;
			}
			float num2 = GraphicsUnitConvert.ConvertFromCM(MinHeightInCMUnit, dcgraphics_0.PageUnit);
			if (rectangleF_0.Height < num2)
			{
				return;
			}
			rectangleF_0.Offset(0f, 10f);
			rectangleF_0.Height -= 20f;
			XFontValue runtimeFont = RuntimeFont;
			float num3 = Math.Max(1f, runtimeFont.Size / 5f);
			if (runtimeFont.Bold)
			{
				num3 *= 2f;
			}
			if (string.Compare(string_2, "line:/", ignoreCase: true) == 0)
			{
				dcgraphics_0.DrawLine(Color, num3, rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom);
				return;
			}
			if (string.Compare(string_2, "line:\\", ignoreCase: true) == 0)
			{
				dcgraphics_0.DrawLine(Color, num3, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom);
				return;
			}
			if (string.Compare(string_2, "line:s", ignoreCase: true) == 0)
			{
				using (new Pen(Color, num3))
				{
					GraphicsPath graphicsPath = new GraphicsPath();
					graphicsPath.AddBezier(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top, rectangleF_0.Left - rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f, rectangleF_0.Right + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f, rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Bottom);
					if (!dcgraphics_0.IsPDFMode)
					{
						dcgraphics_0.DrawPath(Color, num3, graphicsPath);
					}
					else
					{
						graphicsPath.Flatten();
						PointF[] pathPoints = graphicsPath.PathPoints;
						dcgraphics_0.DrawLines(Color, num3, pathPoints);
					}
					graphicsPath.Dispose();
				}
				return;
			}
			SizeF sizeF = dcgraphics_0.MeasureString("HH", runtimeFont, 10000, DrawStringFormatExt.GenericDefault);
			float num4 = 0f;
			if (string_2.Length > 0)
			{
				num4 = sizeF.Height + (rectangleF_0.Height - sizeF.Height * (float)string_2.Length) / (float)(string_2.Length - 1);
			}
			for (int i = 0; i < string_2.Length; i++)
			{
				RectangleF layoutRectangle = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - sizeF.Width) / 2f, rectangleF_0.Top + num4 * (float)i, sizeF.Width, sizeF.Height);
				if (rectangleF_1.IsEmpty || layoutRectangle.IntersectsWith(rectangleF_1))
				{
					dcgraphics_0.DrawString(string_2[i].ToString(), runtimeFont, Color, layoutRectangle, StringAlignment.Center, StringAlignment.Near);
				}
			}
		}

		
		public DocumentTerminalTextInfo method_7()
		{
			DocumentTerminalTextInfo documentTerminalTextInfo = (DocumentTerminalTextInfo)MemberwiseClone();
			if (xfontValue_0 != null)
			{
				documentTerminalTextInfo.xfontValue_0 = xfontValue_0.Clone();
			}
			return documentTerminalTextInfo;
		}
	}
}
