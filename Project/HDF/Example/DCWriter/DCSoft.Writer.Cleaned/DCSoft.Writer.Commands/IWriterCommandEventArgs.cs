using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>WriterCommandEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("BFEFA60E-5F2D-4590-B8AA-5B9C9EF0D198")]
	[Browsable(false)]
	public interface IWriterCommandEventArgs
	{
		/// <summary>属性Actived</summary>
		[DispId(2)]
		bool Actived
		{
			get;
			set;
		}

		/// <summary>属性AltKey</summary>
		[DispId(3)]
		bool AltKey
		{
			get;
			set;
		}

		/// <summary>属性Cancel</summary>
		[DispId(4)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性Checked</summary>
		[DispId(5)]
		bool Checked
		{
			get;
			set;
		}

		/// <summary>属性CommandControler</summary>
		[DispId(6)]
		WriterCommandControler CommandControler
		{
			get;
		}

		/// <summary>属性CtlKey</summary>
		[DispId(7)]
		bool CtlKey
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(8)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性DocumentControler</summary>
		[DispId(9)]
		DocumentControler DocumentControler
		{
			get;
		}

		/// <summary>属性EditorControl</summary>
		[DispId(10)]
		WriterControl EditorControl
		{
			get;
		}

		/// <summary>属性Enabled</summary>
		[DispId(11)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性Host</summary>
		[DispId(12)]
		WriterAppHost Host
		{
			get;
			set;
		}

		/// <summary>属性KeyChar</summary>
		[DispId(13)]
		char KeyChar
		{
			get;
		}

		/// <summary>属性KeyCodeValue</summary>
		[DispId(14)]
		int KeyCodeValue
		{
			get;
			set;
		}

		/// <summary>属性Mode</summary>
		[DispId(15)]
		WriterCommandEventMode Mode
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(16)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Parameter</summary>
		[DispId(17)]
		object Parameter
		{
			get;
			set;
		}

		/// <summary>属性RaiseFromUI</summary>
		[DispId(27)]
		bool RaiseFromUI
		{
			get;
			set;
		}

		/// <summary>属性RefreshLevel</summary>
		[DispId(18)]
		UIStateRefreshLevel RefreshLevel
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(19)]
		object Result
		{
			get;
			set;
		}

		/// <summary>属性Session</summary>
		[DispId(26)]
		Dictionary<string, object> Session
		{
			get;
		}

		/// <summary>属性ShiftKey</summary>
		[DispId(20)]
		bool ShiftKey
		{
			get;
			set;
		}

		/// <summary>属性ShowUI</summary>
		[DispId(21)]
		bool ShowUI
		{
			get;
			set;
		}

		/// <summary>属性SourceElement</summary>
		[DispId(22)]
		XTextElement SourceElement
		{
			get;
			set;
		}

		/// <summary>属性UIElement</summary>
		[DispId(23)]
		object UIElement
		{
			get;
			set;
		}

		/// <summary>属性UIEventArgs</summary>
		[DispId(24)]
		object UIEventArgs
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(25)]
		bool Visible
		{
			get;
			set;
		}
	}
}
