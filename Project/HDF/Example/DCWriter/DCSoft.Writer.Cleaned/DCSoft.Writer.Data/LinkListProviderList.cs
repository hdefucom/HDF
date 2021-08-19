using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       联动列表项目提供者集合
	///       </summary>
	[Guid("D030F4E0-C4EF-4370-9F07-4FA1AFC62C7D")]
	[ComDefaultInterface(typeof(ILinkListProviderList))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("Count={ Count }")]
	[ComClass("D030F4E0-C4EF-4370-9F07-4FA1AFC62C7D", "36702F82-E65E-4F65-8CE8-8A9F8BF7CC5C")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DocumentComment]
	[DCPublishAPI]
	public class LinkListProviderList : List<LinkListProvider>, ILinkListProviderList
	{
		internal const string CLASSID = "D030F4E0-C4EF-4370-9F07-4FA1AFC62C7D";

		internal const string CLASSID_Interface = "36702F82-E65E-4F65-8CE8-8A9F8BF7CC5C";

		/// <summary>
		///       获得所有可用提供者的名称
		///       </summary>
		public string[] Names
		{
			get
			{
				string[] array = new string[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = base[i].Name;
				}
				return array;
			}
		}

		/// <summary>
		///       获得指定名称的提供者对象
		///       </summary>
		/// <param name="name">名称，不区分大小写</param>
		/// <returns>获得的提供者对象，若未找到则返回空引用。</returns>
		public LinkListProvider GetEnabledProvider(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LinkListProvider current = enumerator.Current;
					if (current.Enabled && string.Compare(current.Name, name, ignoreCase: true) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       判断是否存在指定名称的提供者对象
		///       </summary>
		/// <param name="name">名称，不区分大小写</param>
		/// <returns>是否存在</returns>
		public bool ContainsName(string name)
		{
			return GetEnabledProvider(name) != null;
		}

		/// <summary>
		///       删除指定名称的提供者对象
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <returns>
		/// </returns>
		public bool RemoveByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LinkListProvider current = enumerator.Current;
					if (string.Compare(current.Name, name, ignoreCase: true) == 0)
					{
						Remove(current);
						return true;
					}
				}
			}
			return false;
		}
	}
}
