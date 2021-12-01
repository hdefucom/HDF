using System;
using System.Drawing;
using System.Drawing.Printing;
using XDesignerGUI;

namespace XDesignerPrinting
{
	public class XPaperSize
	{
		private PaperKind intKind = PaperKind.Custom;

		private int intWidth = 0;

		private int intHeight = 0;

		public PaperKind Kind
		{
			get
			{
				return intKind;
			}
			set
			{
				intKind = value;
			}
		}

		public int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				if (intKind == PaperKind.Custom)
				{
					intWidth = value;
					return;
				}
				throw new FieldAccessException("Width is readonly");
			}
		}

		public int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				if (intKind == PaperKind.Custom)
				{
					intHeight = value;
					return;
				}
				throw new FieldAccessException("Height is readonly");
			}
		}

		public PaperSize StdSize
		{
			get
			{
				return new PaperSize(intKind.ToString(), intWidth, intHeight);
			}
			set
			{
				if (value != null)
				{
					intKind = value.Kind;
					intWidth = value.Width;
					intHeight = value.Height;
				}
			}
		}

		public XPaperSize()
		{
		}

		public XPaperSize(PaperSize size)
		{
			intKind = size.Kind;
			intWidth = size.Width;
			intHeight = size.Height;
		}

		public XPaperSize(PaperKind vKind, int vWidth, int vHeight)
		{
			intKind = vKind;
			intWidth = vWidth;
			intHeight = vHeight;
		}

		public static double GetRate(GraphicsUnit unit)
		{
			return GraphicsUnitConvert.GetRate(unit, GraphicsUnit.Document) / 3.0;
		}

		public double GetWidth(GraphicsUnit unit)
		{
			return GraphicsUnitConvert.Convert(intWidth * 3, GraphicsUnit.Document, unit);
		}

		public void SetWidth(double vWidth, GraphicsUnit unit)
		{
			intWidth = (int)(GraphicsUnitConvert.Convert(vWidth, unit, GraphicsUnit.Document) / 3.0);
		}

		public double GetHeight(GraphicsUnit unit)
		{
			return GraphicsUnitConvert.Convert(intHeight * 3, GraphicsUnit.Document, unit);
		}

		public void SetHeight(double vHeight, GraphicsUnit unit)
		{
			intHeight = (int)(GraphicsUnitConvert.Convert(vHeight, unit, GraphicsUnit.Document) / 3.0);
		}

		public override string ToString()
		{
			return intKind.ToString();
		}
	}
}
