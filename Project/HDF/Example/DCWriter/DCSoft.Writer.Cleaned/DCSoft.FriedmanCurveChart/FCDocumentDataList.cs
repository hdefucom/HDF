using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文档数据列表
	///       </summary>
	[Serializable]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	[DocumentComment]
	public class FCDocumentDataList : List<FCDocumentData>
	{
		/// <summary>
		///       根据名称获得数据，没找到则自动创建
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的数据</returns>
		public FCValuePointList GetValuesByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCDocumentData current = enumerator.Current;
					if (current.Name == name)
					{
						return current.Values;
					}
				}
			}
			FCDocumentData fCDocumentData = new FCDocumentData();
			fCDocumentData.Name = name;
			Add(fCDocumentData);
			return fCDocumentData.Values;
		}

		/// <summary>
		///       根据名称获得数据
		///       </summary>
		/// <param name="name">名称</param>
		/// <param name="autoCreate">若对象不存在则自动创建</param>
		/// <returns>获得的数据</returns>
		public FCDocumentData GetDataByName(string name, bool autoCreate)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCDocumentData current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			if (autoCreate)
			{
				FCDocumentData fCDocumentData = new FCDocumentData();
				fCDocumentData.Name = name;
				Add(fCDocumentData);
				return fCDocumentData;
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FCDocumentDataList Clone()
		{
			FCDocumentDataList fCDocumentDataList = new FCDocumentDataList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCDocumentData current = enumerator.Current;
					FCDocumentData fCDocumentData = new FCDocumentData();
					fCDocumentData.Name = current.Name;
					fCDocumentData.Values = current.Values.Clone();
					fCDocumentDataList.Add(fCDocumentData);
				}
			}
			return fCDocumentDataList;
		}
	}
}
