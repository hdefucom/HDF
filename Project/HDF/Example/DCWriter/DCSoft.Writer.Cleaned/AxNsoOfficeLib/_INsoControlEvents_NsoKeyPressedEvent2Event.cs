using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoKeyPressedEvent2Event
	{
		public bool bCancel;

		public short nKeyChar;

		public short nKeyCode;

		public short nKeyFunction;

		public short nModifiers;

		public _INsoControlEvents_NsoKeyPressedEvent2Event(short nKeyCode, short nKeyChar, short nKeyFunction, short nModifiers, bool bCancel)
		{
			this.nKeyCode = nKeyCode;
			this.nKeyChar = nKeyChar;
			this.nKeyFunction = nKeyFunction;
			this.nModifiers = nModifiers;
			this.bCancel = bCancel;
		}
	}
}
