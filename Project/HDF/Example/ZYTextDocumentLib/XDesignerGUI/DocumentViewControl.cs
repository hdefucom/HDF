using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Windows32;
using XDesignerCommon;

namespace XDesignerGUI
{
	[Browsable(false)]
	public class DocumentViewControl : BorderUserControl
	{
		protected class MyCapturer : MouseCapturer
		{
			public BorderUserControl Control = null;

			public int DragStyle = 0;

			public Rectangle[] Rects = null;

			public Rectangle ViewClipRectangle = Rectangle.Empty;

			protected override CaptureMouseMoveEventArgs CreateArgs()
			{
				DocumentViewControl documentViewControl = (DocumentViewControl)base.BindControl;
				CaptureMouseMoveEventArgs captureMouseMoveEventArgs = base.CreateArgs();
				captureMouseMoveEventArgs.StartPosition = documentViewControl.myTransform.TransformPoint(captureMouseMoveEventArgs.StartPosition);
				captureMouseMoveEventArgs.CurrentPosition = documentViewControl.myTransform.TransformPoint(captureMouseMoveEventArgs.CurrentPosition);
				return captureMouseMoveEventArgs;
			}
		}

		protected Cursor myDefaultCursor = System.Windows.Forms.Cursors.Default;

		protected float fXZoomRate = 1f;

		protected float fYZoomRate = 1f;

		protected GraphicsUnit intGraphicsUnit = GraphicsUnit.Pixel;

		protected TransformBase myTransform = new SimpleRectangleTransform();

		protected Rectangle myViewBounds = Rectangle.Empty;

		protected bool bolMouseDragScroll = false;

		protected Point myMouseDragPoint = Point.Empty;

		private bool bolScrollFlag = false;

		protected bool bolScrolling = false;

		public new Cursor DefaultCursor
		{
			get
			{
				return myDefaultCursor;
			}
			set
			{
				myDefaultCursor = value;
			}
		}

		[Browsable(false)]
		public float XZoomRate
		{
			get
			{
				return fXZoomRate;
			}
			set
			{
				if (fXZoomRate != value)
				{
					fXZoomRate = value;
					UpdateViewBounds();
					Invalidate();
				}
			}
		}

		[Browsable(false)]
		public float YZoomRate
		{
			get
			{
				return fYZoomRate;
			}
			set
			{
				if (fYZoomRate != value)
				{
					fYZoomRate = value;
					UpdateViewBounds();
					Invalidate();
				}
			}
		}

		[Browsable(false)]
		public GraphicsUnit GraphicsUnit
		{
			get
			{
				return intGraphicsUnit;
			}
			set
			{
				intGraphicsUnit = value;
				UpdateViewBounds();
				Invalidate();
			}
		}

		[Browsable(false)]
		public virtual Size ViewAutoScrollMinSize
		{
			get
			{
				Size autoScrollMinSize = base.AutoScrollMinSize;
				autoScrollMinSize = GraphicsUnitConvert.Convert(autoScrollMinSize, GraphicsUnit.Pixel, intGraphicsUnit);
				autoScrollMinSize.Width = (int)((float)autoScrollMinSize.Width * fXZoomRate);
				autoScrollMinSize.Height = (int)((float)autoScrollMinSize.Height * fYZoomRate);
				return autoScrollMinSize;
			}
			set
			{
				Size autoScrollMinSize = GraphicsUnitConvert.Convert(value, intGraphicsUnit, GraphicsUnit.Pixel);
				autoScrollMinSize.Width = (int)((float)autoScrollMinSize.Width / fXZoomRate);
				autoScrollMinSize.Height = (int)((float)autoScrollMinSize.Height / fYZoomRate);
				base.AutoScrollMinSize = autoScrollMinSize;
			}
		}

		[Browsable(false)]
		public double ClientToViewXRate
		{
			get
			{
				double rate = GraphicsUnitConvert.GetRate(intGraphicsUnit, GraphicsUnit.Pixel);
				return rate / (double)fXZoomRate;
			}
		}

		[Browsable(false)]
		public double ClientToViewYRate
		{
			get
			{
				double rate = GraphicsUnitConvert.GetRate(intGraphicsUnit, GraphicsUnit.Pixel);
				return rate / (double)fYZoomRate;
			}
		}

