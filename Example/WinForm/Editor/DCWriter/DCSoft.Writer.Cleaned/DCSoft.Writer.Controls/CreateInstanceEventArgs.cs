using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       创建对象实例事件参数
	///       </summary>
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("3CFD2E1C-72C2-4330-8D1F-56D8E72554F0", "2DE060E8-A2EB-4879-9383-7387E7952DD7")]
	
	[ComDefaultInterface(typeof(ICreateInstanceEventArgs))]
	[ComVisible(true)]
	[Guid("3CFD2E1C-72C2-4330-8D1F-56D8E72554F0")]
	public class CreateInstanceEventArgs : EventArgs, ICreateInstanceEventArgs
	{
		internal const string CLASSID = "3CFD2E1C-72C2-4330-8D1F-56D8E72554F0";

		internal const string CLASSID_Interface = "2DE060E8-A2EB-4879-9383-7387E7952DD7";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private Type _InstanceType = null;

		private string _CommandName = null;

		private object _CreatedInstance = null;

		private bool _Cancel = false;

		/// <summary>
		///       编辑器控件
		///       </summary>
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       实例对象类型
		///       </summary>
		
		public Type InstanceType => _InstanceType;

		/// <summary>
		///       对象类型全名
		///       </summary>
		
		public string InstanceTypeFullName
		{
			get
			{
				if (_InstanceType == null)
				{
					return null;
				}
				return _InstanceType.FullName;
			}
		}

		/// <summary>
		///       相关的命令名称
		///       </summary>
		
		public string CommandName => _CommandName;

		/// <summary>
		///       创建的对象实例
		///       </summary>
		
		public object CreatedInstance
		{
			get
			{
				return _CreatedInstance;
			}
			set
			{
				_CreatedInstance = value;
			}
		}

		/// <summary>
		///       是否取消操作
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
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="instanceType">实例类型</param>
		/// <param name="commandName">命令名称</param>
		
		public CreateInstanceEventArgs(WriterControl writerControl_0, XTextDocument document, Type instanceType, string commandName)
		{
			_WriterControl = writerControl_0;
			_Document = document;
			_InstanceType = instanceType;
			_CommandName = commandName;
		}
	}
}
