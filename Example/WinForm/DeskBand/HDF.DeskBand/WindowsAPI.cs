using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HDF.DeskBand
{
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8
    }

    public struct HotKey
    {
        public Keys Key { get; set; }
        public KeyModifiers Modifier { get; set; }
        public HotKey(Keys key, KeyModifiers m)
        {
            Key = key;
            Modifier = m;
        }
    }


    public class WindowsAPI
    {
        [DllImport("kernel32.dll")]
        private static extern UInt32 GlobalAddAtom(String lpString);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr handle, int id, uint modifiers, uint virtualCode);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr handle, int id);




        private static Dictionary<HotKey, uint> HotKeyDict = new Dictionary<HotKey, uint>();


        public static bool RegisterHotKey(IntPtr handle, HotKey hotkey)
        {
            if (HotKeyDict.ContainsKey(hotkey))
                return false;
            var hotkeyid = GlobalAddAtom(Guid.NewGuid().ToString());
            HotKeyDict.Add(hotkey, hotkeyid);
            return RegisterHotKey(handle, (int)hotkeyid, (uint)hotkey.Modifier, (uint)hotkey.Key);
        }
        public static bool UnregisterHotKey(IntPtr handle, HotKey hotkey)
        {
            if (!HotKeyDict.ContainsKey(hotkey))
                return false;
            var hotkeyid = HotKeyDict[hotkey];
            HotKeyDict.Remove(hotkey);
            return UnregisterHotKey(handle, (int)hotkeyid);
        }

        public static bool RegisterHotKey(IntPtr handle, Keys key, KeyModifiers flag)
        {
            if (HotKeyDict.ContainsKey(new HotKey(key, flag)))
                return false;
            var hotkeyid = GlobalAddAtom(Guid.NewGuid().ToString());
            HotKeyDict.Add(new HotKey(key, flag), hotkeyid);
            return RegisterHotKey(handle, (int)hotkeyid, (uint)flag, (uint)key);
        }


        public static bool UnregisterHotKey(IntPtr handle, Keys key, KeyModifiers flag)
        {
            if (!HotKeyDict.ContainsKey(new HotKey(key, flag)))
                return false;
            var hotkeyid = HotKeyDict[new HotKey(key, flag)];
            return UnregisterHotKey(handle, (int)hotkeyid);
        }





        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);




        //private static IntPtr WindowsHandle;

        //public static bool AddClipboardFormatListener(IWin32Window windows)
        //{
        //    WindowsHandle = windows.Handle;
        //    if (WindowsHandle == IntPtr.Zero)
        //        return false;
        //    return AddClipboardFormatListener(WindowsHandle);
        //}

        //public static bool RemoveClipboardFormatListener(IWin32Window windows)
        //{
        //    WindowsHandle = windows.Handle;
        //    if (WindowsHandle == IntPtr.Zero)
        //        return false;
        //    return AddClipboardFormatListener(WindowsHandle);
        //}







        public static bool SetForeground(string windowName)
        {
            IntPtr Handle = FindWindow(windowName, null); //The className & WindowName I got using Spy++
            if (Handle != null)
            {
                return SetForegroundWindow(Handle);
            }
            return false;
        }
        //// 函数讲解：  https://blog.csdn.net/qq_34126663/article/details/70255257
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);





    }
}
