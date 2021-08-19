using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextLine 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("88F6BACA-29E0-465E-AC26-710AC3AF1050")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextLine
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		XTextElement this[int index]
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(8)]
		float Top
		{
			get;
			set;
		}

		/// <summary>方法Contains</summary>
		[DispId(2)]
		bool Contains(XTextElement item);

		/// <summary>方法GetItem</summary>
		[DispId(9)]
		XTextElement GetItem(int index);
	}
}
