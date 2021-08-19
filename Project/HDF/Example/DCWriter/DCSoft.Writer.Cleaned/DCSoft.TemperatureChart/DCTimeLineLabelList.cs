using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文本标签列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCTimeLineLabelList : List<DCTimeLineLabel>
	{
		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCTimeLineLabelList Clone()
		{
			DCTimeLineLabelList dCTimeLineLabelList = new DCTimeLineLabelList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCTimeLineLabel current = enumerator.Current;
					dCTimeLineLabelList.Add(current.Clone());
				}
			}
			return dCTimeLineLabelList;
		}
	}
}
