using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextRulerElement 的COM接口</summary>
	[ComVisible(true)]
	[Guid("B453DD01-FEEE-4126-9625-F64885E82BB9")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextRulerElement
	{
		/// <summary>属性Height</summary>
		[DispId(2)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(3)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性LineColor</summary>
		[DispId(4)]
		Color LineColor
		{
			get;
			set;
		}

		/// <summary>属性MaxScale</summary>
		[DispId(5)]
		int MaxScale
		{
			get;
			set;
		}

		/// <summary>属性MinScale</summary>
		[DispId(6)]
		int MinScale
		{
			get;
			set;
		}

		/// <summary>属性RulerValue</summary>
		[DispId(7)]
		float RulerValue
		{
			get;
			set;
		}

		/// <summary>属性Scales</summary>
		[DispId(8)]
		ScalePropertyList Scales
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(9)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(10)]
		float Width
		{
			get;
			set;
		}
	}
}
