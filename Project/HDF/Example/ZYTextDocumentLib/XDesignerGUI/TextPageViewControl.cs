using System;
using System.Drawing;
using System.Windows.Forms;
using Windows32;
using XDesignerPrinting;

namespace XDesignerGUI
{
	public class TextPageViewControl : PageScrollableControl
	{
		protected bool bolAcceptsTab = true;

		private static Keys[] myInputKeys = new Keys[8]
		{
			Keys.Left,
			Keys.Up,
			Keys.Right,
			Keys.Down,
			Keys.Tab,
			Keys.Return,
			Keys.ShiftKey,
			Keys.Control
		};

		protected bool bolForceShowCaret = false;

		protected bool bolMoveCaretWithScroll = true;

		protected bool bolInsertMode = true;

		protected bool bolCaretCreated = false;

		public static int DefaultCaretWidth = 2;

		public static int DefaultBroadCaretWidth = 6;

		protected Win32Caret myCaret = null;

		private Rectangle myCaretBounds = Rectangle.Empty;

		public bool AcceptsTab
		{
			get
			{
				return bolAcceptsTab;
			}
			set
			{
				bolAcceptsTab = value;
			}
		}

		public bool ForceShowCaret
		{
			get
			{
				return bolForceShowCaret;
			}
			set
			{
				bolForceShowCaret = value;
			}
		}

		public bool MoveCaretWithScroll
		{
			get
			{
				return bolMoveCaretWithScroll;
			}
			set
			{
				bolMoveCaretWithScroll = value;
			}
		}

		public virtual bool InsertMode
		{
			get
			{
				return bolInsertMode;
			}
			set
			{
				bolInsertMode = value;
			}
		}

		public TextPageViewControl()
		{
			myCaret = new Win32Caret(this);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData == Keys.Tab && !bolAcceptsTab)
			{
				return base.IsInputKey(keyData);
			}
			for (int i = 0; i < myInputKeys.Length; i++)
			{
				int num = (int)myInputKeys[i];
				if ((num & (int)keyData) == num)
				{
					return true;
				}
			}
			return base.IsInputKey(keyData);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			if (bolCaretCreated && !myCaretBounds.IsEmpty && Focused)
			{
				myCaret.Create(0, myCaretBounds.Width, myCaretBounds.Height);
				myCaret.SetPos(myCaretBounds.X, myCaretBounds.Y);
				myCaret.Show();
			}
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			if (bolCaretCreated)
			{
				myCaret.Hide();
			}
			base.OnLostFocus(e);
		}

		public bool MoveCaretTo(int vLeft, int vTop, int vWidth, int vHeight)
		{
			if (base.Updating)
			{
				return false;
			}
			if (!ForceShowCaret && !Focused)
			{
				if (bolCaretCreated)
				{
					myCaret.Hide();
				}
				return false;
			}
			int num = GraphicsUnitConvert.Convert(vHeight, base.GraphicsUnit, GraphicsUnit.Pixel);
			if (vWidth > 0 && vHeight > 0)
			{
				bolCaretCreated = myCaret.Create(0, vWidth, num);
				if (bolCaretCreated)
				{
					if (bolMoveCaretWithScroll)
					{
						ScrollToView(vLeft, vTop, vWidth, vHeight);
					}
					Point point = ViewPointToClient(vLeft, vTop);
					myCaret.SetPos(point.X, point.Y);
					myCaret.Show();
					if (Imm32.isImmOpen(base.Handle.ToInt32()))
					{
						Imm32.SetImmPos(base.Handle.ToInt32(), point.X, point.Y);
					}
					myCaretBounds = new Rectangle(point.X, point.Y, vWidth, num);
					if (bolMoveCaretWithScroll)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool MoveTextCaretTo(int vLeft, int vBottom, int vHeight)
		{
			return MoveCaretTo(vLeft, vBottom - vHeight, bolInsertMode ? DefaultCaretWidth : DefaultBroadCaretWidth, vHeight);
		}

		public void HideOwnerCaret()
		{
			myCaret.Hide();
		}
	}
}
