using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       当前操作员所在的部门的基本信息
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890020")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(ICurrentDepartmentInfo))]
	[ComClass("00012345-6789-ABCD-EF01-234567890020", "B9C0BC20-EBAF-4C3E-B134-DF1BC5DC9D38")]
	[DocumentComment]
	public class CurrentDepartmentInfo : ICurrentDepartmentInfo
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890020";

		internal const string CLASSID_Interface = "B9C0BC20-EBAF-4C3E-B134-DF1BC5DC9D38";

		private string _ID = null;

		private string _Name = null;

		/// <summary>
		///       编号
		///       </summary>
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       名称
		///       </summary>
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
	}
}
