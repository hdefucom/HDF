using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       复制来源信息
	///       </summary>
	[Serializable]
	[Guid("17946D6F-DE3C-4D07-93E1-B99CFC2EB713")]
	[ComDefaultInterface(typeof(ICopySourceInfo))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[DocumentComment]
	
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("17946D6F-DE3C-4D07-93E1-B99CFC2EB713", "CFCE3920-FE4C-4FE7-9D39-2D5D44F4E391")]
	public class CopySourceInfo : ICopySourceInfo, IDCStringSerializable
	{
		internal const string CLASSID = "17946D6F-DE3C-4D07-93E1-B99CFC2EB713";

		internal const string CLASSID_Interface = "CFCE3920-FE4C-4FE7-9D39-2D5D44F4E391";

		private string _SourceID = null;

		private string _SourcePropertyName = null;

		private string _DescPropertyName = null;

		private bool _IgnoreChildElements = true;

		/// <summary>
		///       数据来源的文档元素编号
		///       </summary>
		
		[DefaultValue(null)]
		public string SourceID
		{
			get
			{
				return _SourceID;
			}
			set
			{
				_SourceID = value;
			}
		}

		/// <summary>
		///       属性名称
		///       </summary>
		
		[DefaultValue(null)]
		public string SourcePropertyName
		{
			get
			{
				return _SourcePropertyName;
			}
			set
			{
				_SourcePropertyName = value;
			}
		}

		/// <summary>
		///       目标属性名称
		///       </summary>
		[DefaultValue(null)]
		
		public string DescPropertyName
		{
			get
			{
				return _DescPropertyName;
			}
			set
			{
				_DescPropertyName = value;
			}
		}

		/// <summary>
		///       忽略掉子元素的操作
		///       </summary>
		
		[DefaultValue(true)]
		public bool IgnoreChildElements
		{
			get
			{
				return _IgnoreChildElements;
			}
			set
			{
				_IgnoreChildElements = value;
			}
		}

		public bool IsEmpty => string.IsNullOrEmpty(_DescPropertyName) && string.IsNullOrEmpty(_SourceID) && string.IsNullOrEmpty(_SourcePropertyName) && _IgnoreChildElements;

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public CopySourceInfo()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		
		public CopySourceInfo Clone()
		{
			return (CopySourceInfo)MemberwiseClone();
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		
		public override string ToString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		
		public string DCWriteString()
		{
			return ToString();
		}

		
		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}
	}
}
