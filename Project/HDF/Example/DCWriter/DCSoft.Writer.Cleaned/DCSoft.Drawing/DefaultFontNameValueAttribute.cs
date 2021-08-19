using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Drawing
{
	/// <summary>
	///       默认字体名称特性
	///       </summary>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[ComVisible(false)]
	public class DefaultFontNameValueAttribute : DefaultValueAttribute
	{
		/// <summary>
		///       默认字体名称
		///       </summary>
		public static string DefaultFontName;

		static DefaultFontNameValueAttribute()
		{
			DefaultFontName = null;
			DefaultFontName = Control.DefaultFont.Name;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DefaultFontNameValueAttribute()
			: base(DefaultFontName)
		{
		}
	}
}
