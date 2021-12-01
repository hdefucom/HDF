using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       数据源绑定信息说明
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComClass("0102B4ED-75A1-4CCB-A963-0E77E30A30D8", "D59EE5C4-1077-4C31-B53D-1D39D479500A")]
	[ComVisible(true)]
	[Guid("0102B4ED-75A1-4CCB-A963-0E77E30A30D8")]
	[ComDefaultInterface(typeof(IFieldValueDescriptor))]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	public class FieldValueDescriptor : IFieldValueDescriptor
	{
		internal const string CLASSID = "0102B4ED-75A1-4CCB-A963-0E77E30A30D8";

		internal const string CLASSID_Interface = "D59EE5C4-1077-4C31-B53D-1D39D479500A";

		private string _ID = null;

		private string _Name = null;

		private bool _Readonly = false;

		private string _DataSource = null;

		private string _BindingPath = null;

		private string _BindingPathForText = null;

		private XTextElement _Element = null;

		internal int _ContentVersion = 0;

		private string _Value = null;

		/// <summary>
		///       文档元素编号
		///       </summary>
		[DefaultValue(null)]
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
		///       文档元素的名称
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
		///       数据源
		///       </summary>
		[DefaultValue(null)]
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
		///       绑定路径
		///       </summary>
		[DefaultValue(null)]
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
		///       绑定路径
		///       </summary>
		[DefaultValue(null)]
		public string BindingPathForText
		{
			get
			{
				return _BindingPathForText;
			}
			set
			{
				_BindingPathForText = value;
			}
		}

		/// <summary>
		///       文档元素对象
		///       </summary>
		[DefaultValue(null)]
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
		///       旧数据
		///       </summary>
		[DefaultValue(null)]
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (_Value != value)
				{
					_Value = value;
				}
			}
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			return DataSource + "." + BindingPath + "=" + Value;
		}
	}
}
