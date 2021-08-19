using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(true)]
	[Guid("D42ECAF8-5F32-4FF9-92E9-6ECE253FC0FB")]
	public enum OFInitState
	{
		ofiCanSave = 1,
		ofiCanSaveAs = 2,
		ofiCanModify = 4,
		ofiCanEdit = 8,
		ofiViewToolBar = 0x10,
		ofiShowVersion = 0x20
	}
}
