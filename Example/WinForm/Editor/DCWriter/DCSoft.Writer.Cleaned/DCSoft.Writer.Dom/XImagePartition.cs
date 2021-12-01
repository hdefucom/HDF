using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       描述图像区域信息
	///       </summary>
	[Serializable]
	[XmlInclude(typeof(PointF))]
	[ComVisible(false)]
	public class XImagePartition
	{
		[XmlIgnore]
		public Region region_0;

		[XmlIgnore]
		public GraphicsPath graphicsPath_0;

		private string string_0;

		private int int_0;

		private bool bool_0;

		[CompilerGenerated]
		private List<PointF> list_0;

		/// <summary>
		///       描述构成区域的点的坐标信息，注意这里的坐标并不是坐标真实数据，而是点坐标对应横纵轴长度的比值。因为要考虑到图片伸缩的问题
		///       </summary>
		public List<PointF> RatioToPointFsList
		{
			get;
			set;
		}

		/// <summary>
		///        获取或设置区域的额外描述文本信息
		///       </summary>
		public string Text
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       获取或设置区域的额外描述数值信息
		///       </summary>
		public int Value
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///        获取或设置该区域是否处于被选中状态
		///       </summary>
		public bool IsSelect
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public XImagePartition()
		{
			string_0 = null;
			int_0 = -65535;
			bool_0 = false;
			RatioToPointFsList = new List<PointF>();
			region_0 = new Region();
			graphicsPath_0 = new GraphicsPath();
		}

		public override string ToString()
		{
			return "区域：" + Text + Value;
		}
	}
}
