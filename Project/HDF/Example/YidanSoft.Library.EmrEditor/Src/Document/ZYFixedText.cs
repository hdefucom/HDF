using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYFixedText : ZYTextBlock
    {
        public ZYFixedText()
        {
            this.Type = ElementType.FixedText;
            this.CanDelete = true;//2019.08.08xll 默认可删除
        }

        Level? level = null;

        public Level? Level
        {
            get { return level; }
            set 
            { 
                level = value; 
            //根据不同层次，设置不同大小,这样太智能了可能并不是用户想需要的，
                if (value != null)
                {
                    //this.Attributes.SetValue(ZYTextConst.c_FontSize, 21 - (int)value);
                    //this.Attributes.SetValue(ZYTextConst.c_FontBold, true);
                    this.Text = this.Text;
                }
            }
        }

        /// <summary>
        /// 辅助决策
        /// </summary>
        public bool AssistDecision = false;

        public bool Print = true;

        public override string GetXMLName()
        {
            return ZYTextConst.c_RoElement;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {

            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("level", this.Level.ToString());
                myElement.SetAttribute("print", this.Print.ToString());
                myElement.SetAttribute("assistDecision", this.AssistDecision.ToString());
                myElement.SetAttribute("candelete", this.CanDelete.ToString());//2019.07.10-hdf：添加是否能删除属性

                myElement.InnerText = this.Text;
                return true;
                //return base.ToXML(myElement);
            }
            return false;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {


            if (myElement != null)
            {

                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                //value应该在设置Attributes之前
                string level = myElement.GetAttribute("level");
                if (level.Length == 0)
                {
                    this.Level = null;
                }
                else
                {
                    this.Level = (Level?)Enum.Parse(typeof(Level), level);
                }
                this.Attributes.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");

                if (myElement.HasAttribute("print"))
                {
                    this.Print = bool.Parse(myElement.GetAttribute("print"));
                }
                if (myElement.HasAttribute("assistDecision"))
                {
                    this.AssistDecision = bool.Parse(myElement.GetAttribute("assistDecision"));
                }
                //2019.07.10-hdf：添加是否能删除属性
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                } 
                this.Text = myElement.InnerText;
                return true;
            }
            return false;
        }

        
    }
}
