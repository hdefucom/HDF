using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表示连续空格的元素
	///       </summary>
	[Serializable]
	
	[ComVisible(false)]
	[XmlType("XSpaces")]
	[DocumentComment]
	public sealed class XTextWhiteSpacesElement : XTextElement
	{
		private int int_6 = 0;

		/// <summary>
		///       长度
		///       </summary>
		
		[DefaultValue(0)]
		[HtmlAttribute]
		public int Length
		{
			get
			{
				return int_6;
			}
			set
			{
				int_6 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextWhiteSpacesElement()
		{
		}
	}
}
