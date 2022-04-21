using DCSoft.Common;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       OLE拖拽事件参数类型
	///       </summary>
	
	[ComVisible(false)]
	public class DCCardListViewDragEventArgs : EventArgs
	{
		private DragEventArgs _SourceArgs = null;

		private int _ClientX = 0;

		private int _ClientY = 0;

		private DCCardListViewControl _ListView = null;

		private DCCardListViewItem _Item = null;

		private IDataObject _DataObject = null;

		public IDataObject Data => _SourceArgs.Data;

		public DragDropEffects AllowedEffect => _SourceArgs.AllowedEffect;

		public DragDropEffects Effect
		{
			get
			{
				return _SourceArgs.Effect;
			}
			set
			{
				_SourceArgs.Effect = value;
			}
		}

		public int KeyState => _SourceArgs.KeyState;

		public int X => _SourceArgs.X;

		public int Y => _SourceArgs.Y;

		public int ClientX => _ClientX;

		public int ClientY => _ClientY;

		public DCCardListViewControl ListView => _ListView;

		public DCCardListViewItem Item => _Item;

		public IDataObject DataObject
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
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件</param>
		/// <param name="args">原始事件参数</param>
		/// <param name="item">列表项目</param>
		public DCCardListViewDragEventArgs(DCCardListViewControl dccardListViewControl_0, DragEventArgs args, DCCardListViewItem item)
		{
			_ListView = dccardListViewControl_0;
			_SourceArgs = args;
			Point point = dccardListViewControl_0.PointToClient(new Point(args.X, args.Y));
			_ClientX = point.X;
			_ClientY = point.Y;
			_Item = item;
		}
	}
}
