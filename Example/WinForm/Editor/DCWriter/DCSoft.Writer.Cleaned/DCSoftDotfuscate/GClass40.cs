using DCSoft.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass40
	{
		private class Class76 : IComparer<GClass41>
		{
			public int Compare(GClass41 gclass41_0, GClass41 gclass41_1)
			{
				if (gclass41_0.method_3() != gclass41_1.method_3())
				{
					if (gclass41_0.method_3())
					{
						return -1;
					}
					return 1;
				}
				return string.Compare(gclass41_0.method_1(), gclass41_1.method_1());
			}
		}

		private Dictionary<Type, string> dictionary_0 = new Dictionary<Type, string>();

		private Dictionary<Type, string> dictionary_1 = new Dictionary<Type, string>();

		private Dictionary<string, Type> dictionary_2 = new Dictionary<string, Type>();

		private GClass42 gclass42_0 = null;

		private List<GClass42> list_0 = new List<GClass42>();

		private List<string> list_1 = new List<string>();

		public static void smethod_0(string string_0, string string_1, string string_2, Type type_0, Type[] type_1)
		{
			GClass40 gClass = new GClass40();
			gClass.method_11(type_0, type_1);
			gClass.method_4(string_0, string_1, string_2);
		}

		public GClass40()
		{
			method_2()[typeof(string)] = "string.IsNullOrEmpty";
			method_2()[typeof(DateTime)] = "WriterUtils.IsEmptyDateTime";
			method_0()[typeof(Color)] = "System.Drawing.ColorTranslator.FromHtml";
			method_0()[typeof(byte[])] = "Convert.FromBase64String";
			method_0()[typeof(byte)] = "Convert.ToByte";
			method_0()[typeof(sbyte)] = "Convert.ToSByte";
			method_0()[typeof(short)] = "Convert.ToInt16";
			method_0()[typeof(ushort)] = "Convert.ToUInt16";
			method_0()[typeof(int)] = "Convert.ToInt32";
			method_0()[typeof(uint)] = "Convert.ToUInt32";
			method_0()[typeof(long)] = "Convert.ToInt64";
			method_0()[typeof(ulong)] = "Convert.ToUInt64";
			method_0()[typeof(decimal)] = "Convert.ToDecimal";
			method_0()[typeof(float)] = "Convert.ToSingle";
			method_0()[typeof(double)] = "Convert.ToDouble";
			method_0()[typeof(DateTime)] = "Convert.ToDateTime";
			method_0()[typeof(char)] = "Convert.ToChar";
			method_0()[typeof(string)] = "";
		}

		public Dictionary<Type, string> method_0()
		{
			return dictionary_0;
		}

		public void method_1(Dictionary<Type, string> dictionary_3)
		{
			dictionary_0 = dictionary_3;
		}

		public Dictionary<Type, string> method_2()
		{
			return dictionary_1;
		}

		public void method_3(Dictionary<Type, string> dictionary_3)
		{
			dictionary_1 = dictionary_3;
		}

		public void method_4(string string_0, string string_1, string string_2)
		{
			string value = method_5(string_1, string_2);
			using (StreamWriter streamWriter = new StreamWriter(string_0, append: false, Encoding.UTF8))
			{
				streamWriter.Write(value);
			}
		}

		public string method_5(string string_0, string string_1)
		{
			int num = 17;
			Dictionary<string, GClass41> dictionary = new Dictionary<string, GClass41>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("using System;");
			stringBuilder.AppendLine("using System.Xml;");
			stringBuilder.AppendLine("namespace " + string_0);
			stringBuilder.AppendLine("{");
			stringBuilder.AppendLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"DCSoft.Serialization.MyXMLDeserilizeCodeGen\", \"1.0\")]");
			stringBuilder.AppendLine("[System.Runtime.InteropServices.ComVisible( false )]");
			stringBuilder.AppendLine("public class " + string_1);
			stringBuilder.AppendLine("{");
			if (method_9() != null)
			{
				stringBuilder.AppendLine("\tpublic void WriteDocument( XmlWriter writer , " + method_9().method_0() + " Value )");
				stringBuilder.AppendLine("\t{");
				stringBuilder.AppendLine("\t\twriter.WriteStartElement(\"" + method_9().method_4() + "\");");
				stringBuilder.AppendLine("\t\tWrite( writer , Value );");
				stringBuilder.AppendLine("\t\twriter.WriteEndElement( );");
				stringBuilder.AppendLine("\t}");
			}
			foreach (GClass42 item in method_12())
			{
				stringBuilder.AppendLine("\tpublic void Write( XmlWriter writer , " + item.method_0() + " Value )");
				stringBuilder.AppendLine("\t{");
				if (item.method_6() == null)
				{
					foreach (GClass41 item2 in item.method_8())
					{
						bool flag = false;
						if (item2.method_8())
						{
							flag = true;
							stringBuilder.AppendLine("\t\tif( Value." + item2.method_5().Name + " != " + DesignUtils.ToCShaprValueString(item2.method_10()) + " )");
							stringBuilder.AppendLine("\t\t{");
						}
						else if (method_2().ContainsKey(item2.method_7()))
						{
							flag = true;
							stringBuilder.AppendLine("\t\tif( " + method_2()[item2.method_7()] + "( Value." + item2.method_5().Name + " ) == false )");
							stringBuilder.AppendLine("\t\t{");
						}
						else if (!method_16(item2.method_7()) && item2.method_7().IsClass)
						{
							flag = true;
							stringBuilder.AppendLine("\t\tif( Value." + item2.method_0() + " != null )");
							stringBuilder.AppendLine("\t\t{");
						}
						if (method_16(item2.method_7()))
						{
							string text = item2.method_0();
							if (item2.method_7().Equals(typeof(DateTime)))
							{
								text = item2.method_0() + ".ToString(\"yyyy-MM-dd HH:mm:ss\")";
							}
							else if (!item2.method_7().Equals(typeof(string)))
							{
								text = item2.method_0() + ".ToString()";
							}
							if (item2.method_3())
							{
								stringBuilder.AppendLine("\t\t\twriter.WriteAttributeString(\"" + item2.method_1() + "\", Value." + text + " );");
							}
							else
							{
								stringBuilder.AppendLine("\t\t\twriter.WriteElementString(\"" + item2.method_1() + "\" , Value." + text + " );");
							}
						}
						else
						{
							stringBuilder.AppendLine("\t\t\twriter.WriteStartElement(\"" + item2.method_1() + "\");");
							if (item2.method_12() != null && item2.method_12().Count > 0)
							{
								string text2 = "Write_" + item2.method_5().DeclaringType.Name + "_" + item2.method_0();
								dictionary[text2] = item2;
								stringBuilder.AppendLine("\t\t\t" + text2 + "( writer , Value." + item2.method_0() + " );");
							}
							else
							{
								stringBuilder.AppendLine("\t\t\tWrite( writer , Value." + item2.method_0() + " );");
							}
							stringBuilder.AppendLine("\t\t\twriter.WriteEndElement();");
						}
						if (flag)
						{
							stringBuilder.AppendLine("\t\t}");
						}
					}
				}
				else
				{
					stringBuilder.AppendLine("\t\tforeach( " + item.method_6().method_0() + " item in Value )");
					stringBuilder.AppendLine("\t\t{");
					stringBuilder.AppendLine("\t\t\twriter.WriteStartElement(\"" + item.method_6().method_4() + "\");");
					stringBuilder.AppendLine("\t\t\tWrite( writer , item );");
					stringBuilder.AppendLine("\t\t\twriter.WriteEndElement();");
					stringBuilder.AppendLine("\t\t}");
				}
				stringBuilder.AppendLine("\t}");
				stringBuilder.AppendLine();
			}
			if (dictionary.Count > 0)
			{
				foreach (string key in dictionary.Keys)
				{
					GClass41 current2 = dictionary[key];
					Dictionary<string, GClass42> dictionary2 = new Dictionary<string, GClass42>();
					foreach (string key2 in current2.method_12().Keys)
					{
						if (!current2.method_12()[key2].method_2().IsAbstract)
						{
							dictionary2.Add(key2, current2.method_12()[key2]);
						}
					}
					foreach (GClass42 value in current2.method_12().Values)
					{
						foreach (GClass42 item3 in method_12())
						{
							if (item3.method_2().IsSubclassOf(value.method_2()))
							{
								dictionary2[item3.method_4()] = item3;
							}
						}
					}
					stringBuilder.AppendLine("\tprivate void " + key + "( XmlWriter writer , " + DesignUtils.GetCSharpTypeName(current2.method_7()) + " Value)");
					stringBuilder.AppendLine("\t{");
					if (dictionary2.Count == 1)
					{
						foreach (string key3 in dictionary2.Keys)
						{
							GClass42 current = dictionary2[key3];
							stringBuilder.AppendLine("\t\tforeach( " + DesignUtils.GetCSharpTypeName(current.method_2()) + " item in Value )");
							stringBuilder.AppendLine("\t\t{");
							stringBuilder.AppendLine("\t\t\twriter.WriteStartElement(\"" + key3 + "\");");
							stringBuilder.AppendLine("\t\t\tWrite( writer , item );");
							stringBuilder.AppendLine("\t\t\twriter.WriteEndElement();");
							stringBuilder.AppendLine("\t\t}");
						}
					}
					else
					{
						stringBuilder.AppendLine("\t\tforeach( object item in Value )");
						stringBuilder.AppendLine("\t\t{");
						foreach (string key4 in dictionary2.Keys)
						{
							GClass42 current = dictionary2[key4];
							stringBuilder.AppendLine("\t\t\tif( item is " + current.method_0() + " )");
							stringBuilder.AppendLine("\t\t\t{");
							stringBuilder.AppendLine("\t\t\t\twriter.WriteStartElement(\"" + key4 + "\");");
							stringBuilder.AppendLine("\t\t\t\tWrite( writer , ( " + current.method_0() + " ) item );");
							stringBuilder.AppendLine("\t\t\t\twriter.WriteEndElement();");
							stringBuilder.AppendLine("\t\t\t}");
						}
						stringBuilder.AppendLine("\t\t}");
					}
					stringBuilder.AppendLine("\t}");
				}
			}
			stringBuilder.AppendLine("//***************************");
			foreach (GClass42 item4 in method_12())
			{
				stringBuilder.AppendLine("\t\tpublic void ReadProperties( XmlReader reader , " + item4.method_0() + " instance )");
				stringBuilder.AppendLine("\t\t{");
				bool flag2 = false;
				foreach (GClass41 item5 in item4.method_8())
				{
					if (item5.method_3())
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					stringBuilder.AppendLine("if( reader.MoveToFirstAttribute() )");
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("string attributeName = reader.LocalName ;");
					stringBuilder.AppendLine("switch( attributeName )");
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("}");
				}
				stringBuilder.AppendLine("\t\t\treader.MoveToElement();");
				stringBuilder.AppendLine("\t\t\tif( reader.IsEmptyElement )");
				stringBuilder.AppendLine("\t\t\t{");
				stringBuilder.AppendLine("\t\t\t\treader.Skip();");
				stringBuilder.AppendLine("\t\t\t\treturn;");
				stringBuilder.AppendLine("\t\t\t}");
				stringBuilder.AppendLine("\t\t\tstring elementName = reader.LocalName ;");
				stringBuilder.AppendLine("\t\t\tswitch( elementName )");
				stringBuilder.AppendLine("\t\t\t{");
				foreach (GClass41 item6 in item4.method_8())
				{
					if (!item6.method_3())
					{
						stringBuilder.AppendLine("\t\t\t\tcase \"" + item6.method_1() + "\":");
						stringBuilder.AppendLine("\t\t\t\t{");
						if (!method_16(item6.method_7()) || !item6.method_7().Equals(typeof(string)))
						{
						}
						stringBuilder.AppendLine("\t\t\t\t}");
					}
				}
				stringBuilder.AppendLine("\t\t\t}");
				stringBuilder.AppendLine("\t\t}");
			}
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}

		private void method_6(StringBuilder stringBuilder_0, GClass42 gclass42_1, bool bool_0)
		{
			int num = 17;
			foreach (GClass41 item in gclass42_1.method_8())
			{
				if (item.method_3() == bool_0)
				{
					stringBuilder_0.AppendLine("case \"" + item.method_1() + "\" :");
					if (method_16(item.method_7()) || bool_0)
					{
						string text = null;
						if (method_0().ContainsKey(item.method_7()))
						{
							text = method_0()[item.method_7()];
						}
						else
						{
							text = "ConvertTo_" + method_8(item.method_7());
							dictionary_2[text] = item.method_7();
						}
						if (bool_0)
						{
							stringBuilder_0.AppendLine("instance." + item.method_0() + " = " + text + "( reader.Value );");
						}
						else
						{
							stringBuilder_0.AppendLine("instance." + item.method_0() + " = " + text + "( reader.ReadString() );");
						}
					}
					else
					{
						stringBuilder_0.AppendLine("{");
						stringBuilder_0.AppendLine(DesignUtils.GetCSharpTypeName(item.method_7()) + " newValue = new " + DesignUtils.GetCSharpTypeName(item.method_7()) + "();");
						if (bool_0)
						{
							stringBuilder_0.AppendLine("ReadProperties( reader , newValue );");
						}
						stringBuilder_0.AppendLine("}");
					}
					stringBuilder_0.AppendLine("break;");
				}
			}
		}

		private void method_7(StringBuilder stringBuilder_0, Type type_0)
		{
			int num = 10;
			string cSharpTypeName = DesignUtils.GetCSharpTypeName(type_0);
			string[] names = Enum.GetNames(type_0);
			stringBuilder_0.AppendLine("// 读取枚举变量值 " + type_0.FullName);
			stringBuilder_0.AppendLine("private " + cSharpTypeName + " ConvertTo_" + method_8(type_0) + " ( string Value )");
			stringBuilder_0.AppendLine("{");
			stringBuilder_0.AppendLine("if( string.IsNullOrEmpty ( Value ))");
			stringBuilder_0.AppendLine("{");
			stringBuilder_0.AppendLine("   return " + cSharpTypeName + "." + names[0] + " ;");
			stringBuilder_0.AppendLine("}");
			stringBuilder_0.AppendLine("Value = Value.Trim().ToLower() ;");
			stringBuilder_0.AppendLine("switch( Value )");
			stringBuilder_0.AppendLine("{");
			string[] array = names;
			foreach (string text in array)
			{
				stringBuilder_0.AppendLine("case \"" + text.ToLower() + "\"\t: return " + type_0.FullName + "." + text + " ;");
			}
			FlagsAttribute flagsAttribute = (FlagsAttribute)Attribute.GetCustomAttribute(type_0, typeof(FlagsAttribute));
			if (flagsAttribute == null)
			{
				stringBuilder_0.AppendLine("default:return " + cSharpTypeName + "." + names[0] + " ;");
			}
			else
			{
				stringBuilder_0.AppendLine("default:return (" + cSharpTypeName + ") TryToParseEnum( typeof(" + cSharpTypeName + ") , Value , " + cSharpTypeName + "." + names[0] + " );");
			}
			stringBuilder_0.AppendLine("}");
			stringBuilder_0.AppendLine("}// To_" + method_8(type_0));
		}

		private string method_8(Type type_0)
		{
			string fullName = type_0.FullName;
			fullName = fullName.Replace(".", "_");
			fullName = fullName.Replace("+", "_");
			return fullName.Replace("[]", "_Array");
		}

		public GClass42 method_9()
		{
			return gclass42_0;
		}

		public void method_10(GClass42 gclass42_1)
		{
			gclass42_0 = gclass42_1;
		}

		public void method_11(Type type_0, Type[] type_1)
		{
			int num = 6;
			if (type_0 == null)
			{
				throw new ArgumentNullException("rootType");
			}
			List<Type> list = new List<Type>();
			list.Add(type_0);
			if (type_1 != null && type_1.Length > 0)
			{
				foreach (Type item in type_1)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}
			List<Type> list_ = new List<Type>();
			foreach (Type item2 in list)
			{
				if (method_14(item2) == null)
				{
					method_15(item2, list_);
				}
			}
			method_10(method_14(type_0));
		}

		public List<GClass42> method_12()
		{
			return list_0;
		}

		public void method_13(List<GClass42> list_2)
		{
			list_0 = list_2;
		}

		public GClass42 method_14(Type type_0)
		{
			foreach (GClass42 item in method_12())
			{
				if (item.method_2() == type_0)
				{
					return item;
				}
			}
			return null;
		}

		private GClass42 method_15(Type type_0, List<Type> list_2)
		{
			int num = 12;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (method_16(type_0))
			{
				return null;
			}
			list_2.Add(type_0);
			GClass42 gClass = new GClass42();
			list_0.Add(gClass);
			gClass.method_3(type_0);
			XmlTypeAttribute xmlTypeAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type_0, typeof(XmlTypeAttribute), inherit: false);
			if (xmlTypeAttribute != null)
			{
				gClass.method_5(xmlTypeAttribute.TypeName);
			}
			if (string.IsNullOrEmpty(gClass.method_4()))
			{
				gClass.method_5(type_0.Name);
			}
			gClass.method_1(DesignUtils.GetCSharpTypeName(type_0));
			Type collectionItemType = DesignUtils.GetCollectionItemType(type_0, checkAddMethod: true);
			if (!type_0.IsAbstract)
			{
				if (collectionItemType != null)
				{
					gClass.method_7(method_14(collectionItemType));
					if (gClass.method_6() == null)
					{
						gClass.method_7(method_15(collectionItemType, list_2));
					}
				}
				else
				{
					PropertyInfo[] properties = type_0.GetProperties(BindingFlags.Instance | BindingFlags.Public);
					List<PropertyInfo> list = new List<PropertyInfo>();
					list.AddRange(properties);
					foreach (PropertyInfo item in list)
					{
						if (item.CanWrite && item.CanRead)
						{
							XmlIgnoreAttribute xmlIgnoreAttribute = (XmlIgnoreAttribute)Attribute.GetCustomAttribute(item, typeof(XmlIgnoreAttribute), inherit: true);
							if (xmlIgnoreAttribute == null)
							{
								GClass41 gClass2 = new GClass41();
								gClass2.method_6(item);
								XmlAttributeAttribute xmlAttributeAttribute = (XmlAttributeAttribute)Attribute.GetCustomAttribute(item, typeof(XmlAttributeAttribute), inherit: false);
								if (xmlAttributeAttribute != null)
								{
									gClass2.method_4(bool_2: true);
									gClass2.method_2(xmlAttributeAttribute.AttributeName);
								}
								else
								{
									XmlElementAttribute xmlElementAttribute = (XmlElementAttribute)Attribute.GetCustomAttribute(item, typeof(XmlElementAttribute), inherit: false);
									if (xmlElementAttribute != null)
									{
										gClass2.method_2(xmlElementAttribute.ElementName);
										gClass2.method_4(bool_2: false);
									}
									else
									{
										gClass2.method_2(item.Name);
										gClass2.method_4(bool_2: false);
									}
								}
								XmlArrayAttribute xmlArrayAttribute = (XmlArrayAttribute)Attribute.GetCustomAttribute(item, typeof(XmlArrayAttribute), inherit: false);
								if (xmlArrayAttribute != null && !string.IsNullOrEmpty(xmlArrayAttribute.ElementName))
								{
									gClass2.method_2(xmlArrayAttribute.ElementName);
								}
								if (string.IsNullOrEmpty(gClass2.method_1()))
								{
									gClass2.method_2(item.Name);
								}
								DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(item, typeof(DefaultValueAttribute), inherit: true);
								if (defaultValueAttribute != null)
								{
									gClass2.method_9(bool_2: true);
									gClass2.method_11(defaultValueAttribute.Value);
								}
								gClass.method_8().Add(gClass2);
								if (!method_16(item.PropertyType))
								{
									if (method_14(item.PropertyType) == null)
									{
										foreach (Type item2 in list_2)
										{
											if (item2.Equals(item.PropertyType))
											{
												throw new InvalidOperationException(type_0.Name + "." + item.Name + " 出现循环引用");
											}
										}
										method_15(item.PropertyType, list_2);
									}
									Type collectionItemType2 = DesignUtils.GetCollectionItemType(item.PropertyType, checkAddMethod: true);
									if (collectionItemType2 != null)
									{
										gClass2.method_13(new Dictionary<string, GClass42>());
										Attribute[] customAttributes = Attribute.GetCustomAttributes(item, typeof(XmlArrayItemAttribute), inherit: false);
										if (customAttributes != null && customAttributes.Length > 0)
										{
											Attribute[] array = customAttributes;
											for (int i = 0; i < array.Length; i++)
											{
												XmlArrayItemAttribute xmlArrayItemAttribute = (XmlArrayItemAttribute)array[i];
												if (xmlArrayItemAttribute.Type != null)
												{
													GClass42 gClass3 = method_14(xmlArrayItemAttribute.Type);
													if (gClass3 == null)
													{
														gClass3 = method_15(xmlArrayItemAttribute.Type, list_2);
													}
													gClass2.method_12()[xmlArrayItemAttribute.ElementName] = gClass3;
												}
											}
										}
										else
										{
											GClass42 gClass3 = method_14(collectionItemType2);
											if (gClass3 == null)
											{
												gClass3 = method_15(collectionItemType2, list_2);
											}
											gClass2.method_12()[collectionItemType2.Name] = gClass3;
										}
									}
								}
							}
						}
					}
					gClass.method_8().Sort(new Class76());
				}
			}
			list_2.RemoveAt(list_2.Count - 1);
			return gClass;
		}

		private bool method_16(Type type_0)
		{
			if (type_0.IsArray)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0.IsPrimitive)
			{
				return true;
			}
			if (type_0.IsEnum)
			{
				return true;
			}
			if (type_0.Equals(typeof(DateTime)))
			{
				return true;
			}
			if (type_0.IsInterface)
			{
				return true;
			}
			if (type_0.Equals(typeof(string)))
			{
				return true;
			}
			if (type_0.Equals(typeof(Color)))
			{
				return true;
			}
			if (type_0.Equals(typeof(Font)))
			{
				return true;
			}
			return false;
		}
	}
}
