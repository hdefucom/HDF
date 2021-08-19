using DCSoft.Common;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数据源绑定信息
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("9D9BA649-62D3-41AC-9A34-CAFC92267FF0")]
	[DocumentComment]
	[ComDefaultInterface(typeof(IDataSourceBindingDescription))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComClass("9D9BA649-62D3-41AC-9A34-CAFC92267FF0", "1C702A9E-7C16-40DF-AC7A-E57A1002714D")]
	[ComVisible(true)]
	[DCPublishAPI]
	public class DataSourceBindingDescription : IDataSourceBindingDescription
	{
		internal const string CLASSID = "9D9BA649-62D3-41AC-9A34-CAFC92267FF0";

		internal const string CLASSID_Interface = "1C702A9E-7C16-40DF-AC7A-E57A1002714D";

		private string _DataSource = null;

		private string _BindingPath = null;

		private string _ElementID = null;

		private XTextElement _Element = null;

		private string _FormatString = null;

		private bool _AutoUpdate = false;

		private bool _Readonly = false;

		/// <summary>
		///       数据源名称
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string DataSource
		{
			get
			{
				return _DataSource;
			}
			set
			{
				_DataSource = value;
			}
		}

		/// <summary>
		///       数据源的绑定路径
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string BindingPath
		{
			get
			{
				return _BindingPath;
			}
			set
			{
				_BindingPath = value;
			}
		}

		/// <summary>
		///       元素编号
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ElementID
		{
			get
			{
				return _ElementID;
			}
			set
			{
				_ElementID = value;
			}
		}

		/// <summary>
		///       文档元素对象
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[XmlIgnore]
		public XTextElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       格式化字符串
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string FormatString
		{
			get
			{
				return _FormatString;
			}
			set
			{
				_FormatString = value;
			}
		}

		/// <summary>
		///       自动更新
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool AutoUpdate
		{
			get
			{
				return _AutoUpdate;
			}
			set
			{
				_AutoUpdate = value;
			}
		}

		/// <summary>
		///       只读
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
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
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public DataSourceBindingDescription()
		{
		}
	}
}
