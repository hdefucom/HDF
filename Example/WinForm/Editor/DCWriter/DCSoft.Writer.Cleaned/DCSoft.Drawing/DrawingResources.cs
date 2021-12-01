using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class DrawingResources
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
				int num = 10;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Drawing.DrawingResources", typeof(DrawingResources).Assembly);
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

		internal static Bitmap BackImage1
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage1", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage10
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage10", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage11
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage11", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage12
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage12", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage13
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage13", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage2
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage2", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage3
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage3", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage4
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage4", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage5
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage5", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage6
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage6", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage7
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage7", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage8
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage8", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BackImage9
		{
			get
			{
				object @object = ResourceManager.GetObject("BackImage9", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap BrowseButtonIcon
		{
			get
			{
				object @object = ResourceManager.GetObject("BrowseButtonIcon", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap ButtonBackgroundDown
		{
			get
			{
				object @object = ResourceManager.GetObject("ButtonBackgroundDown", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap ButtonBackgroundOver
		{
			get
			{
				object @object = ResourceManager.GetObject("ButtonBackgroundOver", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap ButtonBackgroundUp
		{
			get
			{
				object @object = ResourceManager.GetObject("ButtonBackgroundUp", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap CalenderButtonIcon
		{
			get
			{
				object @object = ResourceManager.GetObject("CalenderButtonIcon", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap ComboBoxButtonActive
		{
			get
			{
				object @object = ResourceManager.GetObject("ComboBoxButtonActive", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap ComboBoxButtonNormal
		{
			get
			{
				object @object = ResourceManager.GetObject("ComboBoxButtonNormal", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap FloatBrowseButtonIcon
		{
			get
			{
				object @object = ResourceManager.GetObject("FloatBrowseButtonIcon", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal DrawingResources()
		{
		}
	}
}
