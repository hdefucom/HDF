using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>SubDocumentSettings 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("9F6C58B6-5389-4561-A5D9-02DBE019FC07")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISubDocumentSettings
	{
		/// <summary>属性AllowSave</summary>
		[DispId(3)]
		bool AllowSave
		{
			get;
			set;
		}

		/// <summary>属性BackColor</summary>
		[DispId(4)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性BackColorValue</summary>
		[DispId(5)]
		string BackColorValue
		{
			get;
			set;
		}

		/// <summary>属性BorderColor</summary>
		[DispId(6)]
		Color BorderColor
		{
			get;
			set;
		}

		/// <summary>属性BorderColorValue</summary>
		[DispId(7)]
		string BorderColorValue
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(8)]
		bool EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性Locked</summary>
		[DispId(9)]
		bool Locked
		{
			get;
			set;
		}

		/// <summary>属性NewPage</summary>
		[DispId(10)]
		bool NewPage
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(11)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性SubDocumentSpacing</summary>
		[DispId(12)]
		float SubDocumentSpacing
		{
			get;
			set;
		}

		/// <summary>方法Clone</summary>
		[DispId(2)]
		SubDocumentSettings Clone();
	}
}
