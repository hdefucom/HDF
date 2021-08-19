using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间轴运行设计器之后的事件参数
	///       </summary>
	[DocumentComment]
	[DCPublishAPI]
	[ComVisible(true)]
	public class AfterRunDesignerEventArgs
	{
		private TemperatureControl _Control;

		private TemperatureDocument _Document;

		/// <summary>
		///       时间轴控件对象
		///       </summary>
		public TemperatureControl Control => _Control;

		/// <summary>
		///       文档对象
		///       </summary>
		public TemperatureDocument Document => _Document;

		/// <summary>
		///       配置XML字符串
		///       </summary>
		public string ConfigXML => _Document.ConfigXml;

		public AfterRunDesignerEventArgs(TemperatureControl temperatureControl_0, TemperatureDocument document)
		{
			int num = 4;
			_Control = null;
			_Document = null;
			
			if (temperatureControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			_Control = temperatureControl_0;
			_Document = document;
		}
	}
}
