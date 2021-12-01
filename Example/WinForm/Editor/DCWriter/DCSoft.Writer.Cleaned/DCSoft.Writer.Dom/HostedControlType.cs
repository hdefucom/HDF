using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       承载的对象类型
	///       </summary>
	[Guid("FA6DDBD7-B67D-4AAB-8FC2-862219FBDE8A")]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[ComVisible(true)]
	public enum HostedControlType
	{
		/// <summary>
		///       自动检测
		///       </summary>
		[DCDescription(typeof(HostedControlType), "AutoDetect")]
		AutoDetect,
		/// <summary>
		///       WinForm控件
		///       </summary>
		[DCDescription(typeof(HostedControlType), "Control")]
		Control,
		/// <summary>
		///       OCX控件
		///       </summary>
		[DCDescription(typeof(HostedControlType), "OCX")]
		OCX,
		/// <summary>
		///       原生态的Windows控件
		///       </summary>
		[DCDescription(typeof(HostedControlType), "OCX")]
		NativeWinControl,
		/// <summary>
		///       WPF控件
		///       </summary>
		[DCDescription(typeof(HostedControlType), "WPF")]
		WPF,
		/// <summary>
		///       实现了IDocumentImage接口的对象
		///       </summary>
		[DCDescription(typeof(HostedControlType), "DocumentImage")]
		DocumentImage,
		/// <summary>
		///       无效的类型
		///       </summary>
		[DCDescription(typeof(HostedControlType), "InvalidateType")]
		InvalidateType
	}
}
