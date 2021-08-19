using DCSoft.Common;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DCInternal]
	public abstract class GClass8
	{
		private XTextDocument xtextDocument_0 = null;

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public abstract XTextElement CreateElement(XTextDocument document);

		public abstract bool PromptNewElement(WriterCommandEventArgs args);

		public abstract bool PromptEditProperties(WriterCommandEventArgs args);

		public abstract bool ReadProperties(XTextElement element);

		public abstract bool ApplyToElement(XTextDocument document, XTextElement element, bool logUndo);
	}
}
