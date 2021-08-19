using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       本地缓存信息对象
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class LocalDataBufferItem
	{
		private string _Name = null;

		private string _FileName = null;

		private int _Version = 0;

		private int _TimeoutDays = 5;

		                                                                    /// <summary>
		                                                                    ///       数据名称
		                                                                    ///       </summary>
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
		                                                                    ///       文件名
		                                                                    ///       </summary>
		[XmlAttribute]
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
		                                                                    ///       数据版本号
		                                                                    ///       </summary>
		[XmlAttribute]
		[DefaultValue(0)]
		public int Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       超时天数
		                                                                    ///       </summary>
		[DefaultValue(5)]
		[XmlAttribute]
		public int TimeoutDays
		{
			get
			{
				return _TimeoutDays;
			}
			set
			{
				_TimeoutDays = value;
			}
		}
	}
}
