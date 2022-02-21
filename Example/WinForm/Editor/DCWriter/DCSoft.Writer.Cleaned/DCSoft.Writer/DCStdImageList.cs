using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       标准图标图片对象列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("5F3D758E-DDC0-44D7-BDD8-4018A0AB1941")]
	[ComClass("5F3D758E-DDC0-44D7-BDD8-4018A0AB1941", "DAC1FD81-51AE-4700-A97B-9E840CC5FB45")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDCStdImageList))]
	
	public class DCStdImageList : IDCStdImageList
	{
		internal const string string_0 = "5F3D758E-DDC0-44D7-BDD8-4018A0AB1941";

		internal const string string_1 = "DAC1FD81-51AE-4700-A97B-9E840CC5FB45";

		private static DCStdImageList dcstdImageList_0 = null;

		private static Dictionary<DCStdImageKey, Bitmap> dictionary_0 = null;

		private Dictionary<DCStdImageKey, Bitmap> dictionary_1 = new Dictionary<DCStdImageKey, Bitmap>();

		private Color color_0 = Color.Red;

		private static Bitmap bitmap_0 = null;

		private static Bitmap bitmap_1 = null;

		private static Bitmap bitmap_2 = null;

		private static Bitmap bitmap_3 = null;

		private TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		/// <summary>
		///       对象唯一静态实例
		///       </summary>
		public static DCStdImageList Instance
		{
			get
			{
				if (dcstdImageList_0 == null)
				{
					dcstdImageList_0 = new DCStdImageList();
				}
				return dcstdImageList_0;
			}
		}

		/// <summary>
		///       透明色
		///       </summary>
		
		public Color TransparentColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       操作系统使用的勾选状态的复选框。
		///       </summary>
		internal Bitmap BmpSystemCheckBoxChecked
		{
			get
			{
				if (bitmap_0 == null)
				{
					bitmap_0 = new Bitmap(16, 16);
					using (Graphics graphics = Graphics.FromImage(bitmap_0))
					{
						graphics.Clear(Color.Red);
						ControlPaint.DrawCheckBox(graphics, 0, 0, 16, 16, ButtonState.Checked | ButtonState.Flat);
					}
					bitmap_0.MakeTransparent(Color.Red);
				}
				return bitmap_0;
			}
		}

		/// <summary>
		///       操作系统使用的勾选状态的复选框。
		///       </summary>
		internal Bitmap BmpSystemCheckBoxUnchecked
		{
			get
			{
				if (bitmap_1 == null)
				{
					bitmap_1 = new Bitmap(16, 16);
					using (Graphics graphics = Graphics.FromImage(bitmap_1))
					{
						graphics.Clear(Color.Red);
						ControlPaint.DrawCheckBox(graphics, 0, 0, 16, 16, ButtonState.Flat);
					}
					bitmap_1.MakeTransparent(Color.Red);
				}
				return bitmap_1;
			}
		}

		/// <summary>
		///       操作系统使用的勾选状态的复选框。
		///       </summary>
		internal Bitmap BmpSystemRadioBoxChecked
		{
			get
			{
				if (bitmap_2 == null)
				{
					bitmap_2 = new Bitmap(16, 16);
					using (Graphics graphics = Graphics.FromImage(bitmap_2))
					{
						graphics.Clear(Color.Red);
						ControlPaint.DrawRadioButton(graphics, 1, 1, 14, 14, ButtonState.Checked | ButtonState.Flat);
					}
					bitmap_2.MakeTransparent(Color.Red);
				}
				return bitmap_2;
			}
		}

		/// <summary>
		///       操作系统使用的勾选状态的复选框。
		///       </summary>
		internal Bitmap BmpSystemRadioBoxUnchecked
		{
			get
			{
				if (bitmap_3 == null)
				{
					bitmap_3 = new Bitmap(16, 16);
					using (Graphics graphics = Graphics.FromImage(bitmap_3))
					{
						graphics.Clear(Color.Red);
						ControlPaint.DrawRadioButton(graphics, 1, 1, 14, 14, ButtonState.Flat);
					}
					bitmap_3.MakeTransparent(Color.Red);
				}
				return bitmap_3;
			}
		}

		/// <summary>
		///       勾选状态的复选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpCheckBoxChecked
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.CheckBoxChecked);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.CheckBoxChecked;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.CheckBoxChecked, value);
			}
		}

		/// <summary>
		///       不是勾选状态的复选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpCheckBoxUnchecked
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.CheckBoxUnchecked);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.CheckBoxUnChecked;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.CheckBoxUnchecked, value);
			}
		}

		/// <summary>
		///       勾选状态的单选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpRadioBoxChecked
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.RadioBoxChecked);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.RadioChecked;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.RadioBoxChecked, value);
			}
		}

		/// <summary>
		///       不是勾选状态的单选框,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpRadioBoxUnchecked
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.RadioBoxUnchecked);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.RadioUnChecked;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.RadioBoxUnchecked, value);
			}
		}

		/// <summary>
		///       从左到右时的段落符号，必须为9*12的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpParagraphFlagLeftToRight
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.ParagraphFlagLeftToRight);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.ParagraphFlagLeftToRight;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.ParagraphFlagLeftToRight, value);
			}
		}

		/// <summary>
		///       从右到左时的段落符号,必须为9*12的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpParagraphFlagRightToLeft
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.ParagraphFlagRightToLeft);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.ParagraphFlagRightToLeft;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.ParagraphFlagRightToLeft, value);
			}
		}

		/// <summary>
		///       换行符号,必须为9*12的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpLinebreak
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.Linebreak);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.linebreak;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.Linebreak, value);
			}
		}

		/// <summary>
		///       拖拽内容使用的把柄,必须为13*13的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpDragHandle
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.DragHandle);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.DragHandle;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.DragHandle, value);
			}
		}

		/// <summary>
		///       收缩内容的图标,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpCollapse
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.Collapse);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.Collapse;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.Collapse, value);
			}
		}

		/// <summary>
		///       展开内容的图标,必须为16*16的BMP图片格式,透明色为红色。
		///       </summary>
		
		public Bitmap BmpExpand
		{
			get
			{
				Bitmap bitmap = GetBitmap(DCStdImageKey.Expand);
				if (bitmap == null)
				{
					bitmap = WriterResourcesCore.Expand;
				}
				return bitmap;
			}
			set
			{
				SetBitmape(DCStdImageKey.Expand, value);
			}
		}

		/// <summary>
		///       透明色值
		///       </summary>
		public string TransparentColorValue
		{
			get
			{
				return typeConverter_0.ConvertToString(TransparentColor);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					TransparentColor = Color.Red;
				}
				else
				{
					TransparentColor = (Color)typeConverter_0.ConvertFromString(value);
				}
			}
		}

		private DCStdImageList()
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<DCStdImageKey, Bitmap>();
				dictionary_0.Add(DCStdImageKey.CheckBoxChecked, (Bitmap)WriterResourcesCore.CheckBoxChecked.Clone());
				dictionary_0.Add(DCStdImageKey.CheckBoxUnchecked, (Bitmap)WriterResourcesCore.CheckBoxUnChecked.Clone());
				dictionary_0.Add(DCStdImageKey.RadioBoxChecked, (Bitmap)WriterResourcesCore.RadioChecked.Clone());
				dictionary_0.Add(DCStdImageKey.RadioBoxUnchecked, (Bitmap)WriterResourcesCore.RadioUnChecked.Clone());
				dictionary_0.Add(DCStdImageKey.ParagraphFlagLeftToRight, (Bitmap)WriterResourcesCore.ParagraphFlagLeftToRight.Clone());
				dictionary_0.Add(DCStdImageKey.ParagraphFlagRightToLeft, (Bitmap)WriterResourcesCore.ParagraphFlagRightToLeft.Clone());
				dictionary_0.Add(DCStdImageKey.Linebreak, (Bitmap)WriterResourcesCore.linebreak.Clone());
				dictionary_0.Add(DCStdImageKey.DragHandle, (Bitmap)WriterResourcesCore.DragHandle.Clone());
				dictionary_0.Add(DCStdImageKey.Collapse, (Bitmap)WriterResourcesCore.Collapse.Clone());
				dictionary_0.Add(DCStdImageKey.Expand, (Bitmap)WriterResourcesCore.Expand.Clone());
				foreach (Bitmap value in dictionary_0.Values)
				{
					value.MakeTransparent(Color.Red);
				}
			}
		}

		/// <summary>
		///       根据BASE64字符串加载图标
		///       </summary>
		/// <param name="key">关键字</param>
		/// <param name="base64String">包含图标内容的BASE64字符串</param>
		
		public void SetBitmapByBase64String(DCStdImageKey dcstdImageKey_0, string base64String)
		{
			if (string.IsNullOrEmpty(base64String))
			{
				SetBitmape(dcstdImageKey_0, null);
				return;
			}
			byte[] buffer = Convert.FromBase64String(base64String);
			MemoryStream stream = new MemoryStream(buffer);
			Bitmap bitmap_ = new Bitmap(stream);
			SetBitmape(dcstdImageKey_0, bitmap_);
		}

		/// <summary>
		///       根据文件名设置图标
		///       </summary>
		/// <param name="key">关键字</param>
		/// <param name="fileName">文件名</param>
		
		public void SetBitmapByFileName(DCStdImageKey dcstdImageKey_0, string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				SetBitmape(dcstdImageKey_0, null);
				return;
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			Bitmap bitmap_ = new Bitmap(fileName);
			SetBitmape(dcstdImageKey_0, bitmap_);
		}

		/// <summary>
		///       设置图片
		///       </summary>
		/// <param name="key">关键字</param>
		/// <param name="bmp">图片对象</param>
		
		public void SetBitmape(DCStdImageKey dcstdImageKey_0, Bitmap bitmap_4)
		{
			if (XTextDocument.smethod_13(GEnum6.const_193) && dcstdImageKey_0 != DCStdImageKey.SystemCheckBoxChecked && dcstdImageKey_0 != DCStdImageKey.SystemCheckBoxUnchecked && dcstdImageKey_0 != DCStdImageKey.SystemRadioBoxChecked && dcstdImageKey_0 != DCStdImageKey.SystemRadioBoxUnchecked)
			{
				bitmap_4?.MakeTransparent(TransparentColor);
				dictionary_1[dcstdImageKey_0] = bitmap_4;
			}
		}

		/// <summary>
		///       获得图标对象
		///       </summary>
		/// <param name="key">
		/// </param>
		/// <returns>
		/// </returns>
		
		public Bitmap GetBitmap(DCStdImageKey dcstdImageKey_0)
		{
			if (dictionary_1.ContainsKey(dcstdImageKey_0) && dictionary_1[dcstdImageKey_0] != null)
			{
				return dictionary_1[dcstdImageKey_0];
			}
			if (dictionary_0.ContainsKey(dcstdImageKey_0))
			{
				return dictionary_0[dcstdImageKey_0];
			}
			switch (dcstdImageKey_0)
			{
			default:
				return null;
			case DCStdImageKey.SystemCheckBoxChecked:
				return BmpSystemCheckBoxChecked;
			case DCStdImageKey.SystemCheckBoxUnchecked:
				return BmpSystemCheckBoxUnchecked;
			case DCStdImageKey.SystemRadioBoxChecked:
				return BmpSystemRadioBoxChecked;
			case DCStdImageKey.SystemRadioBoxUnchecked:
				return BmpSystemRadioBoxUnchecked;
			}
		}
	}
}
