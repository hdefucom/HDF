using System;
using System.Drawing.Printing;
using ZYCommon;

namespace XDesignerPrinting
{
	public class XPageSettings
	{
		private static XPageSettings myInstance = new XPageSettings();

		private XPaperSize myPaperSize = new XPaperSize((PaperKind)Enum.Parse(typeof(PaperKind), ZYPublic.PaperKind), ZYPublic.PaperWidth, ZYPublic.PaperHeight);

		private Margins myMargins = new Margins(ZYPublic.MarginLeft, ZYPublic.MarginRight, ZYPublic.MarginTop, ZYPublic.MarginBottom);

		private bool bolLandscape = ZYPublic.Landscape;

		public static XPageSettings Instance => myInstance;

		public XPaperSize PaperSize
		{
			get
			{
				return myPaperSize;
			}
			set
			{
				myPaperSize = value;
			}
		}

		public Margins Margins
		{
			get
			{
				return myMargins;
			}
			set
			{
				myMargins = value;
			}
		}

		public bool Landscape
		{
			get
			{
				return bolLandscape;
			}
			set
			{
				bolLandscape = value;
			}
		}

		public PageSettings StdPageSettings
		{
			get
			{
				PageSettings pageSettings = new PageSettings();
				if (myPaperSize.Kind == PaperKind.Custom)
				{
					if (!bolLandscape)
					{
						pageSettings.PaperSize = new PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
					}
					else
					{
						pageSettings.PaperSize = new PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
					}
				}
				else
				{
					bool flag = false;
					PrinterSettings printerSettings = new PrinterSettings();
					foreach (PaperSize paperSize in printerSettings.PaperSizes)
					{
						if (paperSize.Kind == myPaperSize.Kind)
						{
							pageSettings.PaperSize = paperSize;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						if (!bolLandscape)
						{
							pageSettings.PaperSize = new PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
						}
						else
						{
							pageSettings.PaperSize = new PaperSize("Custom", myPaperSize.Width, myPaperSize.Height);
						}
					}
				}
				pageSettings.Margins = myMargins;
				pageSettings.Landscape = bolLandscape;
				return pageSettings;
			}
			set
			{
				if (value != null)
				{
					myMargins = value.Margins;
					bolLandscape = value.Landscape;
					myPaperSize = new XPaperSize(value.PaperSize);
				}
			}
		}

		public XPageSettings Clone()
		{
			XPageSettings xPageSettings = new XPageSettings();
			xPageSettings.myPaperSize = new XPaperSize(myPaperSize.Kind, myPaperSize.Width, myPaperSize.Height);
			xPageSettings.myMargins = new Margins(myMargins.Left, myMargins.Right, myMargins.Top, myMargins.Bottom);
			xPageSettings.bolLandscape = bolLandscape;
			return xPageSettings;
		}
	}
}
