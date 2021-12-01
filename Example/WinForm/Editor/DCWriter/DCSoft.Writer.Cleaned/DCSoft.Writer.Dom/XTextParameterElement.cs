using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       变量域对象
	///       </summary>
	[Serializable]
	[XmlType("XTextParameter")]
	[ComVisible(false)]
	public class XTextParameterElement : XTextFieldElementBase
	{
		private string string_16 = null;

		private string string_17 = null;

		private ParameterValueUpdateMode parameterValueUpdateMode_0 = ParameterValueUpdateMode.Fixed;

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return string_16;
			}
			set
			{
				string_16 = value;
			}
		}

		/// <summary>
		///       参数名
		///       </summary>
		[DefaultValue(null)]
		public string ParameterName
		{
			get
			{
				return string_17;
			}
			set
			{
				string_17 = value;
			}
		}

		/// <summary>
		///       参数值更新方式
		///       </summary>
		[DefaultValue(ParameterValueUpdateMode.Fixed)]
		public ParameterValueUpdateMode ValueUpdateMode
		{
			get
			{
				return parameterValueUpdateMode_0;
			}
			set
			{
				parameterValueUpdateMode_0 = value;
			}
		}
	}
}
