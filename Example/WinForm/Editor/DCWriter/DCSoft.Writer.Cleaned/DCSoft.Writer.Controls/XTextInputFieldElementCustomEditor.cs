using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       使用自定义控件的文本输入域内容编辑器对象
	///       </summary>
	[DCInternal]
	[ComVisible(false)]
	public class XTextInputFieldElementCustomEditor : ElementValueEditor
	{
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
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)context.Element;
			_ = xTextInputFieldElement.FieldSettings;
			Type controlType = ControlHelper.GetControlType(xTextInputFieldElement.EditorControlTypeName, typeof(Control));
			if (controlType == null)
			{
				return ElementValueEditResult.None;
			}
			if (!xTextInputFieldElement.OwnerDocument.UIStartEditContent())
			{
				return ElementValueEditResult.None;
			}
			using (Control control = (Control)Activator.CreateInstance(controlType))
			{
				InputFieldElementEditorEventArgs inputFieldElementEditorEventArgs = new InputFieldElementEditorEventArgs(host.EditControl, host.Document, xTextInputFieldElement, context);
				if (control is IInputFieldElementEditorControl)
				{
					IInputFieldElementEditorControl inputFieldElementEditorControl = (IInputFieldElementEditorControl)control;
					inputFieldElementEditorControl.EditorInitalize(inputFieldElementEditorEventArgs);
				}
				host.DropDownControl(control);
				return inputFieldElementEditorEventArgs.Result;
			}
		}
	}
}
