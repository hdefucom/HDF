using DCSoft.Writer.Dom;
using DCSoftDotfuscate;

namespace DCSoft.Writer.Serialization.Html
{
	internal class MHTContentSerializer : HTMLContentSerializer
	{
		public override string Name => "mht";

		public override string FileExtension => ".mht";

		public override string FileFilter => WriterStringsCore.MHTFileFilter;

		public override GEnum14 Flags => GEnum14.flag_2 | GEnum14.flag_4;

		public MHTContentSerializer()
		{
			base.MhtFormat = true;
		}

		public override bool NeedRefreshPages(XTextDocument document)
		{
			return true;
		}
	}
}
