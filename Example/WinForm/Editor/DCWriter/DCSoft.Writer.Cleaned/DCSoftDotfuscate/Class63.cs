using DCSoft.Common;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	internal class Class63 : GClass30
	{
		public override void vmethod_0(XmlWriter xmlWriter_0, XTextElement xtextElement_0)
		{
			int num = 10;
			base.vmethod_0(xmlWriter_0, xtextElement_0);
			XTextObjectElement xTextObjectElement = (XTextObjectElement)xtextElement_0;
			if (xTextObjectElement.ContentReadonly != ContentReadonlyState.Inherit)
			{
				xmlWriter_0.WriteAttributeString("ContentReadonly", xTextObjectElement.ContentReadonly.ToString());
			}
			if (!xTextObjectElement.Deleteable)
			{
				xmlWriter_0.WriteAttributeString("Deleteable", "false");
			}
			if (!xTextObjectElement.Enabled)
			{
				xmlWriter_0.WriteAttributeString("Enabled", "false");
			}
			if (!string.IsNullOrEmpty(xTextObjectElement.EventTemplateName))
			{
				xmlWriter_0.WriteAttributeString("EventTemplateName", xTextObjectElement.EventTemplateName);
			}
			if (!string.IsNullOrEmpty(xTextObjectElement.Name))
			{
				xmlWriter_0.WriteAttributeString("Name", xTextObjectElement.Name);
			}
			if (xTextObjectElement.OffsetX != 0f)
			{
				xmlWriter_0.WriteAttributeString("OffsetX", xTextObjectElement.OffsetX.ToString());
			}
			if (xTextObjectElement.OffsetY != 0f)
			{
				xmlWriter_0.WriteAttributeString("OffsetY", xTextObjectElement.OffsetY.ToString());
			}
			if (xTextObjectElement.PrintVisibility != 0)
			{
				xmlWriter_0.WriteAttributeString("PrintVisibility", xTextObjectElement.PrintVisibility.ToString());
			}
			if (xTextObjectElement.Resizeable != ResizeableType.WidthAndHeight)
			{
				xmlWriter_0.WriteAttributeString("Resizeable", xTextObjectElement.Resizeable.ToString());
			}
			if (xTextObjectElement.UserFlags != 0)
			{
				xmlWriter_0.WriteAttributeString("UserFlags", xTextObjectElement.UserFlags.ToString());
			}
			if (!xTextObjectElement.Visible)
			{
				xmlWriter_0.WriteAttributeString("Visible", "false");
			}
			if (xTextObjectElement.ZOrderStyle != 0)
			{
				xmlWriter_0.WriteAttributeString("ZOrderStyle", xTextObjectElement.ZOrderStyle.ToString());
			}
			if (!string.IsNullOrEmpty(xTextObjectElement.StringTag))
			{
				xmlWriter_0.WriteElementString("StringTag", xTextObjectElement.StringTag);
			}
			method_8(xmlWriter_0, "ScriptItems", xTextObjectElement.ScriptItems);
			method_6(xmlWriter_0, "PropertyExpressions", xTextObjectElement.PropertyExpressions);
			method_1(xmlWriter_0, "Attributes", xTextObjectElement.Attributes);
			method_12(xmlWriter_0, "LinkInfo", xTextObjectElement.LinkInfo);
			if (!string.IsNullOrEmpty(xTextObjectElement.JavaScriptForClick))
			{
				method_9(xmlWriter_0, "JavaScriptForClick", xTextObjectElement.JavaScriptForClick);
			}
			if (!string.IsNullOrEmpty(xTextObjectElement.JavaScriptForDoubleClick))
			{
				method_9(xmlWriter_0, "JavaScriptForDoubleClick", xTextObjectElement.JavaScriptForDoubleClick);
			}
		}

		protected void method_12(XmlWriter xmlWriter_0, string string_0, HyperlinkInfo hyperlinkInfo_0)
		{
			int num = 4;
			if (hyperlinkInfo_0 != null && !hyperlinkInfo_0.IsEmpty)
			{
				xmlWriter_0.WriteStartElement(string_0);
				if (!string.IsNullOrEmpty(hyperlinkInfo_0.Reference))
				{
					xmlWriter_0.WriteAttributeString("Reference", hyperlinkInfo_0.Reference);
				}
				if (!string.IsNullOrEmpty(hyperlinkInfo_0.Target))
				{
					xmlWriter_0.WriteAttributeString("Target", hyperlinkInfo_0.Target);
				}
				if (!string.IsNullOrEmpty(hyperlinkInfo_0.Title))
				{
					xmlWriter_0.WriteAttributeString("Title", hyperlinkInfo_0.Title);
				}
				xmlWriter_0.WriteEndElement();
			}
		}
	}
}
