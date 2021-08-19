using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Shape
{
	/// <summary>
	///       多边形图形
	///       </summary>
	[ComVisible(false)]
	[ToolboxItem(false)]
	[DefaultProperty("Text")]
	public class ShapeDocumentImageBase : IDocumentImage
	{
		/// <summary>
		///       图形类型
		///       </summary>
		internal GEnum0 _ShapeType = GEnum0.const_1;

		private string _Text = null;

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
		///       绘制对象图形
		///       </summary>
		/// <param name="args">
		/// </param>
		public void Draw(DocumentPaintEventArgs args)
		{
			RectangleF clientViewBounds = args.ClientViewBounds;
			clientViewBounds.X += args.Style.BorderWidth;
			clientViewBounds.Y += args.Style.BorderWidth;
			clientViewBounds.Width -= args.Style.BorderWidth * 2f;
			clientViewBounds.Height -= args.Style.BorderWidth * 2f;
			switch (_ShapeType)
			{
			case GEnum0.const_0:
				if (args.Style.HasVisibleBackground)
				{
					using (XBrushStyle brush = args.Style.CreateBackgroundBrush2())
					{
						args.Graphics.FillEllipse(brush, clientViewBounds);
					}
				}
				DrawText(args, clientViewBounds);
				if (args.Style.HasVisibleBorder)
				{
					using (args.Style.CreateBorderPen())
					{
						args.Graphics.DrawEllipse(args.Style.BorderTopColor, args.Style.BorderWidth, args.Style.BorderStyle, clientViewBounds);
					}
				}
				break;
			case GEnum0.const_1:
				if (args.Style.HasVisibleBackground)
				{
					using (XBrushStyle brush = args.Style.CreateBackgroundBrush2())
					{
						args.Graphics.FillRectangle(brush, clientViewBounds);
					}
				}
				DrawText(args, clientViewBounds);
				if (args.Style.HasVisibleBorder)
				{
					args.Graphics.DrawRectangle(args.Style.BorderTopColor, args.Style.BorderWidth, args.Style.BorderStyle, clientViewBounds.Left, clientViewBounds.Top, clientViewBounds.Width, clientViewBounds.Height);
				}
				break;
			}
		}

		/// <summary>
		///       绘制文字
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="bounds">
		/// </param>
		private void DrawText(DocumentPaintEventArgs args, RectangleF bounds)
		{
			if (!string.IsNullOrEmpty(Text))
			{
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					args.Graphics.DrawString(Text, args.Style.Font, args.Style.Color, bounds, drawStringFormatExt);
				}
			}
		}
	}
}
