using System;
using System.Security.Cryptography;
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Xml;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
    /// <summary>
    /// 通用的字符串处理静态对象
    /// </summary>
    public class StringCommon
    {

        public const string c_HexCharList = "0123456789ABCDEF";
        public const string c_Base64CharList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        public const string c_ABC123CharList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.";

        public const string StartPunctuaction = "!),.:;?]}¨·ˇˉ―‖’”…∶、。〃々〉》」』】〕〗！＂＇），．：；？］｀｜｝～￠";
        public const string EndPunctuaction = "([{·‘“〈《「『【〔〖（．［｛￡￥";

        public static ElementType GetTypeByName(string name)
        {
            ElementType type = ElementType.None;
            if ("" != name)
            {
                switch (name)
                {
                    case "button":
                        type = ElementType.Button;
                        break;
                    case "fixedtext":
                        type = ElementType.FixedText;
                        break;
                    case "text":
                        type = ElementType.Text;
                        break;
                    case "formatdatetime":
                        type = ElementType.FormatDatetime;
                        break;
                    case "formatnumber":
                        type = ElementType.FormatNumber;
                        break;
                    case "formatstring":
                        type = ElementType.FormatString;
                        break;
                    case "havenotelement":
                        type = ElementType.HaveNotElement;
                        break;
                    case "multielement":
                        type = ElementType.MultiElement;
                        break;
                    case "prompttext":
                        type = ElementType.PromptText;
                        break;
                    case "singleelement":
                        type = ElementType.SingleElement;
                        break;
                    case "mensesFormula":
                        type = ElementType.MensesFormula;
                        break;
                    //新增的牙齿检查   add by ywk  2012年11月27日16:53:13
                    case "toothcheck":
                        type = ElementType.ToothCheck;
                        break;

                    case "horizontalLine":
                        type = ElementType.HorizontalLine;
                        break;
                    case "macro":
                        type = ElementType.Macro;
                        break;
                    case "replace":
                        type = ElementType.Replace;
                        break;
                    case "template":
                        type = ElementType.Template;
                        break;
                    case "checkbox":
                        type = ElementType.CheckBox;
                        break;
                    case "pageend":
                        type = ElementType.PageEnd;
                        break;
                    case "flag":
                        type = ElementType.Flag;
                        break;
                    case "lookupeditor":
                        type = ElementType.LookUpEditor;
                        break;
                    case "dataelementlookupeditor":
                        type = ElementType.DataElementLookUpEditor;
                        break;
                    case "diag":
                        type = ElementType.Diag;
                        break;
                    case "subject":
                        type = ElementType.Subject;
                        break;
                    case "tablesum":
                        type = ElementType.TableSum;
                        break;
                }
            }
            return type;
        }
        public static string GetNameByType(ElementType type)
        {
            string name = "";
            switch (type)
            {
                case ElementType.Button:
                    name = "button";
                    break;
                case ElementType.FixedText:
                    name = "fixedtext";
                    break;
                case ElementType.Text:
                    name = "text";
                    break;
                case ElementType.FormatDatetime:
                    name = "formatdatetime";
                    break;
                case ElementType.FormatNumber:
                    name = "formatnumber";
                    break;
                case ElementType.FormatString:
                    name = "formatstring";
                    break;
                case ElementType.HaveNotElement:
                    name = "havenotelement";
                    break;
                case ElementType.MultiElement:
                    name = "multielement";
                    break;
                case ElementType.PromptText:
                    name = "prompttext";
                    break;
                case ElementType.SingleElement:
                    name = "singleelement";
                    break;
                case ElementType.MensesFormula:
                    name = "mensesFormula";
                    break;

                //新增的牙齿检查   add by ywk  2012年11月27日16:53:13
                case ElementType.ToothCheck:
                    name = "toothcheck";
                    break;


                case ElementType.HorizontalLine:
                    name = "horizontalLine";
                    break;
                case ElementType.Macro:
                    name = "macro";
                    break;
                case ElementType.Replace:
                    name = "replace";
                    break;
                case ElementType.Template:
                    name = "template";
                    break;
                case ElementType.CheckBox:
                    name = "checkbox";
                    break;
                case ElementType.PageEnd:
                    name = "pageend";
                    break;
                case ElementType.Flag:
                    name = "flag";
                    break;
                case ElementType.LookUpEditor:
                    name = "lookupeditor";
                    break;
                case ElementType.DataElementLookUpEditor:
                    name = "dataelementlookupeditor";
                    break;
                case ElementType.Diag:
                    name = "diag";
                    break;
                case ElementType.Subject:
                    name = "subject";
                    break;
                case ElementType.TableSum:
                    name = "tablesum";
                    break;
            }
            return name;

        }

        public static int GetSymbolSplitLevel(char vSymbol)
        {
            if (vSymbol == '.' || vSymbol == '。')
                return 5;
            if (vSymbol == ';' || vSymbol == '；')
                return 4;
            if (vSymbol == ',' || vSymbol == '，')
                return 3;
            if (vSymbol == '、')
                return 2;
            if (char.IsWhiteSpace(vSymbol))
                return 1;
            return 0;
        }

        /// <summary>
        /// 使用GB2312编码格式读取一个文本文件的内容
        /// </summary>
        /// <param name="strFile">文件名</param>
        /// <returns>读取的文件内容，若文件不存在或发生错误则返回空引用</returns>
        public static string LoadAnsiFile(string strFile)
        {
            System.IO.StreamReader myReader = null;
            try
            {
                if (System.IO.File.Exists(strFile))
                {
                    myReader = new System.IO.StreamReader(strFile, System.Text.Encoding.GetEncoding(936));
                    string strText = myReader.ReadToEnd();
                    myReader.Close();
                    return strText;
                }
            }
            catch
            {
                if (myReader != null)
                    myReader.Close();
            }
            return null;
        }//public static string LoadAnsiFile( string strFile)

        /// <summary>
        /// 获得可用于作为控件快捷键字符列表
        /// </summary>
        /// <param name="strExcept">排除的字母组成的字符串</param>
        /// <returns>可供作为快捷字符组成的字符串</returns>
        public static string GetShortCutChars(string strExcept)
        {
            string strList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (strExcept != null)
                strExcept = strExcept.Trim().ToUpper();
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            foreach (char myChar in strList)
                if (strExcept == null || strExcept.IndexOf(myChar) < 0)
                    myStr.Append(myChar);
            return myStr.ToString();
        }// GetShortCutChars

        /// <summary>
        /// 删除XML字符串的	XML声明头
        /// </summary>
        /// <param name="strXML">XML字符串</param>
        /// <returns>去掉XML声明头的XML字符串</returns>
        public static string RemoveXMLDeclear(string strXML)
        {
            if (strXML != null)
            {
                int Index = strXML.IndexOf("?>");
                if (Index > 0)
                    return strXML.Substring(Index + 2);
            }
            return null;
        }

        public static string GetTypeVersion(System.Type t)
        {
            string[] strInfos = AnalyseStringList(t.AssemblyQualifiedName, ',', '=', false);
            if (strInfos != null && strInfos.Length > 0)
            {
                for (int iCount = 0; iCount < strInfos.Length; iCount += 2)
                {
                    if (strInfos[iCount].Trim() == "Version")
                    {
                        return strInfos[iCount + 1];
                    }
                }
            }
            return null;
        }

        private static int intAllocCount = 0;
        /// <summary>
        /// 分配一个对象名称
        /// </summary>
        /// <returns></returns>
        public static string AllocObjectName()
        {
            intAllocCount++;
            return "C" + System.Environment.TickCount.ToString("X") + intAllocCount.ToString();
        }

        public static string CombinStringArray(string[] strItems, string strItemSplit, string strValueSplit)
        {
            if (strItems != null && strItems.Length > 0 && strItems.Length % 2 == 0)
            {
                System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                int Num = strItems.Length / 2;
                for (int iCount = 0; iCount < strItems.Length; iCount += 2)
                {
                    if (myStr.Length > 0)
                        myStr.Append(strItemSplit);
                    myStr.Append(strItems[iCount]);
                    myStr.Append(strValueSplit);
                    myStr.Append(strItems[iCount + 1]);
                }
                return myStr.ToString();
            }
            return null;
        }


        /// <summary>
        /// 根据一个分隔字符拆分一个字符串
        /// </summary>
        /// <param name="strText">要拆分的字符串</param>
        /// <param name="Spliter">分隔字符</param>
        /// <returns>两个元素的字符串数组,分别是原始字符串中分隔字符前面的部分和后面的部分,若参数不正确则返回空引用
        /// 若没找到分隔字符则第一个元素为原始字符串,第二个为无内容的字符串</returns>
        public static string[] SplistString(string strText, char Spliter)
        {
            if (strText == null || strText.Length == 0)
                return null;
            else
            {
                int index = strText.IndexOf(Spliter);
                string[] strItems = new string[2];
                if (index >= 0)
                {
                    strItems[0] = strText.Substring(0, index);
                    strItems[1] = strText.Substring(index + 1);
                }
                else
                {
                    strItems[0] = strText;
                    strItems[1] = "";
                }
                return strItems;
            }
        }// string[] SplitString()


        /// <summary>
        /// 根据一个分隔字符串拆分一个字符串
        /// </summary>
        /// <param name="strText">要拆分的字符串</param>
        /// <param name="strSpliter">分隔字符串</param>
        /// <returns>两个元素的字符串数组,分别是原始字符串中分隔字符串前面的部分和后面的部分,若参数不正确则返回空引用
        /// 若没找到分隔字符串则第一个元素为原始字符串,第二个为无内容的字符串</returns>
        public static string[] SplistString(string strText, string strSpliter)
        {
            if (strText == null || strSpliter == null || strText.Length == 0)
                return null;
            else
            {
                int index = strText.IndexOf(strSpliter);
                string[] strItems = new string[2];
                if (index >= 0)
                {
                    strItems[0] = strText.Substring(0, index);
                    strItems[1] = strText.Substring(index + strSpliter.Length);
                }
                else
                {
                    strItems[0] = strText;
                    strItems[1] = "";
                }
                return strItems;
            }
        }// string[] SplitString()

        /// <summary>
        /// 分析单行字符串,该字符串为名称值=值对
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="strLastParamName"></param>
        /// <param name="AllowSameName">是否允许重名</param>
        /// <returns></returns>
        public static string[] AnalyseSingleLineParams(string strList, string strLastParamName, bool AllowSameName)
        {
            // 判断参数的正确性
            if (strList == null || strList.Length == 0)
                return null;
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            string strItem = null;
            string strName = null;
            string strValue = null;
            int index1 = 0;
            while (index1 < strList.Length)
            {
                int index2 = StringCommon.IndexofWiteSpace(strList, index1);
                if (index2 < 0)
                    index2 = strList.Length;
                if (index2 > index1 + 1)
                {
                    // 获得单个项目
                    strItem = strList.Substring(index1, index2 - index1);
                    // 获得新项目名和项目值
                    int index3 = strItem.IndexOf('=');
                    if (index3 > 0)
                    {
                        strName = strItem.Substring(0, index3);

                        strValue = strItem.Substring(index3 + 1);
                    }
                    else
                    {
                        strName = strItem;
                        strValue = "";
                    }
                    if (strLastParamName != null && strLastParamName.Equals(strName))
                    {
                        index1 = strList.IndexOf('=', index1);
                        if (index1 > 0)
                        {
                            strValue = strList.Substring(index1 + 1);
                        }
                        else
                            strValue = "";
                    }
                    // 注册新的项目
                    bool bolAdd = true;
                    if (AllowSameName == false)
                    {
                        foreach (NameValueItem myItem in myList)
                        {
                            if (myItem.Name == strName)
                            {
                                bolAdd = false;
                                break;
                            }
                        }
                    }
                    if (bolAdd)
                    {
                        NameValueItem NewItem = new NameValueItem();
                        NewItem.Name = strName;
                        NewItem.Value = strValue;
                        myList.Add(NewItem);
                    }
                }
                index1 = index2 + 1;
            }
            // 输出结果
            string[] strReturn = new string[myList.Count * 2];
            int iCount = 0;
            foreach (NameValueItem myItem in myList)
            {
                strReturn[iCount] = myItem.Name;
                strReturn[iCount + 1] = myItem.Value;
                iCount += 2;
            }
            return strReturn;
        }// string[] AnalyseStringList


        /// <summary>
        /// 本函数参数为一个多行字符串，每一行字符串由一个名称和一个值组成，名称和值间用等号分开，本函数
        /// 就是分析这个字符串，将名称和值拆开来组成一个字符串对象数组，该数组元素个数为偶数个
        /// </summary>
        /// <param name="strText">供分析的字符串</param>
        /// <returns>生成的字符串数组，数组元素个数为偶数个且大于0，若参数中没有数据则返回空对象</returns>
        public static string[] AnalyseLineParams(string strText)
        {
            if (strText == null || strText.Length == 0)
                return null;
            System.IO.StringReader myReader = new System.IO.StringReader(strText);
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            string strLine = myReader.ReadLine();
            while (strLine != null)
            {
                if (strLine.Length > 0)
                {
                    int index = strLine.IndexOf('=');
                    if (index >= 0)
                    {
                        myList.Add(strLine.Substring(0, index));
                        myList.Add(strLine.Substring(index + 1));
                    }
                    else
                    {
                        myList.Add(strLine);
                        myList.Add("");
                    }
                }
                strLine = myReader.ReadLine();
            }
            if (myList.Count > 0)
                return (string[])myList.ToArray(typeof(string));
            else
                return null;
        }// string[] AnalyseLineParams


        /// <summary>
        /// 分析一个保存列表数据的字符串并将分析结果保存在一个名称-值集合中
        /// 该字符串格式为 项目名 值分隔字符 项目值 项目分隔字符 项目名 值分隔字符 项目值 ...
        /// 例如 若值分隔字符为 ； 项目分隔字符为 = 则该输入字符串格式为 a=1;b=2;c=33
        /// 则本函数将生成一个名称-值集合对象,其中的内容为 {(a,1),(b,2),(c,33)}
        /// </summary>
        /// <param name="strList">保存列表数据的字符串</param>
        /// <param name="ItemSplit">项目分隔字符串</param>
        /// <param name="ValueSplit">值分隔字符串</param>
        /// <param name="AllowSameName">分析的项目是否允许重名</param>
        /// <returns>返回的依次保存项目名称和项目值的集合对象,参数不正确则返回空引用</returns>
        public static System.Collections.Specialized.NameValueCollection AnalyseNameValueList(string strList, char ItemSplit, char ValueSplit, bool AllowSameName)
        {
            string[] strItems = AnalyseStringList(strList, ItemSplit, ValueSplit, AllowSameName);
            if (strItems != null && strItems.Length > 0)
            {
                System.Collections.Specialized.NameValueCollection myList = new System.Collections.Specialized.NameValueCollection();
                for (int iCount = 0; iCount < strItems.Length; iCount += 2)
                    myList.Set(strItems[iCount], strItems[iCount + 1]);
                return myList;
            }
            return null;
        }

        /// <summary>
        /// 分析一个保存列表数据的字符串并将分析结果保存在一个字符串数组中
        /// 该字符串格式为 项目名 值分隔字符 项目值 项目分隔字符 项目名 值分隔字符 项目值 ...
        /// 例如 若值分隔字符为 ； 项目分隔字符为 = 则该输入字符串格式为 a=1;b=2;c=33
        /// 则本函数将生成一个字符串数组 {a,1,b,2,c,33}，数组元素为偶数个
        /// </summary>
        /// <param name="strList">保存列表数据的字符串</param>
        /// <param name="ItemSplit">项目分隔字符串</param>
        /// <param name="ValueSplit">值分隔字符串</param>
        /// <param name="AllowSameName">分析的项目是否允许重名</param>
        /// <returns>返回的依次保存项目名称和项目值的字符串，元素个数必为偶数个,参数不正确则返回空引用</returns>
        public static string[] AnalyseStringList(string strList, char ItemSplit, char ValueSplit, bool AllowSameName)
        {
            // 判断参数的正确性
            if (strList == null || strList.Length == 0)
                return null;
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            string strItem = null;
            string strName = null;
            string strValue = null;
            int index1 = 0;
            while (index1 < strList.Length)
            {
                int index2 = strList.IndexOf(ItemSplit, index1);
                if (index2 < 0)
                    index2 = strList.Length;
                if (index2 > index1 + 1)
                {
                    // 获得单个项目
                    strItem = strList.Substring(index1, index2 - index1);
                    // 获得西项目名和项目值
                    int index3 = strItem.IndexOf(ValueSplit);
                    if (index3 > 0)
                    {
                        strName = strItem.Substring(0, index3);
                        strValue = strItem.Substring(index3 + 1);
                    }
                    else
                    {
                        strName = strItem;
                        strValue = "";
                    }
                    // 注册新的项目
                    bool bolAdd = true;
                    if (AllowSameName == false)
                    {
                        foreach (NameValueItem myItem in myList)
                        {
                            if (myItem.Name == strName)
                            {
                                bolAdd = false;
                                break;
                            }
                        }
                    }
                    if (bolAdd)
                    {
                        NameValueItem NewItem = new NameValueItem();
                        NewItem.Name = strName;
                        NewItem.Value = strValue;
                        myList.Add(NewItem);
                    }
                }
                index1 = index2 + 1;
            }
            // 输出结果
            string[] strReturn = new string[myList.Count * 2];
            int iCount = 0;
            foreach (NameValueItem myItem in myList)
            {
                strReturn[iCount] = myItem.Name;
                strReturn[iCount + 1] = myItem.Value;
                iCount += 2;
            }
            return strReturn;
        }// string[] AnalyseStringList


        /// <summary>
        /// 内部使用的名称和值的项目对
        /// </summary>
        private class NameValueItem
        {
            public string Name;
            public string Value;
        }
        //
        //
        //		/// <summary>
        //		/// Fill a hashtable with a xmlelement attribute set 
        //		/// add attribute name as hashtable item's key and attribute value as hashtable item's value 
        //		/// </summary>
        //		/// <param name="myTable">hashtable object</param>
        //		/// <param name="myElement">xmlelement object</param>
        //		/// <returns>number of key-value set add to hashtable, -1 for error</returns>
        //		public static int LoadHashTableFromXMLAttribute( System.Collections.Hashtable myTable , System.Xml.XmlElement myElement)
        //		{
        //			int iCount = 0 ;
        //			if( myTable == null && myElement == null)
        //				return -1;
        //			try
        //			{
        //				foreach(System.Xml.XmlAttribute myAttr in myElement.Attributes)
        //				{
        //					myTable.Add( myAttr.Name , myAttr.Value);
        //					iCount ++ ;
        //				}
        //				return iCount ;
        //			}
        //			catch
        //			{
        //				return -1;
        //			}
        //		}// End of function : LoadHashTableFromXMLAttribute
        //
        //		/// <summary>
        //		/// Save HashTable's keys and values to a xmlelement's attribute set
        //		/// </summary>
        //		/// <param name="myTable">hashtable Object</param>
        //		/// <param name="myElement">XMLElement object</param>
        //		/// <returns>handle is ok</returns>
        //		public static bool SaveHashTableToXMLAttribute( System.Collections.Hashtable myTable , System.Xml.XmlElement myElement)
        //		{
        //			if( myTable != null && myElement != null)
        //			{
        //				for( int iCount = 0 ; iCount < myTable.Count ; iCount ++ )
        //				{
        //					string strKey = myTable.Keys[iCount];
        //					string strValue = myTable[strKey];
        //					if( strValue != null && strValue.Length != 0 )
        //						myElement.SetAttribute(strKey , strValue );
        //				}
        //				return true;
        //			}
        //			return false;
        //		}
        //
        //		/// <summary>
        //		/// Copy all key and value from source hashtable to target hashtable
        //		/// </summary>
        //		/// <param name="from">Source hashtable object</param>
        //		/// <param name="to">Target hashtable object</param>
        //		public static void CopyHashTableTo( System.Collections.Hashtable from , System.Collections.Hashtable to)
        //		{
        //			// if one of the hastables is null refrence or two refrence is equation 
        //			// then no meaning to copy data
        //			if( from == null || to == null || from == to )
        //				return  ;
        //			// remove all target hashtable's data
        //			to.Clear();
        //			// enumerate the source hashtable , copy every key and value to target hashtable
        //			for(int iCount = 0 ; iCount < from.Count ; iCount ++ )
        //				to.Add( from.Keys[iCount], from.Values[iCount] );
        //		}
        //
        //		/// <summary>
        //		/// 比较两个哈希列表中的内容是否完全一致
        //		/// 若一个列表为空则视为相同
        //		/// </summary>
        //		/// <param name="t1">第一个哈希列表</param>
        //		/// <param name="t2">第二个哈希列表</param>
        //		/// <returns>比较结果</returns>
        //		public static bool EqualHashTable( System.Collections.Hashtable t1 , System.Collections.Hashtable t2)
        //		{
        //			// 若两个哈希列表中有一个为空或两个列表对象的引用一样则判断通过
        //			if( t1 == null || t2 == null || t1 == t2 )
        //				return true;
        //
        //			// 若两个列表项目个数不一致则比较失败
        //			if( t1.Count != t2.Count) 
        //				return false;
        //
        //			// 遍历第一个列表中所有的项目,查看在第二个列表是否存在相应的项目且值一样
        //			for(int iCount = 0 ; iCount < t1.Count ; iCount ++ )
        //			{
        //				object objKey = t1.Keys[iCount]; // 获得当前键值
        //				if( t2.ContainsKey(objKey))
        //				{
        //					if( t1[objKey] != null )
        //					{
        //						// 若第一个列表中当前值和第二个列表的相对应的值比较不通过则比较失败
        //						if( t1[objKey].Equals( t2[objKey] ) == false )
        //							return false;
        //					}
        //					else
        //					{
        //						// 若第一个列表当前值为空而第二个列表相对应的值不为空则比较失败
        //						if( t2[objKey] != null) 
        //							return false;
        //					}
        //				}
        //				else
        //					// 当前键值在第二个列表中不存在则判断不通过,立即返回
        //					return false;
        //			}
        //			// 所有的项目判断通过,则确定两个列表内容完全一样,返回成功
        //			return true;
        //		}// End of function : EqualHashTable 


        /// <summary>
        /// 汉字拼音首字母列表 本列表包含了20902个汉字,用于配合 GetChineseSpell 函数使用,本表收录的字符的Unicode编码范围为19968至40869
        /// </summary>
        private static string strChineseFirstPY =
            "YDYQSXMWZSSXJBYMGCCZQPSSQBYCDSCDQLDYLYBSSJGYZZJJFKCCLZDHWDWZJLJPFYYNWJJTMYHZWZHFLZPPQHGSCYYYNJQYXXGJ"
            + "HHSDSJNKKTMOMLCRXYPSNQSECCQZGGLLYJLMYZZSECYKYYHQWJSSGGYXYZYJWWKDJHYCHMYXJTLXJYQBYXZLDWRDJRWYSRLDZJPC"
            + "BZJJBRCFTLECZSTZFXXZHTRQHYBDLYCZSSYMMRFMYQZPWWJJYFCRWFDFZQPYDDWYXKYJAWJFFXYPSFTZYHHYZYSWCJYXSCLCXXWZ"
            + "ZXNBGNNXBXLZSZSBSGPYSYZDHMDZBQBZCWDZZYYTZHBTSYYBZGNTNXQYWQSKBPHHLXGYBFMJEBJHHGQTJCYSXSTKZHLYCKGLYSMZ"
            + "XYALMELDCCXGZYRJXSDLTYZCQKCNNJWHJTZZCQLJSTSTBNXBTYXCEQXGKWJYFLZQLYHYXSPSFXLMPBYSXXXYDJCZYLLLSJXFHJXP"
            + "JBTFFYABYXBHZZBJYZLWLCZGGBTSSMDTJZXPTHYQTGLJSCQFZKJZJQNLZWLSLHDZBWJNCJZYZSQQYCQYRZCJJWYBRTWPYFTWEXCS"
            + "KDZCTBZHYZZYYJXZCFFZZMJYXXSDZZOTTBZLQWFCKSZSXFYRLNYJMBDTHJXSQQCCSBXYYTSYFBXDZTGBCNSLCYZZPSAZYZZSCJCS"
            + "HZQYDXLBPJLLMQXTYDZXSQJTZPXLCGLQTZWJBHCTSYJSFXYEJJTLBGXSXJMYJQQPFZASYJNTYDJXKJCDJSZCBARTDCLYJQMWNQNC"
            + "LLLKBYBZZSYHQQLTWLCCXTXLLZNTYLNEWYZYXCZXXGRKRMTCNDNJTSYYSSDQDGHSDBJGHRWRQLYBGLXHLGTGXBQJDZPYJSJYJCTM"
            + "RNYMGRZJCZGJMZMGXMPRYXKJNYMSGMZJYMKMFXMLDTGFBHCJHKYLPFMDXLQJJSMTQGZSJLQDLDGJYCALCMZCSDJLLNXDJFFFFJCZ"
            + "FMZFFPFKHKGDPSXKTACJDHHZDDCRRCFQYJKQCCWJDXHWJLYLLZGCFCQDSMLZPBJJPLSBCJGGDCKKDEZSQCCKJGCGKDJTJDLZYCXK"
            + "LQSCGJCLTFPCQCZGWPJDQYZJJBYJHSJDZWGFSJGZKQCCZLLPSPKJGQJHZZLJPLGJGJJTHJJYJZCZMLZLYQBGJWMLJKXZDZNJQSYZ"
            + "MLJLLJKYWXMKJLHSKJGBMCLYYMKXJQLBMLLKMDXXKWYXYSLMLPSJQQJQXYXFJTJDXMXXLLCXQBSYJBGWYMBGGBCYXPJYGPEPFGDJ"
            + "GBHBNSQJYZJKJKHXQFGQZKFHYGKHDKLLSDJQXPQYKYBNQSXQNSZSWHBSXWHXWBZZXDMNSJBSBKBBZKLYLXGWXDRWYQZMYWSJQLCJ"
            + "XXJXKJEQXSCYETLZHLYYYSDZPAQYZCMTLSHTZCFYZYXYLJSDCJQAGYSLCQLYYYSHMRQQKLDXZSCSSSYDYCJYSFSJBFRSSZQSBXXP"
            + "XJYSDRCKGJLGDKZJZBDKTCSYQPYHSTCLDJDHMXMCGXYZHJDDTMHLTXZXYLYMOHYJCLTYFBQQXPFBDFHHTKSQHZYYWCNXXCRWHOWG"
            + "YJLEGWDQCWGFJYCSNTMYTOLBYGWQWESJPWNMLRYDZSZTXYQPZGCWXHNGPYXSHMYQJXZTDPPBFYHZHTJYFDZWKGKZBLDNTSXHQEEG"
            + "ZZYLZMMZYJZGXZXKHKSTXNXXWYLYAPSTHXDWHZYMPXAGKYDXBHNHXKDPJNMYHYLPMGOCSLNZHKXXLPZZLBMLSFBHHGYGYYGGBHSC"
            + "YAQTYWLXTZQCEZYDQDQMMHTKLLSZHLSJZWFYHQSWSCWLQAZYNYTLSXTHAZNKZZSZZLAXXZWWCTGQQTDDYZTCCHYQZFLXPSLZYGPZ"
            + "SZNGLNDQTBDLXGTCTAJDKYWNSYZLJHHZZCWNYYZYWMHYCHHYXHJKZWSXHZYXLYSKQYSPSLYZWMYPPKBYGLKZHTYXAXQSYSHXASMC"
            + "HKDSCRSWJPWXSGZJLWWSCHSJHSQNHCSEGNDAQTBAALZZMSSTDQJCJKTSCJAXPLGGXHHGXXZCXPDMMHLDGTYBYSJMXHMRCPXXJZCK"
            + "ZXSHMLQXXTTHXWZFKHCCZDYTCJYXQHLXDHYPJQXYLSYYDZOZJNYXQEZYSQYAYXWYPDGXDDXSPPYZNDLTWRHXYDXZZJHTCXMCZLHP"
            + "YYYYMHZLLHNXMYLLLMDCPPXHMXDKYCYRDLTXJCHHZZXZLCCLYLNZSHZJZZLNNRLWHYQSNJHXYNTTTKYJPYCHHYEGKCTTWLGQRLGG"
            + "TGTYGYHPYHYLQYQGCWYQKPYYYTTTTLHYHLLTYTTSPLKYZXGZWGPYDSSZZDQXSKCQNMJJZZBXYQMJRTFFBTKHZKBXLJJKDXJTLBWF"
            + "ZPPTKQTZTGPDGNTPJYFALQMKGXBDCLZFHZCLLLLADPMXDJHLCCLGYHDZFGYDDGCYYFGYDXKSSEBDHYKDKDKHNAXXYBPBYYHXZQGA"
            + "FFQYJXDMLJCSQZLLPCHBSXGJYNDYBYQSPZWJLZKSDDTACTBXZDYZYPJZQSJNKKTKNJDJGYYPGTLFYQKASDNTCYHBLWDZHBBYDWJR"
            + "YGKZYHEYYFJMSDTYFZJJHGCXPLXHLDWXXJKYTCYKSSSMTWCTTQZLPBSZDZWZXGZAGYKTYWXLHLSPBCLLOQMMZSSLCMBJCSZZKYDC"
            + "ZJGQQDSMCYTZQQLWZQZXSSFPTTFQMDDZDSHDTDWFHTDYZJYQJQKYPBDJYYXTLJHDRQXXXHAYDHRJLKLYTWHLLRLLRCXYLBWSRSZZ"
            + "SYMKZZHHKYHXKSMDSYDYCJPBZBSQLFCXXXNXKXWYWSDZYQOGGQMMYHCDZTTFJYYBGSTTTYBYKJDHKYXBELHTYPJQNFXFDYKZHQKZ"
            + "BYJTZBXHFDXKDASWTAWAJLDYJSFHBLDNNTNQJTJNCHXFJSRFWHZFMDRYJYJWZPDJKZYJYMPCYZNYNXFBYTFYFWYGDBNZZZDNYTXZ"
            + "EMMQBSQEHXFZMBMFLZZSRXYMJGSXWZJSPRYDJSJGXHJJGLJJYNZZJXHGXKYMLPYYYCXYTWQZSWHWLYRJLPXSLSXMFSWWKLCTNXNY"
            + "NPSJSZHDZEPTXMYYWXYYSYWLXJQZQXZDCLEEELMCPJPCLWBXSQHFWWTFFJTNQJHJQDXHWLBYZNFJLALKYYJLDXHHYCSTYYWNRJYX"
            + "YWTRMDRQHWQCMFJDYZMHMYYXJWMYZQZXTLMRSPWWCHAQBXYGZYPXYYRRCLMPYMGKSJSZYSRMYJSNXTPLNBAPPYPYLXYYZKYNLDZY"
            + "JZCZNNLMZHHARQMPGWQTZMXXMLLHGDZXYHXKYXYCJMFFYYHJFSBSSQLXXNDYCANNMTCJCYPRRNYTYQNYYMBMSXNDLYLYSLJRLXYS"
            + "XQMLLYZLZJJJKYZZCSFBZXXMSTBJGNXYZHLXNMCWSCYZYFZLXBRNNNYLBNRTGZQYSATSWRYHYJZMZDHZGZDWYBSSCSKXSYHYTXXG"
            + "CQGXZZSHYXJSCRHMKKBXCZJYJYMKQHZJFNBHMQHYSNJNZYBKNQMCLGQHWLZNZSWXKHLJHYYBQLBFCDSXDLDSPFZPSKJYZWZXZDDX"
            + "JSMMEGJSCSSMGCLXXKYYYLNYPWWWGYDKZJGGGZGGSYCKNJWNJPCXBJJTQTJWDSSPJXZXNZXUMELPXFSXTLLXCLJXJJLJZXCTPSWX"
            + "LYDHLYQRWHSYCSQYYBYAYWJJJQFWQCQQCJQGXALDBZZYJGKGXPLTZYFXJLTPADKYQHPMATLCPDCKBMTXYBHKLENXDLEEGQDYMSAW"
            + "HZMLJTWYGXLYQZLJEEYYBQQFFNLYXRDSCTGJGXYYNKLLYQKCCTLHJLQMKKZGCYYGLLLJDZGYDHZWXPYSJBZKDZGYZZHYWYFQYTYZ"
            + "SZYEZZLYMHJJHTSMQWYZLKYYWZCSRKQYTLTDXWCTYJKLWSQZWBDCQYNCJSRSZJLKCDCDTLZZZACQQZZDDXYPLXZBQJYLZLLLQDDZ"
            + "QJYJYJZYXNYYYNYJXKXDAZWYRDLJYYYRJLXLLDYXJCYWYWNQCCLDDNYYYNYCKCZHXXCCLGZQJGKWPPCQQJYSBZZXYJSQPXJPZBSB"
            + "DSFNSFPZXHDWZTDWPPTFLZZBZDMYYPQJRSDZSQZSQXBDGCPZSWDWCSQZGMDHZXMWWFYBPDGPHTMJTHZSMMBGZMBZJCFZWFZBBZMQ"
            + "CFMBDMCJXLGPNJBBXGYHYYJGPTZGZMQBQTCGYXJXLWZKYDPDYMGCFTPFXYZTZXDZXTGKMTYBBCLBJASKYTSSQYYMSZXFJEWLXLLS"
            + "ZBQJJJAKLYLXLYCCTSXMCWFKKKBSXLLLLJYXTYLTJYYTDPJHNHNNKBYQNFQYYZBYYESSESSGDYHFHWTCJBSDZZTFDMXHCNJZYMQW"
            + "SRYJDZJQPDQBBSTJGGFBKJBXTGQHNGWJXJGDLLTHZHHYYYYYYSXWTYYYCCBDBPYPZYCCZYJPZYWCBDLFWZCWJDXXHYHLHWZZXJTC"
            + "ZLCDPXUJCZZZLYXJJTXPHFXWPYWXZPTDZZBDZCYHJHMLXBQXSBYLRDTGJRRCTTTHYTCZWMXFYTWWZCWJWXJYWCSKYBZSCCTZQNHX"
            + "NWXXKHKFHTSWOCCJYBCMPZZYKBNNZPBZHHZDLSYDDYTYFJPXYNGFXBYQXCBHXCPSXTYZDMKYSNXSXLHKMZXLYHDHKWHXXSSKQYHH"
            + "CJYXGLHZXCSNHEKDTGZXQYPKDHEXTYKCNYMYYYPKQYYYKXZLTHJQTBYQHXBMYHSQCKWWYLLHCYYLNNEQXQWMCFBDCCMLJGGXDQKT"
            + "LXKGNQCDGZJWYJJLYHHQTTTNWCHMXCXWHWSZJYDJCCDBQCDGDNYXZTHCQRXCBHZTQCBXWGQWYYBXHMBYMYQTYEXMQKYAQYRGYZSL"
            + "FYKKQHYSSQYSHJGJCNXKZYCXSBXYXHYYLSTYCXQTHYSMGSCPMMGCCCCCMTZTASMGQZJHKLOSQYLSWTMXSYQKDZLJQQYPLSYCZTCQ"
            + "QPBBQJZCLPKHQZYYXXDTDDTSJCXFFLLCHQXMJLWCJCXTSPYCXNDTJSHJWXDQQJSKXYAMYLSJHMLALYKXCYYDMNMDQMXMCZNNCYBZ"
            + "KKYFLMCHCMLHXRCJJHSYLNMTJZGZGYWJXSRXCWJGJQHQZDQJDCJJZKJKGDZQGJJYJYLXZXXCDQHHHEYTMHLFSBDJSYYSHFYSTCZQ"
            + "LPBDRFRZTZYKYWHSZYQKWDQZRKMSYNBCRXQBJYFAZPZZEDZCJYWBCJWHYJBQSZYWRYSZPTDKZPFPBNZTKLQYHBBZPNPPTYZZYBQN"
            + "YDCPJMMCYCQMCYFZZDCMNLFPBPLNGQJTBTTNJZPZBBZNJKLJQYLNBZQHKSJZNGGQSZZKYXSHPZSNBCGZKDDZQANZHJKDRTLZLSWJ"
            + "LJZLYWTJNDJZJHXYAYNCBGTZCSSQMNJPJYTYSWXZFKWJQTKHTZPLBHSNJZSYZBWZZZZLSYLSBJHDWWQPSLMMFBJDWAQYZTCJTBNN"
            + "WZXQXCDSLQGDSDPDZHJTQQPSWLYYJZLGYXYZLCTCBJTKTYCZJTQKBSJLGMGZDMCSGPYNJZYQYYKNXRPWSZXMTNCSZZYXYBYHYZAX"
            + "YWQCJTLLCKJJTJHGDXDXYQYZZBYWDLWQCGLZGJGQRQZCZSSBCRPCSKYDZNXJSQGXSSJMYDNSTZTPBDLTKZWXQWQTZEXNQCZGWEZK"
            + "SSBYBRTSSSLCCGBPSZQSZLCCGLLLZXHZQTHCZMQGYZQZNMCOCSZJMMZSQPJYGQLJYJPPLDXRGZYXCCSXHSHGTZNLZWZKJCXTCFCJ"
            + "XLBMQBCZZWPQDNHXLJCTHYZLGYLNLSZZPCXDSCQQHJQKSXZPBAJYEMSMJTZDXLCJYRYYNWJBNGZZTMJXLTBSLYRZPYLSSCNXPHLL"
            + "HYLLQQZQLXYMRSYCXZLMMCZLTZSDWTJJLLNZGGQXPFSKYGYGHBFZPDKMWGHCXMSGDXJMCJZDYCABXJDLNBCDQYGSKYDQTXDJJYXM"
            + "SZQAZDZFSLQXYJSJZYLBTXXWXQQZBJZUFBBLYLWDSLJHXJYZJWTDJCZFQZQZZDZSXZZQLZCDZFJHYSPYMPQZMLPPLFFXJJNZZYLS"
            + "JEYQZFPFZKSYWJJJHRDJZZXTXXGLGHYDXCSKYSWMMZCWYBAZBJKSHFHJCXMHFQHYXXYZFTSJYZFXYXPZLCHMZMBXHZZSXYFYMNCW"
            + "DABAZLXKTCSHHXKXJJZJSTHYGXSXYYHHHJWXKZXSSBZZWHHHCWTZZZPJXSNXQQJGZYZYWLLCWXZFXXYXYHXMKYYSWSQMNLNAYCYS"
            + "PMJKHWCQHYLAJJMZXHMMCNZHBHXCLXTJPLTXYJHDYYLTTXFSZHYXXSJBJYAYRSMXYPLCKDUYHLXRLNLLSTYZYYQYGYHHSCCSMZCT"
            + "ZQXKYQFPYYRPFFLKQUNTSZLLZMWWTCQQYZWTLLMLMPWMBZSSTZRBPDDTLQJJBXZCSRZQQYGWCSXFWZLXCCRSZDZMCYGGDZQSGTJS"
            + "WLJMYMMZYHFBJDGYXCCPSHXNZCSBSJYJGJMPPWAFFYFNXHYZXZYLREMZGZCYZSSZDLLJCSQFNXZKPTXZGXJJGFMYYYSNBTYLBNLH"
            + "PFZDCYFBMGQRRSSSZXYSGTZRNYDZZCDGPJAFJFZKNZBLCZSZPSGCYCJSZLMLRSZBZZLDLSLLYSXSQZQLYXZLSKKBRXBRBZCYCXZZ"
            + "ZEEYFGKLZLYYHGZSGZLFJHGTGWKRAAJYZKZQTSSHJJXDCYZUYJLZYRZDQQHGJZXSSZBYKJPBFRTJXLLFQWJHYLQTYMBLPZDXTZYG"
            + "BDHZZRBGXHWNJTJXLKSCFSMWLSDQYSJTXKZSCFWJLBXFTZLLJZLLQBLSQMQQCGCZFPBPHZCZJLPYYGGDTGWDCFCZQYYYQYSSCLXZ"
            + "SKLZZZGFFCQNWGLHQYZJJCZLQZZYJPJZZBPDCCMHJGXDQDGDLZQMFGPSYTSDYFWWDJZJYSXYYCZCYHZWPBYKXRYLYBHKJKSFXTZJ"
            + "MMCKHLLTNYYMSYXYZPYJQYCSYCWMTJJKQYRHLLQXPSGTLYYCLJSCPXJYZFNMLRGJJTYZBXYZMSJYJHHFZQMSYXRSZCWTLRTQZSST"
            + "KXGQKGSPTGCZNJSJCQCXHMXGGZTQYDJKZDLBZSXJLHYQGGGTHQSZPYHJHHGYYGKGGCWJZZYLCZLXQSFTGZSLLLMLJSKCTBLLZZSZ"
            + "MMNYTPZSXQHJCJYQXYZXZQZCPSHKZZYSXCDFGMWQRLLQXRFZTLYSTCTMJCXJJXHJNXTNRZTZFQYHQGLLGCXSZSJDJLJCYDSJTLNY"
            + "XHSZXCGJZYQPYLFHDJSBPCCZHJJJQZJQDYBSSLLCMYTTMQTBHJQNNYGKYRQYQMZGCJKPDCGMYZHQLLSLLCLMHOLZGDYYFZSLJCQZ"
            + "LYLZQJESHNYLLJXGJXLYSYYYXNBZLJSSZCQQCJYLLZLTJYLLZLLBNYLGQCHXYYXOXCXQKYJXXXYKLXSXXYQXCYKQXQCSGYXXYQXY"
            + "GYTQOHXHXPYXXXULCYEYCHZZCBWQBBWJQZSCSZSSLZYLKDESJZWMYMCYTSDSXXSCJPQQSQYLYYZYCMDJDZYWCBTJSYDJKCYDDJLB"
            + "DJJSODZYSYXQQYXDHHGQQYQHDYXWGMMMAJDYBBBPPBCMUUPLJZSMTXERXJMHQNUTPJDCBSSMSSSTKJTSSMMTRCPLZSZMLQDSDMJM"
            + "QPNQDXCFYNBFSDQXYXHYAYKQYDDLQYYYSSZBYDSLNTFQTZQPZMCHDHCZCWFDXTMYQSPHQYYXSRGJCWTJTZZQMGWJJTJHTQJBBHWZ"
            + "PXXHYQFXXQYWYYHYSCDYDHHQMNMTMWCPBSZPPZZGLMZFOLLCFWHMMSJZTTDHZZYFFYTZZGZYSKYJXQYJZQBHMBZZLYGHGFMSHPZF"
            + "ZSNCLPBQSNJXZSLXXFPMTYJYGBXLLDLXPZJYZJYHHZCYWHJYLSJEXFSZZYWXKZJLUYDTMLYMQJPWXYHXSKTQJEZRPXXZHHMHWQPW"
            + "QLYJJQJJZSZCPHJLCHHNXJLQWZJHBMZYXBDHHYPZLHLHLGFWLCHYYTLHJXCJMSCPXSTKPNHQXSRTYXXTESYJCTLSSLSTDLLLWWYH"
            + "DHRJZSFGXTSYCZYNYHTDHWJSLHTZDQDJZXXQHGYLTZPHCSQFCLNJTCLZPFSTPDYNYLGMJLLYCQHYSSHCHYLHQYQTMZYPBYWRFQYK"
            + "QSYSLZDQJMPXYYSSRHZJNYWTQDFZBWWTWWRXCWHGYHXMKMYYYQMSMZHNGCEPMLQQMTCWCTMMPXJPJJHFXYYZSXZHTYBMSTSYJTTQ"
            + "QQYYLHYNPYQZLCYZHZWSMYLKFJXLWGXYPJYTYSYXYMZCKTTWLKSMZSYLMPWLZWXWQZSSAQSYXYRHSSNTSRAPXCPWCMGDXHXZDZYF"
            + "JHGZTTSBJHGYZSZYSMYCLLLXBTYXHBBZJKSSDMALXHYCFYGMQYPJYCQXJLLLJGSLZGQLYCJCCZOTYXMTMTTLLWTGPXYMZMKLPSZZ"
            + "ZXHKQYSXCTYJZYHXSHYXZKXLZWPSQPYHJWPJPWXQQYLXSDHMRSLZZYZWTTCYXYSZZSHBSCCSTPLWSSCJCHNLCGCHSSPHYLHFHHXJ"
            + "SXYLLNYLSZDHZXYLSXLWZYKCLDYAXZCMDDYSPJTQJZLNWQPSSSWCTSTSZLBLNXSMNYYMJQBQHRZWTYYDCHQLXKPZWBGQYBKFCMZW"
            + "PZLLYYLSZYDWHXPSBCMLJBSCGBHXLQHYRLJXYSWXWXZSLDFHLSLYNJLZYFLYJYCDRJLFSYZFSLLCQYQFGJYHYXZLYLMSTDJCYHBZ"
            + "LLNWLXXYGYYHSMGDHXXHHLZZJZXCZZZCYQZFNGWPYLCPKPYYPMCLQKDGXZGGWQBDXZZKZFBXXLZXJTPJPTTBYTSZZDWSLCHZHSLT"
            + "YXHQLHYXXXYYZYSWTXZKHLXZXZPYHGCHKCFSYHUTJRLXFJXPTZTWHPLYXFCRHXSHXKYXXYHZQDXQWULHYHMJTBFLKHTXCWHJFWJC"
            + "FPQRYQXCYYYQYGRPYWSGSUNGWCHKZDXYFLXXHJJBYZWTSXXNCYJJYMSWZJQRMHXZWFQSYLZJZGBHYNSLBGTTCSYBYXXWXYHXYYXN"
            + "SQYXMQYWRGYQLXBBZLJSYLPSYTJZYHYZAWLRORJMKSCZJXXXYXCHDYXRYXXJDTSQFXLYLTSFFYXLMTYJMJUYYYXLTZCSXQZQHZXL"
            + "YYXZHDNBRXXXJCTYHLBRLMBRLLAXKYLLLJLYXXLYCRYLCJTGJCMTLZLLCYZZPZPCYAWHJJFYBDYYZSMPCKZDQYQPBPCJPDCYZMDP"
            + "BCYYDYCNNPLMTMLRMFMMGWYZBSJGYGSMZQQQZTXMKQWGXLLPJGZBQCDJJJFPKJKCXBLJMSWMDTQJXLDLPPBXCWRCQFBFQJCZAHZG"
            + "MYKPHYYHZYKNDKZMBPJYXPXYHLFPNYYGXJDBKXNXHJMZJXSTRSTLDXSKZYSYBZXJLXYSLBZYSLHXJPFXPQNBYLLJQKYGZMCYZZYM"
            + "CCSLCLHZFWFWYXZMWSXTYNXJHPYYMCYSPMHYSMYDYSHQYZCHMJJMZCAAGCFJBBHPLYZYLXXSDJGXDHKXXTXXNBHRMLYJSLTXMRHN"
            + "LXQJXYZLLYSWQGDLBJHDCGJYQYCMHWFMJYBMBYJYJWYMDPWHXQLDYGPDFXXBCGJSPCKRSSYZJMSLBZZJFLJJJLGXZGYXYXLSZQYX"
            + "BEXYXHGCXBPLDYHWETTWWCJMBTXCHXYQXLLXFLYXLLJLSSFWDPZSMYJCLMWYTCZPCHQEKCQBWLCQYDPLQPPQZQFJQDJHYMMCXTXD"
            + "RMJWRHXCJZYLQXDYYNHYYHRSLSRSYWWZJYMTLTLLGTQCJZYABTCKZCJYCCQLJZQXALMZYHYWLWDXZXQDLLQSHGPJFJLJHJABCQZD"
            + "JGTKHSSTCYJLPSWZLXZXRWGLDLZRLZXTGSLLLLZLYXXWGDZYGBDPHZPBRLWSXQBPFDWOFMWHLYPCBJCCLDMBZPBZZLCYQXLDOMZB"
            + "LZWPDWYYGDSTTHCSQSCCRSSSYSLFYBFNTYJSZDFNDPDHDZZMBBLSLCMYFFGTJJQWFTMTPJWFNLBZCMMJTGBDZLQLPYFHYYMJYLSD"
            + "CHDZJWJCCTLJCLDTLJJCPDDSQDSSZYBNDBJLGGJZXSXNLYCYBJXQYCBYLZCFZPPGKCXZDZFZTJJFJSJXZBNZYJQTTYJYHTYCZHYM"
            + "DJXTTMPXSPLZCDWSLSHXYPZGTFMLCJTYCBPMGDKWYCYZCDSZZYHFLYCTYGWHKJYYLSJCXGYWJCBLLCSNDDBTZBSCLYZCZZSSQDLL"
            + "MQYYHFSLQLLXFTYHABXGWNYWYYPLLSDLDLLBJCYXJZMLHLJDXYYQYTDLLLBUGBFDFBBQJZZMDPJHGCLGMJJPGAEHHBWCQXAXHHHZ"
            + "CHXYPHJAXHLPHJPGPZJQCQZGJJZZUZDMQYYBZZPHYHYBWHAZYJHYKFGDPFQSDLZMLJXKXGALXZDAGLMDGXMWZQYXXDXXPFDMMSSY"
            + "MPFMDMMKXKSYZYSHDZKXSYSMMZZZMSYDNZZCZXFPLSTMZDNMXCKJMZTYYMZMZZMSXHHDCZJEMXXKLJSTLWLSQLYJZLLZJSSDPPMH"
            + "NLZJCZYHMXXHGZCJMDHXTKGRMXFWMCGMWKDTKSXQMMMFZZYDKMSCLCMPCGMHSPXQPZDSSLCXKYXTWLWJYAHZJGZQMCSNXYYMMPML"
            + "KJXMHLMLQMXCTKZMJQYSZJSYSZHSYJZJCDAJZYBSDQJZGWZQQXFKDMSDJLFWEHKZQKJPEYPZYSZCDWYJFFMZZYLTTDZZEFMZLBNP"
            + "PLPLPEPSZALLTYLKCKQZKGENQLWAGYXYDPXLHSXQQWQCQXQCLHYXXMLYCCWLYMQYSKGCHLCJNSZKPYZKCQZQLJPDMDZHLASXLBYD"
            + "WQLWDNBQCRYDDZTJYBKBWSZDXDTNPJDTCTQDFXQQMGNXECLTTBKPWSLCTYQLPWYZZKLPYGZCQQPLLKCCYLPQMZCZQCLJSLQZDJXL"
            + "DDHPZQDLJJXZQDXYZQKZLJCYQDYJPPYPQYKJYRMPCBYMCXKLLZLLFQPYLLLMBSGLCYSSLRSYSQTMXYXZQZFDZUYSYZTFFMZZSMZQ"
            + "HZSSCCMLYXWTPZGXZJGZGSJSGKDDHTQGGZLLBJDZLCBCHYXYZHZFYWXYZYMSDBZZYJGTSMTFXQYXQSTDGSLNXDLRYZZLRYYLXQHT"
            + "XSRTZNGZXBNQQZFMYKMZJBZYMKBPNLYZPBLMCNQYZZZSJZHJCTZKHYZZJRDYZHNPXGLFZTLKGJTCTSSYLLGZRZBBQZZKLPKLCZYS"
            + "SUYXBJFPNJZZXCDWXZYJXZZDJJKGGRSRJKMSMZJLSJYWQSKYHQJSXPJZZZLSNSHRNYPZTWCHKLPSRZLZXYJQXQKYSJYCZTLQZYBB"
            + "YBWZPQDWWYZCYTJCJXCKCWDKKZXSGKDZXWWYYJQYYTCYTDLLXWKCZKKLCCLZCQQDZLQLCSFQCHQHSFSMQZZLNBJJZBSJHTSZDYSJ"
            + "QJPDLZCDCWJKJZZLPYCGMZWDJJBSJQZSYZYHHXJPBJYDSSXDZNCGLQMBTSFSBPDZDLZNFGFJGFSMPXJQLMBLGQCYYXBQKDJJQYRF"
            + "KZTJDHCZKLBSDZCFJTPLLJGXHYXZCSSZZXSTJYGKGCKGYOQXJPLZPBPGTGYJZGHZQZZLBJLSQFZGKQQJZGYCZBZQTLDXRJXBSXXP"
            + "ZXHYZYCLWDXJJHXMFDZPFZHQHQMQGKSLYHTYCGFRZGNQXCLPDLBZCSCZQLLJBLHBZCYPZZPPDYMZZSGYHCKCPZJGSLJLNSCDSLDL"
            + "XBMSTLDDFJMKDJDHZLZXLSZQPQPGJLLYBDSZGQLBZLSLKYYHZTTNTJYQTZZPSZQZTLLJTYYLLQLLQYZQLBDZLSLYYZYMDFSZSNHL"
            + "XZNCZQZPBWSKRFBSYZMTHBLGJPMCZZLSTLXSHTCSYZLZBLFEQHLXFLCJLYLJQCBZLZJHHSSTBRMHXZHJZCLXFNBGXGTQJCZTMSFZ"
            + "KJMSSNXLJKBHSJXNTNLZDNTLMSJXGZJYJCZXYJYJWRWWQNZTNFJSZPZSHZJFYRDJSFSZJZBJFZQZZHZLXFYSBZQLZSGYFTZDCSZX"
            + "ZJBQMSZKJRHYJZCKMJKHCHGTXKXQGLXPXFXTRTYLXJXHDTSJXHJZJXZWZLCQSBTXWXGXTXXHXFTSDKFJHZYJFJXRZSDLLLTQSQQZ"
            + "QWZXSYQTWGWBZCGZLLYZBCLMQQTZHZXZXLJFRMYZFLXYSQXXJKXRMQDZDMMYYBSQBHGZMWFWXGMXLZPYYTGZYCCDXYZXYWGSYJYZ"
            + "NBHPZJSQSYXSXRTFYZGRHZTXSZZTHCBFCLSYXZLZQMZLMPLMXZJXSFLBYZMYQHXJSXRXSQZZZSSLYFRCZJRCRXHHZXQYDYHXSJJH"
            + "ZCXZBTYNSYSXJBQLPXZQPYMLXZKYXLXCJLCYSXXZZLXDLLLJJYHZXGYJWKJRWYHCPSGNRZLFZWFZZNSXGXFLZSXZZZBFCSYJDBRJ"
            + "KRDHHGXJLJJTGXJXXSTJTJXLYXQFCSGSWMSBCTLQZZWLZZKXJMLTMJYHSDDBXGZHDLBMYJFRZFSGCLYJBPMLYSMSXLSZJQQHJZFX"
            + "GFQFQBPXZGYYQXGZTCQWYLTLGWSGWHRLFSFGZJMGMGBGTJFSYZZGZYZAFLSSPMLPFLCWBJZCLJJMZLPJJLYMQDMYYYFBGYGYZMLY"
            + "ZDXQYXRQQQHSYYYQXYLJTYXFSFSLLGNQCYHYCWFHCCCFXPYLYPLLZYXXXXXKQHHXSHJZCFZSCZJXCPZWHHHHHAPYLQALPQAFYHXD"
            + "YLUKMZQGGGDDESRNNZLTZGCHYPPYSQJJHCLLJTOLNJPZLJLHYMHEYDYDSQYCDDHGZUNDZCLZYZLLZNTNYZGSLHSLPJJBDGWXPCDU"
            + "TJCKLKCLWKLLCASSTKZZDNQNTTLYYZSSYSSZZRYLJQKCQDHHCRXRZYDGRGCWCGZQFFFPPJFZYNAKRGYWYQPQXXFKJTSZZXSWZDDF"
            + "BBXTBGTZKZNPZZPZXZPJSZBMQHKCYXYLDKLJNYPKYGHGDZJXXEAHPNZKZTZCMXCXMMJXNKSZQNMNLWBWWXJKYHCPSTMCSQTZJYXT"
            + "PCTPDTNNPGLLLZSJLSPBLPLQHDTNJNLYYRSZFFJFQWDPHZDWMRZCCLODAXNSSNYZRESTYJWJYJDBCFXNMWTTBYLWSTSZGYBLJPXG"
            + "LBOCLHPCBJLTMXZLJYLZXCLTPNCLCKXTPZJSWCYXSFYSZDKNTLBYJCYJLLSTGQCBXRYZXBXKLYLHZLQZLNZCXWJZLJZJNCJHXMNZ"
            + "ZGJZZXTZJXYCYYCXXJYYXJJXSSSJSTSSTTPPGQTCSXWZDCSYFPTFBFHFBBLZJCLZZDBXGCXLQPXKFZFLSYLTUWBMQJHSZBMDDBCY"
            + "SCCLDXYCDDQLYJJWMQLLCSGLJJSYFPYYCCYLTJANTJJPWYCMMGQYYSXDXQMZHSZXPFTWWZQSWQRFKJLZJQQYFBRXJHHFWJJZYQAZ"
            + "MYFRHCYYBYQWLPEXCCZSTYRLTTDMQLYKMBBGMYYJPRKZNPBSXYXBHYZDJDNGHPMFSGMWFZMFQMMBCMZZCJJLCNUXYQLMLRYGQZCY"
            + "XZLWJGCJCGGMCJNFYZZJHYCPRRCMTZQZXHFQGTJXCCJEAQCRJYHPLQLSZDJRBCQHQDYRHYLYXJSYMHZYDWLDFRYHBPYDTSSCNWBX"
            + "GLPZMLZZTQSSCPJMXXYCSJYTYCGHYCJWYRXXLFEMWJNMKLLSWTXHYYYNCMMCWJDQDJZGLLJWJRKHPZGGFLCCSCZMCBLTBHBQJXQD"
            + "SPDJZZGKGLFQYWBZYZJLTSTDHQHCTCBCHFLQMPWDSHYYTQWCNZZJTLBYMBPDYYYXSQKXWYYFLXXNCWCXYPMAELYKKJMZZZBRXYYQ"
            + "JFLJPFHHHYTZZXSGQQMHSPGDZQWBWPJHZJDYSCQWZKTXXSQLZYYMYSDZGRXCKKUJLWPYSYSCSYZLRMLQSYLJXBCXTLWDQZPCYCYK"
            + "PPPNSXFYZJJRCEMHSZMSXLXGLRWGCSTLRSXBZGBZGZTCPLUJLSLYLYMTXMTZPALZXPXJTJWTCYYZLBLXBZLQMYLXPGHDSLSSDMXM"
            + "BDZZSXWHAMLCZCPJMCNHJYSNSYGCHSKQMZZQDLLKABLWJXSFMOCDXJRRLYQZKJMYBYQLYHETFJZFRFKSRYXFJTWDSXXSYSQJYSLY"
            + "XWJHSNLXYYXHBHAWHHJZXWMYLJCSSLKYDZTXBZSYFDXGXZJKHSXXYBSSXDPYNZWRPTQZCZENYGCXQFJYKJBZMLJCMQQXUOXSLYXX"
            + "LYLLJDZBTYMHPFSTTQQWLHOKYBLZZALZXQLHZWRRQHLSTMYPYXJJXMQSJFNBXYXYJXXYQYLTHYLQYFMLKLJTMLLHSZWKZHLJMLHL"
            + "JKLJSTLQXYLMBHHLNLZXQJHXCFXXLHYHJJGBYZZKBXSCQDJQDSUJZYYHZHHMGSXCSYMXFEBCQWWRBPYYJQTYZCYQYQQZYHMWFFHG"
            + "ZFRJFCDPXNTQYZPDYKHJLFRZXPPXZDBBGZQSTLGDGYLCQMLCHHMFYWLZYXKJLYPQHSYWMQQGQZMLZJNSQXJQSYJYCBEHSXFSZPXZ"
            + "WFLLBCYYJDYTDTHWZSFJMQQYJLMQXXLLDTTKHHYBFPWTYYSQQWNQWLGWDEBZWCMYGCULKJXTMXMYJSXHYBRWFYMWFRXYQMXYSZTZ"
            + "ZTFYKMLDHQDXWYYNLCRYJBLPSXCXYWLSPRRJWXHQYPHTYDNXHHMMYWYTZCSQMTSSCCDALWZTCPQPYJLLQZYJSWXMZZMMYLMXCLMX"
            + "CZMXMZSQTZPPQQBLPGXQZHFLJJHYTJSRXWZXSCCDLXTYJDCQJXSLQYCLZXLZZXMXQRJMHRHZJBHMFLJLMLCLQNLDXZLLLPYPSYJY"
            + "SXCQQDCMQJZZXHNPNXZMEKMXHYKYQLXSXTXJYYHWDCWDZHQYYBGYBCYSCFGPSJNZDYZZJZXRZRQJJYMCANYRJTLDPPYZBSTJKXXZ"
            + "YPFDWFGZZRPYMTNGXZQBYXNBUFNQKRJQZMJEGRZGYCLKXZDSKKNSXKCLJSPJYYZLQQJYBZSSQLLLKJXTBKTYLCCDDBLSPPFYLGYD"
            + "TZJYQGGKQTTFZXBDKTYYHYBBFYTYYBCLPDYTGDHRYRNJSPTCSNYJQHKLLLZSLYDXXWBCJQSPXBPJZJCJDZFFXXBRMLAZHCSNDLBJ"
            + "DSZBLPRZTSWSBXBCLLXXLZDJZSJPYLYXXYFTFFFBHJJXGBYXJPMMMPSSJZJMTLYZJXSWXTYLEDQPJMYGQZJGDJLQJWJQLLSJGJGY"
            + "GMSCLJJXDTYGJQJQJCJZCJGDZZSXQGSJGGCXHQXSNQLZZBXHSGZXCXYLJXYXYYDFQQJHJFXDHCTXJYRXYSQTJXYEFYYSSYYJXNCY"
            + "ZXFXMSYSZXYYSCHSHXZZZGZZZGFJDLTYLNPZGYJYZYYQZPBXQBDZTZCZYXXYHHSQXSHDHGQHJHGYWSZTMZMLHYXGEBTYLZKQWYTJ"
            + "ZRCLEKYSTDBCYKQQSAYXCJXWWGSBHJYZYDHCSJKQCXSWXFLTYNYZPZCCZJQTZWJQDZZZQZLJJXLSBHPYXXPSXSHHEZTXFPTLQYZZ"
            + "XHYTXNCFZYYHXGNXMYWXTZSJPTHHGYMXMXQZXTSBCZYJYXXTYYZYPCQLMMSZMJZZLLZXGXZAAJZYXJMZXWDXZSXZDZXLEYJJZQBH"
            + "ZWZZZQTZPSXZTDSXJJJZNYAZPHXYYSRNQDTHZHYYKYJHDZXZLSWCLYBZYECWCYCRYLCXNHZYDZYDYJDFRJJHTRSQTXYXJRJHOJYN"
            + "XELXSFSFJZGHPZSXZSZDZCQZBYYKLSGSJHCZSHDGQGXYZGXCHXZJWYQWGYHKSSEQZZNDZFKWYSSTCLZSTSYMCDHJXXYWEYXCZAYD"
            + "MPXMDSXYBSQMJMZJMTZQLPJYQZCGQHXJHHLXXHLHDLDJQCLDWBSXFZZYYSCHTYTYYBHECXHYKGJPXHHYZJFXHWHBDZFYZBCAPNPG"
            + "NYDMSXHMMMMAMYNBYJTMPXYYMCTHJBZYFCGTYHWPHFTWZZEZSBZEGPFMTSKFTYCMHFLLHGPZJXZJGZJYXZSBBQSCZZLZCCSTPGXM"
            + "JSFTCCZJZDJXCYBZLFCJSYZFGSZLYBCWZZBYZDZYPSWYJZXZBDSYUXLZZBZFYGCZXBZHZFTPBGZGEJBSTGKDMFHYZZJHZLLZZGJQ"
            + "ZLSFDJSSCBZGPDLFZFZSZYZYZSYGCXSNXXCHCZXTZZLJFZGQSQYXZJQDCCZTQCDXZJYQJQCHXZTDLGSCXZSYQJQTZWLQDQZTQCHQ"
            + "QJZYEZZZPBWKDJFCJPZTYPQYQTTYNLMBDKTJZPQZQZZFPZSBNJLGYJDXJDZZKZGQKXDLPZJTCJDQBXDJQJSTCKNXBXZMSLYJCQMT"
            + "JQWWCJQNJNLLLHJCWQTBZQYDZCZPZZDZYDDCYZZZCCJTTJFZDPRRTZTJDCQTQZDTJNPLZBCLLCTZSXKJZQZPZLBZRBTJDCXFCZDB"
            + "CCJJLTQQPLDCGZDBBZJCQDCJWYNLLZYZCCDWLLXWZLXRXNTQQCZXKQLSGDFQTDDGLRLAJJTKUYMKQLLTZYTDYYCZGJWYXDXFRSKS"
            + "TQTENQMRKQZHHQKDLDAZFKYPBGGPZREBZZYKZZSPEGJXGYKQZZZSLYSYYYZWFQZYLZZLZHWCHKYPQGNPGBLPLRRJYXCCSYYHSFZF"
            + "YBZYYTGZXYLXCZWXXZJZBLFFLGSKHYJZEYJHLPLLLLCZGXDRZELRHGKLZZYHZLYQSZZJZQLJZFLNBHGWLCZCFJYSPYXZLZLXGCCP"
            + "ZBLLCYBBBBUBBCBPCRNNZCZYRBFSRLDCGQYYQXYGMQZWTZYTYJXYFWTEHZZJYWLCCNTZYJJZDEDPZDZTSYQJHDYMBJNYJZLXTSST"
            + "PHNDJXXBYXQTZQDDTJTDYYTGWSCSZQFLSHLGLBCZPHDLYZJYCKWTYTYLBNYTSDSYCCTYSZYYEBHEXHQDTWNYGYCLXTSZYSTQMYGZ"
            + "AZCCSZZDSLZCLZRQXYYELJSBYMXSXZTEMBBLLYYLLYTDQYSHYMRQWKFKBFXNXSBYCHXBWJYHTQBPBSBWDZYLKGZSKYHXQZJXHXJX"
            + "GNLJKZLYYCDXLFYFGHLJGJYBXQLYBXQPQGZTZPLNCYPXDJYQYDYMRBESJYYHKXXSTMXRCZZYWXYQYBMCLLYZHQYZWQXDBXBZWZMS"
            + "LPDMYSKFMZKLZCYQYCZLQXFZZYDQZPZYGYJYZMZXDZFYFYTTQTZHGSPCZMLCCYTZXJCYTJMKSLPZHYSNZLLYTPZCTZZCKTXDHXXT"
            + "QCYFKSMQCCYYAZHTJPCYLZLYJBJXTPNYLJYYNRXSYLMMNXJSMYBCSYSYLZYLXJJQYLDZLPQBFZZBLFNDXQKCZFYWHGQMRDSXYCYT"
            + "XNQQJZYYPFZXDYZFPRXEJDGYQBXRCNFYYQPGHYJDYZXGRHTKYLNWDZNTSMPKLBTHBPYSZBZTJZSZZJTYYXZPHSSZZBZCZPTQFZMY"
            + "FLYPYBBJQXZMXXDJMTSYSKKBJZXHJCKLPSMKYJZCXTMLJYXRZZQSLXXQPYZXMKYXXXJCLJPRMYYGADYSKQLSNDHYZKQXZYZTCGHZ"
            + "TLMLWZYBWSYCTBHJHJFCWZTXWYTKZLXQSHLYJZJXTMPLPYCGLTBZZTLZJCYJGDTCLKLPLLQPJMZPAPXYZLKKTKDZCZZBNZDYDYQZ"
            + "JYJGMCTXLTGXSZLMLHBGLKFWNWZHDXUHLFMKYSLGXDTWWFRJEJZTZHYDXYKSHWFZCQSHKTMQQHTZHYMJDJSKHXZJZBZZXYMPAGQM"
            + "STPXLSKLZYNWRTSQLSZBPSPSGZWYHTLKSSSWHZZLYYTNXJGMJSZSUFWNLSOZTXGXLSAMMLBWLDSZYLAKQCQCTMYCFJBSLXCLZZCL"
            + "XXKSBZQCLHJPSQPLSXXCKSLNHPSFQQYTXYJZLQLDXZQJZDYYDJNZPTUZDSKJFSLJHYLZSQZLBTXYDGTQFDBYAZXDZHZJNHHQBYKN"
            + "XJJQCZMLLJZKSPLDYCLBBLXKLELXJLBQYCXJXGCNLCQPLZLZYJTZLJGYZDZPLTQCSXFDMNYCXGBTJDCZNBGBQYQJWGKFHTNPYQZQ"
            + "GBKPBBYZMTJDYTBLSQMPSXTBNPDXKLEMYYCJYNZCTLDYKZZXDDXHQSHDGMZSJYCCTAYRZLPYLTLKXSLZCGGEXCLFXLKJRTLQJAQZ"
            + "NCMBYDKKCXGLCZJZXJHPTDJJMZQYKQSECQZDSHHADMLZFMMZBGNTJNNLGBYJBRBTMLBYJDZXLCJLPLDLPCQDHLXZLYCBLCXZZJAD"
            + "JLNZMMSSSMYBHBSQKBHRSXXJMXSDZNZPXLGBRHWGGFCXGMSKLLTSJYYCQLTSKYWYYHYWXBXQYWPYWYKQLSQPTNTKHQCWDQKTWPXX"
            + "HCPTHTWUMSSYHBWCRWXHJMKMZNGWTMLKFGHKJYLSYYCXWHYECLQHKQHTTQKHFZLDXQWYZYYDESBPKYRZPJFYYZJCEQDZZDLATZBB"
            + "FJLLCXDLMJSSXEGYGSJQXCWBXSSZPDYZCXDNYXPPZYDLYJCZPLTXLSXYZYRXCYYYDYLWWNZSAHJSYQYHGYWWAXTJZDAXYSRLTDPS"
            + "SYYFNEJDXYZHLXLLLZQZSJNYQYQQXYJGHZGZCYJCHZLYCDSHWSHJZYJXCLLNXZJJYYXNFXMWFPYLCYLLABWDDHWDXJMCXZTZPMLQ"
            + "ZHSFHZYNZTLLDYWLSLXHYMMYLMBWWKYXYADTXYLLDJPYBPWUXJMWMLLSAFDLLYFLBHHHBQQLTZJCQJLDJTFFKMMMBYTHYGDCQRDD"
            + "WRQJXNBYSNWZDBYYTBJHPYBYTTJXAAHGQDQTMYSTQXKBTZPKJLZRBEQQSSMJJBDJOTGTBXPGBKTLHQXJJJCTHXQDWJLWRFWQGWSH"
            + "CKRYSWGFTGYGBXSDWDWRFHWYTJJXXXJYZYSLPYYYPAYXHYDQKXSHXYXGSKQHYWFDDDPPLCJLQQEEWXKSYYKDYPLTJTHKJLTCYYHH"
            + "JTTPLTZZCDLTHQKZXQYSTEEYWYYZYXXYYSTTJKLLPZMCYHQGXYHSRMBXPLLNQYDQHXSXXWGDQBSHYLLPJJJTHYJKYPPTHYYKTYEZ"
            + "YENMDSHLCRPQFDGFXZPSFTLJXXJBSWYYSKSFLXLPPLBBBLBSFXFYZBSJSSYLPBBFFFFSSCJDSTZSXZRYYSYFFSYZYZBJTBCTSBSD"
            + "HRTJJBYTCXYJEYLXCBNEBJDSYXYKGSJZBXBYTFZWGENYHHTHZHHXFWGCSTBGXKLSXYWMTMBYXJSTZSCDYQRCYTWXZFHMYMCXLZNS"
            + "DJTTTXRYCFYJSBSDYERXJLJXBBDEYNJGHXGCKGSCYMBLXJMSZNSKGXFBNBPTHFJAAFXYXFPXMYPQDTZCXZZPXRSYWZDLYBBKTYQP"
            + "QJPZYPZJZNJPZJLZZFYSBTTSLMPTZRTDXQSJEHBZYLZDHLJSQMLHTXTJECXSLZZSPKTLZKQQYFSYGYWPCPQFHQHYTQXZKRSGTTSQ"
            + "CZLPTXCDYYZXSQZSLXLZMYCPCQBZYXHBSXLZDLTCDXTYLZJYYZPZYZLTXJSJXHLPMYTXCQRBLZSSFJZZTNJYTXMYJHLHPPLCYXQJ"
            + "QQKZZSCPZKSWALQSBLCCZJSXGWWWYGYKTJBBZTDKHXHKGTGPBKQYSLPXPJCKBMLLXDZSTBKLGGQKQLSBKKTFXRMDKBFTPZFRTBBR"
            + "FERQGXYJPZSSTLBZTPSZQZSJDHLJQLZBPMSMMSXLQQNHKNBLRDDNXXDHDDJCYYGYLXGZLXSYGMQQGKHBPMXYXLYTQWLWGCPBMQXC"
            + "YZYDRJBHTDJYHQSHTMJSBYPLWHLZFFNYPMHXXHPLTBQPFBJWQDBYGPNZTPFZJGSDDTQSHZEAWZZYLLTYYBWJKXXGHLFKXDJTMSZS"
            + "QYNZGGSWQSPHTLSSKMCLZXYSZQZXNCJDQGZDLFNYKLJCJLLZLMZZNHYDSSHTHZZLZZBBHQZWWYCRZHLYQQJBEYFXXXWHSRXWQHWP"
            + "SLMSSKZTTYGYQQWRSLALHMJTQJSMXQBJJZJXZYZKXBYQXBJXSHZTSFJLXMXZXFGHKZSZGGYLCLSARJYHSLLLMZXELGLXYDJYTLFB"
            + "HBPNLYZFBBHPTGJKWETZHKJJXZXXGLLJLSTGSHJJYQLQZFKCGNNDJSSZFDBCTWWSEQFHQJBSAQTGYPQLBXBMMYWXGSLZHGLZGQYF"
            + "LZBYFZJFRYSFMBYZHQGFWZSYFYJJPHZBYYZFFWODGRLMFTWLBZGYCQXCDJYGZYYYYTYTYDWEGAZYHXJLZYYHLRMGRXXZCLHNELJJ"
            + "TJTPWJYBJJBXJJTJTEEKHWSLJPLPSFYZPQQBDLQJJTYYQLYZKDKSQJYYQZLDQTGJQYZJSUCMRYQTHTEJMFCTYHYPKMHYZWJDQFHY"
            + "YXWSHCTXRLJHQXHCCYYYJLTKTTYTMXGTCJTZAYYOCZLYLBSZYWJYTSJYHBYSHFJLYGJXXTMZYYLTXXYPZLXYJZYZYYPNHMYMDYYL"
            + "BLHLSYYQQLLNJJYMSOYQBZGDLYXYLCQYXTSZEGXHZGLHWBLJHEYXTWQMAKBPQCGYSHHEGQCMWYYWLJYJHYYZLLJJYLHZYHMGSLJL"
            + "JXCJJYCLYCJPCPZJZJMMYLCQLNQLJQJSXYJMLSZLJQLYCMMHCFMMFPQQMFYLQMCFFQMMMMHMZNFHHJGTTHHKHSLNCHHYQDXTMMQD"
            + "CYZYXYQMYQYLTDCYYYZAZZCYMZYDLZFFFMMYCQZWZZMABTBYZTDMNZZGGDFTYPCGQYTTSSFFWFDTZQSSYSTWXJHXYTSXXYLBYQHW"
            + "WKXHZXWZNNZZJZJJQJCCCHYYXBZXZCYZTLLCQXYNJYCYYCYNZZQYYYEWYCZDCJYCCHYJLBTZYYCQWMPWPYMLGKDLDLGKQQBGYCHJ"
            + "XY";

        /// <summary>
        /// 获得一个字符串的汉语拼音码
        /// </summary>
        /// <param name="strText">字符串</param>
        /// <returns>汉语拼音码,该字符串只包含大写的英文字母</returns>
        public static string GetChineseSpell(string strText)
        {
            if (strText == null || strText.Length == 0)
                return strText;
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            int index = 0;
            foreach (char vChar in strText)
            {
                // 若是字母则直接输出
                if ((vChar >= 'a' && vChar <= 'z') || (vChar >= 'A' && vChar <= 'Z'))
                    myStr.Append(char.ToUpper(vChar));
                else
                {
                    index = (int)vChar - 19968;
                    if (index >= 0 && index < strChineseFirstPY.Length)
                        myStr.Append(strChineseFirstPY[index]);
                }
            }//foreach
            return myStr.ToString();
        }// public static string GetChineseSpell( string strText)

        /// <summary>
        /// 清除一个字符串中的空白字符
        /// </summary>
        /// <param name="strText">原始字符串</param>
        /// <param name="intMaxLength">输出结果的最长长度,为0表示无限制</param>
        /// <param name="bolHtml">是否模仿HTML对空白字符的处理</param>
        /// <returns>没有空白字符的字符串</returns>
        public static string ClearWhiteSpace(string strText, int intMaxLength, bool bolHtml)
        {
            if (strText == null)
                return null;
            else
            {
                bool bolPreIsWhiteSpace = false;
                System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                int iCount = 0;
                foreach (char vChar in strText)
                {
                    if (char.IsWhiteSpace(vChar))
                        bolPreIsWhiteSpace = true;
                    else
                    {
                        if (bolHtml && bolPreIsWhiteSpace == true)
                        {
                            myStr.Append(" ");
                        }
                        myStr.Append(vChar);
                        if (intMaxLength > 0)
                        {
                            iCount++;
                            if (iCount > intMaxLength)
                                break;
                        }

                        bolPreIsWhiteSpace = false;
                    }
                }
                return myStr.ToString();
            }
        }

        static XmlDocument testdoc = new XmlDocument();
        /// <summary>
        /// 把一个字符串转换成可以做为xmlelement节点名的形式，主要是要删除其中不合法的字符，如空格，标点符号，其它特殊字符等
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// 
        public static string GetXmlElementName(string name)
        {
            //string str = name.Replace(" ", "");
            //str = str.Replace("：", "");
            //str = str.Replace(":", "");
            //str = str.Replace("、", "");
            //Regex regex = new Regex("\\s+");
            //str = regex.Replace(str, "");

            string str = "";
            foreach (char c in name)
            {
                try
                {
                    testdoc.CreateElement(str + c);
                    str += c;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return str;
        }

        /// <summary>
        /// 根据一个BASE64的字符串加载一个图片对象
        /// </summary>
        /// <param name="strBase64">Base54字符串</param>
        /// <returns>创建的图片对象,若发生错误则返回空引用</returns>
        public static System.Drawing.Image ImageFromBase64String(string strBase64)
        {
            try
            {
                byte[] bytBuf = Convert.FromBase64String(strBase64);
                System.IO.MemoryStream myStream = new System.IO.MemoryStream(bytBuf);
                System.Drawing.Image myImg = System.Drawing.Image.FromStream(myStream);
                myStream.Close();
                return myImg;
            }
            catch
            { }
            return null;
        }

        /// <summary>
        /// 将一个图片对象按照指定的图片格式保存到一个Base64字符串
        /// </summary>
        /// <param name="myImage">图片对象</param>
        /// <param name="format">图片格式,默认为PNG格式</param>
        /// <returns>Base64字符串</returns>
        public static string ImageToBase64String(System.Drawing.Image myImage, System.Drawing.Imaging.ImageFormat format)
        {
            if (myImage == null)
                return null;
            if (format == null)
                format = System.Drawing.Imaging.ImageFormat.Png;
            System.IO.MemoryStream myStream = new System.IO.MemoryStream();
            myImage.Save(myStream, format);
            byte[] bytBuf = myStream.ToArray();
            myStream.Close();
            return Convert.ToBase64String(bytBuf);
        }


        /// <summary> 
        /// 使用 POST 方法向 某web服务器发送和接受数据的事件处理
        ///  参数strURL web服务器页面地址 ContentLength 上传或者下载的数据的长度
        ///  CompletedLength 已经上传或下载的数据的长度
        ///  Tick     操作开始的毫秒数
        ///  Status 状态 0:正在打开连接 1:正在上传数据 2:上传完毕，正在等待响应 
        ///              3:收到响应，准备下载 4:正在下载 5:下载完毕
        ///  返回值：True 继续执行操作 False 立即终止操作
        /// </summary>
        public delegate bool PostEventHandler(string strURL, long ContentLength, long CompletedLength, int Tick, int Status);

        /// <summary>
        /// 向指定URL使用POST方法发送一个字符串数据并返回保存响应结果的字符串
        /// </summary>
        /// <param name="strSend">POST发送的字符串</param>
        /// <param name="strURL">URL地址</param>
        /// <param name="vEvent">发送事件对象</param>
        /// <returns>保存相应结果的字符串,若取消操作则返回空引用</returns>
        public static string PostStringData(string strSend, string strURL, PostEventHandler vEvent)
        {
            byte[] bytSend = System.Text.Encoding.UTF8.GetBytes(strSend);
            int StartTick = System.Environment.TickCount;
            // 启动HTTP请求
            if (vEvent != null && vEvent(strURL, bytSend.Length, 0, 0, 0) == false) return null;
            System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURL);
            myReq.ContentType = "application/x-www-form-urlencoded";
            myReq.ContentLength = bytSend.Length;
            myReq.Method = "POST";
            // 发送数据
            System.IO.Stream myStream = myReq.GetRequestStream();
            int iCount = 0;
            while (true)
            {
                if (iCount + 1024 > bytSend.Length)
                {
                    myStream.Write(bytSend, iCount, bytSend.Length - iCount);
                    if (vEvent != null && vEvent(strURL, bytSend.Length, bytSend.Length, System.Environment.TickCount - StartTick, 1) == false)
                    {
                        myStream.Close();
                        myReq.Abort();
                        return null;
                    }
                    break;
                }
                else
                    myStream.Write(bytSend, iCount, 1024);
                iCount += 1024;
                if (vEvent != null && vEvent(strURL, bytSend.Length, iCount, System.Environment.TickCount - StartTick, 1) == false)
                {
                    myStream.Close();
                    myReq.Abort();
                    return null;
                }
            }
            myStream.Close();
            if (vEvent != null && vEvent(strURL, bytSend.Length, iCount, System.Environment.TickCount - StartTick, 2) == false)
            {
                myReq.Abort();
                return null;
            }
            // 接受数据
            System.Net.HttpWebResponse myRes = (System.Net.HttpWebResponse)myReq.GetResponse();
            myStream = myRes.GetResponseStream();
            if (vEvent != null && vEvent(strURL, myRes.ContentLength, 0, System.Environment.TickCount - StartTick, 3) == false)
            {
                myRes.Close();
                myReq.Abort();
                return null;
            }
            System.IO.MemoryStream myBuf = new System.IO.MemoryStream(1024);
            byte[] bytBuf = new byte[1024];
            while (true)
            {
                int iLen = myStream.Read(bytBuf, 0, 1024);
                if (iLen == 0)
                    break;
                myBuf.Write(bytBuf, 0, iLen);
                if (vEvent != null && vEvent(strURL, myRes.ContentLength, myBuf.Length, System.Environment.TickCount - StartTick, 4) == false)
                {
                    myRes.Close();
                    myReq.Abort();
                    myBuf.Close();
                    return null;
                }
            }

            myStream.Close();
            myRes.Close();
            myReq.Abort();
            // 关闭HTTP请求
            if (vEvent != null && vEvent(strURL, myRes.ContentLength, myBuf.Length, System.Environment.TickCount - StartTick, 5) == false)
            {
                return null;
            }
            // 输出结果
            byte[] bytReturn = myBuf.ToArray();
            myBuf.Close();

            char[] chrReturn = new char[System.Text.Encoding.UTF8.GetCharCount(bytReturn, 0, bytReturn.Length)];
            System.Text.Encoding.UTF8.GetChars(bytReturn, 0, bytReturn.Length, chrReturn, 0);
            string strReserve = new string(chrReturn);
            return strReserve;
        }// End of function : PostStringData

        #region 时间字符串处理的函数群 ************************************************************

        /// <summary>
        /// 获得 年年年年月月日日时时分分秒秒 格式的表示当前时间的字符串,该字符串长度为14,精确到秒
        /// </summary>
        /// <returns></returns>
        public static string GetNowString14()
        {
            return ZYTime.GetServerTime().ToString("yyyyMMddHHmmss");
            //return System.DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        /// <summary>
        /// 获得 年年年年月月日日时时分分 格式的表示当前时间的字符串,该字符串长度12,精确到分
        /// </summary>
        /// <returns></returns>
        public static string GetNowString12()
        {
            return ZYTime.GetServerTime().ToString("yyyyMMddHHmm");
            //return System.DateTime.Now.ToString("yyyyMMddHHmm");
        }

        /// <summary>
        /// 将字符串按照指定格式转换为时间数据，若没指定格式则尝试自动判别格式,若转换失败则使用默认时间
        /// </summary>
        /// <param name="strValue">表示时间数据的字符串</param>
        /// <param name="strFromFormat">指定的转换格式，可以为空</param>
        /// <param name="DefaultValue">若转换失败则使用的默认时间</param>
        /// <returns>转换后的时间数据</returns>
        public static System.DateTime ConvertToDateTime(string strValue, string strFromFormat, System.DateTime DefaultValue)
        {
            try
            {
                return ConvertToDateTime(strValue, strFromFormat);
            }
            catch
            {
                return DefaultValue;
            }
        }

        /// <summary>
        /// 将字符串按照指定格式转换为时间数据，若没指定格式则尝试自动判别格式
        /// </summary>
        /// <param name="strValue">表示时间数据的字符串</param>
        /// <param name="strFromFormat">指定的转换格式，可以为空</param>
        /// <returns>转换后的时间数据</returns>
        public static System.DateTime ConvertToDateTime(string strValue, string strFromFormat)
        {
            System.DateTime dtmValue;
            if (isBlankString(strFromFormat))
            {
                strValue = strValue.Trim();
                switch (strValue.Length)
                {
                    case 14:
                        strFromFormat = "yyyyMMddHHmmss";
                        break;
                    case 12:
                        strFromFormat = "yyyyMMddHHmm";
                        break;
                    case 10:
                        if (strValue.IndexOf("-") >= 0)
                            strFromFormat = "yyyy-MM-dd";
                        else
                            strFromFormat = "yyyyMMddHH";
                        break;
                    case 8:
                        strFromFormat = "yyyyMMdd";
                        break;
                    case 19:
                        strFromFormat = "yyyy-MM-dd HH:mm:ss";
                        break;
                    case 16:
                        strFromFormat = "yyyy-MM-dd HH:mm";
                        break;
                    case 13:
                        strFromFormat = "yyyy-MM-dd HH";
                        break;
                }
            }
            if (isBlankString(strFromFormat))
            {
                dtmValue = System.DateTime.Parse(strValue);
            }
            else
            {
                System.Globalization.DateTimeFormatInfo myFormat = new System.Globalization.DateTimeFormatInfo();
                System.IFormatProvider myF = new System.Globalization.CultureInfo("zh-CN", false);
                dtmValue = System.DateTime.ParseExact(strValue, strFromFormat, myF);
            }
            return dtmValue;
        }// System.DateTime ConvertToDateTime()

        /// <summary>
        /// 格式化时间字符串
        /// </summary>
        /// <param name="strValue">包含数据数据的字符串</param>
        /// <param name="strFromFormat">转换前的时间字符串格式</param>
        /// <param name="strToFormat">转换后的时间格式化字符串</param>
        /// <returns>转换后的时间字符串，若发生错误则返回零长度的字符串</returns>
        public static string FormatDateTime(string strValue, string strFromFormat, string strToFormat)
        {
            try
            {
                System.DateTime dtmValue = ConvertToDateTime(strValue, strFromFormat);
                return dtmValue.ToString(strToFormat);
            }
            catch
            {
                return "";
            }
        }// static string FormatDateTime()

        #endregion

        /// <summary>
        /// 根据保存在一个列表中的数据源参数修正字符串
        /// </summary>
        /// <param name="strText">供处理的原始字符串</param>
        /// <param name="strHead">标记的头字符串</param>
        /// <param name="strEnd">标记尾字符串</param>
        /// <param name="myKeys">保存所有参数的列表</param>
        /// <returns>处理后的字符串</returns>
        public static string fixVariableString(
            string strText,
            string strHead,
            string strEnd,
            System.Collections.Hashtable myKeys)
        {
            // 若原始字符串无效或者没有任何可用的参数则退出函数
            if (strText == null
                || strHead == null
                || strEnd == null
                || strHead.Length == 0
                || strEnd.Length == 0
                || strText.Length == 0
                || myKeys == null
                || myKeys.Count == 0)
                return strText;

            int index = strText.IndexOf(strHead);
            // 若原始字符串没有变量标记则退出函数
            if (index < 0)
                return strText;

            string strKey;
            int index2;
            int LastIndex = 0;
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            do
            {
                // 查找有 "[内容]" 样式的子字符串
                // 若没有找到 "[" 和 "]"的字符对则退出循环
                index2 = strText.IndexOf(strEnd, index + 1);
                if (index2 > index)
                {
                    // 若 "[" 符号后面出现 "]"符号则存在 "[]"字符对
                    // 修正查找结果以保证 "[]"字符对中不出现字符 "["
                    int index3 = index;
                    do
                    {
                        index = index3;
                        index3 = strText.IndexOf(strHead, index3 + 1);
                    } while (index3 > index && index3 < index2);

                    // 获得字符对夹着的子字符串,该子字符串为参数名
                    // 若该参数名有效则向输出结果输出参数值
                    // 否则不进行额外的处理
                    strKey = strText.Substring(index + strHead.Length, index2 - index - strHead.Length);
                    if (myKeys.ContainsKey(strKey))
                    {
                        if (LastIndex < index)
                        {
                            myStr.Append(strText.Substring(LastIndex, index - LastIndex));
                        }
                        myStr.Append(myKeys[strKey] as string);
                        index = index2 + strEnd.Length;
                        LastIndex = index;
                    }
                    else
                        index = index2 + strEnd.Length;
                }
                else
                {
                    break;
                }
            } while (index >= 0 && index < strText.Length);
            // 添加处理过后剩余的字符串
            if (LastIndex < strText.Length)
                myStr.Append(strText.Substring(LastIndex));
            return myStr.ToString();
        }// End of function : fixVariableString


        /// <summary>
        /// 判断一个字符串是否表示一个 http 的 URL 
        /// </summary>
        /// <param name="strData">字符串</param>
        /// <returns>是否是HTTP的URL</returns>
        public static bool isHttpURL(string strData)
        {
            if (strData != null)
            {
                strData = strData.Trim().ToLower();
                return strData.StartsWith("http://");
            }
            return false;
        }

        /// <summary>
        /// 将 #xxxxxx 字符串转换为一个颜色值
        /// </summary>
        /// <param name="strText">#xxxxxx 格式的字符串</param>
        /// <param name="DefaultValue">若转换失败则使用的默认值</param> 
        /// <returns>转换结果</returns>
        public static System.Drawing.Color ColorFromHtml(string strText, System.Drawing.Color DefaultValue)
        {
            if (strText != null)
            {
                strText = strText.ToUpper().Trim();
                if (strText.StartsWith("#") && strText.Length <= 7)
                {
                    int iValue = 0;
                    int Index = 0;
                    const string c_HexList = "0123456789ABCDEF";
                    for (int iCount = 1; iCount < strText.Length; iCount++)
                    {
                        Index = c_HexList.IndexOf(strText[iCount]);
                        if (Index >= 0)
                            iValue = iValue * 16 + Index;
                        else
                            return DefaultValue;
                    }
                    System.Drawing.Color myColor = System.Drawing.Color.FromArgb(iValue);
                    return System.Drawing.Color.FromArgb(255, myColor);
                }
                else
                {
                    try
                    {
                        return System.Drawing.Color.FromArgb(Convert.ToInt32(strText));
                    }
                    catch
                    {
                        return DefaultValue;
                    }
                }
            }
            return DefaultValue;
        }

        /// <summary>
        /// 将一个颜色值转换为 #XXXXXX 格式的字符串
        /// </summary>
        /// <param name="intValue">整数值</param>
        /// <returns>转换后的字符串</returns>
        public static string ColorToHtml(System.Drawing.Color myColor)
        {
            return "#" + Convert.ToInt32(myColor.ToArgb() & 0xffffff).ToString("X6");
        }

        #region 字符串表操作函数群*****************************************************************

        private static System.Collections.Specialized.NameValueCollection myStringTable = null;
        /// <summary>
        /// 加载字符串列表
        /// </summary>
        /// <param name="strURL">定义字符串列表的XML文档URL</param>
        public static void LoadStringTable(string strURL)
        {
            System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement myElement = null;
            myDoc.Load(strURL);
            myStringTable = new System.Collections.Specialized.NameValueCollection();
            foreach (System.Xml.XmlNode myNode in myDoc.DocumentElement.ChildNodes)
            {
                myElement = myNode as System.Xml.XmlElement;
                if (myElement != null)
                {
                    myStringTable.Set(myElement.GetAttribute("name"), myElement.InnerText);
                }
            }
        }
        /// <summary>
        /// 获得指定名称的字符串项目
        /// </summary>
        /// <param name="strName">字符串项目的名称</param>
        /// <returns>字符串项目的值</returns>
        public static string GetStringValue(string strName)
        {
            if (myStringTable != null)
                return myStringTable[strName];
            else
                return null;
        }

        #endregion

        /// <summary>
        /// 清除一段文本中所有的空白行
        /// </summary>
        /// <param name="strData">文本</param>
        /// <returns>处理后的文本</returns>
        public static string ClearBlankLine(string strData)
        {
            if (strData == null)
                return null;
            else
            {
                System.IO.StringReader myReader = new System.IO.StringReader(strData);
                System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                string strLine = myReader.ReadLine();
                bool bolFirst = true;
                while (strLine != null)
                {
                    foreach (System.Char myChr in strLine)
                    {
                        if (System.Char.IsWhiteSpace(myChr) == false)
                        {
                            if (!bolFirst)
                                myStr.Append("\r\n");
                            myStr.Append(strLine);
                            bolFirst = false;
                            break;
                        }
                    }
                    strLine = myReader.ReadLine();
                }
                myReader.Close();
                return myStr.ToString();
            }
        }
        /// <summary>
        /// 将HTML代码转换为纯文本
        /// </summary>
        /// <param name="strHTML">HTML代码</param>
        /// <returns>纯文本</returns>
        public static string HTMLToText(string strHTML)
        {
            if (strHTML != null)
            {
                return System.Web.HttpUtility.HtmlDecode(strHTML);
            }
            return null;
        }

        /// <summary>
        /// 将一个纯文本转换为一个XML字符串
        /// </summary>
        /// <param name="strData">纯文本</param>
        /// <returns>XML字符串</returns>
        public static string ToXMLString(string strData)
        {
            if (strData != null)
            {
                if (strData.IndexOf('\"') >= 0)
                    strData = strData.Replace("\"", "&quot;");
                if (strData.IndexOf('>') >= 0)
                    strData = strData.Replace(">", "&gt;");
                if (strData.IndexOf('<') >= 0)
                    strData = strData.Replace("<", "&lt;");
                return strData;
            }
            else
                return "";
        }

        #region 进行数据格式转换处理***************************************************************
        /// <summary>
        /// 将yyyyMMddHHmmss 格式的字符串转化为时间数据
        /// </summary>
        /// <param name="strData">原始字符串</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns>转换后的时间数据</returns>
        public static System.DateTime ToDBDateTime(string strData, System.DateTime DefaultValue)
        {
            try
            {
                if (strData == null)
                    return DefaultValue;
                else
                {
                    strData = strData.PadRight(14, '0');
                    return System.DateTime.Parse("yyyyMMddhhmmss");
                    /*
                    System.DateTime.Parse(
                    return new System.DateTime
                        (Convert.ToInt32(strData.Substring(0,4)),
                        Convert.ToInt32(strData.Substring(4,2)),
                        Convert.ToInt32(strData.Substring(6,2)) ,
                        Convert.ToInt32(strData.Substring(8,2)) ,
                        Convert.ToInt32(strData.Substring(10,2)) ,
                        Convert.ToInt32(strData.Substring(12,2)) );*/
                }
            }
            catch
            {
                return DefaultValue;
            }
        }
        /// <summary>
        /// 将一个字符串转换为整数
        /// </summary>
        /// <param name="strData">字符串</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns>转换结果</returns>
        public static int ToInt32Value(string strData, int DefaultValue)
        {
            try
            {
                if (strData == null || strData.Length == 0)
                    return DefaultValue;
                return Convert.ToInt32(strData);
                //				char[] myChars = strData.ToCharArray();
                //				int iValue = 0 ;
                //				int iCount = 0 ;
                //				bool bolNegative = false ;
                //				foreach( char myChar in myChars)
                //				{
                //					iValue = (int)myChar ;
                //					if( iValue >= 48 && iValue <= 57)
                //						iCount = iCount * 10 + iValue - 48 ;
                //					else
                //						break;
                //				}
                //				return iCount ;
            }
            catch
            {
                return DefaultValue;
            }
        }

        /// <summary>
        /// 将一个对象转换为字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns>字符串</returns>
        public static string ToStringValue(object obj, string DefaultValue)
        {
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return DefaultValue;
            }
        }

        /// <summary>
        /// 将一个字符串转换为布尔类型的值
        /// </summary>
        /// <param name="strData">待处理的字符串</param>
        /// <param name="DefaultValue">若转换失败则返回的默认值</param>
        /// <returns>转换结果</returns>
        public static bool ToBoolValue(string strData, bool DefaultValue)
        {
            try
            {
                if (strData == null)
                    return DefaultValue;
                else
                    return Convert.ToBoolean(strData);
            }
            catch
            {
                return DefaultValue;
            }
        }
        #endregion

        /// <summary>
        /// 找到指定字符串中一组字符出现的第一个序号
        /// </summary>
        /// <param name="strData">字符串</param>
        /// <param name="strFind">所有需要查找的字符组成的字符串</param>
        /// <returns>第一次出现字符的序号,若未找到则返回-1</returns>
        public static int IndexofEx(string strData, string strFind)
        {
            int Result = -1;
            int Index = 0;
            if (strData != null && strFind != null)
            {
                for (int iCount = 0; iCount < strFind.Length; iCount++)
                {
                    Index = strData.IndexOf(strFind[iCount]);
                    if (Index < Result || Result == -1)
                        Result = Index;
                }
            }
            return Result;
        }

        /// <summary>
        /// 找到第一次出现空白字符的位置
        /// </summary>
        /// <param name="strData">字符串</param>
        /// <returns>第一次出现空白字符的位置,若未找到则返回字符的长度</returns>
        public static int IndexofWiteSpace(string strData)
        {
            for (int iCount = 0; iCount < strData.Length; iCount++)
            {
                if (Char.IsWhiteSpace(strData, iCount))
                    return iCount;
            }
            return strData.Length;
        }

        /// <summary>
        /// 找到第一次出现空白字符的位置
        /// </summary>
        /// <param name="strData">字符串</param>
        /// <param name="StartIndex">开始查找的起始位置</param>
        /// <returns>第一次出现空白字符的位置,若未找到则返回字符的长度</returns>
        public static int IndexofWiteSpace(string strData, int StartIndex)
        {
            if (StartIndex < 0 || StartIndex >= strData.Length)
                StartIndex = 0;
            for (int iCount = StartIndex; iCount < strData.Length; iCount++)
            {
                if (Char.IsWhiteSpace(strData, iCount))
                    return iCount;
            }
            return strData.Length;
        }

        /// <summary>
        /// 判断一个字符串是否全部由数字字符组成
        /// </summary>
        /// <param name="strData">要测试的字符串</param>
        /// <returns>若全部由数字字符组成则返回true 否则返回false ，字符串对象为空时也返回false</returns>
        public static bool isInteger(string strData)
        {
            if (strData != null)
            {
                foreach (char myChar in strData)
                    if (Char.IsNumber(myChar) == false)
                        return false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断一个字符串对象是否是空字符串
        /// </summary>
        /// <param name="strData">字符串</param>
        /// <returns>若字符串为空或者全部有空白字符组成则返回True,否则返回false</returns>
        public static bool isBlankString(string strData)
        {
            if (strData == null)
                return true;
            else
            {
                for (int iCount = 0; iCount < strData.Length; iCount++)
                {
                    if (Char.IsWhiteSpace(strData[iCount]) == false)
                        return false;
                }
                return true;
            }
        }//public static bool isBlankString()

        /// <summary>
        /// 判断一个字符串是否有内容,本函数和isBlankString相反
        /// </summary>
        /// <param name="strData">字符串对象</param>
        /// <returns>若字符串不为空且存在非空白字符则返回True 否则返回False</returns>
        public static bool HasContent(string strData)
        {
            if (strData != null && strData.Length > 0)
            {
                foreach (char c in strData)
                {
                    if (Char.IsWhiteSpace(c) == false)
                        return true;
                }
            }
            return false;
        }// bool HasContent()

        /// <summary>
        /// 在XML字符串外面加上XSLT文档框架
        /// </summary>
        /// <param name="strXML">XML字符串</param>
        /// <returns>输出的XSLT字符串</returns>
        public static string TransToXSLFrame(string strXML)
        {
            return "<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" version=\"1.0\"><xsl:template match=\"/*\">" + strXML + "</xsl:template></xsl:stylesheet>";
        }


        /// <summary>
        /// 测试一个字符串中所有的字符都是字母或者数字
        /// </summary>
        /// <param name="strData">供测试的字符串</param>
        /// <returns>若字符串所有字符都是字母或数字则返回true ,否则返回 false</returns>
        public static bool IsLetterOrDigit(string strData)
        {
            if (strData != null)
            {
                for (int iCount = 0; iCount < strData.Length; iCount++)
                {
                    if (System.Char.IsLetterOrDigit(strData, iCount) == false)
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 是否是英文字母或数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsABC123(char c)
        {
            return c_ABC123CharList.IndexOf(c) >= 0 ? true : false;
        }
        /// <summary>
        /// 判断一个字符串是否全部是由数字字符组成
        /// </summary>
        /// <param name="strData">共测试的字符串</param>
        /// <returns>若字符串中所有字符未数字则返回true,否则返回false</returns>
        public static bool IsInteger(string strData)
        {
            if (strData != null)
            {
                foreach (char myChar in strData)
                    if (System.Char.IsNumber(myChar) == false)
                        return false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据指定字符串计算MD5数值的16进制字符串
        /// </summary>
        /// <param name="strData">字符串数据</param>
        /// <returns>大写的MD5的16进制字符串</returns>
        public static string GetMD5String(string strData)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider myMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytBuf = System.Text.Encoding.Unicode.GetBytes(strData);
            byte[] md5 = myMD5.ComputeHash(bytBuf, 0, bytBuf.Length);
            return ByteToHex(md5);
        }

        #region 对字符串进行16进制或Base64的编码解码处理*******************************************
        /// <summary>
        /// 将一个字节数值转换为一个16进制字符串
        /// </summary>
        /// <param name="bytBuf">字节数组</param>
        /// <returns>16进制字符串</returns>
        public static string ByteToHex(byte[] bytBuf)
        {
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            for (int iCount = 0; iCount < bytBuf.Length; iCount++)
            {
                myStr.Append(bytBuf[iCount].ToString("X2"));
            }
            return myStr.ToString();
        }

        /// <summary>
        /// 将字符串转换为GB2312编码后的16进制字符串
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static string ToHexString(string strData)
        {
            if (strData != null)
            {
                byte[] bytData = System.Text.Encoding.GetEncoding(936).GetBytes(strData);
                return ByteToHex(bytData);
            }
            else
                return null;
        }
        public static string FromHexString(string strData)
        {
            if (strData != null)
            {
                System.Text.Decoder myDec = System.Text.Encoding.GetEncoding(936).GetDecoder();
                byte[] bytData = HexToByte(strData);
                char[] myChars = new char[myDec.GetCharCount(bytData, 0, bytData.Length)];
                myDec.GetChars(bytData, 0, bytData.Length, myChars, 0);
                return new string(myChars);
            }
            else
                return null;
        }
        public static byte[] HexToByte(string strData)
        {
            if (strData != null)
            {
                int iSize = strData.Length;
                byte[] bytData = new byte[iSize];
                int iByte;
                int iByteCount = 0;
                int iCharCount = 0;
                int iCount = 0;
                System.Text.Encoding.ASCII.GetBytes(strData.ToUpper(), 0, strData.Length, bytData, 0);
                for (iCount = 0; iCount < iSize; iCount++)
                {
                    iByte = bytData[iCount];
                    if ((bytData[iCount] >= 48 && bytData[iCount] <= 57) || (bytData[iCount] >= 65 && bytData[iCount] <= 70))
                    {
                        if (bytData[iCount] <= 57)
                            iByte = bytData[iCount] - 48;
                        else
                            iByte = bytData[iCount] - 65 + 10;
                        iCharCount++;
                        if ((iCharCount % 2) == 0 && iCharCount > 0)
                        {
                            bytData[iByteCount] = Convert.ToByte(bytData[iByteCount] * 16 + iByte);
                            iByteCount++;
                        }
                        else
                            bytData[iByteCount] = Convert.ToByte(iByte);
                    }
                }
                byte[] bytOut = new byte[iByteCount];
                for (iCount = 0; iCount < iByteCount; iCount++)
                    bytOut[iCount] = bytData[iCount];
                return bytOut;
            }
            else
                return null;
        }

        public static string ToBase64String(string strData)
        {
            if (strData == null)
                return null;
            else
                return Convert.ToBase64String(System.Text.Encoding.GetEncoding(936).GetBytes(strData));
        }
        public static string FromBase64String(string strData)
        {
            if (strData == null)
                return null;
            else
            {
                byte[] bytData = Convert.FromBase64String(strData);
                char[] chrData = System.Text.Encoding.GetEncoding(936).GetChars(bytData);
                return new string(chrData);
            }
        }

        /// <summary>
        /// 判断一个字符的编码是否是属于Base64字符
        /// </summary>
        /// <param name="intChar">字符的Ansi或Unicode编码</param>
        /// <returns>判断结果</returns>
        public static bool isBase64Ascii(int intChar)
        {
            return ((intChar >= 65 && intChar <= 90)
                || (intChar >= 97 && intChar <= 122)
                || (intChar >= 48 && intChar <= 57)
                || intChar == 43
                || intChar == 47
                || intChar == 61);
        }

        /// <summary>
        /// 格式化Base64编码字符串，进行分隔处理
        /// </summary>
        /// <param name="strBase64">纯的Base64编码字符串</param>
        /// <param name="GroupSize">一组编码的字符个数</param>
        /// <param name="LineGroupCount">每行文本的编码组个数</param>
        /// <returns>格式化后的字符串</returns>
        public static string FormatBase64String(string strBase64, int GroupSize, int LineGroupCount)
        {
            if (strBase64 == null || strBase64.Length == 0 || (GroupSize <= 0 && LineGroupCount <= 0))
                return strBase64;

            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            int iSize = strBase64.Length;
            int iCount = 0;
            LineGroupCount *= GroupSize;
            while (true)
            {
                myStr.Append(" ");
                if (iCount + GroupSize < iSize)
                {
                    myStr.Append(strBase64.Substring(iCount, GroupSize));
                }
                else
                {
                    myStr.Append(strBase64.Substring(iCount));
                    break;
                }
                iCount += GroupSize;
                if (iCount % LineGroupCount == 0)
                    myStr.Append("\r\n");
            }
            return myStr.ToString();
        }


        #endregion

        #region 置换加密字符串的函数群*************************************************************
        /// <summary>
        /// 判断一个字符串是否经过置换加密
        /// </summary>
        /// <param name="strData">原始字符串</param>
        /// <returns>是否经过置换加密</returns>
        public static bool isExchangeEncrypt(string strData)
        {
            const string c_Pre = "HTEEV1.0";
            if (strData != null)
            {
                if (strData.StartsWith(c_Pre) && strData.EndsWith(c_Pre))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 通过有规律的置换字符来打乱字符原有的序列来加密字符串
        /// </summary>
        /// <param name="strSource">原始字符串</param>
        /// <param name="toEncrypt">是否进行加密，True:加密字符串 False:解密字符串</param>
        /// <param name="bolHead">是否处理加密的标记头</param>
        /// <returns>处理过的字符串</returns>
        public static string ExchangeEncrypt(string strSource, bool toEncrypt, bool bolHead)
        {
            System.Char[] myChar;
            string strOut;
            int iLength;
            const string c_Pre = "HTEEV1.0";
            if (StringCommon.isBlankString(strSource))
                return null;
            if (toEncrypt)
            {
                iLength = (int)System.Math.Ceiling((double)strSource.Length / 2);
                myChar = strSource.ToCharArray();
                ExchangeChar(myChar, 2, iLength, true);
                ExchangeChar(myChar, 3, iLength, true);
                ExchangeChar(myChar, 7, 3, true);
                ExchangeChar(myChar, 3, 33, true);
                strOut = new string(myChar);
                if (bolHead)
                    return c_Pre + strOut + c_Pre;
                else
                    return strOut;
            }
            else
            {
                if (bolHead)
                {
                    strSource = strSource.Trim();
                    if (strSource.StartsWith(c_Pre) && strSource.EndsWith(c_Pre))
                        strSource = strSource.Substring(c_Pre.Length, strSource.Length - c_Pre.Length * 2);
                    else
                        return null;
                }
                iLength = (int)System.Math.Ceiling((double)strSource.Length / 2);
                myChar = strSource.ToCharArray();
                ExchangeChar(myChar, 3, 33, false);
                ExchangeChar(myChar, 7, 3, false);
                ExchangeChar(myChar, 3, iLength, false);
                ExchangeChar(myChar, 2, iLength, false);
                strOut = new string(myChar);
                return strOut;
            }
        }

        /// <summary>
        /// 通过置换字符的方式加密字符数组
        /// 将原始字符数组中的字符有规律的打乱来加密字符串
        /// </summary>
        /// <param name="myChar">字符数组</param>
        /// <param name="iStep">置换的字符序号的步长</param>
        /// <param name="iStep2">置换的字符序号</param>
        /// <param name="bolDirect">处理方向</param>
        public static void ExchangeChar(System.Char[] myChar, int iStep, int iStep2, bool bolDirect)
        {
            int iCount;
            System.Char chrTemp;
            int iLength;
            int index;
            //int iHCount ;
            if (iStep == 0) return;
            iLength = myChar.Length;
            if (bolDirect)
            {
                for (iCount = 0; iCount < iLength; iCount += iStep)
                {
                    index = (iCount + iStep2) % iLength;
                    chrTemp = myChar[iCount];
                    myChar[iCount] = myChar[index];
                    myChar[index] = chrTemp;
                }
            }
            else
            {
                index = (iLength - 1) - ((iLength - 1) % iStep);
                iStep = 0 - iStep;
                for (iCount = index; iCount >= 0; iCount += iStep)
                {
                    index = (iCount + iStep2) % iLength;
                    chrTemp = myChar[iCount];
                    myChar[iCount] = myChar[index];
                    myChar[index] = chrTemp;
                }
            }
        }
        #endregion




    }// class StringCommon
}