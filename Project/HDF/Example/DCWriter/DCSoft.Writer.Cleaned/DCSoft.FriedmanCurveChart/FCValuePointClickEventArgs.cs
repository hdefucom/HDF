using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据点点击事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IValuePointClickEventArgs))]
	[Guid("28C40C66-B897-4654-8E04-0D2CB2C2827B")]
	[ComVisible(true)]
	public class FCValuePointClickEventArgs : IValuePointClickEventArgs
	{
		private FCYAxisInfo _YAxis = null;

		private FCTitleLineInfo _TitleLine = null;

		private FCValuePoint _Point = null;

		/// <summary>
		///       点所属的Y坐标轴
		///       </summary>
		public FCYAxisInfo YAxis => _YAxis;

		/// <summary>
		///       数据序列的标题
		///       </summary>
		public string SerialTitle
		{
			get
			{
				if (_TitleLine != null)
				{
					return _TitleLine.Title;
				}
				if (_YAxis != null)
				{
					return _YAxis.Title;
				}
				return null;
			}
		}

		/// <summary>
		///       数据序列的名称
		///       </summary>
		public string SerialName
		{
			get
			{
				if (_TitleLine != null)
				{
					return _TitleLine.Name;
				}
				if (_YAxis != null)
				{
					return _YAxis.Name;
				}
				return null;
			}
		}

		/// <summary>
		///       数据点所属的标题行信息对象
		///       </summary>
		public FCTitleLineInfo TitleLine => _TitleLine;

		/// <summary>
		///       数据点对象
		///       </summary>
		public FCValuePoint Point => _Point;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="vp">
		/// </param>
		public FCValuePointClickEventArgs(FCValuePoint fcvaluePoint_0)
		{
			_YAxis = (fcvaluePoint_0.Parent as FCYAxisInfo);
			_TitleLine = (fcvaluePoint_0.Parent as FCTitleLineInfo);
			_Point = fcvaluePoint_0;
		}
	}
}
