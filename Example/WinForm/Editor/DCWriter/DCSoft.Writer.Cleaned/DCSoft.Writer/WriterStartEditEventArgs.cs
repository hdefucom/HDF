using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       控件开始编辑文档事件参数
	///       </summary>
	[ComClass("07142DDF-C237-4185-8F34-CF965211B1C5", "2800DB6D-3FA6-4397-9723-35B24B6994BA")]
	
	[Guid("07142DDF-C237-4185-8F34-CF965211B1C5")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterStartEditEventArgs))]
	
	[ClassInterface(ClassInterfaceType.None)]
	public class WriterStartEditEventArgs : WriterEventArgs, IWriterStartEditEventArgs
	{
		internal new const string CLASSID = "07142DDF-C237-4185-8F34-CF965211B1C5";

		internal new const string CLASSID_Interface = "2800DB6D-3FA6-4397-9723-35B24B6994BA";

		private string _DocumentID = null;

		private XTextContainerElement _ContainerElement = null;

		private bool _Readonly = false;

		private bool _CanDetectAgain = true;

		private bool _ReloadDocument = false;

		/// <summary>
		///       文档编号
		///       </summary>
		
		[XmlElement]
		[DefaultValue(null)]
		public string DocumentID
		{
			get
			{
				return _DocumentID;
			}
			set
			{
				_DocumentID = value;
			}
		}

		/// <summary>
		///       触发事件的容器元素对象
		///       </summary>
		public XTextContainerElement ContainerElement
		{
			get
			{
				return _ContainerElement;
			}
			set
			{
				_ContainerElement = value;
			}
		}

		/// <summary>
		///       文档内容只读
		///       </summary>
		[XmlElement]
		
		[DefaultValue(false)]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		/// <summary>
		///       以后能否还能继续检测
		///       </summary>
		[DefaultValue(true)]
		[XmlElement]
		
		public bool CanDetectAgain
		{
			get
			{
				return _CanDetectAgain;
			}
			set
			{
				_CanDetectAgain = value;
			}
		}

		/// <summary>
		///       重新加载了文档
		///       </summary>
		
		public bool ReloadDocument
		{
			get
			{
				return _ReloadDocument;
			}
			set
			{
				_ReloadDocument = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="doc">文档对象</param>
		
		public WriterStartEditEventArgs(WriterControl writerControl_0, XTextDocument xtextDocument_0)
			: base(writerControl_0, xtextDocument_0, null)
		{
			if (xtextDocument_0 != null)
			{
				DocumentID = xtextDocument_0.ID;
			}
		}
	}
}
