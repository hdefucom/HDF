using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>DCCardListViewItem 的COM接口</summary>
	[ComVisible(true)]
	[Guid("041D958B-8C97-4A98-ACFC-7E43C394EABC")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDCCardListViewItem
	{
		/// <summary>属性AutoLine</summary>
		[DispId(5)]
		bool AutoLine
		{
			get;
			set;
		}

		/// <summary>属性BackColor</summary>
		[DispId(6)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性Blink</summary>
		[DispId(7)]
		bool Blink
		{
			get;
			set;
		}

		/// <summary>属性BorderColor</summary>
		[DispId(8)]
		Color BorderColor
		{
			get;
			set;
		}

		/// <summary>属性BorderWidth</summary>
		[DispId(9)]
		int BorderWidth
		{
			get;
			set;
		}

		/// <summary>属性ColumnIndex</summary>
		[DispId(10)]
		int ColumnIndex
		{
			get;
		}

		/// <summary>属性Highlight</summary>
		[DispId(11)]
		bool Highlight
		{
			get;
			set;
		}

		/// <summary>属性HighlightBorder</summary>
		[DispId(12)]
		bool HighlightBorder
		{
			get;
			set;
		}

		/// <summary>属性Index</summary>
		[DispId(13)]
		int Index
		{
			get;
		}

		/// <summary>属性Name</summary>
		[DispId(14)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Pushed</summary>
		[DispId(15)]
		bool Pushed
		{
			get;
			set;
		}

		/// <summary>属性RowIndex</summary>
		[DispId(16)]
		int RowIndex
		{
			get;
		}

		/// <summary>属性Selected</summary>
		[DispId(17)]
		bool Selected
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(18)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>方法GetStringValue</summary>
		[DispId(19)]
		string GetStringValue(string fieldName);

		/// <summary>方法Invalidate</summary>
		[DispId(2)]
		void Invalidate();

		/// <summary>方法SetImageValueByFileName</summary>
		[DispId(3)]
		bool SetImageValueByFileName(string dataFieldName, string fileName);

		/// <summary>方法SetStringValue</summary>
		[DispId(4)]
		bool SetStringValue(string dataFieldName, string textValue);
	}
}
