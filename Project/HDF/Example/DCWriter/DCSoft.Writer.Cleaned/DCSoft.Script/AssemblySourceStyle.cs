using System.Runtime.InteropServices;

namespace DCSoft.Script
{
	[ComVisible(false)]
	public enum AssemblySourceStyle
	{
		/// <summary>
		///       .NET framework standard assembly
		///       </summary>
		Standard,
		/// <summary>
		///       The third part assembly
		///       </summary>
		ThirdPart,
		/// <summary>
		///       owner assembly
		///       </summary>
		Custom
	}
}
