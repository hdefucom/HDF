using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文件内容来源
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(true)]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[DocumentComment]
	
	[Guid("2BAFD620-9591-4048-8198-8D3173BCD57B")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IFileContentSource))]
	[ComClass("2BAFD620-9591-4048-8198-8D3173BCD57B", "C14AF047-EDBF-4152-B832-E5B6957D30EA")]
	public class FileContentSource : ICloneable, IDCStringSerializable, IFileContentSource
	{
		internal const string CLASSID = "2BAFD620-9591-4048-8198-8D3173BCD57B";

		internal const string CLASSID_Interface = "C14AF047-EDBF-4152-B832-E5B6957D30EA";

		private string _FileSystemName = null;

		private string _FileName = null;

		private string _Format = null;

		private string _RuntimeFileName = null;

		private string _RuntimeFormat = null;

		private string _Range = null;

		/// <summary>
		///       使用的文件系统名称
		///       </summary>
		
		[DefaultValue(null)]
		public string FileSystemName
		{
			get
			{
				return _FileSystemName;
			}
			set
			{
				_FileSystemName = value;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		[DefaultValue(null)]
		
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		
		[DefaultValue(null)]
		public string Format
		{
			get
			{
				return _Format;
			}
			set
			{
				_Format = value;
			}
		}

		/// <summary>
		///       实际加载文档使用的文件名
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public string RuntimeFileName
		{
			get
			{
				return _RuntimeFileName;
			}
			set
			{
				_RuntimeFileName = value;
			}
		}

		/// <summary>
		///       实际加载文档使用的格式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public string RuntimeFormat
		{
			get
			{
				if (_RuntimeFormat == null)
				{
					return _Format;
				}
				return _RuntimeFormat;
			}
			set
			{
				_RuntimeFormat = value;
			}
		}

		/// <summary>
		///       文件内容范围
		///       </summary>
		
		[DefaultValue(null)]
		public string Range
		{
			get
			{
				return _Range;
			}
			set
			{
				_Range = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public FileContentSource()
		{
		}

		
		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public FileContentSource Clone()
		{
			return (FileContentSource)MemberwiseClone();
		}

		/// <summary>
		///       返回表示对象数据的字符串
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
