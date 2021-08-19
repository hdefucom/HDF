using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间轴区域信息列表
	///       </summary>
	[Serializable]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DocumentComment]
	[ComVisible(false)]
	[DebuggerDisplay("Count={ Count }")]
	public class TimeLineZoneInfoList : List<TimeLineZoneInfo>
	{
		private class ZoneComparer : IComparer<TimeLineZoneInfo>
		{
			public int Compare(TimeLineZoneInfo timeLineZoneInfo_0, TimeLineZoneInfo timeLineZoneInfo_1)
			{
				return timeLineZoneInfo_0.StartTime.CompareTo(timeLineZoneInfo_1.StartTime);
			}
		}

		/// <summary>
		///       获得指定名称的区域对象，名称区分大小写
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的对象</returns>
		public TimeLineZoneInfo GetByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TimeLineZoneInfo current = enumerator.Current;
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
					TimeLineZoneInfo current = enumerator.Current;
					current.ParentZone = null;
				}
			}
			for (int i = 0; i < base.Count; i++)
			{
				TimeLineZoneInfo current = base[i];
				current.ZoneIndex = i;
				for (int j = i + 1; j < base.Count; j++)
				{
					TimeLineZoneInfo timeLineZoneInfo = base[j];
					if (timeLineZoneInfo.StartTime < current.EndTime)
					{
						timeLineZoneInfo.ParentZone = current;
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
		public TimeLineZoneInfo GetZone(DateTime dateTime_0)
		{
			int num = base.Count - 1;
			TimeLineZoneInfo timeLineZoneInfo;
			while (true)
			{
				if (num >= 0)
				{
					timeLineZoneInfo = base[num];
					if (!TemperatureDocument.smethod_4(timeLineZoneInfo.StartTime) && dateTime_0 >= timeLineZoneInfo.StartTime && (TemperatureDocument.smethod_4(timeLineZoneInfo.EndTime) || !(dateTime_0 >= timeLineZoneInfo.EndTime)))
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return timeLineZoneInfo;
		}
	}
}
