using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.IO;

namespace DCSoft.Writer.Serialization.PDF
{
	/// <summary>
	///       PDF格式的内容序列化器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	internal class ImagePDFContentSerializer : ContentSerializer
	{
		public override string Name => "image.pdf";

		public override string FileExtension => ".image.pdf";

		public override string FileFilter => WriterStringsCore.ImagePDFFilter;

		/// <summary>
		///       只支持二进制序列化
		///       </summary>
		public override GEnum14 Flags => GEnum14.flag_2;

		public override bool NeedRefreshPages(XTextDocument document)
		{
			return true;
		}

		/// <summary>
		///       进行二进制序列化
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">选项</param>
		/// <returns>操作是否成功</returns>
		public override bool Serialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			int num = 3;
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_8, Name))
			{
				return false;
			}
			float result = 1f;
			if (options != null && options.Parameters.ContainsKey("ZoomRate") && !float.TryParse(options.Parameters["ZoomRate"], out result))
			{
				result = 1f;
			}
			document.CheckPageRefreshed();
			Class132 @class = new Class132();
			@class.method_0().Add(document);
			using (GClass519 gclass519_ = new GClass519(stream))
			{
				@class.method_3(gclass519_);
				@class.method_4(result);
			}
			return true;
		}
	}
}
