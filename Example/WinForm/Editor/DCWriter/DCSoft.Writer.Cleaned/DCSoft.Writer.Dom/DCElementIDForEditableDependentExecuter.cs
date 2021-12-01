#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DCSoft.Writer.Dom
{
	internal class DCElementIDForEditableDependentExecuter : IDCElementIDForEditableDependentExecuter
	{
		private XTextDocument xtextDocument_0;

		private List<XTextContainerElement> list_0;

		public DCElementIDForEditableDependentExecuter(XTextDocument xtextDocument_1)
		{
			int num = 8;
			xtextDocument_0 = null;
			list_0 = null;
			
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("doc");
			}
			xtextDocument_0 = xtextDocument_1;
		}

		public void RefreshState()
		{
			list_0 = null;
		}

		/// <summary>
		///       由于元素编号发生改变而自动更新设置
		///       </summary>
		/// <param name="elements">要操作的文档元素列表</param>
		/// <param name="idMaps">新旧元素编号映射表</param>
		/// <returns>操作修改的元素个数</returns>
		public int SynchronForModifyElementID(XTextElementList elements, Dictionary<string, string> idMaps)
		{
			int num = 5;
			if (elements == null || elements.Count == 0)
			{
				return 0;
			}
			if (idMaps == null || idMaps.Count == 0)
			{
				return 0;
			}
			int num2 = 0;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(elements);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					string elementIDForEditableDependent = xTextContainerElement.ElementIDForEditableDependent;
					if (!string.IsNullOrEmpty(elementIDForEditableDependent))
					{
						foreach (string key in idMaps.Keys)
						{
							string text = idMaps[key];
							if (elementIDForEditableDependent == text)
							{
								xTextContainerElement.ElementIDForEditableDependent = key;
								num2++;
							}
							else if (elementIDForEditableDependent == "!" + text)
							{
								xTextContainerElement.ElementIDForEditableDependent = "!" + key;
								num2++;
							}
						}
					}
				}
			}
			return num2;
		}

		public string GetEffectTargetElementIDs(XTextElement srcElement)
		{
			int num = 2;
			if (srcElement == null)
			{
				throw new ArgumentNullException("srcElement");
			}
			if (string.IsNullOrEmpty(srcElement.ID))
			{
				return null;
			}
			if (list_0 == null)
			{
				list_0 = new List<XTextContainerElement>();
				foreach (XTextContainerElement item in xtextDocument_0.GetElementsByType(typeof(XTextContainerElement)))
				{
					if (!string.IsNullOrEmpty(item.ElementIDForEditableDependent) && !string.IsNullOrEmpty(item.ID))
					{
						list_0.Add(item);
					}
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			string b = "!" + srcElement.ID;
			foreach (XTextContainerElement item2 in list_0)
			{
				string elementIDForEditableDependent = item2.ElementIDForEditableDependent;
				if (elementIDForEditableDependent == srcElement.ID || elementIDForEditableDependent == b)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(item2.ID);
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       执行操作
		///       </summary>
		/// <param name="srcElement">
		/// </param>
		/// <param name="fastMode">
		/// </param>
		/// <returns>
		/// </returns>
		public int Execute(XTextElement srcElement, bool fastMode)
		{
			int num = 11;
			if (srcElement == null)
			{
				throw new ArgumentNullException("srcElement");
			}
			if (!xtextDocument_0.Options.BehaviorOptions.EnableExpression)
			{
				return 0;
			}
			string iD = srcElement.ID;
			if (string.IsNullOrEmpty(iD))
			{
				return 0;
			}
			int num2 = 0;
			foreach (XTextContainerElement item in xtextDocument_0.GetElementsByType(typeof(XTextContainerElement)))
			{
				string text = item.ElementIDForEditableDependent;
				if (!string.IsNullOrEmpty(text))
				{
					bool flag = false;
					if (text.StartsWith("!"))
					{
						text = text.Substring(1);
						flag = true;
					}
					if (text == iD)
					{
						ContentReadonlyState contentReadonlyState = item.ContentReadonly;
						if (srcElement is XTextCheckBoxElementBase)
						{
							contentReadonlyState = (((XTextCheckBoxElementBase)srcElement).Checked ? ((!flag) ? ContentReadonlyState.False : ContentReadonlyState.True) : (flag ? ContentReadonlyState.False : ContentReadonlyState.True));
						}
						if (item.ContentReadonly != contentReadonlyState)
						{
							string message = string.Format(WriterStrings.ElementIDForEditableDependent_SrcID_TargetID_Result, iD, item.ID, contentReadonlyState);
							Debug.WriteLine(message);
							item.ContentReadonly = contentReadonlyState;
							num2++;
						}
					}
				}
			}
			if (num2 > 0 && !fastMode && xtextDocument_0.EditorControl != null)
			{
				xtextDocument_0.EditorControl.CommandControler.UpdateBindingControlStatus();
			}
			return num2;
		}
	}
}
