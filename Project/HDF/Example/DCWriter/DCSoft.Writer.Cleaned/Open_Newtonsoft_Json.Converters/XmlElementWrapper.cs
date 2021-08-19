using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal class XmlElementWrapper : XmlNodeWrapper, IXmlElement
	{
		private readonly XmlElement _element;

		public bool IsEmpty => _element.IsEmpty;

		public XmlElementWrapper(XmlElement element)
			: base(element)
		{
			_element = element;
		}

		public void SetAttributeNode(IXmlNode attribute)
		{
			XmlNodeWrapper xmlNodeWrapper = (XmlNodeWrapper)attribute;
			_element.SetAttributeNode((XmlAttribute)xmlNodeWrapper.WrappedNode);
		}

		public string GetPrefixOfNamespace(string namespaceUri)
		{
			return _element.GetPrefixOfNamespace(namespaceUri);
		}
	}
}
