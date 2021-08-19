using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>XMLLinkListProvider 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("CEFF447F-988C-437C-BFB3-3E4725D186A1")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXMLLinkListProvider
	{
		/// <summary>属性Enabled</summary>
		[DispId(5)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(6)]
		string Name
		{
			get;
			set;
		}

		/// <summary>方法GetListItems</summary>
		[DispId(2)]
		void GetListItems(GetLinkListItemsEventArgs args);

		/// <summary>方法LoadXMLDocument</summary>
		[DispId(3)]
		void LoadXMLDocument(string fileName);

		/// <summary>方法LoadXMLString</summary>
		[DispId(4)]
		void LoadXMLString(string string_0);
	}
}
