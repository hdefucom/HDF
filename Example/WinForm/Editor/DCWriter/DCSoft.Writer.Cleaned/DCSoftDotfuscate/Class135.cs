using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;

namespace DCSoftDotfuscate
{
	internal class Class135
	{
		private XTextDocument xtextDocument_0;

		private int int_0;

		private Dictionary<string, XTextElementList> dictionary_0;

		private Dictionary<string, XTextElementList> dictionary_1;

		public Class135(XTextDocument xtextDocument_1)
		{
			int num = 3;
			xtextDocument_0 = null;
			int_0 = 1;
			dictionary_0 = null;
			dictionary_1 = null;
			
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public int method_1()
		{
			return int_0;
		}

		public void method_2()
		{
			int_0++;
			dictionary_0 = null;
			dictionary_1 = null;
		}

		internal XTextElementList method_3(string string_0, Type type_0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (string.IsNullOrEmpty(string_0))
			{
				return xTextElementList;
			}
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(xtextDocument_0);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (type_0.IsInstanceOfType(item))
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
					if (string_0 == xTextCheckBoxElementBase.RuntimeGroupName)
					{
						xTextElementList.Add(xTextCheckBoxElementBase);
					}
				}
			}
			return xTextElementList;
		}

		public XTextElementList method_4(string string_0)
		{
			method_6();
			if (dictionary_1.ContainsKey(string_0))
			{
				return dictionary_1[string_0];
			}
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			return null;
		}

		public XTextElementList method_5(XTextCheckBoxElementBase xtextCheckBoxElementBase_0)
		{
			int num = 0;
			if (xtextCheckBoxElementBase_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextCheckBoxElementBase_0.GroupInfoVersion != int_0)
			{
				method_2();
			}
			method_6();
			string text = xtextCheckBoxElementBase_0.RuntimeGroupName;
			if (text == null)
			{
				text = string.Empty;
			}
			Dictionary<string, XTextElementList> dictionary = null;
			if (xtextCheckBoxElementBase_0 is XTextCheckBoxElement)
			{
				dictionary = dictionary_0;
			}
			else if (xtextCheckBoxElementBase_0 is XTextRadioBoxElement)
			{
				dictionary = dictionary_1;
			}
			XTextElementList xTextElementList = null;
			if (dictionary.ContainsKey(text))
			{
				xTextElementList = dictionary[text];
			}
			if (xTextElementList != null)
			{
				xTextElementList = xTextElementList.Clone();
			}
			return xTextElementList;
		}

		private void method_6()
		{
			if (dictionary_0 == null)
			{
				float tickCountFloat = CountDown.GetTickCountFloat();
				int_0++;
				dictionary_0 = new Dictionary<string, XTextElementList>();
				dictionary_1 = new Dictionary<string, XTextElementList>();
				XTextElementList elementsByType = xtextDocument_0.GetElementsByType(typeof(XTextCheckBoxElementBase));
				foreach (XTextCheckBoxElementBase item in elementsByType)
				{
					item.GroupInfoVersion = int_0;
					string text = item.RuntimeGroupName;
					if (string.IsNullOrEmpty(text))
					{
						text = string.Empty;
					}
					Dictionary<string, XTextElementList> dictionary = null;
					if (item is XTextCheckBoxElement)
					{
						dictionary = dictionary_0;
					}
					else if (item is XTextRadioBoxElement)
					{
						dictionary = dictionary_1;
					}
					if (dictionary.ContainsKey(text))
					{
						dictionary[text].Add(item);
					}
					else
					{
						XTextElementList xTextElementList2 = dictionary[text] = new XTextElementList();
						xTextElementList2.Add(item);
					}
				}
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			}
		}
	}
}
