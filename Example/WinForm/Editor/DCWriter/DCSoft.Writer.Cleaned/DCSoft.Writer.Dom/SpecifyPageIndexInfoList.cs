using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       指定页码信息列表
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(ISpecifyPageIndexInfoList))]
	[DCPublishAPI]
	[ComVisible(true)]
	[ComClass("CC5E620A-FAC6-4F82-9605-6E1B74AB45AC", "90DD9F88-9BAF-4F4B-AA06-D75BFF97BA93")]
	[DocumentComment]
	[Guid("CC5E620A-FAC6-4F82-9605-6E1B74AB45AC")]
	[ClassInterface(ClassInterfaceType.None)]
	public class SpecifyPageIndexInfoList : List<SpecifyPageIndexInfo>, IDCStringSerializable, ISpecifyPageIndexInfoList
	{
		private class MyComparer : IComparer<SpecifyPageIndexInfo>
		{
			public int Compare(SpecifyPageIndexInfo specifyPageIndexInfo_0, SpecifyPageIndexInfo specifyPageIndexInfo_1)
			{
				return specifyPageIndexInfo_0.RawPageIndex - specifyPageIndexInfo_1.RawPageIndex;
			}
		}

		internal const string CLASSID = "CC5E620A-FAC6-4F82-9605-6E1B74AB45AC";

		internal const string CLASSID_Interface = "90DD9F88-9BAF-4F4B-AA06-D75BFF97BA93";

		public void SetValue(int pageIndex, int specifyPageIndex)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SpecifyPageIndexInfo current = enumerator.Current;
					if (current.RawPageIndex == pageIndex)
					{
						current.SpecifyPageIndex = specifyPageIndex;
						return;
					}
				}
			}
			SpecifyPageIndexInfo specifyPageIndexInfo = new SpecifyPageIndexInfo();
			specifyPageIndexInfo.RawPageIndex = pageIndex;
			specifyPageIndexInfo.SpecifyPageIndex = specifyPageIndex;
			Add(specifyPageIndexInfo);
		}

		internal void SortItems()
		{
			Sort(new MyComparer());
		}

		[DCInternal]
		public string DCWriteString()
		{
			int num = 9;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SpecifyPageIndexInfo current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(current.RawPageIndex + "=" + current.SpecifyPageIndex);
				}
			}
			return stringBuilder.ToString();
		}

		[DCInternal]
		public void DCReadString(string text)
		{
			Clear();
			if (text == null)
			{
				return;
			}
			string[] array = text.Split(';');
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				int num = text2.IndexOf('=');
				if (num > 0)
				{
					int result = 0;
					int result2 = 0;
					if (int.TryParse(text2.Substring(0, num), out result) && int.TryParse(text2.Substring(num + 1), out result2))
					{
						SpecifyPageIndexInfo specifyPageIndexInfo = new SpecifyPageIndexInfo();
						specifyPageIndexInfo.RawPageIndex = result;
						specifyPageIndexInfo.SpecifyPageIndex = result2;
						Add(specifyPageIndexInfo);
					}
				}
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public SpecifyPageIndexInfoList Clone()
		{
			SpecifyPageIndexInfoList specifyPageIndexInfoList = new SpecifyPageIndexInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SpecifyPageIndexInfo current = enumerator.Current;
					specifyPageIndexInfoList.Add(current.Clone());
				}
			}
			return specifyPageIndexInfoList;
		}
	}
}
