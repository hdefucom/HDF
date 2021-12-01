using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       表达式信息列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class DomExpressionList : List<DomExpression>
	{
		/// <summary>
		///       获得指定名称的表达式对象
		///       </summary>
		/// <param name="name">表达式名称</param>
		/// <returns>表达式对象</returns>
		public DomExpression this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DomExpression current = enumerator.Current;
						if (current.Name == name)
						{
							return current;
						}
					}
				}
				return null;
			}
		}
	}
}
