using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Windows32;

namespace ZYCommon
{
	[DefaultEvent("SelectedIndexChanged")]
	[Designer(typeof(EMRTabControlDesigner))]
	public class EMRTabControl : UserControl
	{
		private EMRTabPageCollection myTabPages = new EMRTabPageCollection();

		private EMRTabPage mySelectedTab = null;

		private Color intClientBorderColor = Color.Black;

		private Color intClientBackColor = SystemColors.Control;

		private int intPageTagSize = 25;

		public bool EnableSelectedIndexChangedEvent = true;

		public bool EnableClickChange = true;

		private Image myButtonImage = null;

		private bool isDrawTabContent = false;

		public int PageTagSize
		{
			get
			{
				return intPageTagSize;
			}
			set
			{
				intPageTagSize = value;
			}
		}

		public Color ClientBorderColor
		{
			get
			{
				return intClientBorderColor;
			}
			set
			{
				intClientBorderColor = value;
			}
		}

		public Color ClientBackColor
		{
			get
			{
				return intClientBackColor;
			}
			set
			{
				intClientBackColor = value;
				foreach (EMRTabPage myTabPage in myTabPages)
				{
					myTabPage.UpdateBackColor();
				}
			}
		}

		public Image ButtonImage
		{
			get
			{
				return myButtonImage;
			}
			set
			{
				myButtonImage = value;
			}
		}

		public EMRTabPage SelectedTab
		{
			get
			{
				return mySelectedTab;
			}
			set
			{
				if (mySelectedTab != value)
				{
					mySelectedTab = value;
					mySelectedTab.BringToFront();
					RefreshTagHead();
					if (this.SelectedIndexChanged != null && EnableSelectedIndexChangedEvent)
					{
						this.SelectedIndexChanged(this, null);
					}
				}
			}
		}

