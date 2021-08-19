#define DEBUG
using Microsoft.Win32;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Script
{
	[Serializable]
	[ComVisible(false)]
	public class DotNetAssemblyInfoList : CollectionBase, ICloneable
	{
		private class AssemblyInfoComparer : IComparer
		{
			public int Compare(object object_0, object object_1)
			{
				return string.Compare(((DotNetAssemblyInfo)object_0).Name, ((DotNetAssemblyInfo)object_1).Name, ignoreCase: true);
			}
		}

		private static DotNetAssemblyInfoList myGlobalList = null;

		/// <summary>
		///       global assembly list in host system
		///       </summary>
		public static DotNetAssemblyInfoList GlobalList
		{
			get
			{
				int num = 19;
				if (myGlobalList == null)
				{
					lock (typeof(DotNetAssemblyInfoList))
					{
						DotNetAssemblyInfoList dotNetAssemblyInfoList = new DotNetAssemblyInfoList();
						ArrayList arrayList = new ArrayList();
						GetAssemblyNames("SOFTWARE\\Microsoft\\.NETFramework\\AssemblyFolders", arrayList);
						Version version = Environment.Version;
						GetAssemblyNames("SOFTWARE\\Microsoft\\.NETFramework\\v" + version.Major + "." + version.Minor + "." + version.Build + "\\AssemblyFoldersEx", arrayList);
						GetAssmeblyNamesByPath(DotNetAssemblyInfo.RuntimePath, arrayList);
						for (int i = 0; i < arrayList.Count; i++)
						{
							string text = (string)arrayList[i];
							if (!text.ToLower().EndsWith("system.enterpriseservices.wrapper.dll"))
							{
								try
								{
									string runtimeVersion = DotNetAssemblyInfo.GetRuntimeVersion(text);
									if (runtimeVersion != null && runtimeVersion.Trim().Length != 0)
									{
										runtimeVersion = runtimeVersion.Trim().ToUpper();
										if (runtimeVersion.StartsWith("V"))
										{
											runtimeVersion = runtimeVersion.Substring(1);
										}
										AssemblyName assemblyName = AssemblyName.GetAssemblyName(text);
										DotNetAssemblyInfo dotNetAssemblyInfo = new DotNetAssemblyInfo(assemblyName);
										dotNetAssemblyInfo.FileName = text;
										dotNetAssemblyInfo.RuntimeVersion = new Version(runtimeVersion);
										if (IsInRuntimePath(text))
										{
											dotNetAssemblyInfo.SourceStyle = AssemblySourceStyle.Standard;
										}
										else
										{
											dotNetAssemblyInfo.SourceStyle = AssemblySourceStyle.ThirdPart;
										}
										dotNetAssemblyInfoList.Add(dotNetAssemblyInfo);
									}
								}
								catch (BadImageFormatException)
								{
									Debug.WriteLine("Analyse " + text + " error.");
								}
								catch (Exception ex2)
								{
									Debug.WriteLine(text + ":" + ex2.Message);
								}
							}
						}
						dotNetAssemblyInfoList.InnerList.Sort(new AssemblyInfoComparer());
						myGlobalList = dotNetAssemblyInfoList;
					}
				}
				return myGlobalList;
			}
		}

		/// <summary>
		///       get assembly information specify index
		///       </summary>
		/// <param name="index">index</param>
		/// <returns>object</returns>
		public DotNetAssemblyInfo this[int index] => (DotNetAssemblyInfo)base.List[index];

		/// <summary>
		///       get assembly information specify name
		///       </summary>
		/// <param name="name">assembly name</param>
		/// <returns>object</returns>
		public DotNetAssemblyInfo this[string name]
		{
			get
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DotNetAssemblyInfo dotNetAssemblyInfo = (DotNetAssemblyInfo)enumerator.Current;
						if (string.Compare(dotNetAssemblyInfo.Name, name, ignoreCase: true) == 0)
						{
							return dotNetAssemblyInfo;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return null;
			}
		}

		public string[] FileNames
		{
			get
			{
				string[] array = new string[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = ((DotNetAssemblyInfo)base.List[i]).FileName;
				}
				return array;
			}
		}

		internal static void Test()
		{
			int num = 19;
			foreach (DotNetAssemblyInfo global in GlobalList)
			{
				Console.WriteLine(string.Concat(global.Name, " ", global.Version, " ", global.FileName));
			}
			Console.ReadLine();
		}

		/// <summary>
		///       refrsh global assembly list
		///       </summary>
		public static void RefreshGlobalList()
		{
			myGlobalList = null;
		}

		public static bool IsInRuntimePath(string fileName)
		{
			if (Path.IsPathRooted(fileName))
			{
				fileName = fileName.Trim().ToLower();
				string value = DotNetAssemblyInfo.RuntimePath.ToLower();
				return fileName.StartsWith(value);
			}
			return false;
		}

		private static void GetAssemblyNames(string keyPath, ArrayList myFiles)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath);
			if (registryKey != null)
			{
				string[] subKeyNames = registryKey.GetSubKeyNames();
				foreach (string name in subKeyNames)
				{
					RegistryKey registryKey2 = registryKey.OpenSubKey(name);
					string path = Convert.ToString(registryKey2.GetValue(null));
					GetAssmeblyNamesByPath(path, myFiles);
					registryKey2.Close();
				}
				registryKey.Close();
			}
		}

		private static void GetAssmeblyNamesByPath(string path, ArrayList myFiles)
		{
			int num = 13;
			if (!Directory.Exists(path))
			{
				return;
			}
			string[] files = Directory.GetFiles(path, "*.dll");
			foreach (string text in files)
			{
				bool flag = false;
				foreach (string myFile in myFiles)
				{
					if (string.Compare(myFile, text, ignoreCase: true) == 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					myFiles.Add(text);
				}
			}
		}

		/// <summary>
		///       add new item
		///       </summary>
		/// <param name="info">new item</param>
		/// <returns>index of new item in this list</returns>
		public int Add(DotNetAssemblyInfo info)
		{
			int num = IndexOf(info.Name);
			if (num >= 0)
			{
				base.List.RemoveAt(num);
			}
			return base.List.Add(info);
		}

		public int AddStandard(string name)
		{
			int num = 1;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			DotNetAssemblyInfo dotNetAssemblyInfo = new DotNetAssemblyInfo();
			dotNetAssemblyInfo.Name = name;
			dotNetAssemblyInfo.SourceStyle = AssemblySourceStyle.Standard;
			if (!name.ToLower().EndsWith(".dll"))
			{
				name += ".dll";
			}
			dotNetAssemblyInfo.FileName = Path.Combine(DotNetAssemblyInfo.RuntimePath, name);
			return Add(dotNetAssemblyInfo);
		}

		public int AddByName(string name)
		{
			int num = 12;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			DotNetAssemblyInfo dotNetAssemblyInfo = new DotNetAssemblyInfo(name);
			if (myGlobalList != null)
			{
				DotNetAssemblyInfo dotNetAssemblyInfo2 = GlobalList[dotNetAssemblyInfo.Name];
				if (dotNetAssemblyInfo2 != null)
				{
					dotNetAssemblyInfo = dotNetAssemblyInfo2;
				}
			}
			return Add(dotNetAssemblyInfo);
		}

		public int AddByType(Type type_0)
		{
			int num = 16;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			DotNetAssemblyInfo info = new DotNetAssemblyInfo(type_0.Assembly);
			int result = Add(info);
			Type[] interfaces = type_0.GetInterfaces();
			if (interfaces != null && interfaces.Length > 0)
			{
				Type[] array = interfaces;
				foreach (Type type in array)
				{
					DotNetAssemblyInfo info2 = new DotNetAssemblyInfo(type.Assembly);
					Add(info2);
				}
			}
			for (Type baseType = type_0.BaseType; baseType != null; baseType = baseType.BaseType)
			{
				DotNetAssemblyInfo info2 = new DotNetAssemblyInfo(baseType.Assembly);
				Add(info2);
			}
			return result;
		}

		/// <summary>
		///       delete item
		///       </summary>
		/// <param name="info">item</param>
		public void Remove(DotNetAssemblyInfo info)
		{
			base.List.Remove(info);
		}

		public int IndexOf(string name)
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					DotNetAssemblyInfo dotNetAssemblyInfo = (DotNetAssemblyInfo)base.List[num];
					if (string.Compare(dotNetAssemblyInfo.Name, name, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		object ICloneable.Clone()
		{
			DotNetAssemblyInfoList dotNetAssemblyInfoList = new DotNetAssemblyInfoList();
			dotNetAssemblyInfoList.InnerList.AddRange(this);
			return dotNetAssemblyInfoList;
		}

		/// <summary>
		///       clone instance
		///       </summary>
		/// <returns>instance</returns>
		public DotNetAssemblyInfoList Clone()
		{
			return (DotNetAssemblyInfoList)((ICloneable)this).Clone();
		}
	}
}
