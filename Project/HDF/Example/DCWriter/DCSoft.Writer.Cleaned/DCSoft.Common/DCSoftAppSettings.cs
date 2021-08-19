using System;
using System.Configuration;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       DCSoft配置文件读取器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class DCSoftAppSettings
	{
		private static bool bool_0 = false;

		private static Configuration configuration_0 = null;

		private static ConfigurationSection configurationSection_0 = null;

		                                                                    /// <summary>
		                                                                    ///       是否抛出异常
		                                                                    ///       </summary>
		public static bool ThrowException
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		private static bool smethod_0()
		{
			try
			{
				if (configuration_0 == null)
				{
					configuration_0 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				}
				return true;
			}
			catch (Exception ex)
			{
				if (bool_0)
				{
					throw ex;
				}
			}
			return false;
		}

		public static string smethod_1(string string_0)
		{
			int num = 19;
			try
			{
				if (smethod_0())
				{
					return configuration_0.AppSettings.Settings["DCSoft_" + string_0]?.Value;
				}
				return null;
			}
			catch (Exception ex)
			{
				if (bool_0)
				{
					throw ex;
				}
			}
			return null;
		}

		public static void smethod_2(string string_0, string string_1)
		{
			int num = 6;
			try
			{
				if (smethod_0())
				{
					KeyValueConfigurationElement keyValueConfigurationElement = configuration_0.AppSettings.Settings["DCSoft_" + string_0];
					if (keyValueConfigurationElement == null)
					{
						keyValueConfigurationElement = new KeyValueConfigurationElement("DCSoft_" + string_0, string_1);
						configuration_0.AppSettings.Settings.Add(keyValueConfigurationElement);
					}
					else
					{
						keyValueConfigurationElement.Value = string_1;
					}
				}
			}
			catch (Exception ex)
			{
				if (bool_0)
				{
					throw ex;
				}
			}
		}

		public static void smethod_3()
		{
			try
			{
				if (smethod_0())
				{
					configuration_0.Save();
				}
			}
			catch (Exception ex)
			{
				if (bool_0)
				{
					throw ex;
				}
			}
		}
	}
}
