using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档中承载的对象的参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	
	[ComVisible(false)]
	public class ObjectParameter
	{
		private string _Name = null;

		private string _Value = null;

		/// <summary>
		///       参数名
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
		///       参数值
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

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		
		public override string ToString()
		{
			return Name + "=" + Value;
		}

		
		public ObjectParameter Clone()
		{
			return (ObjectParameter)MemberwiseClone();
		}
	}
}
