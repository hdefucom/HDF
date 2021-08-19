using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal interface IXmlElement : IXmlNode
	{
		bool IsEmpty
		{
			get;
		}

		void SetAttributeNode(IXmlNode attribute);

		string GetPrefixOfNamespace(string namespaceUri);
	}
}
