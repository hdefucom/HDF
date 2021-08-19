using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       段落对象
	///       </summary>
	/// <remarks>本对象只在加载或保存文档是临时生成。</remarks>
	[Serializable]
	[Browsable(false)]
	[XmlType("XParagraph")]
	[DCInternal]
	[DebuggerDisplay("<P>:{ PreviewString }")]
	public class XTextParagraphElement : XTextContainerElement
	{
		private bool bool_17 = false;

		internal XTextTableCellElement xtextTableCellElement_0 = null;

		/// <summary>
		///       临时标记
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public bool TemporaryFlag
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		internal XTextParagraphFlagElement FlagElement
		{
			get
			{
				if (Elements != null)
				{
					return Elements.LastElement as XTextParagraphFlagElement;
				}
				return null;
			}
		}

		internal XTextElement method_26(XTextElement xtextElement_0)
		{
			if (Elements.Contains(xtextElement_0))
			{
				return xtextElement_0;
			}
			XTextElement xTextElement = xtextElement_0;
			while (xTextElement.Parent != this && xTextElement != null)
			{
				xTextElement = xTextElement.Parent;
			}
			if (xTextElement != null && xTextElement.Parent == this)
			{
				return xTextElement;
			}
			return null;
		}

		[DCInternal]
		[ComVisible(false)]
		public XTextParagraphElement method_27(bool bool_18)
		{
			XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
			xTextParagraphElement.OwnerDocument = OwnerDocument;
			xTextParagraphElement.StyleIndex = StyleIndex;
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.OwnerDocument = OwnerDocument;
			foreach (XTextElement element in Elements)
			{
				if (!bool_18 || OwnerDocument.IsSelected(element))
				{
					if (element is XTextCharElement)
					{
						XTextCharElement xTextCharElement = (XTextCharElement)element;
						if (xTextStringElement.method_27(xTextCharElement))
						{
							xTextStringElement.method_28(xTextCharElement, xTextCharElement.ToString());
						}
						else
						{
							if (xTextStringElement.HasContent)
							{
								xTextParagraphElement.Elements.AddRaw(xTextStringElement);
								xTextStringElement = new XTextStringElement();
							}
							xTextStringElement.OwnerDocument = OwnerDocument;
							xTextStringElement.method_28(xTextCharElement, xTextCharElement.ToString());
						}
					}
					else
					{
						if (xTextStringElement.HasContent)
						{
							xTextParagraphElement.Elements.AddRaw(xTextStringElement);
							xTextStringElement = new XTextStringElement();
						}
						if (!(element is XTextParagraphFlagElement))
						{
							xTextParagraphElement.Elements.AddRaw(element);
						}
					}
				}
			}
			if (xTextStringElement.HasContent)
			{
				xTextParagraphElement.Elements.AddRaw(xTextStringElement);
			}
			return xTextParagraphElement;
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			int num = 8;
			if (!TemporaryFlag && FlagElement != null)
			{
				gclass103_0.method_35(RuntimeStyle, FlagElement);
				if (xtextTableCellElement_0 != null)
				{
					gclass103_0.method_28("intbl");
					int neastLevel = xtextTableCellElement_0.OwnerTable.NeastLevel;
					if (neastLevel > 1)
					{
						gclass103_0.method_28("itap" + neastLevel);
					}
				}
			}
			foreach (XTextElement element in Elements)
			{
				element.vmethod_19(gclass103_0);
			}
			if (!TemporaryFlag)
			{
				gclass103_0.method_37();
			}
		}
	}
}
