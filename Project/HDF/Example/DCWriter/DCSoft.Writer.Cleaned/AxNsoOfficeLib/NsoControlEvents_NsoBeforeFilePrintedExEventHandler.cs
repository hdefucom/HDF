using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	[Guid("01460DEE-BA29-444C-9F13-8AEA44E15F04")]
	public delegate void NsoControlEvents_NsoBeforeFilePrintedExEventHandler(bool bCancel);
}
