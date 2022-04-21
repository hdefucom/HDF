using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       粘贴时检查病历编号的类型
	///       </summary>
	[ComVisible(true)]
	[Guid("BB1ADA19-0BCF-44A4-9AD7-E1C3445B84D8")]
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	
	
	public enum InsertDocumentWithCheckMRIDType
	{
		/// <summary>
		///       没有设置
		///       </summary>
		[DCDescription(typeof(InsertDocumentWithCheckMRIDType), "None")]
		None,
		/// <summary>
		///       若判断不通过则显示警告信息
		///       </summary>
		[DCDescription(typeof(InsertDocumentWithCheckMRIDType), "WarringWhenFail")]
		WarringWhenFail,
		/// <summary>
		///       若判断不通过则禁止操作，还显示提示信息
		///       </summary>
		[DCDescription(typeof(InsertDocumentWithCheckMRIDType), "PromptForbitWhenFail")]
		PromptForbitWhenFail,
		/// <summary>
		///       若判断不通过则禁止操作
		///       </summary>
		[DCDescription(typeof(InsertDocumentWithCheckMRIDType), "ForbitWhenFail")]
		ForbitWhenFail
	}
}
