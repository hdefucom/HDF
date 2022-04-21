using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       VB脚本项目列表
	///       </summary>
	[Serializable]
	
	[ComVisible(false)]
	public class VBScriptItemList : List<VBScriptItem>
	{
		/// <summary>
		///       获得指定名称的项目
		///       </summary>
		/// <param name="name">指定的名称</param>
		/// <returns>获得的项目，若未找到则返回空引用</returns>
		public VBScriptItem this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						VBScriptItem current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: true) == 0)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       列表内容是否为空
		///       </summary>
		public bool IsEmpty
		{
			get
			{
				if (base.Count == 0)
				{
					return true;
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						VBScriptItem current = enumerator.Current;
						if (!string.IsNullOrEmpty(current.ScriptText))
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		/// <summary>
		///       判断是否存在指定名称的有效脚本代码
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>是否存在脚本代码</returns>
		public bool ContainsScript(string name)
		{
			VBScriptItem vBScriptItem = this[name];
			if (vBScriptItem != null)
			{
				return !string.IsNullOrEmpty(vBScriptItem.ScriptText);
			}
			return false;
		}

		/// <summary>
		///       设置脚本
		///       </summary>
		/// <param name="name">名称</param>
		/// <param name="scriptText">脚本</param>
		public void SetScript(string name, string scriptText)
		{
			if (scriptText != null)
			{
				scriptText = scriptText.Trim();
				if (scriptText.Length == 0)
				{
					scriptText = null;
				}
			}
			VBScriptItem vBScriptItem = this[name];
			if (scriptText == null)
			{
				if (vBScriptItem != null)
				{
					Remove(vBScriptItem);
				}
				return;
			}
			if (vBScriptItem == null)
			{
				vBScriptItem = new VBScriptItem();
				vBScriptItem.Name = name;
				Add(vBScriptItem);
			}
			vBScriptItem.ScriptText = scriptText;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public VBScriptItemList Clone()
		{
			VBScriptItemList vBScriptItemList = new VBScriptItemList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VBScriptItem current = enumerator.Current;
					vBScriptItemList.Add(current.Clone());
				}
			}
			return vBScriptItemList;
		}

		/// <summary>
		///       表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			int num = 9;
			if (IsEmpty)
			{
				return "";
			}
			if (base.Count == 1)
			{
				VBScriptItem vBScriptItem = base[0];
				return vBScriptItem.Name + ":" + vBScriptItem.ScriptText;
			}
			return string.Format(WriterStringsCore.ScriptItems_Count, base.Count);
		}
	}
}
