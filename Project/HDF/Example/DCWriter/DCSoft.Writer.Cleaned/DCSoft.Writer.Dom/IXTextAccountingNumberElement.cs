using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextAccountingNumberElement 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("87BA328F-7682-49DC-A732-6DEAD74BD635")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextAccountingNumberElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(6)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Digitals</summary>
		[DispId(7)]
		int Digitals
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(8)]
		bool Focused
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(9)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(10)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(11)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(12)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(13)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(14)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintGrid</summary>
		[DispId(15)]
		bool PrintGrid
		{
			get;
			set;
		}

		/// <summary>属性ShowGrid</summary>
		[DispId(16)]
		bool ShowGrid
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(19)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性UnitMode</summary>
		[DispId(17)]
		AccountingNumberUnitMode UnitMode
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(18)]
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

		/// <summary>方法Select</summary>
		[DispId(4)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(5)]
		bool SetAttribute(string name, string Value);
	}
}
