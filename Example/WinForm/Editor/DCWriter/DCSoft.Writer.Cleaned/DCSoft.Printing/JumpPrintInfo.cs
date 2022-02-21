using DCSoft.Common;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Printing
{
	/// <summary>
	///       续打信息
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("FCD1C6AA-5912-4667-A224-4EBD97DE0E59")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IJumpPrintInfo))]
	public class JumpPrintInfo : IJumpPrintInfo
	{
		private JumpPrintMode _Mode = JumpPrintMode.Disable;

		private PrintPage _Page = null;

		private int _PageIndex = -1;

		private float intNativePosition = 0f;

		private float intPosition = 0f;

		private float _AbsPosition = 0f;

		private float intNativeEndPosition = 0f;

		private float intEndPosition = 0f;

		private int _EndPageIndex = -1;

		/// <summary>
		///       是否存在有效的信息
		///       </summary>
		
		public bool HasValidateInfo
		{
			get
			{
				if (!Enabled)
				{
					return false;
				}
				if (PageIndex >= 0 && Position > 0f)
				{
					return true;
				}
				if (EndPageIndex >= 0 && EndPosition > 0f)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       续打模式
		///       </summary>
		[DefaultValue(JumpPrintMode.Disable)]
		public JumpPrintMode Mode
		{
			get
			{
				return _Mode;
			}
			set
			{
				_Mode = value;
			}
		}

		/// <summary>
		///       是否允许续打
		///       </summary>
		[DefaultValue(false)]
		public bool Enabled
		{
			get
			{
				return _Mode == JumpPrintMode.Normal || _Mode == JumpPrintMode.Append || _Mode == JumpPrintMode.Offset;
			}
			set
			{
				if (value)
				{
					_Mode = JumpPrintMode.Normal;
				}
				else
				{
					_Mode = JumpPrintMode.Disable;
				}
			}
		}

		/// <summary>
		///       发生续打的页面对象
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public PrintPage Page
		{
			get
			{
				return _Page;
			}
			set
			{
				_Page = value;
			}
		}

		/// <summary>
		///       发生续打的页面号
		///       </summary>
		[DefaultValue(-1)]
		public int PageIndex
		{
			get
			{
				return _PageIndex;
			}
			set
			{
				_PageIndex = value;
			}
		}

		/// <summary>
		///       原始续打位置
		///       </summary>
		[DefaultValue(0f)]
		public float NativePosition
		{
			get
			{
				return intNativePosition;
			}
			set
			{
				intNativePosition = value;
			}
		}

		/// <summary>
		///       实际使用的续打位置离续打页面顶端的距离
		///       </summary>
		[DefaultValue(0f)]
		public float Position
		{
			get
			{
				return intPosition;
			}
			set
			{
				intPosition = value;
			}
		}

		/// <summary>
		///       续打的绝对位置
		///       </summary>
		
		[DefaultValue(0f)]
		public float AbsPosition
		{
			get
			{
				return _AbsPosition;
			}
			set
			{
				_AbsPosition = value;
			}
		}

		/// <summary>
		///       原始续打结束位置,如果小于等于Position值就无效
		///       </summary>
		[DefaultValue(0f)]
		
		public float NativeEndPosition
		{
			get
			{
				return intNativeEndPosition;
			}
			set
			{
				intNativeEndPosition = value;
			}
		}

		/// <summary>
		///       实际使用的续打结束位置离续打页面顶端的距离,如果小于等于Position值就无效
		///       </summary>
		[DefaultValue(0f)]
		public float EndPosition
		{
			get
			{
				return intEndPosition;
			}
			set
			{
				intEndPosition = value;
			}
		}

		/// <summary>
		///       续打结束位置处的页码
		///       </summary>
		[DefaultValue(-1)]
		public int EndPageIndex
		{
			get
			{
				return _EndPageIndex;
			}
			set
			{
				_EndPageIndex = value;
			}
		}

		
		public void SetNativePosition(float float_0)
		{
			intNativePosition = float_0;
			intPosition = float_0;
		}

		
		public void SetNativeEndPosition(float float_0)
		{
			intNativeEndPosition = float_0;
			intEndPosition = float_0;
		}

		
		public void Clear()
		{
			_EndPageIndex = -1;
			_Page = null;
			_PageIndex = -1;
			_Mode = JumpPrintMode.Disable;
			intEndPosition = 0f;
			intNativeEndPosition = 0f;
			intNativePosition = 0f;
			intPosition = 0f;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public JumpPrintInfo Clone()
		{
			return (JumpPrintInfo)MemberwiseClone();
		}

		/// <summary>
		///       比较两个对象的数据
		///       </summary>
		/// <param name="info">
		/// </param>
		/// <returns>
		/// </returns>
		
		public bool EqualsValue(JumpPrintInfo info)
		{
			if (info == null)
			{
				return false;
			}
			if (info == this)
			{
				return true;
			}
			return info._Mode == _Mode && info.intNativePosition == intNativePosition && info.intPosition == intPosition && info.intEndPosition == intEndPosition && info.intNativeEndPosition == intNativeEndPosition && info._PageIndex == _PageIndex && info._EndPageIndex == _EndPageIndex;
		}
	}
}
