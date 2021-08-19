using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       文档元素事件表达式信息对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComClass("BD1CD19C-F1CD-4795-AAD3-3C01F81229EC", "295CDC0C-1CE1-45D4-A364-204866DDA784")]
	[ComDefaultInterface(typeof(IEventExpressionInfo))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DocumentComment]
	[Guid("BD1CD19C-F1CD-4795-AAD3-3C01F81229EC")]
	public class EventExpressionInfo : ICloneable, IEventExpressionInfo
	{
		internal const string CLASSID = "BD1CD19C-F1CD-4795-AAD3-3C01F81229EC";

		internal const string CLASSID_Interface = "295CDC0C-1CE1-45D4-A364-204866DDA784";

		private string _EventName = "ContentChanged";

		private string _Expression = null;

		private EventExpressionTarget _Target = EventExpressionTarget.NextElement;

		private string _CustomTargetName = null;

		private string _TargetPropertyName = "VISIBLE";

		/// <summary>
		///       事件名称
		///       </summary>
		[DefaultValue("ContentChanged")]
		[DCPublishAPI]
		public string EventName
		{
			get
			{
				return _EventName;
			}
			set
			{
				_EventName = value;
			}
		}

		/// <summary>
		///       表达式文本
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Expression
		{
			get
			{
				return _Expression;
			}
			set
			{
				_Expression = value;
			}
		}

		/// <summary>
		///       目标
		///       </summary>
		[DefaultValue(EventExpressionTarget.NextElement)]
		[DCPublishAPI]
		public EventExpressionTarget Target
		{
			get
			{
				return _Target;
			}
			set
			{
				_Target = value;
			}
		}

		/// <summary>
		///       自定义的目标元素编号
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string CustomTargetName
		{
			get
			{
				return _CustomTargetName;
			}
			set
			{
				_CustomTargetName = value;
			}
		}

		/// <summary>
		///       目标属性名称
		///       </summary>
		[DefaultValue("VISIBLE")]
		[DCPublishAPI]
		public string TargetPropertyName
		{
			get
			{
				return _TargetPropertyName;
			}
			set
			{
				_TargetPropertyName = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public EventExpressionInfo()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public EventExpressionInfo Clone()
		{
			return (EventExpressionInfo)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			return (EventExpressionInfo)MemberwiseClone();
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Expression;
		}
	}
}
