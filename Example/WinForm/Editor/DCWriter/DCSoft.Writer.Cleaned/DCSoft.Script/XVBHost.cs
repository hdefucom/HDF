using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       VB脚本引擎宿主
	///       </summary>
	[XmlType]
	[ComVisible(false)]
	public class XVBHost : IVbHost
	{
		private IWin32Window _ParentWindow = null;

		private string _WindowTitle = null;

		public IWin32Window ParentWindow
		{
			get
			{
				return _ParentWindow;
			}
			set
			{
				_ParentWindow = value;
			}
		}

		public string WindowTitle
		{
			get
			{
				return _WindowTitle;
			}
			set
			{
				_WindowTitle = value;
			}
		}

		public IWin32Window GetParentWindow()
		{
			return _ParentWindow;
		}

		public string GetWindowTitle()
		{
			return _WindowTitle;
		}
	}
}
