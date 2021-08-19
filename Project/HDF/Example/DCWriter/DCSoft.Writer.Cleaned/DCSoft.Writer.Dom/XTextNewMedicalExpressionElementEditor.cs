using DCSoft.Writer.Controls;
using DCSoft.Writer.MedicalExpression;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       医学表达式编辑器对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextNewMedicalExpressionElementEditor : ElementPropertiesEditor
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
						XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)args.Element;
						if (args.Method == ElementPropertiesEditMethod.Edit)
						{
							ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
							contentChangedEventArgs.Document = args.Document;
							contentChangedEventArgs.Element = xTextNewMedicalExpressionElement;
							contentChangedEventArgs.LoadingDocument = false;
							xTextNewMedicalExpressionElement.Parent.method_23(contentChangedEventArgs);
						}
					}
					return true;
				}
				return false;
			}
		}
	}
}
