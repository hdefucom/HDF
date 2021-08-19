using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       指向右的箭头
	///       </summary>
	[DefaultProperty("Text")]
	[ComVisible(false)]
	[ToolboxBitmap(typeof(ArrowheadRightDocumentImage))]
	public class ArrowheadRightDocumentImage : IDocumentImage
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

		/// <summary>
		///       获得对象推荐大小
		///       </summary>
		/// <param name="g">
		/// </param>
		/// <returns>
		/// </returns>
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
			array[0].X = bounds.X;
			array[0].Y = bounds.Y + bounds.Height / 4f;
			array[1].X = bounds.X + bounds.Width / 2f;
			array[1].Y = bounds.Y + bounds.Height / 4f;
			array[2].X = bounds.X + bounds.Width / 2f;
			array[2].Y = bounds.Y;
			array[3].X = bounds.X + bounds.Width;
			array[3].Y = bounds.Y + bounds.Height / 2f;
			array[4].X = bounds.X + bounds.Width / 2f;
			array[4].Y = bounds.Y + bounds.Height;
			array[5].X = bounds.X + bounds.Width / 2f;
			array[5].Y = bounds.Y + (bounds.Height - bounds.Height / 4f);
			array[6].X = bounds.X;
			array[6].Y = bounds.Y + (bounds.Height - bounds.Height / 4f);
			array[7].X = bounds.X;
			array[7].Y = bounds.Y + bounds.Height / 4f;
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
				args.Graphics.DrawString(Text, args.Style.Font, args.Style.Color, args.ClientViewBounds, StringAlignment.Center, StringAlignment.Center);
			}
			if (args.Style.HasVisibleBorder)
			{
				args.Graphics.DrawPolygon(args.Style.BorderTopColor, args.Style.BorderWidth, args.Style.BorderStyle, polygonPoints);
			}
		}
	}
}
