using DCSoft.Common;
using DCSoft.HtmlDom;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.IO;
using System.Text;

namespace DCSoft.Writer.Serialization.Html
{
	internal class HTMLContentSerializer : ContentSerializer
	{
		private bool bool_0 = false;

		/// <summary>
		///       MHT模式
		///       </summary>
		protected bool MhtFormat
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public override string Name => "html";

		public override string FileExtension => ".htm";

		public override string FileFilter => WriterStringsCore.HtmlFileFilter;

		public override GEnum14 Flags => GEnum14.flag_1 | GEnum14.flag_2 | GEnum14.flag_3 | GEnum14.flag_4;

		public HTMLContentSerializer()
		{
			base.ContentEncoding = Encoding.Default;
		}

		public override bool NeedRefreshPages(XTextDocument document)
		{
			return true;
		}

		public override bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_2, Name))
			{
				return false;
			}
			HTMLDocument hTMLDocument = new HTMLDocument();
			hTMLDocument.BaseURL = options.BasePath;
			if (string.IsNullOrEmpty(hTMLDocument.BaseURL))
			{
				hTMLDocument.BaseURL = document.BaseUrl;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			hTMLDocument.Load(stream);
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			float num = CountDown.GetTickCountFloat() - tickCountFloat;
			method_0(hTMLDocument, document);
			num = CountDown.GetTickCountFloat() - num;
			return true;
		}

		public override bool Deserialize(TextReader reader, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_2, Name))
			{
				return false;
			}
			HTMLDocument hTMLDocument = new HTMLDocument();
			hTMLDocument.BaseURL = options.BasePath;
			if (string.IsNullOrEmpty(hTMLDocument.BaseURL))
			{
				hTMLDocument.BaseURL = document.BaseUrl;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			hTMLDocument.Load(reader);
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			float num = CountDown.GetTickCountFloat() - tickCountFloat;
			method_0(hTMLDocument, document);
			num = CountDown.GetTickCountFloat() - num;
			return true;
		}

		private void method_0(HTMLDocument htmldocument_0, XTextDocument xtextDocument_0)
		{
			int num = 4;
			float tickCountFloat = CountDown.GetTickCountFloat();
			xtextDocument_0.method_40(DomReadyStates.Loading);
			xtextDocument_0.method_56();
			xtextDocument_0.FileName = htmldocument_0.Location;
			xtextDocument_0.FileFormat = "html";
			xtextDocument_0.Info.Title = htmldocument_0.Title;
			ReadHTMLEventArgs readHTMLEventArgs_ = new ReadHTMLEventArgs(null, htmldocument_0.Body, xtextDocument_0, null);
			xtextDocument_0.Clear();
			xtextDocument_0.Header.Elements.Clear();
			xtextDocument_0.Footer.Elements.Clear();
			foreach (GClass163 item in htmldocument_0.Body.vmethod_2())
			{
				if (item.method_37() == "DCDocumentViewState")
				{
					DocumentViewState.LoadViewStateString(xtextDocument_0, item.method_9("value"));
					break;
				}
			}
			xtextDocument_0.Body.Elements.Clear();
			xtextDocument_0.Body.vmethod_17(readHTMLEventArgs_);
			xtextDocument_0.method_40(DomReadyStates.Loaded);
			xtextDocument_0.FixDomState();
			xtextDocument_0.Header.FixElements();
			xtextDocument_0.Body.FixElements();
			xtextDocument_0.Footer.FixElements();
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		public override bool Serialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			int num = 1;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_6, Name))
			{
				return false;
			}
			GInterface5 gInterface = document.AppHost.Tools.CreateWriterHtmlDocumentWriter();
			string text = null;
			if (MhtFormat)
			{
				gInterface.imethod_14("file{0}");
			}
			else if (!string.IsNullOrEmpty(options.BasePath) && Path.IsPathRooted(options.BasePath) && !string.IsNullOrEmpty(options.FileName))
			{
				string text2 = Path.GetFileNameWithoutExtension(options.FileName) + ".files";
				gInterface.imethod_14(text2 + "\\{0}");
				text = Path.Combine(options.BasePath, text2);
			}
			gInterface.imethod_40().Add(document);
			gInterface.imethod_49(options.IncludeSelectionOnly);
			gInterface.imethod_43(GEnum12.const_0);
			gInterface.imethod_56(DCBackgroundTextOutputMode.Output);
			gInterface.imethod_30(bool_0: true);
			gInterface.imethod_46().method_3(bool_9: false);
			gInterface.imethod_46().vmethod_1(bool_9: false);
			gInterface.imethod_46().method_1(options.ContentEncoding);
			gInterface.imethod_46().method_11(bool_9: false);
			if (XTextDocument.IsLZLicense)
			{
				gInterface.imethod_46().method_11(bool_9: true);
			}
			gInterface.imethod_35(bool_0: true);
			gInterface.imethod_10();
			if (MhtFormat)
			{
				gInterface.imethod_6(stream);
			}
			else
			{
				gInterface.imethod_4(stream);
				if (text != null)
				{
					gInterface.imethod_3(text);
				}
			}
			return true;
		}

		public override bool Serialize(TextWriter writer, XTextDocument document, ContentSerializeOptions options)
		{
			int num = 0;
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_6, Name))
			{
				return false;
			}
			GInterface5 gInterface = document.AppHost.Tools.CreateWriterHtmlDocumentWriter();
			gInterface.imethod_40().Add(document);
			gInterface.imethod_49(options.IncludeSelectionOnly);
			gInterface.imethod_43(GEnum12.const_0);
			gInterface.imethod_56(DCBackgroundTextOutputMode.Output);
			gInterface.imethod_30(bool_0: true);
			gInterface.imethod_46().method_3(bool_9: true);
			gInterface.imethod_8(options.ContentEncoding);
			gInterface.imethod_46().vmethod_1(bool_9: false);
			gInterface.imethod_46().method_11(bool_9: false);
			gInterface.imethod_35(options.ForPrint);
			gInterface.imethod_46().method_3(options.Formated);
			if (XTextDocument.IsLZLicense)
			{
				gInterface.imethod_46().method_11(bool_9: true);
			}
			if (!string.IsNullOrEmpty(options.BasePath) && Directory.Exists(options.BasePath))
			{
				gInterface.imethod_14("{0}");
				gInterface.imethod_10();
				gInterface.imethod_5(writer);
				gInterface.imethod_3(options.BasePath);
			}
			else
			{
				gInterface.imethod_10();
				gInterface.imethod_5(writer);
			}
			return true;
		}
	}
}
