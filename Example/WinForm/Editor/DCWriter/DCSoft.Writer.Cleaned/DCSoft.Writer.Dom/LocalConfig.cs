using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档本地配置
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(ILocalConfig))]
	[Guid("00012345-6789-ABCD-EF01-23456789009F")]
	
	[ComClass("00012345-6789-ABCD-EF01-23456789009F", "BE183319-C54A-4B39-97C4-2D38075CBF77")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public class LocalConfig : ICloneable, ILocalConfig
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789009F";

		internal const string CLASSID_Interface = "BE183319-C54A-4B39-97C4-2D38075CBF77";

		private bool _OldWhitespaceWidth = false;

		/// <summary>
		///       采用旧的计算空格的算法
		///       </summary>
		[DefaultValue(false)]
		public bool OldWhitespaceWidth
		{
			get
			{
				return _OldWhitespaceWidth;
			}
			set
			{
				_OldWhitespaceWidth = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public LocalConfig Clone()
		{
			return (LocalConfig)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
