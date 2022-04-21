#define DEBUG
using DCSoft.Common;
using DCSoft.FriedmanCurveChart;
using DCSoft.TemperatureChart;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Serialization.Html;
using DCSoft.Writer.Serialization.PDF;
using DCSoft.Writer.Serialization.RTF;
using DCSoft.Writer.Serialization.TXT;
using DCSoft.Writer.Serialization.Xml;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace DCSoft.Writer
{
	/// <summary>
	///       自动化模块启动器
	///       </summary>
	
	[ComVisible(false)]
	public class ModuleStarter
	{
		private static bool bool_0 = false;

		private static List<ModuleStarter> list_0 = null;

		private static bool bool_1 = false;

		private static string string_0 = Path.GetDirectoryName(typeof(string).Assembly.Location);

		private static Dictionary<int, GClass138> dictionary_0 = new Dictionary<int, GClass138>();

		/// <summary>
		///       已经执行了的标记
		///       </summary>
		public static bool Started => bool_0;

		public static List<ModuleStarter> GlobalStarters
		{
			get
			{
				if (list_0 == null)
				{
					list_0 = new List<ModuleStarter>();
					list_0.Add(new ModuleStarter());
				}
				return list_0;
			}
		}

		/// <summary>
		///       执行启动操作
		///       </summary>
		public virtual void Start()
		{
		}

		/// <summary>
		///       初始化应用程序宿主对象
		///       </summary>
		/// <param name="host">
		/// </param>
		public virtual void InitWriterAppHost(WriterAppHost host)
		{
			host.ContentSerializers.AddSerializer(new XMLContentSerializer());
			host.ContentSerializers.AddSerializer(new HTMLContentSerializer());
			host.ContentSerializers.AddSerializer(new MHTContentSerializer());
			host.ContentSerializers.AddSerializer(new RTFContentSerializer());
			host.ContentSerializers.AddSerializer(new TXTContentSerializer());
			host.ContentSerializers.AddSerializer(new PDFContentSerializer());
			host.ContentSerializers.AddSerializer(new ImagePDFContentSerializer());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleCore());
			host.Services.AddService(typeof(DCUITools), new DCUITools());
			host.Services.AddService(typeof(IErrorReporter), new DefaultErrorReporter());
			GClass380.smethod_4(typeof(WriterStringsCore));
			WinFormUtils.smethod_1();
			new ValuePoint();
			new FCValuePoint();
			smethod_3();
		}

		/// <summary>
		///       添加全局模块启动器
		///       </summary>
		/// <param name="starter">
		/// </param>
		public static void AddGlobalModuleStarter(ModuleStarter starter)
		{
			int num = 0;
			if (starter == null)
			{
				throw new ArgumentNullException("starter");
			}
			if (!smethod_0(starter))
			{
				GlobalStarters.Add(starter);
			}
		}

		private static bool smethod_0(ModuleStarter moduleStarter_0)
		{
			foreach (ModuleStarter globalStarter in GlobalStarters)
			{
				if (globalStarter.GetType().Equals(moduleStarter_0.GetType()))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       启动所有的应用程序模块
		///       </summary>
		public static void StartAllModule(WriterAppHost host)
		{
			int num = 12;
			long tickCountExt = CountDown.GetTickCountExt();
			bool_1 = false;
			foreach (ModuleStarter globalStarter in GlobalStarters)
			{
				globalStarter.Start();
				globalStarter.InitWriterAppHost(host);
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly[] array = assemblies;
			foreach (Assembly assembly in array)
			{
				string fullName = assembly.FullName;
				Debug.WriteLine(fullName);
				if (fullName != null && fullName.StartsWith("DCSoft.Writer"))
				{
					smethod_1(assembly, host);
				}
			}
			if (!bool_1)
			{
				ObjectHandle objectHandle = null;
				try
				{
					objectHandle = AppDomain.CurrentDomain.CreateInstance("DCSoft.Writer.Extension", "DCSoft.Writer.Extension.ExtensionStart");
				}
				catch (Exception)
				{
				}
				if (objectHandle == null)
				{
					try
					{
						objectHandle = AppDomain.CurrentDomain.CreateInstance("DCSoft.Writer.Extension.Publish", "DCSoft.Writer.Extension.ExtensionStart");
					}
					catch (Exception ex2)
					{
						Debug.WriteLine("试图加载扩展包失败：" + ex2.Message);
					}
				}
				if (!bool_1 && objectHandle != null)
				{
					ModuleStarter current = (ModuleStarter)objectHandle.Unwrap();
					if (!smethod_0(current))
					{
						current.Start();
						current.InitWriterAppHost(host);
					}
				}
			}
			tickCountExt = CountDown.GetTickCountExt() - tickCountExt;
			CountDown.TickCountExtToTick(tickCountExt);
			bool_0 = true;
		}

		private static bool smethod_1(Assembly assembly_0, WriterAppHost writerAppHost_0)
		{
			int num = 6;
			if (writerAppHost_0 == null)
			{
				writerAppHost_0 = WriterAppHost.Default;
			}
			if (assembly_0 == null || assembly_0.ReflectionOnly)
			{
				return false;
			}
			try
			{
				if (assembly_0 is AssemblyBuilder)
				{
					return false;
				}
				if (assembly_0.GetType().Namespace == "System.Reflection.Emit")
				{
					return false;
				}
				string text = null;
				try
				{
					text = assembly_0.Location;
				}
				catch (Exception)
				{
					return false;
				}
				if (text != null && text.StartsWith(string_0, StringComparison.CurrentCultureIgnoreCase))
				{
					return false;
				}
				if (assembly_0.FullName.StartsWith("System.") || assembly_0.FullName.StartsWith("System,") || assembly_0.FullName.StartsWith("Microsoft.VisualStudio."))
				{
					return false;
				}
				Type[] array = null;
				try
				{
					array = assembly_0.GetTypes();
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return false;
				}
				Type[] array2 = array;
				foreach (Type type in array2)
				{
					if (!bool_1 && type.Namespace != null && type.Namespace.StartsWith("DCSoft.Writer.Extension"))
					{
						bool_1 = true;
					}
					if ((type.Equals(typeof(ModuleStarter)) || type.IsSubclassOf(typeof(ModuleStarter))) && !type.IsAbstract)
					{
						ModuleStarter moduleStarter = (ModuleStarter)Activator.CreateInstance(type);
						if (!smethod_0(moduleStarter))
						{
							moduleStarter.Start();
							moduleStarter.InitWriterAppHost(writerAppHost_0);
						}
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		private static void smethod_2(object sender, AssemblyLoadEventArgs e)
		{
			if (e.LoadedAssembly != null)
			{
				smethod_1(e.LoadedAssembly, null);
			}
		}

		private static void smethod_3()
		{
			string string_ = "DCSoft.TemperatureChart.TemperatureDocument";
			smethod_4(string_);
			string string_2 = "DCSoft.FriedmanCurveChart.FriedmanCurveDocument";
			smethod_4(string_2);
		}

		private static bool smethod_4(string string_1)
		{
			Type controlType = ControlHelper.GetControlType(string_1, null);
			if (controlType != null)
			{
				FieldInfo[] fields = controlType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.FieldType == typeof(GDelegate24))
					{
						fieldInfo.SetValue(null, new GDelegate24(smethod_5));
						return true;
					}
				}
			}
			return false;
		}

		private static object smethod_5(object object_0, Type type_0, int int_0)
		{
			string propertyName = "Config.PageTitlePosition";
			GClass472 gClass = new GClass472();
			if (object_0 != null)
			{
				gClass.method_21((GEnum88)ValueTypeHelper.GetPropertyValueMultiLayer(object_0, propertyName, GEnum88.flag_0, throwExecption: false));
			}
			GClass138 gclass138_ = null;
			if (dictionary_0.ContainsKey(int_0))
			{
				gclass138_ = dictionary_0[int_0];
			}
			GClass138 gClass2 = GClass145.smethod_0(gclass138_, int_0, type_0, DCPublishDateAttribute.GetValue(type_0.Assembly));
			dictionary_0[int_0] = gClass2;
			if (gClass2.method_34())
			{
				gClass.method_9(gClass2.method_50());
				gClass.method_7(bool_7: true);
				gClass.method_3(gClass2.method_53());
			}
			else
			{
				string string_ = "【未注册，请联系南京都昌信息科技有限公司进行注册】";
				gClass.method_7(bool_7: false);
				gClass.method_9(string_);
				gClass.method_13(20f);
				gClass.method_17(Color.Red);
			}
			return gClass;
		}
	}
}
