using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("FF534C3D-4E95-4966-AB2E-6A440F16CCBB")]
	[ComVisible(true)]
	public delegate void NsoControlEvents_NsoBeforeFileSavedEventHandler(string sName, bool bCancel);
}
