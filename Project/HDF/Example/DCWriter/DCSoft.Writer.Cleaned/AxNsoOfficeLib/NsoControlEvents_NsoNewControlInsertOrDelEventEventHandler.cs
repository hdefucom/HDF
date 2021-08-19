using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("4143F9FE-1E8D-4BE9-960D-A85A8EA41069")]
	[ComVisible(true)]
	public delegate void NsoControlEvents_NsoNewControlInsertOrDelEventEventHandler(string sName, string sParentSection, int nEventType);
}
