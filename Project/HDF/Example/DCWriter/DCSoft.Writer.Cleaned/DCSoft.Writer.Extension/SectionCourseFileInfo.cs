using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       某次病程记录文件的信息对象
	///       </summary>
	[DocumentComment]
	[ComDefaultInterface(typeof(ISectionCourseFileInfo))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("6A0255A8-6B60-4C7C-8C2A-2EB19FF1FAFE", "E9B5F906-6776-419C-8466-FFBCEE754CB4")]
	[Guid("6A0255A8-6B60-4C7C-8C2A-2EB19FF1FAFE")]
	public class SectionCourseFileInfo : ISectionCourseFileInfo
	{
		internal const string CLASSID = "6A0255A8-6B60-4C7C-8C2A-2EB19FF1FAFE";

		internal const string CLASSID_Interface = "E9B5F906-6776-419C-8466-FFBCEE754CB4";

		/// <summary>
		///       需要加载文档内容
		///       </summary>
		internal bool NeedLoadDocumentContent = false;

		private string _FileName = null;

		private float _Top = 0f;

		private float _Height = 0f;

		/// <summary>
		///       文件名
		///       </summary>
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       文档在整个视图中的顶端位置
		///       </summary>
		public float Top
		{
			get
			{
				return _Top;
			}
			set
			{
				_Top = value;
			}
		}

		/// <summary>
		///       文档的视图高度
		///       </summary>
		public float Height
		{
			get
			{
				return _Height;
			}
			set
			{
				_Height = value;
			}
		}
	}
}
