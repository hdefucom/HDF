using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// 可根据XML节点加载或保存数据的接口
	/// </summary>
	public interface IXMLSerializable
	{
		/// <summary>
		/// 获得保存对象的XML节点的名称
		/// </summary>
		/// <returns>XML节点的名称</returns>
		string GetXMLName();

		/// <summary>
		/// 向XML节点保存对象数据
		/// </summary>
		/// <param name="RootElement">XML节点</param>
		/// <returns>保存是否成功</returns>
		bool FromXML(System.Xml.XmlElement RootElement);

		/// <summary>
		/// 从XML节点加载对象数据
		/// </summary>
		/// <param name="RootElement">XML节点</param>
		/// <returns>加载是否成功</returns>
		bool ToXML(System.Xml.XmlElement RootElement);
	}// interface IXMLSerializable
}
