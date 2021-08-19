using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs14 : EventArgs
	{
		private GClass533 gclass533_0 = null;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private ContentStyle contentStyle_0 = null;

		private GClass449 gclass449_0 = null;

		public GEventArgs14(GClass533 gclass533_1, RectangleF rectangleF_1, ContentStyle contentStyle_1, GClass449 gclass449_1)
		{
			gclass533_0 = gclass533_1;
			rectangleF_0 = rectangleF_1;
			contentStyle_0 = contentStyle_1;
			gclass449_0 = gclass449_1;
		}

		public GClass533 method_0()
		{
			return gclass533_0;
		}

		public RectangleF method_1()
		{
			return rectangleF_0;
		}

		public ContentStyle method_2()
		{
			return contentStyle_0;
		}

		public GClass449 method_3()
		{
			return gclass449_0;
		}
	}
}
