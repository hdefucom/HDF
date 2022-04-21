using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档结束标记
	///       </summary>
	[Serializable]
	
	[ComVisible(false)]
	public class XTextEOFElement : XTextElement
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		protected XTextEOFElement()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="doc">对象所属文本</param>
		public XTextEOFElement(XTextDocument xtextDocument_1)
		{
			OwnerDocument = xtextDocument_1;
		}
	}
}
