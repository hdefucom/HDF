using DCSoft.Design;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器可承载的组件类型信息加载器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class HostComponentTypeInfoLoader : ComponentTypeInfoLoader
	{
		/// <summary>
		///       指定WinForm控件
		///       </summary>
		public bool SupportWinFormControl
		{
			get
			{
				return base.SupportedBaseTypes.ContainsKey(typeof(Control));
			}
			set
			{
				if (value)
				{
					if (!base.SupportedBaseTypes.ContainsKey(typeof(Control)))
					{
						base.SupportedBaseTypes[typeof(Control)] = WriterResourcesCore.IconControl;
					}
				}
				else if (base.SupportedBaseTypes.ContainsKey(typeof(Control)))
				{
					base.SupportedBaseTypes.Remove(typeof(Control));
				}
			}
		}

		/// <summary>
		///       指定文档图形对象
		///       </summary>
		public bool SupportDocumentImage
		{
			get
			{
				return base.SupportedBaseTypes.ContainsKey(typeof(IDocumentImage));
			}
			set
			{
				if (value)
				{
					if (!base.SupportedBaseTypes.ContainsKey(typeof(IDocumentImage)))
					{
						base.SupportedBaseTypes[typeof(IDocumentImage)] = WriterResourcesCore.IconDocumentImage;
					}
				}
				else if (base.SupportedBaseTypes.ContainsKey(typeof(IDocumentImage)))
				{
					base.SupportedBaseTypes.Remove(typeof(IDocumentImage));
				}
			}
		}

		/// <summary>
		///       指定WPF对象
		///       </summary>
		public bool SupportWPF
		{
			get
			{
				if (GClass129.smethod_1() == null)
				{
					return false;
				}
				return base.SupportedBaseTypes.ContainsKey(typeof(IDocumentImage));
			}
			set
			{
				if (GClass129.smethod_1() == null)
				{
					return;
				}
				if (value)
				{
					if (!base.SupportedBaseTypes.ContainsKey(GClass129.smethod_1()))
					{
						base.SupportedBaseTypes[GClass129.smethod_1()] = WriterResourcesCore.IconWPFElement;
					}
				}
				else if (base.SupportedBaseTypes.ContainsKey(GClass129.smethod_1()))
				{
					base.SupportedBaseTypes.Remove(GClass129.smethod_1());
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public HostComponentTypeInfoLoader()
		{
			base.SupportedBaseTypes = new Dictionary<Type, Image>();
			base.SupportedBaseTypes[typeof(Control)] = method_2(WriterResourcesCore.IconControl);
			base.SupportedBaseTypes[typeof(IDocumentImage)] = method_2(WriterResourcesCore.IconDocumentImage);
			if (GClass129.smethod_1() != null)
			{
				base.SupportedBaseTypes[GClass129.smethod_1()] = method_2(WriterResourcesCore.IconWPFElement);
			}
			base.ExcludeBaseTypes = new List<Type>();
			base.ExcludeBaseTypes.Add(typeof(Form));
			base.ExcludeBaseTypes.Add(typeof(WriterControl));
		}

		/// <summary>
		///       从指定的程序集中加载组件类型信息
		///       </summary>
		/// <param name="asm">程序集对象</param>
		/// <returns>获得的组件类型信息数组</returns>
		public override ComponentTypeInfo[] Load(Assembly assembly_0)
		{
			int num = 19;
			ComponentTypeInfo[] array = base.Load(assembly_0);
			List<ComponentTypeInfo> list = new List<ComponentTypeInfo>();
			if (array != null && array.Length > 0)
			{
				ComponentTypeInfo[] array2 = array;
				foreach (ComponentTypeInfo componentTypeInfo in array2)
				{
					if (!(componentTypeInfo.Namespace == "DCSoft.Writer.Controls"))
					{
						list.Add(componentTypeInfo);
					}
				}
				return list.ToArray();
			}
			return null;
		}

		private Image method_2(Image image_0)
		{
			if (image_0 is Bitmap)
			{
				Bitmap bitmap = (Bitmap)image_0;
				bitmap = (Bitmap)bitmap.Clone();
				bitmap.MakeTransparent();
				return bitmap;
			}
			return image_0;
		}
	}
}
