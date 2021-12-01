using System;

namespace XDesignerCommon
{
	/// <summary>
	/// �ַ��������ṩ�߽ӿ�
	/// </summary>
	public interface IVariableProvider
	{
		/// <summary>
		/// �ж��Ƿ����ָ�����Ƶı���
		/// </summary>
		/// <param name="Name">��������</param>
		/// <returns>�Ƿ����ָ�����Ƶı���</returns>
		bool Exists( string Name );
		/// <summary>
		/// ���ָ�����Ƶı���ֵ
		/// </summary>
		/// <param name="Name">��������</param>
		/// <returns>����ֵ</returns>
		string Get( string Name );
		/// <summary>
		/// ����ָ�����Ƶı���ֵ
		/// </summary>
		/// <param name="Name">��������</param>
		/// <param name="Value">����ֵ</param>
		void Set( string Name , string Value );
		/// <summary>
		/// ������б���������
		/// </summary>
		string[] AllNames
		{
			get;
		}
	}//public interface IVariableProvider

	
	/// <summary>
	/// ʹ��һ����ϣ�б���ʵ�ֵ��ַ��������ṩ�߶���
	/// </summary>
	public class HashTableVariableProvider : IVariableProvider
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public HashTableVariableProvider()
		{
			myValues = new System.Collections.Hashtable();
		}

		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="vars">��ϣ�б����</param>
		public HashTableVariableProvider( System.Collections.Hashtable vars )
		{
			myValues = vars ;
		}
		private System.Collections.Hashtable myValues = null;
		/// <summary>
		/// �������ݵĹ�ϣ�б�
		/// </summary>
		public System.Collections.Hashtable Values
		{
			get{ return myValues ;}
		}
		/// <summary>
		/// ���ñ���ֵ
		/// </summary>
		/// <param name="Name">��������</param>
		/// <param name="Value">����ֵ</param>
		public void Set( string Name , string Value )
		{
			myValues[ Name ] = Value ;
		}
		/// <summary>
		/// �ж��Ƿ����ָ�����Ƶı���
		/// </summary>
		/// <param name="Name">��������</param>
		/// <returns>�Ƿ����ָ�����Ƶı���</returns>
		public bool Exists(string Name)
		{
			return myValues.ContainsKey( Name );
		}

		/// <summary>
		/// ���ָ�����Ƶı���ֵ
		/// </summary>
		/// <param name="Name">��������</param>
		/// <returns>����ֵ</returns>
		public string Get(string Name)
		{
			return Convert.ToString( myValues[ Name ] ) ;
		}
		
