using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       允许设置表达式的类型成员
	///       </summary>
	[ComVisible(false)]
	
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class MemberExpressionableAttribute : Attribute
	{
		private MemberEffectLevel _EffectLevel = MemberEffectLevel.DOM;

		/// <summary>
		///       影响等级
		///       </summary>
		public MemberEffectLevel EffectLevel => _EffectLevel;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="effectLevel">
		/// </param>
		public MemberExpressionableAttribute(MemberEffectLevel effectLevel)
		{
			_EffectLevel = effectLevel;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public MemberExpressionableAttribute()
		{
		}
	}
}
