using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       工具箱项目列表
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCToolBoxItemList : List<DCToolBoxItem>
	{
		/// <summary>
		///       获得指定名称的项目对象
		///       </summary>
		/// <param name="name">项目名称</param>
		/// <returns>获得的项目对象</returns>
		public DCToolBoxItem this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DCToolBoxItem current = enumerator.Current;
						if (current.Name == name)
						{
							return current;
						}
					}
				}
				return null;
			}
		}
	}
}
