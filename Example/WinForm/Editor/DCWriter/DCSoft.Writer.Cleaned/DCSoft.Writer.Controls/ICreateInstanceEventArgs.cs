using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>CreateInstanceEventArgs 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("2DE060E8-A2EB-4879-9383-7387E7952DD7")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface ICreateInstanceEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性CommandName</summary>
		[DispId(3)]
		string CommandName
		{
			get;
		}

		/// <summary>属性CreatedInstance</summary>
		[DispId(4)]
		object CreatedInstance
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(5)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性InstanceTypeFullName</summary>
		[DispId(6)]
		string InstanceTypeFullName
		{
			get;
		}
	}
}
