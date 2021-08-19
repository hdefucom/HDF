using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("03740E58-1E55-4FEB-B2FB-3D8D8E61F124")]
	public delegate void WriterAfterExecuteEventExpressionEventHandler(object sender, WriterAfterExecuteEventExpressionEventArgs e);
}
