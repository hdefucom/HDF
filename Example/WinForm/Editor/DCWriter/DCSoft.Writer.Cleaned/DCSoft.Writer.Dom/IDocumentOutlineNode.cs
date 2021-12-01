using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentOutlineNode 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("D43A5956-6F5E-4672-A27F-074324A86328")]
	public interface IDocumentOutlineNode
	{
		/// <summary>属性ChildNodes</summary>
		[DispId(3)]
		DocumentOutlineNodeList ChildNodes
		{
			get;
		}

		/// <summary>属性Level</summary>
		[DispId(8)]
		int Level
		{
			get;
		}

		/// <summary>属性LevelText</summary>
		[DispId(4)]
		string LevelText
		{
			get;
			set;
		}

		/// <summary>属性ParagraphFlag</summary>
		[DispId(5)]
		XTextParagraphFlagElement ParagraphFlag
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(9)]
		DocumentOutlineNode Parent
		{
			get;
			set;
		}

		/// <summary>属性StartElement</summary>
		[DispId(6)]
		XTextElement StartElement
		{
			get;
		}

		/// <summary>属性Text</summary>
		[DispId(7)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(10)]
		bool Visible
		{
			get;
		}

		/// <summary>方法Focus</summary>
		[DispId(2)]
		void Focus();
	}
}
