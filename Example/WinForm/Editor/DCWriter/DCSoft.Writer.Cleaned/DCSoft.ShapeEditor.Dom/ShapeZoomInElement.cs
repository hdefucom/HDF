using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       局部放大视图元素
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeZoomInElement : ShapeRectangleElement
	{
		private float float_4 = 2f;

		private bool bool_4 = false;

		/// <summary>
		///       放大比率
		///       </summary>
		[DefaultValue(2f)]
		public float ZoomInRate
		{
			get
			{
				return float_4;
			}
			set
			{
				float_4 = value;
			}
		}

		/// <summary>
		///       是否采用平滑放大效果
		///       </summary>
		[DefaultValue(false)]
		public bool SmoothZoomIn
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		public override void vmethod_7(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			ShapeDocumentImagePage shapeDocumentImagePage = base.OwnerPage as ShapeDocumentImagePage;
			if (shapeDocumentImagePage == null)
			{
				return;
			}
			XImageValue image = shapeDocumentImagePage.Image;
			if (image == null || image.Value == null)
			{
				return;
			}
			RectangleF absBounds = shapeDocumentImagePage.AbsBounds;
			RectangleF absBounds2 = AbsBounds;
			RectangleF descRect = RectangleF.Intersect(absBounds2, absBounds);
			if (descRect.IsEmpty)
			{
				return;
			}
			RectangleF b = absBounds2;
			if (ZoomInRate >= 1f)
			{
				b.Width = absBounds2.Width / ZoomInRate;
				b.Height = absBounds2.Height / ZoomInRate;
				b.X = absBounds2.Left + absBounds2.Width / 2f - b.Width / 2f;
				b.Y = absBounds2.Top + absBounds2.Height / 2f - b.Height / 2f;
			}
			b = RectangleF.Intersect(absBounds, b);
			if (!b.IsEmpty)
			{
				b = RectangleCommon.ZoomRectangleF(b, absBounds.X, absBounds.Y, (float)image.Width / absBounds.Width, (float)image.Height / absBounds.Height);
				b.Offset(0f - absBounds.X, 0f - absBounds.Y);
				if (SmoothZoomIn)
				{
					shapeRenderEventArgs_0.Graphics.DrawImage(image.Value, descRect, b, GraphicsUnit.Pixel);
					return;
				}
				PixelOffsetMode pixelOffsetMode = shapeRenderEventArgs_0.Graphics.PixelOffsetMode;
				InterpolationMode interpolationMode = shapeRenderEventArgs_0.Graphics.InterpolationMode;
				shapeRenderEventArgs_0.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				shapeRenderEventArgs_0.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
				shapeRenderEventArgs_0.Graphics.DrawImage(image.Value, descRect, b, GraphicsUnit.Pixel);
				shapeRenderEventArgs_0.Graphics.InterpolationMode = interpolationMode;
				shapeRenderEventArgs_0.Graphics.PixelOffsetMode = pixelOffsetMode;
			}
		}
	}
}
