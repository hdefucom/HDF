using DCSoft.Writer.Security;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DocumentOptions 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("71B9BF56-ABD2-441E-A401-0F36367A01AE")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDocumentOptions
	{
		/// <summary>属性BehaviorOptions</summary>
		[DispId(2)]
		DocumentBehaviorOptions BehaviorOptions
		{
			get;
			set;
		}

		/// <summary>属性EditOptions</summary>
		[DispId(3)]
		DocumentEditOptions EditOptions
		{
			get;
			set;
		}

		/// <summary>属性SecurityOptions</summary>
		[DispId(4)]
		DocumentSecurityOptions SecurityOptions
		{
			get;
			set;
		}

		/// <summary>属性ViewOptions</summary>
		[DispId(5)]
		DocumentViewOptions ViewOptions
		{
			get;
			set;
		}
	}
}
