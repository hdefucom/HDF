#define DEBUG
using DCSoft.Common;
using DCSoft.TemperatureChart;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///        体温单控件的ActiveX控件版本
	///       </summary>
	/// <remarks>
	///       本控件用于COM和B/S开发,不用于.NET开发.
	///       编制 袁永福
	///       </remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("2219FC85-1715-4B7E-B674-95637E1D3E88", "69ECCB7E-4595-4202-BD44-1C6EFF6237C7", "9BBA47B8-3E76-4D24-BD80-54E148043797")]
	
	[DocumentComment]
	[ToolboxItem(false)]
	[ToolboxBitmap(typeof(AxTemperatureControl))]
	[ComSourceInterfaces(typeof(IAxTemperatureControlComEvents))]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IAxTemperatureControl))]
	[Guid("2219FC85-1715-4B7E-B674-95637E1D3E88")]
	public class AxTemperatureControl : TemperatureControl, IObjectSafety, IAxTemperatureControl
	{
		internal const string CLASSID = "2219FC85-1715-4B7E-B674-95637E1D3E88";

		internal const string CLASSID_Interface = "69ECCB7E-4595-4202-BD44-1C6EFF6237C7";

		internal const string CLASSID_ComEventInterface = "9BBA47B8-3E76-4D24-BD80-54E148043797";

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

		private bool _fSafeForScripting;

		private bool _fSafeForInitializing;

		/// <summary>
		///       是否作为ActiveX控件的模式运行
		///       </summary>
		protected override bool IsAxControl => true;

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

		DateTime IAxTemperatureControl.CaretDateTime
		{
			get
			{
				return base.CaretDateTime;
			}
			set
			{
				base.CaretDateTime = value;
			}
		}

		TemperatureDocument IAxTemperatureControl.Document
		{
			get
			{
				return base.Document;
			}
			set
			{
				base.Document = value;
			}
		}

		string IAxTemperatureControl.DocumentConfigXml
		{
			get
			{
				return base.DocumentConfigXml;
			}
			set
			{
				base.DocumentConfigXml = value;
			}
		}

		int IAxTemperatureControl.NumOfPages => base.NumOfPages;

		Color IAxTemperatureControl.PageBackColor
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

		int IAxTemperatureControl.PageIndex
		{
			get
			{
				return base.PageIndex;
			}
			set
			{
				base.PageIndex = value;
			}
		}

		bool IAxTemperatureControl.ShowTooltip
		{
			get
			{
				return base.ShowTooltip;
			}
			set
			{
				base.ShowTooltip = value;
			}
		}

		bool IAxTemperatureControl.ToolbarVisible
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

		DocumentViewMode IAxTemperatureControl.ViewMode
		{
			get
			{
				return base.ViewMode;
			}
			set
			{
				base.ViewMode = value;
			}
		}

		string IAxTemperatureControl.XMLText
		{
			get
			{
				return base.XMLText;
			}
			set
			{
				base.XMLText = value;
			}
		}

		string IAxTemperatureControl.XMLTextIndented
		{
			get
			{
				return base.XMLTextIndented;
			}
			set
			{
				base.XMLTextIndented = value;
			}
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

		/// <summary>
		///       初始化对象
		///       </summary>
		public AxTemperatureControl()
		{
			int num = 4;
			_fSafeForScripting = true;
			_fSafeForInitializing = true;
			
			WriterControl.EnableVisualStyles();
			try
			{
				base.BorderStyle = BorderStyle.Fixed3D;
				BackColor = SystemColors.Control;
				CreateHandle();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("AxTemperatureControlLoad:" + ex.ToString());
				MessageBox.Show(ex.ToString());
			}
			Debug.WriteLine("AxTemperatureControlLoaded");
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
			int num = 5;
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
		
		public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
		{
			int num = 12;
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

		public HeaderLabelInfo ComCreateHeaderLabelInfo()
		{
			return new HeaderLabelInfo();
		}

		public TitleLineInfo ComCreateTitleLineInfo()
		{
			return new TitleLineInfo();
		}

		public ValuePoint ComCreateValuePoint()
		{
			return new ValuePoint();
		}

		public YAxisInfo ComCreateYAxisInfo()
		{
			return new YAxisInfo();
		}

		public YAxisScaleInfo ComCreateYAxisScaleInfo()
		{
			return new YAxisScaleInfo();
		}

		public TemperatureDocument ComCreateTemperatureDocument()
		{
			return new TemperatureDocument();
		}

		void IAxTemperatureControl.AboutControl()
		{
			AboutControl();
		}

		void IAxTemperatureControl.AddPoint(string param0, ValuePoint param1)
		{
			AddPoint(param0, param1);
		}

		void IAxTemperatureControl.AddPointByTimeText(string param0, DateTime param1, string param2)
		{
			AddPointByTimeText(param0, param1, param2);
		}

		void IAxTemperatureControl.AddPointByTimeTextColor(string param0, DateTime param1, string param2, string param3)
		{
			AddPointByTimeTextColor(param0, param1, param2, param3);
		}

		void IAxTemperatureControl.AddPointByTimeTextValue(string param0, DateTime param1, string param2, float param3)
		{
			AddPointByTimeTextValue(param0, param1, param2, param3);
		}

		void IAxTemperatureControl.AddPointByTimeValue(string param0, DateTime param1, float param2)
		{
			AddPointByTimeValue(param0, param1, param2);
		}

		void IAxTemperatureControl.AddPointByTimeValueLandernValue(string param0, DateTime param1, float param2, float param3)
		{
			AddPointByTimeValueLandernValue(param0, param1, param2, param3);
		}

		void IAxTemperatureControl.BeginDeleteValuePoint()
		{
			BeginDeleteValuePoint();
		}

		void IAxTemperatureControl.BeginDragValuePointFixDate()
		{
			BeginDragValuePointFixDate();
		}

		bool IAxTemperatureControl.BeginInsertValuePointFor(string param0)
		{
			return BeginInsertValuePointFor(param0);
		}

		void IAxTemperatureControl.CancelEditValuePoint()
		{
			CancelEditValuePoint();
		}

		void IAxTemperatureControl.ClearData()
		{
			ClearData();
		}

		ValuePoint IAxTemperatureControl.CreateValuePoint()
		{
			return CreateValuePoint();
		}

		void IAxTemperatureControl.LoadDocumentFormString(string param0)
		{
			LoadDocumentFormString(param0);
		}

		void IAxTemperatureControl.LoadDocumentFromFile(string param0)
		{
			LoadDocumentFromFile(param0);
		}

		void IAxTemperatureControl.PrintCurrentPage()
		{
			PrintCurrentPage();
		}

		void IAxTemperatureControl.PrintDocument()
		{
			PrintDocument();
		}

		void IAxTemperatureControl.PrintDocumentSpecifyPageIndex(int param0)
		{
			PrintDocumentSpecifyPageIndex(param0);
		}

		void IAxTemperatureControl.RefreshView()
		{
			RefreshView();
		}

		void IAxTemperatureControl.RefreshViewWithoutRefreshDataSource()
		{
			RefreshViewWithoutRefreshDataSource();
		}

		bool IAxTemperatureControl.RunDesigner()
		{
			return RunDesigner();
		}

		void IAxTemperatureControl.SaveDataHtmlToFile(string param0)
		{
			SaveDataHtmlToFile(param0);
		}

		void IAxTemperatureControl.SaveDocumentToFile(string param0)
		{
			SaveDocumentToFile(param0);
		}

		string IAxTemperatureControl.SaveDocumentToString()
		{
			return SaveDocumentToString();
		}

		void IAxTemperatureControl.SetHeaderLableValue(string param0, string param1)
		{
			SetHeaderLableValue(param0, param1);
		}

		void IAxTemperatureControl.SetHeaderLableValueByIndex(int param0, string param1)
		{
			SetHeaderLableValueByIndex(param0, param1);
		}

		void IAxTemperatureControl.SetParameterValue(string param0, string param1)
		{
			SetParameterValue(param0, param1);
		}

		void IAxTemperatureControl.SetRegisterCode(string param0)
		{
			SetRegisterCode(param0);
		}

		bool IAxTemperatureControl.SetTimeLineZoneRange(string param0, DateTime param1, DateTime param2)
		{
			return SetTimeLineZoneRange(param0, param1, param2);
		}
	}
}
