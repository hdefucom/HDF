using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts XML to and from JSON.
	///       </summary>
	[ComVisible(false)]
	public class XmlNodeConverter : JsonConverter
	{
		private const string TextName = "#text";

		private const string CommentName = "#comment";

		private const string CDataName = "#cdata-section";

		private const string WhitespaceName = "#whitespace";

		private const string SignificantWhitespaceName = "#significant-whitespace";

		private const string DeclarationName = "?xml";

		private const string JsonNamespaceUri = "http://james.newtonking.com/projects/json";

		/// <summary>
		///       Gets or sets the name of the root element to insert when deserializing to XML if the JSON structure has produces multiple root elements.
		///       </summary>
		/// <value>The name of the deserialize root element.</value>
		public string DeserializeRootElementName
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a flag to indicate whether to write the Json.NET array attribute.
		///       This attribute helps preserve arrays when converting the written XML back to JSON.
		///       </summary>
		/// <value>
		///   <c>true</c> if the array attibute is written to the XML; otherwise, <c>false</c>.</value>
		public bool WriteArrayAttribute
		{
			get;
			set;
		}

		/// <summary>
		///       Gets or sets a value indicating whether to write the root JSON object.
		///       </summary>
		/// <value>
		///   <c>true</c> if the JSON root object is omitted; otherwise, <c>false</c>.</value>
		public bool OmitRootObject
		{
			get;
			set;
		}

		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <param name="value">The value.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			IXmlNode node = WrapXml(value);
			XmlNamespaceManager manager = new XmlNamespaceManager(new NameTable());
			PushParentNamespaces(node, manager);
			if (!OmitRootObject)
			{
				writer.WriteStartObject();
			}
			SerializeNode(writer, node, manager, !OmitRootObject);
			if (!OmitRootObject)
			{
				writer.WriteEndObject();
			}
		}

		private IXmlNode WrapXml(object value)
		{
			int num = 1;
			if (!(value is XmlNode))
			{
				throw new ArgumentException("Value must be an XML object.", "value");
			}
			return XmlNodeWrapper.WrapNode((XmlNode)value);
		}

		private void PushParentNamespaces(IXmlNode node, XmlNamespaceManager manager)
		{
			int num = 8;
			List<IXmlNode> list = null;
			IXmlNode xmlNode = node;
			while ((xmlNode = xmlNode.ParentNode) != null)
			{
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					if (list == null)
					{
						list = new List<IXmlNode>();
					}
					list.Add(xmlNode);
				}
			}
			if (list != null)
			{
				list.Reverse();
				foreach (IXmlNode item in list)
				{
					manager.PushScope();
					foreach (IXmlNode attribute in item.Attributes)
					{
						if (attribute.NamespaceUri == "http://www.w3.org/2000/xmlns/" && attribute.LocalName != "xmlns")
						{
							manager.AddNamespace(attribute.LocalName, attribute.Value);
						}
					}
				}
			}
		}

		private string ResolveFullName(IXmlNode node, XmlNamespaceManager manager)
		{
			int num = 10;
			string text = (node.NamespaceUri == null || (node.LocalName == "xmlns" && node.NamespaceUri == "http://www.w3.org/2000/xmlns/")) ? null : manager.LookupPrefix(node.NamespaceUri);
			if (!string.IsNullOrEmpty(text))
			{
				return text + ":" + node.LocalName;
			}
			return node.LocalName;
		}

		private string GetPropertyName(IXmlNode node, XmlNamespaceManager manager)
		{
			int num = 11;
			switch (node.NodeType)
			{
			case XmlNodeType.Element:
				return ResolveFullName(node, manager);
			case XmlNodeType.Attribute:
				if (node.NamespaceUri == "http://james.newtonking.com/projects/json")
				{
					return "$" + node.LocalName;
				}
				return "@" + ResolveFullName(node, manager);
			case XmlNodeType.Text:
				return "#text";
			case XmlNodeType.CDATA:
				return "#cdata-section";
			case XmlNodeType.ProcessingInstruction:
				return "?" + ResolveFullName(node, manager);
			case XmlNodeType.Comment:
				return "#comment";
			case XmlNodeType.DocumentType:
				return "!" + ResolveFullName(node, manager);
			case XmlNodeType.Whitespace:
				return "#whitespace";
			case XmlNodeType.SignificantWhitespace:
				return "#significant-whitespace";
			default:
				throw new JsonSerializationException("Unexpected XmlNodeType when getting node name: " + node.NodeType);
			case XmlNodeType.XmlDeclaration:
				return "?xml";
			}
		}

		private bool IsArray(IXmlNode node)
		{
			IXmlNode xmlNode = (node.Attributes != null) ? Enumerable.SingleOrDefault(node.Attributes, delegate(IXmlNode ixmlNode_0)
			{
				int num = 13;
				return ixmlNode_0.LocalName == "Array" && ixmlNode_0.NamespaceUri == "http://james.newtonking.com/projects/json";
			}) : null;
			return xmlNode != null && XmlConvert.ToBoolean(xmlNode.Value);
		}

		private void SerializeGroupedNodes(JsonWriter writer, IXmlNode node, XmlNamespaceManager manager, bool writePropertyName)
		{
			Dictionary<string, List<IXmlNode>> dictionary = new Dictionary<string, List<IXmlNode>>();
			for (int i = 0; i < node.ChildNodes.Count; i++)
			{
				IXmlNode xmlNode = node.ChildNodes[i];
				string propertyName = GetPropertyName(xmlNode, manager);
				if (!dictionary.TryGetValue(propertyName, out List<IXmlNode> value))
				{
					value = new List<IXmlNode>();
					dictionary.Add(propertyName, value);
				}
				value.Add(xmlNode);
			}
			foreach (KeyValuePair<string, List<IXmlNode>> item in dictionary)
			{
				List<IXmlNode> value2 = item.Value;
				if (value2.Count == 1 && !IsArray(value2[0]))
				{
					SerializeNode(writer, value2[0], manager, writePropertyName);
				}
				else
				{
					string key = item.Key;
					if (writePropertyName)
					{
						writer.WritePropertyName(key);
					}
					writer.WriteStartArray();
					for (int i = 0; i < value2.Count; i++)
					{
						SerializeNode(writer, value2[i], manager, writePropertyName: false);
					}
					writer.WriteEndArray();
				}
			}
		}

		private void SerializeNode(JsonWriter writer, IXmlNode node, XmlNamespaceManager manager, bool writePropertyName)
		{
			int num = 4;
			switch (node.NodeType)
			{
			case XmlNodeType.Element:
				if (IsArray(node) && Enumerable.All(node.ChildNodes, (IXmlNode ixmlNode_0) => ixmlNode_0.LocalName == node.LocalName) && node.ChildNodes.Count > 0)
				{
					SerializeGroupedNodes(writer, node, manager, writePropertyName: false);
					break;
				}
				manager.PushScope();
				foreach (IXmlNode attribute in node.Attributes)
				{
					if (attribute.NamespaceUri == "http://www.w3.org/2000/xmlns/")
					{
						string prefix = (attribute.LocalName != "xmlns") ? attribute.LocalName : string.Empty;
						string value = attribute.Value;
						manager.AddNamespace(prefix, value);
					}
				}
				if (writePropertyName)
				{
					writer.WritePropertyName(GetPropertyName(node, manager));
				}
				if (!Enumerable.Any(ValueAttributes(node.Attributes)) && node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)
				{
					writer.WriteValue(node.ChildNodes[0].Value);
				}
				else if (node.ChildNodes.Count == 0 && CollectionUtils.IsNullOrEmpty(node.Attributes))
				{
					IXmlElement xmlElement = (IXmlElement)node;
					if (xmlElement.IsEmpty)
					{
						writer.WriteNull();
					}
					else
					{
						writer.WriteValue(string.Empty);
					}
				}
				else
				{
					writer.WriteStartObject();
					for (int i = 0; i < node.Attributes.Count; i++)
					{
						SerializeNode(writer, node.Attributes[i], manager, writePropertyName: true);
					}
					SerializeGroupedNodes(writer, node, manager, writePropertyName: true);
					writer.WriteEndObject();
				}
				manager.PopScope();
				break;
			case XmlNodeType.Comment:
				if (writePropertyName)
				{
					writer.WriteComment(node.Value);
				}
				break;
			case XmlNodeType.DocumentType:
			{
				IXmlDocumentType xmlDocumentType = (IXmlDocumentType)node;
				writer.WritePropertyName(GetPropertyName(node, manager));
				writer.WriteStartObject();
				if (!string.IsNullOrEmpty(xmlDocumentType.Name))
				{
					writer.WritePropertyName("@name");
					writer.WriteValue(xmlDocumentType.Name);
				}
				if (!string.IsNullOrEmpty(xmlDocumentType.Public))
				{
					writer.WritePropertyName("@public");
					writer.WriteValue(xmlDocumentType.Public);
				}
				if (!string.IsNullOrEmpty(xmlDocumentType.System))
				{
					writer.WritePropertyName("@system");
					writer.WriteValue(xmlDocumentType.System);
				}
				if (!string.IsNullOrEmpty(xmlDocumentType.InternalSubset))
				{
					writer.WritePropertyName("@internalSubset");
					writer.WriteValue(xmlDocumentType.InternalSubset);
				}
				writer.WriteEndObject();
				break;
			}
			case XmlNodeType.Document:
			case XmlNodeType.DocumentFragment:
				SerializeGroupedNodes(writer, node, manager, writePropertyName);
				break;
			case XmlNodeType.Attribute:
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				if ((!(node.NamespaceUri == "http://www.w3.org/2000/xmlns/") || !(node.Value == "http://james.newtonking.com/projects/json")) && (!(node.NamespaceUri == "http://james.newtonking.com/projects/json") || !(node.LocalName == "Array")))
				{
					if (writePropertyName)
					{
						writer.WritePropertyName(GetPropertyName(node, manager));
					}
					writer.WriteValue(node.Value);
				}
				break;
			default:
				throw new JsonSerializationException("Unexpected XmlNodeType when serializing nodes: " + node.NodeType);
			case XmlNodeType.XmlDeclaration:
			{
				IXmlDeclaration xmlDeclaration = (IXmlDeclaration)node;
				writer.WritePropertyName(GetPropertyName(node, manager));
				writer.WriteStartObject();
				if (!string.IsNullOrEmpty(xmlDeclaration.Version))
				{
					writer.WritePropertyName("@version");
					writer.WriteValue(xmlDeclaration.Version);
				}
				if (!string.IsNullOrEmpty(xmlDeclaration.Encoding))
				{
					writer.WritePropertyName("@encoding");
					writer.WriteValue(xmlDeclaration.Encoding);
				}
				if (!string.IsNullOrEmpty(xmlDeclaration.Standalone))
				{
					writer.WritePropertyName("@standalone");
					writer.WriteValue(xmlDeclaration.Standalone);
				}
				writer.WriteEndObject();
				break;
			}
			}
		}

		/// <summary>
		///       Reads the JSON representation of the object.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int num = 2;
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			XmlNamespaceManager manager = new XmlNamespaceManager(new NameTable());
			IXmlDocument xmlDocument = null;
			IXmlNode xmlNode = null;
			if (typeof(XmlNode).IsAssignableFrom(objectType))
			{
				if (objectType != typeof(XmlDocument))
				{
					throw new JsonSerializationException("XmlNodeConverter only supports deserializing XmlDocuments");
				}
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.XmlResolver = null;
				xmlDocument = new XmlDocumentWrapper(xmlDocument2);
				xmlNode = xmlDocument;
			}
			if (xmlDocument == null || xmlNode == null)
			{
				throw new JsonSerializationException("Unexpected type when converting XML: " + objectType);
			}
			if (reader.TokenType != JsonToken.StartObject)
			{
				throw new JsonSerializationException("XmlNodeConverter can only convert JSON that begins with an object.");
			}
			if (!string.IsNullOrEmpty(DeserializeRootElementName))
			{
				ReadElement(reader, xmlDocument, xmlNode, DeserializeRootElementName, manager);
			}
			else
			{
				reader.Read();
				DeserializeNode(reader, xmlDocument, manager, xmlNode);
			}
			return xmlDocument.WrappedNode;
		}

		private void DeserializeValue(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, string propertyName, IXmlNode currentNode)
		{
			int num = 2;
			switch (propertyName)
			{
			case "#significant-whitespace":
				currentNode.AppendChild(document.CreateSignificantWhitespace(reader.Value.ToString()));
				return;
			case "#whitespace":
				currentNode.AppendChild(document.CreateWhitespace(reader.Value.ToString()));
				return;
			case "#cdata-section":
				currentNode.AppendChild(document.CreateCDataSection(reader.Value.ToString()));
				return;
			case "#text":
				currentNode.AppendChild(document.CreateTextNode(reader.Value.ToString()));
				return;
			}
			if (!string.IsNullOrEmpty(propertyName) && propertyName[0] == '?')
			{
				CreateInstruction(reader, document, currentNode, propertyName);
			}
			else if (string.Equals(propertyName, "!DOCTYPE", StringComparison.OrdinalIgnoreCase))
			{
				CreateDocumentType(reader, document, currentNode);
			}
			else if (reader.TokenType == JsonToken.StartArray)
			{
				ReadArrayElements(reader, document, propertyName, currentNode, manager);
			}
			else
			{
				ReadElement(reader, document, currentNode, propertyName, manager);
			}
		}

		private void ReadElement(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName, XmlNamespaceManager manager)
		{
			int num = 16;
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new JsonSerializationException("XmlNodeConverter cannot convert JSON with an empty property name to XML.");
			}
			Dictionary<string, string> dictionary = ReadAttributeElements(reader, manager);
			string prefix = MiscellaneousUtils.GetPrefix(propertyName);
			if (StringUtils.StartsWith(propertyName, '@'))
			{
				string text = propertyName.Substring(1);
				string value = reader.Value.ToString();
				string prefix2 = MiscellaneousUtils.GetPrefix(text);
				IXmlNode attributeNode = (!string.IsNullOrEmpty(prefix2)) ? document.CreateAttribute(text, manager.LookupNamespace(prefix2), value) : document.CreateAttribute(text, value);
				((IXmlElement)currentNode).SetAttributeNode(attributeNode);
				return;
			}
			IXmlElement xmlElement = CreateElement(propertyName, document, prefix, manager);
			currentNode.AppendChild(xmlElement);
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				string prefix2 = MiscellaneousUtils.GetPrefix(item.Key);
				IXmlNode attributeNode = (!string.IsNullOrEmpty(prefix2)) ? document.CreateAttribute(item.Key, manager.LookupNamespace(prefix2) ?? string.Empty, item.Value) : document.CreateAttribute(item.Key, item.Value);
				xmlElement.SetAttributeNode(attributeNode);
			}
			if (reader.TokenType == JsonToken.String || reader.TokenType == JsonToken.Integer || reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Boolean || reader.TokenType == JsonToken.Date)
			{
				xmlElement.AppendChild(document.CreateTextNode(ConvertTokenToXmlValue(reader)));
			}
			else if (reader.TokenType != JsonToken.Null)
			{
				if (reader.TokenType != JsonToken.EndObject)
				{
					manager.PushScope();
					DeserializeNode(reader, document, manager, xmlElement);
					manager.PopScope();
				}
				manager.RemoveNamespace(string.Empty, manager.DefaultNamespace);
			}
		}

		private string ConvertTokenToXmlValue(JsonReader reader)
		{
			int num = 13;
			if (reader.TokenType == JsonToken.String)
			{
				return reader.Value.ToString();
			}
			if (reader.TokenType == JsonToken.Integer)
			{
				return XmlConvert.ToString(Convert.ToInt64(reader.Value, CultureInfo.InvariantCulture));
			}
			if (reader.TokenType == JsonToken.Float)
			{
				if (reader.Value is decimal)
				{
					return XmlConvert.ToString((decimal)reader.Value);
				}
				if (reader.Value is float)
				{
					return XmlConvert.ToString((float)reader.Value);
				}
				return XmlConvert.ToString(Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture));
			}
			if (reader.TokenType == JsonToken.Boolean)
			{
				return XmlConvert.ToString(Convert.ToBoolean(reader.Value, CultureInfo.InvariantCulture));
			}
			if (reader.TokenType == JsonToken.Date)
			{
				DateTime value = Convert.ToDateTime(reader.Value, CultureInfo.InvariantCulture);
				return XmlConvert.ToString(value, DateTimeUtils.ToSerializationMode(value.Kind));
			}
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot get an XML string value from token type '{0}'.", CultureInfo.InvariantCulture, reader.TokenType));
		}

		private void ReadArrayElements(JsonReader reader, IXmlDocument document, string propertyName, IXmlNode currentNode, XmlNamespaceManager manager)
		{
			string prefix = MiscellaneousUtils.GetPrefix(propertyName);
			IXmlElement xmlElement = CreateElement(propertyName, document, prefix, manager);
			currentNode.AppendChild(xmlElement);
			int num = 0;
			while (reader.Read() && reader.TokenType != JsonToken.EndArray)
			{
				DeserializeValue(reader, document, manager, propertyName, xmlElement);
				num++;
			}
			if (WriteArrayAttribute)
			{
				AddJsonArrayAttribute(xmlElement, document);
			}
			if (num == 1 && WriteArrayAttribute)
			{
				IXmlElement element = Enumerable.Single(Enumerable.OfType<IXmlElement>(xmlElement.ChildNodes), (IXmlElement ixmlElement_0) => ixmlElement_0.LocalName == propertyName);
				AddJsonArrayAttribute(element, document);
			}
		}

		private void AddJsonArrayAttribute(IXmlElement element, IXmlDocument document)
		{
			element.SetAttributeNode(document.CreateAttribute("json:Array", "http://james.newtonking.com/projects/json", "true"));
		}

		private Dictionary<string, string> ReadAttributeElements(JsonReader reader, XmlNamespaceManager manager)
		{
			int num = 13;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			bool flag = false;
			bool flag2 = false;
			if (reader.TokenType != JsonToken.String && reader.TokenType != JsonToken.Null && reader.TokenType != JsonToken.Boolean && reader.TokenType != JsonToken.Integer && reader.TokenType != JsonToken.Float && reader.TokenType != JsonToken.Date && reader.TokenType != JsonToken.StartConstructor)
			{
				while (!flag && !flag2 && reader.Read())
				{
					switch (reader.TokenType)
					{
					case JsonToken.EndObject:
						flag2 = true;
						break;
					case JsonToken.PropertyName:
					{
						string text = reader.Value.ToString();
						if (!string.IsNullOrEmpty(text))
						{
							switch (text[0])
							{
							default:
								flag = true;
								break;
							case '@':
							{
								text = text.Substring(1);
								reader.Read();
								string value = ConvertTokenToXmlValue(reader);
								dictionary.Add(text, value);
								if (IsNamespaceAttribute(text, out string prefix))
								{
									manager.AddNamespace(prefix, value);
								}
								break;
							}
							case '$':
							{
								text = text.Substring(1);
								reader.Read();
								string value = reader.Value.ToString();
								string text2 = manager.LookupPrefix("http://james.newtonking.com/projects/json");
								if (text2 == null)
								{
									int? num2 = null;
									while (manager.LookupNamespace("json" + num2) != null)
									{
										num2 = num2.GetValueOrDefault() + 1;
									}
									text2 = "json" + num2;
									dictionary.Add("xmlns:" + text2, "http://james.newtonking.com/projects/json");
									manager.AddNamespace(text2, "http://james.newtonking.com/projects/json");
								}
								dictionary.Add(text2 + ":" + text, value);
								break;
							}
							}
						}
						else
						{
							flag = true;
						}
						break;
					}
					case JsonToken.Comment:
						flag2 = true;
						break;
					default:
						throw new JsonSerializationException("Unexpected JsonToken: " + reader.TokenType);
					}
				}
			}
			return dictionary;
		}

		private void CreateInstruction(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName)
		{
			int num = 6;
			if (propertyName == "?xml")
			{
				string version = null;
				string encoding = null;
				string standalone = null;
				while (reader.Read() && reader.TokenType != JsonToken.EndObject)
				{
					switch (reader.Value.ToString())
					{
					case "@standalone":
						reader.Read();
						standalone = reader.Value.ToString();
						break;
					case "@encoding":
						reader.Read();
						encoding = reader.Value.ToString();
						break;
					case "@version":
						reader.Read();
						version = reader.Value.ToString();
						break;
					default:
						throw new JsonSerializationException("Unexpected property name encountered while deserializing XmlDeclaration: " + reader.Value);
					}
				}
				IXmlNode newChild = document.CreateXmlDeclaration(version, encoding, standalone);
				currentNode.AppendChild(newChild);
			}
			else
			{
				IXmlNode newChild2 = document.CreateProcessingInstruction(propertyName.Substring(1), reader.Value.ToString());
				currentNode.AppendChild(newChild2);
			}
		}

		private void CreateDocumentType(JsonReader reader, IXmlDocument document, IXmlNode currentNode)
		{
			int num = 0;
			string name = null;
			string publicId = null;
			string systemId = null;
			string internalSubset = null;
			while (reader.Read() && reader.TokenType != JsonToken.EndObject)
			{
				switch (reader.Value.ToString())
				{
				case "@internalSubset":
					reader.Read();
					internalSubset = reader.Value.ToString();
					break;
				case "@system":
					reader.Read();
					systemId = reader.Value.ToString();
					break;
				case "@public":
					reader.Read();
					publicId = reader.Value.ToString();
					break;
				case "@name":
					reader.Read();
					name = reader.Value.ToString();
					break;
				default:
					throw new JsonSerializationException("Unexpected property name encountered while deserializing XmlDeclaration: " + reader.Value);
				}
			}
			IXmlNode newChild = document.CreateXmlDocumentType(name, publicId, systemId, internalSubset);
			currentNode.AppendChild(newChild);
		}

		private IXmlElement CreateElement(string elementName, IXmlDocument document, string elementPrefix, XmlNamespaceManager manager)
		{
			string text = string.IsNullOrEmpty(elementPrefix) ? manager.DefaultNamespace : manager.LookupNamespace(elementPrefix);
			return (!string.IsNullOrEmpty(text)) ? document.CreateElement(elementName, text) : document.CreateElement(elementName);
		}

		private void DeserializeNode(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, IXmlNode currentNode)
		{
			int num = 18;
			bool num3;
			do
			{
				switch (reader.TokenType)
				{
				case JsonToken.EndObject:
				case JsonToken.EndArray:
					return;
				case JsonToken.Comment:
					currentNode.AppendChild(document.CreateComment((string)reader.Value));
					goto IL_0024;
				case JsonToken.PropertyName:
					if (currentNode.NodeType != XmlNodeType.Document || document.DocumentElement == null)
					{
						string propertyName = reader.Value.ToString();
						reader.Read();
						if (reader.TokenType == JsonToken.StartArray)
						{
							int num2 = 0;
							while (reader.Read() && reader.TokenType != JsonToken.EndArray)
							{
								DeserializeValue(reader, document, manager, propertyName, currentNode);
								num2++;
							}
							if (num2 == 1 && WriteArrayAttribute)
							{
								IXmlElement element = Enumerable.Single(Enumerable.OfType<IXmlElement>(currentNode.ChildNodes), (IXmlElement ixmlElement_0) => ixmlElement_0.LocalName == propertyName);
								AddJsonArrayAttribute(element, document);
							}
						}
						else
						{
							DeserializeValue(reader, document, manager, propertyName, currentNode);
						}
						goto IL_0024;
					}
					throw new JsonSerializationException("JSON root object has multiple properties. The root object must have a single property in order to create a valid XML document. Consider specifing a DeserializeRootElementName.");
				case JsonToken.StartConstructor:
				{
					string propertyName2 = reader.Value.ToString();
					while (reader.Read() && reader.TokenType != JsonToken.EndConstructor)
					{
						DeserializeValue(reader, document, manager, propertyName2, currentNode);
					}
					goto IL_0024;
				}
				default:
					{
						throw new JsonSerializationException("Unexpected JsonToken when deserializing node: " + reader.TokenType);
					}
					IL_0024:
					num3 = (reader.TokenType == JsonToken.PropertyName || reader.Read());
					break;
				}
			}
			while (num3);
		}

		/// <summary>
		///       Checks if the attributeName is a namespace attribute.
		///       </summary>
		/// <param name="attributeName">Attribute name to test.</param>
		/// <param name="prefix">The attribute name prefix if it has one, otherwise an empty string.</param>
		/// <returns>True if attribute name is for a namespace attribute, otherwise false.</returns>
		private bool IsNamespaceAttribute(string attributeName, out string prefix)
		{
			if (attributeName.StartsWith("xmlns", StringComparison.Ordinal))
			{
				if (attributeName.Length == 5)
				{
					prefix = string.Empty;
					return true;
				}
				if (attributeName[5] == ':')
				{
					prefix = attributeName.Substring(6, attributeName.Length - 6);
					return true;
				}
			}
			prefix = null;
			return false;
		}

		private IEnumerable<IXmlNode> ValueAttributes(IEnumerable<IXmlNode> ienumerable_0)
		{
			return Enumerable.Where(ienumerable_0, (IXmlNode ixmlNode_0) => ixmlNode_0.NamespaceUri != "http://james.newtonking.com/projects/json");
		}

		/// <summary>
		///       Determines whether this instance can convert the specified value type.
		///       </summary>
		/// <param name="valueType">Type of the value.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
		///       </returns>
		public override bool CanConvert(Type valueType)
		{
			if (typeof(XmlNode).IsAssignableFrom(valueType))
			{
				return true;
			}
			return false;
		}
	}
}
