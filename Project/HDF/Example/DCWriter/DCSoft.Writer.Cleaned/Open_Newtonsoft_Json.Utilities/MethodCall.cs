using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal delegate TResult MethodCall<T, TResult>(T target, params object[] args);
}
