using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       Represents a trace writer that writes to the application's <see cref="T:System.Diagnostics.TraceListener" /> instances.
	///       </summary>
	[ComVisible(false)]
	public class DiagnosticsTraceWriter : ITraceWriter
	{
		/// <summary>
		///       Gets the <see cref="T:System.Diagnostics.TraceLevel" /> that will be used to filter the trace messages passed to the writer.
		///       For example a filter level of <code>Info</code> will exclude <code>Verbose</code> messages and include <code>Info</code>,
		///       <code>Warning</code> and <code>Error</code> messages.
		///       </summary>
		/// <value>
		///       The <see cref="T:System.Diagnostics.TraceLevel" /> that will be used to filter the trace messages passed to the writer.
		///       </value>
		public TraceLevel LevelFilter
		{
			get;
			set;
		}

		private TraceEventType GetTraceEventType(TraceLevel level)
		{
			int num = 8;
			switch (level)
			{
			default:
				throw new ArgumentOutOfRangeException("level");
			case TraceLevel.Error:
				return TraceEventType.Error;
			case TraceLevel.Warning:
				return TraceEventType.Warning;
			case TraceLevel.Info:
				return TraceEventType.Information;
			case TraceLevel.Verbose:
				return TraceEventType.Verbose;
			}
		}

		/// <summary>
		///       Writes the specified trace level, message and optional exception.
		///       </summary>
		/// <param name="level">The <see cref="T:System.Diagnostics.TraceLevel" /> at which to write this trace.</param>
		/// <param name="message">The trace message.</param>
		/// <param name="ex">The trace exception. This parameter is optional.</param>
		public void Trace(TraceLevel level, string message, Exception exception_0)
		{
			int num = 11;
			if (level != 0)
			{
				TraceEventCache eventCache = new TraceEventCache();
				TraceEventType traceEventType = GetTraceEventType(level);
				foreach (TraceListener listener in System.Diagnostics.Trace.Listeners)
				{
					if (!listener.IsThreadSafe)
					{
						lock (listener)
						{
							listener.TraceEvent(eventCache, "Open_Newtonsoft_Json", traceEventType, 0, message);
						}
					}
					else
					{
						listener.TraceEvent(eventCache, "Open_Newtonsoft_Json", traceEventType, 0, message);
					}
					if (System.Diagnostics.Trace.AutoFlush)
					{
						listener.Flush();
					}
				}
			}
		}
	}
}
