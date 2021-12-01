using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YidanSoft.Library.EmrEditor.Src.Print;

namespace CustomPrintDialog
{
    /// <summary>
    /// CustomPrintDialog is a direct (=PInvoke) implementation 
    /// for a print dialog customized with additional controls. Unfortunately
    /// this cannot be done by inheriting from the PrintDialog (is sealed) and
    /// has to be done by hand.
    /// This example simply adds a checkbox to the dialog offering the user the ability
    /// to "compress output to fit on one page".
    /// </summary>
    public class CustomPrintDialog : System.Windows.Forms.CommonDialog
    {
        //flags to allow user to enable / diable certain features
        private bool m_f_allow_selection;
        private bool m_f_allow_page_range;
        private bool m_f_shrink_output;

        public bool PrintHeader
        {
            get
            {
                return m_Panel.checkBoxHeader.Checked;
            }
        }

        public bool PrintFooter
        {
            get
            {
                return m_Panel.checkBoxFooter.Checked;
            }
        }

        //custom controls we add to the dialog; those controls must be members of the class to ensure that
        //their lifetime is equal to that of the dialog in which they appear; this example uses just a checkbox
        //private CheckBox m_cb = new CheckBox();
        public PrintExPanel m_Panel = new PrintExPanel();

        public CustomPrintDialog()
        {
            //this.pdlg.Flags.
        }

        /// <summary>
        /// Whether to enable the "Print range" control in the dialog or not.
        /// </summary>
        public bool AllowSomePages
        {
            get { return m_f_allow_page_range; }
            set { m_f_allow_page_range = value; }
        }

        /// <summary>
        /// Whether to enable the "Selection" control in the dialog or not.
        /// </summary>
        public bool AllowSelection
        {
            get { return m_f_allow_selection; }
            set { m_f_allow_selection = value; }
        }

        /// <summary>
        /// Whether to shrink the output to fit one one page (our custom functionality)
        /// </summary>
        public bool ShrinkOutputToFitOnOnePage
        {
            get { return m_f_shrink_output; }
            set { m_f_shrink_output = value; }
        }


        #region Imports from the Win32 API

        public delegate IntPtr PrintHookProc(IntPtr hdlg, Int32 msg, UInt16 wparam, Int32 lparam);

