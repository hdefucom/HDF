using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class ClientProcessModuleInfo : IComparable
	{
		private string _Name = null;

		private string _FileName = null;

		private string _Version = null;

		[XmlAttribute]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		[XmlText]
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		[XmlAttribute]
		public string Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		public int CompareTo(object target)
		{
			ClientProcessModuleInfo clientProcessModuleInfo = target as ClientProcessModuleInfo;
			if (clientProcessModuleInfo == null)
			{
				return 0;
			}
			return string.Compare(Name, clientProcessModuleInfo.Name);
		}
	}
}
