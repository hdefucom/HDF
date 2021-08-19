using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文本标签列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCFriedmanCurveLabelList : List<DCFriedmanCurveLabel>
	{
		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCFriedmanCurveLabelList Clone()
		{
			DCFriedmanCurveLabelList dCFriedmanCurveLabelList = new DCFriedmanCurveLabelList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCFriedmanCurveLabel current = enumerator.Current;
					dCFriedmanCurveLabelList.Add(current.Clone());
				}
			}
			return dCFriedmanCurveLabelList;
		}
	}
}
