using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>ListItem 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("1B5A7174-A133-4613-8DE9-BA77C1706664")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IListItem
	{
		/// <summary>属性EntryID</summary>
		[DispId(12)]
		string EntryID
		{
			get;
			set;
		}

		/// <summary>属性Group</summary>
		[DispId(2)]
		string Group
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

		/// <summary>属性ListIndex</summary>
		[DispId(4)]
		int ListIndex
		{
			get;
			set;
		}

		/// <summary>属性SpellCode</summary>
		[DispId(5)]
		string SpellCode
		{
			get;
			set;
		}

		/// <summary>属性SpellCode2</summary>
		[DispId(6)]
		string SpellCode2
		{
			get;
			set;
		}

		/// <summary>属性SpellCode3</summary>
		[DispId(7)]
		string SpellCode3
		{
			get;
			set;
		}

		/// <summary>属性Tag</summary>
		[DispId(8)]
		string Tag
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(9)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Text2</summary>
		[DispId(11)]
		string Text2
		{
			get;
			set;
		}

		/// <summary>属性TextInList</summary>
		[DispId(13)]
		string TextInList
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(10)]
		string Value
		{
			get;
			set;
		}
	}
}
