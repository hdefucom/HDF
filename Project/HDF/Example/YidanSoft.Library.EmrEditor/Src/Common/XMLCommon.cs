using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// XML操作的通用函数集合,本模块以静态函数的形式提供了一些用于操作XML文档的例程
	/// </summary>
	public class XMLCommon
	{
		/// <summary>
		/// 获得指定名称的子节点的数据
		/// </summary>
		/// <param name="RootElement">父节点</param>
		/// <param name="strName">子节点的名称</param>
		/// <returns>找到的子节点的数据,若未找到则返回空引用</returns>
		public static string GetElementValue( System.Xml.XmlElement RootElement , string strName )
		{
			foreach( System.Xml.XmlNode myNode in RootElement.ChildNodes )
				if( myNode.Name == strName )
					return myNode.InnerText ;
			return null;
		}

		/// <summary>
		/// 设置指定名称的子节点的数据
		/// </summary>
		/// <param name="RootElement">父节点</param>
		/// <param name="strName">子节点的名称</param>
		/// <param name="strValue">子节点的数据</param>
		/// <returns>操作是否成功</returns>
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
		/// 删除一个XML节点的所有的子节点
		/// </summary>
		/// <param name="myNode">XML节点</param>
		public static void ClearChildNode(System.Xml.XmlNode myNode)
		{
			if( myNode != null)
				while( myNode.FirstChild != null)
					myNode.RemoveChild( myNode.FirstChild);
		}

		/// <summary>
		/// 根据XML路径字符串查找XML节点
		/// </summary>
		/// <example><![CDATA[ 
		/// 现有XML文档,文件保存在 c:\a.xml , 其内容如下
		/// <a>
		///		<b>
		///			<c>数据1</c>
		///			<d>数据2</d>
		///			<e>数据3</e>
		///			<f>
		///				<g>数据4</g>
		///			</f>
		///		</b>
		/// </a>
		/// ]]> 
		///  则使用该函数的例子为
		///  System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
		///  myDoc.Load( "c:\\a.xml" );
		///  //获得数据1
		///  System.Xml.XmlNode myNode = XMLCommon.GetXMLNodeByPath(myDoc.DocumentElement , "b.d");
		///  System.Console.WriteLine( myNode.InnerText);
		///  // 获得数据4
		///  myNode = XMLCommon.GetXMLNodeByPath( myDoc.DocumentElement , "b.f.g");
		///  System.Console.WriteLine( myNode.InnerText);
		/// </example>
		/// <param name="rootNode">父节点</param>
		/// <param name="strPath">XML路径，为路径经过的XML节点的名称的集合，各层节点间用点号分开</param>
		/// <returns>找到的XML节点,若没有找到则返回空</returns>
		public static System.Xml.XmlNode GetXMLNodeByPath( System.Xml.XmlNode rootNode , string strPath )
		{
			if( strPath == null || rootNode == null)
				return null;
			 
			int Index = strPath.IndexOf(".");
			string strName = null;
			// 拆分路径字符串,获得当前层的匹配的XML子节点的名称
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
			// 找到当前层匹配的子节点
			foreach(System.Xml.XmlNode myNode in rootNode.ChildNodes)
			{
				
				if( myNode.Name == strName )
				{
					// 若当前层为路径的最后一层则返回找到的XML子节点
					// 否则递归调用本函数查找下一级的XML节点
					if( strPath == null)
						return myNode ;
					else
						return GetXMLNodeByPath( myNode , strPath );
				}
			}
			return null;
		}//public static System.Xml.XmlNode GetXMLNodeByPath()


		/// <summary>
		/// 根据名称查找XML子孙节点
		/// </summary>
		/// <param name="rootNode">父节点</param>
		/// <param name="strName">XML子节点的名称</param>
		/// <param name="Deep">是否查找子孙节点</param>
		/// <returns>找到的指定名称的节点,若没有找到则返回空</returns>
		public static System.Xml.XmlElement GetElementByName(System.Xml.XmlElement rootNode , string strName , bool Deep   )
		{
			if ( rootNode == null || strName == null || strName.Trim().Length == 0 ) 
				return null;
			strName = strName.Trim();

			// 找到当前层匹配的子节点
			foreach( System.Xml.XmlNode myNode in rootNode.ChildNodes)
			{
				if( myNode.Name == strName )
					return (System.Xml.XmlElement) myNode ;
				else if( Deep && myNode is System.Xml.XmlElement && myNode.ChildNodes.Count > 0 )
				{
					// 进入子孙节点进行查找
					System.Xml.XmlElement findElement = GetElementByName((System.Xml.XmlElement) myNode , strName ,true);
					if( findElement != null)
						return findElement ;
				}
			}
			return null;
		}//public static System.Xml.XmlElement GetElementByName()


		/// <summary>
		/// 创建一个指定名称的XML子节点
		/// </summary>
		/// <param name="RootElement">XML根节点</param>
		/// <param name="strName">指定的子节点的名称</param>
		/// <param name="bolCreate">函数首先试图查找指定名称的子节点,若没找到则该参数指示函数是否创建一个指定名称的新的子节点</param>
		/// <returns>找到或新增的子节点,若参数错误或没有找到或创建则返回空引用</returns>
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
		/// 根据XML节点的名称和属性值找到子节点
		/// </summary>
		/// <param name="rootElement">根节点</param>
		/// <param name="strName">指定的节点名称</param>
		/// <param name="strAttrName">指定的节点属性名</param>
		/// <param name="strAttrValue">指定的属性值</param>
		/// <param name="bolCreate">若为找到相匹配的节点则是否创建该节点</param>
		/// <returns>找到的XML节点,若没参数错误或没找到则返回空引用</returns>
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