using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentEventArgs 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("693A4F9F-5DE9-4AB8-A630-FA40E11379DC")]
	public interface IDocumentEventArgs
	{
		/// <summary>属性AltKey</summary>
		[DispId(2)]
		bool AltKey
		{
			get;
		}

		/// <summary>属性ButtonValue</summary>
		[DispId(3)]
		int ButtonValue
		{
			get;
		}

		/// <summary>属性ClientX</summary>
		[DispId(5)]
		int ClientX
		{
			get;
		}

		/// <summary>属性ClientY</summary>
		[DispId(6)]
		int ClientY
		{
			get;
		}

		/// <summary>属性CtlKey</summary>
		[DispId(7)]
		bool CtlKey
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(8)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(9)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(4)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性KeyCharValue</summary>
		[DispId(10)]
		int KeyCharValue
		{
			get;
		}

		/// <summary>属性KeyCodeValue</summary>
		[DispId(11)]
		int KeyCodeValue
		{
			get;
		}

		/// <summary>属性MouseClicks</summary>
		[DispId(12)]
		int MouseClicks
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(13)]
		string Name
		{
			get;
		}

		/// <summary>属性ReturnValue</summary>
		[DispId(14)]
		object ReturnValue
		{
			get;
			set;
		}

		/// <summary>属性ShiftKey</summary>
		[DispId(15)]
		bool ShiftKey
		{
			get;
		}

		/// <summary>属性StrictMatch</summary>
		[DispId(16)]
		bool StrictMatch
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(17)]
		DocumentEventStyles Style
		{
			get;
		}

		/// <summary>属性Tooltip</summary>
		[DispId(18)]
		string Tooltip
		{
			get;
			set;
		}

		/// <summary>属性ViewX</summary>
		[DispId(22)]
		float ViewX
		{
			get;
		}

		/// <summary>属性ViewY</summary>
		[DispId(23)]
		float ViewY
		{
			get;
		}

		/// <summary>属性WheelDelta</summary>
		[DispId(19)]
		int WheelDelta
		{
			get;
		}

		/// <summary>属性X</summary>
		[DispId(20)]
		int X
		{
			get;
		}

		/// <summary>属性Y</summary>
		[DispId(21)]
		int Y
		{
			get;
		}
	}
}
