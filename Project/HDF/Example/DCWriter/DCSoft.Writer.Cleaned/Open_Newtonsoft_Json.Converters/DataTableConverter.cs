using Open_Newtonsoft_Json.Serialization;
using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts a <see cref="T:System.Data.DataTable" /> to and from JSON.
	///       </summary>
	[ComVisible(false)]
	public class DataTableConverter : JsonConverter
	{
		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			DataTable dataTable = (DataTable)value;
			DefaultContractResolver defaultContractResolver = serializer.ContractResolver as DefaultContractResolver;
			writer.WriteStartArray();
			foreach (DataRow row in dataTable.Rows)
			{
				writer.WriteStartObject();
				foreach (DataColumn column in row.Table.Columns)
				{
					object obj = row[column];
					if (serializer.NullValueHandling != NullValueHandling.Ignore || (obj != null && obj != DBNull.Value))
					{
						writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName(column.ColumnName) : column.ColumnName);
						serializer.Serialize(writer, obj);
					}
				}
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
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
			int num = 5;
			DataTable dataTable = existingValue as DataTable;
			if (dataTable == null)
			{
				dataTable = ((objectType == typeof(DataTable)) ? new DataTable() : ((DataTable)Activator.CreateInstance(objectType)));
			}
			if (reader.TokenType == JsonToken.PropertyName)
			{
				dataTable.TableName = (string)reader.Value;
				CheckedRead(reader);
			}
			if (reader.TokenType != JsonToken.StartArray)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected JSON token when reading DataTable. Expected StartArray, got {0}.", CultureInfo.InvariantCulture, reader.TokenType));
			}
			CheckedRead(reader);
			while (reader.TokenType != JsonToken.EndArray)
			{
				CreateRow(reader, dataTable, serializer);
				CheckedRead(reader);
			}
			return dataTable;
		}

		private static void CreateRow(JsonReader reader, DataTable dataTable_0, JsonSerializer serializer)
		{
			DataRow dataRow = dataTable_0.NewRow();
			CheckedRead(reader);
			while (reader.TokenType == JsonToken.PropertyName)
			{
				string text = (string)reader.Value;
				CheckedRead(reader);
				DataColumn dataColumn = dataTable_0.Columns[text];
				if (dataColumn == null)
				{
					Type columnDataType = GetColumnDataType(reader);
					dataColumn = new DataColumn(text, columnDataType);
					dataTable_0.Columns.Add(dataColumn);
				}
				if (dataColumn.DataType == typeof(DataTable))
				{
					if (reader.TokenType == JsonToken.StartArray)
					{
						CheckedRead(reader);
					}
					DataTable dataTable = new DataTable();
					while (reader.TokenType != JsonToken.EndArray)
					{
						CreateRow(reader, dataTable, serializer);
						CheckedRead(reader);
					}
					dataRow[text] = dataTable;
				}
				else if (dataColumn.DataType.IsArray && dataColumn.DataType != typeof(byte[]))
				{
					if (reader.TokenType == JsonToken.StartArray)
					{
						CheckedRead(reader);
					}
					List<object> list = new List<object>();
					while (reader.TokenType != JsonToken.EndArray)
					{
						list.Add(reader.Value);
						CheckedRead(reader);
					}
					Array array = Array.CreateInstance(dataColumn.DataType.GetElementType(), list.Count);
					Array.Copy(list.ToArray(), array, list.Count);
					dataRow[text] = array;
				}
				else
				{
					dataRow[text] = ((reader.Value != null) ? serializer.Deserialize(reader, dataColumn.DataType) : DBNull.Value);
				}
				CheckedRead(reader);
			}
			dataRow.EndEdit();
			dataTable_0.Rows.Add(dataRow);
		}

		private static Type GetColumnDataType(JsonReader reader)
		{
			int num = 8;
			JsonToken tokenType = reader.TokenType;
			switch (tokenType)
			{
			case JsonToken.StartArray:
			{
				CheckedRead(reader);
				if (reader.TokenType == JsonToken.StartObject)
				{
					return typeof(DataTable);
				}
				Type columnDataType = GetColumnDataType(reader);
				return columnDataType.MakeArrayType();
			}
			case JsonToken.Null:
			case JsonToken.Undefined:
				return typeof(string);
			default:
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected JSON token when reading DataTable: {0}", CultureInfo.InvariantCulture, tokenType));
			case JsonToken.Integer:
			case JsonToken.Float:
			case JsonToken.String:
			case JsonToken.Boolean:
			case JsonToken.Date:
			case JsonToken.Bytes:
				return reader.ValueType;
			}
		}

		private static void CheckedRead(JsonReader reader)
		{
			int num = 19;
			if (!reader.Read())
			{
				throw JsonSerializationException.Create(reader, "Unexpected end when reading DataTable.");
			}
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
			return typeof(DataTable).IsAssignableFrom(valueType);
		}
	}
}
