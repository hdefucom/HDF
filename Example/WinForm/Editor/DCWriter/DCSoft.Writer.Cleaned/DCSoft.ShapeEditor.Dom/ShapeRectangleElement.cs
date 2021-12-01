using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       矩形图形对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeRectangleElement : ShapeElement
	{
		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 100f;

		private float float_3 = 100f;

		[NonSerialized]
		private GEventArgs11 geventArgs11_0 = null;

		private bool bool_3 = true;

		[NonSerialized]
		private GClass330 gclass330_0 = null;

		private string string_1 = null;

		/// <summary>
		///       左端位置
		///       </summary>
		[Category("Layout")]
		[DefaultValue(0f)]
		public float Left
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
				gclass330_0 = null;
			}
		}

		/// <summary>
		///       顶端位置
		///       </summary>
		[DefaultValue(0f)]
		[Category("Layout")]
		public float Top
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
				gclass330_0 = null;
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100f)]
		public float Width
		{
			get
			{
				return float_2;
			}
			set
			{
				float_2 = value;
				gclass330_0 = null;
			}
		}

		/// <summary>
		///       宽度
		///       </summary>
		[Category("Layout")]
		[DefaultValue(100f)]
		public float Height
		{
			get
			{
				return float_3;
			}
			set
			{
				float_3 = value;
				gclass330_0 = null;
			}
		}

		/// <summary>
		///       上端位置
		///       </summary>
		[Browsable(false)]
		public float Right => Left + Width;

		/// <summary>
		///       下端位置
		///       </summary>
		[Browsable(false)]
		public float Bottom => Top + Height;

		/// <summary>
		///       对象边界
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override RectangleF Bounds
		{
			get
			{
				return new RectangleF(Left, Top, Width, Height);
			}
			set
			{
				Left = value.Left;
				Top = value.Top;
				Width = value.Width;
				Height = value.Height;
				gclass330_0 = null;
			}
		}

		/// <summary>
		///       客户区边界，采用元素内部坐标系
		///       </summary>
		[Browsable(false)]
		public RectangleF ClientRectangle
		{
			get
			{
				ContentStyle runtimeStyle = RuntimeStyle;
				return new RectangleF(runtimeStyle.PaddingLeft, runtimeStyle.PaddingTop, Width - runtimeStyle.PaddingLeft - runtimeStyle.PaddingRight, Height - runtimeStyle.PaddingTop - runtimeStyle.PaddingBottom);
			}
		}

		/// <summary>
		///       元素能否被用户改变大小
		///       </summary>
		[Browsable(false)]
		[DefaultValue(true)]
		public virtual bool Resizeable
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

		public override void vmethod_0(float float_4, float float_5)
		{
			Left *= float_4;
			Top *= float_5;
			Width *= float_4;
			Height *= float_5;
		}

		public override GraphicsPath vmethod_5()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(new RectangleF(0f, 0f, Width, Height));
			return graphicsPath;
		}

		public override void vmethod_2(GEventArgs11 geventArgs11_1)
		{
			geventArgs11_0 = geventArgs11_1;
			geventArgs11_1.method_12().Draw += method_0;
			if (geventArgs11_1.method_12().method_2(bool_1: false))
			{
				int width = geventArgs11_1.method_12().EndPosition.X - geventArgs11_1.method_10().X;
				int height = geventArgs11_1.method_12().EndPosition.Y - geventArgs11_1.method_10().Y;
				SizeF sizeF = geventArgs11_1.method_6().method_25(new Size(width, height));
				RectangleF bounds = Bounds;
				vmethod_15();
				bounds = (Bounds = ((geventArgs11_0.method_0() != GEnum76.const_1) ? RectangleCommon.ChangeRectangle(bounds, sizeF.Width, sizeF.Height, 8) : RectangleCommon.ChangeRectangle(bounds, sizeF.Width, sizeF.Height, geventArgs11_0.method_4().method_12())));
				vmethod_15();
				OwnerDocument.Modified = true;
				OwnerDocument.method_6();
				OwnerDocument.vmethod_23(EventArgs.Empty);
				OwnerDocument.vmethod_24(EventArgs.Empty);
			}
		}

		private void method_0(object sender, CaptureMouseMoveEventArgs e)
		{
			Rectangle rect = geventArgs11_0.method_6().method_22(AbsBounds);
			rect = ((geventArgs11_0.method_0() != GEnum76.const_1) ? RectangleCommon.ChangeRectangle(rect, e.method_5().X - geventArgs11_0.method_10().X, e.method_5().Y - geventArgs11_0.method_10().Y, 8) : RectangleCommon.ChangeRectangle(rect, e.method_5().X - geventArgs11_0.method_10().X, e.method_5().Y - geventArgs11_0.method_10().Y, geventArgs11_0.method_4().method_12()));
			if (this is ShapeEllipseElement)
			{
				geventArgs11_0.method_14().method_16(rect);
			}
			else
			{
				geventArgs11_0.method_14().DrawRectangle(rect);
			}
		}

		public override void vmethod_1(GClass328 gclass328_0)
		{
			if (gclass328_0.method_4() >= 0f && gclass328_0.method_4() <= Width && gclass328_0.method_6() >= 0f && gclass328_0.method_6() <= Height)
			{
				gclass328_0.method_9(GEnum73.const_2);
			}
		}

		[Browsable(false)]
		public override GClass330 vmethod_4()
		{
			if (gclass330_0 == null)
			{
				gclass330_0 = new GClass330();
				gclass330_0.Add(new GClass329(0f, 0f, Cursors.SizeNWSE));
				gclass330_0.Add(new GClass329(Width / 2f, 0f, Cursors.SizeNS));
				gclass330_0.Add(new GClass329(Width, 0f, Cursors.SizeNESW));
				gclass330_0.Add(new GClass329(Width, Height / 2f, Cursors.SizeWE));
				gclass330_0.Add(new GClass329(Width, Height, Cursors.SizeNWSE));
				gclass330_0.Add(new GClass329(Width / 2f, Height, Cursors.SizeNS));
				gclass330_0.Add(new GClass329(0f, Height, Cursors.SizeNESW));
				gclass330_0.Add(new GClass329(0f, Height / 2f, Cursors.SizeWE));
				foreach (GClass329 item in gclass330_0)
				{
					item.method_9(Resizeable);
					item.method_13(gclass330_0.IndexOf(item));
					item.method_1(this);
				}
			}
			return gclass330_0;
		}

		public override void vmethod_7(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			string displayText = DisplayText;
			if (displayText != null && displayText.Length > 0)
			{
				RectangleF absBounds = AbsBounds;
				ContentStyle runtimeStyle = RuntimeStyle;
				absBounds = runtimeStyle.method_25(absBounds);
				using (DrawStringFormatExt drawStringFormatExt = runtimeStyle.method_12())
				{
					XFontValue font = runtimeStyle.Font;
					if (OwnerDocument.AutoZoomFontSize && shapeRenderEventArgs_0.ZoomRate > 0f)
					{
						font.Size /= shapeRenderEventArgs_0.ZoomRate;
					}
					SizeF sizeF = shapeRenderEventArgs_0.Graphics.MeasureString(displayText, font, (int)absBounds.Width, drawStringFormatExt);
					if (OwnerDocument.TextBackColor.A != 0)
					{
						RectangleF rect = RectangleCommon.AlignRect(absBounds, sizeF.Width, sizeF.Height + 10f, drawStringFormatExt.Alignment, drawStringFormatExt.LineAlignment);
						shapeRenderEventArgs_0.Graphics.FillRectangle(OwnerDocument.TextBackColor, rect);
					}
					shapeRenderEventArgs_0.Graphics.DrawString(displayText, font, runtimeStyle.Color, absBounds, drawStringFormatExt);
				}
			}
		}

		public override void vmethod_13(ShapeLabelEditEventArgs shapeLabelEditEventArgs_0)
		{
			shapeLabelEditEventArgs_0.Text = Text;
			shapeLabelEditEventArgs_0.Cancel = false;
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
	}
}
