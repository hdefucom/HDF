using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("DE7DEF27-997D-4232-9B51-384852980F49")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(false)]
	public interface INsoDualCallback
	{
		[DispId(1)]
		void SetContainInterfaceToControl(INsoDualCallback insoDualCallback_0);

		[DispId(2)]
		void SetNsoControlInterfaceToControl(string strGUID);

		[DispId(3)]
		void BeforeContainWindowShow();

		[DispId(4)]
		void ReleaseDllResource();

		[DispId(5)]
		void ContainSendEventToControl(int nEvent, string sRev1, string sRev2);

		[DispId(6)]
		void ControlSetSize(int lWidth, int lHeight);

		[DispId(7)]
		void ControlGainFocus(bool bGain);

		[DispId(8)]
		void ControlDestroyContainWindow();

		[DispId(9)]
		void ControlAskContainToDoSomething(int nEvent, string sRev1, string sRev2);

		[DispId(10)]
		void NotifyNsoElementClick(string sElementName);

		[DispId(11)]
		void NotifyNsoElementDoubleClick(string sElementName);

		[DispId(12)]
		void NotifyNsoElementLostFocus(string sElementName);

		[DispId(13)]
		void NotifyNsoElementKeyPressed(string keyChar);

		[DispId(14)]
		void NotifyNsoElementTextChanged(string sElementName, string sText);

		[DispId(15)]
		void NotifyNsoElementExternEvent(int nEvent, string sRev1, string sRev2);
	}
}
