using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Provides methods to get attributes from a <see cref="T:System.Type" />, <see cref="T:System.Reflection.MemberInfo" />, <see cref="T:System.Reflection.ParameterInfo" /> or <see cref="T:System.Reflection.Assembly" />.
	///       </summary>
	[ComVisible(false)]
	public class ReflectionAttributeProvider : IAttributeProvider
	{
		private readonly object _attributeProvider;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.ReflectionAttributeProvider" /> class.
		///       </summary>
		/// <param name="attributeProvider">The instance to get attributes for. This parameter should be a <see cref="T:System.Type" />, <see cref="T:System.Reflection.MemberInfo" />, <see cref="T:System.Reflection.ParameterInfo" /> or <see cref="T:System.Reflection.Assembly" />.</param>
		public ReflectionAttributeProvider(object attributeProvider)
		{
			ValidationUtils.ArgumentNotNull(attributeProvider, "attributeProvider");
			_attributeProvider = attributeProvider;
		}

		/// <summary>
		///       Returns a collection of all of the attributes, or an empty collection if there are no attributes.
		///       </summary>
		/// <param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute.</param>
		/// <returns>A collection of <see cref="T:System.Attribute" />s, or an empty collection.</returns>
		public IList<Attribute> GetAttributes(bool inherit)
		{
			return ReflectionUtils.GetAttributes(_attributeProvider, null, inherit);
		}

		/// <summary>
		///       Returns a collection of attributes, identified by type, or an empty collection if there are no attributes.
		///       </summary>
		/// <param name="attributeType">The type of the attributes.</param>
		/// <param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute.</param>
		/// <returns>A collection of <see cref="T:System.Attribute" />s, or an empty collection.</returns>
		public IList<Attribute> GetAttributes(Type attributeType, bool inherit)
		{
			return ReflectionUtils.GetAttributes(_attributeProvider, attributeType, inherit);
		}
	}
}
