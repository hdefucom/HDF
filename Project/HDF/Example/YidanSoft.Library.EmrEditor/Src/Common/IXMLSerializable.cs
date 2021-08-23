using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// �ɸ���XML�ڵ���ػ򱣴����ݵĽӿ�
	/// </summary>
	public interface IXMLSerializable
	{
		/// <summary>
		/// ��ñ�������XML�ڵ������
		/// </summary>
		/// <returns>XML�ڵ������</returns>
		string GetXMLName();

		/// <summary>
		/// ��XML�ڵ㱣���������
		/// </summary>
		/// <param name="RootElement">XML�ڵ�</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		bool FromXML(System.Xml.XmlElement RootElement);

		/// <summary>
		/// ��XML�ڵ���ض�������
		/// </summary>
		/// <param name="RootElement">XML�ڵ�</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		bool ToXML(System.Xml.XmlElement RootElement);
	}// interface IXMLSerializable
}
