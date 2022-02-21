using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[DebuggerDisplay("Count={ Count }")]
	
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class GClass108 : List<ContentProtectedInfo>
	{
		public void method_0(XTextElement xtextElement_0, string string_0, ContentProtectedReason contentProtectedReason_0)
		{
			Add(new ContentProtectedInfo(xtextElement_0, string_0, contentProtectedReason_0));
		}

		public ContentProtectedInfo method_1(XTextElement xtextElement_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ContentProtectedInfo current = enumerator.Current;
					if (current.Element == xtextElement_0)
					{
						return current;
					}
				}
			}
			return null;
		}

		public string method_2()
		{
			int num = 5;
			StringBuilder stringBuilder = new StringBuilder();
			ContentProtectedInfo contentProtectedInfo = null;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ContentProtectedInfo current = enumerator.Current;
					bool flag = false;
					if (contentProtectedInfo == null)
					{
						flag = true;
					}
					else if (!current.Element.GetType().Equals(contentProtectedInfo.Element.GetType()))
					{
						stringBuilder.AppendLine();
						flag = true;
					}
					if (flag)
					{
						stringBuilder.Append(current.Element.DispalyTypeName);
						stringBuilder.Append(":");
					}
					contentProtectedInfo = current;
					if (current.Element is XTextCharElement)
					{
						XTextCharElement xTextCharElement = (XTextCharElement)current.Element;
						stringBuilder.Append(xTextCharElement.CharValue.ToString());
					}
					else
					{
						if (contentProtectedInfo != null && contentProtectedInfo.Element is XTextCharElement)
						{
							stringBuilder.Append("#" + contentProtectedInfo.Message);
						}
						if (current.Element is XTextInputFieldElementBase)
						{
							XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)current.Element;
							if (!string.IsNullOrEmpty(xTextInputFieldElementBase.Name))
							{
								stringBuilder.Append(xTextInputFieldElementBase.Name);
							}
							else
							{
								stringBuilder.Append(xTextInputFieldElementBase.DisplayName);
							}
							stringBuilder.Append(":");
							stringBuilder.Append(WriterUtils.smethod_33(xTextInputFieldElementBase.Text, 50));
							stringBuilder.Append("#");
							stringBuilder.Append(current.Message);
						}
						else
						{
							stringBuilder.Append(string.Concat(current.Element, "#", current.Message));
						}
					}
					if (stringBuilder.Length > 1000)
					{
						break;
					}
				}
			}
			if (contentProtectedInfo != null && contentProtectedInfo.Element is XTextCharElement)
			{
				stringBuilder.Append("#" + contentProtectedInfo.Message);
			}
			return stringBuilder.ToString();
		}
	}
}
