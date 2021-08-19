using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	public delegate TResult Func<TResult>();
	[ComVisible(false)]
	public delegate TResult Func<T, TResult>(T gparam_0);
	[ComVisible(false)]
	public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
	[ComVisible(false)]
	public delegate TResult Func<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);
	[ComVisible(false)]
	public delegate TResult Func<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
}
