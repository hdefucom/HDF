using System;
using System.Drawing;
using XDesignerDrawer;
using XDesignerGUI;

namespace XDesignerPrinting
{
	public class DocumentPageDrawer
	{
		protected IPageDocument myDocument = null;

		protected PrintPageCollection myPages = null;

		protected bool bolDrawHead = true;

		protected bool bolDrawFooter = true;

		protected Color intBackColor = Color.White;

		protected Color intBorderColor = Color.Transparent;

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

		public PrintPageCollection Pages
		{
			get
			{
				return myPages;
			}
			set
			{
				myPages = value;
			}
		}

		public bool DrawHead
		{
			get
			{
				return bolDrawHead;
			}
			set
			{
				bolDrawHead = value;
			}
		}

		public bool DrawFooter
		{
			get
			{
				return bolDrawFooter;
			}
			set
			{
				bolDrawFooter = value;
			}
		}

		public Color BackColor
		{
			get
			{
				return intBackColor;
			}
			set
			{
				intBackColor = value;
			}
		}

		public Color BorderColor
		{
			get
			{
				return intBorderColor;
			}
			set
			{
				intBorderColor = value;
			}
		}

		public DocumentPageDrawer()
		{
		}

		public DocumentPageDrawer(IPageDocument doc, PrintPageCollection pages)
		{
			myDocument = doc;
			myPages = pages;
		}

		public static Bitmap GetPageBmp(IPageDocument doc, PrintPageCollection pages, int PageIndex, bool DrawBorder)
		{
			DocumentPageDrawer documentPageDrawer = new DocumentPageDrawer();
			documentPageDrawer.Document = doc;
			documentPageDrawer.Pages = pages;
			documentPageDrawer.BackColor = Color.White;
			if (DrawBorder)
			{
				documentPageDrawer.BorderColor = Color.Black;
			}
			else
			{
				documentPageDrawer.BorderColor = Color.Transparent;
			}
			return documentPageDrawer.GetPageBmp(pages[PageIndex], DrawMargin: true);
		}

		public Bitmap GetPageBmp(int PageIndex, bool DrawMargin)
		{
			return GetPageBmp(myPages[PageIndex], DrawMargin);
		}

		public Bitmap GetPageBmp(PrintPage page, bool DrawMargin)
		{
			double rate = GraphicsUnitConvert.GetRate(myDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			int width = (int)Math.Ceiling((double)myPages.PaperWidth / rate);
			int height = (int)Math.Ceiling((double)myPages.PaperHeight / rate);
			Bitmap bitmap = new Bitmap(width, height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				if (intBackColor.A != 0)
				{
					graphics.Clear(intBackColor);
				}
				graphics.PageUnit = myDocument.DocumentGraphicsUnit;
				PageFrameDrawer pageFrameDrawer = new PageFrameDrawer();
				pageFrameDrawer.DrawMargin = DrawMargin;
				pageFrameDrawer.BackColor = Color.Transparent;
				pageFrameDrawer.BorderColor = intBorderColor;
				pageFrameDrawer.BorderWidth = 1;
				pageFrameDrawer.LeftMargin = myPages.LeftMargin;
				pageFrameDrawer.TopMargin = myPages.TopMargin;
				pageFrameDrawer.RightMargin = myPages.RightMargin;
				pageFrameDrawer.BottomMargin = myPages.BottomMargin;
				pageFrameDrawer.Bounds = new Rectangle(0, 0, myPages.PaperWidth, myPages.PaperHeight);
				pageFrameDrawer.DrawPageFrame(graphics, Rectangle.Empty);
				DrawPage(page, graphics, page.Bounds, UseMargin: true);
			}
			return bitmap;
		}

		protected virtual void OnBeforeDrawPage(PrintPage page, Graphics g)
		{
			myDocument.PageIndex = page.Index;
		}

		public virtual void DrawPage(PrintPage myPage, Graphics g, Rectangle MainClipRect, bool UseMargin)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (UseMargin)
			{
				num = myPages.LeftMargin;
				num2 = myPages.TopMargin;
				num3 = myPages.RightMargin;
				num4 = myPages.BottomMargin;
			}
			OnBeforeDrawPage(myPage, g);
			g.PageUnit = myDocument.DocumentGraphicsUnit;
			Rectangle empty = Rectangle.Empty;
			if (bolDrawHead)
			{
				if (myPages.HeadHeight > 0)
				{
					g.ResetTransform();
					g.ResetClip();
					empty = new Rectangle(0, 0, myPage.Width, myPages.HeadHeight);
					g.TranslateTransform(num, num2);
					g.SetClip(new Rectangle(empty.Left, empty.Top, empty.Width + 1, empty.Height + 1));
					myDocument.DrawHead(g, empty);
				}
				g.ResetClip();
				g.ResetTransform();
			}
			empty = new Rectangle(0, myPages.Top, myPage.Width, myPages.Height);
			if (!MainClipRect.IsEmpty)
			{
				empty = Rectangle.Intersect(empty, MainClipRect);
			}
			if (!empty.IsEmpty)
			{
				g.TranslateTransform(num, num2 - myPage.Top + myPages.HeadHeight);
				RectangleF clip = DrawerUtil.FixClipBounds(g, empty.Left, empty.Top, empty.Width, empty.Height);
				clip.Offset(-4f, -4f);
				clip.Width += 8f;
				clip.Height += 8f;
				g.SetClip(clip);
				myDocument.DrawDocument(g, empty);
			}
			if (bolDrawFooter && myPages.FooterHeight > 0)
			{
				g.ResetClip();
				g.ResetTransform();
				empty = new Rectangle(0, myPages.DocumentHeight - myPages.FooterHeight, myPage.Width, myPages.FooterHeight);
				int num5 = 0;
				num5 = ((!UseMargin) ? (myPages.PaperHeight - myPages.BottomMargin - myPages.DocumentHeight - myPages.TopMargin) : (myPages.PaperHeight - myPages.BottomMargin - myPages.DocumentHeight));
				g.TranslateTransform(num, num5);
				g.SetClip(new Rectangle(empty.Left, empty.Top, empty.Width + 1, empty.Height + 1));
				myDocument.DrawFooter(g, empty);
			}
		}
	}
}
