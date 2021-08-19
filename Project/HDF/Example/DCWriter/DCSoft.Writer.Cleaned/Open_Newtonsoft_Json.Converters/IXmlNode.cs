using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal interface IXmlNode
	{
		XmlNodeType NodeType
		{
			get;
		}

		string LocalName
		{
			get;
		}

		IList<IXmlNode> ChildNodes
		{
			get;
		}

		IList<IXmlNode> Attributes
		{
			get;
		}

		IXmlNode ParentNode
		{
			get;
		}

		string Value
		{
			get;
			set;
		}

		string NamespaceUri
		{
			get;
		}

		object WrappedNode
		{
			get;
		}

		IXmlNode AppendChild(IXmlNode newChild);
	}
}
