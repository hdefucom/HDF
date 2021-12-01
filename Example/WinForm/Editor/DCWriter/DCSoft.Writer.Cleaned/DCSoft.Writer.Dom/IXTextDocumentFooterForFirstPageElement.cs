using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocumentFooterForFirstPageElement 的COM接口</summary>
	[Guid("8A8EDE39-9B6A-4A5A-945A-82F4E8FA1997")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextDocumentFooterForFirstPageElement
	{
		/// <summary>属性Elements</summary>
		[DispId(7)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(8)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>方法Focus</summary>
		[DispId(9)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(2)]
		string GetAttribute(string name);

		/// <summary>方法HasAttribute</summary>
		[DispId(3)]
		bool HasAttribute(string name);

		/// <summary>方法RemoveChild</summary>
		[DispId(4)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法SelectFirstLine</summary>
		[DispId(5)]
		bool SelectFirstLine();

		/// <summary>方法SetAttribute</summary>
		[DispId(6)]
		bool SetAttribute(string name, string Value);
	}
}
