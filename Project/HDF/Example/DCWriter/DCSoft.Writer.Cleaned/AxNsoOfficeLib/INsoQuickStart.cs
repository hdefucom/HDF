using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>NsoQuickStart 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("91EF0286-F954-4C52-9DCC-4A6C9AD67AEC")]
	public interface INsoQuickStart
	{
		                                                                    /// <summary>方法DisableOfficeQuickStart</summary>
		[DispId(2)]
		void DisableOfficeQuickStart();

		                                                                    /// <summary>方法EnableOfficeQuickStart</summary>
		[DispId(3)]
		void EnableOfficeQuickStart(string sLinkName);

		                                                                    /// <summary>方法SetWindowsFirewall</summary>
		[DispId(4)]
		void SetWindowsFirewall();

		                                                                    /// <summary>方法StartOfficeService</summary>
		[DispId(5)]
		void StartOfficeService(bool bKillThread);

		                                                                    /// <summary>方法StopOfficeService</summary>
		[DispId(6)]
		void StopOfficeService();
	}
}
