using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据标尺刻度信息列表
	///       </summary>
	[Serializable]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IYAxisScaleInfoList))]
	[DebuggerDisplay("Count={ Count }")]
	[Guid("377F6925-6D91-4C37-92A4-16CEC22EA42D")]
	[DocumentComment]
	public class FCYAxisScaleInfoList : List<FCYAxisScaleInfo>, IYAxisScaleInfoList
	{
		private class ItemComparaer : IComparer<FCYAxisScaleInfo>
		{
			public int Compare(FCYAxisScaleInfo fcyaxisScaleInfo_0, FCYAxisScaleInfo fcyaxisScaleInfo_1)
			{
				if (fcyaxisScaleInfo_0.Value == fcyaxisScaleInfo_1.Value)
				{
					return 0;
				}
				if (fcyaxisScaleInfo_0.Value > fcyaxisScaleInfo_1.Value)
				{
					return 1;
				}
				return -1;
			}
		}

		/// <summary>
		///       获得最大值
		///       </summary>
		internal float MaxValue
		{
			get
			{
				float num = float.NaN;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IYAxisScaleInfo current = enumerator.Current;
						if (!FriedmanCurveDocument.smethod_3(current.Value))
						{
							if (float.IsNaN(num))
							{
								num = current.Value;
							}
							else if (num < current.Value)
							{
								num = current.Value;
							}
						}
					}
				}
				return num;
			}
		}

		/// <summary>
		///       获得最大值
		///       </summary>
		internal float MinValue
		{
			get
			{
				float num = float.NaN;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IYAxisScaleInfo current = enumerator.Current;
						if (!FriedmanCurveDocument.smethod_3(current.Value))
						{
							if (float.IsNaN(num))
							{
								num = current.Value;
							}
							else if (num > current.Value)
							{
								num = current.Value;
							}
						}
					}
				}
				return num;
			}
		}

		internal FCYAxisScaleInfo GetScaleInfoByValue(float Value)
		{
			if (FriedmanCurveDocument.smethod_3(Value) || base.Count == 0)
			{
				return null;
			}
			if (base.Count == 1)
			{
				return base[0];
			}
			int num = base.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (base[num].Value <= Value)
					{
						break;
					}
					num--;
					continue;
				}
				return base[0];
			}
			return base[num];
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="Value">
		/// </param>
		/// <param name="scaleRate">
		/// </param>
		public void AddItem(float Value, float scaleRate)
		{
			FCYAxisScaleInfo fCYAxisScaleInfo = new FCYAxisScaleInfo();
			fCYAxisScaleInfo.Value = Value;
			fCYAxisScaleInfo.ScaleRate = scaleRate;
			Add(fCYAxisScaleInfo);
		}

		/// <summary>
		///       根据数值进行排序
		///       </summary>
		public void SortByValue()
		{
			Sort(new ItemComparaer());
		}
	}
}
