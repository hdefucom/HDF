using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class202
	{
		private enum Enum23
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 4
		}

		public static bool smethod_0(GClass383 gclass383_0)
		{
			if (gclass383_0.method_5().Count == 0)
			{
				return false;
			}
			if (gclass383_0.method_5().Count == 1 && gclass383_0.method_5().method_0(0) is GClass388)
			{
				GClass388 gClass = (GClass388)gclass383_0.method_5().method_0(0);
				if (gClass.method_5().Count == 0)
				{
					return false;
				}
			}
			return true;
		}

		[DllImport("gdiplus.dll")]
		private static extern uint GdipEmfToWmfBits(IntPtr intptr_0, uint uint_0, byte[] byte_0, int int_0, Enum23 enum23_0);

		private string method_0(Image image_0)
		{
			int num = 17;
			StringBuilder stringBuilder = null;
			MemoryStream memoryStream = null;
			Graphics graphics = null;
			Metafile metafile = null;
			try
			{
				stringBuilder = new StringBuilder();
				memoryStream = new MemoryStream();
				using (graphics = Graphics.FromHwnd(new IntPtr(0)))
				{
					IntPtr hdc = graphics.GetHdc();
					metafile = new Metafile(memoryStream, hdc);
					graphics.ReleaseHdc(hdc);
				}
				using (graphics = Graphics.FromImage(metafile))
				{
					graphics.DrawImage(image_0, new Rectangle(0, 0, image_0.Width, image_0.Height));
				}
				IntPtr henhmetafile = metafile.GetHenhmetafile();
				uint num2 = GdipEmfToWmfBits(henhmetafile, 0u, null, 8, Enum23.const_0);
				byte[] array = new byte[num2];
				GdipEmfToWmfBits(henhmetafile, num2, array, 8, Enum23.const_0);
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append($"{array[i]:X2}");
				}
				return stringBuilder.ToString();
			}
			finally
			{
				graphics?.Dispose();
				metafile?.Dispose();
				memoryStream?.Close();
			}
		}

		private Class202()
		{
		}
	}
}
