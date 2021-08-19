using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>FilterValueEventArgs 的COM接口</summary>
	[Guid("3031DB88-078B-46EB-A94A-5691D9F70A25")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IFilterValueEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性Source</summary>
		[DispId(3)]
		InputValueSource Source
		{
			get;
			set;
		}

		/// <summary>属性SourceName</summary>
		[DispId(4)]
		string SourceName
		{
			get;
			set;
		}

		/// <summary>属性Type</summary>
		[DispId(5)]
		InputValueType Type
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(6)]
		object Value
		{
			get;
			set;
		}
	}
}
