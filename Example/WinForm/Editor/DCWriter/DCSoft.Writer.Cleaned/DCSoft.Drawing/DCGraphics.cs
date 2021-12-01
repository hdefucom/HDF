using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Drawing
{
	/// <summary>
	///       画布对象
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class DCGraphics : IDisposable
	{
		private enum DCMetaRecordType
		{
			None,
			SolidBrush,
			TextureBrush,
			Image,
			HatchBrush,
			PageUnit,
			SmoothingMode,
			DrawEllipse,
			Pen,
			DrawImageUnscaled,
			DrawLine
		}

		private Graphics graphics_0;

		private GClass519 gclass519_0;

		private GraphicsUnit graphicsUnit_0;

		private Matrix matrix_0;

		private static Graphics graphics_1 = null;

		private GClass375 gclass375_0;

		private GClass378 gclass378_0;

		private DCGraphics dcgraphics_0;

		private bool bool_0;

		private DCGraphicsLogType dcgraphicsLogType_0;

		private Stream stream_0;

		/// <summary>
		///       原始的画布对象
		///       </summary>
		[DCInternal]
		public Graphics NativeGraphics => graphics_0;

		[DCInternal]
		public bool IsPDFMode => gclass519_0 != null;

		[DCInternal]
		public Region Clip
		{
			get
			{
				if (gclass519_0 != null)
				{
					return gclass519_0.method_4();
				}
				if (graphics_0 != null)
				{
					return graphics_0.Clip;
				}
				return null;
			}
			set
			{
				if (gclass519_0 != null)
				{
					gclass519_0.method_5(value);
				}
				if (graphics_0 != null)
				{
					graphics_0.Clip = value;
				}
			}
		}

		public PixelOffsetMode PixelOffsetMode
		{
			get
			{
				if (graphics_0 == null)
				{
					return PixelOffsetMode.Default;
				}
				return graphics_0.PixelOffsetMode;
			}
			set
			{
				if (graphics_0 != null)
				{
					graphics_0.PixelOffsetMode = value;
				}
			}
		}

		public TextRenderingHint TextRenderingHint
		{
			get
			{
				if (graphics_0 == null)
				{
					return TextRenderingHint.SystemDefault;
				}
				return graphics_0.TextRenderingHint;
			}
			set
			{
				if (graphics_0 != null)
				{
					graphics_0.TextRenderingHint = value;
				}
			}
		}

		public InterpolationMode InterpolationMode
		{
			get
			{
				if (graphics_0 == null)
				{
					return InterpolationMode.Default;
				}
				return graphics_0.InterpolationMode;
			}
			set
			{
				if (graphics_0 != null)
				{
					graphics_0.InterpolationMode = value;
				}
			}
		}

		/// <summary>
		///       快速获取度量单位
		///       </summary>
		public GraphicsUnit PageUnitFast => graphicsUnit_0;

		public GraphicsUnit PageUnit
		{
			get
			{
				if (gclass519_0 != null)
				{
					return gclass519_0.method_6();
				}
				if (graphics_0 == null)
				{
					return GraphicsUnit.Pixel;
				}
				return graphics_0.PageUnit;
			}
			set
			{
				if (gclass519_0 != null)
				{
					gclass519_0.method_7(value);
				}
				if (graphics_0 != null)
				{
					graphics_0.PageUnit = value;
				}
				graphicsUnit_0 = value;
				if (gclass378_0 != null)
				{
					method_12(DCMetaRecordType.PageUnit);
					gclass378_0.method_13((int)value);
				}
			}
		}

		public SmoothingMode SmoothingMode
		{
			get
			{
				if (graphics_0 == null)
				{
					return SmoothingMode.Default;
				}
				return graphics_0.SmoothingMode;
			}
			set
			{
				if (graphics_0 != null)
				{
					graphics_0.SmoothingMode = value;
				}
				if (gclass378_0 != null)
				{
					method_12(DCMetaRecordType.SmoothingMode);
					gclass378_0.method_13((int)value);
				}
			}
		}

		public float DpiX
		{
			get
			{
				if (graphics_0 == null)
				{
					return 96f;
				}
				return graphics_0.DpiX;
			}
		}

		public float DpiY
		{
			get
			{
				if (graphics_0 == null)
				{
					return 96f;
				}
				return graphics_0.DpiY;
			}
		}

		public Matrix Transform
		{
			get
			{
				if (graphics_0 != null)
				{
					return graphics_0.Transform;
				}
				if (gclass519_0 != null)
				{
					if (matrix_0 == null)
					{
						matrix_0 = new Matrix();
					}
					return matrix_0;
				}
				return null;
			}
			set
			{
				if (gclass519_0 != null)
				{
					matrix_0 = value;
				}
				if (graphics_0 != null)
				{
					graphics_0.Transform = value;
				}
			}
		}

		[DCInternal]
		public Graphics GraphisForMeasure
		{
			get
			{
				if (graphics_0 != null)
				{
					return graphics_0;
				}
				if (gclass519_0 != null)
				{
					if (graphics_1 == null)
					{
						Bitmap image = new Bitmap(1, 1);
						graphics_1 = Graphics.FromImage(image);
					}
					graphics_1.PageUnit = gclass519_0.method_6();
					return graphics_1;
				}
				return null;
			}
		}

		/// <summary>
		///       是否自动销毁掉底层的画布对象
		///       </summary>
		[DCInternal]
		public bool AutoDisposeNativeGraphics
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       内容记录类型
		///       </summary>
		[DCInternal]
		public DCGraphicsLogType LogType
		{
			get
			{
				return dcgraphicsLogType_0;
			}
			set
			{
				dcgraphicsLogType_0 = value;
			}
		}

		/// <summary>
		///       记录内容使用的流对象
		///       </summary>
		[DCInternal]
		public Stream LogStream
		{
			get
			{
				return stream_0;
			}
			set
			{
				stream_0 = value;
			}
		}

		[DCInternal]
		public static DCGraphics smethod_0(Image image_0)
		{
			DCGraphics dCGraphics = new DCGraphics(Graphics.FromImage(image_0));
			dCGraphics.AutoDisposeNativeGraphics = true;
			return dCGraphics;
		}

		private DCGraphics()
		{
			graphics_0 = null;
			gclass519_0 = null;
			graphicsUnit_0 = GraphicsUnit.Document;
			matrix_0 = null;
			gclass375_0 = null;
			gclass378_0 = null;
			dcgraphics_0 = null;
			bool_0 = false;
			dcgraphicsLogType_0 = DCGraphicsLogType.None;
			stream_0 = null;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="g">
		/// </param>
		public DCGraphics(Graphics graphics_2)
		{
			int num = 18;
			graphics_0 = null;
			gclass519_0 = null;
			graphicsUnit_0 = GraphicsUnit.Document;
			matrix_0 = null;
			gclass375_0 = null;
			gclass378_0 = null;
			dcgraphics_0 = null;
			bool_0 = false;
			dcgraphicsLogType_0 = DCGraphicsLogType.None;
			stream_0 = null;
			
			if (graphics_2 == null)
			{
				throw new ArgumentNullException("g");
			}
			graphics_0 = graphics_2;
			graphicsUnit_0 = graphics_2.PageUnit;
		}

		[DCInternal]
		public static DCGraphics smethod_1(GClass519 gclass519_1)
		{
			DCGraphics dCGraphics = new DCGraphics();
			dCGraphics.gclass519_0 = gclass519_1;
			dCGraphics.graphicsUnit_0 = gclass519_1.method_6();
			return dCGraphics;
		}

		[DCInternal]
		public void ResetClip()
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_5(null);
			}
			else if (graphics_0 != null)
			{
				graphics_0.ResetClip();
			}
		}

		/// <summary>
		///       获得字体高度
		///       </summary>
		/// <param name="font">
		/// </param>
		/// <returns>
		/// </returns>
		public float GetFontHeight(Font font)
		{
			if (graphics_0 != null)
			{
				return font.GetHeight(graphics_0);
			}
			if (GraphisForMeasure != null)
			{
				return font.GetHeight(GraphisForMeasure);
			}
			return font.GetHeight(DpiY);
		}

		/// <summary>
		///       获得字体高度
		///       </summary>
		/// <param name="font">
		/// </param>
		/// <returns>
		/// </returns>
		public float GetFontHeight(XFontValue font)
		{
			int num = 17;
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			return GetFontHeight(font.Value);
		}

		public void TransformPoints(PointF[] pointF_0)
		{
			Transform.TransformPoints(pointF_0);
		}

		public void TranslateTransform(float float_0, float float_1, MatrixOrder order)
		{
			if (gclass519_0 != null)
			{
				Transform.Translate(float_0, float_1, order);
			}
			else if (graphics_0 != null)
			{
				graphics_0.TranslateTransform(float_0, float_1, order);
			}
		}

		public void ResetTransform()
		{
			if (gclass519_0 != null)
			{
				Transform.Reset();
			}
			else if (graphics_0 != null)
			{
				graphics_0.ResetTransform();
			}
		}

		public void RotateTransform(float angle)
		{
			if (gclass519_0 != null)
			{
				Transform.Rotate(angle);
			}
			else if (graphics_0 != null)
			{
				graphics_0.RotateTransform(angle);
			}
		}

		public void TranslateTransform(float float_0, float float_1)
		{
			if (gclass519_0 != null)
			{
				Transform.Translate(float_0, float_1);
			}
			else if (graphics_0 != null)
			{
				graphics_0.TranslateTransform(float_0, float_1);
			}
		}

		public void ScaleTransform(float float_0, float float_1)
		{
			if (gclass519_0 != null)
			{
				Transform.Scale(float_0, float_1);
			}
			else if (graphics_0 != null)
			{
				graphics_0.ScaleTransform(float_0, float_1);
			}
		}

		public void DrawPolygon(Color color_0, PointF[] pointF_0)
		{
			DrawPolygon(GClass438.smethod_1(color_0), pointF_0);
		}

		public void DrawPolygon(Color color_0, float lineWidth, PointF[] pointF_0)
		{
			using (Pen pen_ = new Pen(color_0, lineWidth))
			{
				DrawPolygon(pen_, pointF_0);
			}
		}

		public void DrawPolygon(Color color_0, float lineWidth, DashStyle lineStyle, PointF[] pointF_0)
		{
			using (Pen pen = new Pen(color_0, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawPolygon(pen, pointF_0);
			}
		}

		public void DrawPolygon(Pen pen_0, PointF[] pointF_0)
		{
			if (graphics_0 != null)
			{
				graphics_0.DrawPolygon(pen_0, pointF_0);
			}
		}

		public void DrawEllipse(Color color_0, RectangleF rect)
		{
			DrawEllipse(GClass438.smethod_1(color_0), rect);
		}

		public void DrawEllipse(Color color_0, float lineWidth, RectangleF rect)
		{
			using (Pen pen_ = new Pen(color_0, lineWidth))
			{
				DrawEllipse(pen_, rect);
			}
		}

		public void DrawEllipse(Color color_0, float lineWidth, DashStyle lineStyle, RectangleF rect)
		{
			using (Pen pen = new Pen(color_0, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawEllipse(pen, rect);
			}
		}

		public void DrawEllipse(Pen pen_0, RectangleF rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_47(pen_0, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawEllipse(pen_0, rect);
			}
			if (gclass378_0 != null)
			{
				method_12(DCMetaRecordType.DrawEllipse);
				method_9(pen_0);
				gclass378_0.method_18(rect.Left);
				gclass378_0.method_18(rect.Top);
				gclass378_0.method_18(rect.Width);
				gclass378_0.method_18(rect.Height);
			}
		}

		public void DrawImageUnscaledAndClipped(Image image_0, Rectangle rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_57(image_0, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawImageUnscaledAndClipped(image_0, rect);
			}
		}

		public void DrawImage(Image image_0, float float_0, float float_1)
		{
			if (gclass519_0 != null)
			{
				float width = GraphicsUnitConvert.Convert(image_0.Width, GraphicsUnit.Pixel, gclass519_0.method_6());
				float height = GraphicsUnitConvert.Convert(image_0.Height, GraphicsUnit.Pixel, gclass519_0.method_6());
				gclass519_0.method_57(image_0, new RectangleF(float_0, float_1, width, height));
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawImage(image_0, float_0, float_1);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(image_0);
			}
		}

		[DCInternal]
		public void method_0(Image image_0, RectangleF rectangleF_0, bool bool_1)
		{
			if (gclass519_0 != null)
			{
				_ = (float)GraphicsUnitConvert.Convert(image_0.Width, GraphicsUnit.Pixel, gclass519_0.method_6());
				_ = (float)GraphicsUnitConvert.Convert(image_0.Height, GraphicsUnit.Pixel, gclass519_0.method_6());
				gclass519_0.method_58(image_0, rectangleF_0, bool_1);
			}
		}

		public void DrawImage(Image image_0, RectangleF rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_57(image_0, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawImage(image_0, rect);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(image_0);
			}
		}

		public void DrawImage(Image image_0, RectangleF descRect, RectangleF sourceRect, GraphicsUnit unit)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_57(image_0, descRect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawImage(image_0, descRect, sourceRect, unit);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(image_0);
			}
		}

		public void DrawImage(Image image_0, float float_0, float float_1, float width, float height)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_57(image_0, new RectangleF(float_0, float_1, width, height));
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawImage(image_0, float_0, float_1, width, height);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(image_0);
			}
		}

		public void DrawImageUnscaled(Image image, int int_0, int int_1)
		{
			if (gclass519_0 != null)
			{
				DrawImage(image, int_0, int_1);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawImageUnscaled(image, int_0, int_1);
			}
			if (gclass378_0 != null)
			{
				method_12(DCMetaRecordType.DrawImageUnscaled);
				gclass378_0.method_13(int_0);
				gclass378_0.method_13(int_1);
				method_8(image);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(image);
			}
		}

		public void DrawLine(Pen pen_0, PointF pointF_0, PointF pointF_1)
		{
			DrawLine(pen_0, pointF_0.X, pointF_0.Y, pointF_1.X, pointF_1.Y);
		}

		public void DrawLine(Color color_0, PointF pointF_0, PointF pointF_1)
		{
			DrawLine(GClass438.smethod_1(color_0), pointF_0.X, pointF_0.Y, pointF_1.X, pointF_1.Y);
		}

		public void DrawLine(Color color_0, float lineWidth, PointF pointF_0, PointF pointF_1)
		{
			using (Pen pen_ = new Pen(color_0, lineWidth))
			{
				DrawLine(pen_, pointF_0, pointF_1);
			}
		}

		public void DrawLine(Color color_0, float lineWidth, DashStyle lineStyle, PointF pointF_0, PointF pointF_1)
		{
			using (Pen pen = new Pen(color_0, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawLine(pen, pointF_0, pointF_1);
			}
		}

		public void DrawLine(Color color_0, float float_0, float float_1, float float_2, float float_3)
		{
			DrawLine(GClass438.smethod_1(color_0), float_0, float_1, float_2, float_3);
		}

		public void DrawLine(Pen pen_0, float float_0, float float_1, float float_2, float float_3)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_56(pen_0, float_0, float_1, float_2, float_3);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawLine(pen_0, float_0, float_1, float_2, float_3);
			}
			if (gclass378_0 != null)
			{
				method_12(DCMetaRecordType.DrawLine);
				method_9(pen_0);
				gclass378_0.method_18(float_0);
				gclass378_0.method_18(float_1);
				gclass378_0.method_18(float_2);
				gclass378_0.method_18(float_3);
			}
		}

		public void DrawLine(Pen pen_0, int int_0, int int_1, int int_2, int int_3)
		{
			DrawLine(pen_0, (float)int_0, (float)int_1, (float)int_2, (float)int_3);
		}

		public void DrawLines(XPenStyle xpenStyle_0, PointF[] points)
		{
			DrawLines(xpenStyle_0.Value, points);
		}

		public void DrawLines(Color color_0, PointF[] points)
		{
			DrawLines(GClass438.smethod_1(color_0), points);
		}

		public void DrawLines(Color lineColor, float lineWidth, PointF[] points)
		{
			using (Pen pen_ = new Pen(lineColor, lineWidth))
			{
				DrawLines(pen_, points);
			}
		}

		public void DrawLines(Color lineColor, float lineWidth, DashStyle lineStyle, PointF[] points)
		{
			using (Pen pen = new Pen(lineColor, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawLines(pen, points);
			}
		}

		public void DrawLines(Pen pen_0, PointF[] points)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_54(pen_0, points);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawLines(pen_0, points);
			}
		}

		public void DrawLine(XPenStyle xpenStyle_0, PointF pointF_0, PointF pointF_1)
		{
			DrawLine(xpenStyle_0, pointF_0.X, pointF_0.Y, pointF_1.X, pointF_1.Y);
		}

		public void DrawLine(Color color, float width, DashStyle lineStyle, float float_0, float float_1, float float_2, float float_3)
		{
			using (Pen pen = new Pen(color, width))
			{
				pen.DashStyle = lineStyle;
				DrawLine(pen, float_0, float_1, float_2, float_3);
			}
		}

		public void DrawLine(Color color, float width, float float_0, float float_1, float float_2, float float_3)
		{
			using (Pen pen_ = new Pen(color, width))
			{
				DrawLine(pen_, float_0, float_1, float_2, float_3);
			}
		}

		public void DrawLine(XPenStyle xpenStyle_0, float float_0, float float_1, float float_2, float float_3)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_56(xpenStyle_0.Value, float_0, float_1, float_2, float_3);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawLine(xpenStyle_0.Value, float_0, float_1, float_2, float_3);
			}
			if (gclass378_0 != null)
			{
				method_12(DCMetaRecordType.DrawLine);
				method_9(xpenStyle_0.Value);
				gclass378_0.method_18(float_0);
				gclass378_0.method_18(float_1);
				gclass378_0.method_18(float_2);
				gclass378_0.method_18(float_3);
			}
		}

		public void DrawLine(XPenStyle xpenStyle_0, int int_0, int int_1, int int_2, int int_3)
		{
			DrawLine(xpenStyle_0, (float)int_0, (float)int_1, (float)int_2, (float)int_3);
		}

		public void FillPolygon(Color color, PointF[] points)
		{
			FillPolygon(GClass438.smethod_0(color), points);
		}

		public void FillPolygon(Brush brush, PointF[] points)
		{
			if (gclass519_0 == null)
			{
			}
			if (graphics_0 != null)
			{
				graphics_0.FillPolygon(brush, points);
			}
		}

		public void FillPolygon(XBrushStyle brush, PointF[] points)
		{
			if (gclass519_0 == null)
			{
			}
			if (graphics_0 != null)
			{
				using (Brush brush2 = brush.method_0())
				{
					graphics_0.FillPolygon(brush2, points);
				}
			}
		}

		public void DrawRectangle(Color color_0, RectangleF rect)
		{
			DrawRectangle(GClass438.smethod_1(color_0), rect);
		}

		public void DrawRectangle(Color color_0, float lineWidth, RectangleF rect)
		{
			using (Pen pen_ = new Pen(color_0, lineWidth))
			{
				DrawRectangle(pen_, rect);
			}
		}

		public void DrawRectangle(Color color_0, float lineWidth, DashStyle lineStyle, RectangleF rect)
		{
			using (Pen pen = new Pen(color_0, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawRectangle(pen, rect);
			}
		}

		public void DrawRectangle(Color color, float float_0, float float_1, float width, float height)
		{
			using (Pen pen_ = new Pen(color))
			{
				DrawRectangle(pen_, float_0, float_1, width, height);
			}
		}

		public void DrawRectangle(Color color, float lineWidth, float float_0, float float_1, float width, float height)
		{
			using (Pen pen_ = new Pen(color, lineWidth))
			{
				DrawRectangle(pen_, float_0, float_1, width, height);
			}
		}

		public void DrawRectangle(Color color, float lineWidth, DashStyle lineStyle, float float_0, float float_1, float width, float height)
		{
			using (Pen pen = new Pen(color, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawRectangle(pen, float_0, float_1, width, height);
			}
		}

		public void DrawRectangle(Pen pen_0, float float_0, float float_1, float width, float height)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_46(pen_0, float_0, float_1, width, height);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawRectangle(pen_0, float_0, float_1, width, height);
			}
		}

		public void DrawRectangle(Pen pen_0, Rectangle rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_45(pen_0, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawRectangle(pen_0, rect);
			}
		}

		public void DrawRectangle(Pen pen_0, RectangleF rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_45(pen_0, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawRectangle(pen_0, rect.Left, rect.Top, rect.Width, rect.Height);
			}
		}

		public void DrawRectangle(XPenStyle xpenStyle_0, float float_0, float float_1, float width, float height)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_46(xpenStyle_0.Value, float_0, float_1, width, height);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawRectangle(xpenStyle_0.Value, float_0, float_1, width, height);
			}
		}

		public void DrawRectangle(XPenStyle xpenStyle_0, Rectangle rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_45(xpenStyle_0.Value, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawRectangle(xpenStyle_0.Value, rect);
			}
		}

		public void DrawRectangle(XPenStyle xpenStyle_0, RectangleF rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_45(xpenStyle_0.Value, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawRectangle(xpenStyle_0.Value, rect.Left, rect.Top, rect.Width, rect.Height);
			}
		}

		public void DrawString(string string_0, XFontValue font, Color color, RectangleF layoutRectangle, StringAlignment alignment, StringAlignment lineAlignment)
		{
			DrawString(string_0, font, color, layoutRectangle, alignment, lineAlignment, noWrap: true);
		}

		public void DrawString(string string_0, XFontValue font, Color color, RectangleF layoutRectangle, StringAlignment alignment, StringAlignment lineAlignment, bool noWrap)
		{
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = alignment;
				stringFormat.LineAlignment = lineAlignment;
				if (noWrap)
				{
					stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
				}
				DrawString(string_0, font.Value, GClass438.smethod_0(color), layoutRectangle, stringFormat);
			}
		}

		public void DrawString(string string_0, Font font, Brush brush, RectangleF layoutRectangle, StringFormat format)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_53(string_0, font, brush, layoutRectangle, format);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawString(string_0, font, brush, layoutRectangle, format);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(string_0);
			}
		}

		public void method_1(string string_0, XFontValue xfontValue_0, Rectangle rectangle_0, Color color_0, TextFormatFlags textFormatFlags_0)
		{
			if (graphics_0 != null)
			{
				TextRenderer.DrawText(graphics_0, string_0, xfontValue_0.Value, rectangle_0, color_0, textFormatFlags_0);
			}
		}

		public void DrawString(string string_0, XFontValue font, Color color_0, RectangleF rect, DrawStringFormatExt format)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_53(string_0, font.Value, GClass438.smethod_0(color_0), rect, format.Value);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawString(string_0, font.Value, GClass438.smethod_0(color_0), rect, format.Value);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(string_0);
			}
		}

		public void DrawString(string string_0, XFontValue font, Color color_0, float float_0, float float_1, DrawStringFormatExt format)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_53(string_0, font.Value, GClass438.smethod_0(color_0), new RectangleF(float_0, float_1, 10000f, 1000f), format.Value);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawString(string_0, font.Value, GClass438.smethod_0(color_0), float_0, float_1, format.Value);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(string_0);
			}
		}

		public void DrawString(string string_0, Font font, Brush brush, float float_0, float float_1, StringFormat format)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_53(string_0, font, brush, new RectangleF(float_0, float_1, 10000f, 1000f), format);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawString(string_0, font, brush, float_0, float_1, format);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(string_0);
			}
		}

		public void DrawString(string string_0, XFontValue font, Color color_0, float float_0, float float_1)
		{
			DrawString(string_0, font.Value, GClass438.smethod_0(color_0), float_0, float_1);
		}

		public void DrawString(string string_0, Font font, Brush brush, float float_0, float float_1)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_53(string_0, font, brush, new RectangleF(float_0, float_1, 10000f, 1000f), StringFormat.GenericDefault);
			}
			if (graphics_0 != null)
			{
				graphics_0.DrawString(string_0, font, brush, float_0, float_1);
			}
			if (LogType == DCGraphicsLogType.Content)
			{
				LogContent(string_0);
			}
		}

		public void method_2(string string_0, DrawStringFormatExt drawStringFormatExt_0)
		{
			int num = 11;
			if (drawStringFormatExt_0 == null)
			{
				throw new ArgumentNullException("format");
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				using (StringFormat stringFormat = drawStringFormatExt_0.CreateStringFormat())
				{
					SolidBrush solidBrush = GClass438.smethod_0(drawStringFormatExt_0.Color);
					XFontValue xFontValue = drawStringFormatExt_0.Font;
					if (xFontValue == null)
					{
						xFontValue = new XFontValue();
					}
					if (gclass519_0 != null)
					{
						gclass519_0.method_53(string_0, xFontValue.Value, solidBrush, new RectangleF(drawStringFormatExt_0.Left, drawStringFormatExt_0.Top, drawStringFormatExt_0.Width, drawStringFormatExt_0.Height), stringFormat);
					}
					if (graphics_0 != null)
					{
						graphics_0.DrawString(string_0, xFontValue.Value, solidBrush, new RectangleF(drawStringFormatExt_0.Left, drawStringFormatExt_0.Top, drawStringFormatExt_0.Width, drawStringFormatExt_0.Height), stringFormat);
					}
					if (LogType == DCGraphicsLogType.Content)
					{
						LogContent(string_0);
					}
				}
			}
		}

		public SizeF MeasureString(string text, Font font, int width, StringFormat format)
		{
			return GraphisForMeasure.MeasureString(text, font, width, format);
		}

		public SizeF MeasureString(string text, XFontValue font, int width, DrawStringFormatExt format)
		{
			using (StringFormat format2 = format.CreateStringFormat())
			{
				return GraphisForMeasure.MeasureString(text, font.Value, width, format2);
			}
		}

		public SizeF MeasureString(string text, XFontValue font)
		{
			return GraphisForMeasure.MeasureString(text, font.Value);
		}

		public SizeF MeasureString(string text, Font font)
		{
			return GraphisForMeasure.MeasureString(text, font);
		}

		public void FillRectangle(XBrushStyle brush, RectangleF rect)
		{
			using (Brush brush2 = brush.method_0())
			{
				FillRectangle(brush2, rect.Left, rect.Top, rect.Width, rect.Height);
			}
		}

		public void FillRectangle(XBrushStyle brush, Rectangle rect)
		{
			using (Brush brush2 = brush.method_0())
			{
				FillRectangle(brush2, rect.Left, rect.Top, rect.Width, rect.Height);
			}
		}

		public void FillRectangle(Brush brush, RectangleF rect)
		{
			FillRectangle(brush, rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void method_3(Brush brush_0, Rectangle rectangle_0)
		{
			FillRectangle(brush_0, rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
		}

		public void FillRectangle(Brush brush, float float_0, float float_1, float width, float height)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_50(brush, float_0, float_1, width, height);
			}
			if (graphics_0 != null)
			{
				graphics_0.FillRectangle(brush, float_0, float_1, width, height);
			}
		}

		public void FillRectangle(Color color_0, RectangleF rect)
		{
			FillRectangle(color_0, rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void method_4(Color color_0, Rectangle rectangle_0)
		{
			FillRectangle(color_0, rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
		}

		public void FillRectangle(Color color, float float_0, float float_1, float width, float height)
		{
			Brush brush = GClass438.smethod_0(color);
			if (gclass519_0 != null)
			{
				gclass519_0.method_50(brush, float_0, float_1, width, height);
			}
			if (graphics_0 != null)
			{
				graphics_0.FillRectangle(brush, float_0, float_1, width, height);
			}
		}

		public void DrawRoundRectangle(Color color, float lineWidth, RectangleF bounds, float radio)
		{
			if (graphics_0 != null)
			{
				using (Pen pen = new Pen(color, lineWidth))
				{
					using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(bounds, radio))
					{
						graphics_0.DrawPath(pen, path);
					}
				}
			}
		}

		public void DrawRoundRectangle(Color color, RectangleF bounds, float radio)
		{
			if (graphics_0 != null)
			{
				Pen pen = GClass438.smethod_1(color);
				using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(bounds, radio))
				{
					graphics_0.DrawPath(pen, path);
				}
			}
		}

		/// <summary>
		///       绘制圆角矩形
		///       </summary>
		/// <param name="p">
		/// </param>
		/// <param name="left">
		/// </param>
		/// <param name="top">
		/// </param>
		/// <param name="width">
		/// </param>
		/// <param name="height">
		/// </param>
		/// <param name="radio">
		/// </param>
		public void DrawRoundRectangle(XPenStyle xpenStyle_0, RectangleF bounds, float radio)
		{
			DrawRoundRectangle(xpenStyle_0, bounds.Left, bounds.Top, bounds.Width, bounds.Height, radio);
		}

		/// <summary>
		///       绘制圆角矩形
		///       </summary>
		/// <param name="p">
		/// </param>
		/// <param name="left">
		/// </param>
		/// <param name="top">
		/// </param>
		/// <param name="width">
		/// </param>
		/// <param name="height">
		/// </param>
		/// <param name="radio">
		/// </param>
		public void DrawRoundRectangle(XPenStyle xpenStyle_0, float left, float float_0, float width, float height, float radio)
		{
			int num = 7;
			if (xpenStyle_0 == null)
			{
				throw new ArgumentNullException("p");
			}
			using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(new RectangleF(left, float_0, width, height), radio))
			{
				if (graphics_0 != null)
				{
					graphics_0.DrawPath(xpenStyle_0.Value, path);
				}
			}
		}

		public void FillRoundRectangle(Color color_0, RectangleF bounds, float radio)
		{
			using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(bounds, radio))
			{
				if (graphics_0 != null)
				{
					graphics_0.FillPath(GClass438.smethod_0(color_0), path);
				}
			}
		}

		/// <summary>
		///       填充圆角矩形
		///       </summary>
		/// <param name="c">
		/// </param>
		/// <param name="left">
		/// </param>
		/// <param name="top">
		/// </param>
		/// <param name="width">
		/// </param>
		/// <param name="height">
		/// </param>
		/// <param name="radio">
		/// </param>
		public void FillRoundRectangle(Color color_0, float left, float float_0, float width, float height, float radio)
		{
			using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(new RectangleF(left, float_0, width, height), radio))
			{
				if (graphics_0 != null)
				{
					graphics_0.FillPath(GClass438.smethod_0(color_0), path);
				}
			}
		}

		public void FillPath(Brush brush, GraphicsPath path)
		{
			if (graphics_0 != null)
			{
				graphics_0.FillPath(brush, path);
			}
		}

		public void FillPath(Color color_0, GraphicsPath path)
		{
			if (graphics_0 != null)
			{
				graphics_0.FillPath(GClass438.smethod_0(color_0), path);
			}
		}

		public void DrawPath(Color lineColor, float lineWidth, DashStyle lineStyle, GraphicsPath path)
		{
			using (Pen pen = new Pen(lineColor, lineWidth))
			{
				pen.DashStyle = lineStyle;
				DrawPath(pen, path);
			}
		}

		public void DrawPath(Color lineColor, float lineWidth, GraphicsPath path)
		{
			using (Pen pen_ = new Pen(lineColor, lineWidth))
			{
				DrawPath(pen_, path);
			}
		}

		public void DrawPath(Color lineColor, GraphicsPath path)
		{
			DrawPath(GClass438.smethod_1(lineColor), path);
		}

		public void DrawPath(Pen pen_0, GraphicsPath path)
		{
			if (graphics_0 != null)
			{
				graphics_0.DrawPath(pen_0, path);
			}
		}

		public void DrawPath(XPenStyle xpenStyle_0, GraphicsPath path)
		{
			if (graphics_0 != null)
			{
				using (Pen pen = xpenStyle_0.CreatePen())
				{
					graphics_0.DrawPath(pen, path);
				}
			}
		}

		public void FillEllipse(Color color_0, RectangleF rect)
		{
			FillEllipse(GClass438.smethod_0(color_0), rect);
		}

		public void FillEllipse(XBrushStyle brush, RectangleF rect)
		{
			using (Brush brush2 = brush.method_0())
			{
				FillEllipse(brush2, rect);
			}
		}

		public void FillEllipse(Brush brush, RectangleF rect)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_51(brush, rect);
			}
			if (graphics_0 != null)
			{
				graphics_0.FillEllipse(brush, rect);
			}
		}

		public void SetClip(RectangleF rect, CombineMode mode)
		{
			if (gclass519_0 != null)
			{
				gclass519_0.method_5(new Region(rect));
			}
			if (graphics_0 != null)
			{
				graphics_0.SetClip(rect, mode);
			}
		}

		public GraphicsState Save()
		{
			if (graphics_0 == null)
			{
				return null;
			}
			return graphics_0.Save();
		}

		public void Restore(GraphicsState graphicsState_0)
		{
			if (graphics_0 != null)
			{
				graphics_0.Restore(graphicsState_0);
			}
		}

		private Brush method_5()
		{
			DCMetaRecordType dCMetaRecordType = method_13();
			switch (dCMetaRecordType)
			{
			case DCMetaRecordType.SolidBrush:
				return new SolidBrush(Color.FromArgb(gclass375_0.method_14()));
			case DCMetaRecordType.TextureBrush:
			{
				Image bitmap = method_7();
				return new TextureBrush(bitmap);
			}
			default:
				throw new InvalidDataException(dCMetaRecordType.ToString());
			case DCMetaRecordType.HatchBrush:
			{
				HatchStyle hatchStyle = HatchStyle.DarkDownwardDiagonal;
				hatchStyle = (HatchStyle)gclass375_0.method_14();
				Color foreColor = Color.FromArgb(gclass375_0.method_14());
				Color backColor = Color.FromArgb(gclass375_0.method_14());
				return new HatchBrush(hatchStyle, foreColor, backColor);
			}
			}
		}

		private void method_6(Brush brush_0)
		{
			if (brush_0 is SolidBrush)
			{
				method_12(DCMetaRecordType.SolidBrush);
				gclass378_0.method_13(((SolidBrush)brush_0).Color.ToArgb());
			}
			else if (brush_0 is TextureBrush)
			{
				TextureBrush textureBrush = (TextureBrush)brush_0;
				method_12(DCMetaRecordType.TextureBrush);
				method_8(textureBrush.Image);
			}
			else if (brush_0 is HatchBrush)
			{
				HatchBrush hatchBrush = (HatchBrush)brush_0;
				method_12(DCMetaRecordType.HatchBrush);
				gclass378_0.method_13((int)hatchBrush.HatchStyle);
				gclass378_0.method_13(hatchBrush.ForegroundColor.ToArgb());
				gclass378_0.method_13(hatchBrush.BackgroundColor.ToArgb());
			}
		}

		private Image method_7()
		{
			method_11(DCMetaRecordType.Image);
			byte[] array = gclass375_0.method_9();
			if (array != null && array.Length > 0)
			{
				MemoryStream stream = new MemoryStream(array);
				return Image.FromStream(stream);
			}
			return null;
		}

		private void method_8(Image image_0)
		{
			method_12(DCMetaRecordType.Image);
			MemoryStream memoryStream = new MemoryStream();
			image_0.Save(memoryStream, ImageFormat.Png);
			memoryStream.Close();
			gclass378_0.method_6(memoryStream.ToArray());
		}

		private void method_9(Pen pen_0)
		{
			method_12(DCMetaRecordType.Pen);
			gclass378_0.method_13(pen_0.Color.ToArgb());
			gclass378_0.method_13((int)pen_0.DashStyle);
			gclass378_0.method_18(pen_0.Width);
		}

		private Pen method_10()
		{
			method_11(DCMetaRecordType.Pen);
			Color color = Color.FromArgb(gclass375_0.method_14());
			DashStyle dashStyle = (DashStyle)gclass375_0.method_14();
			float width = gclass375_0.method_20();
			Pen pen = new Pen(color, width);
			pen.DashStyle = dashStyle;
			return pen;
		}

		private void method_11(DCMetaRecordType dcmetaRecordType_0)
		{
			int num = 6;
			DCMetaRecordType dCMetaRecordType = method_13();
			if (dcmetaRecordType_0 != dCMetaRecordType)
			{
				throw new InvalidDataException(string.Concat(dCMetaRecordType, "!=", dcmetaRecordType_0));
			}
		}

		private void method_12(DCMetaRecordType dcmetaRecordType_0)
		{
			gclass378_0.method_12((short)dcmetaRecordType_0);
		}

		private DCMetaRecordType method_13()
		{
			return (DCMetaRecordType)gclass375_0.method_13();
		}

		[DCInternal]
		public void Dispose()
		{
			if (AutoDisposeNativeGraphics && graphics_0 != null)
			{
				Graphics graphics = graphics_0;
				graphics_0 = null;
				graphics.Dispose();
			}
		}

		[DCInternal]
		public void LogContent(string string_0)
		{
			if (LogType == DCGraphicsLogType.Content && stream_0 != null && !string.IsNullOrEmpty(string_0))
			{
				byte[] bytes = Encoding.UTF8.GetBytes(string_0);
				LogStream.Write(bytes, 0, bytes.Length);
			}
		}

		[DCInternal]
		public void LogContent(byte[] byte_0)
		{
			if (LogType == DCGraphicsLogType.Content && stream_0 != null && byte_0 != null && byte_0.Length > 0)
			{
				LogStream.Write(byte_0, 0, byte_0.Length);
			}
		}

		[DCInternal]
		public void LogContent(Image image_0)
		{
			if (LogType == DCGraphicsLogType.Content && LogStream != null && image_0 != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				image_0.Save(memoryStream, ImageFormat.Png);
				memoryStream.WriteTo(LogStream);
			}
		}
	}
}
