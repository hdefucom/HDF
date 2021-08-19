using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Design
{
	/// <summary>
	///       支持项目说明的枚举值编辑器
	///       </summary>
	/// <remarks>袁永福到此一游</remarks>
	[DocumentComment]
	[ComVisible(false)]
	public class EnumEditorSupportDescription : UITypeEditor
	{
		/// <summary>
		///       为下拉列表方式
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		/// <summary>
		///       编辑数值
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <param name="provider">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <returns>
		/// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			int num = 1;
			Type propertyType = context.PropertyDescriptor.PropertyType;
			if (propertyType == null)
			{
				throw new ArgumentNullException("PropertyType");
			}
			if (!propertyType.IsEnum)
			{
				throw new ArgumentException(propertyType.FullName);
			}
			return DesignUtils.EditEnumValue(context, provider, value, propertyType);
		}
	}
}
