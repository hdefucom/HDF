#define DEBUG
using Evaluant.Calculator;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass53 : GClass52
	{
		public const int int_0 = 2147439148;

		public static string string_1 = "DCExpression.";

		public static string[] string_2 = new string[47]
		{
			"LOOKUP",
			"IF",
			"AGE",
			"AGEMONTH",
			"AGEWEEK",
			"AGEDAY",
			"AGEHOUR",
			"FIND",
			"LEN",
			"PARAMETER",
			"ABS",
			"ACOS",
			"ASIN",
			"ATAN",
			"ATAN2",
			"AVERAGE",
			"CEILING",
			"COS",
			"COUNT",
			"EXP",
			"FLOOR",
			"INT",
			"LOG",
			"LOG10",
			"MAX",
			"MIN",
			"MOD",
			"ODD",
			"PI",
			"POW",
			"PRODUCT",
			"RADIANS",
			"RAND",
			"ROUNDDOWN",
			"ROUNDUP",
			"ROUND",
			"SIGN",
			"SIN",
			"SQRT",
			"SUM",
			"TAN",
			"PARAMETER",
			"CINT",
			"CDOUBLE",
			"LEN",
			"FIND",
			"FINDINDEX"
		};

		public GDelegate2 gdelegate2_1 = null;

		private static Random random_0 = new Random();

		public static string smethod_3(string string_3)
		{
			string str = string_1;
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (char c in string_3)
			{
				if (char.IsLetterOrDigit(c))
				{
					stringBuilder2.Append(c);
					continue;
				}
				if (stringBuilder2.Length > 0)
				{
					string text = stringBuilder2.ToString();
					string[] array = string_2;
					foreach (string strA in array)
					{
						if (string.Compare(strA, text, ignoreCase: true) == 0)
						{
							text = str + text.ToUpper();
							break;
						}
					}
					stringBuilder.Append(text);
					stringBuilder2 = new StringBuilder();
				}
				stringBuilder.Append(c);
			}
			if (stringBuilder2.Length > 0)
			{
				string text = stringBuilder2.ToString().ToUpper();
				string[] array = string_2;
				foreach (string strA in array)
				{
					if (text == strA)
					{
						text = str + text;
					}
				}
				stringBuilder.Append(text);
			}
			return stringBuilder.ToString();
		}

		public GClass53(string string_3)
			: base(string_3)
		{
			method_5(method_11);
		}

		private void method_11(string string_3, GEventArgs1 geventArgs1_0)
		{
			int num = 0;
			if (gdelegate2_1 != null)
			{
				gdelegate2_1(string_3, geventArgs1_0);
				if (geventArgs1_0.method_2())
				{
					return;
				}
			}
			switch (string_3.ToUpper())
			{
			case "LOOKUP":
				if (geventArgs1_0.method_4().Length >= 3)
				{
					double num2 = Convert.ToDouble(geventArgs1_0.method_4()[0]);
					object object_ = null;
					for (int i = 1; i < geventArgs1_0.method_4().Length; i += 2)
					{
						double num3 = Convert.ToDouble(geventArgs1_0.method_4()[i]);
						if (num2 < num3)
						{
							break;
						}
						if (i + 1 < geventArgs1_0.method_4().Length)
						{
							object_ = geventArgs1_0.method_4()[i + 1];
						}
					}
					geventArgs1_0.method_1(object_);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "IF":
				if (geventArgs1_0.method_4().Length >= 3)
				{
					bool flag = false;
					object obj3 = geventArgs1_0.method_4()[0];
					if (obj3 == null || DBNull.Value.Equals(obj3))
					{
						flag = false;
					}
					else if (obj3 is float)
					{
						flag = !float.IsNaN((float)obj3);
					}
					else if (obj3 is double)
					{
						flag = !double.IsNaN((double)obj3);
					}
					else if (obj3 is string)
					{
						string text2 = (string)obj3;
						flag = (text2 != null && !string.IsNullOrEmpty(text2) && Convert.ToBoolean(text2));
					}
					else
					{
						flag = Convert.ToBoolean(obj3);
					}
					if (flag)
					{
						geventArgs1_0.method_1(geventArgs1_0.method_4()[1]);
					}
					else
					{
						geventArgs1_0.method_1(geventArgs1_0.method_4()[2]);
					}
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "AGE":
				if (geventArgs1_0.method_4().Length >= 1)
				{
					geventArgs1_0.method_1(method_12(geventArgs1_0.method_4()[0], 0));
				}
				else
				{
					geventArgs1_0.method_1(0);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "AGEMONTH":
				if (geventArgs1_0.method_4().Length >= 1)
				{
					geventArgs1_0.method_1(method_12(geventArgs1_0.method_4()[0], 1));
				}
				else
				{
					geventArgs1_0.method_1(0);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "AGEWEEK":
				if (geventArgs1_0.method_4().Length >= 1)
				{
					geventArgs1_0.method_1(method_12(geventArgs1_0.method_4()[0], 2));
				}
				else
				{
					geventArgs1_0.method_1(0);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "AGEDAY":
				if (geventArgs1_0.method_4().Length >= 1)
				{
					geventArgs1_0.method_1(method_12(geventArgs1_0.method_4()[0], 3));
				}
				else
				{
					geventArgs1_0.method_1(0);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "AGEHOUR":
				if (geventArgs1_0.method_4().Length >= 1)
				{
					geventArgs1_0.method_1(method_12(geventArgs1_0.method_4()[0], 4));
				}
				else
				{
					geventArgs1_0.method_1(0);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "FINDINDEX":
				geventArgs1_0.method_1(-1);
				if (geventArgs1_0.method_4().Length >= 2 && geventArgs1_0.method_4()[0] != null && !DBNull.Value.Equals(geventArgs1_0.method_4()[0]) && geventArgs1_0.method_4()[1] != null && !DBNull.Value.Equals(geventArgs1_0.method_4()[1]))
				{
					string value = Convert.ToString(smethod_35(geventArgs1_0.method_4()[0], bool_0: true));
					string text = Convert.ToString(smethod_35(geventArgs1_0.method_4()[1], bool_0: true));
					if (!string.IsNullOrEmpty(text))
					{
						string[] array = text.Split(',');
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (a == value)
							{
								geventArgs1_0.method_1(i);
								break;
							}
						}
					}
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "FIND":
				if (geventArgs1_0.method_4().Length >= 2)
				{
					if (geventArgs1_0.method_4()[0] != null && !DBNull.Value.Equals(geventArgs1_0.method_4()[0]) && geventArgs1_0.method_4()[1] != null && !DBNull.Value.Equals(geventArgs1_0.method_4()[1]))
					{
						string value = Convert.ToString(smethod_35(geventArgs1_0.method_4()[0], bool_0: true));
						string text = Convert.ToString(smethod_35(geventArgs1_0.method_4()[1], bool_0: true));
						geventArgs1_0.method_1(text.IndexOf(value));
					}
					else
					{
						geventArgs1_0.method_1(-1);
					}
				}
				else
				{
					geventArgs1_0.method_1(-1);
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "LEN":
				geventArgs1_0.method_1(0);
				if (geventArgs1_0.method_4().Length > 0)
				{
					object obj4 = smethod_35(geventArgs1_0.method_4()[0], bool_0: true);
					if (obj4 == null || DBNull.Value.Equals(obj4))
					{
						geventArgs1_0.method_1(0);
					}
					else if (obj4 is float)
					{
						if (float.IsNaN((float)obj4))
						{
							geventArgs1_0.method_1(0);
						}
						else
						{
							geventArgs1_0.method_1(obj4.ToString().Length);
						}
					}
					else if (obj4 is double)
					{
						if (double.IsNaN((double)obj4))
						{
							geventArgs1_0.method_1(0);
						}
						else
						{
							geventArgs1_0.method_1(obj4.ToString().Length);
						}
					}
					else
					{
						string text3 = Convert.ToString(obj4);
						geventArgs1_0.method_1(text3.Length);
					}
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "PARAMETER":
				if (geventArgs1_0.method_4().Length == 0 || method_9() == null)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					string key = Convert.ToString(smethod_35(geventArgs1_0.method_4()[0], bool_0: true));
					if (method_9().Contains(key))
					{
						geventArgs1_0.method_1(2147439148);
					}
					else
					{
						geventArgs1_0.method_1(method_9()[key]);
					}
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ABS":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_7(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ACOS":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_8(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ASIN":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_9(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ATAN":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_10(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ATAN2":
				if (geventArgs1_0.method_4().Length < 2)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_11(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "AVERAGE":
				geventArgs1_0.method_1(smethod_12(geventArgs1_0.method_4()));
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "CEILING":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_13(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "COS":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_14(geventArgs1_0.method_4()[0]));
				}
				break;
			case "COUNT":
				geventArgs1_0.method_1(smethod_15(geventArgs1_0.method_4()));
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "EXP":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(method_14(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "FLOOR":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_16(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "INT":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_17(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "LOG":
				if (geventArgs1_0.method_4().Length < 2)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_18(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "LOG10":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_19(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "MAX":
				geventArgs1_0.method_1(smethod_20(geventArgs1_0.method_4()));
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "MIN":
				geventArgs1_0.method_1(smethod_21(geventArgs1_0.method_4()));
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "MOD":
				if (geventArgs1_0.method_4().Length < 2)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_22(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ODD":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_23(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "POW":
				if (geventArgs1_0.method_4().Length < 2)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_24(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "PRODUCT":
				geventArgs1_0.method_1(smethod_25(geventArgs1_0.method_4()));
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "RADIANS":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_26(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "RAND":
				geventArgs1_0.method_1(method_15());
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ROUND":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else if (geventArgs1_0.method_4().Length == 1)
				{
					geventArgs1_0.method_1(smethod_27(geventArgs1_0.method_4()[0], null));
				}
				else
				{
					geventArgs1_0.method_1(smethod_27(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ROUNDDOWN":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_28(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "ROUNDUP":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_29(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "SIGN":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_30(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "SIN":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_31(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "SQRT":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_32(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "SUM":
				geventArgs1_0.method_1(smethod_33(geventArgs1_0.method_4()));
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "TAN":
				if (geventArgs1_0.method_4().Length == 0)
				{
					geventArgs1_0.method_1(2147439148);
				}
				else
				{
					geventArgs1_0.method_1(smethod_34(geventArgs1_0.method_4()[0]));
				}
				geventArgs1_0.method_3(bool_1: true);
				break;
			case "CINT":
				if (geventArgs1_0.method_4().Length == 2)
				{
					geventArgs1_0.method_1(smethod_5(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				else if (geventArgs1_0.method_4().Length == 1)
				{
					try
					{
						double num2 = Convert.ToDouble(geventArgs1_0.method_4()[0]);
						geventArgs1_0.method_1((int)num2);
					}
					catch
					{
						geventArgs1_0.method_1(0);
					}
				}
				else
				{
					geventArgs1_0.method_1(2147439148);
				}
				break;
			case "CDOUBLE":
				if (geventArgs1_0.method_4().Length == 2)
				{
					geventArgs1_0.method_1(smethod_6(geventArgs1_0.method_4()[0], geventArgs1_0.method_4()[1]));
				}
				else if (geventArgs1_0.method_4().Length == 1)
				{
					try
					{
						geventArgs1_0.method_1(Convert.ToDouble(geventArgs1_0.method_4()[0]));
					}
					catch
					{
						geventArgs1_0.method_1(0.0);
					}
				}
				else
				{
					geventArgs1_0.method_1(2147439148);
				}
				break;
			default:
				throw new FunctionNotSupportedException(string_3);
			}
		}

		private int method_12(object object_0, int int_1)
		{
			DateTime dateTime = method_13(object_0);
			if (dateTime != DateTime.MinValue)
			{
				TimeSpan timeSpan = DateTime.Now - dateTime;
				switch (int_1)
				{
				default:
					return (int)(timeSpan.TotalDays / 365.0);
				case 0:
					return (int)(timeSpan.TotalDays / 365.0);
				case 1:
					return (int)(timeSpan.TotalDays / 30.0);
				case 2:
					return (int)(timeSpan.TotalDays / 7.0);
				case 3:
					return (int)timeSpan.TotalDays;
				case 4:
					return (int)timeSpan.TotalHours;
				case 5:
					return (int)timeSpan.TotalMinutes;
				case 6:
					return (int)timeSpan.TotalSeconds;
				}
			}
			return 0;
		}

		private DateTime method_13(object object_0)
		{
			try
			{
				object_0 = smethod_35(object_0, bool_0: true);
				if (object_0 == null || DBNull.Value.Equals(object_0))
				{
					return DateTime.MinValue;
				}
				if (object_0 is string)
				{
					DateTime result = DateTime.MinValue;
					if (!DateTime.TryParse((string)object_0, out result))
					{
						result = DateTime.MinValue;
					}
					return result;
				}
				if (object_0 is DateTime)
				{
					return (DateTime)object_0;
				}
				return Convert.ToDateTime(object_0);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return DateTime.MinValue;
			}
		}

		private static object[] smethod_4(object[] object_0)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in object_0)
			{
				if (obj != null)
				{
					if (obj.GetType().IsArray)
					{
						Array c = (Array)obj;
						arrayList.AddRange(c);
					}
					else
					{
						arrayList.Add(obj);
					}
				}
			}
			return arrayList.ToArray();
		}

		public static int smethod_5(object object_0, object object_1)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return Convert.ToInt32(object_1);
			}
			if (object_0 is string)
			{
				string text = (string)object_0;
				int result = 0;
				if (string.IsNullOrEmpty(text))
				{
					return Convert.ToInt32(object_1);
				}
				if (int.TryParse(text, out result))
				{
					return result;
				}
				return Convert.ToInt32(object_1);
			}
			return 0;
		}

		public static double smethod_6(object object_0, object object_1)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return Convert.ToDouble(object_1);
			}
			if (object_0 is string)
			{
				string text = (string)object_0;
				double result = 0.0;
				if (string.IsNullOrEmpty(text))
				{
					return Convert.ToDouble(object_1);
				}
				if (double.TryParse(text, out result))
				{
					return result;
				}
				return Convert.ToDouble(object_1);
			}
			return 0.0;
		}

		public static double smethod_7(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			return Math.Abs(num);
		}

		public static double smethod_8(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Acos(d);
		}

		public static double smethod_9(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Asin(d);
		}

		public static double smethod_10(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Atan(d);
		}

		public static double smethod_11(object object_0, object object_1)
		{
			double num = smethod_36(object_0);
			double num2 = smethod_36(object_1);
			if (double.IsNaN(num) || double.IsNaN(num2))
			{
				return double.NaN;
			}
			return Math.Atan2(num, num2);
		}

		public static double smethod_12(object[] object_0)
		{
			int num = 0;
			double num2 = 0.0;
			for (int i = 0; i < object_0.Length; i++)
			{
				double num3 = smethod_36(object_0[i]);
				if (!double.IsNaN(num3))
				{
					num++;
					num2 += num3;
				}
			}
			if (num > 0)
			{
				return num2 / (double)num;
			}
			return double.NaN;
		}

		public static double smethod_13(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			return Math.Ceiling(num);
		}

		public static double smethod_14(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Cos(d);
		}

		public static double smethod_15(object[] object_0)
		{
			double num = 0.0;
			object[] array = smethod_4(object_0);
			for (int i = 0; i < array.Length; i++)
			{
				double d = smethod_36(array[i]);
				if (!double.IsNaN(d))
				{
					num += 1.0;
				}
			}
			return num;
		}

		public double method_14(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Exp(d);
		}

		public static double smethod_16(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Floor(d);
		}

		public static double smethod_17(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			return (int)num;
		}

		public static double smethod_18(object object_0, object object_1)
		{
			double num = smethod_36(object_0);
			double num2 = smethod_36(object_1);
			if (double.IsNaN(num) || double.IsNaN(num2))
			{
				return double.NaN;
			}
			return Math.Log(num, num2);
		}

		public static double smethod_19(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Log10(d);
		}

		public static double smethod_20(object[] object_0)
		{
			double num = double.NaN;
			object[] array = smethod_4(object_0);
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = smethod_36(array[i]);
				if (double.IsNaN(num))
				{
					num = num2;
				}
				else if (!double.IsNaN(num2) && num < num2)
				{
					num = num2;
				}
			}
			return num;
		}

		public static double smethod_21(object[] object_0)
		{
			double num = double.NaN;
			object[] array = smethod_4(object_0);
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = smethod_36(array[i]);
				if (double.IsNaN(num))
				{
					num = num2;
				}
				else if (!double.IsNaN(num2) && num > num2)
				{
					num = num2;
				}
			}
			return num;
		}

		public static double smethod_22(object object_0, object object_1)
		{
			double num = smethod_36(object_0);
			double num2 = smethod_36(object_1);
			if (double.IsNaN(num) || double.IsNaN(num2))
			{
				return double.NaN;
			}
			return Math.IEEERemainder(num, num2);
		}

		public static double smethod_23(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			double num2 = Math.Ceiling(Math.Abs(num));
			if (num2 % 2.0 == 0.0)
			{
				num2 += 1.0;
			}
			if (num < 0.0)
			{
				return 0.0 - num2;
			}
			return num2;
		}

		public static double smethod_24(object object_0, object object_1)
		{
			double num = smethod_36(object_0);
			double num2 = smethod_36(object_1);
			if (double.IsNaN(num) || double.IsNaN(num2))
			{
				return double.NaN;
			}
			return Math.Pow(num, num2);
		}

		public static double smethod_25(object[] object_0)
		{
			double num = double.NaN;
			object[] array = smethod_4(object_0);
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = smethod_36(array[i]);
				if (!double.IsNaN(num2))
				{
					num = ((!double.IsNaN(num)) ? (num * num2) : num2);
				}
			}
			return num;
		}

		public static double smethod_26(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			return Math.PI / 180.0 * num;
		}

		public double method_15()
		{
			return random_0.NextDouble();
		}

		public static double smethod_27(object object_0, object object_1)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			double num2 = smethod_36(object_1);
			if (double.IsNaN(num2))
			{
				return Math.Round(num);
			}
			if (num2 >= 0.0)
			{
				return Math.Round(num, (int)smethod_28(num2));
			}
			decimal d = Convert.ToDecimal(Math.Pow(10.0, 0.0 - smethod_29(num2)));
			return (double)(decimal.Round((decimal)num / d, MidpointRounding.AwayFromZero) * d);
		}

		public static double smethod_28(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			double num2 = Math.Round(num);
			if (num2 > num)
			{
				return num2 - 1.0;
			}
			return num2;
		}

		public static double smethod_29(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			double num2 = Math.Round(num);
			if (num2 < num)
			{
				return num2 + 1.0;
			}
			return num2;
		}

		public static double smethod_30(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			if (num > 0.0)
			{
				return 1.0;
			}
			if (num == 0.0)
			{
				return 0.0;
			}
			return -1.0;
		}

		public static double smethod_31(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			return Math.Sin(num);
		}

		public static double smethod_32(object object_0)
		{
			double d = smethod_36(object_0);
			if (double.IsNaN(d))
			{
				return double.NaN;
			}
			return Math.Sqrt(d);
		}

		public static double smethod_33(object[] object_0)
		{
			double num = double.NaN;
			object[] array = smethod_4(object_0);
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = smethod_36(array[i]);
				if (!double.IsNaN(num2))
				{
					num = ((!double.IsNaN(num)) ? (num + num2) : num2);
				}
			}
			return num;
		}

		public static double smethod_34(object object_0)
		{
			double num = smethod_36(object_0);
			if (double.IsNaN(num))
			{
				return double.NaN;
			}
			return Math.Tan(num);
		}

		protected static object smethod_35(object object_0, bool bool_0)
		{
			int num = 18;
			if (object_0 != null && object_0.GetType().IsArray)
			{
				if (bool_0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (object item in (IEnumerable)object_0)
					{
						if (item != null && !DBNull.Value.Equals(item))
						{
							string value = Convert.ToString(item);
							if (!string.IsNullOrEmpty(value))
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append(",");
								}
								stringBuilder.Append(value);
							}
						}
					}
					return stringBuilder.ToString();
				}
				double num2 = 0.0;
				foreach (object item2 in (IEnumerable)object_0)
				{
					if (item2 != null && !DBNull.Value.Equals(item2))
					{
						double num3 = smethod_36(item2);
						if (!double.IsNaN(num3))
						{
							num2 += num3;
						}
					}
				}
				return num2;
			}
			return object_0;
		}

		public static double smethod_36(object object_0)
		{
			int num = 5;
			object_0 = smethod_35(object_0, bool_0: false);
			if (object_0 == null)
			{
				return double.NaN;
			}
			if (object_0 is double)
			{
				return (double)object_0;
			}
			string text = Convert.ToString(object_0);
			if (text == null)
			{
				return double.NaN;
			}
			text = text.Trim();
			if (text.Length == 0 || text.Length > 30)
			{
				return double.NaN;
			}
			if (string.Compare(text, "NaN", ignoreCase: true) == 0)
			{
				return double.NaN;
			}
			double result = double.NaN;
			if (double.TryParse(text, out result))
			{
				return result;
			}
			return double.NaN;
		}
	}
}
