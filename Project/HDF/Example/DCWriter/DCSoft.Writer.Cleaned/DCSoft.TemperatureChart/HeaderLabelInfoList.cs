using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       标题信息列表
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[Guid("980DE57B-E04E-450A-9292-0B1621469B4B")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IHeaderLabelInfoList))]
	[DocumentComment]
	public class HeaderLabelInfoList : List<HeaderLabelInfo>, IHeaderLabelInfoList
	{
		/// <summary>
		///       添加对象
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="dataSourceName">数据源名</param>
		/// <returns>新添加的对象</returns>
		public HeaderLabelInfo AddItemByDataSourceName(string title, string dataSourceName)
		{
			HeaderLabelInfo headerLabelInfo = new HeaderLabelInfo();
			headerLabelInfo.Title = title;
			headerLabelInfo.DataSourceName = dataSourceName;
			Add(headerLabelInfo);
			return headerLabelInfo;
		}

		/// <summary>
		///       添加对象
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="Value">数据</param>
		/// <returns>新添加的对象</returns>
		public HeaderLabelInfo AddItemByValue(string title, string Value)
		{
			HeaderLabelInfo headerLabelInfo = new HeaderLabelInfo();
			headerLabelInfo.Title = title;
			headerLabelInfo.Value = Value;
			Add(headerLabelInfo);
			return headerLabelInfo;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public HeaderLabelInfoList Clone()
		{
			HeaderLabelInfoList headerLabelInfoList = new HeaderLabelInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HeaderLabelInfo current = enumerator.Current;
					headerLabelInfoList.Add(current.Clone());
				}
			}
			return headerLabelInfoList;
		}
	}
}
