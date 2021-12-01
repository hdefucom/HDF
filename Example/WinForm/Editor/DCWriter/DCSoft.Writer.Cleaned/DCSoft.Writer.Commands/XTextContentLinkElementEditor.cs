using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档内容链接对象编辑器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextContentLinkElementEditor : ElementPropertiesEditor
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
			using (dlgContentLinkEditor dlgContentLinkEditor = new dlgContentLinkEditor())
			{
				dlgContentLinkEditor.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgContentLinkEditor, args.Element) == DialogResult.OK)
				{
					if (args.Method == ElementPropertiesEditMethod.Edit)
					{
						XTextContentLinkFieldElement xTextContentLinkFieldElement = (XTextContentLinkFieldElement)args.Element;
						if (!args.Document.Options.BehaviorOptions.DesignMode)
						{
							xTextContentLinkFieldElement.method_31(bool_20: false);
						}
						if (args.Method == ElementPropertiesEditMethod.Edit)
						{
							ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
							contentChangedEventArgs.Document = args.Document;
							contentChangedEventArgs.Element = xTextContentLinkFieldElement;
							contentChangedEventArgs.LoadingDocument = false;
							xTextContentLinkFieldElement.method_23(contentChangedEventArgs);
						}
					}
					return true;
				}
				return false;
			}
		}
	}
}
