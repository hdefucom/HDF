using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(true)]
	[Guid("61AF732C-5233-4828-AD9C-F0DB2F725148")]
	public delegate void NsoControlEvents_NsoSectionInsertOrDelEventEventHandler(string sName, int nEventType);
}
