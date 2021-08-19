using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class MiscellaneousUtils
	{
		public static bool ValueEquals(object objA, object objB)
		{
			if (objA == null && objB == null)
			{
				return true;
			}
			if (objA != null && objB == null)
			{
				return false;
			}
			if (objA == null && objB != null)
			{
				return false;
			}
			if (objA.GetType() != objB.GetType())
			{
				if (ConvertUtils.IsInteger(objA) && ConvertUtils.IsInteger(objB))
				{
					return Convert.ToDecimal(objA, CultureInfo.CurrentCulture).Equals(Convert.ToDecimal(objB, CultureInfo.CurrentCulture));
				}
				if ((objA is double || objA is float || objA is decimal) && (objB is double || objB is float || objB is decimal))
				{
					return MathUtils.ApproxEquals(Convert.ToDouble(objA, CultureInfo.CurrentCulture), Convert.ToDouble(objB, CultureInfo.CurrentCulture));
				}
				return false;
			}
			return objA.Equals(objB);
		}

		public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(string paramName, object actualValue, string message)
		{
			string message2 = message + Environment.NewLine + StringUtils.FormatWith("Actual value was {0}.", CultureInfo.InvariantCulture, actualValue);
			return new ArgumentOutOfRangeException(paramName, message2);
		}

		public static string ToString(object value)
		{
			int num = 2;
			if (value == null)
			{
				return "{null}";
			}
			return (value is string) ? ("\"" + value.ToString() + "\"") : value.ToString();
		}

		public static int ByteArrayCompare(byte[] byte_0, byte[] byte_1)
		{
			int num = byte_0.Length.CompareTo(byte_1.Length);
			if (num != 0)
			{
				return num;
			}
			int num2 = 0;
			int num3;
			while (true)
			{
				if (num2 < byte_0.Length)
				{
					num3 = byte_0[num2].CompareTo(byte_1[num2]);
					if (num3 != 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return 0;
			}
			return num3;
		}

		public static string GetPrefix(string qualifiedName)
		{
			GetQualifiedNameParts(qualifiedName, out string prefix, out string _);
			return prefix;
		}

		public static string GetLocalName(string qualifiedName)
		{
			GetQualifiedNameParts(qualifiedName, out string _, out string localName);
			return localName;
		}

		public static void GetQualifiedNameParts(string qualifiedName, out string prefix, out string localName)
		{
			int num = qualifiedName.IndexOf(':');
			if (num == -1 || num == 0 || qualifiedName.Length - 1 == num)
			{
				prefix = null;
				localName = qualifiedName;
			}
			else
			{
				prefix = qualifiedName.Substring(0, num);
				localName = qualifiedName.Substring(num + 1);
			}
		}

		internal static string FormatValueForPrint(object value)
		{
			int num = 2;
			if (value == null)
			{
				return "{null}";
			}
			if (value is string)
			{
				return string.Concat("\"", value, "\"");
			}
			return value.ToString();
		}
	}
}
