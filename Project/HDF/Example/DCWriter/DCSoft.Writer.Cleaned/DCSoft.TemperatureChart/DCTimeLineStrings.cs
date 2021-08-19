using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class DCTimeLineStrings
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		/// <summary>
		///         返回此类使用的缓存的 ResourceManager 实例。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 4;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.TemperatureChart.DCTimeLineStrings", typeof(DCTimeLineStrings).Assembly);
				}
				return resourceManager_0;
			}
		}

		/// <summary>
		///         使用此强类型资源类，为所有资源查找
		///         重写当前线程的 CurrentUICulture 属性。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return cultureInfo_0;
			}
			set
			{
				cultureInfo_0 = value;
			}
		}

		/// <summary>
		///         查找类似 取消数据编辑 的本地化字符串。
		///       </summary>
		internal static string CancelEditValuePoint => ResourceManager.GetString("CancelEditValuePoint", cultureInfo_0);

		/// <summary>
		///         查找类似 已经是第一个位置了，不能向前移动位置。 的本地化字符串。
		///       </summary>
		internal static string CannotMoveForward => ResourceManager.GetString("CannotMoveForward", cultureInfo_0);

		/// <summary>
		///         查找类似 已经是最后的位置，不能向后移动位置了。 的本地化字符串。
		///       </summary>
		internal static string CannotMoveNext => ResourceManager.GetString("CannotMoveNext", cultureInfo_0);

		/// <summary>
		///         查找类似 灯笼数据 的本地化字符串。
		///       </summary>
		internal static string DefaultLanternValueTitle => ResourceManager.GetString("DefaultLanternValueTitle", cultureInfo_0);

		/// <summary>
		///         查找类似 删除数据点 的本地化字符串。
		///       </summary>
		internal static string DeleteValuePoint => ResourceManager.GetString("DeleteValuePoint", cultureInfo_0);

		/// <summary>
		///         查找类似 文档全局配置 的本地化字符串。
		///       </summary>
		internal static string DocumentConfig => ResourceManager.GetString("DocumentConfig", cultureInfo_0);

		/// <summary>
		///         查找类似 贴图 的本地化字符串。
		///       </summary>
		internal static string DocumentImage => ResourceManager.GetString("DocumentImage", cultureInfo_0);

		/// <summary>
		///         查找类似 文本标签 的本地化字符串。
		///       </summary>
		internal static string DocumentLabel => ResourceManager.GetString("DocumentLabel", cultureInfo_0);

		/// <summary>
		///         查找类似 文档参数 的本地化字符串。
		///       </summary>
		internal static string DocumentParameter => ResourceManager.GetString("DocumentParameter", cultureInfo_0);

		/// <summary>
		///         查找类似 拖拽“{0}”的数据点。 的本地化字符串。
		///       </summary>
		internal static string DragValuePoint_Name => ResourceManager.GetString("DragValuePoint_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 拖拽数据点，不修改时间。 的本地化字符串。
		///       </summary>
		internal static string DragValuePointFixedTime => ResourceManager.GetString("DragValuePointFixedTime", cultureInfo_0);

		/// <summary>
		///         查找类似 修改“{0}”的数据点 的本地化字符串。
		///       </summary>
		internal static string EditValuePoint_Title => ResourceManager.GetString("EditValuePoint_Title", cultureInfo_0);

		/// <summary>
		///         查找类似 页脚数据行 的本地化字符串。
		///       </summary>
		internal static string FooterLine => ResourceManager.GetString("FooterLine", cultureInfo_0);

		/// <summary>
		///         查找类似 页眉标签 的本地化字符串。
		///       </summary>
		internal static string HeaderLabel => ResourceManager.GetString("HeaderLabel", cultureInfo_0);

		/// <summary>
		///         查找类似 页眉数据行 的本地化字符串。
		///       </summary>
		internal static string HeaderTitleLine => ResourceManager.GetString("HeaderTitleLine", cultureInfo_0);

		/// <summary>
		///         查找类似 图片文件(*.png,*.bmp,*.jpg,*.jpeg,*.gif)|*.png;*.bmp;*.jpg;*.jpeg;*.gif 的本地化字符串。
		///       </summary>
		internal static string ImageFilter => ResourceManager.GetString("ImageFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 请输入{0} 的本地化字符串。
		///       </summary>
		internal static string InputTitle_Name => ResourceManager.GetString("InputTitle_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 请输入{0} 最小值{1}，最大值{2}。 的本地化字符串。
		///       </summary>
		internal static string InputTitle_Name_Min_Max => ResourceManager.GetString("InputTitle_Name_Min_Max", cultureInfo_0);

		/// <summary>
		///         查找类似 输入的{0}超出范围（最小值{1}，最大值{2}）。 的本地化字符串。
		///       </summary>
		internal static string InputValueOutofRange_Title__MinValue_MaxValue => ResourceManager.GetString("InputValueOutofRange_Title__MinValue_MaxValue", cultureInfo_0);

		/// <summary>
		///         查找类似 新增“{0}”的数据点 的本地化字符串。
		///       </summary>
		internal static string NewValuePoint_Name => ResourceManager.GetString("NewValuePoint_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 超出最大值为“{0}”最小值为“{1}”的取值范围。 的本地化字符串。
		///       </summary>
		internal static string OutofRange_Max_Min => ResourceManager.GetString("OutofRange_Max_Min", cultureInfo_0);

		/// <summary>
		///         查找类似 请确认是否删除数据“{0}”，时间为“{1}”，数值为“{2}”？ 的本地化字符串。
		///       </summary>
		internal static string PromptDeleteValuePoint_Title_Time_Value => ResourceManager.GetString("PromptDeleteValuePoint_Title_Time_Value", cultureInfo_0);

		/// <summary>
		///         查找类似 存在特定时间区域，无法以分页方式显示。 的本地化字符串。
		///       </summary>
		internal static string PromptExistTimeZone => ResourceManager.GetString("PromptExistTimeZone", cultureInfo_0);

		/// <summary>
		///         查找类似 点击展开或收缩数据行。 的本地化字符串。
		///       </summary>
		internal static string PromptExpandedCollapseTitleLine => ResourceManager.GetString("PromptExpandedCollapseTitleLine", cultureInfo_0);

		/// <summary>
		///         查找类似 点击展开或收缩时间区域。 的本地化字符串。
		///       </summary>
		internal static string PromptExpandedCollapseZone => ResourceManager.GetString("PromptExpandedCollapseZone", cultureInfo_0);

		/// <summary>
		///         查找类似 必须输入数据。 的本地化字符串。
		///       </summary>
		internal static string RequiredValue => ResourceManager.GetString("RequiredValue", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string SystemAlert => ResourceManager.GetString("SystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 时间 的本地化字符串。
		///       </summary>
		internal static string Time => ResourceManager.GetString("Time", cultureInfo_0);

		/// <summary>
		///         查找类似 时间区域 的本地化字符串。
		///       </summary>
		internal static string TimeLineZone => ResourceManager.GetString("TimeLineZone", cultureInfo_0);

		/// <summary>
		///         查找类似 [未注册，请注册本软件] 的本地化字符串。
		///       </summary>
		internal static string UnRegisterTitle => ResourceManager.GetString("UnRegisterTitle", cultureInfo_0);

		/// <summary>
		///         查找类似 数值 的本地化字符串。
		///       </summary>
		internal static string Value => ResourceManager.GetString("Value", cultureInfo_0);

		/// <summary>
		///         查找类似 时间刻度太小，是否继续操作？ 的本地化字符串。
		///       </summary>
		internal static string WarringSmallTickStep => ResourceManager.GetString("WarringSmallTickStep", cultureInfo_0);

		/// <summary>
		///         查找类似 正在处理，请稍候... 的本地化字符串。
		///       </summary>
		internal static string Watting => ResourceManager.GetString("Watting", cultureInfo_0);

		/// <summary>
		///         查找类似 数据标尺 的本地化字符串。
		///       </summary>
		internal static string YAxis => ResourceManager.GetString("YAxis", cultureInfo_0);

		internal DCTimeLineStrings()
		{
		}
	}
}
