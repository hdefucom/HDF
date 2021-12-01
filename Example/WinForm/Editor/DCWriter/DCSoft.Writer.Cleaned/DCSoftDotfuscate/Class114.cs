using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;

namespace DCSoftDotfuscate
{
	internal class Class114
	{
		public void method_0(XTextInputFieldElement xtextInputFieldElement_0)
		{
			if (xtextInputFieldElement_0 != null && xtextInputFieldElement_0.LinkListBinding != null && xtextInputFieldElement_0.LinkListBinding.IsRoot)
			{
				method_1(xtextInputFieldElement_0, bool_0: true);
			}
		}

		public void method_1(XTextInputFieldElement xtextInputFieldElement_0, bool bool_0)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_185) || xtextInputFieldElement_0 == null || xtextInputFieldElement_0.LinkListBinding == null)
			{
				return;
			}
			_ = xtextInputFieldElement_0.OwnerDocument;
			XTextElementList xTextElementList = null;
			xTextElementList = ((!bool_0) ? method_3(xtextInputFieldElement_0) : new XTextElementList(xtextInputFieldElement_0));
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				return;
			}
			if (bool_0)
			{
				GetLinkListItemsEventArgs getLinkListItemsEventArgs = new GetLinkListItemsEventArgs();
				getLinkListItemsEventArgs.EffectElements = xTextElementList;
				getLinkListItemsEventArgs.ParentBinding = xtextInputFieldElement_0.LinkListBinding;
				getLinkListItemsEventArgs.ParentElement = xtextInputFieldElement_0;
				getLinkListItemsEventArgs.ParentValue = xtextInputFieldElement_0.InnerValue;
				getLinkListItemsEventArgs.CurrentElement = xtextInputFieldElement_0;
				getLinkListItemsEventArgs.CurrentBinding = xtextInputFieldElement_0.LinkListBinding;
				method_2(xtextInputFieldElement_0, xtextInputFieldElement_0, getLinkListItemsEventArgs);
				return;
			}
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElementList.GetNextElement(xtextInputFieldElement_0);
			if (xTextInputFieldElement != null)
			{
				GetLinkListItemsEventArgs getLinkListItemsEventArgs = new GetLinkListItemsEventArgs();
				getLinkListItemsEventArgs.EffectElements = xTextElementList;
				getLinkListItemsEventArgs.ParentBinding = xtextInputFieldElement_0.LinkListBinding;
				getLinkListItemsEventArgs.ParentElement = xtextInputFieldElement_0;
				getLinkListItemsEventArgs.ParentValue = xtextInputFieldElement_0.InnerValue;
				getLinkListItemsEventArgs.CurrentElement = xTextInputFieldElement;
				getLinkListItemsEventArgs.CurrentBinding = xTextInputFieldElement.LinkListBinding;
				method_2(xtextInputFieldElement_0, xTextInputFieldElement, getLinkListItemsEventArgs);
			}
		}

		private void method_2(XTextInputFieldElement xtextInputFieldElement_0, XTextInputFieldElement xtextInputFieldElement_1, GetLinkListItemsEventArgs getLinkListItemsEventArgs_0)
		{
			XTextDocument ownerDocument = xtextInputFieldElement_0.OwnerDocument;
			if (ownerDocument.EditorControl != null)
			{
				ownerDocument.EditorControl.vmethod_34(getLinkListItemsEventArgs_0);
				if (getLinkListItemsEventArgs_0.Cancel)
				{
					return;
				}
			}
			if (!getLinkListItemsEventArgs_0.Handled && getLinkListItemsEventArgs_0.Items.Count == 0)
			{
				ownerDocument.AppHost.LinkListProviders.GetEnabledProvider(getLinkListItemsEventArgs_0.ParentBinding.ProviderName)?.GetListItems(getLinkListItemsEventArgs_0);
			}
			if (getLinkListItemsEventArgs_0.Cancel)
			{
				return;
			}
			if (xtextInputFieldElement_1.FieldSettings == null)
			{
				xtextInputFieldElement_1.FieldSettings = new InputFieldSettings();
			}
			if (xtextInputFieldElement_1.FieldSettings.ListSource == null)
			{
				xtextInputFieldElement_1.FieldSettings.ListSource = new ListSourceInfo();
			}
			xtextInputFieldElement_1.FieldSettings.ListSource.RuntimeItems = getLinkListItemsEventArgs_0.Items;
			if (!getLinkListItemsEventArgs_0.CurrentBinding.AutoSetFirstItems)
			{
				return;
			}
			if (getLinkListItemsEventArgs_0.Items.Count > 0)
			{
				ListItem listItem = getLinkListItemsEventArgs_0.Items[0];
				string text = listItem.Value;
				if (string.IsNullOrEmpty(text))
				{
					text = listItem.Text;
				}
				xtextInputFieldElement_1.InnerValue = text;
				xtextInputFieldElement_1.EditorTextExt = listItem.Text;
			}
			else
			{
				xtextInputFieldElement_1.InnerValue = null;
				xtextInputFieldElement_1.EditorTextExt = "";
			}
		}

		private XTextElementList method_3(XTextInputFieldElement xtextInputFieldElement_0)
		{
			if (xtextInputFieldElement_0 == null || xtextInputFieldElement_0.LinkListBinding == null || string.IsNullOrEmpty(xtextInputFieldElement_0.LinkListBinding.ProviderName))
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			XTextDocumentContentElement documentContentElement = xtextInputFieldElement_0.DocumentContentElement;
			XTextElementList xTextElementList2 = new XTextElementList();
			XTextElementList elementsByType = documentContentElement.GetElementsByType(typeof(XTextInputFieldElement));
			foreach (XTextInputFieldElement item in elementsByType)
			{
				if (item.LinkListBinding != null && item.LinkListBinding.ProviderName == xtextInputFieldElement_0.LinkListBinding.ProviderName)
				{
					xTextElementList2.Add(item);
				}
			}
			if (!xTextElementList2.Contains(xtextInputFieldElement_0))
			{
				return null;
			}
			XTextInputFieldElement xTextInputFieldElement2 = xtextInputFieldElement_0;
			while (!xTextInputFieldElement2.LinkListBinding.IsRoot)
			{
				bool flag = false;
				foreach (XTextInputFieldElement item2 in xTextElementList2)
				{
					if (item2.LinkListBinding.NextTarget == EventExpressionTarget.Custom && item2.LinkListBinding.NextTargetID == xTextInputFieldElement2.ID)
					{
						xTextElementList.method_13(0, item2);
						xTextInputFieldElement2 = item2;
						flag = true;
						xTextElementList2.Remove(item2);
						break;
					}
					if (item2.LinkListBinding.NextTarget == EventExpressionTarget.NextElement && xTextElementList2.IndexOf(item2) == xTextElementList2.IndexOf(xTextInputFieldElement2) - 1)
					{
						xTextElementList.method_13(0, item2);
						xTextInputFieldElement2 = item2;
						flag = true;
						xTextElementList2.Remove(item2);
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			xTextElementList.Add(xtextInputFieldElement_0);
			xTextInputFieldElement2 = xtextInputFieldElement_0;
			while (xTextInputFieldElement2.LinkListBinding.NextTarget != EventExpressionTarget.None)
			{
				if (xTextInputFieldElement2.LinkListBinding.NextTarget == EventExpressionTarget.NextElement)
				{
					XTextInputFieldElement xTextInputFieldElement3 = (XTextInputFieldElement)xTextElementList2.GetNextElement(xTextInputFieldElement2);
					if (xTextInputFieldElement3 == null)
					{
						break;
					}
					xTextInputFieldElement2 = xTextInputFieldElement3;
					xTextElementList.Add(xTextInputFieldElement2);
				}
				else if (xTextInputFieldElement2.LinkListBinding.NextTarget == EventExpressionTarget.Custom)
				{
					bool flag = false;
					foreach (XTextInputFieldElement item3 in xTextElementList2)
					{
						if (item3.ID == xTextInputFieldElement2.LinkListBinding.NextTargetID)
						{
							xTextInputFieldElement2 = item3;
							xTextElementList.Add(xTextInputFieldElement2);
							flag = true;
							xTextElementList2.Remove(item3);
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
			}
			return xTextElementList;
		}
	}
}
