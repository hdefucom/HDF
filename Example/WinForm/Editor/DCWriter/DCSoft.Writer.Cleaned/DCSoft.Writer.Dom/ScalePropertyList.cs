using DCSoft.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数据标尺刻度信息列表
	///       </summary>
	[DocumentComment]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[XmlType("ScalePropertyList")]
	[DebuggerDisplay("Count={ Count }")]
	public class ScalePropertyList : List<ScaleProperty>
	{
		private class ItemComparaer : IComparer<ScaleProperty>
		{
			public int Compare(ScaleProperty scaleProperty_0, ScaleProperty scaleProperty_1)
			{
				if (scaleProperty_0.Value == scaleProperty_1.Value)
				{
					return 0;
				}
				if (scaleProperty_0.Value > scaleProperty_1.Value)
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
						ScaleProperty current = enumerator.Current;
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
				return num;
			}
		}

		/// <summary>
		///       获得最小值
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
						ScaleProperty current = enumerator.Current;
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
				return num;
			}
		}

		internal ScaleProperty GetScaleInfoByValue(float Value)
		{
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
			ScaleProperty scaleProperty = new ScaleProperty();
			scaleProperty.Value = Value;
			scaleProperty.ScaleRate = scaleRate;
			Add(scaleProperty);
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
