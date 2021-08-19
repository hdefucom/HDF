using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>HyperlinkInfo 的COM接口</summary>
	[Browsable(true)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("F772194F-D3F8-4C09-BB4F-6E9351123681")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IHyperlinkInfo
	{
		                                                                    /// <summary>属性IsEmpty</summary>
		[DispId(2)]
		bool IsEmpty
		{
			get;
		}

		                                                                    /// <summary>属性Reference</summary>
		[DispId(3)]
		string Reference
		{
			get;
			set;
		}

		                                                                    /// <summary>属性Target</summary>
		[DispId(4)]
		string Target
		{
			get;
			set;
		}

		                                                                    /// <summary>
		                                                                    ///       属性Title
		                                                                    ///       </summary>
		[DispId(5)]
		string Title
		{
			get;
			set;
		}
	}
}
