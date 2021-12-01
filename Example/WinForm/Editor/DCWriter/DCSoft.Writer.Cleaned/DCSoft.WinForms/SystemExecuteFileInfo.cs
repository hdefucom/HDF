using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	/// <summary>
	///       可执行文件信息
	///       </summary>
	[Serializable]
	public class SystemExecuteFileInfo
	{
		/// <summary>
		///       错误信息
		///       </summary>
		[XmlElement("A错误信息")]
		public string Error;

		/// <summary>
		///       文件路径名
		///       </summary>
		[XmlElement("文件路径")]
		public string FullName;

		/// <summary>
		///       文件创建时间
		///       </summary>
		[XmlElement("文件创建时间")]
		public string CreationTime;

		/// <summary>
		///       文件修改时间
		///       </summary>
		[XmlElement("文件修改时间")]
		public string LastWriteTime;

		/// <summary>
		///       最后读取时间
		///       </summary>
		[XmlElement("最后读取时间")]
		public string LastAccessTime;

		/// <summary>
		///       文件属性
		///       </summary>
		[XmlElement("文件属性")]
		public FileAttributes Attributes;

		/// <summary>
		///       文件长度
		///       </summary>
		[XmlElement("文件长度")]
		public long Length;

		/// <summary>
		///       公司名称
		///       </summary>
		[XmlElement("公司名称")]
		public string CompanyName;

		/// <summary>
		///       文件说明
		///       </summary>
		[XmlElement("文件说明")]
		public string Comments;

		/// <summary>
		///       文件版本
		///       </summary>
		[XmlElement("文件版本")]
		public string Version;

		/// <summary>
		///       发行语言
		///       </summary>
		[XmlElement("发行语言")]
		public string Language;

		/// <summary>
		///       产品名称
		///       </summary>
		[XmlElement("产品名称")]
		public string ProductName;

		/// <summary>
		///       初始化对象
		///       </summary>
		public SystemExecuteFileInfo()
		{
			Error = null;
			FullName = null;
			CreationTime = null;
			LastWriteTime = null;
			LastAccessTime = null;
			Attributes = FileAttributes.Normal;
			Length = 0L;
			CompanyName = null;
			Comments = null;
			Version = null;
			Language = null;
			ProductName = null;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public SystemExecuteFileInfo(string FileName)
		{
			int num = 3;
			Error = null;
			FullName = null;
			CreationTime = null;
			LastWriteTime = null;
			LastAccessTime = null;
			Attributes = FileAttributes.Normal;
			Length = 0L;
			CompanyName = null;
			Comments = null;
			Version = null;
			Language = null;
			ProductName = null;
			
			try
			{
				if (File.Exists(FileName))
				{
					FileInfo fileInfo = new FileInfo(FileName);
					FullName = fileInfo.FullName;
					CreationTime = fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
					LastWriteTime = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
					LastAccessTime = fileInfo.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss");
					Attributes = fileInfo.Attributes;
					Length = fileInfo.Length;
					FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(FileName);
					if (versionInfo != null)
					{
						CompanyName = versionInfo.CompanyName;
						Comments = versionInfo.Comments;
						Version = versionInfo.FileVersion;
						Language = versionInfo.Language;
						ProductName = versionInfo.ProductName;
					}
				}
				else
				{
					Error = "文件[" + FileName + "]不存在";
				}
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}
		}
	}
}
