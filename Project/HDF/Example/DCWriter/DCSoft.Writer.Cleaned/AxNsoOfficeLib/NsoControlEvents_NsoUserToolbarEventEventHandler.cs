using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("6F34332E-B3AD-4005-A937-0B5314D1D7DD")]
	[ComVisible(true)]
	public delegate void NsoControlEvents_NsoUserToolbarEventEventHandler(int nID, string sRev1, string sRev2);
}