		public int SelectedIndex
		{
			get
			{
				return myTabPages.IndexOf(mySelectedTab);
			}
			set
			{
				if (value >= 0 && value < myTabPages.Count)
				{
					SelectedTab = myTabPages[value];
				}
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public EMRTabPageCollection TabPages => myTabPages;

		public virtual Rectangle PageBounds => new Rectangle(2, intPageTagSize + 1, base.ClientSize.Width - 4, base.ClientSize.Height - intPageTagSize - 3);

		public event EventHandler SelectedIndexChanged = null;

		public EMRTabControl()
		{
			myTabPages.OwnerTabControl = this;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 20:
				break;
			case 15:
				DoPaintUpdateRect();
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		internal void InnerTestClick()
		{
			OnClick(null);
		}

		protected override void OnClick(EventArgs e)
		{
			if (EnableClickChange)
			{
				Point pt = PointToClient(Control.MousePosition);
				foreach (EMRTabPage myTabPage in myTabPages)
				{
					Rectangle tagBounds = myTabPage.TagBounds;
					if (tagBounds.Contains(pt))
					{
						if (SelectedTab != myTabPage)
						{
							SelectedTab = myTabPage;
						}
						break;
					}
				}
			}
		}

		public void RefreshTagHead()
		{
			Invalidate(new Rectangle(0, 0, base.ClientSize.Width, intPageTagSize + 4), invalidateChildren: false);
		}

		private void DoPaintUpdateRect()
		{
			PAINTSTRUCT ps = default(PAINTSTRUCT);
			User32.BeginPaint(base.Handle.ToInt32(), ref ps);
			RECT rect = default(RECT);
			User32.InvalidateRect(base.Handle.ToInt32(), ref rect, erase: false);
			Graphics g = CreateGraphics();
			PaintContent(g);
			User32.EndPaint(base.Handle.ToInt32(), ref ps);
		}

		private void PaintContent(Graphics g)
		{
			RefreshTagBounds(g);
			int num = 0;
			int height = 0;
			try
			{
				foreach (EMRTabPage myTabPage in myTabPages)
				{
					num += myTabPage.TagBounds.Width;
					height = myTabPage.TagBounds.Height;
				}
				g.FillRectangle(SystemBrushes.ButtonHighlight, num, 0, base.Width - num, height);
			}
			catch
			{
			}
			foreach (EMRTabPage myTabPage2 in myTabPages)
			{
				OnDrawItem(g, myTabPage2);
			}
			using (Pen pen = new Pen(intClientBorderColor))
			{
				Rectangle pageBounds = PageBounds;
				pageBounds.Offset(-1, -1);
				pageBounds.Width += 2;
				pageBounds.Height += 2;
				if (myTabPages.LastPage != null)
				{
					Rectangle tagBounds = myTabPages.LastPage.TagBounds;
					if (tagBounds.Right < base.ClientSize.Width)
					{
						g.DrawLine(pen, tagBounds.Right, pageBounds.Top, pageBounds.Right, pageBounds.Top);
					}
				}
				g.DrawLine(pen, pageBounds.Left, pageBounds.Top, pageBounds.Left, pageBounds.Bottom);
				g.DrawLine(pen, pageBounds.Left, pageBounds.Bottom, pageBounds.Right, pageBounds.Bottom);
				g.DrawLine(pen, pageBounds.Right, pageBounds.Top, pageBounds.Right, pageBounds.Bottom);
			}
		}

		public void RefreshTagBounds(Graphics myGraph)
		{
			int num = PageBounds.Left - 1;
			int num2 = 2;
			if (myButtonImage != null)
			{
				num2 = myButtonImage.Size.Width / 3 + 2;
			}
			using (StringFormat format = new StringFormat())
			{
				foreach (EMRTabPage myTabPage in myTabPages)
				{
					SizeF sizeF = myGraph.MeasureString(myTabPage.Caption, Font, 1000, format);
					myTabPage.TagBounds = new Rectangle(num, 1, num2 * 2 + (int)sizeF.Width, intPageTagSize);
					num += num2 * 2 + (int)sizeF.Width;
				}
			}
		}

		protected virtual void OnDrawItem(Graphics myGraph, EMRTabPage Page)
		{
			if (isDrawTabContent)
			{
			}
			isDrawTabContent = true;
			Rectangle tagBounds = Page.TagBounds;
			if (myButtonImage != null)
			{
				int num = myButtonImage.Size.Width / 3;
				int height = myButtonImage.Size.Height;
				Rectangle destRect = tagBounds;
				destRect.Width = num;
				myGraph.DrawImage(myButtonImage, destRect, 0, 0, num, height, GraphicsUnit.Pixel);
				destRect.X = tagBounds.Left + num;
				destRect.Width = tagBounds.Width - num * 2;
				myGraph.DrawImage(myButtonImage, destRect, num, 0, num, height, GraphicsUnit.Pixel);
				destRect.X = tagBounds.Right - num;
				destRect.Width = num;
				myGraph.DrawImage(myButtonImage, destRect, num * 2, 0, num, height, GraphicsUnit.Pixel);
			}
			else
			{
				using (Pen pen = new Pen(intClientBorderColor))
				{
					myGraph.DrawLine(pen, tagBounds.Left, tagBounds.Top, tagBounds.Left, tagBounds.Bottom);
					myGraph.DrawLine(pen, tagBounds.Left, tagBounds.Top, tagBounds.Right, tagBounds.Top);
					myGraph.DrawLine(pen, tagBounds.Right, tagBounds.Top, tagBounds.Right, tagBounds.Bottom);
				}
			}
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				myGraph.DrawString(Page.Caption, Font, SystemBrushes.WindowText, new RectangleF(tagBounds.X, tagBounds.Y, tagBounds.Width, tagBounds.Height), stringFormat);
			}
			if (Page != mySelectedTab)
			{
				using (Pen pen = new Pen(intClientBorderColor))
				{
					myGraph.DrawLine(pen, tagBounds.X, tagBounds.Bottom - 1, tagBounds.Right, tagBounds.Bottom - 1);
				}
			}
		}

		internal void UpdatePages()
		{
			base.Controls.Clear();
			base.Controls.AddRange(myTabPages.ToArray());
			foreach (EMRTabPage myTabPage in myTabPages)
			{
				myTabPage.OwnerTabControl = this;
				myTabPage.UpdateBackColor();
			}
			if (myTabPages.Count > 0)
			{
				mySelectedTab = myTabPages[0];
			}
		}

		protected override void OnResize(EventArgs e)
		{
			Rectangle pageBounds = PageBounds;
			foreach (Control control in base.Controls)
			{
				control.Bounds = pageBounds;
			}
		}

		public void CallResize()
		{
			OnResize(null);
		}
	}
}
