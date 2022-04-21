using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;

namespace DCSoft.Writer
{
	/// <summary>
	///       超链接事件参数
	///       </summary>
	[ComDefaultInterface(typeof(IWriterLinkEventArgs))]
	
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[Guid("A7EA3FF9-EF4C-46DC-A8F6-DDA4978E80CF")]
	[ComClass("A7EA3FF9-EF4C-46DC-A8F6-DDA4978E80CF", "F3DFCF56-6C01-4B7B-81A2-1F83605AF4CD")]
	public class WriterLinkEventArgs : WriterEventArgs, IWriterLinkEventArgs
	{
		internal new const string CLASSID = "A7EA3FF9-EF4C-46DC-A8F6-DDA4978E80CF";

		internal new const string CLASSID_Interface = "F3DFCF56-6C01-4B7B-81A2-1F83605AF4CD";

		private string _Reference = null;

		private string _Target = null;

		/// <summary>
		///       链接引用的地址
		///       </summary>
		[DefaultValue(null)]
		
		public string Reference => _Reference;

		/// <summary>
		///       超链接地址目标。本属性不支持数据源和变量。
		///       </summary>
		/// <remarks>
		///       当报表元素设置了超连接，应用在WEB系统时，报表元素会输出HTML的A标签，此时该标签的href属性值为报表元素的Link属性值，
		///       而HTML标签的target属性值就是本属性的值。一般可以为"_blank","_media","_parent","_search" ,"_self","_top"。
		///       </remarks>
		[TypeConverter(typeof(TargetConverter))]
		
		[DefaultValue(null)]
		public virtual string Target => _Target;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="reference">引用的路径</param>
		/// <param name="target">目标框架</param>
		
		public WriterLinkEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string reference, string target)
			: base(writerControl_0, document, element)
		{
			_Reference = reference;
			_Target = target;
		}
	}
}
