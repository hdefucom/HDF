using DCSoft.Common;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       获得拖拽数据事件使用的参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DocumentComment]
	public class DCToolBoxGetItemDragDataEventArgs : EventArgs
	{
		private DCToolBoxItem _ToolItem = null;

		private DCToolBoxTab _ToolTab = null;

		private DataObject _DataObject = null;

		private bool _Cancel = false;

		/// <summary>
		///       工具箱项目
		///       </summary>
		public DCToolBoxItem ToolItem => _ToolItem;

		/// <summary>
		///       工具箱分页标签对象
		///       </summary>
		public DCToolBoxTab ToolTab => _ToolTab;

		/// <summary>
		///       数据对象
		///       </summary>
		public DataObject DataObject
		{
			get
			{
				return _DataObject;
			}
			set
			{
				_DataObject = value;
			}
		}

		/// <summary>
		///       用户取消操作
		///       </summary>
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="tab">分页对象</param>
		/// <param name="item">工具箱项目对象</param>
		public DCToolBoxGetItemDragDataEventArgs(DCToolBoxTab dctoolBoxTab_0, DCToolBoxItem item)
		{
			_ToolTab = dctoolBoxTab_0;
			_ToolItem = item;
		}
	}
}
