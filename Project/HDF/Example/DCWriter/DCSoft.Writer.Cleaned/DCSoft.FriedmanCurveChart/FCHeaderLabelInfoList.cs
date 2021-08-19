using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       标题信息列表
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComDefaultInterface(typeof(IHeaderLabelInfoList))]
	[Guid("28C01300-4682-4408-A713-40B4DE088493")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public class FCHeaderLabelInfoList : List<FCHeaderLabelInfo>, IHeaderLabelInfoList
	{
		/// <summary>
		///       添加对象
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="dataSourceName">数据源名</param>
		/// <returns>新添加的对象</returns>
		public FCHeaderLabelInfo AddItemByDataSourceName(string title, string dataSourceName)
		{
			FCHeaderLabelInfo fCHeaderLabelInfo = new FCHeaderLabelInfo();
			fCHeaderLabelInfo.Title = title;
			fCHeaderLabelInfo.DataSourceName = dataSourceName;
			Add(fCHeaderLabelInfo);
			return fCHeaderLabelInfo;
		}

		/// <summary>
		///       添加对象
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="Value">数据</param>
		/// <returns>新添加的对象</returns>
		public FCHeaderLabelInfo AddItemByValue(string title, string Value)
		{
			FCHeaderLabelInfo fCHeaderLabelInfo = new FCHeaderLabelInfo();
			fCHeaderLabelInfo.Title = title;
			fCHeaderLabelInfo.Value = Value;
			Add(fCHeaderLabelInfo);
			return fCHeaderLabelInfo;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FCHeaderLabelInfoList Clone()
		{
			FCHeaderLabelInfoList fCHeaderLabelInfoList = new FCHeaderLabelInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCHeaderLabelInfo current = enumerator.Current;
					fCHeaderLabelInfoList.Add(current.Clone());
				}
			}
			return fCHeaderLabelInfoList;
		}
	}
}
