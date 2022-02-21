using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       检测数据源绑定导致的内容发送改变的结果信息列表
	///       </summary>
	[Serializable]
	[Guid("C72CA203-3B3F-44F3-98F1-22DAFB408510")]
	[ComDefaultInterface(typeof(IDetectResultForValueBindingModifiedList))]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("Count={ Count }")]
	[ComVisible(true)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComClass("C72CA203-3B3F-44F3-98F1-22DAFB408510", "D0A86420-1826-4B24-87F2-63B19AFE2F9F")]
	
	public class DetectResultForValueBindingModifiedList : List<DetectResultForValueBindingModified>, IDetectResultForValueBindingModifiedList
	{
		internal const string CLASSID = "C72CA203-3B3F-44F3-98F1-22DAFB408510";

		internal const string CLASSID_Interface = "D0A86420-1826-4B24-87F2-63B19AFE2F9F";

		public override string ToString()
		{
			int num = 4;
			if (base.Count == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DetectResultForValueBindingModified current = enumerator.Current;
					stringBuilder.AppendLine("[" + current.CurrentValue + "]=>[" + current.NewValue + "] {" + current.Binding.DataSource + "#" + current.Binding.BindingPath + "}");
				}
			}
			return stringBuilder.ToString();
		}
	}
}
