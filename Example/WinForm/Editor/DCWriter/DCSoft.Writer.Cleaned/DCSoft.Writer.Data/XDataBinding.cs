using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       数据源绑定信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComClass("180935CE-71A7-4C64-9988-E481182814EF", "D862B3A3-5160-4386-8EB6-1A58A2A3D1C0")]
	[ComDefaultInterface(typeof(IXDataBinding))]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComVisible(true)]
	[Guid("180935CE-71A7-4C64-9988-E481182814EF")]
	public class XDataBinding : ICloneable, IDCStringSerializable, IXDataBinding
	{
		internal const string CLASSID = "180935CE-71A7-4C64-9988-E481182814EF";

		internal const string CLASSID_Interface = "D862B3A3-5160-4386-8EB6-1A58A2A3D1C0";

		private bool _Enabled = true;

		private string _DataSource = null;

		private string _FormatString = null;

		private string _BindingPath = null;

		private string _BindingPathForText = null;

		private string _WriteTextBindingPath = null;

		private string _ValueBindingPath = null;

		private DCProcessStates _ProcessState = DCProcessStates.Always;

		private bool _AutoUpdate = false;

		private bool _Readonly = false;

		private bool _Handled = false;

		/// <summary>
		///       对象是否可用
		///       </summary>
		[DefaultValue(true)]
		[DCPublishAPI]
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

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
		///       格式化字符串
		///       </summary>
		[DCPublishAPI]
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
		///       绑定路径
		///       </summary>
		[DCPublishAPI]
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
		///       为Text而设置的绑定路径,仅对XTextInputFieldElement元素有效。
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[DCPublishAPI]
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
		///       文本值绑定路径，仅对XTextInputFieldElement有效
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string WriteTextBindingPath
		{
			get
			{
				return _WriteTextBindingPath;
			}
			set
			{
				_WriteTextBindingPath = value;
			}
		}

		/// <summary>
		///       后台数值绑定路径
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[XmlIgnore]
		[Obsolete("本属性已作废,请使用BindingPathForInnerValue属性。")]
		[DefaultValue(null)]
		public string ValueBindingPath
		{
			get
			{
				return _ValueBindingPath;
			}
			set
			{
				_ValueBindingPath = value;
			}
		}

		/// <summary>
		///       是空白的数据绑定信息
		///       </summary>
		[DCPublishAPI]
		[DCInternal]
		public bool IsEmptyBinding => string.IsNullOrEmpty(_DataSource) && string.IsNullOrEmpty(_BindingPath) && string.IsNullOrEmpty(_ValueBindingPath) && string.IsNullOrEmpty(_BindingPathForText);

		/// <summary>
		///       操作状态
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(DCProcessStates.Always)]
		public DCProcessStates ProcessState
		{
			get
			{
				return _ProcessState;
			}
			set
			{
				_ProcessState = value;
			}
		}

		/// <summary>
		///       自动更新内容
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
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
		///       只读标记
		///       </summary>
		[DCPublishAPI]
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
		///       对象已经被处理过了。
		///       </summary>
		[DefaultValue(false)]
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
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XDataBinding()
		{
		}

		/// <summary>
		///       比较两者的设置
		///       </summary>
		/// <param name="binding">要比较的值</param>
		/// <returns>比较结果，如果两者设置一样则返回true，否则返回false.</returns>
		[DCInternal]
		public bool CompareSettings(XDataBinding binding)
		{
			if (binding == null)
			{
				return false;
			}
			if (binding == this)
			{
				return true;
			}
			return _AutoUpdate == binding._AutoUpdate && string.Equals(_BindingPath, binding._BindingPath) && string.Equals(_DataSource, binding._DataSource) && _Enabled == binding._Enabled && string.Equals(_FormatString, binding._FormatString) && _ProcessState == binding._ProcessState && _Readonly == binding._Readonly && string.Equals(_BindingPathForText, binding._BindingPathForText) && string.Equals(_WriteTextBindingPath, binding._WriteTextBindingPath) && _Handled == binding._Handled;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public XDataBinding Clone()
		{
			return (XDataBinding)((ICloneable)this).Clone();
		}

		[DCInternal]
		object ICloneable.Clone()
		{
			return (XDataBinding)MemberwiseClone();
		}

		/// <summary>
		///       获得 表示对象内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		[DCInternal]
		public override string ToString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		[DCInternal]
		public string DCWriteString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		[DCInternal]
		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}
	}
}
