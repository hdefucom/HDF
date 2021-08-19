using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据点对象列表
	///       </summary>
	[Serializable]
	[DocumentComment]
	[Guid("9544D6F7-8AE0-468E-9EE1-DC15B24531EE")]
	[ComVisible(true)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IValuePointList))]
	[DebuggerDisplay("Count={ Count }")]
	public class FCValuePointList : List<FCValuePoint>, IValuePointList
	{
		private class TimeComparer : IComparer<FCValuePoint>
		{
			public int Compare(FCValuePoint fcvaluePoint_0, FCValuePoint fcvaluePoint_1)
			{
				return DateTime.Compare(fcvaluePoint_0.Time, fcvaluePoint_1.Time);
			}
		}

		private bool _SortInvalidate = true;

		/// <summary>
		///       排序状态无效标记
		///       </summary>
		internal bool SortInvalidate
		{
			get
			{
				return _SortInvalidate;
			}
			set
			{
				_SortInvalidate = value;
			}
		}

		/// <summary>
		///       最大时间
		///       </summary>
		public DateTime MaxDate
		{
			get
			{
				if (base.Count > 0)
				{
					DateTime time = base[base.Count - 1].Time;
					DateTime endTime = base[base.Count - 1].EndTime;
					if (!FriedmanCurveDocument.smethod_4(endTime) && endTime > time)
					{
						return endTime;
					}
					return time;
				}
				return FriedmanCurveDocument.NullDate;
			}
		}

		/// <summary>
		///       最小时间
		///       </summary>
		public DateTime MinDate
		{
			get
			{
				if (base.Count > 0)
				{
					return base[0].Time;
				}
				return FriedmanCurveDocument.NullDate;
			}
		}

		/// <summary>
		///       判断列表中的数据是否为文本类型的数据
		///       </summary>
		internal bool IsTextMode(FCTitleLineInfo info)
		{
			int num = 0;
			int num2 = 0;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCValuePoint current = enumerator.Current;
					if (!string.IsNullOrEmpty(current.Text))
					{
						num++;
						if (num > 5)
						{
							return true;
						}
					}
					else if (!FriedmanCurveDocument.smethod_3(current.Value))
					{
						num2++;
						if (num2 > 5)
						{
							return false;
						}
					}
				}
			}
			if (num > 0 && num2 > 0)
			{
				return num > num2;
			}
			if (info != null)
			{
				if (!string.IsNullOrEmpty(info.ValueDisplayFormat))
				{
					return false;
				}
				return true;
			}
			return true;
		}

		/// <summary>
		///       获得前一个数据点对象
		///       </summary>
		/// <param name="vp">数据点对象</param>
		/// <returns>获得的数据点对象</returns>
		public FCValuePoint GetPrePoint(FCValuePoint fcvaluePoint_0)
		{
			int num = IndexOf(fcvaluePoint_0);
			if (num > 0)
			{
				return base[num - 1];
			}
			return null;
		}

		/// <summary>
		///       获得下一个数据点对象
		///       </summary>
		/// <param name="vp">数据点对象</param>
		/// <returns>获得的数据点对象</returns>
		public FCValuePoint GetNextPoint(FCValuePoint fcvaluePoint_0)
		{
			int num = IndexOf(fcvaluePoint_0);
			if (num >= 0 && num < base.Count - 2)
			{
				return base[num + 1];
			}
			return null;
		}

		internal void CheckSortInvalidate()
		{
			if (_SortInvalidate)
			{
				SortByTime();
			}
		}

		/// <summary>
		///       根据时间和数据添加项目
		///       </summary>
		/// <param name="dtm">时间</param>
		/// <param name="Value">数据</param>
		/// <returns>添加的项目</returns>
		public FCValuePoint AddByTimeValue(DateTime dateTime_0, float Value)
		{
			FCValuePoint fCValuePoint = new FCValuePoint();
			fCValuePoint.Time = dateTime_0;
			fCValuePoint.Value = Value;
			Add(fCValuePoint);
			_SortInvalidate = true;
			return fCValuePoint;
		}

		/// <summary>
		///       根据时间和文本添加项目
		///       </summary>
		/// <param name="dtm">时间</param>
		/// <param name="Text">文本</param>
		/// <returns>添加的项目</returns>
		public FCValuePoint AddByTimeText(DateTime dateTime_0, string Text)
		{
			FCValuePoint fCValuePoint = new FCValuePoint();
			fCValuePoint.Time = dateTime_0;
			fCValuePoint.Text = Text;
			Add(fCValuePoint);
			_SortInvalidate = true;
			return fCValuePoint;
		}

		/// <summary>
		///       根据时间和文本添加项目
		///       </summary>
		/// <param name="dtm">时间</param>
		/// <param name="Text">文本</param>
		/// <param name="Value">数值</param>
		/// <returns>添加的项目</returns>
		public FCValuePoint AddByTimeTextValue(DateTime dateTime_0, string Text, float Value)
		{
			FCValuePoint fCValuePoint = new FCValuePoint();
			fCValuePoint.Time = dateTime_0;
			fCValuePoint.Text = Text;
			fCValuePoint.Value = Value;
			Add(fCValuePoint);
			_SortInvalidate = true;
			return fCValuePoint;
		}

		/// <summary>
		///       根据时间、数据和灯笼数据添加项目
		///       </summary>
		/// <param name="dtm">时间</param>
		/// <param name="Value">数据</param>
		/// <param name="landernValue">灯笼数据</param>
		/// <returns>新增的项目对象</returns>
		public FCValuePoint AddByTimeValueLandernValue(DateTime dateTime_0, float Value, float landernValue)
		{
			FCValuePoint fCValuePoint = new FCValuePoint();
			fCValuePoint.Time = dateTime_0;
			fCValuePoint.Value = Value;
			fCValuePoint.LanternValue = landernValue;
			Add(fCValuePoint);
			_SortInvalidate = true;
			return fCValuePoint;
		}

		internal void BindingDataSource(object datasource, string timeFieldName, string valueFieldName, string lanternFieldName, bool textMode)
		{
			Clear();
			if (datasource == null || string.IsNullOrEmpty(timeFieldName) || string.IsNullOrEmpty(valueFieldName))
			{
				return;
			}
			GClass314 gClass = new GClass314(datasource);
			gClass.method_7();
			while (gClass.method_9())
			{
				FCValuePoint fCValuePoint = new FCValuePoint();
				fCValuePoint.Value = float.NaN;
				fCValuePoint.Time = Convert.ToDateTime(gClass.method_11(timeFieldName));
				fCValuePoint.DataBoundItem = gClass.method_10();
				if (textMode)
				{
					fCValuePoint.Text = Convert.ToString(gClass.method_11(valueFieldName));
				}
				else
				{
					fCValuePoint.Value = ToSingleValue(gClass.method_11(valueFieldName));
				}
				if (!string.IsNullOrEmpty(lanternFieldName))
				{
					fCValuePoint.LanternValue = ToSingleValue(gClass.method_11(lanternFieldName));
				}
				Add(fCValuePoint);
			}
		}

		private float ToSingleValue(object object_0)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return -10000f;
			}
			try
			{
				float num = Convert.ToSingle(object_0);
				if (float.IsNaN(num))
				{
					return -10000f;
				}
				return num;
			}
			catch
			{
				return -10000f;
			}
		}

		/// <summary>
		///       根据数据时间进行元素排序
		///       </summary>
		public void SortByTime()
		{
			Sort(new TimeComparer());
			_SortInvalidate = false;
		}

		internal FCValuePoint GetNearestPoint(DateTime dateTime_0, float maxSecondSpan)
		{
			int nearestPointIndex = GetNearestPointIndex(dateTime_0, maxSecondSpan);
			if (nearestPointIndex >= 0)
			{
				return base[nearestPointIndex];
			}
			return null;
		}

		/// <summary>
		///       获得时间小于等于指定时间的最大的数据点序号
		///       </summary>
		/// <param name="dtm">
		/// </param>
		/// <returns>
		/// </returns>
		internal int GetFloorIndexByTime(DateTime dateTime_0)
		{
			CheckSortInvalidate();
			if (base.Count == 0)
			{
				return -1;
			}
			if (dateTime_0 < MinDate)
			{
				return -1;
			}
			if (dateTime_0 == MinDate)
			{
				return 0;
			}
			if (dateTime_0 >= MaxDate)
			{
				return base.Count - 1;
			}
			int num = 0;
			int num2 = base.Count - 1;
			while (num2 - num > 10)
			{
				int num3 = (num + num2) / 2;
				if (base[num3].Time > dateTime_0)
				{
					num2 = num3;
				}
				else
				{
					num = num3;
				}
			}
			int num4 = num2;
			while (true)
			{
				if (num4 >= num)
				{
					if (base[num4].Time <= dateTime_0)
					{
						break;
					}
					num4--;
					continue;
				}
				return num;
			}
			return num4;
		}

		internal int GetNearestPointIndex(DateTime dateTime_0, float maxSecondSpan)
		{
			if (base.Count == 0)
			{
				return -1;
			}
			if (dateTime_0 <= MinDate)
			{
				if (dateTime_0 >= MinDate.AddSeconds(0f - maxSecondSpan))
				{
					return 0;
				}
				return -1;
			}
			if (dateTime_0 >= MaxDate)
			{
				if (dateTime_0 <= MaxDate.AddSeconds(maxSecondSpan))
				{
					return base.Count - 1;
				}
				return -1;
			}
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			while (num2 - num > 10)
			{
				num3++;
				int num4 = (num + num2) / 2;
				if (base[num4].Time > dateTime_0)
				{
					num2 = num4;
				}
				else
				{
					num = num4;
				}
			}
			long num5 = long.MaxValue;
			int num6 = num;
			int num7 = num;
			while (true)
			{
				if (num7 <= num2)
				{
					num3++;
					long num8 = Math.Abs(base[num7].Time.Ticks - dateTime_0.Ticks);
					if (num8 == 0L)
					{
						break;
					}
					if (num8 < num5)
					{
						num5 = num8;
						num6 = num7;
					}
					num7++;
					continue;
				}
				if (!float.IsNaN(maxSecondSpan))
				{
					DateTime time = base[num6].Time;
					if (Math.Abs((time - dateTime_0).TotalSeconds) > (double)maxSecondSpan)
					{
						return -1;
					}
				}
				return num6;
			}
			return num7;
		}

		internal void GetRange(DateTime startTime, DateTime endTime, ref int startIndex, ref int endIndex)
		{
			startIndex = -1;
			endIndex = -1;
			if (startTime <= MinDate)
			{
				startIndex = 0;
			}
			if (endTime >= MaxDate)
			{
				endIndex = base.Count - 1;
			}
			int num = (int)Math.Ceiling(Math.Log(base.Count, 2.0));
			int num2 = 0;
			int num3 = base.Count - 1;
			int num4 = 0;
			int num5 = base.Count - 1;
			int num6 = 0;
			for (int i = 0; i < num; i++)
			{
				if (startIndex < 0)
				{
					num6 = (num2 + num3) / 2;
					if (base[num6].Time > startTime)
					{
						num2 = num6;
					}
					else
					{
						num3 = num6;
					}
				}
				if (endIndex < 0)
				{
					num6 = (num4 + num5) / 2;
					if (base[num6].Time > endTime)
					{
						num4 = num6;
					}
					else
					{
						num5 = num6;
					}
				}
			}
			if (startIndex < 0)
			{
				for (int i = num2; i <= num3 && base[i].Time <= startTime; i++)
				{
					startIndex = i;
				}
			}
			if (endIndex < 0)
			{
				int i = num5;
				while (i >= num4 && base[i].Time >= endTime)
				{
					endIndex = i;
					i--;
				}
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FCValuePointList Clone()
		{
			FCValuePointList fCValuePointList = new FCValuePointList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCValuePoint current = enumerator.Current;
					fCValuePointList.Add(current.Clone());
				}
			}
			return fCValuePointList;
		}
	}
}
