using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       控件承载宿主对象编辑器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextControlHostElementEditor : ElementPropertiesEditor
	{
		/// <summary>
		///       判断是否支持指定的编辑方法
		///       </summary>
		/// <param name="method">编辑方法类型</param>
		/// <returns>是否支持</returns>
		public override bool IsSupportMethod(ElementPropertiesEditMethod method)
		{
			return true;
		}

		/// <summary>
		///       编辑内容
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			using (dlgControlHostEditor dlgControlHostEditor = new dlgControlHostEditor())
			{
				dlgControlHostEditor.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgControlHostEditor, args.Element) == DialogResult.OK)
				{
					if (args.Method == ElementPropertiesEditMethod.Edit)
					{
						XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)args.Element;
						if (args.Method == ElementPropertiesEditMethod.Edit)
						{
							ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
							contentChangedEventArgs.Document = args.Document;
							contentChangedEventArgs.Element = xTextControlHostElement;
							contentChangedEventArgs.LoadingDocument = false;
							xTextControlHostElement.Parent.method_23(contentChangedEventArgs);
							if (args.Document.EditorControl != null)
							{
								xTextControlHostElement.vmethod_27();
								xTextControlHostElement.vmethod_29();
							}
						}
					}
					return true;
				}
				return false;
			}
		}
	}
}
