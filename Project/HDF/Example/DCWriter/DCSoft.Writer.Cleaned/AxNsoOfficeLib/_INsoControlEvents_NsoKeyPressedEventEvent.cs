using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoKeyPressedEventEvent
	{
		public bool bCancel;

		public sbyte nKeyChar;

		public short nKeyCode;

		public short nKeyFunction;

		public short nModifiers;

		public _INsoControlEvents_NsoKeyPressedEventEvent(short nKeyCode, sbyte nKeyChar, short nKeyFunction, short nModifiers, bool bCancel)
		{
			this.nKeyCode = nKeyCode;
			this.nKeyChar = nKeyChar;
			this.nKeyFunction = nKeyFunction;
			this.nModifiers = nModifiers;
			this.bCancel = bCancel;
		}
	}
}
