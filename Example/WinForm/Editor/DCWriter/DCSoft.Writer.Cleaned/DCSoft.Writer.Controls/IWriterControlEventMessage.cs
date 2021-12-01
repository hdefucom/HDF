using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>WriterControlEventMessage 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("69AC547F-860C-4E11-8D79-95442A0C06EA")]
	public interface IWriterControlEventMessage
	{
		/// <summary>属性AltKey</summary>
		[DispId(2)]
		bool AltKey
		{
			get;
			set;
		}

		/// <summary>属性AltLeft</summary>
		[DispId(3)]
		bool AltLeft
		{
			get;
			set;
		}

		/// <summary>属性Button</summary>
		[DispId(4)]
		int Button
		{
			get;
			set;
		}

		/// <summary>属性CancelBubble</summary>
		[DispId(5)]
		bool CancelBubble
		{
			get;
			set;
		}

		/// <summary>属性ClientX</summary>
		[DispId(6)]
		float ClientX
		{
			get;
			set;
		}

		/// <summary>属性ClientY</summary>
		[DispId(7)]
		float ClientY
		{
			get;
			set;
		}

		/// <summary>属性ContextText</summary>
		[DispId(8)]
		string ContextText
		{
			get;
			set;
		}

		/// <summary>属性CtrlKey</summary>
		[DispId(9)]
		bool CtrlKey
		{
			get;
			set;
		}

		/// <summary>属性CtrlLeft</summary>
		[DispId(10)]
		bool CtrlLeft
		{
			get;
			set;
		}

		/// <summary>属性FromElement</summary>
		[DispId(11)]
		XTextElement FromElement
		{
			get;
			set;
		}

		/// <summary>属性KeyCode</summary>
		[DispId(12)]
		int KeyCode
		{
			get;
			set;
		}

		/// <summary>属性OffsetX</summary>
		[DispId(13)]
		float OffsetX
		{
			get;
			set;
		}

		/// <summary>属性OffsetY</summary>
		[DispId(14)]
		float OffsetY
		{
			get;
			set;
		}

		/// <summary>属性ReturnValue</summary>
		[DispId(15)]
		object ReturnValue
		{
			get;
			set;
		}

		/// <summary>属性ScreenX</summary>
		[DispId(16)]
		float ScreenX
		{
			get;
			set;
		}

		/// <summary>属性ScreenY</summary>
		[DispId(17)]
		float ScreenY
		{
			get;
			set;
		}

		/// <summary>属性ShiftKey</summary>
		[DispId(18)]
		bool ShiftKey
		{
			get;
			set;
		}

		/// <summary>属性ShiftLeft</summary>
		[DispId(19)]
		bool ShiftLeft
		{
			get;
			set;
		}

		/// <summary>属性SrcElement</summary>
		[DispId(20)]
		XTextElement SrcElement
		{
			get;
			set;
		}

		/// <summary>属性SrcElementID</summary>
		[DispId(33)]
		string SrcElementID
		{
			get;
		}

		/// <summary>属性SrcElementName</summary>
		[DispId(34)]
		string SrcElementName
		{
			get;
		}

		/// <summary>属性SrcElementTypeName</summary>
		[DispId(27)]
		string SrcElementTypeName
		{
			get;
		}

		/// <summary>属性SrcElementValue</summary>
		[DispId(35)]
		string SrcElementValue
		{
			get;
			set;
		}

		/// <summary>属性SrcInputFieldElement</summary>
		[DispId(28)]
		XTextInputFieldElement SrcInputFieldElement
		{
			get;
		}

		/// <summary>属性SrcSectionElement</summary>
		[DispId(29)]
		XTextSectionElement SrcSectionElement
		{
			get;
		}

		/// <summary>属性SrcTableCellElement</summary>
		[DispId(30)]
		XTextTableCellElement SrcTableCellElement
		{
			get;
		}

		/// <summary>属性SrcTableElement</summary>
		[DispId(31)]
		XTextTableElement SrcTableElement
		{
			get;
		}

		/// <summary>属性SrcTableRowElement</summary>
		[DispId(32)]
		XTextTableRowElement SrcTableRowElement
		{
			get;
		}

		/// <summary>属性StringReturnValue</summary>
		[DispId(21)]
		string StringReturnValue
		{
			get;
			set;
		}

		/// <summary>属性ToElement</summary>
		[DispId(22)]
		XTextElement ToElement
		{
			get;
			set;
		}

		/// <summary>属性Type</summary>
		[DispId(23)]
		string Type
		{
			get;
		}

		/// <summary>属性WheelDelta</summary>
		[DispId(24)]
		int WheelDelta
		{
			get;
			set;
		}

		/// <summary>属性X</summary>
		[DispId(25)]
		float X
		{
			get;
			set;
		}

		/// <summary>属性Y</summary>
		[DispId(26)]
		float Y
		{
			get;
			set;
		}
	}
}
