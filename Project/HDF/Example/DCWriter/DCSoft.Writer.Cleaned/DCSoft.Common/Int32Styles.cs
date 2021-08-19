using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       使用一个整型数据保存多个样式的模块
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class Int32Styles
	{
		                                                                    /// <summary>
		                                                                    ///       保存参数的整数数值
		                                                                    ///       </summary>
		protected int intStyle = 0;

		                                                                    /// <summary>
		                                                                    ///       保存参数的整数数值
		                                                                    ///       </summary>
		public int Style
		{
			get
			{
				return intStyle;
			}
			set
			{
				intStyle = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得或设置指定的样式
		                                                                    ///       </summary>
		public bool this[int MaskFlag]
		{
			get
			{
				return GetStyle(MaskFlag);
			}
			set
			{
				SetStyle(MaskFlag, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式0
		                                                                    ///       </summary>
		public bool Flag0
		{
			get
			{
				return GetStyle(1);
			}
			set
			{
				SetStyle(1, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式1
		                                                                    ///       </summary>
		public bool Flag1
		{
			get
			{
				return GetStyle(2);
			}
			set
			{
				SetStyle(2, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式2
		                                                                    ///       </summary>
		public bool Flag2
		{
			get
			{
				return GetStyle(4);
			}
			set
			{
				SetStyle(4, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式3
		                                                                    ///       </summary>
		public bool Flag3
		{
			get
			{
				return GetStyle(8);
			}
			set
			{
				SetStyle(8, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式4
		                                                                    ///       </summary>
		public bool Flag4
		{
			get
			{
				return GetStyle(16);
			}
			set
			{
				SetStyle(16, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式5
		                                                                    ///       </summary>
		public bool Flag5
		{
			get
			{
				return GetStyle(32);
			}
			set
			{
				SetStyle(32, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式6
		                                                                    ///       </summary>
		public bool Flag6
		{
			get
			{
				return GetStyle(64);
			}
			set
			{
				SetStyle(64, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式7
		                                                                    ///       </summary>
		public bool Flag7
		{
			get
			{
				return GetStyle(128);
			}
			set
			{
				SetStyle(128, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式8
		                                                                    ///       </summary>
		public bool Flag8
		{
			get
			{
				return GetStyle(256);
			}
			set
			{
				SetStyle(256, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式9
		                                                                    ///       </summary>
		public bool Flag9
		{
			get
			{
				return GetStyle(512);
			}
			set
			{
				SetStyle(512, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式10
		                                                                    ///       </summary>
		public bool Flag10
		{
			get
			{
				return GetStyle(1024);
			}
			set
			{
				SetStyle(1024, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式11
		                                                                    ///       </summary>
		public bool Flag11
		{
			get
			{
				return GetStyle(2048);
			}
			set
			{
				SetStyle(2048, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式12
		                                                                    ///       </summary>
		public bool Flag12
		{
			get
			{
				return GetStyle(4096);
			}
			set
			{
				SetStyle(4096, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式13
		                                                                    ///       </summary>
		public bool Flag13
		{
			get
			{
				return GetStyle(8192);
			}
			set
			{
				SetStyle(8192, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式14
		                                                                    ///       </summary>
		public bool Flag14
		{
			get
			{
				return GetStyle(16384);
			}
			set
			{
				SetStyle(16384, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式15
		                                                                    ///       </summary>
		public bool Flag15
		{
			get
			{
				return GetStyle(32768);
			}
			set
			{
				SetStyle(32768, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式16
		                                                                    ///       </summary>
		public bool Flag16
		{
			get
			{
				return GetStyle(65536);
			}
			set
			{
				SetStyle(65536, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式17
		                                                                    ///       </summary>
		public bool Flag17
		{
			get
			{
				return GetStyle(131072);
			}
			set
			{
				SetStyle(131072, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式18
		                                                                    ///       </summary>
		public bool Flag18
		{
			get
			{
				return GetStyle(262144);
			}
			set
			{
				SetStyle(262144, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式19
		                                                                    ///       </summary>
		public bool Flag19
		{
			get
			{
				return GetStyle(524288);
			}
			set
			{
				SetStyle(524288, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式20
		                                                                    ///       </summary>
		public bool Flag20
		{
			get
			{
				return GetStyle(1048576);
			}
			set
			{
				SetStyle(1048576, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式21
		                                                                    ///       </summary>
		public bool Flag21
		{
			get
			{
				return GetStyle(2097152);
			}
			set
			{
				SetStyle(2097152, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式22
		                                                                    ///       </summary>
		public bool Flag22
		{
			get
			{
				return GetStyle(4194304);
			}
			set
			{
				SetStyle(4194304, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式23
		                                                                    ///       </summary>
		public bool Flag23
		{
			get
			{
				return GetStyle(8388608);
			}
			set
			{
				SetStyle(8388608, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式24
		                                                                    ///       </summary>
		public bool Flag24
		{
			get
			{
				return GetStyle(16777216);
			}
			set
			{
				SetStyle(16777216, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式25
		                                                                    ///       </summary>
		public bool Flag25
		{
			get
			{
				return GetStyle(33554432);
			}
			set
			{
				SetStyle(33554432, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式26
		                                                                    ///       </summary>
		public bool Flag26
		{
			get
			{
				return GetStyle(67108864);
			}
			set
			{
				SetStyle(67108864, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式27
		                                                                    ///       </summary>
		public bool Flag27
		{
			get
			{
				return GetStyle(134217728);
			}
			set
			{
				SetStyle(134217728, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式28
		                                                                    ///       </summary>
		public bool Flag28
		{
			get
			{
				return GetStyle(268435456);
			}
			set
			{
				SetStyle(268435456, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式29
		                                                                    ///       </summary>
		public bool Flag29
		{
			get
			{
				return GetStyle(536870912);
			}
			set
			{
				SetStyle(536870912, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       样式30
		                                                                    ///       </summary>
		public bool Flag30
		{
			get
			{
				return GetStyle(1073741824);
			}
			set
			{
				SetStyle(1073741824, value);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       设置指定数值的样式
		                                                                    ///       </summary>
		                                                                    /// <param name="intValue">原始数据</param>
		                                                                    /// <param name="MaskFlag">掩码</param>
		                                                                    /// <param name="bolSet">是否设置</param>
		                                                                    /// <returns>处理后的数据</returns>
		public static int SetStyle(int intValue, int MaskFlag, bool bolSet)
		{
			return bolSet ? (intValue | MaskFlag) : (intValue & ~MaskFlag);
		}

		                                                                    /// <summary>
		                                                                    ///       获得样式
		                                                                    ///       </summary>
		                                                                    /// <param name="intValue">原始数据</param>
		                                                                    /// <param name="MaskFlag">掩码</param>
		                                                                    /// <returns>是否设置了样式</returns>
		public static bool GetStyle(int intValue, int MaskFlag)
		{
			return (intValue & MaskFlag) == MaskFlag;
		}

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public Int32Styles()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       设置数值的初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="vStyle">数值</param>
		public Int32Styles(int vStyle)
		{
			intStyle = vStyle;
		}

		                                                                    /// <summary>
		                                                                    ///       设置指定的样式属性
		                                                                    ///       </summary>
		                                                                    /// <param name="MaskFlag">样式掩码</param>
		                                                                    /// <param name="bolSet">是否设置该样式属性</param>
		public void SetStyle(int MaskFlag, bool bolSet)
		{
			intStyle = (bolSet ? (intStyle | MaskFlag) : (intStyle & ~MaskFlag));
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定的样式属性
		                                                                    ///       </summary>
		                                                                    /// <param name="MaskFlag">样式掩码</param>
		                                                                    /// <returns>是否设置了该样式属性</returns>
		public bool GetStyle(int MaskFlag)
		{
			return (intStyle & MaskFlag) == MaskFlag;
		}
	}
}
