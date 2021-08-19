using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComClass("80048CBB-E15A-45E2-B7B0-E7B3BEDEA184", "C65D0A67-ACAB-4F3B-BCC4-884CBDECC0DD")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(INsoNetDog))]
	[Guid("80048CBB-E15A-45E2-B7B0-E7B3BEDEA184")]
	[ClassInterface(ClassInterfaceType.None)]
	public class NsoNetDog : INsoNetDog
	{
		internal const string CLASSID = "80048CBB-E15A-45E2-B7B0-E7B3BEDEA184";

		internal const string CLASSID_Interface = "C65D0A67-ACAB-4F3B-BCC4-884CBDECC0DD";

		[ComVisible(true)]
		public void Create()
		{
		}

		[ComVisible(true)]
		public void CreateRemote()
		{
		}
	}
}
