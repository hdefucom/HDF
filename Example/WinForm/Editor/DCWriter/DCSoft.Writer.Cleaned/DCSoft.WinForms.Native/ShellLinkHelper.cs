using DCSoft.Common;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       /Windows操作系统快捷方式处理模块
	///       </summary>
	[ComVisible(false)]
	
	public static class ShellLinkHelper
	{
		[ComImport]
		[ComVisible(false)]
		[Guid("00021401-0000-0000-C000-000000000046")]
		internal class ShellLink
		{
			//[MethodImpl(MethodImplOptions.InternalCall)]
			//public extern ShellLink();
		}

		[ComImport]
		[Guid("000214F9-0000-0000-C000-000000000046")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[ComVisible(false)]
		internal interface IShellLink
		{
			void GetPath([Out] [MarshalAs(UnmanagedType.LPWStr)] string pszFile, int cchMaxPath, out IntPtr intptr_0, int fFlags);

			void GetIDList(out IntPtr ppidl);

			void SetIDList(IntPtr pidl);

			void GetDescription([Out] [MarshalAs(UnmanagedType.LPWStr)] string pszName, int cchMaxName);

			void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			void GetWorkingDirectory([Out] [MarshalAs(UnmanagedType.LPWStr)] string pszDir, int cchMaxPath);

			void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

			void GetArguments([Out] [MarshalAs(UnmanagedType.LPWStr)] string pszArgs, int cchMaxPath);

			void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

			void GetHotkey(out short pwHotkey);

			void SetHotkey(short wHotkey);

			void GetShowCmd(out int piShowCmd);

			void SetShowCmd(int iShowCmd);

			void GetIconLocation([Out] [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int cchIconPath, out int piIcon);

			void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

			void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);

			void Resolve(IntPtr hwnd, int fFlags);

			void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
		}

		/// <summary>
		///       在桌面上创建指定文件的快捷方式
		///       </summary>
		/// <param name="sourceFileName">来源文件</param>
		/// <param name="description">描述</param>
		/// <returns>操作是否成功</returns>
		public static bool CreateDesktopShortcut(string sourceFileName, string description)
		{
			int num = 18;
			if (string.IsNullOrEmpty(sourceFileName))
			{
				throw new ArgumentNullException("sourceFileName");
			}
			if (!File.Exists(sourceFileName))
			{
				throw new FileNotFoundException(sourceFileName);
			}
			string path = Path.GetFileName(sourceFileName) + ".lnk";
			path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), path);
			return CreateShortcut(sourceFileName, description, path);
		}

		/// <summary>
		///       创建快捷方式
		///       </summary>
		/// <param name="sourceFileName">来源文件名</param>
		/// <param name="description">描述</param>
		/// <param name="targetFileName">目标文件名</param>
		/// <returns>操作是否成功</returns>
		public static bool CreateShortcut(string sourceFileName, string description, string targetFileName)
		{
			int num = 5;
			if (string.IsNullOrEmpty(sourceFileName))
			{
				throw new ArgumentNullException("sourceFileName");
			}
			if (string.IsNullOrEmpty(targetFileName))
			{
				throw new ArgumentNullException("targetFileName");
			}
			if (!File.Exists(sourceFileName))
			{
				throw new FileNotFoundException(sourceFileName);
			}
			IShellLink shellLink = (IShellLink)new ShellLink();
			if (!string.IsNullOrEmpty(description))
			{
				shellLink.SetDescription(description);
			}
			shellLink.SetPath(sourceFileName);
			IPersistFile persistFile = (IPersistFile)shellLink;
			persistFile.Save(targetFileName, fRemember: false);
			return true;
		}
	}
}
