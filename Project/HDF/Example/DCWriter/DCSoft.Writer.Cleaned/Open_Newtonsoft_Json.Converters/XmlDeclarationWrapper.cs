using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal class XmlDeclarationWrapper : XmlNodeWrapper, IXmlDeclaration
	{
		private readonly XmlDeclaration _declaration;

		public string Version => _declaration.Version;

		public string Encoding
		{
			get
			{
				return _declaration.Encoding;
			}
			set
			{
				_declaration.Encoding = value;
			}
		}

		public string Standalone
		{
			get
			{
				return _declaration.Standalone;
			}
			set
			{
				_declaration.Standalone = value;
			}
		}

		public XmlDeclarationWrapper(XmlDeclaration declaration)
			: base(declaration)
		{
			_declaration = declaration;
		}
	}
}
