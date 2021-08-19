using System;
using System.Collections;
using System.Drawing;
using XDesignerCommon;
using XDesignerGUI;

namespace XDesignerPrinting
{
	public class MultiPageTransform : MultiRectangleTransform
	{
		protected PrintPageCollection myPages = null;

		protected bool bolUseAbsTransformPoint = false;

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

		public bool UseAbsTransformPoint
		{
			get
			{
				return bolUseAbsTransformPoint;
			}
			set
			{
				bolUseAbsTransformPoint = value;
			}
		}

		public void AddPage(PrintPage page, int PageTop, float ZoomRate)
		{
			Rectangle empty = Rectangle.Empty;
			int num = (int)((float)myPages.LeftMargin * ZoomRate);
			int num2 = (int)((float)myPages.TopMargin * ZoomRate);
			int num3 = (int)((float)myPages.RightMargin * ZoomRate);
			int num4 = (int)((float)myPages.BottomMargin * ZoomRate);
			int num5 = (int)((float)myPages.PaperWidth * ZoomRate);
			int num6 = (int)((float)myPages.PaperHeight * ZoomRate);
			int top = PageTop + num2;
			SimpleRectangleTransform simpleRectangleTransform = null;
			if (myPages.HeadHeight > 0)
			{
				simpleRectangleTransform = new SimpleRectangleTransform();
				simpleRectangleTransform.PageIndex = page.Index;
				simpleRectangleTransform.Flag2 = 0;
				simpleRectangleTransform.Tag = page;
				simpleRectangleTransform.DescRect = new Rectangle(0, 0, page.Width, myPages.HeadHeight);
				top = SetSourceRect(simpleRectangleTransform, ZoomRate, num, top);
				Add(simpleRectangleTransform);
			}
			simpleRectangleTransform = new SimpleRectangleTransform();
			simpleRectangleTransform.PageIndex = page.Index;
			simpleRectangleTransform.Flag2 = 1;
			simpleRectangleTransform.Tag = page;
			simpleRectangleTransform.DescRect = new Rectangle(0, page.Top, page.Width, page.Height);
			top = SetSourceRect(simpleRectangleTransform, ZoomRate, num, top);
			Add(simpleRectangleTransform);
			if (myPages.FooterHeight > 0)
			{
				simpleRectangleTransform = new SimpleRectangleTransform();
				simpleRectangleTransform.PageIndex = page.Index;
				simpleRectangleTransform.Flag2 = 2;
				simpleRectangleTransform.Tag = page;
				simpleRectangleTransform.DescRect = new Rectangle(0, myPages.DocumentHeight - myPages.FooterHeight, page.Width, myPages.FooterHeight);
				SetSourceRect(simpleRectangleTransform, ZoomRate, num, top);
				empty = simpleRectangleTransform.SourceRect;
				top = PageTop + num6 - num4 - empty.Height;
				simpleRectangleTransform.SourceRect = new Rectangle(num, top, empty.Width, empty.Height);
				Add(simpleRectangleTransform);
			}
		}

		public void Refresh(float ZoomRate, int PageSplitBlank)
		{
			int num = (int)((float)myPages.LeftMargin * ZoomRate);
			int num2 = (int)((float)myPages.PaperHeight * ZoomRate);
			mySourceOffsetBack = Point.Empty;
			Clear();
			int num3 = 0;
			foreach (PrintPage myPage in myPages)
			{
				int pageTop = (num2 + PageSplitBlank) * num3 + PageSplitBlank;
				num3++;
				AddPage(myPage, pageTop, ZoomRate);
			}
		}

		private int SetSourceRect(SimpleRectangleTransform item, float ZoomRate, int left, int Top)
		{
			RectangleF sourceRectF = Rectangle.Empty;
			sourceRectF.X = left;
			sourceRectF.Y = Top;
			sourceRectF.Width = item.DescRectF.Width * ZoomRate;
			sourceRectF.Height = item.DescRectF.Height * ZoomRate;
			item.SourceRectF = sourceRectF;
			return (int)Math.Ceiling((float)Top + sourceRectF.Height);
		}

		public override Point TransformPoint(int x, int y)
		{
			if (bolUseAbsTransformPoint)
			{
				return AbsTransformPoint(x, y);
			}
			return base.TransformPoint(x, y);
		}

		public override bool ContainsSourcePoint(int x, int y)
		{
			if (bolUseAbsTransformPoint)
			{
				return true;
			}
			return base.ContainsSourcePoint(x, y);
		}

		public Point AbsTransformPoint(int x, int y)
		{
			SimpleRectangleTransform simpleRectangleTransform = null;
			SimpleRectangleTransform simpleRectangleTransform2 = null;
			SimpleRectangleTransform simpleRectangleTransform3 = null;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform4 = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform4.Enable)
					{
						if (simpleRectangleTransform4.SourceRect.Contains(x, y))
						{
							return simpleRectangleTransform4.TransformPoint(x, y);
						}
						if ((float)y >= simpleRectangleTransform4.SourceRectF.Top && (float)y <= simpleRectangleTransform4.SourceRectF.Bottom)
						{
							simpleRectangleTransform3 = simpleRectangleTransform4;
							break;
						}
						if ((float)y < simpleRectangleTransform4.SourceRectF.Top && (simpleRectangleTransform2 == null || simpleRectangleTransform4.SourceRectF.Top < simpleRectangleTransform2.SourceRectF.Top))
						{
							simpleRectangleTransform2 = simpleRectangleTransform4;
						}
						if ((float)y > simpleRectangleTransform4.SourceRectF.Bottom && (simpleRectangleTransform == null || simpleRectangleTransform4.SourceRectF.Bottom > simpleRectangleTransform.SourceRectF.Bottom))
						{
							simpleRectangleTransform = simpleRectangleTransform4;
						}
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
			if (simpleRectangleTransform3 == null)
			{
				simpleRectangleTransform3 = ((simpleRectangleTransform == null) ? simpleRectangleTransform2 : simpleRectangleTransform);
			}
			if (simpleRectangleTransform3 == null)
			{
				return Point.Empty;
			}
			Point p = new Point(x, y);
			p = RectangleCommon.MoveInto(p, simpleRectangleTransform3.SourceRect);
			return simpleRectangleTransform3.TransformPoint(p);
		}
	}
}
