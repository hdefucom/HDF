using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       选择区域正在发生改变事件参数类型
	///       </summary>
	/// <remarks> 编制 袁永福</remarks>
	[DocumentComment]
	[ComClass("C0CC596D-25F3-40D7-B808-66A8388F5AF6", "6BA3090C-6F53-46E5-AC8D-25932D32893C")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("C0CC596D-25F3-40D7-B808-66A8388F5AF6")]
	[ComDefaultInterface(typeof(ISelectionChangingEventArgs))]
	
	[ComVisible(true)]
	public class SelectionChangingEventArgs : EventArgs, ISelectionChangingEventArgs
	{
		internal const string CLASSID = "C0CC596D-25F3-40D7-B808-66A8388F5AF6";

		internal const string CLASSID_Interface = "6BA3090C-6F53-46E5-AC8D-25932D32893C";

		private XTextDocument _Documnent = null;

		private bool _OldLineEndFlag = false;

		private int _OldSelectionIndex = 0;

		private int _OldSelectionLength = 0;

		private bool _NewLineEndFlag = false;

		private int _NewSelectionIndex = 0;

		private int _NewSelectionLength = 0;

		private bool _Cancel = false;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Documnent
		{
			get
			{
				return _Documnent;
			}
			set
			{
				_Documnent = value;
			}
		}

		/// <summary>
		///       旧的行尾标记
		///       </summary>
		
		public bool OldLineEndFlag
		{
			get
			{
				return _OldLineEndFlag;
			}
			set
			{
				_OldLineEndFlag = value;
			}
		}

		/// <summary>
		///       旧的选择区域开始位置
		///       </summary>
		
		public int OldSelectionIndex
		{
			get
			{
				return _OldSelectionIndex;
			}
			set
			{
				_OldSelectionIndex = value;
			}
		}

		/// <summary>
		///       旧的选择区域长度
		///       </summary>
		
		public int OldSelectionLength
		{
			get
			{
				return _OldSelectionLength;
			}
			set
			{
				_OldSelectionLength = value;
			}
		}

		/// <summary>
		///       新的行尾标记
		///       </summary>
		
		public bool NewLineEndFlag
		{
			get
			{
				return _NewLineEndFlag;
			}
			set
			{
				_NewLineEndFlag = value;
			}
		}

		/// <summary>
		///       新的选择区域开始位置
		///       </summary>
		
		public int NewSelectionIndex
		{
			get
			{
				return _NewSelectionIndex;
			}
			set
			{
				_NewSelectionIndex = value;
			}
		}

		/// <summary>
		///       新的选择区域长度
		///       </summary>
		
		public int NewSelectionLength
		{
			get
			{
				return _NewSelectionLength;
			}
			set
			{
				_NewSelectionLength = value;
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
		
		public SelectionChangingEventArgs()
		{
		}
	}
}
