using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Expression;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextRadioBoxElement 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("FA36AF8F-4188-4AAA-ABA2-621971228E34")]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextRadioBoxElement
	{
		/// <summary>属性Caption</summary>
		[DispId(20)]
		string Caption
		{
			get;
			set;
		}

		/// <summary>属性CaptionAlign</summary>
		[DispId(49)]
		StringAlignment CaptionAlign
		{
			get;
			set;
		}

		/// <summary>属性CheckAlignLeft</summary>
		[DispId(21)]
		bool CheckAlignLeft
		{
			get;
			set;
		}

		/// <summary>属性CheckboxVisibility</summary>
		[DispId(50)]
		RenderVisibility CheckboxVisibility
		{
			get;
			set;
		}

		/// <summary>属性Checked</summary>
		[DispId(22)]
		bool Checked
		{
			get;
			set;
		}

		/// <summary>属性CheckedValue</summary>
		[DispId(23)]
		string CheckedValue
		{
			get;
			set;
		}

		/// <summary>属性DataName</summary>
		[DispId(51)]
		string DataName
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(27)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(28)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EventExpressions</summary>
		[DispId(24)]
		EventExpressionInfoList EventExpressions
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(25)]
		string EventTemplateName
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

		/// <summary>属性InnerXML</summary>
		[DispId(33)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(36)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(37)]
		HyperlinkInfo LinkInfo
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

		/// <summary>属性Multiline</summary>
		[DispId(30)]
		bool Multiline
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(9)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(10)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(34)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(38)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(11)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(45)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(12)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(13)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintBoxOnlyChecked</summary>
		[DispId(39)]
		bool PrintBoxOnlyChecked
		{
			get;
			set;
		}

		/// <summary>属性PrintTextForChecked</summary>
		[DispId(40)]
		string PrintTextForChecked
		{
			get;
			set;
		}

		/// <summary>属性PrintTextForUnChecked</summary>
		[DispId(41)]
		string PrintTextForUnChecked
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(47)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibilityWhenUnchecked</summary>
		[DispId(48)]
		PrintVisibilityModeWhenUnchecked PrintVisibilityWhenUnchecked
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(42)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性StringTag</summary>
		[DispId(54)]
		string StringTag
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(14)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(15)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(32)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性UnCheckedValue</summary>
		[DispId(43)]
		string UnCheckedValue
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

		/// <summary>属性ValueBinding</summary>
		[DispId(44)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(46)]
		string ValueExpression
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

		/// <summary>属性Visible</summary>
		[DispId(16)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性VisualStyle</summary>
		[DispId(31)]
		CheckBoxVisualStyle VisualStyle
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(17)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法EndSetStyle</summary>
		[DispId(3)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(4)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(5)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(35)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(26)]
		bool HasAttribute(string name);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(52)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(53)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法SetAttribute</summary>
		[DispId(6)]
		bool SetAttribute(string name, string Value);
	}
}
