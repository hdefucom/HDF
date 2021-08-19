using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       .NET assembly information
	///       </summary>
	[Serializable]
	[TypeConverter(typeof(DotNetAssemblyInfoConverter))]
	[ComVisible(false)]
	public class DotNetAssemblyInfo : ICloneable
	{
		private static string strRuntimePath = null;

		private string strName;

		private string strFullName;

		private string strCodeBase;

		private string strFileName;

		private Version myVersion;

		private Version myRuntimeVersion;

		private AssemblyNameFlags intFlags;

		private AssemblySourceStyle intSourceStyle;

		/// <summary>
		///       the directory of clr runtime library
		///       </summary>
		public static string RuntimePath
		{
			get
			{
				if (strRuntimePath == null)
				{
					strRuntimePath = GetFileNameByCodeBase(typeof(string).Assembly.CodeBase);
					strRuntimePath = Path.GetDirectoryName(strRuntimePath);
				}
				return strRuntimePath;
			}
		}

		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		public string FullName
		{
			get
			{
				return strFullName;
			}
			set
			{
				strFullName = value;
			}
		}

		public string CodeBase
		{
			get
			{
				return strCodeBase;
			}
			set
			{
				strCodeBase = value;
			}
		}

		public string FileName
		{
			get
			{
				int num = 2;
				if (strFileName == null)
				{
					strFileName = strName;
					if (!strFileName.ToLower().EndsWith(".dll"))
					{
						strFileName += ".dll";
					}
					if (intSourceStyle == AssemblySourceStyle.Standard)
					{
						strFileName = Path.Combine(RuntimePath, strFileName);
					}
				}
				return strFileName;
			}
			set
			{
				strFileName = value;
			}
		}

		/// <summary>
		///       assembly version
		///       </summary>
		[XmlIgnore]
		public Version Version
		{
			get
			{
				return myVersion;
			}
			set
			{
				myVersion = value;
			}
		}

		[Browsable(false)]
		[XmlElement]
		public string VersionString
		{
			get
			{
				return myVersion.ToString();
			}
			set
			{
				if (value != null && value.Trim().Length > 0)
				{
					myVersion = new Version(value);
				}
				else
				{
					myVersion = new Version();
				}
			}
		}

		/// <summary>
		///       clr runtime version
		///       </summary>
		[XmlIgnore]
		public Version RuntimeVersion
		{
			get
			{
				return myRuntimeVersion;
			}
			set
			{
				myRuntimeVersion = value;
			}
		}

		[Browsable(false)]
		[XmlElement]
		public string RuntimeVersionString
		{
			get
			{
				return myRuntimeVersion.ToString();
			}
			set
			{
				if (value != null && value.Trim().Length > 0)
				{
					myRuntimeVersion = new Version(value);
				}
				else
				{
					myRuntimeVersion = new Version();
				}
			}
		}

		public AssemblyNameFlags Flags
		{
			get
			{
				return intFlags;
			}
			set
			{
				intFlags = value;
			}
		}

		/// <summary>
		///       assembly source style
		///       </summary>
		public AssemblySourceStyle SourceStyle
		{
			get
			{
				return intSourceStyle;
			}
			set
			{
				intSourceStyle = value;
			}
		}

		/// <summary>
		///       获得标准的程序集文件全路径名
		///       </summary>
		/// <param name="name">程序集名称</param>
		/// <returns>获得的全路径名，若不存在则返回空引用</returns>
		public static string GetStandardAssemblyFileName(string name)
		{
			int num = 14;
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				return null;
			}
			if (!name.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase))
			{
				name += ".dll";
			}
			name = Path.GetFileName(name);
			name = Path.Combine(RuntimePath, name);
			if (File.Exists(name))
			{
				return name;
			}
			return null;
		}

		/// <summary>
		///       Returns the version number of a specified file.
		///       </summary>
		/// <param name="szFilename">The path of the file to be examined</param>
		/// <param name="szBuffer">The buffer allocated for the version information that is returned</param>
		/// <param name="cchBuffer">The size, in wide characters, of szBuffer</param>
		/// <param name="dwLength">The size, in bytes, of the returned szBuffer</param>
		/// <returns>Returns the version of the CLR for the file, or empty string if the file is not a .NET assembly. </returns>
		[DllImport("mscoree.dll")]
		private static extern int GetFileVersion([MarshalAs(UnmanagedType.LPWStr)] string szFilename, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder szBuffer, int cchBuffer, out int dwLength);

		/// <summary>
		///       Returns the .NET runtime version associated with the specified file
		///       </summary>
		/// <param name="fileName">Name of the assembly</param>
		/// <returns>The version of the .NET runtime</returns>
		[SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static string GetRuntimeVersion(string fileName)
		{
			StringBuilder stringBuilder = new StringBuilder(1024);
			int dwLength;
			int fileVersion = GetFileVersion(fileName, stringBuilder, stringBuilder.Capacity, out dwLength);
			if (fileVersion == -2147024885)
			{
				return string.Empty;
			}
			if (fileVersion < 0)
			{
				throw new Win32Exception(fileVersion);
			}
			return stringBuilder.ToString(0, dwLength - 1);
		}

		/// <summary>
		///       Checks if the specified file is a .NET assembly
		///       </summary>
		/// <param name="path">Path to the assembly</param>
		/// <returns>True, if the specified file is a .NET assembly</returns>
		public static bool IsDotNetAssembly(string path)
		{
			string runtimeVersion = GetRuntimeVersion(path);
			return runtimeVersion != null && runtimeVersion.Trim().Length > 0;
		}

		public static bool IsManagedAssemblyByReadFile(string fileName)
		{
			uint[] array = new uint[16];
			uint[] array2 = new uint[16];
			using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				BinaryReader binaryReader = new BinaryReader(stream);
				stream.Position = 60L;
				uint num = binaryReader.ReadUInt32();
				stream.Position = num;
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt16();
				binaryReader.ReadUInt16();
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt16();
				binaryReader.ReadUInt16();
				ushort num2 = Convert.ToUInt16(Convert.ToUInt16(stream.Position) + 96);
				stream.Position = num2;
				for (int i = 0; i < 15; i++)
				{
					array[i] = binaryReader.ReadUInt32();
					array2[i] = binaryReader.ReadUInt32();
				}
				stream.Close();
			}
			if (array[14] == 0)
			{
				return false;
			}
			return true;
		}

		public static string GetFileNameByCodeBase(string codeBase)
		{
			if (codeBase != null)
			{
				Uri uri = new Uri(codeBase);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					return uri.LocalPath;
				}
			}
			return null;
		}

		public static DotNetAssemblyInfo CreateByFileName(string FileName)
		{
			DotNetAssemblyInfo dotNetAssemblyInfo = new DotNetAssemblyInfo(AssemblyName.GetAssemblyName(FileName));
			dotNetAssemblyInfo.FileName = FileName;
			if (string.Compare(Path.GetDirectoryName(FileName), RuntimePath, ignoreCase: true) == 0)
			{
				dotNetAssemblyInfo.intSourceStyle = AssemblySourceStyle.Standard;
			}
			else
			{
				dotNetAssemblyInfo.intSourceStyle = AssemblySourceStyle.ThirdPart;
			}
			return dotNetAssemblyInfo;
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		public DotNetAssemblyInfo()
		{
			strName = null;
			strFullName = null;
			strCodeBase = null;
			strFileName = null;
			myVersion = new Version();
			myRuntimeVersion = new Version();
			intFlags = AssemblyNameFlags.None;
			intSourceStyle = AssemblySourceStyle.Custom;
			
		}

		public DotNetAssemblyInfo(AssemblyName name)
		{
			strName = null;
			strFullName = null;
			strCodeBase = null;
			strFileName = null;
			myVersion = new Version();
			myRuntimeVersion = new Version();
			intFlags = AssemblyNameFlags.None;
			intSourceStyle = AssemblySourceStyle.Custom;
			
			strName = name.Name;
			strFullName = name.FullName;
			strCodeBase = name.CodeBase;
			if (strCodeBase != null)
			{
				Uri uri = new Uri(strCodeBase);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					strFileName = uri.LocalPath;
				}
			}
			myVersion = name.Version;
			intFlags = name.Flags;
		}

		public DotNetAssemblyInfo(string name, string version, string runtimeversion, string codeBase, string fileName, AssemblyNameFlags flags)
		{
			strName = null;
			strFullName = null;
			strCodeBase = null;
			strFileName = null;
			myVersion = new Version();
			myRuntimeVersion = new Version();
			intFlags = AssemblyNameFlags.None;
			intSourceStyle = AssemblySourceStyle.Custom;
			
			strName = name;
			VersionString = version;
			RuntimeVersionString = runtimeversion;
			strCodeBase = codeBase;
			strFileName = fileName;
			intFlags = flags;
		}

		public DotNetAssemblyInfo(Assembly assembly_0)
		{
			int num = 10;
			strName = null;
			strFullName = null;
			strCodeBase = null;
			strFileName = null;
			myVersion = new Version();
			myRuntimeVersion = new Version();
			intFlags = AssemblyNameFlags.None;
			intSourceStyle = AssemblySourceStyle.Custom;
			
			strName = assembly_0.GetName().Name;
			strCodeBase = assembly_0.CodeBase;
			Uri uri = new Uri(assembly_0.CodeBase);
			if (uri.Scheme == Uri.UriSchemeFile)
			{
				strFileName = uri.LocalPath;
			}
			else
			{
				strFileName = assembly_0.Location;
			}
			strFullName = assembly_0.FullName;
			string text = assembly_0.ImageRuntimeVersion;
			if (text.StartsWith("v") || text.StartsWith("V"))
			{
				text = text.Substring(1);
			}
			RuntimeVersionString = text;
			intFlags = assembly_0.GetName().Flags;
			Version = assembly_0.GetName().Version;
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		/// <param name="name">Assembly name , can be CodeBase or short name</param>
		public DotNetAssemblyInfo(string name)
		{
			int num = 6;
			strName = null;
			strFullName = null;
			strCodeBase = null;
			strFileName = null;
			myVersion = new Version();
			myRuntimeVersion = new Version();
			intFlags = AssemblyNameFlags.None;
			intSourceStyle = AssemblySourceStyle.Custom;
			
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			if (name.IndexOf(":") > 0)
			{
				Uri uri = new Uri(name);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					strFileName = uri.LocalPath;
				}
				else
				{
					strFileName = uri.AbsoluteUri;
				}
				strName = Path.GetFileNameWithoutExtension(strFileName);
			}
			else if (name.ToLower().EndsWith(".dll") || name.ToLower().EndsWith(".exe"))
			{
				strName = Path.GetFileNameWithoutExtension(name);
				strFileName = name;
			}
			else
			{
				strName = name;
				strFileName = name + ".dll";
			}
			if (DotNetAssemblyInfoList.IsInRuntimePath(strFileName))
			{
				intSourceStyle = AssemblySourceStyle.Standard;
			}
			else
			{
				intSourceStyle = AssemblySourceStyle.ThirdPart;
			}
		}

		public static string CodeBaseToFileName(string codeBase)
		{
			int num = 15;
			if (codeBase == null)
			{
				return null;
			}
			if (codeBase.IndexOf(":") > 0)
			{
				Uri uri = new Uri(codeBase);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					return uri.LocalPath;
				}
				return uri.AbsoluteUri;
			}
			return codeBase;
		}

		object ICloneable.Clone()
		{
			DotNetAssemblyInfo dotNetAssemblyInfo = new DotNetAssemblyInfo();
			dotNetAssemblyInfo.strName = strName;
			dotNetAssemblyInfo.strFileName = strFileName;
			dotNetAssemblyInfo.strCodeBase = strCodeBase;
			dotNetAssemblyInfo.strFullName = strFullName;
			dotNetAssemblyInfo.myVersion = (Version)myVersion.Clone();
			dotNetAssemblyInfo.intSourceStyle = intSourceStyle;
			dotNetAssemblyInfo.intFlags = intFlags;
			return dotNetAssemblyInfo;
		}

		/// <summary>
		///       clone instance
		///       </summary>
		/// <returns>new instance</returns>
		public DotNetAssemblyInfo Clone()
		{
			DotNetAssemblyInfo dotNetAssemblyInfo = new DotNetAssemblyInfo();
			dotNetAssemblyInfo.strName = strName;
			dotNetAssemblyInfo.strFileName = strFileName;
			dotNetAssemblyInfo.strCodeBase = strCodeBase;
			dotNetAssemblyInfo.strFullName = strFullName;
			dotNetAssemblyInfo.myVersion = (Version)myVersion.Clone();
			dotNetAssemblyInfo.intSourceStyle = intSourceStyle;
			dotNetAssemblyInfo.intFlags = intFlags;
			return dotNetAssemblyInfo;
		}
	}
}
