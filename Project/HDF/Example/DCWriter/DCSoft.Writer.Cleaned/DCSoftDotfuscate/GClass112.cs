using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using Open_Newtonsoft_Json;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass112
	{
		private class MyJsonConverter : JsonConverter
		{
			public override bool CanWrite => true;

			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				throw new NotImplementedException();
			}

			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				if (value is Color)
				{
					string value2 = ColorTranslator.ToHtml((Color)value);
					writer.WriteValue(value2);
				}
				else if (value is DateTime)
				{
					DateTime dateTime_ = (DateTime)value;
					writer.WriteValue(FormatUtils.ToYYYY_MM_DD_HH_MM_SS(dateTime_));
				}
				else if (value == null)
				{
					writer.WriteNull();
				}
				else
				{
					writer.WriteValue(value.ToString());
				}
			}

			public override bool CanConvert(Type objectType)
			{
				if (objectType == typeof(Color) || objectType == typeof(DateTime) || objectType.IsEnum)
				{
					return true;
				}
				return false;
			}
		}

		public static string smethod_0(IDictionary idictionary_0, bool bool_0)
		{
			int num = 1;
			if (idictionary_0 == null || idictionary_0.Count == 0)
			{
				return "[]";
			}
			StringWriter stringWriter = new StringWriter();
			JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter);
			if (bool_0)
			{
				jsonTextWriter.Formatting = Formatting.Indented;
			}
			else
			{
				jsonTextWriter.Formatting = Formatting.None;
			}
			jsonTextWriter.WriteStartObject();
			foreach (object key in idictionary_0.Keys)
			{
				if (key != null)
				{
					object obj = idictionary_0[key];
					string value = (obj == null) ? "" : obj.ToString();
					jsonTextWriter.WritePropertyName(key.ToString());
					jsonTextWriter.WriteValue(value);
				}
			}
			jsonTextWriter.WriteEndObject();
			jsonTextWriter.Close();
			return stringWriter.ToString();
		}

		public static string smethod_1(ListItemCollection listItemCollection_0, bool bool_0)
		{
			int num = 3;
			if (listItemCollection_0 == null || listItemCollection_0.Count == 0)
			{
				return "[]";
			}
			StringWriter stringWriter = new StringWriter();
			JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter);
			if (bool_0)
			{
				jsonTextWriter.Formatting = Formatting.Indented;
			}
			else
			{
				jsonTextWriter.Formatting = Formatting.None;
			}
			jsonTextWriter.WriteStartArray();
			foreach (ListItem item in listItemCollection_0)
			{
				jsonTextWriter.WriteStartObject();
				jsonTextWriter.WritePropertyName("Text");
				jsonTextWriter.WriteValue(item.Text);
				jsonTextWriter.WritePropertyName("Value");
				jsonTextWriter.WriteValue(item.Value);
				jsonTextWriter.WritePropertyName("TextInList");
				jsonTextWriter.WriteValue(item.TextInList);
				jsonTextWriter.WriteEndObject();
			}
			jsonTextWriter.WriteEndArray();
			jsonTextWriter.Close();
			return stringWriter.ToString();
		}

		public static string smethod_2(DocumentOptions documentOptions_0, bool bool_0)
		{
			return JsonConvert.SerializeObject(documentOptions_0, bool_0 ? Formatting.Indented : Formatting.None, new MyJsonConverter());
		}
	}
}
