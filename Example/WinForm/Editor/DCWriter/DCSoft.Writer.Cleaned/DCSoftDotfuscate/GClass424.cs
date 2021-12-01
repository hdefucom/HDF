using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(GClass421))]
	public class GClass424
	{
		private StringDictionary stringDictionary_0 = new StringDictionary();

		private DateTime dateTime_0 = DateTime.MinValue;

		private DateTime dateTime_1 = DateTime.MinValue;

		private DateTime dateTime_2 = DateTime.MinValue;

		private DateTime dateTime_3 = DateTime.MinValue;

		public string method_0(string string_0)
		{
			return stringDictionary_0[string_0];
		}

		public void method_1(string string_0, string string_1)
		{
			stringDictionary_0[string_0] = string_1;
		}

		public string method_2()
		{
			return stringDictionary_0["title"];
		}

		public void method_3(string string_0)
		{
			stringDictionary_0["title"] = string_0;
		}

		public string method_4()
		{
			return stringDictionary_0["subject"];
		}

		public void method_5(string string_0)
		{
			stringDictionary_0["subject"] = string_0;
		}

		public string method_6()
		{
			return stringDictionary_0["author"];
		}

		public void method_7(string string_0)
		{
			stringDictionary_0["author"] = string_0;
		}

		public string method_8()
		{
			return stringDictionary_0["manager"];
		}

		public void method_9(string string_0)
		{
			stringDictionary_0["manager"] = string_0;
		}

		public string method_10()
		{
			return stringDictionary_0["company"];
		}

		public void method_11(string string_0)
		{
			stringDictionary_0["company"] = string_0;
		}

		public string method_12()
		{
			return stringDictionary_0["operator"];
		}

		public void method_13(string string_0)
		{
			stringDictionary_0["operator"] = string_0;
		}

		public string method_14()
		{
			return stringDictionary_0["category"];
		}

		public void method_15(string string_0)
		{
			stringDictionary_0["categroy"] = string_0;
		}

		public string method_16()
		{
			return stringDictionary_0["keywords"];
		}

		public void method_17(string string_0)
		{
			stringDictionary_0["keywords"] = string_0;
		}

		public string method_18()
		{
			return stringDictionary_0["comment"];
		}

		public void method_19(string string_0)
		{
			stringDictionary_0["comment"] = string_0;
		}

		public string method_20()
		{
			return stringDictionary_0["doccomm"];
		}

		public void method_21(string string_0)
		{
			stringDictionary_0["doccomm"] = string_0;
		}

		public string method_22()
		{
			return stringDictionary_0["hlinkbase"];
		}

		public void method_23(string string_0)
		{
			stringDictionary_0["hlinkbase"] = string_0;
		}

		public int method_24()
		{
			int num = 4;
			if (stringDictionary_0.ContainsKey("edmins"))
			{
				string s = Convert.ToString(stringDictionary_0["edmins"]);
				int result = 0;
				if (int.TryParse(s, out result))
				{
					return result;
				}
			}
			return 0;
		}

		public void method_25(int int_0)
		{
			stringDictionary_0["edmins"] = int_0.ToString();
		}

		public string method_26()
		{
			return stringDictionary_0["vern"];
		}

		public void method_27(string string_0)
		{
			stringDictionary_0["vern"] = string_0;
		}

		public string method_28()
		{
			return stringDictionary_0["nofpages"];
		}

		public void method_29(string string_0)
		{
			stringDictionary_0["nofpages"] = string_0;
		}

		public string method_30()
		{
			return stringDictionary_0["nofwords"];
		}

		public void method_31(string string_0)
		{
			stringDictionary_0["nofwords"] = string_0;
		}

		public string method_32()
		{
			return stringDictionary_0["nofchars"];
		}

		public void method_33(string string_0)
		{
			stringDictionary_0["nofchars"] = string_0;
		}

		public string method_34()
		{
			return stringDictionary_0["nofcharsws"];
		}

		public void method_35(string string_0)
		{
			stringDictionary_0["nofcharsws"] = string_0;
		}

		public string method_36()
		{
			return stringDictionary_0["id"];
		}

		public void method_37(string string_0)
		{
			stringDictionary_0["id"] = string_0;
		}

		public DateTime method_38()
		{
			return dateTime_0;
		}

		public void method_39(DateTime dateTime_4)
		{
			dateTime_0 = dateTime_4;
		}

		public DateTime method_40()
		{
			return dateTime_1;
		}

		public void method_41(DateTime dateTime_4)
		{
			dateTime_1 = dateTime_4;
		}

		public DateTime method_42()
		{
			return dateTime_2;
		}

		public void method_43(DateTime dateTime_4)
		{
			dateTime_2 = dateTime_4;
		}

		public DateTime method_44()
		{
			return dateTime_3;
		}

		public void method_45(DateTime dateTime_4)
		{
			dateTime_3 = dateTime_4;
		}

		internal string[] method_46()
		{
			int num = 8;
			ArrayList arrayList = new ArrayList();
			foreach (string key in stringDictionary_0.Keys)
			{
				arrayList.Add(key + "=" + stringDictionary_0[key]);
			}
			if (method_38() != DateTime.MinValue)
			{
				arrayList.Add("Creatim=" + method_38().ToString("yyyy-MM-dd HH:mm:ss"));
			}
			if (method_40() != DateTime.MinValue)
			{
				arrayList.Add("Revtim=" + method_40().ToString("yyyy-MM-dd HH:mm:ss"));
			}
			if (method_42() != DateTime.MinValue)
			{
				arrayList.Add("Printim=" + method_42().ToString("yyyy-MM-dd HH:mm:ss"));
			}
			if (method_44() != DateTime.MinValue)
			{
				arrayList.Add("Buptim=" + method_44().ToString("yyyy-MM-dd HH:mm:ss"));
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		public void method_47()
		{
			stringDictionary_0.Clear();
			dateTime_0 = DateTime.MinValue;
			dateTime_1 = DateTime.MinValue;
			dateTime_2 = DateTime.MinValue;
			dateTime_3 = DateTime.MinValue;
		}

		public void method_48(GClass414 gclass414_0)
		{
			int num = 18;
			gclass414_0.method_10();
			gclass414_0.method_13("info");
			foreach (string key in stringDictionary_0.Keys)
			{
				gclass414_0.method_10();
				int num2;
				switch (key)
				{
				default:
					num2 = ((!(key == "id")) ? 1 : 0);
					break;
				case "edmins":
				case "vern":
				case "nofpages":
				case "nofwords":
				case "nofchars":
				case "nofcharsws":
					num2 = 0;
					break;
				}
				if (num2 == 0)
				{
					gclass414_0.method_13(key + stringDictionary_0[key]);
				}
				else
				{
					gclass414_0.method_13(key);
					gclass414_0.method_15(stringDictionary_0[key]);
				}
				gclass414_0.method_11();
			}
			gclass414_0.method_10();
			method_49(gclass414_0, "creatim", dateTime_0);
			method_49(gclass414_0, "revtim", dateTime_1);
			method_49(gclass414_0, "printim", dateTime_2);
			method_49(gclass414_0, "buptim", dateTime_3);
			gclass414_0.method_11();
		}

		private void method_49(GClass414 gclass414_0, string string_0, DateTime dateTime_4)
		{
			gclass414_0.method_10();
			gclass414_0.method_13(string_0);
			gclass414_0.method_13("yr" + dateTime_4.Year);
			gclass414_0.method_13("mo" + dateTime_4.Month);
			gclass414_0.method_13("dy" + dateTime_4.Day);
			gclass414_0.method_13("hr" + dateTime_4.Hour);
			gclass414_0.method_13("min" + dateTime_4.Minute);
			gclass414_0.method_13("sec" + dateTime_4.Second);
			gclass414_0.method_11();
		}
	}
}
