using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档页脚对象
	///        </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("Footer :{ PreviewString }")]
	[DocumentComment]
	[DCPublishAPI]
	[ComClass("2F703FDA-076E-4F9E-84EF-42C81AC42F15", "BF7E4F23-D792-4A4F-822E-B770CF526A4E")]
	[Guid("2F703FDA-076E-4F9E-84EF-42C81AC42F15")]
	[ComDefaultInterface(typeof(IXTextDocumentFooterElement))]
	[XmlType("XTextFooter")]
	[ComVisible(true)]
	public sealed class XTextDocumentFooterElement : XTextDocumentContentElement, IXTextDocumentFooterElement
	{
		internal const string string_14 = "2F703FDA-076E-4F9E-84EF-42C81AC42F15";

		internal const string string_15 = "BF7E4F23-D792-4A4F-822E-B770CF526A4E";

		[DCPublishAPI]
		public override PageContentPartyStyle ContentPartyStyle => PageContentPartyStyle.Footer;

		[DCInternal]
		public override string DomDisplayName => "Footer";

		/// <summary>
		///       返回预览用的文本
		///       </summary>
		[DCInternal]
		public override string PreviewString => "Footer:" + base.PreviewString;

		/// <summary>
		///       返回Footer
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public override PageContentPartyStyle PagePartyStyle => PageContentPartyStyle.Footer;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XTextDocumentFooterElement()
		{
		}

		/// <summary>
		///       返回调试时显示的文本
		///       </summary>
		/// <returns>文本</returns>
		[DCInternal]
		public override string ToDebugString()
		{
			int num = 15;
			string text = "Footer";
			if (OwnerDocument != null)
			{
				text = text + ":" + OwnerDocument.RuntimeTitle;
			}
			return text;
		}
	}
}
