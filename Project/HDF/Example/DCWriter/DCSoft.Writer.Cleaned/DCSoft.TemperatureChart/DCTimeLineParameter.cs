using DCSoft.Common;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档参数
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class DCTimeLineParameter
	{
		private string _Name = null;

		private string _Value = null;

		/// <summary>
		///       参数名称
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
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCTimeLineParameter Clone()
		{
			return (DCTimeLineParameter)MemberwiseClone();
		}

		/// <summary>
		///       返回数据点值
		///       </summary>
		public override string ToString()
		{
			return Name + "=" + Value;
		}
	}
}
