using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       弹出日期选择框的文本输入域内容编辑器对象
	///       </summary>
	[ComVisible(false)]
	internal class XTextInputFieldElementNumericValueEditor : ElementValueEditor
	{
		[CompilerGenerated]
		private sealed class Class284
		{
			public XTextInputFieldElement xtextInputFieldElement_0;

			public TextWindowsFormsEditorHost textWindowsFormsEditorHost_0;
		}

		[CompilerGenerated]
		private sealed class Class285
		{
			public Class284 class284_0;

			public string string_0;

			public void method_0(object sender, EventArgs e)
			{
				int num = 14;
				if (class284_0.xtextInputFieldElement_0.InnerValue != string_0)
				{
					if (class284_0.textWindowsFormsEditorHost_0.Document.CanLogUndo)
					{
						class284_0.textWindowsFormsEditorHost_0.Document.UndoList.AddProperty("InnerValue", class284_0.xtextInputFieldElement_0.InnerValue, string_0, class284_0.xtextInputFieldElement_0);
					}
					class284_0.xtextInputFieldElement_0.InnerValue = string_0;
				}
				class284_0.xtextInputFieldElement_0.OwnerDocument.CopySourceExecuter.imethod_2(class284_0.xtextInputFieldElement_0);
			}
		}

		/// <summary>
		///       获得编辑样式
		///       </summary>
		/// <param name="host">
		/// </param>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override ElementValueEditorEditStyle GetEditStyle(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			return ElementValueEditorEditStyle.DropDown;
		}

		/// <summary>
		///       编辑数值
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <param name="context">上下文对象</param>
		/// <returns>操作是否成功</returns>
		public override ElementValueEditResult EditValue(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			int num = 15;
			XTextInputFieldElement xtextInputFieldElement_0 = (XTextInputFieldElement)context.Element;
			_ = xtextInputFieldElement_0.FieldSettings;
			string text = xtextInputFieldElement_0.InnerValue;
			if (string.IsNullOrEmpty(text))
			{
				text = xtextInputFieldElement_0.Text;
			}
			double result = 0.0;
			if (!double.TryParse(text, out result))
			{
				result = 0.0;
			}
			bool flag = false;
			using (WriterCalculateControl writerCalculateControl = new WriterCalculateControl())
			{
				writerCalculateControl.InputValue = result;
				writerCalculateControl.EditorHost = host;
				host.DropDownControl(writerCalculateControl);
				if (flag = writerCalculateControl.Modified)
				{
					result = writerCalculateControl.InputValue;
				}
			}
			if (flag)
			{
				string string_0 = null;
				string text2 = null;
				if (double.IsNaN(result))
				{
					text2 = "";
					string_0 = "";
				}
				else
				{
					text2 = ((xtextInputFieldElement_0.DisplayFormat == null || xtextInputFieldElement_0.DisplayFormat.IsEmpty) ? result.ToString() : xtextInputFieldElement_0.DisplayFormat.Execute(result.ToString()));
					if (host.EditControl.DocumentOptions.BehaviorOptions.DisplayFormatToInnerValue && xtextInputFieldElement_0.DisplayFormat != null && !xtextInputFieldElement_0.DisplayFormat.IsEmpty)
					{
						string_0 = xtextInputFieldElement_0.DisplayFormat.Execute(result.ToString());
					}
					else
					{
						string_0 = result.ToString();
					}
				}
				if (xtextInputFieldElement_0.Text != text2)
				{
					string text3 = xtextInputFieldElement_0.Text;
					string innerValue = xtextInputFieldElement_0.InnerValue;
					WriterBeforeFieldContentEditEventArgs writerBeforeFieldContentEditEventArgs = new WriterBeforeFieldContentEditEventArgs(xtextInputFieldElement_0, null, null, "XTextInputFieldElementNumericValueEditor");
					writerBeforeFieldContentEditEventArgs.NewText = text2;
					writerBeforeFieldContentEditEventArgs.NewValue = string_0;
					host.EditControl.method_55(writerBeforeFieldContentEditEventArgs);
					if (writerBeforeFieldContentEditEventArgs.Cancel)
					{
						return ElementValueEditResult.UserCancel;
					}
					text2 = writerBeforeFieldContentEditEventArgs.NewText;
					string_0 = writerBeforeFieldContentEditEventArgs.NewValue;
					if (!xtextInputFieldElement_0.OwnerDocument.UIStartEditContent())
					{
						return ElementValueEditResult.UserCancel;
					}
					xtextInputFieldElement_0.OwnerDocument.BeginLogUndo();
					xtextInputFieldElement_0.eventHandler_0 = delegate
					{
						int num2 = 14;
						if (xtextInputFieldElement_0.InnerValue != string_0)
						{
							if (host.Document.CanLogUndo)
							{
								host.Document.UndoList.AddProperty("InnerValue", xtextInputFieldElement_0.InnerValue, string_0, xtextInputFieldElement_0);
							}
							xtextInputFieldElement_0.InnerValue = string_0;
						}
						xtextInputFieldElement_0.OwnerDocument.CopySourceExecuter.imethod_2(xtextInputFieldElement_0);
					};
					SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
					setContainerTextArgs.NewText = text2;
					setContainerTextArgs.AccessFlags = (DomAccessFlags)MathCommon.smethod_25(255, 2, bool_0: false);
					setContainerTextArgs.ShowUI = true;
					setContainerTextArgs.LogUndo = true;
					setContainerTextArgs.DisablePermission = false;
					setContainerTextArgs.UpdateContent = true;
					setContainerTextArgs.RaiseDocumentContentChangedEvent = false;
					setContainerTextArgs.FocusContainer = true;
					setContainerTextArgs.IgnoreDisplayFormat = true;
					setContainerTextArgs.EventSource = ContentChangedEventSource.ValueEditor;
					if (xtextInputFieldElement_0.SetEditorText(setContainerTextArgs))
					{
						xtextInputFieldElement_0.InnerValue = string_0;
						host.Document.EndLogUndo();
						host.RaiseDocumentContentChangedOnceAfterEditValue = true;
						WriterAfterFieldContentEditEventArgs writerAfterFieldContentEditEventArgs_ = new WriterAfterFieldContentEditEventArgs(xtextInputFieldElement_0, null, null, "XTextInputFieldElementNumericValueEditor", text3, innerValue);
						writerBeforeFieldContentEditEventArgs.NewText = text2;
						writerBeforeFieldContentEditEventArgs.NewValue = string_0;
						host.EditControl.method_56(writerAfterFieldContentEditEventArgs_);
						return ElementValueEditResult.UserAccept;
					}
					host.Document.CancelLogUndo();
					return ElementValueEditResult.UserCancel;
				}
			}
			return ElementValueEditResult.UserCancel;
		}
	}
}