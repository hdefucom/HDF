using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       指定页码值信息
	///       </summary>
	[Serializable]
	
	[Guid("691BF3F0-0A7F-4612-978D-5C6E8CA0EAD7")]
	
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("691BF3F0-0A7F-4612-978D-5C6E8CA0EAD7", "B552FEBF-3035-42DF-8FA5-FEC99E4EF75B")]
	[ComDefaultInterface(typeof(ISpecifyPageIndexInfo))]
	public class SpecifyPageIndexInfo : ISpecifyPageIndexInfo
	{
		internal const string CLASSID = "691BF3F0-0A7F-4612-978D-5C6E8CA0EAD7";

		internal const string CLASSID_Interface = "B552FEBF-3035-42DF-8FA5-FEC99E4EF75B";

		private int _RawPageIndex = 1;

		private int _SpecifyPageIndex = -1;

		/// <summary>
		///       从1开始计算的原始页码数
		///       </summary>
		[XmlAttribute]
		[DefaultValue(1)]
		public int RawPageIndex
		{
			get
			{
				return _RawPageIndex;
			}
			set
			{
				_RawPageIndex = value;
			}
		}

		/// <summary>
		///       指定的页码值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(-1)]
		public int SpecifyPageIndex
		{
			get
			{
				return _SpecifyPageIndex;
			}
			set
			{
				_SpecifyPageIndex = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public SpecifyPageIndexInfo Clone()
		{
			return (SpecifyPageIndexInfo)MemberwiseClone();
		}
	}
}
