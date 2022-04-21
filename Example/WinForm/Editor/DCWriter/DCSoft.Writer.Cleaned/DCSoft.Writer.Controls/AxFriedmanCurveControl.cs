#define DEBUG
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
    /// <summary>
    ///        产程图控件的ActiveX控件版本
    ///       </summary>
    /// <remarks>
    ///       本控件用于COM和B/S开发,不用于.NET开发.
    ///       编制 袁永福
    ///       </remarks>
    [ComVisible(true)]
    [ComClass("16CFBFC3-F102-4668-A00C-5223BCC50704", "E04D7C01-A7B6-4A49-A302-DEFB122D2631", "3BA92EF4-5C99-456C-B6C1-03DFAB8B5AD4")]


    [ComSourceInterfaces(typeof(IAxFriedmanCurveControlComEvents))]
    [Guid("16CFBFC3-F102-4668-A00C-5223BCC50704")]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(AxFriedmanCurveControl))]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IAxFriedmanCurveControl))]
    public class AxFriedmanCurveControl : FriedmanCurveControl, IObjectSafety, IAxFriedmanCurveControl
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

        internal const string CLASSID = "16CFBFC3-F102-4668-A00C-5223BCC50704";

        internal const string CLASSID_Interface = "E04D7C01-A7B6-4A49-A302-DEFB122D2631";

        internal const string CLASSID_ComEventInterface = "3BA92EF4-5C99-456C-B6C1-03DFAB8B5AD4";

        private bool _fSafeForScripting;

        private bool _fSafeForInitializing;

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

        DateTime IAxFriedmanCurveControl.CaretDateTime
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

        FriedmanCurveDocument IAxFriedmanCurveControl.Document
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

        string IAxFriedmanCurveControl.DocumentConfigXml
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

        int IAxFriedmanCurveControl.NumOfPages => base.NumOfPages;

        Color IAxFriedmanCurveControl.PageBackColor
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

        int IAxFriedmanCurveControl.PageIndex
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

        string IAxFriedmanCurveControl.RegisterCode
        {
            get
            {
                return base.RegisterCode;
            }
            set
            {
                base.RegisterCode = value;
            }
        }

        bool IAxFriedmanCurveControl.ShowTooltip
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

        bool IAxFriedmanCurveControl.ToolbarVisible
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

        FCDocumentViewMode IAxFriedmanCurveControl.ViewMode
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

        string IAxFriedmanCurveControl.XMLText
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

        string IAxFriedmanCurveControl.XMLTextIndented
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
        public AxFriedmanCurveControl()
        {
            int num = 5;
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
                Debug.WriteLine("AxFriedmanCurveControlLoad:" + ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            Debug.WriteLine("AxFriedmanCurveControlLoaded");
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
            int num = 18;
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
            int num = 1;
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

        public FCHeaderLabelInfo ComCreateHeaderLabelInfo()
        {
            return new FCHeaderLabelInfo();
        }

        public FCTitleLineInfo ComCreateTitleLineInfo()
        {
            return new FCTitleLineInfo();
        }

        public FCValuePoint ComCreateValuePoint()
        {
            return new FCValuePoint();
        }

        public FCYAxisInfo ComCreateYAxisInfo()
        {
            return new FCYAxisInfo();
        }

        public FCYAxisScaleInfo ComCreateYAxisScaleInfo()
        {
            return new FCYAxisScaleInfo();
        }

        public FriedmanCurveDocument ComCreateFriedmanCurveDocument()
        {
            return new FriedmanCurveDocument();
        }

        void IAxFriedmanCurveControl.AboutControl()
        {
            AboutControl();
        }

        void IAxFriedmanCurveControl.AddPoint(string param0, FCValuePoint param1)
        {
            AddPoint(param0, param1);
        }

        void IAxFriedmanCurveControl.AddPointByTimeText(string param0, DateTime param1, string param2)
        {
            AddPointByTimeText(param0, param1, param2);
        }

        void IAxFriedmanCurveControl.AddPointByTimeTextColor(string param0, DateTime param1, string param2, string param3)
        {
            AddPointByTimeTextColor(param0, param1, param2, param3);
        }

        void IAxFriedmanCurveControl.AddPointByTimeTextValue(string param0, DateTime param1, string param2, float param3)
        {
            AddPointByTimeTextValue(param0, param1, param2, param3);
        }

        void IAxFriedmanCurveControl.AddPointByTimeValue(string param0, DateTime param1, float param2)
        {
            AddPointByTimeValue(param0, param1, param2);
        }

        void IAxFriedmanCurveControl.AddPointByTimeValueLandernValue(string param0, DateTime param1, float param2, float param3)
        {
            AddPointByTimeValueLandernValue(param0, param1, param2, param3);
        }

        void IAxFriedmanCurveControl.BeginDeleteValuePoint()
        {
            BeginDeleteValuePoint();
        }

        void IAxFriedmanCurveControl.BeginDragValuePointFixDate()
        {
            BeginDragValuePointFixDate();
        }

        bool IAxFriedmanCurveControl.BeginInsertValuePointFor(string param0)
        {
            return BeginInsertValuePointFor(param0);
        }

        void IAxFriedmanCurveControl.CancelEditValuePoint()
        {
            CancelEditValuePoint();
        }

        void IAxFriedmanCurveControl.ClearData()
        {
            ClearData();
        }

        FCValuePoint IAxFriedmanCurveControl.CreateValuePoint()
        {
            return CreateValuePoint();
        }

        void IAxFriedmanCurveControl.InvalidateAll()
        {
            InvalidateAll();
        }

        void IAxFriedmanCurveControl.LoadDocumentFormString(string param0)
        {
            LoadDocumentFormString(param0);
        }

        void IAxFriedmanCurveControl.LoadDocumentFromFile(string param0)
        {
            LoadDocumentFromFile(param0);
        }

        void IAxFriedmanCurveControl.PrintCurrentPage()
        {
            PrintCurrentPage();
        }

        void IAxFriedmanCurveControl.PrintDocument()
        {
            PrintDocument();
        }

        void IAxFriedmanCurveControl.PrintDocumentPageIndex(string param0)
        {
            PrintDocumentPageIndex(param0);
        }

        void IAxFriedmanCurveControl.PrintDocumentSpecifyPageIndex(int param0)
        {
            PrintDocumentSpecifyPageIndex(param0);
        }

        void IAxFriedmanCurveControl.RefreshView()
        {
            RefreshView();
        }

        void IAxFriedmanCurveControl.RefreshViewWithoutRefreshDataSource()
        {
            RefreshViewWithoutRefreshDataSource();
        }

        bool IAxFriedmanCurveControl.RunDesigner()
        {
            return RunDesigner();
        }

        bool IAxFriedmanCurveControl.RunDesignerMax()
        {
            return RunDesignerMax();
        }

        void IAxFriedmanCurveControl.SaveDataHtmlToFile(string param0)
        {
            SaveDataHtmlToFile(param0);
        }

        void IAxFriedmanCurveControl.SaveDataHtmlToStream(Stream param0)
        {
            SaveDataHtmlToStream(param0);
        }

        void IAxFriedmanCurveControl.SaveDocumentToFile(string param0)
        {
            SaveDocumentToFile(param0);
        }

        string IAxFriedmanCurveControl.SaveDocumentToString()
        {
            return SaveDocumentToString();
        }

        bool IAxFriedmanCurveControl.SetFriedmanCurveZoneRange(string param0, DateTime param1, DateTime param2)
        {
            return SetFriedmanCurveZoneRange(param0, param1, param2);
        }

        void IAxFriedmanCurveControl.SetHeaderLableValue(string param0, string param1)
        {
            SetHeaderLableValue(param0, param1);
        }

        void IAxFriedmanCurveControl.SetHeaderLableValueByIndex(int param0, string param1)
        {
            SetHeaderLableValueByIndex(param0, param1);
        }

        void IAxFriedmanCurveControl.SetParameterValue(string param0, string param1)
        {
            SetParameterValue(param0, param1);
        }
    }
}
