using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Security
{
	/// <summary>DocumentSecurityOptions 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("E5F54326-317A-4B4F-B89C-22164D42E846")]
	[Browsable(false)]
	public interface IDocumentSecurityOptions
	{
		/// <summary>属性AutoEnablePermissionWhenUserLogin</summary>
		[DispId(13)]
		bool AutoEnablePermissionWhenUserLogin
		{
			get;
			set;
		}

		/// <summary>属性CanModifyDeleteSameLevelContent</summary>
		[DispId(14)]
		bool CanModifyDeleteSameLevelContent
		{
			get;
			set;
		}

		/// <summary>属性CreatorTipFormatString</summary>
		[DispId(15)]
		string CreatorTipFormatString
		{
			get;
			set;
		}

		/// <summary>属性DeleterTipFormatString</summary>
		[DispId(16)]
		string DeleterTipFormatString
		{
			get;
			set;
		}

		/// <summary>属性EnableLogicDelete</summary>
		[DispId(2)]
		bool EnableLogicDelete
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(3)]
		bool EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性PowerfulSignDocument</summary>
		[DispId(4)]
		bool PowerfulSignDocument
		{
			get;
			set;
		}

		/// <summary>属性RealDeleteOwnerContent</summary>
		[DispId(5)]
		bool RealDeleteOwnerContent
		{
			get;
			set;
		}

		/// <summary>属性ShowLogicDeletedContent</summary>
		[DispId(6)]
		bool ShowLogicDeletedContent
		{
			get;
			set;
		}

		/// <summary>属性ShowPermissionMark</summary>
		[DispId(7)]
		bool ShowPermissionMark
		{
			get;
			set;
		}

		/// <summary>属性ShowPermissionTip</summary>
		[DispId(8)]
		bool ShowPermissionTip
		{
			get;
			set;
		}

		/// <summary>属性TrackVisibleLevel0</summary>
		[DispId(9)]
		TrackVisibleConfig TrackVisibleLevel0
		{
			get;
			set;
		}

		/// <summary>属性TrackVisibleLevel1</summary>
		[DispId(10)]
		TrackVisibleConfig TrackVisibleLevel1
		{
			get;
			set;
		}

		/// <summary>属性TrackVisibleLevel2</summary>
		[DispId(11)]
		TrackVisibleConfig TrackVisibleLevel2
		{
			get;
			set;
		}

		/// <summary>属性TrackVisibleLevel3</summary>
		[DispId(12)]
		TrackVisibleConfig TrackVisibleLevel3
		{
			get;
			set;
		}
	}
}
