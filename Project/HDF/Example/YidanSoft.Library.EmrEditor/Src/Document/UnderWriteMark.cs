using System;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// 表示签名对象的集合
	/// </summary>
	public class UnderWriteMarkCollection : IXMLSerializable , System.Collections.IEnumerable
	{


		/// <summary>
		/// 该对象所在的文档对象
		/// </summary>
		public ZYTextDocument OwnerDocument ;
		/// <summary>
		/// 该对象所在的元素对象
		/// </summary>
		public ZYTextElement  OwnerElement ;

		/// <summary>
		/// 是否允许进行签名
		/// </summary>
		public bool Enable = true;

		private System.Collections.ArrayList myItems = new System.Collections.ArrayList();

		

//		/// <summary>
//		/// 该对象内部的列表对象
//		/// </summary>
//		public System.Collections.ArrayList Items
//		{
//			get{ return myItems;}
//		}

		
		/// <summary>
		/// 判断序号是否有效
		/// </summary>
		/// <param name="Index"></param>
		/// <returns></returns>
		public bool IndexAvailable(int Index)
		{
			return Index >=0 && Index < myItems.Count ;
		}

		/// <summary>
		/// 签名记录的个数
		/// </summary>
		public int Count
		{
			get{ return myItems.Count ;}
		}
		/// <summary>
		/// 获得指定序号的签名对象
		/// </summary>
		public UnderWriteMark this[int index]
		{
			get{ return ( UnderWriteMark ) myItems[index];}
		}
		/// <summary>
		/// 获得最后一个签名对象
		/// </summary>
		public UnderWriteMark LastMark
		{
			get{ return ( UnderWriteMark ) myItems[myItems.Count -1 ]; }
		}

		/// <summary>
		/// 获得最后一个签名指定的下一次签名人
		/// </summary>
		public string LastSenior
		{
			get
			{
				if( myItems.Count > 0 )
				{
					return ( ( UnderWriteMark ) myItems[myItems.Count -1 ] ).Senior ;
				}
				return null;
			}
		}

		/// <summary>
		/// 判断指定的用户名是否可以签名
		/// </summary>
		/// <param name="strUserName">用户名</param>
		/// <returns>是否可以签名</returns>
		public bool CanMark( string strUserName)
		{
			if( myItems.Count > 0 )
			{
				string ls = this.LastSenior ;
				if( ls == null || ls.Length == 0 )
					return true;
				else
					return ls == strUserName ;
			}
			return true;
		}

		/// <summary>
		/// 新建的签名对象
		/// </summary>
		public UnderWriteMark NewMark = null;

		/// <summary>
		/// 添加一个签名
		/// </summary>
		/// <param name="strUserName">签名人</param>
		/// <param name="strSenior">签名人指定的下一次签名人</param>
		/// <returns>新增的签名对象,若签名失败则返回空引用</returns>
		public UnderWriteMark AddMark( string strUserName , string strSenior )
		{
			if( myItems.Count > 0 )
			{
				string sn = this.LastSenior ;
				if( sn != null && sn.Length > 0 )
				{
					if( sn != strUserName )
						return null;
				}
			}
			NewMark = new UnderWriteMark();
			NewMark.UserName = strUserName ;
			NewMark.Senior = strSenior ;
			//NewMark.MarkTime = System.DateTime.Now ;
			NewMark.MarkTime = ZYTime.GetServerTime();
			myItems.Add( NewMark );
			if( OwnerDocument != null)
			{
                //NewMark.SaveLogIndex = OwnerDocument.SaveLogs.CurrentIndex ;
                //OwnerDocument.UpdateUserName();
			}
			//
			//				if( OwnerElement != null && OwnerElement is ZYTextContainer)
			//				{
			//					( OwnerElement as ZYTextContainer).UpdateUserLogin();
			//					OwnerElement.OwnerDocument.Refresh();
			//				}
			return NewMark;
		}

		/// <summary>
		/// 删除所有的签名对象
		/// </summary>
		public void Clear()
		{
			myItems.Clear();
		}

		public string[] ToStringArray()
		{
			string[] strItems = new string[ myItems.Count ];
			for(int iCount = 0 ; iCount < myItems.Count ; iCount ++ )
			{
				UnderWriteMark m = ( UnderWriteMark ) myItems[iCount];
				strItems[iCount] = m.DisplayText();
			}
			return strItems ;
		}

		public string GetDisplayText()
		{
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			foreach(UnderWriteMark m in myItems)
			{
				if( myStr.Length > 0 )
					myStr.Append("\r\n");
				myStr.Append( m.UserName );
				myStr.Append( " 签名于 ");
				myStr.Append( m.MarkTime.ToString("yyyy年MM月dd日 HH:mm:ss"));
			}
			if( myItems.Count > 0 )
			{
				if( StringCommon.isBlankString( this.LastMark.Senior) ==false)
					myStr.Append("\r\n 本区域指定由[ " + this.LastMark.Senior + " ]签名");
			}
			return myStr.ToString();
		}

		#region IXMLSerializable 成员

		public string GetXMLName()
		{
			return "underwritemarks";
		}

		public bool FromXML(System.Xml.XmlElement RootElement)
		{
			this.Clear();
			if( RootElement != null)
			{
				foreach(System.Xml.XmlNode myXMLNode in RootElement.ChildNodes)
				{
					if( myXMLNode is System.Xml.XmlElement)
					{
						UnderWriteMark NewMark = new UnderWriteMark();
						NewMark.FromXML( myXMLNode as System.Xml.XmlElement );
						myItems.Add( NewMark );
					}
				}
				return true;
			}
			return false;
		}

		public bool ToXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				foreach(UnderWriteMark mark in myItems)
				{
					System.Xml.XmlElement NewElement = RootElement.OwnerDocument.CreateElement(mark.GetXMLName());
					RootElement.AppendChild( NewElement );
					mark.ToXML( NewElement );
				}
				return true;
			}
			return false;
		}
		#endregion

		#region IEnumerable 成员

		public System.Collections.IEnumerator GetEnumerator()
		{
			return new myEnumerator(myItems);
		}

		#endregion

		private class myEnumerator : System.Collections.IEnumerator
		{
			private System.Collections.ArrayList myList ;
			private int index ;
			public myEnumerator( System.Collections.ArrayList lst)
			{
				myList = lst ;
				index = -1 ;
			}
			#region IEnumerator 成员

			public void Reset()
			{
				index = -1 ;
			}

			public object Current
			{
				get
				{
					return (UnderWriteMark) myList[index];
				}
			}

			public bool MoveNext()
			{
				index ++ ;
				return index < myList.Count ;
			}

			#endregion
		}

	}// class UnderWriteMarkCollection

	/// <summary>
	/// UnderWriteMark 的摘要说明。
	/// </summary>
	public class UnderWriteMark : IXMLSerializable
	{
//		/// <summary>
//		/// 该对象所在的文档对象
//		/// </summary>
//		public ZYTextDocument OwnerDocument ;
//		/// <summary>
//		/// 该对象所在的元素对象
//		/// </summary>
//		public ZYTextElement OwnerElement ;
		/// <summary>
		/// 签名人
		/// </summary>
		public string UserName ;
		/// <summary>
		/// 签名时间
		/// </summary>
		public System.DateTime MarkTime ;

		/// <summary>
		/// 签名时保存日志对象的编号
		/// </summary>
		public int SaveLogIndex ;

		/// <summary>
		/// 签名人指定的上一级人员
		/// </summary>
		public string Senior;
 
//		public string DisplayDateTime
//		{
//			get{ return dtSaveDateTime.ToString("yyyy年MM月dd日 HH:mm");}
//		}
		public string DisplayText()
		{
			return UserName + " 签名于" + MarkTime.ToString("yyyy年MM月dd日 HH:mm") ;
		}

		#region IXMLSerializable 成员

		public string GetXMLName()
		{
			return "underwritemark";
		}

		public bool FromXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				UserName = RootElement.GetAttribute("username");
				//MarkTime = StringCommon.ConvertToDateTime( RootElement.GetAttribute("marktime"),null,System.DateTime.Now);
				MarkTime = StringCommon.ConvertToDateTime( RootElement.GetAttribute("marktime"),null,ZYTime.GetServerTime());
				Senior	= RootElement.GetAttribute("senior");
				SaveLogIndex = StringCommon.ToInt32Value( RootElement.GetAttribute("savelog"),0);
				return true;
			}
			return false;
		}

		public bool ToXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				RootElement.SetAttribute("username", UserName);
				RootElement.SetAttribute("marktime", MarkTime.ToString("yyyy-MM-dd HH:mm:ss"));
				RootElement.SetAttribute("senior", Senior);
				RootElement.SetAttribute("savelog",SaveLogIndex.ToString());
				return true;
			}
			return false;
		}

		#endregion
	}
}
