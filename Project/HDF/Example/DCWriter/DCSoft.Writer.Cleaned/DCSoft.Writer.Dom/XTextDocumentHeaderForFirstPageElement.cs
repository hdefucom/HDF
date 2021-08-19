using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
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
	[ComDefaultInterface(typeof(IXTextDocumentHeaderForFirstPageElement))]
	[ComClass("942F72BF-930D-43B9-BFE5-0BDA614FFD97", "13244198-8DD8-4652-9D52-2AEF315D6FA5")]
	[Guid("942F72BF-930D-43B9-BFE5-0BDA614FFD97")]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	[XmlType("XTextHeaderForFirstPage")]
	[DebuggerDisplay("HeaderForFirstPage :{ PreviewString }")]
	[ComVisible(true)]
	public sealed class XTextDocumentHeaderForFirstPageElement : XTextDocumentContentElement, IXTextDocumentHeaderForFirstPageElement
	{
		internal const string string_14 = "942F72BF-930D-43B9-BFE5-0BDA614FFD97";

		internal const string string_15 = "13244198-8DD8-4652-9D52-2AEF315D6FA5";

		[DCPublishAPI]
		public override PageContentPartyStyle ContentPartyStyle => PageContentPartyStyle.HeaderForFirstPage;

		[DCInternal]
		public override string DomDisplayName => "HeaderForFirstPage";

		/// <summary>
		///       返回预览文本
		///       </summary>
		[DCInternal]
		public override string PreviewString => "HeaderForFirstPage:" + base.PreviewString;

		/// <summary>
		///       返回Header
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public override PageContentPartyStyle PagePartyStyle => PageContentPartyStyle.HeaderForFirstPage;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XTextDocumentHeaderForFirstPageElement()
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
			int num = 11;
			string text = "HeaderForFirstPage";
			if (OwnerDocument != null)
			{
				text = text + ":" + OwnerDocument.RuntimeTitle;
			}
			return text;
		}

		[DCInternal]
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			base.DrawContent(args);
			OwnerDocument.method_114(this, args, GEnum6.const_29);
		}
	}
}
