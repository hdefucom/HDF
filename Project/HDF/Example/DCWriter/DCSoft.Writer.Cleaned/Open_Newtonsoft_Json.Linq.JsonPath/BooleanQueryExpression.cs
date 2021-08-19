using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal class BooleanQueryExpression : QueryExpression
	{
		public List<PathFilter> Path
		{
			get;
			set;
		}

		public JValue Value
		{
			get;
			set;
		}

		public override bool IsMatch(JToken jtoken_0)
		{
			IEnumerable<JToken> enumerable = JPath.Evaluate(Path, jtoken_0, errorWhenNoMatch: false);
			foreach (JToken item in enumerable)
			{
				JValue jValue = item as JValue;
				switch (base.Operator)
				{
				case QueryOperator.Equals:
					if (jValue != null && jValue.Equals(Value))
					{
						return true;
					}
					break;
				case QueryOperator.NotEquals:
					if (!(jValue?.Equals(Value) ?? true))
					{
						return true;
					}
					break;
				case QueryOperator.LessThan:
					if (jValue != null && jValue.CompareTo(Value) < 0)
					{
						return true;
					}
					break;
				case QueryOperator.LessThanOrEquals:
					if (jValue != null && jValue.CompareTo(Value) <= 0)
					{
						return true;
					}
					break;
				case QueryOperator.GreaterThan:
					if (jValue != null && jValue.CompareTo(Value) > 0)
					{
						return true;
					}
					break;
				case QueryOperator.GreaterThanOrEquals:
					if (jValue != null && jValue.CompareTo(Value) >= 0)
					{
						return true;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case QueryOperator.Exists:
					return true;
				}
			}
			return false;
		}
	}
}
