using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       电子病历对象属性业务相关说明
	///       </summary>
	[AttributeUsage(AttributeTargets.Property)]
	[ComVisible(false)]
	public class EMRPropertyDescriptionAttribute : Attribute
	{
		private string _ListStyle = null;

		private bool _ListOnly = false;

		private string _ListDisplayMember = null;

		private string _ListValueMember = null;

		private string _DisplayFormat = null;

		/// <summary>
		///       列表属性说明
		///       </summary>
		public string ListStyle
		{
			get
			{
				return _ListStyle;
			}
			set
			{
				_ListStyle = value;
			}
		}

		/// <summary>
		///       只是用下拉列表来读取数据，用户不能自由输入
		///       </summary>
		public bool ListOnly
		{
			get
			{
				return _ListOnly;
			}
			set
			{
				_ListOnly = value;
			}
		}

		/// <summary>
		///       下拉列表中显示的文本成员名
		///       </summary>
		public string ListDisplayMember
		{
			get
			{
				return _ListDisplayMember;
			}
			set
			{
				_ListDisplayMember = value;
			}
		}

		/// <summary>
		///       下拉列表中显示的数值成员名
		///       </summary>
		public string ListValueMember
		{
			get
			{
				return _ListValueMember;
			}
			set
			{
				_ListValueMember = value;
			}
		}

		/// <summary>
		///       显示格式 
		///       </summary>
		public string DisplayFormat
		{
			get
			{
				return _DisplayFormat;
			}
			set
			{
				_DisplayFormat = value;
			}
		}
	}
}
