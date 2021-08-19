using Open_Newtonsoft_Json.Utilities;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal abstract class PathFilter
	{
		public abstract IEnumerable<JToken> ExecuteFilter(IEnumerable<JToken> current, bool errorWhenNoMatch);

		protected static JToken GetTokenIndex(JToken jtoken_0, bool errorWhenNoMatch, int index)
		{
			int num = 0;
			JArray jArray = jtoken_0 as JArray;
			JConstructor jConstructor = jtoken_0 as JConstructor;
			if (jArray != null)
			{
				if (jArray.Count <= index)
				{
					if (errorWhenNoMatch)
					{
						throw new JsonException(StringUtils.FormatWith("Index {0} outside the bounds of JArray.", CultureInfo.InvariantCulture, index));
					}
					return null;
				}
				return jArray[index];
			}
			if (jConstructor != null)
			{
				if (jConstructor.Count <= index)
				{
					if (errorWhenNoMatch)
					{
						throw new JsonException(StringUtils.FormatWith("Index {0} outside the bounds of JConstructor.", CultureInfo.InvariantCulture, index));
					}
					return null;
				}
				return jConstructor[index];
			}
			if (errorWhenNoMatch)
			{
				throw new JsonException(StringUtils.FormatWith("Index {0} not valid on {1}.", CultureInfo.InvariantCulture, index, jtoken_0.GetType().Name));
			}
			return null;
		}
	}
}
