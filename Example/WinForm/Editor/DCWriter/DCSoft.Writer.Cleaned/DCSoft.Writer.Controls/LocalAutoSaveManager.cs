using DCSoft.Common;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       基于本地文件系统的自动保存管理器
	///       </summary>
	
	
	[ComVisible(false)]
	public class LocalAutoSaveManager : IAutoSaveManager
	{
		private WriterControl writerControl_0;

		private static MD5CryptoServiceProvider md5CryptoServiceProvider_0 = new MD5CryptoServiceProvider();

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		public LocalAutoSaveManager(WriterControl writerControl_1)
		{
			int num = 11;
			writerControl_0 = null;
			
			if (writerControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			writerControl_0 = writerControl_1;
		}

		/// <summary>
		///       判断是否存在自动保存的文件
		///       </summary>
		/// <param name="fileID">文件编号</param>
		/// <param name="confirm">是否让用户确认操作</param>
		/// <returns>是否存在自动保存的文件</returns>
		public bool Exists(string fileID, bool confirm)
		{
			int num = 0;
			if (fileID == null || fileID.Length == 0)
			{
				return false;
			}
			string text = method_0(fileID);
			if (text == null)
			{
				return false;
			}
			if (File.Exists(text))
			{
				if (confirm)
				{
					string string_ = string.Format(arg0: File.GetCreationTime(text).ToString("yyyy-MM-dd HH:mm:ss"), format: WriterStrings.ConfirmAutoSave_Time_FileName, arg1: fileID);
					if (writerControl_0.AppHost.UITools.Confirm(writerControl_0, string_))
					{
						return true;
					}
					File.Delete(text);
					return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       读取自动保存的文件内容
		///       </summary>
		/// <param name="fileID">
		/// </param>
		/// <returns>
		/// </returns>
		public byte[] ReadContent(string fileID)
		{
			if (fileID == null || fileID.Length == 0)
			{
				return null;
			}
			string text = method_0(fileID);
			if (text == null)
			{
				return null;
			}
			if (File.Exists(text))
			{
				return File.ReadAllBytes(text);
			}
			return null;
		}

		/// <summary>
		///       为自动保存而保存文件内容到临时文件
		///       </summary>
		/// <param name="fileID">
		/// </param>
		/// <param name="content">
		/// </param>
		/// <returns>
		/// </returns>
		public bool SaveContent(string fileID, byte[] content)
		{
			if (fileID == null || fileID.Length == 0)
			{
				return false;
			}
			string text = method_0(fileID);
			if (text == null)
			{
				return false;
			}
			File.WriteAllBytes(text, content);
			return true;
		}

		/// <summary>
		///       删除临时保存的文件内容
		///       </summary>
		/// <param name="fileID">
		/// </param>
		public void Delete(string fileID)
		{
			if (fileID != null && fileID.Length > 0)
			{
				string text = method_0(fileID);
				if (text != null && File.Exists(text))
				{
					File.Delete(text);
				}
			}
		}

		private string method_0(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			string localAutoSaveWorkDirectory = writerControl_0.DocumentOptions.BehaviorOptions.LocalAutoSaveWorkDirectory;
			if (string.IsNullOrEmpty(localAutoSaveWorkDirectory))
			{
				return null;
			}
			if (!Directory.Exists(localAutoSaveWorkDirectory))
			{
				Directory.CreateDirectory(localAutoSaveWorkDirectory);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			bytes = md5CryptoServiceProvider_0.ComputeHash(bytes);
			string path = StringConvertHelper.ToHexString(bytes, 0, 0);
			return Path.Combine(localAutoSaveWorkDirectory, path);
		}
	}
}
