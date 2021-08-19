using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass131
	{
		private static Image image_0 = null;

		internal static Image smethod_0()
		{
			int num = 2;
			if (image_0 == null)
			{
				image_0 = smethod_1(typeof(GClass131).Assembly, "DCSoft.Writer.Commands.Images.Null.bmp");
			}
			return image_0;
		}

		internal static Image smethod_1(Assembly assembly_0, string string_0)
		{
			if (assembly_0 == null)
			{
				return null;
			}
			if (string_0 != null && string_0.Trim().Length > 0)
			{
				Stream manifestResourceStream = assembly_0.GetManifestResourceStream(string_0);
				if (manifestResourceStream != null)
				{
					byte[] array = new byte[manifestResourceStream.Length];
					manifestResourceStream.Read(array, 0, array.Length);
					MemoryStream stream = new MemoryStream(array);
					Image image = Image.FromStream(stream);
					if (image is Bitmap)
					{
						Bitmap bitmap = (Bitmap)image;
						bitmap.MakeTransparent(bitmap.GetPixel(0, bitmap.Height - 1));
					}
					return image;
				}
			}
			return null;
		}
	}
}
