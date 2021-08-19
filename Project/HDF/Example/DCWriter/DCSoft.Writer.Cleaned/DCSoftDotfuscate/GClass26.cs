using DCSoft.Common;
using DCSoft.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass26
	{
		private List<Type> list_0 = new List<Type>();

		private string string_0 = null;

		private string string_1 = null;

		private TextWriter textWriter_0 = null;

		private GClass342 gclass342_0 = null;

		private List<Class69> list_1 = null;

		public List<Type> method_0()
		{
			return list_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public void method_2(string string_2)
		{
			string_0 = string_2;
		}

		public string method_3()
		{
			return string_1;
		}

		public void method_4(string string_2)
		{
			string_1 = string_2;
		}

		public TextWriter method_5()
		{
			return textWriter_0;
		}

		public void method_6(TextWriter textWriter_1)
		{
			textWriter_0 = textWriter_1;
		}

		public static void smethod_0(Type type_0, string string_2, string string_3, string string_4)
		{
			GClass26 gClass = new GClass26();
			gClass.method_0().Add(type_0);
			gClass.method_2(string_2);
			gClass.method_4(string_3);
			using (StreamWriter textWriter_ = new StreamWriter(string_4, append: false, Encoding.UTF8))
			{
				gClass.method_6(textWriter_);
				gClass.method_7();
			}
		}

		public void method_7()
		{
			int num = 7;
			if (textWriter_0 == null)
			{
				throw new Exception("Writer为空");
			}
			gclass342_0 = new GClass342(textWriter_0);
			method_8();
		}

		private void method_8()
		{
			int num = 9;
			list_1 = Class69.smethod_1(method_0());
			List<string> list = new List<string>();
			list.Add("System");
			foreach (Class69 item in list_1)
			{
				string @namespace = item.method_0().Namespace;
				if (!string.IsNullOrEmpty(@namespace) && !list.Contains(@namespace))
				{
					list.Add(@namespace);
				}
			}
			list.Sort();
			foreach (string item2 in list)
			{
				gclass342_0.method_9("using " + item2 + ";");
			}
			gclass342_0.method_9("namespace " + method_1());
			gclass342_0.method_9("{");
			gclass342_0.method_11();
			gclass342_0.method_9("[System.Runtime.InteropServices.ComVisible( false )]");
			gclass342_0.method_9("public class " + method_3() + ":" + typeof(GClass21).FullName);
			gclass342_0.method_9("{");
			gclass342_0.method_11();
			gclass342_0.method_7();
			gclass342_0.method_9("protected override void Serialize(object instance)");
			gclass342_0.method_9("{");
			gclass342_0.method_11();
			foreach (Class69 item3 in list_1)
			{
				if (!item3.method_0().IsEnum)
				{
					gclass342_0.method_9("if( instance is " + DesignUtils.GetCSharpTypeName(item3.method_0()) + ")");
					gclass342_0.method_9("{");
					gclass342_0.method_11();
					gclass342_0.method_9("Write_" + item3.method_3() + "((" + DesignUtils.GetCSharpTypeName(item3.method_0()) + ")instance);");
					gclass342_0.method_12();
					gclass342_0.method_9("}");
				}
			}
			gclass342_0.method_12();
			gclass342_0.method_9("}");
			gclass342_0.method_7();
			foreach (Class69 item4 in list_1)
			{
				if (!item4.method_0().IsEnum && !item4.method_0().Equals(typeof(byte[])) && !item4.method_0().Equals(typeof(Color)) && item4.method_7() != null && item4.method_7().Length != 0)
				{
					gclass342_0.method_7();
					gclass342_0.method_9("private void Write_" + item4.method_3() + "(" + DesignUtils.GetCSharpTypeName(item4.method_0()) + " instance )");
					gclass342_0.method_9("{");
					gclass342_0.method_11();
					_ = item4.method_0().IsClass;
					if (item4.method_0().IsClass)
					{
						gclass342_0.method_9("if( instance == null ) return ;");
					}
					gclass342_0.method_9("this.WriteStartElement(" + DesignUtils.ToCShaprValueString(item4.method_4()) + ");");
					gclass342_0.method_9("Write_" + item4.method_3() + "_Properties( instance );");
					gclass342_0.method_9("this.WriteEndElement();");
					gclass342_0.method_12();
					gclass342_0.method_9("}");
					gclass342_0.method_9("private void Write_" + item4.method_3() + "_Properties(" + DesignUtils.GetCSharpTypeName(item4.method_0()) + " instance)");
					gclass342_0.method_9("{");
					gclass342_0.method_11();
					if (item4.method_0().IsClass)
					{
						gclass342_0.method_9("if( instance == null ) return ;");
					}
					if (item4.method_2() == null)
					{
						method_9(item4);
					}
					else
					{
						Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
						dictionary[item4.method_2()] = XMLSerializeHelper.GetXmlTypeName(item4.method_2());
						method_10(item4.method_2(), dictionary, "instance", bool_0: true);
					}
					gclass342_0.method_12();
					gclass342_0.method_9("}");
				}
			}
			gclass342_0.method_12();
			gclass342_0.method_9("}//public class");
			gclass342_0.method_12();
			gclass342_0.method_9("}//namespace");
		}

		private void method_9(Class69 class69_0)
		{
			int num = 18;
			Class68[] array = class69_0.method_7();
			foreach (Class68 @class in array)
			{
				if (@class.method_0())
				{
					continue;
				}
				Type propertyType = @class.method_4().PropertyType;
				DesignUtils.GetCSharpTypeName(propertyType);
				Class69 class2 = Class69.smethod_3(@class.method_4().PropertyType);
				if (propertyType.IsPrimitive || propertyType.Equals(typeof(string)) || propertyType.Equals(typeof(Color)) || propertyType.Equals(typeof(byte[])) || propertyType.IsEnum || propertyType.Equals(typeof(DateTime)) || class2 == null)
				{
					string text = null;
					if (@class.method_14())
					{
						text = "this.WritePropertyAttribute";
					}
					else if (@class.method_15())
					{
						text = "this.WritePropertyElement";
					}
					else if (@class.method_17())
					{
						text = "this.WriteString";
					}
					string text2 = "instance." + @class.method_4().Name;
					string text3 = null;
					if (@class.method_8())
					{
						text3 = DesignUtils.ToCShaprValueString(@class.method_9());
					}
					if (propertyType.IsEnum)
					{
						text2 = "EnumToString(instance." + @class.method_4().Name + ")";
						if (@class.method_8())
						{
							text3 = DesignUtils.ToCShaprValueString(GClass21.smethod_4(@class.method_9()));
						}
					}
					else if (propertyType.Equals(typeof(byte[])))
					{
						text3 = null;
					}
					if (@class.method_17())
					{
						gclass342_0.method_9(text + "(" + text2 + ");");
					}
					else if (string.IsNullOrEmpty(text3) || @class.method_17())
					{
						gclass342_0.method_9(text + "(\"" + @class.method_2() + "\"," + text2 + " );");
					}
					else
					{
						gclass342_0.method_9(text + "(\"" + @class.method_2() + "\"," + text2 + "," + text3 + " );");
					}
					continue;
				}
				bool flag = false;
				if (@class.method_6())
				{
					flag = true;
					if (@class.method_11().Count == 1)
					{
						Type collectionItemType = DesignUtils.GetCollectionItemType(@class.method_4().PropertyType, checkAddMethod: true);
						foreach (Type key in @class.method_11().Keys)
						{
							if (collectionItemType == key)
							{
								if (@class.method_11()[key] == XMLSerializeHelper.GetXmlTypeName(key))
								{
									flag = false;
								}
								break;
							}
						}
					}
				}
				if (flag)
				{
					gclass342_0.method_9("if ( instance." + @class.method_4().Name + " != null && instance." + @class.method_4().Name + ".Count > 0 )");
					gclass342_0.method_9("{");
					gclass342_0.method_11();
					gclass342_0.method_9("this.WriteStartElement(\"" + @class.method_2() + "\");");
					method_10(DesignUtils.GetCollectionItemType(@class.method_4().PropertyType, checkAddMethod: true), @class.method_11(), "instance." + @class.method_4().Name, bool_0: false);
					gclass342_0.method_9("this.WriteEndElement();");
					gclass342_0.method_12();
					gclass342_0.method_9("}//if");
					continue;
				}
				if (@class.method_4().PropertyType.IsClass)
				{
					if (@class.method_16())
					{
						gclass342_0.method_9("if ( instance." + @class.method_4().Name + " != null && instance." + @class.method_4().Name + ".Count > 0 )");
					}
					else
					{
						gclass342_0.method_9("if( instance." + @class.method_4().Name + " != null )");
					}
					gclass342_0.method_9("{");
					gclass342_0.method_11();
				}
				gclass342_0.method_9("this.WriteStartElement(\"" + @class.method_2() + "\");");
				gclass342_0.method_9("Write_" + class2.method_3() + "_Properties(instance." + @class.method_4().Name + ");");
				gclass342_0.method_9("this.WriteEndElement();");
				if (@class.method_4().PropertyType.IsClass)
				{
					gclass342_0.method_12();
					gclass342_0.method_9("}//if");
				}
			}
		}

		private void method_10(Type type_0, Dictionary<Type, string> dictionary_0, string string_2, bool bool_0)
		{
			int num = 1;
			if (dictionary_0 == null && dictionary_0.Count == 0)
			{
				return;
			}
			Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
			foreach (Type key in dictionary_0.Keys)
			{
				dictionary[key] = dictionary_0[key];
			}
			if (bool_0 && list_1 != null)
			{
				foreach (Class69 item in list_1)
				{
					Type type = item.method_0();
					foreach (Type key2 in dictionary_0.Keys)
					{
						if (type.IsSubclassOf(key2) && !dictionary_0.ContainsKey(type))
						{
							string text = dictionary[type] = XMLSerializeHelper.GetXmlTypeName(type);
							break;
						}
					}
				}
			}
			if (dictionary.Count == 1)
			{
				Type type_ = null;
				string str = null;
				foreach (Type key3 in dictionary.Keys)
				{
					type_ = key3;
					str = dictionary[key3];
				}
				gclass342_0.method_9("foreach(" + DesignUtils.GetCSharpTypeName(type_) + " item in " + string_2 + ")");
				gclass342_0.method_9("{");
				gclass342_0.method_11();
				gclass342_0.method_9("this.WriteStartElement(\"" + str + "\");");
				method_11(type_, "item");
				gclass342_0.method_9("this.WriteEndElement();");
				gclass342_0.method_12();
				gclass342_0.method_9("}//foreach");
			}
			else
			{
				if (type_0 == null)
				{
					type_0 = typeof(object);
				}
				gclass342_0.method_9("foreach( " + DesignUtils.GetCSharpTypeName(type_0) + " item in " + string_2 + ")");
				gclass342_0.method_9("{");
				gclass342_0.method_11();
				foreach (Type key4 in dictionary.Keys)
				{
					if (!key4.IsAbstract)
					{
						string str = dictionary[key4];
						gclass342_0.method_9("if( item is " + DesignUtils.GetCSharpTypeName(key4) + ")");
						gclass342_0.method_9("{");
						gclass342_0.method_11();
						gclass342_0.method_9("this.WriteStartElement(\"" + str + "\");");
						method_11(key4, "(" + DesignUtils.GetCSharpTypeName(key4) + ")item");
						gclass342_0.method_9("this.WriteEndElement();");
						gclass342_0.method_12();
						gclass342_0.method_9("}//if");
					}
				}
				gclass342_0.method_12();
				gclass342_0.method_9("}//foreach");
			}
		}

		private void method_11(Type type_0, string string_2)
		{
			int num = 12;
			string text = method_12(type_0, string_2);
			if (string.IsNullOrEmpty(text))
			{
				Class69 @class = Class69.smethod_3(type_0);
				if (@class == null)
				{
					throw new Exception("不支持的类型" + type_0.FullName);
				}
				gclass342_0.method_9("Write_" + @class.method_3() + "_Properties(" + string_2 + ");");
			}
			else
			{
				gclass342_0.method_9("this.WriteString(" + text + ");");
			}
		}

		private string method_12(Type type_0, string string_2)
		{
			int num = 2;
			if (type_0.IsEnum)
			{
				return "EnumToString(" + string_2 + ")";
			}
			if (type_0.Equals(typeof(Color)))
			{
				return "ColorToString(" + string_2 + ")";
			}
			if (type_0.Equals(typeof(DateTime)))
			{
				return "DateTimeToString(" + string_2 + ")";
			}
			if (type_0.Equals(typeof(string)))
			{
				return string_2;
			}
			if (type_0.Equals(typeof(byte[])))
			{
				return "ToBase64String(" + string_2 + ")";
			}
			if (type_0.IsPrimitive)
			{
				return string_2 + ".ToString()";
			}
			return null;
		}
	}
}
