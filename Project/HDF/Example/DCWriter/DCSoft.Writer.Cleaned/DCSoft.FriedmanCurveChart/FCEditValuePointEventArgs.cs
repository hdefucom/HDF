using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       编辑数据点事件参数
	///       </summary>
	[ComDefaultInterface(typeof(IEditValuePointEventArgs))]
	[ComVisible(true)]
	[Guid("85225F66-41AF-4832-9011-8F0560B566AF")]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	public class FCEditValuePointEventArgs : IEditValuePointEventArgs
	{
		private FriedmanCurveControl _Control = null;

		private FriedmanCurveDocument _Document = null;

		private FCEditValuePointMode _EditMode = FCEditValuePointMode.Insert;

		private FCValuePoint _ValuePoint = null;

		private bool _Result = true;

		/// <summary>
		///       产程图控件对象
		///       </summary>
		public FriedmanCurveControl Control => _Control;

		/// <summary>
		///       产程图文档对象
		///       </summary>
		public FriedmanCurveDocument Document => _Document;

		/// <summary>
		///       处理模式
		///       </summary>
		public FCEditValuePointMode EditMode => _EditMode;

		/// <summary>
		///       数据点对象
		///       </summary>
		public FCValuePoint ValuePoint => _ValuePoint;

		/// <summary>
		///       数据序列的标题
		///       </summary>
		public string SerialTitle
		{
			get
			{
				if (_ValuePoint != null)
				{
					if (_ValuePoint.Parent is FCYAxisInfo)
					{
						return ((FCYAxisInfo)_ValuePoint.Parent).Title;
					}
					if (_ValuePoint.Parent is FCTitleLineInfo)
					{
						return ((FCTitleLineInfo)_ValuePoint.Parent).Title;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       数据序列的名称
		///       </summary>
		public string SerialName
		{
			get
			{
				if (ValuePoint != null)
				{
					if (ValuePoint.Parent is FCYAxisInfo)
					{
						return ((FCYAxisInfo)ValuePoint.Parent).Name;
					}
					if (ValuePoint.Parent is FCTitleLineInfo)
					{
						return ((FCTitleLineInfo)ValuePoint.Parent).Name;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       Y轴坐标信息
		///       </summary>
		public FCYAxisInfo YAxisInfo => _ValuePoint.Parent as FCYAxisInfo;

		/// <summary>
		///       标题行信息对象
		///       </summary>
		public FCTitleLineInfo TitleLineInfo => _ValuePoint.Parent as FCTitleLineInfo;

		/// <summary>
		///       操作是否成功
		///       </summary>
		public bool Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">产程图控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="vp">数据点对象</param>
		/// <param name="mode">事件模式</param>
		public FCEditValuePointEventArgs(FriedmanCurveControl friedmanCurveControl_0, FriedmanCurveDocument document, FCValuePoint fcvaluePoint_0, FCEditValuePointMode mode)
		{
			_Control = friedmanCurveControl_0;
			_Document = document;
			_ValuePoint = fcvaluePoint_0;
			_EditMode = mode;
		}
	}
}
