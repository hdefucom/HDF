using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>LinkListProvider 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("6271A999-743F-4068-80B4-E3D48EB288B3")]
	public interface ILinkListProvider
	{
		/// <summary>属性Enabled</summary>
		[DispId(3)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(4)]
		string Name
		{
			get;
			set;
		}

		/// <summary>方法GetListItems</summary>
		[DispId(2)]
		void GetListItems(GetLinkListItemsEventArgs args);
	}
}
