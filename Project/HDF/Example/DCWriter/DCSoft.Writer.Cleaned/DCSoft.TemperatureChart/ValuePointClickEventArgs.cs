using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       数据点点击事件参数
	///       </summary>
	[Guid("C689D881-63F0-48CB-B3DC-E7C94131E654")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IValuePointClickEventArgs))]
	public class ValuePointClickEventArgs : IValuePointClickEventArgs
	{
		private YAxisInfo _YAxis = null;

		private TitleLineInfo _TitleLine = null;

		private ValuePoint _Point = null;

		/// <summary>
		///       点所属的Y坐标轴
		///       </summary>
		public YAxisInfo YAxis => _YAxis;

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
		public TitleLineInfo TitleLine => _TitleLine;

		/// <summary>
		///       数据点对象
		///       </summary>
		public ValuePoint Point => _Point;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="vp">
		/// </param>
		public ValuePointClickEventArgs(ValuePoint valuePoint_0)
		{
			_YAxis = (valuePoint_0.Parent as YAxisInfo);
			_TitleLine = (valuePoint_0.Parent as TitleLineInfo);
			_Point = valuePoint_0;
		}
	}
}
