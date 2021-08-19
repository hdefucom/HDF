using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>DCTestControl 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("A32BC359-C7FB-44F8-B3D6-5128FC3CF863")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IDCTestControl
	{
		/// <summary>属性ButtonText</summary>
		[DispId(5)]
		string ButtonText
		{
			get;
			set;
		}

		/// <summary>方法ComDispose</summary>
		[DispId(2)]
		void ComDispose();

		/// <summary>方法SetButtonText</summary>
		[DispId(4)]
		void SetButtonText(string string_0);
	}
}
