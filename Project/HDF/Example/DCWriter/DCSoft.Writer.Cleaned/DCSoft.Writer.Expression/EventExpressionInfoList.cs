using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       事件表达式信息列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("5A48ACC6-38E6-4AB5-92A0-8F9F445C5B99", "5F8FD594-BDA8-4BF4-92CC-BDFB7775B560")]
	[Guid("5A48ACC6-38E6-4AB5-92A0-8F9F445C5B99")]
	[DocumentComment]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IEventExpressionInfoList))]
	[DCPublishAPI]
	public class EventExpressionInfoList : List<EventExpressionInfo>, ICloneable, IEventExpressionInfoList
	{
		internal const string CLASSID = "5A48ACC6-38E6-4AB5-92A0-8F9F445C5B99";

		internal const string CLASSID_Interface = "5F8FD594-BDA8-4BF4-92CC-BDFB7775B560";

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public EventExpressionInfoList()
		{
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="eventName">
		/// </param>
		/// <param name="expression">
		/// </param>
		/// <param name="target">
		/// </param>
		/// <param name="customTargetName">
		/// </param>
		/// <param name="targetPropertyName">
		/// </param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public EventExpressionInfo AddItem(string eventName, string expression, EventExpressionTarget target, string customTargetName, string targetPropertyName)
		{
			EventExpressionInfo eventExpressionInfo = new EventExpressionInfo();
			eventExpressionInfo.EventName = eventName;
			eventExpressionInfo.Expression = expression;
			eventExpressionInfo.Target = target;
			eventExpressionInfo.CustomTargetName = customTargetName;
			eventExpressionInfo.TargetPropertyName = targetPropertyName;
			Add(eventExpressionInfo);
			return eventExpressionInfo;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public EventExpressionInfoList Clone()
		{
			return (EventExpressionInfoList)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			EventExpressionInfoList eventExpressionInfoList = new EventExpressionInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EventExpressionInfo current = enumerator.Current;
					eventExpressionInfoList.Add(current.Clone());
				}
			}
			return eventExpressionInfoList;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 9;
			if (base.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EventExpressionInfo current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(current.Expression);
					if (current.Target == EventExpressionTarget.NextElement)
					{
						stringBuilder.Append("->NextElement");
					}
					else
					{
						stringBuilder.Append("->" + current.CustomTargetName);
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
}
