using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       XML序列化数据封装包
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCXmlSerializablePackage : IXmlSerializable
	{
		private object _Value = null;

		private string _ValueTypeName = null;

		private bool _AutoConvertToXMLElement = false;

		/// <summary>
		///       对象数据
		///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       数据类型名称
		///       </summary>
		[DefaultValue(null)]
		public string ValueTypeName
		{
			get
			{
				return _ValueTypeName;
			}
			set
			{
				_ValueTypeName = value;
			}
		}

		/// <summary>
		///       当无法找到实体类型时自动转换为XML元素对象
		///       </summary>
		[DefaultValue(false)]
		public bool AutoConvertToXMLElement
		{
			get
			{
				return _AutoConvertToXMLElement;
			}
			set
			{
				_AutoConvertToXMLElement = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCXmlSerializablePackage()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCXmlSerializablePackage(object object_0)
		{
			_Value = object_0;
		}

		/// <summary>
		///       获得格式
		///       </summary>
		/// <returns>
		/// </returns>
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		///       读取XML
		///       </summary>
		/// <param name="reader">
		/// </param>
		public void ReadXml(XmlReader reader)
		{
			int num = 5;
			_ValueTypeName = reader.GetAttribute("TypeName");
			AutoConvertToXMLElement = (reader.GetAttribute("AutoConvertToXMLElement") == "true");
			if (_ValueTypeName == "System.Xml.XmlElement")
			{
				XmlDocument xmlDocument = new XmlDocument();
				reader.ReadStartElement();
				xmlDocument.Load(reader);
				reader.ReadEndElement();
				Value = xmlDocument.DocumentElement;
				return;
			}
			if (_ValueTypeName == "System.Xml.XmlDocument")
			{
				XmlDocument xmlDocument = new XmlDocument();
				reader.ReadStartElement();
				xmlDocument.Load(reader);
				reader.ReadEndElement();
				Value = xmlDocument;
				return;
			}
			Type controlType = ControlHelper.GetControlType(_ValueTypeName, null);
			if (controlType == null)
			{
				if (AutoConvertToXMLElement)
				{
					XmlDocument xmlDocument = new XmlDocument();
					reader.ReadStartElement();
					xmlDocument.Load(reader);
					reader.ReadEndElement();
					_Value = xmlDocument.DocumentElement;
				}
				else
				{
					reader.Skip();
				}
			}
			else if (CanSerializeString(controlType))
			{
				string text = reader.ReadString();
				if (reader.NodeType == XmlNodeType.Element)
				{
					reader.Read();
				}
				else
				{
					reader.ReadEndElement();
				}
				if (controlType == typeof(string))
				{
					_Value = text;
					return;
				}
				TypeConverter converter = TypeDescriptor.GetConverter(controlType);
				_Value = converter.ConvertFromString(text);
			}
			else if (reader.GetAttribute("Binary") == "true")
			{
				string text = reader.ReadString();
				if (reader.NodeType == XmlNodeType.Element)
				{
					reader.Read();
				}
				else
				{
					reader.ReadEndElement();
				}
				if (!string.IsNullOrEmpty(text))
				{
					byte[] buffer = Convert.FromBase64String(text);
					MemoryStream memoryStream = new MemoryStream(buffer);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					_Value = binaryFormatter.Deserialize(memoryStream);
					memoryStream.Close();
				}
			}
			else
			{
				XmlSerializer xmlSerializer = new XmlSerializer(controlType);
				reader.ReadStartElement();
				_Value = xmlSerializer.Deserialize(reader);
				reader.ReadEndElement();
			}
		}

		/// <summary>
		///       写入XML文档
		///       </summary>
		/// <param name="writer">
		/// </param>
		public void WriteXml(XmlWriter writer)
		{
			int num = 19;
			if (Value == null || DBNull.Value.Equals(Value))
			{
				return;
			}
			if (Value is XmlElement && AutoConvertToXMLElement && !string.IsNullOrEmpty(_ValueTypeName))
			{
				writer.WriteAttributeString("TypeName", _ValueTypeName);
				writer.WriteAttributeString("AutoConvertToXMLElement", "true");
				XmlElement xmlElement = (XmlElement)Value;
				xmlElement.WriteTo(writer);
				return;
			}
			Type type = _Value.GetType();
			if (Value is XmlDocument)
			{
				writer.WriteAttributeString("TypeName", "System.Xml.XmlDocument");
				XmlDocument xmlDocument = (XmlDocument)Value;
				xmlDocument.WriteTo(writer);
				return;
			}
			if (Value is XmlElement)
			{
				writer.WriteAttributeString("TypeName", "System.Xml.XmlElement");
				XmlElement xmlElement = (XmlElement)Value;
				xmlElement.WriteTo(writer);
				return;
			}
			_ValueTypeName = ControlHelper.GetControlFullTypeName(type);
			writer.WriteAttributeString("TypeName", _ValueTypeName);
			if (CanSerializeString(type))
			{
				if (AutoConvertToXMLElement)
				{
					writer.WriteAttributeString("AutoConvertToXMLElement", "true");
				}
				string text = "";
				if (type == typeof(string))
				{
					text = (string)_Value;
				}
				else if (_Value is DateTime)
				{
					text = ((DateTime)_Value).ToString();
				}
				else
				{
					TypeConverter converter = TypeDescriptor.GetConverter(_Value);
					text = ((converter != null) ? converter.ConvertToString(_Value) : _Value.ToString());
				}
				writer.WriteString(text);
			}
			else if (Attribute.GetCustomAttribute(type, typeof(SerializableAttribute), inherit: false) != null)
			{
				writer.WriteAttributeString("Binary", "true");
				MemoryStream memoryStream = new MemoryStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, _Value);
				memoryStream.Close();
				byte[] inArray = memoryStream.ToArray();
				writer.WriteString(Convert.ToBase64String(inArray));
			}
			else
			{
				if (AutoConvertToXMLElement)
				{
					writer.WriteAttributeString("AutoConvertToXMLElement", "true");
				}
				XmlSerializer xmlSerializer = new XmlSerializer(type);
				xmlSerializer.Serialize(writer, _Value);
			}
		}

		private bool CanSerializeString(Type type_0)
		{
			if (type_0 == typeof(string) || type_0 == typeof(DateTime) || type_0 == typeof(Color) || type_0.IsPrimitive || type_0.IsEnum)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCXmlSerializablePackage Clone()
		{
			return (DCXmlSerializablePackage)MemberwiseClone();
		}
	}
}
