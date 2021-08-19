using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass456 : GClass455
	{
		private bool bool_0 = false;

		private Image image_0 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private GClass515 gclass515_0 = null;

		private Color color_0 = Color.Empty;

		private bool bool_1 = false;

		public GClass456(Image image_1, string string_1)
			: base(string_1)
		{
			image_0 = image_1;
			method_14();
		}

		public bool method_5()
		{
			return bool_0;
		}

		public void method_6(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (method_5() && image_0 != null)
			{
				Image image = image_0;
				image_0 = null;
				image.Dispose();
			}
		}

		public Image method_7()
		{
			return image_0;
		}

		public float method_8()
		{
			return float_0;
		}

		public void method_9(float float_2)
		{
			float_0 = float_2;
		}

		public float method_10()
		{
			return float_1;
		}

		public void method_11(float float_2)
		{
			float_1 = float_2;
		}

		public override float vmethod_3()
		{
			return image_0.Width;
		}

		public override float vmethod_4()
		{
			return image_0.Height;
		}

		public bool method_12()
		{
			return image_0.RawFormat.Guid.ToString() == ImageFormat.Jpeg.Guid.ToString();
		}

		public bool method_13()
		{
			return image_0.RawFormat.Guid.ToString() == ImageFormat.Bmp.Guid.ToString() || image_0.RawFormat.Guid.ToString() == ImageFormat.MemoryBmp.Guid.ToString();
		}

		private void method_14()
		{
			if (!method_12() && method_13())
			{
				int pixelFormatSize = Image.GetPixelFormatSize(image_0.PixelFormat);
				if (pixelFormatSize <= 8 && image_0.Palette.Entries.Length > 0)
				{
					method_15();
				}
			}
		}

		private void method_15()
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < image_0.Palette.Entries.Length; i++)
			{
				stringBuilder.Append(image_0.Palette.Entries[i].R.ToString("X2", CultureInfo.CurrentCulture));
				stringBuilder.Append(image_0.Palette.Entries[i].G.ToString("X2", CultureInfo.CurrentCulture));
				stringBuilder.Append(image_0.Palette.Entries[i].B.ToString("X2", CultureInfo.CurrentCulture));
				if (i < image_0.Palette.Entries.Length - 1)
				{
					stringBuilder.Append(" ");
				}
			}
			stringBuilder.Append(">\r\n");
			gclass515_0 = new GClass515();
			gclass515_0.method_1(GEnum89.const_1);
			gclass515_0.method_12().method_9("Filter", "ASCIIHexDecode");
			gclass515_0.method_8(stringBuilder.ToString());
		}

		private void method_16()
		{
			method_4().method_9("ColorSpace", "DeviceRGB");
			GClass513 gClass = new GClass513();
			gClass.method_10("DCTDecode");
			method_4().method_8("Filter", gClass);
			method_4().method_10("BitsPerComponent", 8);
			method_7().Save(method_3().method_13(), ImageFormat.Jpeg);
		}

		private void method_17(Bitmap bitmap_0)
		{
			method_4().method_10("BitsPerComponent", 8);
			method_4().method_9("ColorSpace", "DeviceRGB");
			int height = bitmap_0.Height;
			int width = bitmap_0.Width;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Color pixel = bitmap_0.GetPixel(j, i);
					if (pixel.A == 0 && color_0 == Color.Empty)
					{
						color_0 = pixel;
					}
					method_3().method_10(pixel.R);
					method_3().method_10(pixel.G);
					method_3().method_10(pixel.B);
				}
			}
		}

		private void method_18()
		{
			method_4().method_10("BitsPerComponent", 8);
			GClass513 gClass = new GClass513();
			gClass.method_10("Indexed");
			gClass.method_10("DeviceRGB");
			gClass.method_11(image_0.Palette.Entries.Length - 1);
			gClass.method_9(gclass515_0);
			method_4().method_8("ColorSpace", gClass);
			MemoryStream memoryStream = new MemoryStream();
			image_0.Save(memoryStream, ImageFormat.Bmp);
			byte[] buffer = memoryStream.GetBuffer();
			int num = BitConverter.ToInt32(buffer, 10);
			for (int num2 = image_0.Height - 1; num2 >= 0; num2--)
			{
				for (int i = 0; i < image_0.Width; i++)
				{
					method_3().method_10(buffer[num + num2 * image_0.Width + i]);
				}
			}
		}

		private void method_19()
		{
			switch (image_0.PixelFormat)
			{
			case PixelFormat.Indexed:
				if (Image.GetPixelFormatSize(image_0.PixelFormat) <= 8)
				{
					method_18();
				}
				break;
			case PixelFormat.Format1bppIndexed:
			case PixelFormat.Format4bppIndexed:
			case PixelFormat.Format8bppIndexed:
				method_18();
				break;
			case PixelFormat.Gdi:
			case PixelFormat.Format16bppRgb555:
			case PixelFormat.Format16bppRgb565:
			case PixelFormat.Format24bppRgb:
			case PixelFormat.Format32bppRgb:
			case PixelFormat.Format16bppArgb1555:
			case PixelFormat.Format32bppPArgb:
			case PixelFormat.Format48bppRgb:
			case PixelFormat.Format64bppPArgb:
			case PixelFormat.Format32bppArgb:
			case PixelFormat.Format64bppArgb:
				if (image_0 is Bitmap)
				{
					method_17(image_0 as Bitmap);
				}
				break;
			}
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			if (gclass515_0 != null)
			{
				gclass515_0.method_6(streamWriter_0);
			}
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			if (gclass515_0 != null)
			{
				gclass540_0.method_2(gclass515_0);
			}
		}

		public override void vmethod_2()
		{
			int num = 6;
			if (!bool_1)
			{
				bool_1 = true;
				base.vmethod_2();
				method_4().method_9("Subtype", "Image");
				method_4().method_10("Width", image_0.Width);
				method_4().method_10("Height", image_0.Height);
				if (method_12())
				{
					method_16();
				}
				else if (method_13())
				{
					method_19();
				}
				else if (image_0 is Bitmap)
				{
					method_17(image_0 as Bitmap);
				}
				else if (image_0 is Metafile)
				{
					Bitmap bitmap = null;
					bitmap = ((!(method_8() > 0f) || !(method_10() > 0f)) ? new Bitmap(image_0.Width, image_0.Height) : new Bitmap((int)method_8(), (int)method_10()));
					Graphics graphics = Graphics.FromImage(bitmap);
					try
					{
						graphics.Clear(Color.White);
						graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
						graphics.DrawImage(image_0, 0, 0, bitmap.Width, bitmap.Height);
						method_17(bitmap);
					}
					finally
					{
						graphics.Dispose();
					}
				}
				if (color_0 != Color.Empty)
				{
					GClass513 gClass = new GClass513();
					gClass.method_11(color_0.R);
					gClass.method_11(color_0.R);
					gClass.method_11(color_0.G);
					gClass.method_11(color_0.G);
					gClass.method_11(color_0.B);
					gClass.method_11(color_0.B);
					method_4().method_8("Mask", gClass);
				}
				if (image_0 != null)
				{
					image_0.Dispose();
					image_0 = null;
				}
			}
		}
	}
}
