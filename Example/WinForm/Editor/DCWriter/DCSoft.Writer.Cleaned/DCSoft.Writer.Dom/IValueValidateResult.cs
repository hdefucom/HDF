using DCSoft.Common;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>ValueValidateResult 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("0C3BFAF9-A7AD-4618-B0C3-ED9807B116DF")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IValueValidateResult
	{
		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ExcludeKeywordText</summary>
		[DispId(4)]
		string ExcludeKeywordText
		{
			get;
			set;
		}

		/// <summary>属性Level</summary>
		[DispId(7)]
		ValueValidateLevel Level
		{
			get;
			set;
		}

		/// <summary>属性Message</summary>
		[DispId(5)]
		string Message
		{
			get;
			set;
		}

		/// <summary>属性Type</summary>
		[DispId(6)]
		ValueValidateResultTypes Type
		{
			get;
			set;
		}

		/// <summary>方法Selet</summary>
		[DispId(2)]
		bool Selet();
	}
}
