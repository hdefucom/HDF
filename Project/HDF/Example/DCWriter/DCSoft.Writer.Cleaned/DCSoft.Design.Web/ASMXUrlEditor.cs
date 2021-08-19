using System.Runtime.InteropServices;
using System.Web.UI.Design;

namespace DCSoft.Design.Web
{
	/// <summary>
	///       编辑ASPX页面URL的属性编辑器
	///       </summary>
	[ComVisible(false)]
	public class ASMXUrlEditor : UrlEditor
	{
		protected override string Caption => DesignStrings.ASMXURLPickerCaption;

		protected override string Filter => DesignStrings.ASMXFileFilter;

		protected override UrlBuilderOptions Options => UrlBuilderOptions.None;
	}
}
