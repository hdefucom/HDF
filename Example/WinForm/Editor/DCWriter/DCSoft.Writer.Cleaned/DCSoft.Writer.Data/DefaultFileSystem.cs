using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       默认使用的文件系统操作对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DocumentComment]
	public class DefaultFileSystem : IFileSystem
	{
		private string string_0 = null;

		private string string_1 = null;

		/// <summary>
		///       打开文件使用的文件名过滤字符串
		///       </summary>
		public string OpenFileFilter
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       保存时使用的文件名过滤条件
		///       </summary>
		public string SaveFileFilter
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       读取文件内容
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>读取的数据</returns>
		public virtual byte[] Read(VFileSystemEventArgs args)
		{
			int num = 8;
			if (string.IsNullOrEmpty(args.FileName))
			{
				throw new ArgumentNullException("fileName");
			}
			_ = (WriterDebugger)args.Services.GetService(typeof(WriterDebugger));
			UrlStream urlStream = UrlStream.smethod_0(args.FileName);
			if (urlStream != null)
			{
				using (urlStream)
				{
					return urlStream.method_0();
				}
			}
			return null;
		}

		/// <summary>
		///       向文件写数据
		///       </summary>
		/// <param name="args">参数</param>
		/// <param name="content">要写入的数据</param>
		/// <returns>操作是否成功</returns>
		public virtual bool Write(VFileSystemEventArgs args, byte[] content)
		{
			int num = 7;
			if (string.IsNullOrEmpty(args.FileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (content == null)
			{
				return false;
			}
			UrlStream urlStream = UrlStream.smethod_1(args.FileName);
			if (urlStream != null)
			{
				using (urlStream)
				{
					urlStream.Write(content, 0, content.Length);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       获得文件信息
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>获得的文件信息</returns>
		public virtual VFileInfo GetFileInfo(VFileSystemEventArgs args)
		{
			int num = 11;
			if (string.IsNullOrEmpty(args.FileName))
			{
				return null;
			}
			if (args.ParentWindow is WriterControl)
			{
				WriterControl writerControl = (WriterControl)args.ParentWindow;
				if (writerControl.HasEventReadSaveFileContent)
				{
					VFileInfo vFileInfo = new VFileInfo();
					vFileInfo.Format = args.FileFormat;
					vFileInfo.FullPath = args.FileName;
					vFileInfo.Exists = true;
					return vFileInfo;
				}
			}
			string text = args.FileName;
			VFileInfo vFileInfo2 = new VFileInfo();
			try
			{
				if (text.IndexOf(":") < 0)
				{
					text = Path.Combine(Environment.CurrentDirectory, text);
					vFileInfo2 = new VFileInfo(new FileInfo(text));
					vFileInfo2.Format = args.AppHost.ContentSerializers.GetFormatNameByFileExtension(text);
				}
				else
				{
					Uri uri = new Uri(text);
					if (uri.Scheme == Uri.UriSchemeFile)
					{
						vFileInfo2 = new VFileInfo(new FileInfo(uri.LocalPath));
						vFileInfo2.Format = args.AppHost.ContentSerializers.GetFormatNameByFileExtension(uri.LocalPath);
					}
					else
					{
						vFileInfo2.Exists = true;
						vFileInfo2.Format = args.AppHost.ContentSerializers.DefaultSerializer.Name;
						vFileInfo2.Name = text;
						vFileInfo2.FullPath = text;
						vFileInfo2.BasePath = GClass334.smethod_1(text);
					}
				}
			}
			catch
			{
				vFileInfo2.Exists = false;
				vFileInfo2.Name = text;
				vFileInfo2.FullPath = text;
			}
			return vFileInfo2;
		}

		/// <summary>
		///       为读取文件而显示浏览文件对话框
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>获得的文件信息</returns>
		public VFileInfo BrowseForRead(VFileSystemEventArgs args)
		{
			int num = 1;
			Dictionary<int, string> dictionary = null;
			string text = OpenFileFilter;
			int filterIndex = 1;
			if (string.IsNullOrEmpty(text))
			{
				dictionary = new Dictionary<int, string>();
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = 0;
				foreach (ContentSerializer contentSerializer in args.AppHost.ContentSerializers)
				{
					if ((contentSerializer.Flags & GEnum14.flag_1) == GEnum14.flag_1)
					{
						dictionary[num2] = contentSerializer.Name;
						if (args.FileFormat != null && string.Compare(args.FileFormat, contentSerializer.Name, ignoreCase: true) == 0)
						{
							filterIndex = num2 + 1;
						}
						num2++;
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(contentSerializer.FileFilter);
					}
				}
				if (dictionary.Count == 0)
				{
					return null;
				}
				text = stringBuilder.ToString();
			}
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (!string.IsNullOrEmpty(args.FileName))
				{
					openFileDialog.FileName = args.FileName;
				}
				openFileDialog.Title = WriterStringsCore.OpenLocalFile;
				if (args.ParentWindow is WriterControl)
				{
					openFileDialog.Title = ((WriterControl)args.ParentWindow).DialogTitlePrefix + openFileDialog.Title;
				}
				openFileDialog.Filter = text;
				openFileDialog.CheckFileExists = true;
				openFileDialog.FilterIndex = filterIndex;
				if (openFileDialog.ShowDialog(args.ParentWindow) == DialogResult.OK)
				{
					VFileInfo vFileInfo = new VFileInfo(new FileInfo(openFileDialog.FileName));
					if (dictionary != null && openFileDialog.FilterIndex >= 1)
					{
						vFileInfo.Format = dictionary[openFileDialog.FilterIndex - 1];
					}
					if (string.IsNullOrEmpty(vFileInfo.Format))
					{
						vFileInfo.Format = args.AppHost.ContentSerializers.GetFormatNameByFileExtension(vFileInfo.FullPath);
					}
					args.FileName = openFileDialog.FileName;
					args.FileFormat = vFileInfo.Format;
					return vFileInfo;
				}
			}
			return null;
		}

		/// <summary>
		///       为保存文件而显示浏览对话框
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		public VFileInfo BrowseForWrite(VFileSystemEventArgs args)
		{
			int num = 18;
			Dictionary<int, string> dictionary = null;
			string text = SaveFileFilter;
			int filterIndex = 1;
			if (string.IsNullOrEmpty(text))
			{
				dictionary = new Dictionary<int, string>();
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = 0;
				foreach (ContentSerializer contentSerializer in args.AppHost.ContentSerializers)
				{
					if ((contentSerializer.Flags & GEnum14.flag_2) == GEnum14.flag_2)
					{
						dictionary[num2] = contentSerializer.Name;
						if (args.FileFormat != null && string.Compare(args.FileFormat, contentSerializer.Name, ignoreCase: true) == 0)
						{
							filterIndex = num2 + 1;
						}
						num2++;
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append(contentSerializer.FileFilter);
					}
				}
				if (dictionary.Count == 0)
				{
					return null;
				}
				text = stringBuilder.ToString();
			}
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				if (!string.IsNullOrEmpty(args.FileName))
				{
					saveFileDialog.FileName = args.FileName;
				}
				saveFileDialog.Title = WriterStringsCore.SaveLocalFile;
				if (args.ParentWindow is WriterControl)
				{
					saveFileDialog.Title = ((WriterControl)args.ParentWindow).DialogTitlePrefix + saveFileDialog.Title;
				}
				saveFileDialog.Filter = text;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.FilterIndex = filterIndex;
				if (saveFileDialog.ShowDialog(args.ParentWindow) == DialogResult.OK)
				{
					VFileInfo vFileInfo = new VFileInfo(new FileInfo(saveFileDialog.FileName));
					if (dictionary != null && saveFileDialog.FilterIndex >= 1)
					{
						vFileInfo.Format = dictionary[saveFileDialog.FilterIndex - 1];
					}
					if (string.IsNullOrEmpty(vFileInfo.Format))
					{
						vFileInfo.Format = args.AppHost.ContentSerializers.GetFormatNameByFileExtension(vFileInfo.FullPath);
					}
					args.FileName = saveFileDialog.FileName;
					args.FileFormat = vFileInfo.Format;
					return vFileInfo;
				}
			}
			return null;
		}
	}
}
