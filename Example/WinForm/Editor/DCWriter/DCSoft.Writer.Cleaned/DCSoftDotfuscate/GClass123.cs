using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public class GClass123
	{
		private class Class133 : Dictionary<Type, XTextElementList>
		{
			public int int_0 = 0;
		}

		private bool bool_0 = false;

		private Dictionary<XTextContainerElement, Class133> dictionary_0 = new Dictionary<XTextContainerElement, Class133>();

		internal bool method_0()
		{
			return bool_0;
		}

		internal void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		internal void method_2()
		{
			if (dictionary_0 != null)
			{
				foreach (XTextContainerElement key in dictionary_0.Keys)
				{
					Class133 @class = dictionary_0[key];
					@class.int_0 = key.ContentVersion;
				}
			}
		}

		internal void method_3()
		{
			if (!bool_0)
			{
				dictionary_0.Clear();
			}
		}

		internal void method_4()
		{
			if (dictionary_0 != null)
			{
				foreach (XTextContainerElement key in dictionary_0.Keys)
				{
					Class133 @class = dictionary_0[key];
					foreach (Type key2 in @class.Keys)
					{
						XTextElementList xTextElementList = @class[key2];
						xTextElementList.Clear();
					}
				}
				dictionary_0.Clear();
				dictionary_0 = null;
				bool_0 = false;
			}
		}

		public XTextElementList method_5(XTextContainerElement xtextContainerElement_0, Type type_0)
		{
			int num = 0;
			if (xtextContainerElement_0 == null)
			{
				throw new ArgumentNullException("rootElement");
			}
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (type_0 == typeof(XTextCharElement))
			{
				throw new ArgumentOutOfRangeException(type_0.FullName);
			}
			Class133 value = null;
			if (!dictionary_0.TryGetValue(xtextContainerElement_0, out value))
			{
				value = new Class133();
				value.int_0 = xtextContainerElement_0.ContentVersion;
				dictionary_0[xtextContainerElement_0] = value;
			}
			if (value.int_0 != xtextContainerElement_0.ContentVersion)
			{
				value.int_0 = xtextContainerElement_0.ContentVersion;
				value.Clear();
			}
			if (value.ContainsKey(type_0))
			{
				return value[type_0];
			}
			return value[type_0] = xtextContainerElement_0.GetElementsByType(type_0);
		}
	}
}
