using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>CanInsertObjectEventArgs 的COM接口</summary>
	[Guid("D3361D0B-CBF6-41B8-8708-3719B96E9DF5")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ICanInsertObjectEventArgs
	{
		/// <summary>属性AccessFlags</summary>
		[DispId(5)]
		DomAccessFlags AccessFlags
		{
			get;
			set;
		}

		/// <summary>属性AllowDataFormats</summary>
		[DispId(6)]
		WriterDataFormats AllowDataFormats
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

		/// <summary>属性Handled</summary>
		[DispId(10)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Position</summary>
		[DispId(11)]
		int Position
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(12)]
		bool Result
		{
			get;
			set;
		}

		/// <summary>属性SpecifyFormat</summary>
		[DispId(13)]
		string SpecifyFormat
		{
			get;
			set;
		}

		/// <summary>属性SpecifyPosition</summary>
		[DispId(14)]
		int SpecifyPosition
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
