using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       名称-值项目
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCNameValueItem
	{
		private string _Name = null;

		private string _Value = null;

		                                                                    /// <summary>
		                                                                    ///       名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
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
		                                                                    ///       值
		                                                                    ///       </summary>
		[XmlText]
		[DefaultValue(null)]
		public string Value
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

		public DCNameValueItem()
		{
		}

		public DCNameValueItem(string name, string Value)
		{
			_Name = name;
			_Value = Value;
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public DCNameValueItem Clone()
		{
			return (DCNameValueItem)MemberwiseClone();
		}

		public override string ToString()
		{
			return Name + "=" + Value;
		}
	}
}
