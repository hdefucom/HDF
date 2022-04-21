using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       重复引用的图片对象
	///       </summary>
	[Serializable]
	
	[ComVisible(false)]
	public class RepeatedImageValue : XImageValue
	{
		private int int_3 = 0;

		private int int_4 = 0;

		/// <summary>
		///       对象引用的次数
		///       </summary>
		[Browsable(true)]
		[XmlAttribute]
		[DefaultValue(0)]
		public int ReferenceCount
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		/// <summary>
		///       编号
		///       </summary>
		[DefaultValue(0)]
		[XmlAttribute]
		public int ValueIndex
		{
			get
			{
				return int_4;
			}
			set
			{
				int_4 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public RepeatedImageValue()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="img">图片数据</param>
		public RepeatedImageValue(XImageValue ximageValue_0)
		{
			ximageValue_0?.method_3(this);
		}
	}
}
