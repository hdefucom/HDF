using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;

namespace XDesignerPrinting
{
	[Browsable(false)]
	public class XPrintDocument : PrintDocument
	{
		protected IPageDocument myDocument = null;

		protected int intPageIndex = 0;

		protected bool bolEnableJumpPrint = false;

		protected int intJumpPrintPosition = 100;

		private int intSpecialPageIndex = -1;

		protected bool bolFirstPage = true;

		public IPageDocument Document
		{
			get
			{
				return myDocument;
			}
			set
			{
				myDocument = value;
			}
		}

		public int PageIndex => intPageIndex;

		public bool EnableJumpPrint
		{
			get
			{
				return bolEnableJumpPrint;
			}
			set
			{
				bolEnableJumpPrint = value;
			}
		}

		public int JumpPrintPosition
		{
			get
			{
				return intJumpPrintPosition;
			}
			set
			{
				intJumpPrintPosition = value;
			}
		}

		public void PrintSpecialPage(int vPageIndex)
		{
			intSpecialPageIndex = vPageIndex;
			intPageIndex = vPageIndex;
			Print();
			intSpecialPageIndex = -1;
		}

		protected override void OnBeginPrint(PrintEventArgs e)
		{
			if (myDocument != null)
			{
				bolFirstPage = true;
				intPageIndex = GetStartPageIndex();
				if (intSpecialPageIndex >= 0)
				{
					intPageIndex = intSpecialPageIndex;
				}
				base.PrinterSettings = myDocument.Pages.PrinterSettings;
			}
			else
			{
				intPageIndex = 0;
			}
			base.OnBeginPrint(e);
		}

		private int GetStartPageIndex()
		{
			if (bolEnableJumpPrint && intJumpPrintPosition > 0)
			{
				for (int i = 0; i < myDocument.Pages.Count; i++)
				{
					if (myDocument.Pages[i].Bottom > intJumpPrintPosition)
					{
						return i;
					}
				}
			}
			return 0;
		}

		protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
		{
			if (myDocument != null)
			{
				PageSettings stdPageSettings = myDocument.Pages.PageSettings.StdPageSettings;
				stdPageSettings.PrinterSettings.Copies = e.PageSettings.PrinterSettings.Copies;
				foreach (PaperSize paperSize in base.PrinterSettings.PaperSizes)
				{
					if (stdPageSettings.PaperSize.PaperName == paperSize.PaperName)
					{
						stdPageSettings.PaperSize = paperSize;
						break;
					}
				}
				e.PageSettings = stdPageSettings;
				if (myDocument.Pages.PrinterSettings != null)
				{
					base.PrinterSettings = myDocument.Pages.PrinterSettings;
				}
			}
			base.OnQueryPageSettings(e);
		}

		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			if (myDocument != null)
			{
				if (bolFirstPage)
				{
				}
				bolFirstPage = false;
				if (intSpecialPageIndex >= 0 && intSpecialPageIndex < myDocument.Pages.Count)
				{
					if (intPageIndex == intSpecialPageIndex)
					{
						InnerPrintPage(e);
						e.HasMorePages = false;
					}
				}
				else
				{
					InnerPrintPage(e);
				}
			}
			intPageIndex++;
			base.OnPrintPage(e);
		}

		protected void InnerPrintPage(PrintPageEventArgs e)
		{
			if (intPageIndex >= 0 && intPageIndex <= myDocument.Pages.Count)
			{
				PrintPage printPage = myDocument.Pages[intPageIndex];
				myDocument.PageIndex = intPageIndex;
				Rectangle mainClipRect = new Rectangle(printPage.Left, printPage.Top, printPage.Width, printPage.Height);
				bool flag = false;
				if (bolEnableJumpPrint && intJumpPrintPosition > 0 && intJumpPrintPosition > printPage.Top && intJumpPrintPosition < printPage.Bottom)
				{
					int num = intJumpPrintPosition - printPage.Top;
					mainClipRect.Offset(0, num);
					mainClipRect.Height -= num;
					flag = true;
				}
				if (flag)
				{
					PaintPage(printPage, e.Graphics, mainClipRect, DrawHead: false, DrawFooter: false);
				}
				else
				{
					PaintPage(printPage, e.Graphics, mainClipRect, DrawHead: true, DrawFooter: true);
				}
				e.HasMorePages = (intPageIndex != myDocument.Pages.Count - 1);
			}
			else
			{
				e.HasMorePages = false;
			}
		}

		protected void PaintPage(PrintPage myPage, Graphics g, Rectangle MainClipRect, bool DrawHead, bool DrawFooter)
		{
			DocumentPageDrawer documentPageDrawer = new DocumentPageDrawer(myDocument, myDocument.Pages);
			documentPageDrawer.DrawFooter = DrawFooter;
			documentPageDrawer.DrawHead = DrawHead;
			documentPageDrawer.DrawPage(myPage, g, MainClipRect, UseMargin: true);
		}
	}
}
