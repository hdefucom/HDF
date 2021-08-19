using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	[ComVisible(false)]
	public interface IMemberPropertyExpressions
	{
		PropertyExpressionInfoList PropertyExpressions
		{
			get;
			set;
		}
	}
}
