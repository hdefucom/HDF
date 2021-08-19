using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>InsertObjectEventArgs 的COM接口</summary>
	[Guid("C8B8395D-3AF2-4502-A9A9-79A7D8FE48F2")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IInsertObjectEventArgs
	{
		/// <summary>属性AllowDataFormats</summary>
		[DispId(5)]
		WriterDataFormats AllowDataFormats
		{
			get;
			set;
		}

		/// <summary>属性AllowedEffect</summary>
		[DispId(18)]
		DragDropEffects AllowedEffect
		{
			get;
			set;
		}

		/// <summary>属性AutoSelectContent</summary>
		[DispId(6)]
		bool AutoSelectContent
		{
			get;
			set;
		}

		/// <summary>属性ContainerElement</summary>
		[DispId(7)]
		XTextContainerElement ContainerElement
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(8)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性DocumentControler</summary>
		[DispId(9)]
		DocumentControler DocumentControler
		{
			get;
			set;
		}

		/// <summary>属性DragEffect</summary>
		[DispId(19)]
		DragDropEffects DragEffect
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(10)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性InputSource</summary>
		[DispId(11)]
		InputValueSource InputSource
		{
			get;
			set;
		}

		/// <summary>属性NewElements</summary>
		[DispId(17)]
		XTextElementList NewElements
		{
			get;
			set;
		}

		/// <summary>属性Position</summary>
		[DispId(12)]
		int Position
		{
			get;
			set;
		}

		/// <summary>属性RejectFormats</summary>
		[DispId(16)]
		List<string> RejectFormats
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(13)]
		bool Result
		{
			get;
			set;
		}

		/// <summary>属性ShowUI</summary>
		[DispId(14)]
		bool ShowUI
		{
			get;
			set;
		}

		/// <summary>属性SpecifyFormat</summary>
		[DispId(15)]
		string SpecifyFormat
		{
			get;
			set;
		}

		/// <summary>方法GetData</summary>
		[DispId(2)]
		object GetData(string format);

		/// <summary>方法GetDataPresent</summary>
		[DispId(3)]
		bool GetDataPresent(string format);

		/// <summary>方法GetFormats</summary>
		[DispId(4)]
		string[] GetFormats();
	}
}
