using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("99C85318-FF76-47F2-BE07-B0F26C189139")]
	[ComVisible(true)]
	public delegate void NsoControlEvents_NsoKeyPressedEvent2EventHandler(short nKeyCode, short nKeyChar, short nKeyFunction, short nModifiers, bool bCancel);
}
