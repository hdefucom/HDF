using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>WriterShowDialogEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("F3ADC9B8-DFEE-4497-A454-74698A62051D")]
	public interface IWriterShowDialogEventArgs
	{
		/// <summary>属性DialogResult</summary>
		[DispId(2)]
		DialogResult DialogResult
		{
			get;
			set;
		}

		/// <summary>属性DialogTypeName</summary>
		[DispId(3)]
		string DialogTypeName
		{
			get;
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
		[DispId(6)]
		bool Handled
		{
			get;
			set;
		}
	}
}
