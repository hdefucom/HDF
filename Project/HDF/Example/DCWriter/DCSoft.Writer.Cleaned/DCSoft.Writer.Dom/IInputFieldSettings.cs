using DCSoft.Writer.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>InputFieldSettings 的COM接口</summary>
	[Guid("6C95AC4B-26D3-4EAA-9C1E-4F0B015E8CE5")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IInputFieldSettings
	{
		/// <summary>属性DynamicListItems</summary>
		[DispId(2)]
		bool DynamicListItems
		{
			get;
			set;
		}

		/// <summary>属性EditStyle</summary>
		[DispId(3)]
		InputFieldEditStyle EditStyle
		{
			get;
			set;
		}

		/// <summary>属性EnableCustomListItems</summary>
		[DispId(8)]
		bool EnableCustomListItems
		{
			get;
			set;
		}

		/// <summary>属性GetValueOrderByTime</summary>
		[DispId(9)]
		bool GetValueOrderByTime
		{
			get;
			set;
		}

		/// <summary>属性ListSource</summary>
		[DispId(4)]
		ListSourceInfo ListSource
		{
			get;
			set;
		}

		/// <summary>属性ListValueFormatString</summary>
		[DispId(5)]
		string ListValueFormatString
		{
			get;
			set;
		}

		/// <summary>属性ListValueSeparatorChar</summary>
		[DispId(6)]
		string ListValueSeparatorChar
		{
			get;
			set;
		}

		/// <summary>属性MultiColumn</summary>
		[DispId(10)]
		bool MultiColumn
		{
			get;
			set;
		}

		/// <summary>属性MultiSelect</summary>
		[DispId(7)]
		bool MultiSelect
		{
			get;
			set;
		}
	}
}
