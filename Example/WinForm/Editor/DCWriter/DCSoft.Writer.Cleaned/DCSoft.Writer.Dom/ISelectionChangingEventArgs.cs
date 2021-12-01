using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>SelectionChangingEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("6BA3090C-6F53-46E5-AC8D-25932D32893C")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface ISelectionChangingEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性Documnent</summary>
		[DispId(3)]
		XTextDocument Documnent
		{
			get;
			set;
		}

		/// <summary>属性NewLineEndFlag</summary>
		[DispId(4)]
		bool NewLineEndFlag
		{
			get;
			set;
		}

		/// <summary>属性NewSelectionIndex</summary>
		[DispId(5)]
		int NewSelectionIndex
		{
			get;
			set;
		}

		/// <summary>属性NewSelectionLength</summary>
		[DispId(6)]
		int NewSelectionLength
		{
			get;
			set;
		}

		/// <summary>属性OldLineEndFlag</summary>
		[DispId(7)]
		bool OldLineEndFlag
		{
			get;
			set;
		}

		/// <summary>属性OldSelectionIndex</summary>
		[DispId(8)]
		int OldSelectionIndex
		{
			get;
			set;
		}

		/// <summary>属性OldSelectionLength</summary>
		[DispId(9)]
		int OldSelectionLength
		{
			get;
			set;
		}
	}
}
