using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       名称-值数据列表
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	[Editor(typeof(dlgDCNameValueList.DCNameValueListUITypEditor), typeof(UITypeEditor))]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[DocumentComment]
	public class DCNameValueList : List<DCNameValueItem>
	{
		public override string ToString()
		{
			int num = 8;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCNameValueItem current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(current.Name + "=" + current.Value);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       获得数值
		                                                                    ///       </summary>
		                                                                    /// <param name="name">数据名称</param>
		                                                                    /// <returns>数据内容</returns>
		public string GetValue(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCNameValueItem current = enumerator.Current;
					if (current.Name == name)
					{
						return current.Value;
					}
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       设置数值
		                                                                    ///       </summary>
		                                                                    /// <param name="name">数据名称</param>
		                                                                    /// <param name="Value">数值</param>
		public bool SetValue(string name, string Value)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCNameValueItem current = enumerator.Current;
					if (current.Name == name)
					{
						if (current.Value == Value)
						{
							return false;
						}
						current.Value = Value;
						return true;
					}
				}
			}
			DCNameValueItem item = new DCNameValueItem(name, Value);
			Add(item);
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public DCNameValueList Clone()
		{
			DCNameValueList dCNameValueList = new DCNameValueList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCNameValueItem current = enumerator.Current;
					dCNameValueList.Add(current.Clone());
				}
			}
			return dCNameValueList;
		}
	}
}
