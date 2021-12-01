using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_InsertKB : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertkb";
		}

		public override bool Execute()
		{
			myOwnerDocument._InsertKB(OnlyTemplate: false);
			return true;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool TestHotKey(Keys vKeyCode, bool vShift, bool vControl, bool vAlt)
		{
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
			switch (vKeyCode)
			{
			case (Keys)131147:
				return true;
			case Keys.F4:
				return true;
			default:
				return false;
			}
		}

		public A_InsertKB()
		{
			HotKey = Keys.F9;
		}
	}
}
