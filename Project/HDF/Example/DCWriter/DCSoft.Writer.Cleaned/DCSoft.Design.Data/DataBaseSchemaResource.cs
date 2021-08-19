using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Design.Data
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class DataBaseSchemaResource
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
				int num = 6;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Design.Data.DataBaseSchemaResource", typeof(DataBaseSchemaResource).Assembly);
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

		internal static Bitmap Assembly
		{
			get
			{
				object @object = ResourceManager.GetObject("Assembly", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap DataBase
		{
			get
			{
				object @object = ResourceManager.GetObject("DataBase", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Field
		{
			get
			{
				object @object = ResourceManager.GetObject("Field", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Key
		{
			get
			{
				object @object = ResourceManager.GetObject("Key", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Bitmap_0
		{
			get
			{
				object @object = ResourceManager.GetObject("mdb", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap SQLServer
		{
			get
			{
				object @object = ResourceManager.GetObject("SQLServer", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Table
		{
			get
			{
				object @object = ResourceManager.GetObject("Table", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		internal DataBaseSchemaResource()
		{
		}
	}
}
