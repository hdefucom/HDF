using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxWriterPrintPreviewControl 的COM接口</summary>
	[Guid("61FDA393-EBA5-47BD-A456-05FE1DEECE78")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IAxWriterPrintPreviewControl
	{
		/// <summary>属性AllowUserChangePrintArea</summary>
		[DispId(12371)]
		bool AllowUserChangePrintArea
		{
			get;
			set;
		}

		/// <summary>属性AutoDisposeDocument</summary>
		[DispId(12372)]
		bool AutoDisposeDocument
		{
			get;
			set;
		}

		/// <summary>属性AxContentBase64String</summary>
		[DispId(12366)]
		string AxContentBase64String
		{
			get;
			set;
		}

		/// <summary>属性CleanMode</summary>
		[DispId(12350)]
		bool CleanMode
		{
			get;
			set;
		}

		/// <summary>属性CodeBaseForUpdateAssembly</summary>
		[DispId(12367)]
		string CodeBaseForUpdateAssembly
		{
			get;
			set;
		}

		/// <summary>属性CurrentPrintResult</summary>
		[DispId(12373)]
		PrintResult CurrentPrintResult
		{
			get;
			set;
		}

		/// <summary>属性EnabledControlEvent</summary>
		[DispId(12374)]
		bool EnabledControlEvent
		{
			get;
			set;
		}

		/// <summary>属性EnableSetJumpPrintPosition</summary>
		[DispId(12360)]
		bool EnableSetJumpPrintPosition
		{
			get;
			set;
		}

		/// <summary>属性JumpPrintPosition</summary>
		[DispId(12362)]
		float JumpPrintPosition
		{
			get;
			set;
		}

		/// <summary>属性LastPrintPosition</summary>
		[DispId(12363)]
		int LastPrintPosition
		{
			get;
		}

		/// <summary>属性LastPrintResult</summary>
		[DispId(12364)]
		PrintResult LastPrintResult
		{
			get;
		}

		/// <summary>属性PageBackColor</summary>
		[DispId(12351)]
		Color PageBackColor
		{
			get;
			set;
		}

		/// <summary>属性PreviewBackColor</summary>
		[DispId(12375)]
		Color PreviewBackColor
		{
			get;
			set;
		}

		/// <summary>属性RegisterCode</summary>
		[DispId(12352)]
		string RegisterCode
		{
			get;
			set;
		}

		/// <summary>属性ShowPageSettingsButton</summary>
		[DispId(12376)]
		bool ShowPageSettingsButton
		{
			get;
			set;
		}

		/// <summary>属性ShowPrinterSettingsBeforePrint</summary>
		[DispId(12377)]
		bool ShowPrinterSettingsBeforePrint
		{
			get;
			set;
		}

		/// <summary>属性ShowPrinterSettingsButton</summary>
		[DispId(12378)]
		bool ShowPrinterSettingsButton
		{
			get;
			set;
		}

		/// <summary>属性ShowStartPageIndex</summary>
		[DispId(12379)]
		bool ShowStartPageIndex
		{
			get;
			set;
		}

		/// <summary>属性SpecifyViewOptions</summary>
		[DispId(12361)]
		DocumentViewOptions SpecifyViewOptions
		{
			get;
			set;
		}

		/// <summary>属性StartPage</summary>
		[DispId(12382)]
		int StartPage
		{
			get;
			set;
		}

		/// <summary>属性TextDocument</summary>
		[DispId(12353)]
		XTextDocument TextDocument
		{
			get;
			set;
		}

		/// <summary>属性TextDocuments</summary>
		[DispId(12354)]
		XTextDocumentList TextDocuments
		{
			get;
			set;
		}

		/// <summary>属性ToolbarVisible</summary>
		[DispId(12369)]
		bool ToolbarVisible
		{
			get;
			set;
		}

		/// <summary>属性UseAntiAlias</summary>
		[DispId(12355)]
		bool UseAntiAlias
		{
			get;
			set;
		}

		/// <summary>属性Zoom</summary>
		[DispId(12380)]
		double Zoom
		{
			get;
			set;
		}

		/// <summary>方法AddDocumenByText</summary>
		[DispId(12341)]
		void AddDocumenByText(string text, string format);

		/// <summary>方法AddDocument</summary>
		[DispId(12342)]
		void AddDocument(XTextDocument document);

		/// <summary>方法AddDocumentByBase64Text</summary>
		[DispId(12343)]
		void AddDocumentByBase64Text(string base64Text, string format);

		/// <summary>方法AddDocumentByBinary</summary>
		[DispId(12365)]
		void AddDocumentByBinary(byte[] byte_0, string format);

		/// <summary>方法AddDocumentByUrl</summary>
		[DispId(12344)]
		void AddDocumentByUrl(string string_0, string format);

		/// <summary>方法AppendToContainerControl</summary>
		[DispId(12345)]
		bool AppendToContainerControl(int containerHandle);

		/// <summary>方法ClearDocument</summary>
		[DispId(12346)]
		void ClearDocument();

		/// <summary>方法CloseForPB</summary>
		[DispId(12370)]
		void CloseForPB();

		/// <summary>方法CloseForPBWithoutDock</summary>
		[DispId(12381)]
		void CloseForPBWithoutDock();

		/// <summary>方法ComCallInstanceMethodByName</summary>
		[DispId(12356)]
		object ComCallInstanceMethodByName(object instance, string name, string paramters);

		/// <summary>方法ComCallMethodByName</summary>
		[DispId(12357)]
		object ComCallMethodByName(string name, string paramters);

		/// <summary>方法ComDispose</summary>
		[DispId(12358)]
		void ComDispose();

		/// <summary>方法InvalidatePreview</summary>
		[DispId(12348)]
		void InvalidatePreview();

		/// <summary>方法InvalidatePreviewMegeDocument</summary>
		[DispId(12359)]
		void InvalidatePreviewMegeDocument();

		/// <summary>方法PrintDocumentExt</summary>
		[DispId(12368)]
		void PrintDocumentExt(bool showUI, string specifyPageIndes);

		/// <summary>方法ShowAbout</summary>
		[DispId(12349)]
		void ShowAbout();
	}
}
