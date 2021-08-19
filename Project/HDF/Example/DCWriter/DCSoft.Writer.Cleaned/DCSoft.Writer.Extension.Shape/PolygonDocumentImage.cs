using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       多边形图形
	///       </summary>
	[DefaultProperty("Text")]
	[ToolboxBitmap(typeof(PolygonDocumentImage))]
	[ComVisible(false)]
	public class PolygonDocumentImage : IDocumentImage
	{
		private string _Text = null;

		private int _PolygonNumer = 5;

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
		[DefaultValue(5)]
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
			double num = bounds.X + bounds.Width / 2f;
			double num2 = bounds.Y + bounds.Height / 2f;
			double num3 = (bounds.Width > bounds.Height) ? (bounds.Height / 2f) : (bounds.Width / 2f);
			double num4 = Math.PI * 2.0 / (double)PolygonNumer;
			PointF[] array = new PointF[PolygonNumer + 1];
			for (int i = 0; i < PolygonNumer; i++)
			{
				array[i].X = (float)(num + num3 * Math.Sin(num4 * (double)i + Math.PI));
				array[i].Y = (float)(num2 + num3 * Math.Cos(num4 * (double)i + Math.PI));
			}
			array[array.Length - 1].X = array[0].X;
			array[array.Length - 1].Y = array[0].Y;
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
