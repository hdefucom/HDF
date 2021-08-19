using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class DCFriedmanCurveImageResources
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
				int num = 2;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.FriedmanCurveChart.DCFriedmanCurveImageResources", typeof(DCFriedmanCurveImageResources).Assembly);
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
		internal static Bitmap ArrowDown
		{
			get
			{
				object @object = ResourceManager.GetObject("ArrowDown", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap ArrowUp
		{
			get
			{
				object @object = ResourceManager.GetObject("ArrowUp", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap Collapse
		{
			get
			{
				object @object = ResourceManager.GetObject("Collapse", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap Expand
		{
			get
			{
				object @object = ResourceManager.GetObject("Expand", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal DCFriedmanCurveImageResources()
		{
		}
	}
}
