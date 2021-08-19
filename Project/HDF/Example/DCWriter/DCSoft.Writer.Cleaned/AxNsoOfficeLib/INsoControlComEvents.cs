using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>NsoControl 事件的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("8524F372-2FF4-468F-AFDC-CB4BEED1E16D")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Browsable(false)]
	public interface INsoControlComEvents
	{
		                                                                    /// <summary> NsoAuthorityStatus 事件</summary>
		[DispId(372)]
		void NsoAuthorityStatus(int nStatus);

		                                                                    /// <summary> NsoBeforeFilePrinted 事件</summary>
		[DispId(373)]
		void NsoBeforeFilePrinted(string sName);

		                                                                    /// <summary> NsoBeforeFilePrintedEx 事件</summary>
		[DispId(374)]
		void NsoBeforeFilePrintedEx(bool bCancel);

		                                                                    /// <summary> NsoBeforeFileSaved 事件</summary>
		[DispId(375)]
		void NsoBeforeFileSaved(string sName, bool bCancel);

		                                                                    /// <summary> NsoDragAndDropCompleted 事件</summary>
		[DispId(376)]
		void NsoDragAndDropCompleted(string sContent);

		                                                                    /// <summary> NsoFileClosingEvent 事件</summary>
		[DispId(377)]
		void NsoFileClosingEvent();

		                                                                    /// <summary> NsoFileModifyChanged 事件</summary>
		[DispId(378)]
		void NsoFileModifyChanged(bool bModify);

		                                                                    /// <summary> NsoFileOpenCompleted 事件</summary>
		[DispId(379)]
		void NsoFileOpenCompleted(string sPath, string sReserve);

		                                                                    /// <summary> NsoFileReOpenedWhenCrash 事件</summary>
		[DispId(2)]
		void NsoFileReOpenedWhenCrash(string sName);

		                                                                    /// <summary> NsoFileSavedCompleted 事件</summary>
		[DispId(380)]
		void NsoFileSavedCompleted(string sName);

		                                                                    /// <summary> NsoImageClick 事件</summary>
		[DispId(381)]
		void NsoImageClick(string sName);

		                                                                    /// <summary> NsoImageDBClick 事件</summary>
		[DispId(382)]
		void NsoImageDBClick(string sName);

		                                                                    /// <summary> NsoIntellectiveEvent 事件</summary>
		[DispId(383)]
		void NsoIntellectiveEvent(string sContent);

		                                                                    /// <summary> NsoKeyPressedEvent 事件</summary>
		[DispId(384)]
		void NsoKeyPressedEvent(short nKeyCode, sbyte nKeyChar, short nKeyFunction, short nModifiers, bool bCancel);

		                                                                    /// <summary> NsoKeyPressedEvent2 事件</summary>
		[DispId(385)]
		void NsoKeyPressedEvent2(short nKeyCode, short nKeyChar, short nKeyFunction, short nModifiers, bool bCancel);

		                                                                    /// <summary> NsoLButtonDown 事件</summary>
		[DispId(107)]
		void NsoLButtonDown(int xPos, int yPos);

		                                                                    /// <summary> NsoNetDogStatus 事件</summary>
		[DispId(386)]
		void NsoNetDogStatus(int nStatus);

		                                                                    /// <summary> NsoNewControlBeforeDropDown 事件</summary>
		[DispId(387)]
		void NsoNewControlBeforeDropDown(string sName);

		                                                                    /// <summary> NsoNewControlChanged 事件</summary>
		[DispId(249)]
		void NsoNewControlChanged(string sName);

		                                                                    /// <summary> NsoNewControlCheckedChanged 事件</summary>
		[DispId(388)]
		void NsoNewControlCheckedChanged(string sName);

		                                                                    /// <summary> NsoNewControlClick 事件</summary>
		[DispId(4)]
		void NsoNewControlClick(string sName);

		                                                                    /// <summary> NsoNewControlCursorEnter 事件</summary>
		[DispId(250)]
		void NsoNewControlCursorEnter(string sName);

		                                                                    /// <summary> NsoNewControlCursorLeft 事件</summary>
		[DispId(243)]
		void NsoNewControlCursorLeft(string sName);

		                                                                    /// <summary> NsoNewControlDBClick 事件</summary>
		[DispId(244)]
		void NsoNewControlDBClick(string sName);

		                                                                    /// <summary> NsoNewControlDropDown 事件</summary>
		[DispId(389)]
		void NsoNewControlDropDown(string sName);

		                                                                    /// <summary> NsoNewControlGainFocus 事件</summary>
		[DispId(111)]
		void NsoNewControlGainFocus(string sName);

		                                                                    /// <summary> NsoNewControlInsertOrDelEvent 事件</summary>
		[DispId(245)]
		void NsoNewControlInsertOrDelEvent(string sName, string sParentSection, int nEventType);

		                                                                    /// <summary> NsoNewControlLostFocus 事件</summary>
		[DispId(5)]
		void NsoNewControlLostFocus(string sName);

		                                                                    /// <summary> NsoOLEClick 事件</summary>
		[DispId(390)]
		void NsoOLEClick(string sName);

		                                                                    /// <summary> NsoPreviewExitEvent 事件</summary>
		[DispId(391)]
		void NsoPreviewExitEvent();

		                                                                    /// <summary> NsoRadioButtonCheckChanged 事件</summary>
		[DispId(392)]
		void NsoRadioButtonCheckChanged(string sName, int oldCheckIndex, int newCheckIndex);

		                                                                    /// <summary> NsoRButtonUp 事件</summary>
		[DispId(108)]
		void NsoRButtonUp(int xPos, int yPos);

		                                                                    /// <summary> NsoRegionDBClick 事件</summary>
		[DispId(393)]
		void NsoRegionDBClick(string sName);

		                                                                    /// <summary> NsoRegionGainFocus 事件</summary>
		[DispId(394)]
		void NsoRegionGainFocus(string sName);

		                                                                    /// <summary> NsoRegionLostFocus 事件</summary>
		[DispId(395)]
		void NsoRegionLostFocus(string sName);

		                                                                    /// <summary> NsoSectionChanged 事件</summary>
		[DispId(396)]
		void NsoSectionChanged(string sName);

		                                                                    /// <summary> NsoSectionClick 事件</summary>
		[DispId(7)]
		void NsoSectionClick(string sName);

		                                                                    /// <summary> NsoSectionCursorEnter 事件</summary>
		[DispId(246)]
		void NsoSectionCursorEnter(string sName);

		                                                                    /// <summary> NsoSectionCursorLeft 事件</summary>
		[DispId(397)]
		void NsoSectionCursorLeft(string sName);

		                                                                    /// <summary> NsoSectionDBClick 事件</summary>
		[DispId(398)]
		void NsoSectionDBClick(string sName);

		                                                                    /// <summary> NsoSectionGainFocus 事件</summary>
		[DispId(8)]
		void NsoSectionGainFocus(string sName);

		                                                                    /// <summary> NsoSectionInsertOrDelEvent 事件</summary>
		[DispId(113)]
		void NsoSectionInsertOrDelEvent(string sName, int nEventType);

		                                                                    /// <summary> NsoSectionLostFocus 事件</summary>
		[DispId(9)]
		void NsoSectionLostFocus(string sName);

		                                                                    /// <summary> NsoSelectionChanged 事件</summary>
		[DispId(399)]
		void NsoSelectionChanged();

		                                                                    /// <summary> NsoTableAddNewRowWhenPressTabKey 事件</summary>
		[DispId(400)]
		void NsoTableAddNewRowWhenPressTabKey(string sTableName);

		                                                                    /// <summary> NsoToolbarAddinEvent 事件</summary>
		[DispId(401)]
		void NsoToolbarAddinEvent(int nID, string sRev1, string sRev2);

		                                                                    /// <summary> NsoUserMenuItemEvent 事件</summary>
		[DispId(402)]
		void NsoUserMenuItemEvent(int nID, string sRev1, string sRev2);

		                                                                    /// <summary> NsoUserToolbarEvent 事件</summary>
		[DispId(10)]
		void NsoUserToolbarEvent(int nID, string sRev1, string sRev2);
	}
}
