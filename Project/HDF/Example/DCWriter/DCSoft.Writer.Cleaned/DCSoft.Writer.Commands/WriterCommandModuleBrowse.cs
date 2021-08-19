using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       只读的浏览文档内容的功能模块
	///       </summary>
	/// <remarks>
	///       该模块中的功能用于滚动浏览文档内容，不会修改文档内容。编制，袁永福。
	///       </remarks>
	[WriterCommandDescription("Browse")]
	internal class WriterCommandModuleBrowse : WriterCommandModule
	{
		private const float AutoZoomRateFlag = 100000f;

		/// <summary>
		///       是否显示标尺
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("RuleVisible")]
		protected void RuleVisible(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				if (e.EditorControl != null)
				{
					e.Checked = e.EditorControl.RuleVisible;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool flag = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.RuleVisible);
				if (e.EditorControl.RuleVisible != flag)
				{
					e.EditorControl.RuleVisible = flag;
				}
			}
		}

		/// <summary>
		///       显示文档元素扩展标记文本
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShowAdornText")]
		protected void ShowAdornText(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgAdornTextSettings dlgAdornTextSettings = new dlgAdornTextSettings())
				{
					dlgAdornTextSettings.ViewOptions = e.EditorControl.DocumentOptions.ViewOptions;
					if (WriterControl.UIShowDialog(e.EditorControl, dlgAdornTextSettings, null) == DialogResult.OK)
					{
						e.EditorControl.InnerViewControl.Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       打开文件所在目录
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("OpenFileDirectory")]
		protected void OpenFileDirectory(object sender, WriterCommandEventArgs e)
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
				string fileName = e.Document.FileName;
				if (!string.IsNullOrEmpty(fileName))
				{
					string directoryName = Path.GetDirectoryName(fileName);
					if (Directory.Exists(directoryName))
					{
						ProcessStartInfo processStartInfo = new ProcessStartInfo();
						processStartInfo.FileName = directoryName;
						processStartInfo.UseShellExecute = true;
						Process.Start(processStartInfo);
					}
				}
			}
		}

		[WriterCommandDescription("RefreshDocument")]
		protected void RefreshDocument(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				e.EditorControl.ResetBodyLayoutOffset();
				e.EditorControl.RefreshDocument();
			}
		}

		/// <summary>
		///       让编辑器控件获得焦点
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Focus")]
		protected void FocusControl(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				e.EditorControl.Focus();
			}
		}

		/// <summary>
		///       从左到右排版
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("LeftToRight")]
		protected void LeftToRight(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				e.Checked = (e.EditorControl != null && e.EditorControl.RightToLeft == System.Windows.Forms.RightToLeft.No);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				e.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       从右到左排版
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("RightToLeft")]
		protected void RightToLeft(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				e.Checked = (e.EditorControl != null && e.EditorControl.RightToLeft == System.Windows.Forms.RightToLeft.Yes);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				e.EditorControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       设置文档网格线样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentGridLineVisible", ImageResource = "DCSoft.Writer.Commands.Images.CommandDocumentGridLineVisible.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = GEnum6.const_33)]
		protected void DocumentGridLineVisible(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				if (e.EditorControl != null)
				{
					e.Checked = e.EditorControl.DocumentOptions.ViewOptions.ShowGridLine;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				if (e.ShowUI)
				{
					e.EditorControl.UITools.ShowWarringMessageBox(e.EditorControl, WriterStrings.RecommentDocumentGridLine);
				}
				e.Result = false;
				DocumentViewOptions viewOptions = e.EditorControl.DocumentOptions.ViewOptions;
				viewOptions.ShowGridLine = WriterUtils.smethod_41(e.Parameter, !viewOptions.ShowGridLine);
				e.Result = viewOptions.ShowGridLine;
				e.RefreshLevel = UIStateRefreshLevel.Current;
				e.EditorControl.InnerViewControl.Invalidate();
			}
		}

		/// <summary>
		///       设置文档网格线样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentGridLine", ImageResource = "DCSoft.Writer.Commands.Images.CommandDocumentGridLineVisible.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = GEnum6.const_33)]
		protected void DocumentGridLine(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				if (e.EditorControl != null)
				{
					e.Checked = e.EditorControl.DocumentOptions.ViewOptions.ShowGridLine;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				if (e.ShowUI)
				{
					e.EditorControl.UITools.ShowWarringMessageBox(e.EditorControl, WriterStrings.RecommentDocumentGridLine);
				}
				e.Result = false;
				GridLineSettings gridLineSettings = null;
				if (e.Parameter is GridLineSettings)
				{
					gridLineSettings = (GridLineSettings)e.Parameter;
				}
				else
				{
					gridLineSettings = new GridLineSettings();
					DocumentViewOptions viewOptions = e.EditorControl.DocumentOptions.ViewOptions;
					gridLineSettings.ShowGridLine = WriterUtils.smethod_41(e.Parameter, viewOptions.ShowGridLine);
					gridLineSettings.GridLineColor = viewOptions.GridLineColor;
					gridLineSettings.PrintGridLine = viewOptions.PrintGridLine;
					gridLineSettings.LineStyle = viewOptions.GridLineStyle;
				}
				if (e.ShowUI)
				{
					using (dlgDocmentGridLine dlgDocmentGridLine = new dlgDocmentGridLine())
					{
						dlgDocmentGridLine.GridSettings = gridLineSettings;
						dlgDocmentGridLine.Document = e.Document;
						if (dlgDocmentGridLine.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
					}
				}
				DocumentViewOptions viewOptions2 = e.EditorControl.DocumentOptions.ViewOptions;
				viewOptions2.ShowGridLine = gridLineSettings.ShowGridLine;
				viewOptions2.GridLineColor = gridLineSettings.GridLineColor;
				viewOptions2.PrintGridLine = gridLineSettings.PrintGridLine;
				viewOptions2.GridLineStyle = gridLineSettings.LineStyle;
				e.Result = true;
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.EditorControl.InnerViewControl.Invalidate();
			}
		}

		/// <summary>
		///       新的设置文档网格线样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentGridLineNew", ImageResource = "DCSoft.Writer.Commands.Images.CommandDocumentGridLineVisible.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = GEnum6.const_33)]
		protected void DocumentGridLineNew(object sender, WriterCommandEventArgs e)
		{
			int num = 16;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
				if (e.Document != null)
				{
					e.Checked = (e.Document.Body.GridLine != null && e.Document.Body.GridLine.Visible);
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				DCGridLineInfo dCGridLineInfo = null;
				dCGridLineInfo = ((e.Parameter is DCGridLineInfo) ? ((DCGridLineInfo)e.Parameter) : ((e.Document.PageSettings.DocumentGridLine != null) ? e.Document.PageSettings.DocumentGridLine.method_5() : new DCGridLineInfo()));
				if (e.ShowUI)
				{
					using (dlgDCGridLineInfoForPageSettings dlgDCGridLineInfoForPageSettings = new dlgDCGridLineInfoForPageSettings())
					{
						dlgDCGridLineInfoForPageSettings.InputGridLineInfo = dCGridLineInfo;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDCGridLineInfoForPageSettings, null) != DialogResult.OK)
						{
							return;
						}
					}
				}
				if (e.Document.BeginLogUndo())
				{
					e.Document.UndoList.AddProperty("DocumentGridLine", e.Document.PageSettings.DocumentGridLine, dCGridLineInfo, e.Document.PageSettings);
					e.Document.UndoList.AddMethod(UndoMethodTypes.RefreshLayout);
					e.Document.EndLogUndo();
				}
				e.Document.PageSettings.DocumentGridLine = dCGridLineInfo;
				e.EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: true);
				e.Result = true;
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       显示编辑器命令清单对话框
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("WriterCommandList")]
		protected void WriterCommandList(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Host != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgCommandList dlgCommandList = new dlgCommandList())
				{
					dlgCommandList.AppHost = e.Host;
					dlgCommandList.ShowDialog(e.EditorControl);
				}
			}
		}

		/// <summary>
		///       显示关于对话框
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AboutControl", ImageResource = "DCSoft.Writer.Commands.Images.CommandAboutControl.bmp")]
		protected void AboutControl(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = e.ShowUI;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgAbout dlgAbout = new dlgAbout())
				{
					if (e.EditorControl != null)
					{
						dlgAbout.Text = e.EditorControl.DialogTitlePrefix + dlgAbout.Text;
					}
					dlgAbout.ShowDialog(e.EditorControl);
				}
			}
		}

		[WriterCommandDescription("MoveToPage", ReturnValueType = typeof(bool))]
		protected void MoveToPage(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				XTextDocument document = e.Document;
				PrintPage printPage = null;
				if (e.Parameter is PrintPage)
				{
					printPage = (PrintPage)e.Parameter;
					if (!document.Pages.Contains(printPage))
					{
						printPage = null;
					}
				}
				else if (e.Parameter is int || e.Parameter is short || e.Parameter is long || e.Parameter is float || e.Parameter is double || e.Parameter is byte)
				{
					int num = (int)e.Parameter;
					printPage = document.Pages.SafeGet(num - 1);
				}
				else if (e.Parameter is string)
				{
					int num = 0;
					if (int.TryParse((string)e.Parameter, out num))
					{
						printPage = document.Pages.SafeGet(num - 1);
					}
				}
				if (printPage != null)
				{
					foreach (XTextLine line in document.Body.Lines)
					{
						if (line.OwnerPage == printPage)
						{
							XTextElement xTextElement = line[0];
							if (xTextElement is XTextTableElement || xTextElement is XTextSectionElement)
							{
								xTextElement = xTextElement.FirstContentElementInPublicContent;
							}
							int num = document.Body.Content.IndexOf(xTextElement);
							if (xTextElement is XTextParagraphListItemElement)
							{
								num++;
							}
							num = document.Body.Content.FixIndexForStrictFormViewMode(num, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: true);
							document.Body.Content.MoveToPosition(num);
							_ = printPage.ClientBounds;
							e.EditorControl.ScrollToCaretExt(ScrollToViewStyle.Top);
							e.Result = true;
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       移动位置
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("MoveTo")]
		protected void MoveTo(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				MoveTarget moveTarget = MoveTarget.None;
				if (e.Parameter is MoveTarget)
				{
					moveTarget = (MoveTarget)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					try
					{
						moveTarget = (MoveTarget)Enum.Parse(typeof(MoveTarget), (string)e.Parameter, ignoreCase: true);
					}
					catch
					{
					}
				}
				if (moveTarget != 0)
				{
					e.Document.Content.AutoClearSelection = true;
					e.Document.Content.MoveToTarget(moveTarget);
				}
			}
		}

		/// <summary>
		///       移动位置
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("MoveToPosition", ReturnValueType = typeof(bool))]
		protected void MoveToPosition(object sender, WriterCommandEventArgs e)
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
				e.Result = false;
				if (e.Parameter != null)
				{
					int num = WriterUtils.smethod_40(e.Parameter, -1);
					if (num >= 0 && num < e.Document.Content.Count)
					{
						e.Document.Content.AutoClearSelection = true;
						e.Result = e.Document.Content.MoveToPosition(num);
						e.EditorControl.ScrollToCaret();
					}
				}
			}
		}

		/// <summary>
		///       向上移动一页
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("MovePageDown", ShortcutKey = Keys.Next)]
		protected void MovePageDown(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				Point autoScrollPosition = e.EditorControl.InnerViewControl.AutoScrollPosition;
				e.Document.Content.MoveStep(e.Document.PageSettings.ViewClientHeight);
				e.Document.EditorControl.UpdateTextCaret();
				Point autoScrollPosition2 = e.EditorControl.InnerViewControl.AutoScrollPosition;
				if (autoScrollPosition == autoScrollPosition2)
				{
					int height = e.EditorControl.InnerViewControl.Transform.UnTransformSize(1, (int)e.Document.PageSettings.ViewClientHeight).Height;
					autoScrollPosition2 = new Point(-autoScrollPosition2.X, height - autoScrollPosition2.Y);
					e.EditorControl.InnerViewControl.SetAutoScrollPosition(autoScrollPosition2);
				}
			}
		}

		/// <summary>
		///       向上移动一页
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("MovePageUp", ShortcutKey = Keys.Prior)]
		protected void MovePageUp(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				Point autoScrollPosition = e.EditorControl.InnerViewControl.AutoScrollPosition;
				e.Document.Content.MoveStep(0f - e.Document.PageSettings.ViewPaperHeight);
				e.Document.EditorControl.UpdateTextCaret();
				Point autoScrollPosition2 = e.EditorControl.InnerViewControl.AutoScrollPosition;
				if (autoScrollPosition == autoScrollPosition2)
				{
					int height = e.EditorControl.InnerViewControl.Transform.UnTransformSize(1, (int)e.Document.PageSettings.ViewClientHeight).Height;
					autoScrollPosition2 = new Point(-autoScrollPosition2.X, -height - autoScrollPosition2.Y);
					e.EditorControl.InnerViewControl.SetAutoScrollPosition(autoScrollPosition2);
				}
			}
		}

		/// <summary>
		///       向上移动一列
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("MoveUp", ShortcutKey = Keys.Up)]
		protected void MoveUp(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				e.Document.Content.MoveUpOneLine();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向右移动一列
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("MoveRight", ShortcutKey = Keys.Right)]
		protected void MoveRight(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				ContentLayoutDirectionStyle currentLayoutDirection = e.Document.Content.CurrentLayoutDirection;
				if (currentLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					e.Document.Content.MoveLeft();
				}
				else
				{
					e.Document.Content.MoveRight();
				}
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向左移动一列
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("MoveLeft", ShortcutKey = Keys.Left)]
		protected void MoveLeft(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				if (e.Document.Content.CurrentLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					e.Document.Content.MoveRight();
				}
				else
				{
					e.Document.Content.MoveLeft();
				}
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向下移动一行
		///       </summary>
		/// <param name="send">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("MoveDown", ShortcutKey = Keys.Down)]
		protected void MoveDown(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				e.Document.Content.MoveDownOneLine();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       移动到行首
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("MoveHome", ShortcutKey = Keys.Home)]
		protected void MoveHome(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				e.Document.Content.MoveHome();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       移动到行尾
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("MoveEnd", ShortcutKey = Keys.End)]
		protected void MoveEnd(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = true;
				e.Document.Content.MoveEnd();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向上移动一页
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ShiftMovePageDown", ShortcutKey = (Keys.RButton | Keys.Space | Keys.Shift))]
		protected void ShiftMovePageDown(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				Point autoScrollPosition = e.EditorControl.InnerViewControl.AutoScrollPosition;
				e.Document.Content.MoveStep(e.Document.PageSettings.ViewClientHeight);
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
				Point autoScrollPosition2 = e.EditorControl.InnerViewControl.AutoScrollPosition;
				if (autoScrollPosition == autoScrollPosition2)
				{
					int height = e.EditorControl.InnerViewControl.Transform.UnTransformSize(1, (int)e.Document.PageSettings.ViewClientHeight).Height;
					autoScrollPosition2 = new Point(-autoScrollPosition2.X, height - autoScrollPosition2.Y);
					e.EditorControl.InnerViewControl.SetAutoScrollPosition(autoScrollPosition2);
				}
			}
		}

		/// <summary>
		///       向上移动一页
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ShiftMovePageUp", ShortcutKey = (Keys.LButton | Keys.Space | Keys.Shift))]
		protected void ShiftMovePageUp(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				Point autoScrollPosition = e.EditorControl.InnerViewControl.AutoScrollPosition;
				e.Document.Content.MoveStep(0f - e.Document.PageSettings.ViewClientHeight);
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
				Point autoScrollPosition2 = e.EditorControl.InnerViewControl.AutoScrollPosition;
				if (autoScrollPosition == autoScrollPosition2)
				{
					int height = e.EditorControl.InnerViewControl.Transform.UnTransformSize(1, (int)e.Document.PageSettings.ViewClientHeight).Height;
					autoScrollPosition2 = new Point(-autoScrollPosition2.X, -height - autoScrollPosition2.Y);
					e.EditorControl.InnerViewControl.SetAutoScrollPosition(autoScrollPosition2);
				}
			}
		}

		/// <summary>
		///       向上移动一列
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ShiftMoveUp", ShortcutKey = (Keys.RButton | Keys.MButton | Keys.Space | Keys.Shift))]
		protected void ShiftMoveUp(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				e.Document.Content.MoveUpOneLine();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向右移动一列
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ShiftMoveRight", ShortcutKey = (Keys.LButton | Keys.RButton | Keys.MButton | Keys.Space | Keys.Shift))]
		protected void ShiftMoveRight(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				if (e.Document.Content.CurrentLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					e.Document.Content.MoveLeft();
				}
				else
				{
					e.Document.Content.MoveRight();
				}
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向左移动一列
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ShiftMoveLeft", ShortcutKey = (Keys.LButton | Keys.MButton | Keys.Space | Keys.Shift))]
		protected void ShiftMoveLeft(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				if (e.Document.Content.CurrentLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
				{
					e.Document.Content.MoveRight();
				}
				else
				{
					e.Document.Content.MoveLeft();
				}
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		[WriterCommandDescription("SelectLine")]
		protected void SelectLine(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				if (!e.Document.CurrentElement.OwnerLine.IsEmptyLine)
				{
					e.EditorControl.ExecuteCommand("MoveHome", showUI: false, null);
					e.EditorControl.ExecuteCommand("ShiftMoveEnd", showUI: false, null);
				}
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       向下移动一行
		///       </summary>
		/// <param name="send">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShiftMoveDown", ShortcutKey = (Keys.Back | Keys.Space | Keys.Shift))]
		protected void ShiftMoveDown(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				e.Document.Content.MoveDownOneLine();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       移动到行首
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShiftMoveHome", ShortcutKey = (Keys.MButton | Keys.Space | Keys.Shift))]
		protected void ShiftMoveHome(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				e.Document.Content.MoveHome();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		/// <summary>
		///       移动到行尾
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShiftMoveEnd", ShortcutKey = (Keys.LButton | Keys.RButton | Keys.Space | Keys.Shift))]
		protected void ShiftMoveEnd(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.AutoClearSelection = false;
				e.Document.Content.MoveEnd();
				e.EditorControl.UpdateTextCaret();
				e.EditorControl.ScrollToCaret();
			}
		}

		[WriterCommandDescription("CtlMoveUp", ShortcutKey = (Keys.RButton | Keys.MButton | Keys.Space | Keys.Control))]
		protected void CtlMoveUp(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				Point autoScrollPosition = e.EditorControl.InnerViewControl.AutoScrollPosition;
				int height = e.EditorControl.InnerViewControl.Transform.UnTransformSize(1, (int)e.Document.DefaultStyle.DefaultLineHeight).Height;
				autoScrollPosition = new Point(-autoScrollPosition.X, -height - autoScrollPosition.Y);
				e.EditorControl.InnerViewControl.SetAutoScrollPosition(autoScrollPosition);
				e.EditorControl.InnerViewControl.method_1();
			}
		}

		/// <summary>
		///       按住Ctl键向下移动一行
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("CtlMoveDown", ShortcutKey = (Keys.Back | Keys.Space | Keys.Control))]
		protected void CtlMoveDown(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				Point autoScrollPosition = e.EditorControl.InnerViewControl.AutoScrollPosition;
				int height = e.EditorControl.InnerViewControl.Transform.UnTransformSize(1, (int)e.Document.DefaultStyle.DefaultLineHeight).Height;
				autoScrollPosition = new Point(-autoScrollPosition.X, height - autoScrollPosition.Y);
				e.EditorControl.InnerViewControl.SetAutoScrollPosition(autoScrollPosition);
				e.EditorControl.InnerViewControl.method_1();
			}
		}

		/// <summary>
		///       全选文档内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SelectAll", ShortcutKey = (Keys)131137)]
		protected void SelectAll(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Document.Content.SelectAll();
				e.EditorControl.InnerViewControl.Invalidate();
				e.EditorControl.UpdateTextCaret();
			}
		}

		/// <summary>
		///       区域选择视图模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BoundsSelectionViewMode", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_45)]
		protected void BoundsSelectionViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (e.EditorControl.ExtViewMode == WriterControlExtViewMode.BoundsSelection);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || e.EditorControl == null)
				{
					return;
				}
				e.EditorControl.ResetBodyLayoutOffset();
				bool flag = e.EditorControl.ExtViewMode == WriterControlExtViewMode.BoundsSelection;
				bool flag2 = WriterUtils.smethod_41(e.Parameter, !flag);
				if (flag != flag2)
				{
					if (flag2)
					{
						e.EditorControl.ExtViewMode = WriterControlExtViewMode.BoundsSelection;
					}
					else
					{
						e.EditorControl.ExtViewMode = WriterControlExtViewMode.Normal;
						e.EditorControl.UpdatePages();
					}
				}
				e.Result = (e.EditorControl.ExtViewMode == WriterControlExtViewMode.BoundsSelection);
			}
		}

		/// <summary>
		///       断点续打模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("JumpPrintMode", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_42)]
		protected void JumpPrintMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = (e.EditorControl.ViewMode == PageViewMode.Page);
				e.Checked = (e.EditorControl.ExtViewMode == WriterControlExtViewMode.JumpPrint);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || e.EditorControl == null)
				{
					return;
				}
				bool flag = e.EditorControl.ExtViewMode == WriterControlExtViewMode.JumpPrint;
				bool flag2 = WriterUtils.smethod_41(e.Parameter, !flag);
				if (flag != flag2)
				{
					e.EditorControl.ResetBodyLayoutOffset();
					if (flag2)
					{
						bool flag3 = e.EditorControl.ExtViewMode == WriterControlExtViewMode.BoundsSelection;
						e.EditorControl.ExtViewMode = WriterControlExtViewMode.JumpPrint;
						e.EditorControl.ResetBodyLayoutOffset();
						if (flag3)
						{
							e.EditorControl.UpdatePages();
						}
					}
					else
					{
						e.EditorControl.ExtViewMode = WriterControlExtViewMode.Normal;
					}
				}
				e.Result = (e.EditorControl.ExtViewMode == WriterControlExtViewMode.JumpPrint);
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       断点续打模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("OffsetJumpPrintMode", ReturnValueType = typeof(bool))]
		protected void OffsetJumpPrintMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = (e.EditorControl.ViewMode == PageViewMode.Page);
				e.Checked = (e.EditorControl.ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || e.EditorControl == null)
				{
					return;
				}
				bool flag = e.EditorControl.ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint;
				bool flag2 = WriterUtils.smethod_41(e.Parameter, !flag);
				if (flag != flag2)
				{
					if (flag2)
					{
						bool flag3 = e.EditorControl.ExtViewMode == WriterControlExtViewMode.BoundsSelection;
						e.EditorControl.ExtViewMode = WriterControlExtViewMode.OffsetJumpPrint;
						if (flag3)
						{
							e.EditorControl.UpdatePages();
						}
					}
					else
					{
						e.EditorControl.ResetBodyLayoutOffset();
						e.EditorControl.ExtViewMode = WriterControlExtViewMode.Normal;
					}
				}
				e.Result = (e.EditorControl.ExtViewMode == WriterControlExtViewMode.OffsetJumpPrint);
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		[WriterCommandDescription("JumpPrintModeBySubDocument", FunctionID = GEnum6.const_42)]
		protected void JumpPrintModeBySubDocument(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					foreach (XTextElement element in e.Document.Body.Elements)
					{
						if (element is XTextSubDocumentElement)
						{
							e.Enabled = true;
							break;
						}
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.Document != null)
			{
				XTextSubDocumentElement xTextSubDocumentElement = null;
				foreach (XTextElement element2 in e.Document.Body.Elements)
				{
					if (element2 is XTextSubDocumentElement)
					{
						XTextSubDocumentElement xTextSubDocumentElement2 = (XTextSubDocumentElement)element2;
						if (!xTextSubDocumentElement2.Printed)
						{
							if (xTextSubDocumentElement != null)
							{
								float position = xTextSubDocumentElement.PrintPositionInPage + xTextSubDocumentElement.Height;
								JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
								jumpPrintInfo.Position = position;
								e.EditorControl.SetJumpPrintPositionTo(xTextSubDocumentElement2, autoSetStartPageIndex: false, useTopPosition: true);
							}
							break;
						}
						xTextSubDocumentElement = xTextSubDocumentElement2;
					}
				}
			}
		}

		/// <summary>
		///       根据文档选择的内容设置续打模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("JumpPrintModeBySelection", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_42)]
		protected void JumpPrintModeBySelection(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
				}
				else
				{
					e.Enabled = (e.EditorControl.Selection.Length != 0);
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.EditorControl.Selection.Length != 0 && e.EditorControl != null)
				{
					e.EditorControl.EnableJumpPrint = true;
					XTextElement xTextElement = null;
					XTextElement xTextElement2 = null;
					xTextElement = e.EditorControl.Selection.ContentElements.FirstElement;
					xTextElement2 = e.EditorControl.Selection.ContentElements.LastElement;
					JumpPrintInfo jumpPrintInfo = e.Document.GetJumpPrintInfo(xTextElement, xTextElement2);
					if (jumpPrintInfo != null)
					{
						e.EditorControl.JumpPrint = jumpPrintInfo;
						e.EditorControl.InnerViewControl.Invalidate();
					}
					else
					{
						e.EditorControl.ResetBodyLayoutOffset();
					}
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       清除续打模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearJumpPrintMode", ReturnValueType = typeof(bool))]
		protected void ClearJumpPrintMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.EditorControl != null)
			{
				e.EditorControl.EnableJumpPrint = false;
				e.EditorControl.JumpPrint.PageIndex = -1;
				e.EditorControl.JumpPrint.SetNativePosition(0f);
				e.EditorControl.JumpPrint.SetNativeEndPosition(0f);
				e.EditorControl.JumpPrint.Position = 0f;
				e.EditorControl.JumpPrint.EndPageIndex = -1;
				e.EditorControl.JumpPrint.EndPosition = 0f;
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       编辑器是否处于设计时模式
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("DesignMode", ImageResource = "DCSoft.Writer.Commands.Images.CommandDesignMode.bmp", ReturnValueType = typeof(bool))]
		protected void DesignMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = e.EditorControl.DocumentOptions.BehaviorOptions.DesignMode;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool bool_ = !e.EditorControl.DocumentOptions.BehaviorOptions.DesignMode;
				bool_ = WriterUtils.smethod_41(e.Parameter, bool_);
				e.EditorControl.DocumentOptions.BehaviorOptions.DesignMode = bool_;
				e.Document.Options.BehaviorOptions.DesignMode = bool_;
				e.Result = e.EditorControl.DocumentOptions.BehaviorOptions.DebugMode;
				e.EditorControl.RefreshDocument();
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.Current;
			}
		}

		/// <summary>
		///       编辑器是否处于调试模式
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("DebugMode", ReturnValueType = typeof(bool))]
		protected void DebugMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = e.EditorControl.DocumentOptions.BehaviorOptions.DebugMode;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool flag = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.DocumentOptions.BehaviorOptions.DebugMode);
				e.EditorControl.DocumentOptions.BehaviorOptions.DebugMode = flag;
				e.Document.Options.BehaviorOptions.DebugMode = flag;
				e.RefreshLevel = UIStateRefreshLevel.Current;
				e.Result = flag;
			}
		}

		/// <summary>
		///       页面视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ComplexViewMode", FunctionID = GEnum6.const_118)]
		protected void ComplexViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null || e.EditorControl.ReadViewMode)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				DocumentSecurityOptions securityOptions = e.Document.Options.SecurityOptions;
				e.Checked = (securityOptions.ShowLogicDeletedContent && securityOptions.ShowPermissionMark && securityOptions.ShowPermissionTip);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				DocumentSecurityOptions securityOptions = e.Document.Options.SecurityOptions;
				securityOptions.ShowLogicDeletedContent = true;
				securityOptions.ShowPermissionMark = true;
				securityOptions.ShowPermissionTip = true;
				if (e.EditorControl != null)
				{
					securityOptions = e.EditorControl.DocumentOptions.SecurityOptions;
					securityOptions.ShowLogicDeletedContent = true;
					securityOptions.ShowPermissionMark = true;
					securityOptions.ShowPermissionTip = true;
				}
				e.EditorControl.RefreshDocument();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       页面视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("CleanViewMode", FunctionID = GEnum6.const_117)]
		protected void CleanViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				DocumentSecurityOptions securityOptions = e.Document.Options.SecurityOptions;
				e.Checked = (!securityOptions.ShowLogicDeletedContent && !securityOptions.ShowPermissionMark && !securityOptions.ShowPermissionTip);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				DocumentSecurityOptions securityOptions = e.Document.Options.SecurityOptions;
				securityOptions.ShowLogicDeletedContent = false;
				securityOptions.ShowPermissionMark = false;
				securityOptions.ShowPermissionTip = false;
				if (e.EditorControl != null)
				{
					securityOptions = e.EditorControl.DocumentOptions.SecurityOptions;
					securityOptions.ShowLogicDeletedContent = false;
					securityOptions.ShowPermissionMark = false;
					securityOptions.ShowPermissionTip = false;
				}
				e.EditorControl.RefreshDocument();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       阅读版式视图模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ReadViewMode", ImageResource = "DCSoft.Writer.Commands.Images.CommandReadViewMode.bmp")]
		protected void ReadViewMode(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				if (e.Enabled)
				{
					e.Checked = e.EditorControl.ReadViewMode;
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.EditorControl.ResetBodyLayoutOffset();
				bool flag;
				if ((flag = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.ReadViewMode)) == e.EditorControl.ReadViewMode)
				{
					return;
				}
				e.RefreshLevel = UIStateRefreshLevel.All;
				Dictionary<string, object> session;
				if (flag)
				{
					session = e.Session;
					session["readonly"] = e.EditorControl.Readonly;
					session["viewmode"] = e.EditorControl.ViewMode;
					session["formview"] = e.EditorControl.FormView;
					session["comment"] = e.EditorControl.CommentVisibility;
					e.EditorControl.ReadViewMode = true;
					e.EditorControl.Readonly = true;
					e.EditorControl.ViewMode = PageViewMode.Page;
					e.EditorControl.FormView = DCSoft.Writer.Controls.FormViewMode.Disable;
					e.EditorControl.CommentVisibility = FunctionControlVisibility.Hide;
					e.EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: true);
					return;
				}
				session = e.Session;
				e.EditorControl.ReadViewMode = false;
				if (session.ContainsKey("readonly"))
				{
					e.EditorControl.Readonly = (bool)session["readonly"];
				}
				if (session.ContainsKey("viewmode"))
				{
					e.EditorControl.ViewMode = (PageViewMode)session["viewmode"];
				}
				if (session.ContainsKey("formview"))
				{
					e.EditorControl.FormView = (FormViewMode)session["formview"];
				}
				if (session.ContainsKey("comment"))
				{
					e.EditorControl.CommentVisibility = (FunctionControlVisibility)session["comment"];
				}
				e.EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: true);
			}
		}

		/// <summary>
		///       页面视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FormViewMode", ReturnValueType = typeof(FormViewMode), FunctionID = GEnum6.const_119)]
		protected void FormViewMode(object sender, WriterCommandEventArgs e)
		{
			int num = 10;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null || e.EditorControl.ReadViewMode)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (e.EditorControl.FormView == DCSoft.Writer.Controls.FormViewMode.Normal || e.EditorControl.FormView == DCSoft.Writer.Controls.FormViewMode.Strict);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				FormViewMode formViewMode = e.EditorControl.FormView;
				if (e.Parameter is FormViewMode)
				{
					formViewMode = (FormViewMode)e.Parameter;
				}
				else if (e.Parameter is bool)
				{
					formViewMode = (((bool)e.Parameter) ? DCSoft.Writer.Controls.FormViewMode.Strict : DCSoft.Writer.Controls.FormViewMode.Disable);
				}
				else if (!(e.Parameter is string))
				{
					formViewMode = ((formViewMode == DCSoft.Writer.Controls.FormViewMode.Disable) ? DCSoft.Writer.Controls.FormViewMode.Strict : DCSoft.Writer.Controls.FormViewMode.Disable);
				}
				else
				{
					string strA = (string)e.Parameter;
					if (string.Compare(strA, "Strict", ignoreCase: true) == 0)
					{
						formViewMode = DCSoft.Writer.Controls.FormViewMode.Strict;
					}
					else if (string.Compare(strA, "Normal", ignoreCase: true) == 0)
					{
						formViewMode = DCSoft.Writer.Controls.FormViewMode.Normal;
					}
					else if (string.Compare(strA, "Disable", ignoreCase: true) == 0)
					{
						formViewMode = DCSoft.Writer.Controls.FormViewMode.Disable;
					}
					else if (string.Compare(strA, "true", ignoreCase: true) == 0)
					{
						formViewMode = DCSoft.Writer.Controls.FormViewMode.Strict;
					}
					else if (string.Compare(strA, "false", ignoreCase: true) == 0)
					{
						formViewMode = DCSoft.Writer.Controls.FormViewMode.Disable;
					}
				}
				e.EditorControl.FormView = formViewMode;
				e.EditorControl.ReadViewMode = false;
				if (e.Document != null)
				{
					e.Document.Content.method_46();
				}
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = formViewMode;
			}
		}

		/// <summary>
		///       显示或隐藏表单按钮
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShowFormButton")]
		protected void ShowFormButton(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				if (e.Enabled)
				{
					e.Checked = e.EditorControl.DocumentOptions.ViewOptions.ShowFormButton;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool flag = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.DocumentOptions.ViewOptions.ShowFormButton);
				if (e.EditorControl.DocumentOptions.ViewOptions.ShowFormButton != flag)
				{
					e.EditorControl.DocumentOptions.ViewOptions.ShowFormButton = flag;
					e.EditorControl.RefreshDocument();
					e.RefreshLevel = UIStateRefreshLevel.Current;
				}
			}
		}

		/// <summary>
		///       页面视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AutoLineViewMode", FunctionID = GEnum6.const_114)]
		protected void AutoLineViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null || e.EditorControl.ReadViewMode)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (e.EditorControl.ViewMode == PageViewMode.AutoLine);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.EditorControl.ResetBodyLayoutOffset();
				e.EditorControl.EnableJumpPrint = false;
				e.EditorControl.ViewMode = PageViewMode.AutoLine;
				e.EditorControl.ReadViewMode = false;
				e.EditorControl.RefreshDocument();
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       页面视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("PageViewMode", ImageResource = "DCSoft.Writer.Commands.Images.CommandPageViewMode.bmp", FunctionID = GEnum6.const_115)]
		protected void PageViewModeFunction(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null || e.EditorControl.ReadViewMode)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (e.EditorControl.ViewMode == PageViewMode.Page);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.EditorControl.ResetBodyLayoutOffset();
				e.EditorControl.EnableJumpPrint = false;
				e.EditorControl.ViewMode = PageViewMode.Page;
				e.EditorControl.ReadViewMode = false;
				e.EditorControl.RefreshDocument();
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       普通视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("NormalViewMode", ImageResource = "DCSoft.Writer.Commands.Images.CommandNormalViewMode.bmp", FunctionID = GEnum6.const_116)]
		protected void NormalViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null || e.EditorControl.ReadViewMode)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (e.EditorControl.ViewMode == PageViewMode.Normal);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.EditorControl.ResetBodyLayoutOffset();
				e.EditorControl.EnableJumpPrint = false;
				e.EditorControl.ViewMode = PageViewMode.Normal;
				e.EditorControl.RefreshDocument();
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       普通居中视图方式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("NormalCenterViewMode", FunctionID = GEnum6.const_116)]
		protected void NormalCenterViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null || e.EditorControl.ReadViewMode)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (e.EditorControl.ViewMode == PageViewMode.NormalCenter);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.EditorControl.ResetBodyLayoutOffset();
				e.EditorControl.EnableJumpPrint = false;
				e.EditorControl.ViewMode = PageViewMode.NormalCenter;
				e.EditorControl.RefreshDocument();
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       显示单元格背景编号
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShowBackgroundCellID")]
		protected void ShowBackgroundCellID(object sender, WriterCommandEventArgs e)
		{
			bool showBackgroundCellID;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = e.EditorControl.DocumentOptions.ViewOptions.ShowBackgroundCellID;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && (showBackgroundCellID = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.DocumentOptions.ViewOptions.ShowBackgroundCellID)) != e.EditorControl.DocumentOptions.ViewOptions.ShowBackgroundCellID)
			{
				e.EditorControl.DocumentOptions.ViewOptions.ShowBackgroundCellID = showBackgroundCellID;
				e.EditorControl.InnerViewControl.Invalidate();
				e.RefreshLevel = UIStateRefreshLevel.Current;
			}
		}

		/// <summary>
		///       放大
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ZoomIn", ImageResource = "DCSoft.Writer.Commands.Images.CommandZoomIn.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_120)]
		protected void ZoomIn(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.XZoomRate < 5f);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				float xZoomRate = e.EditorControl.XZoomRate;
				xZoomRate = ((!(xZoomRate < 1f) || !((double)xZoomRate > 0.9)) ? (xZoomRate * 1.1f) : 1f);
				SetZoomRate(e, xZoomRate);
			}
		}

		/// <summary>
		///       缩小
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ZoomOut", ImageResource = "DCSoft.Writer.Commands.Images.CommandZoomOut.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_120)]
		protected void ZoomOut(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && (double)e.EditorControl.XZoomRate > 0.2);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				float xZoomRate = e.EditorControl.XZoomRate;
				xZoomRate = ((!(xZoomRate > 1f) || !((double)xZoomRate < 1.1)) ? (xZoomRate * 0.9f) : 1f);
				SetZoomRate(e, xZoomRate);
			}
		}

		/// <summary>
		///       设置缩放 比率
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Zoom", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_120)]
		protected void Zoom(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				float result = float.NaN;
				if (e.Parameter is float || e.Parameter is double)
				{
					result = Convert.ToSingle(e.Parameter);
				}
				else if (e.Parameter is string)
				{
					string text = (string)e.Parameter;
					text = text.Trim();
					if (string.Compare(text, "auto", ignoreCase: true) == 0)
					{
						result = 100000f;
					}
					else
					{
						float num2 = 1f;
						if (text.EndsWith("%"))
						{
							text = text.Substring(0, text.Length - 1);
							num2 = 0.01f;
						}
						result = (float.TryParse(text, out result) ? (result * num2) : float.NaN);
					}
				}
				if (!float.IsNaN(result))
				{
					SetZoomRate(e, result);
				}
			}
		}

		/// <summary>
		///       设置缩放 比率
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ZoomAuto", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_121)]
		protected void ZoomAuto(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				SetZoomRate(e, 100000f);
			}
		}

		/// <summary>
		///       重新设置缩放比率为原始大小
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ZoomReset", FunctionID = GEnum6.const_120)]
		protected void ZoomReset(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				SetZoomRate(e, 1f);
				e.Result = true;
			}
		}

		private void SetZoomRate(WriterCommandEventArgs args, float rate)
		{
			if (rate == 100000f)
			{
				if (!args.EditorControl.AutoZoom)
				{
					args.EditorControl.AutoZoom = true;
					args.EditorControl.UpdateForAutoZoom(forceLayout: true);
					args.RefreshLevel = UIStateRefreshLevel.All;
					args.Result = true;
				}
				return;
			}
			args.EditorControl.AutoZoom = false;
			rate = args.EditorControl.method_24(rate);
			if (args.EditorControl.XZoomRate != rate)
			{
				args.EditorControl.SetZoomRate(rate);
				args.EditorControl.UpdatePages();
				args.EditorControl.UpdateTextCaret();
				args.EditorControl.ScrollToCaret();
				if (args.EditorControl.ControlHostManger != null)
				{
					args.EditorControl.ControlHostManger.UpdateHostWindowsControlPosition();
				}
				args.RefreshLevel = UIStateRefreshLevel.All;
				args.Result = true;
				args.EditorControl.vmethod_36(new WriterEventArgs(args.EditorControl, args.Document, null));
			}
		}

		/// <summary>
		///       显示调试输出窗口
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DebugOutputWindow", ImageResource = "DCSoft.Writer.Commands.Images.CommandDebugOutputWindow.bmp")]
		protected void DebugOutputWindow(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				frmDebugOutput frmDebugOutput = (frmDebugOutput)e.EditorControl.ToolWindows.method_0(typeof(frmDebugOutput));
				if (frmDebugOutput == null)
				{
					frmDebugOutput = new frmDebugOutput();
					frmDebugOutput.Owner = e.EditorControl.FindForm();
					e.EditorControl.ToolWindows.Add(frmDebugOutput);
				}
				if (frmDebugOutput.Visible)
				{
					frmDebugOutput.Activate();
				}
				else
				{
					WriterControl.UIShowForm(e.EditorControl, frmDebugOutput);
				}
				if (e.EditorControl != null)
				{
					e.EditorControl.DocumentOptions.BehaviorOptions.DebugMode = true;
				}
			}
		}

		/// <summary>
		///       显示所有的隐藏元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DisplayWhole")]
		protected void DisplayWhole(object sender, WriterCommandEventArgs e)
		{
			int num = 9;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && !e.EditorControl.RuntimeReadonly)
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
				if (e.UIStartEditContent())
				{
					int num2 = 0;
					XTextElementList allElements = e.EditorControl.Document.GetAllElements();
					if (allElements != null && allElements.Count > 0)
					{
						e.Document.BeginLogUndo();
						foreach (XTextElement item in allElements)
						{
							if (e.DocumentControler.CanModify(item, DomAccessFlags.Normal) && !item.Visible && e.Document.CanLogUndo)
							{
								item.Visible = true;
								num2++;
								e.Document.UndoList.AddProperty("Visible", false, true, item);
							}
						}
						e.Document.EndLogUndo();
						e.Document.Modified = true;
						e.Result = num2;
						e.RefreshLevel = UIStateRefreshLevel.All;
						e.EditorControl.RefreshDocument();
						e.Document.OnSelectionChanged();
						e.Document.OnDocumentContentChanged();
					}
				}
			}
		}
	}
}
