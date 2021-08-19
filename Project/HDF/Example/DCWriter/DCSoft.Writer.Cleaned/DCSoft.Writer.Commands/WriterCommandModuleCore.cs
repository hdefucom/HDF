using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using DCSoftDotfuscate;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[WriterCommandDescription("Core")]
	internal class WriterCommandModuleCore : WriterCommandModule
	{
		[WriterCommandDescription("SimplifiedSwapTraditional", ImageResource = "DCSoft.Writer.Commands.Images.CommandSimplifiedSwapTraditional.bmp", ReturnValueType = typeof(int))]
		protected void method_1(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				method_4(e, 2);
			}
		}

		[WriterCommandDescription("SimplifiedToTraditional", ImageResource = "DCSoft.Writer.Commands.Images.CommandSimplifiedToTraditional.bmp", ReturnValueType = typeof(int))]
		protected void method_2(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				method_4(e, 0);
			}
		}

		[WriterCommandDescription("TraditionalToSimplified", ImageResource = "DCSoft.Writer.Commands.Images.CommandTraditionalToSimplified.bmp", ReturnValueType = typeof(int))]
		protected void method_3(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				method_4(e, 1);
			}
		}

		private void method_4(WriterCommandEventArgs writerCommandEventArgs_0, int int_0)
		{
			int num = 2;
			DocumentControler documentControler = writerCommandEventArgs_0.DocumentControler;
			XTextElementList xTextElementList = new XTextElementList();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(writerCommandEventArgs_0.Document);
			domTreeNodeEnumerable.ExcludeCharElement = false;
			domTreeNodeEnumerable.ExcludeParagraphFlag = false;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				bool flag;
				if ((flag = documentControler.CanModify(item, DomAccessFlags.Normal)) && item is XTextContainerElement)
				{
					ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
					contentChangingEventArgs.Document = writerCommandEventArgs_0.Document;
					contentChangingEventArgs.Element = item;
					if (item is XTextContainerElement)
					{
						((XTextContainerElement)item).method_22(contentChangingEventArgs);
					}
					if (contentChangingEventArgs.Cancel)
					{
						flag = false;
					}
				}
				if (flag)
				{
					if (item is XTextCharElement || item is XTextInputFieldElement || item is XTextLabelElement || item is XTextCheckBoxElementBase || item is XTextImageElement)
					{
						xTextElementList.Add(item);
					}
				}
				else
				{
					domTreeNodeEnumerable.CancelChild();
				}
			}
			if (xTextElementList.Count <= 0)
			{
				return;
			}
			XTextUndoCharValue xTextUndoCharValue = null;
			if (writerCommandEventArgs_0.Document.BeginLogUndo())
			{
				xTextUndoCharValue = new XTextUndoCharValue();
			}
			int num2 = 0;
			XTextElementList xTextElementList2 = new XTextElementList();
			foreach (XTextElement item2 in xTextElementList)
			{
				if (item2 is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)item2;
					char c = xTextCharElement.CharValue;
					switch (int_0)
					{
					case 0:
						c = StringConvertHelper.SimplifiedToTraditional(c);
						break;
					case 1:
						c = StringConvertHelper.TraditionalToSimplified(c);
						break;
					case 2:
						c = StringConvertHelper.SimplifiedSwapTraditional(c);
						break;
					}
					if (c != xTextCharElement.CharValue)
					{
						xTextUndoCharValue?.method_0(xTextCharElement, xTextCharElement.CharValue, c, bool_0: false);
						xTextCharElement.CharValue = c;
						num2++;
						if (!xTextElementList2.Contains(xTextCharElement.Parent))
						{
							xTextElementList2.Add(xTextCharElement.Parent);
						}
					}
				}
				else if (item2 is XTextInputFieldElement)
				{
					if (method_5(writerCommandEventArgs_0.Document, item2, new string[5]
					{
						"BackgroundText",
						"UnitText",
						"LabelText",
						"ToolTip",
						"InnerValue"
					}, int_0))
					{
						num2++;
						if (!xTextElementList2.Contains(item2))
						{
							xTextElementList2.Add(item2);
						}
					}
				}
				else if (item2 is XTextLabelElement)
				{
					if (method_5(writerCommandEventArgs_0.Document, item2, new string[1]
					{
						"Text"
					}, int_0))
					{
						num2++;
						if (!xTextElementList2.Contains(item2.Parent))
						{
							xTextElementList2.Add(item2.Parent);
						}
					}
				}
				else if (item2 is XTextCheckBoxElementBase)
				{
					if (method_5(writerCommandEventArgs_0.Document, item2, new string[2]
					{
						"Caption",
						"ToolTip"
					}, int_0))
					{
						num2++;
						if (!xTextElementList2.Contains(item2.Parent))
						{
							xTextElementList2.Add(item2.Parent);
						}
					}
				}
				else if (item2 is XTextImageElement && method_5(writerCommandEventArgs_0.Document, item2, new string[2]
				{
					"Alt",
					"Title"
				}, int_0))
				{
					num2++;
					if (!xTextElementList2.Contains(item2.Parent))
					{
						xTextElementList2.Add(item2.Parent);
					}
				}
			}
			if (num2 > 0)
			{
				if (xTextUndoCharValue != null)
				{
					if (xTextUndoCharValue.Count > 0)
					{
						writerCommandEventArgs_0.Document.UndoList.method_14(xTextUndoCharValue);
					}
					writerCommandEventArgs_0.Document.EndLogUndo();
				}
				writerCommandEventArgs_0.Document.Modified = true;
				if (xTextElementList2.Count > 0)
				{
					foreach (XTextContainerElement item3 in xTextElementList2)
					{
						if (item3 != null)
						{
							ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
							contentChangedEventArgs.Document = writerCommandEventArgs_0.Document;
							contentChangedEventArgs.Element = item3;
							contentChangedEventArgs.LoadingDocument = false;
							item3.method_23(contentChangedEventArgs);
						}
					}
				}
				writerCommandEventArgs_0.Document.OnDocumentContentChanged();
				writerCommandEventArgs_0.RefreshLevel = UIStateRefreshLevel.All;
				writerCommandEventArgs_0.EditorControl.InnerViewControl.Invalidate();
			}
			writerCommandEventArgs_0.Result = num2;
		}

		private bool method_5(XTextDocument xtextDocument_0, object object_0, string[] string_1, int int_0)
		{
			int num = 16;
			bool result = false;
			foreach (string text in string_1)
			{
				PropertyInfo property = object_0.GetType().GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					string text2 = (string)property.GetValue(object_0, Type.EmptyTypes);
					string text3 = method_6(text2, int_0);
					if (text2 != text3)
					{
						if (xtextDocument_0.CanLogUndo)
						{
							xtextDocument_0.UndoList.AddProperty(text, text2, text3, object_0);
						}
						property.SetValue(object_0, text3, Type.EmptyTypes);
						result = true;
					}
					continue;
				}
				throw new ArgumentException("propertyName=" + text);
			}
			return result;
		}

		private string method_6(string string_1, int int_0)
		{
			switch (int_0)
			{
			case 0:
				return StringConvertHelper.SimplifiedToTraditional(string_1);
			case 1:
				return StringConvertHelper.TraditionalToSimplified(string_1);
			case 2:
				return StringConvertHelper.SimplifiedSwapTraditional(string_1);
			default:
				return string_1;
			}
		}

		[WriterCommandDescription("Register", ReturnValueType = typeof(string))]
		protected void method_7(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
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
				XTextDocument.smethod_14();
				if (GClass143.smethod_14(bool_1: false))
				{
					if (e.ShowUI)
					{
						MessageBox.Show(e.EditorControl, WriterStringsCore.LoadLicenseFromDog, WriterStringsCore.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						e.Result = "DogLicense";
					}
					if (e.EditorControl != null)
					{
						Class126.smethod_4();
						e.EditorControl.InnerViewControl.Invalidate();
					}
					return;
				}
				string text = e.Parameter as string;
				if (e.ShowUI)
				{
					using (dlgRegister dlgRegister = new dlgRegister())
					{
						dlgRegister.InputRegisterCode = text;
						if (dlgRegister.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						text = dlgRegister.InputRegisterCode;
					}
				}
				if (WriterAppHost.Register(text, saveFile: true))
				{
					e.Result = text;
				}
				if (e.EditorControl != null)
				{
					e.EditorControl.InnerViewControl.Invalidate();
					Class126.smethod_4();
				}
			}
		}
	}
}
