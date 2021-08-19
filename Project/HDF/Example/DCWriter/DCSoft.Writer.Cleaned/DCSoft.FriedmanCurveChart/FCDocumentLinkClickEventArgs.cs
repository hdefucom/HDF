using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文档中的超链接点击事件
	///       </summary>
	[ComDefaultInterface(typeof(IDocumentLinkClickEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[Guid("3F0E865F-47EB-4689-B376-5EAAA8F2466D")]
	[DocumentComment]
	public class FCDocumentLinkClickEventArgs : IDocumentLinkClickEventArgs
	{
		private FriedmanCurveControl _Control;

		private FriedmanCurveDocument _Document;

		private FCValuePoint _ValuePoint;

		private string _Link;

		private string _LinkTarget;

		private Rectangle _ScreenBounds;

		/// <summary>
		///       控件对象
		///       </summary>
		[ComVisible(false)]
		public FriedmanCurveControl Control => _Control;

		/// <summary>
		///       控件内部显示产程图文档的视图控件
		///       </summary>
		[ComVisible(false)]
		public GControl2 ViewControl => _Control.DocumentViewControl;

		/// <summary>
		///       文档对象
		///       </summary>
		public FriedmanCurveDocument Document => _Document;

		/// <summary>
		///       数据点对象
		///       </summary>
		public FCValuePoint ValuePoint => _ValuePoint;

		/// <summary>
		///       超链接地址
		///       </summary>
		public string Link => _Link;

		/// <summary>
		///       超链接目标
		///       </summary>
		public string LinkTarget => _LinkTarget;

		/// <summary>
		///       超链接区域在屏幕坐标中的 边界
		///       </summary>
		[ComVisible(false)]
		public Rectangle ScreenBounds => _ScreenBounds;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="doc">文档对象</param>
		/// <param name="vp">数据点对象</param>
		/// <param name="link">超链接地址</param>
		/// <param name="linkTaget">超链接目标</param>
		public FCDocumentLinkClickEventArgs(FriedmanCurveControl friedmanCurveControl_0, FriedmanCurveDocument friedmanCurveDocument_0, FCValuePoint fcvaluePoint_0, string link, string linkTaget)
		{
			int num = 10;
			_Control = null;
			_Document = null;
			_ValuePoint = null;
			_Link = null;
			_LinkTarget = null;
			_ScreenBounds = Rectangle.Empty;
			
			if (friedmanCurveControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (friedmanCurveDocument_0 == null)
			{
				throw new ArgumentNullException("doc");
			}
			if (fcvaluePoint_0 == null)
			{
				throw new ArgumentNullException("vp");
			}
			_Control = friedmanCurveControl_0;
			_Document = friedmanCurveDocument_0;
			_ValuePoint = fcvaluePoint_0;
			_Link = link;
			_LinkTarget = linkTaget;
			RectangleF rectangleF = _Control.DocumentViewControl.method_36().vmethod_23(fcvaluePoint_0.ViewBounds);
			rectangleF.Location = _Control.DocumentViewControl.PointToScreen(new Point((int)rectangleF.Left, (int)rectangleF.Top));
			_ScreenBounds = new Rectangle((int)rectangleF.Left, (int)rectangleF.Top, (int)rectangleF.Width, (int)rectangleF.Height);
		}
	}
}
