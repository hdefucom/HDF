using Open_Newtonsoft_Json.Utilities;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Resolves member mappings for a type, camel casing property names.
	///       </summary>
	[ComVisible(false)]
	public class CamelCasePropertyNamesContractResolver : DefaultContractResolver
	{
		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.CamelCasePropertyNamesContractResolver" /> class.
		///       </summary>
		public CamelCasePropertyNamesContractResolver()
			: base(shareCache: true)
		{
		}

		/// <summary>
		///       Resolves the name of the property.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>The property name camel cased.</returns>
		protected override string ResolvePropertyName(string propertyName)
		{
			return StringUtils.ToCamelCase(propertyName);
		}
	}
}
