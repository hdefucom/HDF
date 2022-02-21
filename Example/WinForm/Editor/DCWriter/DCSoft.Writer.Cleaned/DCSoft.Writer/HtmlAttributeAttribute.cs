using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       输出到HTML属性中的标记
	///       </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	
	[ComVisible(false)]
	public sealed class HtmlAttributeAttribute : Attribute
	{
		private string _AttributeName = null;

		private bool _AutoUseAttributeString = false;

		private bool _DetectDefaultValue = true;

		/// <summary>
		///       指定的属性名
		///       </summary>
		public string AttributeName
		{
			get
			{
				return _AttributeName;
			}
			set
			{
				_AttributeName = value;
			}
		}

		/// <summary>
		///       自动使用属性字符串
		///       </summary>
		public bool AutoUseAttributeString
		{
			get
			{
				return _AutoUseAttributeString;
			}
			set
			{
				_AutoUseAttributeString = value;
			}
		}

		/// <summary>
		///       检测默认值
		///       </summary>
		public bool DetectDefaultValue
		{
			get
			{
				return _DetectDefaultValue;
			}
			set
			{
				_DetectDefaultValue = value;
			}
		}
	}
}
