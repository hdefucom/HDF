using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       IDE调试模式下查看列表类型数据的视图对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class ListDebugView
	{
		private object myInstance;

		                                                                    /// <summary>
		                                                                    ///       output debug item at design time
		                                                                    ///       </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public object Items
		{
			get
			{
				if (myInstance is IEnumerable)
				{
					ArrayList arrayList = new ArrayList();
					foreach (object item in (IEnumerable)myInstance)
					{
						arrayList.Add(item);
					}
					return arrayList.ToArray();
				}
				return myInstance;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       initialize instance
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">
		                                                                    /// </param>
		public ListDebugView(object instance)
		{
			int num = 19;
			myInstance = null;
			
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			myInstance = instance;
		}
	}
}
