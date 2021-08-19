using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class77 : IDictionary
	{
		private GClass39 gclass39_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private XTextElement xtextElement_0 = null;

		private StringBuilder stringBuilder_0 = null;

		public int Count
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsReadOnly => true;

		public object SyncRoot
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsSynchronized
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public object this[object object_0]
		{
			get
			{
				int num = 3;
				string text = Convert.ToString(object_0);
				if (method_0() != null)
				{
					if (string.Compare(text, "Value", ignoreCase: true) == 0 && method_2() != null)
					{
						string text2 = method_2().Text;
						method_7("Value", text2);
						return text2;
					}
					if (text.StartsWith("this.", StringComparison.CurrentCultureIgnoreCase))
					{
						string string_ = text.Substring(5).Trim();
						if (method_2() != null)
						{
							PropertyInfo propertyInfo = smethod_0(method_2().GetType(), string_);
							if (propertyInfo != null)
							{
								ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
								if (indexParameters == null || indexParameters.Length == 0)
								{
									object value = propertyInfo.GetValue(method_2(), null);
									method_7("this." + propertyInfo.Name, value);
									return value;
								}
							}
						}
					}
					foreach (DocumentParameter parameter in method_0().Parameters)
					{
						if (string.Compare(parameter.Name, text, ignoreCase: true) == 0)
						{
							method_7(parameter.Name, parameter.Value);
							return parameter.Value;
						}
					}
					if (gclass39_0 != null)
					{
						bool bool_ = false;
						object obj = gclass39_0.method_18(text, ref bool_);
						if (bool_)
						{
							method_7(text, obj);
							return obj;
						}
					}
					object obj2 = null;
					XTextElement elementByIdExt = method_0().GetElementByIdExt(text, idAttributeOnly: true);
					if (elementByIdExt != null)
					{
						if (elementByIdExt is XTextCheckBoxElementBase)
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)elementByIdExt;
							if (xTextCheckBoxElementBase.Checked)
							{
								obj2 = xTextCheckBoxElementBase.CheckedValue;
							}
						}
						else
						{
							obj2 = elementByIdExt.Text;
						}
						method_7(text, obj2);
						return obj2;
					}
					if (obj2 == null && elementByIdExt != null)
					{
						foreach (DocumentParameter innerParameter in method_0().InnerParameters)
						{
							if (innerParameter.Name == text)
							{
								method_7(text, innerParameter.Value);
								return innerParameter.Value;
							}
						}
					}
					method_7(text, obj2);
					return obj2;
				}
				method_7(text, null);
				return null;
			}
			set
			{
			}
		}

		public ICollection Keys => method_4(bool_0: true);

		public ICollection Values => method_4(bool_0: false);

		public bool IsFixedSize => true;

		public Class77(XTextDocument xtextDocument_1, XTextElement xtextElement_1, GClass39 gclass39_1 = null)
		{
			method_1(xtextDocument_1);
			method_3(xtextElement_1);
			gclass39_0 = gclass39_1;
			if (gclass39_0 == null)
			{
				gclass39_0 = new GClass39();
				gclass39_0.method_3(xtextElement_1);
				gclass39_0.method_5(xtextElement_1);
			}
		}

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextElement method_2()
		{
			return xtextElement_0;
		}

		public void method_3(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}

		public void Add(object object_0, object value)
		{
		}

		public void Clear()
		{
		}

		private static PropertyInfo smethod_0(Type type_0, string string_0)
		{
			return type_0.GetProperty(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
		}

		public bool Contains(object object_0)
		{
			int num = 6;
			if (method_0() == null)
			{
				return false;
			}
			string text = Convert.ToString(object_0);
			if (string.Compare(text, "Value", ignoreCase: true) == 0)
			{
				return true;
			}
			if (text.StartsWith("this.", StringComparison.CurrentCultureIgnoreCase))
			{
				string string_ = text.Substring(5).Trim();
				if (method_2() != null && smethod_0(method_2().GetType(), string_) != null)
				{
					return true;
				}
			}
			if (method_0().Parameters.Contains(text))
			{
				return true;
			}
			if (method_0().InnerParameters.Contains(text))
			{
				return true;
			}
			if (GClass344.smethod_0(text))
			{
				return true;
			}
			return true;
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			return null;
		}

		public void Remove(object object_0)
		{
		}

		private ICollection method_4(bool bool_0)
		{
			int num = 2;
			ArrayList arrayList = new ArrayList();
			if (method_0() != null)
			{
				arrayList.Add("Value");
				foreach (DocumentParameter innerParameter in method_0().InnerParameters)
				{
					if (bool_0)
					{
						arrayList.Add(innerParameter.Name);
					}
					else
					{
						arrayList.Add(innerParameter.Value);
					}
				}
				foreach (DocumentParameter parameter in method_0().Parameters)
				{
					if (bool_0)
					{
						if (!arrayList.Contains(parameter.Name))
						{
							arrayList.Add(parameter.Name);
						}
					}
					else
					{
						arrayList.Add(parameter.Value);
					}
				}
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(method_0());
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item is XTextInputFieldElementBase)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item;
						if (!arrayList.Contains(xTextInputFieldElementBase.Name))
						{
							if (bool_0)
							{
								arrayList.Add(xTextInputFieldElementBase.Name);
							}
							else
							{
								arrayList.Add(xTextInputFieldElementBase.Text);
							}
						}
					}
				}
			}
			return arrayList;
		}

		private bool method_5()
		{
			if (method_0() != null && method_0().AppHost.DebugMode)
			{
				return true;
			}
			return false;
		}

		public string method_6()
		{
			if (stringBuilder_0 == null)
			{
				return null;
			}
			return stringBuilder_0.ToString();
		}

		public void method_7(string string_0, object object_0)
		{
			int num = 11;
			if (!method_5())
			{
				return;
			}
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = new StringBuilder();
			}
			stringBuilder_0.Append(">>" + string_0 + "=");
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				stringBuilder_0.Append("[NULL]");
			}
			else if (object_0 is Array)
			{
				IList list = (IList)object_0;
				for (int i = 0; i < list.Count; i++)
				{
					object obj = list[i];
					if (i > 0)
					{
						stringBuilder_0.Append(',');
					}
					if (obj == null || DBNull.Value.Equals(obj))
					{
						stringBuilder_0.Append("[NULL]");
					}
					else
					{
						stringBuilder_0.Append(Convert.ToString(obj));
					}
				}
			}
			else
			{
				stringBuilder_0.Append(Convert.ToString(object_0));
			}
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
