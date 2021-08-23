using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// XML������ͨ�ú�������,��ģ���Ծ�̬��������ʽ�ṩ��һЩ���ڲ���XML�ĵ�������
	/// </summary>
	public class XMLCommon
	{
		/// <summary>
		/// ���ָ�����Ƶ��ӽڵ������
		/// </summary>
		/// <param name="RootElement">���ڵ�</param>
		/// <param name="strName">�ӽڵ������</param>
		/// <returns>�ҵ����ӽڵ������,��δ�ҵ��򷵻ؿ�����</returns>
		public static string GetElementValue( System.Xml.XmlElement RootElement , string strName )
		{
			foreach( System.Xml.XmlNode myNode in RootElement.ChildNodes )
				if( myNode.Name == strName )
					return myNode.InnerText ;
			return null;
		}

		/// <summary>
		/// ����ָ�����Ƶ��ӽڵ������
		/// </summary>
		/// <param name="RootElement">���ڵ�</param>
		/// <param name="strName">�ӽڵ������</param>
		/// <param name="strValue">�ӽڵ������</param>
		/// <returns>�����Ƿ�ɹ�</returns>
		public static bool SetElementValue( System.Xml.XmlElement RootElement , string strName , string strValue )
		{
			System.Xml.XmlElement myElement = null;
			foreach( System.Xml.XmlNode myNode in RootElement.ChildNodes )
			{
				if( myNode.Name == strName )
				{
					myElement = ( System.Xml.XmlElement ) myNode ;
					break;
				}
			}//foreach
			if( myElement == null)
			{
				myElement = RootElement.OwnerDocument.CreateElement( strName );
				RootElement.AppendChild( myElement );
			}
			myElement.InnerText = strValue ;
			return true;
		}

		/// <summary>
		/// ɾ��һ��XML�ڵ�����е��ӽڵ�
		/// </summary>
		/// <param name="myNode">XML�ڵ�</param>
		public static void ClearChildNode(System.Xml.XmlNode myNode)
		{
			if( myNode != null)
				while( myNode.FirstChild != null)
					myNode.RemoveChild( myNode.FirstChild);
		}

		/// <summary>
		/// ����XML·���ַ�������XML�ڵ�
		/// </summary>
		/// <example><![CDATA[ 
		/// ����XML�ĵ�,�ļ������� c:\a.xml , ����������
		/// <a>
		///		<b>
		///			<c>����1</c>
		///			<d>����2</d>
		///			<e>����3</e>
		///			<f>
		///				<g>����4</g>
		///			</f>
		///		</b>
		/// </a>
		/// ]]> 
		///  ��ʹ�øú���������Ϊ
		///  System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
		///  myDoc.Load( "c:\\a.xml" );
		///  //�������1
		///  System.Xml.XmlNode myNode = XMLCommon.GetXMLNodeByPath(myDoc.DocumentElement , "b.d");
		///  System.Console.WriteLine( myNode.InnerText);
		///  // �������4
		///  myNode = XMLCommon.GetXMLNodeByPath( myDoc.DocumentElement , "b.f.g");
		///  System.Console.WriteLine( myNode.InnerText);
		/// </example>
		/// <param name="rootNode">���ڵ�</param>
		/// <param name="strPath">XML·����Ϊ·��������XML�ڵ�����Ƶļ��ϣ�����ڵ���õ�ŷֿ�</param>
		/// <returns>�ҵ���XML�ڵ�,��û���ҵ��򷵻ؿ�</returns>
		public static System.Xml.XmlNode GetXMLNodeByPath( System.Xml.XmlNode rootNode , string strPath )
		{
			if( strPath == null || rootNode == null)
				return null;
			 
			int Index = strPath.IndexOf(".");
			string strName = null;
			// ���·���ַ���,��õ�ǰ���ƥ���XML�ӽڵ������
			if ( Index > 0)
			{	
				strName = strPath.Substring(0, Index );
				strPath = strPath.Substring(Index + 1 );
			}
			else
			{
				strName = strPath ;
				strPath = null;
			}
			// �ҵ���ǰ��ƥ����ӽڵ�
			foreach(System.Xml.XmlNode myNode in rootNode.ChildNodes)
			{
				
				if( myNode.Name == strName )
				{
					// ����ǰ��Ϊ·�������һ���򷵻��ҵ���XML�ӽڵ�
					// ����ݹ���ñ�����������һ����XML�ڵ�
					if( strPath == null)
						return myNode ;
					else
						return GetXMLNodeByPath( myNode , strPath );
				}
			}
			return null;
		}//public static System.Xml.XmlNode GetXMLNodeByPath()


		/// <summary>
		/// �������Ʋ���XML����ڵ�
		/// </summary>
		/// <param name="rootNode">���ڵ�</param>
		/// <param name="strName">XML�ӽڵ������</param>
		/// <param name="Deep">�Ƿ��������ڵ�</param>
		/// <returns>�ҵ���ָ�����ƵĽڵ�,��û���ҵ��򷵻ؿ�</returns>
		public static System.Xml.XmlElement GetElementByName(System.Xml.XmlElement rootNode , string strName , bool Deep   )
		{
			if ( rootNode == null || strName == null || strName.Trim().Length == 0 ) 
				return null;
			strName = strName.Trim();

			// �ҵ���ǰ��ƥ����ӽڵ�
			foreach( System.Xml.XmlNode myNode in rootNode.ChildNodes)
			{
				if( myNode.Name == strName )
					return (System.Xml.XmlElement) myNode ;
				else if( Deep && myNode is System.Xml.XmlElement && myNode.ChildNodes.Count > 0 )
				{
					// ��������ڵ���в���
					System.Xml.XmlElement findElement = GetElementByName((System.Xml.XmlElement) myNode , strName ,true);
					if( findElement != null)
						return findElement ;
				}
			}
			return null;
		}//public static System.Xml.XmlElement GetElementByName()


		/// <summary>
		/// ����һ��ָ�����Ƶ�XML�ӽڵ�
		/// </summary>
		/// <param name="RootElement">XML���ڵ�</param>
		/// <param name="strName">ָ�����ӽڵ������</param>
		/// <param name="bolCreate">����������ͼ����ָ�����Ƶ��ӽڵ�,��û�ҵ���ò���ָʾ�����Ƿ񴴽�һ��ָ�����Ƶ��µ��ӽڵ�</param>
		/// <returns>�ҵ����������ӽڵ�,�����������û���ҵ��򴴽��򷵻ؿ�����</returns>
		public static System.Xml.XmlElement CreateChildElement( System.Xml.XmlElement RootElement , string strName , bool bolCreate)
		{
			if( RootElement == null || strName == null || strName.Trim().Length == 0 )
				return null;
			try
			{
				strName = strName.Trim();
				foreach(System.Xml.XmlNode myNode in RootElement.ChildNodes)
				{
					if( myNode.Name == strName )
						return (System.Xml.XmlElement) myNode ;
				}
				if( bolCreate )
				{
					System.Xml.XmlElement NewElement = RootElement.OwnerDocument.CreateElement( strName );
					RootElement.AppendChild( NewElement );
					return NewElement ;
				}
			}
			catch
			{}
			return null;
		}//public static System.Xml.XmlElement CreateChildElement()

		/// <summary>
		/// ����XML�ڵ�����ƺ�����ֵ�ҵ��ӽڵ�
		/// </summary>
		/// <param name="rootElement">���ڵ�</param>
		/// <param name="strName">ָ���Ľڵ�����</param>
		/// <param name="strAttrName">ָ���Ľڵ�������</param>
		/// <param name="strAttrValue">ָ��������ֵ</param>
		/// <param name="bolCreate">��Ϊ�ҵ���ƥ��Ľڵ����Ƿ񴴽��ýڵ�</param>
		/// <returns>�ҵ���XML�ڵ�,��û���������û�ҵ��򷵻ؿ�����</returns>
		public static System.Xml.XmlElement GetElementByAttribute(
			System.Xml.XmlElement rootElement , 
			string strName , 
			string strAttrName ,
			string strAttrValue ,
			bool bolCreate)
		{
			System.Xml.XmlElement myElement = null;
			if( rootElement == null || strName == null || strAttrName == null || strAttrValue == null )
				return null;
			else
			{
				foreach(System.Xml.XmlNode myNode in rootElement.ChildNodes )
				{
					myElement = myNode as System.Xml.XmlElement ;
					if(    myElement != null 
						&& myElement.Name == strName 
						&& myElement.HasAttribute( strAttrName ) 
						&& myElement.GetAttribute(strAttrName) == strAttrValue)
						return myElement ;
				}
			}
			if( bolCreate )
			{
				myElement = rootElement.OwnerDocument.CreateElement( strName );
				myElement.SetAttribute(strAttrName, strAttrValue);
				rootElement.AppendChild( myElement );
				return myElement ;
			}
			return null ;
		}//public static System.Xml.XmlElement GetElementByAttribute()
	}//public class XMLCommon
}