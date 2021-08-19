using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Script
{
	/// <summary>
	///       Script error list
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ScriptErrorList : CollectionBase
	{
		/// <summary>
		///       get error information
		///       </summary>
		/// <param name="index">index</param>
		/// <returns>error information</returns>
		public ScriptError this[int index] => (ScriptError)base.List[index];

		/// <summary>
		///       add new item
		///       </summary>
		/// <param name="err">item</param>
		/// <returns>index of item</returns>
		public int Add(ScriptError scriptError_0)
		{
			return base.List.Add(scriptError_0);
		}
	}
}
