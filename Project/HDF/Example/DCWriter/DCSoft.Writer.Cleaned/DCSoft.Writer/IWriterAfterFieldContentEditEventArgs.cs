using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterAfterFieldContentEditEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("2BC86E56-454B-4C1E-912D-AAE838379536")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IWriterAfterFieldContentEditEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性EditorTypeName</summary>
		[DispId(3)]
		string EditorTypeName
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextInputFieldElement Element
		{
			get;
		}

		/// <summary>属性ElementID</summary>
		[DispId(5)]
		string ElementID
		{
			get;
			set;
		}

		/// <summary>属性ElementName</summary>
		[DispId(6)]
		string ElementName
		{
			get;
			set;
		}

		/// <summary>属性NewText</summary>
		[DispId(7)]
		string NewText
		{
			get;
			set;
		}

		/// <summary>属性NewValue</summary>
		[DispId(8)]
		string NewValue
		{
			get;
			set;
		}

		/// <summary>属性OldText</summary>
		[DispId(9)]
		string OldText
		{
			get;
			set;
		}

		/// <summary>属性OldValue</summary>
		[DispId(10)]
		string OldValue
		{
			get;
			set;
		}

		/// <summary>属性SelectedIndexs</summary>
		[DispId(11)]
		string SelectedIndexs
		{
			get;
			set;
		}

		/// <summary>属性SelectedItems</summary>
		[DispId(12)]
		ListItemCollection SelectedItems
		{
			get;
			set;
		}
	}
}
