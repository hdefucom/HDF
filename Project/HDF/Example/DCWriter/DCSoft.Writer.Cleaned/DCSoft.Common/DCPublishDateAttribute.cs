using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       表示发布日期的特性
	                                                                    ///       </summary>
	[AttributeUsage(AttributeTargets.All)]
	[ComVisible(false)]
	public class DCPublishDateAttribute : Attribute
	{
		private DateTime _Value = DateTime.MinValue;

		private static Dictionary<Assembly, DateTime> _Values = new Dictionary<Assembly, DateTime>();

		private static DateTime _ValueForCurrentDomain = DateTime.MinValue;

		                                                                    /// <summary>
		                                                                    ///       日期数值
		                                                                    ///       </summary>
		[Description("日期数值")]
		public DateTime Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       当前程序域中所有加载的程序集中的发布日期数值
		                                                                    ///       </summary>
		public static DateTime ValueForCurrentDomain
		{
			get
			{
				int num = 13;
				if (_ValueForCurrentDomain == DateTime.MinValue)
				{
					_ValueForCurrentDomain = DateTime.MaxValue;
					Assembly assembly = Assembly.GetCallingAssembly();
					if (assembly == null)
					{
						assembly = typeof(DCPublishDateAttribute).Assembly;
					}
					DCPublishDateAttribute dCPublishDateAttribute = (DCPublishDateAttribute)Attribute.GetCustomAttribute(assembly, typeof(DCPublishDateAttribute), inherit: true);
					if (dCPublishDateAttribute != null)
					{
						_ValueForCurrentDomain = dCPublishDateAttribute.Value;
					}
					else
					{
						Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
						foreach (Assembly assembly2 in assemblies)
						{
							try
							{
								if (!assembly2.ReflectionOnly && !(assembly2 is AssemblyBuilder) && !(assembly2.GetType().Namespace == "System.Reflection.Emit"))
								{
									DCPublishDateAttribute dCPublishDateAttribute2 = (DCPublishDateAttribute)Attribute.GetCustomAttribute(assembly2, typeof(DCPublishDateAttribute), inherit: true);
									if (dCPublishDateAttribute2 != null)
									{
										_ValueForCurrentDomain = dCPublishDateAttribute2.Value;
										goto IL_010f;
									}
								}
							}
							catch
							{
							}
						}
					}
				}
				goto IL_010f;
				IL_010f:
				return _ValueForCurrentDomain;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="year">年</param>
		                                                                    /// <param name="month">月</param>
		                                                                    /// <param name="day">日</param>
		public DCPublishDateAttribute(int year, int month, int int_0)
		{
			_Value = new DateTime(year, month, int_0);
		}

		                                                                    /// <summary>
		                                                                    ///       返回日期字符串
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public override string ToString()
		{
			return FormatUtils.ToYYYY_MM_DD_HH_MM_SS(_Value);
		}

		public static DateTime GetValue(Assembly assembly_0)
		{
			DateTime value = DateTime.MinValue;
			if (!_Values.TryGetValue(assembly_0, out value))
			{
				DCPublishDateAttribute dCPublishDateAttribute = (DCPublishDateAttribute)Attribute.GetCustomAttribute(assembly_0, typeof(DCPublishDateAttribute), inherit: true);
				if (dCPublishDateAttribute != null)
				{
					value = dCPublishDateAttribute.Value;
				}
				_Values[assembly_0] = value;
			}
			return value;
		}
	}
}
