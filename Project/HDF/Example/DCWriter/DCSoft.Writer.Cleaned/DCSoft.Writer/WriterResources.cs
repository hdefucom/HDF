using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Writer
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class WriterResources
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
				int num = 5;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Writer.WriterResources", typeof(WriterResources).Assembly);
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

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap KBBlankEntry
		{
			get
			{
				object @object = ResourceManager.GetObject("KBBlankEntry", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap KBListEntry
		{
			get
			{
				object @object = ResourceManager.GetObject("KBListEntry", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap KBListItem
		{
			get
			{
				object @object = ResourceManager.GetObject("KBListItem", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap KBTemplate
		{
			get
			{
				object @object = ResourceManager.GetObject("KBTemplate", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap pause
		{
			get
			{
				object @object = ResourceManager.GetObject("pause", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap play
		{
			get
			{
				object @object = ResourceManager.GetObject("play", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Bitmap_0
		{
			get
			{
				object @object = ResourceManager.GetObject("sql", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap stop
		{
			get
			{
				object @object = ResourceManager.GetObject("stop", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal WriterResources()
		{
		}
	}
}
