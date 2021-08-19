using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DocumentWriterControlOptions 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("64724F79-BCEA-4324-9019-0183EE7C984E")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDocumentWriterControlOptions
	{
		/// <summary>属性AcceptDataFormats</summary>
		[DispId(2)]
		WriterDataFormats AcceptDataFormats
		{
			get;
			set;
		}

		/// <summary>属性AllowDragContent</summary>
		[DispId(3)]
		bool AllowDragContent
		{
			get;
			set;
		}

		/// <summary>属性AllowDrop</summary>
		[DispId(4)]
		bool AllowDrop
		{
			get;
			set;
		}

		/// <summary>属性AutoSetDocumentDefaultFont</summary>
		[DispId(17)]
		bool AutoSetDocumentDefaultFont
		{
			get;
			set;
		}

		/// <summary>属性AutoUserLogin</summary>
		[DispId(5)]
		bool AutoUserLogin
		{
			get;
			set;
		}

		/// <summary>属性CommentVisibility</summary>
		[DispId(6)]
		FunctionControlVisibility CommentVisibility
		{
			get;
			set;
		}

		/// <summary>属性CreationDataFormats</summary>
		[DispId(7)]
		WriterDataFormats CreationDataFormats
		{
			get;
			set;
		}

		/// <summary>属性EnabledElementEvent</summary>
		[DispId(8)]
		bool EnabledElementEvent
		{
			get;
			set;
		}

		/// <summary>属性FormView</summary>
		[DispId(9)]
		FormViewMode FormView
		{
			get;
			set;
		}

		/// <summary>属性HeaderFooterReadonly</summary>
		[DispId(10)]
		bool HeaderFooterReadonly
		{
			get;
			set;
		}

		/// <summary>属性IsAdministrator</summary>
		[DispId(11)]
		bool IsAdministrator
		{
			get;
			set;
		}

		/// <summary>属性MoveFocusHotKey</summary>
		[DispId(12)]
		MoveFocusHotKeys MoveFocusHotKey
		{
			get;
			set;
		}

		/// <summary>属性PageTitlePosition</summary>
		[DispId(13)]
		PageTitlePosition PageTitlePosition
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(14)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性ReadViewMode</summary>
		[DispId(15)]
		bool ReadViewMode
		{
			get;
			set;
		}

		/// <summary>属性ViewMode</summary>
		[DispId(16)]
		PageViewMode ViewMode
		{
			get;
			set;
		}
	}
}
