using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;

namespace DCSoft.Writer
{
	
	public class WriterAfterExecuteEventExpressionEventArgs : EventArgs
	{
		private XTextDocument _Document = null;

		private WriterControl _WriterControl = null;

		private XTextElement _SourceElement = null;

		private XTextElement _TargetElement = null;

		private string _TargetPropertyName = null;

		public XTextDocument Document => _Document;

		public WriterControl WriterControl => _WriterControl;

		public XTextElement SourceElement => _SourceElement;

		public XTextElement TargetElement => _TargetElement;

		public string TargetPropertyName => _TargetPropertyName;

		public WriterAfterExecuteEventExpressionEventArgs(WriterControl writerControl_0, XTextDocument xtextDocument_0, XTextElement sourceElement, XTextElement targetElement, string targetPropertyName)
		{
			_WriterControl = writerControl_0;
			_Document = xtextDocument_0;
			_SourceElement = sourceElement;
			_TargetElement = targetElement;
			_TargetPropertyName = targetPropertyName;
		}
	}
}
