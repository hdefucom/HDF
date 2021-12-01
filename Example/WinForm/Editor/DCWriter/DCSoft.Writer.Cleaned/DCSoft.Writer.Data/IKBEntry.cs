using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>KBEntry 的COM接口</summary>
	[Guid("04459E25-93E0-4256-8F3D-E7B1F4B1BD1D")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IKBEntry
	{
		/// <summary>属性EntryTemplateContent</summary>
		[DispId(17)]
		string EntryTemplateContent
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(2)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性ListIndex</summary>
		[DispId(3)]
		int ListIndex
		{
			get;
			set;
		}

		/// <summary>属性ListItems</summary>
		[DispId(4)]
		ListItemCollection ListItems
		{
			get;
			set;
		}

		/// <summary>属性ListItemsSource</summary>
		[DispId(5)]
		string ListItemsSource
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(18)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性OwnerID</summary>
		[DispId(6)]
		string OwnerID
		{
			get;
			set;
		}

		/// <summary>属性OwnerLevel</summary>
		[DispId(7)]
		EntryOwnerLevel OwnerLevel
		{
			get;
			set;
		}

		/// <summary>属性Parent</summary>
		[DispId(8)]
		KBEntry Parent
		{
			get;
			set;
		}

		/// <summary>属性ParentID</summary>
		[DispId(9)]
		string ParentID
		{
			get;
			set;
		}

		/// <summary>属性RangeMask</summary>
		[DispId(21)]
		int RangeMask
		{
			get;
			set;
		}

		/// <summary>属性SpellCode</summary>
		[DispId(10)]
		string SpellCode
		{
			get;
			set;
		}

		/// <summary>属性SpellCode2</summary>
		[DispId(11)]
		string SpellCode2
		{
			get;
			set;
		}

		/// <summary>属性SpellCode3</summary>
		[DispId(12)]
		string SpellCode3
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(13)]
		KBEntryStyle Style
		{
			get;
			set;
		}

		/// <summary>属性SubEntries</summary>
		[DispId(14)]
		KBEntryList SubEntries
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(15)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Text2</summary>
		[DispId(19)]
		string Text2
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(16)]
		string Value
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(20)]
		bool Visible
		{
			get;
			set;
		}
	}
}
