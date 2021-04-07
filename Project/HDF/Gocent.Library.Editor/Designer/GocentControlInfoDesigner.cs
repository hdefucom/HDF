using System;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gocent.Library.Editor.Designer
{
    public class GocentControlInfoDesigner : ControlDesigner
    {
        /// <summary>
        /// 不允许在设计窗体使用鼠标拖动调整控件的高度
        /// </summary>
        //public override SelectionRules SelectionRules => SelectionRules.Moveable;



        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);

            var rect = new Rectangle(
                this.Control.ClientRectangle.X + 2,
                this.Control.ClientRectangle.Y + 2,
                this.Control.ClientRectangle.Width - 4,
                this.Control.ClientRectangle.Height - 4);

            //pe.Graphics.Clear(System.Windows.Forms.Control.DefaultBackColor);
            pe.Graphics.DrawRectangle(new Pen(Color.Black, 2f) { DashStyle = DashStyle.Dash, Alignment = PenAlignment.Inset }, rect);

            StringFormat format = new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
            };
            var assembly = this.Control.GetType().Assembly;
            var descript = this.Control.GetType().GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
            var info = $"{descript?.Description}{Environment.NewLine}【{assembly.GetName().Name}({assembly.GetName().Version})】{Environment.NewLine}{Environment.NewLine}程序集：{assembly.FullName}{Environment.NewLine}文件：{assembly.Location}";

            pe.Graphics.DrawString(info,
                                   this.Control.Font,
                                   new SolidBrush(this.Control.ForeColor),
                                   rect,
                                   format);
        }


    }
}
