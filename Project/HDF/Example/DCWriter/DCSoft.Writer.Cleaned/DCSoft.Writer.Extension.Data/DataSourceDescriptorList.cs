using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       数据源描述对象列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComClass("DC3BCA1A-952D-4D72-8712-5FE4666D0DA0", "333C6844-83AC-4890-A854-EB94FD29BC71")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[Guid("DC3BCA1A-952D-4D72-8712-5FE4666D0DA0")]
	[XmlType]
	[DebuggerDisplay("Count={ Count }")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDataSourceDescriptorList))]
	public class DataSourceDescriptorList : List<DataSourceDescriptor>, IDataSourceDescriptorList
	{
		internal const string CLASSID = "DC3BCA1A-952D-4D72-8712-5FE4666D0DA0";

		internal const string CLASSID_Interface = "333C6844-83AC-4890-A854-EB94FD29BC71";
	}
}
