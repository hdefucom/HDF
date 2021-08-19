using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       获得zhishik
	///       </summary>
	[Guid("823001B1-4DFA-437F-B8E3-4A20E29CA0A6")]
	[ComDefaultInterface(typeof(IListItemsEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("823001B1-4DFA-437F-B8E3-4A20E29CA0A6", "F9A4A830-6319-4333-A52E-A370ADA50848")]
	[ComVisible(true)]
	public class ListItemsEventArgs : EventArgs, IListItemsEventArgs
	{
		internal const string CLASSID = "823001B1-4DFA-437F-B8E3-4A20E29CA0A6";

		internal const string CLASSID_Interface = "F9A4A830-6319-4333-A52E-A370ADA50848";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private ListSourceInfo _Info = null;

		private WriterAppHost _Host = null;

		private IServiceProvider _Services = null;

		private string _SourceName = null;

		private KBEntry _KBEntry = null;

		private bool _IsDynamicListItems = false;

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档元素对象
		///       </summary>
		public XTextElement Element => _Element;

		/// <summary>
		///       相关的输入域文档元素对象
		///       </summary>
		public XTextInputFieldElement FieldElement => _Element as XTextInputFieldElement;

		/// <summary>
		///       相关的列表来源信息
		///       </summary>
		public ListSourceInfo Info
		{
			get
			{
				return _Info;
			}
			set
			{
				_Info = value;
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		public WriterAppHost Host
		{
			get
			{
				return _Host;
			}
			set
			{
				_Host = value;
			}
		}

		/// <summary>
		///       服务容器对象
		///       </summary>
		[ComVisible(false)]
		public IServiceProvider Services
		{
			get
			{
				return _Services;
			}
			set
			{
				_Services = value;
			}
		}

		/// <summary>
		///       列表来源
		///       </summary>
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
		///       知识库节点对象
		///       </summary>
		public KBEntry KBEntry
		{
			get
			{
				return _KBEntry;
			}
			set
			{
				_KBEntry = value;
			}
		}

		/// <summary>
		///       是否为动态加载列表项目
		///       </summary>
		public bool IsDynamicListItems
		{
			get
			{
				return _IsDynamicListItems;
			}
			set
			{
				_IsDynamicListItems = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="host">
		/// </param>
		/// <param name="sourceName">
		/// </param>
		public ListItemsEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, WriterAppHost host, string sourceName)
		{
			_WriterControl = writerControl_0;
			_Document = document;
			_Element = element;
			_Host = host;
			_SourceName = sourceName;
			if (_Host != null)
			{
				_Services = _Host.Services;
			}
		}
	}
}
