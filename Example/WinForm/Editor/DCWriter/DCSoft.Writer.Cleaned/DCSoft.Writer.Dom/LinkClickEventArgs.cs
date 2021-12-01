using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档链接点击事件参数类型
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	[DCPublishAPI]
	public class LinkClickEventArgs : EventArgs
	{
		private XTextDocument myDocument = null;

		private XTextElement myElement = null;

		private string strLink = null;

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument Document => myDocument;

		/// <summary>
		///       触发链接的文档元素对象
		///       </summary>
		[DCPublishAPI]
		public XTextElement Element => myElement;

		/// <summary>
		///       链接目标地址
		///       </summary>
		[DCPublishAPI]
		public string Link => strLink;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">元素</param>
		/// <param name="link">链接目标</param>
		[DCInternal]
		public LinkClickEventArgs(XTextDocument xtextDocument_0, XTextElement xtextElement_0, string link)
		{
			myDocument = xtextDocument_0;
			myElement = xtextElement_0;
			strLink = link;
		}
	}
}
