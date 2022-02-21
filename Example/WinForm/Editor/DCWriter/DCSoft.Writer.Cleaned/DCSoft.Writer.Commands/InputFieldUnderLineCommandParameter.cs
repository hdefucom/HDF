using DCSoft.Common;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       用下边框方式来实现下划线的命令参数
	///       </summary>
	/// <remarks>
	/// </remarks>
	[DocumentComment]
	
	public class InputFieldUnderLineCommandParameter
	{
		/// <summary>
		///       获取或设置要进行的操作是加下划线还是去掉下划线
		///       </summary>
		public bool IsAddLine
		{
			get;
			set;
		}

		/// <summary>
		///       获取或设置下划线的颜色
		///       </summary>
		public Color InputFieldUnderLineColor
		{
			get;
			set;
		}

		/// <summary>
		///       获取或设置下划线的线宽
		///       </summary>
		public float InputFieldUnderLineWidth
		{
			get;
			set;
		}

		/// <summary>
		///       获取或设置下划线的线长，设置bUseMyOwnLength属性为true会导致此属性直接影响到输入域的固定长度
		///       </summary>
		public float InputFieldUnderLineLength
		{
			get;
			set;
		}

		/// <summary>
		///       获取或设置下划线的样式
		///       </summary>
		public DashStyle InputFieldUnderLineStyle
		{
			get;
			set;
		}

		/// <summary>
		///       获取或设置是否使用参数对象的长度，若设为否，则不会影响输入域原本设置的长度，若设为是，则使用InputFieldUnderLineLength属性来改变输入域的长度
		///       </summary>
		public bool bUseMyOwnLength
		{
			get;
			set;
		}

		public InputFieldUnderLineCommandParameter()
		{
			InputFieldUnderLineColor = Color.Black;
			InputFieldUnderLineWidth = 1f;
			InputFieldUnderLineLength = 0f;
			InputFieldUnderLineStyle = DashStyle.Solid;
			bUseMyOwnLength = false;
			IsAddLine = false;
		}
	}
}
