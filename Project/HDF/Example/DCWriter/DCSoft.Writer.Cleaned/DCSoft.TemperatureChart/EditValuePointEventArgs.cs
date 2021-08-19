using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       编辑数据点事件参数
	///       </summary>
	[Guid("37C075A0-CA73-4AF1-A7F2-EC2DA559CDE0")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComDefaultInterface(typeof(IEditValuePointEventArgs))]
	public class EditValuePointEventArgs : IEditValuePointEventArgs
	{
		private TemperatureControl _Control = null;

		private TemperatureDocument _Document = null;

		private EditValuePointMode _EditMode = EditValuePointMode.Insert;

		private ValuePoint _ValuePoint = null;

		private bool _Result = true;

		/// <summary>
		///       时间轴控件对象
		///       </summary>
		public TemperatureControl Control => _Control;

		/// <summary>
		///       时间轴文档对象
		///       </summary>
		public TemperatureDocument Document => _Document;

		/// <summary>
		///       处理模式
		///       </summary>
		public EditValuePointMode EditMode => _EditMode;

		/// <summary>
		///       数据点对象
		///       </summary>
		public ValuePoint ValuePoint => _ValuePoint;

		/// <summary>
		///       数据序列的标题
		///       </summary>
		public string SerialTitle
		{
			get
			{
				if (_ValuePoint != null)
				{
					if (_ValuePoint.Parent is YAxisInfo)
					{
						return ((YAxisInfo)_ValuePoint.Parent).Title;
					}
					if (_ValuePoint.Parent is TitleLineInfo)
					{
						return ((TitleLineInfo)_ValuePoint.Parent).Title;
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
					if (ValuePoint.Parent is YAxisInfo)
					{
						return ((YAxisInfo)ValuePoint.Parent).Name;
					}
					if (ValuePoint.Parent is TitleLineInfo)
					{
						return ((TitleLineInfo)ValuePoint.Parent).Name;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       Y轴坐标信息
		///       </summary>
		public YAxisInfo YAxisInfo => _ValuePoint.Parent as YAxisInfo;

		/// <summary>
		///       标题行信息对象
		///       </summary>
		public TitleLineInfo TitleLineInfo => _ValuePoint.Parent as TitleLineInfo;

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
		/// <param name="ctl">时间轴控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="vp">数据点对象</param>
		/// <param name="mode">事件模式</param>
		public EditValuePointEventArgs(TemperatureControl temperatureControl_0, TemperatureDocument document, ValuePoint valuePoint_0, EditValuePointMode mode)
		{
			_Control = temperatureControl_0;
			_Document = document;
			_ValuePoint = valuePoint_0;
			_EditMode = mode;
		}
	}
}
