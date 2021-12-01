using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Script;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器的一些工具方法
	///       </summary>
	[DocumentComment]
	[DCInternal]
	[ComVisible(false)]
	public class WriterTools : GClass15
	{
		private class MyImmProvider : GClass16, IImmProvider
		{
			public MyImmProvider(WriterViewControl writerViewControl_0)
				: base(writerViewControl_0)
			{
			}

			public bool IsWM_IME_NOTIFY_IMN_SETOPENSTATUS(Message message_0)
			{
				return message_0.Msg == 642 && message_0.WParam.ToInt32() == 8;
			}

			bool IImmProvider.IsImmOpen()
			{
				return IsImmOpen();
			}

			void IImmProvider.SetImmPos(int param0, int param1)
			{
				SetImmPos(param0, param1);
			}

			bool IImmProvider.BackConversionStatus()
			{
				return BackConversionStatus();
			}

			bool IImmProvider.RestoreConversionStatus()
			{
				return RestoreConversionStatus();
			}
		}

		private class MyCaretProvider : GClass17, ICaretProvider
		{
			public MyCaretProvider(WriterViewControl writerViewControl_0)
				: base(writerViewControl_0)
			{
			}

			bool ICaretProvider.Hide()
			{
				return Hide();
			}

			bool ICaretProvider.Create(int param0, int param1, int param2)
			{
				return Create(param0, param1, param2);
			}

			bool ICaretProvider.SetPos(int param0, int param1)
			{
				return SetPos(param0, param1);
			}

			bool ICaretProvider.Show()
			{
				return Show();
			}
		}

		/// <summary>
		///       创建输入法控制器
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <returns>
		/// </returns>
		public override IImmProvider CreateImmProvider(WriterControl writerControl_0)
		{
			return new MyImmProvider(writerControl_0.InnerViewControl);
		}

		/// <summary>
		///       创建光标控制器
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <returns>
		/// </returns>
		public override ICaretProvider CreateCaretProvider(WriterControl writerControl_0)
		{
			return new MyCaretProvider(writerControl_0.InnerViewControl);
		}

		public override IAutoSaveManager CreateLocalAutoSaveManager(WriterControl writerControl_0)
		{
			return new LocalAutoSaveManager(writerControl_0);
		}

		public override GInterface4 CreateDocumentExpressionExecuter(XTextDocument xtextDocument_0)
		{
			return new Class55(xtextDocument_0);
		}

		public override GInterface5 CreateWriterHtmlDocumentWriter()
		{
			return new Class57();
		}

		public override IWriterControlWebServiceProtocol CreateWriterControlWebServiceProtocol(WriterControl writerControl_0)
		{
			return new WriterControlWebServiceProtocol(writerControl_0);
		}

		public override GInterface8 CreateKBInserter(WriterControl writerControl_0)
		{
			return new Class60(writerControl_0);
		}

		public override IContextMenuStripManager CreateContextMenuStripManager(WriterControl writerControl_0)
		{
			return new ContextMenuStripManager(writerControl_0);
		}

		public override IDCElementIDForEditableDependentExecuter CreateDCElementIDForEditableDependentExecuter(XTextDocument xtextDocument_0)
		{
			return new DCElementIDForEditableDependentExecuter(xtextDocument_0);
		}

		public override GInterface6 CreateHighlightManager(XTextDocument xtextDocument_0)
		{
			return new GClass27(xtextDocument_0);
		}

		public override GInterface9 CreateDocumentCommentManager(WriterControl writerControl_0)
		{
			return new GClass36(writerControl_0.InnerViewControl);
		}

		public override GInterface2 CreateTabIndexManager(XTextDocument xtextDocument_0)
		{
			return new Class51(xtextDocument_0);
		}

		public override GInterface19 CreateAssistStringList(WriterControl writerControl_0)
		{
			return new frmAssistStringList(writerControl_0);
		}

		public override GInterface20 CreateControlHostManager()
		{
			return new ControlHostManager();
		}

		public override GInterface3 CreateContentSearchReplacer()
		{
			return new Class53();
		}

		public override IDocumentScriptEngine CreateDocumentScriptEngine(XTextDocument document)
		{
			return new DocumentScriptEngine(document);
		}

		public override GInterface7 CreateCopySourceExecuter(XTextDocument document)
		{
			return new GClass28(document);
		}

		public override Control CreateDeveloperToolsControl()
		{
			return new DeveloperToolsControl();
		}

		public override ElementValueEditor CreateElementValueEditor(XTextElement element)
		{
			XTextInputFieldElement xTextInputFieldElement = element as XTextInputFieldElement;
			if (xTextInputFieldElement != null)
			{
				if (!xTextInputFieldElement.EnableValueEditor)
				{
					return null;
				}
				ElementValueEditor valueEditor = xTextInputFieldElement.GetValueEditor();
				if (valueEditor != null)
				{
					return valueEditor;
				}
				if (!string.IsNullOrEmpty(xTextInputFieldElement.EditorControlTypeName))
				{
					return new XTextInputFieldElementCustomEditor();
				}
				if (!string.IsNullOrEmpty(xTextInputFieldElement.CustomValueEditorTypeName))
				{
					Type controlType = ControlHelper.GetControlType(xTextInputFieldElement.CustomValueEditorTypeName, typeof(ElementValueEditor));
					if (controlType != null)
					{
						return (ElementValueEditor)Activator.CreateInstance(controlType);
					}
				}
				if (xTextInputFieldElement.FieldSettings != null)
				{
					if (xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.Date)
					{
						return new XTextInputFieldElementDateValueEditor();
					}
					if (xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.DateTime)
					{
						return new XTextInputFieldElementDateTimeValueEditor();
					}
					if (xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.DateTimeWithoutSecond)
					{
						return new XTextInputFieldElementDateTimeWithoutSectionValueEditor();
					}
					if (xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.Time)
					{
						return new XTextInputFieldElementTimeValueEditor();
					}
					if (xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList)
					{
						return new XTextInputFieldElementListValueEditor();
					}
					if (xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.Numeric)
					{
						return new XTextInputFieldElementNumericValueEditor();
					}
				}
			}
			return null;
		}

		public override string FormatSelectedValueByIndexs(WriterControl writerControl_0, XTextInputFieldElement element, int[] indexs, bool getText)
		{
			return XTextInputFieldElementListValueEditor.FormatSelectedValueByIndexs(writerControl_0, element, indexs, getText);
		}

		public override string[] ParseSelectedValue(WriterControl writerControl_0, XTextElement element, List<string> allValues, string itemSpliter, string formatString, string Value)
		{
			return XTextInputFieldElementListValueEditor.ParseSelectedValue(writerControl_0, element, allValues, itemSpliter, formatString, Value);
		}

		public static InputFieldEditStyle GetEditStyleByDateTimeFormatString(string format)
		{
			int num = 9;
			if (format != null)
			{
				bool flag = format.IndexOf("yy") >= 0;
				bool flag2 = format.IndexOf("mm") >= 0;
				bool flag3 = format.IndexOf("ss") >= 0;
				if (flag && flag2 && flag3)
				{
					return InputFieldEditStyle.DateTime;
				}
				if (flag && flag2 && !flag3)
				{
					return InputFieldEditStyle.DateTimeWithoutSecond;
				}
				if (flag && !flag2 && !flag3)
				{
					return InputFieldEditStyle.Date;
				}
				if (!flag && (flag2 || flag3))
				{
					return InputFieldEditStyle.Time;
				}
			}
			return InputFieldEditStyle.DateTimeWithoutSecond;
		}
	}
}
