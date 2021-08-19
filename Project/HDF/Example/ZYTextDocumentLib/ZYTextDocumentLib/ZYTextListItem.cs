using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextListItem
	{
		public string Value = null;

		public string Text = null;

		public bool Selected = false;

		public void CopyTo(ZYTextListItem myItem)
		{
			if (myItem != null)
			{
				myItem.Value = Value;
				myItem.Text = Text;
				myItem.Selected = Selected;
			}
		}

		public static string GetXMLName()
		{
			return "option";
		}

		public bool FromXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				if (myElement.HasAttribute("value"))
				{
					Value = myElement.GetAttribute("value");
				}
				else
				{
					Value = myElement.InnerText;
				}
				Text = myElement.InnerText;
				Selected = myElement.HasAttribute("selected");
			}
			return true;
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				myElement.InnerText = Text;
				if (!StringCommon.isBlankString(Value) && Value != Text)
				{
					myElement.SetAttribute("value", Value);
				}
				if (Selected)
				{
					myElement.SetAttribute("selected", "1");
				}
			}
			return true;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
