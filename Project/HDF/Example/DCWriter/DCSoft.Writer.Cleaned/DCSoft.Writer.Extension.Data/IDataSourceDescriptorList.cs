using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>DataSourceDescriptorList 的COM接口</summary>
	[Guid("333C6844-83AC-4890-A854-EB94FD29BC71")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IDataSourceDescriptorList
	{
		/// <summary>属性Count</summary>
		[DispId(10)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(11)]
		DataSourceDescriptor this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(DataSourceDescriptor item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(DataSourceDescriptor item);

		/// <summary>方法Remove</summary>
		[DispId(8)]
		bool Remove(DataSourceDescriptor item);

		/// <summary>方法RemoveAt</summary>
		[DispId(9)]
		void RemoveAt(int index);
	}
}
