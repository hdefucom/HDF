using System;
using System.Collections;
using System.Text;

namespace XDesignerCommon
{
	public class VariableString
	{
		private string strVariablePrefix = "[%";

		private string strVariableEndfix = "%]";

		private IVariableProvider myVariables = new HashTableVariableProvider();

		private string strText = null;

		public string VariablePrefix
		{
			get
			{
				return strVariablePrefix;
			}
			set
			{
				strVariablePrefix = value;
			}
		}

		public string VariableEndfix
		{
			get
			{
				return strVariableEndfix;
			}
			set
			{
				strVariableEndfix = value;
			}
		}

		public IVariableProvider Variables
		{
			get
			{
				return myVariables;
			}
			set
			{
				myVariables = value;
			}
		}

		public string Text
		{
			get
			{
				return strText;
			}
			set
			{
				strText = value;
			}
		}

		public VariableString()
		{
		}

		public VariableString(string txt)
		{
			strText = txt;
		}

		public void SetVariable(string strName, string strValue)
		{
			if (myVariables != null)
			{
				myVariables.Set(strName, strValue);
			}
		}

		public string[] GetVariableNames()
		{
			string[] array = AnalyseVariableString(strText, strVariablePrefix, strVariableEndfix);
			if (array != null)
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 1; i < array.Length; i += 2)
				{
					arrayList.Add(array[i]);
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
			return null;
		}

		public string Execute()
		{
			return Execute(strText, null);
		}

		public string Execute(string txt, ArrayList ParameterValues)
		{
			if (myVariables == null)
			{
				throw new InvalidOperationException("未设置 Variables 属性");
			}
			if (txt == null || txt.Length == 0)
			{
				return txt;
			}
			string[] array = AnalyseVariableString(txt, strVariablePrefix, strVariableEndfix);
			if (array == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				string text = array[i];
				bool flag = text.StartsWith("@");
				if (flag)
				{
					text = text.Substring(1);
				}
				string text2 = null;
				text2 = ((!myVariables.Exists(text)) ? "" : myVariables.Get(text));
				if (ParameterValues != null && flag)
				{
					ParameterValues.Add(text2);
					stringBuilder.Append(" ? ");
				}
				else
				{
					stringBuilder.Append(text2);
				}
			}
			return stringBuilder.ToString();
		}

		private static string[] AnalyseVariableString(string strText, string strHead, string strEnd)
		{
			if (strText == null || strHead == null || strEnd == null || strHead.Length == 0 || strEnd.Length == 0 || strText.Length == 0)
			{
				return new string[1]
				{
					strText
				};
			}
			int num = strText.IndexOf(strHead);
			if (num < 0)
			{
				return new string[1]
				{
					strText
				};
			}
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			do
			{
				int num3 = strText.IndexOf(strEnd, num + 1);
				if (num3 > num)
				{
					int num4 = num;
					do
					{
						num = num4;
						num4 = strText.IndexOf(strHead, num4 + 1);
					}
					while (num4 > num && num4 < num3);
					string value = strText.Substring(num + strHead.Length, num3 - num - strHead.Length);
					if (num2 < num)
					{
						arrayList.Add(strText.Substring(num2, num - num2));
					}
					else
					{
						arrayList.Add("");
					}
					arrayList.Add(value);
					num = num3 + strEnd.Length;
					num2 = num;
					continue;
				}
				break;
			}
			while (num >= 0 && num < strText.Length);
			if (num2 < strText.Length)
			{
				arrayList.Add(strText.Substring(num2));
			}
			return (string[])arrayList.ToArray(typeof(string));
		}
	}
}
