using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       字符串的卡片内容
	///       </summary>
	
	[ComVisible(false)]
	public class DCCardStringItem : DCCardContentItem
	{
		private string _Text = null;

		private string _FontName = null;

		private float _FontSize = 9f;

		private FontStyle _FontStyle = FontStyle.Regular;

		private StringAlignment _Align = StringAlignment.Near;

		private StringAlignment _LineAlign = StringAlignment.Center;

		private Color _Color = Color.Black;

		private static TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		private bool _Multiline = false;

		[DefaultValue(null)]
		[XmlAttribute]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		[DefaultValue(null)]
		[XmlAttribute]
		public string FontName
		{
			get
			{
				return _FontName;
			}
			set
			{
				_FontName = value;
			}
		}

		[DefaultValue(9f)]
		[XmlAttribute]
		public float FontSize
		{
			get
			{
				return _FontSize;
			}
			set
			{
				_FontSize = value;
			}
		}

		[DefaultValue(FontStyle.Regular)]
		[XmlAttribute]
		public FontStyle FontStyle
		{
			get
			{
				return _FontStyle;
			}
			set
			{
				_FontStyle = value;
			}
		}

		[DefaultValue(StringAlignment.Near)]
		[XmlAttribute]
		public StringAlignment Align
		{
			get
			{
				return _Align;
			}
			set
			{
				_Align = value;
			}
		}

		[XmlAttribute]
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment LineAlign
		{
			get
			{
				return _LineAlign;
			}
			set
			{
				_LineAlign = value;
			}
		}

		[XmlIgnore]
		public Color Color
		{
			get
			{
				return _Color;
			}
			set
			{
				_Color = value;
			}
		}

		/// <summary>
		///       边框颜色值
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[Browsable(false)]
		public string ColorValue
		{
			get
			{
				if (Color == Color.Black)
				{
					return null;
				}
				return typeConverter_0.ConvertToString(Color);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					Color = Color.Black;
				}
				else
				{
					Color = (Color)typeConverter_0.ConvertFromString(value);
				}
			}
		}

		[DefaultValue(false)]
		[XmlAttribute]
		public bool Multiline
		{
			get
			{
				return _Multiline;
			}
			set
			{
				_Multiline = value;
			}
		}

		public override void OnPaint(DCCardContentItemPaintEventArgs args)
		{
			string text = Text;
			if (args.Value != null)
			{
				text = Convert.ToString(args.Value);
			}
			if (!string.IsNullOrEmpty(text))
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = Align;
					stringFormat.LineAlignment = LineAlign;
					if (!Multiline)
					{
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					}
					if (args.ListView != null && args.ListView.RightToLeft == RightToLeft.Yes)
					{
						stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
					}
					XFontValue xFontValue = new XFontValue(FontName, FontSize, FontStyle);
					SolidBrush brush = GClass438.smethod_0(Color);
					if (args.Highlight)
					{
						brush = GClass438.smethod_0(SystemColors.HighlightText);
					}
					args.Graphics.DrawString(text, xFontValue.Value, brush, new RectangleF(args.ViewBounds.Left, args.ViewBounds.Top, args.ViewBounds.Width, args.ViewBounds.Height), stringFormat);
				}
			}
		}
	}
}
