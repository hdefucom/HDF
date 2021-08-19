using System.Collections;
using System.Drawing;

namespace ZYTextDocumentLib
{
	public class ParagraphTagProvider : SmartTagProvider
	{
		public override int ImageIndex => 17;

		public override bool isEnable()
		{
			return Element is ZYTextParagraph;
		}

		public override Point GetPos()
		{
			return new Point(Element.RealLeft + Element.Width + 6, Element.RealTop);
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextParagraph zYTextParagraph = Element as ZYTextParagraph;
			if (zYTextParagraph != null)
			{
				myList.Add(new SmartTagItem("-"));
				myList.Add(new SmartTagItem(this, 2, zYTextParagraph.LeftAlign, "左对齐"));
				myList.Add(new SmartTagItem(this, 3, zYTextParagraph.CenterAlign, "居中对齐"));
				myList.Add(new SmartTagItem(this, 4, zYTextParagraph.RightAlign, "右对齐"));
				myList.Add(new SmartTagItem(this, 5, zYTextParagraph.JustifyAlign, "两边对齐"));
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextParagraph zYTextParagraph = OwnerDocument.Content.CurrentElement as ZYTextParagraph;
			if (zYTextParagraph != null)
			{
				switch (item.ID)
				{
				case 2:
					OwnerDocument.BeginContentChangeLog();
					zYTextParagraph.LeftAlign = true;
					OwnerDocument.EndContentChangeLog();
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				case 3:
					OwnerDocument.BeginContentChangeLog();
					zYTextParagraph.CenterAlign = true;
					OwnerDocument.EndContentChangeLog();
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				case 4:
					OwnerDocument.BeginContentChangeLog();
					zYTextParagraph.RightAlign = true;
					OwnerDocument.EndContentChangeLog();
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				case 5:
					OwnerDocument.BeginContentChangeLog();
					zYTextParagraph.JustifyAlign = true;
					OwnerDocument.EndContentChangeLog();
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				}
			}
			return false;
		}
	}
}
