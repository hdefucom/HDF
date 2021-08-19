using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal class XmlDocumentTypeWrapper : XmlNodeWrapper, IXmlDocumentType
	{
		private readonly XmlDocumentType _documentType;

		public string Name => _documentType.Name;

		public string System => _documentType.SystemId;

		public string Public => _documentType.PublicId;

		public string InternalSubset => _documentType.InternalSubset;

		public override string LocalName => "DOCTYPE";

		public XmlDocumentTypeWrapper(XmlDocumentType documentType)
			: base(documentType)
		{
			_documentType = documentType;
		}
	}
}
