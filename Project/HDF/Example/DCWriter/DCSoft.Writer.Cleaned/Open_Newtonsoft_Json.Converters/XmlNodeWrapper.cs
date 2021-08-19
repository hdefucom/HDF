using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal class XmlNodeWrapper : IXmlNode
	{
		private readonly XmlNode _node;

		private IList<IXmlNode> _childNodes;

		public object WrappedNode => _node;

		public XmlNodeType NodeType => _node.NodeType;

		public virtual string LocalName => _node.LocalName;

		public IList<IXmlNode> ChildNodes
		{
			get
			{
				if (_childNodes == null)
				{
					_childNodes = Enumerable.ToList(Enumerable.Select(Enumerable.Cast<XmlNode>(_node.ChildNodes), WrapNode));
				}
				return _childNodes;
			}
		}

		public IList<IXmlNode> Attributes
		{
			get
			{
				if (_node.Attributes == null)
				{
					return null;
				}
				return Enumerable.ToList(Enumerable.Select(Enumerable.Cast<XmlAttribute>(_node.Attributes), WrapNode));
			}
		}

		public IXmlNode ParentNode
		{
			get
			{
				XmlNode xmlNode = (_node is XmlAttribute) ? ((XmlAttribute)_node).OwnerElement : _node.ParentNode;
				if (xmlNode == null)
				{
					return null;
				}
				return WrapNode(xmlNode);
			}
		}

		public string Value
		{
			get
			{
				return _node.Value;
			}
			set
			{
				_node.Value = value;
			}
		}

		public string NamespaceUri => _node.NamespaceURI;

		public XmlNodeWrapper(XmlNode node)
		{
			_node = node;
		}

		internal static IXmlNode WrapNode(XmlNode node)
		{
			switch (node.NodeType)
			{
			default:
				return new XmlNodeWrapper(node);
			case XmlNodeType.XmlDeclaration:
				return new XmlDeclarationWrapper((XmlDeclaration)node);
			case XmlNodeType.DocumentType:
				return new XmlDocumentTypeWrapper((XmlDocumentType)node);
			case XmlNodeType.Element:
				return new XmlElementWrapper((XmlElement)node);
			}
		}

		public IXmlNode AppendChild(IXmlNode newChild)
		{
			XmlNodeWrapper xmlNodeWrapper = (XmlNodeWrapper)newChild;
			_node.AppendChild(xmlNodeWrapper._node);
			_childNodes = null;
			return newChild;
		}
	}
}
