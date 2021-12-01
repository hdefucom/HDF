using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>SetContainerTextArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("12D3C309-EADD-4676-A08A-BE94889047AC")]
	public interface ISetContainerTextArgs
	{
		/// <summary>属性AccessFlags</summary>
		[DispId(2)]
		DomAccessFlags AccessFlags
		{
			get;
			set;
		}

		/// <summary>属性DisablePermission</summary>
		[DispId(3)]
		bool DisablePermission
		{
			get;
			set;
		}

		/// <summary>属性LogUndo</summary>
		[DispId(4)]
		bool LogUndo
		{
			get;
			set;
		}

		/// <summary>属性NewText</summary>
		[DispId(5)]
		string NewText
		{
			get;
			set;
		}

		/// <summary>属性NewTextStyle</summary>
		[DispId(6)]
		DocumentContentStyle NewTextStyle
		{
			get;
			set;
		}

		/// <summary>属性RaiseEvent</summary>
		[DispId(7)]
		bool RaiseEvent
		{
			get;
			set;
		}

		/// <summary>属性UpdateContent</summary>
		[DispId(8)]
		bool UpdateContent
		{
			get;
			set;
		}
	}
}
