using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComDefaultInterface(typeof(INsoQuickStart))]
	[ComClass("46AB59D2-C600-456A-A2AB-FE8CF73A1D3C", "91EF0286-F954-4C52-9DCC-4A6C9AD67AEC")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("46AB59D2-C600-456A-A2AB-FE8CF73A1D3C")]
	public class NsoQuickStart : INsoQuickStart
	{
		internal const string CLASSID = "46AB59D2-C600-456A-A2AB-FE8CF73A1D3C";

		internal const string CLASSID_Interface = "91EF0286-F954-4C52-9DCC-4A6C9AD67AEC";

		[ComVisible(true)]
		public void StartOfficeService(bool bKillThread)
		{
		}

		[ComVisible(true)]
		public void StopOfficeService()
		{
		}

		[ComVisible(true)]
		public void EnableOfficeQuickStart(string sLinkName)
		{
		}

		[ComVisible(true)]
		public void DisableOfficeQuickStart()
		{
		}

		[ComVisible(true)]
		public void SetWindowsFirewall()
		{
		}
	}
}
