using DCSoft.Common;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       XML序列化项目
	///       </summary>
	[ComVisible(false)]
	
	public class XMLViewStateBagItem
	{
		private string _Name = null;

		private string _TypeName = null;

		private object _Value = null;

		/// <summary>
		///       名称
		///       </summary>
		[XmlAttribute]
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
		///       类型名称
		///       </summary>
		[XmlAttribute]
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
		///       对象值
		///       </summary>
		[DefaultValue(null)]
		[XmlIgnore]
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       XML数据
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		public DCXmlSerializablePackage XMLValue
		{
			get
			{
				DCXmlSerializablePackage dCXmlSerializablePackage = new DCXmlSerializablePackage();
				dCXmlSerializablePackage.Value = _Value;
				return dCXmlSerializablePackage;
			}
			set
			{
				if (value != null)
				{
					_Value = value.Value;
				}
			}
		}
	}
}
