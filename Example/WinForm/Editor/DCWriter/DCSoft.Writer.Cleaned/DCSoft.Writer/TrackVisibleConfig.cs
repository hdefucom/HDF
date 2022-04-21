using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户痕迹可视化设置
	///       </summary>
	[Serializable]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	
	[ComVisible(true)]
	[ComClass("00012345-6789-ABCD-EF01-234567890072", "E9B6AA40-C74D-41AC-8F4F-88F1E7405D2B")]
	
	[ComDefaultInterface(typeof(ITrackVisibleConfig))]
	[Guid("00012345-6789-ABCD-EF01-234567890072")]
	[ClassInterface(ClassInterfaceType.None)]
	public class TrackVisibleConfig : ITrackVisibleConfig
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890072";

		internal const string CLASSID_Interface = "E9B6AA40-C74D-41AC-8F4F-88F1E7405D2B";

		private bool _Enabled = true;

		private Color _BackgroundColor = Color.Transparent;

		private Color _UnderLineColor = Color.Blue;

		private int _UnderLineColorNum = 1;

		private Color _DeleteLineColor = Color.Red;

		private int _DeleteLineNum = 1;

		/// <summary>
		///       配置是否可用，默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(TrackVisibleConfig), "Enabled")]
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
		///       背景色，默认为透明色。
		///       </summary>
		[DCDescription(typeof(TrackVisibleConfig), "BackgroundColor")]
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		public Color BackgroundColor
		{
			get
			{
				return _BackgroundColor;
			}
			set
			{
				_BackgroundColor = value;
			}
		}

		/// <summary>
		///       颜色文本值
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string BackgroundColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackgroundColor, Color.Transparent);
			}
			set
			{
				BackgroundColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       下划线颜色，默认为蓝色。
		///       </summary>
		[DefaultValue(typeof(Color), "Blue")]
		[DCDescription(typeof(TrackVisibleConfig), "UnderLineColor")]
		[XmlIgnore]
		public Color UnderLineColor
		{
			get
			{
				return _UnderLineColor;
			}
			set
			{
				_UnderLineColor = value;
			}
		}

		/// <summary>
		///       颜色文本值
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string UnderLineColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(UnderLineColor, Color.Blue);
			}
			set
			{
				UnderLineColor = XMLSerializeHelper.StringToColor(value, Color.Blue);
			}
		}

		/// <summary>
		///       下划线个数，默认为1.
		///       </summary>
		[DCDescription(typeof(TrackVisibleConfig), "UnderLineColorNum")]
		[DefaultValue(1)]
		public int UnderLineColorNum
		{
			get
			{
				return _UnderLineColorNum;
			}
			set
			{
				_UnderLineColorNum = value;
			}
		}

		/// <summary>
		///       删除线的颜色，默认为红色。
		///       </summary>
		[DCDescription(typeof(TrackVisibleConfig), "DeleteLineColor")]
		[DefaultValue(typeof(Color), "Red")]
		[XmlIgnore]
		public Color DeleteLineColor
		{
			get
			{
				return _DeleteLineColor;
			}
			set
			{
				_DeleteLineColor = value;
			}
		}

		/// <summary>
		///       颜色文本值
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[DefaultValue(null)]
		public string DeleteLineColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(DeleteLineColor, Color.Red);
			}
			set
			{
				DeleteLineColor = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       删除线的个数，默认为1。
		///       </summary>
		[DCDescription(typeof(TrackVisibleConfig), "DeleteLineNum")]
		[DefaultValue(1)]
		public int DeleteLineNum
		{
			get
			{
				return _DeleteLineNum;
			}
			set
			{
				_DeleteLineNum = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public TrackVisibleConfig Clone()
		{
			return (TrackVisibleConfig)MemberwiseClone();
		}
	}
}
