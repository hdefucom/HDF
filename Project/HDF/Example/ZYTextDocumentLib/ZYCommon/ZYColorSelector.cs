using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class ZYColorSelector
	{
		private static int[] ColorTable = new int[28]
		{
			0,
			8421504,
			128,
			32896,
			32768,
			8421376,
			8388608,
			8388736,
			4227200,
			4210688,
			16744448,
			8404992,
			16711744,
			16512,
			16777215,
			12632256,
			255,
			65535,
			65280,
			16776960,
			16711680,
			16711935,
			8454143,
			8453888,
			16777088,
			16744576,
			8388863,
			4227327
		};

		private int ItemSize = 15;

		private Color intForeColor = Color.Black;

		private Color intBackColor = Color.White;

		private int intLeft;

		private int intTop;

		private int intWidth;

		private int intHeight;

		private Control myOwnerControl = null;

		private int intSelectMode = 0;

		private bool bolShowForeColor = true;

		private bool bolShowBackColor = true;

		public bool ShowForeColor
		{
			get
			{
				return bolShowForeColor;
			}
			set
			{
				bolShowForeColor = value;
				if (!bolShowForeColor)
				{
					intSelectMode = 1;
				}
				UpdateView();
			}
		}

		public bool ShowBackColor
		{
			get
			{
				return bolShowBackColor;
			}
			set
			{
				bolShowBackColor = value;
				if (!bolShowBackColor)
				{
					intSelectMode = 0;
				}
				UpdateView();
			}
		}

		public int SelectMode
		{
			get
			{
				return intSelectMode;
			}
			set
			{
				intSelectMode = value;
				UpdateView();
			}
		}

		public Color ForeColor
		{
			get
			{
				return intForeColor;
			}
			set
			{
				intForeColor = value;
				UpdateView();
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
				UpdateView();
			}
		}

		public Color CurrentColor
		{
			get
			{
				return (intSelectMode == 0) ? intForeColor : intBackColor;
			}
			set
			{
				if (intSelectMode == 0)
				{
					intForeColor = value;
				}
				else
				{
					intBackColor = value;
				}
				UpdateView();
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

		public void BindControl(Control vControl)
		{
			myOwnerControl = vControl;
			if (myOwnerControl != null)
			{
				myOwnerControl.Paint += myOwnerControl_Paint;
				myOwnerControl.MouseDown += myOwnerControl_MouseDown;
			}
		}

		private Rectangle GetColorRect(bool vForeColor)
		{
			if ((vForeColor && bolShowForeColor) || (!vForeColor && bolShowBackColor))
			{
				Rectangle result = new Rectangle(intLeft + 5, intTop + 5, ItemSize - 2, ItemSize - 2);
				if (!bolShowForeColor || !bolShowBackColor)
				{
					result.Width = ItemSize + 4;
					result.Height = ItemSize + 4;
				}
				if (bolShowForeColor && bolShowBackColor && !vForeColor)
				{
					result.X = intLeft + 11;
					result.Y = intTop + 11;
				}
				return result;
			}
			return Rectangle.Empty;
		}

		public void RefreshView(Graphics Graph, Rectangle ClipRect)
		{
			Rectangle rectangle = new Rectangle(intLeft, intTop, ItemSize * 2, ItemSize * 2);
			if (Graph == null)
			{
				return;
			}
			if (rectangle.IntersectsWith(ClipRect))
			{
				ControlPaint.DrawButton(Graph, rectangle, ButtonState.Pushed);
				rectangle = GetColorRect(vForeColor: false);
				if (!rectangle.IsEmpty)
				{
					using (SolidBrush brush = new SolidBrush(intBackColor))
					{
						Graph.FillRectangle(brush, rectangle);
						Graph.DrawRectangle((intSelectMode == 1) ? Pens.Red : Pens.Black, rectangle);
						if (intSelectMode == 1)
						{
							Graph.DrawRectangle(Pens.Red, rectangle.Left - 1, rectangle.Top - 1, rectangle.Width + 2, rectangle.Height + 2);
						}
					}
				}
				rectangle = GetColorRect(vForeColor: true);
				if (!rectangle.IsEmpty)
				{
					using (SolidBrush brush = new SolidBrush(intForeColor))
					{
						Graph.FillRectangle(brush, rectangle);
						Graph.DrawRectangle((intSelectMode == 0) ? Pens.Red : Pens.Black, rectangle);
						if (intSelectMode == 0)
						{
							Graph.DrawRectangle(Pens.Red, rectangle.Left - 1, rectangle.Top - 1, rectangle.Width + 2, rectangle.Height + 2);
						}
					}
				}
			}
			for (int i = 0; i < ColorTable.Length; i++)
			{
				rectangle = GetItemRect(i);
				if (rectangle.IntersectsWith(ClipRect))
				{
					ControlPaint.DrawButton(Graph, rectangle, ButtonState.Pushed);
					using (SolidBrush brush = new SolidBrush(CommonFunction.ConvertToColor(ColorTable[i])))
					{
						Graph.FillRectangle(brush, rectangle.Left + 2, rectangle.Top + 2, rectangle.Width - 4, rectangle.Height - 4);
					}
				}
			}
		}

		private Rectangle GetItemRect(int index)
		{
			int num = (int)Math.Ceiling((double)ColorTable.Length / 2.0);
			return new Rectangle(intLeft + ItemSize * (2 + index % num), intTop + ((index >= num) ? ItemSize : 0), ItemSize, ItemSize);
		}

		public bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			if (Button == MouseButtons.Left)
			{
				Rectangle colorRect = GetColorRect(vForeColor: true);
				if (!colorRect.IsEmpty && colorRect.Contains(x, y))
				{
					intSelectMode = 0;
					UpdateView();
					return true;
				}
				colorRect = GetColorRect(vForeColor: false);
				if (!colorRect.IsEmpty && colorRect.Contains(x, y))
				{
					intSelectMode = 1;
					UpdateView();
					return true;
				}
				for (int i = 0; i < ColorTable.Length; i++)
				{
					if (GetItemRect(i).Contains(x, y))
					{
						if (intSelectMode == 0)
						{
							intForeColor = CommonFunction.ConvertToColor(ColorTable[i]);
						}
						else
						{
							intBackColor = CommonFunction.ConvertToColor(ColorTable[i]);
						}
						UpdateView();
						return true;
					}
				}
			}
			return false;
		}

		public void UpdateView()
		{
			if (myOwnerControl != null)
			{
				myOwnerControl.Invalidate(new Rectangle(intLeft, intTop, ItemSize * 2, ItemSize * 2));
			}
		}

		private void myOwnerControl_Paint(object sender, PaintEventArgs e)
		{
			RefreshView(e.Graphics, e.ClipRectangle);
		}

		private void myOwnerControl_MouseDown(object sender, MouseEventArgs e)
		{
			HandleMouseDown(e.X, e.Y, e.Button);
		}
	}
}
