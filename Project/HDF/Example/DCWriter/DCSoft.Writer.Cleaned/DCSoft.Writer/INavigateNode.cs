using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>NavigateNode 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("2B8A0CD5-CF6B-4EEF-BA74-E4C62D39D469")]
	[ComVisible(true)]
	public interface INavigateNode
	{
		/// <summary>属性Elements</summary>
		[DispId(2)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性EndContentIndex</summary>
		[DispId(9)]
		int EndContentIndex
		{
			get;
		}

		/// <summary>属性HasChildNode</summary>
		[DispId(3)]
		bool HasChildNode
		{
			get;
		}

		/// <summary>属性ID</summary>
		[DispId(8)]
		string ID
		{
			get;
		}

		/// <summary>属性Level</summary>
		[DispId(4)]
		int Level
		{
			get;
			set;
		}

		/// <summary>属性Nodes</summary>
		[DispId(5)]
		NavigateNodeList Nodes
		{
			get;
			set;
		}

		/// <summary>属性Position</summary>
		[DispId(6)]
		int Position
		{
			get;
		}

		/// <summary>属性StartContentIndex</summary>
		[DispId(10)]
		int StartContentIndex
		{
			get;
		}

		/// <summary>属性Text</summary>
		[DispId(7)]
		string Text
		{
			get;
		}
	}
}
