using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片列表项目的集合
	///       </summary>
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("95AF2711-7AB2-489A-9C8B-FD3509C043DF")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDCCardListViewItemCollection))]
	public class DCCardListViewItemCollection : List<DCCardListViewItem>, IDCCardListViewItemCollection
	{
		internal DCCardListViewControl _ListView = null;

		/// <summary>
		///       安全的获得列表项目
		///       </summary>
		/// <param name="index">序号</param>
		/// <returns>项目对象</returns>
		public DCCardListViewItem SafeGetItem(int index)
		{
			if (index >= 0 && index < base.Count)
			{
				return base[index];
			}
			return null;
		}

		/// <summary>
		///       添加新的空白项目
		///       </summary>
		/// <returns>新的项目对象</returns>
		public DCCardListViewItem AddNewItem()
		{
			DCCardListViewItem dCCardListViewItem = new DCCardListViewItem();
			dCCardListViewItem._ListView = _ListView;
			Add(dCCardListViewItem);
			return dCCardListViewItem;
		}

		/// <summary>
		///       获得指定名称的卡片对象
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的对象</returns>
		public DCCardListViewItem GetItemByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCCardListViewItem current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       根据绑定的数据源对象查找列表项目
		///       </summary>
		/// <param name="dataBoundItem">数据源绑定的对象</param>
		/// <returns>找到的列表项目，若未找到则返回空引用</returns>
		public DCCardListViewItem GetItemByDataBoundItem(object dataBoundItem)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCCardListViewItem current = enumerator.Current;
					if (current.DataBoundItem == dataBoundItem)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
