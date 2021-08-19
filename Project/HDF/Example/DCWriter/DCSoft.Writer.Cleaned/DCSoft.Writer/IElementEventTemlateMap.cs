using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementEventTemlateMap 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("A06FC173-15D6-4EDF-AAC1-3373216F41E3")]
	public interface IElementEventTemlateMap
	{
		/// <summary>方法ContainsByTypeName</summary>
		[DispId(2)]
		bool ContainsByTypeName(string typeName);

		/// <summary>方法GetEventTemplatesByTypeName</summary>
		[DispId(3)]
		ElementEventTemplateList GetEventTemplatesByTypeName(string elementTypeName);

		/// <summary>方法SetEventTemplatesByTypeName</summary>
		[DispId(4)]
		void SetEventTemplatesByTypeName(string typeName, ElementEventTemplate elementEventTemplate_0);
	}
}
