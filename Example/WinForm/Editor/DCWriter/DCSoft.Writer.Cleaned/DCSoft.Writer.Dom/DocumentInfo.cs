using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档设置信息对象
	///       </summary>
	[Serializable]
	
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDocumentInfo))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("64C6D8E7-A63C-4D86-9F69-42F107CB1660", "760F4A6D-1A63-4E49-844B-743406573313")]
	[Guid("64C6D8E7-A63C-4D86-9F69-42F107CB1660")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	
	public class DocumentInfo : IDCStringSerializable, IDocumentInfo
	{
		internal const string CLASSID = "64C6D8E7-A63C-4D86-9F69-42F107CB1660";

		internal const string CLASSID_Interface = "760F4A6D-1A63-4E49-844B-743406573313";

		private SubDocumentSettings _SubDocumentSettings = null;

		private bool _Readonly = false;

		private bool _RefreshLayoutFlag = false;

		private bool _RefreshViewFlag = false;

		private DCBooleanValue _ShowHeaderBottomLine = DCBooleanValue.Inherit;

		private float _FieldBorderElementWidth = 1f;

		private int _KBEntryRangeMask = 0;

		[NonSerialized]
		private string _RuntimeTitle = null;

		private string _ID = null;

		private bool _IsTemplate = false;

		private string _MRID = null;

		private int _TimeoutHours = 0;

		private string _Version = null;

		private string _Title = null;

		private string _Description = null;

		private string _LicenseText = null;

		private DateTime _CreationTime = NullDateTime;

		private DateTime _LastModifiedTime = NullDateTime;

		private int _EditMinute = 0;

		private DateTime _LastPrintTime = NullDateTime;

		private string _Author = null;

		private string _AuthorName = null;

		private int _AuthorPermissionLevel = 0;

		private string _DepartmentID = null;

		private string _DepartmentName = null;

		private string _DocumentFormat = null;

		private string _DocumentType = null;

		private int _DocumentProcessState = 0;

		private int _DocumentEditState = 0;

		private string _Comment = null;

		private string _Operator = "DCSoft.Writer Version:" + typeof(DocumentInfo).Assembly.GetName().Version;

		private int _NumOfPage = 0;

		private bool _UseLanguage2 = false;

		private bool _Printable = true;

		private int _StartPositionInPringJob = 0;

		private int _HeightInPrintJob = 0;

		public static readonly DateTime NullDateTime = new DateTime(1980, 1, 1);

		/// <summary>
		///       子文档模式下是设置
		///       </summary>
		
		[DefaultValue(null)]
		public SubDocumentSettings SubDocumentSettings
		{
			get
			{
				return _SubDocumentSettings;
			}
			set
			{
				_SubDocumentSettings = value;
			}
		}

		/// <summary>
		///       文档内容只读
		///       </summary>
		
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
		///       刷新文档排版标记,DCWriter内部使用。
		///       </summary>
		[XmlIgnore]
		
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool RefreshLayoutFlag
		{
			get
			{
				return _RefreshLayoutFlag;
			}
			set
			{
				_RefreshLayoutFlag = value;
			}
		}

		/// <summary>
		///       刷新文档视图标记,DCWriter内部使用。
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		[XmlIgnore]
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RefreshViewFlag
		{
			get
			{
				return _RefreshViewFlag;
			}
			set
			{
				_RefreshViewFlag = value;
			}
		}

		/// <summary>
		///       是否显示页眉下面的横线
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "ShowHeaderBottomLine")]
		
		[DefaultValue(DCBooleanValue.Inherit)]
		[DCDescription(typeof(DocumentInfo), "ShowHeaderBottomLine")]
		public DCBooleanValue ShowHeaderBottomLine
		{
			get
			{
				return _ShowHeaderBottomLine;
			}
			set
			{
				_ShowHeaderBottomLine = value;
				_RefreshViewFlag = true;
			}
		}

		/// <summary>
		///       输入域边框元素像素宽度
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "FieldBorderElementWidth")]
		[DefaultValue(1f)]
		[DCDisplayName(typeof(DocumentInfo), "FieldBorderElementWidth")]
		
		public float FieldBorderElementWidth
		{
			get
			{
				return _FieldBorderElementWidth;
			}
			set
			{
				_FieldBorderElementWidth = value;
				_RefreshLayoutFlag = true;
			}
		}

		/// <summary>
		///       本文档使用的知识库节点应用范围掩码
		///       </summary>
		[DefaultValue(0)]
		[DCDisplayName(typeof(DocumentInfo), "KBEntryRangeMask")]
		
		[DCDescription(typeof(DocumentInfo), "KBEntryRangeMask")]
		public int KBEntryRangeMask
		{
			get
			{
				return _KBEntryRangeMask;
			}
			set
			{
				_KBEntryRangeMask = value;
			}
		}

		/// <summary>
		///       实际使用的文档标题
		///       </summary>
		
		[ComVisible(false)]
		[XmlIgnore]
		[Browsable(false)]
		public string RuntimeTitle
		{
			get
			{
				return _RuntimeTitle;
			}
			set
			{
				_RuntimeTitle = value;
			}
		}

		/// <summary>
		///       文档编号
		///       </summary>
		
		[DefaultValue(null)]
		[DCDisplayName(typeof(DocumentInfo), "ID")]
		[DCDescription(typeof(DocumentInfo), "ID")]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       该文档是模板文档
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "IsTemplate")]
		[DefaultValue(false)]
		
		[DCDescription(typeof(DocumentInfo), "IsTemplate")]
		public bool IsTemplate
		{
			get
			{
				return _IsTemplate;
			}
			set
			{
				_IsTemplate = value;
			}
		}

		/// <summary>
		///       文档关联的病历编号
		///       </summary>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentInfo), "MRID")]
		[DCDisplayName(typeof(DocumentInfo), "MRID")]
		
		public string MRID
		{
			get
			{
				return _MRID;
			}
			set
			{
				_MRID = value;
			}
		}

		/// <summary>
		///       超时小时数，如果当前时间减去文档创建时间的
		///       小时数超过该属性值，则文档超时。
		///       本属性设置为0表示无意义。
		///       </summary>
		[DefaultValue(0)]
		[DCDescription(typeof(DocumentInfo), "TimeoutHours")]
		
		[DCDisplayName(typeof(DocumentInfo), "TimeoutHours")]
		public int TimeoutHours
		{
			get
			{
				return _TimeoutHours;
			}
			set
			{
				_TimeoutHours = value;
			}
		}

		/// <summary>
		///       内容版本号
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "Version")]
		[DefaultValue(null)]
		[DCDisplayName(typeof(DocumentInfo), "Version")]
		
		public string Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		/// <summary>
		///       文档标题
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "Title")]
		[DCDescription(typeof(DocumentInfo), "Title")]
		
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		/// <summary>
		///       文档说明
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "Description")]
		[DefaultValue(null)]
		
		[DCDisplayName(typeof(DocumentInfo), "Description")]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		/// <summary>
		///       授权信息文本
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "LicenseText")]
		[DefaultValue(null)]
		
		[DCDescription(typeof(DocumentInfo), "LicenseText")]
		public string LicenseText
		{
			get
			{
				return _LicenseText;
			}
			set
			{
				_LicenseText = value;
			}
		}

		/// <summary>
		///       文档创建日期
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "CreationTime")]
		[DCDescription(typeof(DocumentInfo), "CreationTime")]
		
		public DateTime CreationTime
		{
			get
			{
				return _CreationTime;
			}
			set
			{
				_CreationTime = value;
			}
		}

		/// <summary>
		///       最后修改日期
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "LastModifiedTime")]
		[DCDisplayName(typeof(DocumentInfo), "LastModifiedTime")]
		
		public DateTime LastModifiedTime
		{
			get
			{
				return _LastModifiedTime;
			}
			set
			{
				_LastModifiedTime = value;
			}
		}

		/// <summary>
		///       文档编辑的时间长度，单位分钟。
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "EditMinute")]
		[DefaultValue(0)]
		
		[DCDescription(typeof(DocumentInfo), "EditMinute")]
		public int EditMinute
		{
			get
			{
				return _EditMinute;
			}
			set
			{
				_EditMinute = value;
			}
		}

		/// <summary>
		///       最后一次打印的时间
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "LastPrintTime")]
		
		[DCDescription(typeof(DocumentInfo), "LastPrintTime")]
		public DateTime LastPrintTime
		{
			get
			{
				return _LastPrintTime;
			}
			set
			{
				_LastPrintTime = value;
			}
		}

		/// <summary>
		///       作者
		///       </summary>
		
		[DCDisplayName(typeof(DocumentInfo), "Author")]
		[DCDescription(typeof(DocumentInfo), "Author")]
		[DefaultValue(null)]
		public string Author
		{
			get
			{
				return _Author;
			}
			set
			{
				_Author = value;
			}
		}

		/// <summary>
		///       作者姓名
		///       </summary>
		
		[DefaultValue(null)]
		[DCDisplayName(typeof(DocumentInfo), "AuthorName")]
		[DCDescription(typeof(DocumentInfo), "AuthorName")]
		public string AuthorName
		{
			get
			{
				return _AuthorName;
			}
			set
			{
				_AuthorName = value;
			}
		}

		/// <summary>
		///       作者使用的授权等级
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "AuthorPermissionLevel")]
		
		[DCDisplayName(typeof(DocumentInfo), "AuthorPermissionLevel")]
		[DefaultValue(0)]
		public int AuthorPermissionLevel
		{
			get
			{
				return _AuthorPermissionLevel;
			}
			set
			{
				_AuthorPermissionLevel = value;
			}
		}

		/// <summary>
		///       部门编号
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "DepartmentID")]
		[DefaultValue(null)]
		[DCDisplayName(typeof(DocumentInfo), "DepartmentID")]
		
		public string DepartmentID
		{
			get
			{
				return _DepartmentID;
			}
			set
			{
				_DepartmentID = value;
			}
		}

		/// <summary>
		///       部门名称
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "DepartmentName")]
		[DCDisplayName(typeof(DocumentInfo), "DepartmentName")]
		
		[DefaultValue(null)]
		public string DepartmentName
		{
			get
			{
				return _DepartmentName;
			}
			set
			{
				_DepartmentName = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		
		[DCDisplayName(typeof(DocumentInfo), "DocumentFormat")]
		[DCDescription(typeof(DocumentInfo), "DocumentFormat")]
		[DefaultValue(null)]
		public string DocumentFormat
		{
			get
			{
				return _DocumentFormat;
			}
			set
			{
				_DocumentFormat = value;
			}
		}

		/// <summary>
		///       文档类型
		///       </summary>
		[DCDisplayName(typeof(DocumentInfo), "DocumentType")]
		[DCDescription(typeof(DocumentInfo), "DocumentType")]
		
		[DefaultValue(null)]
		public string DocumentType
		{
			get
			{
				return _DocumentType;
			}
			set
			{
				_DocumentType = value;
			}
		}

		/// <summary>
		///       文档操作状态
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "DocumentProcessState")]
		[DCDisplayName(typeof(DocumentInfo), "DocumentProcessState")]
		
		[DefaultValue(0)]
		public int DocumentProcessState
		{
			get
			{
				return _DocumentProcessState;
			}
			set
			{
				_DocumentProcessState = value;
			}
		}

		/// <summary>
		///       文档编辑状态
		///       </summary>
		
		[DCDisplayName(typeof(DocumentInfo), "DocumentEditState")]
		[DefaultValue(0)]
		[DCDescription(typeof(DocumentInfo), "DocumentEditState")]
		public int DocumentEditState
		{
			get
			{
				return _DocumentEditState;
			}
			set
			{
				_DocumentEditState = value;
			}
		}

		/// <summary>
		///       内容说明
		///       </summary>
		
		[DCDescription(typeof(DocumentInfo), "Comment")]
		[DCDisplayName(typeof(DocumentInfo), "Comment")]
		[DefaultValue(null)]
		public string Comment
		{
			get
			{
				return _Comment;
			}
			set
			{
				_Comment = value;
			}
		}

		/// <summary>
		///       操作者
		///       </summary>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentInfo), "Operator")]
		[DCDisplayName(typeof(DocumentInfo), "Operator")]
		
		public string Operator
		{
			get
			{
				return _Operator;
			}
			set
			{
				_Operator = value;
			}
		}

		/// <summary>
		///       文档总页数
		///       </summary>
		[DCDescription(typeof(DocumentInfo), "NumOfPage")]
		[DCDisplayName(typeof(DocumentInfo), "NumOfPage")]
		[DefaultValue(0)]
		
		public int NumOfPage
		{
			get
			{
				return _NumOfPage;
			}
			set
			{
				_NumOfPage = value;
			}
		}

		/// <summary>
		///       启用第二语言
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(DocumentInfo), "UseLanguage2")]
		
		[DCDescription(typeof(DocumentInfo), "UseLanguage2")]
		public bool UseLanguage2
		{
			get
			{
				return _UseLanguage2;
			}
			set
			{
				_UseLanguage2 = value;
			}
		}

		/// <summary>
		///       文档能否打印
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentInfo), "Printable")]
		[DCDisplayName(typeof(DocumentInfo), "Printable")]
		
		public bool Printable
		{
			get
			{
				return _Printable;
			}
			set
			{
				_Printable = value;
			}
		}

		/// <summary>
		///       文档在打印任务中的开始的打印位置
		///       </summary>
		[DefaultValue(0)]
		[DCDescription(typeof(DocumentInfo), "StartPositionInPringJob")]
		[DCDisplayName(typeof(DocumentInfo), "StartPositionInPringJob")]
		
		public int StartPositionInPringJob
		{
			get
			{
				return _StartPositionInPringJob;
			}
			set
			{
				_StartPositionInPringJob = value;
			}
		}

		/// <summary>
		///       文档在打印任务中的打印高度
		///       </summary>
		
		[DCDescription(typeof(DocumentInfo), "HeightInPrintJob")]
		[DefaultValue(0)]
		[DCDisplayName(typeof(DocumentInfo), "HeightInPrintJob")]
		public int HeightInPrintJob
		{
			get
			{
				return _HeightInPrintJob;
			}
			set
			{
				_HeightInPrintJob = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public DocumentInfo Clone()
		{
			DocumentInfo documentInfo = (DocumentInfo)MemberwiseClone();
			if (_SubDocumentSettings != null)
			{
				documentInfo._SubDocumentSettings = _SubDocumentSettings.Clone();
			}
			return documentInfo;
		}

		
		public override string ToString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		
		public string DCWriteString()
		{
			return ToString();
		}

		
		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}
	}
}
