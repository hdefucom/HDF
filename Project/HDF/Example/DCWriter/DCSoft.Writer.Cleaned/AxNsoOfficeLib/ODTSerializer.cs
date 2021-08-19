using DCSoft.Writer.Dom;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System.IO;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>
	                                                                    ///       ODT文件读取器
	                                                                    ///       </summary>
	internal class ODTSerializer : ContentSerializer
	{
		public override string Name => "odt";

		public override string FileExtension => ".odt";

		public override string FileFilter => "ODT文件(*.odt)|*.odt";

		public override GEnum14 Flags => GEnum14.flag_1;

		public override bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			Class74 @class = new Class74();
			@class.method_1(bool_2: false);
			@class.method_3("123");
			return @class.method_4(stream, document, options);
		}
	}
}
