using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       基于XML的视图数据包
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	[DCInternal]
	public class XMLViewStateBag : List<XMLViewStateBagItem>, IDisposable
	{
		public object this[string name]
		{
			get
			{
				return GetValue(name);
			}
			set
			{
				SetValue(name, value);
			}
		}

		/// <summary>
		///       判断是否存在指定关键字的数值
		///       </summary>
		/// <param name="key">
		/// </param>
		/// <returns>
		/// </returns>
		public bool Contains(string string_0)
		{
			return GetItem(string_0) == null;
		}

		/// <summary>
		///       设置状态值
		///       </summary>
		/// <param name="key">关键字值</param>
		/// <returns>获得的数据</returns>
		public object GetValue(string string_0)
		{
			return GetItem(string_0)?.Value;
		}

		/// <summary>
		///       设置数值
		///       </summary>
		/// <param name="Name">名称</param>
		/// <param name="Value">值</param>
		public void SetValue(string Name, object Value)
		{
			XMLViewStateBagItem xMLViewStateBagItem = GetItem(Name);
			if (Value == null)
			{
				if (xMLViewStateBagItem != null)
				{
					Remove(xMLViewStateBagItem);
				}
				return;
			}
			if (xMLViewStateBagItem == null)
			{
				xMLViewStateBagItem = new XMLViewStateBagItem();
				Add(xMLViewStateBagItem);
				xMLViewStateBagItem.Name = Name;
			}
			xMLViewStateBagItem.Value = Value;
			xMLViewStateBagItem.TypeName = ControlHelper.GetControlFullTypeName(Value.GetType());
		}

		/// <summary>
		///       获得指定名称的列表项目对象
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <returns>
		/// </returns>
		private XMLViewStateBagItem GetItem(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XMLViewStateBagItem current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			try
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XMLViewStateBagItem current = enumerator.Current;
						if (current.Value != null && current.Value is IDisposable)
						{
							((IDisposable)current.Value).Dispose();
						}
					}
				}
			}
			finally
			{
				Clear();
			}
		}
	}
}
