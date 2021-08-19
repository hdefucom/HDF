using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass331
	{
		public virtual void vmethod_0(float float_0, float float_1, GClass329 gclass329_0, ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			float runtimeControlPointSize = shapeRenderEventArgs_0.ViewOptions.RuntimeControlPointSize;
			RectangleF rect = new RectangleF(float_0 - runtimeControlPointSize / 2f, float_1 - runtimeControlPointSize / 2f, runtimeControlPointSize, runtimeControlPointSize);
			if (gclass329_0.method_8())
			{
				if (gclass329_0.method_6())
				{
					shapeRenderEventArgs_0.Graphics.FillRectangle(SystemColors.Highlight, rect);
					shapeRenderEventArgs_0.Graphics.DrawRectangle(SystemColors.HighlightText, rect.Left, rect.Top, rect.Width, rect.Height);
				}
				else
				{
					shapeRenderEventArgs_0.Graphics.FillRectangle(Color.White, rect);
					shapeRenderEventArgs_0.Graphics.DrawRectangle(Color.Black, rect.Left, rect.Top, rect.Width, rect.Height);
				}
			}
			else
			{
				shapeRenderEventArgs_0.Graphics.FillRectangle(Color.White, rect);
				shapeRenderEventArgs_0.Graphics.DrawRectangle(Color.Gray, rect.Left, rect.Top, rect.Width, rect.Height);
			}
		}

		public virtual void vmethod_1(ShapeElement shapeElement_0, ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			vmethod_2(shapeElement_0, shapeRenderEventArgs_0);
			shapeElement_0.vmethod_7(shapeRenderEventArgs_0);
			vmethod_3(shapeElement_0, shapeRenderEventArgs_0);
		}

		public virtual void vmethod_2(ShapeElement shapeElement_0, ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			ContentStyle runtimeStyle = shapeElement_0.RuntimeStyle;
			if (runtimeStyle.HasVisibleBackground)
			{
				GraphicsPath graphicsPath = shapeElement_0.vmethod_5();
				if (graphicsPath != null)
				{
					PointF absLocation = shapeElement_0.AbsLocation;
					using (Matrix matrix = new Matrix())
					{
						matrix.Translate(absLocation.X, absLocation.Y);
						graphicsPath.Transform(matrix);
					}
					using (Brush brush = runtimeStyle.method_8(shapeElement_0.Bounds, shapeElement_0.OwnerDocument.DocumentGraphicsUnit))
					{
						if (brush != null)
						{
							shapeRenderEventArgs_0.Graphics.FillPath(brush, graphicsPath);
						}
					}
					graphicsPath.Dispose();
				}
			}
		}

		public virtual void vmethod_3(ShapeElement shapeElement_0, ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			GraphicsPath graphicsPath = shapeElement_0.vmethod_5();
			if (graphicsPath != null)
			{
				using (Matrix matrix = new Matrix())
				{
					PointF absLocation = shapeElement_0.AbsLocation;
					matrix.Translate(absLocation.X, absLocation.Y);
					graphicsPath.Transform(matrix);
				}
				ContentStyle runtimeStyle = shapeElement_0.RuntimeStyle;
				if (runtimeStyle.HasVisibleBorder)
				{
					shapeRenderEventArgs_0.Graphics.DrawPath(runtimeStyle.BorderTopColor, runtimeStyle.BorderWidth, runtimeStyle.BorderStyle, graphicsPath);
				}
				else if (shapeRenderEventArgs_0.Document.EditMode)
				{
					shapeRenderEventArgs_0.Graphics.DrawPath(shapeRenderEventArgs_0.ViewOptions.NoneBorder, graphicsPath);
				}
				graphicsPath.Dispose();
			}
		}
	}
}
