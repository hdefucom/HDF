using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design
{
	/// <summary>
	///       组件类型库对象 
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class DCTypeLibrary
	{
		private static DCTypeLibrary _Instance = null;

		private string _FileName = null;

		private DCTypeDomDocument _DomInfo = new DCTypeDomDocument();

		/// <summary>
		///       唯一静态对象实例
		///       </summary>
		public static DCTypeLibrary Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new DCTypeLibrary();
				}
				return _Instance;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       内置的类型库文档对象模型
		///       </summary>
		public DCTypeDomDocument DomInfo
		{
			get
			{
				if (_DomInfo == null)
				{
					_DomInfo = new DCTypeDomDocument();
				}
				return _DomInfo;
			}
			set
			{
				_DomInfo = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCTypeLibrary()
		{
			FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DCComponentTypeLibrary.dat");
		}

		public bool Load()
		{
			if (File.Exists(FileName))
			{
				try
				{
					using (FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
					{
						DCTypeDomDocument dCTypeDomDocument = DCTypeDomDocument.LoadBinary(stream);
						if (dCTypeDomDocument != null)
						{
							DomInfo = dCTypeDomDocument;
							DomInfo.Sort();
							return true;
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}

		public bool Save()
		{
			using (FileStream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write))
			{
				DomInfo.SaveBinary(stream);
			}
			return true;
		}

		public void LoadFromCurrentDomain(bool includeStdAssembly)
		{
			int num = 7;
			string directoryName = Path.GetDirectoryName(typeof(string).Assembly.Location);
			DomInfo.Assemblies.Clear();
			string tempPath = Path.GetTempPath();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				string location = assembly.Location;
				if (!includeStdAssembly)
				{
					if (string.IsNullOrEmpty(location))
					{
						continue;
					}
					string directoryName2 = Path.GetDirectoryName(location);
					if (string.Compare(directoryName2, directoryName, ignoreCase: true) == 0)
					{
						continue;
					}
					string fileName = Path.GetFileName(location);
					if (fileName.StartsWith("System.", StringComparison.CurrentCultureIgnoreCase))
					{
						fileName = Path.Combine(directoryName, fileName);
						if (File.Exists(fileName))
						{
							continue;
						}
					}
				}
				if (string.IsNullOrEmpty(location) || (!location.StartsWith(tempPath, StringComparison.CurrentCultureIgnoreCase) && File.Exists(location)))
				{
					DomInfo.Load(assembly);
				}
			}
			DomInfo.Sort();
		}

		/// <summary>
		///       显示一个对话框来管理类型库
		///       </summary>
		/// <param name="parent">
		/// </param>
		/// <returns>
		/// </returns>
		public bool ShowDialog(IWin32Window parent)
		{
			using (dlgComponentTypeLibrary dlgComponentTypeLibrary = new dlgComponentTypeLibrary())
			{
				dlgComponentTypeLibrary.ComponentDomInfo = DomInfo;
				if (dlgComponentTypeLibrary.ShowDialog(parent) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}
	}
}
