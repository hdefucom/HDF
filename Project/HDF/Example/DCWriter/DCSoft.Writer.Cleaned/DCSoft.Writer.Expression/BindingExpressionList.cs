using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       表达式列表
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class BindingExpressionList : List<BindingExpression>, ICloneable
	{
		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public BindingExpressionList Clone()
		{
			return (BindingExpressionList)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			BindingExpressionList bindingExpressionList = new BindingExpressionList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BindingExpression current = enumerator.Current;
					bindingExpressionList.Add(current.Clone());
				}
			}
			return bindingExpressionList;
		}
	}
}
