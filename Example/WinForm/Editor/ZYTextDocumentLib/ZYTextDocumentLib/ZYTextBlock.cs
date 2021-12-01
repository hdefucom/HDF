using System.Collections.Generic;
using System.Drawing;

namespace ZYTextDocumentLib
{
	public class ZYTextBlock : ZYTextContainer
	{
		protected bool bolStandOutBack = false;

		public bool KeyField
		{
			get
			{
				return myAttributes.GetString("keyfield") != "0";
			}
			set
			{
				myAttributes.SetValue("keyfield", value ? "1" : "0");
			}
		}

		public override bool Locked
		{
			get
			{
				return myParent.Locked;
			}
			set
			{
				base.Locked = value;
			}
		}

		public override bool Block => true;

		public override bool isNewLine()
		{
			return false;
		}

		public override bool isNewParagraph()
		{
			return false;
		}

		public override bool OwnerWholeLine()
		{
			return false;
		}

		public override void ResetViewState()
		{
			bolStandOutBack = false;
			if (myOwnerDocument.Content.SelectLength == 0 && (myOwnerDocument.Content.CurrentElement == this || myChildElements.Contains(myOwnerDocument.Content.CurrentElement) || myOwnerDocument.CurrentHoverElement == this))
			{
				bolStandOutBack = true;
			}
		}

		public override Rectangle GetContentBounds()
		{
			Rectangle a = Rectangle.Empty;
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				a = ((!a.IsEmpty) ? Rectangle.Union(a, myChildElement.Bounds) : Bounds);
			}
			return Rectangle.Union(a, Bounds);
		}

		public override void AddElementToList(List<ZYTextElement> myList, bool ResetFlag)
		{
			if (ResetFlag)
			{
				base.Visible = false;
				Index = -1;
			}
			if (myOwnerDocument.isVisible(this))
			{
				base.Visible = true;
				myList.Add(this);
				base.AddElementToList(myList, ResetFlag);
			}
		}

		public override void HandleEnter()
		{
			RefreshForSelect();
		}

		public override void HandleLeave()
		{
			RefreshForSelect();
		}

		private void RefreshForSelect()
		{
			bool flag = bolStandOutBack;
			ResetViewState();
			if (flag != bolStandOutBack)
			{
				myOwnerDocument.RefreshElement(this);
			}
		}

		public override bool isTextElement()
		{
			return true;
		}

		public override bool RefreshView()
		{
			DrawBackGround(this);
			return true;
		}
	}
}
