using System.Xml;
using ZYTextDocumentLib;

namespace ZYCommon
{
	public class ZYPublic
	{
		public static bool StandardMode = false;

		public static string PatientID = "";

		public static XmlDocument PatientInfo = null;

		public static bool Isoutcopy = false;

		public static ZYTextImage TempZYTextImage = null;

		public static string ImageIndex = "";

		public static string WebServerUrl = "http://localhost/pacs";

		public static string PaperKind = "Executive";

		public static int PaperHeight = 1051;

		public static int PaperWidth = 724;

		public static int MarginTop = 50;

		public static int MarginBottom = 50;

		public static int MarginLeft = 50;

		public static int MarginRight = 50;

		public static bool Landscape = false;

		public static string ModalityName = "";
	}
}
