using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Converters
{
	[ComVisible(false)]
	internal interface IXmlDeclaration : IXmlNode
	{
		string Version
		{
			get;
		}

		string Encoding
		{
			get;
			set;
		}

		string Standalone
		{
			get;
			set;
		}
	}
}
