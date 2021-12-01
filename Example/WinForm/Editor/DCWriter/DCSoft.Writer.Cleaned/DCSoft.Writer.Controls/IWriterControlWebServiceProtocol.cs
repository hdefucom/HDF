using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	[ComVisible(false)]
	[DCInternal]
	[DocumentComment]
	public interface IWriterControlWebServiceProtocol : IDisposable, IWriterControlWebService
	{
		string Url
		{
			get;
			set;
		}

		/// <summary>
		///       是否处于调试模式
		///       </summary>
		bool DebugMode
		{
			get;
			set;
		}
	}
}
