using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_InsertChar : ZYEditorAction
	{
		public override bool CanHandleKeyDown()
		{
			return false;
		}

		public override bool TestHotKey(Keys vKeyCode, bool vShift, bool vControl, bool vAlt)
		{
			if (vShift || vControl || vAlt)
			{
				return false;
			}
			char c = (char)vKeyCode;
			if (char.IsControl(c))
			{
				if (c == '\t' || c == '\r')
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public override string ActionName()
		{
			return "insertchar";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertChar((char)KeyCode);
			return true;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertChar a_InsertChar = new A_InsertChar();
			a_InsertChar.BaseCloneFrom(this);
			return a_InsertChar;
		}
	}
}
