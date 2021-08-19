using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       y轴网格线配置信息
	///       </summary>
	[Serializable]
	[DocumentComment]
	[Guid("69D7EBBF-DE22-40F4-8212-D12EE239F441")]
	[ComDefaultInterface(typeof(IGridYSplitInfo))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	public class GridYSplitInfo : IGridYSplitInfo
	{
		private int _GridYSplitNum = 8;

		private int _GridYSpaceNum = 5;

		private float _ThickLineWidth = 2f;

		private float _ThinLineWidth = 1f;

		/// <summary>
		///       网格垂直拆分数
		///       </summary>
		[DefaultValue(8)]
		[DCDisplayName(typeof(GridYSplitInfo), "GridYSplitNum")]
		public int GridYSplitNum
		{
			get
			{
				return _GridYSplitNum;
			}
			set
			{
				_GridYSplitNum = value;
			}
		}

		/// <summary>
		///       每次绘制的线条数（包含一条粗线和多条细线）
		///       </summary>
		[DCDisplayName(typeof(GridYSplitInfo), "GridYSpaceNum")]
		[DefaultValue(5)]
		public int GridYSpaceNum
		{
			get
			{
				return _GridYSpaceNum;
			}
			set
			{
				_GridYSpaceNum = value;
			}
		}

		/// <summary>
		///       粗线宽度
		///       </summary>
		[DefaultValue(2f)]
		[DCDisplayName(typeof(GridYSplitInfo), "ThickLineWidth")]
		public float ThickLineWidth
		{
			get
			{
				return _ThickLineWidth;
			}
			set
			{
				_ThickLineWidth = value;
			}
		}

		/// <summary>
		///       细线宽度
		///       </summary>
		[DCDisplayName(typeof(GridYSplitInfo), "ThinLineWidth")]
		[DefaultValue(1f)]
		public float ThinLineWidth
		{
			get
			{
				return _ThinLineWidth;
			}
			set
			{
				_ThinLineWidth = value;
			}
		}
	}
}
