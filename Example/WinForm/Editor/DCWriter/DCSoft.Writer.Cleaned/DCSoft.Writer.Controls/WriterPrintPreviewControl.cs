#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       打印预览控件对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("00012345-6789-ABCD-EF01-234567890083")]
	[ComVisible(true)]
	[ToolboxBitmap(typeof(WriterPrintPreviewControl))]
	
	[DocumentComment]
	[ToolboxItem(true)]
	public class WriterPrintPreviewControl : DCPrintPreviewControl
	{
		private bool bool_5 = false;

		private ToolStripMenuItem toolStripMenuItem_0 = null;

		private ToolStripMenuItem toolStripMenuItem_1 = null;

		private ToolStripMenuItem toolStripMenuItem_2 = null;

		private ToolStripMenuItem toolStripMenuItem_3 = null;

		private DocumentViewOptions documentViewOptions_0 = null;

		private bool bool_6 = false;

		private XTextDocumentList xtextDocumentList_0 = new XTextDocumentList();

		private VoidEventHandler voidEventHandler_0 = null;

		/// <summary>
		///       销毁控件的时候自动销毁文档对象
		///       </summary>
		[DefaultValue(false)]
		
		[ComVisible(true)]
		[Category("Behavior")]
		public bool AutoDisposeDocument
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       是否启用续打
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		
		[Browsable(false)]
		public bool EnableJumpPrint
		{
			get
			{
				if (base.PrintPreviewControl.Options.JumpPrint != null)
				{
					return base.PrintPreviewControl.Options.JumpPrint.Enabled;
				}
				return false;
			}
			set
			{
				if (base.PrintPreviewControl.Options.JumpPrint == null)
				{
					base.PrintPreviewControl.Options.JumpPrint = new JumpPrintInfo();
				}
				base.PrintPreviewControl.Options.JumpPrint.Enabled = value;
				btnJumpPrint.Checked = value;
			}
		}

		/// <summary>
		///       最后一次打印的结果信息
		///       </summary>
		
		[Category("Data")]
		[ComVisible(true)]
		public PrintResult LastPrintResult => base.CurrentPrintResult;

		/// <summary>
		///       最后一次的打印位置
		///       </summary>
		/// <remarks>
		///       一般本属性和控件的JumpPrintPosition属性搭配使用.
		///       比如在打印后存储该属性值,下次打开文档后,再设置JumpPrintPosition属性值.
		///       能设置上次打印结束的位置为续打起始位置.
		///       </remarks>
		
		[Browsable(false)]
		[ComVisible(true)]
		public int LastPrintPosition
		{
			get
			{
				if (LastPrintResult == null || LastPrintResult.UserCancel)
				{
					return 0;
				}
				return LastPrintResult.Position;
			}
		}

		/// <summary>
		///       续打位置
		///       </summary>
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public float JumpPrintPosition
		{
			get
			{
				return base.PrintPreviewControl.JumpPrintPosition;
			}
			set
			{
				base.PrintPreviewControl.JumpPrintPosition = value;
			}
		}

		/// <summary>
		///       布局停靠样式，仅仅向COM接口提供该属性
		///       </summary>
		[Browsable(false)]
		[DefaultValue(0)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int LayoutDock
		{
			get
			{
				return (int)Dock;
			}
			set
			{
				Dock = (DockStyle)value;
			}
		}

		/// <summary>
		///       指定的文档视图选项
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		
		[DefaultValue(null)]
		public DocumentViewOptions SpecifyViewOptions
		{
			get
			{
				return documentViewOptions_0;
			}
			set
			{
				documentViewOptions_0 = value;
			}
		}

		/// <summary>
		///       整洁打印模式，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[ComVisible(true)]
		
		public bool CleanMode
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       文档对象列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		
		public XTextDocumentList TextDocuments
		{
			get
			{
				if (xtextDocumentList_0 == null)
				{
					xtextDocumentList_0 = new XTextDocumentList();
				}
				return xtextDocumentList_0;
			}
			set
			{
				xtextDocumentList_0 = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public XTextDocument TextDocument
		{
			get
			{
				return TextDocuments.FirstDocument;
			}
			set
			{
				TextDocuments.Clear();
				if (value != null)
				{
					TextDocuments.Add(value);
				}
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[Category("Data")]
		
		[DefaultValue(null)]
		public string RegisterCode
		{
			get
			{
				return null;
			}
			set
			{
				XTextDocument.StaticRegisterCode = value;
			}
		}

		/// <summary>
		///       针对COM而声明的文档打印完成事件，在.NET开发中不使用该事件。
		///       </summary>
		[Browsable(false)]
		public event VoidEventHandler ComPrintCompleted
		{
			add
			{
				VoidEventHandler voidEventHandler = voidEventHandler_0;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Combine(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_0, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
			remove
			{
				VoidEventHandler voidEventHandler = voidEventHandler_0;
				VoidEventHandler voidEventHandler2;
				do
				{
					voidEventHandler2 = voidEventHandler;
					VoidEventHandler value2 = (VoidEventHandler)Delegate.Remove(voidEventHandler2, value);
					voidEventHandler = Interlocked.CompareExchange(ref voidEventHandler_0, value2, voidEventHandler2);
				}
				while ((object)voidEventHandler != voidEventHandler2);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterPrintPreviewControl()
		{
			base.JumpPrintButtonVisible = true;
			base.EnableSetJumpPrintPosition = true;
			base.ShowPageSettingsButton = false;
		}

		protected override void InnerClearMemberValues()
		{
			base.InnerClearMemberValues();
			documentViewOptions_0 = null;
			xtextDocumentList_0 = null;
		}

		
		protected override bool vmethod_0(string string_4)
		{
			int num = 8;
			switch (string_4)
			{
			case "BoundsSelection":
				return XTextDocument.smethod_13(GEnum6.const_45);
			case "DoubleColumns":
				return XTextDocument.smethod_13(GEnum6.const_48);
			case "PrintDocumentExt":
				return XTextDocument.smethod_13(GEnum6.const_46);
			case "Zoom":
				return XTextDocument.smethod_13(GEnum6.const_49);
			default:
				return true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (AutoDisposeDocument && xtextDocumentList_0 != null)
			{
				XTextDocumentList xTextDocumentList = xtextDocumentList_0;
				xtextDocumentList_0 = null;
				foreach (XTextDocument item in xTextDocumentList)
				{
					item.Dispose();
				}
			}
		}

		/// <summary>
		///       加载控件的操作
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLoad(EventArgs eventArgs_0)
		{
			int num = 19;
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				btnPrintManualDuplex.Visible = false;
			}
			ToolStripDropDownButton toolStripDropDownButton = new ToolStripDropDownButton();
			toolStripDropDownButton.Text = WriterStrings.MenuSaveFile;
			base.MainToolStrip.Items.Insert(0, toolStripDropDownButton);
			toolStripDropDownButton.AutoToolTip = false;
			toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			base.MainToolStrip.Items.Insert(1, new ToolStripSeparator());
			toolStripMenuItem_3 = new ToolStripMenuItem(WriterStrings.MenuSavePDFFile);
			toolStripMenuItem_3.Tag = "pdf";
			toolStripDropDownButton.DropDownItems.Add(toolStripMenuItem_3);
			toolStripMenuItem_3.Click += toolStripMenuItem_2_Click;
			toolStripMenuItem_0 = new ToolStripMenuItem(WriterStrings.MenuSaveRTFFile);
			toolStripMenuItem_0.Tag = "rtf";
			toolStripDropDownButton.DropDownItems.Add(toolStripMenuItem_0);
			toolStripMenuItem_0.Click += toolStripMenuItem_2_Click;
			toolStripMenuItem_1 = new ToolStripMenuItem(WriterStrings.MenuSaveHTMLFile);
			toolStripMenuItem_1.Tag = "html";
			toolStripDropDownButton.DropDownItems.Add(toolStripMenuItem_1);
			toolStripMenuItem_1.Click += toolStripMenuItem_2_Click;
			toolStripMenuItem_2 = new ToolStripMenuItem(WriterStrings.MenuSaveXMLFile);
			toolStripMenuItem_2.Tag = "xml";
			toolStripDropDownButton.DropDownItems.Add(toolStripMenuItem_2);
			toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		}

		private void method_7()
		{
			if (toolStripMenuItem_1 != null)
			{
				bool flag = false;
				if (Document is WriterPrintDocument)
				{
					flag = (((WriterPrintDocument)Document).Documents.Count > 1);
				}
				toolStripMenuItem_1.Text = (flag ? WriterStrings.MenuSaveFirstHTMLFile : WriterStrings.MenuSaveHTMLFile);
				toolStripMenuItem_3.Text = (flag ? WriterStrings.MenuSaveFirstPDFFile : WriterStrings.MenuSavePDFFile);
				toolStripMenuItem_2.Text = (flag ? WriterStrings.MenuSaveFirstXMLFile : WriterStrings.MenuSaveXMLFile);
				toolStripMenuItem_0.Text = (flag ? WriterStrings.MenuSaveFirstRTFFile : WriterStrings.MenuSaveRTFFile);
			}
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			int num = 14;
			XTextDocument xTextDocument = TextDocument;
			if (xTextDocument == null && Document is WriterPrintDocument)
			{
				xTextDocument = ((WriterPrintDocument)Document).RuntimeMainDocument;
			}
			if (xTextDocument != null)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
				string text = (string)toolStripMenuItem.Tag;
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.OverwritePrompt = true;
					saveFileDialog.CheckPathExists = true;
					switch (text)
					{
					case "pdf":
						saveFileDialog.Filter = WriterStrings.PDFFilter;
						break;
					case "rtf":
						saveFileDialog.Filter = WriterStrings.RTFFileFilter;
						break;
					case "html":
						saveFileDialog.Filter = WriterStrings.HtmlFileFilter;
						break;
					case "xml":
						saveFileDialog.Filter = WriterStrings.XMLFilter;
						break;
					}
					if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						string fileName = saveFileDialog.FileName;
						xTextDocument.Save(fileName, text);
					}
				}
			}
		}

		/// <summary>
		///       面向COM的调用控件的方法
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <param name="paramters">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		public object ComCallMethodByName(string name, string paramters)
		{
			return WriterUtils.smethod_18(this, name, paramters, bool_2: false);
		}

		/// <summary>
		///       面向COM的调用控件的方法
		///       </summary>
		/// <param name="instance">对象实例</param>
		/// <param name="name">方法名称</param>
		/// <param name="paramters">参数</param>
		/// <returns>返回值</returns>
		[ComVisible(true)]
		
		[Obsolete("仅向COM公开，在.NET中不要调用")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object ComCallInstanceMethodByName(object instance, string name, string paramters)
		{
			return WriterUtils.smethod_18(instance, name, paramters, bool_2: false);
		}

		/// <summary>
		///       清空文档
		///       </summary>
		
		[ComVisible(true)]
		public void ClearDocument()
		{
			TextDocuments.Clear();
			XPrintDocument xPrintDocument = Document as XPrintDocument;
			if (xPrintDocument != null)
			{
				xPrintDocument.Pages = new PrintPageCollection();
			}
			InvalidatePreview();
		}

		private void method_8()
		{
			if (TextDocument != null)
			{
				base.PrintPreviewControl.MaskColorForJumpPrint = TextDocument.Options.ViewOptions.MaskColorForJumpPrint;
			}
			else if (Document is WriterPrintDocument)
			{
				WriterPrintDocument writerPrintDocument = (WriterPrintDocument)Document;
				if (writerPrintDocument.Documents != null && writerPrintDocument.Documents.Count > 0)
				{
					base.PrintPreviewControl.MaskColorForJumpPrint = writerPrintDocument.Documents[0].Options.ViewOptions.MaskColorForJumpPrint;
				}
			}
		}

		/// <summary>
		///       刷新打印预览显示
		///       </summary>
		[ComVisible(true)]
		
		public override void InvalidatePreview()
		{
			if (base.Options != null && base.Options.JumpPrint != null)
			{
				btnJumpPrint.Checked = base.Options.JumpPrint.Enabled;
			}
			method_8();
			base.IsPrintCompleted = false;
			if (xtextDocumentList_0 != null && xtextDocumentList_0.Count > 0)
			{
				WriterPrintDocument writerPrintDocument = new WriterPrintDocument();
				writerPrintDocument.Documents = TextDocuments;
				if (SpecifyViewOptions != null)
				{
					foreach (XTextDocument textDocument in TextDocuments)
					{
						textDocument.Options.ViewOptions = SpecifyViewOptions;
						base.EnableSetJumpPrintPosition = textDocument.Options.BehaviorOptions.EnableSetJumpPrintPositionWhenPreview;
					}
				}
				base.Document = writerPrintDocument;
				base.PrintPreviewControl.Document = writerPrintDocument;
				writerPrintDocument.CleanMode = CleanMode;
				writerPrintDocument.UpdateDocumentsState();
				base.PrintPreviewControl.Options.JumpPrint = new JumpPrintInfo();
				base.PrintPreviewControl.Options.BoundsSelection = new BoundsSelectionPrintInfo();
				base.InvalidatePreview();
				base.TotalPages = writerPrintDocument.TotalPages;
			}
			else if (Document != null)
			{
				if (Document is WriterPrintDocument)
				{
					WriterPrintDocument writerPrintDocument2 = (WriterPrintDocument)Document;
					if (writerPrintDocument2.RuntimeMainDocument != null)
					{
						base.EnableSetJumpPrintPosition = writerPrintDocument2.RuntimeMainDocument.Options.BehaviorOptions.EnableSetJumpPrintPositionWhenPreview;
					}
				}
				base.InvalidatePreview();
			}
			method_7();
		}

		/// <summary>
		///       已文档合并的方式刷新打印预览显示
		///       </summary>
		[ComVisible(true)]
		
		public void InvalidatePreviewMegeDocument()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_38))
			{
				InvalidatePreview();
			}
			if (base.Options.JumpPrint != null)
			{
				btnJumpPrint.Checked = base.Options.JumpPrint.Enabled;
			}
			method_8();
			base.IsPrintCompleted = false;
			if (xtextDocumentList_0 != null && xtextDocumentList_0.Count > 0)
			{
				WriterPrintDocument writerPrintDocument = new WriterPrintDocument();
				XTextDocument xTextDocument = TextDocuments[0];
				for (int i = 1; i < TextDocuments.Count; i++)
				{
					XTextDocument xTextDocument2 = TextDocuments[i];
					XTextElementList elements = xTextDocument2.Body.Elements;
					xTextDocument.ImportElements(elements);
					if (elements.LastElement is XTextParagraphFlagElement)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)elements.LastElement;
						if (xTextParagraphFlagElement.StyleIndex == -1)
						{
							elements.RemoveAt(elements.Count - 1);
						}
					}
					elements.Add(new XTextParagraphFlagElement());
					xTextDocument.Body.Elements.AddRange(elements);
				}
				if (TextDocuments.Count > 1)
				{
					xTextDocument.FixDomState();
				}
				writerPrintDocument.Documents = new XTextDocumentList();
				writerPrintDocument.Documents.Add(xTextDocument);
				if (SpecifyViewOptions != null)
				{
					foreach (XTextDocument textDocument in TextDocuments)
					{
						textDocument.Options.ViewOptions = SpecifyViewOptions;
						base.EnableSetJumpPrintPosition = textDocument.Options.BehaviorOptions.EnableSetJumpPrintPositionWhenPreview;
					}
				}
				base.Document = writerPrintDocument;
				base.PrintPreviewControl.Document = writerPrintDocument;
				writerPrintDocument.CleanMode = CleanMode;
				writerPrintDocument.UpdateDocumentsState();
				base.InvalidatePreview();
				base.TotalPages = writerPrintDocument.TotalPages;
			}
			else if (Document != null)
			{
				base.InvalidatePreview();
			}
			method_7();
		}

		/// <summary>
		///       添加文档
		///       </summary>
		/// <param name="document">
		/// </param>
		
		public void AddDocument(XTextDocument document)
		{
			if (document != null)
			{
				method_9(document);
				TextDocuments.Add(document);
			}
		}

		/// <summary>
		///       从纯文本数据中加载文档对象
		///       </summary>
		/// <param name="text">文本数据</param>
		/// <param name="format">指定的文档格式</param>
		
		public void AddDocumenByText(string text, string format)
		{
			if (!string.IsNullOrEmpty(text))
			{
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.Load(new StringReader(text), format);
				method_9(xTextDocument);
				TextDocuments.Add(xTextDocument);
			}
		}

		/// <summary>
		///       从二进制数据加载文档对象
		///       </summary>
		/// <param name="bs">二进制数据</param>
		/// <param name="format">文档格式</param>
		
		public void AddDocumentByBinary(byte[] byte_0, string format)
		{
			if (byte_0 != null && byte_0.Length > 0)
			{
				MemoryStream stream = new MemoryStream(byte_0);
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.Load(stream, format);
				method_9(xTextDocument);
				TextDocuments.Add(xTextDocument);
			}
		}

		/// <summary>
		///       从BASE64格式的文本数据中加载文档对象
		///       </summary>
		/// <param name="base64Text">BASE64文本数据</param>
		/// <param name="format">指定的文档格式</param>
		
		public void AddDocumentByBase64Text(string base64Text, string format)
		{
			if (!string.IsNullOrEmpty(base64Text))
			{
				byte[] buffer = Convert.FromBase64String(base64Text);
				MemoryStream stream = new MemoryStream(buffer);
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.Load(stream, format);
				method_9(xTextDocument);
				TextDocuments.Add(xTextDocument);
			}
		}

		/// <summary>
		///       从文件流中加载文档并添加到控件中
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		
		[ComVisible(false)]
		public void AddDocument(Stream stream, string format)
		{
			if (stream != null)
			{
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.Load(stream, format);
				method_9(xTextDocument);
				TextDocuments.Add(xTextDocument);
			}
		}

		/// <summary>
		///       从指定的地址加载文件并添加到控件中
		///       </summary>
		/// <param name="url">文件地址</param>
		/// <param name="format">文件格式</param>
		
		public void AddDocumentByUrl(string string_4, string format)
		{
			if (!string.IsNullOrEmpty(string_4))
			{
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.Load(string_4, format);
				method_9(xTextDocument);
				TextDocuments.Add(xTextDocument);
			}
		}

		private void method_9(XTextDocument xtextDocument_0)
		{
			using (DCGraphics dcgraphics_ = xtextDocument_0.CreateDCGraphics())
			{
				xtextDocument_0.RefreshSize(dcgraphics_);
			}
		}

		protected override bool vmethod_1()
		{
			if (base.Document is WriterPrintDocument)
			{
				WriterPrintDocument writerPrintDocument = (WriterPrintDocument)base.Document;
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				cancelEventArgs.Cancel = false;
				writerPrintDocument.method_5(cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return false;
				}
			}
			return base.vmethod_1();
		}

		protected override void vmethod_2()
		{
			int num = 11;
			if (base.Document is WriterPrintDocument)
			{
				WriterPrintDocument writerPrintDocument = (WriterPrintDocument)base.Document;
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				cancelEventArgs.Cancel = false;
				writerPrintDocument.method_6(EventArgs.Empty);
			}
			base.vmethod_2();
			if (base.EnabledControlEvent && voidEventHandler_0 != null)
			{
				if (IsTryCathForRaiseEvent)
				{
					try
					{
						voidEventHandler_0();
					}
					catch (Exception ex)
					{
						Debug.WriteLine("ComPrintCompleted:" + ex.Message);
					}
				}
				else
				{
					voidEventHandler_0();
				}
			}
		}

		/// <summary>
		///       将控件添加到指定句柄的窗体中
		///       </summary>
		/// <param name="containerHandle">指定的窗体句柄对象</param>
		/// <returns>操作是否成功</returns>
		
		public bool AppendToContainerControl(int containerHandle)
		{
			GClass271 gClass = new GClass271();
			gClass.method_3(new IntPtr(containerHandle));
			gClass.method_1(base.Handle);
			gClass.method_5(Dock);
			return gClass.method_6();
		}

		/// <summary>
		///       显示关于对话框
		///       </summary>
		
		public void ShowAbout()
		{
			using (dlgAbout dlgAbout = new dlgAbout())
			{
				dlgAbout.ShowDialog(this);
			}
		}
	}
}
