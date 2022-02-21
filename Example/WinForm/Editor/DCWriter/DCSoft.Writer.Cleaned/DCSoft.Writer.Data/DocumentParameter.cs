using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文档参数对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	
	public class DocumentParameter
	{
		[NonSerialized]
		private XTextDocument _Document = null;

		private string strName = null;

		private string strDescription = null;

		private string _TypeName = null;

		private DocumentParameterValueType intValueType = DocumentParameterValueType.Object;

		private string strSourceColumn = null;

		private string strDefaultValue = null;

		private string _ValueTypeFullName = null;

		[NonSerialized]
		private DCXmlSerializablePackage _SerializeValue = null;

		private object _Value = null;

		/// <summary>
		///       文档对象
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		
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
		///       参数名称
		///       </summary>
		
		[DefaultValue(null)]
		[XmlAttribute]
		[Category("Design")]
		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		/// <summary>
		///       参数说明
		///       </summary>
		
		[Category("Design")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string Description
		{
			get
			{
				return strDescription;
			}
			set
			{
				strDescription = value;
			}
		}

		/// <summary>
		///       数据类型名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		
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
		///       数据类型
		///       </summary>
		[XmlAttribute]
		[DefaultValue(DocumentParameterValueType.Object)]
		[Category("Data")]
		
		public DocumentParameterValueType ValueType
		{
			get
			{
				return intValueType;
			}
			set
			{
				intValueType = value;
			}
		}

		/// <summary>
		///       参数值来源栏目名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		
		public string SourceColumn
		{
			get
			{
				return strSourceColumn;
			}
			set
			{
				strSourceColumn = value;
			}
		}

		/// <summary>
		///       数据类型
		///       </summary>
		
		[Browsable(false)]
		public Type ValueDataType
		{
			get
			{
				switch (intValueType)
				{
				default:
					return typeof(string);
				case DocumentParameterValueType.Text:
					return typeof(string);
				case DocumentParameterValueType.Boolean:
					return typeof(bool);
				case DocumentParameterValueType.Numeric:
					return typeof(double);
				case DocumentParameterValueType.Date:
					return typeof(DateTime);
				case DocumentParameterValueType.Time:
					return typeof(TimeSpan);
				case DocumentParameterValueType.DateTime:
					return typeof(DateTime);
				case DocumentParameterValueType.Binary:
					return typeof(byte[]);
				case DocumentParameterValueType.Object:
					return typeof(object);
				}
			}
		}

		/// <summary>
		///       默认值
		///       </summary>
		[DefaultValue(null)]
		[Category("Data")]
		
		[XmlAttribute]
		public string DefaultValue
		{
			get
			{
				return strDefaultValue;
			}
			set
			{
				strDefaultValue = value;
			}
		}

		/// <summary>
		///       类型全名.DCWriter内部使用。
		///       </summary>
		[Browsable(false)]
		[XmlAttribute]
		
		[DefaultValue(null)]
		public string ValueTypeFullName
		{
			get
			{
				return _ValueTypeFullName;
			}
			set
			{
				_ValueTypeFullName = value;
			}
		}

		/// <summary>
		///       XML的数值序列化结果。DCWriter内部使用。
		///       </summary>
		
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public DCXmlSerializablePackage SerializeValue
		{
			get
			{
				return _SerializeValue;
			}
			set
			{
				_SerializeValue = value;
			}
		}

		/// <summary>
		///       参数值
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public object Value
		{
			get
			{
				CheckSerializeState();
				if (ValueType == DocumentParameterValueType.Object)
				{
					return _Value;
				}
				if (_Value == null && strDefaultValue != null)
				{
					object Result = ValueTypeHelper.GetDefaultValue(ValueDataType);
					ValueTypeHelper.TryConvertTo(strDefaultValue, ValueDataType, ref Result);
					return Result;
				}
				return _Value;
			}
			set
			{
				if (_Value != value)
				{
					_SerializeValue = null;
					_ValueTypeFullName = null;
					try
					{
						if (value == null || DBNull.Value.Equals(value))
						{
							_Value = ValueTypeHelper.GetDefaultValue(ValueDataType);
							if (_Value == null)
							{
								_Value = DBNull.Value;
							}
						}
						else
						{
							_Value = ValueTypeHelper.ConvertTo(value, ValueDataType);
							if (intValueType == DocumentParameterValueType.Date)
							{
								_Value = Convert.ToDateTime(_Value).Date;
							}
						}
					}
					catch (Exception innerException)
					{
						throw new Exception(string.Format(WriterStringsCore.BadParameterValueType_Name_Type_Value, strName, intValueType, Value), innerException);
					}
				}
			}
		}

		/// <summary>
		///       获得字符串值
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public string StringValue
		{
			get
			{
				object value = Value;
				if (value == null || DBNull.Value.Equals(value))
				{
					return DefaultValue;
				}
				return Convert.ToString(value);
			}
		}

		/// <summary>
		///       用于序列化/反序列化的用户设置的参数值的属性值
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public string SerializeStringValue
		{
			get
			{
				if (_Value == null || DBNull.Value.Equals(_Value))
				{
					return DefaultValue;
				}
				return StringValue;
			}
			set
			{
				Value = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentParameter()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">参数名称</param>
		
		public DocumentParameter(string name)
		{
			strName = name;
		}

		internal void SetSerializeValue()
		{
			_SerializeValue = null;
			if (Value != null)
			{
				_SerializeValue = new DCXmlSerializablePackage(_Value);
				_SerializeValue.AutoConvertToXMLElement = true;
				_SerializeValue.ValueTypeName = _ValueTypeFullName;
			}
		}

		private void CheckSerializeState()
		{
			if (_Value == null && _SerializeValue != null)
			{
				_Value = _SerializeValue.Value;
				_ValueTypeFullName = _SerializeValue.ValueTypeName;
				_SerializeValue = null;
			}
		}

		/// <summary>
		///       尝试根据文本值设置参数值,不触发异常
		///       </summary>
		/// <param name="strValue">文本值</param>
		/// <returns>操作是否成功</returns>
		public bool TrySetValue(string strValue)
		{
			_SerializeValue = null;
			return ValueTypeHelper.TryConvertTo(strValue, ValueDataType, ref _Value);
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		
		public override string ToString()
		{
			return strName + "=" + _Value;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public DocumentParameter Clone()
		{
			DocumentParameter documentParameter = (DocumentParameter)MemberwiseClone();
			if (_SerializeValue != null)
			{
				documentParameter._SerializeValue = _SerializeValue.Clone();
			}
			return documentParameter;
		}
	}
}
