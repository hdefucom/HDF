using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       处理XML文档的通用模块
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	[ComVisible(false)]
	public sealed class XMLHelper
	{
		private class XmlPropertyInfo : IComparable
		{
			public static readonly object NoneDefaultValue = new object();

			public string Name = null;

			public PropertyInfo Property = null;

			public object DefaultValue = NoneDefaultValue;

			public int ValueType = 1;

			public string DataType = null;

			public Attribute[] ArrayItemAttributes = null;

			public int CompareTo(object target)
			{
				XmlPropertyInfo xmlPropertyInfo = (XmlPropertyInfo)target;
				if (xmlPropertyInfo.ValueType != ValueType)
				{
					return ValueType - xmlPropertyInfo.ValueType;
				}
				return string.Compare(Name, ((XmlPropertyInfo)target).Name);
			}
		}

		private const string BaseEntryChars = " <>&\"'￠£¥€§©®™×÷";

		public const string XML_Stylesheet = "xml-stylesheet";

		public const string XMLContentType = "text/xml";

		                                                                    /// <summary>
		                                                                    ///       XSL前缀元素名称空间字符串
		                                                                    ///       </summary>
		public const string XslNamespaceURI = "http:                                                                    //www.w3.org/1999/XSL/Transform";

		                                                                    /// <summary>
		                                                                    ///       要序列化的对象的原始名称
		                                                                    ///       </summary>
		private static Dictionary<Type, string> _NativeXmlName = new Dictionary<Type, string>();

		                                                                    /// <summary>
		                                                                    ///       要序列化的对象属性信息字典
		                                                                    ///       </summary>
		private static Dictionary<Type, List<XmlPropertyInfo>> _SerializeInfos = new Dictionary<Type, List<XmlPropertyInfo>>();

		public static string ToXMLEntry(string text)
		{
			int num = 18;
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in text)
			{
				if (c > '\u007f' || " <>&\"'￠£¥€§©®™×÷".IndexOf(c) >= 0)
				{
					stringBuilder.Append("&#x" + Convert.ToInt32(c).ToString("X") + ";");
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static string AllToXMLEntry(string text)
		{
			int num = 6;
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in text)
			{
				stringBuilder.Append("&#x" + Convert.ToInt32(value).ToString("X") + ";");
			}
			return stringBuilder.ToString();
		}

		public static string ToXMLEntryRandom(string text, double rate)
		{
			int num = 6;
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			Random random = new Random();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in text)
			{
				if (random.NextDouble() < rate || " <>&\"'￠£¥€§©®™×÷".IndexOf(value) >= 0)
				{
					stringBuilder.Append("&#x" + Convert.ToInt32(value).ToString("X") + ";");
				}
				else
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       清除XML的头文本
		                                                                    ///       </summary>
		                                                                    /// <param name="xmlText">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string CleanupXMLHeader(string xmlText)
		{
			int num = 6;
			if (string.IsNullOrEmpty(xmlText))
			{
				return xmlText;
			}
			int num2 = xmlText.IndexOf("?>");
			if (num2 >= 0 && num2 < 50)
			{
				num2 = xmlText.IndexOf("<", num2 + 1);
				if (num2 > 0)
				{
					xmlText = xmlText.Substring(num2);
				}
			}
			return xmlText;
		}

		                                                                    /// <summary>
		                                                                    ///       保存对象到一个XML字符串中
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象实例</param>
		                                                                    /// <returns>XML字符串</returns>
		public static string SaveObjectToXMLString(object instance)
		{
			int num = 9;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.None;
			SaveObjectToXMLWriter(instance, xmlTextWriter);
			xmlTextWriter.Close();
			string xmlText = stringWriter.ToString();
			return CleanupXMLHeader(xmlText);
		}

		                                                                    /// <summary>
		                                                                    ///       保存对象到一个带缩进的XML字符串中
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象</param>
		                                                                    /// <returns>XML字符串</returns>
		public static string SaveObjectToIndentXMLString(object instance)
		{
			int num = 2;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Indentation = 3;
			xmlTextWriter.IndentChar = ' ';
			SaveObjectToXMLWriter(instance, xmlTextWriter);
			xmlTextWriter.Close();
			string xmlText = stringWriter.ToString();
			return CleanupXMLHeader(xmlText);
		}

		public static object LoadObjectFromXMLString(Type type, string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			StringReader stringReader = new StringReader(string_0);
			XmlTextReader reader = new XmlTextReader(stringReader);
			object result = LoadObjectFromXMLReader(type, reader);
			stringReader.Close();
			return result;
		}

		public static object LoadObjectFromXMLReader(Type type, XmlTextReader reader)
		{
			reader.Normalization = false;
			if (type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(DateTime)))
			{
				reader.ReadStartElement();
				string value = reader.ReadElementString();
				return Convert.ChangeType(value, type);
			}
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			return xmlSerializer.Deserialize(reader);
		}

		public static void SaveObjectToXMLStream(object instance, Stream stream)
		{
			int num = 10;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("fileName");
			}
			using (StreamWriter w = new StreamWriter(stream, Encoding.UTF8))
			{
				XmlTextWriter writer = new XmlTextWriter(w);
				SaveObjectToXMLWriter(instance, writer);
			}
		}

		public static void SaveObjectToXMLFile(object instance, string fileName)
		{
			int num = 17;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			using (StreamWriter w = new StreamWriter(fileName, append: false, Encoding.UTF8))
			{
				XmlTextWriter writer = new XmlTextWriter(w);
				SaveObjectToXMLWriter(instance, writer);
			}
		}

		public static void SaveObjectToXMLWriter(object instance, XmlTextWriter writer)
		{
			int num = 11;
			Type type = instance.GetType();
			if (type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(DateTime)))
			{
				writer.WriteStartDocument();
				writer.WriteStartElement("Value");
				writer.WriteString(Convert.ToString(instance));
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
			else
			{
				XmlSerializer xmlSerializer = new XmlSerializer(instance.GetType());
				xmlSerializer.Serialize(writer, instance);
			}
		}

		public static void SaveObjectToTextWriter(object instance, TextWriter writer)
		{
			instance.GetType();
			XmlTextWriter writer2 = new XmlTextWriter(writer);
			SaveObjectToXMLWriter(instance, writer2);
		}

		public static object LoadObjectFromXMLFile(Type type, string fileName)
		{
			int num = 13;
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			using (StreamReader input = new StreamReader(fileName, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
			{
				XmlTextReader reader = new XmlTextReader(input);
				return LoadObjectFromXMLReader(type, reader);
			}
		}

		public static object LoadObjectFromStream(Type type, Stream stream)
		{
			int num = 9;
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			using (StreamReader input = new StreamReader(stream, Encoding.UTF8))
			{
				XmlTextReader reader = new XmlTextReader(input);
				return LoadObjectFromXMLReader(type, reader);
			}
		}

		public static object LoadObjectUseXMLSerialize(string FileName, Type ObjectType)
		{
			int num = 2;
			if (FileName == null || FileName.Length == 0)
			{
				throw new ArgumentNullException("FileName");
			}
			if (ObjectType == null)
			{
				throw new ArgumentNullException("ObjectType");
			}
			if (!File.Exists(FileName))
			{
				return null;
			}
			XmlTextReader xmlTextReader = new XmlTextReader(FileName);
			XmlSerializer xmlSerializer = new XmlSerializer(ObjectType);
			object result = xmlSerializer.Deserialize(xmlTextReader);
			xmlTextReader.Close();
			return result;
		}

		public static void SaveObjectUseXMLSerialize(string FileName, object ObjectValue)
		{
			int num = 8;
			if (FileName == null || FileName.Length == 0)
			{
				throw new ArgumentNullException("FileName");
			}
			if (ObjectValue == null)
			{
				throw new ArgumentNullException("ObjectValue");
			}
			if (File.Exists(FileName))
			{
				File.SetAttributes(FileName, FileAttributes.Normal);
			}
			XmlTextWriter xmlTextWriter = new XmlTextWriter(FileName, Encoding.UTF8);
			xmlTextWriter.IndentChar = ' ';
			xmlTextWriter.Indentation = 3;
			xmlTextWriter.Formatting = Formatting.Indented;
			XmlSerializer xmlSerializer = new XmlSerializer(ObjectValue.GetType());
			xmlSerializer.Serialize(xmlTextWriter, ObjectValue);
			xmlTextWriter.Close();
		}

		                                                                    /// <summary>
		                                                                    ///       删除XML字符串中的XML声明头部分
		                                                                    ///       </summary>
		                                                                    /// <param name="strXML">XML字符串</param>
		                                                                    /// <returns>处理后的XML字符串</returns>
		[Obsolete("请使用CleanupXMLHeader()")]
		public static string RemoveXMLDeclare(string strXML)
		{
			if (strXML == null || strXML.Length == 0)
			{
				return strXML;
			}
			int num = strXML.IndexOf('<');
			while (num >= 0 && num < strXML.Length - 1 && strXML[num + 1] == '?')
			{
				num = strXML.IndexOf('<', num + 1);
			}
			if (num <= 0)
			{
				return strXML;
			}
			return strXML.Substring(num);
		}

		                                                                    /// <summary>
		                                                                    ///       对XML节点输出格式化的XML字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="node">XML节点</param>
		                                                                    /// <returns>生成的XML字符串</returns>
		public static string FormatXMLString(XmlNode node)
		{
			return FormatXMLString(node, ' ', 3);
		}

		                                                                    /// <summary>
		                                                                    ///       对XML节点输出格式化的XML字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="node">XML节点</param>
		                                                                    /// <param name="IndentChar">缩进字符</param>
		                                                                    /// <param name="Indentation">每层缩进量</param>
		                                                                    /// <returns>生成的XML字符串</returns>
		public static string FormatXMLString(XmlNode node, char IndentChar, int Indentation)
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.IndentChar = IndentChar;
			xmlTextWriter.Indentation = Indentation;
			xmlTextWriter.Formatting = Formatting.Indented;
			node.WriteTo(xmlTextWriter);
			xmlTextWriter.Close();
			return CleanupXMLHeader(stringWriter.ToString());
		}

		                                                                    /// <summary>
		                                                                    ///       对XML字符串进行缩进的格式化处理
		                                                                    ///       </summary>
		                                                                    /// <param name="strXML">原始XML字符串</param>
		                                                                    /// <param name="IndentChar">缩进字符</param>
		                                                                    /// <param name="Indentation">每层缩进量</param>
		                                                                    /// <returns>处理后的XML字符串</returns>
		public static string FormatXMLString(string strXML, char IndentChar, int Indentation)
		{
			StringReader input = new StringReader(strXML);
			StringWriter stringWriter = new StringWriter();
			XmlTextReader xmlTextReader = new XmlTextReader(input);
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Indentation = Indentation;
			xmlTextWriter.IndentChar = IndentChar;
			if (Indentation > 0)
			{
				xmlTextWriter.Formatting = Formatting.Indented;
			}
			else
			{
				xmlTextWriter.Formatting = Formatting.None;
			}
			xmlTextWriter.WriteStartDocument();
			while (xmlTextReader.Read())
			{
				switch (xmlTextReader.NodeType)
				{
				case XmlNodeType.EndElement:
					xmlTextWriter.WriteEndElement();
					break;
				case XmlNodeType.Element:
				{
					bool isEmptyElement = xmlTextReader.IsEmptyElement;
					xmlTextWriter.WriteStartElement(xmlTextReader.Prefix, xmlTextReader.LocalName, xmlTextReader.NamespaceURI);
					while (xmlTextReader.MoveToNextAttribute())
					{
						xmlTextWriter.WriteAttributeString(xmlTextReader.Prefix, xmlTextReader.LocalName, xmlTextReader.NamespaceURI, xmlTextReader.Value);
					}
					if (isEmptyElement)
					{
						xmlTextWriter.WriteEndElement();
					}
					break;
				}
				case XmlNodeType.Text:
					xmlTextWriter.WriteString(xmlTextReader.Value);
					break;
				case XmlNodeType.CDATA:
					xmlTextWriter.WriteCData(xmlTextReader.Value);
					break;
				case XmlNodeType.ProcessingInstruction:
					xmlTextWriter.WriteProcessingInstruction(xmlTextReader.Name, xmlTextReader.Value);
					break;
				case XmlNodeType.Comment:
					xmlTextWriter.WriteComment(xmlTextReader.Value);
					break;
				}
			}
			xmlTextReader.Close();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
			string xmlText = stringWriter.ToString();
			return CleanupXMLHeader(xmlText);
		}

		                                                                    /// <summary>
		                                                                    ///       添加XML值
		                                                                    ///       </summary>
		                                                                    /// <param name="RootNode">
		                                                                    /// </param>
		                                                                    /// <param name="strPath">
		                                                                    /// </param>
		                                                                    /// <param name="nsm">
		                                                                    /// </param>
		                                                                    /// <param name="strValue">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static bool AppendXMLValueByPath(XmlNode RootNode, string strPath, XmlNamespaceManager xmlNamespaceManager_0, string strValue)
		{
			int num = 2;
			XmlNode xmlNode = CreateXMLNodeByPath(RootNode, strPath, 1, xmlNamespaceManager_0);
			if (xmlNode != null)
			{
				string text = null;
				text = ((!(xmlNode is XmlElement)) ? xmlNode.Value : xmlNode.InnerText);
				text = ((!StringFormatHelper.HasContent(text)) ? strValue : (text + "," + strValue));
				if (xmlNode is XmlElement)
				{
					xmlNode.InnerText = text;
				}
				else
				{
					xmlNode.Value = text;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       保存指定数据到指定根节点下的指定路径
		                                                                    ///       </summary>
		                                                                    /// <param name="RootNode">根节点</param>
		                                                                    /// <param name="strPath">路径</param>
		                                                                    /// <param name="nsm">名称空间管理器</param>
		                                                                    /// <param name="strValue">数值</param>
		                                                                    /// <returns>操作是否成功</returns>
		public static bool SetXMLValueByPath(XmlNode RootNode, string strPath, XmlNamespaceManager xmlNamespaceManager_0, string strValue)
		{
			XmlNode xmlNode = CreateXMLNodeByPath(RootNode, strPath, 1, xmlNamespaceManager_0);
			if (xmlNode != null)
			{
				if (xmlNode is XmlElement)
				{
					xmlNode.InnerText = strValue;
				}
				else
				{
					xmlNode.Value = strValue;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定根节点下的指定路径的XML节点的数据
		                                                                    ///       </summary>
		                                                                    /// <param name="RootNode">根节点</param>
		                                                                    /// <param name="strPath">路径</param>
		                                                                    /// <param name="nsm">名称空间管理器</param>
		                                                                    /// <returns>获得的字符串数据</returns>
		public static string GetXMLValueByPath(XmlNode RootNode, string strPath, XmlNamespaceManager xmlNamespaceManager_0)
		{
			XmlNode xmlNode = CreateXMLNodeByPath(RootNode, strPath, 0, xmlNamespaceManager_0);
			if (xmlNode == null)
			{
				return null;
			}
			if (xmlNode is XmlElement)
			{
				return xmlNode.InnerText;
			}
			return xmlNode.Value;
		}

		                                                                    /// <summary>
		                                                                    ///       根据路径字符串创建XML节点
		                                                                    ///       </summary>
		                                                                    /// <param name="RootNode">根节点</param>
		                                                                    /// <param name="strPath">路径字符串</param>
		                                                                    /// <param name="Create">
		                                                                    ///       创建节点的模式 0:若未找到节点则退出函数 , 
		                                                                    ///       1:若未找到节点则创建节点 2:不查找节点,立即创建节点</param>
		                                                                    /// <param name="nsm">名称空间管理对象</param>
		                                                                    /// <returns>找到或创建的XML节点</returns>
		public static XmlNode CreateXMLNodeByPath(XmlNode RootNode, string strPath, int Create, XmlNamespaceManager xmlNamespaceManager_0)
		{
			int num = 14;
			if (Create != 0 && Create != 1 && Create != 2)
			{
				throw new ArgumentException("Create参数无效");
			}
			if (RootNode == null)
			{
				throw new ArgumentNullException("RootNode", "未指定根节点");
			}
			if (strPath == null)
			{
				throw new ArgumentNullException("strPath", "未指定路径");
			}
			if (XmlReader.IsName(strPath))
			{
				if (Create == 0 || Create == 1)
				{
					foreach (XmlNode childNode in RootNode.ChildNodes)
					{
						if (childNode.Name == strPath)
						{
							return childNode;
						}
					}
				}
				if (Create == 1 || Create == 2)
				{
					XmlElement xmlElement = RootNode.OwnerDocument.CreateElement(strPath);
					RootNode.AppendChild(xmlElement);
					return xmlElement;
				}
			}
			XmlNode xmlNode2 = null;
			if (Create == 0 || Create == 1)
			{
				xmlNode2 = RootNode.SelectSingleNode(strPath, xmlNamespaceManager_0);
				if (xmlNode2 != null)
				{
					return xmlNode2;
				}
				if (Create == 0)
				{
					return null;
				}
			}
			string[] array = strPath.Split('/');
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					string text = array[num2];
					text = text.Trim();
					if (text.StartsWith("@"))
					{
						text = text.Substring(1);
						text = text.Trim();
					}
					if (!XmlReader.IsName(text))
					{
						break;
					}
					num2++;
					continue;
				}
				XmlDocument ownerDocument = RootNode.OwnerDocument;
				for (num2 = 0; num2 < array.Length; num2++)
				{
					string text = array[num2];
					text = text.Trim();
					if (text.StartsWith("@"))
					{
						if (RootNode.Attributes == null)
						{
							return null;
						}
						string text2 = text.Substring(1);
						text2 = text2.Trim();
						xmlNode2 = RootNode.Attributes[text2];
						if (xmlNode2 == null)
						{
							xmlNode2 = ownerDocument.CreateAttribute(text2);
							RootNode.Attributes.Append((XmlAttribute)xmlNode2);
							break;
						}
					}
					else
					{
						bool flag = false;
						if (num2 != array.Length - 1 || Create == 1)
						{
							foreach (XmlNode childNode2 in RootNode.ChildNodes)
							{
								if (childNode2.Name == text)
								{
									xmlNode2 = childNode2;
									RootNode = xmlNode2;
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							xmlNode2 = ownerDocument.CreateElement(text);
							RootNode.AppendChild(xmlNode2);
							RootNode = xmlNode2;
						}
					}
				}
				return xmlNode2;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       输出XSLT处理指令
		                                                                    ///       </summary>
		                                                                    /// <param name="writer">XML书写器</param>
		                                                                    /// <param name="strHref">XSLT文档路径</param>
		public void WriteXSLTProcess(XmlWriter writer, string strHref)
		{
			writer.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='" + strHref + "'");
		}

		                                                                    /// <summary>
		                                                                    ///       创建指定名称的xsl元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="strName">XSL元素名称</param>
		                                                                    /// <returns>新创建的XSL元素</returns>
		public static XmlElement CreateXSLElement(XmlDocument xmlDocument_0, string strName)
		{
			int num = 18;
			if (StringFormatHelper.HasContent(strName))
			{
				return xmlDocument_0.CreateElement("xsl:" + strName, "http:                                                                    //www.w3.org/1999/XSL/Transform");
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       创建一个xsl:value-of 元素
		                                                                    ///       </summary>
		                                                                    /// <param name="xmlDoc">XML文档对象</param>
		                                                                    /// <param name="strSelect">xsl:value-of 元素的 select 属性值</param>
		                                                                    /// <returns>新创建的xsl:vlaue-of 元素</returns>
		public static XmlElement CreateXSLValueOf(XmlDocument xmlDoc, string strSelect)
		{
			int num = 12;
			if (StringFormatHelper.HasContent(strSelect))
			{
				XmlElement xmlElement = xmlDoc.CreateElement("xsl:value-of", "http:                                                                    //www.w3.org/1999/XSL/Transform");
				xmlElement.SetAttribute("select", strSelect);
				return xmlElement;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       创建一个xsl:for-each 元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="strSelect">xsl:for-each 元素的select 属性值</param>
		                                                                    /// <returns>新创建的xsl:for-each 元素</returns>
		public static XmlElement CreateXSLForeach(XmlDocument xmlDocument_0, string strSelect)
		{
			int num = 3;
			if (StringFormatHelper.HasContent(strSelect))
			{
				XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:for-each", "http:                                                                    //www.w3.org/1999/XSL/Transform");
				xmlElement.SetAttribute("select", strSelect);
				return xmlElement;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       创建一个xsl:attribute 元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="strName">元素的name属性值</param>
		                                                                    /// <returns>新创建的xsl:attribute 元素</returns>
		public static XmlElement CreateXSLAttriubte(XmlDocument xmlDocument_0, string strName)
		{
			int num = 8;
			if (StringFormatHelper.HasContent(strName))
			{
				XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:attribute", "http:                                                                    //www.w3.org/1999/XSL/Transform");
				xmlElement.SetAttribute("name", strName);
				return xmlElement;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       创建一个 xsl:text 元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="disable_output_escaping">元素disable_output_escaping属性值</param>
		                                                                    /// <returns>新创建的xsl:text 元素</returns>
		public static XmlElement CreateXSLText(XmlDocument xmlDocument_0, bool disable_output_escaping)
		{
			int num = 9;
			XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:text", "http:                                                                    //www.w3.org/1999/XSL/Transform");
			if (disable_output_escaping)
			{
				xmlElement.SetAttribute("disable-output-escaping", "yes");
			}
			else
			{
				xmlElement.SetAttribute("disable-output-escaping", "no");
			}
			return xmlElement;
		}

		                                                                    /// <summary>
		                                                                    ///       创建一个 xsl:text 元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="disable_output_escaping">元素disable_output_escaping属性值</param>
		                                                                    /// <param name="Text">文本内容</param>
		                                                                    /// <returns>新创建的xsl:text 元素</returns>
		public static XmlElement CreateXSLText(XmlDocument xmlDocument_0, bool disable_output_escaping, string Text)
		{
			int num = 11;
			XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:text", "http:                                                                    //www.w3.org/1999/XSL/Transform");
			if (disable_output_escaping)
			{
				xmlElement.SetAttribute("disable-output-escaping", "yes");
			}
			else
			{
				xmlElement.SetAttribute("disable-output-escaping", "no");
			}
			if (Text != null && Text.Length > 0)
			{
				if (Text.IndexOf(">") >= 0 || Text.IndexOf("<") >= 0 || Text.IndexOf("&") >= 0)
				{
					xmlElement.AppendChild(xmlDocument_0.CreateCDataSection(Text));
				}
				else
				{
					xmlElement.AppendChild(xmlDocument_0.CreateTextNode(Text));
				}
			}
			return xmlElement;
		}

		                                                                    /// <summary>
		                                                                    ///       创建xsl:variable 元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="strName">元素name属性值</param>
		                                                                    /// <param name="Select">select属性值</param>
		                                                                    /// <returns>新创建的xsl:variable 元素</returns>
		public static XmlElement CreateXSLVariable(XmlDocument xmlDocument_0, string strName, string Select)
		{
			XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:variable", "http:                                                                    //www.w3.org/1999/XSL/Transform");
			xmlElement.SetAttribute("name", strName);
			xmlElement.SetAttribute("select", Select);
			return xmlElement;
		}

		                                                                    /// <summary>
		                                                                    ///       创建xsl:output元素
		                                                                    ///       </summary>
		                                                                    /// <param name="doc">XML文档对象</param>
		                                                                    /// <param name="strMethod">元素 method 属性值</param>
		                                                                    /// <param name="bolIndent">是否设置元素 indent 属性值</param>
		                                                                    /// <returns>新创建的xsl:output元素</returns>
		public static XmlElement CreateXSLOutput(XmlDocument xmlDocument_0, string strMethod, bool bolIndent)
		{
			int num = 5;
			XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:output", "http:                                                                    //www.w3.org/1999/XSL/Transform");
			xmlElement.SetAttribute("method", strMethod);
			if (bolIndent)
			{
				xmlElement.SetAttribute("indent", "yes");
			}
			else
			{
				xmlElement.SetAttribute("indent", "no");
			}
			return xmlElement;
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个XML元素下面是否有纯文本节点
		                                                                    ///       </summary>
		                                                                    /// <param name="myElement">XML元素</param>
		                                                                    /// <returns>是否有文本节点</returns>
		public static bool HasTextNode(XmlElement myElement)
		{
			foreach (XmlNode childNode in myElement.ChildNodes)
			{
				if (childNode.NodeType == XmlNodeType.CDATA || childNode.NodeType == XmlNodeType.Text || childNode.NodeType == XmlNodeType.Whitespace)
				{
					return true;
				}
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个XML元素下面是否全部是文本节点
		                                                                    ///       </summary>
		                                                                    /// <param name="myElement">XML元素</param>
		                                                                    /// <returns>若该元素下面没有非文本节点则返回true,若存在非文本节点则返回false</returns>
		public static bool AllChildIsTextNode(XmlElement myElement)
		{
			foreach (XmlNode childNode in myElement.ChildNodes)
			{
				if (childNode.NodeType != XmlNodeType.CDATA && childNode.NodeType != XmlNodeType.Text && childNode.NodeType != XmlNodeType.Whitespace)
				{
					return false;
				}
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       向节点添加一个 xsl:for-each 子节点
		                                                                    ///       </summary>
		                                                                    /// <param name="RootElement">根节点对象</param>
		                                                                    /// <param name="strSelect">xsl:for-each 的select 属性值</param>
		                                                                    /// <returns>新创建的xsl:for-each 子节点</returns>
		public static XmlElement CreateXSLForeachChildElement(XmlElement RootElement, string strSelect)
		{
			XmlElement xmlElement = RootElement.OwnerDocument.CreateElement("xsl:for-each", "http:                                                                    //www.w3.org/1999/XSL/Transform");
			xmlElement.SetAttribute("select", strSelect);
			RootElement.AppendChild(xmlElement);
			return xmlElement;
		}

		                                                                    /// <summary>
		                                                                    ///       从XML节点下获得指定名称的子节点
		                                                                    ///       </summary>
		                                                                    /// <param name="RootElement">根节点对象</param>
		                                                                    /// <param name="strName">子节点的名称</param>
		                                                                    /// <param name="CreateElement">若指定名称的子节点不存在则是否创建新的子节点</param>
		                                                                    /// <returns>找到或新创建的子节点对象,若不存在且不创建子节点则返回空引用</returns>
		public static XmlElement CreateChildElement(XmlElement RootElement, string strName, bool CreateElement)
		{
			int num = 4;
			if (RootElement == null)
			{
				throw new ArgumentNullException("RootElement");
			}
			if (strName == null)
			{
				throw new ArgumentNullException("strName");
			}
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				if (childNode.Name == strName)
				{
					return childNode as XmlElement;
				}
			}
			if (CreateElement)
			{
				XmlElement xmlElement = RootElement.OwnerDocument.CreateElement(strName);
				RootElement.AppendChild(xmlElement);
				return xmlElement;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定名称的XML子节点
		                                                                    ///       </summary>
		                                                                    /// <param name="RootElement">根元素</param>
		                                                                    /// <param name="strName">子节点的名称</param>
		                                                                    /// <returns>获得的XML子节点对象</returns>
		public static XmlNode GetChildNode(XmlElement RootElement, string strName)
		{
			int num = 14;
			if (RootElement == null)
			{
				throw new ArgumentNullException("RootElement");
			}
			if (strName == null)
			{
				throw new ArgumentNullException("strName");
			}
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				if (childNode.Name == strName)
				{
					return childNode;
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       删除所有子节点
		                                                                    ///       </summary>
		                                                                    /// <param name="myElement">要删除所有子节点的根节点对象</param>
		public static void RemoveAllChild(XmlElement myElement)
		{
			while (myElement.LastChild != null)
			{
				myElement.RemoveChild(myElement.LastChild);
			}
		}

		public static string FixXMLName(string strName, char FixChar)
		{
			if (strName == null || strName.Length == 0)
			{
				return null;
			}
			if (XmlReader.IsName(strName))
			{
				return strName;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			for (int i = 0; i < strName.Length; i++)
			{
				char c = strName[i];
				if (XmlReader.IsName(c.ToString()))
				{
					stringBuilder.Append(c);
				}
				else if (!flag && char.IsNumber(c))
				{
					stringBuilder.Append(c);
				}
				else
				{
					stringBuilder.Append(FixChar);
				}
				flag = false;
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       删除XML字符串的	XML声明头
		                                                                    ///       </summary>
		                                                                    /// <param name="strXML">XML字符串</param>
		                                                                    /// <returns>去掉XML声明头的XML字符串</returns>
		[Obsolete("请使用CleanupXMLHeader()")]
		public static string RemoveXMLDeclear(string strXML)
		{
			int num = 7;
			if (strXML != null)
			{
				int num2 = strXML.IndexOf("?>");
				num2 = ((num2 > 0) ? (num2 + 2) : 0);
				int num3 = num2;
				while (true)
				{
					if (num3 < strXML.Length)
					{
						if (!char.IsWhiteSpace(strXML, num3))
						{
							break;
						}
						num3++;
						continue;
					}
					return strXML;
				}
				return strXML.Substring(num3);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       根据一个XML节点输出缩进的XML字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="node">XML节点</param>
		                                                                    /// <param name="IndentChar">缩进字符</param>
		                                                                    /// <param name="Indentation">缩进量</param>
		                                                                    /// <param name="vRemoveXMLDeclear">是否删除XML声明头</param>
		                                                                    /// <returns>输出的XML字符串</returns>
		public static string ToIndentXMLString(XmlNode node, char IndentChar, int Indentation, bool vRemoveXMLDeclear)
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Indentation = Indentation;
			xmlTextWriter.IndentChar = IndentChar;
			node.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			string text = stringWriter.ToString();
			xmlTextWriter.Close();
			if (vRemoveXMLDeclear)
			{
				text = CleanupXMLHeader(text);
			}
			return text;
		}

		                                                                    /// <summary>
		                                                                    ///       自由的保存对象到一个带缩进的XML字符串中
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象</param>
		                                                                    /// <returns>XML字符串</returns>
		public static string SaveObjectToIndentXMLStringFreedom(object instance)
		{
			int num = 3;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Indentation = 3;
			xmlTextWriter.IndentChar = ' ';
			string nativeXmlName = GetNativeXmlName(instance.GetType());
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement(nativeXmlName);
			MySerilizeXml(instance, xmlTextWriter, 0);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
			string xmlText = stringWriter.ToString();
			return CleanupXMLHeader(xmlText);
		}

		private static string GetNativeXmlName(Type type_0)
		{
			if (!_NativeXmlName.ContainsKey(type_0))
			{
				string value = null;
				XmlTypeAttribute xmlTypeAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type_0, typeof(XmlTypeAttribute), inherit: true);
				if (xmlTypeAttribute != null)
				{
					value = xmlTypeAttribute.TypeName;
				}
				if (string.IsNullOrEmpty(value))
				{
					value = type_0.Name;
				}
				_NativeXmlName[type_0] = value;
			}
			return _NativeXmlName[type_0];
		}

		private static void MySerilizeXml(object instance, XmlWriter writer, int level)
		{
			int num = 14;
			if (instance == null)
			{
				return;
			}
			if (level > 20)
			{
				throw new InvalidOperationException("level=" + level);
			}
			Type type = instance.GetType();
			if (type.IsPrimitive || instance is string || instance is decimal)
			{
				string text = instance.ToString();
				writer.WriteString(text);
				return;
			}
			if (instance is DateTime)
			{
				DateTime dateTime_ = (DateTime)instance;
				writer.WriteString(FormatUtils.ToYYYY_MM_DD_HH_MM_SS(dateTime_));
				return;
			}
			if (instance is Color)
			{
				writer.WriteString(XMLSerializeHelper.ColorToString((Color)instance));
				return;
			}
			if (!type.IsClass)
			{
				string text = instance.ToString();
				writer.WriteString(text);
				return;
			}
			if (instance is IList)
			{
				foreach (object item in (IList)instance)
				{
					if (item != null && !DBNull.Value.Equals(item))
					{
						string nativeXmlName = GetNativeXmlName(item.GetType());
						writer.WriteStartElement(nativeXmlName);
						MySerilizeXml(item, writer, level + 1);
						writer.WriteEndElement();
					}
				}
				return;
			}
			List<XmlPropertyInfo> list = null;
			if (_SerializeInfos.ContainsKey(type))
			{
				list = _SerializeInfos[type];
			}
			else
			{
				list = new List<XmlPropertyInfo>();
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					XmlIgnoreAttribute xmlIgnoreAttribute = (XmlIgnoreAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlIgnoreAttribute), inherit: true);
					if (xmlIgnoreAttribute != null || !propertyInfo.CanRead)
					{
						continue;
					}
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters != null && indexParameters.Length > 0)
					{
						continue;
					}
					XmlPropertyInfo xmlPropertyInfo = new XmlPropertyInfo();
					xmlPropertyInfo.Name = propertyInfo.Name;
					xmlPropertyInfo.Property = propertyInfo;
					xmlPropertyInfo.ValueType = 1;
					xmlPropertyInfo.DefaultValue = XmlPropertyInfo.NoneDefaultValue;
					DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DefaultValueAttribute), inherit: true);
					if (defaultValueAttribute != null)
					{
						xmlPropertyInfo.DefaultValue = defaultValueAttribute.Value;
					}
					XmlElementAttribute xmlElementAttribute = (XmlElementAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlElementAttribute), inherit: true);
					if (xmlElementAttribute != null)
					{
						xmlPropertyInfo.ValueType = 1;
						xmlPropertyInfo.DataType = xmlElementAttribute.DataType;
						if (!string.IsNullOrEmpty(xmlElementAttribute.ElementName))
						{
							xmlPropertyInfo.Name = xmlElementAttribute.ElementName;
						}
					}
					else
					{
						XmlAttributeAttribute xmlAttributeAttribute = (XmlAttributeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlAttributeAttribute), inherit: true);
						if (xmlAttributeAttribute != null)
						{
							xmlPropertyInfo.ValueType = 0;
							xmlPropertyInfo.DataType = xmlAttributeAttribute.DataType;
							if (!string.IsNullOrEmpty(xmlAttributeAttribute.AttributeName))
							{
								xmlPropertyInfo.Name = xmlAttributeAttribute.AttributeName;
							}
						}
						else
						{
							XmlTextAttribute xmlTextAttribute = (XmlTextAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(XmlTextAttribute), inherit: true);
							if (xmlTextAttribute != null)
							{
								xmlPropertyInfo.ValueType = 2;
								xmlPropertyInfo.DataType = xmlTextAttribute.DataType;
							}
						}
					}
					Attribute[] customAttributes = Attribute.GetCustomAttributes(propertyInfo, typeof(XmlArrayItemAttribute), inherit: true);
					if (customAttributes != null)
					{
						xmlPropertyInfo.ArrayItemAttributes = customAttributes;
					}
					list.Add(xmlPropertyInfo);
				}
				list.Sort();
				_SerializeInfos[type] = list;
			}
			foreach (XmlPropertyInfo item2 in list)
			{
				object value = item2.Property.GetValue(instance, null);
				if (item2.DefaultValue == XmlPropertyInfo.NoneDefaultValue || (value != item2.DefaultValue && !object.Equals(value, item2.DefaultValue)))
				{
					string text2 = null;
					if (value == null || DBNull.Value.Equals(value))
					{
						text2 = "";
					}
					else if (value.GetType().IsPrimitive || value is string || value is decimal)
					{
						text2 = value.ToString();
					}
					else if (value is DateTime)
					{
						text2 = FormatUtils.ToYYYY_MM_DD_HH_MM_SS((DateTime)value);
					}
					else if (value is Color)
					{
						text2 = XMLSerializeHelper.ColorToString((Color)value);
					}
					else
					{
						if (value.GetType().IsClass)
						{
							if (item2.ArrayItemAttributes != null && item2.ArrayItemAttributes.Length > 0)
							{
								IEnumerable enumerable = (IEnumerable)value;
								if (value is IList)
								{
									IList list2 = (IList)value;
									if (list2.Count == 0)
									{
										continue;
									}
								}
								writer.WriteStartElement(item2.Name);
								foreach (object item3 in enumerable)
								{
									bool flag = false;
									Attribute[] arrayItemAttributes = item2.ArrayItemAttributes;
									for (int i = 0; i < arrayItemAttributes.Length; i++)
									{
										XmlArrayItemAttribute xmlArrayItemAttribute = (XmlArrayItemAttribute)arrayItemAttributes[i];
										if (xmlArrayItemAttribute.Type.IsInstanceOfType(item3))
										{
											string text3 = xmlArrayItemAttribute.ElementName;
											if (string.IsNullOrEmpty(text3))
											{
												text3 = GetNativeXmlName(item3.GetType());
											}
											writer.WriteStartElement(text3);
											MySerilizeXml(item3, writer, level + 1);
											writer.WriteEndElement();
											flag = true;
											break;
										}
									}
									if (!flag)
									{
										string text3 = GetNativeXmlName(item3.GetType());
										writer.WriteStartElement(text3);
										MySerilizeXml(item3, writer, level + 1);
										writer.WriteEndElement();
									}
								}
								writer.WriteEndElement();
							}
							else
							{
								writer.WriteStartElement(item2.Name);
								MySerilizeXml(value, writer, level + 1);
								writer.WriteEndElement();
							}
							continue;
						}
						text2 = value.ToString();
					}
					if (text2 == null)
					{
						text2 = "";
					}
					if (item2.ValueType == 0)
					{
						writer.WriteAttributeString(item2.Name, text2);
					}
					else if (item2.ValueType == 1)
					{
						writer.WriteElementString(item2.Name, text2);
					}
					else if (item2.ValueType == 2)
					{
						writer.WriteString(text2);
						break;
					}
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       本对象不能实例化
		                                                                    ///       </summary>
		private XMLHelper()
		{
		}
	}
}
