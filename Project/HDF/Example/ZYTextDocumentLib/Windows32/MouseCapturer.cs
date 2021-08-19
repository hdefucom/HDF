using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XDesignerCommon;

namespace Windows32
{
	public class MouseCapturer
	{
		private struct MSG
		{
			public int hwnd;

			public int message;

			public int wParam;

			public int lParam;

			public int time;

			public int pt_x;

			public int pt_y;
		}

		protected Control myBindControl = null;

		private Point myInitStartPosition = Point.Empty;

		private Point myStartPosition = Point.Empty;

		private Point myEndPosition = Point.Empty;

		private Point myLastPosition = Point.Empty;

		private Point myCurrentPosition = Point.Empty;

		private Size myMoveSize = Size.Empty;

		private Rectangle myClipRectangle = Rectangle.Empty;

		private ReversibleShapeStyle intReversibleShape = ReversibleShapeStyle.Custom;

		private object objTag = null;

		public Control BindControl
		{
			get
			{
				return myBindControl;
			}
			set
			{
				myBindControl = value;
			}
		}

		public Point InitStartPosition
		{
			get
			{
				return myInitStartPosition;
			}
			set
			{
				myInitStartPosition = value;
			}
		}

		public Point StartPosition => myStartPosition;

		public Point EndPosition => myEndPosition;

		public Point LastPosition => myLastPosition;

		public Point CurrentPosition => myCurrentPosition;

		public Size MoveSize
		{
			get
			{
				return myMoveSize;
			}
			set
			{
				myMoveSize = value;
			}
		}

		public int DX => myEndPosition.X - myStartPosition.X;

		public int DY => myEndPosition.Y - myStartPosition.Y;

		public Rectangle CaptureRectagle
		{
			get
			{
				Rectangle rectangle = RectangleCommon.GetRectangle(myStartPosition, myEndPosition);
				rectangle.Location = FixPointForControl(rectangle.Location);
				return rectangle;
			}
		}

		public Rectangle ClipRectangle
		{
			get
			{
				return myClipRectangle;
			}
			set
			{
				myClipRectangle = value;
			}
		}

		public ReversibleShapeStyle ReversibleShape
		{
			get
			{
				return intReversibleShape;
			}
			set
			{
				intReversibleShape = value;
			}
		}

		public object Tag
		{
			get
			{
				return objTag;
			}
			set
			{
				objTag = value;
			}
		}

		public Size CurrentMoveSize => new Size(myCurrentPosition.X - myStartPosition.X, myCurrentPosition.Y - myStartPosition.Y);

		private Point CurMousePosition => GetMousePosition(Control.MousePosition);

		public event CaptureMouseMoveEventHandler MouseMove = null;

		public event CaptureMouseMoveEventHandler Draw = null;

		public MouseCapturer()
		{
		}

		public MouseCapturer(Control ctl)
		{
			myBindControl = ctl;
		}

		protected virtual CaptureMouseMoveEventArgs CreateArgs()
		{
			return new CaptureMouseMoveEventArgs(this, myStartPosition, myCurrentPosition);
		}

		protected virtual void OnMouseMove()
		{
			if (this.MouseMove != null)
			{
				this.MouseMove(this, CreateArgs());
			}
		}

		protected virtual void OnDraw()
		{
			if (this.Draw != null)
			{
				this.Draw(this, CreateArgs());
			}
		}

		protected virtual void OnReversibleDrawCallback()
		{
			Rectangle rectangle = RectangleCommon.GetRectangle(myStartPosition, myCurrentPosition);
			switch (intReversibleShape)
			{
			case ReversibleShapeStyle.Line:
				ControlPaint.DrawReversibleLine(myStartPosition, myCurrentPosition, Color.Black);
				break;
			case ReversibleShapeStyle.Rectangle:
				ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Dashed);
				break;
			case ReversibleShapeStyle.FillRectangle:
				ControlPaint.FillReversibleRectangle(rectangle, Color.Black);
				break;
			case ReversibleShapeStyle.Custom:
				if (this.Draw != null)
				{
					this.Draw(this, null);
				}
				break;
			}
		}

		public void Reset()
		{
			if (myInitStartPosition.IsEmpty)
			{
				myStartPosition = CurMousePosition;
			}
			else
			{
				myStartPosition = myInitStartPosition;
			}
			myLastPosition = myStartPosition;
			myCurrentPosition = myStartPosition;
			myEndPosition = myStartPosition;
			myMoveSize = Size.Empty;
		}

		public bool CaptureMouseMove()
		{
			Reset();
			MSG msg = default(MSG);
			int width = SystemInformation.DragSize.Width;
			bool flag = false;
			if (Control.MouseButtons == MouseButtons.None)
			{
				return false;
			}
			Point curMousePosition = CurMousePosition;
			while (WaitMessage())
			{
				curMousePosition = CurMousePosition;
				if (Control.MouseButtons == MouseButtons.None)
				{
					break;
				}
				if (!PeekMessage(ref msg, 0, 0u, 0u, 0u))
				{
					continue;
				}
				if (isMouseUpMessage(msg.message))
				{
					curMousePosition.X = (short)msg.lParam;
					curMousePosition.Y = msg.lParam >> 16;
					break;
				}
				if (isMouseMoveMessage(msg.message))
				{
					Point point = new Point((short)msg.lParam, msg.lParam >> 16);
					if (point.X != myCurrentPosition.X || point.Y != myCurrentPosition.Y)
					{
						if (flag)
						{
							OnDraw();
						}
						myCurrentPosition = point;
						if (!flag && (Math.Abs(myCurrentPosition.X - myStartPosition.X) >= width || Math.Abs(myCurrentPosition.Y - myStartPosition.Y) >= width))
						{
							flag = true;
						}
						if (flag)
						{
							myCurrentPosition = point;
							OnDraw();
							OnMouseMove();
							myLastPosition = myCurrentPosition;
						}
					}
				}
				GetMessage(ref msg, 0, 0u, 0u);
			}
			myCurrentPosition = curMousePosition;
			if (flag)
			{
				OnDraw();
			}
			myEndPosition = myCurrentPosition;
			myMoveSize = new Size(myEndPosition.X - myStartPosition.X, myEndPosition.Y - myStartPosition.Y);
			if (myMoveSize.Width == 0 && myMoveSize.Height == 0)
			{
				return false;
			}
			return flag;
		}

		private Point GetMousePosition(Point p)
		{
			if (myBindControl != null)
			{
				p = myBindControl.PointToClient(p);
			}
			return RectangleCommon.MoveInto(p, myClipRectangle);
		}

		private Point FixPointForControl(Point p)
		{
			if (myBindControl != null)
			{
				p = myBindControl.PointToClient(p);
			}
			return p;
		}

		private static bool isMouseMoveMessage(int intMessage)
		{
			if (intMessage == 512 || intMessage == 160)
			{
				return true;
			}
			return false;
		}

		private static bool isMouseUpMessage(int intMessage)
		{
			if (intMessage == 514 || intMessage == 520 || intMessage == 517 || intMessage == 524)
			{
				return true;
			}
			if (intMessage == 162 || intMessage == 168 || intMessage == 165 || intMessage == 172)
			{
				return true;
			}
			return false;
		}

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern bool WaitMessage();
	}
}
