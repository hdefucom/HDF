using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass21
	{
		private class Class54
		{
			public bool bool_0 = false;

			public long[] long_0 = null;

			public string[] string_0 = null;
		}

		private XmlTextWriter xmlTextWriter_0 = null;

		private static Dictionary<Type, Class54> dictionary_0 = new Dictionary<Type, Class54>();

		public void method_0(object object_0, TextWriter textWriter_0)
		{
			xmlTextWriter_0 = new XmlTextWriter(textWriter_0);
			vmethod_0(object_0);
		}

		protected virtual void vmethod_0(object object_0)
		{
		}

		public XmlTextWriter method_1()
		{
			return xmlTextWriter_0;
		}

		public void method_2(XmlTextWriter xmlTextWriter_1)
		{
			xmlTextWriter_0 = xmlTextWriter_1;
		}

		protected void method_3(string string_0)
		{
			xmlTextWriter_0.WriteStartElement(string_0);
		}

		protected void method_4(string string_0, string string_1)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, string_1);
		}

		protected void method_5(string string_0, string string_1)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				xmlTextWriter_0.WriteAttributeString(string_0, string_1);
			}
		}

		protected void method_6(string string_0, string string_1, string string_2)
		{
			if (!string.IsNullOrEmpty(string_1) && string_1 != string_2)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, string_1);
			}
		}

		protected void method_7(string string_0, int int_0, int int_1)
		{
			if (int_0 != int_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, int_0.ToString());
			}
		}

		protected void method_8(string string_0, int int_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, int_0.ToString());
		}

		protected void method_9(string string_0, float float_0, float float_1)
		{
			if (float_0 != float_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, float_0.ToString());
			}
		}

		protected void method_10(string string_0, float float_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, float_0.ToString());
		}

		protected void method_11(string string_0, double double_0, double double_1)
		{
			if (double_0 != double_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, double_0.ToString());
			}
		}

		protected void method_12(string string_0, double double_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, double_0.ToString());
		}

		protected void method_13(string string_0, char char_0, char char_1)
		{
			if (char_0 != char_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, char_0.ToString());
			}
		}

		protected void method_14(string string_0, char char_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, char_0.ToString());
		}

		protected void method_15(string string_0, bool bool_0, bool bool_1)
		{
			if (bool_0 != bool_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, bool_0.ToString());
			}
		}

		protected void method_16(string string_0, bool bool_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, bool_0.ToString());
		}

		protected void method_17(string string_0, DateTime dateTime_0, DateTime dateTime_1)
		{
			if (dateTime_0 != dateTime_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, Class58.smethod_1(dateTime_0));
			}
		}

		protected void method_18(string string_0, DateTime dateTime_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, Class58.smethod_1(dateTime_0));
		}

		protected void method_19(string string_0, Color color_0, Color color_1)
		{
			if (color_0.ToArgb() != color_1.ToArgb())
			{
				xmlTextWriter_0.WriteAttributeString(string_0, Class58.smethod_2(color_0));
			}
		}

		protected void method_20(string string_0, Color color_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, Class58.smethod_2(color_0));
		}

		protected void method_21(string string_0, decimal decimal_0, decimal decimal_1)
		{
			if (decimal_0 != decimal_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, decimal_0.ToString());
			}
		}

		protected void method_22(string string_0, decimal decimal_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, decimal_0.ToString());
		}

		protected void method_23(string string_0, byte byte_0, byte byte_1)
		{
			if (byte_0 != byte_1)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, byte_0.ToString());
			}
		}

		protected void method_24(string string_0, byte byte_0)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, byte_0.ToString());
		}

		protected void method_25(string string_0, string string_1)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				xmlTextWriter_0.WriteElementString(string_0, string_1);
			}
		}

		protected void method_26(string string_0, string string_1, string string_2)
		{
			if (!string.IsNullOrEmpty(string_1) && string_1 != string_2)
			{
				xmlTextWriter_0.WriteElementString(string_0, string_1);
			}
		}

		protected void method_27(string string_0, int int_0, int int_1)
		{
			if (int_0 != int_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, int_0.ToString());
			}
		}

		protected void method_28(string string_0, int int_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, int_0.ToString());
		}

		protected void method_29(string string_0, float float_0, float float_1)
		{
			if (float_0 != float_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, float_0.ToString());
			}
		}

		protected void method_30(string string_0, float float_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, float_0.ToString());
		}

		protected void method_31(string string_0, double double_0, double double_1)
		{
			if (double_0 != double_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, double_0.ToString());
			}
		}

		protected void method_32(string string_0, double double_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, double_0.ToString());
		}

		protected void method_33(string string_0, char char_0, char char_1)
		{
			if (char_0 != char_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, char_0.ToString());
			}
		}

		protected void method_34(string string_0, char char_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, char_0.ToString());
		}

		protected void method_35(string string_0, bool bool_0, bool bool_1)
		{
			if (bool_0 != bool_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, bool_0.ToString());
			}
		}

		protected void method_36(string string_0, bool bool_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, bool_0.ToString());
		}

		protected void method_37(string string_0, DateTime dateTime_0, DateTime dateTime_1)
		{
			if (dateTime_0 != dateTime_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, smethod_2(dateTime_0));
			}
		}

		protected void method_38(string string_0, DateTime dateTime_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, smethod_2(dateTime_0));
		}

		protected void method_39(string string_0, Color color_0, Color color_1)
		{
			if (color_0.ToArgb() != color_1.ToArgb())
			{
				xmlTextWriter_0.WriteElementString(string_0, smethod_1(color_0));
			}
		}

		protected void method_40(string string_0, Color color_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, smethod_1(color_0));
		}

		protected void method_41(string string_0, decimal decimal_0, decimal decimal_1)
		{
			if (decimal_0 != decimal_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, decimal_0.ToString());
			}
		}

		protected void method_42(string string_0, decimal decimal_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, decimal_0.ToString());
		}

		protected void method_43(string string_0, byte byte_0, byte byte_1)
		{
			if (byte_0 != byte_1)
			{
				xmlTextWriter_0.WriteElementString(string_0, byte_0.ToString());
			}
		}

		protected void method_44(string string_0, byte byte_0)
		{
			xmlTextWriter_0.WriteElementString(string_0, byte_0.ToString());
		}

		protected void method_45(string string_0, byte[] byte_0)
		{
			if (byte_0 != null && byte_0.Length > 0)
			{
				xmlTextWriter_0.WriteElementString(string_0, smethod_5(byte_0));
			}
		}

		protected void method_46(string string_0, byte[] byte_0)
		{
			if (byte_0 != null && byte_0.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString(string_0, smethod_5(byte_0));
			}
		}

		protected void method_47(string string_0, string string_1)
		{
			if (!string.IsNullOrEmpty(string_0) && !string.IsNullOrEmpty(string_1))
			{
				xmlTextWriter_0.WriteAttributeString(string_0, string_1);
			}
		}

		protected void method_48()
		{
			xmlTextWriter_0.WriteEndElement();
		}

		protected void method_49()
		{
			xmlTextWriter_0.WriteFullEndElement();
		}

		protected void method_50(string string_0)
		{
			xmlTextWriter_0.WriteCData(string_0);
		}

		protected void method_51(string string_0, string string_1)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				xmlTextWriter_0.WriteStartElement(string_0);
				xmlTextWriter_0.WriteCData(string_1);
				xmlTextWriter_0.WriteEndElement();
			}
		}

		protected void method_52(string string_0)
		{
			xmlTextWriter_0.WriteString(string_0);
		}

		private void method_53(XTextDocument xtextDocument_0)
		{
			int num = 8;
			if (xtextDocument_0 != null)
			{
				method_47("BaseUrl", xtextDocument_0.BaseUrl);
				method_51("BodyText", xtextDocument_0.BodyText);
				method_55(xtextDocument_0.Attributes);
				method_54(xtextDocument_0.Comments);
			}
		}

		private void method_54(DocumentCommentList documentCommentList_0)
		{
			int num = 18;
			if (documentCommentList_0 != null && documentCommentList_0.Count > 0)
			{
				foreach (DocumentComment item in documentCommentList_0)
				{
					method_3("Comment");
					method_5("Author", item.Author);
					method_5("AuthorID", item.AuthorID);
					method_17("CreationTime", item.CreationTime, DocumentComment.dateTime_0);
					method_7("CreatorIndex", item.CreatorIndex, -1);
					method_19("ForeColor", item.ForeColor, Color.Black);
					method_15("false", item.BindingUserTrack, bool_1: false);
					if (item.Attributes != null)
					{
						method_55(item.Attributes);
					}
					method_48();
				}
			}
		}

		private void method_55(XAttributeList xattributeList_0)
		{
			int num = 9;
			if (xattributeList_0 != null && xattributeList_0.Count > 0)
			{
				foreach (XAttribute item in xattributeList_0)
				{
					method_3("Attribute");
					method_5("Name", item.Name);
					method_52(item.Value);
					method_48();
				}
			}
		}

		private void method_56(DocumentParameterCollection documentParameterCollection_0)
		{
			int num = 15;
			if (documentParameterCollection_0 != null && documentParameterCollection_0.Count > 0)
			{
				foreach (DocumentParameter item in documentParameterCollection_0)
				{
					method_3("Parameter");
					method_4("Name", item.Name);
					method_5("Description", item.Description);
					method_52(item.SerializeStringValue);
					method_48();
				}
			}
		}

		protected static string smethod_0(object object_0)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return "";
			}
			return Convert.ToString(object_0);
		}

		protected static string smethod_1(Color color_0)
		{
			return XMLSerializeHelper.ColorToString(color_0);
		}

		protected static string smethod_2(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyy-MM-dd HH:mm:ss");
		}

		private static Class54 smethod_3(Type type_0)
		{
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			Class54 @class = new Class54();
			@class.bool_0 = (Attribute.GetCustomAttribute(type_0, typeof(FlagsAttribute), inherit: true) != null);
			List<long> list = new List<long>();
			List<string> list2 = new List<string>();
			FieldInfo[] fields = type_0.GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				list.Add(Convert.ToInt64(fieldInfo.GetValue(null)));
				string name = fieldInfo.Name;
				XmlEnumAttribute xmlEnumAttribute = (XmlEnumAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(XmlEnumAttribute), inherit: true);
				if (xmlEnumAttribute != null && !string.IsNullOrEmpty(xmlEnumAttribute.Name))
				{
					name = xmlEnumAttribute.Name;
				}
				list2.Add(name);
			}
			@class.long_0 = list.ToArray();
			@class.string_0 = list2.ToArray();
			dictionary_0[type_0] = @class;
			return @class;
		}

		public static string smethod_4(object object_0)
		{
			int num = 14;
			Class54 @class = smethod_3(object_0.GetType());
			long num2 = Convert.ToInt64(object_0);
			int num3;
			if (@class.bool_0)
			{
				num3 = 0;
				while (true)
				{
					if (num3 < @class.long_0.Length)
					{
						long num4 = @class.long_0[num3];
						if (num4 == num2)
						{
							break;
						}
						num3++;
						continue;
					}
					StringBuilder stringBuilder = new StringBuilder();
					for (num3 = 0; num3 < @class.long_0.Length; num3++)
					{
						long num4 = @class.long_0[num3];
						if ((num4 & num2) == num4)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							stringBuilder.Append(@class.string_0[num3]);
						}
					}
					return stringBuilder.ToString();
				}
				return @class.string_0[num3];
			}
			num3 = 0;
			while (true)
			{
				if (num3 < @class.long_0.Length)
				{
					long num4 = @class.long_0[num3];
					if (num4 == num2)
					{
						break;
					}
					num3++;
					continue;
				}
				return object_0.ToString();
			}
			return @class.string_0[num3];
		}

		protected static string smethod_5(byte[] byte_0)
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			string strData = Convert.ToBase64String(byte_0);
			return StringFormatHelper.GroupFormatString(strData, 16, 16);
		}
	}
}
