using System;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文档双击事件参数
	///       </summary>
	[ComDefaultInterface(typeof(IDocumentDblClickEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("F532BCDD-518F-45A1-A993-AD2BB4ADFC86")]
	[ComVisible(true)]
	public class FCDocumentDblClickEventArgs : EventArgs, IDocumentDblClickEventArgs
	{
		private FriedmanCurveDocument _Document = null;

		/// <summary>
		///       文档对象
		///       </summary>
		public FriedmanCurveDocument Document => _Document;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		public FCDocumentDblClickEventArgs(FriedmanCurveDocument friedmanCurveDocument_0)
		{
			_Document = friedmanCurveDocument_0;
		}
	}
}
