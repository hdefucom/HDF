using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer
{
	/// <summary>
	///       系统警告信息对象
	///       </summary>
	[ComDefaultInterface(typeof(ISystemAlertInfoList))]
	
	[ComClass("71F15190-595D-40FA-B552-A307D2985381", "6B532050-E4CD-4C85-83D1-705F2C533682")]
	[ComVisible(true)]
	[Guid("71F15190-595D-40FA-B552-A307D2985381")]
	[ClassInterface(ClassInterfaceType.None)]
	public class SystemAlertInfoList : List<SystemAlertInfo>, ISystemAlertInfoList
	{
		internal const string CLASSID = "71F15190-595D-40FA-B552-A307D2985381";

		internal const string CLASSID_Interface = "6B532050-E4CD-4C85-83D1-705F2C533682";

		/// <summary>
		///       添加信息
		///       </summary>
		/// <param name="msg">信息文本</param>
		/// <returns>
		/// </returns>
		public SystemAlertInfo AddInfo(string string_0)
		{
			SystemAlertInfo systemAlertInfo = new SystemAlertInfo();
			systemAlertInfo.Message = string_0;
			Add(systemAlertInfo);
			return systemAlertInfo;
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			if (base.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SystemAlertInfo current = enumerator.Current;
					stringBuilder.AppendLine(current.Message);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
