using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       鼠标事件参数
	///       </summary>
	[ComVisible(false)]
	public class ShapeMouseEventArgs
	{
		private int _ClientX = 0;

		private int _ClientY = 0;

		private float _X = 0f;

		private float _Y = 0f;

		private MouseButtons _Button = MouseButtons.None;

		private int _Clicks = 0;

		private int _Delta = 0;

		private bool _Handled = false;

		/// <summary>
		///       鼠标光标在控件客户区中的X坐标
		///       </summary>
		public int ClientX
		{
			get
			{
				return _ClientX;
			}
			set
			{
				_ClientX = value;
			}
		}

		/// <summary>
		///       鼠标光标在控件客户区中的Y坐标
		///       </summary>
		public int ClientY
		{
			get
			{
				return _ClientY;
			}
			set
			{
				_ClientY = value;
			}
		}

		/// <summary>
		///       鼠标光标在视图中的X坐标
		///       </summary>
		public float X
		{
			get
			{
				return _X;
			}
			set
			{
				_X = value;
			}
		}

		/// <summary>
		///       鼠标光标在视图中的Y坐标
		///       </summary>
		public float Y
		{
			get
			{
				return _Y;
			}
			set
			{
				_Y = value;
			}
		}

		/// <summary>
		///       鼠标按键状态
		///       </summary>
		public MouseButtons Button
		{
			get
			{
				return _Button;
			}
			set
			{
				_Button = value;
			}
		}

		/// <summary>
		///       鼠标点击次数
		///       </summary>
		public int Clicks
		{
			get
			{
				return _Clicks;
			}
			set
			{
				_Clicks = value;
			}
		}

		/// <summary>
		///       鼠标滚轮计数
		///       </summary>
		public int Delta
		{
			get
			{
				return _Delta;
			}
			set
			{
				_Delta = value;
			}
		}

		/// <summary>
		///       事件已经被处理了，无需后续处理
		///       </summary>
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ShapeMouseEventArgs()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="x">鼠标光标X坐标</param>
		/// <param name="y">鼠标光标Y坐标</param>
		/// <param name="button">鼠标按键状态</param>
		/// <param name="clicks">鼠标点击次数</param>
		/// <param name="delta">鼠标滚轮计数</param>
		public ShapeMouseEventArgs(float float_0, float float_1, MouseButtons button, int clicks, int delta)
		{
			_X = float_0;
			_Y = float_1;
			_Button = button;
			_Clicks = clicks;
			_Delta = delta;
		}
	}
}
