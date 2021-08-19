#define DEBUG
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       数据相关的编辑器命令模块
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Data")]
	internal class WriterCommandModuleData : WriterCommandModule
	{
		/// <summary>
		///       重置表单数据
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ResetFormValue")]
		protected void ResetFormValue(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.Document.ResetFormValue())
			{
				e.Document.Modified = true;
				e.Document.UndoList.Clear();
				e.EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: true);
				e.Document.OnDocumentContentChanged();
				e.Document.OnSelectionChanged();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       清空缓存的数据
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearBuffer")]
		protected void ClearBuffer(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Document != null)
			{
				foreach (XTextInputFieldElement item in e.Document.GetElementsByType(typeof(XTextInputFieldElement)))
				{
					if (item.FieldSettings != null && item.FieldSettings.ListSource != null)
					{
						item.FieldSettings.ListSource.RuntimeItems = null;
					}
				}
				KBLibrary kBLibrary = (KBLibrary)e.Host.Services.GetService(typeof(KBLibrary));
				if (kBLibrary != null)
				{
					foreach (KBEntry allKBEntry in kBLibrary.AllKBEntries)
					{
						allKBEntry.RuntimeItems = null;
					}
				}
			}
		}

		/// <summary>
		///       编辑文档参数
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("EditDocumentParameters", ReturnValueType = typeof(bool))]
		protected void EditDocumentParameters(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.ShowUI)
				{
					using (dlgDocumentParameters dlgDocumentParameters = new dlgDocumentParameters())
					{
						dlgDocumentParameters.InputParameters = e.Document.Parameters;
						dlgDocumentParameters.InputDocument = e.Document;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDocumentParameters, null) == DialogResult.OK)
						{
							e.Document.Parameters = dlgDocumentParameters.InputParameters;
							e.Result = true;
						}
					}
				}
			}
		}

		/// <summary>
		///       加载知识库
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("LoadKBLibrary", ReturnValueType = typeof(KBLibrary))]
		protected void LoadKBLibrary(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Host != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerLoadKBLibrary(e, filter: true);
			}
		}

		/// <summary>
		///       加载知识库而且不进行过滤
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("LoadKBLibraryWithoutFilter", ReturnValueType = typeof(KBLibrary))]
		protected void LoadKBLibraryWithoutFilter(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Host != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerLoadKBLibrary(e, filter: false);
			}
		}

		/// <summary>
		///       加载知识库
		///       </summary>
		/// <param name="args">参数</param>
		/// <param name="filter">是否过滤</param>
		private void InnerLoadKBLibrary(WriterCommandEventArgs args, bool filter)
		{
			int num = 6;
			args.Result = null;
			if (args.Parameter is KBLibrary)
			{
				KBLibrary kBLibrary = (KBLibrary)args.Parameter;
				if (filter)
				{
					kBLibrary.Filter(args.Host);
				}
				args.Host.Services.AddService(typeof(KBLibrary), kBLibrary);
				if (kBLibrary != null)
				{
					kBLibrary.UseLanguage2 = args.EditorControl.DocumentOptions.ViewOptions.UseLanguage2;
				}
				args.Result = true;
				return;
			}
			KBLibrary kBLibrary2 = (KBLibrary)args.Host.Services.GetService(typeof(KBLibrary));
			string text = null;
			if (args.Parameter is string)
			{
				text = (string)args.Parameter;
			}
			else
			{
				if (args.Parameter is Stream)
				{
					if (kBLibrary2 == null)
					{
						kBLibrary2 = new KBLibrary();
						kBLibrary2.Load((Stream)args.Parameter);
						args.Host.Services.AddService(typeof(KBLibrary), kBLibrary2);
					}
					else
					{
						kBLibrary2.Load((Stream)args.Parameter);
					}
					if (filter)
					{
						kBLibrary2.Filter(args.Host);
					}
					if (kBLibrary2 != null)
					{
						kBLibrary2.UseLanguage2 = args.EditorControl.DocumentOptions.ViewOptions.UseLanguage2;
					}
					args.Result = kBLibrary2;
					return;
				}
				if (args.Parameter is TextReader)
				{
					if (kBLibrary2 == null)
					{
						kBLibrary2 = new KBLibrary();
						kBLibrary2.Load((TextReader)args.Parameter);
						args.Host.Services.AddService(typeof(KBLibrary), kBLibrary2);
					}
					else
					{
						kBLibrary2.Load((TextReader)args.Parameter);
					}
					if (filter)
					{
						kBLibrary2.Filter(args.Host);
					}
					if (kBLibrary2 != null)
					{
						kBLibrary2.UseLanguage2 = args.EditorControl.DocumentOptions.ViewOptions.UseLanguage2;
					}
					args.Result = kBLibrary2;
				}
			}
			if (args.ShowUI)
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.Filter = WriterStrings.XMLFilter;
					openFileDialog.CheckFileExists = true;
					openFileDialog.FileName = text;
					if (openFileDialog.ShowDialog(args.EditorControl) != DialogResult.OK)
					{
						return;
					}
					text = openFileDialog.FileName;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			WriterReadFileContentEventArgs args2 = new WriterReadFileContentEventArgs(args.EditorControl, args.Document, null, text, "kblibrary");
			byte[] array = WriterControl.ReadFileContent(args.EditorControl, args2);
			if (array == null || array.Length <= 0)
			{
				return;
			}
			MemoryStream memoryStream = new MemoryStream(array);
			if (kBLibrary2 == null)
			{
				kBLibrary2 = new KBLibrary();
				kBLibrary2.Load(memoryStream);
				if (string.IsNullOrEmpty(kBLibrary2.BaseURL))
				{
					kBLibrary2.RuntimeBaseURL = GClass334.smethod_1(text);
				}
				args.Host.Services.AddService(typeof(KBLibrary), kBLibrary2);
			}
			else
			{
				kBLibrary2.Load(memoryStream);
				if (string.IsNullOrEmpty(kBLibrary2.BaseURL))
				{
					kBLibrary2.BaseURL = GClass334.smethod_1(text);
				}
			}
			if (filter)
			{
				kBLibrary2.Filter(args.Host);
			}
			if (kBLibrary2 != null)
			{
				kBLibrary2.UseLanguage2 = args.EditorControl.DocumentOptions.ViewOptions.UseLanguage2;
			}
			args.Result = kBLibrary2;
			if (args.Host.DebugMode)
			{
				Debug.Write(string.Format(WriterStrings.LoadComplete_Size, WriterUtils.smethod_44((int)memoryStream.Length)));
			}
		}

		/// <summary>
		///       保存知识库
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SaveKBLibrary", ReturnValueType = typeof(bool))]
		protected void SaveKBLibrary(object sender, WriterCommandEventArgs e)
		{
			int num = 12;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Host != null && e.Host.Services.GetService(typeof(KBLibrary)) != null)
				{
					e.Enabled = true;
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				KBLibrary kBLibrary = (KBLibrary)e.Host.Services.GetService(typeof(KBLibrary));
				string text = null;
				if (e.Parameter is string)
				{
					text = (string)e.Parameter;
				}
				else
				{
					if (e.Parameter is Stream)
					{
						kBLibrary.Save((Stream)e.Parameter);
						e.Result = true;
						return;
					}
					if (e.Parameter is TextWriter)
					{
						kBLibrary.Save((TextWriter)e.Parameter);
						e.Result = true;
						return;
					}
				}
				if (e.ShowUI)
				{
					string string_ = null;
					string text2 = WriterControl.smethod_1(e.EditorControl, e.Host, text, ref string_, null);
					if (text2 == null)
					{
						return;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					if (e.Host.DebugMode)
					{
						Debug.WriteLine(string.Format(WriterStrings.Saving_FileName, text));
					}
					MemoryStream memoryStream = new MemoryStream();
					kBLibrary.Save(memoryStream);
					byte[] content = memoryStream.ToArray();
					memoryStream.Close();
					WriterSaveFileContentEventArgs args = new WriterSaveFileContentEventArgs(e.EditorControl, e.Document, null, text, "kblibrary", content);
					bool flag = WriterControl.SaveFileContent(e.EditorControl, args);
					e.Result = flag;
				}
			}
		}

		/// <summary>
		///       根据数据源更新文档视图
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("UpdateViewForDataSource", ReturnValueType = typeof(int))]
		protected void UpdateViewForDataSource(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = e.EditorControl.UpdateViewForDataSource();
			}
		}

		/// <summary>
		///       根据文视图更新数据源
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("UpdateDataSourceForView", ReturnValueType = typeof(int))]
		protected void UpdateDataSourceForView(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = e.EditorControl.UpdateDataSourceForView();
			}
		}
	}
}
