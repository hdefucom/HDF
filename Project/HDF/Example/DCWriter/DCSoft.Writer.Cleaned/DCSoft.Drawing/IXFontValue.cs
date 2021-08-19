using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>XFontValue 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("21CAF270-0AC8-4CA1-AA5D-1FA8A77833C2")]
	public interface IXFontValue
	{
		/// <summary>属性Bold</summary>
		[DispId(2)]
		bool Bold
		{
			get;
			set;
		}

		/// <summary>属性Italic</summary>
		[DispId(3)]
		bool Italic
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(4)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Size</summary>
		[DispId(5)]
		float Size
		{
			get;
			set;
		}

		/// <summary>属性Strikeout</summary>
		[DispId(6)]
		bool Strikeout
		{
			get;
			set;
		}

		/// <summary>属性Underline</summary>
		[DispId(7)]
		bool Underline
		{
			get;
			set;
		}
	}
}
