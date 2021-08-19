using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       对象参数列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	[DCPublishAPI]
	public class ObjectParameterList : List<ObjectParameter>
	{
		/// <summary>
		///       获得指定名称的参数对象
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>获得的参数对象</returns>
		public ObjectParameter this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectParameter current = enumerator.Current;
						if (current.Name == name)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		public ObjectParameterList Clone()
		{
			ObjectParameterList objectParameterList = new ObjectParameterList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ObjectParameter current = enumerator.Current;
					objectParameterList.Add(current.Clone());
				}
			}
			return objectParameterList;
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public ObjectParameter ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void ComSetItem(int index, ObjectParameter item)
		{
			base[index] = item;
		}
	}
}
