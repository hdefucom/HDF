using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       向文档插入对象事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-23456789006E", "C8B8395D-3AF2-4502-A9A9-79A7D8FE48F2")]
	[DocumentComment]
	
	[Guid("00012345-6789-ABCD-EF01-23456789006E")]
	[ComDefaultInterface(typeof(IInsertObjectEventArgs))]
	[ComVisible(true)]
	public class InsertObjectEventArgs : EventArgs, IInsertObjectEventArgs
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789006E";

		internal const string CLASSID_Interface = "C8B8395D-3AF2-4502-A9A9-79A7D8FE48F2";

		private bool _CheckMaxTextLengthForCopyPaste = false;

		private XTextElement _CurrentElement = null;

		private bool _DetectForDragContent = false;

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private DocumentControler _DocumentControler = null;

		private WriterDataFormats _AllowDataFormats = WriterDataFormats.All;

		private IServiceProvider _Services = null;

		private XTextContainerElement _ContainerElement = null;

		private int _PositionInContainer = -1;

		private DragDropEffects _AllowedEffect = DragDropEffects.None;

		private DragDropEffects _DragEffect = DragDropEffects.None;

		private IDataObject _DataObject = null;

		private string _SpecifyFormat = null;

		private bool _ShowUI = true;

		private bool _Handled = false;

		private InputValueSource _InputSource = InputValueSource.Clipboard;

		private bool _AutoSelectContent = false;

		private XTextElementList _NewElements = null;

		private bool _Result = true;

		private List<string> _RejectFormats = new List<string>();

		/// <summary>
		///       是否检测MaxTextLengthForCopyPaste设置.
		///       </summary>
		
		public bool CheckMaxTextLengthForCopyPaste
		{
			get
			{
				return _CheckMaxTextLengthForCopyPaste;
			}
			set
			{
				_CheckMaxTextLengthForCopyPaste = value;
			}
		}

		/// <summary>
		///       指定插入位置的文档元素对象
		///       </summary>
		
		public XTextElement CurrentElement
		{
			get
			{
				return _CurrentElement;
			}
			set
			{
				_CurrentElement = value;
			}
		}

		/// <summary>
		///       为拖拽文档内容而进行检测
		///       </summary>
		internal bool DetectForDragContent
		{
			get
			{
				return _DetectForDragContent;
			}
			set
			{
				_DetectForDragContent = value;
			}
		}

		/// <summary>
		///       编辑器控件
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
		///       文档对象
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
		///       文档控制器对象
		///       </summary>
		
		public DocumentControler DocumentControler
		{
			get
			{
				return _DocumentControler;
			}
			set
			{
				_DocumentControler = value;
			}
		}

		/// <summary>
		///       允许的数据格式
		///       </summary>
		
		public WriterDataFormats AllowDataFormats
		{
			get
			{
				return _AllowDataFormats;
			}
			set
			{
				_AllowDataFormats = value;
			}
		}

		/// <summary>
		///       服务对象容器
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
		///       容器元素对象
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
		///       插入点位置
		///       </summary>
		
		public int Position
		{
			get
			{
				return _PositionInContainer;
			}
			set
			{
				_PositionInContainer = value;
			}
		}

		/// <summary>
		///       允许的拖拽样式
		///       </summary>
		
		public DragDropEffects AllowedEffect
		{
			get
			{
				return _AllowedEffect;
			}
			set
			{
				_AllowedEffect = value;
			}
		}

		/// <summary>
		///       拖拽样式
		///       </summary>
		
		public DragDropEffects DragEffect
		{
			get
			{
				return _DragEffect;
			}
			set
			{
				_DragEffect = value;
			}
		}

		/// <summary>
		///       要插入的对象
		///       </summary>
		[ComVisible(false)]
		
		public IDataObject DataObject
		{
			get
			{
				return _DataObject;
			}
			set
			{
				_DataObject = value;
			}
		}

		/// <summary>
		///       指定的数据格式
		///       </summary>
		
		public string SpecifyFormat
		{
			get
			{
				return _SpecifyFormat;
			}
			set
			{
				_SpecifyFormat = value;
			}
		}

		/// <summary>
		///       是否显示用户界面
		///       </summary>
		
		public bool ShowUI
		{
			get
			{
				return _ShowUI;
			}
			set
			{
				_ShowUI = value;
			}
		}

		/// <summary>
		///       事件已经处理过了标记
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
		///       数据操作来源
		///       </summary>
		
		public InputValueSource InputSource
		{
			get
			{
				return _InputSource;
			}
			set
			{
				_InputSource = value;
			}
		}

		/// <summary>
		///       自动选择插入的内容
		///       </summary>
		
		public bool AutoSelectContent
		{
			get
			{
				return _AutoSelectContent;
			}
			set
			{
				_AutoSelectContent = value;
			}
		}

		/// <summary>
		///       新增的文档元素列表
		///       </summary>
		
		public XTextElementList NewElements
		{
			get
			{
				return _NewElements;
			}
			set
			{
				_NewElements = value;
			}
		}

		/// <summary>
		///       操作是否成功
		///       </summary>
		
		public bool Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       拒绝的数据格式名称
		///       </summary>
		
		public List<string> RejectFormats
		{
			get
			{
				return _RejectFormats;
			}
			set
			{
				_RejectFormats = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">
		/// </param>
		public InsertObjectEventArgs(XTextDocument document)
		{
			_Document = document;
			if (_Document != null)
			{
				_WriterControl = document.EditorControl;
				_DocumentControler = document.DocumentControler;
				_Services = document.AppHost.Services;
				_Document.Content.GetCurrentPositionInfo(out _ContainerElement, out _PositionInContainer);
				if (_Document.EditorControl != null)
				{
					_AllowDataFormats = _Document.EditorControl.AcceptDataFormats;
				}
			}
		}

		/// <summary>
		///       获得数据格式列表
		///       </summary>
		/// <returns>
		/// </returns>
		
		public string[] GetFormats()
		{
			if (DataObject == null)
			{
				return null;
			}
			return DataObject.GetFormats();
		}

		/// <summary>
		///       获得数据
		///       </summary>
		/// <param name="format">数据格式名称</param>
		/// <returns>数据</returns>
		
		public object GetData(string format)
		{
			if (DataObject == null)
			{
				return null;
			}
			return DataObject.GetData(format);
		}

		/// <summary>
		///       获得是否存在指定格式的数据
		///       </summary>
		/// <param name="format">数据格式名称</param>
		/// <returns>是否存在</returns>
		
		public bool GetDataPresent(string format)
		{
			if (DataObject == null)
			{
				return false;
			}
			return DataObject.GetDataPresent(format);
		}
	}
}
