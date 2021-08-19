using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Open_Newtonsoft_Json
{
	[ComVisible(false)]
	internal struct JsonPosition
	{
		private static readonly char[] SpecialCharacters = new char[6]
		{
			'.',
			' ',
			'[',
			']',
			'(',
			')'
		};

		internal JsonContainerType Type;

		internal int Position;

		internal string PropertyName;

		internal bool HasIndex;

		public JsonPosition(JsonContainerType type)
		{
			Type = type;
			HasIndex = TypeHasIndex(type);
			Position = -1;
			PropertyName = null;
		}

		internal void WriteTo(StringBuilder stringBuilder_0)
		{
			int num = 7;
			switch (Type)
			{
			case JsonContainerType.Object:
			{
				if (stringBuilder_0.Length > 0)
				{
					stringBuilder_0.Append('.');
				}
				string propertyName = PropertyName;
				if (propertyName.IndexOfAny(SpecialCharacters) != -1)
				{
					stringBuilder_0.Append("['");
					stringBuilder_0.Append(propertyName);
					stringBuilder_0.Append("']");
				}
				else
				{
					stringBuilder_0.Append(propertyName);
				}
				break;
			}
			case JsonContainerType.Array:
			case JsonContainerType.Constructor:
				stringBuilder_0.Append('[');
				stringBuilder_0.Append(Position);
				stringBuilder_0.Append(']');
				break;
			}
		}

		internal static bool TypeHasIndex(JsonContainerType type)
		{
			return type == JsonContainerType.Array || type == JsonContainerType.Constructor;
		}

		internal static string BuildPath(IEnumerable<JsonPosition> positions)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (JsonPosition position in positions)
			{
				position.WriteTo(stringBuilder);
			}
			return stringBuilder.ToString();
		}

		internal static string FormatMessage(IJsonLineInfo lineInfo, string path, string message)
		{
			int num = 14;
			if (!message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
			{
				message = message.Trim();
				if (!StringUtils.EndsWith(message, '.'))
				{
					message += ".";
				}
				message += " ";
			}
			message += StringUtils.FormatWith("Path '{0}'", CultureInfo.InvariantCulture, path);
			if (lineInfo != null && lineInfo.HasLineInfo())
			{
				message += StringUtils.FormatWith(", line {0}, position {1}", CultureInfo.InvariantCulture, lineInfo.LineNumber, lineInfo.LinePosition);
			}
			message += ".";
			return message;
		}
	}
}
