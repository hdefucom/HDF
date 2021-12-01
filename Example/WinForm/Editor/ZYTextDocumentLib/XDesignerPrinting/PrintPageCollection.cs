using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace XDesignerPrinting
{
	public class PrintPageCollection : CollectionBase
	{
		private int intTop = 0;

		private int intMinPageHeight = 100;

		private PageSettings myPageSettings = new PageSettings();

		private int intLeftMargin = 20;

		private int intTopMargin = 30;

		private int intRightMargin = 20;

		private int intBottomMargin = 40;

		private int intPaperWidth = 400;

		private int intPaperHeight = 400;

		private PaperKind intPaperKind = PaperKind.Custom;

		private bool bolLanscape = false;

		private bool bolCustomPageSize = false;

		protected bool bolCustomDrawHeadFooter = false;

		protected PrinterSettings myPrinterSettings = new PrinterSettings();

		private GraphicsUnit intGraphicsUnit = GraphicsUnit.Document;

		protected int intHeadHeight = 0;

		protected int intFooterHeight = 0;

		protected int intDocumentHeight = 0;

		public bool CustomDrawHeadFooter
		{
			get
			{
				return bolCustomDrawHeadFooter;
			}
			set
			{
				bolCustomDrawHeadFooter = value;
			}
		}

		public bool CustomPageSize
		{
			get
			{
				return bolCustomPageSize || PrinterSettings.InstalledPrinters.Count == 0 || myPageSettings == null;
			}
			set
			{
				bolCustomPageSize = value;
			}
		}

		public Rectangle PageBounds => new Rectangle(intLeftMargin, intTopMargin, intPaperWidth - intLeftMargin - intRightMargin, intPaperHeight - intTopMargin - intBottomMargin);

		public XPaperSize PaperSize
		{
			get
			{
				XPaperSize xPaperSize = null;
				if (intPaperKind != 0)
				{
					xPaperSize = XPaperSizeCollection.StdInstance[intPaperKind];
					if (xPaperSize != null)
					{
						return xPaperSize;
					}
				}
				double rate = XPaperSize.GetRate(intGraphicsUnit);
				xPaperSize = new XPaperSize();
				xPaperSize.Kind = intPaperKind;
				if (!bolLanscape)
				{
					xPaperSize.Width = (int)((double)intPaperWidth * rate);
					xPaperSize.Height = (int)((double)intPaperHeight * rate);
				}
				else
				{
					xPaperSize.Width = (int)((double)intPaperHeight * rate);
					xPaperSize.Height = (int)((double)intPaperWidth * rate);
				}
				return xPaperSize;
			}
			set
			{
				intPaperKind = value.Kind;
				XPaperSize xPaperSize = null;
				if (value.Kind != 0)
				{
					xPaperSize = XPaperSizeCollection.StdInstance[value.Kind];
				}
				if (xPaperSize == null)
				{
					xPaperSize = value;
				}
				double rate = XPaperSize.GetRate(intGraphicsUnit);
				if (!bolLanscape)
				{
					intPaperWidth = (int)((double)xPaperSize.Width / rate);
					intPaperHeight = (int)((double)xPaperSize.Height / rate);
				}
				else
				{
					intPaperWidth = (int)((double)xPaperSize.Height / rate);
					intPaperHeight = (int)((double)xPaperSize.Width / rate);
				}
			}
		}

		public XPageSettings PageSettings
		{
			get
			{
				XPageSettings xPageSettings = new XPageSettings();
				double rate = XPaperSize.GetRate(intGraphicsUnit);
				xPageSettings.Margins = new Margins((int)((double)intLeftMargin * rate), (int)((double)intRightMargin * rate), (int)((double)intTopMargin * rate), (int)((double)intBottomMargin * rate));
				xPageSettings.Landscape = bolLanscape;
				xPageSettings.PaperSize = PaperSize;
				return xPageSettings;
			}
			set
			{
				double rate = XPaperSize.GetRate(intGraphicsUnit);
				intPaperKind = value.PaperSize.Kind;
				intLeftMargin = (int)((double)value.Margins.Left / rate);
				intTopMargin = (int)((double)value.Margins.Top / rate);
				intRightMargin = (int)((double)value.Margins.Right / rate);
				intBottomMargin = (int)((double)value.Margins.Bottom / rate);
				bolLanscape = value.Landscape;
				PaperSize = value.PaperSize;
			}
		}

		public PrinterSettings PrinterSettings
		{
			get
			{
				return myPrinterSettings;
			}
			set
			{
				myPrinterSettings = value;
			}
		}

		public GraphicsUnit GraphicsUnit
		{
			get
			{
				return intGraphicsUnit;
			}
			set
			{
				intGraphicsUnit = value;
			}
		}

		public int PaperWidth
		{
			get
			{
				return intPaperWidth;
			}
			set
			{
				intPaperWidth = value;
			}
		}

		public int PaperHeight
		{
			get
			{
				return intPaperHeight;
			}
			set
			{
				intPaperHeight = value;
			}
		}

		public int LeftMargin
		{
			get
			{
				return intLeftMargin;
			}
			set
			{
				intLeftMargin = value;
			}
		}

		public int TopMargin
		{
			get
			{
				return intTopMargin;
			}
			set
			{
				intTopMargin = value;
			}
		}

		public int RightMargin
		{
			get
			{
				return intRightMargin;
			}
			set
			{
				intRightMargin = value;
			}
		}

		public int BottomMargin
		{
			get
			{
				return intBottomMargin;
			}
			set
			{
				intBottomMargin = value;
			}
		}

		public int MinPageHeight
		{
			get
			{
				return intMinPageHeight;
			}
			set
			{
				intMinPageHeight = value;
			}
		}

		public PaperKind PaperKind
		{
			get
			{
				return intPaperKind;
			}
			set
			{
				intPaperKind = value;
				if (value != 0)
				{
					XPaperSize xPaperSize = XPaperSizeCollection.StdInstance[value];
					if (xPaperSize != null)
					{
						PaperSize = xPaperSize;
					}
				}
			}
		}

		public bool Landscape
		{
			get
			{
				return bolLanscape;
			}
			set
			{
				bolLanscape = value;
			}
		}

		public int StandardWidth => intPaperWidth - intLeftMargin - intRightMargin;

		public int StandardHeight => intPaperHeight - intTopMargin - intBottomMargin - intHeadHeight - intFooterHeight;

		public int HeadHeight
		{
			get
			{
				return intHeadHeight;
			}
			set
			{
				intHeadHeight = value;
			}
		}

		public int FooterHeight
		{
			get
			{
				return intFooterHeight;
			}
			set
			{
				intFooterHeight = value;
			}
		}

		public int Top
		{
			get
			{
				return intTop;
			}
			set
			{
				intTop = value;
			}
		}

		public int DocumentHeight
		{
			get
			{
				return intDocumentHeight;
			}
			set
			{
				intDocumentHeight = value;
			}
		}

		public PrintPage FirstPage
		{
			get
			{
				if (base.Count > 0)
				{
					return this[0];
				}
				return null;
			}
		}

		public PrintPage LastPage
		{
			get
			{
				if (base.Count > 0)
				{
					return this[base.Count - 1];
				}
				return null;
			}
		}

		public int Height
		{
			get
			{
				int num = 0;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						PrintPage printPage = (PrintPage)enumerator.Current;
						num += printPage.Height;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return num;
			}
		}

		public int BodyHeight
		{
			get
			{
				int num = 0;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						PrintPage printPage = (PrintPage)enumerator.Current;
						num += printPage.Height - intHeadHeight - intFooterHeight;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return num;
			}
		}

		public PrintPage this[int index] => (PrintPage)base.List[index];

		public PrintPageCollection()
		{
			PageSettings = new XPageSettings();
		}

		public bool ContainsTop(int vTop)
		{
			int num = intTop;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PrintPage printPage = (PrintPage)enumerator.Current;
					num += printPage.Height;
					if (num > vTop)
					{
						return true;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return false;
		}

		public int IndexOf(PrintPage myPage)
		{
			return base.InnerList.IndexOf(myPage);
		}

		public PrintPage NewPage()
		{
			PrintPage printPage = new PrintPage();
			printPage.OwnerPages = this;
			printPage.Height = StandardHeight;
			printPage.Width = StandardWidth;
			return printPage;
		}

		public void Add(PrintPage myPage)
		{
			if (!base.InnerList.Contains(myPage))
			{
				base.InnerList.Add(myPage);
			}
		}

		public void Remove(PrintPage myPage)
		{
			base.InnerList.Remove(myPage);
		}

		public bool Contains(PrintPage page)
		{
			return base.List.Contains(page);
		}

		public int GetPageMaxWidth()
		{
			int num = 0;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PrintPage printPage = (PrintPage)enumerator.Current;
					if (printPage.Width > num)
					{
						num = printPage.Width;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return num + intLeftMargin + intRightMargin;
		}

		public PrintPage GetPage(int y)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PrintPage printPage = (PrintPage)enumerator.Current;
					if (y >= printPage.ClientBounds.Top && y <= printPage.ClientBounds.Bottom)
					{
						return printPage;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}
	}
}
