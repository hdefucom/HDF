using System.Xml;

namespace ZYCommon
{
	public interface IXMLSerializable
	{
		string GetXMLName();

		bool FromXML(XmlElement RootElement);

		bool ToXML(XmlElement RootElement);
	}
}
