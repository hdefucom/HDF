using DCSoft.Common;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       全局性的调试配置信息
	///       </summary>
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(false)]
	public class GlobalDebugConfig
	{
		private bool _Enable = false;

		private bool _RealTimeLoad = true;

		private bool _ShowMessageWhenCreateControl = false;

		private bool _ShowMessageWhenDisposeControl = false;

		private static GlobalDebugConfig _EmptyInstance = new GlobalDebugConfig();

		private static GlobalDebugConfig _Instance = null;

		/// <summary>
		///       是否启用该功能
		///       </summary>
		[DefaultValue(false)]
		public bool Enable
		{
			get
			{
				return _Enable;
			}
			set
			{
				_Enable = value;
			}
		}

		/// <summary>
		///       实时加载
		///       </summary>
		[DefaultValue(true)]
		public bool RealTimeLoad
		{
			get
			{
				return _RealTimeLoad;
			}
			set
			{
				_RealTimeLoad = value;
			}
		}

		/// <summary>
		///       创建控件时显示消息
		///       </summary>
		[DefaultValue(false)]
		public bool ShowMessageWhenCreateControl
		{
			get
			{
				return _ShowMessageWhenCreateControl;
			}
			set
			{
				_ShowMessageWhenCreateControl = value;
			}
		}

		/// <summary>
		///       创建控件时显示消息
		///       </summary>
		[DefaultValue(false)]
		public bool ShowMessageWhenDisposeControl
		{
			get
			{
				return _ShowMessageWhenDisposeControl;
			}
			set
			{
				_ShowMessageWhenDisposeControl = value;
			}
		}

		public static string FileName => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DCSoft.GlobalDebugConfig.xml");

		/// <summary>
		///       对象唯一静态对象实例
		///       </summary>
		public static GlobalDebugConfig Instance
		{
			get
			{
				if (_Instance == null)
				{
					try
					{
						if (File.Exists(FileName))
						{
							_Instance = (GlobalDebugConfig)XMLHelper.LoadObjectFromXMLFile(typeof(GlobalDebugConfig), FileName);
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
						_Instance = new GlobalDebugConfig();
					}
					if (_Instance == null)
					{
						_Instance = new GlobalDebugConfig();
					}
				}
				return _Instance;
			}
		}

		public void Save()
		{
			XMLHelper.SaveObjectToXMLFile(this, FileName);
		}

		public static GlobalDebugConfig CreateInstance()
		{
			if (Instance.Enable)
			{
				if (!Instance.RealTimeLoad)
				{
					return Instance;
				}
				GlobalDebugConfig globalDebugConfig = null;
				try
				{
					if (File.Exists(FileName))
					{
						globalDebugConfig = (GlobalDebugConfig)XMLHelper.LoadObjectFromXMLFile(typeof(GlobalDebugConfig), FileName);
						if (globalDebugConfig == null)
						{
							globalDebugConfig = Instance;
						}
						return globalDebugConfig;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return _EmptyInstance;
		}
	}
}
