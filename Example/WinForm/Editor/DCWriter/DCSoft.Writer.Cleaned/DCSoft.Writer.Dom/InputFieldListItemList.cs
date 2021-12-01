using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       下列列表项目列表
	///       </summary>
	[Serializable]
	[Obsolete]
	[XmlType]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	public class InputFieldListItemList : List<InputFieldListItem>
	{
	}
}
