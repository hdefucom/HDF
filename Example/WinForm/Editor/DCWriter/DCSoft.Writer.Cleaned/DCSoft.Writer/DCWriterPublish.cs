using DCSoft.Common;
using DCSoft.Writer.Extension;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       启用软件模块
	///       </summary>
	[ComVisible(true)]
	[ComClass("6AF148FB-3227-4F42-8C0D-D102EB9DBD7F", "DBF2070E-C5B3-4377-A6C9-48C497152539")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDCWriterPublish))]
	[Guid("6AF148FB-3227-4F42-8C0D-D102EB9DBD7F")]
	
	public class DCWriterPublish : IDCWriterPublish
	{
		internal const string CLASSID = "6AF148FB-3227-4F42-8C0D-D102EB9DBD7F";

		internal const string CLASSID_Interface = "DBF2070E-C5B3-4377-A6C9-48C497152539";

		private static bool _StartFlag = false;

		
		public static void Start()
		{
			int num = 15;
			if (!_StartFlag)
			{
				WriterUtils.CheckNET20SP2(throwException: true);
				_StartFlag = true;
				GClass359.smethod_9(typeof(DCWriterPublish).Assembly, "DCSoft.Writer.WriterDescriptionStrings");
				ModuleStarter.AddGlobalModuleStarter(new ModuleStarter());
				ModuleStarter.AddGlobalModuleStarter(new MainModuleStarter());
				ModuleStarter.AddGlobalModuleStarter(new ExtensionStart());
				_ = WriterAppHost.Default;
			}
		}

		public void StartSystem()
		{
			Start();
		}
	}
}
