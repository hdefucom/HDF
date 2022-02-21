using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///        WriterControl编辑器控件的ActiveX控件版本
	///       </summary>
	/// <remarks>
	///       本控件用于COM和B/S开发,不用于.NET开发.
	///       编制 袁永福
	///       </remarks>
	[ComClass("00012345-6789-ABCD-EF01-2345678900EE", "61FDA393-EBA5-47BD-A456-05FE1DEECE78", "6FEE3DDC-D761-46E5-8FBC-E9C3658CCBBD")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	
	[Guid("00012345-6789-ABCD-EF01-2345678900EE")]
	[ToolboxItem(false)]
	[ComDefaultInterface(typeof(IAxWriterPrintPreviewControl))]
	[ComSourceInterfaces(typeof(IAxWriterPrintPreviewControlComEvents))]
	[ToolboxBitmap(typeof(AxWriterControl))]
	public sealed class AxWriterPrintPreviewControl : WriterPrintPreviewControl, IObjectSafety, IAxWriterPrintPreviewControl
	{
		private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";

		private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";

		private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";

		private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";

		private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

		private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 1;

		private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 2;

		private const int S_OK = 0;

		private const int E_FAIL = -2147467259;

		private const int E_NOINTERFACE = -2147467262;

		internal const string CLASSID = "00012345-6789-ABCD-EF01-2345678900EE";

		internal const string CLASSID_Interface = "61FDA393-EBA5-47BD-A456-05FE1DEECE78";

		internal const string CLASSID_ComEventInterface = "6FEE3DDC-D761-46E5-8FBC-E9C3658CCBBD";

		private GClass299 _AxContentBase64StringLoader = null;

		private string _AxContentBase64String = null;

		private InstanceFactoryForCOM _InstanceFactory = null;

		private bool _fSafeForScripting = true;

		private bool _fSafeForInitializing = true;

		/// <summary>
		///       忽略掉触发事件时的异常
		///       </summary>
		protected override bool IsTryCathForRaiseEvent => true;

		/// <summary>
		///       供下载新版文件的CodeBase值,本功能仅供WEB开发使用。
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
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

		/// <summary>
		///       AX格式的文档BASE64字符串
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		public string AxContentBase64String
		{
			get
			{
				return _AxContentBase64String;
			}
			set
			{
				_AxContentBase64String = value;
				if (_AxContentBase64StringLoader != null)
				{
					_AxContentBase64StringLoader.method_2(200);
				}
			}
		}

		/// <summary>
		///       对象实例创建工厂对象
		///       </summary>
		[Browsable(false)]
		public InstanceFactoryForCOM InstanceFactory
		{
			get
			{
				if (_InstanceFactory == null)
				{
					_InstanceFactory = new InstanceFactoryForCOM();
				}
				return _InstanceFactory;
			}
		}

		bool IAxWriterPrintPreviewControl.AllowUserChangePrintArea
		{
			get
			{
				return base.AllowUserChangePrintArea;
			}
			set
			{
				base.AllowUserChangePrintArea = value;
			}
		}

		PrintResult IAxWriterPrintPreviewControl.CurrentPrintResult
		{
			get
			{
				return base.CurrentPrintResult;
			}
			set
			{
				base.CurrentPrintResult = value;
			}
		}

		bool IAxWriterPrintPreviewControl.EnabledControlEvent
		{
			get
			{
				return base.EnabledControlEvent;
			}
			set
			{
				base.EnabledControlEvent = value;
			}
		}

		bool IAxWriterPrintPreviewControl.EnableSetJumpPrintPosition
		{
			get
			{
				return base.EnableSetJumpPrintPosition;
			}
			set
			{
				base.EnableSetJumpPrintPosition = value;
			}
		}

		Color IAxWriterPrintPreviewControl.PageBackColor
		{
			get
			{
				return base.PageBackColor;
			}
			set
			{
				base.PageBackColor = value;
			}
		}

		Color IAxWriterPrintPreviewControl.PreviewBackColor
		{
			get
			{
				return base.PreviewBackColor;
			}
			set
			{
				base.PreviewBackColor = value;
			}
		}

		bool IAxWriterPrintPreviewControl.ShowPageSettingsButton
		{
			get
			{
				return base.ShowPageSettingsButton;
			}
			set
			{
				base.ShowPageSettingsButton = value;
			}
		}

		bool IAxWriterPrintPreviewControl.ShowPrinterSettingsBeforePrint
		{
			get
			{
				return base.ShowPrinterSettingsBeforePrint;
			}
			set
			{
				base.ShowPrinterSettingsBeforePrint = value;
			}
		}

		bool IAxWriterPrintPreviewControl.ShowPrinterSettingsButton
		{
			get
			{
				return base.ShowPrinterSettingsButton;
			}
			set
			{
				base.ShowPrinterSettingsButton = value;
			}
		}

		bool IAxWriterPrintPreviewControl.ShowStartPageIndex
		{
			get
			{
				return base.ShowStartPageIndex;
			}
			set
			{
				base.ShowStartPageIndex = value;
			}
		}

		int IAxWriterPrintPreviewControl.StartPage
		{
			get
			{
				return base.StartPage;
			}
			set
			{
				base.StartPage = value;
			}
		}

		bool IAxWriterPrintPreviewControl.ToolbarVisible
		{
			get
			{
				return base.ToolbarVisible;
			}
			set
			{
				base.ToolbarVisible = value;
			}
		}

		bool IAxWriterPrintPreviewControl.UseAntiAlias
		{
			get
			{
				return base.UseAntiAlias;
			}
			set
			{
				base.UseAntiAlias = value;
			}
		}

		double IAxWriterPrintPreviewControl.Zoom
		{
			get
			{
				return base.Zoom;
			}
			set
			{
				base.Zoom = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public AxWriterPrintPreviewControl()
		{
			base.BorderStyle = BorderStyle.Fixed3D;
		}

		protected override void InnerClearMemberValues()
		{
			base.InnerClearMemberValues();
			_AxContentBase64String = null;
			_AxContentBase64StringLoader = null;
			_InstanceFactory = null;
		}

		/// <summary>
		///       为PB而关闭编辑器，用于解决PB中关闭编辑器而导致的程序闪退现象。
		///       </summary>
		[ComVisible(true)]
		public void CloseForPB()
		{
			try
			{
				List<Control> list = new List<Control>();
				foreach (Control control in base.Controls)
				{
					list.Add(control);
				}
				foreach (Control item in list)
				{
					base.Controls.Remove(item);
					item.Dispose();
				}
				InnerClearMemberValues();
				GC.SuppressFinalize(this);
				GC.Collect();
				dlgAxWriterControlDock.AddControl(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		/// <summary>
		///       为PB而关闭编辑器，用于解决PB中关闭编辑器而导致的程序闪退现象。本函数不会控件停靠到系统内置的垃圾堆窗体中。
		///       </summary>
		[ComVisible(true)]
		public void CloseForPBWithoutDock()
		{
			try
			{
				InnerClearMemberValues();
				List<Control> list = new List<Control>();
				foreach (Control control in base.Controls)
				{
					list.Add(control);
				}
				foreach (Control item in list)
				{
					base.Controls.Remove(item);
					item.Dispose();
				}
				GC.SuppressFinalize(this);
				GC.Collect();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				_AxContentBase64StringLoader = new GClass299();
				_AxContentBase64StringLoader.method_1(LoadAxContentBase64String);
				if (_AxContentBase64StringLoader != null)
				{
					_AxContentBase64StringLoader.method_2(300);
				}
			}
		}

		private void LoadAxContentBase64String(object sender, EventArgs e)
		{
			if (!base.DesignMode && !string.IsNullOrEmpty(_AxContentBase64String))
			{
				byte[] byte_ = Convert.FromBase64String(_AxContentBase64String);
				byte_ = FileHelper.GZipDecompress(byte_);
				AddDocumentByBinary(byte_, null);
				foreach (XTextDocument textDocument in base.TextDocuments)
				{
					if (textDocument.DocumentOptionsToSaveFile != null)
					{
						textDocument.Options = textDocument.DocumentOptionsToSaveFile;
					}
				}
				InvalidatePreview();
			}
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
			GC.Collect();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComRegisterFunction]
		private static void Register(Type type_0)
		{
			GClass305.smethod_1(type_0, "1");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComUnregisterFunction]
		private static void Unregister(Type type_0)
		{
			GClass305.smethod_2(type_0);
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message message_0)
		{
			if (!base.IsHandleCreated)
			{
				base.WndProc(ref message_0);
				return;
			}
			if (message_0.Msg == 7)
			{
				OnEnter(EventArgs.Empty);
			}
			else if (message_0.Msg == 528 && (message_0.WParam.ToInt32() == 513 || message_0.WParam.ToInt32() == 516))
			{
				if (!base.ContainsFocus)
				{
					OnEnter(EventArgs.Empty);
				}
			}
			else if (message_0.Msg == 2 && !base.IsDisposed && !base.Disposing)
			{
				Dispose();
			}
			base.WndProc(ref message_0);
		}

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
		public int GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
		{
			int num = 15;
			int num2 = -2147467259;
			string text = riid.ToString("B");
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
			case "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}":
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
		public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
		{
			int num = 17;
			int result = -2147467259;
			switch (riid.ToString("B"))
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
			case "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}":
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

		void IAxWriterPrintPreviewControl.PrintDocumentExt(bool param0, string param1)
		{
			PrintDocumentExt(param0, param1);
		}
	}
}
