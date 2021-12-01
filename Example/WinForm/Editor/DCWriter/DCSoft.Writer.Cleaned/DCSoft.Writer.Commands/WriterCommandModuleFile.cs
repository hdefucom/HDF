using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Printing;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文件功能模块
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("File")]
	internal class WriterCommandModuleFile : WriterCommandModule
	{
		/// <summary>
		///       为调试而保存文件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DebugSaveFile")]
		protected void DebugSaveFile(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = WriterStrings.XMLFilter;
					saveFileDialog.CheckPathExists = true;
					saveFileDialog.OverwritePrompt = true;
					if (saveFileDialog.ShowDialog(e.EditorControl) == DialogResult.OK)
					{
						e.Document.ControlOptionsForDebug = new WriterControlOptions();
						e.Document.ControlOptionsForDebug.ReadFromControl(e.EditorControl);
						e.Document.Save(saveFileDialog.FileName, null);
						e.Document.ControlOptionsForDebug = null;
					}
				}
			}
		}

		/// <summary>
		///       为调试而加载文件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DebugLoadFile")]
		protected void DebugLoadFile(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.Filter = WriterStrings.XMLFilter;
					openFileDialog.CheckFileExists = true;
					if (openFileDialog.ShowDialog(e.EditorControl) == DialogResult.OK)
					{
						e.Document.Load(openFileDialog.FileName, null);
						if (e.Document.ControlOptionsForDebug != null)
						{
							e.Document.ControlOptionsForDebug.WriteToControl(e.EditorControl);
						}
						e.EditorControl.RefreshDocument();
					}
				}
			}
		}

		/// <summary>
		///       设置编辑器使用的默认打印机名称
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SetDefaultPrinterName")]
		protected void SetDefaultPrinterName(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				string text = e.Parameter as string;
				if (e.ShowUI)
				{
					using (dlgListBox dlgListBox = new dlgListBox())
					{
						dlgListBox.Text = WriterStrings.SelectDefaultPrinterName;
						foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
						{
							dlgListBox.ListItems.Add(installedPrinter);
						}
						dlgListBox.SelectedText = text;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgListBox, null) != DialogResult.OK)
						{
							return;
						}
						text = dlgListBox.SelectedText;
					}
				}
				WriterControl.GlobalDefaultPrinterName = text;
				e.Result = text;
			}
		}

		/// <summary>
		///       打开指定URL地址的文档,默认以HTML格式打开文件。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileOpenUrl")]
		protected void FileOpenUrl(object sender, WriterCommandEventArgs e)
		{
			int num = 13;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				string text = Convert.ToString(e.Parameter);
				string text2 = "html";
				if (e.ShowUI)
				{
					using (dlgInputUrl dlgInputUrl = new dlgInputUrl())
					{
						if (e.EditorControl != null)
						{
							dlgInputUrl.Text = e.EditorControl.DialogTitlePrefix + dlgInputUrl.Text;
						}
						dlgInputUrl.AppHost = e.EditorControl.AppHost;
						dlgInputUrl.InputURL = text;
						dlgInputUrl.FileFormat = text2;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInputUrl, null) != DialogResult.OK)
						{
							return;
						}
						text = dlgInputUrl.InputURL;
						text2 = dlgInputUrl.FileFormat;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					text = text.Trim();
					GClass334.smethod_1(text);
					e.EditorControl.LoadDocument(text, text2);
					e.Document.FileName = text;
					e.Document.Modified = false;
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
					e.Result = true;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       重新加载文件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileReload", ImageResource = "DCSoft.Writer.Commands.Images.CommandFileOpen.bmp")]
		protected void FileReload(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				string fileName = e.Document.FileName;
				if (File.Exists(fileName))
				{
					e.EditorControl.LoadDocumentFromFile(fileName, e.Document.FileFormat);
				}
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileQueryExit")]
		protected void FileQueryExit(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = true;
				if (e.Document.Modified)
				{
					e.Result = QuerySave(e);
				}
			}
		}

		/// <summary>
		///       打开文件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileOpen", ImageResource = "DCSoft.Writer.Commands.Images.CommandFileOpen.bmp")]
		protected void FileOpen(object sender, WriterCommandEventArgs e)
		{
			InnerFileOpen(sender, e, oldXmlFormat: false, forString: false);
		}

		/// <summary>
		///       打开文件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileOpenString", ImageResource = "DCSoft.Writer.Commands.Images.CommandFileOpen.bmp")]
		protected void FileOpenString(object sender, WriterCommandEventArgs e)
		{
			InnerFileOpen(sender, e, oldXmlFormat: false, forString: true);
		}

		private void InnerFileOpen(object sender, WriterCommandEventArgs args, bool oldXmlFormat, bool forString)
		{
			int num = 3;
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				args.Enabled = (args.Document != null && args.EditorControl != null);
			}
			if (args.Mode != WriterCommandEventMode.Invoke)
			{
				return;
			}
			args.Result = false;
			FileOpenCommandParameter fileOpenCommandParameter = args.Parameter as FileOpenCommandParameter;
			if (fileOpenCommandParameter == null)
			{
				fileOpenCommandParameter = new FileOpenCommandParameter();
				fileOpenCommandParameter.FileSystemName = "document";
				if (args.Parameter is Stream)
				{
					fileOpenCommandParameter.InputStream = (Stream)args.Parameter;
				}
				else if (args.Parameter is TextReader)
				{
					fileOpenCommandParameter.InputReader = (TextReader)args.Parameter;
				}
				else if (args.Parameter is VFileInfo)
				{
					VFileInfo vFileInfo = (VFileInfo)args.Parameter;
					fileOpenCommandParameter.FileName = vFileInfo.FullPath;
					fileOpenCommandParameter.Format = vFileInfo.Format;
				}
				else if (args.Parameter is string)
				{
					string text = (string)args.Parameter;
					if (forString)
					{
						fileOpenCommandParameter.Format = "xml";
						text = text.Trim();
						if (string.IsNullOrEmpty(text))
						{
							return;
						}
						fileOpenCommandParameter.InputReader = new StringReader(text);
					}
					else if (!string.IsNullOrEmpty(text))
					{
						if (text.StartsWith("rawxml:"))
						{
							text = text.Substring(7);
							fileOpenCommandParameter.Format = "xml";
							fileOpenCommandParameter.InputReader = new StringReader(text);
						}
						fileOpenCommandParameter.FileName = text;
					}
				}
			}
			args.Result = false;
			if (args.ShowUI && args.Document.Modified && !QuerySave(args))
			{
				return;
			}
			ContentSerializer defaultSerializer = args.Host.ContentSerializers.DefaultSerializer;
			bool flag = (defaultSerializer.Flags & GEnum14.flag_3) == GEnum14.flag_3;
			bool flag2 = (defaultSerializer.Flags & GEnum14.flag_1) == GEnum14.flag_1;
			if (!flag && !flag2)
			{
				fileOpenCommandParameter.Message = string.Format(WriterStrings.NotSupportRead_Format, defaultSerializer.Name);
				ShowErrorMessage(args, fileOpenCommandParameter.Message);
				return;
			}
			if (fileOpenCommandParameter.InputStream != null && !flag2)
			{
				fileOpenCommandParameter.Message = string.Format(WriterStrings.NotSupportRead_Format, defaultSerializer.Name);
				ShowErrorMessage(args, fileOpenCommandParameter.Message);
				return;
			}
			if (fileOpenCommandParameter.InputReader != null && !flag)
			{
				fileOpenCommandParameter.Message = string.Format(WriterStrings.NotSupportReadText_Format, defaultSerializer.Name);
				ShowErrorMessage(args, fileOpenCommandParameter.Message);
				return;
			}
			if (fileOpenCommandParameter.InputStream != null)
			{
				if (flag2)
				{
					OpenFileSource(fileOpenCommandParameter.InputStream, fileOpenCommandParameter, args);
					return;
				}
				fileOpenCommandParameter.Message = string.Format(WriterStrings.NotSupportRead_Format, defaultSerializer.Name);
				ShowErrorMessage(args, fileOpenCommandParameter.Message);
				return;
			}
			if (fileOpenCommandParameter.InputReader != null)
			{
				if (flag)
				{
					OpenFileSource(fileOpenCommandParameter.InputReader, fileOpenCommandParameter, args);
					return;
				}
				fileOpenCommandParameter.Message = string.Format(WriterStrings.NotSupportReadText_Format, defaultSerializer.Name);
				ShowErrorMessage(args, fileOpenCommandParameter.Message);
				return;
			}
			if (args.ShowUI && args.ShowUI)
			{
				string string_ = fileOpenCommandParameter.Format;
				string text2 = WriterControl.smethod_0(args.EditorControl, args.Host, fileOpenCommandParameter.FileName, ref string_, fileOpenCommandParameter.FileSystemName);
				if (text2 == null)
				{
					fileOpenCommandParameter.Message = WriterStrings.UserCancel;
					return;
				}
				fileOpenCommandParameter.FileName = text2;
				fileOpenCommandParameter.Format = string_;
				defaultSerializer = args.Host.ContentSerializers.GetSerializer(fileOpenCommandParameter.Format);
				bool flag3 = (defaultSerializer.Flags & GEnum14.flag_3) == GEnum14.flag_3;
				bool flag4 = (defaultSerializer.Flags & GEnum14.flag_1) == GEnum14.flag_1;
				if (!flag3 && !flag4)
				{
					fileOpenCommandParameter.Message = string.Format(WriterStrings.NotSupportRead_Format, defaultSerializer.Name);
					ShowErrorMessage(args, fileOpenCommandParameter.Message);
					return;
				}
			}
			WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(args.EditorControl, args.Document, null, fileOpenCommandParameter.FileName, fileOpenCommandParameter.FileSystemName);
			writerReadFileContentEventArgs.FileFormat = fileOpenCommandParameter.Format;
			byte[] buffer = WriterControl.ReadFileContent(args.EditorControl, writerReadFileContentEventArgs);
			fileOpenCommandParameter.Format = writerReadFileContentEventArgs.FileFormat;
			MemoryStream memoryStream = new MemoryStream(buffer);
			if (flag2)
			{
				OpenFileSource(memoryStream, fileOpenCommandParameter, args);
			}
			else
			{
				Encoding encoding = fileOpenCommandParameter.ContentEncoding;
				if (encoding == null)
				{
					encoding = Encoding.Default;
				}
				StreamReader source = new StreamReader(memoryStream, encoding, detectEncodingFromByteOrderMarks: true);
				OpenFileSource(source, fileOpenCommandParameter, args);
			}
			memoryStream.Close();
			args.Document.ContentSourceType = DocumentContentSourceTypes.File;
			args.RefreshLevel = UIStateRefreshLevel.All;
		}

		/// <summary>
		///       加载文件
		///       </summary>
		/// <param name="source">文件数据来源</param>
		/// <param name="fp">命令参数</param>
		/// <param name="args">命令参数</param>
		private void OpenFileSource(object source, FileOpenCommandParameter fileOpenCommandParameter_0, WriterCommandEventArgs args)
		{
			long tickCountExt = CountDown.GetTickCountExt();
			args.Document.FileName = fileOpenCommandParameter_0.FileName;
			args.Document.FileFormat = fileOpenCommandParameter_0.Format;
			args.Document.BaseUrl = GClass334.smethod_1(fileOpenCommandParameter_0.FileName);
			try
			{
				if (source is Stream)
				{
					Stream stream = (Stream)source;
					int size = (int)stream.Length;
					args.EditorControl.InnerViewControl.method_120(fileOpenCommandParameter_0.FileName);
					args.EditorControl.LoadDocument(stream, fileOpenCommandParameter_0.Format);
					args.EditorControl.Document.FileName = fileOpenCommandParameter_0.FileName;
					if (args.Host.Debuger != null)
					{
						args.Host.Debuger.DebugLoadFileComplete(size);
					}
				}
				else
				{
					args.EditorControl.InnerViewControl.method_120(fileOpenCommandParameter_0.FileName);
					TextReader reader = (TextReader)source;
					args.EditorControl.LoadDocument(reader, fileOpenCommandParameter_0.Format);
					args.EditorControl.Document.FileName = fileOpenCommandParameter_0.FileName;
				}
				args.EditorControl.method_77(bool_12: true);
				args.Document.FileName = fileOpenCommandParameter_0.FileName;
				args.Document.FileFormat = fileOpenCommandParameter_0.Format;
				args.Document.OnSelectionChanged();
				args.Document.OnDocumentContentChanged();
			}
			finally
			{
				args.EditorControl.method_77(bool_12: false);
			}
			if (args.EditorControl != null)
			{
				args.EditorControl.vmethod_17(new WriterEventArgs(args.EditorControl, args.Document, null));
			}
			args.Result = true;
			tickCountExt = CountDown.GetTickCountExt() - tickCountExt;
			args.EditorControl.OnSelectionChanged(EventArgs.Empty);
			args.EditorControl.Modified = false;
			if (args.EditorControl.DocumentOptions.BehaviorOptions.AutoFocusWhenOpenDocument)
			{
				args.EditorControl.ComFocus();
			}
		}

		private bool SaveToFile(XTextDocument document, object destinations, FileSaveCommandParameter fileSaveCommandParameter_0, WriterCommandEventArgs args)
		{
			if (!fileSaveCommandParameter_0.BackgroundMode)
			{
				if (!string.IsNullOrEmpty(fileSaveCommandParameter_0.FileName))
				{
					document.FileName = fileSaveCommandParameter_0.FileName;
					document.BaseUrl = GClass334.smethod_1(fileSaveCommandParameter_0.FileName);
				}
				if (!string.IsNullOrEmpty(fileSaveCommandParameter_0.Format))
				{
					document.FileFormat = fileSaveCommandParameter_0.Format;
				}
			}
			if (destinations is Stream)
			{
				Stream stream = (Stream)destinations;
				if (fileSaveCommandParameter_0.ContentEncoding != null)
				{
					bool flag = true;
					ContentSerializer serializer = document.AppHost.ContentSerializers.GetSerializer(fileSaveCommandParameter_0.Format);
					if (serializer != null)
					{
						flag = ((serializer.Flags & GEnum14.flag_4) == GEnum14.flag_4);
					}
					if (flag)
					{
						using (StreamWriter writer = new StreamWriter(stream, fileSaveCommandParameter_0.ContentEncoding))
						{
							document.Save(writer, fileSaveCommandParameter_0.Format, fileSaveCommandParameter_0.BackgroundMode, fileSaveCommandParameter_0.FileName);
						}
						return true;
					}
				}
				document.Save(stream, fileSaveCommandParameter_0.Format, fileSaveCommandParameter_0.BackgroundMode, fileSaveCommandParameter_0.FileName, fileSaveCommandParameter_0.ContentEncoding);
				return true;
			}
			if (destinations is TextWriter)
			{
				TextWriter writer2 = (TextWriter)destinations;
				document.Save(writer2, fileSaveCommandParameter_0.Format, fileSaveCommandParameter_0.BackgroundMode);
				return true;
			}
			return false;
		}

		/// <summary>
		///       保存文档中被选择的内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileSaveSelection", ImageResource = "DCSoft.Writer.Commands.Images.CommandSave.bmp", ReturnValueType = typeof(bool))]
		protected void FileSaveSelection(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Selection.Length != 0);
			}
			if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.Document.Selection.Length == 0)
				{
					e.Result = false;
				}
				else
				{
					e.Result = SaveDocument(newFileName: false, e, selectionOnly: true);
				}
			}
		}

		/// <summary>
		///       保存文档
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileSave", ImageResource = "DCSoft.Writer.Commands.Images.CommandSave.bmp", ReturnValueType = typeof(bool))]
		protected void FileSave(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				e.Result = SaveDocument(newFileName: false, e, selectionOnly: false);
			}
		}

		[WriterCommandDescription("FileSaveAs", ImageResource = "DCSoft.Writer.Commands.Images.CommandSave.bmp", ReturnValueType = typeof(bool))]
		protected void FileSaveAs(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				e.Result = SaveDocument(newFileName: true, e, selectionOnly: false);
			}
		}

		/// <summary>
		///       采用特殊调试模式的另存为
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileSaveAsInDebugMode", ImageResource = "DCSoft.Writer.Commands.Images.CommandSave.bmp", ReturnValueType = typeof(bool))]
		protected void FileSaveAsInDebugMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				bool specifyDebugMode = e.Document.Options.BehaviorOptions.SpecifyDebugMode;
				e.Document.Options.BehaviorOptions.SpecifyDebugMode = true;
				try
				{
					e.Result = SaveDocument(newFileName: true, e, selectionOnly: false);
				}
				finally
				{
					e.Document.Options.BehaviorOptions.SpecifyDebugMode = specifyDebugMode;
				}
			}
		}

		[WriterCommandDescription("FileNew", ImageResource = "DCSoft.Writer.Commands.Images.CommandFileNew.bmp", ReturnValueType = typeof(bool))]
		protected void FileNew(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (QuerySave(e))
				{
					e.EditorControl.ClearContent();
					e.EditorControl.OnDocumentLoad(new WriterEventArgs(e.EditorControl, e.Document, null));
					e.Document.FileName = null;
					e.Document.ContentSourceType = DocumentContentSourceTypes.NewFile;
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       页面边框和背景
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("PageBorderBackgroundFormat", FunctionID = GEnum6.const_35)]
		protected void PageBorderBackgroundFormat(object sender, WriterCommandEventArgs e)
		{
			int num = 0;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && !e.EditorControl.RuntimeReadonly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.EditorControl != null && !e.EditorControl.RuntimeReadonly)
				{
					PageBorderBackgroundStyle style = e.Parameter as PageBorderBackgroundStyle;
					if (style == null)
					{
						style = e.Document.PageSettings.PageBorderBackground;
					}
					if (style == null)
					{
						style = new PageBorderBackgroundStyle();
						style.BackgroundColor = Color.Transparent;
						style.BorderColor = Color.Black;
						style.BorderWidth = 0f;
						style.BorderLeft = true;
						style.BorderTop = true;
						style.BorderRight = true;
						style.BorderBottom = true;
					}
					dlgDocumentBorderBackground dlgDocumentBorderBackground_0 = new dlgDocumentBorderBackground();
					try
					{
						dlgDocumentBorderBackground_0.ShowApplyRange = false;
						BorderBackgroundCommandParameter borderBackgroundCommandParameter = new BorderBackgroundCommandParameter();
						dlgDocumentBorderBackground_0.CommandParameter = borderBackgroundCommandParameter;
						borderBackgroundCommandParameter.ReadContentStyle(style);
						dlgDocumentBorderBackground_0.eventHandler_0 = delegate
						{
							using (dlgPageBorderRange dlgPageBorderRange = new dlgPageBorderRange())
							{
								dlgPageBorderRange.InputStyle = style;
								if (dlgPageBorderRange.ShowDialog(dlgDocumentBorderBackground_0) == DialogResult.OK)
								{
									dlgDocumentBorderBackground_0.ValueModified = true;
								}
							}
						};
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDocumentBorderBackground_0, null) != DialogResult.OK || !borderBackgroundCommandParameter.SetContentStyle(style))
						{
							return;
						}
					}
					finally
					{
						if (dlgDocumentBorderBackground_0 != null)
						{
							((IDisposable)dlgDocumentBorderBackground_0).Dispose();
						}
					}
					e.Document.BeginLogUndo();
					e.Document.UndoList.AddProperty("PageBorderBackground", e.Document.PageSettings.PageBorderBackground, style, e.Document.PageSettings);
					e.Document.UndoList.AddMethod(UndoMethodTypes.Invalidate);
					e.Document.PageSettings.PageBorderBackground = style;
					e.Document.EndLogUndo();
					e.EditorControl.InnerViewControl.Invalidate();
					e.Document.Modified = true;
					e.Document.OnDocumentContentChanged();
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       显示页面设置对话框
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FilePageSettings", ImageResource = "DCSoft.Writer.Commands.Images.CommandPageSettings.bmp", ReturnValueType = typeof(XPageSettings))]
		protected void FilePageSettings(object sender, WriterCommandEventArgs e)
		{
			int num = 1;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					e.Enabled = !e.DocumentControler.EditorControlReadonly;
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XPageSettings xPageSettings = null;
				if (e.Parameter is XPageSettings)
				{
					xPageSettings = (XPageSettings)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					if (string.IsNullOrEmpty((string)e.Parameter))
					{
						xPageSettings = e.Document.PageSettings.Clone();
					}
					else
					{
						xPageSettings = new XPageSettings();
						GClass340 gClass = new GClass340((string)e.Parameter);
						gClass.method_6(xPageSettings, bool_0: false);
					}
				}
				if (e.ShowUI)
				{
					if (xPageSettings == null)
					{
						xPageSettings = e.Document.PageSettings.Clone();
					}
					using (dlgPageSetup dlgPageSetup = new dlgPageSetup())
					{
						dlgPageSetup.PageSettings = xPageSettings;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgPageSetup, null) != DialogResult.OK)
						{
							return;
						}
						xPageSettings = dlgPageSetup.PageSettings;
					}
				}
				if (xPageSettings != null)
				{
					if (e.Document.BeginLogUndo())
					{
						e.Document.UndoList.AddProperty("PageSettings", e.Document.PageSettings, xPageSettings, e.Document);
						e.Document.EndLogUndo();
					}
					e.Document.PageSettings = xPageSettings;
					e.Document.UpdateContentVersion();
					if (e.EditorControl != null)
					{
						e.EditorControl.RefreshDocument();
						e.EditorControl.InnerViewControl.Invalidate();
					}
					e.Result = xPageSettings;
				}
			}
		}

		/// <summary>
		///       打印文档中被选择的内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FilePrintSelection", ImageResource = "DCSoft.Writer.Commands.Images.CommandPrint.bmp", ReturnValueType = typeof(PrintResult), FunctionID = GEnum6.const_44)]
		protected void FilePrintSelection(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.BehaviorOptions.Printable && e.Document.Selection.Length != 0);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerPrint(e, refreshDocument: true);
			}
		}

		/// <summary>
		///       手动双面打印
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FilePrintWithManualDuplex", ImageResource = "DCSoft.Writer.Commands.Images.CommandPrint.bmp", ReturnValueType = typeof(PrintResult), FunctionID = GEnum6.const_39)]
		protected void FilePrintWithManualDuplex(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.BehaviorOptions.Printable);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerPrint(e, refreshDocument: true);
			}
		}

		/// <summary>
		///       打印文档
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FilePrint", ImageResource = "DCSoft.Writer.Commands.Images.CommandPrint.bmp", ReturnValueType = typeof(PrintResult))]
		protected void FilePrint(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.BehaviorOptions.Printable);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerPrint(e, refreshDocument: true);
			}
		}

		/// <summary>
		///       整洁打印文档,不支持续打和打印当前页。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FileCleanPrint", ImageResource = "DCSoft.Writer.Commands.Images.CommandPrint.bmp", ReturnValueType = typeof(PrintResult))]
		protected void FileCleanPrint(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.BehaviorOptions.Printable);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerPrint(e, refreshDocument: true);
			}
		}

		private void InnerPrint(WriterCommandEventArgs args, bool refreshDocument)
		{
			int num = 16;
			args.Result = null;
			if (!args.Document.Options.BehaviorOptions.Printable || !args.Document.Info.Printable)
			{
				if (args.ShowUI)
				{
					args.Host.UITools.ShowWarringMessageBox(args.EditorControl, WriterStrings.PromptCannotPrintDocument);
				}
				return;
			}
			if (!GClass154.smethod_3())
			{
				if (args.ShowUI)
				{
					args.Host.UITools.ShowErrorMessageBox(args.EditorControl, WriterStrings.NotInstallPrinter);
				}
				return;
			}
			DocumentPrinter documentPrinter = null;
			documentPrinter = ((!(args.Parameter is XTextDocument)) ? new DocumentPrinter(args.EditorControl) : new DocumentPrinter((XTextDocument)args.Parameter));
			documentPrinter.Options.PrinterName = WriterControl.GlobalDefaultPrinterName;
			if (args.Parameter is JumpPrintInfo)
			{
				JumpPrintInfo jumpPrintInfo = (JumpPrintInfo)args.Parameter;
				documentPrinter.Options.JumpPrint = args.Document.GetJumpPrintInfo(jumpPrintInfo.Position);
			}
			FilePrintCommandParameter filePrintCommandParameter = args.Parameter as FilePrintCommandParameter;
			if (filePrintCommandParameter == null)
			{
				filePrintCommandParameter = new FilePrintCommandParameter();
				if (args.Name == "FilePrintWithManualDuplex")
				{
					filePrintCommandParameter.ManualDuplex = true;
				}
				else if (args.Name == "FileCleanPrint")
				{
					filePrintCommandParameter.CleanPrintMode = true;
				}
				if (args.Parameter is JumpPrintInfo)
				{
					filePrintCommandParameter.JumpPrintInfo = (JumpPrintInfo)args.Parameter;
				}
			}
			if (args.Document.Options.BehaviorOptions.ShowDebugMessage && args.ShowUI)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("原始输入----");
				stringBuilder.AppendLine(GClass369.smethod_3(args.Parameter));
				stringBuilder.AppendLine("指定的参数-----");
				stringBuilder.AppendLine(GClass369.smethod_3(filePrintCommandParameter));
				args.Host.UITools.ShowMessageBox(args.EditorControl, stringBuilder.ToString());
			}
			documentPrinter.Options.SpecifyPageIndexs = filePrintCommandParameter.SpecifyPageIndexs;
			documentPrinter.Options.SpecifyCopies = filePrintCommandParameter.SpecifyCopies;
			if (!string.IsNullOrEmpty(filePrintCommandParameter.SpecifyPrinterName))
			{
				documentPrinter.Options.PrinterName = filePrintCommandParameter.SpecifyPrinterName;
			}
			documentPrinter.CleanMode = filePrintCommandParameter.CleanPrintMode;
			documentPrinter.Options.ManualDuplex = filePrintCommandParameter.ManualDuplex;
			documentPrinter.Options.PrintRange = PrintRange.AllPages;
			documentPrinter.Options.DrawFirstHeaderFooterWhenJumpPrintMode = filePrintCommandParameter.DrawFirstHeaderFooterWhenJumpPrintMode;
			if (args.Name == "FilePrintCurrentPage")
			{
				documentPrinter.Options.PrintRange = PrintRange.CurrentPage;
				documentPrinter.Options.PrintMode = DCPrintMode.CurrentPage;
			}
			else if (args.Name == "FilePrintWithManualDuplex")
			{
				documentPrinter.Options.PrintMode = DCPrintMode.ManualDuplex;
			}
			else if (args.Name == "FilePrintSelection")
			{
				documentPrinter.Options.PrintRange = PrintRange.Selection;
			}
			if (filePrintCommandParameter.JumpPrintInfo != null)
			{
				documentPrinter.Options.JumpPrint = filePrintCommandParameter.JumpPrintInfo;
			}
			documentPrinter.CurrentPage = args.EditorControl.CurrentPage;
			Cursor cursor = null;
			JumpPrintInfo jumpPrint = null;
			if (args.EditorControl != null)
			{
				jumpPrint = args.EditorControl.JumpPrint.Clone();
				documentPrinter.WriterControl = args.EditorControl;
				if (args.EditorControl.StartPageIndex >= 0)
				{
					documentPrinter.Options.FromPage = args.EditorControl.StartPageIndex;
				}
				if (args.EditorControl.EndPageIndex >= 0)
				{
					documentPrinter.Options.ToPage = args.EditorControl.EndPageIndex;
				}
				documentPrinter.Options.BoundsSelection = args.EditorControl.BoundsSelection;
				cursor = args.EditorControl.Cursor;
				args.EditorControl.Cursor = Cursors.WaitCursor;
				if (refreshDocument)
				{
					args.EditorControl.InnerViewControl.FreezeUI();
				}
			}
			bool showPermissionMark = args.EditorControl.DocumentOptions.SecurityOptions.ShowPermissionMark;
			bool showLogicDeletedContent = args.EditorControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent;
			try
			{
				PrintResult printResult2 = (PrintResult)(args.Result = documentPrinter.PrintDocument(args.ShowUI));
				if (args.Document.Options.BehaviorOptions.SpecifyDebugMode)
				{
					printResult2?.ShowDialog(args.EditorControl);
				}
			}
			finally
			{
				if (args.EditorControl != null)
				{
					args.EditorControl.DocumentOptions.SecurityOptions.ShowPermissionMark = showPermissionMark;
					args.EditorControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = showLogicDeletedContent;
					if (refreshDocument)
					{
						args.EditorControl.RefreshDocument();
						args.EditorControl.JumpPrint = jumpPrint;
						args.EditorControl.InnerViewControl.ReleaseFreezeUI();
					}
					else
					{
						args.EditorControl.UpdatePages();
					}
					args.EditorControl.Cursor = cursor;
				}
			}
		}

		/// <summary>
		///       打印当前页
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FilePrintCurrentPage", ImageResource = "DCSoft.Writer.Commands.Images.CommandPrint.bmp", ReturnValueType = typeof(bool))]
		protected void FilePrintCurrentPage(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null && e.Document.Options.BehaviorOptions.Printable);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerPrint(e, refreshDocument: false);
			}
		}

		/// <summary>
		///       打印预览
		///       </summary>
		/// <param name="sendder">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FilePrintPreview", ImageResource = "DCSoft.Writer.Commands.Images.CommandFilePrintPreview.bmp", ReturnValueType = typeof(PrintResult))]
		protected void FilePrintPreview(object sender, WriterCommandEventArgs e)
		{
			int num = 19;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				if (!e.ShowUI)
				{
					return;
				}
				if (!e.Document.Options.BehaviorOptions.Printable || !e.Document.Info.Printable)
				{
					if (e.ShowUI)
					{
						e.Host.UITools.ShowWarringMessageBox(e.EditorControl, WriterStrings.PromptCannotPrintDocument);
					}
				}
				else
				{
					FilePrintPreviewCommandParameter filePrintPreviewCommandParameter_0 = e.Parameter as FilePrintPreviewCommandParameter;
					frmPrintPreview frmPrintPreview_0 = new frmPrintPreview();
					try
					{
						e.EditorControl.InnerViewControl.FreezeUI();
						WriterPrintDocument writerPrintDocument = new WriterPrintDocument();
						writerPrintDocument.AddDocumentByWriterControl(e.EditorControl);
						frmPrintPreview_0.myPreviewControl.Document = writerPrintDocument;
						if (e.EditorControl != null && (e.EditorControl.StartPageIndex >= 0 || e.EditorControl.EndPageIndex >= 0))
						{
							writerPrintDocument.PrinterSettings.PrintRange = PrintRange.SomePages;
							if (e.EditorControl.StartPageIndex >= 0)
							{
								writerPrintDocument.PrinterSettings.FromPage = e.EditorControl.StartPageIndex + 1;
							}
							if (e.EditorControl.EndPageIndex >= 0)
							{
								writerPrintDocument.PrinterSettings.ToPage = e.EditorControl.EndPageIndex + 1;
							}
						}
						frmPrintPreview_0.StartPosition = FormStartPosition.CenterParent;
						if (filePrintPreviewCommandParameter_0 != null)
						{
							writerPrintDocument.CleanMode = filePrintPreviewCommandParameter_0.CleanPreviewMode;
							frmPrintPreview_0.Load += delegate
							{
								if (filePrintPreviewCommandParameter_0.Maximized)
								{
									frmPrintPreview_0.WindowState = FormWindowState.Maximized;
								}
								switch (filePrintPreviewCommandParameter_0.ZoomRate)
								{
								case PrintPreviewZoomRate.Zooom10:
									frmPrintPreview_0.myPreviewControl.Zoom = 0.1;
									break;
								case PrintPreviewZoomRate.Zoom25:
									frmPrintPreview_0.myPreviewControl.Zoom = 0.25;
									break;
								case PrintPreviewZoomRate.Zoom50:
									frmPrintPreview_0.myPreviewControl.Zoom = 0.5;
									break;
								case PrintPreviewZoomRate.Zoom75:
									frmPrintPreview_0.myPreviewControl.Zoom = 0.75;
									break;
								case PrintPreviewZoomRate.Zoom100:
									frmPrintPreview_0.myPreviewControl.Zoom = 1.0;
									break;
								case PrintPreviewZoomRate.Zoom150:
									frmPrintPreview_0.myPreviewControl.Zoom = 1.5;
									break;
								case PrintPreviewZoomRate.Zoom250:
									frmPrintPreview_0.myPreviewControl.Zoom = 2.5;
									break;
								case PrintPreviewZoomRate.Zoom500:
									frmPrintPreview_0.myPreviewControl.Zoom = 5.0;
									break;
								}
							};
							frmPrintPreview_0.myPreviewControl.AllowUserChangePrintArea = filePrintPreviewCommandParameter_0.AllowUserChangePrintArea;
							frmPrintPreview_0.AutoTurnToLastPage = filePrintPreviewCommandParameter_0.AutoTurnToLastPage;
							frmPrintPreview_0.IsTurnToPage = filePrintPreviewCommandParameter_0.IsTurnToPage;
							frmPrintPreview_0.TurnToPage = filePrintPreviewCommandParameter_0.TurnToPage;
						}
						if (e.Document.Options.BehaviorOptions.MaximizedPrintPreviewDialog)
						{
							frmPrintPreview_0.WindowState = FormWindowState.Maximized;
						}
						frmPrintPreview_0.Text = frmPrintPreview_0.Text + "-" + e.Document.Info.RuntimeTitle;
						frmPrintPreview_0.myPreviewControl.PageBackColor = e.EditorControl.PageBackColor;
						frmPrintPreview_0.myPreviewControl.PreviewBackColor = e.EditorControl.BackColor;
						bool showPermissionMark = e.EditorControl.DocumentOptions.SecurityOptions.ShowPermissionMark;
						bool showLogicDeletedContent = e.EditorControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent;
						writerPrintDocument.UpdateDocumentsState();
						try
						{
							WriterControl.UIShowDialog(e.EditorControl, frmPrintPreview_0, null);
						}
						finally
						{
							e.EditorControl.DocumentOptions.SecurityOptions.ShowPermissionMark = showPermissionMark;
							e.EditorControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = showLogicDeletedContent;
							writerPrintDocument.RestoreDocumentsState();
							e.EditorControl.InnerViewControl.ReleaseFreezeUI();
							e.EditorControl.UpdatePages();
						}
						e.Result = writerPrintDocument.CurrentPrintResult;
					}
					finally
					{
						if (frmPrintPreview_0 != null)
						{
							((IDisposable)frmPrintPreview_0).Dispose();
						}
					}
				}
			}
		}

		/// <summary>
		///       若文档内容修改则询问用户是否保存。
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>用户确认保存</returns>
		public virtual bool QuerySave(WriterCommandEventArgs args)
		{
			if (!args.ShowUI)
			{
				return true;
			}
			if (args.Document.Modified)
			{
				string systemAlert = WriterStrings.SystemAlert;
				if (args.EditorControl != null)
				{
					systemAlert = args.EditorControl.DialogTitlePrefix + systemAlert;
				}
				switch (args.Host.UITools.ShowYesNoCancelMessageBox(args.EditorControl, string.Format(WriterStrings.PromptSaveFile_Name, args.Document.FileName)))
				{
				case DialogResult.Yes:
					return SaveDocument(newFileName: false, args, selectionOnly: false);
				case DialogResult.No:
					return true;
				case DialogResult.Cancel:
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///       保存文件
		///       </summary>
		/// <param name="newFileName">使用新文件名</param>
		/// <param name="cmdArgs">事件参数</param>
		/// <returns>操作是否成功</returns>
		private bool SaveDocument(bool newFileName, WriterCommandEventArgs cmdArgs, bool selectionOnly)
		{
			int num = 16;
			FileSaveCommandParameter fileSaveCommandParameter = cmdArgs.Parameter as FileSaveCommandParameter;
			Stream stream = null;
			TextWriter textWriter = null;
			if (fileSaveCommandParameter == null)
			{
				fileSaveCommandParameter = new FileSaveCommandParameter();
				fileSaveCommandParameter.FileName = cmdArgs.Document.FileName;
				fileSaveCommandParameter.Format = cmdArgs.Document.FileFormat;
				if (cmdArgs.Parameter is Stream)
				{
					stream = (Stream)cmdArgs.Parameter;
				}
				else if (cmdArgs.Parameter is TextWriter)
				{
					textWriter = (TextWriter)cmdArgs.Parameter;
				}
				else if (cmdArgs.Parameter is string)
				{
					fileSaveCommandParameter.FileName = (string)cmdArgs.Parameter;
					fileSaveCommandParameter.Format = cmdArgs.Host.ContentSerializers.GetFormatNameByFileExtension(fileSaveCommandParameter.FileName);
				}
				if (string.IsNullOrEmpty(fileSaveCommandParameter.Format))
				{
					fileSaveCommandParameter.Format = cmdArgs.Host.DefaultFileFormat;
				}
			}
			else
			{
				if (fileSaveCommandParameter.AutoSetFormat && !string.IsNullOrEmpty(fileSaveCommandParameter.FileName))
				{
					int num2 = fileSaveCommandParameter.FileName.LastIndexOf('.');
					switch (fileSaveCommandParameter.FileName.Substring(num2 + 1).Trim().ToLower())
					{
					case "xml":
						fileSaveCommandParameter.Format = "xml";
						break;
					case "rtf":
						fileSaveCommandParameter.Format = "rtf";
						break;
					case "pdf":
						fileSaveCommandParameter.Format = "pdf";
						break;
					case "htm":
						fileSaveCommandParameter.Format = "html";
						break;
					case "html":
						fileSaveCommandParameter.Format = "html";
						break;
					case "txt":
						fileSaveCommandParameter.Format = "txt";
						break;
					case "mht":
						fileSaveCommandParameter.Format = "mht";
						break;
					}
				}
				stream = fileSaveCommandParameter.OutputStream;
				textWriter = fileSaveCommandParameter.OutputWriter;
			}
			if (cmdArgs.ShowUI && stream == null && textWriter == null && (string.IsNullOrEmpty(cmdArgs.Document.FileName) || newFileName || selectionOnly))
			{
				string string_ = cmdArgs.Document.FileFormat;
				string text = WriterControl.smethod_1(cmdArgs.EditorControl, cmdArgs.Host, fileSaveCommandParameter.FileName, ref string_, fileSaveCommandParameter.FileSystemName);
				if (text == null)
				{
					fileSaveCommandParameter.Message = WriterStrings.UserCancel;
					return false;
				}
				fileSaveCommandParameter.FileName = text;
				fileSaveCommandParameter.Format = string_;
			}
			ContentSerializer serializer = cmdArgs.Host.ContentSerializers.GetSerializer(fileSaveCommandParameter.Format);
			bool flag = (serializer.Flags & GEnum14.flag_4) == GEnum14.flag_4;
			bool flag2 = (serializer.Flags & GEnum14.flag_2) == GEnum14.flag_2;
			if (!flag && !flag2)
			{
				fileSaveCommandParameter.Message = string.Format(WriterStrings.NotSupportWrite_Format, serializer.Name);
				ShowErrorMessage(cmdArgs, fileSaveCommandParameter.Message);
				return false;
			}
			XTextDocument xTextDocument = cmdArgs.Document;
			if (selectionOnly)
			{
				xTextDocument = cmdArgs.Document.Selection.CreateDocument();
			}
			if (stream != null)
			{
				if (flag2)
				{
					return SaveToFile(xTextDocument, stream, fileSaveCommandParameter, cmdArgs);
				}
				fileSaveCommandParameter.Message = string.Format(WriterStrings.NotSupportWriteBinary_Format, serializer.Name);
				ShowErrorMessage(cmdArgs, fileSaveCommandParameter.Message);
				return false;
			}
			if (textWriter != null)
			{
				if (flag)
				{
					return SaveToFile(xTextDocument, textWriter, fileSaveCommandParameter, cmdArgs);
				}
				fileSaveCommandParameter.Message = string.Format(WriterStrings.NotSupportWriteText_Format, serializer.Name);
				ShowErrorMessage(cmdArgs, fileSaveCommandParameter.Message);
				return false;
			}
			if (string.IsNullOrEmpty(fileSaveCommandParameter.FileName))
			{
				fileSaveCommandParameter.Message = WriterStrings.NotSpecifyFileName;
				ShowErrorMessage(cmdArgs, fileSaveCommandParameter.Message);
				return false;
			}
			MemoryStream memoryStream = new MemoryStream();
			if (!fileSaveCommandParameter.BackgroundMode && !string.IsNullOrEmpty(fileSaveCommandParameter.FileName))
			{
				xTextDocument.FileName = fileSaveCommandParameter.FileName;
				xTextDocument.FileFormat = fileSaveCommandParameter.Format;
				xTextDocument.BaseUrl = GClass334.smethod_1(fileSaveCommandParameter.FileName);
			}
			xTextDocument.Save(memoryStream, fileSaveCommandParameter.Format, fileSaveCommandParameter.BackgroundMode, fileSaveCommandParameter.FileName, fileSaveCommandParameter.ContentEncoding);
			byte[] content = memoryStream.ToArray();
			WriterSaveFileContentEventArgs writerSaveFileContentEventArgs = new WriterSaveFileContentEventArgs(cmdArgs.EditorControl, cmdArgs.Document, null, fileSaveCommandParameter.FileName, fileSaveCommandParameter.FileSystemName, content);
			if (selectionOnly)
			{
				xTextDocument.Dispose();
				cmdArgs.RefreshLevel = UIStateRefreshLevel.None;
			}
			WriterControl.SaveFileContent(cmdArgs.EditorControl, writerSaveFileContentEventArgs);
			return writerSaveFileContentEventArgs.Result;
		}

		/// <summary>
		///       显示错误信息
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="msg">
		/// </param>
		private void ShowErrorMessage(WriterCommandEventArgs args, string string_1)
		{
			if (args.ShowUI && !string.IsNullOrEmpty(string_1))
			{
				args.Host.UITools.ShowWarringMessageBox(args.EditorControl, string_1);
			}
		}

		/// <summary>
		///       设置文档的默认字体
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentDefaultFont", FunctionID = GEnum6.const_21)]
		protected void DocumentDefaultFont(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null && e.EditorControl != null && !e.EditorControl.RuntimeReadonly && !e.EditorControl.AutoSetDocumentDefaultFont)
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XFontValue xFontValue = new XFontValue();
				if (e.Parameter is XFontValue)
				{
					xFontValue = (XFontValue)e.Parameter;
				}
				else if (e.Parameter is Font)
				{
					xFontValue = new XFontValue((Font)e.Parameter);
				}
				else if (e.Parameter is string)
				{
					xFontValue.method_6((string)e.Parameter);
				}
				else
				{
					xFontValue = e.Document.DefaultStyle.Font;
				}
				Color color = e.Document.DefaultStyle.Color;
				if (e.ShowUI)
				{
					using (FontDialog fontDialog = new FontDialog())
					{
						fontDialog.ShowColor = true;
						fontDialog.Font = xFontValue.Value;
						fontDialog.Color = color;
						if (fontDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						xFontValue = new XFontValue(fontDialog.Font);
						color = fontDialog.Color;
					}
				}
				if (e.Document.BeginLogUndo())
				{
					XTextUndoSetDefaultFont ginterface1_ = new XTextUndoSetDefaultFont(e.EditorControl, e.Document.DefaultStyle.Font, e.Document.DefaultStyle.Color, xFontValue, color);
					e.Document.UndoList.method_14(ginterface1_);
					e.Document.EndLogUndo();
				}
				e.EditorControl.EditorSetDefaultFont(xFontValue, color, updateUI: true);
			}
		}

		/// <summary>
		///       查看和编辑文档选项
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentOptions")]
		protected void DocumentOptions(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgDocumentOptions dlgDocumentOptions = new dlgDocumentOptions())
				{
					dlgDocumentOptions.DocumentOptions = e.EditorControl.DocumentOptions.Clone();
					if (WriterControl.UIShowDialog(e.EditorControl, dlgDocumentOptions, null) == DialogResult.OK)
					{
						e.EditorControl.DocumentOptions = dlgDocumentOptions.DocumentOptions;
						if (e.Document.HighlightManager != null)
						{
							e.Document.HighlightManager.imethod_7();
						}
						e.EditorControl.InnerViewControl.Invalidate();
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       获得指定格式的文档选择内容的文本值
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("GetSelectionContentText", ReturnValueType = typeof(string))]
		protected void GetSelectionContentText(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				StringWriter stringWriter = new StringWriter();
				string text = Convert.ToString(e.Parameter);
				if (string.IsNullOrEmpty(text))
				{
					text = e.Host.ContentSerializers.DefaultSerializer.Name;
				}
				if (e.Document.Selection.Length != 0)
				{
					XTextDocument xTextDocument = e.Document.Selection.CreateDocument();
					if (xTextDocument != null)
					{
						xTextDocument.Save(stringWriter, text);
						xTextDocument.Dispose();
					}
				}
				string text2 = stringWriter.ToString();
				if (e.ShowUI)
				{
					using (frmViewXML frmViewXML = new frmViewXML())
					{
						if (e.EditorControl != null)
						{
							frmViewXML.Text = e.EditorControl.DialogTitlePrefix + frmViewXML.Text;
						}
						frmViewXML.XMLSource = text2;
						WriterControl.UIShowDialog(e.EditorControl, frmViewXML, null);
					}
				}
				e.Result = text2;
			}
		}

		/// <summary>
		///       获得文件XML代码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ViewXMLSourceWithNotePad", ImageResource = "DCSoft.Writer.Commands.Images.CommandViewXMLSource.bmp", ReturnValueType = typeof(string), FunctionID = GEnum6.const_17)]
		protected void ViewXMLSourceWithNotePad(object sender, WriterCommandEventArgs e)
		{
			int num = 12;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !XTextDocument.smethod_13(GEnum6.const_17))
				{
					return;
				}
				string text = null;
				if (e.Parameter is string)
				{
					text = (string)e.Parameter;
				}
				if (string.IsNullOrEmpty(text))
				{
					XTextDocument xTextDocument = e.Document;
					if (e.Parameter is XTextDocument)
					{
						xTextDocument = (XTextDocument)e.Parameter;
					}
					text = xTextDocument.XMLText;
				}
				if (e.ShowUI)
				{
					string text2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe");
					if (File.Exists(text2))
					{
						string text3 = Path.Combine(Path.GetTempPath(), "dcsoft.writer.viewxmlsource.xml");
						using (StreamWriter streamWriter = new StreamWriter(text3, append: false, Encoding.Unicode))
						{
							streamWriter.Write(text);
						}
						Process.Start(text2, "\"" + text3 + "\"");
					}
					else
					{
						e.Host.UITools.ShowMessageBox(e.EditorControl, string.Format(WriterStrings.FileNotExist_FileName, text2));
					}
				}
				e.Result = text;
				e.RefreshLevel = UIStateRefreshLevel.None;
			}
		}

		/// <summary>
		///       获得文件XML代码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ViewXMLSource", ImageResource = "DCSoft.Writer.Commands.Images.CommandViewXMLSource.bmp", ReturnValueType = typeof(string), FunctionID = GEnum6.const_17)]
		protected void ViewXMLSource(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !XTextDocument.smethod_13(GEnum6.const_17))
				{
					return;
				}
				string text = null;
				if (e.Parameter is string)
				{
					text = (string)e.Parameter;
				}
				if (string.IsNullOrEmpty(text))
				{
					XTextDocument xTextDocument = e.Document;
					if (e.Parameter is XTextDocument)
					{
						xTextDocument = (XTextDocument)e.Parameter;
					}
					text = xTextDocument.XMLText;
				}
				if (e.ShowUI)
				{
					using (frmViewXML frmViewXML = new frmViewXML())
					{
						if (e.EditorControl != null)
						{
							frmViewXML.Text = e.EditorControl.DialogTitlePrefix + frmViewXML.Text;
						}
						frmViewXML.XMLSource = text;
						WriterControl.UIShowDialog(e.EditorControl, frmViewXML, null);
					}
				}
				e.Result = text;
				e.RefreshLevel = UIStateRefreshLevel.None;
			}
		}

		/// <summary>
		///       获得文件XML代码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ViewXMLSource2", ImageResource = "DCSoft.Writer.Commands.Images.CommandViewXMLSource.bmp", ReturnValueType = typeof(string), FunctionID = GEnum6.const_17)]
		protected void ViewXMLSource2(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && XTextDocument.smethod_13(GEnum6.const_17) && e.ShowUI && e.EditorControl != null)
			{
				using (frmViewXML frmViewXML = new frmViewXML())
				{
					frmViewXML.Text = e.EditorControl.DialogTitlePrefix + frmViewXML.Text;
					string text = null;
					if (e.Parameter is string)
					{
						text = (string)e.Parameter;
					}
					if (string.IsNullOrEmpty(text))
					{
						XTextDocument xTextDocument = e.Document;
						if (e.Parameter is XTextDocument)
						{
							xTextDocument = (XTextDocument)e.Parameter;
						}
						text = xTextDocument.XMLText;
					}
					frmViewXML.XMLSource = text;
					WriterControl.UIShowDialog(e.EditorControl, frmViewXML, null);
				}
			}
		}

		/// <summary>
		///       预览HTML输出结果
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("HtmlPreview", ImageResource = "DCSoft.Writer.Commands.Images.CommandHtmlPreview.bmp", ReturnValueType = typeof(string), FunctionID = GEnum6.const_16)]
		protected void HtmlPreview(object sender, WriterCommandEventArgs e)
		{
			int num = 17;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI && XTextDocument.smethod_13(GEnum6.const_16))
			{
				FileSaveCommandParameter fileSaveCommandParameter = new FileSaveCommandParameter();
				fileSaveCommandParameter.FileName = Path.Combine(Path.GetTempPath(), "dcsoft.writer.htmlpreview.html");
				fileSaveCommandParameter.Format = "html";
				fileSaveCommandParameter.BackgroundMode = true;
				fileSaveCommandParameter.ContentEncoding = Encoding.UTF8;
				WriterCommandEventArgs writerCommandEventArgs = e.Clone();
				writerCommandEventArgs.Parameter = fileSaveCommandParameter;
				writerCommandEventArgs.ShowUI = false;
				FileSave(sender, writerCommandEventArgs);
				if ((bool)writerCommandEventArgs.Result)
				{
					using (frmPreviewHtml frmPreviewHtml = new frmPreviewHtml())
					{
						frmPreviewHtml.HtmlUrl = fileSaveCommandParameter.FileName;
						WriterControl.UIShowDialog(e.EditorControl, frmPreviewHtml, null);
					}
				}
			}
		}

		/// <summary>
		///       保存图片
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SaveImageFile")]
		protected void SaveImageFile(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			if (e.Mode != WriterCommandEventMode.Invoke)
			{
				return;
			}
			e.Result = false;
			XTextImageElement xTextImageElement = (XTextImageElement)e.Document.GetCurrentElement(typeof(XTextImageElement));
			if (xTextImageElement != null)
			{
				if (!string.IsNullOrEmpty((string)e.Parameter) && !e.ShowUI)
				{
					XImageValue image = xTextImageElement.Image;
					image.Save((string)e.Parameter);
					e.Result = true;
					e.RefreshLevel = UIStateRefreshLevel.None;
				}
				else
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = WriterStrings.ImageFileFilter;
						saveFileDialog.OverwritePrompt = true;
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							XImageValue image = xTextImageElement.Image;
							image.Save(saveFileDialog.FileName);
							e.Result = true;
							e.RefreshLevel = UIStateRefreshLevel.None;
						}
					}
				}
			}
		}
	}
}
