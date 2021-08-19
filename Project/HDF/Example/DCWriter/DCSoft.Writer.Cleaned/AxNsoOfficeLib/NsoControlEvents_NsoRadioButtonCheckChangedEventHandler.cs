using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(true)]
	[Guid("71FEDD28-4BCC-43C3-B48F-9C15ACE19BA1")]
	public delegate void NsoControlEvents_NsoRadioButtonCheckChangedEventHandler(string sName, int oldCheckIndex, int newCheckIndex);
}
