using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间区域事件参数对象
	///       </summary>
	[ComDefaultInterface(typeof(ITimeLineZoneEventArgs))]
	[Guid("548B3F0C-6F22-4CD1-8C85-856C409B8D1E")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DocumentComment]
	public class TimeLineZoneEventArgs : ITimeLineZoneEventArgs
	{
		private TimeLineZoneInfo _Zone = null;

		private TemperatureDocument _Document = null;

		/// <summary>
		///       时间区域对象
		///       </summary>
		public TimeLineZoneInfo Zone => _Zone;

		/// <summary>
		///       文档对象
		///       </summary>
		public TemperatureDocument Document => _Document;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="zone">时间区域对象</param>
		public TimeLineZoneEventArgs(TemperatureDocument document, TimeLineZoneInfo zone)
		{
			_Document = document;
			_Zone = zone;
		}
	}
}
