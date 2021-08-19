using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       医学表达式编辑器对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextMedicalExpressionFieldElementEditor : ElementPropertiesEditor
	{
		/// <summary>
		///       判断操作是否支持
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
		///       编辑对象
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			using (dlgMedicalExpressionEditor dlgMedicalExpressionEditor = new dlgMedicalExpressionEditor())
			{
				dlgMedicalExpressionEditor.SourceEventArgs = args;
				dlgMedicalExpressionEditor.CurrentContentStyle = args.Document.CurrentStyleInfo.Content;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgMedicalExpressionEditor, args.Element) == DialogResult.OK)
				{
					if (args.Method == ElementPropertiesEditMethod.Edit)
					{
						XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = (XTextMedicalExpressionFieldElement)args.Element;
						if (args.Method == ElementPropertiesEditMethod.Edit)
						{
							ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
							contentChangedEventArgs.Document = args.Document;
							contentChangedEventArgs.Element = xTextMedicalExpressionFieldElement;
							contentChangedEventArgs.LoadingDocument = false;
							xTextMedicalExpressionFieldElement.method_23(contentChangedEventArgs);
						}
					}
					return true;
				}
				return false;
			}
		}
	}
}
