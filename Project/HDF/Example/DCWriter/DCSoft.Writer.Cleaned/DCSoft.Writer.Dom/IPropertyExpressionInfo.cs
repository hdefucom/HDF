using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PropertyExpressionInfo 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("BD628F91-A17B-4DBF-9519-DA77C9A252D0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPropertyExpressionInfo
	{
		/// <summary>属性AllowChainReaction</summary>
		[DispId(4)]
		bool AllowChainReaction
		{
			get;
			set;
		}

		/// <summary>属性Expression</summary>
		[DispId(2)]
		string Expression
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(3)]
		string Name
		{
			get;
			set;
		}
	}
}
