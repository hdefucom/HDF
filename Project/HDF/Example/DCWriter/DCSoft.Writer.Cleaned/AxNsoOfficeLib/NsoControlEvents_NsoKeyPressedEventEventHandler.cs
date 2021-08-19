using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(true)]
	[Guid("D13D2FED-7FCC-4CD0-AB90-4583B2FAD9E9")]
	public delegate void NsoControlEvents_NsoKeyPressedEventEventHandler(short nKeyCode, sbyte nKeyChar, short nKeyFunction, short nModifiers, bool bCancel);
}
