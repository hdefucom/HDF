using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>DocumentTerminalTextInfo 的COM接口</summary>
	[Guid("D194EF7D-69BE-4562-B84D-F52C773B378C")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IDocumentTerminalTextInfo
	{
		/// <summary>属性Color</summary>
		[DispId(2)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorValue</summary>
		[DispId(3)]
		string ColorValue
		{
			get;
			set;
		}

		/// <summary>属性Font</summary>
		[DispId(4)]
		XFontValue Font
		{
			get;
			set;
		}

		/// <summary>属性MinHeightInCMUnit</summary>
		[DispId(5)]
		float MinHeightInCMUnit
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(6)]
		string Text
		{
			get;
			set;
		}
	}
}