		[Browsable(false)]
		public virtual Point ViewAutoScrollPosition
		{
			get
			{
				Point autoScrollPosition = base.AutoScrollPosition;
				autoScrollPosition = GraphicsUnitConvert.Convert(autoScrollPosition, GraphicsUnit.Pixel, intGraphicsUnit);
				autoScrollPosition.X = (int)((float)autoScrollPosition.X * fXZoomRate);
				autoScrollPosition.Y = (int)((float)autoScrollPosition.Y * fYZoomRate);
				return autoScrollPosition;
			}
			set
			{
				Point autoScrollPosition = GraphicsUnitConvert.Convert(value, intGraphicsUnit, GraphicsUnit.Pixel);
				autoScrollPosition.X = (int)((float)autoScrollPosition.X / fXZoomRate);
				autoScrollPosition.Y = (int)((float)autoScrollPosition.Y / fYZoomRate);
				SetAutoScrollPosition(autoScrollPosition);
			}
		}

		[Browsable(false)]
		public virtual Size ViewClientSize
		{
			get
			{
				Size result = GraphicsUnitConvert.Convert(base.ClientSize, GraphicsUnit.Pixel, intGraphicsUnit);
				result.Width = (int)((float)result.Width * fXZoomRate);
				result.Height = (int)((float)result.Height * fYZoomRate);
				return result;
			}
		}

		[Browsable(false)]
		public virtual Rectangle ViewClientRectangle
		{
			get
			{
				Rectangle result = GraphicsUnitConvert.Convert(base.ClientRectangle, GraphicsUnit.Pixel, intGraphicsUnit);
				result.X = (int)((float)result.X * fXZoomRate);
				result.Y = (int)((float)result.Y * fYZoomRate);
				result.Width = (int)((float)result.Width * fXZoomRate);
				result.Height = (int)((float)result.Height * fYZoomRate);
				return result;
			}
		}

		[Browsable(false)]
		public TransformBase Transform => myTransform;

		[Browsable(false)]
		public virtual Point ClientMousePosition
		{
			get
			{
				Point mousePosition = Control.MousePosition;
				mousePosition = PointToClient(mousePosition);
				if (base.ClientRectangle.Contains(mousePosition))
				{
					return mousePosition;
				}
				return Point.Empty;
			}
		}

		[Browsable(false)]
		public virtual Point ViewMousePosition
		{
			get
			{
				Point clientMousePosition = ClientMousePosition;
				if (!clientMousePosition.IsEmpty)
				{
					return ClientPointToView(clientMousePosition);
				}
				return Point.Empty;
			}
		}

		[Browsable(false)]
		public Rectangle ViewBounds
		{
			get
			{
				return myViewBounds;
			}
			set
			{
				if (!myViewBounds.Equals(value))
				{
					myViewBounds = value;
					UpdateViewBounds();
				}
			}
		}

		public bool MouseDragScroll
		{
			get
			{
				return bolMouseDragScroll;
			}
			set
			{
				bolMouseDragScroll = value;
			}
		}

		[Browsable(false)]
		public bool ScrollFlag
		{
			get
			{
				return bolScrollFlag;
			}
			set
			{
				bolScrollFlag = value;
			}
		}

		public event MouseEventHandler ViewMouseDown = null;

		public event MouseEventHandler ViewMouseMove = null;

		public event MouseEventHandler ViewMouseUp = null;

		public event MouseEventHandler ViewClick = null;

		public event MouseEventHandler ViewDoubleClick = null;

		public event PaintEventHandler ViewPaint = null;

		public void Zoom(float rate)
		{
			fXZoomRate *= rate;
			fYZoomRate *= rate;
			if (fXZoomRate <= 0f)
			{
				fXZoomRate = 1f;
			}
			if (fYZoomRate <= 0f)
			{
				fYZoomRate = 1f;
			}
			UpdateViewBounds();
			Invalidate();
		}

		protected void CheckZoomRate()
		{
			if (fXZoomRate <= 0f || fYZoomRate <= 0f)
			{
				throw new InvalidOperationException("Bad zoom rate value");
			}
		}

