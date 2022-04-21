using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       应用程序错误信息 
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("06C64259-FD97-4BC8-8492-80AABF778200", "A9888526-AAAD-417A-A5F5-91DC0518415B")]
	[ComDefaultInterface(typeof(IAppErrorInfo))]
	[Guid("06C64259-FD97-4BC8-8492-80AABF778200")]
	
	public class AppErrorInfo : IAppErrorInfo
	{
		internal const string CLASSID = "06C64259-FD97-4BC8-8492-80AABF778200";

		internal const string CLASSID_Interface = "A9888526-AAAD-417A-A5F5-91DC0518415B";

		private Exception _SourceException = null;

		private XTextElement _SourceElement = null;

		[NonSerialized]
		private WriterControl _WriterControl = null;

		private string _EventName = null;

		private string _Message = null;

		public Exception SourceException => _SourceException;

		public XTextElement SourceElement => _SourceElement;

		public WriterControl WriterControl => _WriterControl;

		public string EventName => _EventName;

		public string Message => _Message;

		public AppErrorInfo(XTextElement element, Exception exception_0, string eventName)
		{
			if (element != null)
			{
				_WriterControl = element.WriterControl;
				_SourceElement = element;
			}
			if (exception_0 != null)
			{
				_SourceException = exception_0;
				_Message = exception_0.Message;
			}
			_EventName = eventName;
		}
	}
}
