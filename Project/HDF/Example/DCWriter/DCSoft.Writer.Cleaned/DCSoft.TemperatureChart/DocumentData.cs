using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档数据
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DocumentData
	{
		private string _Name = null;

		private ValuePointList _Values = null;

		/// <summary>
		///       数据名称
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
		///       数值
		///       </summary>
		[XmlArrayItem("Value", typeof(ValuePoint))]
		public ValuePointList Values
		{
			get
			{
				if (_Values == null)
				{
					_Values = new ValuePointList();
				}
				return _Values;
			}
			set
			{
				_Values = value;
			}
		}

		/// <summary>
		///       返回数据点数量
		///       </summary>
		public override string ToString()
		{
			return Name + " " + Values.Count + "个数据点";
		}
	}
}
