using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>CollectProtectedElementsEventArgs 的COM接口</summary>
	[Guid("C663CDE8-C62E-41A5-AAE1-CC7C94816A0B")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICollectProtectedElementsEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性Infos</summary>
		[DispId(4)]
		GClass108 Infos
		{
			get;
			set;
		}

		/// <summary>属性LimitedCount</summary>
		[DispId(5)]
		int LimitedCount
		{
			get;
			set;
		}

		/// <summary>属性RootElements</summary>
		[DispId(6)]
		XTextElementList RootElements
		{
			get;
		}
	}
}
