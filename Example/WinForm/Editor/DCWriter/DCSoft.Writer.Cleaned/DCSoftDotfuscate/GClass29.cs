using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass29
	{
		public static bool smethod_0(string string_0, string string_1)
		{
			int num = 17;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("xmlFileName");
			}
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("rtfFileName");
			}
			if (File.Exists(string_0))
			{
				throw new FileNotFoundException(string_0);
			}
			using (XTextDocument xTextDocument = new XTextDocument())
			{
				xTextDocument.Load(string_0, "xml");
				using (DCGraphics dcgraphics_ = xTextDocument.CreateDCGraphics())
				{
					xTextDocument.RefreshSize(dcgraphics_);
					xTextDocument.ExecuteLayout();
					xTextDocument.RefreshPages();
					xTextDocument.Save(string_1, "rtf");
				}
			}
			return true;
		}
	}
}
