using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Specifies the settings used when merging JSON.
	///       </summary>
	[ComVisible(false)]
	public class JsonMergeSettings
	{
		private MergeArrayHandling _mergeArrayHandling;

		/// <summary>
		///       Gets or sets the method used when merging JSON arrays.
		///       </summary>
		/// <value>The method used when merging JSON arrays.</value>
		public MergeArrayHandling MergeArrayHandling
		{
			get
			{
				return _mergeArrayHandling;
			}
			set
			{
				int num = 14;
				if (value < MergeArrayHandling.Concat || value > MergeArrayHandling.Merge)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_mergeArrayHandling = value;
			}
		}
	}
}
