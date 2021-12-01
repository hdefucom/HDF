using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DocumentNavigator 的COM接口</summary>
	[Guid("D9642920-1041-4B9A-8EC3-FAE9760D7F08")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IDocumentNavigator
	{
		/// <summary>属性CurrentNode</summary>
		[DispId(5)]
		NavigateNode CurrentNode
		{
			get;
		}

		/// <summary>属性Nodes</summary>
		[DispId(6)]
		NavigateNodeList Nodes
		{
			get;
		}

		/// <summary>方法GetNodeByID</summary>
		[DispId(2)]
		NavigateNode GetNodeByID(string string_0);

		/// <summary>方法GetNodeString</summary>
		[DispId(3)]
		string GetNodeString();

		/// <summary>方法Refresh</summary>
		[DispId(4)]
		void Refresh();
	}
}
