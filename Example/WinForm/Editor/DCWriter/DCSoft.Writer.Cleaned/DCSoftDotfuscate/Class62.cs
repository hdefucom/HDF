using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	internal class Class62 : GClass30
	{
		public override void vmethod_0(XmlWriter xmlWriter_0, XTextElement xtextElement_0)
		{
			base.vmethod_0(xmlWriter_0, xtextElement_0);
			XTextContainerElement xTextContainerElement = (XTextContainerElement)xtextElement_0;
			vmethod_2(xmlWriter_0, xTextContainerElement);
			vmethod_1("Elements", xmlWriter_0, xTextContainerElement.Elements);
		}

		protected virtual void vmethod_1(string string_0, XmlWriter xmlWriter_0, XTextElementList xtextElementList_0)
		{
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				xmlWriter_0.WriteStartElement(string_0);
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.AddRangeRaw(xtextElementList_0);
				WriterUtils.smethod_60(xTextElementList, bool_2: false);
				foreach (XTextElement item in xTextElementList)
				{
					string localName = method_0(item);
					xmlWriter_0.WriteStartElement(localName);
					xmlWriter_0.WriteFullEndElement();
				}
				xmlWriter_0.WriteFullEndElement();
			}
		}

		protected virtual void vmethod_2(XmlWriter xmlWriter_0, XTextContainerElement xtextContainerElement_0)
		{
			int num = 18;
			if (!string.IsNullOrEmpty(xtextContainerElement_0.ID))
			{
				xmlWriter_0.WriteAttributeString("ID", xtextContainerElement_0.ID);
			}
			if (xtextContainerElement_0.StyleIndex >= 0)
			{
				xmlWriter_0.WriteAttributeString("StyleIndex", xtextContainerElement_0.StyleIndex.ToString());
			}
			if (xtextContainerElement_0.AcceptChildElementTypes2 != ElementType.All)
			{
				method_2(xmlWriter_0, "AcceptChildElementTypes", xtextContainerElement_0.AcceptChildElementTypes2);
			}
			if (xtextContainerElement_0.AcceptTab)
			{
				xmlWriter_0.WriteAttributeString("AcceptTab", "true");
			}
			if (xtextContainerElement_0.AutoHideMode != 0)
			{
				method_2(xmlWriter_0, "AutoHideMode", xtextContainerElement_0.AutoHideMode);
			}
			if (xtextContainerElement_0.BringoutToSave)
			{
				xmlWriter_0.WriteAttributeString("BringoutToSave", "true");
			}
			if (xtextContainerElement_0.CanBeReferenced)
			{
				xmlWriter_0.WriteAttributeString("CanBeReferenced", "true");
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.DataName))
			{
				xmlWriter_0.WriteAttributeString("DataName", xtextContainerElement_0.DataName);
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.ReferencedDataName))
			{
				xmlWriter_0.WriteAttributeString("ReferencedDataName", xtextContainerElement_0.ReferencedDataName);
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.DefaultValueForValueBinding))
			{
				xmlWriter_0.WriteAttributeString("DefaultValueForValueBinding", xtextContainerElement_0.DefaultValueForValueBinding);
			}
			if (!xtextContainerElement_0.Deleteable)
			{
				xmlWriter_0.WriteAttributeString("Deleteable", "false");
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.ElementIDForEditableDependent))
			{
				xmlWriter_0.WriteAttributeString("ElementIDForEditableDependent", xtextContainerElement_0.ElementIDForEditableDependent);
			}
			if (xtextContainerElement_0.ContentReadonly != ContentReadonlyState.Inherit)
			{
				method_2(xmlWriter_0, "ContentReadonly", xtextContainerElement_0.ContentReadonly);
			}
			if (xtextContainerElement_0.EnablePermission != DCBooleanValue.Inherit)
			{
				method_5(xmlWriter_0, "EnablePermission", xtextContainerElement_0.EnablePermission);
			}
			if (xtextContainerElement_0.EnableValueValidate)
			{
				xmlWriter_0.WriteAttributeString("EnableValueValidate", "true");
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.ToolTip))
			{
				xmlWriter_0.WriteAttributeString("ToolTip", xtextContainerElement_0.ToolTip);
			}
			if (xtextContainerElement_0.UserFlags != 0)
			{
				xmlWriter_0.WriteAttributeString("UserFlag", xtextContainerElement_0.UserFlags.ToString());
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.EventTemplateName))
			{
				xmlWriter_0.WriteAttributeString("EventTemplateName", xtextContainerElement_0.EventTemplateName);
			}
			if (xtextContainerElement_0.MaxInputLength != 0)
			{
				xmlWriter_0.WriteAttributeString("MaxInputLength", xtextContainerElement_0.MaxInputLength.ToString());
			}
			if (xtextContainerElement_0.PrintVisibility != 0)
			{
				method_2(xmlWriter_0, "PrintVisibility", xtextContainerElement_0.PrintVisibility);
			}
			if (!xtextContainerElement_0.Visible)
			{
				xmlWriter_0.WriteAttributeString("Visible", "false");
			}
			method_13(xmlWriter_0, "CopySource", xtextContainerElement_0.CopySource);
			method_12(xmlWriter_0, "ContentLock", xtextContainerElement_0.ContentLock);
			method_7(xmlWriter_0, "Expressions", xtextContainerElement_0.Expressions);
			method_8(xmlWriter_0, "ScriptItems", xtextContainerElement_0.ScriptItems);
			method_6(xmlWriter_0, "PropertyExpressions", xtextContainerElement_0.PropertyExpressions);
			method_14(xmlWriter_0, "ValidateStyle", xtextContainerElement_0.ValidateStyle);
			method_4(xmlWriter_0, "ValueBinding", xtextContainerElement_0.ValueBinding);
			if (!string.IsNullOrEmpty(xtextContainerElement_0.JavaScriptForClick))
			{
				method_9(xmlWriter_0, "JavaScriptForClick", xtextContainerElement_0.JavaScriptForClick);
			}
			if (!string.IsNullOrEmpty(xtextContainerElement_0.JavaScriptForDoubleClick))
			{
				method_9(xmlWriter_0, "JavaScriptForDoubleClick", xtextContainerElement_0.JavaScriptForDoubleClick);
			}
		}

		protected void method_12(XmlWriter xmlWriter_0, string string_0, DCContentLockInfo dccontentLockInfo_0)
		{
			int num = 0;
			if (dccontentLockInfo_0 != null && !dccontentLockInfo_0.IsEmpty)
			{
				xmlWriter_0.WriteStartElement(string_0);
				if (!string.IsNullOrEmpty(dccontentLockInfo_0.AuthorisedUserIDList))
				{
					xmlWriter_0.WriteAttributeString("AuthorisedUserIDList", dccontentLockInfo_0.AuthorisedUserIDList);
				}
				if (dccontentLockInfo_0.CreationTime != DocumentInfo.NullDateTime)
				{
					xmlWriter_0.WriteAttributeString("CreationTime", XMLSerializeHelper.DateTimeToString(dccontentLockInfo_0.CreationTime));
				}
				if (!string.IsNullOrEmpty(dccontentLockInfo_0.OwnerUserID))
				{
					xmlWriter_0.WriteAttributeString("OwnerUserID", dccontentLockInfo_0.OwnerUserID);
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_13(XmlWriter xmlWriter_0, string string_0, CopySourceInfo copySourceInfo_0)
		{
			int num = 3;
			if (copySourceInfo_0 != null && !copySourceInfo_0.IsEmpty)
			{
				xmlWriter_0.WriteStartElement(string_0);
				if (!string.IsNullOrEmpty(copySourceInfo_0.DescPropertyName))
				{
					xmlWriter_0.WriteAttributeString("DescPropertyName", copySourceInfo_0.DescPropertyName);
				}
				if (!copySourceInfo_0.IgnoreChildElements)
				{
					xmlWriter_0.WriteAttributeString("IgnoreChildElements", "false");
				}
				if (!string.IsNullOrEmpty(copySourceInfo_0.SourceID))
				{
					xmlWriter_0.WriteAttributeString("SourceID)", copySourceInfo_0.SourceID);
				}
				if (!string.IsNullOrEmpty(copySourceInfo_0.SourcePropertyName))
				{
					xmlWriter_0.WriteAttributeString("SourcePropertyName", copySourceInfo_0.SourcePropertyName);
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_14(XmlWriter xmlWriter_0, string string_0, ValueValidateStyle valueValidateStyle_0)
		{
			int num = 12;
			if (valueValidateStyle_0 != null && !valueValidateStyle_0.IsEmpty)
			{
				xmlWriter_0.WriteStartElement(string_0);
				xmlWriter_0.WriteAttributeString("ValueType", valueValidateStyle_0.ValueType.ToString());
				if (!string.IsNullOrEmpty(valueValidateStyle_0.ValueName))
				{
					xmlWriter_0.WriteAttributeString("ValueName", valueValidateStyle_0.ValueName);
				}
				if (valueValidateStyle_0.BinaryLength)
				{
					xmlWriter_0.WriteAttributeString("BinaryLength", "true");
				}
				if (valueValidateStyle_0.CheckDecimalDigits)
				{
					xmlWriter_0.WriteAttributeString("CheckDecimalDigits", "true");
				}
				if (valueValidateStyle_0.CheckMaxValue)
				{
					xmlWriter_0.WriteAttributeString("CheckMaxValue", "true");
				}
				if (valueValidateStyle_0.CheckMinValue)
				{
					xmlWriter_0.WriteAttributeString("CheckMinValue", "true");
				}
				if (!string.IsNullOrEmpty(valueValidateStyle_0.CustomMessage))
				{
					xmlWriter_0.WriteAttributeString("CustomMessage", valueValidateStyle_0.CustomMessage);
				}
				if (valueValidateStyle_0.DateTimeMaxValue != ValueValidateStyle.NullDateTime)
				{
					xmlWriter_0.WriteAttributeString("DateTimeMaxValue", XMLSerializeHelper.DateTimeToString(valueValidateStyle_0.DateTimeMaxValue));
				}
				if (valueValidateStyle_0.DateTimeMinValue != ValueValidateStyle.NullDateTime)
				{
					xmlWriter_0.WriteAttributeString("DateTimeMinValue", XMLSerializeHelper.DateTimeToString(valueValidateStyle_0.DateTimeMinValue));
				}
				if (!string.IsNullOrEmpty(valueValidateStyle_0.ExcludeKeywords))
				{
					xmlWriter_0.WriteAttributeString("ExcludeKeywords", valueValidateStyle_0.ExcludeKeywords);
				}
				if (!string.IsNullOrEmpty(valueValidateStyle_0.IncludeKeywords))
				{
					xmlWriter_0.WriteAttributeString("IncludeKeywords", valueValidateStyle_0.IncludeKeywords);
				}
				xmlWriter_0.WriteAttributeString("Level", valueValidateStyle_0.Level.ToString());
				if (valueValidateStyle_0.MaxDecimalDigits != 0)
				{
					xmlWriter_0.WriteAttributeString("MaxDecimalDigits", valueValidateStyle_0.MaxDecimalDigits.ToString());
				}
				if (valueValidateStyle_0.MaxLength != 0)
				{
					xmlWriter_0.WriteAttributeString("MaxLength", valueValidateStyle_0.MaxLength.ToString());
				}
				if (valueValidateStyle_0.MinLength != 0)
				{
					xmlWriter_0.WriteAttributeString("MinLength", valueValidateStyle_0.MinLength.ToString());
				}
				if (valueValidateStyle_0.MaxValue != 0.0)
				{
					xmlWriter_0.WriteAttributeString("MaxValue", valueValidateStyle_0.MaxValue.ToString());
				}
				if (valueValidateStyle_0.MinValue != 0.0)
				{
					xmlWriter_0.WriteAttributeString("MinValue", valueValidateStyle_0.MinValue.ToString());
				}
				if (!string.IsNullOrEmpty(valueValidateStyle_0.Range))
				{
					xmlWriter_0.WriteAttributeString("Range", valueValidateStyle_0.Range);
				}
				if (!string.IsNullOrEmpty(valueValidateStyle_0.RegExpression))
				{
					xmlWriter_0.WriteAttributeString("RegExpression", valueValidateStyle_0.RegExpression);
				}
				if (valueValidateStyle_0.Required)
				{
					xmlWriter_0.WriteAttributeString("Required", "true");
				}
				xmlWriter_0.WriteEndElement();
			}
		}
	}
}
