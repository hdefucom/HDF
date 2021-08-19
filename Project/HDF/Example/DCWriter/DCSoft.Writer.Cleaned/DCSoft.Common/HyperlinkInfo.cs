using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       超链接信息
	                                                                    ///       </summary>
	[Serializable]
	[TypeConverter(typeof(HyperlinkInfoTypeConverter))]
	[DocumentComment]
	[Guid("14D72F1A-47FB-4EA9-BAAC-B352DD96088A")]
	[Editor(typeof(HyperlinkInfoEditor), typeof(UITypeEditor))]
	[ComVisible(true)]
	public class HyperlinkInfo : IHyperlinkInfo
	{
		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		                                                                    /// <summary>
		                                                                    ///       链接引用的地址
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Reference
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       超链接地址目标。本属性不支持数据源和变量。
		                                                                    ///       </summary>
		                                                                    /// <remarks>
		                                                                    ///       当报表元素设置了超连接，应用在WEB系统时，报表元素会输出HTML的A标签，此时该标签的href属性值为报表元素的Link属性值，
		                                                                    ///       而HTML标签的target属性值就是本属性的值。一般可以为"_blank","_media","_parent","_search" ,"_self","_top"。
		                                                                    ///       </remarks>
		[DefaultValue(null)]
		[TypeConverter(typeof(TargetConverter))]
		public string Target
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       标题
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断内容是否为空
		                                                                    ///       </summary>
		[Browsable(false)]
		public bool IsEmpty => string.IsNullOrEmpty(Reference);

		public HyperlinkInfo method_0()
		{
			return (HyperlinkInfo)MemberwiseClone();
		}

		                                                                    /// <summary>
		                                                                    ///       返回表示对象的字符串
		                                                                    ///       </summary>
		                                                                    /// <returns>字符串</returns>
		public override string ToString()
		{
			return Reference;
		}
	}
}
