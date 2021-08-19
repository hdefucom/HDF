using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       本地缓存数据控制器
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class LocalDataBufferController
	{
		private string _AppName = "DCSoftTemp";

		private bool _Enabled = true;

		private string _DataDirectory = null;

		private List<LocalDataBufferItem> _LocalItems = null;

		                                                                    /// <summary>
		                                                                    ///       应用系统名称
		                                                                    ///       </summary>
		public string AppName
		{
			get
			{
				return _AppName;
			}
			set
			{
				_AppName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象是否可用
		                                                                    ///       </summary>
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       保存缓存文件的目录
		                                                                    ///       </summary>
		public string DataDirectory
		{
			get
			{
				if (_DataDirectory == null)
				{
					_DataDirectory = Path.GetTempPath();
					_DataDirectory = Path.Combine(_DataDirectory, AppName);
					if (!Directory.Exists(_DataDirectory))
					{
						Directory.CreateDirectory(_DataDirectory);
					}
				}
				return _DataDirectory;
			}
		}

		private List<LocalDataBufferItem> LocalItems
		{
			get
			{
				int num = 8;
				if (_LocalItems == null)
				{
					string text = Path.Combine(DataDirectory, "DCLocalDataBufferItemList.xml");
					if (File.Exists(text))
					{
						try
						{
							_LocalItems = (List<LocalDataBufferItem>)XMLHelper.LoadObjectFromXMLFile(typeof(List<LocalDataBufferItem>), text);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					if (_LocalItems == null)
					{
						_LocalItems = new List<LocalDataBufferItem>();
					}
				}
				return _LocalItems;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public LocalDataBufferController(string appName)
		{
			_AppName = appName;
		}

		                                                                    /// <summary>
		                                                                    ///       从缓存文件中读取对象数据
		                                                                    ///       </summary>
		                                                                    /// <param name="name">缓存的名称</param>
		                                                                    /// <param name="objectType">对象数据类型</param>
		                                                                    /// <param name="version">最新版本号</param>
		                                                                    /// <returns>读取的数据</returns>
		public virtual object ReadFromBuffer(string name, Type objectType, int version)
		{
			int num = 4;
			if (!Enabled)
			{
				return null;
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			if (objectType == null)
			{
				throw new ArgumentNullException("objectType");
			}
			bool flag = false;
			LocalDataBufferItem localDataBufferItem = null;
			foreach (LocalDataBufferItem localItem in LocalItems)
			{
				if (localItem.Name == name)
				{
					if (!File.Exists(localItem.FileName))
					{
						LocalItems.Remove(localItem);
						flag = true;
					}
					else
					{
						if (localItem.TimeoutDays > 0)
						{
							DateTime t = File.GetLastWriteTime(localItem.FileName).AddDays(localItem.TimeoutDays);
							if (t < DateTime.Now)
							{
								File.Delete(localItem.FileName);
								LocalItems.Remove(localItem);
								flag = true;
								break;
							}
						}
						if (localItem.Version != version)
						{
							File.Delete(localItem.FileName);
							LocalItems.Remove(localItem);
							flag = true;
						}
						else
						{
							localDataBufferItem = localItem;
						}
					}
					break;
				}
			}
			if (flag)
			{
				SaveLocalItems();
			}
			if (localDataBufferItem != null)
			{
				return XMLHelper.LoadObjectFromXMLFile(objectType, localDataBufferItem.FileName);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       保存对象数据到缓存区中
		                                                                    ///       </summary>
		                                                                    /// <param name="name">名称</param>
		                                                                    /// <param name="instance">对象实例</param>
		                                                                    /// <param name="version">版本号</param>
		                                                                    /// <param name="timeoutDays">超时天数</param>
		                                                                    /// <returns>操作是否成功</returns>
		public virtual bool SaveToBuffer(string name, object instance, int version, int timeoutDays)
		{
			int num = 17;
			if (!Enabled)
			{
				return false;
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			if (instance == null)
			{
				return false;
			}
			LocalDataBufferItem localDataBufferItem = null;
			foreach (LocalDataBufferItem localItem in LocalItems)
			{
				if (localItem.Name == name)
				{
					localDataBufferItem = localItem;
					break;
				}
			}
			if (localDataBufferItem == null)
			{
				localDataBufferItem = new LocalDataBufferItem();
				LocalItems.Add(localDataBufferItem);
				localDataBufferItem.Name = name;
			}
			localDataBufferItem.Version = version;
			localDataBufferItem.TimeoutDays = timeoutDays;
			localDataBufferItem.FileName = Path.Combine(DataDirectory, "BufferItem_" + name + ".xml");
			XMLHelper.SaveObjectToXMLFile(instance, localDataBufferItem.FileName);
			SaveLocalItems();
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       清空缓存区
		                                                                    ///       </summary>
		public void ClearBuffer()
		{
			if (Enabled)
			{
				string[] files = Directory.GetFiles(DataDirectory);
				foreach (string path in files)
				{
					File.Delete(path);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       删除指定的缓冲的信息
		                                                                    ///       </summary>
		                                                                    /// <param name="name">名称</param>
		                                                                    /// <returns>操作是否修改了缓冲区</returns>
		public bool ClearBufferItem(string name)
		{
			int num = 2;
			if (!Enabled)
			{
				return false;
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			foreach (LocalDataBufferItem localItem in LocalItems)
			{
				if (localItem.Name == name && File.Exists(localItem.FileName))
				{
					File.Delete(localItem.FileName);
					LocalItems.Remove(localItem);
					SaveLocalItems();
					return true;
				}
			}
			return false;
		}

		private void SaveLocalItems()
		{
			int num = 19;
			if (_LocalItems != null)
			{
				string fileName = Path.Combine(DataDirectory, "DCLocalDataBufferItemList.xml");
				XMLHelper.SaveObjectToXMLFile(_LocalItems, fileName);
			}
		}
	}
}
