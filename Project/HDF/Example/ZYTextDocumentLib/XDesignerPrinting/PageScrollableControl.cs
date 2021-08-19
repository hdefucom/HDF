using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using XDesignerCommon;
using XDesignerDrawer;
using XDesignerGUI;

namespace XDesignerPrinting
{
	public class PageScrollableControl : DocumentViewControl
	{
		protected UpdateLock myUpdateLock = new UpdateLock();

		protected PageViewMode intViewMode = PageViewMode.Page;

		protected PrintPage myCurrentPage = null;

		protected PrintPageCollection myPages = new PrintPageCollection();

		private Margins myClientMargins = new Margins();

		private Size myClientPageSize = Size.Empty;

		protected Color intPageBackColor = Color.White;

		protected int intPageSpacing = 20;

		protected RectangleCounter myInvalidateRect = new RectangleCounter();

		public bool Updating => myUpdateLock.Updating;

		[Browsable(false)]
		public PageViewMode ViewMode
		{
			get
			{
				return intViewMode;
			}
			set
			{
				intViewMode = value;
			}
		}

		[Browsable(false)]
		public PrintPage CurrentPage
		{
			get
			{
				return myCurrentPage;
			}
			set
			{
				myCurrentPage = value;
				if (myCurrentPage != null)
				{
					int top = myCurrentPage.ClientBounds.Top;
					SetAutoScrollPosition(new Point(base.AutoScrollPosition.X, top));
				}
			}
		}

		[Browsable(false)]
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

		public MultiPageTransform PagesTransform => (MultiPageTransform)myTransform;

		public Color PageBackColor
		{
			get
			{
				return intPageBackColor;
			}
			set
			{
				intPageBackColor = value;
			}
		}

		public int PageSpacing
		{
			get
			{
				return intPageSpacing;
			}
			set
			{
				intPageSpacing = value;
			}
		}

		[Browsable(false)]
		public int PageCount
		{
			get
			{
				if (myPages != null)
				{
					return myPages.Count;
				}
				return 0;
			}
		}

		[Browsable(false)]
		public RectangleCounter InvalidateRect => myInvalidateRect;

		[Browsable(false)]
		public bool UseAbsTransformPoint
		{
			get
			{
				return ((MultiPageTransform)myTransform).UseAbsTransformPoint;
			}
			set
			{
				((MultiPageTransform)myTransform).UseAbsTransformPoint = value;
			}
		}

		[Browsable(false)]
		public int PageIndex
		{
			get
			{
				if (myCurrentPage == null)
				{
					return 0;
				}
				return myCurrentPage.Index;
			}
			set
			{
				MoveToPage(value);
			}
		}

		public event EventHandler CurrentPageChanged = null;

		public PageScrollableControl()
		{
			myTransform = new MultiPageTransform();
			myUpdateLock.BindControl = this;
		}

		public void BeginUpdate()
		{
			myUpdateLock.BeginUpdate();
		}

		public void EndUpdate()
		{
			myUpdateLock.EndUpdate();
		}

		protected bool UpdateCurrentPage()
		{
			if (myPages != null)
			{
				MultiPageTransform multiPageTransform = (MultiPageTransform)myTransform;
				PrintPage printPage = null;
				Rectangle b = new Rectangle(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y, base.ClientSize.Width, base.ClientSize.Height);
				int num = 0;
				foreach (PrintPage myPage in myPages)
				{
					Rectangle rectangle = Rectangle.Intersect(myPage.ClientBounds, b);
					if (!rectangle.IsEmpty && num < rectangle.Height)
					{
						printPage = myPage;
						num = rectangle.Height;
					}
				}
				if (printPage != myCurrentPage)
				{
					myCurrentPage = printPage;
					return true;
				}
			}
			return false;
		}

		protected virtual void OnCurrentPageChanged()
		{
			if (this.CurrentPageChanged != null)
			{
				this.CurrentPageChanged(this, null);
			}
		}

		protected override void RefreshScaleTransform()
		{
			MultiPageTransform multiPageTransform = (MultiPageTransform)myTransform;
			intGraphicsUnit = myPages.GraphicsUnit;
			multiPageTransform.Rate = GraphicsUnitConvert.GetRate(intGraphicsUnit, GraphicsUnit.Pixel);
			Point autoScrollPosition = base.AutoScrollPosition;
			multiPageTransform.ClearSourceOffset();
			multiPageTransform.OffsetSource(autoScrollPosition.X, autoScrollPosition.Y, Remark: true);
		}

