using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(true)]
	[Guid("9F447777-D649-4F9A-8343-75B76C28EDBF")]
	public enum WdInfo
	{
		wdSuccess = 0,
		wdFileNameError = 1,
		wdFileNotExist = 2,
		wdFilerError = 3,
		wdServiceError = 4,
		wdFileReadonly = 5,
		wdTextfile = 6,
		wdFormfile = 7,
		wdHttpTempdir = 8,
		wdHttpSaveTemp = 9,
		wdFail = 10,
		wdFileNew = 11,
		wdArgumentError = 12,
		wdNoExist = 13,
		wdFileExist = 14,
		wdFileNewAndModified = 18,
		wdFileModified = 19,
		wdNetDogCannotOpen = 20,
		wdCreateTempFileError = 21,
		wdcurle_write_error = 43,
		wdcurle_read_error = 46,
		wdInitError = 77,
		wdFileDamaged = 78,
		wdOtherOpenSituation = 9999
	}
}
