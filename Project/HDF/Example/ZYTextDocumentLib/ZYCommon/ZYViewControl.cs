using System;
using System.Drawing;
using System.Windows.Forms;
using Windows32;
using XDesignerGUI;
using XDesignerPrinting;
using ZYTextDocumentLib;

namespace ZYCommon
{
	public class ZYViewControl : TextPageViewControl
	{
		protected ZYTextDocument myDocument = null;

		protected bool bolWordWrap = false;

		protected bool bolEnableInsertMode = true;

		protected bool bolCaptureMouse = false;

		protected int intStartCaptureX = 0;

		protected int intStartCaptureY = 0;

		protected int intLastMouseX = 0;

		protected int intLastMouseY = 0;

		protected int intLastMouseDX = 0;

		protected int intLastMouseDY = 0;

		protected bool bolRunInIE = false;

		protected ToolTip myToolTipCtl = new ToolTip();

		protected Label lblInfo = null;

		protected ZYPopupList myPopupList = null;

		protected Point mySavedScrollPos = Point.Empty;

		public int EditorFlag = 0;

		protected int LastMessageTick = 0;

		protected Timer myTimer = new Timer();

		public bool StaticToolTip = false;

		protected bool bolLockingUI = false;

		private bool bolShowingToolTip = false;

		public bool RunInIE
		{
			get
			{
				return bolRunInIE;
			}
			set
			{
				bolRunInIE = value;
			}
		}

		public bool PopupingList
		{
			get
			{
				if (myPopupList != null)
				{
					return myPopupList.WaitingForUserSelected;
				}
				return false;
			}
		}

		public ZYPopupList PopupList => myPopupList;

		public bool CaptureMouse
		{
			get
			{
				return bolCaptureMouse;
			}
			set
			{
				bolCaptureMouse = value;
			}
		}

		public int StartCaptureX => intStartCaptureX;

		public int StartCaptureY => intStartCaptureY;

		public int LastMouseDX => intLastMouseDX;

		public int LastMouseDY => intLastMouseDY;

		public int LastMouseX => intLastMouseX;

		public int LastMouseY => intLastMouseY;

		public bool EnableInsertMode
		{
			get
			{
				return bolEnableInsertMode;
			}
			set
			{
				bolEnableInsertMode = value;
			}
		}

		public override bool InsertMode
		{
			get
			{
				return bolInsertMode;
			}
			set
			{
				bolInsertMode = value;
				if (myDocument != null)
				{
					myDocument.ViewInsertModeChange();
				}
			}
		}

		public bool WordWrap
		{
			get
			{
				return bolWordWrap;
			}
			set
			{
				bolWordWrap = value;
				base.HScroll = !value;
			}
		}

		public ZYTextDocument Document
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

		public bool ShowingPopupList => myPopupList != null && myPopupList.Visible;

		public bool InnerToolTipVisible
		{
			get
			{
				return lblInfo.Visible;
			}
			set
			{
				if (lblInfo.Visible != value)
				{
					if (value)
					{
						lblInfo.Visible = value;
					}
					else
					{
						HideInnerToolTip();
					}
				}
			}
		}

		public event StatusTextChangeHandler StatusTextChange;

		public ZYViewControl()
		{
			SetStyle(ControlStyles.Selectable, value: true);
			SetStyle(ControlStyles.UserPaint, value: true);
			BackColor = SystemColors.Window;
			AutoScroll = true;
			lblInfo = new Label();
			lblInfo.Visible = false;
			lblInfo.BackColor = SystemColors.Info;
			lblInfo.BorderStyle = BorderStyle.FixedSingle;
			lblInfo.Location = new Point(72, 176);
			lblInfo.Font = new Font("宋体", 10f);
			lblInfo.Click += lblInfo_Click;
			lblInfo.MouseMove += lblInfo_MouseMove;
			lblInfo.MouseDown += lblInfo_MouseDown;
			lblInfo.TextAlign = ContentAlignment.MiddleLeft;
			lblInfo.ImageAlign = ContentAlignment.TopLeft;
			base.Controls.Add(lblInfo);
			myTimer.Interval = 100;
			myTimer.Tick += myTimer_Tick;
			myTimer.Start();
			AllowDrop = true;
		}