		public virtual void UpdatePages()
		{
			if (!StackTraceHelper.CheckRecursion())
			{
				float num = (float)(1.0 / base.ClientToViewXRate);
				Size size = new Size((int)((float)myPages.PaperWidth * num), (int)((float)myPages.PaperHeight * num));
				Size size2 = new Size(size.Width + intPageSpacing * 2, (size.Height + intPageSpacing) * myPages.Count + intPageSpacing);
				if (!base.AutoScrollMinSize.Equals(size2))
				{
					base.AutoScrollMinSize = size2;
				}
				MultiPageTransform multiPageTransform = (MultiPageTransform)myTransform;
				intGraphicsUnit = myPages.GraphicsUnit;
				multiPageTransform.Pages = myPages;
				multiPageTransform.Refresh(num, intPageSpacing);
				myClientMargins = new Margins((int)((float)myPages.LeftMargin * num), (int)((float)myPages.RightMargin * num), (int)((float)myPages.TopMargin * num), (int)((float)myPages.BottomMargin * num));
				myClientPageSize = new Size((int)((float)myPages.PaperWidth * num), (int)((float)myPages.PaperHeight * num));
				int width = base.ClientSize.Width;
				int num2 = 0;
				num2 = ((width > size2.Width) ? ((width - size2.Width) / 2 + intPageSpacing) : intPageSpacing);
				multiPageTransform.OffsetSource(num2, 0, Remark: false);
				RefreshScaleTransform();
				Rectangle empty = Rectangle.Empty;
				for (int i = 0; i < myPages.Count; i++)
				{
					empty.X = num2;
					empty.Y = (size.Height + intPageSpacing) * i + intPageSpacing;
					empty.Width = size.Width;
					empty.Height = size.Height;
					myPages[i].ClientBounds = empty;
				}
				UpdateCurrentPage();
			}
		}

		public void AddInvalidateRect(Rectangle myRect)
		{
			myInvalidateRect.Add(myRect);
		}

		public void AddInvalidateRect(int x, int y, int width, int height)
		{
			myInvalidateRect.Add(x, y, width, height);
		}

		public void UpdateInvalidateRect()
		{
			if (!myInvalidateRect.IsEmpty)
			{
				ViewInvalidate(myInvalidateRect.Value);
				myInvalidateRect.Clear();
			}
		}

		public override void ViewInvalidate(Rectangle ViewBounds)
		{
			MultiPageTransform multiPageTransform = myTransform as MultiPageTransform;
			if (multiPageTransform == null)
			{
				base.ViewInvalidate(ViewBounds);
			}
			else
			{
				foreach (SimpleRectangleTransform item in multiPageTransform)
				{
					Rectangle rect = Rectangle.Intersect(item.DescRect, ViewBounds);
					if (!rect.IsEmpty)
					{
						rect = item.UnTransformRectangle(rect);
						Invalidate(rect);
					}
				}
			}
		}

		public void FirstPage()
		{
			MoveToPage(0);
		}

		public void NextPage()
		{
			if (myCurrentPage == null)
			{
				MoveToPage(0);
			}
			else
			{
				MoveToPage(myCurrentPage.Index + 1);
			}
		}

		public void PrePage()
		{
			if (myCurrentPage == null)
			{
				MoveToPage(0);
			}
			else
			{
				MoveToPage(myCurrentPage.Index - 1);
			}
		}

		public void LastPage()
		{
			if (myPages != null)
			{
				MoveToPage(myPages.Count - 1);
			}
		}

		public void MoveToPage(int PageIndex)
		{
			if (myPages != null && PageIndex >= 0 && PageIndex < myPages.Count)
			{
				PrintPage printPage = myPages[PageIndex];
				SetAutoScrollPosition(new Point(0, printPage.ClientBounds.Top));
				myCurrentPage = printPage;
				Invalidate();
			}
		}

