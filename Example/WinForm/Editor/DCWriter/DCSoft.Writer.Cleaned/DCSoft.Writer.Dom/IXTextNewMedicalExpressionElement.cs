using DCSoft.Drawing;
using DCSoft.Writer.MedicalExpression;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextNewMedicalExpressionElement 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("67E28F15-15A0-4F8B-89C0-3210F4B8FA53")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IXTextNewMedicalExpressionElement
	{
		/// <summary>属性Deleteable</summary>
		[DispId(9)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(10)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性ExpressionStyle</summary>
		[DispId(11)]
		DCMedicalExpressionStyle ExpressionStyle
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(16)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(12)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(13)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性VAlign</summary>
		[DispId(14)]
		VerticalAlignStyle VAlign
		{
			get;
			set;
		}

		/// <summary>属性Values</summary>
		[DispId(15)]
		MedicalExpressionValueList Values
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

		/// <summary>方法EditorSetStyle</summary>
		[DispId(2)]
		bool EditorSetStyle(DocumentContentStyle style);

		/// <summary>方法GetAttribute</summary>
		[DispId(3)]
		string GetAttribute(string name);

		/// <summary>方法GetItemValue</summary>
		[DispId(4)]
		string GetItemValue(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(5)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(6)]
		bool HasAttribute(string name);

		/// <summary>方法SetAttribute</summary>
		[DispId(7)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetItemValue</summary>
		[DispId(8)]
		void SetItemValue(string name, string newValue);
	}
}
