using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       时间区域事件参数对象
	///       </summary>
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComDefaultInterface(typeof(IFriedmanCurveZoneEventArgs))]
	[Guid("B2D036A6-14E2-496D-BAD5-88B4C18F1B28")]
	public class FriedmanCurveZoneEventArgs : IFriedmanCurveZoneEventArgs
	{
		private FriedmanCurveZoneInfo _Zone = null;

		private FriedmanCurveDocument _Document = null;

		/// <summary>
		///       时间区域对象
		///       </summary>
		public FriedmanCurveZoneInfo Zone => _Zone;

		/// <summary>
		///       文档对象
		///       </summary>
		public FriedmanCurveDocument Document => _Document;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="zone">时间区域对象</param>
		public FriedmanCurveZoneEventArgs(FriedmanCurveDocument document, FriedmanCurveZoneInfo zone)
		{
			_Document = document;
			_Zone = zone;
		}
	}
}
