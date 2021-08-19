using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       病程记录文件信息对象列表
	///       </summary>
	[Guid("AECD03A9-1960-4A7C-8FFB-CDF12599307A")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("AECD03A9-1960-4A7C-8FFB-CDF12599307A", "8805D1DB-070D-4BD5-B62F-38594F568BD0")]
	[DocumentComment]
	[ComVisible(true)]
	[DebuggerDisplay("Count={ Count }")]
	[ComDefaultInterface(typeof(ISectionCourseFileInfoList))]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class SectionCourseFileInfoList : List<SectionCourseFileInfo>, ISectionCourseFileInfoList
	{
		internal const string CLASSID = "AECD03A9-1960-4A7C-8FFB-CDF12599307A";

		internal const string CLASSID_Interface = "8805D1DB-070D-4BD5-B62F-38594F568BD0";
	}
}
