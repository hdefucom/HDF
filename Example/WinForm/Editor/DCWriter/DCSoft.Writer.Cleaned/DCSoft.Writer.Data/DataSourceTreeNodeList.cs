using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	[Serializable]
	[ComVisible(false)]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class DataSourceTreeNodeList : List<DataSourceTreeNode>
	{
	}
}
