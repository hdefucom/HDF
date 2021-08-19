using System.Runtime.InteropServices;

namespace NsoOfficeLib
{
	[ComVisible(true)]
	[Guid("A5881C37-EF95-4FA3-81FE-A77EC0F91A8B")]
	public interface INsoCallback
	{
		void NotifyNsoNewControlGainFocus(string sStructName, string sRev1);

		void NotifyNsoNewControlLostFocus(string sStructName, string sRev1);

		void NotifyNsoNewControlCursorEnter(string sStructName, string sRev1);

		void NotifyNsoNewControlCursorLeft(string sStructName, string sRev1);

		void NotifyNsoNewControlChanged(string sStructName, string sRev1);

		void NotifyNsoNewControlDBClick(string sStructName, string sRev1);

		void NotifyNsoNewControlDropDown(string sStructName, string sRev1);

		void NotifyNsoNewControlCheckedChanged(string sStructName, string sRev1);

		void NotifyNsoNewControlBeforeDropDown(string sStructName, string sRev1);

		void NotifyNsoNewControlClick(string sStructName, string sRev1);

		void NotifyNsoSectionGainFocus(string sStructName, string sRev1);

		void NotifyNsoSectionLostFocus(string sStructName, string sRev1);

		void NotifyNsoSectionCursorEnter(string sStructName, string sRev1);

		void NotifyNsoSectionCursorLeft(string sStructName, string sRev1);

		void NotifyNsoSectionDBClick(string sStructName, string sRev1);

		void NotifyNsoSectionChanged(string sStructName, string sRev1);

		void NotifyNsoSectionClick(string sStructName, string sRev1);

		void NotifyNsoRegionDBClick(string sStructName, string sRev1);

		void NotifyNsoRegionGainFocus(string sStructName, string sRev1);

		void NotifyNsoRegionLostFocus(string sStructName, string sRev1);

		void NotifyNsoRegionChanged(string sStructName, string sRev1);
	}
}
