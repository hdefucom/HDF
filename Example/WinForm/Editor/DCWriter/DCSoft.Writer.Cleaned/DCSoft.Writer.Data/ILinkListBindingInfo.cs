using DCSoft.Writer.Expression;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>LinkListBindingInfo 的COM接口</summary>
	[Browsable(false)]
	[Guid("65A1AF66-AFF6-4C62-86E4-37E18958CAFA")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface ILinkListBindingInfo
	{
		/// <summary>属性AutoSetFirstItems</summary>
		[DispId(3)]
		bool AutoSetFirstItems
		{
			get;
			set;
		}

		/// <summary>属性AutoUpdateTargetElement</summary>
		[DispId(4)]
		bool AutoUpdateTargetElement
		{
			get;
			set;
		}

		/// <summary>属性DataBoundItem</summary>
		[DispId(5)]
		object DataBoundItem
		{
			get;
			set;
		}

		/// <summary>属性IsRoot</summary>
		[DispId(6)]
		bool IsRoot
		{
			get;
			set;
		}

		/// <summary>属性NextTarget</summary>
		[DispId(7)]
		EventExpressionTarget NextTarget
		{
			get;
			set;
		}

		/// <summary>属性NextTargetID</summary>
		[DispId(8)]
		string NextTargetID
		{
			get;
			set;
		}

		/// <summary>属性ProviderName</summary>
		[DispId(9)]
		string ProviderName
		{
			get;
			set;
		}

		/// <summary>属性UserFlag</summary>
		[DispId(10)]
		string UserFlag
		{
			get;
			set;
		}

		/// <summary>方法Clone</summary>
		[DispId(2)]
		LinkListBindingInfo Clone();
	}
}
