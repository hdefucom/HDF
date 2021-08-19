using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       分组对象列表
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCToolBoxTabList : List<DCToolBoxTab>
	{
		/// <summary>
		///       获得指定名称分页对象
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <returns>
		/// </returns>
		public DCToolBoxTab this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DCToolBoxTab current = enumerator.Current;
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
