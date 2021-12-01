using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       画刷样式对象，本对象可以参与XML序列化和反序列化。
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[Editor("DCSoft.WinForms.Design.XBrushStyleEditor", typeof(UITypeEditor))]
	[TypeConverter(typeof(GClass529))]
	public class XBrushStyle : IDisposable, ICloneable
	{
		public const int int_0 = 1000;

		private Color color_0 = Color.Transparent;

		private Color color_1 = Color.Black;

		private XBrushStyleConst xbrushStyleConst_0 = XBrushStyleConst.Solid;

		private XImageValue ximageValue_0 = null;

		private bool bool_0 = true;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private static Dictionary<XBrushStyleConst, Image> dictionary_0 = null;

		/// <summary>
		///       背景色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
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
		///       画刷颜色文本值
		///       </summary>
		[XmlElement("Color")]
		[DefaultValue("Transparent")]
		[Browsable(false)]
		public string ColorString
		{
			get
			{
				return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(color_0);
			}
			set
			{
				color_0 = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(value);
			}
		}

		/// <summary>
		///       第二背景色，用于充当网格背景色或渐变色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		public Color Color2
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
			}
		}

		/// <summary>
		///       画笔颜色文本值
		///       </summary>
		[XmlElement("Color2")]
		[Browsable(false)]
		[DefaultValue("Black")]
		public string Color2String
		{
			get
			{
				return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(color_1);
			}
			set
			{
				color_1 = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(value);
			}
		}

		/// <summary>
		///       背景图案样式
		///       </summary>
		[DefaultValue(XBrushStyleConst.Solid)]
		public XBrushStyleConst Style
		{
			get
			{
				return xbrushStyleConst_0;
			}
			set
			{
				xbrushStyleConst_0 = value;
			}
		}

		/// <summary>
		///       背景图片
		///       </summary>
		[DefaultValue(null)]
		public XImageValue Image
		{
			get
			{
				return ximageValue_0;
			}
			set
			{
				ximageValue_0 = value;
			}
		}

		/// <summary>
		///       是否重复绘制背景图片
		///       </summary>
		[DefaultValue(true)]
		public bool Repeat
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
		///       背景图片横向偏移量
		///       </summary>
		[DefaultValue(0f)]
		public float OffsetX
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

		/// <summary>
		///       背景图片纵向偏移量
		///       </summary>
		[DefaultValue(0f)]
		public float OffsetY
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		/// <summary>
		///       对象是否有内容可以创建画刷对象
		///       </summary>
		[Browsable(false)]
		public bool HasContent => xbrushStyleConst_0 != XBrushStyleConst.Disabled;

		/// <summary>
		///       是否是纯色画刷
		///       </summary>
		[Browsable(false)]
		public bool IsSolid
		{
			get
			{
				if (xbrushStyleConst_0 == XBrushStyleConst.Disabled)
				{
					return false;
				}
				if (ximageValue_0 != null && ximageValue_0.Value != null)
				{
					return false;
				}
				return xbrushStyleConst_0 == XBrushStyleConst.Solid;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XBrushStyle()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="color">背景颜色</param>
		public XBrushStyle(Color color_2)
		{
			color_0 = color_2;
		}

		public Brush method_0()
		{
			return method_5(0f, 0f, 100f, 100f, GraphicsUnit.Pixel);
		}

		public Brush method_1(Rectangle rectangle_0, GraphicsUnit graphicsUnit_0)
		{
			return method_5(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height, graphicsUnit_0);
		}

		public Brush method_2(Rectangle rectangle_0)
		{
			return method_5(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height, GraphicsUnit.Pixel);
		}

		public Brush method_3(RectangleF rectangleF_0)
		{
			return method_5(rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height, GraphicsUnit.Pixel);
		}

		public Brush method_4(RectangleF rectangleF_0, GraphicsUnit graphicsUnit_0)
		{
			return method_5(rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height, graphicsUnit_0);
		}

		public Brush method_5(float float_2, float float_3, float float_4, float float_5, GraphicsUnit graphicsUnit_0)
		{
			if (xbrushStyleConst_0 == XBrushStyleConst.Disabled)
			{
				return null;
			}
			if (xbrushStyleConst_0 == XBrushStyleConst.Black)
			{
				return new SolidBrush(Color.Black);
			}
			if (xbrushStyleConst_0 == XBrushStyleConst.White)
			{
				return new SolidBrush(Color.White);
			}
			if (ximageValue_0 != null && ximageValue_0.Value != null)
			{
				TextureBrush textureBrush = new TextureBrush(ximageValue_0.Value);
				if (bool_0)
				{
					textureBrush.WrapMode = WrapMode.Tile;
				}
				else
				{
					textureBrush.WrapMode = WrapMode.Clamp;
				}
				float num = (float)GraphicsUnitConvert.GetRate(graphicsUnit_0, GraphicsUnit.Pixel);
				textureBrush.TranslateTransform(float_0, float_1);
				textureBrush.ScaleTransform(num, num);
				return textureBrush;
			}
			if (xbrushStyleConst_0 == XBrushStyleConst.Solid)
			{
				return new SolidBrush(color_0);
			}
			if (xbrushStyleConst_0 < XBrushStyleConst.GradientHorizontal)
			{
				return new HatchBrush((HatchStyle)xbrushStyleConst_0, color_0, color_1);
			}
			if (xbrushStyleConst_0 < (XBrushStyleConst)2000)
			{
				return new LinearGradientBrush(new RectangleF(float_2, float_3, float_4, float_5), color_0, color_1, (LinearGradientMode)(xbrushStyleConst_0 - 1000));
			}
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<XBrushStyleConst, Image>();
				Bitmap backImage = DrawingResources.BackImage1;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage1] = backImage;
				backImage = DrawingResources.BackImage2;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage2] = backImage;
				backImage = DrawingResources.BackImage3;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage3] = backImage;
				backImage = DrawingResources.BackImage4;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage4] = backImage;
				backImage = DrawingResources.BackImage5;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage5] = backImage;
				backImage = DrawingResources.BackImage6;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage6] = backImage;
				backImage = DrawingResources.BackImage7;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage7] = backImage;
				backImage = DrawingResources.BackImage8;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage8] = backImage;
				backImage = DrawingResources.BackImage9;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage9] = backImage;
				backImage = DrawingResources.BackImage10;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage10] = backImage;
				backImage = DrawingResources.BackImage11;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage11] = backImage;
				backImage = DrawingResources.BackImage12;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage12] = backImage;
				backImage = DrawingResources.BackImage13;
				backImage.MakeTransparent(Color.Red);
				dictionary_0[XBrushStyleConst.BackImage13] = backImage;
			}
			if (dictionary_0.ContainsKey(xbrushStyleConst_0))
			{
				TextureBrush textureBrush = new TextureBrush(dictionary_0[xbrushStyleConst_0]);
				if (Repeat)
				{
					textureBrush.WrapMode = WrapMode.Tile;
				}
				else
				{
					textureBrush.WrapMode = WrapMode.Clamp;
				}
				float num = (float)GraphicsUnitConvert.GetRate(graphicsUnit_0, GraphicsUnit.Pixel);
				textureBrush.TranslateTransform(float_0, float_1);
				textureBrush.ScaleTransform(num, num);
				return textureBrush;
			}
			return new SolidBrush(Color);
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 12;
			if (xbrushStyleConst_0 == XBrushStyleConst.Disabled)
			{
				return "Disabled";
			}
			if (ximageValue_0 != null && ximageValue_0.Value != null)
			{
				string str = "";
				if (bool_0)
				{
					str = " Repeat ";
				}
				return str + ximageValue_0.ToString();
			}
			if (xbrushStyleConst_0 == XBrushStyleConst.Solid)
			{
				return ColorTranslator.ToHtml(color_0);
			}
			return xbrushStyleConst_0.ToString() + " " + ColorTranslator.ToHtml(color_0) + "->" + ColorTranslator.ToHtml(color_1);
		}

		object ICloneable.Clone()
		{
			XBrushStyle xBrushStyle = new XBrushStyle();
			xBrushStyle.bool_0 = bool_0;
			xBrushStyle.color_0 = color_0;
			xBrushStyle.color_1 = color_1;
			xBrushStyle.xbrushStyleConst_0 = xbrushStyleConst_0;
			xBrushStyle.float_0 = float_0;
			xBrushStyle.float_1 = float_1;
			if (ximageValue_0 != null)
			{
				xBrushStyle.ximageValue_0 = ximageValue_0.Clone();
			}
			return xBrushStyle;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XBrushStyle Clone()
		{
			return (XBrushStyle)((ICloneable)this).Clone();
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			if (ximageValue_0 != null)
			{
				ximageValue_0.Dispose();
				ximageValue_0 = null;
			}
		}
	}
}
