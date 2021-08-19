using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>EventExpressionInfo 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("295CDC0C-1CE1-45D4-A364-204866DDA784")]
	public interface IEventExpressionInfo
	{
		/// <summary>属性CustomTargetName</summary>
		[DispId(2)]
		string CustomTargetName
		{
			get;
			set;
		}

		/// <summary>属性EventName</summary>
		[DispId(3)]
		string EventName
		{
			get;
			set;
		}

		/// <summary>属性Expression</summary>
		[DispId(4)]
		string Expression
		{
			get;
			set;
		}

		/// <summary>属性Target</summary>
		[DispId(5)]
		EventExpressionTarget Target
		{
			get;
			set;
		}

		/// <summary>属性TargetPropertyName</summary>
		[DispId(6)]
		string TargetPropertyName
		{
			get;
			set;
		}
	}
}
