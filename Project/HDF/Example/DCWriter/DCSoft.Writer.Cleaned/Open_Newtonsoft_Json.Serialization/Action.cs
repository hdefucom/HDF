using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	public delegate void Action();
	[ComVisible(false)]
	public delegate void Action<T1, T2>(T1 arg1, T2 arg2);
	[ComVisible(false)]
	public delegate void Action<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
	[ComVisible(false)]
	public delegate void Action<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
}
