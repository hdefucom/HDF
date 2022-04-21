using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片视图列表控件事件参数
	///       </summary>
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDCCardListViewEventArgs))]
	[Guid("D4B88894-CCD7-49A0-814E-FCB7DD5D8DD4")]
	[ClassInterface(ClassInterfaceType.None)]
	
	public class DCCardListViewEventArgs : EventArgs, IDCCardListViewEventArgs
	{
		private DCCardListViewItem _Item = null;

		/// <summary>
		///       列表项目
		///       </summary>
		public DCCardListViewItem Item => _Item;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="item">列表项目</param>
		public DCCardListViewEventArgs(DCCardListViewItem item)
		{
			_Item = item;
		}
	}
}
