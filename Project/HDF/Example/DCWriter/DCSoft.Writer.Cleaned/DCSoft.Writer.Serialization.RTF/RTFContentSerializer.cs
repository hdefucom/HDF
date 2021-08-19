using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.IO;
using System.Text;

namespace DCSoft.Writer.Serialization.RTF
{
	/// <summary>
	///       RTF格式的序列化器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	internal class RTFContentSerializer : ContentSerializer
	{
		/// <summary>
		///       对象名称
		///       </summary>
		public override string Name => "rtf";

		/// <summary>
		///       文件扩展名
		///       </summary>
		public override string FileExtension => ".rtf";

		/// <summary>
		///       文件名过滤器
		///       </summary>
		public override string FileFilter => WriterStringsCore.RTFFileFilter;

		/// <summary>
		///       对象标记
		///       </summary>
		public override GEnum14 Flags => GEnum14.flag_1 | GEnum14.flag_2 | GEnum14.flag_3 | GEnum14.flag_4;

		/// <summary>
		///       初始化对象
		///       </summary>
		public RTFContentSerializer()
		{
			base.ContentEncoding = Encoding.Default;
		}

		public override bool NeedRefreshPages(XTextDocument document)
		{
			return true;
		}

		/// <summary>
		///       反序列化文档
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">选项</param>
		/// <returns>操作是否成功</returns>
		public override bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			return Deserialize(new StreamReader(stream, Encoding.Default), document, options);
		}

		public override bool Deserialize(TextReader reader, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_3, Name))
			{
				return false;
			}
			Class122 @class = new Class122();
			@class.method_5(options.EnableDocumentSetting);
			@class.method_10(options.ImportTemplateGenerateParagraph);
			@class.vmethod_0(reader);
			@class.method_8(document);
			return true;
		}

		public override bool Serialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			return Serialize(new StreamWriter(stream, Encoding.Default), document, options);
		}

		public override bool Serialize(TextWriter writer, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_10, Name))
			{
				return false;
			}
			GClass103 gClass = new GClass103(writer);
			gClass.method_1(document);
			gClass.vmethod_1(options.IncludeSelectionOnly);
			gClass.method_13(!document.Options.SecurityOptions.ShowLogicDeletedContent);
			gClass.method_46();
			return true;
		}
	}
}