		protected virtual void RefreshScaleTransform()
		{
			SimpleRectangleTransform simpleRectangleTransform = myTransform as SimpleRectangleTransform;
			if (simpleRectangleTransform != null)
			{
				Rectangle rectangle = simpleRectangleTransform.SourceRect = base.ClientRectangle;
				Point autoScrollPosition = base.AutoScrollPosition;
				float num = (float)ClientToViewXRate;
				float num2 = (float)ClientToViewYRate;
				simpleRectangleTransform.DescRectF = new RectangleF((float)(-autoScrollPosition.X) * num, (float)(-autoScrollPosition.Y) * num2, (float)rectangle.Width * num, (float)rectangle.Height * num2);
			}
		}

		public virtual Point ClientPointToView(int x, int y)
		{
			RefreshScaleTransform();
			return myTransform.TransformPoint(x, y);
		}

		public virtual Point ClientPointToView(Point p)
		{
			RefreshScaleTransform();
			return myTransform.TransformPoint(p);
		}

		public virtual Point ViewPointToClient(int x, int y)
		{
			RefreshScaleTransform();
			return myTransform.UnTransformPoint(x, y);
		}

		public virtual Point ViewPointToClient(Point p)
		{
			RefreshScaleTransform();
			return myTransform.UnTransformPoint(p);
		}

		public virtual void UpdateViewBounds()
		{
			Size vSize = new Size(myViewBounds.Right, myViewBounds.Bottom);
			RefreshScaleTransform();
			vSize = (base.AutoScrollMinSize = myTransform.UnTransformSize(vSize));
		}

		public virtual MouseEventArgs CreateViewMouseEventArgs()
		{
			Point viewMousePosition = ViewMousePosition;
			return new MouseEventArgs(Control.MouseButtons, 0, viewMousePosition.X, viewMousePosition.Y, 0);
		}