		public void SaveScrollPos()
		{
			mySavedScrollPos = base.AutoScrollPosition;
		}

		protected override void Dispose(bool disposing)
		{
			if (myPopupList != null)
			{
				myPopupList.Dispose();
				myPopupList = null;
			}
			if (myToolTipCtl != null)
			{
				myToolTipCtl.Dispose();
				myToolTipCtl = null;
			}
			if (myTimer != null)
			{
				myTimer.Dispose();
				myTimer = null;
			}
			base.Dispose(disposing);
		}

		public void SetToolTip(string strTip)
		{
			if (myToolTipCtl.GetToolTip(this) != strTip)
			{
				myToolTipCtl.RemoveAll();
				myToolTipCtl.SetToolTip(this, strTip);
			}
		}

		public void SetCursor(Cursor vCursor)
		{
			if (!Cursor.Equals(vCursor))
			{
				Cursor = vCursor;
			}
		}

		public Size GetViewSize()
		{
			return base.AutoScrollMinSize;
		}

		public void UpdateView(Rectangle vRect)
		{
			Point point = ViewPointToClient(0, 0);
			vRect.Offset(point.X, point.Y);
			Invalidate(vRect);
		}

		protected virtual bool InitPopupList()
		{
			if (myPopupList == null)
			{
				myPopupList = new ZYPopupList();
			}
			myPopupList.Clear();
			myPopupList.AutoClose = true;
			return true;
		}

		public int ShowPopupList(int x, int y, int height, object[] items, string strDefaultText)
		{
			if (InitPopupList())
			{
				myPopupList.AddObjects(items);
				Point p = ViewPointToClient(x, y);
				p = PointToScreen(p);
				myPopupList.SetDefaultSize();
				p = myPopupList.GetPopupPos(p.X, p.Y, height);
				myPopupList.ShowPopupList(p.X, p.Y, FindForm());
				myPopupList.RefreshChineseSpell(ResetAll: false);
				myPopupList.SelectedText = strDefaultText;
				bolCaptureMouse = false;
				if (myPopupList.WaitUserSelected())
				{
					bolCaptureMouse = false;
					return myPopupList.SelectedIndex;
				}
				bolCaptureMouse = false;
			}
			return -1;
		}

		public ZYPopupList ShowPopupList(int x, int y, int height)
		{
			if (InitPopupList())
			{
				Point p = ViewPointToClient(x, y);
				p = PointToScreen(p);
				p = myPopupList.GetPopupPos(p.X, p.Y, height);
				myPopupList.ShowPopupList(p.X, p.Y, FindForm());
				bolCaptureMouse = false;
			}
			return myPopupList;
		}

		public void SetPopupPos(int x, int y, int height)
		{
			if (myPopupList != null)
			{
				height = GraphicsUnitConvert.Convert(height, base.GraphicsUnit, GraphicsUnit.Pixel);
				Point p = ViewPointToClient(x, y);
				p = PointToScreen(p);
				myPopupList.CompositionRect = new Rectangle(p.X, p.Y, 10, height);
				myPopupList.UpdateComposition();
			}
		}

		public void HidePopupList()
		{
			if (myPopupList != null)
			{
				myPopupList.CloseList();
			}
		}

		protected virtual void OnStatusTextChange(string strText)
		{
			if (this.StatusTextChange != null)
			{
				this.StatusTextChange(this, strText);
			}
		}

		public override void Refresh()
		{
			if (!base.Updating)
			{
				myInvalidateRect.Clear();
				base.Refresh();
			}
		}

		public PrintPage HitTestPage(int x, int y)
		{
			x -= base.AutoScrollPosition.X;
			y -= base.AutoScrollPosition.Y;
			foreach (PrintPage myPage in myPages)
			{
				if (myPage.ClientBounds.Contains(x, y))
				{
					return myPage;
				}
			}
			return null;
		}

