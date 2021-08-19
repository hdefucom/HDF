using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       绑定的表达式对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class BindingExpression : ICloneable
	{
		private string _Name = null;

		private bool _Enabled = true;

		private BindingExpressionStyle _Style = BindingExpressionStyle.Expression;

		private string _Expression = null;

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       项目是否可用
		///       </summary>
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       表达式样式
		///       </summary>
		[DefaultValue(BindingExpressionStyle.Expression)]
		public BindingExpressionStyle Style
		{
			get
			{
				return _Style;
			}
			set
			{
				_Style = value;
			}
		}

		/// <summary>
		///       表达式内容
		///       </summary>
		[DefaultValue(null)]
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
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public BindingExpression Clone()
		{
			return (BindingExpression)MemberwiseClone();
		}

		object ICloneable.Clone()
		{
			return (BindingExpression)MemberwiseClone();
		}
	}
}
