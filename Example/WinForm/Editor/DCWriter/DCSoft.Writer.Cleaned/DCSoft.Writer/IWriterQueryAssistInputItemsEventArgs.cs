using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterQueryAssistInputItemsEventArgs 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("3009CECC-4947-48D0-81D5-E94E5DDF77C6")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWriterQueryAssistInputItemsEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(4)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性ContainerElement</summary>
		[DispId(5)]
		XTextContainerElement ContainerElement
		{
			get;
		}

		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(7)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(8)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性PreWord</summary>
		[DispId(9)]
		string PreWord
		{
			get;
			set;
		}

		/// <summary>方法AddItem</summary>
		[DispId(2)]
		void AddItem(string item);

		/// <summary>方法GetItem</summary>
		[DispId(3)]
		string GetItem(int index);
	}
}
