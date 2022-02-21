using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器名称错误事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("8B447673-50B9-4B09-ADAC-DBECB64F90B0", "929F98CD-60F4-4940-85C7-C07B84A22B08")]
	[DocumentComment]
	
	[ComVisible(true)]
	[ComDefaultInterface(typeof(ICommandErrorEventArgs))]
	[Guid("8B447673-50B9-4B09-ADAC-DBECB64F90B0")]
	public class CommandErrorEventArgs : EventArgs, ICommandErrorEventArgs
	{
		internal const string CLASSID = "8B447673-50B9-4B09-ADAC-DBECB64F90B0";

		internal const string CLASSID_Interface = "929F98CD-60F4-4940-85C7-C07B84A22B08";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private string _CommandName = null;

		private object _CommmandParameter = null;

		private Exception _Exception = null;

		private string _Message = null;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		
		public WriterControl WriterControl
		{
			get
			{
				return _WriterControl;
			}
			set
			{
				_WriterControl = value;
			}
		}

		/// <summary>
		///       正在处理的文档对象
		///       </summary>
		
		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		/// <summary>
		///       命令名称
		///       </summary>
		
		public string CommandName
		{
			get
			{
				return _CommandName;
			}
			set
			{
				_CommandName = value;
			}
		}

		/// <summary>
		///       命令参数
		///       </summary>
		
		public object CommmandParameter
		{
			get
			{
				return _CommmandParameter;
			}
			set
			{
				_CommmandParameter = value;
			}
		}

		/// <summary>
		///       异常对象
		///       </summary>
		
		[ComVisible(false)]
		public Exception Exception
		{
			get
			{
				return _Exception;
			}
			set
			{
				_Exception = value;
			}
		}

		/// <summary>
		///       错误提示信息
		///       </summary>
		
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public CommandErrorEventArgs()
		{
		}
	}
}
