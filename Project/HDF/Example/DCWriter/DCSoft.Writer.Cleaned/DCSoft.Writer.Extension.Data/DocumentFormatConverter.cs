#define DEBUG
using DCSoft.Writer.Dom;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       文件格式转换器
	///       </summary>
	[ComVisible(false)]
	public class DocumentFormatConverter
	{
		private volatile bool _CancelFlag = false;

		private List<GClass25> _Tasks = new List<GClass25>();

		private bool _DebugMode = true;

		private List<string> _existDirs = null;

		/// <summary>
		///       任务列表
		///       </summary>
		public List<GClass25> Tasks
		{
			get
			{
				return _Tasks;
			}
			set
			{
				_Tasks = value;
			}
		}

		/// <summary>
		///       调试模式
		///       </summary>
		public bool DebugMode
		{
			get
			{
				return _DebugMode;
			}
			set
			{
				_DebugMode = value;
			}
		}

		/// <summary>
		///       进度事件
		///       </summary>
		public event ProgressChangedEventHandler ProgressChanged = null;

		/// <summary>
		///       取消操作
		///       </summary>
		public void Cancel()
		{
			_CancelFlag = true;
		}

		/// <summary>
		///       执行任务
		///       </summary>
		/// <returns>
		/// </returns>
		public int Run()
		{
			int num = 0;
			_existDirs = new List<string>();
			foreach (GClass25 task in Tasks)
			{
				if (!task.method_8())
				{
					if (RunTask(task))
					{
						task.method_9(bool_1: true);
						num++;
					}
					if (this.ProgressChanged != null)
					{
						ProgressChangedEventArgs e = new ProgressChangedEventArgs(num, task);
						this.ProgressChanged(this, e);
					}
					if (_CancelFlag)
					{
						break;
					}
				}
			}
			_existDirs = null;
			return num;
		}

		public virtual bool RunTask(GClass25 task)
		{
			int num = 14;
			if (task == null)
			{
				return false;
			}
			if (!File.Exists(task.method_0()))
			{
				string text = "未找到源文件:" + task.method_0();
				if (DebugMode)
				{
					Debug.WriteLine(text);
				}
				task.method_11(text);
				return false;
			}
			if (DebugMode)
			{
				Debug.WriteLine("开始处理文件:" + task.method_0());
			}
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.Load(task.method_0(), task.method_2());
			string directoryName = Path.GetDirectoryName(task.method_4());
			if (_existDirs == null || !_existDirs.Contains(directoryName))
			{
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				if (_existDirs != null)
				{
					_existDirs.Add(directoryName);
				}
			}
			xTextDocument.Save(task.method_4(), task.method_6());
			task.method_9(bool_1: true);
			task.method_11(null);
			return true;
		}

		public static int CreateTasks(string sourceDirectory, string sourceFileNamePattern, string sourceFormat, string destDirectory, string destFormat, bool recursionSearch, List<GClass25> tasks)
		{
			int num = 15;
			if (string.IsNullOrEmpty(sourceDirectory))
			{
				sourceDirectory = Environment.CurrentDirectory;
			}
			if (!Directory.Exists(sourceDirectory))
			{
				throw new DirectoryNotFoundException(sourceDirectory);
			}
			if (string.IsNullOrEmpty(sourceFileNamePattern))
			{
				sourceFileNamePattern = "*";
			}
			ContentSerializer serializer = WriterAppHost.Default.ContentSerializers.GetSerializer(sourceFormat);
			if (serializer == null)
			{
				throw new NotSupportedException(sourceFormat);
			}
			ContentSerializer serializer2 = WriterAppHost.Default.ContentSerializers.GetSerializer(destFormat);
			if (destFormat == null)
			{
				throw new NotSupportedException(destFormat);
			}
			string fileExtension = serializer2.FileExtension;
			if (string.IsNullOrEmpty(destDirectory))
			{
				destDirectory = Environment.CurrentDirectory;
			}
			int num2 = 0;
			string[] files = Directory.GetFiles(sourceDirectory, sourceFileNamePattern);
			string[] array = files;
			foreach (string text in array)
			{
				GClass25 gClass = new GClass25();
				gClass.method_1(text);
				gClass.method_3(sourceFormat);
				gClass.method_5(Path.Combine(destDirectory, Path.GetFileNameWithoutExtension(text) + fileExtension));
				gClass.method_7(destFormat);
				tasks.Add(gClass);
				num2++;
			}
			if (recursionSearch)
			{
				string[] directories = Directory.GetDirectories(sourceDirectory, "*");
				array = directories;
				foreach (string text2 in array)
				{
					if (!(text2 == ".") && !(text2 == ".."))
					{
						num2 += CreateTasks(text2, sourceFileNamePattern, sourceFormat, Path.Combine(destDirectory, Path.GetFileName(text2)), destFormat, recursionSearch, tasks);
					}
				}
			}
			return num2;
		}

		/// <summary>
		///       转换
		///       </summary>
		/// <param name="sourceDirectory">
		/// </param>
		/// <param name="sourceFileNamePattern">
		/// </param>
		/// <param name="sourceFormat">
		/// </param>
		/// <param name="destDirectory">
		/// </param>
		/// <param name="destFormat">
		/// </param>
		/// <param name="recursionSearch">
		/// </param>
		/// <returns>
		/// </returns>
		public static int Convert(string sourceDirectory, string sourceFileNamePattern, string sourceFormat, string destDirectory, string destFormat, bool recursionSearch)
		{
			DocumentFormatConverter documentFormatConverter = new DocumentFormatConverter();
			CreateTasks(sourceDirectory, sourceFileNamePattern, sourceFormat, destDirectory, destFormat, recursionSearch, documentFormatConverter.Tasks);
			if (documentFormatConverter.Tasks.Count > 0)
			{
				return documentFormatConverter.Run();
			}
			return 0;
		}
	}
}
