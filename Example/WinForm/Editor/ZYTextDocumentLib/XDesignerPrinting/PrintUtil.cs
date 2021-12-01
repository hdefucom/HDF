using System.Drawing;
using System.Drawing.Imaging;

namespace XDesignerPrinting
{
	internal sealed class PrintUtil
	{
		public static MetafileFrameUnit ConvertUnit(GraphicsUnit unit)
		{
			switch (unit)
			{
			case GraphicsUnit.Document:
				return MetafileFrameUnit.Document;
			case GraphicsUnit.Inch:
				return MetafileFrameUnit.Inch;
			case GraphicsUnit.Millimeter:
				return MetafileFrameUnit.Millimeter;
			case GraphicsUnit.Pixel:
				return MetafileFrameUnit.Pixel;
			case GraphicsUnit.Point:
				return MetafileFrameUnit.Point;
			default:
				return MetafileFrameUnit.Pixel;
			}
		}

		private PrintUtil()
		{
		}
	}
}