		protected virtual void BeforeUserMessage()
		{
			if (lblInfo.Visible)
			{
				lblInfo.Visible = false;
			}
		}

		protected virtual void AfterUserMessage()
		{
		}

		public bool HasShiftPressing()
		{
			return (Control.ModifierKeys & Keys.Shift) != 0;
		}

		public bool HasControlPressing()
		{
			return (Control.ModifierKeys & Keys.Control) != 0;
		}

		public bool HasAltPressing()
		{
			return (Control.ModifierKeys & Keys.Alt) != 0;
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (!bolLockingUI)
			{
				LastMessageTick = Environment.TickCount;
				BeforeUserMessage();
				base.OnKeyPress(e);
				if (myDocument != null)
				{
					myDocument.ViewNewChar(e.KeyChar);
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (bolLockingUI)
			{
				return;
			}
			LastMessageTick = Environment.TickCount;
			BeforeUserMessage();
			if (myDocument != null)
			{
				if (bolEnableInsertMode && e.KeyCode == Keys.Insert)
				{
					InsertMode = !InsertMode;
				}
				else
				{
					Keys keys = e.KeyCode;
					if (keys == Keys.ShiftKey || keys == Keys.ControlKey || keys == Keys.Menu)
					{
						keys = Keys.None;
					}
					if (myDocument.ViewKeyDown(keys, e.Alt, e.Control, e.Shift))
					{
						return;
					}
				}
			}
			base.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (!bolLockingUI)
			{
				LastMessageTick = Environment.TickCount;
				if (myDocument == null || !myDocument.ViewKeyUp(e.KeyCode, e.Alt, e.Control, e.Shift))
				{
					base.OnKeyUp(e);
				}
			}
		}

		public bool WaitForKeyDown(int intKeyCode, bool EatMessage)
		{
			MSG msg = default(MSG);
			int num = 0;
			while (User32.WaitMessage())
			{
				num++;
				if (!User32.PeekMessage(ref msg, 0, 0u, 0u, 0u) || User32.isMouseDownMessage(msg.message) || User32.isMouseUpMessage(msg.message))
				{
					break;
				}
				if (msg.message == 256)
				{
					if (msg.wParam == intKeyCode)
					{
						if (EatMessage)
						{
							User32.GetMessage(ref msg, 0, 0u, 0u);
						}
						return true;
					}
					break;
				}
				Application.DoEvents();
			}
			return false;
		}

		private void mcp_Draw(object sender, CaptureMouseMoveEventArgs e)
		{
			RectangleMouseCapturer rectangleMouseCapturer = (RectangleMouseCapturer)sender;
			int w = rectangleMouseCapturer.CurrentPosition.X - rectangleMouseCapturer.StartPosition.X;
			int h = rectangleMouseCapturer.CurrentPosition.Y - rectangleMouseCapturer.StartPosition.Y;
			Size size = base.Transform.TransformSize(w, h);
			Rectangle rect = rectangleMouseCapturer.UpdateRectangle(rectangleMouseCapturer.SourceRectangle, size.Width, size.Height);
			ReversibleViewDrawRect(rect);
		}

		private void mcp_MouseMove(object sender, CaptureMouseMoveEventArgs e)
		{
			RectangleMouseCapturer rectangleMouseCapturer = (RectangleMouseCapturer)sender;
			int w = rectangleMouseCapturer.CurrentPosition.X - rectangleMouseCapturer.StartPosition.X;
			int h = rectangleMouseCapturer.CurrentPosition.Y - rectangleMouseCapturer.StartPosition.Y;
			Size size = base.Transform.TransformSize(w, h);
			rectangleMouseCapturer.DescRectangle = rectangleMouseCapturer.UpdateRectangle(rectangleMouseCapturer.SourceRectangle, size.Width, size.Height);
		}

		public Rectangle CaptureDragRect(Rectangle SourceRect, int DragStyle, bool DrawFocusRect, double WidthHeightRate, bool ShowSizeInfo, CaptureDragRectangleHandler CallBack)
		{
			RectangleMouseCapturer rectangleMouseCapturer = new RectangleMouseCapturer(this);
			rectangleMouseCapturer.SourceRectangle = SourceRect;
			rectangleMouseCapturer.CustomAction = true;
			rectangleMouseCapturer.DragStyle = DragStyle;
			rectangleMouseCapturer.Draw += mcp_Draw;
			rectangleMouseCapturer.MouseMove += mcp_MouseMove;
			if (rectangleMouseCapturer.CaptureMouseMove())
			{
				bolCaptureMouse = false;
				return rectangleMouseCapturer.DescRectangle;
			}
			bolCaptureMouse = false;
			return Rectangle.Empty;
		}

		protected override void OnViewMouseDown(MouseEventArgs e)
		{
			base.OnViewMouseDown(e);
			if (bolLockingUI)
			{
				return;
			}
			LastMessageTick = Environment.TickCount;
			HideInnerToolTip();
			BeforeUserMessage();
			Point point = new Point(e.X, e.Y);
			if (ContextMenu != null && e.Button == MouseButtons.Right)
			{
				if (myDocument != null)
				{
					myDocument.ViewMouseDown(point.X, point.Y, e.Button);
				}
				base.OnViewMouseDown(e);
				return;
			}
			bolCaptureMouse = true;
			intStartCaptureX = point.X;
			intStartCaptureY = point.Y;
			intLastMouseX = intStartCaptureX;
			intLastMouseY = intStartCaptureY;
			if (myDocument == null || (point.X == -1 && point.Y == -1) || !myDocument.ViewMouseDown(intStartCaptureX, intStartCaptureY, e.Button))
			{
				base.OnViewMouseDown(e);
			}
		}

		protected virtual bool OnStartDrag(int x, int y)
		{
			return false;
		}

		protected override void OnViewMouseMove(MouseEventArgs e)
		{
			if (bolLockingUI)
			{
				return;
			}
			LastMessageTick = Environment.TickCount;
			if (!bolCaptureMouse)
			{
				SetCursor(System.Windows.Forms.Cursors.IBeam);
			}
			Point point = new Point(e.X, e.Y);
			if (e.Button == MouseButtons.Left && AllowDrop)
			{
				RectangleObject rectangleObject = new RectangleObject();
				rectangleObject.SetRect(intStartCaptureX, intStartCaptureY, point.X, point.Y);
				if ((rectangleObject.Width > SystemInformation.DragSize.Width || rectangleObject.Height > SystemInformation.DragSize.Height) && OnStartDrag(point.X, point.Y))
				{
					return;
				}
			}
			intLastMouseDX = point.X - intLastMouseX;
			intLastMouseDY = point.Y - intLastMouseY;
			if (myDocument != null && myDocument.ViewMouseMove(point.X, point.Y, e.Button))
			{
				intLastMouseX = point.X;
				intLastMouseY = point.Y;
			}
			else
			{
				intLastMouseX = point.X;
				intLastMouseY = point.Y;
				base.OnViewMouseMove(e);
			}
		}

		protected override void OnViewMouseUp(MouseEventArgs e)
		{
			if (!bolLockingUI)
			{
				LastMessageTick = Environment.TickCount;
				HideInnerToolTip();
				BeforeUserMessage();
				bolCaptureMouse = false;
				Point point = new Point(e.X, e.Y);
				intLastMouseDX = point.X - intLastMouseX;
				intLastMouseDY = point.Y - intLastMouseY;
				if (myDocument != null && (point.X != -1 || point.Y != -1) && myDocument.ViewMouseUp(point.X, point.Y, e.Button))
				{
					intLastMouseX = point.X;
					intLastMouseY = point.Y;
				}
				else
				{
					intLastMouseX = point.X;
					intLastMouseY = point.Y;
					base.OnViewMouseUp(e);
				}
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (!bolLockingUI)
			{
				if (!StaticToolTip)
				{
					HideInnerToolTip();
				}
				if (myDocument == null || !myDocument.ViewMouseLeave())
				{
					base.OnMouseLeave(e);
				}
			}
		}

		protected override void OnViewClick(MouseEventArgs e)
		{
			if (bolLockingUI)
			{
				return;
			}
			if (myDocument != null)
			{
				Point point = new Point(e.X, e.Y);
				if ((point.X != -1 || point.Y != -1) && myDocument.ViewMouseClick(point.X, point.Y, Control.MouseButtons))
				{
					return;
				}
			}
			OnClick(e);
		}

		protected override void OnViewDoubleClick(MouseEventArgs e)
		{
			if (bolLockingUI)
			{
				return;
			}
			if (myDocument != null)
			{
				Point point = new Point(e.X, e.Y);
				if ((point.X != -1 || point.Y != -1) && myDocument.ViewMouseDoubleClick(point.X, point.Y, Control.MouseButtons))
				{
					return;
				}
			}
			OnDoubleClick(e);
		}

		public void ShowInnerToolTip(string strText, int x, int y, int height)
		{
			ShowInnerToolTip(null, strText, x, y, height);
		}

		public void ShowInnerToolTip(Image img, string strText, int x, int y, int height)
		{
			Rectangle rectangle = new Rectangle(0, 0, 1, 1);
			lblInfo.Image = img;
			if (img != null)
			{
				strText = new string(' ', img.Size.Width / 5) + strText;
			}
			lblInfo.Text = strText;
			Point point = ViewPointToClient(x, y);
			rectangle.X = point.X;
			rectangle.Y = point.Y + height + 1;
			using (Graphics graphics = lblInfo.CreateGraphics())
			{
				SizeF sizeF = graphics.MeasureString(strText, lblInfo.Font);
				rectangle.Width = (img?.Size.Width ?? 0) + (int)sizeF.Width + 4;
				if (rectangle.Width > base.ClientSize.Width)
				{
					rectangle.Width = base.ClientSize.Width;
					sizeF = graphics.MeasureString(strText, lblInfo.Font, rectangle.Width);
				}
				rectangle.Height = (int)sizeF.Height + 4;
				if (img != null && rectangle.Height < img.Size.Height + 4)
				{
					rectangle.Height = img.Size.Height + 4;
				}
			}
			if (rectangle.Right > base.ClientSize.Width)
			{
				rectangle.X = base.ClientSize.Width - rectangle.Width;
			}
			if (rectangle.Bottom > base.ClientSize.Height)
			{
				rectangle.Y = point.Y - rectangle.Height;
			}
			if (rectangle.X < 0)
			{
				rectangle.X = 0;
			}
			if (rectangle.Y < 0)
			{
				rectangle.Y = 0;
			}
			if (!lblInfo.Bounds.Equals(rectangle))
			{
				lblInfo.Bounds = rectangle;
			}
			lblInfo.Tag = "show";
		}

		public void HideInnerToolTip()
		{
			if (!bolShowingToolTip)
			{
				if (lblInfo.Visible)
				{
					lblInfo.Visible = false;
				}
				lblInfo.Text = "";
				lblInfo.Tag = null;
			}
			bolShowingToolTip = false;
		}

		private void lblInfo_Click(object sender, EventArgs e)
		{
			HideInnerToolTip();
		}

		private void lblInfo_MouseMove(object sender, MouseEventArgs e)
		{
			MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, e.X + lblInfo.Left, e.Y + lblInfo.Top, e.Delta);
			OnMouseMove(e2);
		}

		private void lblInfo_MouseDown(object sender, MouseEventArgs e)
		{
			HideInnerToolTip();
		}

		public void UpdateInnerToolTip()
		{
			bolShowingToolTip = true;
			if (!ShowingPopupList)
			{
				if (!lblInfo.Visible && "show".Equals(lblInfo.Tag))
				{
					lblInfo.Visible = true;
				}
				else if (lblInfo.Visible && lblInfo.Tag == null)
				{
					HideInnerToolTip();
				}
			}
		}

		private void myTimer_Tick(object sender, EventArgs e)
		{
			if (myDocument != null)
			{
				myDocument.ViewTimer();
			}
			if (Environment.TickCount - LastMessageTick > 1000)
			{
				UpdateInnerToolTip();
			}
		}
	}
}
