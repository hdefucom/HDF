using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>KBEntryList 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("AE551F76-B49D-4EEE-980B-15CDB1C5AEF7")]
	public interface IKBEntryList
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		KBEntry this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(KBEntry item);

		/// <summary>方法Contains</summary>
		[DispId(3)]
		bool Contains(KBEntry item);

		/// <summary>方法Insert</summary>
		[DispId(7)]
		void Insert(int index, KBEntry item);

		/// <summary>方法Remove</summary>
		[DispId(8)]
		bool Remove(KBEntry item);
	}
}
