using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DefaultMember("Item")]
	[ComVisible(false)]
	
	public class GClass340 : List<GClass341>, ICloneable
	{
		public GClass340()
		{
		}

		public GClass340(string string_0)
		{
			method_5(string_0);
		}

		public GClass341 method_0(string string_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass341 current = enumerator.Current;
					if (string.Compare(current.Name, string_0, ignoreCase: true) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}

		public string method_1(string string_0)
		{
			return method_0(string_0)?.method_0();
		}

		public void method_2(string string_0, string string_1)
		{
			GClass341 gClass = method_0(string_0);
			if (gClass == null)
			{
				gClass = new GClass341();
				gClass.Name = string_0;
				gClass.method_1(string_1);
				Add(gClass);
			}
			else
			{
				gClass.method_1(string_1);
			}
		}

		public bool method_3(string string_0)
		{
			return method_0(string_0) != null;
		}

		public void method_4(string string_0)
		{
			GClass341 gClass = method_0(string_0);
			if (gClass != null)
			{
				Remove(gClass);
			}
		}

		public void method_5(string string_0)
		{
			int num = 16;
			Clear();
			if (string_0 == null || string_0.Length == 0)
			{
				return;
			}
			while (string_0.Length > 0)
			{
				string text = null;
				string string_ = null;
				int num2 = string_0.IndexOf(":");
				if (num2 > 0)
				{
					text = string_0.Substring(0, num2);
					string_0 = string_0.Substring(num2 + 1);
					if (string_0.StartsWith("'"))
					{
						int num3 = string_0.IndexOf("'", 1);
						if (num3 < 0)
						{
							num3 = string_0.IndexOf(";");
						}
						if (num3 >= 0)
						{
							string_ = string_0.Substring(1, num3 - 1);
							string_0 = string_0.Substring(num3 + 1);
							if (string_0.StartsWith("'"))
							{
								string_0 = string_0.Substring(1);
							}
						}
						else
						{
							string_ = string_0.Substring(1);
							string_0 = "";
						}
					}
					else if (string_0.StartsWith("\""))
					{
						int num3 = string_0.IndexOf("\"", 1);
						if (num3 < 0)
						{
							num3 = string_0.IndexOf(";");
						}
						if (num3 >= 0)
						{
							string_ = string_0.Substring(1, num3 - 1);
							string_0 = string_0.Substring(num3 + 1);
							if (string_0.StartsWith("\""))
							{
								string_0 = string_0.Substring(1);
							}
						}
						else
						{
							string_ = string_0.Substring(1);
							string_0 = "";
						}
					}
					else
					{
						int num4 = string_0.IndexOf(";");
						if (num4 >= 0)
						{
							string_ = string_0.Substring(0, num4);
							string_0 = string_0.Substring(num4 + 1);
						}
						else
						{
							string_ = string_0;
							string_0 = "";
						}
					}
				}
				else
				{
					text = string_0.Trim();
					string_0 = "";
				}
				GClass341 gClass = new GClass341();
				gClass.Name = text;
				gClass.method_1(string_);
				Add(gClass);
			}
		}

		public override string ToString()
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass341 current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(current.Name);
					stringBuilder.Append(":");
					string text = current.method_0();
					if (text != null && text.Length > 0)
					{
						if (text.IndexOf(":") >= 0 || text.IndexOf(";") >= 0)
						{
							text = "'" + text + "'";
						}
						stringBuilder.Append(text);
					}
				}
			}
			return stringBuilder.ToString();
		}

		public int method_6(object object_0, bool bool_0)
		{
			int num = 0;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass341 current = enumerator.Current;
					if (ValueTypeHelper.SetPropertyValue(object_0, current.Name, current.method_0(), throwException: false))
					{
						num++;
					}
				}
			}
			return num;
		}

		object ICloneable.Clone()
		{
			GClass340 gClass = new GClass340();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass341 current = enumerator.Current;
					GClass341 gClass2 = new GClass341();
					gClass2.Name = current.Name;
					gClass2.method_1(current.method_0());
					gClass.Add(gClass2);
				}
			}
			return gClass;
		}

		public GClass340 method_7()
		{
			return (GClass340)((ICloneable)this).Clone();
		}

		public static int smethod_0(object object_0, string string_0)
		{
			int num = 7;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string_0 == null || string.IsNullOrEmpty(string_0))
			{
				return 0;
			}
			GClass340 gClass = new GClass340(string_0);
			return gClass.method_6(object_0, bool_0: false);
		}
	}
}
