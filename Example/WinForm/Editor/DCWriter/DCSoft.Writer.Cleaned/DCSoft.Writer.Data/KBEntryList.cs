using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识节点列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	
	[ComClass("00012345-6789-ABCD-EF01-234567890029", "AE551F76-B49D-4EEE-980B-15CDB1C5AEF7")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComDefaultInterface(typeof(IKBEntryList))]
	[Guid("00012345-6789-ABCD-EF01-234567890029")]
	public class KBEntryList : List<KBEntry>, IKBEntryList
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890029";

		internal const string CLASSID_Interface = "AE551F76-B49D-4EEE-980B-15CDB1C5AEF7";

		/// <summary>
		///       列表中最后一个元素
		///       </summary>
		
		public KBEntry Last
		{
			get
			{
				if (base.Count > 0)
				{
					return base[base.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public KBEntryList()
		{
		}

		/// <summary>
		///       根据3个参数创建知识节点并添加到列表中
		///       </summary>
		/// <param name="id">节点编号</param>
		/// <param name="text">节点文本</param>
		/// <param name="Value">节点值</param>
		/// <returns>新添加的节点对象 </returns>
		
		public KBEntry AddBy3Parameter(string string_0, string text, string Value)
		{
			KBEntry kBEntry = new KBEntry();
			kBEntry.ID = string_0;
			kBEntry.Text = text;
			kBEntry.Value = Value;
			Add(kBEntry);
			return kBEntry;
		}

		/// <summary>
		///       根据3个参数创建知识节点并添加到列表中
		///       </summary>
		/// <param name="id">节点编号</param>
		/// <param name="text">节点文本</param>
		/// <param name="Value">节点值</param>
		/// <param name="style">节点类型</param>
		/// <returns>新添加的节点对象 </returns>
		
		public KBEntry AddBy4Parameters(string string_0, string text, string Value, KBEntryStyle style)
		{
			KBEntry kBEntry = new KBEntry();
			kBEntry.ID = string_0;
			kBEntry.Text = text;
			kBEntry.Value = Value;
			kBEntry.Style = style;
			Add(kBEntry);
			return kBEntry;
		}

		/// <summary>
		///       对内容进行排序
		///       </summary>
		/// <returns>操作是否修改了列表内容</returns>
		
		public bool SortItems()
		{
			if (base.Count <= 1)
			{
				return false;
			}
			bool flag = true;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KBEntry current = enumerator.Current;
					if (current.ListIndex != 0)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				return false;
			}
			flag = false;
			for (int i = 0; i < base.Count; i++)
			{
				KBEntry kBEntry = base[i];
				for (int j = i + 1; j < base.Count; j++)
				{
					KBEntry kBEntry2 = base[j];
					if (kBEntry.ListIndex > kBEntry2.ListIndex)
					{
						base[i] = kBEntry2;
						base[j] = kBEntry;
						flag = true;
					}
				}
			}
			return flag;
		}
	}
}
