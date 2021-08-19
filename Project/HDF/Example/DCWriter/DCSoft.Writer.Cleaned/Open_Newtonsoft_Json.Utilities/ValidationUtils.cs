using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class ValidationUtils
	{
		public static void ArgumentNotNullOrEmpty(string value, string parameterName)
		{
			int num = 10;
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
			if (value.Length == 0)
			{
				throw new ArgumentException(StringUtils.FormatWith("'{0}' cannot be empty.", CultureInfo.InvariantCulture, parameterName), parameterName);
			}
		}

		public static void ArgumentTypeIsEnum(Type enumType, string parameterName)
		{
			int num = 6;
			ArgumentNotNull(enumType, "enumType");
			if (!TypeExtensions.IsEnum(enumType))
			{
				throw new ArgumentException(StringUtils.FormatWith("Type {0} is not an Enum.", CultureInfo.InvariantCulture, enumType), parameterName);
			}
		}

		public static void ArgumentNotNull(object value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}
	}
}
