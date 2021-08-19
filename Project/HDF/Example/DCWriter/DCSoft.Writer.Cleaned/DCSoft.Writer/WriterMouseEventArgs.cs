using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器鼠标事件参数
	///       </summary>
	[ComDefaultInterface(typeof(IWriterMouseEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("0359C21A-D8EF-45F4-897C-CDF89E0B965D", "6D63CD6E-F5BB-498C-9DD0-092238DDC8B1")]
	[DCPublishAPI]
	[Guid("0359C21A-D8EF-45F4-897C-CDF89E0B965D")]
	[DocumentComment]
	[ComVisible(true)]
	public class WriterMouseEventArgs : EventArgs, IWriterMouseEventArgs
	{
		internal const string CLASSID = "0359C21A-D8EF-45F4-897C-CDF89E0B965D";

		internal const string CLASSID_Interface = "6D63CD6E-F5BB-498C-9DD0-092238DDC8B1";

		private bool _Handled = false;

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private int _ScreenX = 0;

		private int _ScreenY = 0;

		private XTextElement _HoverElement = null;

		private MouseButtons _Button = MouseButtons.None;

		private int _Delta = 0;

		private int _Clicks = 0;

		private int _X = 0;

		private int _Y = 0;

		/// <summary>
		///       事件已经被处理了。
		///       </summary>
		[DCPublishAPI]
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
		///       编辑器控件对象
		///       </summary>
		[DCPublishAPI]
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument Document => _Document;

		/// <summary>
		///       鼠标光标在屏幕中的X坐标
		///       </summary>
		[DCPublishAPI]
		public int ScreenX => _ScreenX;

		/// <summary>
		///       鼠标光标在屏幕中的X坐标
		///       </summary>
		public int ScreenY => _ScreenY;

		/// <summary>
		///       鼠标悬停下的文档元素对象
		///       </summary>
		[DCPublishAPI]
		public XTextElement HoverElement => _HoverElement;

		/// <summary>
		///       鼠标按钮
		///       </summary>
		[ComVisible(false)]
		[DCPublishAPI]
		public MouseButtons Button => _Button;

		/// <summary>
		///       判断是否是有鼠标左键
		///       </summary>
		[DCPublishAPI]
		public bool HasLeftButton => (_Button & MouseButtons.Left) == MouseButtons.Left;

		/// <summary>
		///       判断是否是有鼠标右键
		///       </summary>
		[DCPublishAPI]
		public bool HasRightButton => (_Button & MouseButtons.Right) == MouseButtons.Right;

		/// <summary>
		///       按钮值
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DCPublishAPI]
		public int ButtonValue => (int)_Button;

		/// <summary>
		///       滚轮值
		///       </summary>
		[DCPublishAPI]
		public int Delta => _Delta;

		/// <summary>
		///       鼠标点击次数
		///       </summary>
		[DCPublishAPI]
		public int Clicks => _Clicks;

		/// <summary>
		///       鼠标光标X坐标值
		///       </summary>
		[DCPublishAPI]
		public int X => _X;

		/// <summary>
		///       鼠标光标Y坐标值
		///       </summary>
		[DCPublishAPI]
		public int Y => _Y;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="args">
		/// </param>
		[DCInternal]
		public WriterMouseEventArgs(WriterControl writerControl_0, MouseEventArgs args)
		{
			_WriterControl = writerControl_0;
			_Document = writerControl_0.Document;
			_X = args.X;
			_Y = args.Y;
			_Clicks = args.Clicks;
			_Button = args.Button;
			_Delta = args.Delta;
			_HoverElement = writerControl_0.HoverElement;
			if (writerControl_0 != null)
			{
				Point p = new Point(args.X, args.Y);
				p = writerControl_0.InnerViewControl.PointToScreen(p);
				_ScreenX = p.X;
				_ScreenY = p.Y;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="args">
		/// </param>
		public WriterMouseEventArgs(WriterControl writerControl_0, int int_0, int int_1, int clicks, MouseButtons button, int delta)
		{
			_WriterControl = writerControl_0;
			_Document = writerControl_0.Document;
			_X = int_0;
			_Y = int_1;
			_Clicks = clicks;
			_Button = button;
			_Delta = delta;
			_HoverElement = writerControl_0.HoverElement;
			if (writerControl_0 != null)
			{
				Point p = new Point(int_0, int_1);
				p = writerControl_0.InnerViewControl.PointToScreen(p);
				_ScreenX = p.X;
				_ScreenY = p.Y;
			}
		}
	}
}
