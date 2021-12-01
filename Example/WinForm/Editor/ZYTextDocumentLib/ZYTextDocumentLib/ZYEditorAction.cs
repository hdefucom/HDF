using System.Collections;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public abstract class ZYEditorAction : ZYToolBarGroup.IZYToolBarButtonAction
	{
		internal int SelectStart = -1;

		internal int SelectLength = -1;

		internal int SelectStart2 = -1;

		internal int SelectLength2 = -1;

		internal ArrayList Elements = null;

		internal ZYTextElement SingleElement = null;

		protected ZYTextDocument myOwnerDocument = null;

		public Keys HotKey = Keys.None;

		public Keys KeyCode = Keys.None;

		public bool ShiftKey = false;

		public bool ControlKey = false;

		public bool AltKey = false;

		public int MouseX = 0;

		public int MouseY = 0;

		public MouseButtons MouseButton = MouseButtons.None;

		public string Param1 = null;

		public string Param2 = null;

		public string Param3 = null;

		public ZYTextDocument OwnerDocument
		{
			get
			{
				return myOwnerDocument;
			}
			set
			{
				myOwnerDocument = value;
			}
		}

		protected ZYEditorAction BaseCloneFrom(ZYEditorAction a)
		{
			if (a != null && a != this)
			{
				myOwnerDocument = a.OwnerDocument;
				HotKey = a.HotKey;
				KeyCode = a.KeyCode;
				ShiftKey = a.ShiftKey;
				ControlKey = a.ControlKey;
				AltKey = a.AltKey;
				MouseX = a.MouseX;
				MouseY = a.MouseY;
				MouseButton = a.MouseButton;
				Param1 = a.Param1;
				Param2 = a.Param2;
				Param3 = a.Param3;
				if (a.Elements != null)
				{
					Elements = new ArrayList();
					Elements.AddRange(a.Elements);
				}
				SingleElement = a.SingleElement;
				return this;
			}
			return null;
		}

		public virtual bool CanHandleKeyDown()
		{
			return true;
		}

		public virtual bool TestHotKey(Keys vKeyCode, bool vShift, bool vControl, bool vAlt)
		{
			if (HotKey == Keys.None)
			{
				return false;
			}
			if (vShift)
			{
				vKeyCode |= Keys.Shift;
			}
			if (vControl)
			{
				vKeyCode |= Keys.Control;
			}
			if (vAlt)
			{
				vKeyCode |= Keys.Alt;
			}
			return vKeyCode == HotKey;
		}

		public virtual string ActionName()
		{
			return null;
		}

		public virtual bool isEnable()
		{
			return true;
		}

		public virtual bool Execute()
		{
			return true;
		}

		public virtual bool UIExecute()
		{
			return Execute();
		}

		public virtual int CheckState()
		{
			return -1;
		}

		public virtual ZYEditorAction Clone()
		{
			return null;
		}

		public bool SetText(string strText)
		{
			Param1 = strText;
			return true;
		}

		public virtual string GetText()
		{
			return Param1;
		}

		public virtual bool isUndoable()
		{
			return false;
		}

		public virtual string UndoName()
		{
			return null;
		}

		public virtual bool Undo()
		{
			return true;
		}

		public virtual bool Redo()
		{
			return Execute();
		}
	}
}
