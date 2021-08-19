using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal interface IXmlDocumentType : IXmlNode
	{
		string Name
		{
			get;
		}

		string System
		{
			get;
		}

		string Public
		{
			get;
		}

		string InternalSubset
		{
			get;
		}
	}
}
