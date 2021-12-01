using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>GetLinkListItemsEventArgs 的COM接口</summary>
	[Browsable(false)]
	[Guid("C1DF2846-0F00-4E73-970D-DD8EB84C6328")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IGetLinkListItemsEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性CurrentBinding</summary>
		[DispId(3)]
		LinkListBindingInfo CurrentBinding
		{
			get;
			set;
		}

		/// <summary>属性CurrentElement</summary>
		[DispId(4)]
		XTextElement CurrentElement
		{
			get;
			set;
		}

		/// <summary>属性CurrentLevelBase0</summary>
		[DispId(10)]
		int CurrentLevelBase0
		{
			get;
		}

		/// <summary>属性EffectElements</summary>
		[DispId(11)]
		XTextElementList EffectElements
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(5)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Items</summary>
		[DispId(6)]
		ListItemCollection Items
		{
			get;
			set;
		}

		/// <summary>属性ParentBinding</summary>
		[DispId(7)]
		LinkListBindingInfo ParentBinding
		{
			get;
			set;
		}

		/// <summary>属性ParentElement</summary>
		[DispId(8)]
		XTextElement ParentElement
		{
			get;
			set;
		}

		/// <summary>属性ParentValue</summary>
		[DispId(9)]
		string ParentValue
		{
			get;
			set;
		}

		/// <summary>属性ProviderName</summary>
		[DispId(12)]
		string ProviderName
		{
			get;
		}
	}
}
