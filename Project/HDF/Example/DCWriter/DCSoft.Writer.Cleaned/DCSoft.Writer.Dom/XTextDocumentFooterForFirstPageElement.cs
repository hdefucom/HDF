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
	///       文档页脚对象
	///        </summary>
	[Serializable]
	[Guid("4FD7A359-E071-41E7-8EA2-52D8338802AF")]
	[ComClass("4FD7A359-E071-41E7-8EA2-52D8338802AF", "8A8EDE39-9B6A-4A5A-945A-82F4E8FA1997")]
	[ComDefaultInterface(typeof(IXTextDocumentFooterForFirstPageElement))]
	[DCPublishAPI]
	[DocumentComment]
	[XmlType("XTextFooterForFirstPage")]
	[ComVisible(true)]
	[DebuggerDisplay("FooterForFirstPage :{ PreviewString }")]
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class XTextDocumentFooterForFirstPageElement : XTextDocumentContentElement, IXTextDocumentFooterForFirstPageElement
	{
		internal const string string_14 = "4FD7A359-E071-41E7-8EA2-52D8338802AF";

		internal const string string_15 = "8A8EDE39-9B6A-4A5A-945A-82F4E8FA1997";

		[DCPublishAPI]
		public override PageContentPartyStyle ContentPartyStyle => PageContentPartyStyle.FooterForFirstPage;

		[DCInternal]
		public override string DomDisplayName => "FooterForFirstPage";

		/// <summary>
		///       返回预览用的文本
		///       </summary>
		[DCInternal]
		public override string PreviewString => "FooterForFirstPage:" + base.PreviewString;

		/// <summary>
		///       返回Footer
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public override PageContentPartyStyle PagePartyStyle => PageContentPartyStyle.FooterForFirstPage;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XTextDocumentFooterForFirstPageElement()
		{
		}

		/// <summary>
		///       返回调试时显示的文本
		///       </summary>
		/// <returns>文本</returns>
		[DCInternal]
		public override string ToDebugString()
		{
			int num = 19;
			string text = "FooterForFirstPage";
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