		protected override void OnScroll()
		{
			base.OnScroll();
			RefreshScaleTransform();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (bolMouseDragScroll)
			{
				myMouseDragPoint = new Point(e.X, e.Y);
			}
			if (myTransform.ContainsSourcePoint(e.X, e.Y))
			{
				Point point = ClientPointToView(e.X, e.Y);
				OnViewMouseDown(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
			}
		}

		protected void Control_OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		protected virtual void OnViewMouseDown(MouseEventArgs e)
		{
			if (this.ViewMouseDown != null)
			{
				this.ViewMouseDown(this, e);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (bolScrolling)
			{
				Console.WriteLine(bolScrolling);
				return;
			}
			if (bolMouseDragScroll)
			{
				if (Control.MouseButtons == MouseButtons.Left)
				{
					if (!myMouseDragPoint.IsEmpty)
					{
						int num = e.X - myMouseDragPoint.X;
						int num2 = e.Y - myMouseDragPoint.Y;
						myMouseDragPoint = new Point(e.X, e.Y);
						SetAutoScrollPosition(new Point(-num - base.AutoScrollPosition.X, -num2 - base.AutoScrollPosition.Y));
						OnScroll();
						return;
					}
				}
				else
				{
					myMouseDragPoint = Point.Empty;
				}
			}
			if (myTransform.ContainsSourcePoint(e.X, e.Y))
			{
				Point point = ClientPointToView(e.X, e.Y);
				OnViewMouseMove(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
			}
			else
			{
				Cursor = myDefaultCursor;
			}
		}

		protected virtual void OnViewMouseMove(MouseEventArgs e)
		{
			if (this.ViewMouseMove != null)
			{
				this.ViewMouseMove(this, e);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			myMouseDragPoint = Point.Empty;
			if (myTransform.ContainsSourcePoint(e.X, e.Y))
			{
				Point point = ClientPointToView(e.X, e.Y);
				OnViewMouseUp(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
			}
		}

		protected virtual void OnViewMouseUp(MouseEventArgs e)
		{
			if (this.ViewMouseUp != null)
			{
				this.ViewMouseUp(this, e);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			Point viewMousePosition = ViewMousePosition;
			OnViewClick(new MouseEventArgs(Control.MouseButtons, 1, viewMousePosition.X, viewMousePosition.Y, 0));
		}

		protected virtual void OnViewClick(MouseEventArgs e)
		{
			if (this.ViewClick != null)
			{
				this.ViewClick(this, e);
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			Point viewMousePosition = ViewMousePosition;
			OnViewDoubleClick(new MouseEventArgs(Control.MouseButtons, 1, viewMousePosition.X, viewMousePosition.Y, 0));
		}

		protected virtual void OnViewDoubleClick(MouseEventArgs e)
		{
			if (this.ViewDoubleClick != null)
			{
				this.ViewDoubleClick(this, e);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			CheckZoomRate();
			RefreshScaleTransform();
			TransformPaint(e, myTransform as SimpleRectangleTransform);
		}

		protected virtual void TransformPaint(PaintEventArgs e, SimpleRectangleTransform trans)
		{
			if (trans == null)
			{
				return;
			}
			Rectangle clipRectangle = e.ClipRectangle;
			clipRectangle.Offset(-1, -1);
			clipRectangle.Width += 2;
			clipRectangle.Height += 2;
			clipRectangle = Rectangle.Intersect(trans.SourceRect, clipRectangle);
			if (!clipRectangle.IsEmpty)
			{
				RectangleF rectangleF = trans.TransformRectangleF(clipRectangle.Left, clipRectangle.Top, clipRectangle.Width, clipRectangle.Height);
				clipRectangle.X = (int)Math.Floor(rectangleF.Left);
				clipRectangle.Y = (int)Math.Floor(rectangleF.Top);
				clipRectangle.Width = (int)Math.Ceiling(rectangleF.Width);
				clipRectangle.Height = (int)Math.Ceiling(rectangleF.Height);
				e.Graphics.PageUnit = intGraphicsUnit;
				e.Graphics.ResetTransform();
				e.Graphics.ScaleTransform(fXZoomRate, fYZoomRate);
				double num = ClientToViewXRate * (double)fXZoomRate;
				e.Graphics.TranslateTransform((float)((double)trans.SourceRect.Left * num - (double)trans.DescRectF.X), (float)((double)trans.SourceRect.Top * num - (double)trans.DescRectF.Y));
				if (trans.XZoomRate < 1f)
				{
					clipRectangle.Width += (int)Math.Ceiling(1f / trans.XZoomRate);
				}
				if (trans.YZoomRate < 1f)
				{
					clipRectangle.Height += (int)Math.Ceiling(1f / trans.YZoomRate);
				}
				PaintEventArgs paintEventArgs = new PaintEventArgs(e.Graphics, clipRectangle);
				paintEventArgs.Graphics.ResetClip();
				paintEventArgs.Graphics.SetClip(new Rectangle(clipRectangle.Left, clipRectangle.Top, clipRectangle.Width + 2, clipRectangle.Height + 2));
				OnViewPaint(paintEventArgs, trans);
			}
		}

		protected virtual void OnViewPaint(PaintEventArgs e, SimpleRectangleTransform trans)
		{
			if (this.ViewPaint != null)
			{
				this.ViewPaint(this, e);
			}
		}

		public Graphics CreateViewGraphics()
		{
			Graphics graphics = CreateGraphics();
			graphics.PageUnit = intGraphicsUnit;
			return graphics;
		}

		protected Bitmap CreateContentBitmap(float rate, Color BmpBackColor)
		{
			SimpleRectangleTransform simpleRectangleTransform = myTransform as SimpleRectangleTransform;
			if (simpleRectangleTransform == null)
			{
				return null;
			}
			Size autoScrollMinSize = base.AutoScrollMinSize;
			autoScrollMinSize.Width = (int)((float)autoScrollMinSize.Width * rate);
			autoScrollMinSize.Height = (int)((float)autoScrollMinSize.Height * rate);
			if (autoScrollMinSize.Width <= 0 || autoScrollMinSize.Height <= 0)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(autoScrollMinSize.Width, autoScrollMinSize.Height);
			float num = fXZoomRate;
			try
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.Clear(BmpBackColor);
					graphics.PageUnit = intGraphicsUnit;
					graphics.ScaleTransform(rate, rate);
					graphics.TranslateTransform(0f - simpleRectangleTransform.DescRectF.X, 0f - simpleRectangleTransform.DescRectF.Y);
					PaintEventArgs e = new PaintEventArgs(graphics, simpleRectangleTransform.DescRect);
					fXZoomRate = rate;
					OnViewPaint(e, simpleRectangleTransform);
					fXZoomRate = num;
				}
				return bitmap;
			}
			catch (Exception ex)
			{
				fXZoomRate = num;
				throw ex;
			}
		}

		public virtual void ViewInvalidate(Rectangle ViewBounds)
		{
			RefreshScaleTransform();
			Rectangle rc = myTransform.UnTransformRectangle(ViewBounds);
			Invalidate(rc);
		}

		public virtual Point[] CaptureMouseMove(CaptureMouseMoveEventHandler DrawFunction, Rectangle ClipRectangle, object Tag)
		{
			if (bolMouseDragScroll)
			{
				return null;
			}
			RefreshScaleTransform();
			MyCapturer myCapturer = new MyCapturer();
			myCapturer.Tag = Tag;
			myCapturer.BindControl = this;
			if (!ClipRectangle.IsEmpty)
			{
				ClipRectangle = myTransform.UnTransformRectangle(ClipRectangle);
				myCapturer.ClipRectangle = ClipRectangle;
			}
			myCapturer.ReversibleShape = ReversibleShapeStyle.Custom;
			if (DrawFunction != null)
			{
				myCapturer.Draw += DrawFunction;
			}
			if (myCapturer.CaptureMouseMove())
			{
				Point startPosition = myCapturer.StartPosition;
				startPosition = myTransform.TransformPoint(startPosition);
				Point endPosition = myCapturer.EndPosition;
				endPosition = myTransform.TransformPoint(endPosition);
				return new Point[2]
				{
					startPosition,
					endPosition
				};
			}
			return null;
		}

		public Point[] GetCaptureMouseRectangle(Rectangle ClipRectangle)
		{
			return CaptureMouseMove(myCaptureRectangle, ClipRectangle, null);
		}

		public Point[] GetCaptureMouseLine(Rectangle ClipRectangle)
		{
			return CaptureMouseMove(myCaptureLine, ClipRectangle, null);
		}

		private void myCaptureRectangle(object sender, CaptureMouseMoveEventArgs e)
		{
			Rectangle rectangle = RectangleCommon.GetRectangle(e.StartPosition, e.CurrentPosition);
			if (!rectangle.IsEmpty)
			{
				ReversibleViewDrawRect(rectangle);
			}
		}

		private void myCaptureLine(object sender, CaptureMouseMoveEventArgs e)
		{
			ReversibleViewDrawLine(e.StartPosition, e.CurrentPosition);
		}

		public void ReversibleViewDrawLine(int x1, int y1, int x2, int y2)
		{
			using (ReversibleDrawer reversibleDrawer = ReversibleDrawer.FromHwnd(base.Handle))
			{
				reversibleDrawer.PenStyle = PenStyle.PS_DOT;
				reversibleDrawer.PenColor = Color.Red;
				RefreshScaleTransform();
				Point p = myTransform.UnTransformPoint(x1, y1);
				Point p2 = myTransform.UnTransformPoint(x2, y2);
				reversibleDrawer.DrawLine(p, p2);
			}
		}

		public void ReversibleViewDrawLine(Point p1, Point p2)
		{
			ReversibleViewDrawLine(p1.X, p1.Y, p2.X, p2.Y);
		}

		public void ReversibleViewDrawRect(Rectangle rect)
		{
			ReversibleViewDrawRect(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void ReversibleViewDrawRect(int left, int top, int width, int height)
		{
			using (ReversibleDrawer reversibleDrawer = ReversibleDrawer.FromHwnd(base.Handle))
			{
				reversibleDrawer.PenStyle = PenStyle.PS_DOT;
				reversibleDrawer.PenColor = Color.Red;
				RefreshScaleTransform();
				Rectangle rect = myTransform.UnTransformRectangle(left, top, width, height);
				reversibleDrawer.DrawRectangle(rect);
			}
		}

		public void ReversibleViewFillRect(Rectangle rect)
		{
			ReversibleViewFillRect(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void ReversibleViewFillRect(int left, int top, int width, int height)
		{
			using (ReversibleDrawer reversibleDrawer = ReversibleDrawer.FromHwnd(base.Handle))
			{
				RefreshScaleTransform();
				RectangleF value = myTransform.UnTransformRectangleF(left, top, width, height);
				reversibleDrawer.FillRectangle(Rectangle.Ceiling(value));
			}
		}

		public void ReversibleViewFillRect(Rectangle rect, Graphics g)
		{
			ReversibleViewFillRect(rect.Left, rect.Top, rect.Width, rect.Height, g);
		}

		public void ReversibleViewFillRect(int left, int top, int width, int height, Graphics g)
		{
			IntPtr hdc = g.GetHdc();
			using (ReversibleDrawer reversibleDrawer = ReversibleDrawer.FromHDC(hdc))
			{
				RefreshScaleTransform();
				Rectangle rect = myTransform.UnTransformRectangle(left, top, width, height);
				reversibleDrawer.FillRectangle(rect);
			}
			g.ReleaseHdc(hdc);
		}

		public void MoveScrollPos(Point p)
		{
			MoveScrollPos(p.X, p.Y);
		}

		public virtual void MoveScrollPos(int dx, int dy)
		{
			if (dx != 0 || dy != 0)
			{
				Point autoScrollPosition = base.AutoScrollPosition;
				SetAutoScrollPosition(new Point(dx - autoScrollPosition.X, dy - autoScrollPosition.Y));
			}
		}

		public virtual bool ScrollToView(Rectangle rect)
		{
			return ScrollToView(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public bool ScrollToView(int x, int y, int width, int height)
		{
			Rectangle rectangle = myTransform.UnTransformRectangle(x, y, width, height);
			if (!rectangle.IsEmpty)
			{
				return InnerScrollToView(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
			}
			return false;
		}

		protected bool InnerScrollToView(int x, int y, int width, int height)
		{
			bool result = false;
			if (width >= 0 && height >= 0)
			{
				int num = 0;
				int num2 = 0;
				Point point = new Point(x, y);
				Size clientSize = base.ClientSize;
				Point autoScrollPosition = base.AutoScrollPosition;
				if (point.X > clientSize.Width - width + 3 && clientSize.Width - width + 3 > 0)
				{
					num = point.X - clientSize.Width + width + 3;
				}
				if (width > clientSize.Width)
				{
					if (point.X > 3)
					{
						num = point.X - 3;
					}
					if (point.X + width < clientSize.Width)
					{
						num = point.X - clientSize.Width + width + 3;
					}
				}
				else if (point.X < 0)
				{
					num = point.X - 3;
				}
				if (point.Y > clientSize.Height - height + 3)
				{
					if (clientSize.Height - height + 3 > 0)
					{
						num2 = point.Y - clientSize.Height + height + 3;
					}
					else if (point.Y + height < 0)
					{
						num2 = point.Y - clientSize.Height + height + 3;
					}
					else if (point.Y > clientSize.Height)
					{
						num2 = point.Y - 3;
					}
				}
				if (height > clientSize.Height)
				{
					if (point.Y > 3)
					{
						num2 = point.Y - 3;
					}
					if (point.Y + height < clientSize.Height)
					{
						num2 = point.Y - clientSize.Height + height + 3;
					}
				}
				else if (point.Y < 0)
				{
					num2 = point.Y - 3;
				}
				if (num != 0 || num2 != 0)
				{
					bolScrollFlag = true;
					Point autoScrollPosition2 = new Point(num - base.AutoScrollPosition.X, num2 - base.AutoScrollPosition.Y);
					SetAutoScrollPosition(autoScrollPosition2);
					result = true;
				}
			}
			return result;
		}

		protected void SetAutoScrollPosition(Point p)
		{
			if (!StackTraceHelper.CheckRecursion())
			{
				Console.Write("Scroll   ----   x:" + Convert.ToString(p.X + base.AutoScrollPosition.X) + " y:" + Convert.ToString(p.Y + base.AutoScrollPosition.Y));
				bolScrolling = true;
				base.AutoScrollPosition = p;
				bolScrolling = false;
				OnScroll();
				Console.WriteLine("End Scroll");
			}
		}
	}
}
