using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementEventTemplateList 的COM接口</summary>
	[ComVisible(true)]
	[Guid("BB0F62C0-A161-4AEB-B3F9-262D156B483B")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IElementEventTemplateList
	{
		/// <summary>属性Count</summary>
		[DispId(7)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(8)]
		ElementEventTemplate this[int index]
		{
			get;
			set;
		}

		/// <summary>属性Item</summary>
		[DispId(9)]
		ElementEventTemplate this[string name]
		{
			get;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(ElementEventTemplate item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(ElementEventTemplate item);

		/// <summary>方法Insert</summary>
		[DispId(5)]
		void Insert(int index, ElementEventTemplate item);

		/// <summary>方法Remove</summary>
		[DispId(6)]
		bool Remove(ElementEventTemplate item);
	}
}