		/// <summary>
		/// ������б���������
		/// </summary>
		public string[] AllNames
		{
			get
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				foreach( object k in myValues.Keys )
				{
					list.Add( Convert.ToString( k ));
				}
				return ( string[] ) list.ToArray( typeof( string ));
			}
		}
	}//public class HashTableVariableProvider : IVariableProvider

	/// <summary>
	/// ʹ��һ���ַ����ֵ���ʵ�ֵ��ַ��������ṩ�߶���
	/// </summary>
	public class StringDictionaryVariableProvider : IVariableProvider
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public StringDictionaryVariableProvider()
		{
			this.myDictionary = new System.Collections.Specialized.StringDictionary();
		}

		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="dir">�ַ����ֵ����</param>
		public StringDictionaryVariableProvider( System.Collections.Specialized.StringDictionary dir )
		{
			this.myDictionary = dir ;
		}
		private System.Collections.Specialized.StringDictionary myDictionary = null;
		/// <summary>
		/// �ַ����ֵ����
		/// </summary>
		public System.Collections.Specialized.StringDictionary Dictionary
		{
			get{ return myDictionary ;}
			set{ myDictionary = value;}
		}
		/// <summary>
		/// ���ñ���ֵ
		/// </summary>
		/// <param name="Name">��������</param>
		/// <param name="Value">����ֵ</param>
		public void Set( string Name , string Value )
		{
			myDictionary[ Name ] = Value ;
		}
		/// <summary>
		/// �ж��Ƿ����ָ�����Ƶı���
		/// </summary>
		/// <param name="Name">��������</param>
		/// <returns>�Ƿ����ָ�����Ƶı���</returns>
		public bool Exists(string Name)
		{
			return myDictionary.ContainsKey( Name );
		}

		/// <summary>
		/// ���ָ�����Ƶı���ֵ
		/// </summary>
		/// <param name="Name">��������</param>
		/// <returns>����ֵ</returns>
		public string Get(string Name)
		{
			return myDictionary[ Name ] ;
		}
		
		/// <summary>
		/// ������б���������
		/// </summary>
		public string[] AllNames
		{
			get
			{
				return null;
			}
		}
	}//public class StringDictionaryVariableProvider : IVariableProvider

	/// <summary>
	/// �ڲ���Ƕ���������ַ����������
	/// </summary>
	public class VariableString
	{
		/// <summary>
		/// ��ʼ������
		/// </summary>
		public VariableString()
		{
		}
		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="txt">�ַ�������</param>
		public VariableString( string txt )
		{
			strText = txt ;
		}
		private string strVariablePrefix = "[%" ;
		/// <summary>
		/// ������ǰ׺
		/// </summary>
		public string VariablePrefix
		{
			get{ return strVariablePrefix ;}
			set{ strVariablePrefix = value;}
		}
		private string strVariableEndfix = "%]";
		/// <summary>
		/// �������׺
		/// </summary>
		public string VariableEndfix
		{
			get{ return strVariableEndfix ;}
			set{ strVariableEndfix = value;}
		}
		private IVariableProvider myVariables = new HashTableVariableProvider();
		/// <summary>
		/// �����ṩ��,Ĭ��Ϊһ�� HashTableVariableProvider ���͵Ķ���
		/// </summary>
		public IVariableProvider Variables
		{
			get{ return myVariables ;}
			set{ myVariables = value;}
		}
		/// <summary>
		/// ���ñ���
		/// </summary>
		/// <param name="strName">��������</param>
		/// <param name="strValue">����ֵ</param>
		public void SetVariable( string strName, string strValue )
		{
			if( myVariables != null )
				myVariables.Set( strName , strValue );
		}
		private string strText = null;
		/// <summary>
		/// �ַ�������
		/// </summary>
		public string Text
		{
			get{ return strText ;}
			set{ strText = value;}
		}
		/// <summary>
		/// ����ַ����а����ı�������
		/// </summary>
		/// <returns>����������ɵ��ַ�������</returns>
		public string[] GetVariableNames( )
		{
			string[] strItems = AnalyseVariableString( strText , strVariablePrefix , strVariableEndfix );
			if( strItems != null )
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				for( int iCount = 1 ; iCount < strItems.Length ; iCount += 2 )
				{
					list.Add( strItems[ iCount ] );
				}
				return ( string[] ) list.ToArray( typeof( string ));
			}
			return null;
		}

		/// <summary>
		/// ִ�б���
		/// </summary>
		/// <returns>�������ַ���</returns>
		public string Execute()
		{
			return Execute( this.strText , null );
		}
		/// <summary>
		/// ִ�б���
		/// </summary>
		/// <param name="txt">ԭʼ�ַ���</param>
		/// <param name="ParameterValues">����������б�</param>
		/// <returns>�������ַ���</returns>
		public string Execute( string txt , System.Collections.ArrayList ParameterValues )
		{
			if( this.myVariables == null )
				throw new System.InvalidOperationException("δ���� Variables ����");

			if( txt == null || txt.Length == 0 )
				return txt ;

			string[] strItems = AnalyseVariableString( txt , strVariablePrefix , strVariableEndfix );
			if( strItems == null )
				return null;
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			for( int iCount = 0 ; iCount < strItems.Length ; iCount ++ )
			{
				if( ( iCount % 2 ) == 0 )
					myStr.Append( strItems[ iCount ] );
				else
				{
					string strName = strItems[ iCount ] ;
					bool bolParameter = strName.StartsWith("@");
					if( bolParameter )
					{
						strName = strName.Substring( 1 );
					}
					string strValue = null;
					if( myVariables.Exists( strName ))
						strValue = myVariables.Get( strName );
					else
					{
						strValue = "";
					}
					if( ParameterValues != null && bolParameter )
					{
						ParameterValues.Add( strValue );
						myStr.Append( " ? " );
					}
					else
						myStr.Append( strValue );
				}
			}
			return myStr.ToString();
		}

		/// <summary>
		/// ����һ���ַ���,���ݿ�ʼ�ַ����ͽ����ַ������зָ�,�����طָ����ɵ��ַ�������
		/// ��Щ�ַ��������ż����Ԫ��Ϊ��ʼ�ַ����ͽ����ַ�����Ĳ���
		/// ��������ַ���"aaa[bbb]ccc"�����ַ�������"aaa","bbb","ccc"
		/// </summary>
		/// <param name="strText">���������ַ���</param>
		/// <param name="strHead">��ʼ�ַ���</param>
		/// <param name="strEnd">�����ַ���</param>
		/// <returns>���ɵ��ַ�������</returns>
		private static string[] AnalyseVariableString(
			string strText ,
			string strHead , 
			string strEnd )
		{
			// ��ԭʼ�ַ�����Ч����û���κο��õĲ������˳�����
			if(    strText 			== null 
				|| strHead			== null 
				|| strEnd 			== null 
				|| strHead.Length	== 0 
				|| strEnd.Length	== 0 
				|| strText.Length	== 0 )
				return new string[]{ strText };
			
			int 	index = strText.IndexOf( strHead );
			// ��ԭʼ�ַ���û�б���������˳�����
			if(index < 0 ) 
				return new string[]{ strText } ;
			
			System.Collections.ArrayList myList = new System.Collections.ArrayList();
			string 	strKey ;
			int 	index2 ;
			int 	LastIndex = 0 ;
			do
			{	
				// ������ "[����]" ��ʽ�����ַ���
				// ��û���ҵ� "[" �� "]"���ַ������˳�ѭ��
				index2 = strText.IndexOf( strEnd ,  index + 1  );
				if(index2 > index)
				{
					// �� "[" ���ź������ "]"��������� "[]"�ַ���
					// �������ҽ���Ա�֤ "[]"�ַ����в������ַ� "["
					int index3 = index ;
					do
					{
						index = index3 ;
						index3 = strText.IndexOf(strHead, index3 + 1 );
					}while( index3 > index && index3 < index2 ) ;
				
					// ����ַ��Լ��ŵ����ַ���,�����ַ���Ϊ������
					// ���ò�������Ч�����������������ֵ
					// ���򲻽��ж���Ĵ���
					strKey = strText.Substring(index + strHead.Length ,  index2 - index - strHead.Length  );
					if(LastIndex < index)
						myList.Add( strText.Substring(LastIndex, index - LastIndex ));
					else
						myList.Add( "" );
					myList.Add( strKey );
					index = index2 +  strEnd.Length ;
					LastIndex = index ; 
				}
				else
				{
					break;
				}
			}while( index >=0 && index < strText.Length );
			// ��Ӵ������ʣ����ַ���
			if(LastIndex < strText.Length   )
				myList.Add( strText.Substring(LastIndex));
			return (string[])myList.ToArray( typeof( string ));
		}//private static string[] AnalyseVariableString
	}//public class VariableString
}