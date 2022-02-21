using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	[ComVisible(false)]
	
	public class CopySourceExecuteInfo
	{
		private XTextElement _SourceElement = null;

		private XTextElement _TargetElement = null;

		private string _SourcePropertyName = null;

		private string _DescPropertyName = null;

		public XTextElement SourceElement
		{
			get
			{
				return _SourceElement;
			}
			set
			{
				_SourceElement = value;
			}
		}

		public XTextElement TargetElement
		{
			get
			{
				return _TargetElement;
			}
			set
			{
				_TargetElement = value;
			}
		}

		public string SourcePropertyName
		{
			get
			{
				return _SourcePropertyName;
			}
			set
			{
				_SourcePropertyName = value;
			}
		}

		public string DescPropertyName
		{
			get
			{
				return _DescPropertyName;
			}
			set
			{
				_DescPropertyName = value;
			}
		}
	}
}
