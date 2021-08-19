using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.Extension.Serialize;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       启动扩展包
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class ExtensionStart : ModuleStarter
	{
		private static bool bool_2 = false;

		/// <summary>
		///       启用扩展包
		///       </summary>
		public override void Start()
		{
			if (!bool_2)
			{
				bool_2 = true;
				WriterAppHost.RegisterElementType(typeof(XTextMedicalExpressionFieldElement));
			}
		}

		/// <summary>
		///       初始化编辑器宿主对象
		///       </summary>
		/// <param name="host">
		/// </param>
		public override void InitWriterAppHost(WriterAppHost host)
		{
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleExtension());
			host.CommandContainer.Modules.AddModule(new InputElementExpand());
			host.ContentSerializers.AddSerializer(new OldXMLContentSerializer());
			host.ElementPropertiesEditors.SetEditor(typeof(XTextMedicalExpressionFieldElement), new XTextMedicalExpressionFieldElementEditor());
		}
	}
}
