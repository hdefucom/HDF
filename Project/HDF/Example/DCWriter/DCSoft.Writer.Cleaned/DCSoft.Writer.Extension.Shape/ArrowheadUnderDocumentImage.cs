using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       指向下的箭头
	///       </summary>
	[ComVisible(false)]
	[ToolboxBitmap(typeof(ArrowheadUnderDocumentImage))]
	[DefaultProperty("Text")]
	public class ArrowheadUnderDocumentImage : IDocumentImage
	{
		private string _Text = null;

		private int _PolygonNumer = 7;

		/// <summary>
		///       文本
		///       </summary>
		[DefaultValue(null)]
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

		/// <summary>
		///       边数
		///       </summary>
		[DefaultValue(7)]
		public int PolygonNumer
		{
			get
			{
				return _PolygonNumer;
			}
			set
			{
				_PolygonNumer = value;
				if (_PolygonNumer < 3)
				{
					_PolygonNumer = 3;
				}
			}
		}

		/// <summary>
		///       返回标志位，此处声明自定义绘制背景
		///       </summary>
		public DocumentImageFlags ImageFlags => DocumentImageFlags.CustomBackground;

		public SizeF GetPreferredSize(DocumentPaintEventArgs args)
		{
			return SizeF.Empty;
		}

		/// <summary>
		///       创建多边形的顶点数组
		///       </summary>
		/// <param name="bounds">边界</param>
		/// <returns>创建的顶点数组</returns>
		private PointF[] GetPolygonPoints(RectangleF bounds)
		{
			PointF[] array = new PointF[PolygonNumer + 1];
			array[0].X = bounds.X + bounds.Width / 4f;
			array[0].Y = bounds.Y;
			array[1].X = bounds.X + bounds.Width / 4f * 3f;
			array[1].Y = bounds.Y;
			array[2].X = bounds.X + bounds.Width / 4f * 3f;
			array[2].Y = bounds.Y + bounds.Height / 2f;
			array[3].X = bounds.X + bounds.Width;
			array[3].Y = bounds.Y + bounds.Height / 2f;
			array[4].X = bounds.X + bounds.Width / 2f;
			array[4].Y = bounds.Y + bounds.Height;
			array[5].X = bounds.X;
			array[5].Y = bounds.Y + bounds.Height / 2f;
			array[6].X = bounds.X + bounds.Width / 4f;
			array[6].Y = bounds.Y + bounds.Height / 2f;
			array[7].X = bounds.X + bounds.Width / 4f;
			array[7].Y = bounds.Y;
			return array;
		}

		/// <summary>
		///       绘制对象图形
		///       </summary>
		/// <param name="args">
		/// </param>
		public void Draw(DocumentPaintEventArgs args)
		{
			PointF[] polygonPoints = GetPolygonPoints(args.ClientViewBounds);
			if (args.Style.HasVisibleBackground)
			{
				using (Brush brush = args.Style.CreateBackgroundBrush())
				{
					args.Graphics.FillPolygon(brush, polygonPoints);
				}
			}
			if (!string.IsNullOrEmpty(Text))
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					using (Brush brush = new SolidBrush(args.Style.Color))
					{
						args.Graphics.DrawString(Text, args.Style.Font.Value, brush, args.ClientViewBounds, stringFormat);
					}
				}
			}
			if (args.Style.HasVisibleBorder)
			{
				using (Pen pen_ = args.Style.CreateBorderPen())
				{
					args.Graphics.DrawPolygon(pen_, polygonPoints);
				}
			}
		}
	}
}
