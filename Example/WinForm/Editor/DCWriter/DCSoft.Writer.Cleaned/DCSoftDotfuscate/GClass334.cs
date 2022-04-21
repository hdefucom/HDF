#define DEBUG
using DCSoft.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public static class GClass334
	{
		public static string smethod_0(string string_0, string string_1)
		{
			int num = 15;
			if (string.IsNullOrEmpty(string_0))
			{
				return string_1;
			}
			if (string.IsNullOrEmpty(string_1))
			{
				return string_0;
			}
			try
			{
				Uri uri = new Uri(string_0);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					return Path.Combine(string_0, string_1);
				}
				string text = string_0.Trim();
				if (!text.EndsWith("/"))
				{
					text += "/";
				}
				uri = new Uri(text);
				Uri uri2 = new Uri(uri, string_1);
				return uri2.AbsoluteUri;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message + "[" + string_0 + "] [" + string_1 + "]");
				return null;
			}
		}

		public static string smethod_1(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			if (string_0 == null)
			{
				return null;
			}
			string text = string_0;
			int num = string_0.LastIndexOfAny(new char[2]
			{
				'\\',
				'/'
			});
			return (num <= 0) ? "" : string_0.Substring(0, num);
		}
	}
}
