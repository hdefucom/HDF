using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       坐标点信息对象
	///       </summary>
	[Serializable]
	[Guid("2AD7F58C-26E2-4673-BE7D-11DB8391BC6A")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IPointClass))]
	[TypeConverter(typeof(GClass471))]
	[ComVisible(true)]
	public class PointClass : ICloneable, IPointClass
	{
		private int intX = 0;

		private int intY = 0;

		/// <summary>
		///       X坐标值
		///       </summary>
		[DefaultValue(0)]
		public int X
		{
			get
			{
				return intX;
			}
			set
			{
				intX = value;
			}
		}

		/// <summary>
		///       Y坐标值
		///       </summary>
		[DefaultValue(0)]
		public int Y
		{
			get
			{
				return intY;
			}
			set
			{
				intY = value;
			}
		}

		/// <summary>
		///       对象数据是否为空
		///       </summary>
		[Browsable(false)]
		public bool IsEmpty => intX == 0 && intY == 0;

		/// <summary>
		///       初始化对象
		///       </summary>
		public PointClass()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="x">X坐标值</param>
		/// <param name="y">Y坐标值</param>
		public PointClass(int int_0, int int_1)
		{
			intX = int_0;
			intY = int_1;
		}

		object ICloneable.Clone()
		{
			return new PointClass(intX, intY);
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public PointClass Clone()
		{
			return new PointClass(intX, intY);
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			return intX + "," + intY;
		}

		/// <summary>
		///       比较两个点的数据是否相等
		///       </summary>
		/// <param name="p">要比较的数据</param>
		/// <returns>两个数据是否相等</returns>
		public bool EqualsValue(PointClass pointClass_0)
		{
			if (pointClass_0 == null)
			{
				return false;
			}
			if (pointClass_0 == this)
			{
				return true;
			}
			return pointClass_0.intX == intX && pointClass_0.intY == intY;
		}

		/// <summary>
		///       将对象转换为Point结构类型
		///       </summary>
		/// <returns>
		/// </returns>
		public Point ToPoint()
		{
			return new Point(intX, intY);
		}
	}
}
