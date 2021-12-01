using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextObject : ZYTextElement
	{
		public static int DragBoxSize = 6;

		protected bool bolCanResize = true;

		protected double dblWidthHeightRate = 0.0;

		public double WidthHeightRate
		{
			get
			{
				return dblWidthHeightRate;
			}
			set
			{
				dblWidthHeightRate = value;
			}
		}

		public bool CanResize
		{
			get
			{
				return bolCanResize;
			}
			set
			{
				bolCanResize = value;
			}
		}

		public string ID
		{
			get
			{
				return myAttributes.GetString("id");
			}
			set
			{
				myAttributes.SetValue("id", value);
			}
		}

		public override int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
				myAttributes.SetValue("width", value.ToString());
			}
		}

		public override int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
				myAttributes.SetValue("height", value.ToString());
			}
		}

		public override void UpdateAttrubute()
		{
			base.Width = StringCommon.ToInt32Value(myAttributes.GetString("width"), base.Width);
			base.Height = StringCommon.ToInt32Value(myAttributes.GetString("height"), base.Height);
			base.UpdateAttrubute();
		}

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			int dragRectSize = myOwnerDocument.PixelToDocumentUnit(DragBoxSize);
			if (ShowDragRect())
			{
				Rectangle[] dragRects = DocumentView.GetDragRects(new Rectangle(RealLeft, RealTop, Width - 1, Height - 1), dragRectSize, InnerDragRect: true);
				for (int i = 0; i < dragRects.Length; i++)
				{
					if (!dragRects[i].Contains(x, y))
					{
						continue;
					}
					if (myOwnerDocument.OwnerControl != null)
					{
						Rectangle rectangle = myOwnerDocument.OwnerControl.CaptureDragRect(Bounds, i, DrawFocusRect: true, dblWidthHeightRate, ShowSizeInfo: true, null);
						if (rectangle.Width > 10 && rectangle.Height > 10)
						{
							myOwnerDocument.BeginContentChangeLog();
							Width = rectangle.Width;
							Height = rectangle.Height;
							myOwnerDocument.EndContentChangeLog();
							myOwnerDocument.RefreshLine();
							myOwnerDocument.UpdateView();
							myOwnerDocument.Modified = true;
							return true;
						}
					}
					return true;
				}
			}
			return false;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			int dragRectSize = myOwnerDocument.PixelToDocumentUnit(DragBoxSize);
			if (ShowDragRect())
			{
				Rectangle[] dragRects = DocumentView.GetDragRects(new Rectangle(RealLeft, RealTop, Width - 1, Height - 1), dragRectSize, InnerDragRect: true);
				for (int i = 0; i < dragRects.Length; i++)
				{
					if (dragRects[i].Contains(x, y))
					{
						Cursor dragRectCursor = DocumentView.GetDragRectCursor(i);
						if (dragRectCursor != null)
						{
							myOwnerDocument.SetCursor(dragRectCursor);
						}
						return true;
					}
				}
			}
			if (Bounds.Contains(x, y))
			{
				myOwnerDocument.SetCursor(Cursors.Default);
			}
			return false;
		}

		public override bool HandleClick(int x, int y, MouseButtons Button)
		{
			if (Bounds.Contains(x, y) && myOwnerDocument.Content.SelectLength == 0)
			{
				myOwnerDocument.Content.SetSelection(myOwnerDocument.IndexOf(this), 1);
				myOwnerDocument.RefreshElement(this);
				myOwnerDocument.HideCaret();
				return true;
			}
			return false;
		}

		public override bool RefreshView()
		{
			int dragRectSize = myOwnerDocument.PixelToDocumentUnit(DragBoxSize);
			if (myOwnerDocument.isSelected(this))
			{
				if (ShowDragRect())
				{
					myOwnerDocument.View.DrawRectangle(Color.Black, new Rectangle(RealLeft, RealTop, Width - 1, Height - 1));
					myOwnerDocument.View.DrawDragRect(new Rectangle(RealLeft, RealTop, Width - 1, Height - 1), dragRectSize, InnerDragRect: true, Color.Black, Color.White);
				}
				else if (!Deleteted && myOwnerDocument.Content.CurrentSelectElement == this)
				{
					myOwnerDocument.View.DrawRectangle(Color.Black, new Rectangle(RealLeft, RealTop, Width - 1, Height - 1));
				}
			}
			return true;
		}

		protected bool ShowDragRect()
		{
			if (myOwnerDocument.IsLock(this))
			{
				return false;
			}
			return bolCanResize && !myParent.Locked && !Deleteted && myOwnerDocument.Content.CurrentSelectElement == this;
		}
	}
}
