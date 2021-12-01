using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class ZYButtonGroup : IDisposable
	{
		public class ZYButton
		{
			public string ToolTip = null;

			public string Command = "";

			public int CommandID = 0;

			public int ImageIndex = -1;

			public bool Visible = true;

			public bool Enable = true;

			public bool Pushing = false;

			public bool Pushed = false;

			public int Left = 0;

			public int Top = 0;

			public int Width = 16;

			public int Height = 16;

			public int GroupID = 0;

			public ZYButtonGroup OwnerGroup = null;

			public string LastStatus = null;

			public Rectangle ButtonRect => new Rectangle(Left + OwnerGroup.Left, Top + OwnerGroup.Top, Width, Height);
		}

		private Image myButtonImage;

		private int intICONWidth = 16;

		private int intICONHeight = 16;

		private int intDefaultButtonWidth = 20;

		private int intDefaultButtonHeight = 20;

		private int intLeft = 0;

		private int intTop = 0;

		private int intWidth = 0;

		private int intHeight = 0;

		private ArrayList myButtons = new ArrayList();

		private ZYButton myCurrentButton = null;

		private ZYButton myLastButton = null;

		private bool bolEnableClickEvent = true;

		private int intPerformHeight = 0;

		private int intPerformWidth = 0;

		public Control OwnerControl = null;

		public int PerformHeight => intPerformHeight;

		public int PerformWidth => intPerformWidth;

		public ArrayList Buttons => myButtons;

		public int DefaultButtonWidth
		{
			get
			{
				return intDefaultButtonWidth;
			}
			set
			{
				intDefaultButtonWidth = value;
			}
		}

		public int DefaultButtonHeight
		{
			get
			{
				return intDefaultButtonHeight;
			}
			set
			{
				intDefaultButtonHeight = value;
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

		public int Top
		{
			get
			{
				return intTop;
			}
			set
			{
				intTop = value;
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
			}
		}

		public Rectangle ClientRect
		{
			get
			{
				return new Rectangle(intLeft, intTop, intWidth, intHeight);
			}
			set
			{
				intLeft = value.Left;
				intTop = value.Top;
				intWidth = value.Width;
				intHeight = value.Height;
			}
		}

		public int CommandID
		{
			get
			{
				return (myCurrentButton == null) ? (-1) : myCurrentButton.CommandID;
			}
			set
			{
				foreach (ZYButton myButton in myButtons)
				{
					if (myButton.Visible && myButton.CommandID == value)
					{
						CurrentButton = myButton;
						break;
					}
				}
			}
		}

		public int LastCommandID => (myLastButton == null) ? (-1) : myLastButton.CommandID;

		public ZYButton LastButton => myLastButton;

		public ZYButton CurrentButton
		{
			get
			{
				return myCurrentButton;
			}
			set
			{
				myCurrentButton = value;
				if (myCurrentButton != null)
				{
					myCurrentButton.Pushed = true;
					myCurrentButton.Pushing = false;
					RefreshButtonView(myCurrentButton);
					foreach (ZYButton myButton in myButtons)
					{
						if (myButton.Visible && myButton.GroupID == myCurrentButton.GroupID && myButton != myCurrentButton && (myButton.Pushed || myButton.Pushing))
						{
							myButton.Pushed = false;
							myButton.Pushing = false;
							RefreshButtonView(myButton);
						}
					}
					RaiseOnClick();
					myLastButton = myCurrentButton;
				}
			}
		}

		public event ZYButtonClickHandler OnClick = null;

		public void BindControl(Control vControl)
		{
			OwnerControl = vControl;
			if (OwnerControl != null)
			{
				OwnerControl.MouseDown += OwnerControl_MouseDown;
				OwnerControl.MouseMove += OwnerControl_MouseMove;
				OwnerControl.MouseUp += OwnerControl_MouseUp;
				OwnerControl.Paint += OwnerControl_Paint;
			}
		}

		public ZYButton AddButton(int vImageIndex, int vCommandID)
		{
			ZYButton zYButton = new ZYButton();
			myButtons.Add(zYButton);
			zYButton.OwnerGroup = this;
			zYButton.Width = intDefaultButtonWidth;
			zYButton.Height = intDefaultButtonHeight;
			zYButton.ImageIndex = vImageIndex;
			zYButton.CommandID = vCommandID;
			return zYButton;
		}

		public void SetButtonImage(Image myImg, int vICONWidth, int vICONHeight)
		{
			myButtonImage = myImg;
			intICONWidth = vICONWidth;
			intICONHeight = vICONHeight;
		}

		public Rectangle GetICONImageRange(int ImageIndex)
		{
			if (ImageIndex >= 0 && myButtonImage != null && intICONWidth > 0 && intICONHeight > 0 && myButtonImage.Size.Width > intICONWidth)
			{
				int num = (int)Math.Floor((double)myButtonImage.Size.Width / (double)intICONWidth);
				if (num > 0)
				{
					Rectangle result = new Rectangle(intICONWidth * (ImageIndex % num), (int)((double)intICONHeight * Math.Floor((double)ImageIndex / (double)num)), intICONWidth, intICONHeight);
					if (result.Bottom <= myButtonImage.Size.Height)
					{
						return result;
					}
				}
			}
			return Rectangle.Empty;
		}

		public void RefreshSize()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			intPerformHeight = 0;
			intPerformWidth = 0;
			ArrayList arrayList = new ArrayList();
			foreach (ZYButton myButton in myButtons)
			{
				if (myButton.Visible)
				{
					if (num4 == 0 || num4 + myButton.Width <= intWidth)
					{
						myButton.Left = num2;
						myButton.Top = num;
						num2 += myButton.Width;
						num4 += myButton.Width;
						if (num3 < myButton.Height)
						{
							num3 = myButton.Height;
						}
					}
					else
					{
						num2 = 0;
						num += num3;
						num4 = myButton.Width;
						num3 = myButton.Height;
						myButton.Left = 0;
						myButton.Top = num;
						num2 = myButton.Width;
					}
					if (intPerformHeight < myButton.Top + myButton.Height)
					{
						intPerformHeight = myButton.Top + myButton.Height;
					}
					if (intPerformWidth < myButton.Left + myButton.Width)
					{
						intPerformWidth = myButton.Left + myButton.Width;
					}
				}
			}
		}

		public void RefreshView(Graphics Graph, Rectangle ClipRect)
		{
			if (Graph != null && ClipRect.Width > 0 && ClipRect.Height > 0 && ClientRect.IntersectsWith(ClipRect))
			{
				foreach (ZYButton myButton in myButtons)
				{
					if (myButton.Visible)
					{
						Rectangle buttonRect = myButton.ButtonRect;
						if (buttonRect.IntersectsWith(ClipRect))
						{
							ControlPaint.DrawButton(Graph, buttonRect, myButton.Pushed ? ButtonState.Pushed : ButtonState.Normal);
							if (!myButton.Pushing && myButton.Pushed)
							{
								Graph.FillRectangle(SystemBrushes.ControlLightLight, buttonRect.Left + 2, buttonRect.Top + 2, buttonRect.Width - 4, buttonRect.Height - 4);
							}
							Rectangle iCONImageRange = GetICONImageRange(myButton.ImageIndex);
							if (!iCONImageRange.IsEmpty)
							{
								buttonRect.X += (buttonRect.Width - iCONImageRange.Width) / 2;
								buttonRect.Y += (buttonRect.Height - iCONImageRange.Height) / 2;
								buttonRect.Width = iCONImageRange.Width;
								buttonRect.Height = iCONImageRange.Height;
								if (myButton.Pushed)
								{
									buttonRect.X += ((!myButton.Pushing) ? 1 : 2);
									buttonRect.Y += ((!myButton.Pushing) ? 1 : 2);
								}
								Graph.DrawImage(myButtonImage, buttonRect, iCONImageRange, GraphicsUnit.Pixel);
							}
						}
					}
				}
			}
		}

		public void RefreshButtonView(ZYButton myButton)
		{
			if (OwnerControl != null && myButton != null && myButton.Visible)
			{
				OwnerControl.Invalidate(myButton.ButtonRect);
			}
		}

		public bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			if (ClientRect.Contains(x, y) && Button == MouseButtons.Left)
			{
				foreach (ZYButton myButton in myButtons)
				{
					if (myButton.Visible && myButton.Enable && myButton.ButtonRect.Contains(x, y))
					{
						Rectangle buttonRect = myButton.ButtonRect;
						myButton.Pushing = true;
						myButton.Pushed = true;
						myCurrentButton = myButton;
						RefreshButtonView(myButton);
						foreach (ZYButton myButton2 in myButtons)
						{
							if (myButton2.Pushed && myButton2.Visible && myButton2 != myButton)
							{
								myButton2.Pushed = false;
								RefreshButtonView(myButton2);
							}
						}
						return true;
					}
				}
			}
			return false;
		}

		public bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			if (myCurrentButton != null && myCurrentButton.Pushing)
			{
				bool flag = myCurrentButton.ButtonRect.Contains(x, y);
				if (flag != myCurrentButton.Pushed)
				{
					myCurrentButton.Pushed = flag;
					RefreshButtonView(myCurrentButton);
				}
			}
			return false;
		}

		public bool HandleMouseUp(int x, int y, MouseButtons Button)
		{
			if (myCurrentButton != null)
			{
				myCurrentButton.Pushing = false;
			}
			if (ClientRect.Contains(x, y) && Button == MouseButtons.Left)
			{
				foreach (ZYButton myButton in myButtons)
				{
					if (myButton.Visible && myButton.Enable && myButton.ButtonRect.Contains(x, y))
					{
						myButton.Pushed = true;
						myButton.Pushing = false;
						myCurrentButton = myButton;
						RefreshButtonView(myButton);
						RaiseOnClick();
						myLastButton = myCurrentButton;
						return true;
					}
				}
			}
			return false;
		}

		public void RaiseOnClick()
		{
			if (bolEnableClickEvent && this.OnClick != null)
			{
				bolEnableClickEvent = false;
				this.OnClick(this, myCurrentButton);
				bolEnableClickEvent = true;
			}
		}

		public void Dispose()
		{
			if (myButtonImage != null)
			{
				myButtonImage.Dispose();
				myButtonImage = null;
			}
		}

		private void OwnerControl_MouseDown(object sender, MouseEventArgs e)
		{
			HandleMouseDown(e.X, e.Y, e.Button);
		}

		private void OwnerControl_MouseMove(object sender, MouseEventArgs e)
		{
			HandleMouseMove(e.X, e.Y, e.Button);
		}

		private void OwnerControl_MouseUp(object sender, MouseEventArgs e)
		{
			HandleMouseUp(e.X, e.Y, e.Button);
		}

		private void OwnerControl_Paint(object sender, PaintEventArgs e)
		{
			RefreshView(e.Graphics, e.ClipRectangle);
		}
	}
}
