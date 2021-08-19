using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class EnumUtils
	{
		private static readonly ThreadSafeStore<Type, BidirectionalDictionary<string, string>> EnumMemberNamesPerType = new ThreadSafeStore<Type, BidirectionalDictionary<string, string>>(InitializeEnumType);

		private static BidirectionalDictionary<string, string> InitializeEnumType(Type type)
		{
			int num = 14;
			BidirectionalDictionary<string, string> bidirectionalDictionary = new BidirectionalDictionary<string, string>(StringComparer.OrdinalIgnoreCase, StringComparer.OrdinalIgnoreCase);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				string name = fieldInfo.Name;
				string name2 = fieldInfo.Name;
				if (!bidirectionalDictionary.TryGetBySecond(name2, out string _))
				{
					bidirectionalDictionary.Set(name, name2);
					continue;
				}
				throw new InvalidOperationException(StringUtils.FormatWith("Enum name '{0}' already exists on enum '{1}'.", CultureInfo.InvariantCulture, name2, type.Name));
			}
			return bidirectionalDictionary;
		}

		public static IList<T> GetFlagsValues<T>(T value) where T : struct
		{
			int num = 13;
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsDefined(typeof(FlagsAttribute), inherit: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Enum type {0} is not a set of flags.", CultureInfo.InvariantCulture, typeFromHandle));
			}
			Type underlyingType = Enum.GetUnderlyingType(value.GetType());
			ulong num2 = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
			IList<EnumValue<ulong>> namesAndValues = GetNamesAndValues<T>();
			IList<T> list = new List<T>();
			foreach (EnumValue<ulong> item in namesAndValues)
			{
				if ((num2 & item.Value) == item.Value && item.Value != 0L)
				{
					list.Add((T)Convert.ChangeType(item.Value, underlyingType, CultureInfo.CurrentCulture));
				}
			}
			if (list.Count == 0 && Enumerable.SingleOrDefault(namesAndValues, (EnumValue<ulong> enumValue_0) => enumValue_0.Value == 0L) != null)
			{
				list.Add(default(T));
			}
			return list;
		}

		/// <summary>
		///       Gets a dictionary of the names and values of an Enum type.
		///       </summary>
		/// <returns>
		/// </returns>
		public static IList<EnumValue<ulong>> GetNamesAndValues<T>() where T : struct
		{
			return GetNamesAndValues<ulong>(typeof(T));
		}

		/// <summary>
		///       Gets a dictionary of the names and values of an Enum type.
		///       </summary>
		/// <param name="enumType">The enum type to get names and values for.</param>
		/// <returns>
		/// </returns>
		public static IList<EnumValue<TUnderlyingType>> GetNamesAndValues<TUnderlyingType>(Type enumType) where TUnderlyingType : struct
		{
			int num = 12;
			if (enumType == null)
			{
				throw new ArgumentNullException("enumType");
			}
			ValidationUtils.ArgumentTypeIsEnum(enumType, "enumType");
			IList<object> values = GetValues(enumType);
			IList<string> names = GetNames(enumType);
			IList<EnumValue<TUnderlyingType>> list = new List<EnumValue<TUnderlyingType>>();
			for (int i = 0; i < values.Count; i++)
			{
				try
				{
					list.Add(new EnumValue<TUnderlyingType>(names[i], (TUnderlyingType)Convert.ChangeType(values[i], typeof(TUnderlyingType), CultureInfo.CurrentCulture)));
				}
				catch (OverflowException innerException)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Value from enum with the underlying type of {0} cannot be added to dictionary with a value type of {1}. Value was too large: {2}", Enum.GetUnderlyingType(enumType), typeof(TUnderlyingType), Convert.ToUInt64(values[i], CultureInfo.InvariantCulture)), innerException);
				}
			}
			return list;
		}

		public static IList<object> GetValues(Type enumType)
		{
			int num = 5;
			if (!TypeExtensions.IsEnum(enumType))
			{
				throw new ArgumentException("Type '" + enumType.Name + "' is not an enum.");
			}
			List<object> list = new List<object>();
			IEnumerable<FieldInfo> enumerable = Enumerable.Where(enumType.GetFields(), (FieldInfo fieldInfo_0) => fieldInfo_0.IsLiteral);
			foreach (FieldInfo item in enumerable)
			{
				object value = item.GetValue(enumType);
				list.Add(value);
			}
			return list;
		}

		public static IList<string> GetNames(Type enumType)
		{
			int num = 9;
			if (!TypeExtensions.IsEnum(enumType))
			{
				throw new ArgumentException("Type '" + enumType.Name + "' is not an enum.");
			}
			List<string> list = new List<string>();
			IEnumerable<FieldInfo> enumerable = Enumerable.Where(enumType.GetFields(), (FieldInfo fieldInfo_0) => fieldInfo_0.IsLiteral);
			foreach (FieldInfo item in enumerable)
			{
				list.Add(item.Name);
			}
			return list;
		}

		public static object ParseEnumName(string enumText, bool isNullable, Type type_0)
		{
			int num = 2;
			if (enumText == string.Empty && isNullable)
			{
				return null;
			}
			BidirectionalDictionary<string, string> bidirectionalDictionary_ = EnumMemberNamesPerType.Get(type_0);
			string value;
			if (enumText.IndexOf(',') != -1)
			{
				string[] array = enumText.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					string enumText2 = array[i].Trim();
					array[i] = ResolvedEnumName(bidirectionalDictionary_, enumText2);
				}
				value = string.Join(", ", array);
			}
			else
			{
				value = ResolvedEnumName(bidirectionalDictionary_, enumText);
			}
			return Enum.Parse(type_0, value, ignoreCase: true);
		}

		public static string ToEnumName(Type enumType, string enumText, bool camelCaseText)
		{
			int num = 11;
			BidirectionalDictionary<string, string> bidirectionalDictionary = EnumMemberNamesPerType.Get(enumType);
			string[] array = enumText.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				bidirectionalDictionary.TryGetByFirst(text, out string second);
				second = (second ?? text);
				if (camelCaseText)
				{
					second = StringUtils.ToCamelCase(second);
				}
				array[i] = second;
			}
			return string.Join(", ", array);
		}

		private static string ResolvedEnumName(BidirectionalDictionary<string, string> bidirectionalDictionary_0, string enumText)
		{
			bidirectionalDictionary_0.TryGetBySecond(enumText, out string first);
			return first ?? enumText;
		}
	}
}
