using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       启动扩展包
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class MainModuleStarter : ModuleStarter
	{
		public override void Start()
		{
		}

		public override void InitWriterAppHost(WriterAppHost host)
		{
			host.Tools = new WriterTools();
			WriterAppHost.RegisterElementType(typeof(XTextTDBarcodeElement), WriterStrings.ElementType_TDBarcode);
			WriterAppHost.RegisterElementType(typeof(XTextTemperatureChartElement), WriterStrings.ElementType_TChart);
			WriterAppHost.RegisterElementType(typeof(XTextAccountingNumberElement), WriterStrings.ElementType_AccountingNumber);
			WriterAppHost.RegisterElementType(typeof(XTextBarcodeFieldElement), WriterStrings.ElementType_Barcode);
			WriterAppHost.RegisterElementType(typeof(XTextMediaElement), WriterStrings.ElementType_Media);
			WriterAppHost.RegisterElementType(typeof(XTextPartitionImageElement), "XTextPartitionImageElement");
			WriterAppHost.RegisterElementType(typeof(XTextNewMedicalExpressionElement));
			host.ElementPropertiesEditors.SetEditor(typeof(XTextNewMedicalExpressionElement), new XTextNewMedicalExpressionElementEditor());
			WriterAppHost.RegisterElementType(typeof(XTextNewBarcodeElement), WriterStrings.ElementType_Barcode);
			host.ElementPropertiesEditors.SetEditor(typeof(XTextNewBarcodeElement), new XTextNewBarcodeElementEditor());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleBrowse());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleEdit());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleFile());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleFormat());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleInsert());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleSecurity());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleTable());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleTools());
			host.CommandContainer.Modules.AddModule(new WriterCommandModuleData());
			host.Services.AddService(typeof(IKBProvider), new DefaultKBProvider());
			ElementPropertiesEditorContainer elementPropertiesEditors = host.ElementPropertiesEditors;
			elementPropertiesEditors.SetEditor(typeof(XTextBarcodeFieldElement), new XTextBarcodeFieldElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextCheckBoxElement), new XTextCheckBoxElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextRadioBoxElement), new XTextRadioBoxElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextContentLinkFieldElement), new XTextContentLinkElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextControlHostElement), new XTextControlHostElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextFileBlockElement), new XTextFileBlockElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextHorizontalLineElement), new XTextHorizontalLineElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextImageElement), new XTextImageElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextInputFieldElement), new XTextInputFieldElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextLabelElement), new XTextLabelElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextButtonElement), new XTextButtonElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextAccountingNumberElement), new XTextAccountingNumberElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextTDBarcodeElement), new XTextTDBarcodeFieldElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextSectionElement), new XTextSectionElementEditor());
			elementPropertiesEditors.SetEditor(typeof(XTextRulerElement), new XTextRulerElementEditor());
			GClass380.smethod_4(typeof(WriterStrings));
		}
	}
}
