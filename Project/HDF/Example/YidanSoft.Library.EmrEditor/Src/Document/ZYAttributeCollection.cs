using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 文档元素属性集合
    /// </summary>
    /// 
    [Serializable]
    public class ZYAttributeCollection : System.Collections.CollectionBase
    {
        private bool bolModified = false;
        public ZYTextElement OwnerElement;


        /// <summary>
        /// 属性集合的内容是否改变标志
        /// </summary>
        public bool Modified
        {
            get { return bolModified; }
            set { bolModified = value; }
        }


        /// <summary>
        /// 判断两个属性列表内容是否一样
        /// </summary>
        /// <param name="a">属性列表</param>
        /// <returns>两个属性列表内容是否一样</returns>
        public bool EqualsValue(ZYAttributeCollection a)
        {
            // if parameter can not convert to an ZYAttribute set 
            // or number of elements is not equals owner elements count
            // then return false
            if (a == null) return false;
            // share one reference , then return true
            if (a == this) return true;
            return (this.ToListString() == a.ToListString());
        }

        /// <summary>
        /// copy all attriute data to another attributeset
        /// </summary>
        /// <param name="descSet"></param>
        public void CopyTo(ZYAttributeCollection descSet)
        {
            descSet.List.Clear();
            foreach (ZYAttribute myAttr in this)
            {
                descSet.List.Add(myAttr.Clone());
            }
        }

        /// <summary>
        /// get attribute object has  specify name
        /// </summary>
        public ZYAttribute this[string strName]
        {
            get
            {
                foreach (ZYAttribute myAttr in this)
                    if (myAttr.Name == strName)
                        return myAttr;
                return null;
            }
        }

        /// <summary>
        /// 删除指定名称的属性
        /// </summary>
        /// <param name="strName"></param>
        public void RemoveAttribute(string strName)
        {
            ZYAttribute myAttr = this[strName];
            if (myAttr != null)
                this.List.Remove(myAttr);
        }

        protected override void OnClear()
        {
            base.OnClear();
            bolModified = true;
        }

        /// <summary>
        /// 是否包含指定名称的属性对象
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <returns>是否包含该名称的属性</returns>
        public bool Contains(string strName)
        {
            foreach (ZYAttribute myAttr in this)
            {
                if (myAttr.Name == strName)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 设置指定名称的属性值
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <param name="vValue">属性值</param>
        public void SetValue(string strName, object vValue)
        {
            ZYAttribute myValue = null;
            foreach (ZYAttribute myAttr in this)
            {
                if (myAttr.Name == strName)
                {
                    myValue = myAttr;
                    break;
                }
            }
            if (myValue == null)
            {
                myValue = new ZYAttribute();
                myValue.Name = strName;
                this.List.Add(myValue);
            }

            if (myValue.Value == null || myValue.Value.Equals(vValue) == false)
            {
                if (myValue.Value != null || vValue != null)
                {
                    if (OwnerElement != null && OwnerElement.OwnerDocument != null && OwnerElement.OwnerDocument.ContentChangeLog != null)
                    //if (OwnerElement != null && OwnerElement.OwnerDocument != null)
                    {
                        OwnerElement.OwnerDocument.ContentChangeLog.LogAttribute(
                            OwnerElement,
                            myValue,
                            vValue);

                        OwnerElement.OwnerDocument.Modified = true;
                    }
                    myValue.Value = vValue;
                    //if( myValue.Value == myValue.DefaultValue )myList.Remove( myValue );
                    bolModified = true;
                }
            }
        }

        /// <summary>
        /// 设置所有属性为默认值
        /// </summary>
        /// <returns>是否修改了数据</returns>
        public bool SetDefaultValue()
        {
            bool bolChange = false;
            foreach (ZYAttribute myAttr in this)
            {
                object DefaultValue = ZYAttribute.GetDefaultValue(myAttr.Name);
                if (DefaultValue != null && DefaultValue.Equals(myAttr.Value))
                {
                    if (OwnerElement != null && OwnerElement.OwnerDocument != null&& OwnerElement.OwnerDocument.ContentChangeLog != null)
                    {
                        OwnerElement.OwnerDocument.ContentChangeLog.LogAttribute(
                            OwnerElement,
                            myAttr,
                            DefaultValue);
                    }
                    myAttr.Value = DefaultValue;
                    bolModified = true;
                    bolChange = true;
                }
            }
            return bolChange;
        }

        /// <summary>
        /// 获得指定名称的布尔类型的属性值
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <returns>属性值</returns>
        public bool GetBool(string strName)
        {
            foreach (ZYAttribute myAttr in this)
            {
                if (myAttr.Name == strName)
                    return (bool)myAttr.Value;
            }
            return (bool)ZYAttribute.GetDefaultValue(strName);
        }
        /// <summary>
        /// 获得指定名称的整数类型的属性值
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <returns>属性值</returns>
        public int GetInt32(string strName)
        {
            try
            {
                foreach (ZYAttribute myAttr in this)
                {
                    if (myAttr.Name == strName)
                        return Convert.ToInt32(myAttr.Value);
                }
                return (int)ZYAttribute.GetDefaultValue(strName);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 获得指定名称的单精度浮点数类型的属性值
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <returns>属性值</returns>
        public float GetFloat(string strName)
        {
            try
            {
                foreach (ZYAttribute myAttr in this)
                {
                    if (myAttr.Name == strName)
                        return Convert.ToSingle(myAttr.Value);
                }
                return Convert.ToSingle(ZYAttribute.GetDefaultValue(strName));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 获得指定名称的字符串类型的属性值
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <returns>属性值</returns>
        public string GetString(string strName)
        {
            foreach (ZYAttribute myAttr in this)
            {
                if (myAttr.Name == strName)
                    return Convert.ToString(myAttr.Value);
            }
            return Convert.ToString(ZYAttribute.GetDefaultValue(strName));
        }

        /// <summary>
        /// 获得颜色值类型的指定名称的属性值
        /// </summary>
        /// <param name="strName">属性名称</param>
        /// <returns>属性值</returns>
        public System.Drawing.Color GetColor(string strName)
        {
            foreach (ZYAttribute myAttr in this)
                if (myAttr.Name == strName)
                    return (System.Drawing.Color)myAttr.Value;
            return System.Drawing.SystemColors.WindowText;
        }

        /// <summary>
        /// load attribute set from a xmlelement's attribute set
        /// </summary>
        /// <param name="myElement">xmlelement object</param>
        /// <returns>handle is ok</returns>
        public bool FromXML(System.Xml.XmlElement myElement)
        {
            // clear owner attribute set
            this.Clear();
            if (myElement == null) return false;
            // enumerate xmlelement's attribute set
            // for each xmlattribute create an attribute and add to owner attribute set
            foreach (System.Xml.XmlAttribute myXMLAttr in myElement.Attributes)
            {
                ZYAttribute myAttr = new ZYAttribute();
                myAttr.Name = myXMLAttr.Name;
                myAttr.ValueString = myXMLAttr.Value;
                if (myAttr.Value != myAttr.DefaultValue)
                    this.List.Add(myAttr);
            }
            bolModified = false;
            return true;
        }
        /// <summary>
        /// save owner attribute set's content to xmlelement's attribute set
        /// </summary>
        /// <param name="myElement">xmlelement object</param>
        /// <returns>Is handle ok</returns>
        public bool ToXML(System.Xml.XmlElement myElement)
        {
            // if xmlelement is null reference then return false
            if (myElement == null) return false;
            // enumerate owner attribute set 
            // for each attribute set xmlattribute 
            foreach (ZYAttribute myAttr in this)
            {
                //if (myAttr.isNeedSave())
                //{
                    string strValue = myAttr.ValueString;
                    if (strValue != null)
                        myElement.SetAttribute(myAttr.Name, myAttr.ValueString);
                //}
            }
            return true;
        }

        public string ToListString()
        {
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            foreach (ZYAttribute myAttr in this)
            {
                if (myAttr.isNeedSave())
                {
                    string strValue = myAttr.ValueString;
                    if (strValue != null)
                        myStr.Append(myAttr.Name + "=" + strValue);
                }
            }
            return myStr.ToString();
        }



        #region 编辑器默认字体大小动态可配时的回车符特殊处理 add by myc 2014-08-14
        ///// <summary>
        ///// 针对回车符的特殊处理，获得指定名称的单精度浮点数类型的属性值。
        ///// </summary>
        ///// <param name="strName">属性名称。</param>
        ///// <returns>属性值。</returns>
        //public float GetFloatByEnter(string strName)
        //{
        //    try
        //    {
        //        foreach (ZYAttribute myAttr in this)
        //        {
        //            if (myAttr.Name == strName)
        //                return Convert.ToSingle(myAttr.Value);
        //        }

        //        return YidanSoft.Library.EmrEditor.Src.Common.FontCommon.GetFontSizeByName("五号");
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //} 
        #endregion



    }//public class ZYAttributeCollection : System.Collections.CollectionBase
}
