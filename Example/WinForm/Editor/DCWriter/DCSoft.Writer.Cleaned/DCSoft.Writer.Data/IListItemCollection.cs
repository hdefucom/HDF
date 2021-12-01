using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>ListItemCollection 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("BD892CF8-D290-4F30-8794-160C62B151A4")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IListItemCollection
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		ListItem this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(ListItem item);

		/// <summary>方法AddByTextValue</summary>
		[DispId(11)]
		ListItem AddByTextValue(string Text, string Value);

		/// <summary>方法AddByTextValueSpellCode</summary>
		[DispId(12)]
		ListItem AddByTextValueSpellCode(string text, string Value, string spellCode);

		/// <summary>方法AddByTextValueTextInList</summary>
		[DispId(13)]
		ListItem AddByTextValueTextInList(string text, string Value, string textInList);

		/// <summary>方法Clear</summary>
		[DispId(14)]
		void Clear();

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(ListItem item);

		/// <summary>方法Remove</summary>
		[DispId(8)]
		bool Remove(ListItem item);
	}
}
