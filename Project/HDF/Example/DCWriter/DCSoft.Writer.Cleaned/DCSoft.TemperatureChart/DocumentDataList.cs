using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文档数据列表
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class DocumentDataList : List<DocumentData>
	{
		/// <summary>
		///       根据名称获得数据，没找到则自动创建
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的数据</returns>
		public ValuePointList GetValuesByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentData current = enumerator.Current;
					if (current.Name == name)
					{
						return current.Values;
					}
				}
			}
			DocumentData documentData = new DocumentData();
			documentData.Name = name;
			Add(documentData);
			return documentData.Values;
		}

		/// <summary>
		///       根据名称获得数据
		///       </summary>
		/// <param name="name">名称</param>
		/// <param name="autoCreate">若对象不存在则自动创建</param>
		/// <returns>获得的数据</returns>
		public DocumentData GetDataByName(string name, bool autoCreate)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentData current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			if (autoCreate)
			{
				DocumentData documentData = new DocumentData();
				documentData.Name = name;
				Add(documentData);
				return documentData;
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DocumentDataList Clone()
		{
			DocumentDataList documentDataList = new DocumentDataList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentData current = enumerator.Current;
					DocumentData documentData = new DocumentData();
					documentData.Name = current.Name;
					documentData.Values = current.Values.Clone();
					documentDataList.Add(documentData);
				}
			}
			return documentDataList;
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		public DocumentData ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		public void ComSetItem(int index, DocumentData item)
		{
			base[index] = item;
		}
	}
}
