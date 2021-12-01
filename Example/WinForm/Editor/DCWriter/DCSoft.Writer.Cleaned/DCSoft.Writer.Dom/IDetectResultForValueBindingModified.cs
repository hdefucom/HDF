using DCSoft.Writer.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DetectResultForValueBindingModified 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("04099AAE-3E03-4F64-88EA-E9F22FED98E1")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IDetectResultForValueBindingModified
	{
		/// <summary>属性Binding</summary>
		[DispId(2)]
		XDataBinding Binding
		{
			get;
		}

		/// <summary>属性CurrentValue</summary>
		[DispId(3)]
		string CurrentValue
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性NewValue</summary>
		[DispId(5)]
		string NewValue
		{
			get;
		}
	}
}
