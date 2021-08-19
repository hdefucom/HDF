using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>
	                                                                    ///       在编辑器的基础上添加新的方法，用于兼容其他电子病历控件的编程接口。专供COM接口使用。可用于VB/DELPHI开发。
	                                                                    ///       </summary>
	                                                                    /// <remarks>
	                                                                    ///       使用这个控件，可以快速替换掉其他编辑器控件而不修改任何用户代码。
	                                                                    ///       </remarks>
	[ComVisible(true)]
	[ComClass("37191954-0DB2-46D8-AA5E-9E85269719D0", "E9E3B18A-CAD1-40DD-8EC0-8B5B76BFFC10", "8524F372-2FF4-468F-AFDC-CB4BEED1E16D")]
	[ToolboxItem(false)]
	[DocumentComment]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("37191954-0DB2-46D8-AA5E-9E85269719D0")]
	[ComSourceInterfaces(typeof(INsoControlComEvents))]
	[ComDefaultInterface(typeof(INsoControl))]
	public class NsoControl : AxNsoControlBase, IObjectSafety, INsoControl
	{
		private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";

		private const string _IID_IDispatchEx = "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}";

		private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";

		private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";

		private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

		private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 1;

		private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 2;

		private const int S_OK = 0;

		private const int E_FAIL = -2147467259;

		private const int E_NOINTERFACE = -2147467262;

		internal const string CLASSID = "37191954-0DB2-46D8-AA5E-9E85269719D0";

		internal const string CLASSID_Interface = "E9E3B18A-CAD1-40DD-8EC0-8B5B76BFFC10";

		internal const string CLASSID_ComEventInterface = "8524F372-2FF4-468F-AFDC-CB4BEED1E16D";

		private bool _fSafeForScripting = true;

		private bool _fSafeForInitializing = true;

		                                                                    /// <summary>
		                                                                    ///       供下载新版文件的CodeBase值,本功能仅供WEB开发使用。
		                                                                    ///       </summary>
		[ComVisible(true)]
		[DefaultValue(null)]
		public string CodeBaseForUpdateAssembly
		{
			get
			{
				return GClass292.smethod_0().method_2();
			}
			set
			{
				GClass292.smethod_0().method_5(this);
				GClass292.smethod_0().method_3(value);
				GClass292.smethod_0().method_16();
			}
		}

		public event NsoControlEvents_NsoAuthorityStatusEventHandler NsoAuthorityStatus = null;

		public event NsoControlEvents_NsoBeforeFilePrintedEventHandler NsoBeforeFilePrinted = null;

		public event NsoControlEvents_NsoBeforeFilePrintedExEventHandler NsoBeforeFilePrintedEx = null;

		public event NsoControlEvents_NsoBeforeFileSavedEventHandler NsoBeforeFileSaved = null;

		public event NsoControlEvents_NsoDragAndDropCompletedEventHandler NsoDragAndDropCompleted = null;

		public event NsoVoidEventHandler NsoFileClosingEvent = null;

		public event NsoControlEvents_NsoFileModifyChangedEventHandler NsoFileModifyChanged = null;

		public event NsoControlEvents_NsoFileOpenCompletedEventHandler NsoFileOpenCompleted = null;

		public event NsoControlEvents_NsoFileReOpenedWhenCrashEventHandler NsoFileReOpenedWhenCrash = null;

		public event NsoControlEvents_NsoFileSavedCompletedEventHandler NsoFileSavedCompleted = null;

		public event NsoControlEvents_NsoImageClickEventHandler NsoImageClick = null;

		public event NsoControlEvents_NsoImageDBClickEventHandler NsoImageDBClick = null;

		public event NsoControlEvents_NsoIntellectiveEventEventHandler NsoIntellectiveEvent = null;

		public event NsoControlEvents_NsoKeyPressedEventEventHandler NsoKeyPressedEvent = null;

		public event NsoControlEvents_NsoKeyPressedEvent2EventHandler NsoKeyPressedEvent2 = null;

		public event NsoControlEvents_NsoLButtonDownEventHandler NsoLButtonDown = null;

		public event NsoControlEvents_NsoNetDogStatusEventHandler NsoNetDogStatus = null;

		public event NsoControlEvents_NsoNewControlBeforeDropDownEventHandler NsoNewControlBeforeDropDown = null;

		public event NsoControlEvents_NsoNewControlChangedEventHandler NsoNewControlChanged = null;

		public event NsoControlEvents_NsoNewControlCheckedChangedEventHandler NsoNewControlCheckedChanged = null;

		public event NsoControlEvents_NsoNewControlClickEventHandler NsoNewControlClick = null;

		public event NsoControlEvents_NsoNewControlCursorEnterEventHandler NsoNewControlCursorEnter = null;

		public event NsoControlEvents_NsoNewControlCursorLeftEventHandler NsoNewControlCursorLeft = null;

		public event NsoControlEvents_NsoNewControlDBClickEventHandler NsoNewControlDBClick = null;

		public event NsoControlEvents_NsoNewControlDropDownEventHandler NsoNewControlDropDown = null;

		public event NsoControlEvents_NsoNewControlGainFocusEventHandler NsoNewControlGainFocus = null;

		public event NsoControlEvents_NsoNewControlInsertOrDelEventEventHandler NsoNewControlInsertOrDelEvent = null;

		public event NsoControlEvents_NsoNewControlLostFocusEventHandler NsoNewControlLostFocus = null;

		public event NsoControlEvents_NsoOLEClickEventHandler NsoOLEClick = null;

		public event NsoVoidEventHandler NsoPreviewExitEvent = null;

		public event NsoControlEvents_NsoRadioButtonCheckChangedEventHandler NsoRadioButtonCheckChanged = null;

		public event NsoControlEvents_NsoRButtonUpEventHandler NsoRButtonUp = null;

		public event NsoControlEvents_NsoRegionDBClickEventHandler NsoRegionDBClick = null;

		public event NsoControlEvents_NsoRegionGainFocusEventHandler NsoRegionGainFocus = null;

		public event NsoControlEvents_NsoRegionLostFocusEventHandler NsoRegionLostFocus = null;

		public event NsoControlEvents_NsoRegionChangedEventHandler NsoRegionChanged = null;

		public event NsoControlEvents_NsoSectionChangedEventHandler NsoSectionChanged = null;

		public event NsoControlEvents_NsoSectionClickEventHandler NsoSectionClick = null;

		public event NsoControlEvents_NsoSectionCursorEnterEventHandler NsoSectionCursorEnter = null;

		public event NsoControlEvents_NsoSectionCursorLeftEventHandler NsoSectionCursorLeft = null;

		public event NsoControlEvents_NsoSectionDBClickEventHandler NsoSectionDBClick = null;

		                                                                    /// <summary>
		                                                                    ///       文档节获得焦点事件
		                                                                    ///       </summary>
		public event NsoControlEvents_NsoSectionGainFocusEventHandler NsoSectionGainFocus = null;

		public event NsoControlEvents_NsoSectionInsertOrDelEventEventHandler NsoSectionInsertOrDelEvent = null;

		public event NsoControlEvents_NsoSectionLostFocusEventHandler NsoSectionLostFocus = null;

		public event NsoVoidEventHandler NsoSelectionChanged = null;

		public event NsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEventHandler NsoTableAddNewRowWhenPressTabKey = null;

		public event NsoControlEvents_NsoToolbarAddinEventEventHandler NsoToolbarAddinEvent = null;

		public event NsoControlEvents_NsoUserMenuItemEventEventHandler NsoUserMenuItemEvent = null;

		                                                                    /// <summary>
		                                                                    ///       自定义工具条事件
		                                                                    ///       </summary>
		public event NsoControlEvents_NsoUserToolbarEventEventHandler NsoUserToolbarEvent = null;

		                                                                    /// <summary>
		                                                                    ///       接口实现
		                                                                    ///       </summary>
		                                                                    /// <param name="riid">
		                                                                    /// </param>
		                                                                    /// <param name="pdwSupportedOptions">
		                                                                    /// </param>
		                                                                    /// <param name="pdwEnabledOptions">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		[ComVisible(true)]
		[DCInternal]
		public new int GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
		{
			int num = 1;
			int num2 = -2147467259;
			string text = riid.ToString("B").ToUpper();
			pdwSupportedOptions = 3;
			switch (text)
			{
			case "{0000010A-0000-0000-C000-000000000046}":
			case "{00000109-0000-0000-C000-000000000046}":
			case "{37D84F60-42CB-11CE-8135-00AA004BB851}":
				num2 = 0;
				pdwEnabledOptions = 0;
				if (_fSafeForInitializing)
				{
					pdwEnabledOptions = 2;
				}
				break;
			case "{00020400-0000-0000-C000-000000000046}":
			case "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}":
				num2 = 0;
				pdwEnabledOptions = 0;
				if (_fSafeForScripting)
				{
					pdwEnabledOptions = 1;
				}
				break;
			default:
				num2 = -2147467262;
				pdwEnabledOptions = 3;
				break;
			}
			return num2;
		}

		                                                                    /// <summary>
		                                                                    ///       接口实现
		                                                                    ///       </summary>
		                                                                    /// <param name="riid">
		                                                                    /// </param>
		                                                                    /// <param name="dwOptionSetMask">
		                                                                    /// </param>
		                                                                    /// <param name="dwEnabledOptions">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		[ComVisible(true)]
		[DCInternal]
		public new int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
		{
			int num = 5;
			int result = -2147467259;
			switch (riid.ToString("B").ToUpper())
			{
			case "{0000010A-0000-0000-C000-000000000046}":
			case "{00000109-0000-0000-C000-000000000046}":
			case "{37D84F60-42CB-11CE-8135-00AA004BB851}":
				if ((dwEnabledOptions & dwOptionSetMask) == 2 && _fSafeForInitializing)
				{
					result = 0;
				}
				break;
			case "{00020400-0000-0000-C000-000000000046}":
			case "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}":
				if ((dwEnabledOptions & dwOptionSetMask) == 1 && _fSafeForScripting)
				{
					result = 0;
				}
				break;
			default:
				result = -2147467262;
				break;
			}
			return result;
		}

		                                                                    /// <summary>
		                                                                    ///       COM中注销控件，释放资源
		                                                                    ///       </summary>
		[ComVisible(true)]
		public void ComDispose()
		{
			if (!base.IsDisposed)
			{
				Dispose();
			}
			if (base.IsHandleCreated)
			{
				base.DestroyHandle();
			}
			GC.Collect();
		}

		public override bool PreProcessMessage(ref Message message_0)
		{
			if (message_0.Msg == 256)
			{
				Keys keys = (Keys)(int)message_0.WParam;
				if ((keys == Keys.Left || keys == Keys.Right || keys == Keys.Up || keys == Keys.Down || keys == Keys.Tab) && myEditControl.Focused)
				{
					if (keys == Keys.Tab)
					{
						myEditControl.method_28('\t');
					}
					else
					{
						myEditControl.method_27(keys);
					}
					return true;
				}
			}
			return base.PreProcessMessage(ref message_0);
		}

		protected override void RaiseOnNsoAuthorityStatus(object sender, _INsoControlEvents_NsoAuthorityStatusEvent _INsoControlEvents_NsoAuthorityStatusEvent_0)
		{
			if (this.NsoAuthorityStatus != null)
			{
				this.NsoAuthorityStatus(_INsoControlEvents_NsoAuthorityStatusEvent_0.nStatus);
			}
		}

		protected override void RaiseOnNsoBeforeFilePrinted(object sender, _INsoControlEvents_NsoBeforeFilePrintedEvent _INsoControlEvents_NsoBeforeFilePrintedEvent_0)
		{
			if (this.NsoBeforeFilePrinted != null)
			{
				this.NsoBeforeFilePrinted(_INsoControlEvents_NsoBeforeFilePrintedEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoBeforeFilePrintedEx(object sender, _INsoControlEvents_NsoBeforeFilePrintedExEvent _INsoControlEvents_NsoBeforeFilePrintedExEvent_0)
		{
			if (this.NsoBeforeFilePrintedEx != null)
			{
				this.NsoBeforeFilePrintedEx(_INsoControlEvents_NsoBeforeFilePrintedExEvent_0.bCancel);
			}
		}

		protected override void RaiseOnNsoBeforeFileSaved(object sender, _INsoControlEvents_NsoBeforeFileSavedEvent _INsoControlEvents_NsoBeforeFileSavedEvent_0)
		{
			if (this.NsoBeforeFileSaved != null)
			{
				this.NsoBeforeFileSaved(_INsoControlEvents_NsoBeforeFileSavedEvent_0.sName, _INsoControlEvents_NsoBeforeFileSavedEvent_0.bCancel);
			}
		}

		protected override void RaiseOnNsoDragAndDropCompleted(object sender, _INsoControlEvents_NsoDragAndDropCompletedEvent _INsoControlEvents_NsoDragAndDropCompletedEvent_0)
		{
			if (this.NsoDragAndDropCompleted != null)
			{
				this.NsoDragAndDropCompleted(_INsoControlEvents_NsoDragAndDropCompletedEvent_0.sContent);
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
				this.NsoFileModifyChanged(_INsoControlEvents_NsoFileModifyChangedEvent_0.bModify);
			}
		}

		protected override void RaiseOnNsoFileOpenCompleted(object sender, _INsoControlEvents_NsoFileOpenCompletedEvent _INsoControlEvents_NsoFileOpenCompletedEvent_0)
		{
			if (this.NsoFileOpenCompleted != null)
			{
				this.NsoFileOpenCompleted(_INsoControlEvents_NsoFileOpenCompletedEvent_0.sPath, _INsoControlEvents_NsoFileOpenCompletedEvent_0.sReserve);
			}
		}

		protected override void RaiseOnNsoFileReOpenedWhenCrash(object sender, _INsoControlEvents_NsoFileReOpenedWhenCrashEvent _INsoControlEvents_NsoFileReOpenedWhenCrashEvent_0)
		{
			if (this.NsoFileReOpenedWhenCrash != null)
			{
				this.NsoFileReOpenedWhenCrash(_INsoControlEvents_NsoFileReOpenedWhenCrashEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoFileSavedCompleted(object sender, _INsoControlEvents_NsoFileSavedCompletedEvent _INsoControlEvents_NsoFileSavedCompletedEvent_0)
		{
			if (this.NsoFileSavedCompleted != null)
			{
				this.NsoFileSavedCompleted(_INsoControlEvents_NsoFileSavedCompletedEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoImageClick(object sender, _INsoControlEvents_NsoImageClickEvent _INsoControlEvents_NsoImageClickEvent_0)
		{
			if (this.NsoImageClick != null)
			{
				this.NsoImageClick(_INsoControlEvents_NsoImageClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoImageDBClick(object sender, _INsoControlEvents_NsoImageDBClickEvent _INsoControlEvents_NsoImageDBClickEvent_0)
		{
			if (this.NsoImageDBClick != null)
			{
				this.NsoImageDBClick(_INsoControlEvents_NsoImageDBClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoIntellectiveEvent(object sender, _INsoControlEvents_NsoIntellectiveEventEvent _INsoControlEvents_NsoIntellectiveEventEvent_0)
		{
			if (this.NsoIntellectiveEvent != null)
			{
				this.NsoIntellectiveEvent(_INsoControlEvents_NsoIntellectiveEventEvent_0.sContent);
			}
		}

		protected override void RaiseOnNsoKeyPressedEvent(object sender, _INsoControlEvents_NsoKeyPressedEventEvent _INsoControlEvents_NsoKeyPressedEventEvent_0)
		{
			if (this.NsoKeyPressedEvent != null)
			{
				this.NsoKeyPressedEvent(_INsoControlEvents_NsoKeyPressedEventEvent_0.nKeyCode, _INsoControlEvents_NsoKeyPressedEventEvent_0.nKeyChar, _INsoControlEvents_NsoKeyPressedEventEvent_0.nKeyFunction, _INsoControlEvents_NsoKeyPressedEventEvent_0.nModifiers, _INsoControlEvents_NsoKeyPressedEventEvent_0.bCancel);
			}
		}

		protected override void RaiseOnNsoKeyPressedEvent2(object sender, _INsoControlEvents_NsoKeyPressedEvent2Event _INsoControlEvents_NsoKeyPressedEvent2Event_0)
		{
			if (this.NsoKeyPressedEvent2 != null)
			{
				this.NsoKeyPressedEvent2(_INsoControlEvents_NsoKeyPressedEvent2Event_0.nKeyCode, _INsoControlEvents_NsoKeyPressedEvent2Event_0.nKeyChar, _INsoControlEvents_NsoKeyPressedEvent2Event_0.nKeyFunction, _INsoControlEvents_NsoKeyPressedEvent2Event_0.nModifiers, _INsoControlEvents_NsoKeyPressedEvent2Event_0.bCancel);
			}
		}

		protected override void RaiseOnNsoLButtonDown(object sender, _INsoControlEvents_NsoLButtonDownEvent _INsoControlEvents_NsoLButtonDownEvent_0)
		{
			if (this.NsoLButtonDown != null)
			{
				this.NsoLButtonDown(_INsoControlEvents_NsoLButtonDownEvent_0.xPos, _INsoControlEvents_NsoLButtonDownEvent_0.yPos);
			}
		}

		protected override void RaiseOnNsoNetDogStatus(object sender, _INsoControlEvents_NsoNetDogStatusEvent _INsoControlEvents_NsoNetDogStatusEvent_0)
		{
			if (this.NsoNetDogStatus != null)
			{
				this.NsoNetDogStatus(_INsoControlEvents_NsoNetDogStatusEvent_0.nStatus);
			}
		}

		protected override void RaiseOnNsoNewControlBeforeDropDown(object sender, _INsoControlEvents_NsoNewControlBeforeDropDownEvent _INsoControlEvents_NsoNewControlBeforeDropDownEvent_0)
		{
			if (this.NsoNewControlBeforeDropDown != null)
			{
				this.NsoNewControlBeforeDropDown(_INsoControlEvents_NsoNewControlBeforeDropDownEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlChanged(object sender, _INsoControlEvents_NsoNewControlChangedEvent _INsoControlEvents_NsoNewControlChangedEvent_0)
		{
			if (this.NsoNewControlChanged != null)
			{
				this.NsoNewControlChanged(_INsoControlEvents_NsoNewControlChangedEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlCheckedChanged(object sender, _INsoControlEvents_NsoNewControlCheckedChangedEvent _INsoControlEvents_NsoNewControlCheckedChangedEvent_0)
		{
			if (this.NsoNewControlCheckedChanged != null)
			{
				this.NsoNewControlCheckedChanged(_INsoControlEvents_NsoNewControlCheckedChangedEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlClick(object sender, _INsoControlEvents_NsoNewControlClickEvent _INsoControlEvents_NsoNewControlClickEvent_0)
		{
			if (this.NsoNewControlClick != null)
			{
				this.NsoNewControlClick(_INsoControlEvents_NsoNewControlClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlCursorEnter(object sender, _INsoControlEvents_NsoNewControlCursorEnterEvent _INsoControlEvents_NsoNewControlCursorEnterEvent_0)
		{
			if (this.NsoNewControlCursorEnter != null)
			{
				this.NsoNewControlCursorEnter(_INsoControlEvents_NsoNewControlCursorEnterEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlCursorLeft(object sender, _INsoControlEvents_NsoNewControlCursorLeftEvent _INsoControlEvents_NsoNewControlCursorLeftEvent_0)
		{
			if (this.NsoNewControlCursorLeft != null)
			{
				this.NsoNewControlCursorLeft(_INsoControlEvents_NsoNewControlCursorLeftEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlDBClick(object sender, _INsoControlEvents_NsoNewControlDBClickEvent _INsoControlEvents_NsoNewControlDBClickEvent_0)
		{
			if (this.NsoNewControlDBClick != null)
			{
				this.NsoNewControlDBClick(_INsoControlEvents_NsoNewControlDBClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlDropDown(object sender, _INsoControlEvents_NsoNewControlDropDownEvent _INsoControlEvents_NsoNewControlDropDownEvent_0)
		{
			if (this.NsoNewControlDropDown != null)
			{
				this.NsoNewControlDropDown(_INsoControlEvents_NsoNewControlDropDownEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlGainFocus(object sender, _INsoControlEvents_NsoNewControlGainFocusEvent _INsoControlEvents_NsoNewControlGainFocusEvent_0)
		{
			if (this.NsoNewControlGainFocus != null)
			{
				this.NsoNewControlGainFocus(_INsoControlEvents_NsoNewControlGainFocusEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoNewControlInsertOrDelEvent(object sender, _INsoControlEvents_NsoNewControlInsertOrDelEventEvent _INsoControlEvents_NsoNewControlInsertOrDelEventEvent_0)
		{
			if (this.NsoNewControlInsertOrDelEvent != null)
			{
				this.NsoNewControlInsertOrDelEvent(_INsoControlEvents_NsoNewControlInsertOrDelEventEvent_0.sName, _INsoControlEvents_NsoNewControlInsertOrDelEventEvent_0.sParentSection, _INsoControlEvents_NsoNewControlInsertOrDelEventEvent_0.nEventType);
			}
		}

		protected override void RaiseOnNsoNewControlLostFocus(object sender, _INsoControlEvents_NsoNewControlLostFocusEvent _INsoControlEvents_NsoNewControlLostFocusEvent_0)
		{
			if (this.NsoNewControlLostFocus != null)
			{
				this.NsoNewControlLostFocus(_INsoControlEvents_NsoNewControlLostFocusEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoOLEClick(object sender, _INsoControlEvents_NsoOLEClickEvent _INsoControlEvents_NsoOLEClickEvent_0)
		{
			if (this.NsoOLEClick != null)
			{
				this.NsoOLEClick(_INsoControlEvents_NsoOLEClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoPreviewExitEvent(object sender, EventArgs e)
		{
			if (this.NsoPreviewExitEvent != null)
			{
				this.NsoPreviewExitEvent();
			}
		}

		protected override void RaiseOnNsoRadioButtonCheckChanged(object sender, _INsoControlEvents_NsoRadioButtonCheckChangedEvent _INsoControlEvents_NsoRadioButtonCheckChangedEvent_0)
		{
			if (this.NsoRadioButtonCheckChanged != null)
			{
				this.NsoRadioButtonCheckChanged(_INsoControlEvents_NsoRadioButtonCheckChangedEvent_0.sName, _INsoControlEvents_NsoRadioButtonCheckChangedEvent_0.oldCheckIndex, _INsoControlEvents_NsoRadioButtonCheckChangedEvent_0.newCheckIndex);
			}
		}

		protected override void RaiseOnNsoRButtonUp(object sender, _INsoControlEvents_NsoRButtonUpEvent _INsoControlEvents_NsoRButtonUpEvent_0)
		{
			if (this.NsoRButtonUp != null)
			{
				this.NsoRButtonUp(_INsoControlEvents_NsoRButtonUpEvent_0.xPos, _INsoControlEvents_NsoRButtonUpEvent_0.yPos);
			}
		}

		protected override void RaiseOnNsoRegionDBClick(object sender, _INsoControlEvents_NsoRegionDBClickEvent _INsoControlEvents_NsoRegionDBClickEvent_0)
		{
			if (this.NsoRegionDBClick != null)
			{
				this.NsoRegionDBClick(_INsoControlEvents_NsoRegionDBClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoRegionGainFocus(object sender, _INsoControlEvents_NsoRegionGainFocusEvent _INsoControlEvents_NsoRegionGainFocusEvent_0)
		{
			if (this.NsoRegionGainFocus != null)
			{
				this.NsoRegionGainFocus(_INsoControlEvents_NsoRegionGainFocusEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoRegionLostFocus(object sender, _INsoControlEvents_NsoRegionLostFocusEvent _INsoControlEvents_NsoRegionLostFocusEvent_0)
		{
			if (this.NsoRegionLostFocus != null)
			{
				this.NsoRegionLostFocus(_INsoControlEvents_NsoRegionLostFocusEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoRegionChanged(object sender, _INsoControlEvents_NsoRegionChangedEvent _INsoControlEvents_NsoRegionChangedEvent_0)
		{
			if (this.NsoRegionChanged != null)
			{
				this.NsoRegionChanged(_INsoControlEvents_NsoRegionChangedEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionChanged(object sender, _INsoControlEvents_NsoSectionChangedEvent _INsoControlEvents_NsoSectionChangedEvent_0)
		{
			if (this.NsoSectionChanged != null)
			{
				this.NsoSectionChanged(_INsoControlEvents_NsoSectionChangedEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionClick(object sender, _INsoControlEvents_NsoSectionClickEvent _INsoControlEvents_NsoSectionClickEvent_0)
		{
			if (this.NsoSectionClick != null)
			{
				this.NsoSectionClick(_INsoControlEvents_NsoSectionClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionCursorEnter(object sender, _INsoControlEvents_NsoSectionCursorEnterEvent _INsoControlEvents_NsoSectionCursorEnterEvent_0)
		{
			if (this.NsoSectionCursorEnter != null)
			{
				this.NsoSectionCursorEnter(_INsoControlEvents_NsoSectionCursorEnterEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionCursorLeft(object sender, _INsoControlEvents_NsoSectionCursorLeftEvent _INsoControlEvents_NsoSectionCursorLeftEvent_0)
		{
			if (this.NsoSectionCursorLeft != null)
			{
				this.NsoSectionCursorLeft(_INsoControlEvents_NsoSectionCursorLeftEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionDBClick(object sender, _INsoControlEvents_NsoSectionDBClickEvent _INsoControlEvents_NsoSectionDBClickEvent_0)
		{
			if (this.NsoSectionDBClick != null)
			{
				this.NsoSectionDBClick(_INsoControlEvents_NsoSectionDBClickEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionGainFocus(object sender, _INsoControlEvents_NsoSectionGainFocusEvent _INsoControlEvents_NsoSectionGainFocusEvent_0)
		{
			if (this.NsoSectionGainFocus != null)
			{
				this.NsoSectionGainFocus(_INsoControlEvents_NsoSectionGainFocusEvent_0.sName);
			}
		}

		protected override void RaiseOnNsoSectionInsertOrDelEvent(object sender, _INsoControlEvents_NsoSectionInsertOrDelEventEvent _INsoControlEvents_NsoSectionInsertOrDelEventEvent_0)
		{
			if (this.NsoSectionInsertOrDelEvent != null)
			{
				this.NsoSectionInsertOrDelEvent(_INsoControlEvents_NsoSectionInsertOrDelEventEvent_0.sName, _INsoControlEvents_NsoSectionInsertOrDelEventEvent_0.nEventType);
			}
		}

		protected override void RaiseOnNsoSectionLostFocus(object sender, _INsoControlEvents_NsoSectionLostFocusEvent _INsoControlEvents_NsoSectionLostFocusEvent_0)
		{
			if (this.NsoSectionLostFocus != null)
			{
				this.NsoSectionLostFocus(_INsoControlEvents_NsoSectionLostFocusEvent_0.sName);
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
				this.NsoTableAddNewRowWhenPressTabKey(_INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEvent_0.sTableName);
			}
		}

		protected override void RaiseOnNsoToolbarAddinEvent(object sender, _INsoControlEvents_NsoToolbarAddinEventEvent _INsoControlEvents_NsoToolbarAddinEventEvent_0)
		{
			if (this.NsoToolbarAddinEvent != null)
			{
				this.NsoToolbarAddinEvent(_INsoControlEvents_NsoToolbarAddinEventEvent_0.nID, _INsoControlEvents_NsoToolbarAddinEventEvent_0.sRev1, _INsoControlEvents_NsoToolbarAddinEventEvent_0.sRev2);
			}
		}

		protected override void RaiseOnNsoUserMenuItemEvent(object sender, _INsoControlEvents_NsoUserMenuItemEventEvent _INsoControlEvents_NsoUserMenuItemEventEvent_0)
		{
			if (this.NsoUserMenuItemEvent != null)
			{
				this.NsoUserMenuItemEvent(_INsoControlEvents_NsoUserMenuItemEventEvent_0.nID, _INsoControlEvents_NsoUserMenuItemEventEvent_0.sRev1, _INsoControlEvents_NsoUserMenuItemEventEvent_0.sRev2);
			}
		}

		protected override void RaiseOnNsoUserToolbarEvent(object sender, _INsoControlEvents_NsoUserToolbarEventEvent _INsoControlEvents_NsoUserToolbarEventEvent_0)
		{
			if (this.NsoUserToolbarEvent != null)
			{
				this.NsoUserToolbarEvent(_INsoControlEvents_NsoUserToolbarEventEvent_0.nID, _INsoControlEvents_NsoUserToolbarEventEvent_0.sRev1, _INsoControlEvents_NsoUserToolbarEventEvent_0.sRev2);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComRegisterFunction]
		private static void Register(Type type_0)
		{
			GClass305.smethod_1(type_0, "1");
		}

		[ComUnregisterFunction]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private static void Unregister(Type type_0)
		{
			GClass305.smethod_2(type_0);
		}

		Control INsoControl.GetNextControl(Control param0, bool param1)
		{
			return GetNextControl(param0, param1);
		}

		bool INsoControl.SelectNextControl(Control param0, bool param1, bool param2, bool param3, bool param4)
		{
			return SelectNextControl(param0, param1, param2, param3, param4);
		}
	}
}
