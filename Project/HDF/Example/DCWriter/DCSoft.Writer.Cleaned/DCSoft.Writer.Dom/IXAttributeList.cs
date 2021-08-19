using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XAttributeList 的COM接口</summary>
	[ComVisible(true)]
	[Guid("2AFDACB6-DDCD-4A96-852A-8B980079E70E")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXAttributeList
	{
		/// <summary>属性Count</summary>
		[DispId(12)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(13)]
		XAttribute this[int index]
		{
			get;
			set;
		}

		/// <summary>属性Item</summary>
		[DispId(14)]
		XAttribute this[string name]
		{
			get;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(XAttribute item);

		/// <summary>方法Contains</summary>
		[DispId(3)]
		bool Contains(XAttribute item);

		/// <summary>方法ContainsByName</summary>
		[DispId(4)]
		bool ContainsByName(string name);

		/// <summary>方法GetValue</summary>
		[DispId(5)]
		string GetValue(string name);

		/// <summary>方法Remove</summary>
		[DispId(9)]
		bool Remove(XAttribute item);

		/// <summary>方法RemoveByName</summary>
		[DispId(10)]
		void RemoveByName(string name);

		/// <summary>方法SetValue</summary>
		[DispId(11)]
		void SetValue(string name, string Value);
	}
}
