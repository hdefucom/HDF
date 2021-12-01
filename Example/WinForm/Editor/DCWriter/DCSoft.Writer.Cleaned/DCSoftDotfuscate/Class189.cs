using DCSoft.ShapeEditor.Dom;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	internal class Class189
	{
		private static Dictionary<Type, Type[]> dictionary_0;

		private static Dictionary<Type, XmlSerializer> dictionary_1;

		private static Dictionary<Type, XmlSerializer> dictionary_2;

		static Class189()
		{
			dictionary_0 = new Dictionary<Type, Type[]>();
			dictionary_1 = new Dictionary<Type, XmlSerializer>();
			dictionary_2 = new Dictionary<Type, XmlSerializer>();
			smethod_0(typeof(ShapeDocument), new Type[5]
			{
				typeof(ShapeDocumentPage),
				typeof(ShapeDocumentImagePage),
				typeof(ShapeRectangleElement),
				typeof(ShapeLineElement),
				typeof(ShapeEllipseElement)
			});
		}

		public static void smethod_0(Type type_0, Type[] type_1)
		{
			int num = 12;
			if (type_0 == null)
			{
				throw new ArgumentNullException("documentType");
			}
			if (!type_0.Equals(typeof(ShapeDocument)) && !type_0.IsSubclassOf(typeof(ShapeDocument)))
			{
				throw new ArgumentException(type_0.FullName + "<>" + typeof(ShapeDocument).FullName);
			}
			if (type_1 == null)
			{
				throw new ArgumentNullException("elementTypes");
			}
			int num2 = 0;
			Type type;
			while (true)
			{
				if (num2 < type_1.Length)
				{
					type = type_1[num2];
					if (!type.IsSubclassOf(typeof(ShapeElement)))
					{
						break;
					}
					num2++;
					continue;
				}
				dictionary_0[type_0] = type_1;
				if (dictionary_1.ContainsKey(type_0))
				{
					dictionary_1.Remove(type_0);
				}
				return;
			}
			throw new ArgumentException(type.FullName + "<>" + typeof(ShapeElement).FullName);
		}

		public static XmlSerializer smethod_1(Type type_0)
		{
			if (dictionary_1.ContainsKey(type_0))
			{
				return dictionary_1[type_0];
			}
			XmlSerializer xmlSerializer = null;
			xmlSerializer = ((!dictionary_0.ContainsKey(type_0)) ? new XmlSerializer(type_0) : new XmlSerializer(type_0, dictionary_0[type_0]));
			dictionary_1[type_0] = xmlSerializer;
			return xmlSerializer;
		}

		public static XmlSerializer smethod_2(Type type_0)
		{
			int num = 10;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (dictionary_2.ContainsKey(type_0))
			{
				return dictionary_2[type_0];
			}
			XmlSerializer xmlSerializer = new XmlSerializer(type_0);
			dictionary_2[type_0] = xmlSerializer;
			return xmlSerializer;
		}
	}
}
