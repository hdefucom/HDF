using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       服务容器对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[ComVisible(false)]
	
	public class WriterServiceContainer : DefaultServiceContainer
	{
		internal IKBProvider KBProivder
		{
			get
			{
				return (IKBProvider)GetService(typeof(IKBProvider));
			}
			set
			{
				AddService(typeof(IKBProvider), value);
			}
		}

		internal IListItemsProvider ListItemsProvider
		{
			get
			{
				return (IListItemsProvider)GetService(typeof(IListItemsProvider));
			}
			set
			{
				AddService(typeof(IListItemsProvider), value);
			}
		}

		internal IListSourceProvider ListSourceProvider
		{
			get
			{
				return (IListSourceProvider)GetService(typeof(IListSourceProvider));
			}
			set
			{
				AddService(typeof(IListSourceProvider), value);
			}
		}

		internal WriterDebugger Debugger
		{
			get
			{
				return (WriterDebugger)GetService(typeof(WriterDebugger));
			}
			set
			{
				AddService(typeof(WriterDebugger), value);
			}
		}
	}
}
