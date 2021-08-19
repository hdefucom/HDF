using DCSoftDotfuscate;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       最近打开的文件名列表
	///       </summary>
	public class RecentFileNameList : GClass0
	{
		/// <summary>
		///       从默认文件中加载对象列表
		///       </summary>
		public void Load()
		{
			Load(Path.Combine(Application.StartupPath, "recent.txt"));
		}

		/// <summary>
		///       向默认文件中保存对象列表
		///       </summary>
		public void Save()
		{
			Save(Path.Combine(Application.StartupPath, "recent.txt"));
		}

		/// <summary>
		///       从指定的文本文件中加载对象列表
		///       </summary>
		/// <param name="strFileName">文件名</param>
		public void Load(string strFileName)
		{
			if (File.Exists(strFileName))
			{
				using (StreamReader streamReader = new StreamReader(strFileName, Encoding.GetEncoding(936)))
				{
					for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
					{
						text = text.Trim();
						if (text.Length > 0 && File.Exists(text))
						{
							method_19(text);
						}
					}
					streamReader.Close();
				}
			}
		}

		/// <summary>
		///       保存对象数据到指定文件中
		///       </summary>
		/// <param name="strFileName">文件名</param>
		public void Save(string strFileName)
		{
			int num = 0;
			while (num < 3)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter(strFileName, append: false, Encoding.GetEncoding(936)))
					{
						IEnumerator enumerator = GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								string value = (string)enumerator.Current;
								streamWriter.WriteLine(value);
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
						streamWriter.Close();
					}
					return;
				}
				catch
				{
					Thread.Sleep(1000);
					num++;
				}
			}
		}
	}
}
