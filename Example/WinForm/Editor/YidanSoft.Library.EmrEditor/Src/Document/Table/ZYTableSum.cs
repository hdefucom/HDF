using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document.Table
{
    public class ZYTableSum : ZYElement
    {
        /// <summary>
        /// 统计类型
        /// </summary>
        public enum SumType
        {
            /// <summary>
            /// 统计所在行
            /// </summary>
            [Description("统计所在行")]
            Row,
            /// <summary>
            /// 统计所在列
            /// </summary>
            [Description("统计所在列")]
            Column,
            /// <summary>
            /// 统计所在表格
            /// </summary>
            [Description("统计所在表格")]
            Table
        }

        /// <summary>
        /// 值类型
        /// </summary>
        public enum ValueType
        {
            /// <summary>
            /// 总和
            /// </summary>
            [Description("总和")]
            Sum,
            /// <summary>
            /// 平均数
            /// </summary>
            [Description("平均数")]
            Average,
            /// <summary>
            /// 数量
            /// </summary>
            [Description("数量")]
            Count
        }

        /// <summary>
        /// 统计类型
        /// </summary>
        public SumType ElementSumType { get; set; }
        /// <summary>
        /// 统计类型
        /// </summary>
        public ValueType ElementValueType { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public double Value { get; set; }


        public ZYTableSum()
        {
            this.Type = ElementType.TableSum;
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_TableSum;
        }


        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("code", this.Code);

                myElement.SetAttribute("sumtype", ((int)this.ElementSumType).ToString());
                myElement.SetAttribute("valuetype", ((int)this.ElementValueType).ToString());

                myElement.InnerText = this.Value.ToString();
                return true;
            }
            return false;
        }


        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Attributes.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");
                this.Code = myElement.GetAttribute("code");

                this.ElementSumType = (SumType)Convert.ToInt32(myElement.GetAttribute("sumtype"));
                this.ElementValueType = (ValueType)Convert.ToInt32(myElement.GetAttribute("valuetype"));

                this.Value = Convert.ToDouble(myElement.InnerText);
                return true;
            }
            return false;
        }

        public override string ToEMRString()
        {
            return this.Value.ToString();
        }

        public override bool isTextElement()
        {
            return true;
        }


        public override bool RefreshSize()
        {
            if (this.Parent.Parent is TPTextCell)
            {
                var cell = this.Parent.Parent as TPTextCell;
                var row = cell.Parent as TPTextRow;
                if (row == null)
                    return false;
                int isdoublecell = 0;
                Func<TPTextCell, double> getval = c =>
                {
                    StringBuilder builder = new StringBuilder();
                    c.GetFinalText(builder);
                    double v = 0;
                    if (double.TryParse(builder.ToString(), out v))
                        isdoublecell++;
                    return v;
                };

                List<TPTextCell> cells = new List<TPTextCell>();
                switch (this.ElementSumType)
                {
                    case SumType.Row:
                        cells = row.Cells.Where(c => c != cell).ToList();
                        break;
                    case SumType.Column:
                        var index = row.Cells.IndexOf(cell);
                        cells = row.OwnerTable.AllRows.Select(r => r.Cells[index]).Where(c => c != cell).ToList();
                        break;
                    case SumType.Table:
                        row.OwnerTable.AllRows.ForEach(r => cells.AddRange(r.Cells.Where(c => c != cell)));
                        //.Sum(r => r.Cells.Where(c => c != cell).Sum(getval));
                        break;
                    default:
                        break;
                }


                switch (this.ElementValueType)
                {
                    case ValueType.Sum:
                        this.Value = cells.Sum(getval);
                        break;
                    case ValueType.Average:
                        this.Value = cells.Sum(getval) / isdoublecell;
                        break;
                    case ValueType.Count:
                        cells.Sum(getval);
                        this.Value = isdoublecell;
                        break;
                    default:
                        break;
                }


            }



            SizeF size1 = OwnerDocument.View.Graph.MeasureString(this.Value.ToString(), this.Font, int.MaxValue, strFormat);

            this.Width = (int)size1.Width;
            this.Height = (int)Math.Ceiling(size1.Height);
            return true;
        }
        public override bool RefreshView()
        {
            this.RefreshSize();
            Rectangle r = this.Bounds;

            if (!this.OwnerDocument.Info.Printing && !this.OwnerDocument.OwnerControl.bolLockingUI)
            {
                Pen p = new Pen(this.ForeColor, 1f);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                p.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
                OwnerDocument.View.Graph.FillRectangle(new SolidBrush(ZYEditorControl.ElementBackColor), r.Left, r.Top, this.Width, this.Height);
            }

            OwnerDocument.View.Graph.DrawString(this.Value.ToString(), this.Font, Brushes.Black, r.Left, r.Top, strFormat);

            return true;
        }





    }






}
