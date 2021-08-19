using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       五角星
	///       </summary>
	[ComVisible(false)]
	[DefaultProperty("Text")]
	[ToolboxBitmap(typeof(FivePointStarDocumentImage))]
	public class FivePointStarDocumentImage : IDocumentImage
	{
		private string _Text = null;

		private int _PolygonNumer = 10;

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
		[DefaultValue(10)]
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
			PointF[] array = new PointF[10];
			Point center = new Point(Convert.ToInt32(bounds.Width / 2f + bounds.X), Convert.ToInt32(bounds.Height / 2f + bounds.Y));
			int num = Convert.ToInt32(Math.Min(bounds.Height, bounds.Width) / 2f);
			array[0] = new Point(center.X, center.Y - num);
			array[1] = RotateTheta(array[0], center, 36.0);
			double num2 = (double)num * Math.Sin(Math.PI / 10.0) / Math.Sin(Math.PI * 7.0 / 10.0);
			array[1].X = (int)((double)center.X + num2 * (double)(array[1].X - (float)center.X) / (double)num);
			array[1].Y = (int)((double)center.Y + num2 * (double)(array[1].Y - (float)center.Y) / (double)num);
			for (int i = 1; i < 5; i++)
			{
				array[2 * i] = RotateTheta(array[2 * (i - 1)], center, 72.0);
				array[2 * i + 1] = RotateTheta(array[2 * i - 1], center, 72.0);
			}
			return array;
		}

		private PointF RotateTheta(PointF pointF_0, Point center, double theta)
		{
			int num = (int)((double)center.X + (double)(pointF_0.X - (float)center.X) * Math.Cos(theta * Math.PI / 180.0) - (double)(pointF_0.Y - (float)center.Y) * Math.Sin(theta * Math.PI / 180.0));
			int num2 = (int)((double)center.Y + (double)(pointF_0.X - (float)center.X) * Math.Sin(theta * Math.PI / 180.0) + (double)(pointF_0.Y - (float)center.Y) * Math.Cos(theta * Math.PI / 180.0));
			return new PointF(num, num2);
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
