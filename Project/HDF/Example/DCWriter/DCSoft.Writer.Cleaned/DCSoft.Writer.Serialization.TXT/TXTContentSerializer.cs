using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.IO;
using System.Text;

namespace DCSoft.Writer.Serialization.TXT
{
	/// <summary>
	///       纯文本格式的文档序列化器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	internal class TXTContentSerializer : ContentSerializer
	{
		public override string FileExtension => ".txt";

		public override string FileFilter => WriterStringsCore.TXTFileFilter;

		public override string Name => "text";

		public override GEnum14 Flags => GEnum14.flag_1 | GEnum14.flag_2 | GEnum14.flag_3 | GEnum14.flag_4;

		/// <summary>
		///       初始化对象
		///       </summary>
		public TXTContentSerializer()
		{
			base.ContentEncoding = Encoding.Default;
		}

		public override bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_4, Name))
			{
				return false;
			}
			using (StreamReader streamReader = new StreamReader(stream, Encoding.Default, detectEncodingFromByteOrderMarks: true))
			{
				string text = streamReader.ReadToEnd();
				document.method_57();
				document.Text = text;
			}
			return true;
		}

		public override bool Deserialize(TextReader reader, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_4, Name))
			{
				return false;
			}
			string text = reader.ReadToEnd();
			document.method_57();
			document.Text = text;
			return true;
		}

		public override bool Serialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_11, Name))
			{
				return false;
			}
			using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.Default))
			{
				string text = document.Text;
				streamWriter.Write(text);
			}
			return true;
		}

		public override bool Serialize(TextWriter writer, XTextDocument document, ContentSerializeOptions options)
		{
			if (!XTextDocument.smethod_8(document.WriterControl, GEnum6.const_11, Name))
			{
				return false;
			}
			writer.Write(document.Text);
			return true;
		}
	}
}
