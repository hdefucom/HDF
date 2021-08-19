using Open_Newtonsoft_Json.Utilities;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Get and set values for a <see cref="T:System.Reflection.MemberInfo" /> using dynamic methods.
	///       </summary>
	[ComVisible(false)]
	public class DynamicValueProvider : IValueProvider
	{
		private readonly MemberInfo _memberInfo;

		private Func<object, object> _getter;

		private Action<object, object> _setter;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.DynamicValueProvider" /> class.
		///       </summary>
		/// <param name="memberInfo">The member info.</param>
		public DynamicValueProvider(MemberInfo memberInfo)
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
			int num = 14;
			try
			{
				if (_setter == null)
				{
					_setter = DynamicReflectionDelegateFactory.Instance.CreateSet<object>(_memberInfo);
				}
				if (value == null)
				{
					if (!ReflectionUtils.IsNullable(ReflectionUtils.GetMemberUnderlyingType(_memberInfo)))
					{
						throw new JsonSerializationException(StringUtils.FormatWith("Incompatible value. Cannot set {0} to null.", CultureInfo.InvariantCulture, _memberInfo));
					}
				}
				else if (!ReflectionUtils.GetMemberUnderlyingType(_memberInfo).IsAssignableFrom(value.GetType()))
				{
					throw new JsonSerializationException(StringUtils.FormatWith("Incompatible value. Cannot set {0} to type {1}.", CultureInfo.InvariantCulture, _memberInfo, value.GetType()));
				}
				_setter(target, value);
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
			int num = 4;
			try
			{
				if (_getter == null)
				{
					_getter = DynamicReflectionDelegateFactory.Instance.CreateGet<object>(_memberInfo);
				}
				return _getter(target);
			}
			catch (Exception innerException)
			{
				throw new JsonSerializationException(StringUtils.FormatWith("Error getting value from '{0}' on '{1}'.", CultureInfo.InvariantCulture, _memberInfo.Name, target.GetType()), innerException);
			}
		}
	}
}
