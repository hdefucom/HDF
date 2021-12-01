using System;
using System.Drawing;
using System.IO;

namespace ZYTextDocumentLib.icon
{
	public class IconHelper
	{
		public static Image GetResourceImage(string strName, Color TransparentColor)
		{
			Type typeFromHandle = typeof(IconHelper);
			string @namespace = typeFromHandle.Namespace;
			strName = @namespace + "." + strName;
			Stream manifestResourceStream = typeFromHandle.Assembly.GetManifestResourceStream(strName);
			if (manifestResourceStream == null)
			{
				Console.WriteLine(strName);
				return null;
			}
			Bitmap bitmap = (Bitmap)Image.FromStream(manifestResourceStream);
			if (bitmap != null && !TransparentColor.IsEmpty)
			{
				bitmap.MakeTransparent(TransparentColor);
			}
			manifestResourceStream.Close();
			bitmap.Save("c:\\1.bmp");
			return bitmap;
		}
	}
}
