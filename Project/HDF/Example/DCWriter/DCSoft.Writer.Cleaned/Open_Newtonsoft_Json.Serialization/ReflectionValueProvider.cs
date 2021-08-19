using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Get and set values for a <see cref="T:System.Reflection.MemberInfo" /> using reflection.
	///       </summary>
	[ComVisible(false)]
	public class ReflectionValueProvider : IValueProvider
	{
		private readonly MemberInfo _memberInfo;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.ReflectionValueProvider" /> class.
		///       </summary>
		/// <param name="memberInfo">The member info.</param>
		public ReflectionValueProvider(MemberInfo memberInfo)
		{
			ValidationUtils.ArgumentNotNull(memberInfo, "memberInfo");
			_memberInfo = memberInfo;
		}

		/// <summary>
		///       Sets the value.
		///       </summary>
		/// <param name="target">The target to set the value on.</param>
		/// <param name="value">The value to set on the target.</param>
		public void SetValue(object target, object value)
		{
			int num = 11;
			try
			{
				ReflectionUtils.SetMemberValue(_memberInfo, target, value);
			}
			catch (Exception innerException)
			{
				throw new JsonSerializationException(StringUtils.FormatWith("Error setting value to '{0}' on '{1}'.", CultureInfo.InvariantCulture, _memberInfo.Name, target.GetType()), innerException);
			}
		}

		/// <summary>
		///       Gets the value.
		///       </summary>
		/// <param name="target">The target to get the value from.</param>
		/// <returns>The value.</returns>
		public object GetValue(object target)
		{
			int num = 17;
			try
			{
				return ReflectionUtils.GetMemberValue(_memberInfo, target);
			}
			catch (Exception innerException)
			{
				throw new JsonSerializationException(StringUtils.FormatWith("Error getting value from '{0}' on '{1}'.", CultureInfo.InvariantCulture, _memberInfo.Name, target.GetType()), innerException);
			}
		}
	}
}