		protected override void OnScroll()
		{
			base.OnScroll();
			if (myPages != null)
			{
				PrintPage myPage = myCurrentPage;
				if (UpdateCurrentPage())
				{
					using (Graphics g = CreateGraphics())
					{
						DrawPageFrame(myPage, g, Focused: false, FillBackGround: false);
						DrawPageFrame(CurrentPage, g, Focused: true, FillBackGround: false);
					}
					OnCurrentPageChanged();
				}
			}
		}

		protected void DrawPageFrame(PrintPage myPage, Graphics g, bool Focused, bool FillBackGround)
		{
			if (myPage != null && myPages.Contains(myPage))
			{
				Rectangle clientBounds = myPage.ClientBounds;
				clientBounds.Offset(base.AutoScrollPosition);
				PageFrameDrawer.DrawPageFrame(clientBounds, myClientMargins, g, Rectangle.Empty, Focused, FillBackGround);
			}
		}

		protected Rectangle GetViewClipRectangle(Rectangle rect)
		{
			double clientToViewXRate = base.ClientToViewXRate;
			double clientToViewYRate = base.ClientToViewYRate;
			rect.X = (int)((double)rect.X * clientToViewXRate);
			rect.Y = (int)((double)rect.Y * clientToViewYRate);
			rect.Width = (int)((double)rect.Width * clientToViewXRate);
			rect.Height = (int)((double)rect.Height * clientToViewYRate);
			return rect;
		}

		protected int GetJumpPrintPosition(int x, int y)
		{
			MultiPageTransform multiPageTransform = (MultiPageTransform)myTransform;
			if (multiPageTransform.ContainsSourcePoint(x, y))
			{
				int y2 = myTransform.TransformPoint(x, y).Y;
				if (y2 >= 0)
				{
					return y2;
				}
			}
			return 0;
		}

		protected void DrawJumpPrintArea(Graphics g, Rectangle ClipRectangle, int Position, Color FillColor)
		{
			MultiPageTransform multiPageTransform = (MultiPageTransform)myTransform;
			int num = multiPageTransform.UnTransformY(Position);
			if (num >= 0)
			{
				Rectangle rectangle = new Rectangle(0, 0, base.ClientSize.Width, num);
				Rectangle b = ClipRectangle;
				b = ((!ClipRectangle.IsEmpty) ? Rectangle.Intersect(rectangle, b) : rectangle);
				if (!b.IsEmpty)
				{
					g.ResetClip();
					g.PageUnit = GraphicsUnit.Pixel;
					g.ResetTransform();
					using (SolidBrush brush = new SolidBrush(FillColor))
					{
						g.FillRectangle(brush, b);
					}
					using (Pen pen = new Pen(Color.Blue, 2f))
					{
						g.DrawLine(pen, 0, rectangle.Bottom - 1, base.ClientSize.Width, rectangle.Bottom - 1);
					}
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!myUpdateLock.Updating)
			{
				Rectangle clipRectangle = e.ClipRectangle;
				Point autoScrollPosition = base.AutoScrollPosition;
				RefreshScaleTransform();
				MultiPageTransform multiPageTransform = (MultiPageTransform)myTransform;
				Graphics graphics = e.Graphics;
				foreach (PrintPage myPage in myPages)
				{
					Rectangle clientBounds = myPage.ClientBounds;
					clientBounds.Offset(autoScrollPosition);
					if (clientBounds.IntersectsWith(clipRectangle))
					{
						GraphicsState gstate = e.Graphics.Save();
						e.Graphics.ResetTransform();
						e.Graphics.PageUnit = GraphicsUnit.Pixel;
						e.Graphics.ResetClip();
						PageFrameDrawer.DrawPageFrame(clientBounds, myClientMargins, e.Graphics, clipRectangle, myPage == myCurrentPage, FillBackground: true);
						e.Graphics.Restore(gstate);
						foreach (SimpleRectangleTransform item in multiPageTransform)
						{
							if (item.Visible && item.Tag == myPage && !Rectangle.Intersect(e.ClipRectangle, item.SourceRect).IsEmpty)
							{
								TransformPaint(e, item);
							}
						}
					}
				}
				base.OnPaint(e);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			UpdatePages();
			base.OnResize(e);
		}

		protected virtual void SetPageIndex(int index)
		{
		}
	}
}
