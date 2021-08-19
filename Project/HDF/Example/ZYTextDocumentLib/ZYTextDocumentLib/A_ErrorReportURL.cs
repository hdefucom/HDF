using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_ErrorReportURL : ZYEditorAction
	{
		public override string ActionName()
		{
			return "errorreporturl";
		}

		public override bool Execute()
		{
			ZYErrorReport.Instance.ReportURL = Param1;
			return true;
		}
	}
}
