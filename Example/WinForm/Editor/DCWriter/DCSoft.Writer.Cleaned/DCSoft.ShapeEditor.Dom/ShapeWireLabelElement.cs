using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       拉线标签元素
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeWireLabelElement : ShapeLineElement
	{
		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private bool bool_3 = false;

		private bool bool_4 = true;

		private float float_4 = 100f;

		private float float_5 = 100f;

		private string string_1 = null;

		/// <summary>
		///       文本格式化对象
		///       </summary>
		internal static DrawStringFormatExt TextFormat
		{
			get
			{
				if (drawStringFormatExt_0 == null)
				{
					drawStringFormatExt_0 = new DrawStringFormatExt();
					drawStringFormatExt_0.Alignment = StringAlignment.Center;
					drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_0.FormatFlags = StringFormatFlags.NoWrap;
				}
				return drawStringFormatExt_0;
			}
		}

		/// <summary>
		///       文本标签显示在左边
		///       </summary>
		[DefaultValue(false)]
		public bool LabelAtLeft
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		/// <summary>
		///       文本标签显示在上面
		///       </summary>
		[DefaultValue(false)]
		public bool LabelAtUp
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

		/// <summary>
		///       文本内容
		///       </summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		public string Text
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       实际显示的文本
		///       </summary>
		[Browsable(false)]
		public string DisplayText => Text;

		[XmlIgnore]
		public override RectangleF Bounds
		{
			get
			{
				RectangleF bounds = base.Bounds;
				return RectangleF.Union(bounds, method_1());
			}
			set
			{
				base.Bounds = value;
			}
		}

		private RectangleF method_1()
		{
			RectangleF result = new RectangleF(base.X2, base.Y2, float_4, float_5);
			if (LabelAtLeft)
			{
				result.X -= result.Width;
			}
			if (LabelAtUp)
			{
				result.Y -= result.Height;
			}
			return result;
		}

		public override void vmethod_6(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			int num = 4;
			base.vmethod_6(shapeRenderEventArgs_0);
			PointF offsetPositionForRender = base.OffsetPositionForRender;
			ContentStyle runtimeStyle = RuntimeStyle;
			PointF pointF = new PointF(base.X1, base.Y1);
			pointF.X += offsetPositionForRender.X;
			pointF.Y += offsetPositionForRender.Y;
			float num2 = (float)GraphicsUnitConvert.PixelToUnit(10.0, shapeRenderEventArgs_0.Graphics.PageUnit);
			shapeRenderEventArgs_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			shapeRenderEventArgs_0.Graphics.FillEllipse(runtimeStyle.BorderColor, new RectangleF(pointF.X - num2 / 2f, pointF.Y - num2 / 2f, num2, num2));
			XFontValue font = runtimeStyle.Font;
			if (OwnerDocument.AutoZoomFontSize && shapeRenderEventArgs_0.ZoomRate > 0f)
			{
				font.Size /= shapeRenderEventArgs_0.ZoomRate;
			}
			string displayText = DisplayText;
			if (string.IsNullOrEmpty(displayText))
			{
				SizeF sizeF = shapeRenderEventArgs_0.Graphics.MeasureString("__", font, 10000, TextFormat);
				float_4 = sizeF.Width;
				float_5 = sizeF.Height;
			}
			else
			{
				SizeF sizeF = shapeRenderEventArgs_0.Graphics.MeasureString(displayText, font, 10000, TextFormat);
				float_4 = sizeF.Width;
				float_5 = sizeF.Height;
			}
			RectangleF rectangleF = method_1();
			rectangleF.Offset(offsetPositionForRender);
			if (!string.IsNullOrEmpty(displayText))
			{
				RectangleF rectangleF_ = rectangleF;
				rectangleF_ = runtimeStyle.method_25(rectangleF_);
				if (OwnerDocument.TextBackColor.A != 0)
				{
					RectangleCommon.AlignRect(rectangleF_, rectangleF_.Width, rectangleF_.Height + 10f, TextFormat.Alignment, TextFormat.LineAlignment);
					shapeRenderEventArgs_0.Graphics.FillRectangle(OwnerDocument.TextBackColor, rectangleF_);
				}
				shapeRenderEventArgs_0.Graphics.DrawString(displayText, font, runtimeStyle.Color, rectangleF_, TextFormat);
			}
			shapeRenderEventArgs_0.Graphics.DrawLine(runtimeStyle.BorderColor, runtimeStyle.BorderWidth, runtimeStyle.BorderStyle, base.X2 + offsetPositionForRender.X, base.Y2 + offsetPositionForRender.Y, base.X2 + offsetPositionForRender.X + (LabelAtLeft ? (0f - float_4) : float_4), base.Y2 + offsetPositionForRender.Y);
		}

		public override void vmethod_13(ShapeLabelEditEventArgs shapeLabelEditEventArgs_0)
		{
			shapeLabelEditEventArgs_0.Text = Text;
			shapeLabelEditEventArgs_0.Cancel = false;
			RectangleF editAreaBounds = method_1();
			editAreaBounds.Offset(base.OffsetPositionForRender);
			shapeLabelEditEventArgs_0.EditAreaBounds = editAreaBounds;
		}

		public override void vmethod_14(ShapeLabelEditEventArgs shapeLabelEditEventArgs_0)
		{
			Text = shapeLabelEditEventArgs_0.NewText;
			shapeLabelEditEventArgs_0.Cancel = false;
			OwnerDocument.Modified = true;
			OwnerDocument.method_6();
			OwnerDocument.vmethod_24(EventArgs.Empty);
			OwnerDocument.vmethod_23(EventArgs.Empty);
		}

		public override GClass330 vmethod_4()
		{
			GClass330 gClass = base.vmethod_4();
			GClass329 gClass2 = gClass[1].method_15();
			if (LabelAtLeft)
			{
				gClass2.method_3(gClass2.method_2() - float_4);
			}
			else
			{
				gClass2.method_3(gClass2.method_2() + float_4);
			}
			if (LabelAtUp)
			{
				gClass2.method_5(gClass2.method_4() - float_5);
			}
			else
			{
				gClass2.method_5(gClass2.method_4() + float_5);
			}
			gClass2.method_13(3);
			gClass.Add(gClass2);
			return gClass;
		}

		public override void vmethod_1(GClass328 gclass328_0)
		{
			RectangleF rectangleF = method_1();
			rectangleF.Offset(0f - Bounds.Left, 0f - Bounds.Top);
			if (rectangleF.Contains(gclass328_0.method_4(), gclass328_0.method_6()))
			{
				gclass328_0.method_9(GEnum73.const_2);
			}
			else
			{
				base.vmethod_1(gclass328_0);
			}
		}

		public override void vmethod_2(GEventArgs11 geventArgs11_0)
		{
			if (geventArgs11_0.method_0() == GEnum76.const_1 && geventArgs11_0.method_4().method_12() == 3 && geventArgs11_0.method_0() == GEnum76.const_1)
			{
				geventArgs11_0.method_12().Tag = geventArgs11_0;
				geventArgs11_0.method_12().Draw += method_2;
				if (geventArgs11_0.method_12().CaptureMouseMove(bool_1: false))
				{
					PointF pointF = geventArgs11_0.method_6().method_23(geventArgs11_0.method_12().CurrentPosition);
					RectangleF clientRectangle = Parent.ClientRectangle;
					clientRectangle.Offset(Parent.AbsLocation);
					pointF.X -= clientRectangle.X;
					pointF.Y -= clientRectangle.Y;
					vmethod_15();
					LabelAtLeft = (pointF.X < base.X2);
					LabelAtUp = (pointF.Y < base.Y2);
					vmethod_15();
				}
			}
			else
			{
				base.vmethod_2(geventArgs11_0);
			}
		}

		private void method_2(object sender, CaptureMouseMoveEventArgs e)
		{
			RectangleF clientRectangle = Parent.ClientRectangle;
			clientRectangle.Offset(Parent.AbsLocation);
			PointF pointF_ = new PointF(base.X1 + clientRectangle.X, base.Y1 + clientRectangle.Y);
			PointF pointF_2 = new PointF(base.X2 + clientRectangle.Y, base.Y2 + clientRectangle.Y);
			GEventArgs11 gEventArgs = (GEventArgs11)e.method_2().Tag;
			gEventArgs.method_6().method_27(pointF_);
			Point point_ = gEventArgs.method_6().method_27(pointF_2);
			gEventArgs.method_14().method_13(point_, e.method_5());
		}
	}
}
