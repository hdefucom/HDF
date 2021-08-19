using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       y轴网格线配置信息
	///       </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IGridYSplitInfo))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[Guid("6E465145-DE46-4E5D-9A20-D52E09A96105")]
	public class FCGridYSplitInfo : IGridYSplitInfo
	{
		private int _GridYSplitNum = 8;

		private int _GridYSpaceNum = 5;

		private float _ThickLineWidth = 2f;

		private float _ThinLineWidth = 1f;

		/// <summary>
		///       网格垂直拆分数
		///       </summary>
		[DefaultValue(8)]
		[DCDisplayName(typeof(FCGridYSplitInfo), "GridYSplitNum")]
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
		[DefaultValue(5)]
		[DCDisplayName(typeof(FCGridYSplitInfo), "GridYSpaceNum")]
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
		[DCDisplayName(typeof(FCGridYSplitInfo), "ThickLineWidth")]
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
		[DefaultValue(1f)]
		[DCDisplayName(typeof(FCGridYSplitInfo), "ThinLineWidth")]
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
