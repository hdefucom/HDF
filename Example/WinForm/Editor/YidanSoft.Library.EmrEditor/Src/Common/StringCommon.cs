using System;
using System.Security.Cryptography;
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Xml;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
    /// <summary>
    /// ͨ�õ��ַ�������̬����
    /// </summary>
    public class StringCommon
    {

        public const string c_HexCharList = "0123456789ABCDEF";
        public const string c_Base64CharList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        public const string c_ABC123CharList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.";

        public const string StartPunctuaction = "!),.:;?]}���������D���������á����������������������������������������ݣ��������";
        public const string EndPunctuaction = "([{�������������������������ۣ��꣤";

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
                    //���������ݼ��   add by ywk  2012��11��27��16:53:13
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

                //���������ݼ��   add by ywk  2012��11��27��16:53:13
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
            if (vSymbol == '.' || vSymbol == '��')
                return 5;
            if (vSymbol == ';' || vSymbol == '��')
                return 4;
            if (vSymbol == ',' || vSymbol == '��')
                return 3;
            if (vSymbol == '��')
                return 2;
            if (char.IsWhiteSpace(vSymbol))
                return 1;
            return 0;
        }

        /// <summary>
        /// ʹ��GB2312�����ʽ��ȡһ���ı��ļ�������
        /// </summary>
        /// <param name="strFile">�ļ���</param>
        /// <returns>��ȡ���ļ����ݣ����ļ������ڻ��������򷵻ؿ�����</returns>
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
        /// ��ÿ�������Ϊ�ؼ���ݼ��ַ��б�
        /// </summary>
        /// <param name="strExcept">�ų�����ĸ��ɵ��ַ���</param>
        /// <returns>�ɹ���Ϊ����ַ���ɵ��ַ���</returns>
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
        /// ɾ��XML�ַ�����	XML����ͷ
        /// </summary>
        /// <param name="strXML">XML�ַ���</param>
        /// <returns>ȥ��XML����ͷ��XML�ַ���</returns>
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
        /// ����һ����������
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
        /// ����һ���ָ��ַ����һ���ַ���
        /// </summary>
        /// <param name="strText">Ҫ��ֵ��ַ���</param>
        /// <param name="Spliter">�ָ��ַ�</param>
        /// <returns>����Ԫ�ص��ַ�������,�ֱ���ԭʼ�ַ����зָ��ַ�ǰ��Ĳ��ֺͺ���Ĳ���,����������ȷ�򷵻ؿ�����
        /// ��û�ҵ��ָ��ַ����һ��Ԫ��Ϊԭʼ�ַ���,�ڶ���Ϊ�����ݵ��ַ���</returns>
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
        /// ����һ���ָ��ַ������һ���ַ���
        /// </summary>
        /// <param name="strText">Ҫ��ֵ��ַ���</param>
        /// <param name="strSpliter">�ָ��ַ���</param>
        /// <returns>����Ԫ�ص��ַ�������,�ֱ���ԭʼ�ַ����зָ��ַ���ǰ��Ĳ��ֺͺ���Ĳ���,����������ȷ�򷵻ؿ�����
        /// ��û�ҵ��ָ��ַ������һ��Ԫ��Ϊԭʼ�ַ���,�ڶ���Ϊ�����ݵ��ַ���</returns>
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
        /// ���������ַ���,���ַ���Ϊ����ֵ=ֵ��
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="strLastParamName"></param>
        /// <param name="AllowSameName">�Ƿ���������</param>
        /// <returns></returns>
        public static string[] AnalyseSingleLineParams(string strList, string strLastParamName, bool AllowSameName)
        {
            // �жϲ�������ȷ��
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
                    // ��õ�����Ŀ
                    strItem = strList.Substring(index1, index2 - index1);
                    // �������Ŀ������Ŀֵ
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
                    // ע���µ���Ŀ
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
            // ������
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
        /// ����������Ϊһ�������ַ�����ÿһ���ַ�����һ�����ƺ�һ��ֵ��ɣ����ƺ�ֵ���õȺŷֿ���������
        /// ���Ƿ�������ַ����������ƺ�ֵ�������һ���ַ����������飬������Ԫ�ظ���Ϊż����
        /// </summary>
        /// <param name="strText">���������ַ���</param>
        /// <returns>���ɵ��ַ������飬����Ԫ�ظ���Ϊż�����Ҵ���0����������û�������򷵻ؿն���</returns>
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
        /// ����һ�������б����ݵ��ַ��������������������һ������-ֵ������
        /// ���ַ�����ʽΪ ��Ŀ�� ֵ�ָ��ַ� ��Ŀֵ ��Ŀ�ָ��ַ� ��Ŀ�� ֵ�ָ��ַ� ��Ŀֵ ...
        /// ���� ��ֵ�ָ��ַ�Ϊ �� ��Ŀ�ָ��ַ�Ϊ = ��������ַ�����ʽΪ a=1;b=2;c=33
        /// �򱾺���������һ������-ֵ���϶���,���е�����Ϊ {(a,1),(b,2),(c,33)}
        /// </summary>
        /// <param name="strList">�����б����ݵ��ַ���</param>
        /// <param name="ItemSplit">��Ŀ�ָ��ַ���</param>
        /// <param name="ValueSplit">ֵ�ָ��ַ���</param>
        /// <param name="AllowSameName">��������Ŀ�Ƿ���������</param>
        /// <returns>���ص����α�����Ŀ���ƺ���Ŀֵ�ļ��϶���,��������ȷ�򷵻ؿ�����</returns>
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
        /// ����һ�������б����ݵ��ַ��������������������һ���ַ���������
        /// ���ַ�����ʽΪ ��Ŀ�� ֵ�ָ��ַ� ��Ŀֵ ��Ŀ�ָ��ַ� ��Ŀ�� ֵ�ָ��ַ� ��Ŀֵ ...
        /// ���� ��ֵ�ָ��ַ�Ϊ �� ��Ŀ�ָ��ַ�Ϊ = ��������ַ�����ʽΪ a=1;b=2;c=33
        /// �򱾺���������һ���ַ������� {a,1,b,2,c,33}������Ԫ��Ϊż����
        /// </summary>
        /// <param name="strList">�����б����ݵ��ַ���</param>
        /// <param name="ItemSplit">��Ŀ�ָ��ַ���</param>
        /// <param name="ValueSplit">ֵ�ָ��ַ���</param>
        /// <param name="AllowSameName">��������Ŀ�Ƿ���������</param>
        /// <returns>���ص����α�����Ŀ���ƺ���Ŀֵ���ַ�����Ԫ�ظ�����Ϊż����,��������ȷ�򷵻ؿ�����</returns>
        public static string[] AnalyseStringList(string strList, char ItemSplit, char ValueSplit, bool AllowSameName)
        {
            // �жϲ�������ȷ��
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
                    // ��õ�����Ŀ
                    strItem = strList.Substring(index1, index2 - index1);
                    // �������Ŀ������Ŀֵ
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
                    // ע���µ���Ŀ
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
            // ������
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
        /// �ڲ�ʹ�õ����ƺ�ֵ����Ŀ��
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
        //		/// �Ƚ�������ϣ�б��е������Ƿ���ȫһ��
        //		/// ��һ���б�Ϊ������Ϊ��ͬ
        //		/// </summary>
        //		/// <param name="t1">��һ����ϣ�б�</param>
        //		/// <param name="t2">�ڶ�����ϣ�б�</param>
        //		/// <returns>�ȽϽ��</returns>
        //		public static bool EqualHashTable( System.Collections.Hashtable t1 , System.Collections.Hashtable t2)
        //		{
        //			// ��������ϣ�б�����һ��Ϊ�ջ������б���������һ�����ж�ͨ��
        //			if( t1 == null || t2 == null || t1 == t2 )
        //				return true;
        //
        //			// �������б���Ŀ������һ����Ƚ�ʧ��
        //			if( t1.Count != t2.Count) 
        //				return false;
        //
        //			// ������һ���б������е���Ŀ,�鿴�ڵڶ����б��Ƿ������Ӧ����Ŀ��ֵһ��
        //			for(int iCount = 0 ; iCount < t1.Count ; iCount ++ )
        //			{
        //				object objKey = t1.Keys[iCount]; // ��õ�ǰ��ֵ
        //				if( t2.ContainsKey(objKey))
        //				{
        //					if( t1[objKey] != null )
        //					{
        //						// ����һ���б��е�ǰֵ�͵ڶ����б�����Ӧ��ֵ�Ƚϲ�ͨ����Ƚ�ʧ��
        //						if( t1[objKey].Equals( t2[objKey] ) == false )
        //							return false;
        //					}
        //					else
        //					{
        //						// ����һ���б�ǰֵΪ�ն��ڶ����б����Ӧ��ֵ��Ϊ����Ƚ�ʧ��
        //						if( t2[objKey] != null) 
        //							return false;
        //					}
        //				}
        //				else
        //					// ��ǰ��ֵ�ڵڶ����б��в��������жϲ�ͨ��,��������
        //					return false;
        //			}
        //			// ���е���Ŀ�ж�ͨ��,��ȷ�������б�������ȫһ��,���سɹ�
        //			return true;
        //		}// End of function : EqualHashTable 


        /// <summary>
        /// ����ƴ������ĸ�б� ���б������20902������,������� GetChineseSpell ����ʹ��,������¼���ַ���Unicode���뷶ΧΪ19968��40869
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
        /// ���һ���ַ����ĺ���ƴ����
        /// </summary>
        /// <param name="strText">�ַ���</param>
        /// <returns>����ƴ����,���ַ���ֻ������д��Ӣ����ĸ</returns>
        public static string GetChineseSpell(string strText)
        {
            if (strText == null || strText.Length == 0)
                return strText;
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            int index = 0;
            foreach (char vChar in strText)
            {
                // ������ĸ��ֱ�����
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
        /// ���һ���ַ����еĿհ��ַ�
        /// </summary>
        /// <param name="strText">ԭʼ�ַ���</param>
        /// <param name="intMaxLength">�������������,Ϊ0��ʾ������</param>
        /// <param name="bolHtml">�Ƿ�ģ��HTML�Կհ��ַ��Ĵ���</param>
        /// <returns>û�пհ��ַ����ַ���</returns>
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
        /// ��һ���ַ���ת���ɿ�����Ϊxmlelement�ڵ�������ʽ����Ҫ��Ҫɾ�����в��Ϸ����ַ�����ո񣬱����ţ����������ַ���
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// 
        public static string GetXmlElementName(string name)
        {
            //string str = name.Replace(" ", "");
            //str = str.Replace("��", "");
            //str = str.Replace(":", "");
            //str = str.Replace("��", "");
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
        /// ����һ��BASE64���ַ�������һ��ͼƬ����
        /// </summary>
        /// <param name="strBase64">Base54�ַ���</param>
        /// <returns>������ͼƬ����,�����������򷵻ؿ�����</returns>
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
        /// ��һ��ͼƬ������ָ����ͼƬ��ʽ���浽һ��Base64�ַ���
        /// </summary>
        /// <param name="myImage">ͼƬ����</param>
        /// <param name="format">ͼƬ��ʽ,Ĭ��ΪPNG��ʽ</param>
        /// <returns>Base64�ַ���</returns>
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
        /// ʹ�� POST ������ ĳweb���������ͺͽ������ݵ��¼�����
        ///  ������strURL web������ҳ���ַ ContentLength �ϴ��������ص����ݵĳ���
        ///  CompletedLength �Ѿ��ϴ������ص����ݵĳ���
        ///  Tick     ������ʼ�ĺ�����
        ///  Status ״̬ 0:���ڴ����� 1:�����ϴ����� 2:�ϴ���ϣ����ڵȴ���Ӧ 
        ///              3:�յ���Ӧ��׼������ 4:�������� 5:�������
        ///  ����ֵ��True ����ִ�в��� False ������ֹ����
        /// </summary>
        public delegate bool PostEventHandler(string strURL, long ContentLength, long CompletedLength, int Tick, int Status);

        /// <summary>
        /// ��ָ��URLʹ��POST��������һ���ַ������ݲ����ر�����Ӧ������ַ���
        /// </summary>
        /// <param name="strSend">POST���͵��ַ���</param>
        /// <param name="strURL">URL��ַ</param>
        /// <param name="vEvent">�����¼�����</param>
        /// <returns>������Ӧ������ַ���,��ȡ�������򷵻ؿ�����</returns>
        public static string PostStringData(string strSend, string strURL, PostEventHandler vEvent)
        {
            byte[] bytSend = System.Text.Encoding.UTF8.GetBytes(strSend);
            int StartTick = System.Environment.TickCount;
            // ����HTTP����
            if (vEvent != null && vEvent(strURL, bytSend.Length, 0, 0, 0) == false) return null;
            System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURL);
            myReq.ContentType = "application/x-www-form-urlencoded";
            myReq.ContentLength = bytSend.Length;
            myReq.Method = "POST";
            // ��������
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
            // ��������
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
            // �ر�HTTP����
            if (vEvent != null && vEvent(strURL, myRes.ContentLength, myBuf.Length, System.Environment.TickCount - StartTick, 5) == false)
            {
                return null;
            }
            // ������
            byte[] bytReturn = myBuf.ToArray();
            myBuf.Close();

            char[] chrReturn = new char[System.Text.Encoding.UTF8.GetCharCount(bytReturn, 0, bytReturn.Length)];
            System.Text.Encoding.UTF8.GetChars(bytReturn, 0, bytReturn.Length, chrReturn, 0);
            string strReserve = new string(chrReturn);
            return strReserve;
        }// End of function : PostStringData

        #region ʱ���ַ�������ĺ���Ⱥ ************************************************************

        /// <summary>
        /// ��� ����������������ʱʱ�ַ����� ��ʽ�ı�ʾ��ǰʱ����ַ���,���ַ�������Ϊ14,��ȷ����
        /// </summary>
        /// <returns></returns>
        public static string GetNowString14()
        {
            return ZYTime.GetServerTime().ToString("yyyyMMddHHmmss");
            //return System.DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        /// <summary>
        /// ��� ����������������ʱʱ�ַ� ��ʽ�ı�ʾ��ǰʱ����ַ���,���ַ�������12,��ȷ����
        /// </summary>
        /// <returns></returns>
        public static string GetNowString12()
        {
            return ZYTime.GetServerTime().ToString("yyyyMMddHHmm");
            //return System.DateTime.Now.ToString("yyyyMMddHHmm");
        }

        /// <summary>
        /// ���ַ�������ָ����ʽת��Ϊʱ�����ݣ���ûָ����ʽ�����Զ��б��ʽ,��ת��ʧ����ʹ��Ĭ��ʱ��
        /// </summary>
        /// <param name="strValue">��ʾʱ�����ݵ��ַ���</param>
        /// <param name="strFromFormat">ָ����ת����ʽ������Ϊ��</param>
        /// <param name="DefaultValue">��ת��ʧ����ʹ�õ�Ĭ��ʱ��</param>
        /// <returns>ת�����ʱ������</returns>
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
        /// ���ַ�������ָ����ʽת��Ϊʱ�����ݣ���ûָ����ʽ�����Զ��б��ʽ
        /// </summary>
        /// <param name="strValue">��ʾʱ�����ݵ��ַ���</param>
        /// <param name="strFromFormat">ָ����ת����ʽ������Ϊ��</param>
        /// <returns>ת�����ʱ������</returns>
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
        /// ��ʽ��ʱ���ַ���
        /// </summary>
        /// <param name="strValue">�����������ݵ��ַ���</param>
        /// <param name="strFromFormat">ת��ǰ��ʱ���ַ�����ʽ</param>
        /// <param name="strToFormat">ת�����ʱ���ʽ���ַ���</param>
        /// <returns>ת�����ʱ���ַ����������������򷵻��㳤�ȵ��ַ���</returns>
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
        /// ���ݱ�����һ���б��е�����Դ���������ַ���
        /// </summary>
        /// <param name="strText">�������ԭʼ�ַ���</param>
        /// <param name="strHead">��ǵ�ͷ�ַ���</param>
        /// <param name="strEnd">���β�ַ���</param>
        /// <param name="myKeys">�������в������б�</param>
        /// <returns>�������ַ���</returns>
        public static string fixVariableString(
            string strText,
            string strHead,
            string strEnd,
            System.Collections.Hashtable myKeys)
        {
            // ��ԭʼ�ַ�����Ч����û���κο��õĲ������˳�����
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
            // ��ԭʼ�ַ���û�б���������˳�����
            if (index < 0)
                return strText;

            string strKey;
            int index2;
            int LastIndex = 0;
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            do
            {
                // ������ "[����]" ��ʽ�����ַ���
                // ��û���ҵ� "[" �� "]"���ַ������˳�ѭ��
                index2 = strText.IndexOf(strEnd, index + 1);
                if (index2 > index)
                {
                    // �� "[" ���ź������ "]"��������� "[]"�ַ���
                    // �������ҽ���Ա�֤ "[]"�ַ����в������ַ� "["
                    int index3 = index;
                    do
                    {
                        index = index3;
                        index3 = strText.IndexOf(strHead, index3 + 1);
                    } while (index3 > index && index3 < index2);

                    // ����ַ��Լ��ŵ����ַ���,�����ַ���Ϊ������
                    // ���ò�������Ч�����������������ֵ
                    // ���򲻽��ж���Ĵ���
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
            // ��Ӵ������ʣ����ַ���
            if (LastIndex < strText.Length)
                myStr.Append(strText.Substring(LastIndex));
            return myStr.ToString();
        }// End of function : fixVariableString


        /// <summary>
        /// �ж�һ���ַ����Ƿ��ʾһ�� http �� URL 
        /// </summary>
        /// <param name="strData">�ַ���</param>
        /// <returns>�Ƿ���HTTP��URL</returns>
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
        /// �� #xxxxxx �ַ���ת��Ϊһ����ɫֵ
        /// </summary>
        /// <param name="strText">#xxxxxx ��ʽ���ַ���</param>
        /// <param name="DefaultValue">��ת��ʧ����ʹ�õ�Ĭ��ֵ</param> 
        /// <returns>ת�����</returns>
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
        /// ��һ����ɫֵת��Ϊ #XXXXXX ��ʽ���ַ���
        /// </summary>
        /// <param name="intValue">����ֵ</param>
        /// <returns>ת������ַ���</returns>
        public static string ColorToHtml(System.Drawing.Color myColor)
        {
            return "#" + Convert.ToInt32(myColor.ToArgb() & 0xffffff).ToString("X6");
        }

        #region �ַ������������Ⱥ*****************************************************************

        private static System.Collections.Specialized.NameValueCollection myStringTable = null;
        /// <summary>
        /// �����ַ����б�
        /// </summary>
        /// <param name="strURL">�����ַ����б��XML�ĵ�URL</param>
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
        /// ���ָ�����Ƶ��ַ�����Ŀ
        /// </summary>
        /// <param name="strName">�ַ�����Ŀ������</param>
        /// <returns>�ַ�����Ŀ��ֵ</returns>
        public static string GetStringValue(string strName)
        {
            if (myStringTable != null)
                return myStringTable[strName];
            else
                return null;
        }

        #endregion

        /// <summary>
        /// ���һ���ı������еĿհ���
        /// </summary>
        /// <param name="strData">�ı�</param>
        /// <returns>�������ı�</returns>
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
        /// ��HTML����ת��Ϊ���ı�
        /// </summary>
        /// <param name="strHTML">HTML����</param>
        /// <returns>���ı�</returns>
        public static string HTMLToText(string strHTML)
        {
            if (strHTML != null)
            {
                return System.Web.HttpUtility.HtmlDecode(strHTML);
            }
            return null;
        }

        /// <summary>
        /// ��һ�����ı�ת��Ϊһ��XML�ַ���
        /// </summary>
        /// <param name="strData">���ı�</param>
        /// <returns>XML�ַ���</returns>
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

        #region �������ݸ�ʽת������***************************************************************
        /// <summary>
        /// ��yyyyMMddHHmmss ��ʽ���ַ���ת��Ϊʱ������
        /// </summary>
        /// <param name="strData">ԭʼ�ַ���</param>
        /// <param name="DefaultValue">Ĭ��ֵ</param>
        /// <returns>ת�����ʱ������</returns>
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
        /// ��һ���ַ���ת��Ϊ����
        /// </summary>
        /// <param name="strData">�ַ���</param>
        /// <param name="DefaultValue">Ĭ��ֵ</param>
        /// <returns>ת�����</returns>
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
        /// ��һ������ת��Ϊ�ַ���
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="DefaultValue">Ĭ��ֵ</param>
        /// <returns>�ַ���</returns>
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
        /// ��һ���ַ���ת��Ϊ�������͵�ֵ
        /// </summary>
        /// <param name="strData">��������ַ���</param>
        /// <param name="DefaultValue">��ת��ʧ���򷵻ص�Ĭ��ֵ</param>
        /// <returns>ת�����</returns>
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
        /// �ҵ�ָ���ַ�����һ���ַ����ֵĵ�һ�����
        /// </summary>
        /// <param name="strData">�ַ���</param>
        /// <param name="strFind">������Ҫ���ҵ��ַ���ɵ��ַ���</param>
        /// <returns>��һ�γ����ַ������,��δ�ҵ��򷵻�-1</returns>
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
        /// �ҵ���һ�γ��ֿհ��ַ���λ��
        /// </summary>
        /// <param name="strData">�ַ���</param>
        /// <returns>��һ�γ��ֿհ��ַ���λ��,��δ�ҵ��򷵻��ַ��ĳ���</returns>
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
        /// �ҵ���һ�γ��ֿհ��ַ���λ��
        /// </summary>
        /// <param name="strData">�ַ���</param>
        /// <param name="StartIndex">��ʼ���ҵ���ʼλ��</param>
        /// <returns>��һ�γ��ֿհ��ַ���λ��,��δ�ҵ��򷵻��ַ��ĳ���</returns>
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
        /// �ж�һ���ַ����Ƿ�ȫ���������ַ����
        /// </summary>
        /// <param name="strData">Ҫ���Ե��ַ���</param>
        /// <returns>��ȫ���������ַ�����򷵻�true ���򷵻�false ���ַ�������Ϊ��ʱҲ����false</returns>
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
        /// �ж�һ���ַ��������Ƿ��ǿ��ַ���
        /// </summary>
        /// <param name="strData">�ַ���</param>
        /// <returns>���ַ���Ϊ�ջ���ȫ���пհ��ַ�����򷵻�True,���򷵻�false</returns>
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
        /// �ж�һ���ַ����Ƿ�������,��������isBlankString�෴
        /// </summary>
        /// <param name="strData">�ַ�������</param>
        /// <returns>���ַ�����Ϊ���Ҵ��ڷǿհ��ַ��򷵻�True ���򷵻�False</returns>
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
        /// ��XML�ַ����������XSLT�ĵ����
        /// </summary>
        /// <param name="strXML">XML�ַ���</param>
        /// <returns>�����XSLT�ַ���</returns>
        public static string TransToXSLFrame(string strXML)
        {
            return "<xsl:stylesheet xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" version=\"1.0\"><xsl:template match=\"/*\">" + strXML + "</xsl:template></xsl:stylesheet>";
        }


        /// <summary>
        /// ����һ���ַ��������е��ַ�������ĸ��������
        /// </summary>
        /// <param name="strData">�����Ե��ַ���</param>
        /// <returns>���ַ��������ַ�������ĸ�������򷵻�true ,���򷵻� false</returns>
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
        /// �Ƿ���Ӣ����ĸ������
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsABC123(char c)
        {
            return c_ABC123CharList.IndexOf(c) >= 0 ? true : false;
        }
        /// <summary>
        /// �ж�һ���ַ����Ƿ�ȫ�����������ַ����
        /// </summary>
        /// <param name="strData">�����Ե��ַ���</param>
        /// <returns>���ַ����������ַ�δ�����򷵻�true,���򷵻�false</returns>
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
        /// ����ָ���ַ�������MD5��ֵ��16�����ַ���
        /// </summary>
        /// <param name="strData">�ַ�������</param>
        /// <returns>��д��MD5��16�����ַ���</returns>
        public static string GetMD5String(string strData)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider myMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytBuf = System.Text.Encoding.Unicode.GetBytes(strData);
            byte[] md5 = myMD5.ComputeHash(bytBuf, 0, bytBuf.Length);
            return ByteToHex(md5);
        }

        #region ���ַ�������16���ƻ�Base64�ı�����봦��*******************************************
        /// <summary>
        /// ��һ���ֽ���ֵת��Ϊһ��16�����ַ���
        /// </summary>
        /// <param name="bytBuf">�ֽ�����</param>
        /// <returns>16�����ַ���</returns>
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
        /// ���ַ���ת��ΪGB2312������16�����ַ���
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
        /// �ж�һ���ַ��ı����Ƿ�������Base64�ַ�
        /// </summary>
        /// <param name="intChar">�ַ���Ansi��Unicode����</param>
        /// <returns>�жϽ��</returns>
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
        /// ��ʽ��Base64�����ַ��������зָ�����
        /// </summary>
        /// <param name="strBase64">����Base64�����ַ���</param>
        /// <param name="GroupSize">һ�������ַ�����</param>
        /// <param name="LineGroupCount">ÿ���ı��ı��������</param>
        /// <returns>��ʽ������ַ���</returns>
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

        #region �û������ַ����ĺ���Ⱥ*************************************************************
        /// <summary>
        /// �ж�һ���ַ����Ƿ񾭹��û�����
        /// </summary>
        /// <param name="strData">ԭʼ�ַ���</param>
        /// <returns>�Ƿ񾭹��û�����</returns>
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
        /// ͨ���й��ɵ��û��ַ��������ַ�ԭ�е������������ַ���
        /// </summary>
        /// <param name="strSource">ԭʼ�ַ���</param>
        /// <param name="toEncrypt">�Ƿ���м��ܣ�True:�����ַ��� False:�����ַ���</param>
        /// <param name="bolHead">�Ƿ�����ܵı��ͷ</param>
        /// <returns>��������ַ���</returns>
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
        /// ͨ���û��ַ��ķ�ʽ�����ַ�����
        /// ��ԭʼ�ַ������е��ַ��й��ɵĴ����������ַ���
        /// </summary>
        /// <param name="myChar">�ַ�����</param>
        /// <param name="iStep">�û����ַ���ŵĲ���</param>
        /// <param name="iStep2">�û����ַ����</param>
        /// <param name="bolDirect">������</param>
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