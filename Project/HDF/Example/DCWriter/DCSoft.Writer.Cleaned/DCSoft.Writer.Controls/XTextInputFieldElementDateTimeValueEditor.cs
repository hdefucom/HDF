using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       弹出时间日期方式编辑文本输入域内容的编辑器
	///       </summary>
	[DCInternal]
	[ComVisible(false)]
	public class XTextInputFieldElementDateTimeValueEditor : ElementValueEditor
	{
		[CompilerGenerated]
		private sealed class Class281
		{
			public XTextInputFieldElement xtextInputFieldElement_0;

			public TextWindowsFormsEditorHost textWindowsFormsEditorHost_0;
		}

		[CompilerGenerated]
		private sealed class Class282
		{
			public Class281 class281_0;

			public string string_0;

			public void method_0(object sender, EventArgs e)
			{
				int num = 16;
				if (class281_0.xtextInputFieldElement_0.InnerValue != string_0)
				{
					if (class281_0.textWindowsFormsEditorHost_0.Document.CanLogUndo)
					{
						class281_0.textWindowsFormsEditorHost_0.Document.UndoList.AddProperty("InnerValue", class281_0.xtextInputFieldElement_0.InnerValue, string_0, class281_0.xtextInputFieldElement_0);
					}
					class281_0.xtextInputFieldElement_0.InnerValue = string_0;
				}
				class281_0.xtextInputFieldElement_0.OwnerDocument.CopySourceExecuter.imethod_2(class281_0.xtextInputFieldElement_0);
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
			return smethod_0(host, context, bool_0: true);
		}

		internal static ElementValueEditResult smethod_0(TextWindowsFormsEditorHost textWindowsFormsEditorHost_0, ElementValueEditContext elementValueEditContext_0, bool bool_0)
		{
			int num = 12;
			XTextInputFieldElement xtextInputFieldElement_0 = (XTextInputFieldElement)elementValueEditContext_0.Element;
			_ = xtextInputFieldElement_0.FieldSettings;
			string text = xtextInputFieldElement_0.InnerValue;
			if (string.IsNullOrEmpty(text))
			{
				text = xtextInputFieldElement_0.Text;
			}
			DateTime nowDateTime = xtextInputFieldElement_0.OwnerDocument.GetNowDateTime();
			DateTime result = nowDateTime;
			DateTime d = nowDateTime;
			bool flag = false;
			using (DateTimeSelectControl dateTimeSelectControl = new DateTimeSelectControl())
			{
				if (!DateTime.TryParse(text, out result))
				{
					result = nowDateTime;
					dateTimeSelectControl.NullValueFlag = true;
				}
				else
				{
					dateTimeSelectControl.NullValueFlag = false;
				}
				dateTimeSelectControl.SecondVisible = bool_0;
				dateTimeSelectControl.DateTimeValue = result;
				dateTimeSelectControl.EditorService = textWindowsFormsEditorHost_0;
				textWindowsFormsEditorHost_0.DropDownControl(dateTimeSelectControl);
				flag = dateTimeSelectControl.Modified;
				d = dateTimeSelectControl.DateTimeValue;
			}
			if (flag)
			{
				string string_0 = null;
				string text2 = null;
				if (d == DateTime.MinValue)
				{
					text2 = "";
					string_0 = "";
				}
				else
				{
					text2 = ((xtextInputFieldElement_0.DisplayFormat != null && !xtextInputFieldElement_0.DisplayFormat.IsEmpty) ? xtextInputFieldElement_0.DisplayFormat.Execute(d.ToString()) : ((!bool_0) ? d.ToString("yyyy-MM-dd HH:mm") : d.ToString("yyyy-MM-dd HH:mm:ss")));
					string_0 = d.ToString("yyyy-MM-dd HH:mm:ss");
				}
				if (xtextInputFieldElement_0.Text != text2)
				{
					string text3 = xtextInputFieldElement_0.Text;
					string innerValue = xtextInputFieldElement_0.InnerValue;
					WriterBeforeFieldContentEditEventArgs writerBeforeFieldContentEditEventArgs = new WriterBeforeFieldContentEditEventArgs(xtextInputFieldElement_0, null, null, "XTextInputFieldElementDateTimeValueEditor");
					writerBeforeFieldContentEditEventArgs.NewText = text2;
					writerBeforeFieldContentEditEventArgs.NewValue = string_0;
					textWindowsFormsEditorHost_0.EditControl.method_55(writerBeforeFieldContentEditEventArgs);
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
						int num2 = 16;
						if (xtextInputFieldElement_0.InnerValue != string_0)
						{
							if (textWindowsFormsEditorHost_0.Document.CanLogUndo)
							{
								textWindowsFormsEditorHost_0.Document.UndoList.AddProperty("InnerValue", xtextInputFieldElement_0.InnerValue, string_0, xtextInputFieldElement_0);
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
						textWindowsFormsEditorHost_0.Document.EndLogUndo();
						textWindowsFormsEditorHost_0.RaiseDocumentContentChangedOnceAfterEditValue = true;
						WriterAfterFieldContentEditEventArgs writerAfterFieldContentEditEventArgs_ = new WriterAfterFieldContentEditEventArgs(xtextInputFieldElement_0, null, null, "XTextInputFieldElementDateTimeValueEditor", text3, innerValue);
						writerBeforeFieldContentEditEventArgs.NewText = text2;
						writerBeforeFieldContentEditEventArgs.NewValue = string_0;
						textWindowsFormsEditorHost_0.EditControl.method_56(writerAfterFieldContentEditEventArgs_);
						textWindowsFormsEditorHost_0.method_0();
						return ElementValueEditResult.UserAccept;
					}
					textWindowsFormsEditorHost_0.Document.CancelLogUndo();
					textWindowsFormsEditorHost_0.method_0();
					return ElementValueEditResult.UserCancel;
				}
			}
			textWindowsFormsEditorHost_0.method_0();
			return ElementValueEditResult.UserCancel;
		}
	}
}
