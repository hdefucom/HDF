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
	///       文档页眉对象
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextDocumentHeaderElement))]
	[DebuggerDisplay("Header :{ PreviewString }")]
	[Guid("8B273384-82C3-4E23-8DA8-940CE19AB582")]
	[DCPublishAPI]
	[DocumentComment]
	[ComClass("8B273384-82C3-4E23-8DA8-940CE19AB582", "1F79E8C5-A034-4BE1-8E76-8A971466DF84")]
	[XmlType("XTextHeader")]
	public sealed class XTextDocumentHeaderElement : XTextDocumentContentElement, IXTextDocumentHeaderElement
	{
		internal const string string_14 = "8B273384-82C3-4E23-8DA8-940CE19AB582";

		internal const string string_15 = "1F79E8C5-A034-4BE1-8E76-8A971466DF84";

		[DCPublishAPI]
		public override PageContentPartyStyle ContentPartyStyle => PageContentPartyStyle.Header;

		[DCInternal]
		public override string DomDisplayName => "Header";

		/// <summary>
		///       返回预览文本
		///       </summary>
		[DCInternal]
		public override string PreviewString => "Header:" + base.PreviewString;

		/// <summary>
		///       返回Header
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public override PageContentPartyStyle PagePartyStyle => PageContentPartyStyle.Header;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XTextDocumentHeaderElement()
		{
		}

		/// <summary>
		///       修正元素内容
		///       </summary>
		[DCInternal]
		public override void FixElements()
		{
			if (Elements.Count == 0 || !(Elements.LastElement is XTextParagraphFlagElement))
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
				xTextParagraphFlagElement.AutoCreate = true;
				DocumentContentStyle documentContentStyle = new DocumentContentStyle();
				documentContentStyle.Align = DocumentContentAlignment.Center;
				xTextParagraphFlagElement.StyleIndex = OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
				AppendChildElement(xTextParagraphFlagElement);
			}
		}

		/// <summary>
		///       返回调试时显示的文本
		///       </summary>
		/// <returns>文本</returns>
		[DCInternal]
		public override string ToDebugString()
		{
			int num = 14;
			string text = "Header";
			if (OwnerDocument != null)
			{
				text = text + ":" + OwnerDocument.RuntimeTitle;
			}
			return text;
		}
	}
}
