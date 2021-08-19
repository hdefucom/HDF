using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocumentHeaderForFirstPageElement 的COM接口</summary>
	[Browsable(false)]
	[Guid("13244198-8DD8-4652-9D52-2AEF315D6FA5")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextDocumentHeaderForFirstPageElement
	{
		/// <summary>属性DataName</summary>
		[DispId(7)]
		string DataName
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(11)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(8)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性Modified</summary>
		[DispId(9)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>方法AppendContentElement</summary>
		[DispId(12)]
		void AppendContentElement(XTextElement element);

		/// <summary>方法AppendContentElements</summary>
		[DispId(13)]
		void AppendContentElements(XTextElementList elements);

		/// <summary>方法Focus</summary>
		[DispId(10)]
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
