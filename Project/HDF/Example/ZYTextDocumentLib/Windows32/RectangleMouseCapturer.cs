using System.Drawing;
using System.Windows.Forms;
using XDesignerCommon;

namespace Windows32
{
	public class RectangleMouseCapturer : MouseCapturer
	{
		protected int intDragStyle = 0;

		protected Rectangle mySourceRectangle = Rectangle.Empty;

		protected Rectangle myDescRectangle = Rectangle.Empty;

		protected bool bolCustomAction = false;

		public int DragStyle
		{
			get
			{
				return intDragStyle;
			}
			set
			{
				intDragStyle = value;
			}
		}

		public Rectangle SourceRectangle
		{
			get
			{
				return mySourceRectangle;
			}
			set
			{
				mySourceRectangle = value;
			}
		}

		public Rectangle DescRectangle
		{
			get
			{
				return myDescRectangle;
			}
			set
			{
				myDescRectangle = value;
			}
		}

		public bool CustomAction
		{
			get
			{
				return bolCustomAction;
			}
			set
			{
				bolCustomAction = value;
			}
		}

		public Rectangle CurrentRectangle => RectangleCommon.GetRectangle(base.StartPosition, base.CurrentPosition);

		public RectangleMouseCapturer()
		{
		}

		public RectangleMouseCapturer(Control ctl)
		{
			myBindControl = ctl;
		}

		public Rectangle UpdateRectangle(Rectangle rect, int dx, int dy)
		{
			if (intDragStyle == -1)
			{
				rect.Offset(dx, dy);
			}
			if (intDragStyle == 0 || intDragStyle == 7 || intDragStyle == 6)
			{
				rect.Offset(dx, 0);
				rect.Width -= dx;
			}
			if (intDragStyle == 0 || intDragStyle == 1 || intDragStyle == 2)
			{
				rect.Offset(0, dy);
				rect.Height -= dy;
			}
			if (intDragStyle == 2 || intDragStyle == 3 || intDragStyle == 4)
			{
				rect.Width += dx;
			}
			if (intDragStyle == 4 || intDragStyle == 5 || intDragStyle == 6)
			{
				rect.Height += dy;
			}
			return rect;
		}

		protected override void OnDraw()
		{
			base.OnDraw();
			if (!bolCustomAction)
			{
				ReversibleDrawer reversibleDrawer = null;
				reversibleDrawer = ((myBindControl == null) ? ReversibleDrawer.FromScreen() : ReversibleDrawer.FromHwnd(myBindControl.Handle));
				reversibleDrawer.DrawRectangle(myDescRectangle);
				reversibleDrawer.Dispose();
			}
		}

		protected override void OnMouseMove()
		{
			base.OnMouseMove();
			if (!bolCustomAction)
			{
				int dx = base.CurrentPosition.X - base.StartPosition.X;
				int dy = base.CurrentPosition.Y - base.StartPosition.Y;
				myDescRectangle = UpdateRectangle(mySourceRectangle, dx, dy);
			}
		}
	}
}
