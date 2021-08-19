using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       产程图区域信息列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[DocumentComment]
	public class FriedmanCurveZoneInfoList : List<FriedmanCurveZoneInfo>
	{
		private class ZoneComparer : IComparer<FriedmanCurveZoneInfo>
		{
			public int Compare(FriedmanCurveZoneInfo friedmanCurveZoneInfo_0, FriedmanCurveZoneInfo friedmanCurveZoneInfo_1)
			{
				return friedmanCurveZoneInfo_0.StartTime.CompareTo(friedmanCurveZoneInfo_1.StartTime);
			}
		}

		/// <summary>
		///       获得指定名称的区域对象，名称区分大小写
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的对象</returns>
		public FriedmanCurveZoneInfo GetByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FriedmanCurveZoneInfo current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       刷新状态
		///       </summary>
		public void RefreshState()
		{
			Sort(new ZoneComparer());
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FriedmanCurveZoneInfo current = enumerator.Current;
					current.ParentZone = null;
				}
			}
			for (int i = 0; i < base.Count; i++)
			{
				FriedmanCurveZoneInfo current = base[i];
				current.ZoneIndex = i;
				for (int j = i + 1; j < base.Count; j++)
				{
					FriedmanCurveZoneInfo friedmanCurveZoneInfo = base[j];
					if (friedmanCurveZoneInfo.StartTime < current.EndTime)
					{
						friedmanCurveZoneInfo.ParentZone = current;
						break;
					}
				}
			}
		}

		/// <summary>
		///       获得指定时间所在的时间区域对象
		///       </summary>
		/// <param name="dtm">时间</param>
		/// <returns>获得的区域对象</returns>
		public FriedmanCurveZoneInfo GetZone(DateTime dateTime_0)
		{
			int num = base.Count - 1;
			FriedmanCurveZoneInfo friedmanCurveZoneInfo;
			while (true)
			{
				if (num >= 0)
				{
					friedmanCurveZoneInfo = base[num];
					if (!FriedmanCurveDocument.smethod_4(friedmanCurveZoneInfo.StartTime) && dateTime_0 >= friedmanCurveZoneInfo.StartTime && (FriedmanCurveDocument.smethod_4(friedmanCurveZoneInfo.EndTime) || !(dateTime_0 >= friedmanCurveZoneInfo.EndTime)))
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return friedmanCurveZoneInfo;
		}
	}
}
