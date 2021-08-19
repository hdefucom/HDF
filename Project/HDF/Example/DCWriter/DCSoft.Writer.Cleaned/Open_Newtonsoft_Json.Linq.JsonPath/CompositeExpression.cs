using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal class CompositeExpression : QueryExpression
	{
		public List<QueryExpression> Expressions
		{
			get;
			set;
		}

		public CompositeExpression()
		{
			Expressions = new List<QueryExpression>();
		}

		public override bool IsMatch(JToken jtoken_0)
		{
			switch (base.Operator)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case QueryOperator.And:
				foreach (QueryExpression expression in Expressions)
				{
					if (!expression.IsMatch(jtoken_0))
					{
						return false;
					}
				}
				return true;
			case QueryOperator.Or:
				foreach (QueryExpression expression2 in Expressions)
				{
					if (expression2.IsMatch(jtoken_0))
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
