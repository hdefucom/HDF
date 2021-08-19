using System;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档双击事件参数
	///       </summary>
	[Guid("1A8B0C9D-6F3F-4BD7-9D43-03B32865412E")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDocumentDblClickEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	public class DocumentDblClickEventArgs : EventArgs, IDocumentDblClickEventArgs
	{
		private TemperatureDocument _Document = null;

		/// <summary>
		///       文档对象
		///       </summary>
		public TemperatureDocument Document => _Document;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		public DocumentDblClickEventArgs(TemperatureDocument temperatureDocument_0)
		{
			_Document = temperatureDocument_0;
		}
	}
}
