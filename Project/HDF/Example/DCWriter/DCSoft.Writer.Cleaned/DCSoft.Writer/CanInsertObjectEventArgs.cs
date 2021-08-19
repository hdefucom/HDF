using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       判断能否插入对象事件参数
	///       </summary>
	[ComDefaultInterface(typeof(ICanInsertObjectEventArgs))]
	[DocumentComment]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-23456789005B")]
	[DCPublishAPI]
	[ComClass("00012345-6789-ABCD-EF01-23456789005B", "D3361D0B-CBF6-41B8-8708-3719B96E9DF5")]
	[ClassInterface(ClassInterfaceType.None)]
	public class CanInsertObjectEventArgs : EventArgs, ICanInsertObjectEventArgs
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789005B";

		internal const string CLASSID_Interface = "D3361D0B-CBF6-41B8-8708-3719B96E9DF5";

		private XTextDocument _Document = null;

		private DocumentControler _DocumentControler = null;

		private WriterDataFormats _AllowDataFormats = WriterDataFormats.All;

		private XTextContainerElement _ContainerElement = null;

		private int _PositionInContainer = -1;

		private IServiceProvider _Services = null;

		private int _SpecifyPosition = -1;

		private IDataObject _DataObject = null;

		private string _SpecifyFormat = null;

		private DomAccessFlags _AccessFlags = DomAccessFlags.Normal;

		private bool _Handled = false;

		private bool _Result = false;

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
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
		[DCPublishAPI]
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
		///       允许接收的数据格式
		///       </summary>
		[DCPublishAPI]
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
		///       插入的位置
		///       </summary>
		[DCPublishAPI]
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
		///       服务对象容器
		///       </summary>
		[ComVisible(false)]
		[DCPublishAPI]
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
		///       文档中指定的位置序号
		///       </summary>
		[DCPublishAPI]
		public int SpecifyPosition
		{
			get
			{
				return _SpecifyPosition;
			}
			set
			{
				_SpecifyPosition = value;
			}
		}

		/// <summary>
		///       要插入的数据对象
		///       </summary>
		[ComVisible(false)]
		[DCPublishAPI]
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
		///       用户指定的数据格式
		///       </summary>
		[DCPublishAPI]
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
		///       访问标记
		///       </summary>
		[DCPublishAPI]
		public DomAccessFlags AccessFlags
		{
			get
			{
				return _AccessFlags;
			}
			set
			{
				_AccessFlags = value;
			}
		}

		/// <summary>
		///       事件已经被处理了，无需后续处理
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
		///       判断结果,true为可以插入对象数据；false不可插入对象数据。
		///       </summary>
		[DCPublishAPI]
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
		///       初始化对象
		///       </summary>
		/// <param name="document">
		/// </param>
		public CanInsertObjectEventArgs(XTextDocument document)
		{
			_Document = document;
			if (_Document != null)
			{
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
		///       获得所有可用的数据格式名称
		///       </summary>
		/// <returns>数据格式名称数组</returns>
		[DCPublishAPI]
		public string[] GetFormats()
		{
			if (DataObject == null)
			{
				return null;
			}
			return DataObject.GetFormats();
		}

		/// <summary>
		///       获得指定格式的数据
		///       </summary>
		/// <param name="format">数据格式</param>
		/// <returns>获得的数据</returns>
		[DCPublishAPI]
		public object GetData(string format)
		{
			if (DataObject == null)
			{
				return null;
			}
			return DataObject.GetData(format);
		}

		/// <summary>
		///       判断是否包含指定格式的数据
		///       </summary>
		/// <param name="format">数据格式</param>
		/// <returns>是否存在</returns>
		[DCPublishAPI]
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
