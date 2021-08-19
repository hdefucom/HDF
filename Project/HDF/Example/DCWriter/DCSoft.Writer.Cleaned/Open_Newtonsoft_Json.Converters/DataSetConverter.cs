using Open_Newtonsoft_Json.Serialization;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	/// <summary>
	///       Converts a <see cref="T:System.Data.DataSet" /> to and from JSON.
	///       </summary>
	[ComVisible(false)]
	public class DataSetConverter : JsonConverter
	{
		/// <summary>
		///       Writes the JSON representation of the object.
		///       </summary>
		/// <param name="writer">The <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			DataSet dataSet = (DataSet)value;
			DefaultContractResolver defaultContractResolver = serializer.ContractResolver as DefaultContractResolver;
			DataTableConverter dataTableConverter = new DataTableConverter();
			writer.WriteStartObject();
			foreach (DataTable table in dataSet.Tables)
			{
				writer.WritePropertyName((defaultContractResolver != null) ? defaultContractResolver.GetResolvedPropertyName(table.TableName) : table.TableName);
				dataTableConverter.WriteJson(writer, table, serializer);
			}
			writer.WriteEndObject();
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
			DataSet dataSet = (objectType == typeof(DataSet)) ? new DataSet() : ((DataSet)Activator.CreateInstance(objectType));
			DataTableConverter dataTableConverter = new DataTableConverter();
			CheckedRead(reader);
			while (reader.TokenType == JsonToken.PropertyName)
			{
				DataTable dataTable = dataSet.Tables[(string)reader.Value];
				bool flag = dataTable != null;
				dataTable = (DataTable)dataTableConverter.ReadJson(reader, typeof(DataTable), dataTable, serializer);
				if (!flag)
				{
					dataSet.Tables.Add(dataTable);
				}
				CheckedRead(reader);
			}
			return dataSet;
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
			return typeof(DataSet).IsAssignableFrom(valueType);
		}

		private void CheckedRead(JsonReader reader)
		{
			int num = 8;
			if (!reader.Read())
			{
				throw JsonSerializationException.Create(reader, "Unexpected end when reading DataSet.");
			}
		}
	}
}
