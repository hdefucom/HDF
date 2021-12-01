using System.Collections;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class EMRRow : ZYTextContainer
	{
		protected ArrayList myCells = new ArrayList();

		protected EMRTable myOwnerTable = null;

		public ArrayList Cells => base.ChildElements;

		internal int ColSpanCount => 0;

		public override int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
			}
		}

		public int RIndex => myOwnerTable.Rows.IndexOf(this);

		public EMRTable OwnerTable
		{
			get
			{
				return myOwnerTable;
			}
			set
			{
				myOwnerTable = value;
				foreach (EMRCell childElement in base.ChildElements)
				{
					childElement.OwnerTable = value;
				}
			}
		}

		public override int Top
		{
			get
			{
				return intTop;
			}
			set
			{
				intTop = value;
			}
		}

		public override bool OwnerWholeLine()
		{
			return false;
		}

		public EMRRow()
		{
			intHeight = 100;
		}

		public override bool isField()
		{
			return false;
		}

		protected override void AddLastElement()
		{
		}

		public override void RefreshLine()
		{
			foreach (EMRCell cell in Cells)
			{
				cell.RefreshLine();
			}
		}

		public override bool RefreshView()
		{
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			return false;
		}

		public override bool FromXML(XmlElement myElement)
		{
			Height = int.Parse(myElement.GetAttribute("height"));
			myChildElements.Clear();
			ArrayList myList = new ArrayList();
			myOwnerDocument.LoadElementsToList(myElement, myList);
			InsertRangeBefore(myList, null);
			return true;
		}
	}
}
