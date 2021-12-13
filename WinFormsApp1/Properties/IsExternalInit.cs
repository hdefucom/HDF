using System.ComponentModel;

namespace System.Runtime.CompilerServices;

/// <summary>
/// 这是SDK的Bug，不添加此类无法使用属性的init访问器
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
class IsExternalInit { }
