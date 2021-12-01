using System.Drawing;
using System.Drawing.Printing;

namespace XDesignerPrinting
{
	public class PrintPage
	{
		private PrinterSettings myPageSettings = null;

		private int intHeight = 0;

		private int intWidth = 0;

		private PrintPageCollection myOwnerPages = null;

		protected Rectangle myClientBounds = Rectangle.Empty;

		protected int intLeft = 0;

		public Rectangle Bounds => new Rectangle(0, Top, intWidth, intHeight);

		public Rectangle ClientBounds
		{
			get
			{
				return myClientBounds;
			}
			set
			{
				myClientBounds = value;
			}
		}

		public int Left
		{
			get
			{
				return intLeft;
			}
			set
			{
				intLeft = value;
			}
		}

		public int Right => intLeft + intWidth;

		public PrintPageCollection OwnerPages
		{
			get
			{
				return myOwnerPages;
			}
			set
			{
				myOwnerPages = value;
				if (intHeight < myOwnerPages.MinPageHeight)
				{
					intHeight = myOwnerPages.MinPageHeight;
				}
			}
		}

		public int PageIndex => myOwnerPages.IndexOf(this) + 1;

		public int Top
		{
			get
			{
				int num = myOwnerPages.Top;
				foreach (PrintPage myOwnerPage in myOwnerPages)
				{
					if (myOwnerPage == this)
					{
						break;
					}
					num += myOwnerPage.Height;
				}
				return num;
			}
		}

		public int Bottom
		{
			get
			{
				return Top + intHeight;
			}
			set
			{
				intHeight = value - Top;
				FixHeight();
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
				intWidth = value;
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
				intHeight = value;
				FixHeight();
			}
		}

		public PrinterSettings PageSettings
		{
			get
			{
				return myPageSettings;
			}
			set
			{
				myPageSettings = value;
			}
		}

		public int Index => myOwnerPages.IndexOf(this);

		private void FixHeight()
		{
			if (intHeight < myOwnerPages.MinPageHeight)
			{
				intHeight = myOwnerPages.MinPageHeight;
			}
			if (intHeight > myOwnerPages.StandardHeight)
			{
				intHeight = myOwnerPages.StandardHeight;
			}
		}
	}
}
