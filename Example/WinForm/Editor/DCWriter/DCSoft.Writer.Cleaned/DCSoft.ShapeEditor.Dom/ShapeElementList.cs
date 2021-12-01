using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       元素列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class ShapeElementList : List<ShapeElement>
	{
		/// <summary>
		///       获得指定编号的元素
		///       </summary>
		/// <param name="id">编号</param>
		/// <returns>元素对象</returns>
		public ShapeElement this[string string_0]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ShapeElement current = enumerator.Current;
						if (current.ID == string_0)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       复制对象，但不复制元素
		///       </summary>
		/// <returns>复制品</returns>
		public ShapeElementList Clone()
		{
			ShapeElementList shapeElementList = new ShapeElementList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ShapeElement current = enumerator.Current;
					shapeElementList.Add(current);
				}
			}
			return shapeElementList;
		}
	}
}
