using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       文档样式容器
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IContentStyleContainer))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890087")]
	public class ContentStyleContainer : IDisposable, ICloneable, IContentStyleContainer
	{
		private ContentStyle contentStyle_0 = null;

		private ContentStyleList contentStyleList_0 = new ContentStyleList();

		/// <summary>
		///       默认样式
		///       </summary>
		[XmlElement("Default", typeof(ContentStyle))]
		public virtual ContentStyle Default
		{
			get
			{
				return contentStyle_0;
			}
			set
			{
				contentStyle_0 = value;
				method_1();
			}
		}

		/// <summary>
		///       样式列表
		///       </summary>
		/// <remarks>在此声明本属性不能进行XML序列化，为得是能在应用中重载本属性，然后添加
		///       扩展的样式成员类型，这样就不会造成由于样式对象重载而导致的XML序列化的不方便。郁闷啊。</remarks>
		[XmlArrayItem("Style", typeof(ContentStyle))]
		[XmlIgnore]
		public virtual ContentStyleList Styles
		{
			get
			{
				return contentStyleList_0;
			}
			set
			{
				contentStyleList_0 = value;
				method_1();
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ContentStyleContainer()
		{
			contentStyle_0 = CreateStyleInstance();
		}

		
		public void HandleAfterLoad()
		{
			int num = 6;
			ContentStyle contentStyle = CreateStyleInstance();
			contentStyle.FontSize = 9f;
			contentStyle.FontName = ContentStyle.string_71;
			foreach (ContentStyle style in Styles)
			{
				if (!string.IsNullOrEmpty(style.DefaultValuePropertyNames))
				{
					string defaultValuePropertyNames = style.DefaultValuePropertyNames;
					style.DefaultValuePropertyNames = null;
					XDependencyObject.smethod_2(style, defaultValuePropertyNames, contentStyle);
				}
				XDependencyObject.CopyValueFast(Default, style, overWrite: false);
				if (!XDependencyObject.smethod_4(style, "FontSize"))
				{
					style.FontSize = 9f;
				}
			}
			Styles.FixFontName();
		}

		
		public void method_0()
		{
			contentStyle_0.Index = -1;
			for (int i = 0; i < Styles.Count; i++)
			{
				Styles[i].Index = i;
			}
		}

		/// <summary>
		///       获得指定编号的样式对象
		///       </summary>
		/// <param name="styleIndex">样式编号</param>
		/// <returns>获得的样式对象</returns>
		
		public ContentStyle GetStyle(int styleIndex)
		{
			return Styles.SafeGet(styleIndex, contentStyle_0);
		}

		/// <summary>
		///       获得样式在列表中的编号。
		///       </summary>
		/// <param name="styleString">样式字符串，比如“FontName:宋体;FontSize:9”</param>
		/// <returns>编号</returns>
		
		public int GetStyleIndexByString(string styleString)
		{
			ContentStyle contentStyle = CreateStyleInstance();
			GClass340.smethod_0(contentStyle, styleString);
			return GetStyleIndex(contentStyle);
		}

		/// <summary>
		///       获得样式在列表中的编号
		///       </summary>
		/// <param name="style">样式</param>
		/// <returns>获得的编号</returns>
		
		public int GetStyleIndex(ContentStyle style)
		{
			if (XDependencyObject.smethod_0(style) == 0)
			{
				return -1;
			}
			if (style == null || style == contentStyle_0 || contentStyle_0.method_4(style))
			{
				return -1;
			}
			int num = Styles.IndexOfExt(style);
			if (num < 0)
			{
				if (style.method_5(Default) <= 0)
				{
					return -1;
				}
				XDependencyObject.CopyValueFast(Default, style, overWrite: false);
				num = Styles.IndexOfExt(style);
				if (num < 0)
				{
					Styles.Add(style);
					style.vmethod_3();
					num = Styles.Count - 1;
				}
				method_1();
				vmethod_0();
			}
			return num;
		}

		
		public virtual void vmethod_0()
		{
		}

		/// <summary>
		///       创建一个样式对象实例
		///       </summary>
		/// <returns>创建的对象</returns>
		
		public virtual ContentStyle CreateStyleInstance()
		{
			return new ContentStyle();
		}

		/// <summary>
		///       清空对象
		///       </summary>
		
		public void Clear()
		{
			contentStyle_0 = CreateStyleInstance();
			contentStyle_0.FontName = Control.DefaultFont.Name;
			contentStyle_0.FontSize = Control.DefaultFont.Size;
			contentStyleList_0.Clear();
			vmethod_0();
		}

		
		public void method_1()
		{
			foreach (ContentStyle style in Styles)
			{
				style.RuntimeStyle = null;
			}
		}

		/// <summary>
		///       获得运行时的样式
		///       </summary>
		/// <param name="styleIndex">
		/// </param>
		/// <returns>
		/// </returns>
		
		public ContentStyle GetRuntimeStyle(int styleIndex)
		{
			ContentStyle style = GetStyle(styleIndex);
			if (style == null || style == contentStyle_0)
			{
				return contentStyle_0;
			}
			return style;
		}

		
		object ICloneable.Clone()
		{
			ContentStyleContainer contentStyleContainer = (ContentStyleContainer)MemberwiseClone();
			contentStyleContainer.contentStyle_0 = contentStyle_0.Clone();
			contentStyleContainer.contentStyleList_0 = new ContentStyleList();
			foreach (ContentStyle item in contentStyleList_0)
			{
				contentStyleContainer.contentStyleList_0.Add(item.Clone());
			}
			contentStyleContainer.method_1();
			return contentStyleContainer;
		}

		
		public ContentStyleContainer method_2()
		{
			return (ContentStyleContainer)((ICloneable)this).Clone();
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		
		public virtual void Dispose()
		{
			if (contentStyle_0 != null)
			{
				contentStyle_0.Dispose();
				contentStyle_0 = null;
			}
			if (contentStyleList_0 != null)
			{
				foreach (ContentStyle item in contentStyleList_0)
				{
					item.Dispose();
				}
				contentStyleList_0 = null;
			}
		}
	}
}
