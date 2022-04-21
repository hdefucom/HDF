using DCSoft.Common;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片视图列表控件事件参数
	///       </summary>
	
	[ComVisible(true)]
	[Guid("64B26D75-131F-4B05-A130-2C7D390388DC")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDCCardListViewMouseEventArgs))]
	public class DCCardListViewMouseEventArgs : EventArgs, IDCCardListViewMouseEventArgs
	{
		private DCCardListViewItem _Item = null;

		private int _Click = 0;

		private MouseButtons _Button = MouseButtons.None;

		private int _X = 0;

		private int _Y = 0;

		/// <summary>
		///       列表项目
		///       </summary>
		public DCCardListViewItem Item => _Item;

		/// <summary>
		///       鼠标点击次数
		///       </summary>
		public int Click => _Click;

		/// <summary>
		///       鼠标按键状态
		///       </summary>
		public MouseButtons Button => _Button;

		/// <summary>
		///       是否按下左键
		///       </summary>
		public bool LeftButton => (_Button & MouseButtons.Left) == MouseButtons.Left;

		/// <summary>
		///       是否按下右键
		///       </summary>
		public bool RightButton => (_Button & MouseButtons.Right) == MouseButtons.Right;

		/// <summary>
		///       鼠标X坐标
		///       </summary>
		public int X => _X;

		/// <summary>
		///       鼠标Y坐标
		///       </summary>
		public int Y => _Y;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="item">列表项目</param>
		public DCCardListViewMouseEventArgs(DCCardListViewItem item, MouseEventArgs args)
		{
			_Item = item;
			_X = args.X;
			_Y = args.Y;
			_Button = args.Button;
			_Click = args.Clicks;
		}
	}
}
