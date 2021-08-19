using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       数据过滤器事件参数
	///       </summary>
	[Guid("BF643322-78BA-46FD-96AC-0FFB69E9CC71")]
	[ComVisible(true)]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IFilterValueEventArgs))]
	[ComClass("BF643322-78BA-46FD-96AC-0FFB69E9CC71", "3031DB88-078B-46EB-A94A-5691D9F70A25")]
	public class FilterValueEventArgs : EventArgs, IFilterValueEventArgs
	{
		internal const string CLASSID = "BF643322-78BA-46FD-96AC-0FFB69E9CC71";

		internal const string CLASSID_Interface = "3031DB88-078B-46EB-A94A-5691D9F70A25";

		private InputValueSource _Source = InputValueSource.Clipboard;

		private string _SourceName = null;

		private InputValueType _Type = InputValueType.Dom;

		private object _Value = null;

		private bool _Cancel = false;

		/// <summary>
		///       数据来源
		///       </summary>
		[DCPublishAPI]
		public InputValueSource Source
		{
			get
			{
				return _Source;
			}
			set
			{
				_Source = value;
			}
		}

		/// <summary>
		///       数据来源名称
		///       </summary>
		[DCPublishAPI]
		public string SourceName
		{
			get
			{
				return _SourceName;
			}
			set
			{
				_SourceName = value;
			}
		}

		/// <summary>
		///       数据类型
		///       </summary>
		[DCPublishAPI]
		public InputValueType Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}

		/// <summary>
		///       数据内容
		///       </summary>
		[DCPublishAPI]
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       取消相关的数据操作
		///       </summary>
		[DCPublishAPI]
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
		/// <param name="source">数据来源</param>
		/// <param name="type">数据类型</param>
		/// <param name="Value">要处理的数据</param>
		[DCInternal]
		public FilterValueEventArgs(InputValueSource source, InputValueType type, object Value)
		{
			_Source = source;
			_Type = type;
			_Value = Value;
		}
	}
}
