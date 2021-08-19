using System.Collections;
using System.Data;

namespace ZYTextDocumentLib
{
	public class SectionList
	{
		protected class SectionItem
		{
			public string SectionName;

			public string SectionCode;
		}

		private ArrayList myList = new ArrayList();

		public string SelectSQL = "Select * From SectionTable Order By SectionName";

		public int Count => myList.Count;

		public void Clear()
		{
			myList.Clear();
		}

		public string GetSectionName(int index)
		{
			SectionItem sectionItem = (SectionItem)myList[index];
			return sectionItem.SectionName;
		}

		public string GetSectionCode(int index)
		{
			SectionItem sectionItem = (SectionItem)myList[index];
			return sectionItem.SectionCode;
		}

		public string GetSectionName(string strSectionCode)
		{
			foreach (SectionItem my in myList)
			{
				if (my.SectionCode == strSectionCode)
				{
					return my.SectionName;
				}
			}
			return null;
		}

		public string GetSectionCode(string strSectionName)
		{
			foreach (SectionItem my in myList)
			{
				if (my.SectionName == strSectionName)
				{
					return my.SectionCode;
				}
			}
			return null;
		}

		public int IndexOf(string strSectionCode)
		{
			for (int i = 0; i < myList.Count; i++)
			{
				if (((SectionItem)myList[i]).SectionCode == strSectionCode)
				{
					return i;
				}
			}
			return -1;
		}

		public bool Contains(string strSection)
		{
			foreach (SectionItem my in myList)
			{
				if (my.SectionCode == strSection)
				{
					return true;
				}
			}
			return false;
		}

		public void Add(string SectionCode, string SectionName)
		{
			SectionItem sectionItem = new SectionItem();
			sectionItem.SectionCode = SectionCode;
			sectionItem.SectionName = SectionName;
			myList.Add(sectionItem);
		}

		public int FromReader(IDataReader myReader)
		{
			int num = 0;
			if (myReader.FieldCount < 2)
			{
				return -1;
			}
			if (myReader.FieldCount == 2)
			{
				while (myReader.Read())
				{
					SectionItem sectionItem = new SectionItem();
					sectionItem.SectionName = myReader.GetString(1);
					sectionItem.SectionCode = myReader.GetString(0);
					myList.Add(sectionItem);
					num++;
				}
				return num;
			}
			int num2 = -1;
			int num3 = -1;
			for (int i = 0; i < myReader.FieldCount; i++)
			{
				string a = myReader.GetName(i).ToUpper().Trim();
				if (a == "SECTIONNAME")
				{
					num2 = i;
				}
				else if (a == "SECTION" || a == "ZSECTION")
				{
					num3 = i;
				}
			}
			if (num2 == -1 || num3 == -1)
			{
				return -1;
			}
			while (myReader.Read())
			{
				SectionItem sectionItem = new SectionItem();
				sectionItem.SectionName = myReader.GetString(num2);
				sectionItem.SectionCode = myReader.GetString(num3);
				myList.Add(sectionItem);
				num++;
			}
			return num;
		}

		public string[] GetSectionNameArray()
		{
			string[] array = new string[myList.Count];
			for (int i = 0; i < myList.Count; i++)
			{
				array[i] = ((SectionItem)myList[i]).SectionName;
			}
			return array;
		}
	}
}
