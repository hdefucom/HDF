using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Design
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class DesignResources
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		/// <summary>
		///         返回此类使用的缓存的 ResourceManager 实例。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 7;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Design.DesignResources", typeof(DesignResources).Assembly);
				}
				return resourceManager_0;
			}
		}

		/// <summary>
		///         使用此强类型资源类，为所有资源查找
		///         重写当前线程的 CurrentUICulture 属性。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return cultureInfo_0;
			}
			set
			{
				cultureInfo_0 = value;
			}
		}

		internal static Bitmap _namespace
		{
			get
			{
				object @object = ResourceManager.GetObject("_namespace", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap classpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("classpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap constpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("constpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap delegatepublic
		{
			get
			{
				object @object = ResourceManager.GetObject("delegatepublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Bitmap_0
		{
			get
			{
				object @object = ResourceManager.GetObject("dll", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap enumpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("enumpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap eventpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("eventpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap fieldpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("fieldpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap IconControl
		{
			get
			{
				object @object = ResourceManager.GetObject("IconControl", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap IconForm
		{
			get
			{
				object @object = ResourceManager.GetObject("IconForm", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap IconWPFElement
		{
			get
			{
				object @object = ResourceManager.GetObject("IconWPFElement", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap interfacepublic
		{
			get
			{
				object @object = ResourceManager.GetObject("interfacepublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap methodpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("methodpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap propertypublic
		{
			get
			{
				object @object = ResourceManager.GetObject("propertypublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap structpublic
		{
			get
			{
				object @object = ResourceManager.GetObject("structpublic", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal DesignResources()
		{
		}
	}
}
