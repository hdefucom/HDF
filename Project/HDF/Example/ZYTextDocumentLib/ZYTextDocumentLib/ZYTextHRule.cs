using System.Drawing;

namespace ZYTextDocumentLib
{
	public class ZYTextHRule : ZYTextElement
	{
		public Color ForeColor
		{
			get
			{
				return myAttributes.GetColor("forecolor");
			}
			set
			{
				myAttributes.SetValue("forecolor", value);
			}
		}

		public int LineHeight
		{
			get
			{
				return myAttributes.GetInt32("height");
			}
			set
			{
				if (value >= 1 && value <= 10)
				{
					myAttributes.SetValue("height", value);
				}
			}
		}

		public override bool isField()
		{
			return false;
		}

		public override bool isTextElement()
		{
			return false;
		}

		public override string ToEMRString()
		{
			return "";
		}

		public override bool isNewLine()
		{
			return true;
		}

		public override bool OwnerWholeLine()
		{
			return true;
		}

		public override string GetXMLName()
		{
			return "hr";
		}

		public override bool RefreshSize()
		{
			Width = myParent.GetClientWidth();
			Height = myOwnerDocument.DefaultRowHeight;
			return true;
		}

		public override bool RefreshView()
		{
			int num = LineHeight;
			if (num <= 0)
			{
				num = 1;
			}
			Pen myPen = myOwnerDocument.View._CreatePen(ForeColor, num);
			int num2 = RealTop + (Height - num) / 2 + 1;
			myOwnerDocument.View.DrawLine(myPen, RealLeft + 10, num2, RealLeft + Width - 10, num2);
			return true;
		}

		public ZYTextHRule()
		{
			LineHeight = 1;
		}
	}
}
