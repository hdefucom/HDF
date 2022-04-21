using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页面内容版本信息
	///       </summary>
	[Serializable]
	
	[ComClass("7D01A5A7-DB33-4106-B19A-3632226D0AC2", "262854DB-5809-4058-A8D3-6473B5B4390B")]
	[ComVisible(true)]
	[Guid("7D01A5A7-DB33-4106-B19A-3632226D0AC2")]
	
	[ComDefaultInterface(typeof(IPageContentVersionInfo))]
	[ClassInterface(ClassInterfaceType.None)]
	public class PageContentVersionInfo : IPageContentVersionInfo
	{
		internal const string CLASSID = "7D01A5A7-DB33-4106-B19A-3632226D0AC2";

		internal const string CLASSID_Interface = "262854DB-5809-4058-A8D3-6473B5B4390B";

		private int _PageIndex = 0;

		private string _Version = null;

		[NonSerialized]
		private byte[] _NativeBytes = null;

		/// <summary>
		///       从0开始计算的页码编号
		///       </summary>
		
		[XmlAttribute]
		public int PageIndex
		{
			get
			{
				return _PageIndex;
			}
			set
			{
				_PageIndex = value;
			}
		}

		/// <summary>
		///       版本号
		///       </summary>
		
		[DefaultValue(null)]
		[XmlAttribute]
		public string Version
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
		///       原始的字节数组
		///       </summary>
		internal byte[] NativeBytes
		{
			get
			{
				return _NativeBytes;
			}
			set
			{
				_NativeBytes = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public PageContentVersionInfo Clone()
		{
			return (PageContentVersionInfo)MemberwiseClone();
		}

		public override string ToString()
		{
			return PageIndex + "=" + Version;
		}
	}
}
