using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       绘制水印的类型
	///       </summary>
	[Serializable]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComDefaultInterface(typeof(IWatermarkInfo))]
	[Guid("E57DF5C8-D3E1-405D-AACA-D41DB9590E17")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	public class WatermarkInfo : IDisposable, IWatermarkInfo
	{
		private bool bool_0 = true;

		private bool bool_1 = true;

		private WatermarkType watermarkType_0 = WatermarkType.None;

		private XFontValue xfontValue_0 = new XFontValue();

		private Color color_0 = Color.Black;

		private Color color_1 = Color.White;

		private int int_0 = 80;

		private string string_0 = null;

		private bool bool_2 = false;

		private XImageValue ximageValue_0 = null;

		[NonSerialized]
		private Image image_0 = null;

		private float float_0 = 0f;

		/// <summary>
		///       在用户界面上显示水印
		///       </summary>
		[DefaultValue(true)]
		public bool ShowWatermark
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
		///       打印水印
		///       </summary>
		[DefaultValue(true)]
		public bool PrintWatermark
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       水印样式
		///       </summary>
		[DefaultValue(WatermarkType.None)]
		public WatermarkType Type
		{
			get
			{
				return watermarkType_0;
			}
			set
			{
				watermarkType_0 = value;
			}
		}

		/// <summary>
		///       绘制文本使用的字体
		///       </summary>
		public XFontValue Font
		{
			get
			{
				if (xfontValue_0 == null)
				{
					xfontValue_0 = new XFontValue();
				}
				return xfontValue_0;
			}
			set
			{
				xfontValue_0 = value;
			}
		}

		/// <summary>
		///       颜色值
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		public Color Color
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       颜色值
		///       </summary>
		[DefaultValue("black")]
		[Browsable(false)]
		[DCInternal]
		[XmlElement]
		public string ColorValue
		{
			get
			{
				return ColorTranslator.ToHtml(color_0);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					color_0 = Color.Black;
				}
				else
				{
					color_0 = ColorTranslator.FromHtml(value);
				}
			}
		}

		/// <summary>
		///       颜色值
		///       </summary>
		[DefaultValue(typeof(Color), "White")]
		[XmlIgnore]
		public Color BackColor
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
				method_0();
			}
		}

		/// <summary>
		///       颜色值
		///       </summary>
		[DCInternal]
		[DefaultValue("white")]
		[XmlElement]
		[Browsable(false)]
		public string BackColorValue
		{
			get
			{
				return ColorTranslator.ToHtml(color_1);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					color_1 = Color.White;
				}
				else
				{
					color_1 = ColorTranslator.FromHtml(value);
				}
				method_0();
			}
		}

		/// <summary>
		///       透明度
		///       </summary>
		[DefaultValue(80)]
		public int Alpha
		{
			get
			{
				return int_0;
			}
			set
			{
				if (value > 255)
				{
					value = 255;
				}
				if (value < 0)
				{
					value = 0;
				}
				int_0 = value;
			}
		}

		/// <summary>
		///       文本
		///       </summary>
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       此属性尚未实现。
		///       </summary>
		[DefaultValue(false)]
		public bool Repeat
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       图片
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		public XImageValue Image
		{
			get
			{
				return ximageValue_0;
			}
			set
			{
				if (ximageValue_0 != value)
				{
					ximageValue_0 = value;
					method_0();
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。
		///       </summary>
		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Image RuntimeImage
		{
			get
			{
				if ((image_0 == null || XImageValue.smethod_1(image_0)) && Image != null && Image.Value != null && Image.Width > 0 && Image.Height > 0)
				{
					Bitmap bitmap = new Bitmap(Image.Width, Image.Height);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.Clear(BackColor);
						graphics.DrawImage(Image.Value, new RectangleF(0f, 0f, bitmap.Width, bitmap.Height));
						using (SolidBrush brush = new SolidBrush(Color.FromArgb(220, BackColor)))
						{
							graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
						}
					}
					image_0 = bitmap;
				}
				return image_0;
			}
		}

		/// <summary>
		///       绘制文本的角度
		///       </summary>
		[DefaultValue(0f)]
		public float Angle
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		[DCInternal]
		private void method_0()
		{
			if (image_0 != null)
			{
				Image image = image_0;
				image_0 = null;
				image.Dispose();
			}
		}

		/// <summary>
		///       清空对象数据
		///       </summary>
		public void Clear()
		{
			int_0 = 80;
			float_0 = 0f;
			color_1 = Color.White;
			color_0 = Color.Black;
			xfontValue_0 = new XFontValue();
			ximageValue_0 = null;
			bool_2 = false;
			method_0();
			string_0 = null;
			watermarkType_0 = WatermarkType.None;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public WatermarkInfo Clone()
		{
			WatermarkInfo watermarkInfo = (WatermarkInfo)MemberwiseClone();
			watermarkInfo.image_0 = null;
			if (ximageValue_0 != null)
			{
				watermarkInfo.ximageValue_0 = ximageValue_0.Clone();
			}
			if (xfontValue_0 != null)
			{
				watermarkInfo.xfontValue_0 = xfontValue_0.Clone();
			}
			return watermarkInfo;
		}

		private PointF method_1(PointF pointF_0, float float_1, float float_2)
		{
			float x = pointF_0.X;
			float y = pointF_0.Y;
			float_2 %= 360f;
			double a = (double)float_2 * Math.PI / 180.0;
			double num = Math.Tan(a);
			double num2 = (double)float_1 / Math.Sqrt(1.0 + num * num);
			double num3 = num2 * num;
			if (float_2 > 90f && float_2 < 270f)
			{
				return new PointF(x - (float)num2, y - (float)num3);
			}
			return new PointF(x + (float)num2, y + (float)num3);
		}

		private void method_2(DCGraphics dcgraphics_0, RectangleF rectangleF_0, float float_1, float float_2)
		{
			SizeF sizeF = dcgraphics_0.MeasureString(Text, Font);
			RectangleF rectangleF = new RectangleF(float_1, float_2, sizeF.Width, sizeF.Height);
			PointF pointF_ = new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height / 2f);
			float float_3 = (float)Math.Sqrt(rectangleF.Width * rectangleF.Width + rectangleF.Height * rectangleF.Height) / 2f;
			float num = (float)(Math.Atan(rectangleF.Height / rectangleF.Width) * (180.0 / Math.PI));
			PointF pointF = method_1(pointF_, float_3, Angle + 180f + num);
			PointF pointF2 = method_1(pointF_, float_3, Angle - num);
			PointF pointF3 = method_1(pointF_, float_3, Angle + num);
			PointF pointF4 = method_1(pointF_, float_3, Angle + 180f - num);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLines(new PointF[4]
			{
				pointF,
				pointF2,
				pointF3,
				pointF4
			});
			if (graphicsPath.GetBounds().IntersectsWith(rectangleF_0))
			{
				dcgraphics_0.TranslateTransform(pointF.X, pointF.Y);
				dcgraphics_0.RotateTransform(Angle);
				dcgraphics_0.DrawString(Text, Font, Color.FromArgb(Alpha, Color), 0f, 0f);
				dcgraphics_0.ResetTransform();
			}
		}

		public bool method_3()
		{
			if (Type == WatermarkType.None)
			{
				return false;
			}
			if (Type == WatermarkType.Text)
			{
				return !string.IsNullOrEmpty(Text);
			}
			if (Type == WatermarkType.Image)
			{
				return RuntimeImage != null;
			}
			return false;
		}

		[DCInternal]
		public bool method_4(RectangleF rectangleF_0, DCGraphics dcgraphics_0, RectangleF rectangleF_1)
		{
			if (dcgraphics_0 == null)
			{
				return false;
			}
			if (rectangleF_0.Width <= 0f || rectangleF_0.Height <= 0f)
			{
				return false;
			}
			if (!rectangleF_0.IntersectsWith(rectangleF_1))
			{
				return false;
			}
			if (Type == WatermarkType.None)
			{
				return false;
			}
			if (Type == WatermarkType.Text)
			{
				if (!string.IsNullOrEmpty(Text))
				{
					SizeF sizeF = dcgraphics_0.MeasureString(Text, Font);
					float float_ = rectangleF_0.Left + rectangleF_0.Width / 2f - sizeF.Width / 2f;
					float float_2 = rectangleF_0.Top + rectangleF_0.Height / 2f - sizeF.Height / 2f;
					method_2(dcgraphics_0, rectangleF_1, float_, float_2);
					return true;
				}
			}
			else if (Type == WatermarkType.Image && RuntimeImage != null)
			{
				float num = (float)RuntimeImage.Width * 1f / (float)RuntimeImage.Height;
				RectangleF bounds = rectangleF_0;
				if (rectangleF_0.Width * 1f / rectangleF_0.Height > num)
				{
					bounds.Height = rectangleF_0.Height;
					bounds.Width = bounds.Height * num;
					bounds.X = rectangleF_0.X + (rectangleF_0.Width - bounds.Width) / 2f;
					bounds.Y = rectangleF_0.Top;
				}
				else
				{
					bounds.Width = rectangleF_0.Width;
					bounds.Height = bounds.Width / num;
					bounds.X = rectangleF_0.X;
					bounds.Y = rectangleF_0.Top + (rectangleF_0.Height - bounds.Height) / 2f;
				}
				if (bounds.Width > 1f && bounds.Height > 1f)
				{
					DrawerUtil.DrawImage(dcgraphics_0, RuntimeImage, bounds, rectangleF_1);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		[DCInternal]
		public void Dispose()
		{
			method_0();
		}
	}
}
