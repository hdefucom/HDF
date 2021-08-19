using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>
	                                                                    ///       在编辑器的基础上添加新的方法，用于兼容其他电子病历控件的编程接口。专供.NET程序使用
	                                                                    ///       </summary>
	                                                                    /// <remarks>
	                                                                    ///       使用这个控件，可以快速替换掉其他编辑器控件而不修改任何用户代码。
	                                                                    ///       </remarks>
	[ComVisible(false)]
	[DocumentComment]
	[ToolboxItem(true)]
	public class AxNsoControl : AxNsoControlBase
	{
		public event _INsoControlEvents_NsoAuthorityStatusEventHandler NsoAuthorityStatus = null;

		public event _INsoControlEvents_NsoBeforeFilePrintedEventHandler NsoBeforeFilePrinted = null;

		public event _INsoControlEvents_NsoBeforeFilePrintedExEventHandler NsoBeforeFilePrintedEx = null;

		public event _INsoControlEvents_NsoBeforeFileSavedEventHandler NsoBeforeFileSaved = null;

		public event _INsoControlEvents_NsoDragAndDropCompletedEventHandler NsoDragAndDropCompleted = null;

		public event NsoVoidEventHandler NsoFileClosingEvent = null;

		public event _INsoControlEvents_NsoFileModifyChangedEventHandler NsoFileModifyChanged = null;

		public event _INsoControlEvents_NsoFileOpenCompletedEventHandler NsoFileOpenCompleted = null;

		public event _INsoControlEvents_NsoFileReOpenedWhenCrashEventHandler NsoFileReOpenedWhenCrash = null;

		public event _INsoControlEvents_NsoFileSavedCompletedEventHandler NsoFileSavedCompleted = null;

		public event _INsoControlEvents_NsoImageClickEventHandler NsoImageClick = null;

		public event _INsoControlEvents_NsoImageDBClickEventHandler NsoImageDBClick = null;

		public event _INsoControlEvents_NsoIntellectiveEventEventHandler NsoIntellectiveEvent = null;

		public event _INsoControlEvents_NsoKeyPressedEventEventHandler NsoKeyPressedEvent = null;

		public event _INsoControlEvents_NsoKeyPressedEvent2EventHandler NsoKeyPressedEvent2 = null;

		public event _INsoControlEvents_NsoLButtonDownEventHandler NsoLButtonDown = null;

		public event _INsoControlEvents_NsoNetDogStatusEventHandler NsoNetDogStatus = null;

		public event _INsoControlEvents_NsoNewControlBeforeDropDownEventHandler NsoNewControlBeforeDropDown = null;

		public event _INsoControlEvents_NsoNewControlChangedEventHandler NsoNewControlChanged = null;

		public event _INsoControlEvents_NsoNewControlCheckedChangedEventHandler NsoNewControlCheckedChanged = null;

		public event _INsoControlEvents_NsoNewControlClickEventHandler NsoNewControlClick = null;

		public event _INsoControlEvents_NsoNewControlCursorEnterEventHandler NsoNewControlCursorEnter = null;

		public event _INsoControlEvents_NsoNewControlCursorLeftEventHandler NsoNewControlCursorLeft = null;

		public event _INsoControlEvents_NsoNewControlDBClickEventHandler NsoNewControlDBClick = null;

		public event _INsoControlEvents_NsoNewControlDropDownEventHandler NsoNewControlDropDown = null;

		public event _INsoControlEvents_NsoNewControlGainFocusEventHandler NsoNewControlGainFocus = null;

		public event _INsoControlEvents_NsoNewControlInsertOrDelEventEventHandler NsoNewControlInsertOrDelEvent = null;

		public event _INsoControlEvents_NsoNewControlLostFocusEventHandler NsoNewControlLostFocus = null;

		public event _INsoControlEvents_NsoOLEClickEventHandler NsoOLEClick = null;

		public event EventHandler NsoPreviewExitEvent = null;

		public event _INsoControlEvents_NsoRadioButtonCheckChangedEventHandler NsoRadioButtonCheckChanged = null;

		public event _INsoControlEvents_NsoRButtonUpEventHandler NsoRButtonUp = null;

		public event _INsoControlEvents_NsoRegionDBClickEventHandler NsoRegionDBClick = null;

		public event _INsoControlEvents_NsoRegionGainFocusEventHandler NsoRegionGainFocus = null;

		public event _INsoControlEvents_NsoRegionLostFocusEventHandler NsoRegionLostFocus = null;

		public event _INsoControlEvents_NsoRegionChangedEventHandler NsoRegionChanged = null;

		public event _INsoControlEvents_NsoSectionChangedEventHandler NsoSectionChanged = null;

		public event _INsoControlEvents_NsoSectionClickEventHandler NsoSectionClick = null;

		public event _INsoControlEvents_NsoSectionCursorEnterEventHandler NsoSectionCursorEnter = null;

		public event _INsoControlEvents_NsoSectionCursorLeftEventHandler NsoSectionCursorLeft = null;

		public event _INsoControlEvents_NsoSectionDBClickEventHandler NsoSectionDBClick = null;

		                                                                    /// <summary>
		                                                                    ///       文档节获得焦点事件
		                                                                    ///       </summary>
		public event _INsoControlEvents_NsoSectionGainFocusEventHandler NsoSectionGainFocus = null;

		public event _INsoControlEvents_NsoSectionInsertOrDelEventEventHandler NsoSectionInsertOrDelEvent = null;

		public event _INsoControlEvents_NsoSectionLostFocusEventHandler NsoSectionLostFocus = null;

		public event NsoVoidEventHandler NsoSelectionChanged = null;

		public event _INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEventHandler NsoTableAddNewRowWhenPressTabKey = null;

		public event _INsoControlEvents_NsoToolbarAddinEventEventHandler NsoToolbarAddinEvent = null;

		public event _INsoControlEvents_NsoUserMenuItemEventEventHandler NsoUserMenuItemEvent = null;

		                                                                    /// <summary>
		                                                                    ///       自定义工具条事件
		                                                                    ///       </summary>
		public event _INsoControlEvents_NsoUserToolbarEventEventHandler NsoUserToolbarEvent = null;

		                                                                    /// <summary>
		                                                                    ///       打印文档
		                                                                    ///       </summary>
		                                                                    /// <param name="base64String">文档BASE64字符串</param>
		                                                                    /// <param name="showUI">是否显示UI界面</param>
		                                                                    /// <returns>打印结果信息</returns>
		public static PrintResult DCPrintDocument(string base64String, bool showUI)
		{
			if (string.IsNullOrEmpty(base64String))
			{
				return null;
			}
			byte[] byte_ = Convert.FromBase64String(base64String);
			XTextDocument xTextDocument = new XTextDocument();
			if (AxNsoControlBase.InnerOpenDocumentBinary(null, byte_, xTextDocument))
			{
				xTextDocument.CheckPageRefreshed();
				DocumentPrinter documentPrinter = new DocumentPrinter();
				documentPrinter.Document = xTextDocument;
				return documentPrinter.PrintDocument(showUI);
			}
			return null;
		}

		public static byte[] ExportPdfFileWithString(string base64String)
		{
			int num = 2;
			if (string.IsNullOrEmpty(base64String))
			{
				return null;
			}
			byte[] byte_ = Convert.FromBase64String(base64String);
			XTextDocument xTextDocument = new XTextDocument();
			if (AxNsoControlBase.InnerOpenDocumentBinary(null, byte_, xTextDocument))
			{
				MemoryStream memoryStream = new MemoryStream();
				xTextDocument.Save(memoryStream, "pdf");
				memoryStream.Close();
				return memoryStream.ToArray();
			}
			return null;
		}

		protected override void RaiseOnNsoAuthorityStatus(object sender, _INsoControlEvents_NsoAuthorityStatusEvent _INsoControlEvents_NsoAuthorityStatusEvent_0)
		{
			if (this.NsoAuthorityStatus != null)
			{
				this.NsoAuthorityStatus(sender, _INsoControlEvents_NsoAuthorityStatusEvent_0);
			}
		}

		protected override void RaiseOnNsoBeforeFilePrinted(object sender, _INsoControlEvents_NsoBeforeFilePrintedEvent _INsoControlEvents_NsoBeforeFilePrintedEvent_0)
		{
			if (this.NsoBeforeFilePrinted != null)
			{
				this.NsoBeforeFilePrinted(sender, _INsoControlEvents_NsoBeforeFilePrintedEvent_0);
			}
		}

		protected override void RaiseOnNsoBeforeFilePrintedEx(object sender, _INsoControlEvents_NsoBeforeFilePrintedExEvent _INsoControlEvents_NsoBeforeFilePrintedExEvent_0)
		{
			if (this.NsoBeforeFilePrintedEx != null)
			{
				this.NsoBeforeFilePrintedEx(sender, _INsoControlEvents_NsoBeforeFilePrintedExEvent_0);
			}
		}

		protected override void RaiseOnNsoBeforeFileSaved(object sender, _INsoControlEvents_NsoBeforeFileSavedEvent _INsoControlEvents_NsoBeforeFileSavedEvent_0)
		{
			if (this.NsoBeforeFileSaved != null)
			{
				this.NsoBeforeFileSaved(sender, _INsoControlEvents_NsoBeforeFileSavedEvent_0);
			}
		}

		protected override void RaiseOnNsoDragAndDropCompleted(object sender, _INsoControlEvents_NsoDragAndDropCompletedEvent _INsoControlEvents_NsoDragAndDropCompletedEvent_0)
		{
			if (this.NsoDragAndDropCompleted != null)
			{
				this.NsoDragAndDropCompleted(sender, _INsoControlEvents_NsoDragAndDropCompletedEvent_0);
			}
		}

		protected override void RaiseOnNsoFileClosingEvent()
		{
			if (this.NsoFileClosingEvent != null)
			{
				this.NsoFileClosingEvent();
			}
		}

		protected override void RaiseOnNsoFileModifyChanged(object sender, _INsoControlEvents_NsoFileModifyChangedEvent _INsoControlEvents_NsoFileModifyChangedEvent_0)
		{
			if (this.NsoFileModifyChanged != null)
			{
				this.NsoFileModifyChanged(sender, _INsoControlEvents_NsoFileModifyChangedEvent_0);
			}
		}

		protected override void RaiseOnNsoFileOpenCompleted(object sender, _INsoControlEvents_NsoFileOpenCompletedEvent _INsoControlEvents_NsoFileOpenCompletedEvent_0)
		{
			if (this.NsoFileOpenCompleted != null)
			{
				this.NsoFileOpenCompleted(sender, _INsoControlEvents_NsoFileOpenCompletedEvent_0);
			}
		}

		protected override void RaiseOnNsoFileReOpenedWhenCrash(object sender, _INsoControlEvents_NsoFileReOpenedWhenCrashEvent _INsoControlEvents_NsoFileReOpenedWhenCrashEvent_0)
		{
			if (this.NsoFileReOpenedWhenCrash != null)
			{
				this.NsoFileReOpenedWhenCrash(sender, _INsoControlEvents_NsoFileReOpenedWhenCrashEvent_0);
			}
		}

		protected override void RaiseOnNsoFileSavedCompleted(object sender, _INsoControlEvents_NsoFileSavedCompletedEvent _INsoControlEvents_NsoFileSavedCompletedEvent_0)
		{
			if (this.NsoFileSavedCompleted != null)
			{
				this.NsoFileSavedCompleted(sender, _INsoControlEvents_NsoFileSavedCompletedEvent_0);
			}
		}

		protected override void RaiseOnNsoImageClick(object sender, _INsoControlEvents_NsoImageClickEvent _INsoControlEvents_NsoImageClickEvent_0)
		{
			if (this.NsoImageClick != null)
			{
				this.NsoImageClick(sender, _INsoControlEvents_NsoImageClickEvent_0);
			}
		}

		protected override void RaiseOnNsoImageDBClick(object sender, _INsoControlEvents_NsoImageDBClickEvent _INsoControlEvents_NsoImageDBClickEvent_0)
		{
			if (this.NsoImageDBClick != null)
			{
				this.NsoImageDBClick(sender, _INsoControlEvents_NsoImageDBClickEvent_0);
			}
		}

		protected override void RaiseOnNsoIntellectiveEvent(object sender, _INsoControlEvents_NsoIntellectiveEventEvent _INsoControlEvents_NsoIntellectiveEventEvent_0)
		{
			if (this.NsoIntellectiveEvent != null)
			{
				this.NsoIntellectiveEvent(sender, _INsoControlEvents_NsoIntellectiveEventEvent_0);
			}
		}

		protected override void RaiseOnNsoKeyPressedEvent(object sender, _INsoControlEvents_NsoKeyPressedEventEvent _INsoControlEvents_NsoKeyPressedEventEvent_0)
		{
			if (this.NsoKeyPressedEvent != null)
			{
				this.NsoKeyPressedEvent(sender, _INsoControlEvents_NsoKeyPressedEventEvent_0);
			}
		}

		protected override void RaiseOnNsoKeyPressedEvent2(object sender, _INsoControlEvents_NsoKeyPressedEvent2Event _INsoControlEvents_NsoKeyPressedEvent2Event_0)
		{
			if (this.NsoKeyPressedEvent2 != null)
			{
				this.NsoKeyPressedEvent2(sender, _INsoControlEvents_NsoKeyPressedEvent2Event_0);
			}
		}

		protected override void RaiseOnNsoLButtonDown(object sender, _INsoControlEvents_NsoLButtonDownEvent _INsoControlEvents_NsoLButtonDownEvent_0)
		{
			if (this.NsoLButtonDown != null)
			{
				this.NsoLButtonDown(sender, _INsoControlEvents_NsoLButtonDownEvent_0);
			}
		}

		protected override void RaiseOnNsoNetDogStatus(object sender, _INsoControlEvents_NsoNetDogStatusEvent _INsoControlEvents_NsoNetDogStatusEvent_0)
		{
			if (this.NsoNetDogStatus != null)
			{
				this.NsoNetDogStatus(sender, _INsoControlEvents_NsoNetDogStatusEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlBeforeDropDown(object sender, _INsoControlEvents_NsoNewControlBeforeDropDownEvent _INsoControlEvents_NsoNewControlBeforeDropDownEvent_0)
		{
			if (this.NsoNewControlBeforeDropDown != null)
			{
				this.NsoNewControlBeforeDropDown(sender, _INsoControlEvents_NsoNewControlBeforeDropDownEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlChanged(object sender, _INsoControlEvents_NsoNewControlChangedEvent _INsoControlEvents_NsoNewControlChangedEvent_0)
		{
			if (this.NsoNewControlChanged != null)
			{
				this.NsoNewControlChanged(sender, _INsoControlEvents_NsoNewControlChangedEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlCheckedChanged(object sender, _INsoControlEvents_NsoNewControlCheckedChangedEvent _INsoControlEvents_NsoNewControlCheckedChangedEvent_0)
		{
			if (this.NsoNewControlCheckedChanged != null)
			{
				this.NsoNewControlCheckedChanged(sender, _INsoControlEvents_NsoNewControlCheckedChangedEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlClick(object sender, _INsoControlEvents_NsoNewControlClickEvent _INsoControlEvents_NsoNewControlClickEvent_0)
		{
			if (this.NsoNewControlClick != null)
			{
				this.NsoNewControlClick(sender, _INsoControlEvents_NsoNewControlClickEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlCursorEnter(object sender, _INsoControlEvents_NsoNewControlCursorEnterEvent _INsoControlEvents_NsoNewControlCursorEnterEvent_0)
		{
			if (this.NsoNewControlCursorEnter != null)
			{
				this.NsoNewControlCursorEnter(sender, _INsoControlEvents_NsoNewControlCursorEnterEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlCursorLeft(object sender, _INsoControlEvents_NsoNewControlCursorLeftEvent _INsoControlEvents_NsoNewControlCursorLeftEvent_0)
		{
			if (this.NsoNewControlCursorLeft != null)
			{
				this.NsoNewControlCursorLeft(sender, _INsoControlEvents_NsoNewControlCursorLeftEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlDBClick(object sender, _INsoControlEvents_NsoNewControlDBClickEvent _INsoControlEvents_NsoNewControlDBClickEvent_0)
		{
			if (this.NsoNewControlDBClick != null)
			{
				this.NsoNewControlDBClick(sender, _INsoControlEvents_NsoNewControlDBClickEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlDropDown(object sender, _INsoControlEvents_NsoNewControlDropDownEvent _INsoControlEvents_NsoNewControlDropDownEvent_0)
		{
			if (this.NsoNewControlDropDown != null)
			{
				this.NsoNewControlDropDown(sender, _INsoControlEvents_NsoNewControlDropDownEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlGainFocus(object sender, _INsoControlEvents_NsoNewControlGainFocusEvent _INsoControlEvents_NsoNewControlGainFocusEvent_0)
		{
			if (this.NsoNewControlGainFocus != null)
			{
				this.NsoNewControlGainFocus(sender, _INsoControlEvents_NsoNewControlGainFocusEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlInsertOrDelEvent(object sender, _INsoControlEvents_NsoNewControlInsertOrDelEventEvent _INsoControlEvents_NsoNewControlInsertOrDelEventEvent_0)
		{
			if (this.NsoNewControlInsertOrDelEvent != null)
			{
				this.NsoNewControlInsertOrDelEvent(sender, _INsoControlEvents_NsoNewControlInsertOrDelEventEvent_0);
			}
		}

		protected override void RaiseOnNsoNewControlLostFocus(object sender, _INsoControlEvents_NsoNewControlLostFocusEvent _INsoControlEvents_NsoNewControlLostFocusEvent_0)
		{
			if (this.NsoNewControlLostFocus != null)
			{
				this.NsoNewControlLostFocus(sender, _INsoControlEvents_NsoNewControlLostFocusEvent_0);
			}
		}

		protected override void RaiseOnNsoOLEClick(object sender, _INsoControlEvents_NsoOLEClickEvent _INsoControlEvents_NsoOLEClickEvent_0)
		{
			if (this.NsoOLEClick != null)
			{
				this.NsoOLEClick(sender, _INsoControlEvents_NsoOLEClickEvent_0);
			}
		}

		protected override void RaiseOnNsoPreviewExitEvent(object sender, EventArgs e)
		{
			if (this.NsoPreviewExitEvent != null)
			{
				this.NsoPreviewExitEvent(sender, e);
			}
		}

		protected override void RaiseOnNsoRadioButtonCheckChanged(object sender, _INsoControlEvents_NsoRadioButtonCheckChangedEvent _INsoControlEvents_NsoRadioButtonCheckChangedEvent_0)
		{
			if (this.NsoRadioButtonCheckChanged != null)
			{
				this.NsoRadioButtonCheckChanged(sender, _INsoControlEvents_NsoRadioButtonCheckChangedEvent_0);
			}
		}

		protected override void RaiseOnNsoRButtonUp(object sender, _INsoControlEvents_NsoRButtonUpEvent _INsoControlEvents_NsoRButtonUpEvent_0)
		{
			if (this.NsoRButtonUp != null)
			{
				this.NsoRButtonUp(sender, _INsoControlEvents_NsoRButtonUpEvent_0);
			}
		}

		protected override void RaiseOnNsoRegionDBClick(object sender, _INsoControlEvents_NsoRegionDBClickEvent _INsoControlEvents_NsoRegionDBClickEvent_0)
		{
			if (this.NsoRegionDBClick != null)
			{
				this.NsoRegionDBClick(sender, _INsoControlEvents_NsoRegionDBClickEvent_0);
			}
		}

		protected override void RaiseOnNsoRegionGainFocus(object sender, _INsoControlEvents_NsoRegionGainFocusEvent _INsoControlEvents_NsoRegionGainFocusEvent_0)
		{
			if (this.NsoRegionGainFocus != null)
			{
				this.NsoRegionGainFocus(sender, _INsoControlEvents_NsoRegionGainFocusEvent_0);
			}
		}

		protected override void RaiseOnNsoRegionLostFocus(object sender, _INsoControlEvents_NsoRegionLostFocusEvent _INsoControlEvents_NsoRegionLostFocusEvent_0)
		{
			if (this.NsoRegionLostFocus != null)
			{
				this.NsoRegionLostFocus(sender, _INsoControlEvents_NsoRegionLostFocusEvent_0);
			}
		}

		protected override void RaiseOnNsoRegionChanged(object sender, _INsoControlEvents_NsoRegionChangedEvent _INsoControlEvents_NsoRegionChangedEvent_0)
		{
			if (this.NsoRegionChanged != null)
			{
				this.NsoRegionChanged(sender, _INsoControlEvents_NsoRegionChangedEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionChanged(object sender, _INsoControlEvents_NsoSectionChangedEvent _INsoControlEvents_NsoSectionChangedEvent_0)
		{
			if (this.NsoSectionChanged != null)
			{
				this.NsoSectionChanged(sender, _INsoControlEvents_NsoSectionChangedEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionClick(object sender, _INsoControlEvents_NsoSectionClickEvent _INsoControlEvents_NsoSectionClickEvent_0)
		{
			if (this.NsoSectionClick != null)
			{
				this.NsoSectionClick(sender, _INsoControlEvents_NsoSectionClickEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionCursorEnter(object sender, _INsoControlEvents_NsoSectionCursorEnterEvent _INsoControlEvents_NsoSectionCursorEnterEvent_0)
		{
			if (this.NsoSectionCursorEnter != null)
			{
				this.NsoSectionCursorEnter(sender, _INsoControlEvents_NsoSectionCursorEnterEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionCursorLeft(object sender, _INsoControlEvents_NsoSectionCursorLeftEvent _INsoControlEvents_NsoSectionCursorLeftEvent_0)
		{
			if (this.NsoSectionCursorLeft != null)
			{
				this.NsoSectionCursorLeft(sender, _INsoControlEvents_NsoSectionCursorLeftEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionDBClick(object sender, _INsoControlEvents_NsoSectionDBClickEvent _INsoControlEvents_NsoSectionDBClickEvent_0)
		{
			if (this.NsoSectionDBClick != null)
			{
				this.NsoSectionDBClick(sender, _INsoControlEvents_NsoSectionDBClickEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionGainFocus(object sender, _INsoControlEvents_NsoSectionGainFocusEvent _INsoControlEvents_NsoSectionGainFocusEvent_0)
		{
			if (this.NsoSectionGainFocus != null)
			{
				this.NsoSectionGainFocus(sender, _INsoControlEvents_NsoSectionGainFocusEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionInsertOrDelEvent(object sender, _INsoControlEvents_NsoSectionInsertOrDelEventEvent _INsoControlEvents_NsoSectionInsertOrDelEventEvent_0)
		{
			if (this.NsoSectionInsertOrDelEvent != null)
			{
				this.NsoSectionInsertOrDelEvent(sender, _INsoControlEvents_NsoSectionInsertOrDelEventEvent_0);
			}
		}

		protected override void RaiseOnNsoSectionLostFocus(object sender, _INsoControlEvents_NsoSectionLostFocusEvent _INsoControlEvents_NsoSectionLostFocusEvent_0)
		{
			if (this.NsoSectionLostFocus != null)
			{
				this.NsoSectionLostFocus(sender, _INsoControlEvents_NsoSectionLostFocusEvent_0);
			}
		}

		protected override void RaiseOnNsoSelectionChanged()
		{
			if (this.NsoSelectionChanged != null)
			{
				this.NsoSelectionChanged();
			}
		}

		protected override void RaiseOnNsoTableAddNewRowWhenPressTabKey(object sender, _INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEvent _INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEvent_0)
		{
			if (this.NsoTableAddNewRowWhenPressTabKey != null)
			{
				this.NsoTableAddNewRowWhenPressTabKey(sender, _INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEvent_0);
			}
		}

		protected override void RaiseOnNsoToolbarAddinEvent(object sender, _INsoControlEvents_NsoToolbarAddinEventEvent _INsoControlEvents_NsoToolbarAddinEventEvent_0)
		{
			if (this.NsoToolbarAddinEvent != null)
			{
				this.NsoToolbarAddinEvent(sender, _INsoControlEvents_NsoToolbarAddinEventEvent_0);
			}
		}

		protected override void RaiseOnNsoUserMenuItemEvent(object sender, _INsoControlEvents_NsoUserMenuItemEventEvent _INsoControlEvents_NsoUserMenuItemEventEvent_0)
		{
			if (this.NsoUserMenuItemEvent != null)
			{
				this.NsoUserMenuItemEvent(sender, _INsoControlEvents_NsoUserMenuItemEventEvent_0);
			}
		}

		protected override void RaiseOnNsoUserToolbarEvent(object sender, _INsoControlEvents_NsoUserToolbarEventEvent _INsoControlEvents_NsoUserToolbarEventEvent_0)
		{
			if (this.NsoUserToolbarEvent != null)
			{
				this.NsoUserToolbarEvent(sender, _INsoControlEvents_NsoUserToolbarEventEvent_0);
			}
		}
	}
}
