using DCSoft.Common;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///       窗体状态栏信息对象
	///       </summary>
	
	[ComVisible(false)]
	public class WindowStatusInfo
	{
		private Image _Icon = null;

		private string _Text = null;

		private EventHandler _ClickHandler = null;

		private EventHandler _DoubleClickHandler = null;

		/// <summary>
		///       图标
		///       </summary>
		public Image Icon
		{
			get
			{
				return _Icon;
			}
			set
			{
				_Icon = value;
			}
		}

		/// <summary>
		///       文本内容
		///       </summary>
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       单击处理过程
		///       </summary>
		public EventHandler ClickHandler
		{
			get
			{
				return _ClickHandler;
			}
			set
			{
				_ClickHandler = value;
			}
		}

		/// <summary>
		///       双击处理过程
		///       </summary>
		public EventHandler DoubleClickHandler
		{
			get
			{
				return _DoubleClickHandler;
			}
			set
			{
				_DoubleClickHandler = value;
			}
		}
	}
}
