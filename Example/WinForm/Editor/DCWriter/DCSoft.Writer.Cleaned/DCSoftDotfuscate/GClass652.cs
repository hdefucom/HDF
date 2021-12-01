using DCSoft.TDCode;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass652
	{
		private GClass683 gclass683_0;

		private float float_0 = 0.3f;

		private string string_0 = "UTF-8";

		private GClass636 gclass636_0 = GClass636.gclass636_3;

		public GClass652()
		{
			gclass683_0 = new GClass683();
		}

		public float method_0()
		{
			return float_0;
		}

		public void method_1(float float_1)
		{
			if (float_0 < 0f || float_0 > 0f)
			{
				float_0 = 0.3f;
			}
			else
			{
				float_0 = float_1;
			}
		}

		public string method_2()
		{
			return string_0;
		}

		public GClass636 method_3()
		{
			return gclass636_0;
		}

		public void method_4(GClass636 gclass636_1)
		{
			gclass636_0 = gclass636_1;
		}

		public Size method_5(string string_1, BarcodeFormat barcodeFormat_0, int int_0, int int_1)
		{
			return gclass683_0.method_0(string_1, barcodeFormat_0, int_0, int_1);
		}

		public sbyte[][] method_6(string string_1, BarcodeFormat barcodeFormat_0, int int_0, int int_1)
		{
			try
			{
				Hashtable hashtable = new Hashtable();
				hashtable.Add(GClass685.gclass685_1, method_2());
				hashtable.Add(GClass685.gclass685_0, method_3());
				GClass658 gClass = gclass683_0.imethod_1(string_1, barcodeFormat_0, int_0, int_1, hashtable);
				return gClass.method_2();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Bitmap method_7(string string_1, BarcodeFormat barcodeFormat_0, int int_0, int int_1)
		{
			try
			{
				Hashtable hashtable = new Hashtable();
				hashtable.Add(GClass685.gclass685_1, method_2());
				hashtable.Add(GClass685.gclass685_0, method_3());
				GClass658 gClass = gclass683_0.imethod_1(string_1, barcodeFormat_0, int_0, int_1, hashtable);
				return gClass.method_7();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Bitmap method_8(string string_1, BarcodeFormat barcodeFormat_0, int int_0, int int_1, Image image_0)
		{
			try
			{
				Bitmap bitmap = method_7(string_1, barcodeFormat_0, int_0, int_1);
				Size size = method_5(string_1, barcodeFormat_0, int_0, int_1);
				int num = Math.Min((int)((float)size.Width * method_0()), image_0.Width);
				int num2 = Math.Min((int)((float)size.Height * method_0()), image_0.Height);
				int x = (bitmap.Width - num) / 2;
				int y = (bitmap.Height - num2) / 2;
				Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
				using (Graphics graphics = Graphics.FromImage(bitmap2))
				{
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.DrawImage(bitmap, 0, 0);
				}
				Graphics graphics2 = Graphics.FromImage(bitmap2);
				graphics2.FillRectangle(Brushes.White, x, y, num, num2);
				graphics2.DrawImage(image_0, x, y, num, num2);
				return bitmap2;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
