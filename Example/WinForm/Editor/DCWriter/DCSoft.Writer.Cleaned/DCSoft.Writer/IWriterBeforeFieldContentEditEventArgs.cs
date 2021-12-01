using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterBeforeFieldContentEditEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("AF81279D-7D75-4B2D-881B-FB2824C736FC")]
	[Browsable(false)]
	public interface IWriterBeforeFieldContentEditEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性EditorTypeName</summary>
		[DispId(4)]
		string EditorTypeName
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(5)]
		XTextInputFieldElement Element
		{
			get;
		}

		/// <summary>属性ElementID</summary>
		[DispId(6)]
		string ElementID
		{
			get;
			set;
		}

		/// <summary>属性ElementName</summary>
		[DispId(7)]
		string ElementName
		{
			get;
			set;
		}

		/// <summary>属性NewText</summary>
		[DispId(8)]
		string NewText
		{
			get;
			set;
		}

		/// <summary>属性NewValue</summary>
		[DispId(9)]
		string NewValue
		{
			get;
			set;
		}

		/// <summary>属性OldText</summary>
		[DispId(10)]
		string OldText
		{
			get;
			set;
		}

		/// <summary>属性OldValue</summary>
		[DispId(11)]
		string OldValue
		{
			get;
			set;
		}

		/// <summary>属性SelectedIndexs</summary>
		[DispId(12)]
		string SelectedIndexs
		{
			get;
			set;
		}

		/// <summary>属性SelectedItems</summary>
		[DispId(13)]
		ListItemCollection SelectedItems
		{
			get;
			set;
		}
	}
}
