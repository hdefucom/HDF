using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       输入域的元素编辑器
	///       </summary>
	[ComVisible(false)]
	public class XTextInputFieldElementEditor : ElementPropertiesEditor
	{
		/// <summary>
		///       支持的方法
		///       </summary>
		/// <param name="method">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool IsSupportMethod(ElementPropertiesEditMethod method)
		{
			return true;
		}

		/// <summary>
		///       编辑元素
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			if (args.SimpleElementProperties)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)args.Element;
				xTextInputFieldElement.OwnerDocument = args.Document;
				if (dlgDateTimeFieldElement.smethod_0(xTextInputFieldElement))
				{
					using (dlgDateTimeFieldElement dlgDateTimeFieldElement = new dlgDateTimeFieldElement())
					{
						dlgDateTimeFieldElement.InputFieldElement = xTextInputFieldElement;
						dlgDateTimeFieldElement.LogUndo = args.LogUndo;
						if (WriterControl.UIShowDialog(args.WriterControl, dlgDateTimeFieldElement, args.Element) == DialogResult.OK)
						{
							return true;
						}
					}
					return false;
				}
				if (dlgInsertListInputField.smethod_0(xTextInputFieldElement))
				{
					using (dlgInsertListInputField dlgInsertListInputField = new dlgInsertListInputField())
					{
						dlgInsertListInputField.LogUndo = args.LogUndo;
						dlgInsertListInputField.FieldElement = xTextInputFieldElement;
						dlgInsertListInputField.Document = args.Document;
						if (WriterControl.UIShowDialog(args.WriterControl, dlgInsertListInputField, args.Element) == DialogResult.OK)
						{
							return true;
						}
					}
					return false;
				}
			}
			using (dlgInputFieldEditor dlgInputFieldEditor = new dlgInputFieldEditor())
			{
				dlgInputFieldEditor.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgInputFieldEditor, args.Element) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}
	}
}
