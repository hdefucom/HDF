using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档控制器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	
	[Guid("00012345-6789-ABCD-EF01-234567890046")]
	
	public class DocumentControler
	{
		public const string string_0 = "DCWriterCommand";

		private FormViewMode formViewMode_0 = FormViewMode.Disable;

		private bool bool_0 = false;

		private XTextDocument xtextDocument_0 = null;

		private WriterAppHost writerAppHost_0 = null;

		[NonSerialized]
		private WriterControl writerControl_0 = null;

		public static readonly string[] string_1 = new string[7]
		{
			"FileNameW",
			DataFormats.Rtf,
			DataFormats.Bitmap,
			DataFormats.Text,
			DataFormats.Html,
			XMLDataFormatName,
			"DCWriterCommand"
		};

		private bool bool_1 = false;

		private ContentProtectedInfo contentProtectedInfo_0 = null;

		private static string string_2 = "!),.:;?]}\u00a8·\u02c7\u02c9―‖’”…∶、。〃\u3005〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠";

		private static string string_3 = "([{·‘“〈《「『【〔〖（．［｛￡￥";

		private DocumentControlerSnapshot documentControlerSnapshot_0 = null;

		/// <summary>
		///       表单视图模式
		///       </summary>
		[DefaultValue(FormViewMode.Disable)]
		[Category("Behavior")]
		public FormViewMode FormView
		{
			get
			{
				if (writerControl_0 != null)
				{
					return writerControl_0.FormView;
				}
				return formViewMode_0;
			}
		}

		/// <summary>
		///       是否以管理员模式运行
		///       </summary>
		/// <remarks>已管理员模式运行,则程序在保证文档结构正常的情况下,
		///       文档中的任何内容都可以删除,文档中的任何部位都能插入,不受授权控制、域只读的限制。
		///       本属性受到文本编辑器控件的Readonly属性的限制.</remarks>
		public bool IsAdministrator
		{
			get
			{
				return bool_0;
			}
			set
			{
				if (!XTextDocument.smethod_13(GEnum6.const_122))
				{
					bool_0 = false;
				}
				else
				{
					bool_0 = value;
				}
			}
		}

		/// <summary>
		///       控制器操作的文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public WriterAppHost AppHost
		{
			get
			{
				if (writerAppHost_0 != null)
				{
					return writerAppHost_0;
				}
				if (EditorControl != null)
				{
					return EditorControl.AppHost;
				}
				return WriterAppHost.Default;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       数据过滤器
		///       </summary>
		[Obsolete("★★★★★请使用WriterControl.ValueFilter事件！！！！")]
		public FilterValueEventHandler ValueFilter
		{
			get
			{
				return (FilterValueEventHandler)AppHost.Services.GetService(typeof(FilterValueEventHandler));
			}
			set
			{
				if (value == null)
				{
					AppHost.Services.RemoveService(typeof(FilterValueEventHandler));
				}
				else
				{
					AppHost.Services.AddService(typeof(FilterValueEventHandler), value);
				}
			}
		}

		/// <summary>
		///       控制器操作的文本编辑器控件对象
		///       </summary>
		public WriterControl EditorControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       控件是否只读
		///       </summary>
		public bool EditorControlReadonly => EditorControl != null && EditorControl.RuntimeReadonly;

		/// <summary>
		///       文档内容呈现器
		///       </summary>
		public GClass95 Render
		{
			get
			{
				if (xtextDocument_0 != null)
				{
					return xtextDocument_0.Render;
				}
				return null;
			}
		}

		private XTextContent Content => Document.Content;

		private XTextDocumentContentElement DocumentContent => Document.CurrentContentElement;

		private XTextSelection Selection => Document.Selection;

		/// <summary>
		///       判断能否执行复制操作
		///       </summary>
		public bool CanCopy => DocumentContent.HasSelectionWithouLogicDeleted;

		public static string XMLDataFormatName => "DCWriterXML V:" + typeof(DocumentControler).Assembly.GetName().Version;

		/// <summary>
		///       判断能否设置样式
		///       </summary>
		/// <returns>
		/// </returns>
		public bool CanSetStyle => true;

		/// <summary>
		///       只执行一次自动大写首字母
		///       </summary>
		internal bool AutoUppercaseFirstCharInFirstLineOnce
		{
			get
			{
				bool result = bool_1;
				bool_1 = false;
				return result;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       判断能否修改当前段落或被选择的段落
		///       </summary>
		public virtual bool CanModifyParagraphs
		{
			get
			{
				XTextElementList paragraphsEOFs = Selection.ParagraphsEOFs;
				foreach (XTextElement item in paragraphsEOFs)
				{
					if (CanModify(item))
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断能否删除文档中选中的区域或者当前元素
		///       </summary>
		public virtual bool CanDeleteSelection
		{
			get
			{
				if (EditorControlReadonly)
				{
					return false;
				}
				if (Selection.Length == 0)
				{
					return true;
				}
				int num = Content.DeleteSelection(raiseEvent: false, detect: true, fastMode: false);
				return num != 0;
			}
		}

		/// <summary>
		///       判断能否在当前位置插入元素
		///       </summary>
		/// <returns>
		/// </returns>
		public bool CanInsertAtCurrentPosition => CanInsertElementAtCurrentPosition(typeof(XTextElement), DomAccessFlags.Normal);

		/// <summary>
		///       后置标点
		///       </summary>
		public static string TailSymbols
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		/// <summary>
		///       前置标点
		///       </summary>
		public static string HeadSymbols
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		/// <summary>
		///       文档状态快照
		///       </summary>
		[Browsable(false)]
		public DocumentControlerSnapshot Snapshot
		{
			get
			{
				if (documentControlerSnapshot_0 != null && (documentControlerSnapshot_0.DocumentContentVersion != Document.ContentVersion || documentControlerSnapshot_0.SelectionVerion != Document.Selection.SelectionVersion))
				{
					documentControlerSnapshot_0 = null;
				}
				if (documentControlerSnapshot_0 == null)
				{
					documentControlerSnapshot_0 = new DocumentControlerSnapshot();
					documentControlerSnapshot_0.DocumentContentVersion = Document.ContentVersion;
					documentControlerSnapshot_0.SelectionVerion = Document.Selection.SelectionVersion;
					documentControlerSnapshot_0.OwnerControler = this;
					documentControlerSnapshot_0.CanModifySelection = CanModifySelection(checkContentProtect: true);
					documentControlerSnapshot_0.CanModifyParagraphs = CanModifyParagraphs;
					documentControlerSnapshot_0.CanDeleteSelection = CanDeleteSelection;
				}
				return documentControlerSnapshot_0;
			}
		}

		public void method_0()
		{
			contentProtectedInfo_0 = null;
			documentControlerSnapshot_0 = null;
		}

		public virtual bool vmethod_0(IDataObject idataObject_0, bool bool_2)
		{
			int num = 7;
			string text = null;
			if (idataObject_0.GetDataPresent("MRID"))
			{
				text = Convert.ToString(idataObject_0.GetData("MRID"));
			}
			if (string.IsNullOrEmpty(text) && Document.Options.BehaviorOptions.DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject)
			{
				return true;
			}
			InsertDocumentWithCheckMRIDType insertDocumentWithCheckMRIDType = Document.Options.BehaviorOptions.InsertDocumentWithCheckMRID;
			switch (insertDocumentWithCheckMRIDType)
			{
			case InsertDocumentWithCheckMRIDType.None:
				if (!XTextDocument.smethod_13(GEnum6.const_138))
				{
					insertDocumentWithCheckMRIDType = InsertDocumentWithCheckMRIDType.WarringWhenFail;
				}
				break;
			case InsertDocumentWithCheckMRIDType.ForbitWhenFail:
				if (!XTextDocument.smethod_13(GEnum6.const_141))
				{
					insertDocumentWithCheckMRIDType = InsertDocumentWithCheckMRIDType.WarringWhenFail;
				}
				break;
			case InsertDocumentWithCheckMRIDType.PromptForbitWhenFail:
				if (!XTextDocument.smethod_13(GEnum6.const_140))
				{
					insertDocumentWithCheckMRIDType = InsertDocumentWithCheckMRIDType.WarringWhenFail;
				}
				break;
			}
			if ((insertDocumentWithCheckMRIDType == InsertDocumentWithCheckMRIDType.ForbitWhenFail || insertDocumentWithCheckMRIDType == InsertDocumentWithCheckMRIDType.WarringWhenFail || insertDocumentWithCheckMRIDType == InsertDocumentWithCheckMRIDType.PromptForbitWhenFail) && !string.IsNullOrEmpty(Document.Info.MRID) && Document.Info.MRID != text)
			{
				switch (insertDocumentWithCheckMRIDType)
				{
				case InsertDocumentWithCheckMRIDType.ForbitWhenFail:
					return false;
				case InsertDocumentWithCheckMRIDType.PromptForbitWhenFail:
				{
					string text2 = Document.Options.BehaviorOptions.CustomPromptForbitCheckMRID;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = WriterStringsCore.PromptForbitPasteMRID_ID_SourceID;
					}
					text2 = string.Format(text2, Document.Info.MRID, text);
					if (bool_2)
					{
						AppHost.UITools.ShowErrorMessageBox(EditorControl, text2);
					}
					return false;
				}
				default:
					if (bool_2)
					{
						string text2 = Document.Options.BehaviorOptions.CustomWarringCheckMRID;
						if (string.IsNullOrEmpty(text2))
						{
							text2 = WriterStringsCore.WarringPasteMRID_ID_SourceID;
						}
						text2 = string.Format(text2, Document.Info.MRID, text);
						return AppHost.UITools.ConfirmDefaultNo(EditorControl, text2);
					}
					return false;
				}
			}
			return true;
		}

		public virtual bool vmethod_1(XTextDocument xtextDocument_1, bool bool_2)
		{
			InsertDocumentWithCheckMRIDType insertDocumentWithCheckMRID = Document.Options.BehaviorOptions.InsertDocumentWithCheckMRID;
			if (insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.ForbitWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.WarringWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.PromptForbitWhenFail)
			{
				if (xtextDocument_1.Info.IsTemplate)
				{
					return true;
				}
				if (!string.IsNullOrEmpty(Document.Info.MRID) && Document.Info.MRID != xtextDocument_1.Info.MRID)
				{
					switch (insertDocumentWithCheckMRID)
					{
					case InsertDocumentWithCheckMRIDType.ForbitWhenFail:
						return false;
					case InsertDocumentWithCheckMRIDType.PromptForbitWhenFail:
					{
						string text = Document.Options.BehaviorOptions.CustomPromptForbitCheckMRID;
						if (string.IsNullOrEmpty(text))
						{
							text = WriterStringsCore.PromptForbitPasteMRID_ID_SourceID;
						}
						text = string.Format(text, Document.Info.MRID, xtextDocument_1.Info.MRID);
						if (bool_2)
						{
							AppHost.UITools.ShowErrorMessageBox(EditorControl, text);
						}
						return false;
					}
					default:
						if (bool_2)
						{
							string text = Document.Options.BehaviorOptions.CustomWarringCheckMRID;
							if (string.IsNullOrEmpty(text))
							{
								text = WriterStringsCore.WarringPasteMRID_ID_SourceID;
							}
							text = string.Format(text, Document.Info.MRID, xtextDocument_1.Info.MRID);
							return AppHost.UITools.ConfirmDefaultNo(EditorControl, text);
						}
						return false;
					}
				}
			}
			return true;
		}

		public bool method_1(int int_0, int int_1)
		{
			return Document.CurrentContentElement.SetSelection(int_0, int_1);
		}

		/// <summary>
		///       判断父元素能否容纳指定的子元素
		///       </summary>
		/// <param name="parentElement">父元素</param>
		/// <param name="element">子元素</param>
		/// <param name="flags">访问标记</param>
		/// <returns>能否容纳子元素</returns>
		public virtual bool AcceptChildElement(XTextElement parentElement, XTextElement element, DomAccessFlags flags)
		{
			int num = 12;
			if (parentElement == null)
			{
				throw new ArgumentNullException("parentElement");
			}
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return AcceptChildElement(parentElement, element.GetType(), flags);
		}

		/// <summary>
		///       判断父元素能否容纳指定类型的子元素
		///       </summary>
		/// <param name="parentElement">父元素对象</param>
		/// <param name="elementType">子元素列表</param>
		/// <param name="flags">访问标记</param>
		/// <returns>能否容纳子元素</returns>
		public virtual bool AcceptChildElement(XTextElement parentElement, Type elementType, DomAccessFlags flags)
		{
			int num = 13;
			if (parentElement == null)
			{
				throw new ArgumentNullException("parentElement");
			}
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (parentElement is XTextContainerElement)
			{
				ElementType runtimeAcceptChildElementTypes = ((XTextContainerElement)parentElement).RuntimeAcceptChildElementTypes;
				if (runtimeAcceptChildElementTypes != ElementType.All)
				{
					ElementType elementType2 = WriterUtils.smethod_64(elementType);
					if (elementType2 == ElementType.None && runtimeAcceptChildElementTypes == ElementType.None)
					{
						return false;
					}
					if (elementType2 != 0 && (runtimeAcceptChildElementTypes & elementType2) != elementType2)
					{
						return false;
					}
				}
			}
			if (typeof(XTextTableRowElement).IsAssignableFrom(elementType))
			{
				return parentElement is XTextTableElement;
			}
			if (typeof(XTextSectionElement).IsAssignableFrom(elementType))
			{
				return parentElement is XTextDocumentBodyElement;
			}
			if (typeof(XTextTableCellElement).IsAssignableFrom(elementType))
			{
				return parentElement is XTextTableRowElement;
			}
			if (parentElement is XTextTableElement)
			{
				return elementType.Equals(typeof(XTextTableRowElement)) || elementType.IsSubclassOf(typeof(XTextTableRowElement)) || elementType.Equals(typeof(XTextTableColumnElement)) || elementType.IsSubclassOf(typeof(XTextTableColumnElement));
			}
			if (parentElement is XTextTableRowElement)
			{
				return elementType.Equals(typeof(XTextTableCellElement)) || elementType.IsSubclassOf(typeof(XTextTableCellElement));
			}
			if (parentElement is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)parentElement;
				if (!IsAdministrator && xTextInputFieldElementBase.RuntimeContentReadonly && method_27(flags, DomAccessFlags.CheckReadonly))
				{
					return false;
				}
			}
			else if (typeof(XTextDocumentContentElement).IsAssignableFrom(elementType))
			{
				return parentElement is XTextDocument;
			}
			return true;
		}

		public virtual void vmethod_2(CanInsertObjectEventArgs canInsertObjectEventArgs_0)
		{
			int num = 14;
			if (canInsertObjectEventArgs_0 == null || canInsertObjectEventArgs_0.DataObject == null || canInsertObjectEventArgs_0.Handled)
			{
				return;
			}
			if (EditorControlReadonly)
			{
				canInsertObjectEventArgs_0.Result = false;
				canInsertObjectEventArgs_0.Handled = true;
				return;
			}
			string text = canInsertObjectEventArgs_0.SpecifyFormat;
			if (text != null)
			{
				text = text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
			}
			if (text != null && !canInsertObjectEventArgs_0.DataObject.GetDataPresent(text))
			{
				canInsertObjectEventArgs_0.Result = false;
				canInsertObjectEventArgs_0.Handled = true;
				return;
			}
			if (Document == null)
			{
				canInsertObjectEventArgs_0.Result = false;
				canInsertObjectEventArgs_0.Handled = true;
				return;
			}
			XTextDocumentContentElement currentContentElement = Document.CurrentContentElement;
			XTextContainerElement xtextContainerElement_ = null;
			int num2 = canInsertObjectEventArgs_0.SpecifyPosition;
			if (num2 < 0 || num2 >= currentContentElement.Content.Count)
			{
				XTextElement currentElement = Document.CurrentElement;
				if (currentElement == null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
				num2 = currentContentElement.Content.IndexOf(currentElement);
			}
			XTextElement xTextElement = currentContentElement.Content[num2];
			XTextElement preElement = currentContentElement.Content.GetPreElement(xTextElement);
			if (preElement != null && xTextElement.RuntimeStyle.ProtectType == ContentProtectType.Range && preElement.RuntimeStyle.ProtectType == ContentProtectType.Range)
			{
				canInsertObjectEventArgs_0.Result = false;
				canInsertObjectEventArgs_0.Handled = true;
				return;
			}
			int int_ = 0;
			currentContentElement.Content.method_20(num2, out xtextContainerElement_, out int_, currentContentElement.Content.LineEndFlag);
			if (!CanInsert(xtextContainerElement_, int_, typeof(XTextElement), canInsertObjectEventArgs_0.AccessFlags))
			{
				canInsertObjectEventArgs_0.Result = false;
				canInsertObjectEventArgs_0.Handled = true;
				return;
			}
			GClass335 gClass = new GClass335(canInsertObjectEventArgs_0.DataObject);
			if (text == "FileNameW" || text == null)
			{
				if (gClass.method_16() && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.FileSource))
				{
					string text2 = gClass.method_18();
					string text3 = text2.ToLower().Trim();
					if (text3.EndsWith(".bmp") || text3.EndsWith(".png") || text3.EndsWith(".jpg") || text3.EndsWith(".jpeg") || text3.EndsWith(".gif") || text3.EndsWith(".emf"))
					{
						canInsertObjectEventArgs_0.Result = CanInsert(xtextContainerElement_, int_, typeof(XTextImageElement), canInsertObjectEventArgs_0.AccessFlags);
						canInsertObjectEventArgs_0.Handled = true;
						return;
					}
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (text == DataFormats.Rtf || text == null)
			{
				if (gClass.method_13() && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.RTF))
				{
					canInsertObjectEventArgs_0.Result = true;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (text == DataFormats.Bitmap || text == null)
			{
				if (gClass.method_4() && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.Image))
				{
					canInsertObjectEventArgs_0.Result = CanInsert(xtextContainerElement_, int_, typeof(XTextImageElement), canInsertObjectEventArgs_0.AccessFlags);
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (text == DataFormats.Text || text == null)
			{
				if (gClass.method_7() && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.Text))
				{
					canInsertObjectEventArgs_0.Result = true;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (text == "DCWriterCommand" || text == null)
			{
				if (gClass.method_19("DCWriterCommand") && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.CommandFormat))
				{
					canInsertObjectEventArgs_0.Result = true;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (text == XMLDataFormatName || text == null)
			{
				if (canInsertObjectEventArgs_0.DataObject.GetDataPresent(XMLDataFormatName) && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.XML))
				{
					canInsertObjectEventArgs_0.Result = true;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (text == typeof(KBEntry).Name || text == null)
			{
				KBEntry kBEntry = method_2(canInsertObjectEventArgs_0.DataObject);
				if (kBEntry != null && WriterUtils.smethod_34(canInsertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.KBEntry) && (kBEntry.SubEntries == null || kBEntry.SubEntries.Count == 0))
				{
					if (kBEntry.Style == KBEntryStyle.Template)
					{
						if (CanInsertAtCurrentPosition)
						{
							canInsertObjectEventArgs_0.Result = true;
							canInsertObjectEventArgs_0.Handled = true;
							return;
						}
					}
					else if (kBEntry.Style == KBEntryStyle.List && CanInsertElementAtCurrentPosition(typeof(XTextInputFieldElement)))
					{
						canInsertObjectEventArgs_0.Result = true;
						canInsertObjectEventArgs_0.Handled = true;
						return;
					}
				}
				if (text != null)
				{
					canInsertObjectEventArgs_0.Result = false;
					canInsertObjectEventArgs_0.Handled = true;
					return;
				}
			}
			if (canInsertObjectEventArgs_0.AllowDataFormats == WriterDataFormats.All)
			{
				canInsertObjectEventArgs_0.Result = true;
			}
			else
			{
				canInsertObjectEventArgs_0.Result = false;
			}
		}

		private KBEntry method_2(IDataObject idataObject_0)
		{
			string[] formats = idataObject_0.GetFormats();
			if (formats != null && formats.Length > 0)
			{
				string[] array = formats;
				foreach (string text in array)
				{
					if (text.EndsWith(typeof(KBEntry).Name))
					{
						return idataObject_0.GetData(text) as KBEntry;
					}
				}
			}
			return null;
		}

		public virtual XTextDocument vmethod_3(IDataObject idataObject_0)
		{
			int num = 1;
			if (idataObject_0 == null)
			{
				return null;
			}
			if (idataObject_0.GetDataPresent(XMLDataFormatName))
			{
				string text = (string)idataObject_0.GetData(XMLDataFormatName);
				if (text != null && text.Length > 0)
				{
					StringReader reader = new StringReader(text);
					XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
					xTextDocument.Load(reader, "xml", fastMode: true);
					xTextDocument.Info.DocumentFormat = "xml";
					return xTextDocument;
				}
			}
			else if (idataObject_0.GetDataPresent(DataFormats.Rtf))
			{
				string text2 = (string)idataObject_0.GetData(DataFormats.Rtf);
				if (!string.IsNullOrEmpty(text2))
				{
					int num2 = text2.LastIndexOf("}");
					if (num2 > 0 && num2 != text2.Length - 1)
					{
						text2 = text2.Substring(0, num2 + 1);
					}
					if (text2.Length > 0)
					{
						XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
						xTextDocument.RTFText = text2;
						xTextDocument.Info.DocumentFormat = "rtf";
						return xTextDocument;
					}
				}
			}
			else if (idataObject_0.GetDataPresent(DataFormats.UnicodeText))
			{
				XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
				xTextDocument.Text = (string)idataObject_0.GetData(DataFormats.UnicodeText);
				xTextDocument.Info.DocumentFormat = "txt";
				return xTextDocument;
			}
			return null;
		}

		internal bool method_3(InsertObjectEventArgs insertObjectEventArgs_0)
		{
			int num = 14;
			if (!insertObjectEventArgs_0.DataObject.GetDataPresent(XMLDataFormatName))
			{
				return false;
			}
			if (!WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.XML))
			{
				return false;
			}
			if (!CanInsertAtCurrentPosition)
			{
				return false;
			}
			string text = (string)insertObjectEventArgs_0.DataObject.GetData(XMLDataFormatName);
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			StringReader reader = new StringReader(text);
			XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
			xTextDocument.Load(reader, "xml", fastMode: true);
			if (!vmethod_1(xTextDocument, bool_2: true))
			{
				xTextDocument.Dispose();
				insertObjectEventArgs_0.Result = false;
				return false;
			}
			XTextElementList xTextElementList = xTextDocument.Body.Elements.Clone();
			xTextDocument.UpdateElementState();
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				if (EditorControl != null)
				{
					FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(InputValueSource.Clipboard, InputValueType.Dom, xTextElementList);
					EditorControl.vmethod_47(filterValueEventArgs);
					if (filterValueEventArgs.Cancel)
					{
						return false;
					}
					xTextElementList = (filterValueEventArgs.Value as XTextElementList);
					if (xTextElementList == null || xTextElementList.Count == 0)
					{
						return false;
					}
				}
				if (xTextElementList.LastElement is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElementList.LastElement;
					if (xTextParagraphFlagElement.AutoCreate)
					{
						xTextElementList.RemoveAt(xTextElementList.Count - 1);
					}
					else
					{
						int num2 = 0;
						foreach (XTextElement item in xTextElementList)
						{
							if (item is XTextParagraphFlagElement)
							{
								num2++;
								if (num2 > 1)
								{
									break;
								}
							}
						}
						if (num2 == 1)
						{
							xTextElementList.RemoveAt(xTextElementList.Count - 1);
						}
					}
					if (xTextElementList.Count == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		private void method_4(InsertObjectEventArgs insertObjectEventArgs_0)
		{
			int num = 9;
			if (!insertObjectEventArgs_0.DataObject.GetDataPresent(XMLDataFormatName))
			{
				insertObjectEventArgs_0.Result = false;
				return;
			}
			if (!WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.XML))
			{
				insertObjectEventArgs_0.RejectFormats.Add(XMLDataFormatName);
				insertObjectEventArgs_0.Result = false;
				return;
			}
			if (!CanInsertAtCurrentPosition)
			{
				insertObjectEventArgs_0.Result = false;
				return;
			}
			string text = (string)insertObjectEventArgs_0.DataObject.GetData(XMLDataFormatName);
			if (string.IsNullOrEmpty(text))
			{
				insertObjectEventArgs_0.Result = false;
				return;
			}
			text = XMLHelper.CleanupXMLHeader(text);
			StringReader reader = new StringReader(text);
			XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
			xTextDocument.Load(reader, "xml", fastMode: true);
			if (!vmethod_1(xTextDocument, bool_2: true))
			{
				xTextDocument.Dispose();
				insertObjectEventArgs_0.Result = false;
				return;
			}
			XTextElementList xTextElementList = xTextDocument.Body.Elements.Clone();
			xTextDocument.UpdateElementState();
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				xTextDocument.Dispose();
				insertObjectEventArgs_0.Result = false;
				return;
			}
			if (EditorControl != null)
			{
				FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(InputValueSource.Clipboard, InputValueType.Dom, xTextElementList);
				EditorControl.vmethod_47(filterValueEventArgs);
				if (filterValueEventArgs.Cancel)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
				xTextElementList = (filterValueEventArgs.Value as XTextElementList);
				if (xTextElementList == null || xTextElementList.Count == 0)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (insertObjectEventArgs_0.CheckMaxTextLengthForCopyPaste && !Document.method_107(xTextElementList, insertObjectEventArgs_0.ShowUI))
			{
				return;
			}
			if (xTextElementList.LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElementList.LastElement;
				if (xTextParagraphFlagElement.AutoCreate)
				{
					xTextElementList.RemoveAt(xTextElementList.Count - 1);
				}
				else
				{
					int num2 = 0;
					foreach (XTextElement item in xTextElementList)
					{
						if (item is XTextParagraphFlagElement)
						{
							num2++;
							if (num2 > 1)
							{
								break;
							}
						}
					}
					if (num2 == 1)
					{
						xTextElementList.RemoveAt(xTextElementList.Count - 1);
					}
				}
				if (xTextElementList.Count == 0)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (insertObjectEventArgs_0.DetectForDragContent)
			{
				insertObjectEventArgs_0.Result = (method_14(insertObjectEventArgs_0.CurrentElement, xTextElementList, bool_2: false, bool_3: true) > 0);
				xTextDocument.Dispose();
				return;
			}
			Document.BeginLogUndo();
			if (DocumentContent.HasSelection)
			{
				Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false);
			}
			Document.ImportElements(xTextElementList);
			Document.method_106(xTextElementList);
			xTextElementList.method_0(bool_1: true);
			_ = (XTextContainerElement)Document.GetCurrentElement(typeof(XTextContainerElement));
			insertObjectEventArgs_0.Result = (method_14(null, xTextElementList, bool_2: false, bool_3: false) > 0);
			if (insertObjectEventArgs_0.Result)
			{
				insertObjectEventArgs_0.NewElements = xTextElementList;
			}
			if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
			{
				vmethod_5(xTextElementList);
			}
			Document.EndLogUndo();
			Document.OnDocumentContentChanged();
		}

		public virtual void vmethod_4(InsertObjectEventArgs insertObjectEventArgs_0)
		{
			int num = 10;
			if (insertObjectEventArgs_0 == null || insertObjectEventArgs_0.DataObject == null)
			{
				insertObjectEventArgs_0.Result = false;
				return;
			}
			if (!insertObjectEventArgs_0.DetectForDragContent)
			{
			}
			string text = insertObjectEventArgs_0.SpecifyFormat;
			if (text != null)
			{
				text = text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
			}
			if (text != null && !insertObjectEventArgs_0.DataObject.GetDataPresent(text))
			{
				insertObjectEventArgs_0.Result = false;
				return;
			}
			if (text == XMLDataFormatName || text == null)
			{
				if (insertObjectEventArgs_0.DataObject.GetDataPresent(XMLDataFormatName))
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.XML))
					{
						method_4(insertObjectEventArgs_0);
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add(XMLDataFormatName.ToString());
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			GClass335 gClass = new GClass335(insertObjectEventArgs_0.DataObject);
			if (text == "DCWriterCommand" || text == null)
			{
				if (insertObjectEventArgs_0.DataObject.GetDataPresent("DCWriterCommand"))
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.CommandFormat))
					{
						string command = Convert.ToString(insertObjectEventArgs_0.DataObject.GetData("DCWriterCommand"));
						object obj = Document.EditorControl.ExecuteStringCommand(command);
						insertObjectEventArgs_0.Result = (obj != null);
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add("DCWriterCommand".ToString());
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (text == "FileNameW" || text == null)
			{
				if (gClass.method_16())
				{
					if (!WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.FileSource))
					{
						insertObjectEventArgs_0.RejectFormats.Add("FileNames");
					}
					else
					{
						string text2 = gClass.method_18();
						string text3 = text2.ToLower().Trim();
						if (text3.EndsWith(".bmp") || text3.EndsWith(".png") || text3.EndsWith(".jpg") || text3.EndsWith(".jpeg") || text3.EndsWith(".gif") || text3.EndsWith(".emf"))
						{
							if (EditorControl != null)
							{
								FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(InputValueSource.Clipboard, InputValueType.FileName, text3);
								EditorControl.vmethod_47(filterValueEventArgs);
								if (filterValueEventArgs.Cancel)
								{
									insertObjectEventArgs_0.Result = false;
									return;
								}
								text3 = (filterValueEventArgs.Value as string);
								if (string.IsNullOrEmpty(text3))
								{
									insertObjectEventArgs_0.Result = false;
									return;
								}
							}
							XImageValue xImageValue = new XImageValue();
							if (xImageValue.Load(text2) > 0 && CanInsertElementAtCurrentPosition(typeof(XTextImageElement)))
							{
								XTextImageElement xTextImageElement = InsertImage(xImageValue, logUndo: true, insertObjectEventArgs_0.InputSource);
								insertObjectEventArgs_0.Result = (xTextImageElement != null);
								if (insertObjectEventArgs_0.Result)
								{
									insertObjectEventArgs_0.NewElements = new XTextElementList(xTextImageElement);
								}
								if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
								{
									vmethod_5(new XTextElementList(xTextImageElement));
								}
							}
							else
							{
								insertObjectEventArgs_0.Result = false;
							}
							return;
						}
					}
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (text == DataFormats.Bitmap || text == null)
			{
				if (gClass.method_4())
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.Image))
					{
						if (!vmethod_0(insertObjectEventArgs_0.DataObject, insertObjectEventArgs_0.ShowUI))
						{
							insertObjectEventArgs_0.Result = false;
							return;
						}
						Image image = gClass.method_5();
						if (image != null && CanInsertElementAtCurrentPosition(typeof(XTextImageElement)))
						{
							XImageValue ximageValue_ = new XImageValue(image);
							XTextImageElement xTextImageElement = InsertImage(ximageValue_, logUndo: true, insertObjectEventArgs_0.InputSource);
							insertObjectEventArgs_0.Result = (xTextImageElement != null);
							if (insertObjectEventArgs_0.Result)
							{
								insertObjectEventArgs_0.NewElements = new XTextElementList(xTextImageElement);
							}
							if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
							{
								vmethod_5(new XTextElementList(xTextImageElement));
							}
						}
						else
						{
							insertObjectEventArgs_0.Result = false;
						}
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add("Image");
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (text == DataFormats.Rtf || text == null)
			{
				if (gClass.method_13())
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.RTF))
					{
						if (!vmethod_0(insertObjectEventArgs_0.DataObject, insertObjectEventArgs_0.ShowUI))
						{
							insertObjectEventArgs_0.Result = false;
						}
						else if (CanInsertAtCurrentPosition)
						{
							string text4 = gClass.method_14();
							if (text4 != null)
							{
								int num2 = text4.LastIndexOf("}");
								if (num2 > 0 && num2 != text4.Length - 1)
								{
									text4 = text4.Substring(0, num2 + 1);
								}
							}
							XTextElementList xTextElementList = InsertRTF(text4, logUndo: true, insertObjectEventArgs_0.InputSource, insertObjectEventArgs_0);
							insertObjectEventArgs_0.Result = (xTextElementList != null && xTextElementList.Count > 0);
							if (insertObjectEventArgs_0.Result)
							{
								insertObjectEventArgs_0.NewElements = xTextElementList;
							}
							if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
							{
								vmethod_5(xTextElementList);
							}
						}
						else
						{
							insertObjectEventArgs_0.Result = false;
						}
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add("RTF");
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (text == DataFormats.Text || text == null)
			{
				if (gClass.method_7())
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.Text))
					{
						if (!vmethod_0(insertObjectEventArgs_0.DataObject, insertObjectEventArgs_0.ShowUI))
						{
							insertObjectEventArgs_0.Result = false;
						}
						else if (CanInsertAtCurrentPosition)
						{
							string text5 = gClass.method_8();
							if (insertObjectEventArgs_0.CheckMaxTextLengthForCopyPaste)
							{
								text5 = Document.method_105(text5, insertObjectEventArgs_0.ShowUI);
								if (string.IsNullOrEmpty(text5))
								{
									return;
								}
							}
							XTextElementList xTextElementList = InsertString(text5, logUndo: true, insertObjectEventArgs_0.InputSource, null, null);
							insertObjectEventArgs_0.Result = (xTextElementList != null && xTextElementList.Count > 0);
							if (insertObjectEventArgs_0.Result)
							{
								insertObjectEventArgs_0.NewElements = xTextElementList;
							}
							if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
							{
								vmethod_5(xTextElementList);
							}
						}
						else
						{
							insertObjectEventArgs_0.Result = false;
						}
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add("Text");
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (text == DataFormats.Html || text == null)
			{
				if (gClass.method_10())
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.Html))
					{
						if (!vmethod_0(insertObjectEventArgs_0.DataObject, insertObjectEventArgs_0.ShowUI))
						{
							insertObjectEventArgs_0.Result = false;
						}
						else if (CanInsertAtCurrentPosition)
						{
							string htmlText = gClass.method_11();
							XTextElementList xTextElementList = InsertHtml(htmlText, logUndo: true, insertObjectEventArgs_0.InputSource, insertObjectEventArgs_0);
							insertObjectEventArgs_0.Result = (xTextElementList != null && xTextElementList.Count > 0);
							if (insertObjectEventArgs_0.Result)
							{
								insertObjectEventArgs_0.NewElements = xTextElementList;
							}
							if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
							{
								vmethod_5(xTextElementList);
							}
						}
						else
						{
							insertObjectEventArgs_0.Result = false;
						}
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add("Html");
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			if (text == typeof(KBEntry).Name || text == null)
			{
				KBEntry kBEntry = method_2(insertObjectEventArgs_0.DataObject);
				if (kBEntry != null)
				{
					if (WriterUtils.smethod_34(insertObjectEventArgs_0.AllowDataFormats, WriterDataFormats.KBEntry))
					{
						XTextElementList xTextElementList = InsertKBEntry(kBEntry, logUndo: true, InputValueSource.UI);
						insertObjectEventArgs_0.Result = (xTextElementList != null && xTextElementList.Count > 0);
						if (insertObjectEventArgs_0.Result)
						{
							insertObjectEventArgs_0.NewElements = xTextElementList;
						}
						if (insertObjectEventArgs_0.Result && insertObjectEventArgs_0.AutoSelectContent)
						{
							vmethod_5(xTextElementList);
						}
						return;
					}
					insertObjectEventArgs_0.RejectFormats.Add("KBEntry");
				}
				if (text != null)
				{
					insertObjectEventArgs_0.Result = false;
					return;
				}
			}
			insertObjectEventArgs_0.Result = false;
		}

		private bool method_5(KBEntry kbentry_0)
		{
			if (EditorControl.DocumentOptions.BehaviorOptions.EnableKBEntryRangeMask)
			{
				int kBEntryRangeMask = EditorControl.Document.Info.KBEntryRangeMask;
				if (kbentry_0.RangeMask != 0 && kBEntryRangeMask != 0 && (kbentry_0.RangeMask & kBEntryRangeMask) != kBEntryRangeMask)
				{
					string text = string.Format(WriterStringsCore.PromptInvalidateKBEntryRangeMask_Name, kbentry_0.Text);
					AppHost.UITools.ShowWarringMessageBox(EditorControl, text);
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///       向文档插入知识库节点
		///       </summary>
		/// <param name="entry">节点</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <param name="inputSource">来源</param>
		/// <returns>插入的文档元素对象列表</returns>
		public virtual XTextElementList InsertKBEntry(KBEntry entry, bool logUndo, InputValueSource inputSource)
		{
			if (entry == null)
			{
				return null;
			}
			if (!method_5(entry))
			{
				return null;
			}
			CreateElementsByKBEntryEventArgs createElementsByKBEntryEventArgs = new CreateElementsByKBEntryEventArgs(Document, entry, inputSource, null);
			EditorControl.CreateElementsByKBEntry(createElementsByKBEntryEventArgs);
			XTextElementList xTextElementList = createElementsByKBEntryEventArgs.Result;
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				if (EditorControl != null)
				{
					FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(InputValueSource.Clipboard, InputValueType.Dom, xTextElementList);
					EditorControl.vmethod_47(filterValueEventArgs);
					if (filterValueEventArgs.Cancel)
					{
						return null;
					}
					xTextElementList = (filterValueEventArgs.Value as XTextElementList);
					if (xTextElementList == null || xTextElementList.Count == 0)
					{
						return null;
					}
				}
				xTextElementList.method_0(bool_1: true);
				int num = method_13(xTextElementList, logUndo);
				if (num > 0)
				{
					return xTextElementList;
				}
			}
			return null;
		}

		/// <summary>
		///       插入图片文件内容
		///       </summary>
		/// <param name="img">图片对象</param>
		/// <param name="logUndo">是否撤销操作</param>
		/// <param name="inputSource">输入来源</param>
		/// <returns>插入的图片元素对象</returns>
		public virtual XTextImageElement InsertImage(XImageValue ximageValue_0, bool logUndo, InputValueSource inputSource)
		{
			int num = 14;
			if (ximageValue_0 == null)
			{
				throw new ArgumentNullException("img");
			}
			if (EditorControl != null)
			{
				FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(inputSource, InputValueType.Image, ximageValue_0.Value);
				EditorControl.vmethod_47(filterValueEventArgs);
				if (filterValueEventArgs.Cancel)
				{
					return null;
				}
				Image image = filterValueEventArgs.Value as Image;
				if (image == null)
				{
					return null;
				}
				ximageValue_0.Value = image;
			}
			XTextImageElement xTextImageElement = Document.CreateImage();
			xTextImageElement.Image = ximageValue_0;
			xTextImageElement.UpdateSize(keepSizePossible: false);
			WriterCommandModule.CheckImageSizeWhenInsertImage(Document, xTextImageElement, xTextImageElement.RuntimeKeepWidthHeightRate, null);
			if (logUndo)
			{
				Document.BeginLogUndo();
			}
			if (DocumentContent.HasSelection)
			{
				Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false);
			}
			Document.InsertElement(xTextImageElement);
			Document.Modified = true;
			if (logUndo)
			{
				Document.EndLogUndo();
			}
			Document.OnDocumentContentChanged();
			return xTextImageElement;
		}

		/// <summary>
		///       在当前位置插入RTF文档
		///       </summary>
		/// <param name="rtfText">RTF文本</param>
		/// <returns>插入的文档元素对象列表</returns>
		public XTextElementList InsertRTF(string rtfText)
		{
			return InsertRTF(rtfText, logUndo: true, InputValueSource.Unknow, null);
		}

		/// <summary>
		///       在当前位置插入RTF文档
		///       </summary>
		/// <param name="rtfText">RTF文本</param>
		/// <param name="logUndo">是否记录撤销操作</param>
		/// <param name="inputSource">输入的来源</param>
		/// <returns>插入的文档元素对象列表</returns>
		public virtual XTextElementList InsertRTF(string rtfText, bool logUndo, InputValueSource inputSource, InsertObjectEventArgs srcArgs)
		{
			int num = 4;
			if (EditorControl != null)
			{
				FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(inputSource, InputValueType.RTF, rtfText);
				EditorControl.vmethod_47(filterValueEventArgs);
				if (filterValueEventArgs.Cancel)
				{
					return null;
				}
				rtfText = (filterValueEventArgs.Value as string);
				if (string.IsNullOrEmpty(rtfText))
				{
					return null;
				}
			}
			if (rtfText == null || rtfText.Length == 0)
			{
				throw new ArgumentNullException("rtfText");
			}
			ContentSerializer serializer = AppHost.ContentSerializers.GetSerializer("rtf");
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.EnableDocumentSetting = false;
			contentSerializeOptions.ImportTemplateGenerateParagraph = false;
			contentSerializeOptions.FastMode = true;
			XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
			serializer.Deserialize(new StringReader(rtfText), xTextDocument, contentSerializeOptions);
			XTextElementList xTextElementList = xTextDocument.Body.Elements.Clone();
			XTextContainerElement xTextContainerElement = (XTextContainerElement)Document.GetCurrentElement(typeof(XTextContainerElement));
			Document.ImportElementsSpceifyImportPermssion(xTextElementList, xTextContainerElement.RuntimeEnablePermission, xTextContainerElement.RuntimeEnablePermission);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
				{
					if (xTextElementList[num2] is XTextDocumentFooterElement || xTextElementList[num2] is XTextDocumentHeaderElement)
					{
						xTextElementList.RemoveAt(num2);
					}
				}
				if (xTextElementList.Count > 0 && EditorControl != null)
				{
					FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(inputSource, InputValueType.Dom, xTextElementList);
					EditorControl.vmethod_47(filterValueEventArgs);
					if (filterValueEventArgs.Cancel)
					{
						return null;
					}
					xTextElementList = (filterValueEventArgs.Value as XTextElementList);
					if (xTextElementList == null || xTextElementList.Count == 0)
					{
						return null;
					}
				}
				if (srcArgs != null && srcArgs.CheckMaxTextLengthForCopyPaste && !Document.method_107(xTextElementList, srcArgs.ShowUI))
				{
					return null;
				}
				Document.method_106(xTextElementList);
				xTextElementList.method_0(bool_1: true);
				if (logUndo)
				{
					Document.BeginLogUndo();
				}
				if (DocumentContent.HasSelection)
				{
					Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false);
				}
				method_13(xTextElementList, bool_2: false);
				if (logUndo)
				{
					Document.EndLogUndo();
				}
				Document.OnDocumentContentChanged();
				return xTextElementList;
			}
			return null;
		}

		/// <summary>
		///       在当前位置插入RTF文档
		///       </summary>
		/// <param name="htmlText">RTF文本</param>
		/// <returns>插入的文档元素对象列表</returns>
		public XTextElementList InsertHtml(string htmlText)
		{
			return InsertHtml(htmlText, logUndo: true, InputValueSource.Unknow, null);
		}

		/// <summary>
		///       在当前位置插入RTF文档
		///       </summary>
		/// <param name="htmlText">RTF文本</param>
		/// <param name="logUndo">是否记录撤销操作</param>
		/// <param name="inputSource">输入的来源</param>
		/// <returns>插入的文档元素对象列表</returns>
		public virtual XTextElementList InsertHtml(string htmlText, bool logUndo, InputValueSource inputSource, InsertObjectEventArgs srcArgs)
		{
			int num = 18;
			if (EditorControl != null)
			{
				FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(inputSource, InputValueType.Html, htmlText);
				EditorControl.vmethod_47(filterValueEventArgs);
				if (filterValueEventArgs.Cancel)
				{
					return null;
				}
				htmlText = (filterValueEventArgs.Value as string);
				if (string.IsNullOrEmpty(htmlText))
				{
					return null;
				}
			}
			if (string.IsNullOrEmpty(htmlText))
			{
				throw new ArgumentNullException("htmlText");
			}
			ContentSerializer serializer = AppHost.ContentSerializers.GetSerializer("html");
			ContentSerializeOptions contentSerializeOptions = new ContentSerializeOptions();
			contentSerializeOptions.EnableDocumentSetting = false;
			contentSerializeOptions.ImportTemplateGenerateParagraph = false;
			contentSerializeOptions.FastMode = true;
			XTextDocument xTextDocument = (XTextDocument)Document.CreateElementByType(Document.GetType());
			serializer.Deserialize(new StringReader(htmlText), xTextDocument, contentSerializeOptions);
			XTextElementList xTextElementList = xTextDocument.Body.Elements.Clone();
			XTextContainerElement xTextContainerElement = (XTextContainerElement)Document.GetCurrentElement(typeof(XTextContainerElement));
			Document.ImportElementsSpceifyImportPermssion(xTextElementList, xTextContainerElement.RuntimeEnablePermission, xTextContainerElement.RuntimeEnablePermission);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
				{
					if (xTextElementList[num2] is XTextDocumentFooterElement || xTextElementList[num2] is XTextDocumentHeaderElement)
					{
						xTextElementList.RemoveAt(num2);
					}
				}
				if (xTextElementList.Count > 0 && EditorControl != null)
				{
					FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(inputSource, InputValueType.Dom, xTextElementList);
					EditorControl.vmethod_47(filterValueEventArgs);
					if (filterValueEventArgs.Cancel)
					{
						return null;
					}
					xTextElementList = (filterValueEventArgs.Value as XTextElementList);
					if (xTextElementList == null || xTextElementList.Count == 0)
					{
						return null;
					}
				}
				if (srcArgs != null && srcArgs.CheckMaxTextLengthForCopyPaste && !Document.method_107(xTextElementList, srcArgs.ShowUI))
				{
					return null;
				}
				Document.method_106(xTextElementList);
				xTextElementList.method_0(bool_1: true);
				if (logUndo)
				{
					Document.BeginLogUndo();
				}
				if (DocumentContent.HasSelection)
				{
					Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false);
				}
				method_13(xTextElementList, bool_2: false);
				if (logUndo)
				{
					Document.EndLogUndo();
				}
				Document.OnDocumentContentChanged();
				return xTextElementList;
			}
			return null;
		}

		/// <summary>
		///       执行删除操作
		///       </summary>
		/// <returns>本操作是否删除了元素</returns>
		public virtual bool Delete(bool showUI)
		{
			bool flag = false;
			int num = -1;
			Document.method_90();
			if (!DocumentContent.HasSelection)
			{
				XTextElement currentElement = Document.CurrentElement;
				if (currentElement is XTextFieldBorderElement)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)currentElement.Parent;
					if (xTextFieldElementBase.StartElement == currentElement && xTextFieldElementBase.Elements.Count > 0)
					{
						Document.Content.MoveToPosition(Document.Content.IndexOf(currentElement) + 1);
					}
					else if (xTextFieldElementBase.EndElement == currentElement && xTextFieldElementBase.Elements.Count > 0)
					{
						if (!Document.Options.BehaviorOptions.AllowDeleteJumpOutOfField)
						{
							method_15(bool_2: true);
							return false;
						}
						int num2 = 0;
						while (num2++ < 4 && currentElement is XTextFieldBorderElement)
						{
							XTextElement nextElement = Document.Content.GetNextElement(currentElement);
							if (nextElement == null)
							{
								break;
							}
							XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)currentElement.Parent;
							if (xTextFieldElementBase2 == null)
							{
								break;
							}
							bool flag2 = method_16(xTextFieldElementBase2);
							if (xTextFieldElementBase2.StartElement == currentElement && !flag2 && !Document.Content.Contains(xTextFieldElementBase2))
							{
								if (!Document.Content.MoveToPosition(Document.Content.IndexOf(nextElement)))
								{
									break;
								}
								currentElement = Document.CurrentElement;
								nextElement = Document.Content.GetNextElement(currentElement);
							}
							else if (xTextFieldElementBase2.EndElement == currentElement)
							{
								if (!Document.Content.MoveToPosition(Document.Content.IndexOf(nextElement)))
								{
									break;
								}
								currentElement = Document.CurrentElement;
								nextElement = Document.Content.GetNextElement(currentElement);
							}
						}
					}
				}
			}
			if (!DocumentContent.HasSelection && method_6(Content.CurrentElement, bool_2: false))
			{
				return true;
			}
			Document.BeginLogUndo();
			num = ((!DocumentContent.HasSelection) ? Content.method_32(bool_4: true) : Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false));
			Document.EndLogUndo();
			if (num >= 0)
			{
				if (num > 0)
				{
					num--;
				}
				Document.OnDocumentContentChanged();
				flag = true;
			}
			if (Document.HasContentProtectedInfos && showUI)
			{
				Document.method_91(null);
			}
			Document.ContentProtectedInfos = null;
			if (!flag)
			{
				bool flag3 = true;
				if (Content.CurrentElement is XTextFieldBorderElement && EditorControl.FormView == FormViewMode.Strict)
				{
					XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)Content.CurrentElement;
					if (xTextFieldBorderElement.Position == BorderElementPosition.End && xTextFieldBorderElement.Parent.GetOwnerParent(typeof(XTextFieldElementBase), includeThis: false) == null)
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					method_15(bool_2: true);
				}
			}
			return flag;
		}

		private bool method_6(XTextElement xtextElement_0, bool bool_2)
		{
			int num = 13;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			XTextFieldElementBase xTextFieldElementBase = null;
			if (xtextElement_0 is XTextFieldBorderElement)
			{
				xTextFieldElementBase = (xtextElement_0.Parent as XTextFieldElementBase);
			}
			if (xtextElement_0.Parent is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)xtextElement_0.Parent;
				if (xTextFieldElementBase2.IsBackgroundTextElement(xtextElement_0))
				{
					xTextFieldElementBase = xTextFieldElementBase2;
				}
			}
			if (xTextFieldElementBase == null)
			{
				return false;
			}
			bool flag = false;
			if (xTextFieldElementBase.Elements.Count == 0)
			{
				flag = true;
			}
			else
			{
				foreach (XTextElement element in xTextFieldElementBase.Elements)
				{
					if (!element.IsLogicDeleted)
					{
						return false;
					}
				}
				flag = true;
			}
			if (!flag)
			{
				return false;
			}
			if (!method_18(xTextFieldElementBase))
			{
				if (!bool_2)
				{
					method_23(Document.ContentProtectedInfos);
				}
				return false;
			}
			if (bool_2)
			{
				return true;
			}
			XTextDocumentContentElement documentContentElement = xTextFieldElementBase.DocumentContentElement;
			int num2 = documentContentElement.Content.IndexOf(xTextFieldElementBase.StartElement);
			if (num2 < 0)
			{
				documentContentElement.Content.IndexOf(xTextFieldElementBase);
			}
			if (xTextFieldElementBase.EditorDelete(logUndo: true))
			{
				if (num2 >= 0)
				{
					documentContentElement.Content.MoveToPosition(num2);
				}
				return true;
			}
			return false;
		}

		public bool method_7(bool bool_2)
		{
			if (DocumentContent.HasSelection)
			{
				method_9();
				Delete(bool_2);
				return true;
			}
			return false;
		}

		public bool method_8()
		{
			if (DocumentContent.HasSelectionWithouLogicDeleted)
			{
				return Snapshot.CanDeleteSelection;
			}
			return false;
		}

		/// <summary>
		/// 复制 Copy
		/// </summary>
		/// <returns></returns>
		public bool method_9()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_51))
			{
				return false;
			}
			IDataObject dataObject = method_12(EditorControl.CreationDataFormats, Document.Options.EditOptions.CopyInTextFormatOnly, Document.Options.EditOptions.ClearFieldValueWhenCopy, Document.Options.EditOptions.CopyWithoutInputFieldStructure, bool_5: true);
			if (dataObject != null)
			{
				EditorControl.method_26(dataObject);
				return true;
			}
			return false;
		}

		public bool method_10()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_51))
			{
				return false;
			}
			IDataObject dataObject = method_12(EditorControl.CreationDataFormats, bool_2: true, Document.Options.EditOptions.ClearFieldValueWhenCopy, Document.Options.EditOptions.CopyWithoutInputFieldStructure, bool_5: true);
			if (dataObject != null)
			{
				EditorControl.method_26(dataObject);
				return true;
			}
			return false;
		}

		public bool method_11()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_51))
			{
				return false;
			}
			IDataObject dataObject = method_12(EditorControl.CreationDataFormats, bool_2: true, bool_3: true, Document.Options.EditOptions.CopyWithoutInputFieldStructure, bool_5: true);
			if (dataObject != null)
			{
				EditorControl.method_26(dataObject);
				return true;
			}
			return false;
		}

		internal IDataObject method_12(WriterDataFormats writerDataFormats_0, bool bool_2, bool bool_3, bool bool_4, bool bool_5)
		{
			int num = 11;
			XTextSelection selection = Selection;
			if (selection != null && selection.Length != 0)
			{
				IDataObject dataObject = EditorControl.InnerViewControl.RuntimeClipboard.CreateDataObject();
				string text = selection.Text;
				if (text != null && text.Length > 0)
				{
					text = StringCommon.CompressWhiteSpace(text);
					if (text.Length > 1024)
					{
						text = text.Substring(0, 1024);
					}
					EditorControl.InnerViewControl.RuntimeClipboard.SetDataTitle(dataObject, text);
				}
				dataObject.SetData("MRID", Document.Info.MRID);
				if (EditorControl != null)
				{
					dataObject.SetData("WriterHandle", EditorControl.Handle.ToString());
				}
				if (WriterUtils.smethod_34(writerDataFormats_0, WriterDataFormats.Text) || bool_2)
				{
					dataObject.SetData(DataFormats.Text, bool_5 ? selection.TextExcludeLogicDeleted : selection.Text);
				}
				if (bool_2)
				{
					return dataObject;
				}
				if (WriterUtils.smethod_34(writerDataFormats_0, WriterDataFormats.RTF))
				{
					string rTFText = selection.GetRTFText(bool_5);
					if (rTFText != null && rTFText.Length > 0)
					{
						dataObject.SetData(DataFormats.Rtf, rTFText);
					}
				}
				if (WriterUtils.smethod_34(writerDataFormats_0, WriterDataFormats.Image) && selection.Length == 1 && selection.Mode == ContentRangeMode.Content && selection.ContentElements[0] is XTextImageElement)
				{
					XTextImageElement xTextImageElement = (XTextImageElement)selection.ContentElements[0];
					if (xTextImageElement.Image.Value != null)
					{
						dataObject.SetData(DataFormats.Bitmap, xTextImageElement.Image.Value);
					}
				}
				if (WriterUtils.smethod_34(writerDataFormats_0, WriterDataFormats.XML))
				{
					using (XTextDocument xTextDocument = selection.CreateDocument(bool_5))
					{
						if (bool_3)
						{
							foreach (XTextInputFieldElementBase item in xTextDocument.GetElementsByType(typeof(XTextInputFieldElementBase)))
							{
								item.SetInnerTextFast(null);
								item.InnerValue = null;
							}
						}
						if (bool_4)
						{
							WriterUtils.smethod_11(xTextDocument.Elements);
						}
						xTextDocument.ScriptText = null;
						StringWriter stringWriter = new StringWriter();
						xTextDocument.Save(stringWriter, "xml");
						string data = stringWriter.ToString();
						dataObject.SetData(XMLDataFormatName, data);
					}
				}
				if (WriterUtils.smethod_34(writerDataFormats_0, WriterDataFormats.Html))
				{
					GInterface5 gInterface = Document.AppHost.Tools.CreateWriterHtmlDocumentWriter();
					gInterface.imethod_40().Add(Document);
					gInterface.imethod_46().method_3(bool_9: true);
					gInterface.imethod_46().method_15(bool_9: true);
					gInterface.imethod_46().vmethod_1(bool_9: true);
					gInterface.imethod_49(bool_0: true);
					gInterface.imethod_39(bool_5);
					gInterface.imethod_46().method_13(bool_9: false);
					gInterface.imethod_12(bool_0: false);
					gInterface.imethod_43(GEnum12.const_0);
					gInterface.imethod_10();
					string text2 = gInterface.imethod_9();
					if (text2 != null && text2.Length > 0)
					{
						dataObject.SetData(DataFormats.Html, text2);
					}
				}
				return dataObject;
			}
			return null;
		}

		/// <summary>
		///       在文档中的当前未知插入文本
		///       </summary>
		/// <param name="strText">要插入的文本</param>
		/// <returns>插入的文档元素对象列表</returns>
		public XTextElementList InsertString(string strText)
		{
			return InsertString(strText, logUndo: true, InputValueSource.Unknow, null, null);
		}

		/// <summary>
		///       执行在当前位置插入一个字符串的操作
		///       </summary>
		/// <param name="strText">要插入的字符串值</param>
		/// <param name="logUndo">是否记录操作过程</param>
		/// <param name="inputSource">来源</param>
		/// <param name="textStyle">字符样式</param>
		/// <param name="paragraphStyle">段落样式</param>
		/// <returns>插入的文档元素对象列表</returns>
		public virtual XTextElementList InsertString(string strText, bool logUndo, InputValueSource inputSource, DocumentContentStyle textStyle, DocumentContentStyle paragraphStyle)
		{
			int num = 13;
			bool autoUppercaseFirstCharInFirstLineOnce = AutoUppercaseFirstCharInFirstLineOnce;
			float tickCountFloat = CountDown.GetTickCountFloat();
			if (EditorControl != null)
			{
				FilterValueEventArgs filterValueEventArgs = new FilterValueEventArgs(inputSource, InputValueType.Text, strText);
				EditorControl.vmethod_47(filterValueEventArgs);
				if (filterValueEventArgs.Cancel)
				{
					return null;
				}
				strText = (filterValueEventArgs.Value as string);
			}
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			if (textStyle == null)
			{
				textStyle = Document.CurrentStyleInfo.ContentStyleForNewString;
			}
			if (paragraphStyle == null)
			{
				paragraphStyle = Document.CurrentStyleInfo.Paragraph;
				if (paragraphStyle.ParagraphOutlineLevel >= 0 && paragraphStyle.ParagraphListStyle != 0)
				{
				}
			}
			XTextContainerElement xTextContainerElement = (XTextContainerElement)Document.GetCurrentElement(typeof(XTextContainerElement));
			if (inputSource == InputValueSource.UI && strText == "\t" && !xTextContainerElement.AcceptTab)
			{
				return null;
			}
			XTextElementList xTextElementList = Document.CreateTextElementsExt(strText, paragraphStyle, textStyle, xTextContainerElement.RuntimeEnablePermission);
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				return null;
			}
			xTextElementList.method_0(bool_1: true);
			XTextCharElement xTextCharElement = null;
			if (autoUppercaseFirstCharInFirstLineOnce)
			{
				_ = Document.CurrentContentElement.CurrentLine;
				XTextElement xTextElement = null;
				xTextElement = ((Selection.Length != 0) ? Selection.FirstElement : Document.CurrentElement);
				if (xTextElement != null && xTextElement.OwnerLine != null)
				{
					XTextLine ownerLine = xTextElement.OwnerLine;
					if (ownerLine.IndexInParagraph == 0)
					{
						foreach (XTextElement item in ownerLine)
						{
							if (item.IsLogicDeleted)
							{
								xTextCharElement = null;
								break;
							}
							if (item is XTextCharElement)
							{
								char charValue = ((XTextCharElement)item).CharValue;
								if (charValue >= 'a' && charValue <= 'z')
								{
									if (xTextCharElement == null)
									{
										xTextCharElement = (XTextCharElement)item;
									}
								}
								else if (!char.IsLetter(charValue))
								{
									xTextCharElement = null;
									break;
								}
							}
							else if (xTextCharElement == null)
							{
								break;
							}
							if (item == xTextElement)
							{
								break;
							}
						}
					}
					if (xTextCharElement != null && !CanModify(xTextCharElement))
					{
						xTextCharElement = null;
					}
				}
			}
			if (logUndo)
			{
				Document.BeginLogUndo();
			}
			if (DocumentContent.HasSelection)
			{
				int num2 = Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false);
				if (num2 > 0)
				{
					Document.Modified = true;
				}
			}
			else if (EditorControl != null && !EditorControl.InsertMode)
			{
				int num2 = Content.method_32(bool_4: true);
				if (num2 > 0)
				{
					Document.Modified = true;
				}
			}
			if (xTextElementList.Count == 1 && xTextElementList[0] is XTextParagraphFlagElement && (Document.IsCurrentPositionAtFirstCell || Document.IsCurrentPositionAtFirstSection))
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElementList[0];
				DocumentContentStyle documentContentStyle = new DocumentContentStyle();
				documentContentStyle.Align = DocumentContentAlignment.Left;
				xTextParagraphFlagElement.StyleIndex = Document.ContentStyles.GetStyleIndex(documentContentStyle);
			}
			DocumentContentStyle content = Document.CurrentStyleInfo.Content;
			DocumentContentStyle contentStyleForNewString = Document.CurrentStyleInfo.ContentStyleForNewString;
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			tickCountFloat = CountDown.GetTickCountFloat();
			int num3 = Document.InsertElements(xTextElementList, updateContent: true);
			_ = CountDown.GetTickCountFloat() - tickCountFloat;
			tickCountFloat = CountDown.GetTickCountFloat();
			if (xTextCharElement != null && !StringFormatHelper.IsEnglishLetter(strText[0]) && xTextCharElement != null)
			{
				char c = char.ToUpper(xTextCharElement.CharValue);
				char charValue2 = xTextCharElement.CharValue;
				xTextCharElement.CharValue = c;
				if (logUndo && Document.UndoList.method_15())
				{
					Document.UndoList.AddProperty("CharValue", charValue2, c, xTextCharElement);
				}
				xTextCharElement.EditorRefreshView();
				Document.OnSelectionChanged();
			}
			if (logUndo)
			{
				Document.EndLogUndo();
			}
			if (Document.FixCurrentStyleInfoForEnter && content != Document.CurrentStyleInfo.Content)
			{
				Document.CurrentStyleInfo.Content = content;
				Document.CurrentStyleInfo.method_0(Document);
				Document.CurrentStyleInfo.ContentStyleForNewString = contentStyleForNewString;
				Document.OnSelectionChanged();
			}
			Document.Modified = true;
			if (num3 > 0)
			{
				Document.OnDocumentContentChanged();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				return xTextElementList;
			}
			return null;
		}

		/// <summary>
		///       插入一个换行元素
		///       </summary>
		public virtual XTextLineBreakElement InsertLineBreak()
		{
			Document.BeginLogUndo();
			XTextLineBreakElement xTextLineBreakElement = (XTextLineBreakElement)Document.CreateElementByType(typeof(XTextLineBreakElement));
			using (DCGraphics dcgraphics_ = Document.CreateDCGraphics())
			{
				DocumentPaintEventArgs documentPaintEventArgs = Document.method_55(dcgraphics_);
				documentPaintEventArgs.Element = xTextLineBreakElement;
				xTextLineBreakElement.RefreshSize(documentPaintEventArgs);
			}
			xTextLineBreakElement.vmethod_0(bool_5: true);
			Document.InsertElement(xTextLineBreakElement);
			Document.EndLogUndo();
			Document.OnDocumentContentChanged();
			return xTextLineBreakElement;
		}

		/// <summary>
		///       对文档进行签名锁定
		///       </summary>
		/// <returns>操作生成的签名元素对象</returns>
		public virtual XTextSignElement SignDocument()
		{
			Document.BeginLogUndo();
			XTextSignElement xTextSignElement = new XTextSignElement();
			xTextSignElement.OwnerDocument = Document;
			using (DCGraphics dcgraphics_ = Document.CreateDCGraphics())
			{
				DocumentPaintEventArgs documentPaintEventArgs = Document.method_55(dcgraphics_);
				documentPaintEventArgs.Element = xTextSignElement;
				xTextSignElement.RefreshSize(documentPaintEventArgs);
			}
			Document.Body.SetSelection(Document.Body.Content.Count - 1, 0);
			Document.InsertElement(xTextSignElement);
			Document.EndLogUndo();
			Document.OnDocumentContentChanged();
			return xTextSignElement;
		}

		/// <summary>
		///       向文档插入一个字符
		///       </summary>
		/// <param name="vChar">字符</param>
		public virtual bool InsertChar(char vChar)
		{
			int num = 6;
			if (vChar == '\n')
			{
				return false;
			}
			if (vChar < ' ' && vChar != '\t' && vChar != '\r')
			{
				return false;
			}
			XTextElementList xTextElementList;
			if (vChar == '\r')
			{
				XTextParagraphFlagElement ownerParagraphEOF = Content.CurrentElement.OwnerParagraphEOF;
				if (ownerParagraphEOF == null)
				{
					throw new Exception("未找到所属段落");
				}
				XTextLine currentLine = Content.CurrentLine;
				int num2 = currentLine.IndexOf(Content.CurrentElement);
				StringBuilder stringBuilder = new StringBuilder();
				if (num2 > 0)
				{
					for (int i = 0; i < num2; i++)
					{
						if (currentLine[i] is XTextCharElement && ((XTextCharElement)currentLine[i]).CharValue == ' ')
						{
							stringBuilder.Append(" ");
							continue;
						}
						stringBuilder = new StringBuilder();
						break;
					}
				}
				stringBuilder.Insert(0, vChar);
				xTextElementList = InsertString(stringBuilder.ToString(), logUndo: true, InputValueSource.UI, null, null);
				return xTextElementList != null && xTextElementList.Count > 0;
			}
			xTextElementList = InsertString(vChar.ToString(), logUndo: true, InputValueSource.UI, null, null);
			return xTextElementList != null && xTextElementList.Count > 0;
		}

		/// <summary>
		///       在当前插入点插入一个元素
		///       </summary>
		/// <param name="element">要插入的元素</param>
		/// <returns>操作是否成功</returns>
		public bool InsertElement(XTextElement element)
		{
			if (element != null)
			{
				element.vmethod_0(bool_5: true);
				element.OwnerDocument = Document;
				Document.BeginLogUndo();
				if (element.SizeInvalid)
				{
					using (DCGraphics dcgraphics_ = Document.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = Document.method_55(dcgraphics_);
						documentPaintEventArgs.Element = element;
						element.RefreshSize(documentPaintEventArgs);
					}
				}
				bool result = Document.InsertElement(element);
				if (Document.ScriptEngine != null)
				{
					Document.ScriptEngine.CheckVBScriptInvalidte(element);
				}
				Document.EndLogUndo();
				Document.OnDocumentContentChanged();
				if (element.vmethod_1(bool_5: true) && !Document.Options.BehaviorOptions.DesignMode)
				{
					Document.StartScriptEngine();
				}
				return result;
			}
			return false;
		}

		/// <summary>
		///       在当前插入点处插入若干个元素
		///       </summary>
		/// <param name="list">要插入的元素的列表</param>
		/// <remarks>插入的元素个数</remarks>
		public int InsertElements(XTextElementList list)
		{
			list?.method_0(bool_1: true);
			return method_14(null, list, bool_2: true, bool_3: false);
		}

		private int method_13(XTextElementList xtextElementList_0, bool bool_2)
		{
			return method_14(null, xtextElementList_0, bool_2, bool_3: false);
		}

		private int method_14(XTextElement xtextElement_0, XTextElementList xtextElementList_0, bool bool_2, bool bool_3)
		{
			if (xtextElementList_0 == null || xtextElementList_0.Count == 0)
			{
				return 0;
			}
			WriterUtils.smethod_62(xtextElementList_0, bool_2: true);
			vmethod_6(xtextElementList_0);
			if (!bool_3 && bool_2)
			{
				Document.BeginLogUndo();
			}
			GClass101 gClass = new GClass101();
			gClass.method_1(xtextElement_0);
			gClass.method_3(xtextElementList_0);
			gClass.method_5(bool_3: true);
			gClass.method_7(bool_3);
			Document.method_62(xtextElementList_0);
			int result = Document.InsertElements(gClass);
			if (!bool_3)
			{
				if (Document.ScriptEngine != null)
				{
					foreach (XTextElement item in xtextElementList_0)
					{
						if (Document.ScriptEngine.CheckVBScriptInvalidte(item))
						{
							break;
						}
					}
				}
				Document.Modified = true;
				if (bool_2)
				{
					Document.EndLogUndo();
				}
				if (!Document.Options.BehaviorOptions.DesignMode)
				{
					foreach (XTextElement item2 in xtextElementList_0)
					{
						if (item2.vmethod_1(bool_5: true))
						{
							Document.StartScriptEngine();
							break;
						}
					}
				}
			}
			return result;
		}

		public virtual bool vmethod_5(XTextElementList xtextElementList_0)
		{
			int num = 6;
			if (xtextElementList_0 == null)
			{
				throw new ArgumentNullException("elements");
			}
			XTextElement firstContentElement = xtextElementList_0.FirstContentElement;
			XTextElement lastContentElement = xtextElementList_0.LastContentElement;
			XTextDocumentContentElement documentContentElement = firstContentElement.DocumentContentElement;
			if (documentContentElement != null)
			{
				int num2 = documentContentElement.Content.IndexOf(firstContentElement);
				int num3 = documentContentElement.Content.IndexOf(lastContentElement);
				if (num2 >= 0 && num3 >= num2)
				{
					documentContentElement.SetSelection(num2, num3 - num2 + 1);
					return true;
				}
			}
			return false;
		}

		public virtual void vmethod_6(XTextElementList xtextElementList_0)
		{
			int num = 0;
			if (xtextElementList_0 == null)
			{
				throw new ArgumentNullException("list");
			}
			if (xtextElementList_0.Count != 0)
			{
				using (DCGraphics dcgraphics_ = Document.CreateDCGraphics())
				{
					foreach (XTextElement item in xtextElementList_0)
					{
						item.OwnerDocument = Document;
						item.FixDomState();
						DocumentPaintEventArgs documentPaintEventArgs = Document.method_55(dcgraphics_);
						documentPaintEventArgs.Element = item;
						item.RefreshSize(documentPaintEventArgs);
						if (item is XTextImageElement)
						{
							XTextImageElement xTextImageElement = (XTextImageElement)item;
							WriterCommandModule.CheckImageSizeWhenInsertImage(Document, xTextImageElement, xTextImageElement.RuntimeKeepWidthHeightRate, null);
						}
						else if (item is XTextTableElement)
						{
							WriterCommandModule.CheckTableWidthWhenInsertTable(Document, (XTextTableElement)item);
						}
					}
				}
			}
		}

		private void method_15(bool bool_2)
		{
			if (!Document.Options.BehaviorOptions.AllowDeleteJumpOutOfField || Document.Content.SelectionLength != 0)
			{
				return;
			}
			bool flag = true;
			bool flag2 = true;
			if (EditorControl.FormView == FormViewMode.Strict)
			{
				if (Content.PreElement is XTextFieldBorderElement)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = Content.PreElement.Parent as XTextInputFieldElementBase;
					if (xTextInputFieldElementBase != null && xTextInputFieldElementBase.IsTopLevelField)
					{
						flag = false;
					}
				}
				if (Content.CurrentElement is XTextFieldBorderElement)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = Content.CurrentElement.Parent as XTextInputFieldElementBase;
					if (xTextInputFieldElementBase != null && xTextInputFieldElementBase.IsTopLevelField)
					{
						flag2 = false;
					}
				}
			}
			XTextLine currentLine = Document.Content.CurrentLine;
			if (currentLine != null && currentLine.RuntimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
			{
				if (bool_2)
				{
					if (flag)
					{
						Document.Content.MoveLeft();
					}
				}
				else if (flag2)
				{
					Document.Content.MoveRight();
				}
			}
			else if (bool_2)
			{
				if (flag2)
				{
					Document.Content.MoveRight();
				}
			}
			else if (flag)
			{
				Document.Content.MoveLeft();
			}
		}

		private bool method_16(XTextFieldElementBase xtextFieldElementBase_0)
		{
			XTextDocumentContentElement documentContentElement = xtextFieldElementBase_0.DocumentContentElement;
			if (documentContentElement != null && documentContentElement.Content.IndexOf(xtextFieldElementBase_0.EndElement) - documentContentElement.Content.IndexOf(xtextFieldElementBase_0.StartElement) == 1)
			{
				return true;
			}
			return false;
		}

		public virtual bool vmethod_7(bool bool_2)
		{
			if (EditorControlReadonly)
			{
				return false;
			}
			Document.method_90();
			int num = -1;
			Document.BeginLogUndo();
			if (!DocumentContent.HasSelection)
			{
				XTextElement currentElement = Document.CurrentElement;
				XTextElement preElement = Document.Content.GetPreElement(currentElement);
				if (preElement != null)
				{
					if (preElement is XTextFieldBorderElement)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)preElement.Parent;
						if (xTextFieldElementBase.StartElement == preElement)
						{
							if (!method_16(xTextFieldElementBase))
							{
								if (EditorControl.FormView == FormViewMode.Strict && xTextFieldElementBase.GetOwnerParent(typeof(XTextInputFieldElementBase), includeThis: false) == null)
								{
									Document.method_90();
									return false;
								}
								method_15(bool_2: false);
								Document.method_90();
								return false;
							}
							bool result;
							if (!(result = method_6(preElement, bool_2: false)))
							{
								method_15(bool_2: false);
							}
							Document.method_90();
							return result;
						}
					}
					int num2 = 0;
					while (preElement is XTextFieldBorderElement && num2++ <= 4)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)preElement.Parent;
						if (xTextFieldElementBase == null)
						{
							break;
						}
						bool flag = method_16(xTextFieldElementBase);
						if (xTextFieldElementBase.EndElement == preElement && !flag && !Document.Content.Contains(xTextFieldElementBase))
						{
							if (!Document.Content.MoveToPosition(Document.Content.IndexOf(preElement)))
							{
								break;
							}
							currentElement = Document.CurrentElement;
							preElement = Document.Content.GetPreElement(currentElement);
						}
						else
						{
							if (xTextFieldElementBase.StartElement != preElement || flag || Document.Content.Contains(xTextFieldElementBase) || !Document.Content.MoveToPosition(Document.Content.IndexOf(preElement)))
							{
								break;
							}
							currentElement = Document.CurrentElement;
							preElement = Document.Content.GetPreElement(currentElement);
						}
					}
				}
				if (preElement != null)
				{
					contentProtectedInfo_0 = null;
					if (method_6(preElement, bool_2: false))
					{
						Document.method_90();
						return true;
					}
					if (Document.HasContentProtectedInfos)
					{
						if (bool_2)
						{
							Document.method_91(null);
						}
						Document.ContentProtectedInfos = null;
						method_15(bool_2: false);
						return false;
					}
				}
				if (method_17(bool_2: false))
				{
					return true;
				}
			}
			Document.ContentProtectedInfos = null;
			if (DocumentContent.HasSelection)
			{
				if (Content.Selection.Mode != ContentRangeMode.Cell)
				{
				}
				int absStartIndex = Content.Selection.AbsStartIndex;
				try
				{
					EditorControl.InnerViewControl.bool_30 = true;
					num = Content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false);
				}
				finally
				{
					EditorControl.InnerViewControl.bool_30 = false;
				}
				if (num > 0)
				{
					Content.method_47(absStartIndex, 0);
					EditorControl.InnerViewControl.method_164();
				}
				else
				{
					EditorControl.InnerViewControl.method_166();
				}
			}
			else
			{
				try
				{
					EditorControl.InnerViewControl.bool_30 = true;
					num = Content.method_29(bool_4: true);
					if (num < 0)
					{
						method_15(bool_2: false);
					}
				}
				finally
				{
					EditorControl.InnerViewControl.bool_30 = false;
				}
				if (num > 0)
				{
					EditorControl.InnerViewControl.method_164();
				}
				else
				{
					EditorControl.InnerViewControl.method_166();
				}
			}
			bool result2 = false;
			if (num >= 0)
			{
				Document.EndLogUndo();
				Document.OnSelectionChanged();
				Document.OnDocumentContentChanged();
				result2 = true;
			}
			else
			{
				Document.EndLogUndo();
			}
			if (Document.HasContentProtectedInfos && bool_2)
			{
				Document.method_91(null);
			}
			Document.ContentProtectedInfos = null;
			return result2;
		}

		internal bool method_17(bool bool_2)
		{
			XTextElement currentElement = Document.CurrentElement;
			if (currentElement == null)
			{
				return false;
			}
			XTextParagraphFlagElement ownerParagraphEOF = currentElement.OwnerParagraphEOF;
			_ = ownerParagraphEOF.DocumentContentElement;
			if (ownerParagraphEOF != null && currentElement == ownerParagraphEOF.ParagraphFirstContentElement && CanModify(ownerParagraphEOF, DomAccessFlags.Normal))
			{
				DocumentContentStyle documentContentStyle = ownerParagraphEOF.RuntimeStyle.CloneParent();
				documentContentStyle.DisableDefaultValue = true;
				bool flag = false;
				bool flag2 = false;
				if (bool_2)
				{
					XTextContentElement contentElement = ownerParagraphEOF.ContentElement;
					float num = 0f;
					num = ((contentElement != null) ? (contentElement.ClientWidth - 100f) : (Document.Body.ClientWidth - 100f));
					if (num < 0f)
					{
						num = 0f;
					}
					float num2 = documentContentStyle.FirstLineIndent;
					float num3 = documentContentStyle.LeftIndent;
					if (documentContentStyle.FirstLineIndent >= 90f)
					{
						num3 += 100f;
					}
					else
					{
						num2 += 100f;
					}
					if (num3 > num)
					{
						num3 = num;
					}
					if (num2 > num)
					{
						num2 = num;
					}
					if (num3 + num2 > num)
					{
						num2 = 0f;
						num3 = num;
					}
					if (documentContentStyle.FirstLineIndent != num2)
					{
						documentContentStyle.FirstLineIndent = num2;
						flag = true;
					}
					if (documentContentStyle.LeftIndent != num3)
					{
						documentContentStyle.LeftIndent = num3;
						flag = true;
					}
				}
				else if (documentContentStyle.ParagraphListStyle != 0)
				{
					flag = true;
					if (documentContentStyle.IsListNumberStyle)
					{
						flag2 = true;
					}
					documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
					documentContentStyle.LeftIndent = 0f;
					documentContentStyle.FirstLineIndent = 0f;
					if (documentContentStyle.ParagraphOutlineLevel >= 0)
					{
						documentContentStyle = (DocumentContentStyle)Document.DefaultStyle.Clone();
					}
				}
				else if (documentContentStyle.Align == DocumentContentAlignment.Right)
				{
					flag = true;
					documentContentStyle.Align = DocumentContentAlignment.Center;
				}
				else if (documentContentStyle.Align == DocumentContentAlignment.Center)
				{
					flag = true;
					documentContentStyle.Align = DocumentContentAlignment.Left;
				}
				else if (documentContentStyle.FirstLineIndent + documentContentStyle.LeftIndent < 30f && documentContentStyle.FirstLineIndent != 0f)
				{
					documentContentStyle.FirstLineIndent = 0f;
					documentContentStyle.LeftIndent = 0f;
					flag = true;
				}
				else if (documentContentStyle.FirstLineIndent > 0f)
				{
					documentContentStyle.FirstLineIndent -= 100f;
					if (documentContentStyle.FirstLineIndent < 0f)
					{
						documentContentStyle.FirstLineIndent = 0f;
					}
					flag = true;
				}
				else
				{
					float leftIndent = documentContentStyle.LeftIndent;
					documentContentStyle.LeftIndent -= 100f;
					if (documentContentStyle.LeftIndent < 0f)
					{
						documentContentStyle.LeftIndent = 0f;
					}
					flag = (leftIndent != documentContentStyle.LeftIndent);
				}
				if (flag)
				{
					Document.CurrentStyleInfo = null;
					documentContentStyle.CreatorIndex = Document.UserHistories.CurrentIndex;
					int styleIndex = Document.ContentStyles.GetStyleIndex(documentContentStyle);
					if (Document.BeginLogUndo())
					{
						Document.UndoList.AddStyleIndex(ownerParagraphEOF, ownerParagraphEOF.StyleIndex, styleIndex);
					}
					ownerParagraphEOF.StyleIndex = styleIndex;
					ownerParagraphEOF.UpdateContentVersion();
					XTextElementList xTextElementList = new XTextElementList();
					xTextElementList.Add(ownerParagraphEOF.ParagraphFirstContentElement);
					xTextElementList.Add(ownerParagraphEOF.LastContentElement);
					if (flag2)
					{
						ownerParagraphEOF.DocumentContentElement.ParagraphTreeInvalidte = true;
						ownerParagraphEOF.DocumentContentElement.method_57(bool_23: false, bool_24: true);
						if (Document.CanLogUndo)
						{
							Document.UndoList.AddMethod(UndoMethodTypes.RefreshParagraphTree);
						}
					}
					WriterUtils.smethod_20(Document, new XTextElementList(ownerParagraphEOF), bool_2: false);
					ownerParagraphEOF.SizeInvalid = true;
					ownerParagraphEOF.ContentElement.method_32(xTextElementList, bool_22: true, bool_23: false);
					EditorControl.UpdateTextCaret();
					Document.OnSelectionChanged();
					Document.EndLogUndo();
					EditorControl.method_16();
					EditorControl.vmethod_12();
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       判断能否修改被选择的内容
		///       </summary>
		public virtual bool CanModifySelection(bool checkContentProtect)
		{
			if (EditorControl != null && EditorControl.BackgroundMode)
			{
				return true;
			}
			if (EditorControlReadonly)
			{
				return false;
			}
			DomAccessFlags domAccessFlags = DomAccessFlags.Normal;
			if (!checkContentProtect)
			{
				domAccessFlags = (DomAccessFlags)MathCommon.smethod_25((int)domAccessFlags, 64, bool_0: false);
			}
			if (Selection.Length == 0)
			{
				if (checkContentProtect && !IsAdministrator)
				{
					XTextElement currentElement = Document.CurrentElement;
					if (currentElement == null)
					{
						return false;
					}
					XTextElement preElement = Document.Content.GetPreElement(currentElement);
					if (preElement != null && preElement.ContentElement == currentElement.ContentElement)
					{
						if (preElement.RuntimeStyle.ProtectType == ContentProtectType.Range && currentElement.RuntimeStyle.ProtectType == ContentProtectType.Range)
						{
							return false;
						}
					}
					else if (currentElement.RuntimeStyle.ProtectType == ContentProtectType.Range)
					{
						return false;
					}
				}
				XTextContainerElement container = null;
				int elementIndex = 0;
				Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				if (container != null && !IsAdministrator && container.RuntimeContentReadonly)
				{
					return false;
				}
				if (container is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)container;
					return xTextInputFieldElementBase.RuntimeUserEditable;
				}
				domAccessFlags &= ~DomAccessFlags.CheckContainerReadonly;
				return CanModifyContent(container, domAccessFlags);
			}
			foreach (XTextElement contentElement in Selection.ContentElements)
			{
				if (CanModify(contentElement, domAccessFlags))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       判断指定的元素能否被修改
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>元素能否被修改</returns>
		public virtual bool CanModify(XTextElement element)
		{
			return CanModify(element, DomAccessFlags.Normal);
		}

		/// <summary>
		///       判断指定的元素能否被修改
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <param name="flags">访问标记</param>
		/// <returns>元素能否被修改</returns>
		public virtual bool CanModify(XTextElement element, DomAccessFlags flags)
		{
			ElementStateDetectEventArgs elementStateDetectEventArgs = new ElementStateDetectEventArgs(element, flags);
			CanModify(elementStateDetectEventArgs);
			return elementStateDetectEventArgs.Result;
		}

		/// <summary>
		///       判断指定的元素的内容能否被修改
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <param name="flags">访问标记</param>
		/// <returns>元素能否被修改</returns>
		public virtual bool CanModifyContent(XTextElement element, DomAccessFlags flags)
		{
			ElementStateDetectEventArgs elementStateDetectEventArgs = new ElementStateDetectEventArgs(element, flags);
			elementStateDetectEventArgs.ForContent = true;
			CanModify(elementStateDetectEventArgs);
			return elementStateDetectEventArgs.Result;
		}

		/// <summary>
		///       判断能否修改文档元素
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void CanModify(ElementStateDetectEventArgs args)
		{
			int num = 12;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (args.Element == null)
			{
				throw new ArgumentNullException("args.Element");
			}
			args.Flags = method_19(args.Flags);
			if (args.Flags == DomAccessFlags.None)
			{
				args.Result = true;
				return;
			}
			if (EditorControl != null && EditorControl.BackgroundMode)
			{
				args.Result = true;
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckControlReadonly) && EditorControlReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.EditControlReadonly;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ControlReadonly);
				args.Result = false;
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckFormView) && (FormView == FormViewMode.Normal || FormView == FormViewMode.Strict) && !(args.Element is XTextCheckBoxElement) && !(args.Element is XTextInputFieldElementBase) && !(args.Element is XTextRadioBoxElement) && !method_20(args.Element))
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyFormViewMode;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.FormViewMode);
				args.Result = false;
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckLock) && !IsAdministrator)
			{
				XTextDocumentContentElement documentContentElement = args.Element.DocumentContentElement;
				if (documentContentElement != null)
				{
					int num2 = 0;
					if (args.Element is XTextParagraphFlagElement)
					{
						num2 = args.Element.ViewIndex;
					}
					else
					{
						XTextElement lastContentElementInPublicContent = args.Element.LastContentElementInPublicContent;
						if (lastContentElementInPublicContent == null)
						{
							args.Result = false;
							return;
						}
						num2 = lastContentElementInPublicContent.ViewIndex;
					}
					if (documentContentElement.Content.LockIndex >= 0 && documentContentElement.Content.method_17(num2))
					{
						if (args.SetMessage)
						{
							args.Message = WriterStringsCore.ReadonlyContentLocked;
						}
						method_21(args.Element, args.Message, ContentProtectedReason.Lock);
						args.Result = false;
						return;
					}
				}
			}
			if (method_27(args.Flags, DomAccessFlags.CheckPermission) && !IsAdministrator && !(AppHost.PermissionControler?.CanModify(Document, args.Element.RuntimeStyle.CreatorIndex, args.Element.RuntimeStyle.DeleterIndex) ?? true))
			{
				if (args.SetMessage)
				{
					if (!string.IsNullOrEmpty(AppHost.PermissionControler.LastMessage))
					{
						args.Message = AppHost.PermissionControler.LastMessage;
					}
					else
					{
						args.Message = WriterStringsCore.ReadonlyPermission;
					}
				}
				if (args.Element.RuntimeStyle.DeleterIndex >= 0)
				{
					method_21(args.Element, args.Message, ContentProtectedReason.LogicDeleteAgain);
				}
				else
				{
					method_21(args.Element, args.Message, ContentProtectedReason.Permission);
				}
				args.Result = false;
				return;
			}
			if (!IsAdministrator && (args.Flags & DomAccessFlags.CheckContentProtect) == DomAccessFlags.CheckContentProtect)
			{
				ContentProtectType protectType = args.Element.RuntimeStyle.ProtectType;
				if (protectType == ContentProtectType.Content || protectType == ContentProtectType.Range)
				{
					if (args.SetMessage)
					{
						args.Message = WriterStringsCore.ReadonlyContentProtect;
					}
					method_21(args.Element, args.Message, ContentProtectedReason.ContentProtectStyle);
					args.Result = false;
					return;
				}
			}
			if (Document.Options.BehaviorOptions.EnableElementEvents)
			{
				ElementEventTemplateList events = args.Element.Events;
				if (events != null && events.HasQueryState)
				{
					ElementQueryStateEventArgs elementQueryStateEventArgs = new ElementQueryStateEventArgs(args.Element);
					elementQueryStateEventArgs.AccessFlags = args.Flags;
					events.OnQueryState(this, elementQueryStateEventArgs);
					if (elementQueryStateEventArgs.PropertyReadonly)
					{
						if (args.SetMessage)
						{
							args.Message = elementQueryStateEventArgs.Message;
							if (string.IsNullOrEmpty(args.Message))
							{
								args.Message = WriterStringsCore.ReadonlyUserEvent;
							}
						}
						method_21(args.Element, args.Message, ContentProtectedReason.UserEvent);
						args.Result = false;
						return;
					}
				}
			}
			if (!IsAdministrator)
			{
				XTextContainerElement xTextContainerElement = null;
				if (args.ForContent && args.Element is XTextContainerElement)
				{
					xTextContainerElement = (XTextContainerElement)args.Element;
				}
				if (xTextContainerElement == null)
				{
					xTextContainerElement = args.Element.Parent;
				}
				if (xTextContainerElement != null && xTextContainerElement.RuntimeContentReadonly && method_27(args.Flags, DomAccessFlags.CheckReadonly))
				{
					if (args.SetMessage)
					{
						args.Message = WriterStringsCore.ReadonlyContainerReadonly;
					}
					method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
					args.Result = false;
					return;
				}
				if ((xTextContainerElement == null || xTextContainerElement.ContentReadonly != ContentReadonlyState.False) && args.Element.Parent != null && args.Element.Parent.RuntimeContentReadonly && method_27(args.Flags, DomAccessFlags.CheckContainerReadonly))
				{
					if (args.SetMessage)
					{
						args.Message = WriterStringsCore.ReadonlyContainerReadonly;
					}
					method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
					args.Result = false;
					return;
				}
			}
			XTextElement xTextElement = args.Element;
			bool flag = false;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement is XTextContainerElement && method_27(args.Flags, DomAccessFlags.CheckReadonly) && !flag)
					{
						flag = true;
						if (!((XTextContainerElement)xTextElement).ContentEditable && !IsAdministrator)
						{
							if (args.SetMessage)
							{
								args.Message = WriterStringsCore.ReadonlyContainerReadonly;
							}
							args.Result = false;
							method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
							return;
						}
					}
					if (!(xTextElement is XTextFieldElementBase))
					{
					}
					if (xTextElement is XTextInputFieldElementBase && xTextElement != args.Element)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement;
						if (xTextInputFieldElementBase.StartElement != args.Element && xTextInputFieldElementBase.EndElement != args.Element && method_27(args.Flags, DomAccessFlags.CheckUserEditable) && !xTextInputFieldElementBase.RuntimeUserEditable && !IsAdministrator)
						{
							if (args.SetMessage)
							{
								args.Message = string.Format(WriterStringsCore.ReadonlyInputFieldUserEditable_ID, xTextInputFieldElementBase.DisplayName);
							}
							method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
							args.Result = false;
							return;
						}
					}
					if (Document.Options.BehaviorOptions.EnableElementEvents)
					{
						ElementEventTemplateList events2 = xTextElement.Events;
						if (events2 != null && events2.HasQueryState && Document.Options.BehaviorOptions.EnableElementEvents)
						{
							ElementQueryStateEventArgs elementQueryStateEventArgs = new ElementQueryStateEventArgs(xTextElement);
							elementQueryStateEventArgs.AccessFlags = args.Flags;
							events2.OnQueryState(this, elementQueryStateEventArgs);
							if (elementQueryStateEventArgs.ContentReadonly)
							{
								break;
							}
						}
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				args.Result = true;
				return;
			}
			if (args.SetMessage)
			{
				args.Message = WriterStringsCore.ReadonlyContainerReadonly;
			}
			method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
			args.Result = false;
		}

		public bool method_18(XTextElement xtextElement_0)
		{
			return CanDelete(xtextElement_0, DomAccessFlags.Normal);
		}

		private DomAccessFlags method_19(DomAccessFlags domAccessFlags_0)
		{
			if ((domAccessFlags_0 & DomAccessFlags.CheckPermission) == DomAccessFlags.CheckPermission && !XTextDocument.smethod_13(GEnum6.const_133))
			{
				domAccessFlags_0 &= ~DomAccessFlags.CheckPermission;
			}
			if ((domAccessFlags_0 & DomAccessFlags.CheckContentProtect) == DomAccessFlags.CheckContentProtect && !XTextDocument.smethod_13(GEnum6.const_134))
			{
				domAccessFlags_0 &= ~DomAccessFlags.CheckContentProtect;
			}
			if ((domAccessFlags_0 & DomAccessFlags.CheckLock) == DomAccessFlags.CheckLock && !XTextDocument.smethod_13(GEnum6.const_137))
			{
				domAccessFlags_0 &= ~DomAccessFlags.CheckLock;
			}
			if ((domAccessFlags_0 & DomAccessFlags.CheckControlReadonly) == DomAccessFlags.CheckControlReadonly && !XTextDocument.smethod_13(GEnum6.const_136))
			{
				domAccessFlags_0 &= ~DomAccessFlags.CheckControlReadonly;
			}
			return domAccessFlags_0;
		}

		private bool method_20(XTextElement xtextElement_0)
		{
			bool result = false;
			XTextElement parent = xtextElement_0.Parent;
			while (parent != null)
			{
				if (!(parent is XTextInputFieldElementBase))
				{
					parent = parent.Parent;
					continue;
				}
				result = true;
				break;
			}
			return result;
		}

		private void method_21(XTextElement xtextElement_0, string string_4, ContentProtectedReason contentProtectedReason_0)
		{
			contentProtectedInfo_0 = new ContentProtectedInfo(xtextElement_0, string_4, contentProtectedReason_0);
		}

		internal ContentProtectedInfo method_22()
		{
			if (contentProtectedInfo_0 != null)
			{
				ContentProtectedInfo result = contentProtectedInfo_0;
				contentProtectedInfo_0 = null;
				return result;
			}
			return null;
		}

		internal void method_23(GClass108 gclass108_0)
		{
			if (contentProtectedInfo_0 != null)
			{
				gclass108_0?.Add(contentProtectedInfo_0);
				contentProtectedInfo_0 = null;
			}
		}

		/// <summary>
		///       扩展性的判断元素能否被删除
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="flags">标记</param>
		/// <returns>能否被删除</returns>
		public bool CanDeleteExt(XTextElement element, DomAccessFlags flags)
		{
			if (EditorControl != null && EditorControl.BackgroundMode)
			{
				return true;
			}
			if (element is XTextFieldBorderElement)
			{
				element = element.Parent;
				ElementStateDetectEventArgs elementStateDetectEventArgs = new ElementStateDetectEventArgs(element, flags);
				CanDelete(elementStateDetectEventArgs);
				return elementStateDetectEventArgs.Result;
			}
			ElementStateDetectEventArgs elementStateDetectEventArgs2 = new ElementStateDetectEventArgs(element, flags);
			CanDelete(elementStateDetectEventArgs2);
			return elementStateDetectEventArgs2.Result;
		}

		/// <summary>
		///       判断指定元素能否被删除
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <param name="flags">访问标记</param>
		/// <returns>元素能否删除</returns>
		public virtual bool CanDelete(XTextElement element, DomAccessFlags flags)
		{
			contentProtectedInfo_0 = null;
			ElementStateDetectEventArgs elementStateDetectEventArgs = new ElementStateDetectEventArgs(element, flags);
			CanDelete(elementStateDetectEventArgs);
			return elementStateDetectEventArgs.Result;
		}

		/// <summary>
		///       判断能否删除文档元素
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void CanDelete(ElementStateDetectEventArgs args)
		{
			int num = 4;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			XTextElement element = args.Element;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			args.Flags = method_19(args.Flags);
			if (args.Flags == DomAccessFlags.None)
			{
				args.Result = true;
				return;
			}
			if (EditorControl != null && EditorControl.BackgroundMode)
			{
				args.Result = true;
				return;
			}
			DomAccessFlags flags = args.Flags;
			if ((element.RuntimeStyle.ProtectType == ContentProtectType.Range || element.RuntimeStyle.ProtectType == ContentProtectType.Content) && method_27(flags, DomAccessFlags.CheckContentProtect) && !IsAdministrator)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContentProtect;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ContentProtectStyle);
				args.Result = false;
				return;
			}
			if (method_27(flags, DomAccessFlags.CheckControlReadonly) && EditorControlReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.EditControlReadonly;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ControlReadonly);
				args.Result = false;
				return;
			}
			if (method_27(flags, DomAccessFlags.CheckLock) && !IsAdministrator)
			{
				XTextDocumentContentElement documentContentElement = element.DocumentContentElement;
				if (documentContentElement == null || element.FirstContentElementInPublicContent == null)
				{
					args.Result = false;
					return;
				}
				if (documentContentElement.Content.LockIndex >= 0 && documentContentElement.Content.method_17(element.FirstContentElementInPublicContent.ViewIndex))
				{
					if (args.SetMessage)
					{
						args.Message = WriterStringsCore.ReadonlyContentLocked;
					}
					method_21(args.Element, args.Message, ContentProtectedReason.Lock);
					args.Result = false;
					return;
				}
			}
			if ((FormView == FormViewMode.Normal || FormView == FormViewMode.Strict) && (flags & DomAccessFlags.CheckUserEditable) == DomAccessFlags.CheckUserEditable && !method_20(element))
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyFormViewMode;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.FormViewMode);
				args.Result = false;
				return;
			}
			if (!IsAdministrator && method_27(args.Flags, DomAccessFlags.CheckPermission) && AppHost.PermissionControler != null && !AppHost.PermissionControler.CanDelete(Document, element.RuntimeStyle.CreatorIndex, element.RuntimeStyle.DeleterIndex))
			{
				if (args.SetMessage)
				{
					if (!string.IsNullOrEmpty(AppHost.PermissionControler.LastMessage))
					{
						args.Message = AppHost.PermissionControler.LastMessage;
					}
					else
					{
						args.Message = WriterStringsCore.ReadonlyPermission;
					}
				}
				if (element.RuntimeStyle.DeleterIndex >= 0)
				{
					method_21(args.Element, args.Message, ContentProtectedReason.LogicDeleteAgain);
				}
				else
				{
					method_21(args.Element, args.Message, ContentProtectedReason.Permission);
				}
				args.Result = false;
				return;
			}
			if (element is IDeleteable && !IsAdministrator)
			{
				IDeleteable deleteable = (IDeleteable)element;
				if (!deleteable.Deleteable && XTextDocument.smethod_13(GEnum6.const_176))
				{
					if (args.SetMessage)
					{
						string arg = element.ID;
						if (element is XTextCheckBoxElementBase)
						{
							arg = ((XTextCheckBoxElementBase)element).DisplayName;
						}
						else if (element is XTextInputFieldElementBase)
						{
							arg = ((XTextInputFieldElementBase)element).DisplayName;
						}
						args.Message = string.Format(WriterStringsCore.ReadonlyElementMarkUndeleteable_ID, arg);
					}
					method_21(args.Element, args.Message, ContentProtectedReason.UnDeleteable);
					args.Result = false;
					return;
				}
			}
			if (element is XTextParagraphFlagElement)
			{
				XTextContentElement contentElement = element.ContentElement;
				if (contentElement.PrivateContent.LastElement == element)
				{
					if (args.SetMessage)
					{
						args.Message = WriterStringsCore.ReadonlyCanNotDeleteLastParagraphFlag;
					}
					method_21(args.Element, args.Message, ContentProtectedReason.UnDeleteable);
					args.Result = false;
					return;
				}
			}
			if (Document.Options.BehaviorOptions.EnableElementEvents && !(element is XTextCharElement) && !(element is XTextParagraphFlagElement))
			{
				ElementEventTemplateList events = element.Events;
				if (events != null && events.HasQueryState)
				{
					ElementQueryStateEventArgs elementQueryStateEventArgs = new ElementQueryStateEventArgs(element);
					elementQueryStateEventArgs.AccessFlags = flags;
					events.OnQueryState(this, elementQueryStateEventArgs);
					if (!elementQueryStateEventArgs.Deleteable)
					{
						if (args.SetMessage)
						{
							args.Message = WriterStringsCore.ReadonlyUserEvent;
						}
						method_21(args.Element, args.Message, ContentProtectedReason.UserEvent);
						args.Result = false;
						return;
					}
				}
			}
			XTextContainerElement parent = element.Parent;
			if (!IsAdministrator && method_27(flags, DomAccessFlags.CheckReadonly) && parent != null && parent.RuntimeContentReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContainerReadonly;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
				args.Result = false;
				return;
			}
			while (true)
			{
				if (parent != null)
				{
					if (parent is XTextFieldElementBase)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)parent;
						if (xTextFieldElementBase.StartElement == element || xTextFieldElementBase.EndElement == element)
						{
							if (args.SetMessage)
							{
								args.Message = WriterStringsCore.ReadonlyCanNotDeleteBorderElement;
							}
							method_21(args.Element, args.Message, ContentProtectedReason.UnDeleteable);
							args.Result = false;
							return;
						}
						if (xTextFieldElementBase.IsBackgroundTextElement(element))
						{
							if (args.SetMessage)
							{
								args.Message = WriterStringsCore.ReadonlyCanNotDeleteBackgroundText;
							}
							method_21(args.Element, args.Message, ContentProtectedReason.UnDeleteable);
							args.Result = false;
							return;
						}
					}
					if (parent is XTextInputFieldElementBase)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)parent;
						if (method_27(flags, DomAccessFlags.CheckUserEditable) && !xTextInputFieldElementBase.RuntimeUserEditable && !IsAdministrator)
						{
							if (args.SetMessage)
							{
								args.Message = string.Format(WriterStringsCore.ReadonlyInputFieldUserEditable_ID, xTextInputFieldElementBase.DisplayName);
							}
							method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
							args.Result = false;
							return;
						}
					}
					if (Document.Options.BehaviorOptions.EnableElementEvents)
					{
						ElementEventTemplateList events = parent.Events;
						if (events != null && events.HasQueryState)
						{
							ElementQueryStateEventArgs elementQueryStateEventArgs = new ElementQueryStateEventArgs(parent);
							elementQueryStateEventArgs.AccessFlags = flags;
							events.OnQueryState(this, elementQueryStateEventArgs);
							if (elementQueryStateEventArgs.ContentReadonly)
							{
								break;
							}
						}
					}
					parent = parent.Parent;
					continue;
				}
				args.Result = true;
				return;
			}
			if (args.SetMessage)
			{
				args.Message = WriterStringsCore.ReadonlyUserEvent;
			}
			method_21(args.Element, args.Message, ContentProtectedReason.UserEvent);
			args.Result = false;
		}

		/// <summary>
		///       判断能否在指定容器元素的指定序号处插入新的元素
		///       </summary>
		/// <param name="container">容器元素</param>
		/// <param name="index">指定序号</param>
		/// <param name="newElement">准备插入的新元素</param>
		/// <returns>能否插入元素</returns>
		public bool CanInsert(XTextContainerElement container, int index, XTextElement newElement)
		{
			return CanInsert(container, index, newElement, DomAccessFlags.CheckUserEditable);
		}

		/// <summary>
		///       判断能否在指定容器元素的指定序号处插入新的元素
		///       </summary>
		/// <param name="container">容器元素</param>
		/// <param name="index">指定序号</param>
		/// <param name="newElement">准备插入的新元素</param>
		/// <param name="flags">访问标记</param>
		/// <returns>能否插入元素</returns>
		public virtual bool CanInsert(XTextContainerElement container, int index, XTextElement newElement, DomAccessFlags flags)
		{
			CanInsertElementEventArgs canInsertElementEventArgs = new CanInsertElementEventArgs(container, index, newElement, flags);
			CanInsetElementInstance(canInsertElementEventArgs);
			return canInsertElementEventArgs.Result;
		}

		/// <summary>
		///       判断能否创建文档元素
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void CanInsetElementInstance(CanInsertElementEventArgs args)
		{
			int num = 5;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (args.Container == null)
			{
				throw new ArgumentNullException("args.Container");
			}
			if (args.Element == null)
			{
				throw new ArgumentNullException("args.Element");
			}
			args.Flags = method_19(args.Flags);
			if (EditorControl != null && EditorControl.BackgroundMode)
			{
				args.Result = AcceptChildElement(args.Container, args.Element, args.Flags);
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckControlReadonly) && EditorControlReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.EditControlReadonly;
				}
				args.Result = false;
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckLock) && !IsAdministrator)
			{
				XTextDocumentContentElement documentContentElement = args.Container.DocumentContentElement;
				if (documentContentElement != null)
				{
					XTextElement xTextElement = args.Container.Elements.SafeGet(args.Index);
					if (xTextElement != null && !documentContentElement.Content.Contains(xTextElement))
					{
						xTextElement = xTextElement.FirstContentElementInPublicContent;
					}
					int int_ = documentContentElement.Content.IndexOf(xTextElement);
					if (documentContentElement.Content.LockIndex >= 0 && documentContentElement.Content.method_17(int_))
					{
						if (args.SetMessage)
						{
							args.Message = WriterStringsCore.ReadonlyContentLocked;
						}
						method_21(args.Element, args.Message, ContentProtectedReason.Lock);
						args.Result = false;
						return;
					}
				}
			}
			if (method_27(args.Flags, DomAccessFlags.CheckFormView) && (FormView == FormViewMode.Normal || FormView == FormViewMode.Strict) && !method_20(args.Container) && !(args.Container is XTextInputFieldElementBase))
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyFormViewMode;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.FormViewMode);
				args.Result = false;
				return;
			}
			if (!AcceptChildElement(args.Container, args.Element, args.Flags))
			{
				if (args.SetMessage)
				{
					args.Message = string.Format(WriterStringsCore.ReadonlyCannotAcceptElementType_ParentType_ChildType, args.Container.DispalyTypeName, args.Element.DispalyTypeName);
				}
				args.Result = false;
				return;
			}
			if (!method_24(args.Container, args.Index))
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContentProtect;
				}
				args.Result = false;
				return;
			}
			XTextContainerElement xTextContainerElement = args.Container;
			if (!IsAdministrator && method_27(args.Flags, DomAccessFlags.CheckReadonly) && xTextContainerElement.RuntimeContentReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContainerReadonly;
				}
				args.Result = false;
				return;
			}
			XTextInputFieldElementBase xTextInputFieldElementBase;
			while (true)
			{
				if (xTextContainerElement != null)
				{
					if (xTextContainerElement is XTextInputFieldElementBase)
					{
						xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextContainerElement;
						if (method_27(args.Flags, DomAccessFlags.CheckUserEditable) && !xTextInputFieldElementBase.RuntimeUserEditable && !IsAdministrator)
						{
							break;
						}
					}
					xTextContainerElement = xTextContainerElement.Parent;
					continue;
				}
				args.Result = true;
				return;
			}
			if (args.SetMessage)
			{
				args.Message = string.Format(WriterStringsCore.ReadonlyInputFieldUserEditable_ID, xTextInputFieldElementBase.DisplayName);
			}
			args.Result = false;
		}

		/// <summary>
		///       判断指定容器元素中指定位置能否插入指定类型的子元素
		///       </summary>
		/// <param name="container">容器元素</param>
		/// <param name="index">要插入子元素的序号</param>
		/// <param name="elementType">子元素类型</param>
		/// <returns>能否插入子元素</returns>
		public virtual bool CanInsert(XTextContainerElement container, int index, Type elementType)
		{
			CanInsertElementEventArgs canInsertElementEventArgs = new CanInsertElementEventArgs(container, index, elementType, DomAccessFlags.Normal);
			CanInsertSpecifyElementType(canInsertElementEventArgs);
			return canInsertElementEventArgs.Result;
		}

		private bool method_24(XTextContainerElement xtextContainerElement_0, int int_0)
		{
			if (IsAdministrator)
			{
				return true;
			}
			if (xtextContainerElement_0 is XTextTableElement || xtextContainerElement_0 is XTextTableRowElement)
			{
				return true;
			}
			if (!XTextDocument.smethod_13(GEnum6.const_134))
			{
				return true;
			}
			XTextElement xTextElement = xtextContainerElement_0.Elements.SafeGet(int_0);
			if (xTextElement != null)
			{
				xTextElement = xTextElement.FirstContentElement;
				_ = xtextContainerElement_0.ContentElement;
				XTextDocumentContentElement documentContentElement = xtextContainerElement_0.DocumentContentElement;
				XTextElement preElement = documentContentElement.Content.GetPreElement(xTextElement);
				if (preElement != null && preElement.ContentElement == xTextElement.ContentElement)
				{
					if (preElement.RuntimeStyle.ProtectType == ContentProtectType.Range && xTextElement.RuntimeStyle.ProtectType == ContentProtectType.Range)
					{
						return false;
					}
				}
				else if (xTextElement.RuntimeStyle.ProtectType == ContentProtectType.Range)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///       判断指定容器元素中指定位置能否插入指定类型的子元素
		///       </summary>
		/// <param name="container">容器元素</param>
		/// <param name="index">要插入子元素的序号</param>
		/// <param name="elementType">子元素类型</param>
		/// <param name="flags">访问标记</param>
		/// <returns>能否插入子元素</returns>
		public virtual bool CanInsert(XTextContainerElement container, int index, Type elementType, DomAccessFlags flags)
		{
			CanInsertElementEventArgs canInsertElementEventArgs = new CanInsertElementEventArgs(container, index, elementType, flags);
			CanInsertSpecifyElementType(canInsertElementEventArgs);
			return canInsertElementEventArgs.Result;
		}

		/// <summary>
		///       判断指定容器元素中指定位置能否插入指定类型的子元素
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void CanInsertSpecifyElementType(CanInsertElementEventArgs args)
		{
			int num = 8;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (args.Container == null)
			{
				throw new ArgumentNullException("args.Container");
			}
			if (args.ElementType == null)
			{
				throw new ArgumentNullException("args.ElementType");
			}
			if (EditorControl != null && EditorControl.BackgroundMode)
			{
				args.Result = AcceptChildElement(args.Container, args.ElementType, args.Flags);
				return;
			}
			if (!method_24(args.Container, args.Index))
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContentProtect;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ContentProtectStyle);
				args.Result = false;
				return;
			}
			args.Flags = method_19(args.Flags);
			if (method_27(args.Flags, DomAccessFlags.CheckControlReadonly) && EditorControlReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.EditControlReadonly;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ControlReadonly);
				args.Result = false;
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckFormView) && (FormView == FormViewMode.Normal || FormView == FormViewMode.Strict) && !method_20(args.Container) && !(args.Container is XTextInputFieldElementBase))
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyFormViewMode;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.FormViewMode);
				args.Result = false;
				return;
			}
			if (args.Container.IsLogicDeleted)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyLogicDeleted;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.LogicDeleteAgain);
				args.Result = false;
				return;
			}
			if (method_27(args.Flags, DomAccessFlags.CheckLock))
			{
				XTextDocumentContentElement documentContentElement = args.Container.DocumentContentElement;
				if (documentContentElement.Content.LockIndex >= 0)
				{
					int int_ = documentContentElement.Content.method_19(args.Container, args.Index, bool_4: false);
					if (documentContentElement.Content.method_17(int_))
					{
						if (args.SetMessage)
						{
							args.Message = WriterStringsCore.ReadonlyContentLocked;
						}
						method_21(args.Element, args.Message, ContentProtectedReason.Lock);
						args.Result = false;
						return;
					}
				}
			}
			if (!IsAdministrator && method_27(args.Flags, DomAccessFlags.CheckReadonly) && args.Container.RuntimeContentReadonly)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContainerReadonly;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
				args.Result = false;
				return;
			}
			XTextContainerElement xTextContainerElement = args.Container;
			if (!AcceptChildElement(args.Container, args.ElementType, args.Flags))
			{
				if (args.SetMessage)
				{
					args.Message = string.Format(WriterStringsCore.ReadonlyCannotAcceptElementType_ParentType_ChildType, args.Container.DispalyTypeName, WriterUtils.smethod_17(args.ElementType));
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
				args.Result = false;
				return;
			}
			if (xTextContainerElement.RuntimeContentReadonly && !IsAdministrator)
			{
				if (args.SetMessage)
				{
					args.Message = WriterStringsCore.ReadonlyContainerReadonly;
				}
				method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
				args.Result = false;
				return;
			}
			while (true)
			{
				if (xTextContainerElement != null)
				{
					if (xTextContainerElement is XTextInputFieldElementBase)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextContainerElement;
						if (method_27(args.Flags, DomAccessFlags.CheckUserEditable) && !xTextInputFieldElementBase.RuntimeUserEditable && !IsAdministrator)
						{
							if (args.SetMessage)
							{
								args.Message = string.Format(WriterStringsCore.ReadonlyInputFieldUserEditable_ID, xTextInputFieldElementBase.DisplayName);
							}
							method_21(args.Element, args.Message, ContentProtectedReason.ContainerReadonly);
							args.Result = false;
							return;
						}
					}
					if (Document.Options.BehaviorOptions.EnableElementEvents)
					{
						ElementEventTemplateList events = xTextContainerElement.Events;
						if (events != null && events.HasQueryState)
						{
							ElementQueryStateEventArgs elementQueryStateEventArgs = new ElementQueryStateEventArgs(xTextContainerElement);
							elementQueryStateEventArgs.AccessFlags = args.Flags;
							events.OnQueryState(this, elementQueryStateEventArgs);
							if (elementQueryStateEventArgs.ContentReadonly)
							{
								break;
							}
						}
					}
					xTextContainerElement = xTextContainerElement.Parent;
					continue;
				}
				args.Result = true;
				return;
			}
			if (args.SetMessage)
			{
				args.Message = WriterStringsCore.ReadonlyUserEvent;
			}
			method_21(args.Element, args.Message, ContentProtectedReason.UserEvent);
			args.Result = false;
		}

		/// <summary>
		///       判断能否在当前位置插入指定类型的元素
		///       </summary>
		/// <param name="newElementType">新插入元素的类型</param>
		/// <returns>能否插入新元素</returns>
		public bool CanInsertElementAtCurrentPosition(Type newElementType)
		{
			return CanInsertElementAtCurrentPosition(newElementType, DomAccessFlags.Normal);
		}

		/// <summary>
		///       判断能否在当前位置插入指定类型的元素
		///       </summary>
		/// <param name="newElementType">新插入元素的类型</param>
		/// <param name="flags">访问标记</param>
		/// <returns>能否插入新元素</returns>
		public virtual bool CanInsertElementAtCurrentPosition(Type newElementType, DomAccessFlags flags)
		{
			if ((flags & DomAccessFlags.CheckControlReadonly) == DomAccessFlags.CheckControlReadonly && EditorControlReadonly)
			{
				return false;
			}
			XTextContainerElement xtextContainerElement_ = null;
			int int_ = 0;
			Document.Content.method_20(Document.Selection.StartIndex, out xtextContainerElement_, out int_, Document.Content.LineEndFlag);
			return CanInsert(xtextContainerElement_, int_, newElementType, flags);
		}

		public virtual bool vmethod_8(XTextElement xtextElement_0)
		{
			return true;
		}

		public virtual bool vmethod_9(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextCharElement)
			{
				return false;
			}
			if (xtextElement_0 is XTextParagraphFlagElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextLineBreakElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextPageBreakElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextSectionElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextHorizontalLineElement)
			{
				return true;
			}
			return false;
		}

		public virtual bool vmethod_10(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextCharElement || xtextElement_0 is XTextParagraphFlagElement)
			{
				return false;
			}
			if (xtextElement_0 is XTextTableElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextPageBreakElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextSectionElement)
			{
				return true;
			}
			if (xtextElement_0 is XTextHorizontalLineElement)
			{
				return true;
			}
			return false;
		}

		public virtual bool vmethod_11(char char_0)
		{
			if (char_0 >= 'a' && char_0 <= 'z')
			{
				return true;
			}
			if (char_0 >= 'A' && char_0 <= 'Z')
			{
				return true;
			}
			if (char_0 >= '0' && char_0 <= '9')
			{
				return true;
			}
			if (char_0 == '.')
			{
				return true;
			}
			if (Class126.smethod_8(char_0))
			{
				return true;
			}
			return false;
		}

		public virtual bool vmethod_12(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextCharElement)
			{
				return vmethod_14(((XTextCharElement)xtextElement_0).CharValue);
			}
			if (xtextElement_0 is XTextFieldBorderElement)
			{
				XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xtextElement_0;
				XTextFieldElementBase ownerField = xTextFieldBorderElement.OwnerField;
				if (ownerField.StartElement == xTextFieldBorderElement)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public virtual bool vmethod_13(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextCharElement)
			{
				return vmethod_15(((XTextCharElement)xtextElement_0).CharValue);
			}
			if (xtextElement_0 is XTextFieldBorderElement)
			{
				XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xtextElement_0;
				XTextFieldElementBase ownerField = xTextFieldBorderElement.OwnerField;
				if (ownerField.EndElement == xTextFieldBorderElement)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public virtual bool vmethod_14(char char_0)
		{
			if (string_2 == null)
			{
				return true;
			}
			return string_2.IndexOf(char_0) < 0;
		}

		public virtual bool vmethod_15(char char_0)
		{
			if (string_3 == null)
			{
				return true;
			}
			return string_3.IndexOf(char_0) < 0;
		}

		public void method_25()
		{
			documentControlerSnapshot_0 = null;
		}

		public void method_26()
		{
			contentProtectedInfo_0 = null;
			documentControlerSnapshot_0 = null;
		}

		private bool method_27(DomAccessFlags domAccessFlags_0, DomAccessFlags domAccessFlags_1)
		{
			return (domAccessFlags_0 & domAccessFlags_1) == domAccessFlags_1;
		}
	}
}
