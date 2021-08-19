using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>QueryListItemsEventArgs 的COM接口</summary>
	[Guid("4D942086-7734-4F28-98AB-AA2069DDA552")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IQueryListItemsEventArgs
	{
		/// <summary>属性BufferItems</summary>
		[DispId(2)]
		bool BufferItems
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(4)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(5)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(3)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性KBEntry</summary>
		[DispId(10)]
		KBEntry KBEntry
		{
			get;
			set;
		}

		/// <summary>属性ListSourceName</summary>
		[DispId(9)]
		string ListSourceName
		{
			get;
			set;
		}

		/// <summary>属性PreText</summary>
		[DispId(11)]
		string PreText
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(12)]
		ListItemCollection Result
		{
			get;
			set;
		}

		/// <summary>属性SpellCode</summary>
		[DispId(7)]
		string SpellCode
		{
			get;
			set;
		}
	}
}