        private const Int32 PD_ALLPAGES = 0x00000000;
        private const Int32 PD_NOSELECTION = 0x00000004;
        private const Int32 PD_NOPAGENUMS = 0x00000008;
        private const Int32 PD_ENABLEPRINTHOOK = 0x00001000;

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public struct PRINTDLG
        {
            public Int32 lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hDevMode;
            public IntPtr hDevNames;
            public IntPtr hDC;
            public Int32 Flags;
            public UInt16 nFromPage;
            public UInt16 nToPage;
            public UInt16 nMinPage;
            public UInt16 nMaxPage;
            public UInt16 nCopies;
            public IntPtr hInstance;
            public Int32 lCustData;
            public PrintHookProc lpfnPrintHook;
            public IntPtr lpfnSetupHook;
            public string lpPrintTemplateName;
            public string lpSetupTemplateName;
            public IntPtr hPrintTemplate;
            public IntPtr hSetupTemplate;
        }

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto)]
        private static extern bool PrintDlg(ref PRINTDLG pdlg);

        [DllImport("comdlg32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 CommDlgExtendedError();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SetParent(IntPtr hwnd, IntPtr parent);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetDlgItem(IntPtr hwnd, int item_id);

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public int Width { get { return (int)(right - left); } }
            public int Height { get { return (int)(bottom - top); } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetWindowRect(IntPtr hwnd, ref RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ScreenToClient(IntPtr hwnd, ref POINT point);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr insert_after,
                                                 int x, int y, int width, int height, Int32 flags);

        private const int WM_INITDIALOG = 0x0110;

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;

        private const int IDOK = 1;
        private const int IDCANCEL = 2;

        #endregion

        #region Customization of the standard dialog through a callback (print hook procedure)

        /// <summary>
        /// Signature matching the delegate above which we instantiate and pass to
        /// the print dialog as the customization method.
        /// </summary>
        private IntPtr PrintCustomizationMethod(IntPtr hdlg, Int32 msg, UInt16 wparam, Int32 lparam)
        {
            if (msg == WM_INITDIALOG)
            {
                //create checkbox and attach it to the dialog
                SetParent(m_Panel.Handle, hdlg);

                //get current dialog size
                RECT rect = new RECT();
                GetWindowRect(hdlg, ref rect);

                //place the checkbox at the bottom of the dialog (using the top of the OK button as reference)
                RECT button_rect = new RECT();
                IntPtr h_button = GetDlgItem(hdlg, IDOK);
                GetWindowRect(h_button, ref button_rect);

                POINT pt;
                pt.x = button_rect.left;
                pt.y = button_rect.top;
                ScreenToClient(hdlg, ref pt);

                m_Panel.Location = new Point(12, pt.y);
                //m_cb.Size = new Size();//(rect.Width - 12, 100);//m_cb.Size.Height);
                m_Panel.Visible = true;
                m_Panel.Text = "Compress output to fit in one page";

                //set initial state and attach handler to combo box check event
                //m_cb.Checked = this.ShrinkOutputToFitOnOnePage;
                //m_cb.CheckedChanged += new EventHandler(cb_CheckedChanged);

                //extend the dialog down with the height of the checkbox
                SetWindowPos(hdlg, new IntPtr(0), 0, 0, rect.Width, rect.Height + m_Panel.Bounds.Height,
                              SWP_NOZORDER | SWP_NOMOVE);

                //move the OK and Cancel buttons down
                h_button = GetDlgItem(hdlg, IDOK);
                GetWindowRect(h_button, ref rect);
                pt.x = rect.left;
                pt.y = rect.top;
                ScreenToClient(hdlg, ref pt);

                SetWindowPos(h_button, new IntPtr(0), pt.x, pt.y + m_Panel.Bounds.Height, 0, 0,
                              SWP_NOZORDER | SWP_NOSIZE);

                h_button = GetDlgItem(hdlg, IDCANCEL);
                GetWindowRect(h_button, ref rect);
                pt.x = rect.left;
                pt.y = rect.top;
                ScreenToClient(hdlg, ref pt);

                SetWindowPos(h_button, new IntPtr(0), pt.x, pt.y + m_Panel.Bounds.Height, 0, 0,
                              SWP_NOZORDER | SWP_NOSIZE);
            }

            //allow processing of messages by default procedure by returning 0
            return new IntPtr(0);
        }

        /// <summary>
        /// Event handler for the custom combo box check event
        /// </summary>
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            this.ShrinkOutputToFitOnOnePage = cb.Checked;
        }

        #endregion

        #region Implementation of abstract methods of the base

        public PRINTDLG pdlg = new PRINTDLG();
        protected override bool RunDialog(System.IntPtr hwndOwner)
        {
            //initialize the structure required by the PrintDlg Win32 API
            //PRINTDLG pdlg = new PRINTDLG();
            pdlg.lStructSize = Marshal.SizeOf(pdlg);
            pdlg.hwndOwner = hwndOwner;



            pdlg.Flags |= PD_ALLPAGES;
            if (!this.AllowSelection)
            {
                pdlg.Flags |= PD_NOSELECTION;
            }

            if (!this.AllowSomePages)
            {
                pdlg.Flags |= PD_NOPAGENUMS;
            }

            //set the hook procedure to point to our instance of the delegate designed
            //for customizing the dialog. Without this, the class will just show the standard print dialog.
            pdlg.Flags |= PD_ENABLEPRINTHOOK;

            pdlg.lpfnPrintHook = new PrintHookProc(this.PrintCustomizationMethod);




            //show the Win32 common print dialog (customized by the hook above)
            bool f = false;
            try
            {
                f = PrintDlg(ref pdlg);
            }
            catch (Exception ex)
            {
                //any exception in the direct Win32 call is most likely caused by a faulty
                //printer driver (we had one issue where the user provided a stack trace 
                //pointing to this call that was resolved by uninstalling printer and installing
                //with a new printer driver)
                throw new ApplicationException("The current printer caused a Windows error:\n ", ex);
            }
            if (!f)
            {
                //closed with Cancel, or an error showing the dialog
                long err = CommDlgExtendedError();
                if (err != 0)
                {
                    Debug.WriteLine("Windows common dlg error code: " + err);
                }
            }

            return f;
        }

        public override void Reset()
        {
        }

        #endregion

    }

    /// <summary>
    /// Values that can be placed in the PRINTDLG structure, we don't use all of them
    /// </summary>
    internal class PrintFlag
    {
        public const Int32 PD_ALLPAGES = 0x00000000;
        public const Int32 PD_SELECTION = 0x00000001;
        public const Int32 PD_PAGENUMS = 0x00000002;
        public const Int32 PD_NOSELECTION = 0x00000004;
        public const Int32 PD_NOPAGENUMS = 0x00000008;
        public const Int32 PD_COLLATE = 0x00000010;
        public const Int32 PD_PRINTTOFILE = 0x00000020;
        public const Int32 PD_PRINTSETUP = 0x00000040;
        public const Int32 PD_NOWARNING = 0x00000080;
        public const Int32 PD_RETURNDC = 0x00000100;
        public const Int32 PD_RETURNIC = 0x00000200;
        public const Int32 PD_RETURNDEFAULT = 0x00000400;
        public const Int32 PD_SHOWHELP = 0x00000800;
        public const Int32 PD_ENABLEPRINTHOOK = 0x00001000;
        public const Int32 PD_ENABLESETUPHOOK = 0x00002000;
        public const Int32 PD_ENABLEPRINTTEMPLATE = 0x00004000;
        public const Int32 PD_ENABLESETUPTEMPLATE = 0x00008000;
        public const Int32 PD_ENABLEPRINTTEMPLATEHANDLE = 0x00010000;
        public const Int32 PD_ENABLESETUPTEMPLATEHANDLE = 0x00020000;
        public const Int32 PD_USEDEVMODECOPIES = 0x00040000;
        public const Int32 PD_USEDEVMODECOPIESANDCOLLATE = 0x00040000;
        public const Int32 PD_DISABLEPRINTTOFILE = 0x00080000;
        public const Int32 PD_HIDEPRINTTOFILE = 0x00100000;
        public const Int32 PD_NONETWORKBUTTON = 0x00200000;
    }
}
