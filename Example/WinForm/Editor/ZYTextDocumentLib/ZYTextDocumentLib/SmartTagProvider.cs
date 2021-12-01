using System.Collections;
using System.Drawing;

namespace ZYTextDocumentLib
{
	public abstract class SmartTagProvider
	{
		public ZYTextDocument OwnerDocument;

		public ZYEditorControl OwnerControl;

		public ZYTextElement Element;

		public virtual int ImageIndex => 0;

		public virtual Point GetPos()
		{
			if (Element != null)
			{
				return new Point(Element.RealLeft + Element.Width + 6, Element.RealTop + Element.Height + 6);
			}
			return Point.Empty;
		}

		public virtual bool isEnable()
		{
			return false;
		}

		public virtual void GetCommands(ArrayList myList)
		{
		}

		public virtual bool HandleCommand(SmartTagItem item)
		{
			return false;
		}
	}
}
