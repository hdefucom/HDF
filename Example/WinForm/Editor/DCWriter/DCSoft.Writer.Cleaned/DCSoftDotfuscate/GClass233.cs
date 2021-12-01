using DCSoft.HtmlDom;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass233
	{
		public bool bool_0 = false;

		public bool bool_1 = false;

		public bool bool_2 = false;

		public bool bool_3 = false;

		public bool bool_4 = false;

		public bool bool_5 = false;

		public bool bool_6 = false;

		public bool bool_7 = true;

		public bool bool_8 = false;

		public string string_0 = "[";

		public string string_1 = "]";

		public bool bool_9 = false;

		public bool bool_10 = false;

		public bool bool_11 = false;

		public bool bool_12 = true;

		public bool bool_13 = false;

		public bool bool_14 = true;

		public bool bool_15 = true;

		protected HTMLDocument htmldocument_0 = null;

		protected string[] string_2 = null;

		public bool bool_16 = true;

		public HTMLDocument method_0()
		{
			return htmldocument_0;
		}

		public void method_1(HTMLDocument htmldocument_1)
		{
			htmldocument_0 = htmldocument_1;
		}

		public string[] method_2()
		{
			return string_2;
		}

		public void method_3(string[] string_3)
		{
			ArrayList arrayList = new ArrayList();
			if (string_3 != null)
			{
				foreach (string text in string_3)
				{
					if (text != null)
					{
						string text2 = text.Trim().ToLower();
						if (text2.Length > 0)
						{
							arrayList.Add(text2);
						}
					}
				}
			}
			if (arrayList.Count > 0)
			{
				string_2 = (string[])arrayList.ToArray(typeof(string));
			}
			else
			{
				string_2 = null;
			}
		}

		public virtual bool vmethod_0(GClass163 gclass163_0)
		{
			if (string_2 != null && gclass163_0 != null)
			{
				string tagName = gclass163_0.TagName;
				string[] array = string_2;
				foreach (string strA in array)
				{
					if (string.Compare(strA, tagName, ignoreCase: true) == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		public string method_4(string string_3)
		{
			if (string_3 != null && string_3.IndexOf('【') >= 0 && string_3.IndexOf('】') > 0)
			{
				string_3 = string_3.Replace('【', '[');
				string_3 = string_3.Replace('】', ']');
			}
			return string_3;
		}
	}
}
