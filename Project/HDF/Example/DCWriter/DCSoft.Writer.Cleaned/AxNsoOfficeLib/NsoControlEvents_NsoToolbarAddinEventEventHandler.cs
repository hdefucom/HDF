using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("1AA5475E-5E45-4E49-89A3-ADCFE9AB5E98")]
	[ComVisible(true)]
	public delegate void NsoControlEvents_NsoToolbarAddinEventEventHandler(int nID, string sRev1, string sRev2);
}
