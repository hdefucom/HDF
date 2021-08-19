using DCSoft.Drawing;
using DCSoft.Writer.Script;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextButtonElement 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("24096F15-6E09-4FA0-B4F6-25F11EB422B1")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IXTextButtonElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(5)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性AutoSize</summary>
		[DispId(34)]
		bool AutoSize
		{
			get;
			set;
		}

		/// <summary>属性CommandName</summary>
		[DispId(20)]
		string CommandName
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(6)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(21)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(22)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性FormulaValue</summary>
		[DispId(25)]
		string FormulaValue
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(26)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(7)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Image</summary>
		[DispId(35)]
		XImageValue Image
		{
			get;
			set;
		}

		/// <summary>属性ImageForDown</summary>
		[DispId(36)]
		XImageValue ImageForDown
		{
			get;
			set;
		}

		/// <summary>属性ImageForMouseOver</summary>
		[DispId(37)]
		XImageValue ImageForMouseOver
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(8)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(9)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(10)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性Parent</summary>
		[DispId(11)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(38)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(39)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(12)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Printable</summary>
		[DispId(13)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(23)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性ScriptItems</summary>
		[DispId(14)]
		VBScriptItemList ScriptItems
		{
			get;
			set;
		}

		/// <summary>属性ScriptTextForClick</summary>
		[DispId(15)]
		string ScriptTextForClick
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(16)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(17)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(18)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(19)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(27)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法GetAttribute</summary>
		[DispId(2)]
		string GetAttribute(string name);

		/// <summary>方法HasAttribute</summary>
		[DispId(3)]
		bool HasAttribute(string name);

		/// <summary>方法LoadImageForDownFromBase64String</summary>
		[DispId(28)]
		void LoadImageForDownFromBase64String(string base64);

		/// <summary>方法LoadImageForDownFromFile</summary>
		[DispId(29)]
		void LoadImageForDownFromFile(string fileName);

		/// <summary>方法LoadImageForMouseOverFromBase64String</summary>
		[DispId(30)]
		void LoadImageForMouseOverFromBase64String(string base64);

		/// <summary>方法LoadImageForMouseOverFromFile</summary>
		[DispId(31)]
		void LoadImageForMouseOverFromFile(string fileName);

		/// <summary>方法LoadImageFromBase64String</summary>
		[DispId(32)]
		void LoadImageFromBase64String(string base64);

		/// <summary>方法LoadImageFromFile</summary>
		[DispId(33)]
		void LoadImageFromFile(string fileName);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(40)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(41)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(24)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(4)]
		bool SetAttribute(string name, string Value);
	}
}
