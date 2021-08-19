using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>ContentStyleContainer 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("D23E2F08-E8B0-4DED-BD1A-885C694D6850")]
	[ComVisible(true)]
	public interface IContentStyleContainer
	{
		/// <summary>属性Default</summary>
		[DispId(6)]
		ContentStyle Default
		{
			get;
			set;
		}

		/// <summary>属性Styles</summary>
		[DispId(7)]
		ContentStyleList Styles
		{
			get;
			set;
		}

		/// <summary>方法Clear</summary>
		[DispId(2)]
		void Clear();

		/// <summary>方法GetRuntimeStyle</summary>
		[DispId(3)]
		ContentStyle GetRuntimeStyle(int styleIndex);

		/// <summary>方法GetStyle</summary>
		[DispId(4)]
		ContentStyle GetStyle(int styleIndex);

		/// <summary>方法GetStyleIndex</summary>
		[DispId(5)]
		int GetStyleIndex(ContentStyle style);
	}
}
