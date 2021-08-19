using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PropertyExpressionInfoList 的COM接口</summary>
	[Guid("A9022DCB-008A-4A3E-9504-3392A73C5FC7")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IPropertyExpressionInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(5)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(6)]
		PropertyExpressionInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(PropertyExpressionInfo item);

		/// <summary>方法GetValue</summary>
		[DispId(3)]
		string GetValue(string memberName);

		/// <summary>方法SetValue</summary>
		[DispId(4)]
		void SetValue(string memberName, string expression);

		/// <summary>方法SetValueExt</summary>
		[DispId(7)]
		void SetValueExt(string memberName, string expression, bool allowChainReaction);
	}
}
