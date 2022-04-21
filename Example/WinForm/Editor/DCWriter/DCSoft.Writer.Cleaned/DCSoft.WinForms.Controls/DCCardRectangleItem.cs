using DCSoft.Common;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       矩形的卡片内容项目
	///       </summary>
	[ComVisible(false)]
	
	public class DCCardRectangleItem : DCCardContentItem
	{
		private Color _BackColor = Color.Transparent;

		private static TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		private Color _BorderColor = Color.Black;

		private int _BorderWidth = 1;

		private DashStyle _BorderStyle = DashStyle.Solid;

		/// <summary>
		///       背景色
		///       </summary>
		[XmlIgnore]
		public Color BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}

		/// <summary>
		///       背景颜色值
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[Browsable(false)]
		public string BackColorValue
		{
			get
			{
				if (BackColor == Color.Transparent)
				{
					return null;
				}
				return typeConverter_0.ConvertToString(BackColor);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					BackColor = Color.Transparent;
				}
				else
				{
					BackColor = (Color)typeConverter_0.ConvertFromString(value);
				}
			}
		}

		/// <summary>
		///       边框色
		///       </summary>
		[XmlIgnore]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
			}
		}

		/// <summary>
		///       边框颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlAttribute]
		public string BorderColorValue
		{
			get
			{
				if (BorderColor == Color.Black)
				{
					return null;
				}
				return typeConverter_0.ConvertToString(BorderColor);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					BorderColor = Color.Black;
				}
				else
				{
					BorderColor = (Color)typeConverter_0.ConvertFromString(value);
				}
			}
		}

		[XmlAttribute]
		[DefaultValue(1)]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = value;
			}
		}

		[DefaultValue(DashStyle.Solid)]
		[XmlAttribute]
		public DashStyle BorderStyle
		{
			get
			{
				return _BorderStyle;
			}
			set
			{
				_BorderStyle = value;
			}
		}

		public override void OnPaint(DCCardContentItemPaintEventArgs args)
		{
			Rectangle viewBounds = args.ViewBounds;
			if (BackColor.A != 0)
			{
				using (SolidBrush brush = new SolidBrush(BackColor))
				{
					args.Graphics.FillRectangle(brush, viewBounds);
				}
			}
			if (BorderColor.A != 0 && BorderWidth > 0)
			{
				using (Pen pen = new Pen(BorderColor, BorderWidth))
				{
					viewBounds.Inflate(-BorderWidth, -BorderWidth);
					Rectangle rectangle = new Rectangle(viewBounds.Left + BorderWidth, viewBounds.Top + BorderWidth, viewBounds.Width - BorderWidth * 2, viewBounds.Height - BorderWidth * 2);
					args.Graphics.DrawRectangle(pen, viewBounds);
				}
			}
		}
	}
}
