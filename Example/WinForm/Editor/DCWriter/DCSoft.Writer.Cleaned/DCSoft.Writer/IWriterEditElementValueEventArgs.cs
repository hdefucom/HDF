using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterEditElementValueEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("61814E57-A693-4A00-BA18-CF959E2C68D0")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IWriterEditElementValueEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性FieldElement</summary>
		[DispId(4)]
		XTextInputFieldElement FieldElement
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(5)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(6)]
		ElementValueEditResult Result
		{
			get;
			set;
		}
	}
}
