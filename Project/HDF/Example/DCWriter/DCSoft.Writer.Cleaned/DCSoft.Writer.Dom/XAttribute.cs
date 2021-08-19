using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       扩展属性对象
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXAttribute))]
	[Guid("00012345-6789-ABCD-EF01-234567890049")]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-234567890049", "1AECE4DB-7387-44DD-836F-D8CD8A6AAB3B")]
	[DocumentComment]
	public class XAttribute : ICloneable, IXAttribute
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890049";

		internal const string CLASSID_Interface = "1AECE4DB-7387-44DD-836F-D8CD8A6AAB3B";

		private string _Name = null;

		private string _Value = null;

		/// <summary>
		///       属性名
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
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
		///       属性值
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
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
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XAttribute()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		[DCPublishAPI]
		public XAttribute(string name, string Value)
		{
			_Name = name;
			_Value = Value;
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XAttribute Clone()
		{
			return (XAttribute)((ICloneable)this).Clone();
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Name + "=" + Value;
		}
	}
}
