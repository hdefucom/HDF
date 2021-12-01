using System.Collections;
using System.Windows.Forms;

namespace ZYCommon
{
	public class EMRTabPageCollection : CollectionBase
	{
		internal EMRTabControl OwnerTabControl = null;

		public EMRTabPage this[int index]
		{
			get
			{
				return (EMRTabPage)base.InnerList[index];
			}
			set
			{
				base.InnerList[index] = value;
			}
		}

		public EMRTabPage LastPage
		{
			get
			{
				if (base.InnerList.Count > 0)
				{
					return (EMRTabPage)base.InnerList[base.InnerList.Count - 1];
				}
				return null;
			}
		}

		public EMRTabPage Add(string vText)
		{
			EMRTabPage eMRTabPage = new EMRTabPage();
			eMRTabPage.Text = vText;
			eMRTabPage.BorderStyle = BorderStyle.Fixed3D;
			base.InnerList.Add(eMRTabPage);
			if (OwnerTabControl != null)
			{
				OwnerTabControl.UpdatePages();
			}
			return eMRTabPage;
		}

		public EMRTabPage Add()
		{
			return Add(null);
		}

		public void AddRange(EMRTabPage[] values)
		{
			foreach (EMRTabPage value in values)
			{
				base.InnerList.Add(value);
			}
			if (OwnerTabControl != null)
			{
				OwnerTabControl.UpdatePages();
			}
		}

		public void Remove(EMRTabPage p)
		{
			base.InnerList.Remove(p);
		}

		public void Insert(int index, EMRTabPage p)
		{
			base.InnerList.Insert(index, p);
		}

		public bool Contains(EMRTabPage p)
		{
			return base.InnerList.Contains(p);
		}

		public int IndexOf(EMRTabPage p)
		{
			if (p == null)
			{
				return -1;
			}
			return base.InnerList.IndexOf(p);
		}

		public EMRTabPage[] ToArray()
		{
			EMRTabPage[] array = new EMRTabPage[base.InnerList.Count];
			for (int i = 0; i < base.InnerList.Count; i++)
			{
				array[i] = (EMRTabPage)base.InnerList[i];
			}
			return array;
		}
	}
}
