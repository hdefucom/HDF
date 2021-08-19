using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       数据源描述信息
	///       </summary>
	[Serializable]
	[DCPublishAPI]
	[ComVisible(true)]
	[ComClass("C2D18260-3260-4CC2-8532-30BB885CDCD5", "80071BC8-41E7-4413-A17E-3B18FF1C02AC")]
	[XmlType]
	[ComDefaultInterface(typeof(IDataSourceDescriptor))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("C2D18260-3260-4CC2-8532-30BB885CDCD5")]
	public class DataSourceDescriptor : IDataSourceDescriptor
	{
		internal const string CLASSID = "C2D18260-3260-4CC2-8532-30BB885CDCD5";

		internal const string CLASSID_Interface = "80071BC8-41E7-4413-A17E-3B18FF1C02AC";

		private bool _UserEditable;

		private InputFieldEditStyle _EditStyle;

		private XDataBinding _ValueBinding;

		private bool _Readonly;

		private string _BackgroundText;

		private string _Name;

		private ListSourceInfo _ListSource;

		private ValueValidateStyle _ValidateStyle;

		private ValueFormater _DisplayFormat;

		private string _TypeName;

		private string _Description;

		private DocumentElementType _ElementType;

		private DataSourceDescriptorList _ChildDescriptors;

		/// <summary>
		///       是否允许用户编辑
		///       </summary>
		[DefaultValue(true)]
		public bool UserEditable
		{
			get
			{
				return _UserEditable;
			}
			set
			{
				_UserEditable = value;
			}
		}

		/// <summary>
		///       输入域编辑方式
		///       </summary>
		[DefaultValue(InputFieldEditStyle.Text)]
		public InputFieldEditStyle EditStyle
		{
			get
			{
				return _EditStyle;
			}
			set
			{
				_EditStyle = value;
			}
		}

		/// <summary>
		///       数据绑定
		///       </summary>
		[DefaultValue(null)]
		public XDataBinding ValueBinding
		{
			get
			{
				return _ValueBinding;
			}
			set
			{
				_ValueBinding = value;
			}
		}

		/// <summary>
		///       是否只读
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
		///       背景文字
		///       </summary>
		[DefaultValue(null)]
		public string BackgroundText
		{
			get
			{
				return _BackgroundText;
			}
			set
			{
				_BackgroundText = value;
			}
		}

		/// <summary>
		///       名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       列表项目
		///       </summary>
		[DefaultValue(null)]
		public ListSourceInfo ListSource
		{
			get
			{
				return _ListSource;
			}
			set
			{
				_ListSource = value;
			}
		}

		/// <summary>
		///       数据格式检查样式
		///       </summary>
		[DefaultValue(null)]
		public ValueValidateStyle ValidateStyle
		{
			get
			{
				return _ValidateStyle;
			}
			set
			{
				_ValidateStyle = value;
			}
		}

		/// <summary>
		///       显示格式
		///       </summary>
		[DefaultValue(null)]
		public ValueFormater DisplayFormat
		{
			get
			{
				return _DisplayFormat;
			}
			set
			{
				_DisplayFormat = value;
			}
		}

		/// <summary>
		///       数据类型名称
		///       </summary>
		[DefaultValue(null)]
		public string TypeName
		{
			get
			{
				return _TypeName;
			}
			set
			{
				_TypeName = value;
			}
		}

		/// <summary>
		///       说明
		///       </summary>
		[DefaultValue(null)]
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
		///       文档元素类型
		///       </summary>
		[DefaultValue(DocumentElementType.InputField)]
		public DocumentElementType ElementType
		{
			get
			{
				return _ElementType;
			}
			set
			{
				_ElementType = value;
			}
		}

		/// <summary>
		///       子节点列表
		///       </summary>
		[XmlArrayItem("Descriptor", typeof(DataSourceDescriptor))]
		[DefaultValue(null)]
		public DataSourceDescriptorList ChildDescriptors
		{
			get
			{
				return _ChildDescriptors;
			}
			set
			{
				_ChildDescriptors = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DataSourceDescriptor()
		{
			_UserEditable = true;
			_EditStyle = InputFieldEditStyle.Text;
			_ValueBinding = null;
			_Readonly = false;
			_BackgroundText = null;
			_Name = null;
			_ListSource = null;
			_ValidateStyle = null;
			_DisplayFormat = null;
			_TypeName = null;
			_Description = null;
			_ElementType = DocumentElementType.InputField;
			_ChildDescriptors = new DataSourceDescriptorList();
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="p">对象属性描述信息</param>
		public DataSourceDescriptor(PropertyDescriptor propertyDescriptor_0)
		{
			int num = 5;
			_UserEditable = true;
			_EditStyle = InputFieldEditStyle.Text;
			_ValueBinding = null;
			_Readonly = false;
			_BackgroundText = null;
			_Name = null;
			_ListSource = null;
			_ValidateStyle = null;
			_DisplayFormat = null;
			_TypeName = null;
			_Description = null;
			_ElementType = DocumentElementType.InputField;
			_ChildDescriptors = new DataSourceDescriptorList();
			
			if (propertyDescriptor_0 == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(propertyDescriptor_0.Description))
			{
				BackgroundText = propertyDescriptor_0.DisplayName;
			}
			else
			{
				BackgroundText = propertyDescriptor_0.Description;
			}
			TypeName = propertyDescriptor_0.PropertyType.FullName;
			Name = propertyDescriptor_0.Name;
			Description = propertyDescriptor_0.Description;
			Readonly = propertyDescriptor_0.IsReadOnly;
			ValueBinding = new XDataBinding();
			ValueBinding.DataSource = propertyDescriptor_0.ComponentType.Name;
			ValueBinding.BindingPath = propertyDescriptor_0.Name;
			ValueBinding.AutoUpdate = true;
			ValueBinding.Readonly = Readonly;
			EMRPropertyDescriptionAttribute eMRPropertyDescriptionAttribute = (EMRPropertyDescriptionAttribute)propertyDescriptor_0.Attributes[typeof(EMRPropertyDescriptionAttribute)];
			Type propertyType = propertyDescriptor_0.PropertyType;
			if (propertyType.Equals(typeof(DateTime)))
			{
				EditStyle = InputFieldEditStyle.Date;
				if (eMRPropertyDescriptionAttribute != null && !string.IsNullOrEmpty(eMRPropertyDescriptionAttribute.DisplayFormat))
				{
					DisplayFormat = new ValueFormater();
					DisplayFormat.Style = ValueFormatStyle.DateTime;
					DisplayFormat.Format = eMRPropertyDescriptionAttribute.DisplayFormat;
					if (eMRPropertyDescriptionAttribute.DisplayFormat.IndexOf("HH") >= 0)
					{
						EditStyle = InputFieldEditStyle.DateTime;
					}
				}
			}
			else if (propertyType.Equals(typeof(int)) || propertyType.Equals(typeof(short)) || propertyType.Equals(typeof(long)))
			{
				ValidateStyle = new ValueValidateStyle();
				ValidateStyle.ValueType = ValueTypeStyle.Integer;
			}
			else if (propertyType.Equals(typeof(float)) || propertyType.Equals(typeof(double)) || propertyType.Equals(typeof(decimal)))
			{
				ValidateStyle = new ValueValidateStyle();
				ValidateStyle.ValueType = ValueTypeStyle.Numeric;
			}
			if (eMRPropertyDescriptionAttribute != null)
			{
				if (eMRPropertyDescriptionAttribute.ListOnly)
				{
					UserEditable = false;
				}
				if (!string.IsNullOrEmpty(eMRPropertyDescriptionAttribute.ListStyle))
				{
					EditStyle = InputFieldEditStyle.DropdownList;
					ListSource = new ListSourceInfo();
					ListSource.SourceName = eMRPropertyDescriptionAttribute.ListStyle;
					ListSource.DisplayPath = eMRPropertyDescriptionAttribute.ListDisplayMember;
					ListSource.ValuePath = eMRPropertyDescriptionAttribute.ListValueMember;
				}
			}
		}

		/// <summary>
		///       根据一个实体类型创建对象
		///       </summary>
		/// <param name="entryType">实体类型</param>
		public DataSourceDescriptor(Type entryType)
		{
			int num = 5;
			_UserEditable = true;
			_EditStyle = InputFieldEditStyle.Text;
			_ValueBinding = null;
			_Readonly = false;
			_BackgroundText = null;
			_Name = null;
			_ListSource = null;
			_ValidateStyle = null;
			_DisplayFormat = null;
			_TypeName = null;
			_Description = null;
			_ElementType = DocumentElementType.InputField;
			_ChildDescriptors = new DataSourceDescriptorList();
			
			if (entryType == null)
			{
				throw new ArgumentNullException("entryType");
			}
			Name = entryType.Name;
			TypeName = entryType.FullName;
			foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(entryType))
			{
				DataSourceDescriptor item = new DataSourceDescriptor(property);
				ChildDescriptors.Add(item);
			}
		}

		/// <summary>
		///       从文件加载对象数据
		///       </summary>
		/// <param name="fileName">文件名</param>
		public void Load(string fileName)
		{
			int num = 0;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				DataSourceDescriptor dataSourceDescriptor = (DataSourceDescriptor)xmlSerializer.Deserialize(stream);
				if (dataSourceDescriptor != null)
				{
					_BackgroundText = dataSourceDescriptor._BackgroundText;
					_ChildDescriptors = dataSourceDescriptor._ChildDescriptors;
					_Description = dataSourceDescriptor._Description;
					_DisplayFormat = dataSourceDescriptor._DisplayFormat;
					_EditStyle = dataSourceDescriptor._EditStyle;
					_ListSource = dataSourceDescriptor._ListSource;
					_Name = dataSourceDescriptor._Name;
					_Readonly = dataSourceDescriptor._Readonly;
					_TypeName = dataSourceDescriptor._TypeName;
					_UserEditable = dataSourceDescriptor._UserEditable;
					_ValidateStyle = dataSourceDescriptor._ValidateStyle;
					_ValueBinding = dataSourceDescriptor._ValueBinding;
				}
			}
		}

		/// <summary>
		///       从数据流加载对象数据
		///       </summary>
		/// <param name="stream">
		/// </param>
		public void Load(Stream stream)
		{
			if (stream != null)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(GetType());
				DataSourceDescriptor dataSourceDescriptor = (DataSourceDescriptor)xmlSerializer.Deserialize(stream);
				if (dataSourceDescriptor != null)
				{
					_BackgroundText = dataSourceDescriptor._BackgroundText;
					_ChildDescriptors = dataSourceDescriptor._ChildDescriptors;
					_Description = dataSourceDescriptor._Description;
					_DisplayFormat = dataSourceDescriptor._DisplayFormat;
					_EditStyle = dataSourceDescriptor._EditStyle;
					_ListSource = dataSourceDescriptor._ListSource;
					_Name = dataSourceDescriptor._Name;
					_Readonly = dataSourceDescriptor._Readonly;
					_TypeName = dataSourceDescriptor._TypeName;
					_UserEditable = dataSourceDescriptor._UserEditable;
					_ValidateStyle = dataSourceDescriptor._ValidateStyle;
					_ValueBinding = dataSourceDescriptor._ValueBinding;
				}
			}
		}

		/// <summary>
		///       保存对象数据到XML文档中
		///       </summary>
		/// <param name="fileName">文件名</param>
		public void Save(string fileName)
		{
			int num = 5;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(GetType());
				xmlSerializer.Serialize(stream, this);
			}
		}

		/// <summary>
		///       根据对象属性设置一个文本输入域
		///       </summary>
		/// <param name="field">要设置的文本输入域</param>
		public void SetInputField(XTextInputFieldElement field)
		{
			if (field != null)
			{
				field.UserEditable = UserEditable;
				field.FieldSettings = new InputFieldSettings();
				field.FieldSettings.EditStyle = EditStyle;
				field.ValueBinding = ValueBinding;
				field.ContentReadonly = ((!Readonly) ? ContentReadonlyState.Inherit : ContentReadonlyState.True);
				field.BackgroundText = BackgroundText;
				field.Name = Name;
				field.FieldSettings.ListSource = ListSource;
				field.ValidateStyle = ValidateStyle;
				field.DisplayFormat = DisplayFormat;
				field.BackgroundText = BackgroundText;
				field.ToolTip = Description;
			}
		}
	}
}
