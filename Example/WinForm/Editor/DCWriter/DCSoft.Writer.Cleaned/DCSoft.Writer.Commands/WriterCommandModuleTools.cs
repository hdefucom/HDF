using DCSoft.Design;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Script;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       工具类型的编辑器命令容器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[WriterCommandDescription("Tools")]
	internal class WriterCommandModuleTools : WriterCommandModule
	{
		/// <summary>
		///       系统清理内存。这个过程是耗时间的。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("GCCollect")]
		protected void GCCollect(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.EditorControl.GCCollect();
			}
		}

		/// <summary>
		///       全局调试信息
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShowSystemLog")]
		protected void ShowSystemLog(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				frmSystemLog.Instance.Show();
			}
		}

		/// <summary>
		///       全局调试信息
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("GlobalDebugInfo")]
		protected void GlobalDebugInfo(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				_ = (e.Parameter is string);
				if (e.ShowUI)
				{
					using (dlgGlobalDebugConfig form_ = new dlgGlobalDebugConfig())
					{
						WriterControl.UIShowDialog(e.EditorControl, form_, null);
					}
				}
			}
		}

		/// <summary>
		///       生成WEB开发中使用的CAB文件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("GenerateCABFile")]
		protected void GenerateCABFile(object sender, WriterCommandEventArgs e)
		{
			int num = 3;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (typeof(XTextDocument).Assembly == typeof(WebWriterControl).Assembly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				string text = e.Parameter as string;
				if (e.ShowUI)
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = "*.cab|*.cab";
						saveFileDialog.CheckPathExists = true;
						saveFileDialog.OverwritePrompt = true;
						if (!string.IsNullOrEmpty(text))
						{
							saveFileDialog.FileName = text;
						}
						if (saveFileDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						text = saveFileDialog.FileName;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					byte[] array = WebWriterControl.smethod_0();
					if (array != null && array.Length > 0)
					{
						File.WriteAllBytes(text, array);
						MessageBox.Show(e.EditorControl, "成功生成文件 " + text);
					}
				}
			}
		}

		/// <summary>
		///       保存控件截屏
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SaveControlSnapshot")]
		protected void SaveControlSnapshot(object sender, WriterCommandEventArgs e)
		{
			int num = 7;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || e.EditorControl == null)
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
					text = e.EditorControl.Document.FileName;
					if (string.IsNullOrEmpty(text))
					{
						text = e.EditorControl.Document.Info.Title;
					}
					if (!string.IsNullOrEmpty(text))
					{
						text = Path.ChangeExtension(text, ".png");
					}
				}
				if (e.ShowUI)
				{
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.FileName = text;
						saveFileDialog.Filter = "*.png|*.png";
						saveFileDialog.CheckPathExists = true;
						saveFileDialog.OverwritePrompt = true;
						if (saveFileDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						text = saveFileDialog.FileName;
					}
					Application.DoEvents();
					Thread.Sleep(400);
					Application.DoEvents();
				}
				if (!string.IsNullOrEmpty(text))
				{
					GClass244 gClass = new GClass244(e.EditorControl);
					Rectangle rectangle = gClass.method_8();
					if (!rectangle.IsEmpty)
					{
						using (Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height))
						{
							using (Graphics graphics = Graphics.FromImage(bitmap))
							{
								ICaretProvider caretProvider = e.EditorControl.AppHost.Tools.CreateCaretProvider(e.EditorControl);
								caretProvider?.Hide();
								Application.DoEvents();
								graphics.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
								caretProvider?.Show();
							}
							bitmap.Save(text, ImageFormat.Png);
						}
					}
				}
			}
		}

		/// <summary>
		///       重置文档脚本引擎
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ResetScriptEngine")]
		protected void ResetScriptEngine(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.ResetScriptEngine();
			}
		}

		[WriterCommandDescription("ThrowException")]
		protected void ThrowException(object sender, WriterCommandEventArgs e)
		{
			int num = 14;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				throw new Exception("这里主动抛出一个异常");
			}
		}

		[WriterCommandDescription("TestPrint")]
		protected void TestPrint(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				using (frmTestPrintDocument frmTestPrintDocument = new frmTestPrintDocument())
				{
					frmTestPrintDocument.ShowDialog(e.EditorControl);
				}
			}
		}

		[WriterCommandDescription("DeveloperTools")]
		protected void DeveloperTools(object sender, WriterCommandEventArgs e)
		{
			bool developerToolsVisible;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				e.Checked = (e.EditorControl != null && e.EditorControl.DeveloperToolsVisible);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && (developerToolsVisible = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.DeveloperToolsVisible)) != e.EditorControl.DeveloperToolsVisible)
			{
				e.EditorControl.DeveloperToolsVisible = developerToolsVisible;
			}
		}

		[WriterCommandDescription("EditStringResource")]
		protected void EditStringResource(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				using (frmDescriptionEditor form_ = new frmDescriptionEditor())
				{
					WriterControl.UIShowDialog(e.EditorControl, form_, null);
				}
			}
		}

		[WriterCommandDescription("GenerateStringResourceCode")]
		protected void GenerateStringResourceCode(object sender, WriterCommandEventArgs e)
		{
			int num = 0;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				List<Type> list = new List<Type>();
				list.Add(typeof(XTextDocument).Assembly.GetType("DCSoft.Writer.WriterStringsCore"));
				list.Add(GetType().Assembly.GetType("DCSoft.Writer.WriterStrings"));
				string text = GClass372.smethod_3("DCSoft.Writer", "DocumentStringOptions", list.ToArray(), bool_0: false);
				Clipboard.SetText(text);
			}
		}

		[WriterCommandDescription("GenerateCreateInstanceCode")]
		protected void GenerateCreateInstanceCode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (frmGenerateCreateInstanceCode frmGenerateCreateInstanceCode = new frmGenerateCreateInstanceCode())
				{
					frmGenerateCreateInstanceCode.ShowDialog(e.EditorControl);
				}
			}
		}

		/// <summary>
		///       文档样式列表
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentContentStyles")]
		protected void DocumentContentStyles(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgDocumentContentStyles dlgDocumentContentStyles = new dlgDocumentContentStyles())
				{
					dlgDocumentContentStyles.Document = e.Document;
					WriterControl.UIShowDialog(e.EditorControl, dlgDocumentContentStyles, null);
				}
			}
		}

		/// <summary>
		///       编辑器控件属性
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("WriterControlProperties")]
		protected void WriterControlProperties(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgProperties dlgProperties = new dlgProperties())
				{
					dlgProperties.ObjectInstance = e.EditorControl;
					WriterControl.UIShowDialog(e.EditorControl, dlgProperties, null);
				}
			}
		}

		/// <summary>
		///       添加服务功能对象
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AddService")]
		public void AddService(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				object parameter = e.Parameter;
				if (parameter != null)
				{
					e.EditorControl.AddServiceInstance(parameter);
				}
			}
		}

		/// <summary>
		///       创建对象实例
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("CreateInstance")]
		protected void CreateInstance(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				string typeName = Convert.ToString(e.Parameter);
				Type controlType = ControlHelper.GetControlType(typeName, typeof(object));
				if (controlType != null)
				{
					ComVisibleAttribute comVisibleAttribute = (ComVisibleAttribute)Attribute.GetCustomAttribute(controlType, typeof(ComVisibleAttribute), inherit: true);
					if (comVisibleAttribute != null && comVisibleAttribute.Value)
					{
						e.Result = Activator.CreateInstance(controlType);
					}
				}
			}
		}

		/// <summary>
		///       清空数据校验结果
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ClearValueValidateResult")]
		protected void ClearValueValidateResult(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.EditOptions.ValueValidateMode != DocumentValueValidateMode.None);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = e.Document.ClearValueValidateResult();
			}
		}

		/// <summary>
		///       对文档数据进行校验
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("DocumentValueValidate")]
		protected void DocumentValueValidate(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.EditOptions.ValueValidateMode != DocumentValueValidateMode.None);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				ValueValidateResultList valueValidateResultList2 = (ValueValidateResultList)(e.Result = e.Document.ValueValidate());
				if (e.ShowUI)
				{
					if (valueValidateResultList2 != null && valueValidateResultList2.Count > 0)
					{
						if (valueValidateResultList2[0].Element != null)
						{
							valueValidateResultList2[0].Element.Focus();
						}
						e.Host.UITools.ShowWarringMessageBox(e.EditorControl, WriterStrings.ValueValidateFail + Environment.NewLine + valueValidateResultList2.ToString());
					}
					else
					{
						e.Host.UITools.ShowMessageBox(e.EditorControl, WriterStrings.ValueValidateOK);
					}
				}
				if (valueValidateResultList2 == null || valueValidateResultList2.Count <= 0)
				{
					return;
				}
				XTextElement element = valueValidateResultList2[0].Element;
				if (element != null)
				{
					element.Focus();
					if (e.ShowUI)
					{
						e.EditorControl.Focus();
					}
				}
			}
		}

		/// <summary>
		///       对文档数据进行校验
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("DocumentValueValidateWithCreateDocumentComments")]
		protected void DocumentValueValidateWithCreateDocumentComments(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Options.EditOptions.ValueValidateMode != DocumentValueValidateMode.None);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				ValueValidateResultList valueValidateResultList2 = (ValueValidateResultList)(e.Result = e.Document.ValueValidateWithCreateDocumentComments());
				if (e.ShowUI)
				{
					if (valueValidateResultList2 != null && valueValidateResultList2.Count > 0)
					{
						if (valueValidateResultList2[0].Element != null)
						{
							valueValidateResultList2[0].Element.Focus();
						}
						e.Host.UITools.ShowWarringMessageBox(e.EditorControl, WriterStrings.ValueValidateFail + Environment.NewLine + valueValidateResultList2.ToString());
					}
					else
					{
						e.Host.UITools.ShowMessageBox(e.EditorControl, WriterStrings.ValueValidateOK);
					}
				}
				if (valueValidateResultList2 == null || valueValidateResultList2.Count <= 0)
				{
					return;
				}
				XTextElement element = valueValidateResultList2[0].Element;
				if (element != null)
				{
					element.Focus();
					if (e.ShowUI)
					{
						e.EditorControl.Focus();
					}
				}
			}
		}

		/// <summary>
		///       立即执行脚本代码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ExecuteScriptImmediately")]
		protected void ExecuteScriptImmediately(object sender, WriterCommandEventArgs e)
		{
			int num = 13;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				string text = e.Parameter as string;
				if (e.ShowUI)
				{
					using (frmScriptEdtior frmScriptEdtior = new frmScriptEdtior())
					{
						if (e.EditorControl != null)
						{
							frmScriptEdtior.Text = e.EditorControl.DialogTitlePrefix + frmScriptEdtior.Text;
						}
						frmScriptEdtior.Document = e.Document;
						frmScriptEdtior.ScriptText = text;
						if (WriterControl.UIShowDialog(e.EditorControl, frmScriptEdtior, null) != DialogResult.OK)
						{
							return;
						}
						text = frmScriptEdtior.ScriptText;
					}
				}
				DocumentScriptEngine documentScriptEngine = new DocumentScriptEngine(e.Document);
				documentScriptEngine.SetImmediatelyMode(immediatelyMode: true, text);
				try
				{
					if (e.EditorControl != null)
					{
						e.EditorControl.Cursor = Cursors.WaitCursor;
					}
					if (documentScriptEngine.Start())
					{
						if (e.Document != null && e.Document.Options.BehaviorOptions.WeakMode)
						{
							documentScriptEngine.Execute("ImmediatelyScriptMethod", null, ThrowException: true);
						}
						else
						{
							documentScriptEngine.method_6("ImmediatelyScriptMethod");
						}
						if (documentScriptEngine.Errors.Count > 0)
						{
							documentScriptEngine.ShowErrorDialog(e.EditorControl);
						}
					}
					else if (e.ShowUI)
					{
						documentScriptEngine.ShowErrorDialog(e.EditorControl);
					}
				}
				finally
				{
					if (e.EditorControl != null)
					{
						e.EditorControl.Cursor = Cursors.Default;
					}
				}
			}
		}

		/// <summary>
		///       编辑VBA脚本代码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("EditVBAScript", ImageResource = "DCSoft.Writer.Commands.Images.CommandEditVBAScript.bmp")]
		protected void EditVBAScript(object sender, WriterCommandEventArgs e)
		{
			int num = 19;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
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
				string text = e.Document.ScriptText;
				if (e.Parameter is string && !string.IsNullOrEmpty((string)e.Parameter))
				{
					text = (string)e.Parameter;
				}
				if (e.ShowUI)
				{
					using (frmScriptEdtior frmScriptEdtior = new frmScriptEdtior())
					{
						if (e.EditorControl != null)
						{
							frmScriptEdtior.Text = e.EditorControl.DialogTitlePrefix + frmScriptEdtior.Text;
						}
						frmScriptEdtior.Document = e.Document;
						frmScriptEdtior.ScriptText = text;
						frmScriptEdtior.ScriptLanguage = e.Document.ScriptLanguage;
						if (WriterControl.UIShowDialog(e.EditorControl, frmScriptEdtior, null) != DialogResult.OK)
						{
							return;
						}
						text = frmScriptEdtior.ScriptText;
					}
				}
				if (!e.DocumentControler.EditorControlReadonly && e.Document.ScriptText != text && e.UIStartEditContent())
				{
					if (e.Document.BeginLogUndo())
					{
						e.Document.UndoList.AddProperty("ScriptText", e.Document.ScriptText, text, e.Document);
						e.Document.EndLogUndo();
					}
					e.Document.ScriptText = text;
					e.Document.UpdateContentVersion();
					e.Document.Modified = true;
					e.Result = true;
					e.Document.OnDocumentContentChanged();
				}
			}
		}

		/// <summary>
		///       显示文档字数统计信息
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("WordCount", ImageResource = "DCSoft.Writer.Commands.Images.CommandWordCount.bmp")]
		protected void WordCount(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.Document != null)
			{
				XTextElementList xTextElementList = new XTextElementList();
				if (e.Document.Selection.Length != 0)
				{
					xTextElementList = e.Document.Selection.ContentElements.Clone();
				}
				else
				{
					foreach (XTextDocumentContentElement element in e.Document.Elements)
					{
						if (!element.IsEmpty)
						{
							xTextElementList.AddRange(element.Content);
						}
					}
				}
				WordCountResult countResult = (WordCountResult)(e.Result = new WordCountResult(e.Document, xTextElementList));
				if (e.ShowUI)
				{
					using (dlgWordCount dlgWordCount = new dlgWordCount())
					{
						if (e.EditorControl != null)
						{
							dlgWordCount.Text = e.EditorControl.DialogTitlePrefix + dlgWordCount.Text;
						}
						dlgWordCount.CountResult = countResult;
						WriterControl.UIShowDialog(e.EditorControl, dlgWordCount, null);
					}
				}
				e.RefreshLevel = UIStateRefreshLevel.None;
			}
		}

		/// <summary>
		///       字符串资源
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ResourceStrings")]
		protected void ResourceStrings(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgResourceStrings dlgResourceStrings = new dlgResourceStrings())
				{
					dlgResourceStrings.WriterControl = e.EditorControl;
					WriterControl.UIShowDialog(e.EditorControl, dlgResourceStrings, null);
					e.EditorControl.InnerViewControl.Invalidate();
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}
	}
}
