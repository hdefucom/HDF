#define DEBUG
using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass39
	{
		private bool bool_0 = false;

		private XTextElement xtextElement_0 = null;

		private XTextElement xtextElement_1 = null;

		private string string_0 = null;

		private string string_1 = null;

		private bool bool_1 = true;

		private ArrayList arrayList_0 = new ArrayList();

		private string string_2 = null;

		private bool bool_2 = false;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public XTextElement method_2()
		{
			return xtextElement_0;
		}

		public void method_3(XTextElement xtextElement_2)
		{
			if (xtextElement_0 != xtextElement_2)
			{
				xtextElement_0 = xtextElement_2;
				bool_2 = false;
			}
		}

		public XTextElement method_4()
		{
			return xtextElement_1;
		}

		public void method_5(XTextElement xtextElement_2)
		{
			xtextElement_1 = xtextElement_2;
		}

		public string method_6()
		{
			return string_0;
		}

		public void method_7(string string_3)
		{
			if (string_0 != string_3)
			{
				string_0 = string_3;
				bool_2 = false;
			}
		}

		public string method_8()
		{
			return string_1;
		}

		public void method_9(string string_3)
		{
			if (string_1 != string_3)
			{
				string_1 = string_3;
				bool_2 = false;
			}
		}

		public bool method_10()
		{
			return bool_1;
		}

		public void method_11(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public override string ToString()
		{
			int num = 3;
			string text = null;
			if (method_2() != null)
			{
				text = method_2().ID;
			}
			return text + "." + method_6() + "=" + method_8();
		}

		public bool method_12(XTextElement xtextElement_2)
		{
			ArrayList arrayList = method_14();
			if (arrayList != null)
			{
				foreach (object item in arrayList)
				{
					if (item == xtextElement_2)
					{
						return true;
					}
					if (item is ArrayList)
					{
						ArrayList arrayList2 = (ArrayList)item;
						if (arrayList2.Contains(xtextElement_2))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public XTextElementList method_13()
		{
			method_17();
			XTextElementList xTextElementList = new XTextElementList();
			if (method_14() != null)
			{
				foreach (object item in method_14())
				{
					if (item is XTextElement)
					{
						xTextElementList.Add((XTextElement)item);
					}
					else if (item is ArrayList)
					{
						ArrayList arrayList = (ArrayList)item;
						foreach (object item2 in arrayList)
						{
							if (item2 is XTextElement)
							{
								xTextElementList.Add((XTextElement)item2);
							}
						}
					}
				}
			}
			return xTextElementList;
		}

		public ArrayList method_14()
		{
			method_17();
			return arrayList_0;
		}

		public void method_15()
		{
		}

		public string method_16()
		{
			return string_2;
		}

		public void method_17()
		{
			int num = 14;
			if (bool_2)
			{
				return;
			}
			string_2 = null;
			if (xtextElement_0 == null)
			{
				throw new InvalidOperationException("Element is null");
			}
			arrayList_0.Clear();
			if (string_1 == null || string_1.Trim().Length == 0)
			{
				return;
			}
			XTextTableElement xTextTableElement = (XTextTableElement)xtextElement_0.GetOwnerParent(typeof(XTextTableElement), includeThis: false);
			if (xTextTableElement == null)
			{
				xTextTableElement = (xtextElement_0.DocumentContentElement.GetFirstElementByType(typeof(XTextTableElement)) as XTextTableElement);
			}
			_ = xtextElement_0.OwnerDocument;
			string[] array = VariableString.AnalyseVariableString(string_1, "[", "]");
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 != 0)
				{
					string string_ = array[i];
					object value = method_19(string_);
					arrayList_0.Add(value);
				}
			}
			bool_2 = true;
		}

		internal object method_18(string string_3, ref bool bool_3)
		{
			int num = 5;
			object obj = method_19(string_3);
			if (obj == null)
			{
				bool_3 = false;
				return null;
			}
			if (obj is ArrayList)
			{
				ArrayList arrayList = (ArrayList)obj;
				if (arrayList.Count > 0)
				{
					if (arrayList[0] is XTextCheckBoxElementBase)
					{
						StringBuilder stringBuilder = new StringBuilder();
						foreach (object item in arrayList)
						{
							if (item is XTextCheckBoxElementBase)
							{
								XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
								if (xTextCheckBoxElementBase.Checked && !string.IsNullOrEmpty(xTextCheckBoxElementBase.CheckedValue))
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append(",");
									}
									stringBuilder.Append(xTextCheckBoxElementBase.CheckedValue);
								}
							}
						}
						bool_3 = true;
						return stringBuilder.ToString();
					}
					ArrayList arrayList2 = new ArrayList();
					foreach (XTextElement item2 in arrayList)
					{
						object value = smethod_0(item2);
						arrayList2.Add(value);
					}
					bool_3 = true;
					return arrayList2.ToArray();
				}
				return null;
			}
			bool_3 = true;
			return smethod_0((XTextElement)obj);
		}

		internal object method_19(string string_3)
		{
			int num = 9;
			string_2 = null;
			if (xtextElement_0 == null)
			{
				throw new InvalidOperationException("Element is null");
			}
			XTextTableElement xTextTableElement = (XTextTableElement)method_2().GetOwnerParent(typeof(XTextTableElement), includeThis: false);
			if (xTextTableElement == null)
			{
				xTextTableElement = (method_2().DocumentContentElement.GetFirstElementByType(typeof(XTextTableElement)) as XTextTableElement);
			}
			XTextDocument ownerDocument = method_2().OwnerDocument;
			object obj = null;
			bool flag = false;
			if (string.Compare(string_3, "value", ignoreCase: true) == 0)
			{
				obj = method_4();
			}
			else if (GClass344.smethod_0(string_3))
			{
				GClass344 gClass = new GClass344(string_3);
				XTextTableElement xTextTableElement2 = xTextTableElement;
				if (!string.IsNullOrEmpty(gClass.method_0()))
				{
					xTextTableElement2 = (ownerDocument.GetElementById(gClass.method_0()) as XTextTableElement);
				}
				if (xTextTableElement != null && GClass344.smethod_0(string_3))
				{
					GClass344 gClass2 = new GClass344(string_3);
					if (gClass2.method_16())
					{
						ArrayList arrayList = new ArrayList();
						foreach (XTextTableCellElement cell in xTextTableElement2.Cells)
						{
							if (!cell.IsOverrided && gClass2.method_17(cell.RowIndex + 1, cell.ColIndex + 1))
							{
								if (cell == method_2())
								{
									flag = true;
									break;
								}
								arrayList.Add(cell);
							}
						}
						obj = arrayList;
					}
					else
					{
						foreach (XTextTableCellElement cell2 in xTextTableElement2.Cells)
						{
							if (!cell2.IsOverrided && gClass2.method_17(cell2.RowIndex + 1, cell2.ColIndex + 1))
							{
								if (cell2 == method_2())
								{
									flag = true;
								}
								else
								{
									obj = cell2;
								}
								break;
							}
						}
					}
				}
			}
			if (obj == null && !flag)
			{
				XTextElement elementByIdExt = ownerDocument.GetElementByIdExt(string_3, idAttributeOnly: true);
				obj = elementByIdExt;
				if (elementByIdExt == null)
				{
					XTextElementList elementsByName = ownerDocument.GetElementsByName(string_3);
					if (elementsByName != null && elementsByName.Count > 0)
					{
						if (elementsByName.Count == 1)
						{
							obj = elementsByName[0];
						}
						else if (elementsByName.Count > 1)
						{
							Type type = elementsByName[0].GetType();
							bool flag2 = false;
							if (!typeof(XTextCheckBoxElementBase).IsInstanceOfType(elementsByName[0]))
							{
								flag2 = true;
							}
							else
							{
								foreach (XTextElement item in elementsByName)
								{
									if (item.GetType() != type)
									{
										flag2 = true;
										break;
									}
								}
							}
							if (flag2)
							{
								string_2 = string.Format(WriterStrings.ParseExpressionTypeInvalidate_ID_Expression_Item, xtextElement_0.ID, string_1, string_3);
								if (xtextElement_0 is XTextInputFieldElement)
								{
									XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xtextElement_0;
									xTextInputFieldElement.vmethod_24(ownerDocument.ReadyState != DomReadyStates.Complete);
								}
								ownerDocument.AppHost.Debuger.WriteLine(string_2);
							}
						}
						obj = new ArrayList(elementsByName);
					}
				}
				if (elementByIdExt != null && (elementByIdExt.IsParentOrSupParent(xtextElement_0) || xtextElement_0.IsParentOrSupParent(elementByIdExt)))
				{
					flag = true;
				}
			}
			if (obj == xtextElement_0 || flag)
			{
				string text = xtextElement_0.ID;
				if (string.IsNullOrEmpty(text) && xtextElement_0 is XTextTableCellElement)
				{
					text = ((XTextTableCellElement)xtextElement_0).CellID;
				}
				string message = string.Format(WriterStrings.ExpressionRefSelf_ElementID_Expression, text, string_1);
				Debug.WriteLine(message);
			}
			if (obj == null)
			{
				string message = string.Format(WriterStrings.ExpressionMissElement_Element_Expression_ID, smethod_3(xtextElement_0), method_8(), string_3);
				ownerDocument.AppHost.Debuger.WriteLine(message);
			}
			return obj;
		}

		public string method_20()
		{
			int num = 14;
			method_17();
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = VariableString.AnalyseVariableString(string_1, "[", "]");
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				object obj = arrayList_0[(i - 1) / 2];
				if (obj == null)
				{
					stringBuilder.Append(" 0 ");
				}
				else if (obj is XTextElement)
				{
					if (obj is XTextTableCellElement)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)obj;
						stringBuilder.Append(GClass344.smethod_1(xTextTableCellElement.RowIndex + 1, xTextTableCellElement.ColIndex + 1));
					}
					else
					{
						stringBuilder.Append(" 0 ");
					}
				}
				else if (obj is ArrayList)
				{
					ArrayList arrayList_ = (ArrayList)obj;
					stringBuilder.Append(method_21(arrayList_));
				}
			}
			return stringBuilder.ToString();
		}

		private string method_21(ArrayList arrayList_1)
		{
			int num = 5;
			ArrayList arrayList = new ArrayList();
			foreach (object item in arrayList_1)
			{
				if (item is XTextTableCellElement)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)item;
					arrayList.Add(new GClass344(xTextTableCellElement.RowIndex + 1, xTextTableCellElement.ColIndex + 1));
				}
				else
				{
					arrayList.Add("0");
				}
			}
			arrayList.Sort();
			arrayList.Reverse();
			for (int num2 = arrayList.Count - 1; num2 >= 0; num2--)
			{
				GClass344 gClass = arrayList[num2] as GClass344;
				if (gClass != null)
				{
					for (int num3 = num2 - 1; num3 >= 0; num3--)
					{
						GClass344 gClass2 = arrayList[num3] as GClass344;
						if (gClass2 != null && gClass2 != gClass && gClass2.method_2() == gClass.method_2() && gClass2.method_6() == gClass.method_6() + gClass.method_10() + 1)
						{
							GClass344 gClass3 = gClass;
							gClass3.method_11(gClass3.method_10() + 1);
							arrayList.RemoveAt(num3);
							num2--;
						}
					}
				}
			}
			for (int num2 = arrayList.Count - 1; num2 >= 0; num2--)
			{
				GClass344 gClass = arrayList[num2] as GClass344;
				if (gClass != null)
				{
					for (int num3 = arrayList.Count - 1; num3 >= 0; num3--)
					{
						GClass344 gClass2 = arrayList[num3] as GClass344;
						if (gClass2 != null && gClass2 != gClass && gClass2.method_2() >= gClass.method_2() && gClass2.method_2() <= gClass.method_2() + gClass.method_12() + 1 && gClass2.method_6() == gClass.method_6() && gClass2.method_10() == gClass.method_10())
						{
							gClass.method_13(gClass2.method_2() + gClass2.method_12() - gClass.method_2());
							arrayList.RemoveAt(num3);
							num2--;
						}
					}
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int num2 = 0; num2 < arrayList.Count && num2 < 30; num2++)
			{
				object current = arrayList[num2];
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				if (current is GClass344)
				{
					GClass344 gClass = (GClass344)current;
					stringBuilder.Append(gClass.ToString());
				}
				else
				{
					stringBuilder.Append("0");
				}
			}
			return stringBuilder.ToString();
		}

		public string method_22()
		{
			object obj = method_23(null, 0);
			if (obj is float && float.IsNaN((float)obj))
			{
				return "";
			}
			if (obj is double && double.IsNaN((double)obj))
			{
				return "";
			}
			return Convert.ToString(obj);
		}

		private static string smethod_0(XTextElement xtextElement_2)
		{
			int num = 9;
			string text = null;
			if (xtextElement_2 is XTextContainerElement)
			{
				StringBuilder stringBuilder = new StringBuilder();
				double num2 = double.NaN;
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xtextElement_2;
				bool flag = false;
				foreach (XTextElement element in xTextContainerElement.Elements)
				{
					if (element is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
						text = xTextInputFieldElement.InnerValue;
						if (string.IsNullOrEmpty(text))
						{
							text = xTextInputFieldElement.Text;
						}
						return text;
					}
					if (element is XTextCheckBoxElement)
					{
						flag = true;
						XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)element;
						if (xTextCheckBoxElement.Checked)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							if (string.IsNullOrEmpty(xTextCheckBoxElement.CheckedValue))
							{
								stringBuilder.Append(xTextCheckBoxElement.Caption);
							}
							else
							{
								stringBuilder.Append(xTextCheckBoxElement.CheckedValue);
							}
							double result = double.NaN;
							if (double.TryParse(xTextCheckBoxElement.CheckedValue, out result))
							{
								num2 = ((!double.IsNaN(num2)) ? (num2 + result) : result);
							}
						}
					}
					else if (element is XTextRadioBoxElement)
					{
						flag = true;
						XTextRadioBoxElement xTextRadioBoxElement = (XTextRadioBoxElement)element;
						if (xTextRadioBoxElement.Checked)
						{
							return xTextRadioBoxElement.CheckedValue;
						}
					}
				}
				if (!double.IsNaN(num2))
				{
					return num2.ToString();
				}
				if (stringBuilder.Length > 0)
				{
					return stringBuilder.ToString();
				}
				if (flag)
				{
					return null;
				}
			}
			else if (xtextElement_2 is XTextCheckBoxElementBase)
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xtextElement_2;
				if (xTextCheckBoxElementBase.Checked)
				{
					if (!string.IsNullOrEmpty(xTextCheckBoxElementBase.CheckedValue))
					{
						return xTextCheckBoxElementBase.CheckedValue;
					}
					return xTextCheckBoxElementBase.Caption;
				}
				return null;
			}
			if (string.IsNullOrEmpty(text))
			{
				if (xtextElement_2 is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xtextElement_2;
					if (xTextInputFieldElement.Elements.Count == 0)
					{
						text = null;
					}
					else
					{
						text = xTextInputFieldElement.InnerValue;
						if (string.IsNullOrEmpty(text))
						{
							text = xTextInputFieldElement.Text;
						}
					}
				}
				else
				{
					text = xtextElement_2.Text;
				}
			}
			return text;
		}

		internal static bool smethod_1(string string_3)
		{
			int num = 5;
			if (!string_3.EndsWith("("))
			{
				return false;
			}
			if (string_3.Trim() == "(")
			{
				return false;
			}
			if (string_3.EndsWith("LEN(") || string_3.EndsWith("PARAMETER(") || string_3.EndsWith("FIND(") || string_3.EndsWith("LOOKUP(") || string_3.EndsWith("AGE(") || string_3.EndsWith("AGEMONTH(") || string_3.EndsWith("AGEWEEK(") || string_3.EndsWith("AGEDAY(") || string_3.EndsWith("AGEHOUR(") || string_3.EndsWith("CINT(") || string_3.EndsWith("CDOUBLE("))
			{
				return true;
			}
			if (string_3.EndsWith("ABS(") || string_3.EndsWith("ACOS(") || string_3.EndsWith("ASIN(") || string_3.EndsWith("ATAN(") || string_3.EndsWith("ATAN2(") || string_3.EndsWith("AVERAGE(") || string_3.EndsWith("CEILING(") || string_3.EndsWith("COS(") || string_3.EndsWith("COUNT(") || string_3.EndsWith("EXP(") || string_3.EndsWith("FLOOR(") || string_3.EndsWith("INT(") || string_3.EndsWith("LOG(") || string_3.EndsWith("LOG10(") || string_3.EndsWith("MAX(") || string_3.EndsWith("MIN(") || string_3.EndsWith("MOD(") || string_3.EndsWith("ODD(") || string_3.EndsWith("POW(") || string_3.EndsWith("PRODUCT(") || string_3.EndsWith("RADIANS(") || string_3.EndsWith("ROUND(") || string_3.EndsWith("ROUNDDOWN(") || string_3.EndsWith("ROUNDUP(") || string_3.EndsWith("SIGN(") || string_3.EndsWith("SIN(") || string_3.EndsWith("SORT(") || string_3.EndsWith("SUM(") || string_3.EndsWith("TAN("))
			{
				return false;
			}
			return true;
		}

		internal static bool smethod_2(string string_3)
		{
			int num = 7;
			if (string.IsNullOrEmpty(string_3))
			{
				return true;
			}
			string_3 = string_3.Trim().ToUpper();
			if (string_3.EndsWith("LEN") || string_3.EndsWith("PARAMETER") || string_3.EndsWith("FIND") || string_3.EndsWith("LOOKUP") || string_3.EndsWith("AGE") || string_3.EndsWith("AGEMONTH") || string_3.EndsWith("AGEWEEK") || string_3.EndsWith("AGEDAY") || string_3.EndsWith("AGEHOUR") || string_3.EndsWith("CINT") || string_3.EndsWith("CDOUBLE"))
			{
				return true;
			}
			if (string_3.EndsWith("ABS") || string_3.EndsWith("ACOS") || string_3.EndsWith("ASIN") || string_3.EndsWith("ATAN") || string_3.EndsWith("ATAN2") || string_3.EndsWith("AVERAGE") || string_3.EndsWith("CEILING") || string_3.EndsWith("COS") || string_3.EndsWith("COUNT") || string_3.EndsWith("EXP") || string_3.EndsWith("FLOOR") || string_3.EndsWith("INT") || string_3.EndsWith("LOG") || string_3.EndsWith("LOG10") || string_3.EndsWith("MAX") || string_3.EndsWith("MIN") || string_3.EndsWith("MOD") || string_3.EndsWith("ODD") || string_3.EndsWith("POW") || string_3.EndsWith("PRODUCT") || string_3.EndsWith("RADIANS") || string_3.EndsWith("ROUND") || string_3.EndsWith("ROUNDDOWN") || string_3.EndsWith("ROUNDUP") || string_3.EndsWith("SIGN") || string_3.EndsWith("SIN") || string_3.EndsWith("SORT") || string_3.EndsWith("SUM") || string_3.EndsWith("TAN"))
			{
				return false;
			}
			return true;
		}

		public object method_23(XTextElement xtextElement_2, int int_0)
		{
			int num = 18;
			method_17();
			method_1(bool_3: true);
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = VariableString.AnalyseVariableString(method_8(), "[", "]");
			string text = null;
			char c = '\0';
			string string_ = null;
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					string text2 = array[i];
					int num2 = text2.IndexOf("(");
					if (num2 > 0)
					{
						string_ = text2.Substring(0, num2);
					}
					else
					{
						num2 = text2.IndexOf(")");
						if (num2 >= 0)
						{
							string_ = null;
						}
					}
					stringBuilder.Append(text2);
					c = (text2.EndsWith("'") ? '\'' : (text2.EndsWith("\"") ? '"' : '\0'));
				}
				else
				{
					int num2 = (i - 1) / 2;
					if (num2 >= arrayList_0.Count)
					{
						stringBuilder.Append(2147439148.ToString());
						continue;
					}
					bool flag = false;
					bool flag2 = false;
					if (c != 0 && i < array.Length - 1)
					{
						string text3 = array[i + 1];
						if (text3.Length > 0 && text3[0] == c)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						if (text != null)
						{
							text.Trim().ToUpper();
							flag2 = smethod_2(string_);
						}
					}
					else
					{
						flag2 = true;
					}
					object obj = arrayList_0[(i - 1) / 2];
					if (obj != null)
					{
						if (obj is XTextElement)
						{
							double d = 2147439148.0;
							string text4 = smethod_0((XTextElement)obj);
							if (flag)
							{
								stringBuilder.Append(text4);
							}
							else if (flag2)
							{
								stringBuilder.Append("'" + text4 + "'");
							}
							else
							{
								if (text4 != null && text4.Length > 0)
								{
									text4 = text4.Trim();
									if (text4.Length > 0 && text4.Length < 25)
									{
										d = GClass53.smethod_36(text4);
									}
								}
								if (double.IsNaN(d))
								{
									stringBuilder.Append("'" + text4 + "'");
								}
								else if (string.IsNullOrEmpty(text4))
								{
									stringBuilder.Append("0");
								}
								else
								{
									stringBuilder.Append(d.ToString());
								}
							}
						}
						else if (obj is ArrayList)
						{
							ArrayList arrayList = (ArrayList)obj;
							if (arrayList.Count > 0 && arrayList[0] is XTextCheckBoxElementBase && !flag2)
							{
								double num3 = 0.0;
								foreach (XTextElement item in arrayList)
								{
									XTextCheckBoxElementBase xTextCheckBoxElementBase = item as XTextCheckBoxElementBase;
									if (xTextCheckBoxElementBase != null && xTextCheckBoxElementBase.Checked)
									{
										string text4 = smethod_0(xTextCheckBoxElementBase);
										if (flag2)
										{
											stringBuilder.Append(text4);
										}
										else
										{
											double result = 0.0;
											if (double.TryParse(text4, out result))
											{
												num3 += result;
											}
										}
									}
								}
								stringBuilder.Append(num3.ToString());
							}
							else
							{
								int num4 = 0;
								if (flag2 && c == '\0')
								{
									stringBuilder.Append("'");
								}
								for (int j = 0; j < arrayList.Count; j++)
								{
									string text4 = smethod_0((XTextElement)arrayList[j]);
									if (arrayList[j] is XTextCheckBoxElementBase && string.IsNullOrEmpty(text4))
									{
										continue;
									}
									if (num4 > 0)
									{
										stringBuilder.Append(",");
									}
									num4++;
									if (flag2)
									{
										stringBuilder.Append(text4);
										continue;
									}
									double d = 2147439148.0;
									if (text4 != null)
									{
										text4 = text4.Trim();
										if (text4.Length > 0 && text4.Length < 25)
										{
											d = GClass53.smethod_36(text4);
										}
									}
									if (double.IsNaN(d))
									{
										stringBuilder.Append(2147439148.ToString());
									}
									else
									{
										stringBuilder.Append(d.ToString());
									}
								}
								if (flag2 && c == '\0')
								{
									stringBuilder.Append("'");
								}
							}
						}
					}
				}
				text = array[i];
			}
			string text5 = stringBuilder.ToString();
			if (method_2().OwnerDocument.Options.BehaviorOptions.NewExpressionExecuteMode)
			{
				text5 = method_8();
				if (!string.IsNullOrEmpty(text5))
				{
					text5 = text5.Replace("[", "");
					text5 = text5.Replace("]", "");
				}
			}
			object obj2 = null;
			string text6 = smethod_3(xtextElement_0);
			string text7 = null;
			try
			{
				if (string.IsNullOrEmpty(text5))
				{
					obj2 = null;
				}
				else
				{
					GClass54 gClass = new GClass54(text5, method_2(), this);
					obj2 = gClass.vmethod_1();
					text7 = gClass.method_16();
				}
				string text8 = smethod_3(xtextElement_2);
				string text9 = null;
				string text10 = string_1;
				if (!string.IsNullOrEmpty(string_0) && string_0 != "FormulaValue")
				{
					text10 = "[" + string_0 + "]#" + text10;
				}
				text9 = ((!string.IsNullOrEmpty(text8)) ? string.Format(WriterStrings.ExecuteExpression_EventSource_Sender_Expression_Result, text8, text6, text10 + " ==> " + text5.Replace(2147439148.ToString(), "NaN"), obj2) : string.Format(WriterStrings.ExecuteExpression_Sender_Expression_Result, text6, text10 + " ==> " + text5.Replace(2147439148.ToString(), "NaN"), obj2));
				if (int_0 > 0)
				{
					text9 = new string(' ', int_0 * 2) + text9;
				}
				if (text7 != null)
				{
					Debug.WriteLine(text7);
				}
			}
			catch (Exception ex)
			{
				string text10 = string_1;
				if (!string.IsNullOrEmpty(string_0) && string_0 != "FormulaValue")
				{
					text10 = "[" + string_0 + "] " + text10;
				}
				Debug.WriteLine(string.Format(WriterStrings.ExecuteExpression_Sender_Expression_Result, text6, text10 + " ==> " + text5.Replace(2147439148.ToString(), "NaN"), ex.Message));
				throw ex;
			}
			return obj2;
		}

		public static string smethod_3(XTextElement xtextElement_2)
		{
			if (xtextElement_2 == null)
			{
				return null;
			}
			string text = xtextElement_2.ID;
			if (string.IsNullOrEmpty(text) && xtextElement_2 is XTextTableCellElement)
			{
				text = ((XTextTableCellElement)xtextElement_2).CellID;
			}
			return text;
		}
	}
}
