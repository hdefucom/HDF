using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       内间距信息
	///       </summary>
	[Serializable]
	[DocumentComment]
	[TypeConverter(typeof(GClass448))]
	[ComDefaultInterface(typeof(IXPaddingF))]
	[Guid("00012345-6789-ABCD-EF01-23456789008E")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public class XPaddingF : ICloneable, IXPaddingF
	{
		private float fLeft = 0f;

		private float fTop = 0f;

		private float fRight = 0f;

		private float fBottom = 0f;

		/// <summary>
		///       内左间距
		///       </summary>
		[DefaultValue(0f)]
		public float Left
		{
			get
			{
				return fLeft;
			}
			set
			{
				fLeft = value;
			}
		}

		/// <summary>
		///       内上间距
		///       </summary>
		[DefaultValue(0f)]
		public float Top
		{
			get
			{
				return fTop;
			}
			set
			{
				fTop = value;
			}
		}

		/// <summary>
		///       内右间距
		///       </summary>
		[DefaultValue(0f)]
		public float Right
		{
			get
			{
				return fRight;
			}
			set
			{
				fRight = value;
			}
		}

		/// <summary>
		///       内下间距
		///       </summary>
		[DefaultValue(0f)]
		public float Bottom
		{
			get
			{
				return fBottom;
			}
			set
			{
				fBottom = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XPaddingF()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="v">间距值</param>
		public XPaddingF(float float_0)
		{
			fLeft = float_0;
			fTop = float_0;
			fRight = float_0;
			fBottom = float_0;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="left">内左间距</param>
		/// <param name="top">内上间距</param>
		/// <param name="right">内右间距</param>
		/// <param name="bottom">内下间距</param>
		public XPaddingF(float left, float float_0, float right, float bottom)
		{
			fLeft = left;
			fTop = float_0;
			fRight = right;
			fBottom = bottom;
		}

		/// <summary>
		///       获得客户区域
		///       </summary>
		/// <param name="bounds">主区域</param>
		/// <returns>客户区域</returns>
		public Rectangle GetClientBounds(Rectangle bounds)
		{
			return new Rectangle(bounds.Left + (int)fLeft, bounds.Top + (int)fTop, bounds.Width - (int)(fLeft + fRight), bounds.Height - (int)(fTop + fBottom));
		}

		/// <summary>
		///       获得客户区域
		///       </summary>
		/// <param name="bounds">主区域</param>
		/// <returns>客户区域</returns>
		public RectangleF GetClientBounds(RectangleF bounds)
		{
			return new RectangleF(bounds.Left + fLeft, bounds.Top + fTop, bounds.Width - fLeft - fRight, bounds.Height - fTop - fBottom);
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XPaddingF Clone()
		{
			return (XPaddingF)MemberwiseClone();
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		/// <summary>
		///       将字符串解析成对象数据
		///       </summary>
		/// <param name="text">字符串</param>
		/// <param name="padding">保存解析结果的对象</param>
		/// <returns>操作是否成功</returns>
		public static bool Parse(string text, XPaddingF padding)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (padding == null)
			{
				return false;
			}
			string[] array = text.Split(',');
			List<float> list = new List<float>();
			for (int i = 0; i < array.Length; i++)
			{
				float result = 0f;
				if (float.TryParse(array[i], out result))
				{
					list.Add(result);
				}
			}
			new XPaddingF();
			switch (list.Count)
			{
			default:
				if (list.Count >= 4)
				{
					padding.Left = list[0];
					padding.Top = list[1];
					padding.Right = list[2];
					padding.Bottom = list[3];
				}
				break;
			case 0:
				return false;
			case 1:
				padding.Left = list[0];
				padding.Top = list[0];
				padding.Right = list[0];
				padding.Bottom = list[0];
				break;
			case 2:
				padding.Left = list[0];
				padding.Top = list[1];
				padding.Right = list[0];
				padding.Bottom = list[0];
				break;
			case 3:
				padding.Left = list[0];
				padding.Top = list[1];
				padding.Right = list[2];
				padding.Bottom = list[2];
				break;
			}
			return true;
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 18;
			if (Left == Top && Left == Right && Left == Bottom)
			{
				return Left.ToString();
			}
			return Left + "," + Top + "," + Right + "," + Bottom;
		}
	}
}
