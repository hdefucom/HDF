using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>EventExpressionInfoList 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("5F8FD594-BDA8-4BF4-92CC-BDFB7775B560")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IEventExpressionInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		EventExpressionInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(EventExpressionInfo item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法Remove</summary>
		[DispId(7)]
		bool Remove(EventExpressionInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(8)]
		void RemoveAt(int index);
	}
}
