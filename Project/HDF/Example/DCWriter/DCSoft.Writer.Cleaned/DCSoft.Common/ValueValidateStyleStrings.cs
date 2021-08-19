using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///         一个强类型的资源类，用于查找本地化的字符串等。
	                                                                    ///       </summary>
	[ComVisible(false)]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	public class ValueValidateStyleStrings
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		                                                                    /// <summary>
		                                                                    ///         返回此类使用的缓存的 ResourceManager 实例。
		                                                                    ///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				int num = 14;
				if (object.ReferenceEquals(resourceMan, null))
				{
					ResourceManager resourceManager = resourceMan = new ResourceManager("DCSoft.Common.ValueValidateStyleStrings", typeof(ValueValidateStyleStrings).Assembly);
				}
				return resourceMan;
			}
		}

		                                                                    /// <summary>
		                                                                    ///         使用此强类型资源类，为所有资源查找
		                                                                    ///         重写当前线程的 CurrentUICulture 属性。
		                                                                    ///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///         查找类似 不能包含“{0}”。 的本地化字符串。
		                                                                    ///       </summary>
		public static string CanNotContains_Text => ResourceManager.GetString("CanNotContains_Text", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 文本不包含在列表“{0}”。 的本地化字符串。
		                                                                    ///       </summary>
		public static string ExcludeRange_Range => ResourceManager.GetString("ExcludeRange_Range", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 数据不能为空。 的本地化字符串。
		                                                                    ///       </summary>
		public static string ForbidEmpty => ResourceManager.GetString("ForbidEmpty", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 文本过短，不得少于 {0} 个字符。 的本地化字符串。
		                                                                    ///       </summary>
		public static string LessThanMinLength_Length => ResourceManager.GetString("LessThanMinLength_Length", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 小于最小值 {0}。 的本地化字符串。
		                                                                    ///       </summary>
		public static string LessThanMinValue_Value => ResourceManager.GetString("LessThanMinValue_Value", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 小数位数超过上限，上限为{0}。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MoreThanMaxDemicalDigits => ResourceManager.GetString("MoreThanMaxDemicalDigits", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 文本过长，不得超过 {0} 个字符。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MoreThanMaxLength_Length => ResourceManager.GetString("MoreThanMaxLength_Length", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 超过最大值 {0}。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MoreThanMaxValue_Value => ResourceManager.GetString("MoreThanMaxValue_Value", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 必须为日期时间格式。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MustDateTimeType => ResourceManager.GetString("MustDateTimeType", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 必须为日期格式。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MustDateType => ResourceManager.GetString("MustDateType", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 必须为整数。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MustInteger => ResourceManager.GetString("MustInteger", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 必须符合“{0}”格式。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MustMatch_Expression => ResourceManager.GetString("MustMatch_Expression", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 必须为数值。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MustNumeric => ResourceManager.GetString("MustNumeric", resourceCulture);

		                                                                    /// <summary>
		                                                                    ///         查找类似 必须为时间格式。 的本地化字符串。
		                                                                    ///       </summary>
		public static string MustTimeType => ResourceManager.GetString("MustTimeType", resourceCulture);

		internal ValueValidateStyleStrings()
		{
		}
	}
}
