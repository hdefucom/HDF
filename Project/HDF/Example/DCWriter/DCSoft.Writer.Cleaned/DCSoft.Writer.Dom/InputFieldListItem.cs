using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       输入域列表项目
	///       </summary>
	[Serializable]
	[Obsolete]
	[ComVisible(false)]
	[XmlType]
	public class InputFieldListItem
	{
		private string _Text = null;

		private string _Value = null;

		private string _Tag = null;

		/// <summary>
		///       列表文本
		///       </summary>
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       列表项目值
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
				_Value = value;
			}
		}

		/// <summary>
		///       附加数据
		///       </summary>
		[DefaultValue(null)]
		public string Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return "Text:" + Text + " Value:" + Value;
		}
	}
}
