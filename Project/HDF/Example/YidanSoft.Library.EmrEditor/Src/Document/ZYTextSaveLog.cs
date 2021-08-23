using System;
using YidanSoft.Library.EmrEditor.Src.Document;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace ZYTextDocumentLib
{
	/// <summary>
	/// 电子病历文档保持记录集合对象
	/// </summary>
	public class ZYTextSaveLogCollection : System.Collections.CollectionBase
	{
		private ZYTextDocument myOwnerDocument = null;
		private ZYTextSaveLog myCurrentSaveLog = new ZYTextSaveLog();

		/// <summary>
		/// 初始化对象
		/// </summary>
		public ZYTextSaveLogCollection()
		{
			this.List.Add( myCurrentSaveLog );
		}

		/// <summary>
		/// 判断序号是否有效
		/// </summary>
		/// <param name="Index"></param>
		/// <returns></returns>
		public bool IndexAvailable(int Index)
		{
			return Index >=0 && Index < this.Count ;
		}

		/// <summary>
		/// 当前记录对象的序号
		/// </summary>
		public int CurrentIndex
		{
			get{ return this.Count - 1  ;}
		}
			 
		/// <summary>
		/// 当前保存日志对象
		/// </summary>
		public ZYTextSaveLog CurrentSaveLog
		{
			get{ return myCurrentSaveLog ;}
			set{ myCurrentSaveLog = value;}
		}


		/// <summary>
		/// 当前用户名
		/// </summary>
		public string CurrentUserName
		{
			get{ return myCurrentSaveLog.UserName ;}
			set
			{
				myCurrentSaveLog.UserName  = value;
				if( myOwnerDocument != null && myOwnerDocument.DocumentElement != null)
				{
					//myOwnerDocument.DocumentElement.UpdateUserLogin();
                    //myOwnerDocument.UpdateUserName();
				}
			}
		}

		/// <summary>
		/// 该集合所在的文档对象
		/// </summary>
		public ZYTextDocument OwnerDocument
		{
			get{ return myOwnerDocument;}
			set
			{
				myOwnerDocument = value;
				foreach(ZYTextSaveLog log in this )
					log.OwnerDocument = myOwnerDocument ;
				myCurrentSaveLog.OwnerDocument = myOwnerDocument ;
			}
		}
 
//		/// <summary>
//		/// 清空列表
//		/// </summary>
//		new public void Clear()
//		{
//			base.Clear();
//			//this.List.Add( myCurrentSaveLog );
//		}
		 

		/// <summary>
		/// 获得最大的签名等级
		/// </summary>
		/// <returns></returns>
		public int GetMaxLockLevel()
		{
			int level = -1 ;
			foreach(ZYTextSaveLog log in this )
			{
				if( log.Lock )
				{
					if( level < log.Level )
						level = log.Level ;
				}
			}
			return level ;
		}

		public void Mark( )
		{
			this.myCurrentSaveLog.Lock = true;
			foreach(ZYTextSaveLog log in this )
			{
				if( log != this.myCurrentSaveLog )
				{
					if( log.UserName == this.myCurrentSaveLog.UserName )
					{
						log.Lock = true;
						log.Level = this.myCurrentSaveLog.Level ;
					}
				}
			}
		}

		public ZYTextSaveLog SafeGet( int index )
		{
			if( index >= 0 && index < this.Count )
				return (ZYTextSaveLog)this.List[index];
			else
				return null;
		}
		/// <summary>
		/// 或者指定序号的记录对象
		/// </summary>
		public ZYTextSaveLog this[int index]
		{
			get{ return (ZYTextSaveLog)this.List[index];}
		}

//		/// <summary>
//		/// 创建一个保存记录对象
//		/// </summary>
//		/// <returns></returns>
//		public ZYTextSaveLog NewLog()
//		{
//			ZYTextSaveLog log = new ZYTextSaveLog();
//			myList.Add( log );
//			log.OwnerDocument = myOwnerDocument ;
//			log.UserName = strCurrentUserName ;
//			log.SaveDateTime = System.DateTime.Now ;
//			return log;
//		}

		public string GetXMLName()
		{
			return "savelogs" ;
		}

		/// <summary>
		/// 从XML节点加载对象数据
		/// </summary>
		/// <param name="RootElement"></param>
		/// <returns></returns>
		public bool FromXML(System.Xml.XmlElement RootElement)
		{
			this.Clear();
			if( RootElement != null)
			{
				foreach(System.Xml.XmlNode myXMLNode in RootElement.ChildNodes)
				{
					if( myXMLNode is System.Xml.XmlElement )
					{
						ZYTextSaveLog LogObj = new ZYTextSaveLog();
						LogObj.FromXML( myXMLNode as System.Xml.XmlElement );
						LogObj.OwnerDocument = myOwnerDocument ;
						this.List.Add( LogObj );
					}
				}
				this.List.Add( myCurrentSaveLog );
				return true;
			}
			this.List.Add( myCurrentSaveLog );
			return false;
		}// bool FromXML

		/// <summary>
		/// 保存对象数据到XML节点
		/// </summary>
		/// <param name="RootElement"></param>
		/// <returns></returns>
		public bool ToXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				myCurrentSaveLog.SaveDateTime =  ZYTime.GetServerTime();//System.DateTime.Now ;
				foreach(ZYTextSaveLog log in this )
				{
					if(log.UserName!="speacil")
					{
						System.Xml.XmlElement NewElement = RootElement.OwnerDocument.CreateElement(log.GetXMLName());
						RootElement.AppendChild( NewElement);
						log.ToXML( NewElement );
					}
				}
				return true;
			}
			return false;
		}
		public string[] ToStringArray()
		{
			string[] strItems = new string[ this.Count];
			int iCount = 0 ;
			foreach(ZYTextSaveLog log in this )
			{
				strItems[iCount] = log.DisplayText();
				iCount ++ ;
			}
			return strItems;
		}
 	}// class ZYTextSaveLogCollection

	/// <summary>
	/// 电子病历文档保存记录
	/// </summary>
	public class ZYTextSaveLog
	{
		/// <summary>
		/// 数据锁定标志
		/// </summary>
		public bool Lock = false;
		/// <summary>
		/// 用户等级
		/// </summary>
		public int Level = 0 ;

		private ZYTextDocument myOwnerDocument = null;
		/// <summary>
		/// 该对象所在的电子病历文档对象
		/// </summary>
		public ZYTextDocument OwnerDocument
		{
			get{ return myOwnerDocument ;}
			set{ myOwnerDocument = value;}
		}

		private string strUserName = null;
		/// <summary>
		/// 保存文档的用户名
		/// </summary>
		public string UserName
		{
			get{ return strUserName;}
			set{ strUserName = value;}
		}

		private System.DateTime dtSaveDateTime = ZYTime.GetServerTime();// System.DateTime.Now ;
		/// <summary>
		/// 保存文档的时间
		/// </summary>
		public System.DateTime SaveDateTime
		{
			get{ return dtSaveDateTime ;}
			set{ dtSaveDateTime = value;}
		}

		public string DisplayDateTime
		{
			get{ return dtSaveDateTime.ToString("yyyy年MM月dd日 HH:mm");}
		}
		public string DisplayText()
		{
			if( strUserName != null && strUserName.Length > 0 )
				return strUserName + " 保存于" + dtSaveDateTime.ToString("yyyy年MM月dd日 HH:mm") ;
			else
				return "";
		}

		public string GetXMLName()
		{
			return "savelog";
		}
		public bool ToXML(System.Xml.XmlElement myElement)
		{
			if( myElement != null)
			{
				myElement.SetAttribute("name", strUserName);
				myElement.SetAttribute("time", dtSaveDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
				myElement.SetAttribute("level" , Level.ToString());
				if( this.Lock )
					myElement.SetAttribute("lock" , "1");
				return true;
			}
			return false;
		}
		public bool FromXML(System.Xml.XmlElement myElement)
		{
			if( myElement != null)
			{
				strUserName = myElement.GetAttribute("name");
				//dtSaveDateTime = ZYCommon.StringCommon.ConvertToDateTime( myElement.GetAttribute("time"),null,System.DateTime.Now);
				dtSaveDateTime = StringCommon.ConvertToDateTime( myElement.GetAttribute("time"),null,ZYTime.GetServerTime());
				this.Lock = myElement.HasAttribute("lock" );
				this.Level = StringCommon.ToInt32Value( myElement.GetAttribute("level") , 0);
				return true;
			}
			return false;
		}
 	}// class ZYTextSaveLog
}
