using DCSoft.Common;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public interface GInterface19 : IDisposable
	{
		bool Focused
		{
			get;
		}

		int Count
		{
			get;
		}

		bool LoadingList
		{
			get;
		}

		bool Visible
		{
			get;
			set;
		}

		void imethod_0(string string_0);

		int imethod_1(string string_0);

		int imethod_2(Stream stream_0);

		int imethod_3(string string_0);

		void imethod_4();

		void imethod_5();

		void imethod_6();

		void imethod_7();
	}
}
