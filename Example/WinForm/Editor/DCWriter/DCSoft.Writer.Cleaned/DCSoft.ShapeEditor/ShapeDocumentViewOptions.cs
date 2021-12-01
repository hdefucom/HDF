using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor
{
	/// <summary>
	///       图形文档对象的图形功能选项
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeDocumentViewOptions
	{
		private int _ControlPointPixelSize = 8;

		[NonSerialized]
		private float _RuntimeControlPointSize = 0f;

		private XPenStyle _NoneBorder = null;

		private XPenStyle _SelectionBorder = null;

		/// <summary>
		///       控制点的像素大小
		///       </summary>
		[DefaultValue(20f)]
		public int ControlPointPixelSize
		{
			get
			{
				return _ControlPointPixelSize;
			}
			set
			{
				_ControlPointPixelSize = value;
			}
		}

		/// <summary>
		///       实际中使用的控制点的视图大小
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float RuntimeControlPointSize
		{
			get
			{
				return _RuntimeControlPointSize;
			}
			set
			{
				_RuntimeControlPointSize = value;
			}
		}

		/// <summary>
		///       元素无边框时的替代边框样式
		///       </summary>
		[DefaultValue(null)]
		public XPenStyle NoneBorder
		{
			get
			{
				return _NoneBorder;
			}
			set
			{
				_NoneBorder = value;
			}
		}

		/// <summary>
		///       选择的元素边框样式
		///       </summary>
		[DefaultValue(null)]
		public XPenStyle SelectionBorder
		{
			get
			{
				return _SelectionBorder;
			}
			set
			{
				_SelectionBorder = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ShapeDocumentViewOptions()
		{
			_NoneBorder = new XPenStyle(Color.LightGray);
			_SelectionBorder = new XPenStyle(Color.Gray, 1f, DashStyle.Dot);
		}
	}
}
