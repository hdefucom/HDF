using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class ClientFormInfo : IComparable
	{
		private string _Name = null;

		private string _TypeName = null;

		private string _Text = null;

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

		[XmlAttribute]
		[DefaultValue(null)]
		public string TypeName
		{
			get
			{
				return _TypeName;
			}
			set
			{
				_TypeName = value;
			}
		}

		[XmlText]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		public int CompareTo(object target)
		{
			ClientFormInfo clientFormInfo = target as ClientFormInfo;
			if (clientFormInfo == null)
			{
				return 0;
			}
			return string.Compare(Name, clientFormInfo.Name);
		}
	}
}
