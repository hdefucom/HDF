using DCSoft.Common;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文件引用块元素
	///       </summary>
	/// <remarks>文档块元素表示在文档中嵌入一个文本标签，该标签能引用到另外一个文档，当双击标签时
	///       会加载其引用的外部文档并插入到当前文档区域替换掉该文本标签。</remarks>
	[Serializable]
	[XmlType("XFileBlock")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextFileBlockElement))]
	[DCPublishAPI]
	[DocumentComment]
	[DebuggerDisplay("File block:{ID} {ContentSourceValue}")]
	[ComClass("00012345-6789-ABCD-EF01-234567890056", "9E74F75D-3D57-45FA-929E-99E7E912987D")]
	[Guid("00012345-6789-ABCD-EF01-234567890056")]
	[ClassInterface(ClassInterfaceType.None)]
	[ToolboxBitmap(typeof(XTextFileBlockElement))]
	public class XTextFileBlockElement : XTextBlockElement, IXTextFileBlockElement
	{
		internal const string string_10 = "00012345-6789-ABCD-EF01-234567890056";

		internal const string string_11 = "9E74F75D-3D57-45FA-929E-99E7E912987D";

		private FileContentSource fileContentSource_0 = null;

		public override string DomDisplayName => "FileBlock:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "fileblock";

		/// <summary>
		///       对象大小是固定的
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		[XmlIgnore]
		public override ResizeableType Resizeable
		{
			get
			{
				return ResizeableType.FixSize;
			}
			set
			{
			}
		}

		/// <summary>
		///       文档内容来源
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public FileContentSource ContentSource
		{
			get
			{
				return fileContentSource_0;
			}
			set
			{
				fileContentSource_0 = value;
			}
		}

		/// <summary>
		///       内容来源值
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public string ContentSourceValue
		{
			get
			{
				if (fileContentSource_0 == null)
				{
					return null;
				}
				return fileContentSource_0.ToString();
			}
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">
		/// </param>
		[DCInternal]
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			switch (args.Style)
			{
			default:
				base.HandleDocumentEvent(args);
				break;
			case DocumentEventStyles.DefaultEditMethod:
				if (!OwnerDocument.DocumentControler.CanModify(this, (DomAccessFlags)MathCommon.smethod_25(255, 2, bool_0: false)))
				{
					vmethod_26(bool_9: true);
				}
				args.Handled = true;
				break;
			case DocumentEventStyles.MouseDblClick:
				vmethod_26(bool_9: true);
				args.Handled = true;
				break;
			}
		}

		[DCInternal]
		public virtual XTextElementList vmethod_26(bool bool_9)
		{
			_ = OwnerDocument;
			XTextElementList xTextElementList = OwnerDocument.ImportDocument(ContentSource);
			OwnerDocument.method_41(xTextElementList);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				OwnerDocument.DocumentControler.vmethod_6(xTextElementList);
				XTextContainerElement parent = Parent;
				GEventArgs4 gEventArgs = new GEventArgs4();
				gEventArgs.method_9(parent);
				gEventArgs.method_29(DomAccessFlags.Normal);
				gEventArgs.method_11(parent.Elements.IndexOf(this));
				gEventArgs.method_13(1);
				gEventArgs.method_15(xTextElementList);
				gEventArgs.method_25(bool_10: true);
				gEventArgs.method_19(bool_9);
				gEventArgs.method_31(bool_10: true);
				gEventArgs.method_27(bool_10: false);
				gEventArgs.method_21(bool_10: true);
				if (bool_9)
				{
					OwnerDocument.BeginLogUndo();
				}
				int num = OwnerDocument.method_63(gEventArgs);
				if (bool_9)
				{
					OwnerDocument.EndLogUndo();
				}
				if (num > 0)
				{
					return xTextElementList;
				}
			}
			return null;
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (XTextDocument.smethod_13(GEnum6.const_203))
			{
				base.DrawContent(args);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			fileContentSource_0 = null;
		}
	}
}
