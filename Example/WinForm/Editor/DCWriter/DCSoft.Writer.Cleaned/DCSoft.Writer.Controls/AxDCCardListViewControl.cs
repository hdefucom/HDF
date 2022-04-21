#define DEBUG
using DCSoft.Common;
using DCSoft.WinForms.Controls;
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
	
	[ComDefaultInterface(typeof(IAxDCCardListViewControl))]
	[ComClass("00DF110D-DF3E-4D54-A5B9-663D432B71BA", "4AA75334-A12F-4529-9CBE-A2C3E82F298E", "39655E71-F969-4804-B3B9-A43B0CD30AA2")]
	[ToolboxBitmap(typeof(AxDCCardListViewControl))]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ToolboxItem(false)]
	[ComSourceInterfaces(typeof(IAxDCCardListViewControlComEvents))]
	[Guid("00DF110D-DF3E-4D54-A5B9-663D432B71BA")]
	[ComVisible(true)]
	public class AxDCCardListViewControl : DCCardListViewControl, IObjectSafety, IAxDCCardListViewControl
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

		internal const string CLASSID = "00DF110D-DF3E-4D54-A5B9-663D432B71BA";

		internal const string CLASSID_Interface = "4AA75334-A12F-4529-9CBE-A2C3E82F298E";

		internal const string CLASSID_ComEventInterface = "39655E71-F969-4804-B3B9-A43B0CD30AA2";

		private bool _fSafeForScripting;

		private bool _fSafeForInitializing;

		int IAxDCCardListViewControl.BlinkTimerInterval
		{
			get
			{
				return base.BlinkTimerInterval;
			}
			set
			{
				base.BlinkTimerInterval = value;
			}
		}

		Color IAxDCCardListViewControl.CardBackColor
		{
			get
			{
				return base.CardBackColor;
			}
			set
			{
				base.CardBackColor = value;
			}
		}

		Color IAxDCCardListViewControl.CardBorderColor
		{
			get
			{
				return base.CardBorderColor;
			}
			set
			{
				base.CardBorderColor = value;
			}
		}

		int IAxDCCardListViewControl.CardBorderWith
		{
			get
			{
				return base.CardBorderWith;
			}
			set
			{
				base.CardBorderWith = value;
			}
		}

		int IAxDCCardListViewControl.CardHeight
		{
			get
			{
				return base.CardHeight;
			}
			set
			{
				base.CardHeight = value;
			}
		}

		int IAxDCCardListViewControl.CardLineSpacing
		{
			get
			{
				return base.CardLineSpacing;
			}
			set
			{
				base.CardLineSpacing = value;
			}
		}

		int IAxDCCardListViewControl.CardRoundRadio
		{
			get
			{
				return base.CardRoundRadio;
			}
			set
			{
				base.CardRoundRadio = value;
			}
		}

		int IAxDCCardListViewControl.CardSpacing
		{
			get
			{
				return base.CardSpacing;
			}
			set
			{
				base.CardSpacing = value;
			}
		}

		string IAxDCCardListViewControl.CardTemplateConfigXml
		{
			get
			{
				return base.CardTemplateConfigXml;
			}
			set
			{
				base.CardTemplateConfigXml = value;
			}
		}

		int IAxDCCardListViewControl.CardWidth
		{
			get
			{
				return base.CardWidth;
			}
			set
			{
				base.CardWidth = value;
			}
		}

		bool IAxDCCardListViewControl.EnableSupperTooltip
		{
			get
			{
				return base.EnableSupperTooltip;
			}
			set
			{
				base.EnableSupperTooltip = value;
			}
		}

		int IAxDCCardListViewControl.ImageAnimateInterval
		{
			get
			{
				return base.ImageAnimateInterval;
			}
			set
			{
				base.ImageAnimateInterval = value;
			}
		}

		DCCardListViewItemCollection IAxDCCardListViewControl.Items
		{
			get
			{
				return base.Items;
			}
			set
			{
				base.Items = value;
			}
		}

		bool IAxDCCardListViewControl.JustifySpacing
		{
			get
			{
				return base.JustifySpacing;
			}
			set
			{
				base.JustifySpacing = value;
			}
		}

		DCCardListViewItem IAxDCCardListViewControl.MouseHoverItem => base.MouseHoverItem;

		Color IAxDCCardListViewControl.SelectedCardBackColor
		{
			get
			{
				return base.SelectedCardBackColor;
			}
			set
			{
				base.SelectedCardBackColor = value;
			}
		}

		bool IAxDCCardListViewControl.ShowCardShade
		{
			get
			{
				return base.ShowCardShade;
			}
			set
			{
				base.ShowCardShade = value;
			}
		}

		int IAxDCCardListViewControl.TooltipHeight
		{
			get
			{
				return base.TooltipHeight;
			}
			set
			{
				base.TooltipHeight = value;
			}
		}

		int IAxDCCardListViewControl.TooltipWidth
		{
			get
			{
				return base.TooltipWidth;
			}
			set
			{
				base.TooltipWidth = value;
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

		/// <summary>
		///       初始化对象
		///       </summary>
		public AxDCCardListViewControl()
		{
			int num = 12;
			_fSafeForScripting = true;
			_fSafeForInitializing = true;
			
			WriterControl.EnableVisualStyles();
			try
			{
				base.BorderStyle = BorderStyle.Fixed3D;
				CreateHandle();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("AxDCCardListViewControlLoad:" + ex.ToString());
				MessageBox.Show(ex.ToString());
			}
			BackColor = SystemColors.Control;
			Debug.WriteLine("AxDCCardListViewControlLoaded");
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
			int num = 9;
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
			int num = 18;
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

		int IAxDCCardListViewControl.AddNewItem()
		{
			return AddNewItem();
		}

		void IAxDCCardListViewControl.Clear()
		{
			Clear();
		}

		bool IAxDCCardListViewControl.EditCardTemplateConfigXml()
		{
			return EditCardTemplateConfigXml();
		}

		void IAxDCCardListViewControl.InvalidateItemByIndex(int param0)
		{
			InvalidateItemByIndex(param0);
		}

		void IAxDCCardListViewControl.RefreshView()
		{
			RefreshView();
		}

		void IAxDCCardListViewControl.SetListItemBlink(int param0, bool param1)
		{
			SetListItemBlink(param0, param1);
		}

		void IAxDCCardListViewControl.SetListItemHighlight(int param0, bool param1)
		{
			SetListItemHighlight(param0, param1);
		}

		void IAxDCCardListViewControl.SetListItemImageValueByBase64String(int param0, string param1, string param2)
		{
			SetListItemImageValueByBase64String(param0, param1, param2);
		}

		void IAxDCCardListViewControl.SetListItemImageValueByFileName(int param0, string param1, string param2)
		{
			SetListItemImageValueByFileName(param0, param1, param2);
		}

		void IAxDCCardListViewControl.SetListItemStringValue(int param0, string param1, string param2)
		{
			SetListItemStringValue(param0, param1, param2);
		}
	}
}
