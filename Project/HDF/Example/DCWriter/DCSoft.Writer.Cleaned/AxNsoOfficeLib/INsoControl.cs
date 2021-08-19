using NsoOfficeLib;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>NsoControl 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("E9E3B18A-CAD1-40DD-8EC0-8B5B76BFFC10")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface INsoControl
	{
		                                                                    /// <summary>属性CodeBaseForUpdateAssembly</summary>
		[DispId(897)]
		string CodeBaseForUpdateAssembly
		{
			get;
			set;
		}

		                                                                    /// <summary>属性ControlTitleText</summary>
		[DispId(899)]
		string ControlTitleText
		{
			get;
			set;
		}

		                                                                    /// <summary>属性IsDebug</summary>
		[DispId(849)]
		bool IsDebug
		{
			get;
			set;
		}

		                                                                    /// <summary>属性ShowDesignInfoToolTip</summary>
		[DispId(231)]
		bool ShowDesignInfoToolTip
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextAlignment</summary>
		[DispId(232)]
		int TextAlignment
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextAsianName</summary>
		[DispId(233)]
		string TextAsianName
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextBackColor</summary>
		[DispId(850)]
		int TextBackColor
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextBackColorPrintable</summary>
		[DispId(851)]
		bool TextBackColorPrintable
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextBold</summary>
		[DispId(234)]
		bool TextBold
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextColor</summary>
		[DispId(852)]
		int TextColor
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextFirstLineIndent</summary>
		[DispId(286)]
		int TextFirstLineIndent
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextItalic</summary>
		[DispId(853)]
		bool TextItalic
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextSize</summary>
		[DispId(235)]
		long TextSize
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextUnderLine</summary>
		[DispId(854)]
		WdUnderLine TextUnderLine
		{
			get;
			set;
		}

		                                                                    /// <summary>属性TextWestName</summary>
		[DispId(855)]
		string TextWestName
		{
			get;
			set;
		}

		                                                                    /// <summary>属性Version1</summary>
		[DispId(856)]
		string Version1
		{
			get;
		}

		                                                                    /// <summary>属性Version2</summary>
		[DispId(371)]
		string Version2
		{
			get;
		}

		                                                                    /// <summary>方法AcceptRecension</summary>
		[DispId(114)]
		void AcceptRecension();

		                                                                    /// <summary>方法ActiveNsoWindow</summary>
		[DispId(859)]
		void ActiveNsoWindow(int int_0);

		                                                                    /// <summary>方法AddDragDropListner</summary>
		[DispId(403)]
		void AddDragDropListner();

		                                                                    /// <summary>方法AddFileListener</summary>
		[DispId(11)]
		void AddFileListener();

		                                                                    /// <summary>方法AddGlobalDocumentListener</summary>
		[DispId(12)]
		void AddGlobalDocumentListener();

		                                                                    /// <summary>方法AddImage</summary>
		[DispId(404)]
		string AddImage(string sPath);

		                                                                    /// <summary>方法AddImageObject</summary>
		[DispId(13)]
		string AddImageObject(string sURL, int nType);

		                                                                    /// <summary>方法AddImageObjectEx</summary>
		[DispId(405)]
		string AddImageObjectEx(string sURL, int nType, float fOleWidth, float fOleHeight);

		                                                                    /// <summary>方法AddImageObjectExWithStream</summary>
		[DispId(406)]
		string AddImageObjectExWithStream(object stmFile, int nType, float fOleWidth, float fOleHeight);

		                                                                    /// <summary>方法AddImageObjectExWithString</summary>
		[DispId(407)]
		string AddImageObjectExWithString(string base64String, int nType, float fOleWidth, float fOleHeight);

		                                                                    /// <summary>方法AddImageObjectWithStream</summary>
		[DispId(408)]
		string AddImageObjectWithStream(object stmFile, int nType);

		                                                                    /// <summary>方法AddImageObjectWithString</summary>
		[DispId(409)]
		string AddImageObjectWithString(string base64String, int nType);

		                                                                    /// <summary>方法AddImageWithStream</summary>
		[DispId(410)]
		string AddImageWithStream(object stmFile);

		                                                                    /// <summary>方法AddImageWithString</summary>
		[DispId(411)]
		string AddImageWithString(string base64String);

		                                                                    /// <summary>方法AddKeyListener</summary>
		[DispId(115)]
		void AddKeyListener(int bReserve);

		                                                                    /// <summary>方法AddLineBeforeTableAtHead</summary>
		[DispId(412)]
		bool AddLineBeforeTableAtHead();

		                                                                    /// <summary>方法AddListenerForOneStruct</summary>
		[DispId(876)]
		void AddListenerForOneStruct(string sStructName, int lListenType, INsoCallback myCallback);

		                                                                    /// <summary>方法AddMouseListener</summary>
		[DispId(14)]
		void AddMouseListener(int nType);

		                                                                    /// <summary>方法AddPostilAtCurrentCursor</summary>
		[DispId(15)]
		bool AddPostilAtCurrentCursor(string strPostilConent, string strDateTime);

		                                                                    /// <summary>方法AddSelectionChangedListener</summary>
		[DispId(413)]
		void AddSelectionChangedListener();

		                                                                    /// <summary>方法AddSignaturePic</summary>
		[DispId(414)]
		string AddSignaturePic(string sPath);

		                                                                    /// <summary>方法AddSignaturePic2</summary>
		[DispId(415)]
		string AddSignaturePic2(string sPath);

		                                                                    /// <summary>方法AddSignaturePic2WithStream</summary>
		[DispId(416)]
		string AddSignaturePic2WithStream(object stmLoad);

		                                                                    /// <summary>方法AddSignaturePic2WithString</summary>
		[DispId(417)]
		string AddSignaturePic2WithString(string base64String);

		                                                                    /// <summary>方法AddSignaturePicBase64</summary>
		[DispId(418)]
		string AddSignaturePicBase64(string sInfo, int nType);

		                                                                    /// <summary>方法AttachFrameToOneOpenedFile</summary>
		[DispId(891)]
		void AttachFrameToOneOpenedFile(string classID);

		                                                                    /// <summary>方法BindXMLToODT</summary>
		[DispId(419)]
		bool BindXMLToODT(string sXMLPath);

		                                                                    /// <summary>方法BrowseTemplet</summary>
		[DispId(16)]
		void BrowseTemplet(int nType, int nProtected);

		                                                                    /// <summary>方法BrowseWebMode</summary>
		[DispId(420)]
		void BrowseWebMode(bool bFlag);

		                                                                    /// <summary>方法CancelPrintPreview</summary>
		[DispId(236)]
		void CancelPrintPreview();

		                                                                    /// <summary>方法CancelSelectOneArea</summary>
		[DispId(17)]
		void CancelSelectOneArea(string string_0, int int_0);

		                                                                    /// <summary>方法ChangeImageToOleObject</summary>
		[DispId(421)]
		string ChangeImageToOleObject(string sImageName, string sRev1);

		                                                                    /// <summary>方法ChangePageNumber</summary>
		[DispId(422)]
		void ChangePageNumber(int oldNum, int newNum);

		                                                                    /// <summary>方法ClearCurrentParagraphTabStop</summary>
		[DispId(423)]
		bool ClearCurrentParagraphTabStop();

		                                                                    /// <summary>方法ClearUndoList</summary>
		[DispId(424)]
		void ClearUndoList();

		                                                                    /// <summary>方法Close</summary>
		[DispId(116)]
		int Close();

		                                                                    /// <summary>方法ComDispose</summary>
		[DispId(868)]
		void ComDispose();

		                                                                    /// <summary>方法Copy</summary>
		[DispId(425)]
		void Copy();

		                                                                    /// <summary>方法CopyMultiRows</summary>
		[DispId(426)]
		bool CopyMultiRows(string tableN, string cellCopyStartN, int count, string cellPasteStartN);

		                                                                    /// <summary>方法CopySelectArea</summary>
		[DispId(117)]
		string CopySelectArea(bool bCopyWithBookmark);

		                                                                    /// <summary>方法CopySelectArea2</summary>
		[DispId(427)]
		bool CopySelectArea2(bool bWithForamt);

		                                                                    /// <summary>方法CreateBookmarkAtSelection</summary>
		[DispId(118)]
		void CreateBookmarkAtSelection(string TagName);

		                                                                    /// <summary>方法CreateNew</summary>
		[DispId(119)]
		int CreateNew(string module);

		                                                                    /// <summary>方法CreateRandomStructName</summary>
		[DispId(428)]
		string CreateRandomStructName();

		                                                                    /// <summary>方法CreateUserRootMenuItem</summary>
		[DispId(429)]
		bool CreateUserRootMenuItem(string strRootCommand, string strRootLabel);

		                                                                    /// <summary>方法CreateUserToolbar</summary>
		[DispId(18)]
		bool CreateUserToolbar(string strToolbar, string strUIName);

		                                                                    /// <summary>方法CursorEnterTableCell</summary>
		[DispId(120)]
		bool CursorEnterTableCell(string sName, string sCell);

		                                                                    /// <summary>方法CursorJumpOutOfOneRegion</summary>
		[DispId(430)]
		bool CursorJumpOutOfOneRegion(string strName, bool bEnd);

		                                                                    /// <summary>方法CursorJumpOutOfOneStruct</summary>
		[DispId(431)]
		bool CursorJumpOutOfOneStruct(string sStructName, int nMark);

		                                                                    /// <summary>方法CursorJumpOutOfOneTable</summary>
		[DispId(432)]
		bool CursorJumpOutOfOneTable(string sTableName, int nMark);

		                                                                    /// <summary>方法CursorJumpToEndOfParagraph</summary>
		[DispId(433)]
		bool CursorJumpToEndOfParagraph();

		                                                                    /// <summary>方法CursorJumpToStartOfParagraph</summary>
		[DispId(434)]
		bool CursorJumpToStartOfParagraph();

		                                                                    /// <summary>方法Cut</summary>
		[DispId(251)]
		void Cut();

		                                                                    /// <summary>方法CutSelectArea</summary>
		[DispId(121)]
		string CutSelectArea();

		                                                                    /// <summary>方法DelBookmark</summary>
		[DispId(122)]
		void DelBookmark(string TagName);

		                                                                    /// <summary>方法DeleteAllCompoundBoxCodeAndValue</summary>
		[DispId(435)]
		bool DeleteAllCompoundBoxCodeAndValue(string sName, int iType);

		                                                                    /// <summary>方法DeleteAllRadioButtonItem</summary>
		[DispId(436)]
		bool DeleteAllRadioButtonItem(string sName);

		                                                                    /// <summary>方法DeleteFooter</summary>
		[DispId(437)]
		void DeleteFooter();

		                                                                    /// <summary>方法DeleteHeader</summary>
		[DispId(438)]
		void DeleteHeader();

		                                                                    /// <summary>方法DeleteImage</summary>
		[DispId(439)]
		bool DeleteImage(string sName);

		                                                                    /// <summary>方法DeleteImageObject</summary>
		[DispId(123)]
		bool DeleteImageObject(string sName);

		                                                                    /// <summary>方法DeleteMedicalformula</summary>
		[DispId(124)]
		bool DeleteMedicalformula(string sName);

		                                                                    /// <summary>方法DeleteMedicalformulaByType</summary>
		[DispId(440)]
		bool DeleteMedicalformulaByType(int lMedicalType);

		                                                                    /// <summary>方法DeleteNewControl</summary>
		[DispId(125)]
		bool DeleteNewControl(string sName);

		                                                                    /// <summary>方法DeleteNewControlText</summary>
		[DispId(869)]
		bool DeleteNewControlText(string sName);

		                                                                    /// <summary>方法DeleteOfficeAppData</summary>
		[DispId(441)]
		void DeleteOfficeAppData();

		                                                                    /// <summary>方法DeleteOneCompoundBoxCodeAndValue</summary>
		[DispId(442)]
		bool DeleteOneCompoundBoxCodeAndValue(string sName, string sCode, int iType);

		                                                                    /// <summary>方法DeleteOneRadioButtonItemByIndex</summary>
		[DispId(443)]
		bool DeleteOneRadioButtonItemByIndex(string sName, int nIndex);

		                                                                    /// <summary>方法DeleteParaProtectArea</summary>
		[DispId(444)]
		bool DeleteParaProtectArea(string sName);

		                                                                    /// <summary>方法DeletePostil</summary>
		[DispId(445)]
		bool DeletePostil(int nType, string strAuthor);

		                                                                    /// <summary>方法DeleteProtectArea</summary>
		[DispId(446)]
		bool DeleteProtectArea(string sName);

		                                                                    /// <summary>方法DeleteRedundant</summary>
		[DispId(19)]
		bool DeleteRedundant(bool bBlankLine, bool bSpace, bool bTab);

		                                                                    /// <summary>方法DeleteRedundantByRegionName</summary>
		[DispId(877)]
		bool DeleteRedundantByRegionName(string ID, bool bBlankLine, bool bSpace, bool bTab);

		                                                                    /// <summary>方法DeleteRedundantEx</summary>
		[DispId(447)]
		bool DeleteRedundantEx(bool bBlankLine, bool bSpace, bool bTab, bool bDelPageBreak);

		                                                                    /// <summary>方法DeleteRegion</summary>
		[DispId(448)]
		bool DeleteRegion(string sName, int lFlag);

		                                                                    /// <summary>方法DeleteRegionTitle</summary>
		[DispId(449)]
		bool DeleteRegionTitle(string strName);

		                                                                    /// <summary>方法DeleteSection</summary>
		[DispId(126)]
		bool DeleteSection(string Section_name);

		                                                                    /// <summary>方法DeleteSectionContent</summary>
		[DispId(450)]
		bool DeleteSectionContent(string sName);

		                                                                    /// <summary>方法DeleteSelectArea</summary>
		[DispId(127)]
		string DeleteSelectArea();

		                                                                    /// <summary>方法DeleteStructAllUserProps</summary>
		[DispId(451)]
		bool DeleteStructAllUserProps(string sStructName);

		                                                                    /// <summary>方法DeleteStructUserProp</summary>
		[DispId(452)]
		bool DeleteStructUserProp(string sStructName, string sProp);

		                                                                    /// <summary>方法DeleteTable</summary>
		[DispId(111)]
		bool DeleteTable(string sName);

		                                                                    /// <summary>方法DeleteTableRowByParam</summary>
		[DispId(860)]
		void DeleteTableRowByParam(string tableName, string cellName, string string_0, string string_1);

		                                                                    /// <summary>方法DelMultiCols</summary>
		[DispId(112)]
		bool DelMultiCols(string sName, int index, int count);

		                                                                    /// <summary>方法DelMultiRows</summary>
		[DispId(107)]
		bool DelMultiRows(string sName, int index, int count);

		                                                                    /// <summary>方法DelWaterMark</summary>
		[DispId(128)]
		bool DelWaterMark();

		                                                                    /// <summary>方法DesignTemplet</summary>
		[DispId(20)]
		void DesignTemplet(bool bContainListener, bool bSelectListener);

		                                                                    /// <summary>方法DisableContextMenuItem</summary>
		[DispId(453)]
		bool DisableContextMenuItem(int nType);

		                                                                    /// <summary>方法DisableKey</summary>
		[DispId(454)]
		void DisableKey(string strKeyName);

		                                                                    /// <summary>方法DisablePostilUI</summary>
		[DispId(898)]
		void DisablePostilUI(int int_0, int int_1);

		                                                                    /// <summary>方法DisconnectRegionLinks</summary>
		[DispId(455)]
		bool DisconnectRegionLinks(string sRegionName);

		                                                                    /// <summary>方法EditStructInProtectedTableCell</summary>
		[DispId(456)]
		bool EditStructInProtectedTableCell(string strTableName, string strTableCell, bool bEdit);

		                                                                    /// <summary>方法EditTemplet</summary>
		[DispId(21)]
		void EditTemplet();

		                                                                    /// <summary>方法EnableCheckboxEvent</summary>
		[DispId(457)]
		bool EnableCheckboxEvent(int lType);

		                                                                    /// <summary>方法EnableCopyFromExternal</summary>
		[DispId(22)]
		bool EnableCopyFromExternal(bool bEnable);

		                                                                    /// <summary>方法EnableEnhanceEditModel</summary>
		[DispId(458)]
		void EnableEnhanceEditModel(bool bFlag, int nMaxHeight);

		                                                                    /// <summary>方法EnableFloatbar</summary>
		[DispId(23)]
		bool EnableFloatbar(bool bShow);

		                                                                    /// <summary>方法EnableKey</summary>
		[DispId(459)]
		void EnableKey(string strKeyName);

		                                                                    /// <summary>方法EnableNavigator</summary>
		[DispId(460)]
		bool EnableNavigator(bool bShow);

		                                                                    /// <summary>方法EnableRedlineReview</summary>
		[DispId(24)]
		void EnableRedlineReview(bool bShow);

		                                                                    /// <summary>方法EnableSpecialEnterAtLastTableCell</summary>
		[DispId(461)]
		bool EnableSpecialEnterAtLastTableCell(bool bEnable);

		                                                                    /// <summary>方法EnableSpecialTabAtLastTableCell</summary>
		[DispId(462)]
		bool EnableSpecialTabAtLastTableCell(bool bEnable);

		                                                                    /// <summary>方法EnableViewEnhancedMode</summary>
		[DispId(463)]
		void EnableViewEnhancedMode(bool bFlag);

		                                                                    /// <summary>方法EndUndo</summary>
		[DispId(464)]
		void EndUndo();

		                                                                    /// <summary>方法ExecuteCommand</summary>
		[DispId(894)]
		object ExecuteCommand(string commandName, bool showUI, object parameter);

		                                                                    /// <summary>方法ExecuteMethod</summary>
		[DispId(25)]
		void ExecuteMethod(string method);

		                                                                    /// <summary>方法ExistCellByTable</summary>
		[DispId(878)]
		bool ExistCellByTable(string sTable, string sCell);

		                                                                    /// <summary>方法ExistImage</summary>
		[DispId(465)]
		bool ExistImage(string sName);

		                                                                    /// <summary>方法ExistImageObject</summary>
		[DispId(129)]
		bool ExistImageObject(string sName);

		                                                                    /// <summary>方法ExistsBookmark</summary>
		[DispId(466)]
		bool ExistsBookmark(string name);

		                                                                    /// <summary>方法ExportBMPByIndex</summary>
		[DispId(467)]
		void ExportBMPByIndex(string rURL, int lPageStart, int lPageEnd);

		                                                                    /// <summary>方法FilterRecensionInfo</summary>
		[DispId(468)]
		bool FilterRecensionInfo(string sAuthors, string sIDs, int lChangeType, DateTime timeStart, DateTime timeEnd);

		                                                                    /// <summary>方法FilterStructsByProp</summary>
		[DispId(469)]
		string FilterStructsByProp(int nType, string sPropName, string sPropValue, string sRev1, string sRev2);

		                                                                    /// <summary>方法ForceStructsBorderVisible</summary>
		[DispId(470)]
		void ForceStructsBorderVisible(bool bVisible);

		                                                                    /// <summary>方法GetAllBookmarksName</summary>
		[DispId(130)]
		string GetAllBookmarksName();

		                                                                    /// <summary>方法GetAllControlNameByCurrentDoc</summary>
		[DispId(26)]
		string GetAllControlNameByCurrentDoc();

		                                                                    /// <summary>方法GetAllFileProperty</summary>
		[DispId(471)]
		string GetAllFileProperty(string sRev);

		                                                                    /// <summary>方法GetAllImageObjectsByCurrentDoc</summary>
		[DispId(131)]
		string GetAllImageObjectsByCurrentDoc();

		                                                                    /// <summary>方法GetAllImagesByCurrentDoc</summary>
		[DispId(472)]
		string GetAllImagesByCurrentDoc();

		                                                                    /// <summary>方法GetAllMedicalformulasByCurrentDoc</summary>
		[DispId(132)]
		string GetAllMedicalformulasByCurrentDoc();

		                                                                    /// <summary>方法GetAllNewControlsBySectionName</summary>
		[DispId(133)]
		string GetAllNewControlsBySectionName(string SectionId);

		                                                                    /// <summary>方法GetAllParaProtectNamesByCurrentDoc</summary>
		[DispId(473)]
		string GetAllParaProtectNamesByCurrentDoc();

		                                                                    /// <summary>方法GetAllProtectAreaNameByCurrentDoc</summary>
		[DispId(474)]
		string GetAllProtectAreaNameByCurrentDoc();

		                                                                    /// <summary>方法GetAllRegionNamesByCurrentDoc</summary>
		[DispId(475)]
		string GetAllRegionNamesByCurrentDoc();

		                                                                    /// <summary>方法GetAllSectAndNewCtrlContentByCurrentDoc</summary>
		[DispId(252)]
		string GetAllSectAndNewCtrlContentByCurrentDoc(string aSctContType, string aCtrlContType, int nPostionFlag, int nReserved);

		                                                                    /// <summary>方法GetAllSectAndNewCtrlContentByCurrentDoc2</summary>
		[DispId(476)]
		string GetAllSectAndNewCtrlContentByCurrentDoc2(string aSctContType, string aCtrlContType, int nPostionFlag, int nReserved);

		                                                                    /// <summary>方法GetAllSectAndNewCtrlContentByCurrentDoc3</summary>
		[DispId(477)]
		string GetAllSectAndNewCtrlContentByCurrentDoc3(string aSctContType, string aCtrlContType, int nPostionFlag, int nReserved);

		                                                                    /// <summary>方法GetAllSectionAndNewControlByCurrentDoc</summary>
		[DispId(478)]
		string GetAllSectionAndNewControlByCurrentDoc();

		                                                                    /// <summary>方法GetAllSectionAndNewControlByCurrentDoc2</summary>
		[DispId(479)]
		string GetAllSectionAndNewControlByCurrentDoc2();

		                                                                    /// <summary>方法GetAllSectionCount</summary>
		[DispId(480)]
		int GetAllSectionCount();

		                                                                    /// <summary>方法GetAllSectionNamesByCurrentDoc</summary>
		[DispId(27)]
		string GetAllSectionNamesByCurrentDoc();

		                                                                    /// <summary>方法GetAllTableNamesByCurrentDoc</summary>
		[DispId(134)]
		string GetAllTableNamesByCurrentDoc();

		                                                                    /// <summary>方法GetBlankLineCountOfPage</summary>
		[DispId(481)]
		int GetBlankLineCountOfPage(ushort iPage);

		                                                                    /// <summary>方法GetBookmarkText</summary>
		[DispId(482)]
		string GetBookmarkText(string tagName);

		                                                                    /// <summary>方法GetCellContent</summary>
		[DispId(135)]
		string GetCellContent(string tableN, string cellN);

		                                                                    /// <summary>方法GetCheckboxCaption</summary>
		[DispId(483)]
		string GetCheckboxCaption(string name);

		                                                                    /// <summary>方法GetCheckboxStatus</summary>
		[DispId(484)]
		bool GetCheckboxStatus(string name);

		                                                                    /// <summary>方法GetCompoundBoxCodeAndValueCount</summary>
		[DispId(485)]
		int GetCompoundBoxCodeAndValueCount(string sName, int iType);

		                                                                    /// <summary>方法GetCompoundBoxCodeWithArray</summary>
		[DispId(486)]
		object GetCompoundBoxCodeWithArray(string sName, int iType);

		                                                                    /// <summary>方法GetCompoundBoxCurrentCode</summary>
		[DispId(487)]
		string GetCompoundBoxCurrentCode(string sName, int iType);

		                                                                    /// <summary>方法GetCompoundBoxCurrentValue</summary>
		[DispId(488)]
		string GetCompoundBoxCurrentValue(string sName, int iType);

		                                                                    /// <summary>方法GetCompoundBoxValueByCode</summary>
		[DispId(489)]
		string GetCompoundBoxValueByCode(string sName, string sCode, int iType);

		                                                                    /// <summary>方法GetCompoundBoxValueWithArray</summary>
		[DispId(490)]
		object GetCompoundBoxValueWithArray(string sName, int iType);

		                                                                    /// <summary>方法GetContentFileFromOneOdt</summary>
		[DispId(491)]
		string GetContentFileFromOneOdt(string strName);

		                                                                    /// <summary>方法GetControlByPasteContent</summary>
		[DispId(136)]
		string GetControlByPasteContent();

		                                                                    /// <summary>方法GetControlBySelectArea</summary>
		[DispId(137)]
		string GetControlBySelectArea();

		                                                                    /// <summary>方法GetControlVersion</summary>
		[DispId(492)]
		string GetControlVersion();

		                                                                    /// <summary>方法GetCurrentAbsoluteRowIndex</summary>
		[DispId(879)]
		int GetCurrentAbsoluteRowIndex();

		                                                                    /// <summary>方法GetCurrentCharInfo</summary>
		[DispId(493)]
		string GetCurrentCharInfo();

		                                                                    /// <summary>方法GetCurrentControlName</summary>
		[DispId(138)]
		string GetCurrentControlName();

		                                                                    /// <summary>方法GetCurrentCursorPage</summary>
		[DispId(139)]
		int GetCurrentCursorPage();

		                                                                    /// <summary>方法GetCurrentImageName</summary>
		[DispId(494)]
		string GetCurrentImageName();

		                                                                    /// <summary>方法GetCurrentImageObjectName</summary>
		[DispId(140)]
		string GetCurrentImageObjectName();

		                                                                    /// <summary>方法GetCurrentNewControlName</summary>
		[DispId(141)]
		string GetCurrentNewControlName();

		                                                                    /// <summary>方法GetCurrentPageStyle</summary>
		[DispId(495)]
		string GetCurrentPageStyle();

		                                                                    /// <summary>方法GetCurrentPostilInfo</summary>
		[DispId(496)]
		string GetCurrentPostilInfo();

		                                                                    /// <summary>方法GetCurrentProtectAreaName</summary>
		[DispId(497)]
		string GetCurrentProtectAreaName();

		                                                                    /// <summary>方法GetCurrentRegionName</summary>
		[DispId(498)]
		string GetCurrentRegionName();

		                                                                    /// <summary>方法GetCurrentRowIndex</summary>
		[DispId(142)]
		int GetCurrentRowIndex();

		                                                                    /// <summary>方法GetCurrentSectionName</summary>
		[DispId(143)]
		string GetCurrentSectionName();

		                                                                    /// <summary>方法GetCursorAbsoluteScreenXPoint</summary>
		[DispId(499)]
		int GetCursorAbsoluteScreenXPoint();

		                                                                    /// <summary>方法GetCursorAbsoluteScreenYPoint</summary>
		[DispId(500)]
		int GetCursorAbsoluteScreenYPoint();

		                                                                    /// <summary>方法GetCursorDistanceToPageTop</summary>
		[DispId(501)]
		int GetCursorDistanceToPageTop();

		                                                                    /// <summary>方法GetCursorLoction</summary>
		[DispId(502)]
		int GetCursorLoction();

		                                                                    /// <summary>方法GetDateTimeBoxOutRangeInfo</summary>
		[DispId(503)]
		string GetDateTimeBoxOutRangeInfo(string strName);

		                                                                    /// <summary>方法GetDateTimeBoxValue</summary>
		[DispId(504)]
		string GetDateTimeBoxValue(string sName);

		                                                                    /// <summary>方法GetDateTimeFormat</summary>
		[DispId(505)]
		int GetDateTimeFormat(string sName);

		                                                                    /// <summary>方法GetDateTimeFormatEx</summary>
		[DispId(506)]
		string GetDateTimeFormatEx(string sName);

		                                                                    /// <summary>方法GetDocProp</summary>
		[DispId(507)]
		bool GetDocProp(string propName);

		                                                                    /// <summary>方法GetDragMode</summary>
		[DispId(508)]
		int GetDragMode();

		                                                                    /// <summary>方法GetDynamicGridLineColor</summary>
		[DispId(509)]
		int GetDynamicGridLineColor();

		                                                                    /// <summary>方法GetEndDateTime</summary>
		[DispId(510)]
		string GetEndDateTime(string sName);

		                                                                    /// <summary>方法GetFatherRegionName</summary>
		[DispId(511)]
		string GetFatherRegionName(string strName);

		                                                                    /// <summary>方法GetFatherRegionNameOfOneStruct</summary>
		[DispId(512)]
		string GetFatherRegionNameOfOneStruct(string sStructsName);

		                                                                    /// <summary>方法GetFatherSectionName</summary>
		[DispId(513)]
		string GetFatherSectionName(string strName);

		                                                                    /// <summary>方法GetFatherXmlTreeByCurrentRegion</summary>
		[DispId(871)]
		string GetFatherXmlTreeByCurrentRegion(string flag);

		                                                                    /// <summary>方法GetFilePath</summary>
		[DispId(28)]
		string GetFilePath();

		                                                                    /// <summary>方法GetFileProperty</summary>
		[DispId(514)]
		string GetFileProperty(string itemName);

		                                                                    /// <summary>方法GetFileTitle</summary>
		[DispId(515)]
		string GetFileTitle();

		                                                                    /// <summary>方法GetFirstLevelRegionNames</summary>
		[DispId(880)]
		string GetFirstLevelRegionNames();

		                                                                    /// <summary>方法GetFirstLevelSectionName</summary>
		[DispId(516)]
		string GetFirstLevelSectionName();

		                                                                    /// <summary>方法GetFirstLevelStructNames</summary>
		[DispId(517)]
		string GetFirstLevelStructNames(int nType);

		                                                                    /// <summary>方法GetFontProp</summary>
		[DispId(518)]
		int GetFontProp(string propName);

		                                                                    /// <summary>方法GetHeaderStructStringByPage</summary>
		[DispId(29)]
		string GetHeaderStructStringByPage(int lPage);

		                                                                    /// <summary>方法GetHeaderTextByPage</summary>
		[DispId(519)]
		string GetHeaderTextByPage(int lPage);

		                                                                    /// <summary>方法GetImageCustomProperty</summary>
		[DispId(861)]
		string GetImageCustomProperty(string sImageName, string sPropName);

		                                                                    /// <summary>方法GetImageLockType</summary>
		[DispId(520)]
		int GetImageLockType(string sName);

		                                                                    /// <summary>方法GetImageScreenEndXPoint</summary>
		[DispId(521)]
		int GetImageScreenEndXPoint(string sName);

		                                                                    /// <summary>方法GetImageScreenEndYPoint</summary>
		[DispId(522)]
		int GetImageScreenEndYPoint(string sName);

		                                                                    /// <summary>方法GetImageScreenStartXPoint</summary>
		[DispId(523)]
		int GetImageScreenStartXPoint(string sName);

		                                                                    /// <summary>方法GetImageScreenStartYPoint</summary>
		[DispId(524)]
		int GetImageScreenStartYPoint(string sName);

		                                                                    /// <summary>方法GetIncompletedCtrlNameList</summary>
		[DispId(30)]
		string GetIncompletedCtrlNameList();

		                                                                    /// <summary>方法GetInsertMode</summary>
		[DispId(525)]
		int GetInsertMode();

		                                                                    /// <summary>方法GetLastCharInfoBeforeCurLine</summary>
		[DispId(857)]
		string GetLastCharInfoBeforeCurLine();

		                                                                    /// <summary>方法GetMedicalformulaText</summary>
		[DispId(144)]
		string GetMedicalformulaText(string sName);

		                                                                    /// <summary>方法GetMedicalformulaTypeByName</summary>
		[DispId(145)]
		int GetMedicalformulaTypeByName(string sName);

		                                                                    /// <summary>方法GetMultiBoxMutexString</summary>
		[DispId(526)]
		string GetMultiBoxMutexString(string strName, int iType);

		                                                                    /// <summary>方法GetMultiCheckboxCodeWithArray</summary>
		[DispId(892)]
		string[] GetMultiCheckboxCodeWithArray(string strName);

		                                                                    /// <summary>方法GetMultiCheckboxValueWithArray</summary>
		[DispId(893)]
		string[] GetMultiCheckboxValueWithArray(string strName);

		                                                                    /// <summary>方法GetNewControlBegin</summary>
		[DispId(146)]
		int GetNewControlBegin(string sName);

		                                                                    /// <summary>方法GetNewControlCountByType</summary>
		[DispId(527)]
		int GetNewControlCountByType(int lType);

		                                                                    /// <summary>方法GetNewControlEnd</summary>
		[DispId(147)]
		int GetNewControlEnd(string sName);

		                                                                    /// <summary>方法GetNewControlNameByType</summary>
		[DispId(528)]
		string GetNewControlNameByType(int lType);

		                                                                    /// <summary>方法GetNewControlPrintAttribute</summary>
		[DispId(529)]
		bool GetNewControlPrintAttribute(string sName);

		                                                                    /// <summary>方法GetNewControlProp</summary>
		[DispId(31)]
		string GetNewControlProp(string name, string propertyName);

		                                                                    /// <summary>方法GetNewControlText</summary>
		[DispId(32)]
		string GetNewControlText(string sName);

		                                                                    /// <summary>方法GetNextControl</summary>
		[DispId(33)]
		Control GetNextControl(Control control_0, bool forward);

		                                                                    /// <summary>方法GetNumboxErrorInputInfo</summary>
		[DispId(530)]
		string GetNumboxErrorInputInfo(string strName);

		                                                                    /// <summary>方法GetNumboxMaxValue</summary>
		[DispId(34)]
		double GetNumboxMaxValue(string name);

		                                                                    /// <summary>方法GetNumboxMinValue</summary>
		[DispId(35)]
		double GetNumboxMinValue(string name);

		                                                                    /// <summary>方法GetNumboxOutRangeInfo</summary>
		[DispId(531)]
		string GetNumboxOutRangeInfo(string strName);

		                                                                    /// <summary>方法GetNumboxPrecision</summary>
		[DispId(532)]
		int GetNumboxPrecision(string name);

		                                                                    /// <summary>方法GetNumboxText</summary>
		[DispId(533)]
		int GetNumboxText(string name);

		                                                                    /// <summary>方法GetNumboxUnit</summary>
		[DispId(534)]
		string GetNumboxUnit(string name);

		                                                                    /// <summary>方法GetObjectByPasteContent</summary>
		[DispId(148)]
		string GetObjectByPasteContent();

		                                                                    /// <summary>方法GetObjectBySelectArea</summary>
		[DispId(149)]
		string GetObjectBySelectArea();

		                                                                    /// <summary>方法GetOfficeInstallPath</summary>
		[DispId(535)]
		string GetOfficeInstallPath(short edition);

		                                                                    /// <summary>方法GetOfficeVersion</summary>
		[DispId(536)]
		string GetOfficeVersion();

		                                                                    /// <summary>方法GetOneFileStructsInfoWithoutOpened</summary>
		[DispId(537)]
		string GetOneFileStructsInfoWithoutOpened(string sFileName, string sRev);

		                                                                    /// <summary>方法GetOneFileStructsInfoWithoutOpenedWithStream</summary>
		[DispId(538)]
		string GetOneFileStructsInfoWithoutOpenedWithStream(object stmFile, string sRev);

		                                                                    /// <summary>方法GetOneFileStructsInfoWithoutOpenedWithString</summary>
		[DispId(539)]
		string GetOneFileStructsInfoWithoutOpenedWithString(string base64String, string sRev);

		                                                                    /// <summary>方法GetOneRangeMd5</summary>
		[DispId(540)]
		string GetOneRangeMd5();

		                                                                    /// <summary>方法GetOpenedDocumentList</summary>
		[DispId(541)]
		string GetOpenedDocumentList();

		                                                                    /// <summary>方法GetOutestRegionNameByCurrentCursor</summary>
		[DispId(881)]
		string GetOutestRegionNameByCurrentCursor();

		                                                                    /// <summary>方法GetPageCount</summary>
		[DispId(36)]
		int GetPageCount();

		                                                                    /// <summary>方法GetParagraphProp</summary>
		[DispId(542)]
		int GetParagraphProp(string propName);

		                                                                    /// <summary>方法GetParaLineSpacing</summary>
		[DispId(543)]
		string GetParaLineSpacing();

		                                                                    /// <summary>方法GetParaProtectAreaBegin</summary>
		[DispId(544)]
		int GetParaProtectAreaBegin(string sName);

		                                                                    /// <summary>方法GetParaProtectAreaEnd</summary>
		[DispId(545)]
		int GetParaProtectAreaEnd(string sName);

		                                                                    /// <summary>方法GetParaProtectAreaProp</summary>
		[DispId(546)]
		string GetParaProtectAreaProp(string sName, string sProp);

		                                                                    /// <summary>方法GetParaProtectAreaText</summary>
		[DispId(547)]
		string GetParaProtectAreaText(string sName);

		                                                                    /// <summary>方法GetPreviousCharInfo</summary>
		[DispId(548)]
		string GetPreviousCharInfo();

		                                                                    /// <summary>方法GetPrinterName</summary>
		[DispId(549)]
		string GetPrinterName();

		                                                                    /// <summary>方法GetProtectAreaBegin</summary>
		[DispId(550)]
		int GetProtectAreaBegin(string sName);

		                                                                    /// <summary>方法GetProtectAreaEnd</summary>
		[DispId(551)]
		int GetProtectAreaEnd(string sName);

		                                                                    /// <summary>方法GetProtectAreaProp</summary>
		[DispId(37)]
		string GetProtectAreaProp(string name, string propertyName);

		                                                                    /// <summary>方法GetProtectAreaText</summary>
		[DispId(552)]
		string GetProtectAreaText(string sName);

		                                                                    /// <summary>方法GetRadioButtonCodeWithArray</summary>
		[DispId(553)]
		object GetRadioButtonCodeWithArray(string sName);

		                                                                    /// <summary>方法GetRadioButtonSelectItemCode</summary>
		[DispId(554)]
		string GetRadioButtonSelectItemCode(string sName);

		                                                                    /// <summary>方法GetRadioButtonSelectItemIndex</summary>
		[DispId(555)]
		int GetRadioButtonSelectItemIndex(string sName);

		                                                                    /// <summary>方法GetRadioButtonSelectItemValue</summary>
		[DispId(556)]
		string GetRadioButtonSelectItemValue(string sName);

		                                                                    /// <summary>方法GetRadioButtonShowStatus</summary>
		[DispId(557)]
		int GetRadioButtonShowStatus(string sName);

		                                                                    /// <summary>方法GetRadioButtonValueWithArray</summary>
		[DispId(558)]
		object GetRadioButtonValueWithArray(string sName);

		                                                                    /// <summary>方法GetRecensionCount</summary>
		[DispId(150)]
		int GetRecensionCount();

		                                                                    /// <summary>方法GetRecensionInfoByRequiment</summary>
		[DispId(38)]
		string GetRecensionInfoByRequiment(string sAuthors, string sIDs, int sChangeTypes, DateTime sTimeStart, DateTime sTimeEnd);

		                                                                    /// <summary>方法GetRecensionState</summary>
		[DispId(560)]
		int GetRecensionState();

		                                                                    /// <summary>方法GetRegionBegin</summary>
		[DispId(561)]
		int GetRegionBegin(string sName);

		                                                                    /// <summary>方法GetRegionEnd</summary>
		[DispId(562)]
		int GetRegionEnd(string sName);

		                                                                    /// <summary>方法GetRegionNamesByEndPosOfPage</summary>
		[DispId(889)]
		string GetRegionNamesByEndPosOfPage(int nFlag);

		                                                                    /// <summary>方法GetRegionNamesByPage</summary>
		[DispId(882)]
		string GetRegionNamesByPage(string sPageRange, bool flag);

		                                                                    /// <summary>方法GetRegionNamesBySelectArea</summary>
		[DispId(563)]
		string GetRegionNamesBySelectArea();

		                                                                    /// <summary>方法GetRegionProp</summary>
		[DispId(564)]
		string GetRegionProp(string sName, string sProp);

		                                                                    /// <summary>方法GetRegionText</summary>
		[DispId(565)]
		string GetRegionText(string sName);

		                                                                    /// <summary>方法GetRegionTitle</summary>
		[DispId(566)]
		string GetRegionTitle(string strName);

		                                                                    /// <summary>方法GetRegionXmlInfoByParament</summary>
		[DispId(567)]
		string GetRegionXmlInfoByParament(string strName, string aSctContType, string aCtrlContType, string sRev1, string sRev2, string sRev3);

		                                                                    /// <summary>方法GetReserveAttrOfImage</summary>
		[DispId(568)]
		string GetReserveAttrOfImage(string sName);

		                                                                    /// <summary>方法GetReserveAttrOfImageObject</summary>
		[DispId(569)]
		string GetReserveAttrOfImageObject(string sName);

		                                                                    /// <summary>方法GetRowCount</summary>
		[DispId(39)]
		int GetRowCount(int pageIndex);

		                                                                    /// <summary>方法GetSearchTextCount</summary>
		[DispId(151)]
		int GetSearchTextCount(string sText);

		                                                                    /// <summary>方法GetSecretInfoFromOneStruct</summary>
		[DispId(570)]
		string GetSecretInfoFromOneStruct(string sStructName);

		                                                                    /// <summary>方法GetSectionBegin</summary>
		[DispId(253)]
		int GetSectionBegin(string sName);

		                                                                    /// <summary>方法GetSectionByPasteContent</summary>
		[DispId(152)]
		string GetSectionByPasteContent();

		                                                                    /// <summary>方法GetSectionBySelectArea</summary>
		[DispId(254)]
		string GetSectionBySelectArea();

		                                                                    /// <summary>方法GetSectionContentBySectionName</summary>
		[DispId(571)]
		string GetSectionContentBySectionName(string strSectionName);

		                                                                    /// <summary>方法GetSectionEnd</summary>
		[DispId(255)]
		int GetSectionEnd(string sName);

		                                                                    /// <summary>方法GetSectionProp</summary>
		[DispId(40)]
		string GetSectionProp(string name, string propertyName);

		                                                                    /// <summary>方法GetSectionText</summary>
		[DispId(41)]
		string GetSectionText(string name);

		                                                                    /// <summary>方法GetSelectAreaXmlInfoByParament</summary>
		[DispId(42)]
		string GetSelectAreaXmlInfoByParament(string aSctContType, string aCtrlContType, string sRev1, string sRev2, string sRev3);

		                                                                    /// <summary>方法GetSelectError</summary>
		[DispId(153)]
		bool GetSelectError();

		                                                                    /// <summary>方法GetSelectionEndAtCurrentPage</summary>
		[DispId(572)]
		int GetSelectionEndAtCurrentPage();

		                                                                    /// <summary>方法GetSelectionRangeEnd</summary>
		[DispId(43)]
		int GetSelectionRangeEnd();

		                                                                    /// <summary>方法GetSelectionRangeStar</summary>
		[DispId(44)]
		int GetSelectionRangeStar();

		                                                                    /// <summary>方法GetSelectionStartAtCurrentPage</summary>
		[DispId(573)]
		int GetSelectionStartAtCurrentPage();

		                                                                    /// <summary>方法GetSelectNewControl</summary>
		[DispId(45)]
		string GetSelectNewControl();

		                                                                    /// <summary>方法GetSelectText</summary>
		[DispId(154)]
		string GetSelectText();

		                                                                    /// <summary>方法GetStartDateTime</summary>
		[DispId(574)]
		string GetStartDateTime(string sName);

		                                                                    /// <summary>方法GetStatusAfterMerged</summary>
		[DispId(575)]
		int GetStatusAfterMerged();

		                                                                    /// <summary>方法GetStructAllUserProps</summary>
		[DispId(576)]
		string GetStructAllUserProps(string sStructName);

		                                                                    /// <summary>方法GetStructLevelAtCurrentCursor</summary>
		[DispId(577)]
		string GetStructLevelAtCurrentCursor();

		                                                                    /// <summary>方法GetStructNamesByOneRegion</summary>
		[DispId(578)]
		string GetStructNamesByOneRegion(string sRegin, int lStructType);

		                                                                    /// <summary>方法GetStructScreenEndXPoint</summary>
		[DispId(579)]
		int GetStructScreenEndXPoint(string sName);

		                                                                    /// <summary>方法GetStructScreenEndYPoint</summary>
		[DispId(580)]
		int GetStructScreenEndYPoint(string sName);

		                                                                    /// <summary>方法GetStructScreenStartXPoint</summary>
		[DispId(581)]
		int GetStructScreenStartXPoint(string sName);

		                                                                    /// <summary>方法GetStructScreenStartYPoint</summary>
		[DispId(582)]
		int GetStructScreenStartYPoint(string sName);

		                                                                    /// <summary>方法GetStructsXmlInfoByParament</summary>
		[DispId(155)]
		string GetStructsXmlInfoByParament(string aSctContType, string aCtrlContType, string sRev1, string sRev2, string sRev3);

		                                                                    /// <summary>方法GetStructTypeByName</summary>
		[DispId(46)]
		int GetStructTypeByName(string name);

		                                                                    /// <summary>方法GetSurplusLinesOfOnePage</summary>
		[DispId(256)]
		int GetSurplusLinesOfOnePage(int lPageNumber);

		                                                                    /// <summary>方法GetTableCellCustomProperty</summary>
		[DispId(583)]
		string GetTableCellCustomProperty(string sTableName, string sCellName, string sPropertyName);

		                                                                    /// <summary>方法GetTableCellNameByCurrentCursor</summary>
		[DispId(109)]
		string GetTableCellNameByCurrentCursor();

		                                                                    /// <summary>方法GetTableColCount</summary>
		[DispId(108)]
		int GetTableColCount(string sName);

		                                                                    /// <summary>方法GetTableCustomProperty</summary>
		[DispId(156)]
		string GetTableCustomProperty(string sTable, string ssPropertyName);

		                                                                    /// <summary>方法GetTableNameByCurrentCursor</summary>
		[DispId(157)]
		string GetTableNameByCurrentCursor();

		                                                                    /// <summary>方法GetTableRowCount</summary>
		[DispId(158)]
		int GetTableRowCount(string sName);

		                                                                    /// <summary>方法GetTableTextBetweenTwoCells</summary>
		[DispId(584)]
		string GetTableTextBetweenTwoCells(string sTableName, string sBeginCell, string sEndCell);

		                                                                    /// <summary>方法GetTableWidth</summary>
		[DispId(585)]
		int GetTableWidth(string strTableName);

		                                                                    /// <summary>方法GetTextBetweenTwoStructs</summary>
		[DispId(586)]
		string GetTextBetweenTwoStructs(string sStartName, string sEndName);

		                                                                    /// <summary>方法GetTextBoxMaxLen</summary>
		[DispId(587)]
		int GetTextBoxMaxLen(string sName);

		                                                                    /// <summary>方法GetTextFromDocument</summary>
		[DispId(588)]
		string GetTextFromDocument();

		                                                                    /// <summary>方法GetTrackRevisions</summary>
		[DispId(159)]
		bool GetTrackRevisions();

		                                                                    /// <summary>方法GetTypeByStructName</summary>
		[DispId(47)]
		string GetTypeByStructName(string name);

		                                                                    /// <summary>方法GetUsingDictName</summary>
		[DispId(160)]
		string GetUsingDictName();

		                                                                    /// <summary>方法GetVScrollbarPos</summary>
		[DispId(862)]
		int GetVScrollbarPos();

		                                                                    /// <summary>方法GetXmlInfoWithTable</summary>
		[DispId(589)]
		string GetXmlInfoWithTable(string sTableName, string sTableProp, string sRegionProp, string sSectionProp, string sNewControlProp, string sTableCellProp, string sRev1, string sRev2);

		                                                                    /// <summary>方法GetXmlWithFirstLevelRegionByCurrentDoc</summary>
		[DispId(883)]
		string GetXmlWithFirstLevelRegionByCurrentDoc();

		                                                                    /// <summary>方法HandleBackspace</summary>
		[DispId(884)]
		bool HandleBackspace();

		                                                                    /// <summary>方法HasFileOpened</summary>
		[DispId(161)]
		string HasFileOpened();

		                                                                    /// <summary>方法HasFooter</summary>
		[DispId(590)]
		bool HasFooter();

		                                                                    /// <summary>方法HasHeader</summary>
		[DispId(591)]
		bool HasHeader();

		                                                                    /// <summary>方法HasHeaderByPage</summary>
		[DispId(592)]
		bool HasHeaderByPage(int lPage);

		                                                                    /// <summary>方法HasSofficeBin</summary>
		[DispId(593)]
		bool HasSofficeBin();

		                                                                    /// <summary>方法HideMenuItem</summary>
		[DispId(594)]
		void HideMenuItem(string strMenuName);

		                                                                    /// <summary>方法ImportFileAtCurrentCursor</summary>
		[DispId(162)]
		string ImportFileAtCurrentCursor(string sFileUrl);

		                                                                    /// <summary>方法ImportFileAtCurrentCursorWithStream</summary>
		[DispId(595)]
		string ImportFileAtCurrentCursorWithStream(object stmFile);

		                                                                    /// <summary>方法ImportFileAtCurrentCursorWithString</summary>
		[DispId(596)]
		string ImportFileAtCurrentCursorWithString(string base64String);

		                                                                    /// <summary>方法ImportOneDict</summary>
		[DispId(163)]
		bool ImportOneDict(string sName);

		                                                                    /// <summary>方法ImportOneDictWithStream</summary>
		[DispId(597)]
		bool ImportOneDictWithStream(string sName, object stmFile);

		                                                                    /// <summary>方法ImportOneDictWithString</summary>
		[DispId(598)]
		bool ImportOneDictWithString(string sName, string sBase64FileString);

		                                                                    /// <summary>方法IncMultiCols</summary>
		[DispId(110)]
		bool IncMultiCols(string sName, int index, int count);

		                                                                    /// <summary>方法IncMultiRows</summary>
		[DispId(164)]
		bool IncMultiRows(string TableN, int index, int count);

		                                                                    /// <summary>方法InitForWinning</summary>
		[DispId(895)]
		void InitForWinning(string registerCode);

		                                                                    /// <summary>方法InsertBlankArea</summary>
		[DispId(599)]
		bool InsertBlankArea(int nHeight, int nTopDistance);

		                                                                    /// <summary>方法InsertExternalSubMenuItem</summary>
		[DispId(600)]
		bool InsertExternalSubMenuItem(string strRootCommand, string strExternalCommand, string strLabel, string strPngPath);

		                                                                    /// <summary>方法InsertExternalToolbarItem</summary>
		[DispId(49)]
		bool InsertExternalToolbarItem(string strToolbar, string strExternalCommand, string strLabel, string strPngPath);

		                                                                    /// <summary>方法InsertFile</summary>
		[DispId(165)]
		void InsertFile(string FilePath);

		                                                                    /// <summary>方法InsertFileWithStream</summary>
		[DispId(50)]
		bool InsertFileWithStream(object stmFile);

		                                                                    /// <summary>方法InsertFileWithString</summary>
		[DispId(601)]
		bool InsertFileWithString(string base64String);

		                                                                    /// <summary>方法InsertFooter</summary>
		[DispId(602)]
		bool InsertFooter();

		                                                                    /// <summary>方法InsertHeader</summary>
		[DispId(603)]
		bool InsertHeader();

		                                                                    /// <summary>方法InsertHyperlinkInWriter</summary>
		[DispId(604)]
		void InsertHyperlinkInWriter(string string_0, string textToDisplay);

		                                                                    /// <summary>方法InsertInternalSubMenuItem</summary>
		[DispId(885)]
		bool InsertInternalSubMenuItem(string strRootCommand, string strInternalCommand);

		                                                                    /// <summary>方法InsertInternalToolbarItem</summary>
		[DispId(51)]
		bool InsertInternalToolbarItem(string strToolbar, string strInternalCommand);

		                                                                    /// <summary>方法InsertLineNumber</summary>
		[DispId(52)]
		void InsertLineNumber(bool bViewLineNum, int nOffset, bool bRestartEachPage, bool bCountBlankLines);

		                                                                    /// <summary>方法InsertMedicalformula</summary>
		[DispId(605)]
		bool InsertMedicalformula(int nType, string sID, object sContent);

		                                                                    /// <summary>方法InsertNewControlAtCurrentCursor</summary>
		[DispId(53)]
		string InsertNewControlAtCurrentCursor(string name, string text, int ctrlType);

		                                                                    /// <summary>方法InsertNewLine</summary>
		[DispId(166)]
		bool InsertNewLine(int nPosition);

		                                                                    /// <summary>方法InsertParaProtectArea</summary>
		[DispId(606)]
		bool InsertParaProtectArea(string sName, int nColor);

		                                                                    /// <summary>方法InsertProtectArea</summary>
		[DispId(607)]
		string InsertProtectArea(string sName);

		                                                                    /// <summary>方法InsertRegionAfterNamedRegion</summary>
		[DispId(608)]
		bool InsertRegionAfterNamedRegion(string strInsertRegion, string strNamedRegion);

		                                                                    /// <summary>方法InsertRegionAtCurrentCursor</summary>
		[DispId(609)]
		string InsertRegionAtCurrentCursor(string sName);

		                                                                    /// <summary>方法InsertRegionBeforeNamedRegion</summary>
		[DispId(610)]
		bool InsertRegionBeforeNamedRegion(string strInsertRegion, string strNamedRegion);

		                                                                    /// <summary>方法InsertSectionAtCurrentCursor</summary>
		[DispId(167)]
		string InsertSectionAtCurrentCursor(string sName, string sText);

		                                                                    /// <summary>方法InsertSectionAtCurrentCursor2</summary>
		[DispId(611)]
		string InsertSectionAtCurrentCursor2(string sName);

		                                                                    /// <summary>方法InsertSpecialPageBreak</summary>
		[DispId(612)]
		bool InsertSpecialPageBreak();

		                                                                    /// <summary>方法InsertTabAtCurrentCursor</summary>
		[DispId(613)]
		bool InsertTabAtCurrentCursor(int nTabStopAlignment, int nTabPos);

		                                                                    /// <summary>方法InsertTable</summary>
		[DispId(168)]
		void InsertTable(string TableN, int int_0, int int_1);

		                                                                    /// <summary>方法InsertTableWithoutHeader</summary>
		[DispId(614)]
		bool InsertTableWithoutHeader(string tableN, int int_0, int int_1);

		                                                                    /// <summary>方法InsertTabStopAtCurrentCursor</summary>
		[DispId(615)]
		bool InsertTabStopAtCurrentCursor();

		                                                                    /// <summary>方法InsertTextAtCurrentCursor</summary>
		[DispId(54)]
		void InsertTextAtCurrentCursor(string sText);

		                                                                    /// <summary>方法InsertTextboxAtSelection</summary>
		[DispId(616)]
		string InsertTextboxAtSelection(string sName);

		                                                                    /// <summary>方法InsertToolbarItem</summary>
		[DispId(617)]
		bool InsertToolbarItem(string strPic, string strUNO, string strHelpText);

		                                                                    /// <summary>方法IsCurrentLineEmpty</summary>
		[DispId(257)]
		bool IsCurrentLineEmpty();

		                                                                    /// <summary>方法IsCurrentLineOverHalfLine</summary>
		[DispId(618)]
		bool IsCurrentLineOverHalfLine();

		                                                                    /// <summary>方法IsCursorAfterLastViewCharLine</summary>
		[DispId(619)]
		bool IsCursorAfterLastViewCharLine();

		                                                                    /// <summary>方法IsCursorAfterLastViewCharPage</summary>
		[DispId(620)]
		bool IsCursorAfterLastViewCharPage();

		                                                                    /// <summary>方法IsCursorBeforeFirstViewCharLine</summary>
		[DispId(621)]
		bool IsCursorBeforeFirstViewCharLine();

		                                                                    /// <summary>方法IsDocHasWaterMark</summary>
		[DispId(169)]
		int IsDocHasWaterMark();

		                                                                    /// <summary>方法IsDocModified</summary>
		[DispId(55)]
		bool IsDocModified();

		                                                                    /// <summary>方法IsInPrintPreView</summary>
		[DispId(622)]
		bool IsInPrintPreView();

		                                                                    /// <summary>方法IsIntellectiveInputOn</summary>
		[DispId(623)]
		bool IsIntellectiveInputOn();

		                                                                    /// <summary>方法IsLineNumberOn</summary>
		[DispId(624)]
		bool IsLineNumberOn();

		                                                                    /// <summary>方法IsProtectedMode</summary>
		[DispId(56)]
		bool IsProtectedMode();

		                                                                    /// <summary>方法IsRegionTitleVisible</summary>
		[DispId(625)]
		bool IsRegionTitleVisible(string strName);

		                                                                    /// <summary>方法IsStructInMainbody</summary>
		[DispId(626)]
		int IsStructInMainbody(string sName, int lStructType);

		                                                                    /// <summary>方法IsTableCellProtected</summary>
		[DispId(170)]
		bool IsTableCellProtected(string sTable, string sCell);

		                                                                    /// <summary>方法IsTableProtected</summary>
		[DispId(171)]
		bool IsTableProtected(string sTable);

		                                                                    /// <summary>方法IsToolbarItemOn</summary>
		[DispId(627)]
		bool IsToolbarItemOn(string strUNO);

		                                                                    /// <summary>方法IsUserRootMenuItemOn</summary>
		[DispId(628)]
		bool IsUserRootMenuItemOn(string strRootCommand);

		                                                                    /// <summary>方法IsUserSubMenuItemOn</summary>
		[DispId(629)]
		bool IsUserSubMenuItemOn(string strRootCommand, string strSubCommmand);

		                                                                    /// <summary>方法IsUserToolbarItemOn</summary>
		[DispId(630)]
		bool IsUserToolbarItemOn(string strToolbar, string strToolbarItem);

		                                                                    /// <summary>方法JumpToEndOfPage</summary>
		[DispId(863)]
		void JumpToEndOfPage();

		                                                                    /// <summary>方法JumpToFileEnd</summary>
		[DispId(57)]
		bool JumpToFileEnd();

		                                                                    /// <summary>方法JumpToFirstPage</summary>
		[DispId(172)]
		void JumpToFirstPage();

		                                                                    /// <summary>方法JumpToFooter</summary>
		[DispId(631)]
		void JumpToFooter();

		                                                                    /// <summary>方法JumpToFooterByPage</summary>
		[DispId(632)]
		bool JumpToFooterByPage(int lPage);

		                                                                    /// <summary>方法JumpToHeader</summary>
		[DispId(633)]
		void JumpToHeader();

		                                                                    /// <summary>方法JumpToHeaderByPage</summary>
		[DispId(634)]
		bool JumpToHeaderByPage(int lPage);

		                                                                    /// <summary>方法JumpToLastPage</summary>
		[DispId(173)]
		void JumpToLastPage();

		                                                                    /// <summary>方法JumpToMainbody</summary>
		[DispId(635)]
		void JumpToMainbody();

		                                                                    /// <summary>方法JumpToNextPage</summary>
		[DispId(174)]
		void JumpToNextPage();

		                                                                    /// <summary>方法JumpToOnePostil</summary>
		[DispId(636)]
		void JumpToOnePostil(string sContent, string sTime);

		                                                                    /// <summary>方法JumpToOnePostion</summary>
		[DispId(58)]
		void JumpToOnePostion(int position);

		                                                                    /// <summary>方法JumpToOneSearchPos</summary>
		[DispId(175)]
		bool JumpToOneSearchPos(string sText, int lpos);

		                                                                    /// <summary>方法JumpToPage</summary>
		[DispId(637)]
		void JumpToPage(short PageIndex);

		                                                                    /// <summary>方法JumpToPreviousPage</summary>
		[DispId(176)]
		void JumpToPreviousPage();

		                                                                    /// <summary>方法JumpToSpecificLineOfPage</summary>
		[DispId(638)]
		bool JumpToSpecificLineOfPage(int lPage, int lLine);

		                                                                    /// <summary>方法JumpToStartOfPage</summary>
		[DispId(864)]
		void JumpToStartOfPage();

		                                                                    /// <summary>方法KillSofficeBin</summary>
		[DispId(639)]
		bool KillSofficeBin();

		                                                                    /// <summary>方法LimitNumOfPasteCharacters</summary>
		[DispId(640)]
		bool LimitNumOfPasteCharacters(bool bLimit, int nCharacters);

		                                                                    /// <summary>方法LockControlLock</summary>
		[DispId(641)]
		void LockControlLock(bool bLocked);

		                                                                    /// <summary>方法MergeDocuments</summary>
		[DispId(60)]
		bool MergeDocuments(bool bDifferentHeader, bool bFirstDifferentHeader, string sFileUrl);

		                                                                    /// <summary>方法MergeDocumentsWithStream</summary>
		[DispId(642)]
		bool MergeDocumentsWithStream(bool bDifferentHeader, bool bFirstDifferentHeader, object stmFile);

		                                                                    /// <summary>方法MergeDocumentsWithString</summary>
		[DispId(643)]
		bool MergeDocumentsWithString(bool bDifferentHeader, bool bFirstDifferentHeader, string base64String);

		                                                                    /// <summary>方法MergeSectionParagraph</summary>
		[DispId(644)]
		bool MergeSectionParagraph(string strName);

		                                                                    /// <summary>方法MergeTableCellRange</summary>
		[DispId(645)]
		bool MergeTableCellRange(string sTable, string sStartCell, string sEndCell);

		                                                                    /// <summary>方法OpenDocument</summary>
		[DispId(61)]
		WdInfo OpenDocument(string fileName, int nFlag);

		                                                                    /// <summary>方法OpenDocumentWithStream</summary>
		[DispId(62)]
		WdInfo OpenDocumentWithStream(object stmLoad, int nFlag);

		                                                                    /// <summary>方法OpenDocumentWithString</summary>
		[DispId(646)]
		WdInfo OpenDocumentWithString(string sContent, int nFlag);

		                                                                    /// <summary>方法Paste</summary>
		[DispId(647)]
		void Paste();

		                                                                    /// <summary>方法PasteAtCurrentCursor</summary>
		[DispId(177)]
		string PasteAtCurrentCursor();

		                                                                    /// <summary>方法PasteAtCurrentCursor2</summary>
		[DispId(858)]
		bool PasteAtCurrentCursor2();

		                                                                    /// <summary>方法PasteWithoutFormat</summary>
		[DispId(648)]
		void PasteWithoutFormat();

		                                                                    /// <summary>方法PreviewDocByPage</summary>
		[DispId(649)]
		bool PreviewDocByPage(int nPageID);

		                                                                    /// <summary>方法PreviewDocBySelect</summary>
		[DispId(650)]
		bool PreviewDocBySelect();

		                                                                    /// <summary>方法PreviewDocBySelect2</summary>
		[DispId(651)]
		bool PreviewDocBySelect2(bool bShowFirstHeader);

		                                                                    /// <summary>方法Print</summary>
		[DispId(652)]
		bool Print(string pageType, int copies, string pageNumbers);

		                                                                    /// <summary>方法PrintDoc</summary>
		[DispId(237)]
		void PrintDoc(bool ShowDialog);

		                                                                    /// <summary>方法PrintDocByLine</summary>
		[DispId(63)]
		bool PrintDocByLine(bool bAutoSetPrinter, bool bFirstPageHeadFooter, int nCopyNum, int aBeginPage, int aBeginRow, int aEndPage, int aEndRow);

		                                                                    /// <summary>方法PrintDocByLine2</summary>
		[DispId(653)]
		bool PrintDocByLine2(bool bAutoSetPrinter, bool bFirstPageHeadFooter, int nCopyNum, int aBeginPage, int aBeginRow, int aEndPage, int aEndRow);

		                                                                    /// <summary>方法PrintDocByOddEven</summary>
		[DispId(258)]
		bool PrintDocByOddEven(int nType);

		                                                                    /// <summary>方法PrintDocBySelect</summary>
		[DispId(654)]
		bool PrintDocBySelect(bool bFirstPageHeadFooter);

		                                                                    /// <summary>方法PrintDocBySelectWithoutHeaderFooter</summary>
		[DispId(655)]
		bool PrintDocBySelectWithoutHeaderFooter();

		                                                                    /// <summary>方法PrintPreview</summary>
		[DispId(656)]
		bool PrintPreview(bool bViewLineNumber);

		                                                                    /// <summary>方法ProtectDoc</summary>
		[DispId(65)]
		bool ProtectDoc(bool bProtect);

		                                                                    /// <summary>方法ProtectTable</summary>
		[DispId(113)]
		bool ProtectTable(string sTable, bool bProtected);

		                                                                    /// <summary>方法ProtectTableByCell</summary>
		[DispId(178)]
		bool ProtectTableByCell(string sTable, string sCell, bool bProtected);

		                                                                    /// <summary>方法PutCellContent</summary>
		[DispId(179)]
		bool PutCellContent(string TableN, string cellN, string string_0);

		                                                                    /// <summary>方法PutCellContentByArray</summary>
		[DispId(657)]
		bool PutCellContentByArray(string strTableName, object lstCell, object lstContent);

		                                                                    /// <summary>方法Redo</summary>
		[DispId(180)]
		void Redo();

		                                                                    /// <summary>方法RejectRecension</summary>
		[DispId(238)]
		void RejectRecension();

		                                                                    /// <summary>方法ReloadDoc</summary>
		[DispId(658)]
		WdInfo ReloadDoc();

		                                                                    /// <summary>方法RemoveAllListener</summary>
		[DispId(66)]
		void RemoveAllListener();

		                                                                    /// <summary>方法RemoveAllStructsListeners</summary>
		[DispId(865)]
		void RemoveAllStructsListeners();

		                                                                    /// <summary>方法RemoveAllSubMenuItem</summary>
		[DispId(659)]
		bool RemoveAllSubMenuItem(string strRootCommand);

		                                                                    /// <summary>方法RemoveAllUserToolbarItem</summary>
		[DispId(67)]
		bool RemoveAllUserToolbarItem(string strToolbar);

		                                                                    /// <summary>方法RemoveAllUsingDict</summary>
		[DispId(181)]
		void RemoveAllUsingDict();

		                                                                    /// <summary>方法RemoveDragDropListner</summary>
		[DispId(660)]
		void RemoveDragDropListner();

		                                                                    /// <summary>方法RemoveExternalSubMenuItem</summary>
		[DispId(661)]
		bool RemoveExternalSubMenuItem(string strRootCommand, string strExternalCommand);

		                                                                    /// <summary>方法RemoveExternalToolbarItem</summary>
		[DispId(662)]
		bool RemoveExternalToolbarItem(string strToolbar, string strExternalCommand);

		                                                                    /// <summary>方法RemoveFileFromSofficeBin</summary>
		[DispId(68)]
		bool RemoveFileFromSofficeBin(string sFileName);

		                                                                    /// <summary>方法RemoveFileListener</summary>
		[DispId(663)]
		void RemoveFileListener();

		                                                                    /// <summary>方法RemoveGlobalDocumentListener</summary>
		[DispId(182)]
		void RemoveGlobalDocumentListener();

		                                                                    /// <summary>方法RemoveInternalSubMenuItem</summary>
		[DispId(664)]
		bool RemoveInternalSubMenuItem(string strRootCommand, string strInternalCommand);

		                                                                    /// <summary>方法RemoveInternalToolbarItem</summary>
		[DispId(665)]
		bool RemoveInternalToolbarItem(string strToolbar, string strInternalCommand);

		                                                                    /// <summary>方法RemoveKeyListener</summary>
		[DispId(183)]
		void RemoveKeyListener();

		                                                                    /// <summary>方法RemoveMouseListener</summary>
		[DispId(184)]
		void RemoveMouseListener();

		                                                                    /// <summary>方法RemoveNewFilesFromSofficeBin</summary>
		[DispId(666)]
		bool RemoveNewFilesFromSofficeBin();

		                                                                    /// <summary>方法RemoveSelectionChangedListener</summary>
		[DispId(667)]
		void RemoveSelectionChangedListener();

		                                                                    /// <summary>方法RemoveToolbarItem</summary>
		[DispId(668)]
		void RemoveToolbarItem(string strUNO);

		                                                                    /// <summary>方法RemoveToolbarItemAll</summary>
		[DispId(669)]
		void RemoveToolbarItemAll(int nBarNum);

		                                                                    /// <summary>方法RemoveUnusedFromSofficeBin</summary>
		[DispId(69)]
		void RemoveUnusedFromSofficeBin(int int_0, int int_1);

		                                                                    /// <summary>方法RemoveUserRootMenuItem</summary>
		[DispId(670)]
		bool RemoveUserRootMenuItem(string strRootCommand);

		                                                                    /// <summary>方法RemoveUserToolbar</summary>
		[DispId(671)]
		bool RemoveUserToolbar(string strToolbar);

		                                                                    /// <summary>方法RemoveUsingDict</summary>
		[DispId(185)]
		int RemoveUsingDict(string sName);

		                                                                    /// <summary>方法RenameExternalSubMenuItem</summary>
		[DispId(672)]
		bool RenameExternalSubMenuItem(string strRootCommand, string strExternalCommand, string strNewLabel);

		                                                                    /// <summary>方法RenameExternalToolbarItem</summary>
		[DispId(673)]
		bool RenameExternalToolbarItem(string strToolbar, string strExternalCommand, string strNewLabel);

		                                                                    /// <summary>方法RenameUserRootMenuItem</summary>
		[DispId(674)]
		bool RenameUserRootMenuItem(string strRootCommand, string strNewRootLabel);

		                                                                    /// <summary>方法RenameUserToolbar</summary>
		[DispId(675)]
		bool RenameUserToolbar(string strToolbar, string strUIName);

		                                                                    /// <summary>方法RepeatTableHeadLine</summary>
		[DispId(676)]
		bool RepeatTableHeadLine(string sTableName, bool bNeed, int nRowLine);

		                                                                    /// <summary>方法ReplaceAllFirstLevelStructsByBackgroundFile</summary>
		[DispId(677)]
		bool ReplaceAllFirstLevelStructsByBackgroundFile(string sBackgroundFile);

		                                                                    /// <summary>方法ReplaceAllFirstLevelStructsByBackgroundFileStream</summary>
		[DispId(678)]
		bool ReplaceAllFirstLevelStructsByBackgroundFileStream(object vBackgroundFile);

		                                                                    /// <summary>方法ReplaceAllFirstLevelStructsByBackgroundFileString</summary>
		[DispId(679)]
		bool ReplaceAllFirstLevelStructsByBackgroundFileString(string sBackgroundString);

		                                                                    /// <summary>方法ReplaceExternalSubMenuItemIcon</summary>
		[DispId(680)]
		bool ReplaceExternalSubMenuItemIcon(string strRootCommand, string strExternalCommand, string strNewPngPath);

		                                                                    /// <summary>方法ReplaceExternalToolbarItemIcon</summary>
		[DispId(681)]
		bool ReplaceExternalToolbarItemIcon(string strToolbar, string strExternalCommand, string strNewPngPath);

		                                                                    /// <summary>方法ReplaceImage</summary>
		[DispId(682)]
		string ReplaceImage(string sOldName, string sNewUrl);

		                                                                    /// <summary>方法ReplaceImageObject</summary>
		[DispId(186)]
		string ReplaceImageObject(string sOldName, string sNewUrl, int nType);

		                                                                    /// <summary>方法ReplaceSpecificStructProp</summary>
		[DispId(683)]
		bool ReplaceSpecificStructProp(string curStructName, string curStructProp, int nType, string fileURL, string wantedCtrlName, string wantedCtrlProp);

		                                                                    /// <summary>方法ReplaceSpecificStructPropWithBackStream</summary>
		[DispId(684)]
		bool ReplaceSpecificStructPropWithBackStream(string curStructName, string curStructProp, int nType, object stmFile, string wantedCtrlName, string wantedCtrlProp);

		                                                                    /// <summary>方法ReplaceSpecificStructPropWithBackString</summary>
		[DispId(685)]
		bool ReplaceSpecificStructPropWithBackString(string curStructName, string curStructProp, int nType, string base64String, string wantedCtrlName, string wantedCtrlProp);

		                                                                    /// <summary>方法ReplaceSpecificStructPropWithoutFormat</summary>
		[DispId(686)]
		bool ReplaceSpecificStructPropWithoutFormat(string curPropertyName, string curPropertyValue, int nType, string fileURL, string wantedPropertylName, string wantedPropertyProp);

		                                                                    /// <summary>方法ReplaceStructContentWithBackOdt</summary>
		[DispId(687)]
		bool ReplaceStructContentWithBackOdt(string strStructNames, string strBackFile);

		                                                                    /// <summary>方法ReplaceStructContentWithBackStream</summary>
		[DispId(688)]
		bool ReplaceStructContentWithBackStream(string strStructNames, object stmFile);

		                                                                    /// <summary>方法ReplaceStructContentWithBackString</summary>
		[DispId(689)]
		bool ReplaceStructContentWithBackString(string strStructNames, string base64String);

		                                                                    /// <summary>方法ReplaceTextInOdt</summary>
		[DispId(690)]
		bool ReplaceTextInOdt(string strSearch, string strReplace);

		                                                                    /// <summary>方法ResetCompoundBoxCode</summary>
		[DispId(691)]
		bool ResetCompoundBoxCode(string sName, string sOldCode, string sNewCode, int iType);

		                                                                    /// <summary>方法ResetNewControlsTagProperty</summary>
		[DispId(692)]
		void ResetNewControlsTagProperty();

		                                                                    /// <summary>方法ResetRadioButtonSelectStatus</summary>
		[DispId(693)]
		bool ResetRadioButtonSelectStatus(string sName);

		                                                                    /// <summary>方法Save</summary>
		[DispId(70)]
		WdInfo Save();

		                                                                    /// <summary>方法SaveAs</summary>
		[DispId(71)]
		WdInfo SaveAs(string fileName);

		                                                                    /// <summary>方法SaveAs2</summary>
		[DispId(72)]
		WdInfo SaveAs2(string fileName, bool backEnd);

		                                                                    /// <summary>方法SaveImageObjectToFile</summary>
		[DispId(187)]
		string SaveImageObjectToFile(string sName);

		                                                                    /// <summary>方法SaveImageToFile</summary>
		[DispId(694)]
		string SaveImageToFile(string sName);

		                                                                    /// <summary>方法SaveImageToFileWithFilefilter</summary>
		[DispId(695)]
		string SaveImageToFileWithFilefilter(string sName, string sFileFilter);

		                                                                    /// <summary>方法SaveSelectAreaToStream</summary>
		[DispId(188)]
		bool SaveSelectAreaToStream(ref object data);

		                                                                    /// <summary>方法SaveSelectAreaToStreamWithoutRedundant</summary>
		[DispId(696)]
		bool SaveSelectAreaToStreamWithoutRedundant(bool bBlankLine, bool bSpace, bool bTab, bool bStart, bool bEnd, ref object stmSave);

		                                                                    /// <summary>方法SaveSelectAreaToString</summary>
		[DispId(697)]
		string SaveSelectAreaToString();

		                                                                    /// <summary>方法SaveStructContentToStream</summary>
		[DispId(698)]
		bool SaveStructContentToStream(string sName, ref object stmSave);

		                                                                    /// <summary>方法SaveStructContentToString</summary>
		[DispId(699)]
		string SaveStructContentToString(string sName);

		                                                                    /// <summary>方法SaveToStream</summary>
		[DispId(700)]
		WdInfo SaveToStream(ref object stmSave);

		                                                                    /// <summary>方法SaveToStream2</summary>
		[DispId(189)]
		object SaveToStream2();

		                                                                    /// <summary>方法SaveToString</summary>
		[DispId(701)]
		string SaveToString();

		                                                                    /// <summary>方法SearchWithRegularExpression</summary>
		[DispId(190)]
		int SearchWithRegularExpression(string aSearchString, string sRev1, string sRev2);

		                                                                    /// <summary>方法SelectionToTop</summary>
		[DispId(702)]
		void SelectionToTop();

		                                                                    /// <summary>方法SelectNextControl</summary>
		[DispId(73)]
		bool SelectNextControl(Control control_0, bool forward, bool tabStopOnly, bool nested, bool wrap);

		                                                                    /// <summary>方法SelectOneArea</summary>
		[DispId(191)]
		void SelectOneArea(int aBeginPage, int aBeginRow, int aEndPage, int aEndRow);

		                                                                    /// <summary>方法SelectOneArea2</summary>
		[DispId(192)]
		void SelectOneArea2(int nBeginPos, int nEndPos);

		                                                                    /// <summary>方法SelectOneAreaByAbsoluteLine</summary>
		[DispId(703)]
		bool SelectOneAreaByAbsoluteLine(int lBeginRow, int lEndRow);

		                                                                    /// <summary>方法SelectOneMedicalformula</summary>
		[DispId(193)]
		bool SelectOneMedicalformula(string sName);

		                                                                    /// <summary>方法SelectOneMultiCheckboxItemByIndex</summary>
		[DispId(872)]
		void SelectOneMultiCheckboxItemByIndex(string sName, string strIndex, bool isChecked);

		                                                                    /// <summary>方法SelectOneNewCtrl</summary>
		[DispId(74)]
		bool SelectOneNewCtrl(string name);

		                                                                    /// <summary>方法SelectOneProtectArea</summary>
		[DispId(704)]
		bool SelectOneProtectArea(string sName);

		                                                                    /// <summary>方法SelectOneRadioButtonItem</summary>
		[DispId(705)]
		bool SelectOneRadioButtonItem(string sName, int nIndex);

		                                                                    /// <summary>方法SelectOneRadioButtonItemByCode</summary>
		[DispId(706)]
		bool SelectOneRadioButtonItemByCode(string sName, string sCode);

		                                                                    /// <summary>方法SelectOneRadioButtonItemByValue</summary>
		[DispId(707)]
		bool SelectOneRadioButtonItemByValue(string sName, string sValue);

		                                                                    /// <summary>方法SelectOneRegion</summary>
		[DispId(708)]
		bool SelectOneRegion(string sName, bool bOnlyContent);

		                                                                    /// <summary>方法SelectOneSection</summary>
		[DispId(75)]
		bool SelectOneSection(string name);

		                                                                    /// <summary>方法SelectOneStructContent</summary>
		[DispId(709)]
		bool SelectOneStructContent(string sStructName);

		                                                                    /// <summary>方法SelectOneTable</summary>
		[DispId(710)]
		bool SelectOneTable(string sName);

		                                                                    /// <summary>方法SelectRegionTitle</summary>
		[DispId(711)]
		bool SelectRegionTitle(string strName);

		                                                                    /// <summary>方法SetAllCheckBoxItemCheckPos</summary>
		[DispId(712)]
		bool SetAllCheckBoxItemCheckPos(string strName);

		                                                                    /// <summary>方法SetAllNewControlFloadBorderColor</summary>
		[DispId(194)]
		bool SetAllNewControlFloadBorderColor(int lRGBColor);

		                                                                    /// <summary>方法SetAllNewCtrlBGColor</summary>
		[DispId(713)]
		bool SetAllNewCtrlBGColor(bool bFlag);

		                                                                    /// <summary>方法SetAllNewCtrlBGColor2</summary>
		[DispId(195)]
		bool SetAllNewCtrlBGColor2(bool bShowNewCtrlBGColor, bool bShowNewCtrlStubBGColor);

		                                                                    /// <summary>方法SetAllNewCtrlBGColorEx</summary>
		[DispId(714)]
		bool SetAllNewCtrlBGColorEx(bool bFlag, int lReserve);

		                                                                    /// <summary>方法SetAllPostilsProperty</summary>
		[DispId(715)]
		bool SetAllPostilsProperty(string sPropertyName, bool bValue);

		                                                                    /// <summary>方法SetAllRadioButtonItemCheckPos</summary>
		[DispId(716)]
		bool SetAllRadioButtonItemCheckPos(string strName);

		                                                                    /// <summary>方法SetAllSectionFloadBorderColor</summary>
		[DispId(259)]
		bool SetAllSectionFloadBorderColor(int lRGBColor);

		                                                                    /// <summary>方法SetBookmarkText</summary>
		[DispId(196)]
		void SetBookmarkText(string TagName, string Content);

		                                                                    /// <summary>方法SetCanCopyFromActiveX</summary>
		[DispId(76)]
		void SetCanCopyFromActiveX(bool bCanCopy);

		                                                                    /// <summary>方法SetCanCopyWithStruct</summary>
		[DispId(197)]
		void SetCanCopyWithStruct(bool bFlag);

		                                                                    /// <summary>方法SetCanDelCtrlDirectlyByKey</summary>
		[DispId(717)]
		bool SetCanDelCtrlDirectlyByKey(bool bCan);

		                                                                    /// <summary>方法SetCanEditRegionTitleProperty</summary>
		[DispId(718)]
		bool SetCanEditRegionTitleProperty(bool bCan);

		                                                                    /// <summary>方法SetCheckboxCaption</summary>
		[DispId(77)]
		bool SetCheckboxCaption(string name, string text);

		                                                                    /// <summary>方法SetCheckBoxItemCheckPos</summary>
		[DispId(719)]
		bool SetCheckBoxItemCheckPos(string strName, string strPos);

		                                                                    /// <summary>方法SetCheckboxStatus</summary>
		[DispId(78)]
		bool SetCheckboxStatus(string name, bool bChecked);

		                                                                    /// <summary>方法SetColorTypeOfNewCtrl</summary>
		[DispId(198)]
		bool SetColorTypeOfNewCtrl(int iRed, int iGreen, int iBlue);

		                                                                    /// <summary>方法SetColorTypeOfProtectArea</summary>
		[DispId(721)]
		bool SetColorTypeOfProtectArea(uint iRed, uint iGreen, uint iBlue);

		                                                                    /// <summary>方法SetCompoundBoxCodeAndValue</summary>
		[DispId(722)]
		bool SetCompoundBoxCodeAndValue(string sName, string sCode, string sValue, int iType);

		                                                                    /// <summary>方法SetCompoundBoxCodeAndValueByArray</summary>
		[DispId(79)]
		bool SetCompoundBoxCodeAndValueByArray(string sName, object lstCode, object lstValue, int iType);

		                                                                    /// <summary>方法SetCompoundBoxCurrentCodeByValue</summary>
		[DispId(723)]
		bool SetCompoundBoxCurrentCodeByValue(string strName, int iType, string strValue);

		                                                                    /// <summary>方法SetCopyWithRegionStruct</summary>
		[DispId(724)]
		bool SetCopyWithRegionStruct(string sName, bool bWithRegionStruct);

		                                                                    /// <summary>方法SetCursorDistanceToPageTop</summary>
		[DispId(725)]
		int SetCursorDistanceToPageTop(int sDistance);

		                                                                    /// <summary>方法SetCustomToolbarVisible</summary>
		[DispId(199)]
		void SetCustomToolbarVisible(string sToolbarName, bool bVisible);

		                                                                    /// <summary>方法SetDateTimeBoxOutRangeInfo</summary>
		[DispId(726)]
		bool SetDateTimeBoxOutRangeInfo(string strName, string strInfo);

		                                                                    /// <summary>方法SetDateTimeBoxValue</summary>
		[DispId(80)]
		bool SetDateTimeBoxValue(string sName, string sValue);

		                                                                    /// <summary>方法SetDateTimeFormat</summary>
		[DispId(727)]
		bool SetDateTimeFormat(string sName, int lType);

		                                                                    /// <summary>方法SetDateTimeFormatEx</summary>
		[DispId(728)]
		bool SetDateTimeFormatEx(string sName, string sFormat);

		                                                                    /// <summary>方法SetDocDefaultAsianFont</summary>
		[DispId(729)]
		bool SetDocDefaultAsianFont(string sFontName, float fFontSize);

		                                                                    /// <summary>方法SetDocDefaultWestFont</summary>
		[DispId(730)]
		bool SetDocDefaultWestFont(string sFontName, float fFontSize);

		                                                                    /// <summary>方法SetDocModified</summary>
		[DispId(81)]
		void SetDocModified();

		                                                                    /// <summary>方法SetDocModified2</summary>
		[DispId(82)]
		bool SetDocModified2(bool modified);

		                                                                    /// <summary>方法SetDocRegionLinkRegion</summary>
		[DispId(731)]
		bool SetDocRegionLinkRegion(string strSourceRegion, string strNamedRegion);

		                                                                    /// <summary>方法SetDocSpaceByParam</summary>
		[DispId(732)]
		bool SetDocSpaceByParam(int lLineSpacing);

		                                                                    /// <summary>方法SetDragMode</summary>
		[DispId(733)]
		bool SetDragMode(int lMode);

		                                                                    /// <summary>方法SetDynamicGridLineColor</summary>
		[DispId(734)]
		void SetDynamicGridLineColor(int nColor);

		                                                                    /// <summary>方法SetDynamicGridShow</summary>
		[DispId(735)]
		void SetDynamicGridShow(bool bShow);

		                                                                    /// <summary>方法SetEmptyLineHeightBeforeTableInNewControl</summary>
		[DispId(736)]
		bool SetEmptyLineHeightBeforeTableInNewControl(string strName, int iType);

		                                                                    /// <summary>方法SetEndDateTime</summary>
		[DispId(737)]
		bool SetEndDateTime(string sName, string sValue);

		                                                                    /// <summary>方法SetExtraCopyInformation</summary>
		[DispId(83)]
		void SetExtraCopyInformation(string bstrExtraCopyInformation);

		                                                                    /// <summary>方法SetFileProperty</summary>
		[DispId(738)]
		void SetFileProperty(string ItemName, string Content);

		                                                                    /// <summary>方法SetFocus2</summary>
		[DispId(84)]
		void SetFocus2();

		                                                                    /// <summary>方法SetFontProp</summary>
		[DispId(739)]
		void SetFontProp(string propName, int propVal);

		                                                                    /// <summary>方法SetFooterDistance</summary>
		[DispId(740)]
		bool SetFooterDistance(float fDistance);

		                                                                    /// <summary>方法SetFooterLine</summary>
		[DispId(741)]
		bool SetFooterLine();

		                                                                    /// <summary>方法SetFooterText</summary>
		[DispId(742)]
		bool SetFooterText(string strText);

		                                                                    /// <summary>方法SetFooterTextEx</summary>
		[DispId(743)]
		bool SetFooterTextEx(string strText, int nParaStyle, string sRev1, string sRev2);

		                                                                    /// <summary>方法SetFormatTagVisible</summary>
		[DispId(744)]
		void SetFormatTagVisible(bool bShow);

		                                                                    /// <summary>方法SetGlobalDocumentListener</summary>
		[DispId(85)]
		void SetGlobalDocumentListener(bool bNeedSection, bool bNeedNewControl, bool bNeedCustomToolBar, bool bNeedDelAndIns);

		                                                                    /// <summary>方法SetGridShow</summary>
		[DispId(745)]
		bool SetGridShow(bool bTable, bool bImage);

		                                                                    /// <summary>方法SetHeaderDistance</summary>
		[DispId(746)]
		bool SetHeaderDistance(float fDistance);

		                                                                    /// <summary>方法SetHeaderFooterReadOnly</summary>
		[DispId(747)]
		bool SetHeaderFooterReadOnly(bool bReadOnly);

		                                                                    /// <summary>方法SetHeaderLineVisible</summary>
		[DispId(748)]
		bool SetHeaderLineVisible();

		                                                                    /// <summary>方法SetHeadersTextByXML</summary>
		[DispId(870)]
		bool SetHeadersTextByXML(string sHeadXml, string sRev1, string sRev2);

		                                                                    /// <summary>方法SetHeaderText</summary>
		[DispId(749)]
		bool SetHeaderText(string strText);

		                                                                    /// <summary>方法SetImageCopyProtection</summary>
		[DispId(750)]
		bool SetImageCopyProtection(string sName, bool bCopyProtect);

		                                                                    /// <summary>方法SetImageCustomProperty</summary>
		[DispId(866)]
		bool SetImageCustomProperty(string sImageName, string sPropName, string sPropValue);

		                                                                    /// <summary>方法SetImageDeleteProtection</summary>
		[DispId(751)]
		bool SetImageDeleteProtection(string sName, bool bDeleteProtect);

		                                                                    /// <summary>方法SetImageLockType</summary>
		[DispId(752)]
		bool SetImageLockType(string sName, int nType);

		                                                                    /// <summary>方法SetImageName</summary>
		[DispId(753)]
		string SetImageName(string sName, string sNewName);

		                                                                    /// <summary>方法SetImageObjectDeleteProtection</summary>
		[DispId(754)]
		bool SetImageObjectDeleteProtection(string sName, bool bDeleteProtect);

		                                                                    /// <summary>方法SetImageObjectLayoutSize</summary>
		[DispId(755)]
		bool SetImageObjectLayoutSize(string sImageName, float fOleWidth, float fOleHeight);

		                                                                    /// <summary>方法SetImageObjectName</summary>
		[DispId(202)]
		string SetImageObjectName(string sName, string sNewName);

		                                                                    /// <summary>方法SetImagePositionSizeProtect</summary>
		[DispId(756)]
		bool SetImagePositionSizeProtect(string sName, bool bPos, bool bSize);

		                                                                    /// <summary>方法SetImageThrough</summary>
		[DispId(757)]
		bool SetImageThrough(string sName);

		                                                                    /// <summary>方法SetImageWaterMark</summary>
		[DispId(758)]
		bool SetImageWaterMark(string strPath, int lScale, bool bWashOut);

		                                                                    /// <summary>方法SetInsertMode</summary>
		[DispId(759)]
		void SetInsertMode(int lMode);

		                                                                    /// <summary>方法SetIntellectiveInput</summary>
		[DispId(86)]
		void SetIntellectiveInput(bool bFlag, int nNumber);

		                                                                    /// <summary>方法SetIntellectiveListener</summary>
		[DispId(886)]
		void SetIntellectiveListener(bool bCancel);

		                                                                    /// <summary>方法SetLimitNumOfPasteCharacters</summary>
		[DispId(873)]
		void SetLimitNumOfPasteCharacters(int nType, int nCharacters, string string_0);

		                                                                    /// <summary>方法SetMedicalformulaText</summary>
		[DispId(760)]
		bool SetMedicalformulaText(bool bChangedType, int nChangedType, string sID, object sContent);

		                                                                    /// <summary>方法SetMenuBarVisible</summary>
		[DispId(88)]
		void SetMenuBarVisible(bool visible);

		                                                                    /// <summary>方法SetMultiBoxMutexString</summary>
		[DispId(761)]
		bool SetMultiBoxMutexString(string strName, int iType, string strMutex);

		                                                                    /// <summary>方法SetMultiDropdownControlGroupSeparator</summary>
		[DispId(762)]
		bool SetMultiDropdownControlGroupSeparator(string strName, string strGroupSeparator);

		                                                                    /// <summary>方法SetMultiDropdownControlSeparator</summary>
		[DispId(763)]
		bool SetMultiDropdownControlSeparator(string sName, string sSeparator);

		                                                                    /// <summary>方法SetNetDogServerInfo</summary>
		[DispId(764)]
		bool SetNetDogServerInfo(string sServerIP, string sPort);

		                                                                    /// <summary>方法SetNewControlDropMode</summary>
		[DispId(765)]
		void SetNewControlDropMode(bool bEnable);

		                                                                    /// <summary>方法SetNewControlHighlight</summary>
		[DispId(203)]
		void SetNewControlHighlight(bool bFlag);

		                                                                    /// <summary>方法SetNewControlName</summary>
		[DispId(89)]
		bool SetNewControlName(string Section_name, string newValue);

		                                                                    /// <summary>方法SetNewControlPrintAttribute</summary>
		[DispId(766)]
		bool SetNewControlPrintAttribute(string sName, bool bPrint);

		                                                                    /// <summary>方法SetNewControlProp</summary>
		[DispId(90)]
		bool SetNewControlProp(string name, string propName, string Value);

		                                                                    /// <summary>方法SetNewControlText</summary>
		[DispId(91)]
		bool SetNewControlText(string sName, string sText);

		                                                                    /// <summary>方法SetNewControlTextColor</summary>
		[DispId(767)]
		bool SetNewControlTextColor(string sName, int nColor);

		                                                                    /// <summary>方法SetNewCtrlDropDownBtnVisible</summary>
		[DispId(204)]
		bool SetNewCtrlDropDownBtnVisible(bool bVisible);

		                                                                    /// <summary>方法SetNewCtrlHelpTipBtnVisible</summary>
		[DispId(205)]
		bool SetNewCtrlHelpTipBtnVisible(bool bVisible);

		                                                                    /// <summary>方法SetNewCtrlUnderLineBrowser</summary>
		[DispId(206)]
		bool SetNewCtrlUnderLineBrowser(bool bBrowser);

		                                                                    /// <summary>方法SetNewCtrlUnderLineColorProp</summary>
		[DispId(768)]
		bool SetNewCtrlUnderLineColorProp(string strName, int nColorType);

		                                                                    /// <summary>方法SetNewCtrlUnderLineStyle</summary>
		[DispId(769)]
		bool SetNewCtrlUnderLineStyle(string strName, int nLineType, int nColorType);

		                                                                    /// <summary>方法SetNewCtrlUnderLineTypeProp</summary>
		[DispId(770)]
		bool SetNewCtrlUnderLineTypeProp(string strName, int nLineType);

		                                                                    /// <summary>方法SetNewCtrlUnderLineVisible</summary>
		[DispId(771)]
		bool SetNewCtrlUnderLineVisible(bool bShowAll, string strName, bool bShow);

		                                                                    /// <summary>方法SetNewCtrlUnderLineVisibleProp</summary>
		[DispId(772)]
		bool SetNewCtrlUnderLineVisibleProp(string strName, bool bShow);

		                                                                    /// <summary>方法SetNumboxErrorInputInfo</summary>
		[DispId(773)]
		bool SetNumboxErrorInputInfo(string strName, string strInfo);

		                                                                    /// <summary>方法SetNumboxMaxValue</summary>
		[DispId(774)]
		bool SetNumboxMaxValue(string name, double maxValue);

		                                                                    /// <summary>方法SetNumboxMinValue</summary>
		[DispId(775)]
		bool SetNumboxMinValue(string name, double minValue);

		                                                                    /// <summary>方法SetNumboxOutRangeInfo</summary>
		[DispId(92)]
		bool SetNumboxOutRangeInfo(string strName, string strInfo);

		                                                                    /// <summary>方法SetNumboxPrecision</summary>
		[DispId(776)]
		bool SetNumboxPrecision(string name, int precision);

		                                                                    /// <summary>方法SetNumboxText</summary>
		[DispId(93)]
		bool SetNumboxText(string name, int lText);

		                                                                    /// <summary>方法SetNumboxUnit</summary>
		[DispId(777)]
		bool SetNumboxUnit(string name, string sUnit);

		                                                                    /// <summary>方法SetOfficeRegKey</summary>
		[DispId(778)]
		bool SetOfficeRegKey(string filePath, short edition);

		                                                                    /// <summary>方法SetPageFormat</summary>
		[DispId(207)]
		bool SetPageFormat(int nPageFormat, float fPageWidth, float fPageHeight, bool bHorOrVer, int nPageLayOut);

		                                                                    /// <summary>方法SetPageHeaderDiffFromFront</summary>
		[DispId(94)]
		bool SetPageHeaderDiffFromFront(int nStartPage);

		                                                                    /// <summary>方法SetPageMargin</summary>
		[DispId(208)]
		bool SetPageMargin(float fPageLeft, float fPageRight, float fPageTop, float fPageBottom);

		                                                                    /// <summary>方法SetPageStyleLayout</summary>
		[DispId(779)]
		bool SetPageStyleLayout(int lType);

		                                                                    /// <summary>方法SetPageViewSizeChange</summary>
		[DispId(780)]
		bool SetPageViewSizeChange(bool bChange);

		                                                                    /// <summary>方法SetParaAlignment</summary>
		[DispId(209)]
		bool SetParaAlignment(int nSelectType, int AlignmentType);

		                                                                    /// <summary>方法SetParagraphIndent</summary>
		[DispId(781)]
		bool SetParagraphIndent(int nCount, int nType);

		                                                                    /// <summary>方法SetParagraphLastLineAdjustment</summary>
		[DispId(782)]
		bool SetParagraphLastLineAdjustment(int nType);

		                                                                    /// <summary>方法SetParagraphProp</summary>
		[DispId(783)]
		void SetParagraphProp(string propName, int propVal);

		                                                                    /// <summary>方法SetParaLineSpacing</summary>
		[DispId(784)]
		void SetParaLineSpacing(int nType, int nHeight);

		                                                                    /// <summary>方法SetParaProtectAreaName</summary>
		[DispId(785)]
		bool SetParaProtectAreaName(string sName, string sNewName);

		                                                                    /// <summary>方法SetParaProtectAreaProp</summary>
		[DispId(786)]
		bool SetParaProtectAreaProp(string sName, string sProp, string sValue);

		                                                                    /// <summary>方法SetParaProtectAreaText</summary>
		[DispId(787)]
		void SetParaProtectAreaText(string sName, string sText);

		                                                                    /// <summary>方法SetPostilPropertyByCurrentCursor</summary>
		[DispId(788)]
		bool SetPostilPropertyByCurrentCursor(string sPropertyName, bool bValue);

		                                                                    /// <summary>方法SetPostilsPropertyByAuthor</summary>
		[DispId(789)]
		bool SetPostilsPropertyByAuthor(string sAuthor, string sPropertyName, bool bValue);

		                                                                    /// <summary>方法SetPrinterName</summary>
		[DispId(239)]
		bool SetPrinterName(string sPrinterName);

		                                                                    /// <summary>方法SetPrinterRightLeft</summary>
		[DispId(240)]
		bool SetPrinterRightLeft(int lPrintMode);

		                                                                    /// <summary>方法SetPrintWithTableBorder</summary>
		[DispId(790)]
		bool SetPrintWithTableBorder(bool bWithBorder);

		                                                                    /// <summary>方法SetProtectAreaHighlight</summary>
		[DispId(210)]
		bool SetProtectAreaHighlight(bool bShow);

		                                                                    /// <summary>方法SetProtectAreaName</summary>
		[DispId(95)]
		bool SetProtectAreaName(string Section_name, string newValue);

		                                                                    /// <summary>方法SetProtectAreaProp</summary>
		[DispId(96)]
		bool SetProtectAreaProp(string name, string propName, string Value);

		                                                                    /// <summary>方法SetProtectAreaText</summary>
		[DispId(791)]
		bool SetProtectAreaText(string sName, string sText);

		                                                                    /// <summary>方法SetRadioButtonCodeAndValue</summary>
		[DispId(792)]
		bool SetRadioButtonCodeAndValue(string sName, string sCode, string sValue);

		                                                                    /// <summary>方法SetRadioButtonCodeAndValueByArray</summary>
		[DispId(97)]
		bool SetRadioButtonCodeAndValueByArray(string sName, object lstCode, object lstValue);

		                                                                    /// <summary>方法SetRadioButtonFormat</summary>
		[DispId(793)]
		bool SetRadioButtonFormat(string strName, int nBeginCharCount, int nEndCharCount, int nItemCountPerLine, int nTabStopAlignment);

		                                                                    /// <summary>方法SetRadioButtonItemCheckPos</summary>
		[DispId(794)]
		bool SetRadioButtonItemCheckPos(string strName, string strPos);

		                                                                    /// <summary>方法SetRecensionInfo</summary>
		[DispId(98)]
		bool SetRecensionInfo(string strUserCode, string strUserName, string strMemo, int nMarkStyle, string strMarkColor);

		                                                                    /// <summary>方法SetRegionBorderVisible</summary>
		[DispId(796)]
		bool SetRegionBorderVisible(bool bVisible);

		                                                                    /// <summary>方法SetRegionFileLink</summary>
		[DispId(797)]
		bool SetRegionFileLink(string strName, string strPath);

		                                                                    /// <summary>方法SetRegionFileLinkWithStream</summary>
		[DispId(798)]
		bool SetRegionFileLinkWithStream(string sRegionName, object stmFile);

		                                                                    /// <summary>方法SetRegionFileLinkWithString</summary>
		[DispId(799)]
		bool SetRegionFileLinkWithString(string sRegionName, string base64String);

		                                                                    /// <summary>方法SetRegionName</summary>
		[DispId(800)]
		bool SetRegionName(string sName, string sNewName);

		                                                                    /// <summary>方法SetRegionProp</summary>
		[DispId(801)]
		bool SetRegionProp(string sName, string sProp, string sValue);

		                                                                    /// <summary>方法SetRegionText</summary>
		[DispId(802)]
		bool SetRegionText(string sName, string sText);

		                                                                    /// <summary>方法SetRegionTitle</summary>
		[DispId(803)]
		bool SetRegionTitle(string strName, string strTitle, bool bAppend);

		                                                                    /// <summary>方法SetRegionTitleVisible</summary>
		[DispId(804)]
		bool SetRegionTitleVisible(string strName, bool bVisible);

		                                                                    /// <summary>方法SetReserveAttrOfImage</summary>
		[DispId(805)]
		bool SetReserveAttrOfImage(string sName, string sReserve);

		                                                                    /// <summary>方法SetReserveAttrOfImageObject</summary>
		[DispId(806)]
		bool SetReserveAttrOfImageObject(string sName, string sReserve);

		                                                                    /// <summary>方法SetRulersVisible</summary>
		[DispId(211)]
		void SetRulersVisible(bool bHideHori, bool bHideVert);

		                                                                    /// <summary>方法SetScrollBarVisible</summary>
		[DispId(807)]
		bool SetScrollBarVisible(bool bShowHori, bool bShowVert);

		                                                                    /// <summary>方法SetScrollWin</summary>
		[DispId(808)]
		bool SetScrollWin(bool bIsScrollWin);

		                                                                    /// <summary>方法SetSectionHighlight</summary>
		[DispId(212)]
		void SetSectionHighlight(bool bFlag);

		                                                                    /// <summary>方法SetSectionName</summary>
		[DispId(99)]
		bool SetSectionName(string Section_name, string newValue);

		                                                                    /// <summary>方法SetSectionProp</summary>
		[DispId(100)]
		bool SetSectionProp(string name, string propName, string Value);

		                                                                    /// <summary>方法SetSectionText</summary>
		[DispId(213)]
		bool SetSectionText(string sName, string sText);

		                                                                    /// <summary>方法SetSpecialPaste</summary>
		[DispId(809)]
		bool SetSpecialPaste(bool bWithForamt);

		                                                                    /// <summary>方法SetSpecialPasteEx</summary>
		[DispId(810)]
		void SetSpecialPasteEx(bool bOutFormat, bool bInFormat);

		                                                                    /// <summary>方法SetSpecificToolBarVisible</summary>
		[DispId(101)]
		void SetSpecificToolBarVisible(string ToolBar_Name, bool bVisible);

		                                                                    /// <summary>方法SetSpellOnline</summary>
		[DispId(811)]
		void SetSpellOnline(bool bFlag);

		                                                                    /// <summary>方法SetStartDateTime</summary>
		[DispId(812)]
		bool SetStartDateTime(string sName, string sValue);

		                                                                    /// <summary>方法SetStatusBarVisible</summary>
		[DispId(214)]
		void SetStatusBarVisible(bool bVisible);

		                                                                    /// <summary>方法SetStructBorderColor</summary>
		[DispId(215)]
		bool SetStructBorderColor(int lColor);

		                                                                    /// <summary>方法SetStructBorderColorByName</summary>
		[DispId(813)]
		bool SetStructBorderColorByName(string strName, int lColor);

		                                                                    /// <summary>方法SetStructBorderVisibleByType</summary>
		[DispId(216)]
		bool SetStructBorderVisibleByType(int nType, bool bVisible);

		                                                                    /// <summary>方法SetStructNavigationInfo</summary>
		[DispId(814)]
		bool SetStructNavigationInfo(string sXML, string sRev1, string sRev2, string sRev3);

		                                                                    /// <summary>方法SetStructNavigationVisible</summary>
		[DispId(815)]
		void SetStructNavigationVisible(bool bFlag);

		                                                                    /// <summary>方法SetStructsTextByArray</summary>
		[DispId(816)]
		bool SetStructsTextByArray(object lstName, object lstValue);

		                                                                    /// <summary>方法SetTableBorderColor</summary>
		[DispId(817)]
		bool SetTableBorderColor(string sTableName, int nColor);

		                                                                    /// <summary>方法SetTableBorderLineVisible</summary>
		[DispId(217)]
		bool SetTableBorderLineVisible(string strTableName, bool bTopLine, bool bBottomLine, bool bLeftLine, bool bRigthLine, bool bHorizontalLine, bool bVerticalLine);

		                                                                    /// <summary>方法SetTableBordersSpacingToContents</summary>
		[DispId(218)]
		bool SetTableBordersSpacingToContents(string sTableName, int lDistance);

		                                                                    /// <summary>方法SetTableBorderWidth</summary>
		[DispId(818)]
		bool SetTableBorderWidth(string sTableName, int nWidth);

		                                                                    /// <summary>方法SetTableCellAlignment</summary>
		[DispId(819)]
		bool SetTableCellAlignment(string strTableName, string strCellName, int nAlignType);

		                                                                    /// <summary>方法SetTableCellCustomProperty</summary>
		[DispId(820)]
		bool SetTableCellCustomProperty(string sTableName, string sCellName, string sPropertyName, string sValue);

		                                                                    /// <summary>方法SetTableCellErrorMsgWhenProtected</summary>
		[DispId(219)]
		bool SetTableCellErrorMsgWhenProtected(string sInfo);

		                                                                    /// <summary>方法SetTableCellProperty</summary>
		[DispId(220)]
		void SetTableCellProperty(string sTable, string sCell, string sColor, string sFontAsian, string sFontSize, int iFontType, int iAlignmentType);

		                                                                    /// <summary>方法SetTableCellWidth</summary>
		[DispId(821)]
		bool SetTableCellWidth(string strTableName, string strTableCell, int nWidth);

		                                                                    /// <summary>方法SetTableColWidth</summary>
		[DispId(822)]
		bool SetTableColWidth(string sTableName, int nWidth, int nIndex);

		                                                                    /// <summary>方法SetTableCustomProperty</summary>
		[DispId(221)]
		bool SetTableCustomProperty(string sTable, string sPropertyName, string sValue);

		                                                                    /// <summary>方法SetTableDeleteProtected</summary>
		[DispId(222)]
		bool SetTableDeleteProtected(string strTableName, bool bDelProtect);

		                                                                    /// <summary>方法SetTableGridlinesVisible</summary>
		[DispId(223)]
		bool SetTableGridlinesVisible(bool bVisible);

		                                                                    /// <summary>方法SetTableName</summary>
		[DispId(224)]
		bool SetTableName(string sTableOldName, string sTableNewName);

		                                                                    /// <summary>方法SetTableRowHeight</summary>
		[DispId(823)]
		bool SetTableRowHeight(string sTableName, int nHeight, int nIndex);

		                                                                    /// <summary>方法SetTableStyleProtected</summary>
		[DispId(225)]
		bool SetTableStyleProtected(string strTableName, bool bProtect);

		                                                                    /// <summary>方法SetTableWidth</summary>
		[DispId(824)]
		bool SetTableWidth(string strTableName, int nWidth);

		                                                                    /// <summary>方法SetText</summary>
		[DispId(825)]
		WdInfo SetText(string strText, WdLocate wdLocate_0);

		                                                                    /// <summary>方法SetTextBoxMaxLen</summary>
		[DispId(826)]
		bool SetTextBoxMaxLen(string sName, int nMaxLen);

		                                                                    /// <summary>方法SetTextWaterMark</summary>
		[DispId(827)]
		bool SetTextWaterMark(string strText, string strFont, int lSize, string strColor, bool bTrans, int lScale, bool bItalic);

		                                                                    /// <summary>方法SetToolbarItemVisible</summary>
		[DispId(828)]
		bool SetToolbarItemVisible(string strToolbar, string strToolbarItem, bool bVisible);

		                                                                    /// <summary>方法SetToolBarsVisible</summary>
		[DispId(228)]
		void SetToolBarsVisible(string Module_ToolBar_Name, bool bVisible);

		                                                                    /// <summary>方法SetUserToolbarVisible</summary>
		[DispId(102)]
		void SetUserToolbarVisible(string strToolbar, bool bVisible);

		                                                                    /// <summary>方法SetUserUIListener</summary>
		[DispId(103)]
		void SetUserUIListener(bool bNeedUserToolbar, bool bNeedUserMenuItem, bool bReserved);

		                                                                    /// <summary>方法SetViewProportion</summary>
		[DispId(104)]
		bool SetViewProportion(int nType, int nValue);

		                                                                    /// <summary>方法SetVScrollbarPos</summary>
		[DispId(867)]
		void SetVScrollbarPos(int position);

		                                                                    /// <summary>方法SetWestCharBreakAttribute</summary>
		[DispId(829)]
		bool SetWestCharBreakAttribute(int nType, bool bEnable);

		                                                                    /// <summary>方法SetXmlInfoWithTable</summary>
		[DispId(830)]
		bool SetXmlInfoWithTable(string sXML, string sTableProp, string sRegionProp, string sSectionProp, string sNewControlProp, string sTableCellProp, string sRev1, string sRev2);

		                                                                    /// <summary>方法ShowDialog</summary>
		[DispId(241)]
		void ShowDialog(int DialogType);

		                                                                    /// <summary>方法ShowDialog2</summary>
		[DispId(831)]
		string ShowDialog2(int nType, string sRev1, string sRev2, string sRev3);

		                                                                    /// <summary>方法ShowGrid</summary>
		[DispId(229)]
		void ShowGrid(bool bVisible);

		                                                                    /// <summary>方法ShowMenuItem</summary>
		[DispId(832)]
		void ShowMenuItem(string strMenuName);

		                                                                    /// <summary>方法ShowRadioButtonSelectItemOnly</summary>
		[DispId(833)]
		bool ShowRadioButtonSelectItemOnly(string sName, bool bOnlyShow);

		                                                                    /// <summary>方法ShowRecension</summary>
		[DispId(105)]
		void ShowRecension(WdRecesionState Flag);

		                                                                    /// <summary>方法SortRegions</summary>
		[DispId(874)]
		void SortRegions(string string_0, string data, string data2);

		                                                                    /// <summary>方法Space1</summary>
		[DispId(835)]
		void Space1();

		                                                                    /// <summary>方法Space15</summary>
		[DispId(836)]
		void Space15();

		                                                                    /// <summary>方法Space2</summary>
		[DispId(837)]
		void Space2();

		                                                                    /// <summary>方法SplitTableCellRange</summary>
		[DispId(838)]
		bool SplitTableCellRange(string sTable, string sCell, int columns, int rows);

		                                                                    /// <summary>方法StartUndo</summary>
		[DispId(839)]
		void StartUndo();

		                                                                    /// <summary>方法StructsBrowseModeBySpecifiedMethod</summary>
		[DispId(875)]
		bool StructsBrowseModeBySpecifiedMethod(string data, string data2, int int_0, int color, bool bol2, string data3);

		                                                                    /// <summary>方法SupportSuperscript</summary>
		[DispId(896)]
		void SupportSuperscript(int nFlag);

		                                                                    /// <summary>方法SwitchNewControlCursorMode</summary>
		[DispId(840)]
		void SwitchNewControlCursorMode(int nMode);

		                                                                    /// <summary>方法SwitchParaProtectArea</summary>
		[DispId(841)]
		bool SwitchParaProtectArea(bool bFlag);

		                                                                    /// <summary>方法SwitchProtectArea</summary>
		[DispId(842)]
		bool SwitchProtectArea(bool bFlag);

		                                                                    /// <summary>方法SwitchRecension</summary>
		[DispId(106)]
		void SwitchRecension(bool Flag);

		                                                                    /// <summary>方法Undo</summary>
		[DispId(260)]
		void Undo();

		                                                                    /// <summary>方法UpdateOfficeWindows</summary>
		[DispId(844)]
		void UpdateOfficeWindows();

		                                                                    /// <summary>方法WriteIniFileKeyString</summary>
		[DispId(845)]
		bool WriteIniFileKeyString(string appName, string keyName, string inString, string fileName);

		                                                                    /// <summary>方法WriteSecretInfoToStruct</summary>
		[DispId(846)]
		bool WriteSecretInfoToStruct(string sStructName, string sInfo);

		                                                                    /// <summary>方法ZoomIn</summary>
		[DispId(847)]
		void ZoomIn();

		                                                                    /// <summary>方法ZoomOut</summary>
		[DispId(848)]
		void ZoomOut();
	}
}
