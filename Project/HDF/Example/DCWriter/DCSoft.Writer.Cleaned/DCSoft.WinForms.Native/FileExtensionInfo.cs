using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       文件扩展名信息对象
	///       </summary>
	/// <remarks>本对象可以从操作系统注册表中获得指定文件扩展名的描述信息,编写 袁永福</remarks>
	[ComVisible(false)]
	public class FileExtensionInfo : IDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct SHFILEINFO
		{
			public IntPtr hIcon;

			public int iIcon;

			public uint dwAttributes;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		private enum FileInfoFlags : uint
		{
			SHGFI_ICON = 0x100,
			SHGFI_DISPLAYNAME = 0x200,
			SHGFI_TYPENAME = 0x400,
			SHGFI_ATTRIBUTES = 0x800,
			SHGFI_ICONLOCATION = 0x1000,
			SHGFI_EXETYPE = 0x2000,
			SHGFI_SYSICONINDEX = 0x4000,
			SHGFI_LINKOVERLAY = 0x8000,
			SHGFI_SELECTED = 0x10000,
			SHGFI_ATTR_SPECIFIED = 0x20000,
			SHGFI_LARGEICON = 0u,
			SHGFI_SMALLICON = 1u,
			SHGFI_OPENICON = 2u,
			SHGFI_SHELLICONSIZE = 4u,
			SHGFI_PIDL = 8u,
			SHGFI_USEFILEATTRIBUTES = 0x10,
			SHGFI_ADDOVERLAYS = 0x20,
			SHGFI_OVERLAYINDEX = 0x40
		}

		private enum FileAttributeFlags : uint
		{
			FILE_ATTRIBUTE_READONLY = 1u,
			FILE_ATTRIBUTE_HIDDEN = 2u,
			FILE_ATTRIBUTE_SYSTEM = 4u,
			FILE_ATTRIBUTE_DIRECTORY = 0x10,
			FILE_ATTRIBUTE_ARCHIVE = 0x20,
			FILE_ATTRIBUTE_DEVICE = 0x40,
			FILE_ATTRIBUTE_NORMAL = 0x80,
			FILE_ATTRIBUTE_TEMPORARY = 0x100,
			FILE_ATTRIBUTE_SPARSE_FILE = 0x200,
			FILE_ATTRIBUTE_REPARSE_POINT = 0x400,
			FILE_ATTRIBUTE_COMPRESSED = 0x800,
			FILE_ATTRIBUTE_OFFLINE = 0x1000,
			FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x2000,
			FILE_ATTRIBUTE_ENCRYPTED = 0x4000
		}

		private static Icon _DirectoryIcon = null;

		private static List<FileExtensionInfo> _Items = new List<FileExtensionInfo>();

		private static FileExtensionInfo _NoneInstance = new FileExtensionInfo();

		protected string _Extension = null;

		private string _ExtensionType = null;

		private string _ContentType = null;

		private string _PerceivedType = null;

		private string[] _OpenWithList = null;

		private string _ExtensionDesc = null;

		private Icon _DefaultIcon = null;

		private string _DefaultIconSource = null;

		private string[] _ShellCommands = null;

		private string _ShellEditCommand = null;

		private string _ShellOpenCommand = null;

		private string _ShellPrintCommand = null;

		private string _ShellPrinttoCommand = null;

		/// <summary>
		///       文件夹图标
		///       </summary>
		public static Icon DirectoryIcon
		{
			get
			{
				if (_DirectoryIcon == null)
				{
					_DirectoryIcon = GetDirectoryIcon(isLargeIcon: false);
				}
				return _DirectoryIcon;
			}
		}

		/// <summary>
		///       文件扩展名
		///       </summary>
		public string Extension => _Extension;

		/// <summary>
		///       文件类型名称
		///       </summary>
		public string ExtensionType => _ExtensionType;

		/// <summary>
		///       文件内容类型
		///       </summary>
		public string ContentType => _ContentType;

		public string PerceivedType => _PerceivedType;

		/// <summary>
		///       打开文档的程序名称列表
		///       </summary>
		public string[] OpenWithList => _OpenWithList;

		/// <summary>
		///       文件类型说明
		///       </summary>
		public string ExtensionDesc => _ExtensionDesc;

		public Icon DefaultIcon => _DefaultIcon;

		/// <summary>
		///       默认图标来源
		///       </summary>
		public string DefaultIconSource => _DefaultIconSource;

		/// <summary>
		///       返回所有的命令行信息,3个字符串一组,其中第一个为名称名称,第二个为命令显示名称,第三个为名称行字符串
		///       </summary>
		public string[] ShellCommands => _ShellCommands;

		/// <summary>
		///       编辑文档的命令行
		///       </summary>
		public string ShellEditCommand => _ShellEditCommand;

		/// <summary>
		///       打开文档的命令行
		///       </summary>
		public string ShellOpenCommand => _ShellOpenCommand;

		/// <summary>
		///       打印文档的命令行
		///       </summary>
		public string ShellPrintCommand => _ShellPrintCommand;

		/// <summary>
		///       打开新文档的命令行
		///       </summary>
		public string ShellPrinttoCommand => _ShellPrinttoCommand;

		public static FileExtensionInfo GetByFileName(string fileName)
		{
			int num = 16;
			string extension = Path.GetExtension(fileName);
			if (string.IsNullOrEmpty(extension))
			{
				return GetByExtension("*");
			}
			return GetByExtension(extension);
		}

		public static FileExtensionInfo GetByExtension(string extension)
		{
			int num = 7;
			foreach (FileExtensionInfo item in _Items)
			{
				if (string.Compare(item.Extension, extension, ignoreCase: true) == 0)
				{
					return item;
				}
			}
			FileExtensionInfo fileExtensionInfo = new FileExtensionInfo();
			fileExtensionInfo._Extension = extension;
			fileExtensionInfo._ExtensionType = fileExtensionInfo.GetRegValue(null);
			fileExtensionInfo._ContentType = fileExtensionInfo.GetRegValue("Content Type");
			fileExtensionInfo._PerceivedType = fileExtensionInfo.GetRegValue("PerceivedType");
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(fileExtensionInfo._Extension + "\\OpenWithList");
			if (registryKey != null)
			{
				string[] subKeyNames = registryKey.GetSubKeyNames();
				registryKey.Close();
				fileExtensionInfo._OpenWithList = subKeyNames;
			}
			fileExtensionInfo._ExtensionDesc = fileExtensionInfo.GetRegValueEx("");
			fileExtensionInfo._DefaultIconSource = fileExtensionInfo.GetRegValueEx("\\DefaultIcon");
			fileExtensionInfo._DefaultIcon = GetIcon("aaa" + fileExtensionInfo.Extension, isLargeIcon: false);
			if (fileExtensionInfo._DefaultIcon == null)
			{
				string text = fileExtensionInfo.DefaultIconSource;
				if (!string.IsNullOrEmpty(text))
				{
					int index = 0;
					int num2 = text.LastIndexOf(",");
					if (num2 > 0)
					{
						index = Convert.ToInt32(text.Substring(num2 + 1));
						text = text.Substring(0, num2).Trim();
						text = Environment.ExpandEnvironmentVariables(text);
					}
					text = text.Trim();
					text = text.Replace("%1", "");
					if (File.Exists(text))
					{
						IntPtr intPtr = ExtractIcon(IntPtr.Zero, text, index);
						if (intPtr != IntPtr.Zero)
						{
							fileExtensionInfo._DefaultIcon = Icon.FromHandle(intPtr);
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(fileExtensionInfo.ExtensionType))
			{
				registryKey = Registry.ClassesRoot.OpenSubKey(fileExtensionInfo.ExtensionType + "\\shell");
				if (registryKey != null)
				{
					ArrayList arrayList = new ArrayList();
					string[] subKeyNames2 = registryKey.GetSubKeyNames();
					string[] array = subKeyNames2;
					foreach (string text2 in array)
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey(text2);
						arrayList.Add(text2);
						arrayList.Add(Convert.ToString(registryKey2.GetValue(null)));
						RegistryKey registryKey3 = registryKey2.OpenSubKey("command");
						if (registryKey3 != null)
						{
							arrayList.Add(Convert.ToString(registryKey3.GetValue(null)));
							registryKey3.Close();
						}
						else
						{
							arrayList.Add("");
						}
						registryKey2.Close();
					}
					registryKey.Close();
					fileExtensionInfo._ShellCommands = (string[])arrayList.ToArray(typeof(string));
				}
			}
			fileExtensionInfo._ShellEditCommand = fileExtensionInfo.GetRegValueEx("\\shell\\Edit\\command");
			fileExtensionInfo._ShellOpenCommand = fileExtensionInfo.GetRegValueEx("\\shell\\Open\\command");
			fileExtensionInfo._ShellPrintCommand = fileExtensionInfo.GetRegValueEx("\\shell\\Print\\command");
			fileExtensionInfo._ShellPrinttoCommand = fileExtensionInfo.GetRegValueEx("\\shell\\opennew\\command");
			_Items.Add(fileExtensionInfo);
			return fileExtensionInfo;
		}

		/// <summary>
		///       无作为的初始化对象
		///       </summary>
		private FileExtensionInfo()
		{
		}

		private string GetRegValueEx(string Path)
		{
			string extensionType = ExtensionType;
			if (!string.IsNullOrEmpty(extensionType))
			{
				RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(extensionType + Path);
				if (registryKey != null)
				{
					extensionType = Convert.ToString(registryKey.GetValue(null));
					registryKey.Close();
					return extensionType;
				}
			}
			return null;
		}

		private string GetRegValue(string KeyName)
		{
			int num = 17;
			if (string.IsNullOrEmpty(Extension))
			{
				return null;
			}
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(_Extension);
			if (registryKey == null)
			{
				return null;
			}
			string text = Convert.ToString(registryKey.GetValue(KeyName));
			registryKey.Close();
			if (KeyName == null)
			{
				registryKey = Registry.ClassesRoot.OpenSubKey(text);
				if (registryKey != null)
				{
					RegistryKey registryKey2 = registryKey.OpenSubKey("CurVer", writable: false);
					if (registryKey2 != null)
					{
						text = Convert.ToString(registryKey2.GetValue(null));
						registryKey2.Close();
					}
				}
			}
			return text;
		}

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, string iconPath, ref int index);

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr ExtractIcon(IntPtr hInst, string iconPath, int index);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "DestroyIcon", ExactSpelling = true, SetLastError = true)]
		private static extern bool DestroyIcon_1(IntPtr hIcon);

		[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		[DllImport("user32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);

		/// <summary>
		///       获取文件类型的关联图标
		///       </summary>
		/// <param name="fileName">文件类型的扩展名或文件的绝对路径</param>
		/// <param name="isLargeIcon">是否返回大图标</param>
		/// <returns>获取到的图标</returns>
		private static Icon GetIcon(string fileName, bool isLargeIcon)
		{
			SHFILEINFO psfi = default(SHFILEINFO);
			if (isLargeIcon)
			{
				SHGetFileInfo(fileName, 0u, ref psfi, (uint)Marshal.SizeOf(psfi), 272u);
			}
			else
			{
				SHGetFileInfo(fileName, 0u, ref psfi, (uint)Marshal.SizeOf(psfi), 273u);
			}
			Icon result = Icon.FromHandle(psfi.hIcon).Clone() as Icon;
			DestroyIcon(psfi.hIcon);
			return result;
		}

		/// <summary> 
		///       获取文件夹图标
		///       </summary>
		/// <returns>图标</returns>
		private static Icon GetDirectoryIcon(bool isLargeIcon)
		{
			SHFILEINFO psfi = default(SHFILEINFO);
			if (((!isLargeIcon) ? SHGetFileInfo("", 0u, ref psfi, (uint)Marshal.SizeOf(psfi), 257u) : SHGetFileInfo("", 0u, ref psfi, (uint)Marshal.SizeOf(psfi), 256u)).Equals(IntPtr.Zero))
			{
				return null;
			}
			return Icon.FromHandle(psfi.hIcon);
		}

		public void Dispose()
		{
			if (_DefaultIcon != null)
			{
				DestroyIcon_1(_DefaultIcon.Handle);
				_DefaultIcon.Dispose();
				_DefaultIcon = null;
			}
		}
	}
}
